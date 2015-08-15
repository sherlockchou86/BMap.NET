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
    /// 导航路线起点/终点位置建议项
    /// </summary>
    partial class BPlacesSuggestionItem : UserControl
    {
        public event EndPointSelectedEventHandler EndPointSelected;

        private JObject _dataSource;
        /// <summary>
        /// 位置数据源
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
                if (_dataSource != null)  //解析 具体json格式参见api文档
                {
                    lblName.Text = (string)_dataSource["name"];
                    lblAddress.Text = (string)_dataSource["address"];
                    if (Type == PointType.RouteEnd)
                    {
                        lblSelect.Text = "设为终点";
                    }
                    else
                    {
                        lblSelect.Text = "设为起点";
                    }
                    lblIndex.Text = Index.ToString();
                }
            }
        }
        /// <summary>
        /// 序号
        /// </summary>
        public int Index
        {
            get;
            set;
        }
        /// <summary>
        /// 位置类型
        /// </summary>
        public PointType Type
        {
            get;
            set;
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public BPlacesSuggestionItem()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(235, 241, 251);
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }
        /// <summary>
        /// 选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblSelect_Click(object sender, EventArgs e)
        {
            if (EndPointSelected != null)
            {
                EndPointSelected(lblName.Text, Type);
            }
        }
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPlacesSuggestionItem_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
