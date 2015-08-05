using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BMap.NET.WindowsForm.DrawingObjects
{
    /// <summary>
    /// 绘制矩形类
    /// </summary>
    class BRectangle:DrawingObject
    {
        /// <summary>
        /// 左上角坐标
        /// </summary>
        public LatLngPoint LeftTop
        {
            get;
            set;
        }
        /// <summary>
        /// 右下角坐标
        /// </summary>
        public LatLngPoint RightBottom
        {
            get;
            set;
        }
        /// <summary>
        /// 绘制方法
        /// </summary>
        /// <param name="g"></param>
        /// <param name="center"></param>
        /// <param name="zoom"></param>
        /// <param name="screen_size"></param>
        public override void Draw(System.Drawing.Graphics g, LatLngPoint center, int zoom, System.Drawing.Size screen_size)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Point theScreenLeftTop = MapHelper.GetScreenLocationByLatLng(LeftTop, center, zoom, screen_size);  //矩形左上角屏幕坐标
            Point theScreenRightBottom = MapHelper.GetScreenLocationByLatLng(RightBottom, center, zoom, screen_size);  //矩形右下角屏幕坐标

            int width = Math.Abs(theScreenRightBottom.X - theScreenLeftTop.X);
            int height = Math.Abs(theScreenRightBottom.Y - theScreenLeftTop.Y);
            Rectangle r = new Rectangle(Math.Min(theScreenLeftTop.X, theScreenRightBottom.X), Math.Min(theScreenLeftTop.Y, theScreenRightBottom.Y), width, height);
            if (new Rectangle(new Point(0, 0), screen_size).IntersectsWith(r))
            {
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(30, Color.Blue)))
                {
                    g.FillRectangle(sb, r);
                }
                using (Pen pen = new Pen(Color.FromArgb(150,Color.Blue), 4))
                {
                    g.DrawRectangle(pen, r);
                }
            }
        }
    }
}
