using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BMap.NET.WindowsForm.BMapElements
{
    /// <summary>
    /// 地图中的标记点
    /// </summary>
    class BMarker:BMapElement
    {
        /// <summary>
        /// 索引号
        /// </summary>
        public int Index
        {
            get;
            set;
        }
        /// <summary>
        /// 位置
        /// </summary>
        public LatLngPoint Location
        {
            set;
            get;
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
        /// <summary>
        /// 标记名
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 标记备注
        /// </summary>
        public string Remarks
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
            g.DrawImage(b, new Point(p.X - b.Width / 2, p.Y - b.Height));
            using (Font f = new Font("微软雅黑", 10, FontStyle.Bold))
            {
                g.DrawString(((Char)(Index + 65)).ToString(), f, Brushes.White, new PointF(_selected ? (p.X - 2) : (p.X - 3), _selected ? (p.Y - 25) : (p.Y - 20)));
            }
        }
    }
}
