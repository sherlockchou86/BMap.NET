using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BMap.NET.WindowsForm.DrawingObjects
{
    /// <summary>
    /// 绘制多边形类
    /// </summary>
    class BPolygon:DrawingObject
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
        /// <param name="center">地图中心点</param>
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
                    l.Add(MapHelper.GetScreenLocationByLatLng(p, center, zoom, screen_size));
                }
                using (Pen pen = new Pen(Color.FromArgb(150,Color.Blue), 4))
                {
                    if (Points.Count == 2)
                    {
                        g.DrawLine(pen, l[0], l[1]);
                    }
                    else
                    {
                        using (SolidBrush sb = new SolidBrush(Color.FromArgb(30, Color.Blue)))
                        {
                            g.FillPolygon(sb, l.ToArray());
                        }
                        g.DrawPolygon(pen, l.ToArray());
                    }
                }
            }
        }
    }
}
