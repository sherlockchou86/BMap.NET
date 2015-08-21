using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using BMap.NET.HTTPService;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace BMap.NET.WindowsForm.BMapElements
{
    /// <summary>
    /// 地图瓦片
    /// </summary>
    class BTile:BMapElement
    {
        static BTile()
        {
            int minWorker, minIOC;
            // 设置线程池最小线程数目
            ThreadPool.GetMinThreads(out minWorker, out minIOC);
            ThreadPool.SetMinThreads(100, minIOC);
        }
        /// <summary>
        /// 瓦片X坐标
        /// </summary>
        public int X
        {
            get;
            set;
        }
        /// <summary>
        /// 瓦片Y坐标
        /// </summary>
        public int Y
        {
            get;
            set;
        }
        /// <summary>
        /// 当前地图缩放级别
        /// </summary>
        public int Zoom
        {
            set;
            get;
        }
        /// <summary>
        /// 当前所在地图控件
        /// </summary>
        public Control BMapControl
        {
            get;
            set;
        }

        private MapMode _mode;
        /// <summary>
        /// 地图模式
        /// </summary>
        [DefaultValue(MapMode.Normal)]
        public MapMode Mode
        {
            get
            {
                return _mode;
            }
            set
            {
                if (value != _mode)
                {
                    _mode = value;
                }
            }
        }
        private LoadMapMode _loadMode;
        /// <summary>
        /// 瓦片加载模式
        /// </summary>
        [DefaultValue(LoadMapMode.CacheServer)]
        public LoadMapMode LoadMode
        {
            get
            {
                return _loadMode;
            }
            set
            {
                if (_loadMode != value)
                {
                    _loadMode = value;
                    _loading = false;
                    _load_error = false;
                    _normal = null;
                    _sate = null;
                    _road_net = null;
                }
            }
        }

        private Bitmap _normal;
        private Bitmap _sate;
        private Bitmap _road_net;
        private bool _loading = false;
        private bool _load_error = false;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="parent"></param>
        /// <param name="mode"></param>
        /// <param name="loadmode"></param>
        public BTile(int x, int y, int z, Control parent, MapMode mode,LoadMapMode loadmode)
        {
            X = x;
            Y = y;
            Zoom = z;
            BMapControl = parent;
            Mode = mode;
            LoadMode = loadmode;
        }
        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="g"></param>
        /// <param name="center"></param>
        /// <param name="zoom"></param>
        /// <param name="screen_size"></param>
        public override void Draw(System.Drawing.Graphics g, LatLngPoint center, int zoom, Size screen_size)
        {
            //偏移处理
            //LatLngPoint offset = new LatLngPoint(MapHelper.OFFSET_LNG, MapHelper.OFFSET_LAT);
            //PointF offset_p = MapHelper.GetLocationByLatLng(offset, zoom);

            PointF center_p = MapHelper.GetLocationByLatLng(center, zoom); //中心点像素坐标
            PointF toleft_p = new PointF(X * 256, (Y + 1) * 256); //瓦片左上角像素坐标
            PointF p = new PointF((int)(screen_size.Width / 2 + (toleft_p.X - center_p.X)), (int)(screen_size.Height / 2 + (toleft_p.Y - center_p.Y) * (-1)));  //屏幕坐标
            //在绘制范围之内
            if (!new Rectangle(-256, -256, screen_size.Width + 256, screen_size.Height + 256).Contains(new Point((int)p.X, (int)p.Y)))
            {
                return;
            }
            if (Mode == MapMode.Normal && _normal == null && !_loading)  //开始下载普通瓦片
            {
                _loading = true;
                if (!_load_error)
                    ((Action)(delegate()
                    {
                        MapService ms = new MapService();
                        _normal = ms.LoadMapTile(X, Y, Zoom, Mode, LoadMode);
                        _loading = false;
                        if (_normal == null)
                        {
                            _load_error = true;
                        }
                        BMapControl.Invoke((Action)delegate()
                        {
                            BMapControl.Invalidate();
                        });

                    })).BeginInvoke(null, null);
            }
            if (Mode == MapMode.RoadNet && _road_net == null && !_loading)  //开始下载道路网瓦片
            {
                _loading = true;
                if (!_load_error)
                ((Action)(delegate()
                {
                    MapService ms = new MapService();
                    _road_net = ms.LoadMapTile(X, Y, Zoom, Mode, LoadMode);
                    _loading = false;
                    if (_road_net == null)
                    {
                        _load_error = true;
                    }
                    BMapControl.Invoke((Action)delegate()
                    {
                        BMapControl.Invalidate();
                    });

                })).BeginInvoke(null, null);
            }
            if (Mode == MapMode.Satellite && _sate == null && !_loading)  //开始下载卫星图瓦片
            {
                _loading = true;
                if (!_load_error)
                ((Action)(delegate()
                {
                    MapService ms = new MapService();
                    _sate = ms.LoadMapTile(X, Y, Zoom, Mode, LoadMode);
                    _loading = false;
                    if (_sate == null)
                    {
                        _load_error = true;
                    }
                    BMapControl.Invoke((Action)delegate()
                    {
                        BMapControl.Invalidate();
                    });

                })).BeginInvoke(null, null);
            }
            if (Mode == MapMode.Sate_RoadNet && _sate == null && !_loading)  //开始下载卫星图瓦片
            {
                _loading = true;
                if (!_load_error)
                ((Action)(delegate()
                {
                    MapService ms = new MapService();
                    _sate = ms.LoadMapTile(X, Y, Zoom, MapMode.Satellite, LoadMode);
                    _loading = false;
                    if (_sate == null)
                    {
                        _load_error = true;
                    }
                    BMapControl.Invoke((Action)delegate()
                    {
                        BMapControl.Invalidate();
                    });

                })).BeginInvoke(null, null);
            }
            if (Mode == MapMode.Sate_RoadNet && _road_net == null && !_loading) //开始下载道路网瓦片
            {
                _loading = true;
                if (!_load_error)
                ((Action)(delegate()
                {
                    MapService ms = new MapService();
                    _road_net = ms.LoadMapTile(X, Y, Zoom, MapMode.RoadNet, LoadMode);
                    _loading = false;
                    if (_road_net == null)
                    {
                        _load_error = true;
                    }
                    BMapControl.Invoke((Action)delegate()
                    {
                        BMapControl.Invalidate();
                    });

                })).BeginInvoke(null, null);
            }

            string error = "正在加载图片...";
            if (_load_error)
            {
                error = "图片加载失败...";
            }
            if (Mode == MapMode.Normal)  //绘制普通地图
            {
                if (_normal == null)
                {
                    g.FillRectangle(Brushes.LightGray, new RectangleF(p, new SizeF(256, 256)));
                    g.DrawRectangle(Pens.Gray, p.X, p.Y, 256, 256);
                    using (Font f = new Font("微软雅黑", 10))
                    {
                        g.DrawString(error, f, Brushes.Red, new PointF(p.X + 60, p.Y + 100));
                    }
                }
                else
                {
                    g.DrawImage(_normal, new RectangleF(p, new SizeF(256, 256)));
                }
            }
            if (Mode == MapMode.RoadNet) //绘制道路网
            {
                if (_road_net == null)
                {
                    g.FillRectangle(Brushes.LightGray, new RectangleF(p, new SizeF(256, 256)));
                    g.DrawRectangle(Pens.Gray, p.X, p.Y, 256, 256);
                    using (Font f = new Font("微软雅黑", 10))
                    {
                        g.DrawString(error, f, Brushes.Red, new PointF(p.X + 60, p.Y + 100));
                    }
                }
                else
                {
                    g.DrawImage(_road_net, new RectangleF(p, new SizeF(256, 256)));
                }
            }
            if (Mode == MapMode.Satellite)  //绘制卫星图
            {
                if (_sate == null)
                {
                    g.FillRectangle(Brushes.LightGray, new RectangleF(p, new SizeF(256, 256)));
                    g.DrawRectangle(Pens.Gray, p.X, p.Y, 256, 256);
                    using (Font f = new Font("微软雅黑", 10))
                    {
                        g.DrawString(error, f, Brushes.Red, new PointF(p.X + 60, p.Y + 100));
                    }
                }
                else
                {
                    g.DrawImage(_sate, new RectangleF(p, new SizeF(256, 256)));
                }
            }
            if (Mode == MapMode.Sate_RoadNet) //绘制卫星图和道路网
            {
                if (_sate == null && _road_net == null)
                {
                    g.FillRectangle(Brushes.LightGray, new RectangleF(p, new SizeF(256, 256)));
                    g.DrawRectangle(Pens.Gray, p.X, p.Y, 256, 256);
                    using (Font f = new Font("微软雅黑", 10))
                    {
                        g.DrawString(error, f, Brushes.Red, new PointF(p.X + 60, p.Y + 100));
                    }
                }
                else
                {
                    //先绘制卫星图  再绘制道路网
                    if (_sate != null)
                        g.DrawImage(_sate, new RectangleF(p, new SizeF(256, 256)));
                    if(_road_net != null)
                        g.DrawImage(_road_net, new RectangleF(p, new SizeF(256, 256)));
                }
            }
        }
    }
}
