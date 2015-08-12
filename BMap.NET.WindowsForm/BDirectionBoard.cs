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
        /// 当前方案 0公交 1驾车 2步行
        /// </summary>
        private int _current_method = 0;
        /// <summary>
        /// 方案类型 0时间短 1少换乘 2少步行  3最短路程 4最短时间 5不走高速
        /// </summary>
        private int _method_filter = 0;
        /// <summary>
        /// 构造方法
        /// </summary>
        public BDirectionBoard()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
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
                _current_method = 0;
                _method_filter = 0;
            }
            else if (new Rectangle(Width / 3, 0, Width / 3, 33).Contains(p)) //驾车模式
            {
                _current_method = 1;
                _method_filter = 3;
            }
            else if (new Rectangle(Width * 2 / 3, 0, Width / 3, 33).Contains(p))  //步行模式
            {
                _current_method = 2;
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
        #endregion

        #region 公开方法
        /// <summary>
        /// 开启搜索
        /// </summary>
        public void StartSearch()
        {
            ((Action)delegate()
            {
                JObject routes;
                DirectionService ds = new DirectionService();
                if (_current_method == 0) //公交
                {
                    if (bPlaceBoxSource.City != bPlaceBoxDestination.City)
                    {
                        MessageBox.Show("公交导航时，两地城市必须一致！");
                        return;
                    }
                    routes = ds.DirectionByTransit(bPlaceBoxSource.QueryText, bPlaceBoxDestination.QueryText, _currentCity);
                }
                else if (_current_method == 1) //驾车
                {
                    routes = ds.DirectionByDriving(bPlaceBoxSource.QueryText, bPlaceBoxDestination.QueryText, bPlaceBoxSource.City, bPlaceBoxDestination.City);
                }
                else //步行
                {
                    if (bPlaceBoxSource.City != bPlaceBoxDestination.City)
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
                        if ((string)routes["type"] == "2") //正常结果
                        {
                            flpRoutes.Controls.Clear();
                            if (_current_method == 0) //公交
                            {
                                foreach (JObject route in routes["result"]["routes"])
                                {
                                    BTransitRouteItem item = new BTransitRouteItem();
                                    item.DataSource = route;
                                    flpRoutes.Controls.Add(item);
                                    item.Width = flpRoutes.Width - 25;
                                }
                            }
                            else if (_current_method == 1) //驾车
                            {
                                foreach (JObject route in routes["result"]["routes"])
                                {
                                    BDrivingRouteItem item = new BDrivingRouteItem();
                                    item.DataSource = route;
                                    flpRoutes.Controls.Add(item);
                                    item.Width = flpRoutes.Width - 25;
                                }
                            }
                            else
                            {

                            }
                        }
                        else //地址模糊 需重新选择
                        {
                            //
                        }
                    });
                }
            }).BeginInvoke(null, null);
        }
        #endregion

    }
}
