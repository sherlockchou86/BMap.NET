using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// POI类型
    /// </summary>
    enum POIType
    {
        /// <summary>
        /// 普通POI
        /// </summary>
        Normal,
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
