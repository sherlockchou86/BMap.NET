using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// 地图中BPoint位置点类型
    /// </summary>
    enum PointType
    {
        /// <summary>
        /// 路线起点
        /// </summary>
        RouteStart,
        /// <summary>
        /// 路线终点
        /// </summary>
        RouteEnd,
        /// <summary>
        /// 未知点
        /// </summary>
        Strange
    }
}
