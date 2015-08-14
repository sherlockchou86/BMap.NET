using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// 导航时，选择打车方案信息显示控件
    /// </summary>
    partial class BTaxiTipControl : UserControl
    {
        private JToken _dataSource;
        /// <summary>
        /// 打车数据源
        /// </summary>
        public JToken DataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                if (_dataSource != null) //解析 具体json格式参见api文档
                {
                    lnkTaxiTip.Text = "打车费用\n";
                    string info = "总距离：" + Math.Round(double.Parse((string)_dataSource["distance"]) / 1000, 1) + "公里" + " 总时间：" + Math.Round(double.Parse((string)_dataSource["duration"]) / 60, 0) + "分钟" + "\n";
                    foreach (JObject p in _dataSource["detail"])
                    {
                        info += ((string)p["desc"] + " " + (string)p["km_price"] + "元/km 起步价：" + (string)p["start_price"] + " 总费用：" + (string)p["total_price"] + "\n");
                        lnkTaxiTip.Text += ((string)p["desc"] + ":" + (string)p["total_price"]) + "元\n";
                    }
                    lnkTaxiTip.Text = lnkTaxiTip.Text.TrimEnd(new char[] { '|'});
                    Height = lnkTaxiTip.Height + 20;
                    lnkTaxiTip.Location = new Point((Width - lnkTaxiTip.Width) / 2, (Height - lnkTaxiTip.Height) / 2);
                    info += ("备注：\n" + (string)_dataSource["remark"]);
                    lbl_more_info.Text = info;
                }
            }
        }

        /// <summary>
        /// 打车更详细的信息
        /// </summary>
        Label lbl_more_info = new Label();
        /// <summary>
        /// 构造方法
        /// </summary>
        public BTaxiTipControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            lbl_more_info.BackColor = Color.White;
            lbl_more_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbl_more_info.Padding = new Padding(5);
            lbl_more_info.Visible = false;
            lbl_more_info.AutoSize = true;
        }

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTaxiTipControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(0, 0, Width - 1, Height - 1));
        }
        /// <summary>
        /// 鼠标进入，显示详细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_MouseEnter(object sender, EventArgs e)
        {
            Control p = FindTheTopControl();
            if (!p.Controls.Contains(lbl_more_info))
            {
                p.Controls.Add(lbl_more_info);
                lbl_more_info.BringToFront();
            }
            Point location = p.PointToClient(this.PointToScreen(lnkTaxiTip.Location));
            lbl_more_info.Location = new Point(location.X + 2, location.Y + lnkTaxiTip.Height);
            lbl_more_info.Visible = true;
        }
        /// <summary>
        /// 鼠标移出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_MouseLeave(object sender, EventArgs e)
        {
            lbl_more_info.Visible = false;
        }
        /// <summary>
        /// 寻找最顶层控件
        /// </summary>
        /// <returns></returns>
        private Control FindTheTopControl()
        {
            Control parent = this.Parent;
            while (parent.Parent != null)
            {
                parent = parent.Parent;
            }
            return parent;
        }
    }
}
