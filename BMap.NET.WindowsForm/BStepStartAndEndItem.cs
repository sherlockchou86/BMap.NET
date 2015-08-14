using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMap.NET.WindowsForm.BMapElements;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// 路线起点/终点控件
    /// </summary>
    partial class BStepStartAndEndItem : UserControl
    {
        public event StepEndPointSelectedEventHandler StepEndPointSelected;

        /// <summary>
        /// 起点/终点数据源
        /// </summary>
        public BPoint EndPoint
        {
            get;
            set;
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public BStepStartAndEndItem()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BStepStartAndEndItem_Paint(object sender, PaintEventArgs e)
        {
            if (EndPoint != null)
            {
                Bitmap b = null;
                if (EndPoint.Type == PointType.RouteStart)
                {
                    b = Properties.BMap.ico_source;
                }
                if (EndPoint.Type == PointType.RouteEnd)
                {
                    b = Properties.BMap.ico_destination;
                }
                e.Graphics.DrawImage(b, new Rectangle(5, (Height - b.Height) / 2, b.Width, b.Height));
            }
        }
        /// <summary>
        /// 鼠标点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            if (StepEndPointSelected != null)
            {
                StepEndPointSelected(EndPoint);
            }
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BStepStartAndEndItem_Load(object sender, EventArgs e)
        {
            label1.Text = EndPoint.Address;
        }
    }
}
