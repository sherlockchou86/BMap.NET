using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            throw new NotImplementedException();
        }
    }
}
