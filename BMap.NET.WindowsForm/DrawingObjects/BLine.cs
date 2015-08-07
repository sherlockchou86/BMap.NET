using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BMap.NET.WindowsForm.DrawingObjects
{
    /// <summary>
    /// 绘制直（折）线类
    /// </summary>
    class BLine:DrawingObject
    {
        /// <summary>
        /// 点集
        /// </summary>
        public List<LatLngPoint> Points
        {
            get;
            set;
        }
        /// <summary>
        /// 更新最后一点
        /// </summary>
        /// <param name="p"></param>
        public void UpdateTheEnd(LatLngPoint p)
        {
            if (Points != null)
            {
                Points[Points.Count - 1] = p;
            }
        }
        /// <summary>
        /// 绘制方法
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="center">地图中心</param>
        /// <param name="zoom">地图缩放级别</param>
        /// <param name="screen_size">地图大小</param>
        public override void Draw(System.Drawing.Graphics g, LatLngPoint center, int zoom, System.Drawing.Size screen_size)
        {
            if (Points != null && Points.Count >= 2)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                List<Point> l = new List<Point>();
                foreach (LatLngPoint p in Points)
                {
                    l.Add(MapHelper.GetScreenLocationByLatLng(p, center, zoom, screen_size));  //屏幕坐标
                }
                using (Pen pen = new Pen(Color.FromArgb(150,Color.Blue), 4))
                {
                    for (int i = 0; i < l.Count - 1; ++i)
                    {
                        g.DrawLine(pen, l[i], l[i + 1]);
                    }
                }
            }
        }
    }
}
