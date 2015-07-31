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

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// 百度地图显示控件
    /// </summary>
    public partial class BMapControl : UserControl
    {
        private const double DISTANCE = 111319.49; //每（经纬）度距离m

        #region 属性
        private LatLngPoint _center = new LatLngPoint(117.176937, 39.109557); 
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
        #endregion

        #region 字段
        /// <summary>
        /// 城市切换控件
        /// </summary>
        private BCityControl _bCityControl = new BCityControl();
        /// <summary>
        /// 当前城市
        /// </summary>
        private string _currentCity = "";
        /// <summary>
        /// 鼠标移动前一点缓存
        /// </summary>
        private Point _previous_point_cache;
        /// <summary>
        /// 鼠标工作方式
        /// </summary>
        private MouseType _mouse_type = MouseType.None;
        /// <summary>
        /// 地图中唯一的矩形（没有则为null）
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
        /// 地图中瓦片容器
        /// </summary>
        private Dictionary<string, BTile> _tiles = new Dictionary<string, BTile>();
        /// <summary>
        /// 地图中信息点（POI）容器
        /// </summary>
        private Dictionary<string, BPOI> _pois = new Dictionary<string, BPOI>();
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
                //地图信息
                DrawMapInfo(e.Graphics);
                //当前城市
                DrawCurrentCity(e.Graphics);
            }
        }
        /// <summary>
        /// 鼠标在地图上按下
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            //检查设置鼠标工作方式
            if (_mouse_type == MouseType.None)
            {
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
                    }
                    Invalidate();
                }
                else  //拖拽地图
                {
                    _mouse_type = MouseType.DragMap;
                    Cursor = Cursors.SizeAll;
                    _previous_point_cache = e.Location;
                }
            }
        }
        /// <summary>
        /// 鼠标在地图上移动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_mouse_type == MouseType.DragMap)  //拖拽地图
            {
                int deltax = e.Location.X - _previous_point_cache.X;
                int deltay = e.Location.Y - _previous_point_cache.Y;
                Center = new LatLngPoint(_center.Lng - (double)deltax / (DISTANCE / Math.Pow(2, 18 - _zoom)), _center.Lat + (double)deltay / (DISTANCE / Math.Pow(2, 18 - _zoom)));
                _previous_point_cache = e.Location;
                Invalidate();
            }
        }
        /// <summary>
        /// 鼠标在地图上弹起
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (_mouse_type == MouseType.DragMap)
            {
                _mouse_type = MouseType.None;
                Cursor = Cursors.Arrow;
            }
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
                Zoom = z;
        }
        /// <summary>
        /// 鼠标离开地图控件区域
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
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
        #endregion

        #region 功能方法
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            if (!DesignMode)
            {
                //定位当前位置
                ((Action)(delegate()
                {
                    IPService ips = new IPService();
                    JObject _location = ips.LocationByIP();
                    if (_location != null)
                    {
                        _currentCity = (string)(_location["content"]["address_detail"]["city"]); //返回JSON结构请参见百度API文档
                    }
                    this.Invoke((Action)delegate()
                    {
                        Invalidate();
                        if (BPlaceBox != null)
                        {
                            BPlaceBox.CurrentCity = _currentCity;
                        }
                    });
                })).BeginInvoke(null, null);

                //初始化功能控件
                _bCityControl.Size = new Size(560, 400);
                _bCityControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                Controls.Add(_bCityControl);
                _bCityControl.Visible = false;
                _bCityControl.SelectedCityChanged += new SelectedCityChangedEventHandler(_bCityControl_SelectedCityChanged);
            }
        }
        /// <summary>
        /// 初始化瓦片
        /// </summary>
        private void InitializeTiles()
        {
            PointF center = MapHelper.GetLocationByLatLng(_center, _zoom); //中心点像素坐标
            PointF left_down = new PointF(center.X - Bounds.Width / 2, center.Y - Bounds.Height / 2); //左下角像素坐标
            PointF right_up = new PointF(center.X + Bounds.Width / 2, center.Y + Bounds.Height / 2); //右上角像素坐标

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
        /// 绘制地图的一些附加信息 如当前坐标、地图级别、logo、版权等
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
                g.DrawString(_currentCity.Length <= 4 ? _currentCity : _currentCity.Substring(0, 4), f, Brushes.DarkGray, new PointF(20, 15));
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
        #endregion

        #region 公开方法
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
                    Invalidate();
                });
            }).BeginInvoke(null, null);
        }
        #endregion
    }
    /// <summary>
    /// 地图辅助类
    /// </summary>
    class MapHelper
    {
        private const double DISTANCE = 111319.49;  //每（经纬）度距离
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

            //转换成经纬度坐标 并返回
            return new LatLngPoint(dp.X / (DISTANCE / Math.Pow(2, 18 - zoom)), dp.Y / (DISTANCE / Math.Pow(2, 18 - zoom)));
        }
        /// <summary>
        /// 根据经纬度坐标计算该点的像素坐标
        /// </summary>
        /// <param name="p">要计算的经纬度</param>
        /// <param name="zoom">地图当前缩放级别</param>
        /// <returns></returns>
        public static Point GetLocationByLatLng(LatLngPoint p, int zoom)
        {
            // DISTANCE / Math.Pow(2, 18 - zoom) 每度占用像素
            int x = (int)(p.Lng * (DISTANCE / Math.Pow(2, 18 - zoom)));
            int y = (int)((p.Lat) * (DISTANCE / Math.Pow(2, 18 - zoom)));
            return new Point(x, y);  //返回像素坐标
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
        DragBound,  //拖拽矩形区域
        DrawBound,  //绘制矩形区域
        DrawDistance //绘制测量线条
    }
}
