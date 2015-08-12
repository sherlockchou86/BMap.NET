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
    /// 公交路线控件
    /// </summary>
    partial class BTransitRouteItem : UserControl
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
                //
                if (_dataSource != null) //解析 具体json格式参见api文档
                {
                    JToken r = _dataSource["scheme"][0];
                    _distance = double.Parse((string)r["distance"]);
                    _duration = double.Parse((string)r["duration"]);
                    foreach (JArray step in r["steps"])
                    {
                        BTransitStepItem item = new BTransitStepItem();
                        item.DataSource = step;
                        _need_walk += item.Step_Walk_Distance;
                        if (item.Step_Transit_Name != "")
                        {
                            _transits += item.Step_Transit_Name + "→";
                        }
                        item.Width = flpSteps.Width;
                        flpSteps.Controls.Add(item);
                        item.Margin = new Padding(0);
                    }
                    _transits = _transits.TrimEnd(new char[] { '→'});
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
        private int _need_walk;
        private string _transits;

        private int _steps_height;

        private bool _selected;
        /// <summary>
        /// 是否选中
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
                    Height = 70; //默认70g高度
                }
            }
        }

        private bool _mouse_hover;
        /// <summary>
        /// 构造方法
        /// </summary>
        public BTransitRouteItem()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        #region 事件处理
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTransitRouteItem_Paint(object sender, PaintEventArgs e)
        {
            if (Selected || _mouse_hover)
            {
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(235, 241, 251)))
                {
                    e.Graphics.FillRectangle(sb, new Rectangle(0, 0, Width - 1, 70 - 1));
                }
            }
            e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(0, 0, Width - 1, 70 - 1));
            using(Font f = new Font("微软雅黑",10))
            {
                e.Graphics.DrawString(_transits, f, Brushes.Blue, new PointF(20, 10));
            }
            using (Font f = new Font("微软雅黑", 9))
            {
                e.Graphics.DrawString(Math.Round(_duration / 60, 0) + "分钟 | " + Math.Round(_distance / 1000, 1) + "公里 | 步行" + _need_walk + "米", f, Brushes.Gray, new PointF(20, 35)); 
            }
        }
        /// <summary>
        /// 点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTransitRouteItem_Click(object sender, EventArgs e)
        {
            Selected = !Selected;
        }
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTransitRouteItem_MouseEnter(object sender, EventArgs e)
        {
            _mouse_hover = true;
            Invalidate();
        }
        /// <summary>
        /// 鼠标移出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTransitRouteItem_MouseLeave(object sender, EventArgs e)
        {
            _mouse_hover = false;
            Invalidate();
        }
        #endregion
    }
}
