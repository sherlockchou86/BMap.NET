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
    /// POI显示项
    /// </summary>
    partial class BPlaceItem : UserControl
    {
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
                if (_selected != value)
                {
                    _selected = value;
                    if (!_selected)  //收缩
                    {
                        Height = 104;
                        BackColor = Color.White;
                        txtAddress.BackColor = Color.White;
                        txtPhone.BackColor = Color.White;
                        txtPrice.BackColor = Color.White;
                        txtTag.BackColor = Color.White;
                        btn_here.BackColor = Color.White;
                        btn_there.BackColor = Color.White;
                    }
                    else //展开
                    {
                        Height = 145;
                        BackColor = Color.FromArgb(235, 245, 250);
                        txtAddress.BackColor = Color.FromArgb(235, 245, 250);
                        txtPhone.BackColor = Color.FromArgb(235, 245, 250);
                        txtPrice.BackColor = Color.FromArgb(235, 245, 250);
                        txtTag.BackColor = Color.FromArgb(235, 245, 250);
                        btn_there.BackColor = Color.White;
                        btn_here.BackColor = Color.White;
                    }
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// 数据源
        /// </summary>
        public BPOI POI
        {
            get;
            set;
        }
        /// <summary>
        /// 索引号
        /// </summary>
        public int Index
        {
            set;
            get;
        }
        /// <summary>
        /// 设置起点
        /// </summary>
        public event SetSourcePlaceEventHandler SetSourcePlace;
        /// <summary>
        /// 设置重点
        /// </summary>
        public event SetDestinationPlaceEventHandler SetDestinationPlace;
        /// <summary>
        /// 选中位置
        /// </summary>
        public event PlaceSelectedChangedEventHandler PlaceSelectedChanged;
        public BPlaceItem()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 鼠标进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPlaceItem_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(235, 245, 250);
            txtAddress.BackColor = Color.FromArgb(235, 245, 250);
            txtPhone.BackColor = Color.FromArgb(235, 245, 250);
            txtPrice.BackColor = Color.FromArgb(235, 245, 250);
            txtTag.BackColor = Color.FromArgb(235, 245, 250);
            btn_there.BackColor = Color.White;
            btn_here.BackColor = Color.White;
        }
        /// <summary>
        /// 鼠标移出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPlaceItem_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
            txtAddress.BackColor = Color.White;
            txtPhone.BackColor = Color.White;
            txtPrice.BackColor = Color.White;
            txtTag.BackColor = Color.White;
            btn_there.BackColor = Color.White;
            btn_here.BackColor = Color.White;
        }
        /// <summary>
        /// 到这里去
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_there_Click(object sender, EventArgs e)
        {
            if (SetDestinationPlace != null)
            {
                SetDestinationPlace((string)POI.DataSource["name"]); //具体json格式参见api文档
            }
        }
        /// <summary>
        /// 从这里出发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_here_Click(object sender, EventArgs e)
        {
            if (SetSourcePlace != null)
            {
                SetSourcePlace((string)POI.DataSource["name"]);  //具体json格式参见api文档
            }
        }
        /// <summary>
        /// 控件绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPlaceItem_Paint(object sender, PaintEventArgs e)
        {
            Bitmap b;
            if (_selected)
            {
                b = Properties.BMap.ico_blue_point_big;
            }
            else
            {
                b = Properties.BMap.ico_red_point_small;
            }
            e.Graphics.DrawImage(b, new Rectangle(3, 8, b.Width * 5 / 6, b.Height * 5 / 6));
            e.Graphics.DrawString(((Char)(Index + 65)).ToString(), new Font("微软雅黑", 10, FontStyle.Bold), Brushes.White, new PointF(_selected ? 9 : 7, _selected ? 12 : 9));
        }
        /// <summary>
        /// 点击选中该项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void BPlaceItem_Click(object sender, EventArgs e)
        {
            Selected = true;
            if (_selected)
            {
                if (PlaceSelectedChanged != null)
                {
                    PlaceSelectedChanged(POI);
                }
            }
        }
        /// <summary>
        /// 控件加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPlaceItem_Load(object sender, EventArgs e)
        {
            if (POI.DataSource != null)
            {
                lnkName.Text = (string)POI.DataSource["name"] + " -详情";  //具体json格式参见api文档
                txtAddress.Text = (string)POI.DataSource["address"];
                txtPhone.Text = (string)POI.DataSource["telephone"];
                if (POI.DataSource["detail_info"] != null && POI.DataSource["detail_info"]["tag"] != null)
                {
                    txtTag.Text = (string)POI.DataSource["detail_info"]["tag"];
                }
                else
                {
                    txtTag.Visible = false;
                }
                if (POI.DataSource["detail_info"] != null && POI.DataSource["detail_info"]["price"] != null)
                {
                    txtPrice.Text = "人均 ￥" + (string)POI.DataSource["detail_info"]["price"];
                }
                else
                {
                    txtPrice.Visible = false;
                }
            }
        }
    }
    /// <summary>
    /// 表示处理设置起点这一事件的方法
    /// </summary>
    /// <param name="sourceName"></param>
    delegate void SetSourcePlaceEventHandler(string sourceName);
    /// <summary>
    /// 表示处理设置终点这一事件的方法
    /// </summary>
    /// <param name="destinationName"></param>
    delegate void SetDestinationPlaceEventHandler(string destinationName);
    /// <summary>
    /// 表示处理选择某位置事件的方法
    /// </summary>
    /// <param name="poi"></param>
    delegate void PlaceSelectedChangedEventHandler(BPOI poi);
}
