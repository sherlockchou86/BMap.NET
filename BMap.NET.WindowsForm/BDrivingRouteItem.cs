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
    /// 驾车路线控件
    /// </summary>
    partial class BDrivingRouteItem : UserControl
    {
        private JObject _dataSource;
        /// <summary>
        /// 路线数据源
        /// </summary>
        public JObject DataSource
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
                    _distance = double.Parse((string)_dataSource["distance"]);
                    _duration = double.Parse((string)_dataSource["duration"]);
                    _toll = double.Parse((string)_dataSource["toll"]);
                    foreach (JObject step in _dataSource["steps"])
                    {
                        BDrivingStepItem item = new BDrivingStepItem();
                        item.DataSource = step;
                        item.Width = flpSteps.Width - 17;
                        flpSteps.Controls.Add(item);
                        item.Margin = new Padding(0);
                        if (item.Step_POIs != null)
                            _pois_near += item.Step_POIs + ",";
                    }
                    if (_pois_near != null)
                    {
                        _pois_near = _pois_near.TrimEnd(new char[] { ',' });
                    }
                    foreach (Control c in flpSteps.Controls)
                    {
                        _steps_height += c.Height;
                    }
                    Selected = false;
                }
            }
        }
        private double _distance;
        private double _duration;
        private string _pois_near;
        private double _toll;

        private int _steps_height;

        private bool _mouse_hover;

        private bool _selected;
        /// <summary>
        /// 是否被选中
        /// </summary>
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                if (_selected)
                {
                    Height = 70 + _steps_height;
                }
                else
                {
                    Height = 70;
                }
            }
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public BDrivingRouteItem()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
        #region 事件处理
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDrivingRouteItem_MouseEnter(object sender, EventArgs e)
        {
            _mouse_hover = true;
            Invalidate();
        }
        /// <summary>
        /// 鼠标移出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDrivingRouteItem_MouseLeave(object sender, EventArgs e)
        {
            _mouse_hover = false;
            Invalidate();
        }
        /// <summary>
        /// 鼠标点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDrivingRouteItem_Click(object sender, EventArgs e)
        {
            Selected = !Selected;
        }
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDrivingRouteItem_Paint(object sender, PaintEventArgs e)
        {
            if (Selected || _mouse_hover)
            {
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(235, 241, 251)))
                {
                    e.Graphics.FillRectangle(sb, new Rectangle(0, 0, Width - 1, 70 - 1));
                }
            }
            e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(0, 0, Width - 1, 70 - 1));
            using (Font f = new Font("微软雅黑", 9))
            {
                e.Graphics.DrawString(Math.Round(_duration / 60, 0) + "分钟 | " + Math.Round(_distance / 1000, 1) + "公里 | 过路费" + Math.Round(_toll,1) + "元", f, Brushes.Gray, new PointF(20, 10));
                e.Graphics.DrawString("途径：" + _pois_near, f, Brushes.DarkGray, new PointF(20, 35));
            }           
        }
        #endregion
    }
}
