using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BMap.NET.WindowsForm.BMapElements
{
    /// <summary>
    /// 矩形搜索区域
    /// </summary>
    class BBound:BMapElement
    {
        /// <summary>
        /// 左上角点
        /// </summary>
        public LatLngPoint LeftTop
        {
            get;
            set;
        }
        /// <summary>
        /// 右下角点
        /// </summary>
        public LatLngPoint RightBottom
        {
            set;
            get;
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
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(15, Color.DarkBlue)))
                {
                    g.FillRectangle(sb, r);
                }
                using (Pen pen = new Pen(Color.FromArgb(150,Color.DarkBlue), 2))
                {
                    g.DrawRectangle(pen, r);
                }
            }

            double d1 = MapHelper.GetDistanceByLatLng(LeftTop, new LatLngPoint(LeftTop.Lng, RightBottom.Lat));
            double d2 = MapHelper.GetDistanceByLatLng(LeftTop, new LatLngPoint(RightBottom.Lng, LeftTop.Lat));
            double d3 = MapHelper.GetDistanceByLatLng(new LatLngPoint(LeftTop.Lng, RightBottom.Lat), RightBottom);
            double d4 = MapHelper.GetDistanceByLatLng(new LatLngPoint(RightBottom.Lng, LeftTop.Lat), RightBottom);

            using (Font f = new Font("微软雅黑", 9))
            {
                g.FillRectangle(Brushes.DarkBlue, new Rectangle(theScreenLeftTop.X, (theScreenLeftTop.Y + theScreenRightBottom.Y) / 2 - 10, 60, 20));
                g.DrawString(Math.Round(d1, 2).ToString() + "km", f, Brushes.White, new PointF(theScreenLeftTop.X + 5, (theScreenLeftTop.Y + theScreenRightBottom.Y) / 2 - 8));
                g.FillRectangle(Brushes.DarkBlue, new Rectangle((theScreenLeftTop.X + theScreenRightBottom.X) / 2 - 30, theScreenLeftTop.Y, 60, 20));
                g.DrawString(Math.Round(d2, 2).ToString() + "km", f, Brushes.White, new PointF((theScreenLeftTop.X + theScreenRightBottom.X) / 2 - 30 + 5, theScreenLeftTop.Y + 2));
                g.FillRectangle(Brushes.DarkBlue, new Rectangle((theScreenLeftTop.X + theScreenRightBottom.X) / 2 - 30, theScreenRightBottom.Y - 20, 60, 20));
                g.DrawString(Math.Round(d3, 2).ToString() + "km", f, Brushes.White, new PointF((theScreenLeftTop.X + theScreenRightBottom.X) / 2 - 30 + 5, theScreenRightBottom.Y + 4 - 20));
                g.FillRectangle(Brushes.DarkBlue, new Rectangle(theScreenRightBottom.X - 60, (theScreenLeftTop.Y + theScreenRightBottom.Y) / 2 - 10, 60, 20));
                g.DrawString(Math.Round(d4, 2).ToString() + "km", f, Brushes.White, new PointF(theScreenRightBottom.X - 60 + 3, (theScreenLeftTop.Y + theScreenRightBottom.Y) / 2 - 10));
            }
        }
    }
}
