using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// 驾车路线步骤控件
    /// </summary>
    partial class BDrivingStepItem : UserControl
    {
        /// <summary>
        /// 路线步骤选中时激发该事件
        /// </summary>
        public event StepSelectedEventHandler StepSelected;
        private JObject _dataSource;
        /// <summary>
        /// 步骤数据源
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
                if (_dataSource != null) //解析 详细json结构参见api文档
                {
                    _step_direction = int.Parse((string)_dataSource["turn"]);
                    _step_info = (string)_dataSource["instructions"];
                    Paths = (string)_dataSource["path"];
                    foreach (JObject poi in _dataSource["pois"])
                    {
                        Step_POIs += (string)poi["name"] + ",";
                    }
                    if (Step_POIs != null)
                        Step_POIs = Step_POIs.TrimEnd(new char[] { ',' });
                    Regex reg = new Regex(@"<(!|/)?\w+( ((.|\n)*?"")?)? *>");
                    _step_info = reg.Replace(_step_info, "").Replace("<br/>","");
                    lblStepInfo.Text = _step_info;
                }
            }
        }
        private int _step_direction;
        private string _step_info;

        /// <summary>
        /// 路过POI信息点
        /// </summary>
        public string Step_POIs
        {
            get;
            set;
        }
        /// <summary>
        /// 当前步骤路线
        /// </summary>
        public string Paths
        {
            get;
            set;
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public BDrivingStepItem()
        {
            InitializeComponent();
        }
        #region 事件处理
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDrivingStepItem_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(0, 0, Width - 2, Height));

        }
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDrivingStepItem_MouseEnter(object sender, EventArgs e)
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
        private void BDrivingStepItem_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }
        /// <summary>
        /// 鼠标点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblStepInfo_Click(object sender, EventArgs e)
        {
            if (StepSelected != null)
            {
                StepSelected(Paths, true);
            }
        }
        #endregion

    }
}
