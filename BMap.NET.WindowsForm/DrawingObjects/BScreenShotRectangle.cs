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
        /// 绘制方法
        /// </summary>
        /// <param name="g"></param>
        /// <param name="center"></param>
        /// <param name="zoom"></param>
        /// <param name="screen_size"></param>
        public override void Draw(Graphics g, LatLngPoint center, int zoom, Size screen_size)
        {
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
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 2, LeftTop.Y - 2), new Size(4, 4)));
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 2 + Width / 2, LeftTop.Y - 2), new Size(4, 4)));
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 2 + Width, LeftTop.Y - 2), new Size(4, 4)));
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 2 + Width, LeftTop.Y - 2 + Height / 2), new Size(4, 4)));
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 2 + Width, LeftTop.Y - 2 + Height), new Size(4, 4)));
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 2 + Width / 2, LeftTop.Y - 2 + Height), new Size(4, 4)));
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 2, LeftTop.Y - 2 + Height), new Size(4, 4)));
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 2, LeftTop.Y - 2 + Height / 2), new Size(4, 4)));
                //高宽
                g.FillRectangle(sb, new Rectangle(new Point(LeftTop.X - 2, LeftTop.Y - 20), new Size(80, 20)));
                using (Font f = new Font("微软雅黑", 9))
                {
                    g.DrawString(Width + "×" + Height, f, sb, new PointF(LeftTop.X - 2, LeftTop.Y - 16));
                }
            }
        }
    }
}
