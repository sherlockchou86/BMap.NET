using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMap.NET.WindowsForm.BMapElements
{
    /// <summary>
    /// 附近区域
    /// </summary>
    class BNearBy : BMapElement
    {
        /// <summary>
        /// 中心
        /// </summary>
        public LatLngPoint Center
        {
            get;
            set;
        }
        /// <summary>
        /// 附近区域半径 米
        /// </summary>
        public double Radius
        {
            get;
            set;
        }
        /// <summary>
        /// 周边点坐标
        /// </summary>
        private List<LatLngPoint> _points_arounds;
        /// <summary>
        /// 绘制方法
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="center">中心</param>
        /// <param name="zoom">地图缩放级别</param>
        /// <param name="screen_size">地图大小</param>
        public override void Draw(System.Drawing.Graphics g, LatLngPoint center, int zoom, System.Drawing.Size screen_size)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (_points_arounds == null)
            {
                _points_arounds = new List<LatLngPoint>();

            }
        }
    }
}
