using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using BMap.NET.WindowsForm.BMapElements;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// 公交路线控件
    /// </summary>
    partial class BTransitRouteItem : UserControl
    {
        /// <summary>
        /// 步骤选择时激发该事件
        /// </summary>
        public event StepSelectedEventHandler StepSelected;
        /// <summary>
        /// 路线选择时激发该事件
        /// </summary>
        public event RouteSelectedEventHandler RouteSelected;
        /// <summary>
        /// 路线起点终点选中时激发该事件
        /// </summary>
        public event StepEndPointSelectedEventHandler StepEndPointSelected;
        private BRoute _dataSource;
        /// <summary>
        /// 路线数据源
        /// </summary>
        public BRoute DataSource
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
                    JToken r = _dataSource.DataSource["scheme"][0];
                    _distance = double.Parse((string)r["distance"]);
                    _duration = double.Parse((string)r["duration"]);
                    if (Origin != null) //起点
                    {
                        flpSteps.Controls.Add(Origin);
                        Origin.StepEndPointSelected += new StepEndPointSelectedEventHandler(Origin_StepEndPointSelected);
                    }
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
                        item.StepSelected += new StepSelectedEventHandler(item_StepSelected);
                    }
                    if (Destination != null) //终点
                    {
                        flpSteps.Controls.Add(Destination);
                        Destination.StepEndPointSelected += new StepEndPointSelectedEventHandler(Destination_StepEndPointSelected);
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

        /// <summary>
        /// 起点
        /// </summary>
        public BStepStartAndEndItem Origin
        {
            get;
            set;
        }
        /// <summary>
        /// 终点
        /// </summary>
        public BStepStartAndEndItem Destination
        {
            get;
            set;
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
            Selected = true;
            if (_selected) //选中
            {
                if (RouteSelected != null)
                {
                    RouteSelected(_dataSource);
                }
            }
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
        /// <summary>
        /// 步骤选中
        /// </summary>
        /// <param name="stepPath"></param>
        /// <param name="enlarge"></param>
        void item_StepSelected(string stepPath, bool enlarge)
        {
            if (StepSelected != null)
            {
                StepSelected(stepPath, enlarge);
            }
        }
        /// <summary>
        /// 终点选中
        /// </summary>
        /// <param name="bPoint"></param>
        void Destination_StepEndPointSelected(BPoint bPoint)
        {
            if (StepEndPointSelected != null)
            {
                StepEndPointSelected(bPoint);
            }
        }
        /// <summary>
        /// 起点选中
        /// </summary>
        /// <param name="bPoint"></param>
        void Origin_StepEndPointSelected(BPoint bPoint)
        {
            if (StepEndPointSelected != null)
            {
                StepEndPointSelected(bPoint);
            }
        }

        #endregion
    }
    /// <summary>
    /// 表示处理选择路线事件的方法
    /// </summary>
    /// <param name="bRoute"></param>
    delegate void RouteSelectedEventHandler(BRoute bRoute);
    /// <summary>
    /// 表示处理选择路线步骤事件的方法
    /// </summary>
    /// <param name="stepPath"></param>
    /// <param name="enlarge"></param>
    delegate void StepSelectedEventHandler(string stepPath, bool enlarge);
    /// <summary>
    /// 表示处理选择路线起点、终点事件的方法
    /// </summary>
    /// <param name="bPoint"></param>
    delegate void StepEndPointSelectedEventHandler(BPoint bPoint);
}
