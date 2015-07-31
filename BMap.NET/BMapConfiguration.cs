using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMap.NET
{
    /// <summary>
    /// 负责读/写配置
    /// </summary>
    public class BMapConfiguration
    {
        /// <summary>
        /// 访问WebAPI的AK
        /// </summary>
        public static string AK
        {
            get
            {
                return Properties.BMap.Default.ServiceAK;
            }
            set
            {
                Properties.BMap.Default.ServiceAK = value;
                Properties.BMap.Default.Save();
            }
        }
        /// <summary>
        /// 访问WebAPI的SK
        /// </summary>
        public static string SK
        {
            get
            {
                return Properties.BMap.Default.ServiceSK;
            }
            set
            {
                Properties.BMap.Default.ServiceSK = value;
                Properties.BMap.Default.Save();
            }
        }
        /// <summary>
        /// Web API校验方式
        /// </summary>
        public static VerificationMode VerificationMode
        {
            get
            {
                return (VerificationMode)Properties.BMap.Default.VerificationMode;
            }
            set
            {
                Properties.BMap.Default.VerificationMode = (int)value;
                Properties.BMap.Default.Save();
            }
        }
        /// <summary>
        /// 地图加载方式
        /// </summary>
        public static LoadMapMode LoadMapMode
        {
            get
            {
                return (LoadMapMode)Properties.BMap.Default.LoadMapMode;
            }
            set
            {
                Properties.BMap.Default.LoadMapMode = (int)value;
                Properties.BMap.Default.Save();
            }
        }
        /// <summary>
        /// 地图缓存路径
        /// </summary>
        public static string MapCachePath
        {
            get
            {
                return Properties.BMap.Default.MapCachePath;
            }
            set
            {
                Properties.BMap.Default.MapCachePath = value;
                Properties.BMap.Default.Save();
            }
        }
    }
}
