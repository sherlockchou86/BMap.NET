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
        private LatLngPoint _center = new LatLngPoint(117.217412, 39.142191);   //天津
        /// <summary>
        /// 地图显示中心经纬度坐标
        /// </summary>
        [Description("地图中心点"),Category("BMap.NET")]
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
        [Description("当前地图缩放级别"),Category("BMap.NET")]
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
        [Description("当前地图模式"),Category("BMap.NET")]
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
        [Description("当前地图加载模式"),Category("BMap.NET")]
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
        [Description("与之关联的位置搜索输入框"),Category("BMap.NET")]
        public BPlaceBox BPlaceBox
        {
            get;
            set;
        }
        /// <summary>
        /// 与之关联的位置列表控件
        /// </summary>
        [Description("与之关联的位置列表控件"),Category("BMap.NET")]
        public BPlacesBoard BPlacesBoard
        {
            set;
            get;
        }
        /// <summary>
        /// 导航控件
        /// </summary>
        [Description("与之关联的导航控件"),Category("BMap.NET")]
        public BDirectionBoard BDirectionBoard
        {
            get;
            set;
        }
        #endregion

        #region 字段
        /// <summary>
        /// 鼠标右键时鼠标位置
        /// </summary>
        private Point _right_mouse_point_cache;
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
        /// 线路起点（没有则为null）
        /// </summary>
        private BPoint _theRouteStart;
        /// <summary>
        /// 线路终点（没有则为null）
        /// </summary>
        private BPoint _theRouteEnd;
        /// <summary>
        /// 地图中用户询问的未知点（没有则为null）
        /// </summary>
        private BPoint _theStrangePoint;
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
        /// <summary>
        /// 当前选择的POI（没有则为null）
        /// </summary>
        private BPOI _current_selected_poi;
        /// <summary>
        /// 当前选择的标记点（没有则为null）
        /// </summary>
        private BMarker _current_selected_marker;
        /// <summary>
        /// 当前选择的位置点（没有则为null）
        /// </summary>
        private BPoint _current_selected_point;
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
                    if (_theStrangePoint != null && _theStrangePoint.Rect.Contains(e.Location)) //是否点击未知点
                    {
                        _current_selected_point = _theStrangePoint;
                        Point point = MapHelper.GetScreenLocationByLatLng(_current_selected_point.Location, _center, _zoom, ClientSize);
                        //信息显示控件
                        _bPointTipControl.BPoint = _current_selected_point;
                        _bPointTipControl.Location = new Point(point.X - _bPointTipControl.Width / 3 + 35, point.Y - _bPointTipControl.Height - _current_selected_point.Rect.Height);
                        _bPointTipControl.Visible = true;
                        return;
                    }
                    if (_theRouteStart !=null && _theRouteStart.Rect.Contains(e.Location)) //是否点击路线起点
                    {
                        _current_selected_point = _theRouteStart;
                        Point point = MapHelper.GetScreenLocationByLatLng(_current_selected_point.Location, _center, _zoom, ClientSize);
                        //信息显示控件
                        _bPointTipControl.BPoint = _current_selected_point;
                        _bPointTipControl.Location = new Point(point.X - _bPointTipControl.Width / 3 + 35, point.Y - _bPointTipControl.Height - _current_selected_point.Rect.Height);
                        _bPointTipControl.Visible = true;                     
                        return;
                    }
                    if (_theRouteEnd != null && _theRouteEnd.Rect.Contains(e.Location)) //是否点击路线终点
                    {
                        _current_selected_point = _theRouteEnd;
                        Point point = MapHelper.GetScreenLocationByLatLng(_current_selected_point.Location, _center, _zoom, ClientSize);
                        //信息显示控件
                        _bPointTipControl.BPoint = _current_selected_point;
                        _bPointTipControl.Location = new Point(point.X - _bPointTipControl.Width / 3 + 35, point.Y - _bPointTipControl.Height - _current_selected_point.Rect.Height);
                        _bPointTipControl.Visible = true;
                        return;
                    }
                    foreach (KeyValuePair<string,BPOI> p in _pois) //是否点击POI点
                    {
                        if (p.Value.Rect.Contains(e.Location))
                        {
                            _current_selected_poi = p.Value;
                            //显示信息控件
                            p.Value.Selected = true;
                            Point point = MapHelper.GetScreenLocationByLatLng(p.Value.Location, _center, _zoom, ClientSize);
                            _bPOITipControl.POI = _current_selected_poi;
                            _bPOITipControl.Location = new Point(point.X - _bPOITipControl.Width / 3 + 35, point.Y - _bPOITipControl.Height - _current_selected_poi.Rect.Height - 5);
                            _bPOITipControl.Visible = true;

                            foreach (KeyValuePair<string, BPOI> pp in _pois)
                            {
                                if (pp.Value != p.Value)
                                {
                                    pp.Value.Selected = false;
                                }
                            }
                            Invalidate();
                            //通知BPlacesBoard  同步选择
                            if (BPlacesBoard != null)
                            {
                                BPlacesBoard.SelectPlace(p.Value);
                            }
                            return;
                        }
                    }
                    foreach (KeyValuePair<string, BMarker> p in _markers) //是否点击标记点
                    {
                        if (p.Value.Rect.Contains(e.Location))
                        {
                            _current_selected_marker = p.Value;
                            //显示标记信息控件
                            Point point = MapHelper.GetScreenLocationByLatLng(p.Value.Location, _center, _zoom, ClientSize);
                            _bMarkerTipControl.Deleted = false;
                            _bMarkerTipControl.Edited = false;
                            _bMarkerTipControl.Marker = _current_selected_marker;
                            _bMarkerTipControl.Location = new Point(point.X - _bMarkerTipControl.Width / 3 + 37, point.Y - _bMarkerTipControl.Height - p.Value.Rect.Height);
                            _bMarkerTipControl.Visible = true;
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
                else if (_mouse_type == MouseType.DrawMarker) //添加标记
                {
                    LatLngPoint p = MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize);
                    ((Action)delegate()
                    {
                        GeocodingService gs = new GeocodingService();
                        JObject place = gs.DeGeocoding(p.Lat + "," + p.Lng);
                        if (place != null)
                        {
                            this.Invoke((Action)delegate()
                            {
                                BMarker marker = new BMarker { Index = _markers.Count, Location = p, Name = (string)place["result"]["formatted_address"], Remarks = "我的备注", Selected = false, Address = (string)place["result"]["formatted_address"] };
                                _markers.Add(marker.Index.ToString(), marker);
                                _bMarkerEditorControl.Saved = false;
                                _bMarkerEditorControl.Marker = marker;
                                _bMarkerEditorControl.Location = new Point(e.Location.X - _bMarkerEditorControl.Width / 3 + 37, e.Location.Y - _bMarkerEditorControl.Height - 22);
                                _bMarkerEditorControl.Visible = true;
                                _current_selected_marker = marker;
                            });
                        }
                    }).BeginInvoke(null, null);
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)  //右键弹菜单
            {
                _right_mouse_point_cache = e.Location;
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
                return;
            }
            else
            {
                Cursor = _current_cursor_cache;
            }

            if (_mouse_type == MouseType.None)  //  鼠标无任何工作
            {
                bool flag = false;
                foreach (KeyValuePair<string, BPOI> p in _pois) //POI信息点
                {
                    if (p.Value.Rect.Contains(e.Location))
                    {
                        flag = true;
                        break;
                    }
                }
                foreach (KeyValuePair<string, BMarker> p in _markers) //标记点
                {
                    if(p.Value.Rect.Contains(e.Location))
                    {
                        flag = true;
                        break;
                    }
                }
                if((_theStrangePoint != null && _theStrangePoint.Rect.Contains(e.Location)) || 
                    (_theRouteEnd != null && _theRouteEnd.Rect.Contains(e.Location))
                    || (_theRouteStart != null && _theRouteStart.Rect.Contains(e.Location))) //
                {
                    flag = true;
                }
                if (flag)
                {
                    Cursor = Cursors.Hand;
                }
                else
                {
                    Cursor = _current_cursor_cache;
                }
            }
            else if (_mouse_type == MouseType.DragMap)  //拖拽地图
            {
                int deltax = e.Location.X - _previous_point_cache.X;
                int deltay = e.Location.Y - _previous_point_cache.Y;
                LatLngPoint llp = MapHelper.GetLatLngByScreenLocation(new Point(ClientSize.Width/2 - deltax, ClientSize.Height/2 - deltay), _center, _zoom, ClientSize);
                Center = llp;
                _previous_point_cache = e.Location;
                Locate(false);
                SyncControlsLocation();
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
            else if (_mouse_type == MouseType.DrawBound && _b_bound != null) //矩形搜索
            {
                _current_cursor_cache = Cursor = Cursors.Arrow;
                _mouse_type = MouseType.None;
                Point p1 = MapHelper.GetScreenLocationByLatLng(_b_bound.LeftTop, _center, _zoom, ClientSize);
                Point p2 = MapHelper.GetScreenLocationByLatLng(_b_bound.RightBottom, _center, _zoom, ClientSize);
                Point p = p1.Y > p2.Y ? p1 : p2;
                _bQuickSearchControl.Location = new Point(p.X - _bQuickSearchControl.Width, p.Y + 2);
                _bQuickSearchControl.Visible = true;
            }
            else if (_mouse_type == MouseType.DrawMarker) //添加标记点
            {
                if (_current_selected_marker != null)
                {
                    _mouse_type = MouseType.None;
                }
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
            if (z >= 3 && z <= 19)
            {
                LatLngPoint p = MapHelper.GetLatLngByScreenLocation(e.Location, _center, _zoom, ClientSize);  //鼠标经纬度坐标
                PointF pt = MapHelper.GetLocationByLatLng(p, z);  //鼠标像素坐标
                PointF pt_center = new PointF(pt.X + (ClientSize.Width/2 - e.Location.X), pt.Y + (e.Location.Y - ClientSize.Height / 2)); //缩放后中心点像素坐标

                LatLngPoint p_center = MapHelper.GetLatLngByLocation(pt_center, z); //像素坐标到经纬度坐标
                Center = p_center;

                Zoom = z;
                Locate(false);
                SyncControlsLocation();
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
            SyncControlsLocation();
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
                //标记点信息显示控件
                _bMarkerTipControl.Visible = false;
                Controls.Add(_bMarkerTipControl);
                _bMarkerEditorControl.VisibleChanged += new EventHandler(_bMarkerEditorControl_VisibleChanged);
                _bMarkerTipControl.SearchNearbyStarted += new SearchNearbyStartedEventHandler(_bTipControl_SearchNearbyStarted);
                _bMarkerTipControl.DirecttionStarted += new DirectionStartedEventHandler(_bTipControl_DirecttionStarted);
                //标记点信息编辑控件
                _bMarkerEditorControl.Visible = false;
                Controls.Add(_bMarkerEditorControl);
                _bMarkerTipControl.VisibleChanged += new EventHandler(_bMarkerTipControl_VisibleChanged);
                //POI信息显示控件
                _bPOITipControl.Visible = false;
                Controls.Add(_bPOITipControl);
                _bPOITipControl.VisibleChanged+=new EventHandler(_bPOITipControl_VisibleChanged);
                _bPOITipControl.SearchNearbyStarted+=new SearchNearbyStartedEventHandler(_bTipControl_SearchNearbyStarted);
                _bPOITipControl.DirecttionStarted+=new DirectionStartedEventHandler(_bTipControl_DirecttionStarted);
                //位置点BPoint信息显示控件
                _bPointTipControl.Visible = false;
                Controls.Add(_bPointTipControl);
                _bPointTipControl.VisibleChanged += new EventHandler(_bPointTipControl_VisibleChanged);
                _bPointTipControl.SearchNearbyStarted+=new SearchNearbyStartedEventHandler(_bTipControl_SearchNearbyStarted);
                _bPointTipControl.DirecttionStarted+=new DirectionStartedEventHandler(_bTipControl_DirecttionStarted);
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
                    if (_location != null && _location["content"] != null)
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
                        if (_location["result"] != null && _location["result"]["addressComponent"] != null)
                        {
                            if (_zoom <= 8) //定位到国家
                            {
                                _currentCity = (string)(_location["result"]["addressComponent"]["country"]);  //返回JSON结构请参见百度API文档
                            }
                            else if (_zoom <= 10) //定位到省份
                            {
                                _currentCity = (string)(_location["result"]["addressComponent"]["province"]);  //返回JSON结构请参见百度API文档
                            }
                            else if (_zoom <= 18) //定位到城市
                            {
                                if (_location["result"]["addressComponent"]["city"] != null)
                                    _currentCity = (string)(_location["result"]["addressComponent"]["city"]);  //返回JSON结构请参见百度API文档
                            }
                            //else  //定位到县区
                            //{
                            //    if (_location["result"]["addressComponent"]["district"] != null)
                            //        _currentCity = (string)(_location["result"]["addressComponent"]["district"]); //返回JSON结构请参见百度API文档
                            //}
                        }
                    }                   
                }
                this.Invoke((Action)delegate()
                {
                    Invalidate();
                    if (BPlaceBox != null)  //关联的位置输入控件
                    {
                        BPlaceBox.CurrentCity = _currentCity;
                    }
                    if (BPlacesBoard != null) //关联的位置列表控件
                    {
                        BPlacesBoard.CurrentCity = _currentCity;
                    }
                    if (BDirectionBoard != null) //关联的导航控件
                    {
                        BDirectionBoard.CurrentCity = _currentCity;
                    }
                    _bMarkerTipControl.CurrentCity = _currentCity;
                    _bPOITipControl.CurrentCity = _currentCity;
                    _bPointTipControl.CurrentCity = _currentCity;
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
        /// 同步控件位置
        /// </summary>
        private void SyncControlsLocation()
        {
            if (_bQuickSearchControl.Visible && _b_bound != null) //同步位置
            {
                Point p1 = MapHelper.GetScreenLocationByLatLng(_b_bound.LeftTop, _center, _zoom, ClientSize);
                Point p2 = MapHelper.GetScreenLocationByLatLng(_b_bound.RightBottom, _center, _zoom, ClientSize);
                Point p = p1.Y > p2.Y ? p1 : p2;
                _bQuickSearchControl.Location = new Point(p.X - _bQuickSearchControl.Width, p.Y + 2);
            }
            if (_bMarkerEditorControl.Visible && _current_selected_marker != null)//同步位置
            {
                Point p = MapHelper.GetScreenLocationByLatLng(_current_selected_marker.Location, _center, _zoom, ClientSize);
                _bMarkerEditorControl.Location = new Point(p.X - _bMarkerEditorControl.Width / 3 + 37, p.Y - _bMarkerEditorControl.Height - 22);
            }
            if (_bMarkerTipControl.Visible && _current_selected_marker != null) //同步位置
            {
                Point p = MapHelper.GetScreenLocationByLatLng(_current_selected_marker.Location, _center, _zoom, ClientSize);
                _bMarkerTipControl.Location = new Point(p.X - _bMarkerTipControl.Width / 3 + 37, p.Y - _bMarkerTipControl.Height - _current_selected_marker.Rect.Height);
            }
            if (_bPOITipControl.Visible && _current_selected_poi != null) //同步位置
            {
                Point p = MapHelper.GetScreenLocationByLatLng(_current_selected_poi.Location, _center, _zoom, ClientSize);
                _bPOITipControl.Location = new Point(p.X - _bPOITipControl.Width / 3 + 37, p.Y - _bPOITipControl.Height - _current_selected_poi.Rect.Height);
            }
            if (_bPointTipControl.Visible && _current_selected_point != null) //同步设置
            {
                Point p = MapHelper.GetScreenLocationByLatLng(_current_selected_point.Location, _center, _zoom, ClientSize);
                _bPointTipControl.Location = new Point(p.X - _bPointTipControl.Width / 3 + 37, p.Y - _bPointTipControl.Height - _current_selected_point.Rect.Height);
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
                        if (ClientRectangle.Contains(p))
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
            if (_b_route != null)  //导航路线
            {
                _b_route.Draw(g, _center, _zoom, ClientSize);
            }
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
            foreach (KeyValuePair<string, BMarker> p in _markers) //标记点
            {
                p.Value.Draw(g, _center, _zoom, ClientSize);
            }
            if (_theStrangePoint != null)
            {
                _theStrangePoint.Draw(g, _center, _zoom, ClientSize);
            }
            if (_theRouteStart != null)
            {
                _theRouteStart.Draw(g, _center, _zoom, ClientSize);
            }
            if(_theRouteEnd != null)
            {
                _theRouteEnd.Draw(g, _center, _zoom, ClientSize);
            }
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
        /// 设置地图中路线起点、终点（可以设为null表示清空）
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        internal void SetRouteStartAndEnd(BPoint start, BPoint end)
        {
            _theRouteStart = start;
            _theRouteEnd = end;
            Invalidate();
        }
        /// <summary>
        /// 设置地图中的导航路线（可以设为null表示清空）
        /// </summary>
        /// <param name="route"></param>
        internal void SetRoute(BRoute route)
        {
            _b_route = route;
            _bPointTipControl.Visible = false;
            _bPOITipControl.Visible = false;
            _bMarkerEditorControl.Visible = false;
            _bMarkerTipControl.Visible = false;
            if (_theRouteStart != null && _theRouteEnd != null) //定位到路线中心
            {
                Center = new LatLngPoint((_theRouteEnd.Location.Lng + _theRouteStart.Location.Lng) / 2, (_theRouteStart.Location.Lat + _theRouteEnd.Location.Lat) / 2);
                Zoom = 13;
                Locate(false);
                SyncControlsLocation();
            }
            Invalidate();
        }
        /// <summary>
        /// 设置路线中高亮部分
        /// </summary>
        /// <param name="path"></param>
        /// <param name="enlarge"></param>
        internal void SetHighlightPath(string path, bool enlarge)
        {
            string[] points = path.Split(';');
            if (_b_route != null)
            {
                _b_route.HighlightPath = path;
                if (enlarge) //放大定位
                {
                    LatLngPoint lp = new LatLngPoint(double.Parse(points[0].Split(',')[0]), double.Parse(points[0].Split(',')[1]));
                    Center = lp;
                    Zoom = 18;
                    Locate(false);
                    SyncControlsLocation();
                }
                Invalidate();
            }
        }
        /// <summary>
        /// 选中地图中的POI
        /// </summary>
        /// <param name="poi"></param>
        internal void SelectBPOI(BPOI poi)
        {
            foreach (KeyValuePair<string, BPOI> p in _pois)
            {
                if (p.Value == poi)
                {
                    p.Value.Selected = true;
                    _current_selected_poi = p.Value;
                    //显示信息控件
                    Point point = MapHelper.GetScreenLocationByLatLng(p.Value.Location, _center, _zoom, ClientSize);
                    _bPOITipControl.POI = _current_selected_poi;
                    _bPOITipControl.Location = new Point(point.X - _bPOITipControl.Width / 3 + 35, point.Y - _bPOITipControl.Height - _current_selected_poi.Rect.Height);
                    _bPOITipControl.Visible = true;

                    //显示在屏幕区域
                    if (!ClientRectangle.Contains(new Rectangle(_bPOITipControl.Left, _bPOITipControl.Top, _bPOITipControl.Width, _bPOITipControl.Height)))
                    {
                        Center = p.Value.Location;
                        Zoom = 13;
                        Locate(false);
                        SyncControlsLocation();
                    }
                }
                else
                {
                    p.Value.Selected = false;
                }
            }
            Invalidate();
        }
        /// <summary>
        /// 选中地图中的位置点
        /// </summary>
        /// <param name="bpoint"></param>
        internal void SelectBPoint(BPoint bpoint)
        {
            if (_theRouteEnd == bpoint)
            {
                _theRouteEnd.Selected = true;
                //
                _current_selected_point = _theRouteEnd;
                Point point = MapHelper.GetScreenLocationByLatLng(_current_selected_point.Location, _center, _zoom, ClientSize);
                //信息显示控件
                _bPointTipControl.BPoint = _current_selected_point;
                _bPointTipControl.Location = new Point(point.X - _bPointTipControl.Width / 3 + 35, point.Y - _bPointTipControl.Height - _current_selected_point.Rect.Height);
                _bPointTipControl.Visible = true;

                if (!ClientRectangle.Contains(new Rectangle(_bPointTipControl.Left, _bPointTipControl.Top, _bPointTipControl.Width, _bPointTipControl.Height)))
                {
                    Center = _theRouteEnd.Location;
                    Zoom = 15;
                    Locate(false);
                    SyncControlsLocation();
                }
            }
            else if (_theRouteStart == bpoint)
            {
                _theRouteStart.Selected = true;
                //
                _current_selected_point = _theRouteStart;
                Point point = MapHelper.GetScreenLocationByLatLng(_current_selected_point.Location, _center, _zoom, ClientSize);
                //信息显示控件
                _bPointTipControl.BPoint = _current_selected_point;
                _bPointTipControl.Location = new Point(point.X - _bPointTipControl.Width / 3 + 35, point.Y - _bPointTipControl.Height - _current_selected_point.Rect.Height);
                _bPointTipControl.Visible = true;

                if (!ClientRectangle.Contains(new Rectangle(_bPointTipControl.Left, _bPointTipControl.Top, _bPointTipControl.Width, _bPointTipControl.Height)))
                {
                    Center = _theRouteStart.Location;
                    Zoom = 15;
                    Locate(false);
                    SyncControlsLocation();
                }
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
            if (BDirectionBoard != null)  //关联的导航控件
            {
                BDirectionBoard.CurrentCity = _currentCity;
            }
            _bMarkerTipControl.CurrentCity = _currentCity;
            _bPOITipControl.CurrentCity = _currentCity;
            _bPointTipControl.CurrentCity = _currentCity;
            Invalidate();
            ((Action)delegate()  //定位到指定城市
            {
                GeocodingService gs = new GeocodingService();
                JObject city_location = gs.Geocoding(_currentCity);
                if (city_location != null && city_location["result"] != null)
                {
                    Center = new LatLngPoint(double.Parse((string)city_location["result"]["location"]["lng"]), double.Parse((string)city_location["result"]["location"]["lat"]));
                    Locate(false);
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
                    sfd.Filter = "PNG文件(*.png)|*.png";
                    sfd.CheckPathExists = true;
                    sfd.DefaultExt = ".png";
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
            if(item.Name == "cmsWhere")  //这是哪里
            {
                LatLngPoint location = MapHelper.GetLatLngByScreenLocation(_right_mouse_point_cache, _center, _zoom, ClientSize);
                ((Action)delegate()
                {
                    GeocodingService gs = new GeocodingService();
                    JObject point = gs.DeGeocoding(location.Lat + "," + location.Lng); 
                    if (point != null) //具体json格式参见api文档
                    {
                        this.Invoke((Action)delegate()
                        {
                            _current_selected_point = _theStrangePoint = new BPoint { Type = PointType.Strange, Selected = true, Address = (string)point["result"]["formatted_address"], Location = location };
                            _bPointTipControl.BPoint = _theStrangePoint;
                            _bPointTipControl.Location = new Point(_right_mouse_point_cache.X - _bPointTipControl.Width / 3 + 37, _right_mouse_point_cache.Y - _bPointTipControl.Height - 34);
                            _bPointTipControl.Visible = true;
                        });
                    }
                }).BeginInvoke(null, null);
            }
            else if (item.Name == "cmsSetStart")  //设为起点
            {
                LatLngPoint location = MapHelper.GetLatLngByScreenLocation(_right_mouse_point_cache, _center, _zoom, ClientSize);
                ((Action)delegate()
                {
                    GeocodingService gs = new GeocodingService();
                    JObject point = gs.DeGeocoding(location.Lat + "," + location.Lng);
                    if (point != null) //具体json格式参见api文档
                    {
                        this.Invoke((Action)delegate()
                        {
                            _current_selected_point = _theRouteStart = new BPoint { Type = PointType.RouteStart, Selected = true, Address = (string)point["result"]["formatted_address"], Location = location };
                            _bPointTipControl.BPoint = _theRouteStart;
                            _bPointTipControl.Location = new Point(_right_mouse_point_cache.X - _bPointTipControl.Width / 3 + 37, _right_mouse_point_cache.Y - _bPointTipControl.Height - 34);
                            _bPointTipControl.Visible = true;

                            BDirectionBoard.SourcePlace = _theRouteStart.Address;
                        });
                    }
                }).BeginInvoke(null, null);
            }
            else if (item.Name == "cmsSetEnd")  //设为终点
            {
                LatLngPoint location = MapHelper.GetLatLngByScreenLocation(_right_mouse_point_cache, _center, _zoom, ClientSize);
                ((Action)delegate()
                {
                    GeocodingService gs = new GeocodingService();
                    JObject point = gs.DeGeocoding(location.Lat + "," + location.Lng);
                    if (point != null) //具体json格式参见api文档
                    {
                        this.Invoke((Action)delegate()
                        {
                            _current_selected_point = _theRouteEnd = new BPoint { Type = PointType.RouteEnd, Selected = true, Address = (string)point["result"]["formatted_address"], Location = location };
                            _bPointTipControl.BPoint = _theRouteEnd;
                            _bPointTipControl.Location = new Point(_right_mouse_point_cache.X - _bPointTipControl.Width / 3 + 37, _right_mouse_point_cache.Y - _bPointTipControl.Height - 34);
                            _bPointTipControl.Visible = true;

                            BDirectionBoard.DestinationPlace = _theRouteEnd.Address;
                        });
                    }
                }).BeginInvoke(null, null);
            }
            else if (item.Name == "cmsCenter") //居中
            {
                LatLngPoint lp = MapHelper.GetLatLngByScreenLocation(PointToClient(Cursor.Position), _center, _zoom, ClientSize);
                Center = lp;
                Locate(false);
                SyncControlsLocation();
            }
            else if (item.Name == "cmsLarge") //放大
            {
                int z = _zoom + 1;
                if (z >= 3 && z <= 19)
                {
                    Zoom = z;
                    Locate(false);
                    SyncControlsLocation();
                }
            }
            else if (item.Name == "cmsSmall") //缩小
            {
                int z = _zoom - 1;
                if (z >= 3 && z <= 19)
                {
                    Zoom = z;
                    Locate(false);
                    SyncControlsLocation();
                }
            }
            else if (item.Name == "cmsClearDrawings") //清空绘图
            {
                _drawingObjects.Clear();
            }
            else if (item.Name == "cmsClearMarkers") //清空标记
            {
                _markers.Clear();
            }
            else if (item.Name == "cmsRegionSaveAs") //可视区域另存为
            {
                using (SaveFileDialog sf = new SaveFileDialog())
                {
                    sf.CheckPathExists = true;
                    sf.Filter = "PNG文件(*.png)|*.png";
                    sf.DefaultExt = ".png";
                    if (sf.ShowDialog() == DialogResult.OK)
                    {
                        Bitmap b = new Bitmap(Width, Height);
                        this.DrawToBitmap(b, ClientRectangle);
                        b.Save(sf.FileName);
                    }
                }
            }
            Invalidate();
        }
        /// <summary>
        /// 标记编辑控件关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _bMarkerEditorControl_VisibleChanged(object sender, EventArgs e)
        {
            if (!_bMarkerEditorControl.Visible)
            {
                if (_bMarkerEditorControl.Saved) //已点击保存
                {
                    Point p = MapHelper.GetScreenLocationByLatLng(_current_selected_marker.Location, _center, _zoom, ClientSize);
                    _bMarkerTipControl.Edited = false;
                    _bMarkerTipControl.Deleted = false;
                    _bMarkerTipControl.Marker = _current_selected_marker;
                    _bMarkerTipControl.Location = new Point(p.X - _bMarkerTipControl.Width / 3 + 37, p.Y - _bMarkerTipControl.Height - _current_selected_marker.Rect.Height);
                    _bMarkerTipControl.Visible = true;
                }
                else
                {
                    _current_selected_marker = null;
                }
            }
        }
        /// <summary>
        /// POI信息显示控件关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _bPOITipControl_VisibleChanged(object sender, EventArgs e)
        {
            if (!_bPOITipControl.Visible)
            {
                _current_selected_poi = null;
                //取消选择
            }
        }
        /// <summary>
        /// 位置点信息显示控件关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _bPointTipControl_VisibleChanged(object sender, EventArgs e)
        {
            if (!_bPointTipControl.Visible)
            {
                _current_selected_point = _theStrangePoint = null;
            }
        }
        /// <summary>
        /// 标记信息显示控件关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _bMarkerTipControl_VisibleChanged(object sender, EventArgs e)
        {
            if (!_bMarkerTipControl.Visible)
            {
                if (_bMarkerTipControl.Deleted)  //已点击删除
                {
                    _markers.Remove(_current_selected_marker.Index.ToString());
                    _current_selected_marker = null;
                }
                else if (_bMarkerTipControl.Edited) //已点击编辑
                {
                    Point p = MapHelper.GetScreenLocationByLatLng(_current_selected_marker.Location, _center, _zoom, ClientSize);
                    _bMarkerEditorControl.Saved = false;
                    _bMarkerEditorControl.Marker = _current_selected_marker;
                    _bMarkerEditorControl.Location = new Point(p.X - _bMarkerEditorControl.Width / 3 + 37, p.Y - _bMarkerEditorControl.Height - _current_selected_marker.Rect.Height);
                    _bMarkerEditorControl.Visible = true;
                }
                else
                {
                    _current_selected_marker = null;
                }
            }
        }
        /// <summary>
        /// 导航开始
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="type"></param>
        void _bTipControl_DirecttionStarted(string source, string destination, RouteType type)
        {
            if (BDirectionBoard != null)
            {
                BDirectionBoard.SourcePlace = source;
                BDirectionBoard.DestinationPlace = destination;
            }
        }
        /// <summary>
        /// 周边搜索
        /// </summary>
        /// <param name="query"></param>
        /// <param name="center"></param>
        void _bTipControl_SearchNearbyStarted(string query, LatLngPoint center)
        {
            ((Action)delegate()
            {
                PlaceService ps = new PlaceService();
                JObject places = ps.SearchInCircle(query, center.Lat + "," + center.Lng, 5000); //默认周边5km
                this.Invoke((Action)delegate()
                {
                    if (BPlacesBoard != null)
                    {
                        BPlacesBoard.AddPlaces(places["results"]);  //具体json格式参见api文档
                    }
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
        public const double EARTH_RADIUS = 6378.137;//地球半径
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
            PointF dp = GetLocationByLatLng(p, zoom);  //目标点的像素坐标
            PointF cp = GetLocationByLatLng(center, zoom);  //中心点的像素坐标

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
        public static LatLngPoint GetLatLngByScreenLocation(PointF p, LatLngPoint center, int zoom, Size screen_size)
        {
            PointF cp = GetLocationByLatLng(center, zoom);  //中心点像素坐标

            //目标点与中心点屏幕坐标差
            float delta_x = p.X - screen_size.Width/2;  
            float delta_y = p.Y - screen_size.Height/2;

            PointF dp = new PointF(cp.X + delta_x, cp.Y + delta_y * (-1));  //目标点像素坐标

            return GetLatLngByLocation(dp, zoom);
        }
        /// <summary>
        /// 根据经纬度坐标计算该点的像素坐标
        /// </summary>
        /// <param name="p">要计算的经纬度</param>
        /// <param name="zoom">地图当前缩放级别</param>
        /// <returns></returns>
        public static PointF GetLocationByLatLng(LatLngPoint p, int zoom)
        {
            PointF mer_p = LatLng2Mercator(p);  //墨卡托坐标
            return new PointF((float)(mer_p.X / Math.Pow(2, 18 - zoom)), (float)(mer_p.Y / Math.Pow(2, 18 - zoom)));
        }
        /// <summary>
        /// 根据像素坐标计算该点的经纬度坐标
        /// </summary>
        /// <param name="p">要计算的像素坐标</param>
        /// <param name="zoom">地图缩放级别</param>
        /// <returns></returns>
        public static LatLngPoint GetLatLngByLocation(PointF p, int zoom)
        {
            PointF mer_p = new PointF((float)(p.X * Math.Pow(2, 18 - zoom)), (float)(p.Y * Math.Pow(2, 18 - zoom)));  //墨卡托坐标
            return Mercator2LatLng(mer_p);
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

        //以下是根据百度地图JavaScript API破解得到 百度坐标<->墨卡托坐标 转换算法
        private static double[] array1 = { 75, 60, 45, 30, 15, 0 };
        private static double[] array3 = { 12890594.86, 8362377.87, 5591021, 3481989.83, 1678043.12, 0 };
        private static double[][] array2 = {new double[]{-0.0015702102444, 111320.7020616939, 1704480524535203, -10338987376042340, 26112667856603880, -35149669176653700, 26595700718403920, -10725012454188240, 1800819912950474, 82.5}
                                               ,new double[]{0.0008277824516172526, 111320.7020463578, 647795574.6671607, -4082003173.641316, 10774905663.51142, -15171875531.51559, 12053065338.62167, -5124939663.577472, 913311935.9512032, 67.5}
                                               ,new double[]{0.00337398766765, 111320.7020202162, 4481351.045890365, -23393751.19931662, 79682215.47186455, -115964993.2797253, 97236711.15602145, -43661946.33752821, 8477230.501135234, 52.5}
                                               ,new double[]{0.00220636496208, 111320.7020209128, 51751.86112841131, 3796837.749470245, 992013.7397791013, -1221952.21711287, 1340652.697009075, -620943.6990984312, 144416.9293806241, 37.5}
                                               ,new double[]{-0.0003441963504368392, 111320.7020576856, 278.2353980772752, 2485758.690035394, 6070.750963243378, 54821.18345352118, 9540.606633304236, -2710.55326746645, 1405.483844121726, 22.5}
                                               ,new double[]{-0.0003218135878613132, 111320.7020701615, 0.00369383431289, 823725.6402795718, 0.46104986909093, 2351.343141331292, 1.58060784298199, 8.77738589078284, 0.37238884252424, 7.45}};
        private static double[][] array4 = {new double[]{1.410526172116255e-8, 0.00000898305509648872, -1.9939833816331, 200.9824383106796, -187.2403703815547, 91.6087516669843, -23.38765649603339, 2.57121317296198, -0.03801003308653, 17337981.2}
                                               ,new double[]{-7.435856389565537e-9, 0.000008983055097726239, -0.78625201886289, 96.32687599759846, -1.85204757529826, -59.36935905485877, 47.40033549296737, -16.50741931063887, 2.28786674699375, 10260144.86}
                                               ,new double[]{-3.030883460898826e-8, 0.00000898305509983578, 0.30071316287616, 59.74293618442277, 7.357984074871, -25.38371002664745, 13.45380521110908, -3.29883767235584, 0.32710905363475, 6856817.37}
                                               ,new double[]{-1.981981304930552e-8, 0.000008983055099779535, 0.03278182852591, 40.31678527705744, 0.65659298677277, -4.44255534477492, 0.85341911805263, 0.12923347998204, -0.04625736007561, 4482777.06}
                                               ,new double[]{3.09191371068437e-9, 0.000008983055096812155, 0.00006995724062, 23.10934304144901, -0.00023663490511, -0.6321817810242, -0.00663494467273, 0.03430082397953, -0.00466043876332, 2555164.4}
                                               ,new double[]{2.890871144776878e-9, 0.000008983055095805407, -3.068298e-8, 7.47137025468032, -0.00000353937994, -0.02145144861037, -0.00001234426596, 0.00010322952773, -0.00000323890364, 826088.5}};

        private static PointF LatLng2Mercator(LatLngPoint p)
        {
            double[] arr = null;
            double n_lat = p.Lat > 74 ? 74 : p.Lat;
            n_lat = n_lat < -74 ? -74 : n_lat;

            for (var i = 0; i < array1.Length; i++) 
            {
                if (p.Lat >= array1[i]) 
                {
                    arr = array2[i];
                    break;
                }
            }
            if (arr == null) {
                for (var i = array1.Length - 1; i >= 0; i--) {
                    if (p.Lat <= -array1[i]) 
                    {
                        arr = array2[i];
                        break;
                    }
                }
            }
            double[] res = Convertor(p.Lng, p.Lat, arr);
            return new PointF((float)res[0], (float)res[1]);
        }
        private static LatLngPoint Mercator2LatLng(PointF p)
        {
            double[] arr = null;
            PointF np = new PointF(Math.Abs(p.X),Math.Abs(p.Y));
            for (var i = 0; i < array3.Length; i++) {
                if (np.Y >= array3[i]) 
                {
                    arr = array4[i];
                    break;
                }
            }
            double[] res = Convertor(np.X, np.Y, arr);
            return new LatLngPoint(res[0],res[1]);
        }
        private static double[] Convertor(double x, double y, double[] param)
        {
            var T = param[0] + param[1] * Math.Abs(x);
            var cC = Math.Abs(y) / param[9];
            var cF = param[2] + param[3] * cC + param[4] * cC * cC + param[5] * cC * cC * cC + param[6] * cC * cC * cC * cC + param[7] * cC * cC * cC * cC * cC + param[8] * cC * cC * cC * cC * cC * cC;
            T *= (x < 0 ? -1 : 1);
            cF *= (y < 0 ? -1 : 1);
            return new double[] { T, cF };
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
