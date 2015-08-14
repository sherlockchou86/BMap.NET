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
    /// 公交路线步骤控件
    /// </summary>
    partial class BTransitStepItem : UserControl
    {
        /// <summary>
        /// 鼠标进入或点击时激发该事件
        /// </summary>
        public event StepSelectedEventHandler StepSelected;
        private JArray _dataSource;
        /// <summary>
        /// 步骤数据源
        /// </summary>
        public JArray DataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                if (_dataSource != null)  //解析  具体json结构参见api文档
                {
                    if ((string)_dataSource[0]["type"] == "5")  //步行
                    {
                        JToken step = _dataSource[0];
                        _step_type = 0;
                        _step_walk_string = (string)step["stepInstruction"];
                        _step_walk_distance = int.Parse((string)step["distance"]);
                        Paths = (string)step["path"];
                        Height = 35;
                    }
                    else
                    {
                        _step_type = 1;
                        Paths = (string)_dataSource[0]["path"];
                        _step_transit_start = (string)_dataSource[0]["vehicle"]["start_name"];
                        _step_transit_end = (string)_dataSource[0]["vehicle"]["end_name"];
                        _step_transit_stops = int.Parse((string)_dataSource[0]["vehicle"]["stop_num"]);

                        foreach (JObject step in _dataSource) //多种方案
                        {
                            _step_transits += (string)step["vehicle"]["name"] + ",";                        
                        }
                        _step_transits = _step_transits.TrimEnd(new char[]{','});
                        Height = 70;
                    }
                }
            }
        }

        private int _step_type;  //当前步骤类型：0步行  1公交
        private string _step_walk_string; //步行信息
        private int _step_walk_distance; //步行距离

        private string _step_transit_start; //公交起始站
        private string _step_transit_end; //公交终点站
        private string _step_transits; //可乘坐公交名称
        private int _step_transit_stops; //公交站数

        /// <summary>
        /// 当前步骤路线
        /// </summary>
        public string Paths
        {
            get;
            set;
        }
        /// <summary>
        /// 步行距离（默认为0）
        /// </summary>
        public int Step_Walk_Distance
        {
            get
            {
                return _step_walk_distance;
            }
        }
        /// <summary>
        /// 公交线路（默认为空）
        /// </summary>
        public string Step_Transit_Name
        {
            get
            {
                if (_step_type == 0)
                {
                    return "";
                }
                else
                {
                    return _step_transits.Split(',')[0]; //取第一个
                }
            }
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public BTransitStepItem()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTransitStepItem_Paint(object sender, PaintEventArgs e)
        {
            if (_step_type == 0) //当前步骤为 步行
            {
                using (Font f = new Font("微软雅黑", 9))
                {
                    using (Pen p = new Pen(Color.FromArgb(50, Color.Gray), 3))
                    {
                        e.Graphics.DrawLine(p, new Point(5 + 9, 3), new Point(5 + 9, Height - 3));
                    }
                    e.Graphics.DrawString(_step_walk_string, f, Brushes.Gray, new PointF(30, 10));
                    e.Graphics.DrawImage(Properties.BMap.ico_bywalk, new Rectangle(5, 8, Properties.BMap.ico_bywalk.Width, Properties.BMap.ico_bywalk.Height));
                }
            }
            else  //当前步骤为公交
            {
                using (Font f = new Font("微软雅黑", 9))
                {
                    using (Pen p = new Pen(Color.FromArgb(50, Color.Gray), 3))
                    {
                        e.Graphics.DrawLine(p, new Point(5 + 9, 3), new Point(5 + 9, Height - 3));
                    }
                    e.Graphics.DrawString(_step_transit_start + " 上车", f, Brushes.Gray, new PointF(30,5));
                    e.Graphics.DrawString(_step_transits, f, Brushes.Black, new PointF(35, 5 + 20));
                    e.Graphics.DrawString(_step_transit_end + " 下车", f, Brushes.Gray, new PointF(30, 5 + 20 + 20));
                    e.Graphics.DrawString(_step_transit_stops + "站", f, Brushes.Gray, new PointF(Width - 50, 5 + 20));
                    e.Graphics.DrawImage(Properties.BMap.ico_bytransit, new Rectangle(5, 5, Properties.BMap.ico_bytransit.Width, Properties.BMap.ico_bytransit.Height));
                    e.Graphics.DrawImage(Properties.BMap.ico_bytransit, new Rectangle(5, 5 + 20 + 20 - 2, Properties.BMap.ico_bytransit.Width, Properties.BMap.ico_bytransit.Height));
                }
            }
        }
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTransitStepItem_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(235, 241, 251);
            if (StepSelected != null)
            {
                StepSelected(Paths, false);
            }
        }
        /// <summary>
        /// 鼠标移出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTransitStepItem_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }
        /// <summary>
        /// 鼠标点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTransitStepItem_Click(object sender, EventArgs e)
        {
            if (StepSelected != null)
            {
                StepSelected(Paths, true);
            }
        }
    }
}
