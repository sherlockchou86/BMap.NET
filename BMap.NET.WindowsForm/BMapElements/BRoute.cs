using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BMap.NET.WindowsForm.BMapElements
{
    /// <summary>
    /// 地图中的导航路线
    /// </summary>
    class BRoute : BMapElement
    {
        /// <summary>
        /// 路线类型
        /// </summary>
        public RouteType Type
        {
            get;
            set;
        }
        /// <summary>
        /// 路线数据源
        /// </summary>
        public JObject DataSource
        {
            get;
            set;
        }
        /// <summary>
        /// 路线高亮部分
        /// </summary>
        public string HighlightPath
        {
            get;
            set;
        }
        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="g"></param>
        /// <param name="center"></param>
        /// <param name="zoom"></param>
        /// <param name="screen_size"></param>
        public override void Draw(System.Drawing.Graphics g, LatLngPoint center, int zoom, System.Drawing.Size screen_size)
        {
            //不同路线绘制不一样 数据源结构也不一样
            if (DataSource != null)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality; //质量优先
                
                LatLngPoint first, second;
                Point s_first = new Point(), s_second = new Point();
                if (Type == RouteType.Transit) //公交
                {
                    using (Pen p = new Pen(Color.FromArgb(250, Color.Blue),6))  //蓝色
                    {
                        p.StartCap = System.Drawing.Drawing2D.LineCap.Round; //连接圆滑
                        p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        p.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                        JToken route = DataSource["scheme"][0];
                        foreach (JArray array in route["steps"])
                        {
                            if ((string)array[0]["type"] == "5") //步行
                            {
                                using (Pen p2 = new Pen(Color.FromArgb(250, Color.Gray), 6))
                                {
                                    p2.StartCap = System.Drawing.Drawing2D.LineCap.Round; //连接圆滑
                                    p2.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                                    p2.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

                                    string[] points = ((string)array[0]["path"]).Split(';'); //每一步骤中的点

                                    for (int i = points.Length - 1; i > 0; --i)
                                    {
                                        first = new LatLngPoint(double.Parse(points[i - 1].Split(',')[0]), double.Parse(points[i - 1].Split(',')[1]));
                                        second = new LatLngPoint(double.Parse(points[i].Split(',')[0]), double.Parse(points[i].Split(',')[1]));
                                        s_first = MapHelper.GetScreenLocationByLatLng(first, center, zoom, screen_size);
                                        s_second = MapHelper.GetScreenLocationByLatLng(second, center, zoom, screen_size);
                                        if (new Rectangle(new Point(0, 0), screen_size).Contains(s_first) || new Rectangle(new Point(0, 0), screen_size).Contains(s_second)) //在屏幕范围内
                                            g.DrawLine(p2, s_first, s_second);
                                    }
                                }
                            }
                            else //公交 地铁
                            {
                                string transits = "";
                                double duration = 0;
                                int type = 0;  //公交 还是 地铁
                                string start_name = "";
                                duration = double.Parse((string)array[0]["duration"]);
                                type = int.Parse((string)array[0]["vehicle"]["type"]);
                                start_name = (string)array[0]["vehicle"]["start_name"];
                                foreach (JObject jo in array) //多种方案
                                {
                                    transits += ((string)jo["vehicle"]["name"] + "/");
                                }
                                transits = transits.TrimEnd(new char[] { '/'});
                                //只绘制一个方案即可

                                string[] points = ((string)array[0]["path"]).Split(';'); //每一步骤中的点

                                for (int i = points.Length - 1; i > 0; --i)
                                {
                                    first = new LatLngPoint(double.Parse(points[i - 1].Split(',')[0]), double.Parse(points[i - 1].Split(',')[1]));
                                    second = new LatLngPoint(double.Parse(points[i].Split(',')[0]), double.Parse(points[i].Split(',')[1]));
                                    s_first = MapHelper.GetScreenLocationByLatLng(first, center, zoom, screen_size);
                                    s_second = MapHelper.GetScreenLocationByLatLng(second, center, zoom, screen_size);
                                    if (new Rectangle(new Point(0, 0), screen_size).Contains(s_first) || new Rectangle(new Point(0, 0), screen_size).Contains(s_second)) //在屏幕范围内
                                        g.DrawLine(p, s_first, s_second);

                                    if (i == 1) //起点
                                    {
                                        using (Font f = new Font("微软雅黑", 8))
                                        {
                                            string info = start_name + " 上车\n乘坐" + transits + " \n车程约" + Math.Round(duration / 60, 0) + "分钟";
                                            Size info_size = TextRenderer.MeasureText(info, f);

                                            GraphicsPath pt = new GraphicsPath();

                                            pt.AddPolygon(new Point[] { new Point(s_first.X - info_size.Width / 2 - 5, s_first.Y - 25), 
                                                new Point(s_first.X - info_size.Width / 2 - 5, s_first.Y - 25 - info_size.Height - 10),
                                                new Point(s_first.X + info_size.Width / 2 + 5, s_first.Y - 25 - info_size.Height - 10),
                                                new Point(s_first.X + info_size.Width / 2 + 5,s_first.Y - 25),
                                                    new Point(s_first.X + 8,s_first.Y - 25),
                                                    new Point(s_first.X,s_first.Y-15),
                                                new Point(s_first.X - 8,s_first.Y-25)});
                                            g.FillPath(Brushes.Wheat, pt);
                                            g.DrawPath(Pens.LightGray, pt);
                                            g.DrawString(info, new Font("微软雅黑", 9), Brushes.Black, new PointF(s_first.X - info_size.Width/2, s_first.Y - info_size.Height - 25 - 5));

                                            Bitmap b = type == 0 ? Properties.BMap.ico_bybus : Properties.BMap.ico_bysubway; //0公交 1地铁轻轨

                                            g.DrawImage(b, new Rectangle(s_first.X - b.Width / 2, s_first.Y - b.Height / 2, b.Width, b.Height));
                                        }
                                    }
                                    if (i == points.Length - 1) //终点
                                    {
                                        Bitmap b = type == 0 ? Properties.BMap.ico_bybus : Properties.BMap.ico_bysubway; //0公交 1地铁轻轨

                                        g.DrawImage(b, new Rectangle(s_second.X - b.Width / 2, s_second.Y - b.Height / 2, b.Width, b.Height));
                                    }

                                }
                            }
                        }
                    }
                }
                else if (Type == RouteType.Driving) //驾车
                {
                    using (Pen p = new Pen(Color.FromArgb(250, Color.Green), 6)) //绿色 
                    {
                        p.StartCap = System.Drawing.Drawing2D.LineCap.Round; //连接圆滑
                        p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        p.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                        foreach (JObject step in DataSource["steps"])
                        {
                            first = new LatLngPoint(double.Parse((string)step["stepOriginLocation"]["lng"]), double.Parse((string)step["stepOriginLocation"]["lat"]));
                            s_first = MapHelper.GetScreenLocationByLatLng(first, center, zoom, screen_size); //第一点

                            string[] points = ((string)step["path"]).Split(';'); //每一步骤中的点
                            for (int i = 0; i < points.Length; ++i)
                            {
                                if (i == 0) //与前一点连接
                                {
                                    second = new LatLngPoint(double.Parse(points[i].Split(',')[0]), double.Parse(points[i].Split(',')[1]));
                                    s_second = MapHelper.GetScreenLocationByLatLng(second, center, zoom, screen_size);
                                    if (new Rectangle(new Point(0, 0), screen_size).Contains(s_first) || new Rectangle(new Point(0, 0), screen_size).Contains(s_second)) //在屏幕范围内
                                        g.DrawLine(p, s_first, s_second);
                                }
                                else
                                {
                                    first = new LatLngPoint(double.Parse(points[i - 1].Split(',')[0]), double.Parse(points[i - 1].Split(',')[1]));
                                    second = new LatLngPoint(double.Parse(points[i].Split(',')[0]), double.Parse(points[i].Split(',')[1]));
                                    s_first = MapHelper.GetScreenLocationByLatLng(first, center, zoom, screen_size);
                                    s_second = MapHelper.GetScreenLocationByLatLng(second, center, zoom, screen_size);
                                    if (new Rectangle(new Point(0, 0), screen_size).Contains(s_first) || new Rectangle(new Point(0, 0), screen_size).Contains(s_second)) //在屏幕范围内
                                        g.DrawLine(p, s_first, s_second);
                                }
                            }
                            s_first = s_second;

                            second = new LatLngPoint(double.Parse((string)step["stepDestinationLocation"]["lng"]), double.Parse((string)step["stepDestinationLocation"]["lat"]));
                            s_second = MapHelper.GetScreenLocationByLatLng(second, center, zoom, screen_size);
                            if (new Rectangle(new Point(0, 0), screen_size).Contains(s_first) || new Rectangle(new Point(0, 0), screen_size).Contains(s_second)) //在屏幕范围内
                                g.DrawLine(p, s_first, s_second);  //最后一点
                        }
                    }
                }
                else //步行
                {
                    using (Pen p = new Pen(Color.FromArgb(250, Color.Gray), 6)) //灰色 
                    {
                        p.StartCap = System.Drawing.Drawing2D.LineCap.Round; //连接圆滑
                        p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        p.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                        foreach (JObject step in DataSource["steps"])
                        {
                            first = new LatLngPoint(double.Parse((string)step["stepOriginLocation"]["lng"]), double.Parse((string)step["stepOriginLocation"]["lat"]));
                            s_first = MapHelper.GetScreenLocationByLatLng(first, center, zoom, screen_size); //第一点

                            string[] points = ((string)step["path"]).Split(';'); //每一步骤中的点
                            for (int i = 0; i < points.Length; ++i)
                            {
                                if (i == 0) //与前一点连接
                                {
                                    second = new LatLngPoint(double.Parse(points[i].Split(',')[0]), double.Parse(points[i].Split(',')[1]));
                                    s_second = MapHelper.GetScreenLocationByLatLng(second, center, zoom, screen_size);
                                    if (new Rectangle(new Point(0, 0), screen_size).Contains(s_first) || new Rectangle(new Point(0, 0), screen_size).Contains(s_second)) //在屏幕范围内
                                        g.DrawLine(p, s_first, s_second);
                                }
                                else
                                {
                                    first = new LatLngPoint(double.Parse(points[i - 1].Split(',')[0]), double.Parse(points[i - 1].Split(',')[1]));
                                    second = new LatLngPoint(double.Parse(points[i].Split(',')[0]), double.Parse(points[i].Split(',')[1]));
                                    s_first = MapHelper.GetScreenLocationByLatLng(first, center, zoom, screen_size);
                                    s_second = MapHelper.GetScreenLocationByLatLng(second, center, zoom, screen_size);
                                    if (new Rectangle(new Point(0, 0), screen_size).Contains(s_first) || new Rectangle(new Point(0, 0), screen_size).Contains(s_second)) //在屏幕范围内
                                        g.DrawLine(p, s_first, s_second);
                                }
                            }
                            s_first = s_second;

                            second = new LatLngPoint(double.Parse((string)step["stepDestinationLocation"]["lng"]), double.Parse((string)step["stepDestinationLocation"]["lat"]));
                            s_second = MapHelper.GetScreenLocationByLatLng(second, center, zoom, screen_size);
                            if (new Rectangle(new Point(0, 0), screen_size).Contains(s_first) || new Rectangle(new Point(0, 0), screen_size).Contains(s_second)) //在屏幕范围内
                                g.DrawLine(p, s_first, s_second);  //最后一点
                        }
                    }
                }

                if (HighlightPath != null)
                {
                    using (Pen p3 = new Pen(Color.FromArgb(250, Color.Red), 6))
                    {
                        p3.StartCap = System.Drawing.Drawing2D.LineCap.Round; //连接圆滑
                        p3.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        p3.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                        string[] points = HighlightPath.Split(';'); //高亮部分中的点
                        for (int i = points.Length - 1; i > 0; --i)
                        {
                            first = new LatLngPoint(double.Parse(points[i - 1].Split(',')[0]), double.Parse(points[i - 1].Split(',')[1]));
                            second = new LatLngPoint(double.Parse(points[i].Split(',')[0]), double.Parse(points[i].Split(',')[1]));
                            s_first = MapHelper.GetScreenLocationByLatLng(first, center, zoom, screen_size);
                            s_second = MapHelper.GetScreenLocationByLatLng(second, center, zoom, screen_size);
                            if (new Rectangle(new Point(0, 0), screen_size).Contains(s_first) || new Rectangle(new Point(0, 0), screen_size).Contains(s_second)) //在屏幕范围内
                                g.DrawLine(p3, s_first, s_second);
                        }
                    }
                }
            }
        }
    }
}
