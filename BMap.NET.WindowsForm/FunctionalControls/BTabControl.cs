using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BMap.NET.WindowsForm.FunctionalControls
{
    /// <summary>
    /// 选项卡控件，可以用来组织 位置列表控件BPlacesControl、导航控件BDirectionControl
    /// </summary>
    public class BTabControl:TabControl
    {
        int _mouse_over = -1;
        public BTabControl()
        {
            ItemSize = new System.Drawing.Size(70, 70);
            Alignment = TabAlignment.Left;
            //自绘
            base.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            base.UpdateStyles();
        }
        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(37, 37, 37)))
            {
                Rectangle all_back = new Rectangle(1, 1, Width - 2, Height - 2);  //整个背景区域
                e.Graphics.FillRectangle(sb, all_back);

                Rectangle back = new Rectangle(ItemSize.Width + 1, 1, Width - ItemSize.Width - 2, Height - 2);  //客户区
                e.Graphics.FillRectangle(Brushes.White, back);
                e.Graphics.DrawRectangle(Pens.Gray, back);

                foreach (TabPage tab in TabPages)  //Tab
                {
                    Rectangle tab_rect = GetTabRect(TabPages.IndexOf(tab));
                    tab_rect = new Rectangle(tab_rect.X - 1, tab_rect.Y - 1, tab_rect.Width, tab_rect.Height);
                    if (this.SelectedTab == tab || TabPages.IndexOf(tab) == _mouse_over)
                    {
                        using (SolidBrush bsb = new SolidBrush(Color.FromArgb(51,133,255)))
                        {
                            e.Graphics.FillRectangle(bsb, tab_rect);
                        }
                        e.Graphics.DrawString(tab.Text, new Font("微软雅黑", 10), Brushes.White, new PointF(tab_rect.X + 18, tab_rect.Y + 20));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(sb, tab_rect);
                        e.Graphics.DrawString(tab.Text, new Font("微软雅黑", 10), Brushes.White, new PointF(tab_rect.X + 18, tab_rect.Y + 20));
                    }
                }
            }
        }
        /// <summary>
        /// 鼠标进入选项卡
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _mouse_over = -1;
            foreach (TabPage tab in TabPages)
            {
                Rectangle tab_rect = GetTabRect(TabPages.IndexOf(tab));
                if (tab_rect.Contains(e.Location))
                {
                    _mouse_over = TabPages.IndexOf(tab);
                    break;
                }
            }
            Invalidate();
        }
        /// <summary>
        /// 鼠标移出
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _mouse_over = -1;
            Invalidate();
        }
    }
}
