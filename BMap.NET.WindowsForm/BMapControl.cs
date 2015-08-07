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
    public partial class BMapControl : UserControl
    {
        private const double DISTANCE = 111319.49; //每（经纬）度距离m

        #region 属性
        private LatLngPoint _center = new LatLngPoint(0, 0); 
        /// <summary>
        /// 地图显示中心经纬度坐标
        /// </summary>
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
        public LoadMapMode LoadMode
        {
            get
            {
                return _loadmode;
            }
            set
            {
                _loadmode = value;
                foreach(KeyValuePair<string,BTile> p in _tiles)
                {
                    p.Value.LoadMode = _loadmode;
                }
                Invalidate();
            }
        }

        //关联控件
        /// <summary>
        /// 与之关联的位置输入框
        /// </summary>
        public BPlaceBox BPlaceBox
        {
            get;
            set;
        }
        /// <summary>
        /// 与之关联的位置列表控件
        /// </summary>
        public BPlacesBoard BPlacesBoard
        {
            set;
            get;
        }
        /// <summary>
        /// 导航控件
        /// </summary>
        public BDirectionBoard BDirectionBoard
        {
            get;
            set;
        }
        #endregion

        #region 字段
        /// <summary>
        /// 快速搜索控件
        /// </summary>
        private BQuickSearchControl _bQuickSearchControl = new BQuickSearchControl();
        /// <summary>
        /// 截图菜单
        /// </summary>
        private BScreenshotMenu _bScreenshotMenu = new BScreenshotMenu();
        /// <summary>
        /// 当前光标
        /// </summary>
        private Cursor _current_cursor_cache = Cursors.Arrow;
        /// <summary>
        /// 地图中提示
        /// </summary>
        private Label _toolTip = new Label();
        /// <summary>
        /// 地图加载模式选择控件
        /// </summary>
        private BLoadMapModeControl _bLoadMapModeControl = new BLoadMapModeControl();
        /// <summary>
        /// 显示路网复选框
        /// </summary>
        private CheckBox _chkShowRoadNet = new CheckBox();
        /// <summary>
        /// 城市切换控件
        /// </summary>
        private BCityControl _bCityControl = new BCityControl();
        /// <summary>
        /// 当前城市
        /// </summary>
        private string _currentCity = "";
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
        /// 地图中唯一的搜索区域矩形（没有则为null）
        /// </summary>
        private BBound _b_bound;
        /// <summary>
        /// 地图中唯一的附近区域（没有则为null）
        /// </summary>
        private BNearBy _b_nearby;
        /// <summary>
        /// 地图中唯一测量线条（没有则为null）
        /// </summary>
        private BDistance _b_distance;
        /// <summary>
        /// 地图中唯一路线（没有则为null）
        /// </summary>
        private BRoute _b_route;
        /// <summary>
        /// 当前绘制图形  没有则为null(包括截图矩形)
        /// </summary>
        private DrawingObject _current_drawing;
        /// <summary>
        /// 地图中瓦片容器
        /// </summary>
        private Dictionary<string, BTile> _tiles = new Dictionary<string, BTile>();
        /// <summary>
        /// 地图中信息点（POI）容器
        /// </summary>
        private Dictionary<string, BPOI> _pois = new Dictionary<string, BPOI>();
        /// <summary>
        /// 绘制图形容器
        /// </summary>
        private Dictionary<int, DrawingObject> _drawingObjects = new Dictionary<int, DrawingObject>();
        /// <summary>
        /// 地图中添加的标记
        /// </summary>
        private Dictionary<string, BPOI> _marks = new Dictionary<string, BPOI>();
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public BMapControl()
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
                //鼠标定位效果
                DrawCursor(e.Graphics);
                //地图元素
                DrawMapElements(e.Graphics);
                //地图信息
                DrawMapInfo(e.Graphics);
                //当前城市
                DrawCurrentCity(e.Graphics);
                //工具栏
                DrawToolsBar(e.Graphics);
            }
        }
        /// <summary>
        /// 鼠标在地图上按下
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Left) //左键
            {
                //检查设置鼠标工作方式
                if (new Rectangle(Width - 384 + 26 * 8, 10, 26, 26).Contains(PointToClient(Cursor.Position))) //鼠标定位
                {
                    _cursor_located = !_cursor_located;
                    Invalidate();
                    return;
                }
                else if (new Rectangle(Width - 384 + 26 * 7, 10, 26, 26).Contains(PointToClient(Cursor.Position))) //绘制多边形
                {
                    if (_mouse_type == MouseType.DrawPolygon)
                    {
                        _mouse_type = MouseType.None;
                        _current_cursor_cache = Cursor = Cursors.Arrow;
                    }
                    else
                    {
                        _mouse_type = MouseType.DrawPolygon;
                        _current_cursor_cache = Cursor = Cursors.Cross;  //特定光标
                        _current_drawing = null;
                        _bScreenshotMenu.Visible = false;
                    }
                    Invalidate();
                    return;
                }
                else if (new Rectangle(Width - 384 + 26 * 6, 10, 26, 26).Contains(PointToClient(Cursor.Position))) //绘制直线
                {
                    if (_mouse_type == MouseType.DrawLine)
                    {
                        _mouse_type = MouseType.None;
                        _current_cursor_cache = Cursor = Cursors.Arrow;
                    }
                    else
                    {
                        _mouse_type = MouseType.DrawLine;
                        _current_cursor_cache = Cursor = Cursors.Cross;  //特定光标
                        _current_drawing = null;
                        _bScreenshotMenu.Visible = false;
                    }
                    Invalidate();
                    return;
                }
                else if (new Rectangle(Width - 384 + 26 * 5, 10, 26, 26).Contains(PointToClient(Cursor.Position))) //绘制椭圆
                {
                    if (_mouse_type == MouseType.DrawCircle)
                    {
                        _mouse_type = MouseType.None;
                        _current_cursor_cache = Cursor = Cursors.Arrow;
                    }
                    else
                    {
                        _mouse_type = MouseType.DrawCircle;
                        _current_cursor_cache = Cursor = Cursors.Cross;  //特定光标
                        _current_drawing = null;
                        _bScreenshotMenu.Visible = false;
                    }
                    Invalidate();
                    return;
                }
                else if (new Rectangle(Width - 384 + 26 * 4, 10, 26, 26).Contains(PointToClient(Cursor.Position))) //绘制矩形
                {
                    if (_mouse_type == MouseType.DrawRectange)
                    {
                        _mouse_type = MouseType.None;
                        _current_cursor_cache = Cursor = Cursors.Arrow;
                    }
                    else
                    {
                        _mouse_type = MouseType.DrawRectange;
                        _current_cursor_cache = Cursor = Cursors.Cross;  //特定光标
                        _current_drawing = null;
                        _bScreenshotMenu.Visible = false;
                    }
                    Invalidate();
                    return;
                }
                else if (new Rectangle(Width - 384 + 26 * 3, 10, 26, 26).Contains(PointToClient(Cursor.Position))) //添加标记点
                {
                    if (_mouse_type == MouseType.DrawMarker)
                    {
                        _mouse_type = MouseType.None;
                        _current_cursor_cache = Cursor = Cursors.Arrow;
                    }
                    else
                    {
                        _mouse_type = MouseType.DrawMarker;
                        _current_cursor_cache = Cursor = Cursors.Cross;  //特定光标
                        _current_drawing = null;
                        _bScreenshotMenu.Visible = false;
                    }
                    Invalidate();
                    return;
                }
                else if (new Rectangle(Width - 384 + 26 * 2, 10, 26, 26).Contains(PointToClient(Cursor.Position))) //截图
                {
                    if (_current_drawing as BScreenShotRectangle == null)
                    {
                        if (_mouse_type == MouseType.DrawScreenshotArea)
                        {
                            _mouse_type = MouseType.None;
                            _current_cursor_cache = Cursor = Cursors.Arrow;
                        }
                        else
                        {
                            _mouse_type = MouseType.DrawScreenshotArea;
                            _current_cursor_cache = Cursor = Cursors.Cross;  //特定光标
                        }
                        Invalidate();
                    }
                    return;
                }
                else if (new Rectangle(Width - 384 + 26 * 1, 10, 26, 26).Contains(PointToClient(Cursor.Position))) //测量距离
                {
                    if (_b_distance == null)
                    {
                        if (_mouse_type == MouseType.DrawDistance)
                        {
                            _mouse_type = MouseType.None;
                            _current_cursor_cache = Cursor = Cursors.Arrow;
                        }
                        else
                        {
                            _mouse_type = MouseType.DrawDistance;
                            _current_cursor_cache = Cursor = Cursors.Cross;  //特定光标
                            _current_drawing = null;
                            _bScreenshotMenu.Visible = false;
                        }
                        Invalidate();
                    }
                    else
                    {
                        _b_distance = null;
                    }
                    return;
                }
                else if (new Rectangle(Width - 384, 10, 26, 26).Contains(PointToClient(Cursor.Position))) //矩形区域搜索
                {
                    if (_b_bound == null)
                    {
                        if (_mouse_type == MouseType.DrawBound)
                        {
                            _mouse_type = MouseType.None;
                            _current_cursor_cache = Cursor = Cursors.Arrow;
                        }
                        else
                        {
                            _mouse_type = MouseType.DrawBound;
                            _current_cursor_cache = Cursor = Cursors.Cross;  //特定光标
                            _current_drawing = null;
                            _bScreenshotMenu.Visible = false;
                        }
                        Invalidate();
                    }
                    else
                    {
                        _b_bound = null;
                        _bQuickSearchControl.Visible = false;
                    }
                    return;
                }
                if (new Rectangle(10, 10, 90, 25).Contains(e.Location))  //打开城市切换窗体
                {
                    if (_bCityControl.Visible)
                    {
                        _bCityControl.Visible = false;
                    }
                    else
                    {
                        _bCityControl.Location = new Point(10, 38);
                        _bCityControl.Visible = true;
                        _bCityControl.CurrentCity = _currentCity;
                    }
                    Invalidate();
                    return;
                }
                else if (new Rectangle(Width - 124, 10, 52, 52).Contains(e.Location)) //打开地图加载模式窗体
                {
                    if (_bLoadMapModeControl.Visible)
                    {
                        _bLoadMapModeControl.Visible = false;
                    }
                    else
                    {
                        _bLoadMapModeControl.Location = new Point(Width - 124 + 52 - _bLoadMapModeControl.Width, 10 + 55);
                        _bLoadMapModeControl.LoadMode = _loadmode;
                        _bLoadMapModeControl.Visible = true;
                    }
                    Invalidate();
                    return;
                }
                else if (new Rectangle(Width - 62, 10, 52, 52).Contains(e.Location)) //切换地图模式
                {
                    if (_mode == MapMode.Normal)
                    {
                        if (_chkShowRoadNet.Checked)
                        {
                            Mode = MapMode.Sate_RoadNet;
                        }
                        else
                        {
                            Mode = MapMode.Satellite;
                        }
                        _chkShowRoadNet.Location = new Point(Width - 62, 65);
                        _chkShowRoadNet.Visible = true;
                    }
                    else
                    {
                        Mode = MapMode.Normal;
                        _chkShowRoadNet.Visible = false;
                    }
                    return;
                }


                if (_mouse_type == MouseType.None)  //拖拽地图
                {
                    //判断是否拖拽其他物体 地图优先级最低
                    if (_current_drawing as BScreenShotRectangle != null)  //拖拽截图矩形
                    {
                        if ((_current_drawing as BScreenShotRectangle).Rect.Contains(e.Location))
                        {
                            _mouse_type = MouseType.DragScreenshotArea;
                            _current_cursor_cache = Cursor = Cursors.SizeAll;
                            _previous_point_cache = e.Location;
                            return;
                        }
                    }
                    _bCityControl.Visible = false;
                    _bLoadMapModeControl.Visible = false;
                    _mouse_type = MouseType.DragMap;
                    _current_cursor_cache = Cursor = Cursors.SizeAll;
                    _previous_point_cache = e.Location;
                }
                else if (_mouse_type == MouseType.DrawCircle)  //绘制椭圆
                {
                    LatLngPoint theCenter = MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize);
                    _current_drawing = new BCircle { Center = theCenter, RightBottom = theCenter };
                }
                else if (_mouse_type == MouseType.DrawRectange) //绘制矩形
                {
                    LatLngPoint leftTop = MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize);
                    _current_drawing = new BRectangle { LeftTop = leftTop, RightBottom = leftTop };
                }
                else if (_mouse_type == MouseType.DrawLine)  //绘制直线
                {
                    LatLngPoint p = MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize);
                    if (_current_drawing == null)
                    {
                        _current_drawing = new BLine { Points = new List<LatLngPoint> { p, p } };
                    }
                    (_current_drawing as BLine).Points.Add(p);
                }
                else if (_mouse_type == MouseType.DrawPolygon)  //绘制多边形
                {
                    LatLngPoint p = MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize);
                    if (_current_drawing == null)
                    {
                        _current_drawing = new BPolygon { Points = new List<LatLngPoint> { p, p } };
                    }
                    (_current_drawing as BPolygon).Points.Add(p);
                }
                else if (_mouse_type == MouseType.DrawScreenshotArea)  //绘制截图区域
                {
                    _current_drawing = new BScreenShotRectangle { LeftTop = e.Location, Width = 0, Height = 0 };
                }
                else if (_mouse_type == MouseType.DrawBound)  //矩形搜索开始
                {
                    LatLngPoint leftTop = MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize);
                    _b_bound = new BBound { LeftTop = leftTop, RightBottom = leftTop };
                }
                else if (_mouse_type == MouseType.DrawDistance) //距离测量
                {
                    LatLngPoint p = MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize);
                    if (_b_distance == null)
                    {
                        _b_distance = new BDistance { Points = new List<LatLngPoint> { p, p } };
                    }
                    _b_distance.Points.Add(p);
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)  //右键弹菜单
            {
                cm_popup.Show(PointToScreen(e.Location));
            }
        }
        /// <summary>
        /// 鼠标在地图上移动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            //提示信息
            if (new Rectangle(Width - 62, 10, 52, 52).Contains(PointToClient(Cursor.Position)))
            {
                _toolTip.Text = "切换地图模式";
                _toolTip.Location = new Point(Width - 10 - _toolTip.Width, 65 + 25);
                _toolTip.Visible = true;
            }
            else if (new Rectangle(Width - 62 - 62, 10, 52, 52).Contains(PointToClient(Cursor.Position)))
            {
                _toolTip.Text = "切换加载模式";
                _toolTip.Location = new Point(Width - 62 - 62 - _toolTip.Width, 62 - _toolTip.Height);
                _toolTip.Visible = true;
            }
            else if (new Rectangle(Width - 384, 10, 26, 26).Contains(PointToClient(Cursor.Position)))
            {
                _toolTip.Text = "区域搜索";
                _toolTip.Location = new Point(Width - 384, 36 + 10);
                _toolTip.Visible = true;
            }
            else if (new Rectangle(Width - 384 + 26 * 1, 10, 26, 26).Contains(PointToClient(Cursor.Position)))
            {
                _toolTip.Text = "距离测量";
                _toolTip.Location = new Point(Width - 384 + 26 * 1, 36 + 10);
                _toolTip.Visible = true;
            }
            else if (new Rectangle(Width - 384 + 26 * 2, 10, 26, 26).Contains(PointToClient(Cursor.Position)))
            {
                _toolTip.Text = "截图";
                _toolTip.Location = new Point(Width - 384 + 26 * 2, 36 + 10);
                _toolTip.Visible = true;
            }
            else if (new Rectangle(Width - 384 + 26 * 3, 10, 26, 26).Contains(PointToClient(Cursor.Position)))
            {
                _toolTip.Text = "标记";
                _toolTip.Location = new Point(Width - 384 + 26 * 3, 36 + 10);
                _toolTip.Visible = true;
            }
            else if (new Rectangle(Width - 384 + 26 * 4, 10, 26, 26).Contains(PointToClient(Cursor.Position)))
            {
                _toolTip.Text = "绘制矩形";
                _toolTip.Location = new Point(Width - 384 + 26 * 4, 36 + 10);
                _toolTip.Visible = true;
            }
            else if (new Rectangle(Width - 384 + 26 * 5, 10, 26, 26).Contains(PointToClient(Cursor.Position)))
            {
                _toolTip.Text = "绘制椭圆";
                _toolTip.Location = new Point(Width - 384 + 26 * 5, 36 + 10);
                _toolTip.Visible = true;
            }
            else if (new Rectangle(Width - 384 + 26 * 6, 10, 26, 26).Contains(PointToClient(Cursor.Position)))
            {
                _toolTip.Text = "绘制直线";
                _toolTip.Location = new Point(Width - 384 + 26 * 6, 36 + 10);
                _toolTip.Visible = true;
            }
            else if (new Rectangle(Width - 384 + 26 * 7, 10, 26, 26).Contains(PointToClient(Cursor.Position)))
            {
                _toolTip.Text = "绘制多边形";
                _toolTip.Location = new Point(Width - 384 + 26 * 7, 36 + 10);
                _toolTip.Visible = true;
            }
            else if (new Rectangle(Width - 384 + 26 * 8, 10, 26, 26).Contains(PointToClient(Cursor.Position)))
            {
                _toolTip.Text = "鼠标定位";
                _toolTip.Location = new Point(Width - 384 + 26 * 8, 36 + 10);
                _toolTip.Visible = true;
            }
            else
            {
                _toolTip.Visible = false;
            }
            //鼠标形状
            if (new Rectangle(Width - 384, 10, 234, 26).Contains(e.Location)
                || new Rectangle(Width - 124, 10, 52, 52).Contains(e.Location)
                || new Rectangle(Width - 62, 10, 52, 52).Contains(e.Location))
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = _current_cursor_cache;
            }

            if (_mouse_type == MouseType.None)  //  鼠标无任何工作
            {

            }
            else if (_mouse_type == MouseType.DragMap)  //拖拽地图
            {
                int deltax = e.Location.X - _previous_point_cache.X;
                int deltay = e.Location.Y - _previous_point_cache.Y;
                LatLngPoint llp = MapHelper.GetLatLngByScreenLocation(new Point(ClientSize.Width/2 - deltax, ClientSize.Height/2 - deltay), _center, _zoom, ClientSize);
                Center = llp;
                _previous_point_cache = e.Location;
                Locate(false);
                if (_bQuickSearchControl.Visible)
                {
                    Point p1 = MapHelper.GetScreenLocationByLatLng(_b_bound.LeftTop, _center, _zoom, ClientSize);
                    Point p2 = MapHelper.GetScreenLocationByLatLng(_b_bound.RightBottom, _center, _zoom, ClientSize);
                    Point p = p1.Y > p2.Y ? p1 : p2;
                    _bQuickSearchControl.Location = new Point(p.X - _bQuickSearchControl.Width, p.Y + 2);
                }
            }
            else if (_mouse_type == MouseType.DragScreenshotArea)
            {
                int deltax = e.Location.X - _previous_point_cache.X;
                int deltay = e.Location.Y - _previous_point_cache.Y;
                BScreenShotRectangle r = _current_drawing as BScreenShotRectangle;
                if (r != null)
                {
                    r.LeftTop = new Point(r.LeftTop.X + deltax, r.LeftTop.Y + deltay);
                    _previous_point_cache = e.Location;
                    _bScreenshotMenu.Location = new Point(r.LeftTop.X + r.Width - _bScreenshotMenu.Width, r.LeftTop.Y + r.Height + 4);
                }
            }
            else if (_mouse_type == MouseType.DrawCircle && _current_drawing as BCircle != null)  //绘制椭圆
            {
                (_current_drawing as BCircle).RightBottom = MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize);
            }
            else if (_mouse_type == MouseType.DrawRectange && _current_drawing as BRectangle != null) //绘制矩形
            {
                (_current_drawing as BRectangle).RightBottom = MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize);
            }
            else if (_mouse_type == MouseType.DrawLine && _current_drawing as BLine != null)  //绘制线条
            {
                (_current_drawing as BLine).UpdateTheEnd(MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize));
            }
            else if (_mouse_type == MouseType.DrawPolygon && _current_drawing as BPolygon != null) //绘制多边形
            {
                (_current_drawing as BPolygon).UpdateTheEnd(MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize));
            }
            else if (_mouse_type == MouseType.DrawScreenshotArea && _current_drawing as BScreenShotRectangle != null) //绘制截图矩形
            {
                (_current_drawing as BScreenShotRectangle).Width = e.Location.X - (_current_drawing as BScreenShotRectangle).LeftTop.X;
                (_current_drawing as BScreenShotRectangle).Height = e.Location.Y - (_current_drawing as BScreenShotRectangle).LeftTop.Y;
            }
            else if (_mouse_type == MouseType.DrawBound && _b_bound != null)  //矩形搜索区域
            {
                _b_bound.RightBottom = MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize);
            }
            else if (_mouse_type == MouseType.DrawDistance && _b_distance != null)  //距离测量
            {
                _b_distance.UpdateTheEnd(MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize));
            }
            Invalidate();
        }
        /// <summary>
        /// 鼠标在地图上弹起
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (_mouse_type == MouseType.DragMap)  //拖动地图 鼠标弹起
            {
                _mouse_type = MouseType.None;
                _current_cursor_cache = Cursor = Cursors.Arrow;
            }
            else if (_mouse_type == MouseType.DragScreenshotArea)  //拖拽截图矩形
            {
                _mouse_type = MouseType.None;
                _current_cursor_cache = Cursor = Cursors.Arrow;
            }
            else if (_mouse_type == MouseType.DrawCircle && _current_drawing as BCircle != null)  //绘制椭圆鼠标弹起
            {
                _mouse_type = MouseType.None;
                _current_cursor_cache = Cursor = Cursors.Arrow;
                _drawingObjects.Add(_drawingObjects.Count + 1, _current_drawing);
                _current_drawing = null;
            }
            else if (_mouse_type == MouseType.DrawRectange && _current_drawing as BRectangle != null)  //绘制矩形鼠标弹起
            {
                _mouse_type = MouseType.None;
                _current_cursor_cache = Cursor = Cursors.Arrow;
                _drawingObjects.Add(_drawingObjects.Count + 1, _current_drawing);
                _current_drawing = null;
            }
            else if (_mouse_type == MouseType.DrawScreenshotArea && _current_drawing as BScreenShotRectangle != null)  //绘制截图矩形鼠标弹起
            {
                _current_cursor_cache = Cursor = Cursors.Arrow;
                _mouse_type = MouseType.None;
                BScreenShotRectangle r = _current_drawing as BScreenShotRectangle;
                _bScreenshotMenu.Location = new Point(r.LeftTop.X + r.Width - _bScreenshotMenu.Width, r.LeftTop.Y + r.Height + 4);
                _bScreenshotMenu.Visible = true;
            }
            else if (_mouse_type == MouseType.DrawBound && _b_bound != null)
            {
                _current_cursor_cache = Cursor = Cursors.Arrow;
                _mouse_type = MouseType.None;
                Point p1 = MapHelper.GetScreenLocationByLatLng(_b_bound.LeftTop, _center, _zoom, ClientSize);
                Point p2 = MapHelper.GetScreenLocationByLatLng(_b_bound.RightBottom, _center, _zoom, ClientSize);
                Point p = p1.Y > p2.Y ? p1 : p2;
                _bQuickSearchControl.Location = new Point(p.X - _bQuickSearchControl.Width, p.Y + 2);
                _bQuickSearchControl.Visible = true;
            }
            Invalidate();
        }
        /// <summary>
        /// 鼠标滚轮在地图上滚动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            //缩放
            int z = _zoom + e.Delta / 100;
            if (z >= 3 && z <= 18)
            {
                Zoom = z;
                Locate(false);
                if (_bQuickSearchControl.Visible)
                {
                    Point p1 = MapHelper.GetScreenLocationByLatLng(_b_bound.LeftTop, _center, _zoom, ClientSize);
                    Point p2 = MapHelper.GetScreenLocationByLatLng(_b_bound.RightBottom, _center, _zoom, ClientSize);
                    Point p = p1.Y > p2.Y ? p1 : p2;
                    _bQuickSearchControl.Location = new Point(p.X - _bQuickSearchControl.Width, p.Y + 2);
                }
            }
        }
        /// <summary>
        /// 鼠标离开地图控件区域
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Invalidate();
        }
        /// <summary>
        /// 地图大小发生变化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
        /// <summary>
        /// 鼠标停留
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
        }
        /// <summary>
        /// 鼠标双击
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if (_mouse_type == MouseType.DrawLine)  //绘制线条结束
            {
                _mouse_type = MouseType.None;
                _current_cursor_cache = Cursor = Cursors.Arrow;
                _drawingObjects.Add(_drawingObjects.Count + 1, _current_drawing);
                _current_drawing = null;
            }
            else if (_mouse_type == MouseType.DrawPolygon) //绘制多边形结束
            {
                _mouse_type = MouseType.None;
                _current_cursor_cache = Cursor = Cursors.Arrow;
                _drawingObjects.Add(_drawingObjects.Count + 1, _current_drawing);
                _current_drawing = null;
            }
            else if (_mouse_type == MouseType.DrawDistance) //测量距离
            {
                _mouse_type = MouseType.None;
                _current_cursor_cache = Cursor = Cursors.Arrow;
            }
            Invalidate();
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
                //定位自己
                Locate(true);

                //初始化功能控件
                //城市切换控件
                _bCityControl.Size = new Size(560, 400);
                _bCityControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                Controls.Add(_bCityControl);
                _bCityControl.Visible = false;
                _bCityControl.SelectedCityChanged += new SelectedCityChangedEventHandler(_bCityControl_SelectedCityChanged);
                //显示路网控件
                _chkShowRoadNet.Text = "道路网";
                _chkShowRoadNet.Visible = false;
                Controls.Add(_chkShowRoadNet);
                _chkShowRoadNet.CheckedChanged += new EventHandler(_chkShowRoadNet_CheckedChanged);
                _chkShowRoadNet.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                _chkShowRoadNet.BackColor = Color.White;
                //地图加载模式控件
                _bLoadMapModeControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                _bLoadMapModeControl.Visible = false;
                Controls.Add(_bLoadMapModeControl);
                _bLoadMapModeControl.LoadMapModeChanged += new LoadMapModeChangedEventHandler(_bLoadMapModeControl_LoadMapModeChanged);
                _bLoadMapModeControl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                _bLoadMapModeControl.BackColor = Color.White;
                //信息提示
                _toolTip.BackColor = Color.White;
                _toolTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                _toolTip.Visible = false;
                _toolTip.TextAlign = ContentAlignment.MiddleLeft;
                _toolTip.AutoSize = true;
                _toolTip.Font = new System.Drawing.Font("微软雅黑", 9);
                _toolTip.Padding = new System.Windows.Forms.Padding(1);
                Controls.Add(_toolTip);
                _toolTip.BringToFront();
                //截图菜单
                _bScreenshotMenu.Visible = false;
                Controls.Add(_bScreenshotMenu);
                _bScreenshotMenu.ScreenshotDone += new ScreenshotDoneEventHandler(_bScreenshotMenu_ScreenshotDone);
                _bScreenshotMenu.BringToFront();
                //快速搜索控件
                _bQuickSearchControl.Visible = false;
                Controls.Add(_bQuickSearchControl);
                _bQuickSearchControl.QuickSearch += new QuickSearchEventHandler(_bQuickSearchControl_QuickSearch);
                _bQuickSearchControl.VisibleChanged += new EventHandler(_bQuickSearchControl_VisibleChanged);
                _bQuickSearchControl.BringToFront();
            }
        }
        /// <summary>
        /// 定位
        /// </summary>
        /// <param name="mylocation">为true表示定位自己 否则定位当前地图中的城市</param>
        private void Locate(bool mylocation)
        {
            //定位位置
            ((Action)(delegate()
            {
                if (mylocation)  //定位自己
                {
                    IPService ips = new IPService();
                    JObject _location = ips.LocationByIP();
                    if (_location != null)
                    {
                        _currentCity = (string)(_location["content"]["address_detail"]["city"]); //返回JSON结构请参见百度API文档
                        _center = new LatLngPoint(double.Parse((string)_location["content"]["point"]["x"]), double.Parse((string)_location["content"]["point"]["y"]));

                    }
                }
                else  //定位地图中心点
                {
                    GeocodingService gs = new GeocodingService();
                    JObject _location = gs.DeGeocoding(_center.Lat + "," + _center.Lng);
                    if (_location != null)
                    {
                        if (_zoom <= 8) //定位到国家
                        {
                            _currentCity = (string)(_location["result"]["addressComponent"]["country"]);  //返回JSON结构请参见百度API文档
                        }
                        else if (_zoom <= 10) //定位到省份
                        {
                            _currentCity = (string)(_location["result"]["addressComponent"]["province"]);  //返回JSON结构请参见百度API文档
                        }
                        else if (_zoom <= 12) //定位到城市
                        {
                            if (_location["result"]["addressComponent"]["city"] != null)
                                _currentCity = (string)(_location["result"]["addressComponent"]["city"]);  //返回JSON结构请参见百度API文档
                        }
                        else  //定位到县区
                        {
                            if (_location["result"]["addressComponent"]["district"] != null)
                                _currentCity = (string)(_location["result"]["addressComponent"]["district"]); //返回JSON结构请参见百度API文档
                        }
                    }                   
                }
                this.Invoke((Action)delegate()
                {
                    Invalidate();
                    if (BPlaceBox != null)
                    {
                        BPlaceBox.CurrentCity = _currentCity;
                    }
                    if (BPlacesBoard != null)
                    {
                        BPlacesBoard.CurrentCity = _currentCity;
                    }
                });
            })).BeginInvoke(null, null);
        }
        /// <summary>
        /// 初始化瓦片
        /// </summary>
        private void InitializeTiles()
        {
            PointF center = MapHelper.GetLocationByLatLng(_center, _zoom); //中心点像素坐标
            PointF left_down = new PointF(center.X -  ClientSize.Width / 2, center.Y - ClientSize.Height / 2); //左下角像素坐标
            PointF right_up = new PointF(center.X + ClientSize.Width / 2, center.Y + ClientSize.Height / 2); //右上角像素坐标

            int tile_left_down_x = (int)Math.Floor(left_down.X / 256);  //左下角瓦片X坐标
            int tile_left_down_y = (int)Math.Floor(left_down.Y / 256);  //左下角瓦片Y坐标
            int tile_right_up_x = (int)Math.Floor(right_up.X / 256);    //右上角瓦片X坐标
            int tile_right_up_y = (int)Math.Floor(right_up.Y / 256);    //右上角瓦片Y坐标

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
            using (GraphicsPath gp = MapHelper.CreateRoundedRectanglePath(new Rectangle(10, Height - 100, 250, 90),6))
            {
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(180, Color.White)))
                {
                    g.FillPath(sb, gp);
                    g.DrawPath(Pens.Black, gp);
                    using (Font f = new Font("微软雅黑", 11))
                    {
                        g.DrawString(MapHelper.GetMapModeTitle(_mode) + "，" + _zoom + "级，" + MapHelper.GetLoadMapModeTitle(_loadmode), f, Brushes.Teal, new PointF(20, Height - 100 + 10));
                        Point p = PointToClient(Cursor.Position);
                        if (Bounds.Contains(p))
                        {
                            LatLngPoint llp = MapHelper.GetLatLngByScreenLocation(p, _center, _zoom, ClientSize); //当前鼠标经纬度
                            g.DrawString(Math.Round(llp.Lat,5) + "，" + Math.Round(llp.Lng,5), f, Brushes.Teal, new PointF(20, Height - 100 + 35));
                        }
                        g.DrawString("BMap.NET 2015", f, Brushes.Teal, new PointF(20, Height - 100 + 60));
                    }
                }
            }
        }
        /// <summary>
        /// 绘制左上角当前城市
        /// </summary>
        /// <param name="g"></param>
        private void DrawCurrentCity(Graphics g)
        {
            g.FillRectangle(Brushes.White, new Rectangle(10, 10, 90, 25));
            g.DrawRectangle(Pens.DarkGray, new Rectangle(10, 10, 90, 25));
            using (Font f = new Font("微软雅黑", 9))
            {
                string info = _currentCity;
                if (_currentCity == "")
                {
                    info = "定位失败";
                }
                g.DrawString(info.Length <= 4 ? info : info.Substring(0, 4), f, Brushes.DarkGray, new PointF(20, 15));
            }
            if (!_bCityControl.Visible)  //城市切换窗体关闭
            {
                g.FillPolygon(Brushes.Gray, new Point[] { new Point(74, 19), new Point(88, 19), new Point(81, 26) });
            }
            else
            {
                g.FillPolygon(Brushes.Gray, new Point[] { new Point(74, 26), new Point(88, 26), new Point(81, 19) });
            }
        }
        /// <summary>
        /// 绘制右上角工具栏
        /// </summary>
        /// <param name="g"></param>
        private void DrawToolsBar(Graphics g)
        {
            //工具
            //g.FillRectangle(Brushes.White, new Rectangle(Width - 384, 10, 234, 26));

            using (SolidBrush sb = new SolidBrush(Color.FromArgb(120, Color.Black)))
            {
                g.DrawImage(Properties.BMap.ico_search_in_bound, new Rectangle(Width - 384, 10, 26, 26)); //矩形区域搜索
                if (_mouse_type == MouseType.DrawBound)
                {
                    g.FillRectangle(sb, new Rectangle(Width - 384, 10, 26, 26));
                }
                g.DrawImage(Properties.BMap.ico_distance, new Rectangle(Width - 384 + 26, 10, 26, 26)); //测量距离
                if (_mouse_type == MouseType.DrawDistance)
                {
                    g.FillRectangle(sb, new Rectangle(Width - 384 + 26 * 1, 10, 26, 26));
                }
                g.DrawImage(Properties.BMap.ico_screenshot, new Rectangle(Width - 384 + 26 * 2, 10, 26, 26)); //截图
                if (_mouse_type == MouseType.DrawScreenshotArea)
                {
                    g.FillRectangle(sb, new Rectangle(Width - 384 + 26 * 2, 10, 26, 26));
                }
                g.DrawImage(Properties.BMap.ico_setmarker, new Rectangle(Width - 384 + 26 * 3, 10, 26, 26)); //添加标记
                if (_mouse_type == MouseType.DrawMarker)
                {
                    g.FillRectangle(sb, new Rectangle(Width - 384 + 26 * 3, 10, 26, 26));
                }
                g.DrawImage(Properties.BMap.ico_rectangle, new Rectangle(Width - 384 + 26 * 4, 10, 26, 26)); //绘制矩形
                if (_mouse_type == MouseType.DrawRectange)
                {
                    g.FillRectangle(sb, new Rectangle(Width - 384 + 26 * 4, 10, 26, 26));
                }
                g.DrawImage(Properties.BMap.ico_circle, new Rectangle(Width - 384 + 26 * 5, 10, 26, 26)); //绘制椭圆
                if (_mouse_type == MouseType.DrawCircle)
                {
                    g.FillRectangle(sb, new Rectangle(Width - 384 + 26 * 5, 10, 26, 26));
                }
                g.DrawImage(Properties.BMap.ico_line, new Rectangle(Width - 384 + 26 * 6, 10, 26, 26)); //绘制直线
                if (_mouse_type == MouseType.DrawLine)
                {
                    g.FillRectangle(sb, new Rectangle(Width - 384 + 26 * 6, 10, 26, 26));
                }
                g.DrawImage(Properties.BMap.ico_polygon, new Rectangle(Width - 384 + 26 * 7, 10, 26, 26));  //绘制多边形
                if (_mouse_type == MouseType.DrawPolygon)
                {
                    g.FillRectangle(sb, new Rectangle(Width - 384 + 26 * 7, 10, 26, 26));
                }
                g.DrawImage(Properties.BMap.ico_cursor_locate, new Rectangle(Width - 384 + 26 * 8, 10, 26, 26));//鼠标定位效果
                if (_cursor_located)
                {
                    g.FillRectangle(sb, new Rectangle(Width - 384 + 26 * 8, 10, 26, 26));
                }
            }
            g.DrawRectangle(Pens.DarkGray, new Rectangle(Width - 384, 10, 234, 26));
            for (int i = 0; i < 8; ++i)
            {
                g.DrawLine(Pens.LightGray, new Point(Width - 384 + (i + 1) * 26, 10), new Point(Width - 384 + (i + 1) * 26, 10 + 26));
            }

            //地图加载模式
            Image mode_image = ((Func<LoadMapMode, Image>)((LoadMapMode m) =>   //临时调用匿名方法
                {
                    if (_loadmode == LoadMapMode.Cache)
                    {
                        return Properties.BMap.ico_cache;
                    }
                    if (_loadmode == LoadMapMode.CacheServer)
                    {
                        return Properties.BMap.ico_cachefirst;
                    }
                    if (_loadmode == LoadMapMode.Server)
                    {
                        return Properties.BMap.ico_server;
                    }
                    return null;
                }))(_loadmode);
            g.DrawImage(mode_image, new Rectangle(Width - 124, 10, 52, 52));
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(180, Color.White)))
            {
                g.FillRectangle(sb, new Rectangle(Width - 124, 10 + 30, 52, 22));
            }
            using (Font f = new System.Drawing.Font("微软雅黑", 8))
            {
                g.DrawString(MapHelper.GetLoadMapModeTitle(_loadmode), f, Brushes.Black, new PointF(Width - 124 + 3, 10 + 30 + 5));
            }
            g.DrawRectangle(Pens.DarkGray, new Rectangle(Width - 124, 10, 52, 52));
            
            //地图模式
            g.DrawImage(_mode == MapMode.Normal ? Properties.BMap.ico_sateshot : Properties.BMap.ico_mapshot, new Rectangle(Width - 62, 10, 52, 52));
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(180, Color.White)))
            {
                g.FillRectangle(sb, new Rectangle(Width - 62, 10 + 30, 52, 22));
            }
            using (Font f = new Font("微软雅黑", 9))
            {
                g.DrawString(_mode == MapMode.Normal ? "卫星" : "地图", f, Brushes.Black, new PointF(Width - 62 + 12, 10 + 30 + 4));
            }
            g.DrawRectangle(Pens.DarkGray, new Rectangle(Width - 62, 10, 52, 52));
        }
        /// <summary>
        /// 绘制鼠标定位效果
        /// </summary>
        /// <param name="g"></param>
        private void DrawCursor(Graphics g)
        {
            Point p = PointToClient(Cursor.Position);
            if (ClientRectangle.Contains(p))
            {
                if (_cursor_located)
                {
                    using (Pen pen = new Pen(Color.FromArgb(200, _mode == MapMode.Normal ? Color.Blue : Color.White), 2))
                    {
                        pen.DashStyle = DashStyle.Dash;
                        g.DrawLine(pen, new Point(0, p.Y), new Point(ClientSize.Width, p.Y));
                        g.DrawLine(pen, new Point(p.X, 0), new Point(p.X, ClientSize.Height));
                    }
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
            if (_b_bound != null)  //矩形搜索区域
            {
                _b_bound.Draw(g, _center, _zoom, ClientSize);
            }
            if(_b_distance != null) //距离测量
            {
                _b_distance.Draw(g, _center, _zoom, ClientSize);
            }
            foreach(KeyValuePair<string,BPOI> p in _pois)  //信息点
            {
                p.Value.Draw(g, _center, _zoom, ClientSize);
            }
        }
        #endregion

        #region 公开方法
        /// <summary>
        /// 向地图中增加位置POI
        /// </summary>
        /// <param name="places"></param>
        public void AddPlaces(JToken places)
        {
            _pois.Clear();
            int index = 0;
            foreach (JObject place in places)
            {
                if (place["location"]["lng"] != null && (string)place["location"]["lng"] != "")
                {
                    LatLngPoint location = new LatLngPoint(double.Parse((string)place["location"]["lng"]), double.Parse((string)place["location"]["lat"]));
                    BPOI poi = new BPOI { DataSource = place, Index = index, Selected = false, Location = location };
                    _pois.Add((string)place["uid"], poi);
                }
                index++;
            }
            Invalidate();
        }
        #endregion

        #region 事件处理方法
        /// <summary>
        /// 城市切换
        /// </summary>
        /// <param name="cityName"></param>
        void _bCityControl_SelectedCityChanged(string cityName)
        {
            _bCityControl.Visible = false;
            _currentCity = cityName;
            if (BPlaceBox != null)  //关联的位置输入框
            {
                BPlaceBox.CurrentCity = cityName;
            }
            if (BPlacesBoard != null)  //关联的位置列表控件
            {
                BPlacesBoard.CurrentCity = cityName;
            }
            Invalidate();
            ((Action)delegate()  //定位到指定城市
            {
                GeocodingService gs = new GeocodingService();
                JObject city_location = gs.Geocoding(_currentCity);
                if (city_location != null)
                {
                    Center = new LatLngPoint(double.Parse((string)city_location["result"]["location"]["lng"]), double.Parse((string)city_location["result"]["location"]["lat"]));
                }
                this.Invoke((Action)delegate()
                {
                    Zoom = 12;
                    Invalidate();
                });
            }).BeginInvoke(null, null);
        }
        /// <summary>
        /// 卫星图模式下是否显示路网
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _chkShowRoadNet_CheckedChanged(object sender, EventArgs e)
        {
            if (_mode != MapMode.Normal)
            {
                if (_chkShowRoadNet.Checked)
                {
                    Mode = MapMode.Sate_RoadNet;
                }
                else
                {
                    Mode = MapMode.Satellite;
                }
            }
        }
        /// <summary>
        /// 加载地图模式改变
        /// </summary>
        /// <param name="loadMode"></param>
        void _bLoadMapModeControl_LoadMapModeChanged(LoadMapMode loadMode)
        {
            LoadMode = loadMode;
        }
        /// <summary>
        /// 截图完成
        /// </summary>
        /// <param name="saved"></param>
        void _bScreenshotMenu_ScreenshotDone(bool saved)
        {
            if (saved) //保存
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "JPEG文件(*.jpeg,jpg)|*.JPEG;*.JPG";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        BScreenShotRectangle r = _current_drawing as BScreenShotRectangle;
                        _current_drawing = null;
                        _bScreenshotMenu.Visible = false;
                        Bitmap b = new Bitmap(Width, Height);
                        DrawToBitmap(b, new Rectangle(0, 0, Width, Height));
                        Bitmap image2save = new Bitmap(r.Width, r.Height);
                        Graphics.FromImage(image2save).DrawImage(b, new Rectangle(0, 0, r.Width, r.Height), r.Rect, GraphicsUnit.Pixel);
                        image2save.Save(sfd.FileName);
                    }
                }
            }
            else
            {
                _current_drawing = null;
                _bScreenshotMenu.Visible = false;
            }
        }
        /// <summary>
        /// 矩形区域搜索
        /// </summary>
        /// <param name="searchName"></param>
        void _bQuickSearchControl_QuickSearch(string searchName)
        {
            LatLngPoint leftbottom = new LatLngPoint(_b_bound.LeftTop.Lng, _b_bound.RightBottom.Lat);
            LatLngPoint righttop = new LatLngPoint(_b_bound.RightBottom.Lng, _b_bound.LeftTop.Lat);
            ((Action)delegate()
            {
                PlaceService ps = new PlaceService();
                JObject places = ps.SearchInBound(searchName, leftbottom.Lat + "," + leftbottom.Lng + "," + righttop.Lat + "," + righttop.Lng);//区域搜索
                this.Invoke((Action)delegate()
                {
                    if (BPlacesBoard != null)
                    {
                        BPlacesBoard.AddPlaces(places["results"]);  //具体json格式参见api文档
                    }
                    else
                    {
                        AddPlaces(places["results"]);
                    }
                });

            }).BeginInvoke(null, null);
            _bQuickSearchControl.Visible = false;
        }
        /// <summary>
        /// 矩形搜索框关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _bQuickSearchControl_VisibleChanged(object sender, EventArgs e)
        {
            if (!_bQuickSearchControl.Visible)
            {
                _b_bound = null;
            }
        }
        /// <summary>
        /// 右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cm_popup_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if(item.Name == "cmsWhere")
            {

            }
            else if (item.Name == "cmsSetStart")
            {

            }
            else if (item.Name == "cmsSetEnd")
            {

            }
            else if (item.Name == "cmsCenter")
            {
                LatLngPoint lp = MapHelper.GetLatLngByScreenLocation(PointToClient(Cursor.Position), _center, _zoom, ClientSize);
                Center = lp;
                Locate(false);
                if (_bQuickSearchControl.Visible)
                {
                    Point p1 = MapHelper.GetScreenLocationByLatLng(_b_bound.LeftTop, _center, _zoom, ClientSize);
                    Point p2 = MapHelper.GetScreenLocationByLatLng(_b_bound.RightBottom, _center, _zoom, ClientSize);
                    Point p = p1.Y > p2.Y ? p1 : p2;
                    _bQuickSearchControl.Location = new Point(p.X - _bQuickSearchControl.Width, p.Y + 2);
                }
            }
            else if (item.Name == "cmsLarge")
            {
                int z = _zoom + 1;
                if (z >= 3 && z <= 18)
                {
                    Zoom = z;
                    Locate(false);
                    if (_bQuickSearchControl.Visible)
                    {
                        Point p1 = MapHelper.GetScreenLocationByLatLng(_b_bound.LeftTop, _center, _zoom, ClientSize);
                        Point p2 = MapHelper.GetScreenLocationByLatLng(_b_bound.RightBottom, _center, _zoom, ClientSize);
                        Point p = p1.Y > p2.Y ? p1 : p2;
                        _bQuickSearchControl.Location = new Point(p.X - _bQuickSearchControl.Width, p.Y + 2);
                    }
                }
            }
            else if (item.Name == "cmsSmall")
            {
                int z = _zoom - 1;
                if (z >= 3 && z <= 18)
                {
                    Zoom = z;
                    Locate(false);
                    if (_bQuickSearchControl.Visible)
                    {
                        Point p1 = MapHelper.GetScreenLocationByLatLng(_b_bound.LeftTop, _center, _zoom, ClientSize);
                        Point p2 = MapHelper.GetScreenLocationByLatLng(_b_bound.RightBottom, _center, _zoom, ClientSize);
                        Point p = p1.Y > p2.Y ? p1 : p2;
                        _bQuickSearchControl.Location = new Point(p.X - _bQuickSearchControl.Width, p.Y + 2);
                    }
                }
            }
            else if (item.Name == "cmsClearDrawings") //清空绘图
            {
                _drawingObjects.Clear();
            }
            else if (item.Name == "cmsClearMarkers") //清空标记
            {
                _marks.Clear();
            }
            Invalidate();
        }
        #endregion

    }
    /// <summary>
    /// 地图辅助类
    /// </summary>
    class MapHelper
    {
        private const double EARTH_RADIUS = 6378.137;//地球半径
        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }
        /// <summary>
        /// 根据经纬度计算两点实际距离（m）
        /// </summary>
        /// <param name="p1">第一个经纬度坐标点</param>
        /// <param name="p2">第二个经纬度坐标点</param>
        /// <returns></returns>
        public static double GetDistanceByLatLng(LatLngPoint p1, LatLngPoint p2)
        {
            double radLat1 = rad(p1.Lat);
            double radLat2 = rad(p2.Lat);
            double a = radLat1 - radLat2;
            double b = rad(p1.Lng) - rad(p2.Lng);
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }
        /// <summary>
        /// 根据经纬度坐标计算该点在屏幕中的坐标
        /// </summary>
        /// <param name="p">要计算的经纬度</param>
        /// <param name="center">屏幕中心经纬度</param>
        /// <param name="zoom">地图当前缩放级别</param>
        /// <param name="screen_size">屏幕大小</param>
        /// <returns></returns>
        public static Point GetScreenLocationByLatLng(LatLngPoint p, LatLngPoint center, int zoom, Size screen_size)
        {
            Point dp = GetLocationByLatLng(p, zoom);  //目标点的像素坐标
            Point cp = GetLocationByLatLng(center, zoom);  //中心点的像素坐标

            //计算目标点和中心点像素坐标差
            double delta_x = dp.X - cp.X;
            double delta_y = dp.Y - cp.Y;

            //转换成屏幕坐标系统的坐标 并返回
            return new Point((int)((float)screen_size.Width / 2 + delta_x), (int)((float)screen_size.Height / 2 + (-1) * delta_y));

        }
        /// <summary>
        /// 根据屏幕坐标计算该点的经纬度坐标
        /// </summary>
        /// <param name="p"></param>
        /// <param name="center"></param>
        /// <param name="zoom"></param>
        /// <param name="screen_size"></param>
        /// <returns></returns>
        public static LatLngPoint GetLatLngByScreenLocation(Point p, LatLngPoint center, int zoom, Size screen_size)
        {
            Point cp = GetLocationByLatLng(center, zoom);  //中心点像素坐标

            //目标点与中心点屏幕坐标差
            int delta_x = p.X - screen_size.Width/2;  
            int delta_y = p.Y - screen_size.Height/2;

            Point dp = new Point(cp.X + delta_x, cp.Y + delta_y * (-1));  //目标点像素坐标

            double c = (2 * Math.PI * EARTH_RADIUS * 1000) / Math.Pow(2, 18 - zoom);//地图背景宽高

            double y = 2 * Math.PI * (1 - (c / 2 - dp.Y) / (c / 2));
            double z = Math.Pow(Math.E, y);
            double siny = (z - 1) / (z + 1);
            

            //转换成经纬度坐标 并返回
            return new LatLngPoint(dp.X / (c / 360), Math.Asin(siny) * 180 / Math.PI + 0.17);
        }
        /// <summary>
        /// 根据经纬度坐标计算该点的像素坐标
        /// </summary>
        /// <param name="p">要计算的经纬度</param>
        /// <param name="zoom">地图当前缩放级别</param>
        /// <returns></returns>
        public static Point GetLocationByLatLng(LatLngPoint p, int zoom)
        {
            double c = (2 * Math.PI * EARTH_RADIUS * 1000) / Math.Pow(2, 18 - zoom);//地图背景宽高

            int x = (int)(p.Lng * (c / 360));  //X像素坐标   经度均匀分布

            double siny = Math.Sin((p.Lat-0.17) * Math.PI / 180);
            double a = Math.Log((1 + siny) / (1 - siny));
            int y = (int)(c / 2 - (c / 2) * (1 - a / (2 * Math.PI)));  //Y像素坐标

            return new Point(x, y);
        }
        /// <summary>
        /// 创建圆角矩形路径
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="cornerRadius"></param>
        /// <returns></returns>
        public static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }
        /// <summary>
        /// 获取地图显示模式文本
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static string GetMapModeTitle(MapMode mode)
        {
            if (mode == MapMode.Normal)
            {
                return "地图";
            }
            if (mode == MapMode.Satellite)
            {
                return "卫星图";
            }
            if (mode == MapMode.RoadNet)
            {
                return "道路网";
            }
            if (mode == MapMode.Sate_RoadNet)
            {
                return "卫星图(路网)";
            }
            return "";
        }
        /// <summary>
        /// 获取地图加载模式文本
        /// </summary>
        /// <param name="load_mode"></param>
        /// <returns></returns>
        public static string GetLoadMapModeTitle(LoadMapMode load_mode)
        {
            if (load_mode == LoadMapMode.Cache)
            {
                return "仅从本地";
            }
            if (load_mode == LoadMapMode.CacheServer)
            {
                return "本地优先";
            }
            if (load_mode == LoadMapMode.Server)
            {
                return "仅从远程";
            }
            return "";
        }
    }
    /// <summary>
    /// 鼠标工作类型
    /// </summary>
    enum MouseType
    {
        None,  //无
        DragMap,  //拖拽地图
        DragNearby,  //拖拽周边区域
        DrawBound,  //绘制矩形搜索区域
        DrawDistance, //绘制测量线条
        DrawScreenshotArea,  //绘制截图矩形
        DragScreenshotArea,  //拖拽截图矩形
        DrawMarker, //绘制标记点
        DrawRectange,  //绘制矩形
        DrawCircle, //绘制圆形
        DrawLine, //绘制直线
        DrawPolygon  //绘制多边形
    }
}
