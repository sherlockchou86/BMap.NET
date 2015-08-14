using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BMap.NET.WindowsForm.BMapElements
{
    /// <summary>
    /// 地图中位置点（与BPOI不同）
    /// </summary>
    class BPoint:BMapElement
    {
        /// <summary>
        /// 位置点类型
        /// </summary>
        public PointType Type
        {
            get;
            set;
        }
        /// <summary>
        /// 位置坐标
        /// </summary>
        public LatLngPoint Location
        {
            get;
            set;
        }
        /// <summary>
        /// 具体地址
        /// </summary>
        public string Address
        {
            get;
            set;
        }
        private bool _selected;
        /// <summary>
        /// 是否被选中
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
        /// 在屏幕中的范围
        /// </summary>
        public Rectangle Rect
        {
            get
            {
                return _rect;
            }
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
            Point p = MapHelper.GetScreenLocationByLatLng(Location, center, zoom, screen_size);  //屏幕坐标
            Bitmap b = null;
            if (Type == PointType.RouteEnd)
            {
                b = Properties.BMap.ico_route_end;
            }
            else if (Type == PointType.RouteStart)
            {
                b = Properties.BMap.ico_route_start;
            }
            else if(Type == PointType.Strange)
            {
                b = Properties.BMap.ico_strange_point;
            }
            _rect = new Rectangle(p.X - b.Width / 2, p.Y - b.Height, b.Width, b.Height);
            g.DrawImage(b, _rect);
        }
    }
}
