using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace BMap.NET.WindowsForm.BMapElements
{
    /// <summary>
    /// 地图中POI 信息点
    /// </summary>
    public class BPOI : BMapElement
    {
        /// <summary>
        /// 位置
        /// </summary>
        public LatLngPoint Location
        {
            set;
            get;
        }
        /// <summary>
        /// 索引号
        /// </summary>
        public int Index
        {
            get;
            set;
        }
        /// <summary>
        /// POI的数据源
        /// </summary>
        public JObject DataSource
        {
            get;
            set;
        }
        private bool _selected;
        /// <summary>
        /// 当前POI是否被选中
        /// </summary>
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }
        private Rectangle _rect;
        /// <summary>
        /// POI在屏幕中的范围
        /// </summary>
        public Rectangle Rect
        {
            get
            {
                return _rect;
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
            Point p = MapHelper.GetScreenLocationByLatLng(Location, center, zoom, screen_size);  //屏幕坐标

            Bitmap b;
            if (_selected)
            {
                b = Properties.BMap.ico_blue_point_big;
            }
            else
            {
                b = Properties.BMap.ico_red_point_small;
            }
            g.DrawImage(b, new Rectangle(p.X - b.Width / 2, p.Y - b.Height, b.Width, b.Height));
            using (Font f = new Font("微软雅黑", 10, FontStyle.Bold))
            {
                g.DrawString(((Char)(Index + 65)).ToString(), f, Brushes.White, new PointF(_selected ? (p.X - 5) : (p.X - 6), _selected ? (p.Y - 30) : (p.Y - 26)));
            }
            _rect = new Rectangle(p.X - b.Width / 2, p.Y - b.Height, b.Width, b.Height);
        }
    }
}
