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
    /// 导航路线起点\终点位置建议控件
    /// </summary>
    partial class BPlacesSuggestionControl : UserControl
    {
        public event EndPointSelectedEventHandler EndPointSelected;
        /// <summary>
        /// 类型（起点或终点）
        /// </summary>
        public PointType Type
        {
            get;
            set;
        }
        private JToken _content;
        /// <summary>
        /// 位置项
        /// </summary>
        public JToken Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                // 解析 具体json格式参见api文档
                if (_content != null)
                {
                    int index=0;
                    foreach (JObject place in _content)
                    {
                        BPlacesSuggestionItem item = new BPlacesSuggestionItem();
                        item.Type = Type;
                        item.Index = index++;
                        item.DataSource = place;
                        item.Width = flpPlaces.Width;
                        flpPlaces.Controls.Add(item);
                        item.Margin = new System.Windows.Forms.Padding(0);
                        item.EndPointSelected += new EndPointSelectedEventHandler(item_EndPointSelected);
                    }
                    foreach (Control c in flpPlaces.Controls)
                    {
                        _places_height += c.Height;
                    }
                    Selected = false;
                }
            }
        }

        private int _places_height;
        private string _selected_place;

        private bool _selected;
        /// <summary>
        /// 是否选中（展开收缩）
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
                    Height = 50 + _places_height;
                }
                else
                {
                    Height = 50;
                }
            }
        }

        /// <summary>
        /// 模糊位置
        /// </summary>
        public string KeyWord
        {
            get;
            set;
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public BPlacesSuggestionControl()
        {
            InitializeComponent();
        }
        #region 事件处理
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPlacesSuggestionControl_Paint(object sender, PaintEventArgs e)
        {
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(50, Color.Wheat)))
            {
                e.Graphics.FillRectangle(sb, new Rectangle(0, 0, Width - 1, 50 - 1));
            }
            e.Graphics.DrawRectangle(Pens.OrangeRed, new Rectangle(0, 0, Width - 1, 50 - 1));
            string info = _selected_place == null ? KeyWord : _selected_place;
            using (Font f = new Font("微软雅黑", 10, FontStyle.Bold))
            {
                e.Graphics.DrawString((Type == PointType.RouteEnd ? "终点：" : "起点：") + info, f, Brushes.OrangeRed, new PointF(20, 15));
            }
        }
        /// <summary>
        /// 选中位置
        /// </summary>
        /// <param name="placeName"></param>
        /// <param name="type"></param>
        void item_EndPointSelected(string placeName, PointType type)
        {
            _selected_place = placeName;
            if (EndPointSelected != null)
            {
                EndPointSelected(placeName, type);
            }
            Invalidate();
        }
        /// <summary>
        /// 选中展开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPlacesSuggestionControl_Click(object sender, EventArgs e)
        {
            Selected = !Selected;
        }
        #endregion

    }
    /// <summary>
    /// 表示处理选中起点/终点这一事件的方法
    /// </summary>
    /// <param name="placeName"></param>
    /// <param name="type"></param>
    delegate void EndPointSelectedEventHandler(string placeName,PointType type);
}
