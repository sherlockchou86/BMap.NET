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
    /// 快速搜索面板
    /// </summary>
    partial class BQuickSearchBoardcs : UserControl
    {
        public event QuickSearchEventHandler QuickSearch;
        public BQuickSearchBoardcs()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (QuickSearch != null)
            {
                QuickSearch((sender as PictureBox).Tag.ToString());
            }
        }
        /// <summary>
        /// 点击搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel4_Click(object sender, EventArgs e)
        {
            if (QuickSearch != null)
            {
                QuickSearch((sender as LinkLabel).Text);
            }
        }
        /// <summary>
        /// 点击搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_Click(object sender, EventArgs e)
        {
            if (QuickSearch != null)
            {
                QuickSearch((sender as LinkLabel).Tag.ToString());
            }
        }
    }
}
