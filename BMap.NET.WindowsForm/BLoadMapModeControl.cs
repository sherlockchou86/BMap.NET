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
    /// 地图加载模式选择控件
    /// </summary>
    partial class BLoadMapModeControl : UserControl
    {
        public event LoadMapModeChangedEventHandler LoadMapModeChanged;
        private LoadMapMode _loadMode = LoadMapMode.Cache;
        public LoadMapMode LoadMode
        {
            get
            {
                return _loadMode;
            }
            set
            {
                if (value != _loadMode)
                {
                    _loadMode = value;
                    if (_loadMode == LoadMapMode.Cache)
                    {
                        rdoCache.Checked = true;
                    }
                    if (_loadMode == LoadMapMode.CacheServer)
                    {
                        rdoCachefirst.Checked = true;
                    }
                    if (_loadMode == LoadMapMode.Server)
                    {
                        rdoServer.Checked = true;
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public BLoadMapModeControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
        /// <summary>
        /// 选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            LoadMapMode lm = LoadMapMode.Cache;
            if (rdoCache.Checked)
            {
                lm = LoadMapMode.Cache;
            }
            if (rdoCachefirst.Checked)
            {
                lm = LoadMapMode.CacheServer;
            }
            if (rdoServer.Checked)
            {
                lm = LoadMapMode.Server;
            }
            if (lm != _loadMode)
            {
                _loadMode = lm;
                if (LoadMapModeChanged != null)
                {
                    LoadMapModeChanged(_loadMode);
                }
                Visible = false;
            }
        }
    }
    delegate void LoadMapModeChangedEventHandler(LoadMapMode loadMode);
}
