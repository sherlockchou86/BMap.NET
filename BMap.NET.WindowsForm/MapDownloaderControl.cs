using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMap.NET.WindowsForm.BMapElements;
using System.Drawing.Drawing2D;
using BMap.NET.HTTPService;
using Newtonsoft.Json.Linq;
using BMap.NET.WindowsForm.FunctionalControls;
using BMap.NET.WindowsForm.DrawingObjects;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// 百度地图显示控件
    /// </summary>
    public partial class MapDownloaderControl : UserControl
    {
        private const double DISTANCE = 111319.49; //每（经纬）度距离m

        #region 属性
        private LatLngPoint _center = new LatLngPoint(117.217412, 39.142191);   //天津
        /// <summary>
        /// 地图显示中心经纬度坐标
        /// </summary>
        [Description("地图中心点"), Category("BMap.NET")]
        public LatLngPoint Center
        {
            get
            {
                return _center;
            }
            set
            {
                _center = value;
            }
        }
        private int _zoom = 12;
        /// <summary>
        /// 地图缩放级别(3-18)
        /// </summary>
        [Description("当前地图缩放级别"), Category("BMap.NET")]
        public int Zoom
        {
            get
            {
                return _zoom;
            }
            set
            {
                _zoom = value;
                _tiles.Clear();
                Invalidate();
            }
        }
        private MapMode _mode = MapMode.Normal;
        /// <summary>
        /// 地图模式
        /// </summary>
        [Description("当前地图模式"), Category("BMap.NET")]
        public MapMode Mode
        {
            get
            {
                return _mode;
            }
            set
            {
                _mode = value;
                foreach (KeyValuePair<string, BTile> p in _tiles)
                {
                    p.Value.Mode = _mode;
                }
                Invalidate();
            }
        }
        private LoadMapMode _loadmode = LoadMapMode.Cache;
        /// <summary>
        /// 地图加载模式
        /// </summary>
        [Description("当前地图加载模式"), Category("BMap.NET")]
        public LoadMapMode LoadMode
        {
            get
            {
                return _loadmode;
            }
            set
            {
                _loadmode = value;
                foreach (KeyValuePair<string, BTile> p in _tiles)
                {
                    p.Value.LoadMode = _loadmode;
                }
                Invalidate();
            }
        }
        #endregion

        #region 字段

        /// <summary>
        /// 当前光标
        /// </summary>
        private Cursor _current_cursor_cache = Cursors.Arrow;
        /// <summary>
        /// 地图中提示
        /// </summary>
        private Label _toolTip = new Label();

        /// <summary>
        /// 鼠标是否定位
        /// </summary>
        private bool _cursor_located = false;
        /// <summary>
        /// 鼠标移动前一点缓存
        /// </summary>
        private Point _previous_point_cache;
        /// <summary>
        /// 鼠标工作方式
        /// </summary>
        private MouseType _mouse_type = MouseType.None;
        /// <summary>
        /// 当前绘制图形  没有则为null(包括截图矩形)
        /// </summary>
        private DrawingObject _current_drawing;
        /// <summary>
        /// 地图中瓦片容器
        /// </summary>
        private Dictionary<string, BTile> _tiles = new Dictionary<string, BTile>();
        /// <summary>
        /// 地图中普通信息点（POI）容器
        /// </summary>
        private Dictionary<string, BPOI> _pois = new Dictionary<string, BPOI>();
        /// <summary>
        /// 绘制图形容器
        /// </summary>
        private Dictionary<int, DrawingObject> _drawingObjects = new Dictionary<int, DrawingObject>();
        /// <summary>
        /// 地图中用户添加的标记点
        /// </summary>
        private Dictionary<string, BMarker> _markers = new Dictionary<string, BMarker>();
        /// <summary>
        /// POI信息显示控件
        /// </summary>
        private BPOITipControl _bPOITipControl = new BPOITipControl();
        /// <summary>
        /// 标记点信息编辑控件
        /// </summary>
        private BMarkerEditorControl _bMarkerEditorControl = new BMarkerEditorControl();
        /// <summary>
        /// 标记点信息显示控件
        /// </summary>
        private BMarkerTipControl _bMarkerTipControl = new BMarkerTipControl();
        /// <summary>
        /// 位置点信息显示控件
        /// </summary>
        private BPointTipControl _bPointTipControl = new BPointTipControl();
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public MapDownloaderControl()
        {
            InitializeComponent();
            //绘制双缓冲
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }

        #region 重写方法
        /// <summary>
        /// 控件加载
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Init();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            //拖拽
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // 拖拽地图
                _mouse_type = MouseType.DragMap;
                _current_cursor_cache = Cursor = Cursors.SizeAll;
                _previous_point_cache = e.Location;

                //拖拽区域

            }

            //绘制区域
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _current_drawing = new BDownloadRectangle { LeftTop = e.Location, Width = 0, Height = 0 };
                _mouse_type = MouseType.DrawDownloadArea;
                _current_cursor_cache = Cursor = Cursors.Cross;
                _previous_point_cache = e.Location;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (_mouse_type == MouseType.DragMap)  //拖拽地图
                {
                    int deltax = e.Location.X - _previous_point_cache.X;
                    int deltay = e.Location.Y - _previous_point_cache.Y;
                    LatLngPoint llp = MapHelper.GetLatLngByScreenLocation(new Point(ClientSize.Width / 2 - deltax, ClientSize.Height / 2 - deltay), _center, _zoom, ClientSize);
                    Center = llp;
                    _previous_point_cache = e.Location;
                }
                //
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (_mouse_type == MouseType.DrawDownloadArea && _current_drawing as BDownloadRectangle != null) //绘制截图矩形
                {
                    (_current_drawing as BDownloadRectangle).Width = e.Location.X - (_current_drawing as BDownloadRectangle).LeftTop.X;
                    (_current_drawing as BDownloadRectangle).Height = e.Location.Y - (_current_drawing as BDownloadRectangle).LeftTop.Y;
                }
            }
            Invalidate();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (_mouse_type == MouseType.DragMap)  //拖动地图 鼠标弹起
            {
                
            }
            if (_mouse_type == MouseType.DrawDownloadArea)  //绘制下载区域 弹起鼠标
            {
                BDownloadRectangle d = _current_drawing as BDownloadRectangle;
                if (d != null)
                {
                    LatLngPoint left_down = MapHelper.GetLatLngByScreenLocation(new Point(d.LeftTop.X, d.LeftTop.Y + d.Height), _center, _zoom, ClientSize);
                    LatLngPoint right_up = MapHelper.GetLatLngByScreenLocation(new Point(d.LeftTop.X + d.Width, d.LeftTop.Y), _center, _zoom, ClientSize);

                    using (MapDownloadDialog dlg = new MapDownloadDialog(left_down, right_up))
                    {
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {

                        }

                        _current_drawing = null;
                        Invalidate();
                    }
                }
            }
            _current_cursor_cache = Cursor = Cursors.Arrow;
            _mouse_type = MouseType.None;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            //缩放
            int z = _zoom + e.Delta / 100;
            if (z >= 3 && z <= 19)
            {
                LatLngPoint p = MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize);  //鼠标经纬度坐标
                PointF pt = MapHelper.GetLocationByLatLng(p, z);  //鼠标像素坐标
                PointF pt_center = new PointF(pt.X + (ClientSize.Width / 2 - e.Location.X), pt.Y + (e.Location.Y - ClientSize.Height / 2)); //缩放后中心点像素坐标

                LatLngPoint p_center = MapHelper.GetLatLngByLocation(pt_center, z); //像素坐标到经纬度坐标
                Center = p_center;

                Zoom = z;
                Invalidate();
            }
        }
        /// <summary>
        /// 地图重绘
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!DesignMode)  //所有绘制工作均在运行时发生
            {
                //瓦片
                DrawTiles(e.Graphics);
                //绘制图形
                DrawDrawingObjects(e.Graphics);

                //地图元素
                DrawMapElements(e.Graphics);
                //地图信息
                DrawMapInfo(e.Graphics);
            }
        }
        #endregion

        #region 功能方法
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            if (!DesignMode)
            {

            }
        }

        /// <summary>
        /// 初始化瓦片
        /// </summary>
        private void InitializeTiles()
        {
            PointF center = MapHelper.GetLocationByLatLng(_center, _zoom); //中心点像素坐标
            PointF left_down = new PointF(center.X - ClientSize.Width / 2, center.Y - ClientSize.Height / 2); //左下角像素坐标
            PointF right_up = new PointF(center.X + ClientSize.Width / 2, center.Y + ClientSize.Height / 2); //右上角像素坐标

            int tile_left_down_x = (int)Math.Floor((left_down.X) / 256);  //左下角瓦片X坐标
            int tile_left_down_y = (int)Math.Floor((left_down.Y) / 256);  //左下角瓦片Y坐标
            int tile_right_up_x = (int)Math.Floor((right_up.X) / 256);    //右上角瓦片X坐标
            int tile_right_up_y = (int)Math.Floor((right_up.Y) / 256);    //右上角瓦片Y坐标

            for (int i = tile_left_down_x; i <= tile_right_up_x; ++i)
            {
                for (int j = tile_left_down_y; j <= tile_right_up_y; ++j)
                {
                    if (!_tiles.ContainsKey(_zoom + "_" + i + "_" + j))
                    {
                        _tiles.Add(_zoom + "_" + i + "_" + j, new BTile(i, j, _zoom, this, _mode, _loadmode));
                    }
                }
            }
        }

        /// <summary>
        /// 绘制瓦片 
        /// </summary>
        /// <param name="g"></param>
        private void DrawTiles(Graphics g)
        {
            InitializeTiles();
            foreach (KeyValuePair<string, BTile> p in _tiles)
            {
                if (p.Key.StartsWith(_zoom.ToString()))
                {
                    p.Value.Draw(g, _center, _zoom, this.ClientSize);
                }
            }
        }
        /// <summary>
        /// 绘制地图左下角的一些附加信息 如当前坐标、地图级别、logo、版权等
        /// </summary>
        /// <param name="g"></param>
        private void DrawMapInfo(Graphics g)
        {
            using (GraphicsPath gp = MapHelper.CreateRoundedRectanglePath(new Rectangle(10, Height - 100, 250, 90), 6))
            {
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(180, Color.White)))
                {
                    g.FillPath(sb, gp);
                    g.DrawPath(Pens.Black, gp);
                    using (Font f = new Font("微软雅黑", 11))
                    {
                        g.DrawString(MapHelper.GetMapModeTitle(_mode) + "，" + _zoom + "级，" + MapHelper.GetLoadMapModeTitle(_loadmode), f, Brushes.Teal, new PointF(20, Height - 100 + 10));
                        Point p = PointToClient(Cursor.Position);
                        if (ClientRectangle.Contains(p))
                        {
                            LatLngPoint llp = MapHelper.GetLatLngByScreenLocation(p, _center, _zoom, ClientSize); //当前鼠标经纬度
                            g.DrawString(Math.Round(llp.Lat, 5) + "，" + Math.Round(llp.Lng, 5), f, Brushes.Teal, new PointF(20, Height - 100 + 35));
                        }
                        g.DrawString("BMap.NET 2015 by 周见智", f, Brushes.Teal, new PointF(20, Height - 100 + 60));
                    }
                }
            }
        }

        /// <summary>
        /// 绘制鼠标效果
        /// </summary>
        /// <param name="g"></param>
        private void DrawCursor(Graphics g)
        {
            Point p = PointToClient(Cursor.Position);
            if (ClientRectangle.Contains(p))
            {
                if (_cursor_located)  //鼠标定位效果
                {
                    using (Pen pen = new Pen(Color.FromArgb(200, _mode == MapMode.Normal ? Color.Blue : Color.White), 2))
                    {
                        pen.DashStyle = DashStyle.Dash;
                        g.DrawLine(pen, new Point(0, p.Y), new Point(ClientSize.Width, p.Y));
                        g.DrawLine(pen, new Point(p.X, 0), new Point(p.X, ClientSize.Height));
                    }
                }
                if (_mouse_type == MouseType.DrawMarker)  //鼠标绘制标记效果
                {
                    Bitmap b = Properties.BMap.ico_marker;
                    g.DrawImage(b, new Rectangle(p.X - b.Width / 2, p.Y - b.Height, b.Width, b.Height));
                }
            }
        }
        /// <summary>
        /// 绘制图形
        /// </summary>
        /// <param name="g"></param>
        private void DrawDrawingObjects(Graphics g)
        {
            if (_current_drawing != null)
            {
                _current_drawing.Draw(g, _center, _zoom, ClientSize);
            }
            foreach (KeyValuePair<int, DrawingObject> p in _drawingObjects)
            {
                p.Value.Draw(g, _center, _zoom, ClientSize);
            }
        }
        /// <summary>
        /// 绘制地图元素
        /// </summary>
        /// <param name="g"></param>
        private void DrawMapElements(Graphics g)
        {

        }
        #endregion

        #region 公开方法
        /// <summary>
        /// 向地图中增加POI
        /// </summary>
        /// <param name="places"></param>
        internal void AddPlaces(List<BPOI> places)
        {
            _pois.Clear();
            _bPointTipControl.Visible = false;
            _bPOITipControl.Visible = false;
            _bMarkerEditorControl.Visible = false;
            _bMarkerTipControl.Visible = false;
            foreach (BPOI poi in places)
            {
                _pois.Add(poi.Index.ToString(), poi);
            }
            Invalidate();
        }
        /// <summary>
        /// 清空地图中所有的POI
        /// </summary>
        internal void ClearPlaces()
        {
            _pois.Clear();
            _bPointTipControl.Visible = false;
            _bPOITipControl.Visible = false;
            _bMarkerEditorControl.Visible = false;
            _bMarkerTipControl.Visible = false;
            Invalidate();
        }
        /// <summary>
        /// 刷新瓦片，该方法会删除瓦片缓存
        /// </summary>
        public void RefreshTitles()
        {
            HTTPService.MapService mapService = new HTTPService.MapService();
            mapService.ClearTileCache();

            _tiles.Clear();

            Invalidate();
        }
        #endregion

        #region 事件处理方法

        #endregion
    }
}
