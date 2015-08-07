using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BMap.NET.WindowsForm.BMapElements
{
    /// <summary>
    /// 距离测量类
    /// </summary>
    class BDistance : BMapElement
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
        /// <param name="g"></param>
        /// <param name="center"></param>
        /// <param name="zoom"></param>
        /// <param name="screen_size"></param>
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
                
                double total = 0; double step = 0;
                using (Pen pen = new Pen(Color.FromArgb(150, Color.OrangeRed), 4))
                {
                    for (int i = 0; i < l.Count - 1; ++i)
                    {
                        g.DrawLine(pen, l[i], l[i + 1]);
                        g.FillEllipse(Brushes.White, new Rectangle(new Point(l[i].X - 4, l[i].Y - 4), new Size(8, 8)));
                        g.DrawEllipse(Pens.OrangeRed, new Rectangle(new Point(l[i].X - 4, l[i].Y - 4), new Size(8, 8)));

                        if (i == 0)  //起点
                        {
                            g.FillRectangle(Brushes.White, new Rectangle(l[i].X + 3, l[i].Y, 35, 20));
                            g.DrawRectangle(Pens.DarkGray, new Rectangle(l[i].X + 3, l[i].Y, 35, 20));
                            g.DrawString("起点", new Font("微软雅黑", 9), Brushes.OrangeRed, new PointF(l[i].X + 6, l[i].Y + 2));

                            if (i == l.Count - 2)  //终点 只有两点的时候
                            {
                                step = MapHelper.GetDistanceByLatLng(Points[i], Points[i + 1]);
                                total += step;

                                g.FillRectangle(Brushes.White, new Rectangle(l[i + 1].X + 3, l[i + 1].Y, 90, 20));
                                g.DrawRectangle(Pens.DarkGray, new Rectangle(l[i + 1].X + 3, l[i + 1].Y, 90, 20));
                                g.DrawString("总长:" + Math.Round(total,2) + "公里", new Font("微软雅黑", 9), Brushes.OrangeRed, new PointF(l[i + 1].X + 10, l[i + 1].Y + 2));
                            }
                        }
                        else //其它点
                        {
                            step = MapHelper.GetDistanceByLatLng(Points[i-1], Points[i]);
                            total += step;

                            g.FillRectangle(Brushes.White, new Rectangle(l[i].X + 3, l[i].Y, 70, 20));
                            g.DrawRectangle(Pens.DarkGray, new Rectangle(l[i].X + 3, l[i].Y, 70, 20));
                            g.DrawString(Math.Round(step,2) + "公里", new Font("微软雅黑", 9), Brushes.OrangeRed, new PointF(l[i].X + 10, l[i].Y + 2));

                            if (i == l.Count - 2)  //终点
                            {
                                step = MapHelper.GetDistanceByLatLng(Points[i], Points[i + 1]);
                                total += step;
                                g.FillRectangle(Brushes.White, new Rectangle(l[i + 1].X + 3, l[i + 1].Y, 100, 20));
                                g.DrawRectangle(Pens.DarkGray, new Rectangle(l[i + 1].X + 3, l[i + 1].Y, 100, 20));
                                g.DrawString("总长:" + Math.Round(total, 2) + "公里", new Font("微软雅黑", 9), Brushes.OrangeRed, new PointF(l[i + 1].X + 10, l[i + 1].Y + 2));
                            }
                        }
                    }
                }
            }
        }
    }
}
