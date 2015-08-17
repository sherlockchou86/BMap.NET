using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Newtonsoft.Json.Linq;
using BMap.NET.WindowsForm.BMapElements;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// POI信息显示控件
    /// </summary>
    partial class BPOITipControl : UserControl
    {
        public event SearchNearbyStartedEventHandler SearchNearbyStarted;
        public event DirectionStartedEventHandler DirecttionStarted;
        /// <summary>
        /// 选项卡
        /// </summary>
        int _tab_index = 0;

        private BPOI _poi;
        /// <summary>
        /// 与之对应的POI
        /// </summary>
        public BPOI POI
        {
            get
            {
                return _poi;
            }
            set
            {
                _poi = value;
                //
                if (_poi.DataSource["name"] != null)
                    lnkName.Text = (string)_poi.DataSource["name"]; //具体json格式参见api文档
                if (_poi.DataSource["address"] != null)
                    txtAddress.Text = (string)_poi.DataSource["address"];
                if (_poi.DataSource["telephone"] != null)
                    txtPhone.Text = (string)_poi.DataSource["telephone"];
                if (_poi.DataSource["detail_info"] != null && _poi.DataSource["detail_info"]["price"] != null)
                    txtPrice.Text = "人均:￥" + (string)_poi.DataSource["detail_info"]["price"];
                if (_poi.DataSource["detail_info"] != null && _poi.DataSource["detail_info"]["tag"] != null)
                    txtTag.Text = (string)_poi.DataSource["detail_info"]["tag"];
            }
        }
        /// <summary>
        /// 当前建议搜索城市
        /// </summary>
        public string CurrentCity
        {
            get
            {
                return bPlaceBox.CurrentCity;
            }
            set
            {
                bPlaceBox.CurrentCity = value;
            }
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public BPOITipControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }

        #region 事件处理
        /// <summary>
        /// 控件加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPOITipControl_Load(object sender, EventArgs e)
        {
            //显示形状
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(new Point(0, 0), new Point(Width, 0));
            gp.AddLine(new Point(Width, 0), new Point(Width, Height - 40));
            gp.AddLine(new Point(Width / 3 + 20, Height - 40), new Point(Width, Height - 40));
            gp.AddLine(new Point(Width / 3 + 20, Height - 40), new Point(Width / 3 - 40, Height));
            gp.AddLine(new Point(Width / 3 - 40, Height), new Point(Width / 3 - 20, Height - 40));
            gp.AddLine(new Point(Width / 3 - 20, Height - 40), new Point(0, Height - 40));
            this.Region = new Region(gp);
        }
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPOITipControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //边框
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(new Point(0, 0), new Point(Width - 1, 0));
            gp.AddLine(new Point(Width - 1, 0), new Point(Width - 1, Height - 40 - 1));
            gp.AddLine(new Point(Width / 3 + 20 - 1, Height - 40 - 1), new Point(Width - 1, Height - 40 - 1));
            gp.AddLine(new Point(Width / 3 + 20 - 1, Height - 40 - 1), new Point(Width / 3 - 40, Height - 1));
            gp.AddLine(new Point(Width / 3 - 40, Height - 1), new Point(Width / 3 - 20 + 1, Height - 40 - 1));
            gp.AddLine(new Point(Width / 3 - 20 + 1, Height - 40 - 1), new Point(0, Height - 40 - 1));
            gp.AddLine(new Point(0, 0), new Point(0, Height - 40 - 1));
            e.Graphics.DrawPath(Pens.Gray, gp);

            using (Pen p = new Pen(Color.FromArgb(150, Color.LightGray)))
            {
                e.Graphics.DrawLine(p, new Point(0, 194 -15), new Point(Width, 194 - 15));
                e.Graphics.DrawLine(p, new Point(Width / 3, 194 + 26 - 15), new Point(Width / 3, 194 - 15));
                e.Graphics.DrawLine(p, new Point(Width * 2 / 3, 194 + 26 - 15), new Point(Width * 2 / 3, 194 - 15));

                e.Graphics.DrawImage(Properties.BMap.ico_destination, new Point(10, 194 + 5 - 15));
                e.Graphics.DrawImage(Properties.BMap.ico_source, new Point(Width / 3 + 10, 194 + 5 - 15));
                e.Graphics.DrawImage(Properties.BMap.ico_search_in_bound, new Rectangle(Width * 2 / 3 + 10, 194 + 5 - 15, 18, 18));

                using (Font f = new Font("微软雅黑", 9))
                {
                    if (_tab_index == 0) //到这里去
                    {
                        e.Graphics.DrawLine(p, new Point(Width / 3, 194 + 26 - 15), new Point(Width, 194 + 26 - 15));
                        e.Graphics.DrawString("到这里去", f, Brushes.Gray, new PointF(25, 194 + 5 - 15));
                        e.Graphics.DrawString("从这里出发", f, Brushes.Blue, new PointF(Width / 3 + 25, 194 + 5 - 15));
                        e.Graphics.DrawString("周边搜索", f, Brushes.Blue, new PointF(Width * 2 / 3 + 25, 194 + 5 - 15));
                    }
                    else if (_tab_index == 1) //从这里出发
                    {
                        e.Graphics.DrawLine(p, new Point(0, 194 + 26 - 15), new Point(Width / 3, 194 + 26 - 15));
                        e.Graphics.DrawLine(p, new Point(Width * 2 / 3, 194 + 26 - 15), new Point(Width, 194 + 26 - 15));
                        e.Graphics.DrawString("到这里去", f, Brushes.Blue, new PointF(25, 194 + 5 - 15));
                        e.Graphics.DrawString("从这里出发", f, Brushes.Gray, new PointF(Width / 3 + 25, 194 + 5 - 15));
                        e.Graphics.DrawString("周边搜索", f, Brushes.Blue, new PointF(Width * 2 / 3 + 25, 194 + 5 - 15));
                    }
                    else //周边搜索
                    {
                        e.Graphics.DrawLine(p, new Point(0, 194 + 26 - 15), new Point(Width * 2 / 3, 194 + 26 - 15));
                        e.Graphics.DrawString("到这里去", f, Brushes.Blue, new PointF(25, 194 + 5 - 15));
                        e.Graphics.DrawString("从这里出发", f, Brushes.Blue, new PointF(Width / 3 + 25, 194 + 5 - 15));
                        e.Graphics.DrawString("周边搜索", f, Brushes.Gray, new PointF(Width * 2 / 3 + 25, 194 + 5 - 15));
                    }
                }
            }
        }
        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPOITipControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (new Rectangle(0, 194 - 15, Width, 26).Contains(e.Location))
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Arrow;
            }
        }
        /// <summary>
        /// 鼠标点击 选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPOITipControl_Click(object sender, EventArgs e)
        {
            Point p = PointToClient(Cursor.Position);
            if (new Rectangle(0, 194 - 15, Width / 3, 26).Contains(p))  //到这里去
            {
                _tab_index = 0;
                lblPlace.Text = "起点";
                lblPlace.Visible = true;
                bPlaceBox.Visible = true;
                btndriving.Visible = true;
                btntransit.Visible = true;

                txtNearby.Visible = false;
                btnsearch.Visible = false;
                lnknearby_bank.Visible = false;
                lnknearby_bus_station.Visible = false;
                lnknearby_eatting.Visible = false;
                lnknearby_hospital.Visible = false;
                lnknearby_hotel.Visible = false;
            }
            if (new Rectangle(Width / 3, 194 - 15, Width / 3, 26).Contains(p))  //从这里出发
            {
                _tab_index = 1;
                lblPlace.Text = "终点";
                lblPlace.Visible = true;
                bPlaceBox.Visible = true;
                btndriving.Visible = true;
                btntransit.Visible = true;

                txtNearby.Visible = false;
                btnsearch.Visible = false;
                lnknearby_bank.Visible = false;
                lnknearby_bus_station.Visible = false;
                lnknearby_eatting.Visible = false;
                lnknearby_hospital.Visible = false;
                lnknearby_hotel.Visible = false;
            }
            if (new Rectangle(Width * 2 / 3, 194 - 15, Width / 3, 26).Contains(p)) //周边搜索
            {
                _tab_index = 2;

                lblPlace.Visible = false;
                bPlaceBox.Visible = false;
                btndriving.Visible = false;
                btntransit.Visible = false;

                txtNearby.Visible = true;
                btnsearch.Visible = true;
                lnknearby_bank.Visible = true;
                lnknearby_bus_station.Visible = true;
                lnknearby_eatting.Visible = true;
                lnknearby_hospital.Visible = true;
                lnknearby_hotel.Visible = true;

                lnknearby_bank.Location = new Point(lnknearby_bank.Location.X, 232 - 15 + 7);
                lnknearby_bus_station.Location = new Point(lnknearby_bus_station.Location.X, 232 - 15 + 7);
                lnknearby_eatting.Location = new Point(lnknearby_eatting.Location.X, 232 - 15 + 7);
                lnknearby_hospital.Location = new Point(lnknearby_hospital.Location.X, 232 - 15 + 7);
                lnknearby_hotel.Location = new Point(lnknearby_hotel.Location.X, 232 - 15 + 7);
                btnsearch.Location = new Point(btnsearch.Location.X, 225 - 15 + 7);
                txtNearby.Location = new Point(txtNearby.Location.X, 226 - 15 + 7);
            }
            Invalidate();
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
        /// <summary>
        /// POI界面的logo绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void piclogo_Paint(object sender, PaintEventArgs e)
        {
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(200, Color.White)))
            {
                e.Graphics.FillRectangle(sb, e.ClipRectangle);
            }
        }
        /// <summary>
        /// 公交导航
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btntransit_Click(object sender, EventArgs e)
        {
            if (DirecttionStarted != null)
            {
                if (_tab_index == 0) //到这里去
                {
                    DirecttionStarted(bPlaceBox.QueryText, (string)_poi.DataSource["name"], RouteType.Transit);
                }
                else //从这里出发
                {
                    DirecttionStarted((string)_poi.DataSource["name"], bPlaceBox.QueryText, RouteType.Transit);
                }
            }
        }
        /// <summary>
        /// 驾车导航
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btndriving_Click(object sender, EventArgs e)
        {
            if (DirecttionStarted != null && bPlaceBox.QueryText != "")
            {
                if (_tab_index == 0) //到这里去
                {
                    DirecttionStarted(bPlaceBox.QueryText, (string)_poi.DataSource["name"], RouteType.Driving);
                }
                else //从这里出发
                {
                    DirecttionStarted((string)_poi.DataSource["name"], bPlaceBox.QueryText, RouteType.Driving);
                }
            }
        }
        /// <summary>
        /// 周边搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (SearchNearbyStarted != null && txtNearby.Text != "")
            {
                SearchNearbyStarted(txtNearby.Text, _poi.Location);
            }
        }
        /// <summary>
        /// 快速周边搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SearchNearbyStarted != null)
            {
                SearchNearbyStarted((sender as LinkLabel).Text, _poi.Location);
            }
        }
        #endregion
    }
}
