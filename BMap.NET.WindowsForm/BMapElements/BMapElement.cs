using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BMap.NET.WindowsForm.BMapElements
{
    /// <summary>
    /// 地图元素基类
    /// </summary>
    abstract class BMapElement
    {
        /// <summary>
        /// 绘制方法
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="center">地图中心点坐标</param>
        /// <param name="zoom">当前地图缩放级别</param>
        /// <param name="screen_size">屏幕大小</param>
        public abstract void Draw(Graphics g, LatLngPoint center, int zoom, Size screen_size); 
    }
}
