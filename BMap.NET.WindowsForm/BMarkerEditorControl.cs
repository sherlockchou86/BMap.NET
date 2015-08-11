using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using BMap.NET.WindowsForm.BMapElements;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// 标记点信息编辑控件
    /// </summary>
    partial class BMarkerEditorControl : UserControl
    {
        /// <summary>
        /// 只是是否已保存
        /// </summary>
        public bool Saved
        {
            get;
            set;
        }
        private BMarker _marker;
        /// <summary>
        /// 与之对应的标记点
        /// </summary>
        public BMarker Marker
        {
            get
            {
                return _marker;
            }
            set
            {
                _marker = value;
                txtName.Text = _marker.Name;
                txtRemarks.Text = _marker.Remarks;
            }
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public BMarkerEditorControl()
        {
            InitializeComponent();
        }

        #region 事件处理
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BMarkerEditorControl_Load(object sender, EventArgs e)
        {
            //显示形状
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(new Point(0, 0), new Point(Width, 0));
            gp.AddLine(new Point(Width, 0), new Point(Width, Height - 40));
            gp.AddLine(new Point(Width / 3 + 20, Height - 40), new Point(Width, Height - 40));
            gp.AddLine(new Point(Width / 3 + 20, Height - 40), new Point(Width / 3 - 40, Height));
            gp.AddLine(new Point(Width / 3 - 40, Height), new Point(Width / 3 - 20, Height - 40));
            gp.AddLine(new Point(Width / 3 - 20, Height - 40), new Point(0, Height - 40));
            this.Region = new Region(gp);
        }
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BMarkerEditorControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //边框
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(new Point(0, 0), new Point(Width - 1, 0));
            gp.AddLine(new Point(Width - 1, 0), new Point(Width - 1, Height - 40 - 1));
            gp.AddLine(new Point(Width / 3 + 20 - 1, Height - 40 - 1), new Point(Width - 1, Height - 40 - 1));
            gp.AddLine(new Point(Width / 3 + 20 - 1, Height - 40 - 1), new Point(Width / 3 - 40, Height - 1));
            gp.AddLine(new Point(Width / 3 - 40, Height - 1), new Point(Width / 3 - 20 + 1, Height - 40 - 1));
            gp.AddLine(new Point(Width / 3 - 20 + 1, Height - 40 - 1), new Point(0, Height - 40 - 1));
            gp.AddLine(new Point(0, 0), new Point(0, Height - 40 - 1));
            e.Graphics.DrawPath(Pens.Gray, gp);
        }
        /// <summary>
        /// 点击关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picClose_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            _marker.Name = txtName.Text;
            _marker.Remarks = txtRemarks.Text;
            Saved = true;
            Visible = false;
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
        #endregion
    }
}
