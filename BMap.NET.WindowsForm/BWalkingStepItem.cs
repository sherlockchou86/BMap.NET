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
    /// 步行路线步骤控件
    /// </summary>
    partial class BWalkingStepItem : UserControl
    {
        /// <summary>
        /// 步骤选中时激发该事件
        /// </summary>
        public event StepSelectedEventHandler StepSelected;

        private JObject _dataSource;
        /// <summary>
        /// 步行路线步骤数据源
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
                    Paths = (string)_dataSource["path"];
                    _step_info = (string)_dataSource["instructions"];
                    _step_direction = int.Parse((string)_dataSource["direction"]);
                    Regex reg = new Regex(@"<(!|/)?\w+( ((.|\n)*?"")?)? *>");
                    _step_info = reg.Replace(_step_info, "").Replace("<br/>", "");
                    lblStepInfo.Text = _step_info;
                }
            }
        }
        private string _step_info;
        private int _step_direction;

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
        public BWalkingStepItem()
        {
            InitializeComponent();
        }

        #region 事件处理
        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BWalkingStepItem_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(0, 0, Width - 2, Height));

        }
        /// <summary>
        /// 点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BWalkingStepItem_Click(object sender, EventArgs e)
        {
            if (StepSelected != null)
            {
                StepSelected(Paths, true);
            }
        }
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BWalkingStepItem_MouseEnter(object sender, EventArgs e)
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
        private void BWalkingStepItem_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }
        #endregion
    }
}
