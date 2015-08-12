using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

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
        /// <summary>
        /// 标记点实际详细位置
        /// </summary>
        public string Address
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
        private Rectangle _rect;
        /// <summary>
        /// 标记点在屏幕中的范围
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
            Bitmap b = Properties.BMap.ico_marker;
            g.DrawImage(b, new Rectangle(p.X - b.Width / 2, p.Y - b.Height, b.Width, b.Height));
            using (Font f = new Font("微软雅黑", 9))
            {
                Size s = TextRenderer.MeasureText(Name, f);  //字体占用像素
                g.FillRectangle(Brushes.Wheat, new Rectangle(new Point(p.X + b.Width / 2 + 5, p.Y - b.Height), new Size(s.Width + 6, s.Height + 6)));
                g.DrawRectangle(Pens.Gray, new Rectangle(new Point(p.X + b.Width / 2 + 5, p.Y - b.Height), new Size(s.Width + 6, s.Height + 6)));
                g.DrawString(Name, f, Brushes.Black, new PointF(p.X + b.Width / 2 + 5 + 3, p.Y - b.Height + 3));
            }
            _rect = new Rectangle(p.X - b.Width / 2, p.Y - b.Height, b.Width, b.Height);
        }
    }
}
