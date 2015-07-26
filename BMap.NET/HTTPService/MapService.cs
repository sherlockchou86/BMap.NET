using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BMap.NET.HTTPService
{
    /// <summary>
    /// 提供地图相关服务
    /// </summary>
    public class MapService
    {
        private static string _road_url = "http://online{0}.map.bdimg.com/onlinelabel";  //地图切片URL
        private static string _sate_url = "http://shangetu{0}.map.bdimg.com/it/";  //卫星图切片URL

        public Bitmap GetMapTile()
        {
            return new Bitmap(0, 0, null);
        }
    }
}
