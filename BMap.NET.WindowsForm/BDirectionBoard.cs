using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using BMap.NET.HTTPService;
using BMap.NET.WindowsForm.BMapElements;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// 导航控件
    /// </summary>
    public partial class BDirectionBoard : UserControl
    {
        private string _currentCity;
        /// <summary>
        /// 当前建议搜索城市
        /// </summary>
        [Description("当前建议搜索城市"),Category("BMap.NET")]
        public string CurrentCity
        {
            get
            {
                return _currentCity;
            }
            set
            {
                _currentCity = value;
                bPlaceBoxSource.CurrentCity = _currentCity;
                bPlaceBoxDestination.CurrentCity = _currentCity;
            }
        }
        /// <summary>
        /// 与之关联的地图控件
        /// </summary>
        [Description("与之关联的地图控件"),Category("BMap.NET")]
        public BMapControl BMapControl
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
            get;
            set;
        }
        /// <summary>
        /// 导航起始位置
        /// </summary>
        [Description("导航起始位置"),Category("BMap.NET")]
        internal string SourcePlace
        {
            get
            {
                return bPlaceBoxSource.QueryText;
            }
            set
            {
                bPlaceBoxSource.DontSearchNextTime();
                bPlaceBoxSource.QueryText = value;
                if (bPlaceBoxSource.QueryText != "" && bPlaceBoxDestination.QueryText != "") //导航起点、终点不为空
                {
                    StartSearch();
                }
                if (Parent != null && Parent is TabPage) //如果父控件是tabpage 则选中
                {
                    ((Parent as TabPage).Parent as TabControl).SelectedTab = (Parent as TabPage);
                }
            }
        }
        /// <summary>
        /// 导航结束位置
        /// </summary>
        [Description("导航结束位置"),Category("BMap.NET")]
        internal string DestinationPlace
        {
            get
            {
                return bPlaceBoxDestination.QueryText;
            }
            set
            {
                bPlaceBoxDestination.DontSearchNextTime();
                bPlaceBoxDestination.QueryText = value;
                if (bPlaceBoxDestination.QueryText != "" && bPlaceBoxSource.QueryText != "")  //导航起点、终点不为空
                {
                    StartSearch();
                }
                if (Parent != null && Parent is TabPage) //如果父控件是tabpage 则选中
                {
                    ((Parent as TabPage).Parent as TabControl).SelectedTab = (Parent as TabPage);
                }
            }
        }

        /// <summary>
        /// 当前方案 0公交 1驾车 2步行
        /// </summary>
        private int _current_method = 0;
        /// <summary>
        /// 方案类型 0时间短 1少换乘 2少步行  3最短路程 4最短时间 5不走高速
        /// </summary>
        private int _method_filter = 0;

        private Label _wait = new Label(); //等待框
        /// <summary>
        /// 构造方法
        /// </summary>
        public BDirectionBoard()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

            _wait.AutoSize = false; _wait.Font = new System.Drawing.Font("微软雅黑", 10);
            _wait.Width = Width; _wait.Height = Height; _wait.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _wait.BackColor = Color.FromArgb(200, Color.White);
            _wait.TextAlign = ContentAlignment.MiddleCenter;
            _wait.Text = "正在搜索,请稍候...";
            _wait.Visible = false;
            _wait.Location = new Point(0, 0);
            Controls.Add(_wait);
            _wait.BringToFront();
        }

        #region 事件处理
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDirectionBoard_Paint(object sender, PaintEventArgs e)
        {
            //顶部 方案选择
            if (_current_method == 0) //公交
            {
                e.Graphics.DrawImage(Properties.BMap.ico_transit_blue, new Point(Width / 3 / 2 - 30, 3));
                e.Graphics.DrawImage(Properties.BMap.ico_driving_gray, new Point(Width / 3 + Width / 3 / 2 - 30, 3));
                e.Graphics.DrawImage(Properties.BMap.ico_walking_gray, new Point(Width * 2 / 3 + Width / 3 / 2 - 30, 3));
                e.Graphics.DrawLine(Pens.LightBlue, new Point(0, 33), new Point(Width / 3 / 2 - 3, 33));
                e.Graphics.DrawLine(Pens.LightBlue, new Point(Width / 3 / 2 + 3, 33), new Point(Width, 33));
                e.Graphics.DrawLine(Pens.LightBlue, new Point(Width / 3 / 2 - 3, 33), new Point(Width / 3 / 2, 30));
                e.Graphics.DrawLine(Pens.LightBlue, new Point(Width / 3 / 2 + 3, 33), new Point(Width / 3 / 2, 30));
            }
            else if (_current_method == 1) //驾车
            {
                e.Graphics.DrawImage(Properties.BMap.ico_transit_gray, new Point(Width / 3 / 2 - 30, 3));
                e.Graphics.DrawImage(Properties.BMap.ico_driving_blue, new Point(Width / 3 + Width / 3 / 2 - 30, 3));
                e.Graphics.DrawImage(Properties.BMap.ico_walking_gray, new Point(Width * 2 / 3 + Width / 3 / 2 - 30, 3));
                e.Graphics.DrawLine(Pens.LightBlue, new Point(0, 33), new Point(Width / 3 + Width / 3 / 2 - 3, 33));
                e.Graphics.DrawLine(Pens.LightBlue, new Point(Width / 3 + Width / 3 / 2 + 3, 33), new Point(Width, 33));
                e.Graphics.DrawLine(Pens.LightBlue, new Point(Width / 3 + Width / 3 / 2 - 3, 33), new Point(Width / 3 + Width / 3 / 2, 30));
                e.Graphics.DrawLine(Pens.LightBlue, new Point(Width / 3 + Width / 3 / 2 + 3, 33), new Point(Width / 3 + Width / 3 / 2, 30));
            }
            else //步行
            {
                e.Graphics.DrawImage(Properties.BMap.ico_transit_gray, new Point(Width / 3 / 2 - 30, 3));
                e.Graphics.DrawImage(Properties.BMap.ico_driving_gray, new Point(Width / 3 + Width / 3 / 2 - 30, 3));
                e.Graphics.DrawImage(Properties.BMap.ico_walking_blue, new Point(Width * 2 / 3 + Width / 3 / 2 - 30, 3));
                e.Graphics.DrawLine(Pens.LightBlue, new Point(0, 33), new Point(Width * 2 / 3 + Width / 3 / 2 - 3, 33));
                e.Graphics.DrawLine(Pens.LightBlue, new Point(Width * 2 / 3 + Width / 3 / 2 + 3, 33), new Point(Width, 33));
                e.Graphics.DrawLine(Pens.LightBlue, new Point(Width * 2 / 3 + Width / 3 / 2 - 3, 33), new Point(Width * 2 / 3 + Width / 3 / 2, 30));
                e.Graphics.DrawLine(Pens.LightBlue, new Point(Width * 2 / 3 + Width / 3 / 2 + 3, 33), new Point(Width * 2 / 3 + Width / 3 / 2, 30));
            }

            //中部 方案类型
            if (_current_method == 0) //公交
            {
                if (_method_filter == 0) //时间短
                {
                    e.Graphics.FillRectangle(Brushes.WhiteSmoke, new Rectangle(3, 135, (Width - 25) / 3, 25));
                    e.Graphics.DrawImage(Properties.BMap.ico_select, new Point(3 + 3, 135 + 5));
                }
                else if (_method_filter == 1) //少换乘
                {
                    e.Graphics.FillRectangle(Brushes.WhiteSmoke, new Rectangle(3 + (Width - 25) / 3, 135, (Width - 25) / 3, 25));
                    e.Graphics.DrawImage(Properties.BMap.ico_select, new Point(3 + (Width - 25) / 3 + 3, 135 + 5));
                }
                else if (_method_filter == 2) //少步行
                {
                    e.Graphics.FillRectangle(Brushes.WhiteSmoke, new Rectangle(3 + 2 * (Width - 25) / 3, 135, (Width - 25) / 3, 25));
                    e.Graphics.DrawImage(Properties.BMap.ico_select, new Point(3 + 2 * (Width - 25) / 3 + 3, 135 + 5));
                }
                e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(3, 135, (Width - 25) / 3, 25));
                e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(3 + (Width - 25) / 3, 135, (Width - 25) / 3, 25));
                e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(3 + 2 * (Width - 25) / 3, 135, (Width - 25) / 3, 25));

                e.Graphics.DrawString("时间短", new Font("微软雅黑", 10), Brushes.Gray, new PointF(3 + 21, 135 + 3));
                e.Graphics.DrawString("少换乘", new Font("微软雅黑", 10), Brushes.Gray, new PointF(3 + (Width - 25) / 3 + 21, 135 + 3));
                e.Graphics.DrawString("少步行", new Font("微软雅黑", 10), Brushes.Gray, new PointF(3 + 2 * (Width - 25) / 3 + 21, 135 + 3));
            }
            else if (_current_method == 1) //驾车
            {
                if (_method_filter == 3) //最短路程
                {
                    e.Graphics.FillRectangle(Brushes.WhiteSmoke, new Rectangle(3, 135, (Width - 25) / 3, 25));
                    e.Graphics.DrawImage(Properties.BMap.ico_select, new Point(3 + 3, 135 + 5));
                }
                else if (_method_filter == 4) //最短距离
                {
                    e.Graphics.FillRectangle(Brushes.WhiteSmoke, new Rectangle(3 + (Width - 25) / 3, 135, (Width - 25) / 3, 25));
                    e.Graphics.DrawImage(Properties.BMap.ico_select, new Point(3 + (Width - 25) / 3 + 3, 135 + 5));
                }
                else if (_method_filter == 5) //不走高速
                {
                    e.Graphics.FillRectangle(Brushes.WhiteSmoke, new Rectangle(3 + 2 * (Width - 25) / 3, 135, (Width - 25) / 3, 25));
                    e.Graphics.DrawImage(Properties.BMap.ico_select, new Point(3 + 2 * (Width - 25) / 3 + 3, 135 + 5));
                }

                e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(3, 135, (Width - 25) / 3, 25));
                e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(3 + (Width - 25) / 3, 135, (Width - 25) / 3, 25));
                e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(3 + 2 * (Width - 25) / 3, 135, (Width - 25) / 3, 25));

                e.Graphics.DrawString("最短时间", new Font("微软雅黑", 10), Brushes.Gray, new PointF(3 + 20, 135 + 3));
                e.Graphics.DrawString("最短路程", new Font("微软雅黑", 10), Brushes.Gray, new PointF(3 + (Width - 25) / 3 + 20, 135 + 3));
                e.Graphics.DrawString("不走高速", new Font("微软雅黑", 10), Brushes.Gray, new PointF(3 + 2 * (Width - 25) / 3 + 20, 135 + 3));
            }
            //步行没有方案类型
        }
        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDirectionBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (new Rectangle(0, 0, Width, 33).Contains(e.Location) 
                || ((new Rectangle(5, 135, Width - 10, 25).Contains(e.Location)) && _current_method != 2))  //顶端 中部 鼠标成手型
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Arrow;
            }
        }
        /// <summary>
        /// 鼠标点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDirectionBoard_Click(object sender, EventArgs e)
        {
            Point p = this.PointToClient(Cursor.Position);
            if (new Rectangle(0, 0, Width / 3, 33).Contains(p))  //公交模式
            {
                if (_current_method != 0)
                {
                    if (_current_method == 2)
                    {
                        flpRoutes.Height = flpRoutes.Height - (171 - 138);
                    }
                    _current_method = 0;
                    _method_filter = 0;                  
                    flpRoutes.Location = new Point(flpRoutes.Location.X, 171);
                    StartSearch(); //开启搜索
                }
            }
            else if (new Rectangle(Width / 3, 0, Width / 3, 33).Contains(p)) //驾车模式
            {
                if (_current_method != 1)
                {
                    if (_current_method == 2)
                    {
                        flpRoutes.Height = flpRoutes.Height - (171 - 138);
                    }
                    _current_method = 1;
                    _method_filter = 3;
                    flpRoutes.Location = new Point(flpRoutes.Location.X, 171);
                    StartSearch(); //开启搜索
                }
            }
            else if (new Rectangle(Width * 2 / 3, 0, Width / 3, 33).Contains(p))  //步行模式
            {
                if (_current_method != 2)
                {
                    _current_method = 2;
                    flpRoutes.Height = flpRoutes.Height + (171 - 138);
                    flpRoutes.Location = new Point(flpRoutes.Location.X, 138);
                    StartSearch(); //开启搜索
                }
            }

            if (_current_method == 0) //公交
            {
                if (new Rectangle(5, 135, (Width - 10) / 3, 25).Contains(p)) //时间短
                {
                    _method_filter = 0;
                }
                else if (new Rectangle(5 + (Width - 10)/3, 135, (Width - 10) / 3, 25).Contains(p)) //少换乘
                {
                    _method_filter = 1;
                }
                else if (new Rectangle(5 + 2 * (Width - 10) / 3, 135, (Width - 10) / 3, 25).Contains(p)) //少步行
                {
                    _method_filter = 2;
                }
            }
            if (_current_method == 1) //驾车
            {
                if (new Rectangle(5, 135, (Width - 10) / 3, 25).Contains(p)) //最短距离
                {
                    _method_filter = 3;
                }
                else if (new Rectangle(5 + (Width - 10) / 3, 135, (Width - 10) / 3, 25).Contains(p)) //最短时间
                {
                    _method_filter = 4;
                }
                else if (new Rectangle(5 + 2 * (Width - 10) / 3, 135, (Width - 10) / 3, 25).Contains(p)) //不走高速
                {
                    _method_filter = 5;
                }
            }
            Invalidate();
        }
        /// <summary>
        /// 鼠标进入搜索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            lblSearch.ForeColor = Color.White;
            lblSearch.BackColor = Color.FromArgb(51, 133, 255);
        }
        /// <summary>
        /// 鼠标移出搜索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            lblSearch.ForeColor = Color.DarkGray;
            lblSearch.BackColor = Color.WhiteSmoke;
        }
        /// <summary>
        /// 互换位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picExchange_Click(object sender, EventArgs e)
        {
            string te = bPlaceBoxDestination.QueryText;
            bPlaceBoxDestination.DontSearchNextTime();
            bPlaceBoxSource.DontSearchNextTime();

            bPlaceBoxDestination.QueryText = bPlaceBoxSource.QueryText;
            bPlaceBoxSource.QueryText = te;
        }
        /// <summary>
        /// 发起搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblSearch_Click(object sender, EventArgs e)
        {
            StartSearch();
        }

        /// <summary>
        /// 路线选中
        /// </summary>
        /// <param name="bRoute"></param>
        void item_RouteSelected(BRoute bRoute)
        {
            foreach (Control c in flpRoutes.Controls)
            {
                if (c as BTransitRouteItem != null && (c as BTransitRouteItem).DataSource != bRoute)
                {
                    (c as BTransitRouteItem).Selected = false;
                }
                if (c as BWalkingRouteItem != null && (c as BWalkingRouteItem).DataSource != bRoute)
                {
                    (c as BWalkingRouteItem).Selected = false;
                }
                if (c as BDrivingRouteItem != null && (c as BDrivingRouteItem).DataSource != bRoute)
                {
                    (c as BDrivingRouteItem).Selected = false;
                }
            }
            if (BMapControl != null)
            {
                BMapControl.SetRoute(bRoute); //更新地图中的路线
            }
        }
        /// <summary>
        /// 路线步骤选中
        /// </summary>
        /// <param name="stepPath"></param>
        /// <param name="enlarge"></param>
        void item_StepSelected(string stepPath, bool enlarge)
        {
            if (BMapControl != null)
            {
                BMapControl.SetHighlightPath(stepPath, enlarge); //高亮设置
            }
        }
        /// <summary>
        /// 路线起点终点选中
        /// </summary>
        /// <param name="bPoint"></param>
        void item_StepEndPointSelected(BPoint bPoint)
        {
            //
            if (BMapControl != null)
            {
                BMapControl.SelectBPoint(bPoint);
            }
        }
        /// <summary>
        /// 选择终点
        /// </summary>
        /// <param name="placeName"></param>
        /// <param name="type"></param>
        void sugg_end_EndPointSelected(string placeName, PointType type)
        {
            DestinationPlace = placeName;
        }
        /// <summary>
        /// 选择起点
        /// </summary>
        /// <param name="placeName"></param>
        /// <param name="type"></param>
        void sugg_start_EndPointSelected(string placeName, PointType type)
        {
            SourcePlace = placeName;
        }
        #endregion

        #region 公开方法
        /// <summary>
        /// 开启搜索
        /// </summary>
        internal void StartSearch()
        {
            flpRoutes.Controls.Clear();
            if (BMapControl != null)
            {
                BMapControl.SetRoute(null); //
                BMapControl.SetRouteStartAndEnd(null, null);
            }
            if (BPlacesBoard != null) //位置列表初始化
            {
                BPlacesBoard.Clear();
            }
            _wait.Visible = true; //等待
            ((Action)delegate()
            {
                JObject routes;
                DirectionService ds = new DirectionService();
                if (_current_method == 0) //公交
                {
                    if (bPlaceBoxSource.City != "" && bPlaceBoxDestination.City != "" && bPlaceBoxSource.City != bPlaceBoxDestination.City)
                    {
                        MessageBox.Show("公交导航时，两地城市必须一致！");
                        return;
                    }
                    routes = ds.DirectionByTransit(bPlaceBoxSource.QueryText, bPlaceBoxDestination.QueryText, _currentCity);
                }
                else if (_current_method == 1) //驾车
                {
                    routes = ds.DirectionByDriving(bPlaceBoxSource.QueryText, bPlaceBoxDestination.QueryText, bPlaceBoxSource.City == "" ? bPlaceBoxSource.CurrentCity : bPlaceBoxSource.City
                        , bPlaceBoxDestination.City == "" ? bPlaceBoxDestination.CurrentCity : bPlaceBoxDestination.City);
                }
                else //步行
                {
                    if (bPlaceBoxSource.City != "" && bPlaceBoxDestination.City != "" && bPlaceBoxSource.City != bPlaceBoxDestination.City)
                    {
                        MessageBox.Show("步行导航时，两地城市必须一致！");
                        return;
                    }
                    routes = ds.DirectionByWalking(bPlaceBoxSource.QueryText, bPlaceBoxDestination.QueryText, _currentCity);
                }
                if (routes != null && (string)routes["status"] == "0") //搜索成功
                {
                    this.Invoke((Action)delegate()
                    {
                        _wait.Visible = false;
                        if ((string)routes["type"] == "2") //正常结果
                        {
                            //生成起点终点
                            BPoint start = new BPoint { Type = PointType.RouteStart, Selected = false, Address = bPlaceBoxSource.QueryText, Location = new LatLngPoint(double.Parse((string)routes["result"]["origin"]["originPt"]["lng"]), double.Parse((string)routes["result"]["origin"]["originPt"]["lat"])) };
                            BPoint end = new BPoint { Type = PointType.RouteEnd, Selected = false, Address = bPlaceBoxDestination.QueryText, Location = new LatLngPoint(double.Parse((string)routes["result"]["destination"]["destinationPt"]["lng"]), double.Parse((string)routes["result"]["destination"]["destinationPt"]["lat"])) };
                            if (BMapControl != null)
                            {
                                BMapControl.SetRouteStartAndEnd(start, end); //设置地图中对应的起点 终点
                            } 
                            if (_current_method == 0) //公交
                            {
                                BTaxiTipControl taxi = new BTaxiTipControl();
                                taxi.DataSource = routes["result"]["taxi"]; //打车信息
                                taxi.Width = flpRoutes.Width - 25;
                                flpRoutes.Controls.Add(taxi);
                                foreach (JObject route in routes["result"]["routes"])
                                {
                                    BTransitRouteItem item = new BTransitRouteItem();

                                    BStepStartAndEndItem origin = new BStepStartAndEndItem();
                                    origin.EndPoint = start;                             
                                    item.Origin = origin; //起点

                                    BStepStartAndEndItem destination = new BStepStartAndEndItem();
                                    destination.EndPoint = end;
                                    item.Destination = destination; //终点

                                    item.DataSource = new BRoute { Type = RouteType.Transit, DataSource = route };
                                    flpRoutes.Controls.Add(item);
                                    item.Width = flpRoutes.Width - 25;

                                    item.StepEndPointSelected += new StepEndPointSelectedEventHandler(item_StepEndPointSelected);
                                    item.StepSelected += new StepSelectedEventHandler(item_StepSelected);
                                    item.RouteSelected += new RouteSelectedEventHandler(item_RouteSelected);
                                }
                            }
                            else if (_current_method == 1) //驾车
                            {
                                BTaxiTipControl taxi = new BTaxiTipControl();
                                taxi.DataSource = routes["result"]["taxi"]; //打车信息
                                taxi.Width = flpRoutes.Width - 25;
                                flpRoutes.Controls.Add(taxi);
                                foreach (JObject route in routes["result"]["routes"])
                                {
                                    BDrivingRouteItem item = new BDrivingRouteItem();

                                    BStepStartAndEndItem origin = new BStepStartAndEndItem();
                                    origin.EndPoint = start;
                                    item.Origin = origin; //起点

                                    BStepStartAndEndItem destination = new BStepStartAndEndItem();
                                    destination.EndPoint = end;
                                    item.Destination = destination; //终点

                                    item.DataSource = new BRoute { DataSource = route, Type = RouteType.Driving };
                                    flpRoutes.Controls.Add(item);
                                    item.Width = flpRoutes.Width - 25;

                                    item.StepEndPointSelected += new StepEndPointSelectedEventHandler(item_StepEndPointSelected);
                                    item.StepSelected += new StepSelectedEventHandler(item_StepSelected);
                                    item.RouteSelected += new RouteSelectedEventHandler(item_RouteSelected);
                                }
                            }
                            else  //步行
                            {
                                //步行没有打车信息
                                foreach (JObject route in routes["result"]["routes"])
                                {
                                    BWalkingRouteItem item = new BWalkingRouteItem();

                                    BStepStartAndEndItem origin = new BStepStartAndEndItem();
                                    origin.EndPoint = start;
                                    item.Origin = origin; //起点

                                    BStepStartAndEndItem destination = new BStepStartAndEndItem();
                                    destination.EndPoint = end;
                                    item.Destination = destination; //终点

                                    item.DataSource = new BRoute { DataSource = route, Type = RouteType.Walking };
                                    flpRoutes.Controls.Add(item);
                                    item.Width = flpRoutes.Width - 25;

                                    item.StepEndPointSelected += new StepEndPointSelectedEventHandler(item_StepEndPointSelected);
                                    item.StepSelected += new StepSelectedEventHandler(item_StepSelected);
                                    item.RouteSelected += new RouteSelectedEventHandler(item_RouteSelected);
                                }
                            }
                        }
                        else //地址模糊 需重新选择  具体json格式参见api文档
                        {
                            //
                            string start_keyword = (string)routes["result"]["originInfo"]["wd"];
                            string end_keyword = (string)routes["result"]["destinationInfo"]["wd"];
                            Label l = new Label();
                            l.AutoSize = false;
                            l.ForeColor = Color.Red;
                            l.Width = flpRoutes.Width - 25; l.Height = 20;
                            l.TextAlign = ContentAlignment.MiddleCenter;
                            l.Text = "请选择准确的位置";
                            flpRoutes.Controls.Add(l);
                            if (routes["result"]["origin"] != null) //起点模糊
                            {
                                if (routes["result"]["origin"] is JArray) //公交
                                {
                                    BPlacesSuggestionControl sugg_start = new BPlacesSuggestionControl();
                                    sugg_start.Type = PointType.RouteStart;
                                    sugg_start.KeyWord = start_keyword;
                                    sugg_start.Content = routes["result"]["origin"];
                                    sugg_start.Width = flpRoutes.Width - 25;
                                    sugg_start.EndPointSelected += new EndPointSelectedEventHandler(sugg_start_EndPointSelected);
                                    flpRoutes.Controls.Add(sugg_start);
                                }
                                else //驾车 步行
                                {
                                    BPlacesSuggestionControl sugg_start = new BPlacesSuggestionControl();
                                    sugg_start.Type = PointType.RouteStart;
                                    sugg_start.KeyWord = start_keyword;
                                    sugg_start.Content = routes["result"]["origin"]["content"];
                                    sugg_start.Width = flpRoutes.Width - 25;
                                    sugg_start.EndPointSelected += new EndPointSelectedEventHandler(sugg_start_EndPointSelected);
                                    flpRoutes.Controls.Add(sugg_start);
                                }
                            }
                            if (routes["result"]["destination"] != null) //终点模糊
                            {
                                if (routes["result"]["destination"] is JArray) //公交
                                {
                                    BPlacesSuggestionControl sugg_end = new BPlacesSuggestionControl();
                                    sugg_end.Type = PointType.RouteEnd;
                                    sugg_end.KeyWord = end_keyword;
                                    sugg_end.Content = routes["result"]["destination"];
                                    sugg_end.Width = flpRoutes.Width - 25;
                                    sugg_end.EndPointSelected += new EndPointSelectedEventHandler(sugg_end_EndPointSelected);
                                    flpRoutes.Controls.Add(sugg_end);
                                }
                                else
                                {
                                    BPlacesSuggestionControl sugg_end = new BPlacesSuggestionControl();
                                    sugg_end.Type = PointType.RouteEnd;
                                    sugg_end.KeyWord = end_keyword;
                                    sugg_end.Content = routes["result"]["destination"]["content"];
                                    sugg_end.Width = flpRoutes.Width - 25;
                                    sugg_end.EndPointSelected += new EndPointSelectedEventHandler(sugg_end_EndPointSelected);
                                    flpRoutes.Controls.Add(sugg_end);
                                }
                            }
                        }
                    });
                }
            }).BeginInvoke(null, null);
        }
        /// <summary>
        /// 清空导航控件（初始化）
        /// </summary>
        public void Clear()
        {
            flpRoutes.Controls.Clear();
            if (BMapControl != null)
            {
                BMapControl.SetRoute(null); //
                BMapControl.SetRouteStartAndEnd(null, null);
            }
        }
        #endregion

    }
}
