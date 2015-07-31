using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// 经纬度坐标
    /// </summary>
    public class LatLngPoint
    {
        public double Lng
        {
            set;
            get;
        }
        public double Lat
        {
            set;
            get;
        }
        public LatLngPoint(double _lng, double _lat)
        {
            Lng = _lng;
            Lat = _lat;
        }
    }
}
