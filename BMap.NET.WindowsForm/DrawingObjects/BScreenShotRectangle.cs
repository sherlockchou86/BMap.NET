using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BMap.NET.WindowsForm.DrawingObjects
{
    /// <summary>
    /// 地图中截图矩形
    /// </summary>
    class BScreenShotRectangle:DrawingObject
    {
        /// <summary>
        /// 左上角屏幕坐标
        /// </summary>
        public Point LeftTop
        {
            get;
            set;
        }
        /// <summary>
        /// 矩形宽 像素
        /// </summary>
        public int Width
        {
            get;
            set;
        }
        /// <summary>
        /// 矩形高 像素
        /// </summary>
        public int Height
        {
            set;
            get;
        }
        /// <summary>
        /// 表示屏幕区域
        /// </summary>
        public Rectangle Rect
        {
            get
            {
                return new Rectangle(LeftTop, new Size(Width, Height));
            }
        }
        /// <summary>
        /// 绘制方法
        /// </summary>
        /// <param name="g"></param>
        /// <param name="center"></param>
        /// <param name="zoom"></param>
        /// <param name="screen_size"></param>
        public override void Draw(Graphics g, LatLngPoint center, int zoom, Size screen_size)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(100, Color.White)))
            {
                g.FillRectangle(sb, new Rectangle(LeftTop, new Size(Width, Height)));
            }
            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawRectangle(pen, new Rectangle(LeftTop, new Size(Width, Height)));
            }
            using (SolidBrush sb = new SolidBrush(Color.Black))
            {
                //移动柄
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 3, LeftTop.Y - 3), new Size(6, 6)));
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 3 + Width / 2, LeftTop.Y - 3), new Size(6, 6)));
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 3 + Width, LeftTop.Y - 3), new Size(6, 6)));
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 3 + Width, LeftTop.Y - 3 + Height / 2), new Size(6, 6)));
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 3 + Width, LeftTop.Y - 3 + Height), new Size(6, 6)));
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 3 + Width / 2, LeftTop.Y - 3 + Height), new Size(6, 6)));
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 3, LeftTop.Y - 3 + Height), new Size(6, 6)));
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 3, LeftTop.Y - 3 + Height / 2), new Size(6, 6)));
                //高宽
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 2, LeftTop.Y - 23), new Size(60, 18)));
                using (Font f = new Font("微软雅黑", 9))
                {
                    g.DrawString(Width + "×" + Height, f, Brushes.White, new PointF(LeftTop.X - 1, LeftTop.Y - 21));
                }
            }
        }
    }
}
