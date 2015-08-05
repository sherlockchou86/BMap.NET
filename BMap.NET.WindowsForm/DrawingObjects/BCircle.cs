using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BMap.NET.WindowsForm.DrawingObjects
{
    /// <summary>
    /// 绘制椭圆类
    /// </summary>
    class BCircle : DrawingObject
    {
        /// <summary>
        /// 椭圆中心
        /// </summary>
        public LatLngPoint Center
        {
            get;
            set;
        }
        /// <summary>
        /// 椭圆矩形任意一角坐标
        /// </summary>
        public LatLngPoint RightBottom
        {
            get;
            set;
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
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Point theScreenCenter = MapHelper.GetScreenLocationByLatLng(Center, center, zoom, screen_size);  //椭圆中心点的屏幕坐标
            Point theScreenRightBottom = MapHelper.GetScreenLocationByLatLng(RightBottom, center, zoom, screen_size);  //椭圆矩形任意一角的屏幕坐标
            int width = Math.Abs(2 * (theScreenRightBottom.X - theScreenCenter.X));
            int height = Math.Abs(2 * (theScreenRightBottom.Y - theScreenCenter.Y));
            if (new Rectangle(new Point(0,0), screen_size).IntersectsWith(new Rectangle(theScreenCenter.X - width/2, theScreenCenter.Y - height/2, width, height)))  //需要绘制
            {
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(30, Color.Blue)))
                {
                    g.FillEllipse(sb, new Rectangle(theScreenCenter.X - width / 2, theScreenCenter.Y - height / 2, width, height));
                }
                using (Pen pen = new Pen(Color.FromArgb(150,Color.Blue), 4))
                {
                    g.DrawEllipse(pen, new Rectangle(theScreenCenter.X - width / 2, theScreenCenter.Y - height / 2, width, height));
                }
            }
        }
    }
}
