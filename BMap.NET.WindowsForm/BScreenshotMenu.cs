using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// 截图菜单
    /// </summary>
    partial class BScreenshotMenu : UserControl
    {
        public event ScreenshotDoneEventHandler ScreenshotDone;
        public BScreenshotMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 鼠标进入变色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.Gray;
        }
        /// <summary>
        /// 鼠标移出变色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.White;
        }
        /// <summary>
        /// 鼠标点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            if ((sender as Label).Text == "确定")
            {
                if (ScreenshotDone != null)
                {
                    ScreenshotDone(true);
                }
            }
            else
            {
                if (ScreenshotDone != null)
                {
                    ScreenshotDone(false);
                }
            }
        }
    }
    /// <summary>
    /// 表示处理截图完成事件的方法
    /// </summary>
    /// <param name="saved"></param>
    delegate void ScreenshotDoneEventHandler(bool saved);
}
