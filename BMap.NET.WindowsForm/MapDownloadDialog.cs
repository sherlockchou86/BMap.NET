using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using BMap.NET.HTTPService;
using System.Collections;

namespace BMap.NET.WindowsForm
{
    public partial class MapDownloadDialog : Form
    {
        LatLngPoint p1; LatLngPoint p2;
        ArrayList _waittodownload = new ArrayList();  //待下载图片集合

        public MapDownloadDialog(LatLngPoint p1, LatLngPoint p2)
        {
            InitializeComponent();
            this.p1 = p1;
            this.p2 = p2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                if (fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtPath.Text = fb.SelectedPath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _path = txtPath.Text;
            if (_path.Equals(""))
            {
                MessageBox.Show("请选择存储路径！");
                return;
            }
            if (numZoom.Value > numZoomEnd.Value)
            {
                MessageBox.Show("地图级别设置不对！");
                return;
            }

            int zoomStart = (int)numZoom.Value;
            int zoomEnd = (int)numZoomEnd.Value;

            int thread = (int)numThread.Value;

            _waittodownload.Clear();
            for (int zoom = zoomStart; zoom <= zoomEnd; ++zoom)
            {


                PointF point1 = MapHelper.GetLocationByLatLng(p1, zoom); //将第一个点经纬度转换成平面2D坐标
                PointF point2 = MapHelper.GetLocationByLatLng(p2, zoom);  //将第二个点经纬度转换成平面2D坐标

                int startX = (int)point1.X / 256;  //起始列
                int endX = (int)point2.X / 256;   //结束列
                if (endX == Math.Pow(2, zoom))  //结束列超出范围
                {
                    endX--;
                }
                int startY = (int)point1.Y / 256;  //起始行
                int endY = (int)point2.Y / 256;   //结束行
                if (endY == Math.Pow(2, zoom))  //结束行超出范围
                {
                    endY--;
                }

                _totalwidth = (endX - startX + 1) * 256;  //合并图的宽度
                _totalheight = (endY - startY + 1) * 256;  //合并图的高度

                int threadId = 0;

                for (int y = startY; y <= endY; y++)
                {
                    for (int x = startX; x <= endX; x++)
                    {
                        RectInfo ri = new RectInfo();
                        ri.threadId = threadId;  //分别由不同的线程下载
                        ri.x = x;
                        ri.y = y;
                        ri.z = zoom;
                        ri.bComplete = false;
                        _waittodownload.Add(ri);  //将每个小方块放入待下载集合
                        threadId = (threadId + 1) % thread;  //由thread个不同线程下载图片
                    }
                }
            }

            if (MessageBox.Show("共有" + _waittodownload.Count + "张图片需要下载，确定下载吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                _thread = thread;
                _zoom = zoomStart;
                _zoomEnd = zoomEnd;

                _downloadnum = 0;

                _normal = radioButton1.Checked;
                button2.Enabled = false;
                rchOuput.Clear();
                groupBox2.Text = "输出(" + _waittodownload.Count + "张)";
                _startTime = DateTime.Now;
                for (int i = 1; i <= thread; ++i)
                {
                    Thread t = new Thread(new ParameterizedThreadStart(DownloadThreadProc));
                    t.Start(i);  //开启下载线程
                }
            }

        }

        /// <summary>
        /// 下载线程方法
        /// </summary>
        /// <param name="param"></param>
        public void DownloadThreadProc(object param)
        {
            int threadId = (int)param;  //当前线程Id
            MapService mapService = new MapService();

            this.Invoke((Action)delegate()  //输出
            {
                rchOuput.SelectionColor = Color.Blue;
                rchOuput.AppendText(DateTime.Now.ToLongTimeString() + " 第" + threadId + "号线程开始执行\r\n");
            });
            for (int i = 0; i < _waittodownload.Count; i++)
            {
                RectInfo ri = (RectInfo)_waittodownload[i];
                if ((!ri.bComplete) && (ri.threadId + 1 == threadId))
                {
                    try
                    {
                        Bitmap map = mapService.LoadMapTile(ri.x, ri.y, ri.z, _normal ? MapMode.Normal : MapMode.Satellite, LoadMapMode.CacheServer);
                        string file = _path + "\\" + ri.z.ToString() + "\\" + ri.z.ToString() + "_" + ri.x.ToString() + "_" + ri.y.ToString() + ".jpg";
                        ri.Bitmap = map;
                        //文件保存格式 “缩放级别_列_行.jpg”
                        if (!Directory.Exists(_path + "\\" + ri.z.ToString()))
                        {
                            Directory.CreateDirectory(_path + "\\" + ri.z.ToString());
                        }
                        map.Save(file, System.Drawing.Imaging.ImageFormat.Jpeg);

                        this.Invoke((Action)delegate()  //输出
                        {
                            rchOuput.SelectionColor = Color.Green;
                            rchOuput.AppendText(DateTime.Now.ToLongTimeString() + " 第" + threadId + "号线程下载图片" + ri.z.ToString() + "_" + ri.x.ToString() + "_" + ri.y.ToString() + ".jpg\r\n");
                        });
                        _downloadnum++;

                        ri.bComplete = true;
                    }
                    catch
                    {
                        this.Invoke((Action)delegate()  //输出
                        {
                            rchOuput.SelectionColor = Color.Red;
                            rchOuput.AppendText(DateTime.Now.ToLongTimeString() + " 第" + threadId + "号线程下载图片" + ri.z.ToString() + "_" + ri.x.ToString() + "_" + ri.y.ToString() + ".jpg失败！\r\n");
                        });
                    }
                }
            }
            this.Invoke((Action)delegate()  //输出
            {
                rchOuput.SelectionColor = Color.Blue;
                rchOuput.AppendText(DateTime.Now.ToLongTimeString() + " 第" + threadId + "号线程执行完毕\r\n");
            });
            _thread--; //工作线程数目减一
            if (_thread == 0) //所有线程均结束
            {
                this.Invoke((Action)delegate()  //输出
                {
                    rchOuput.SelectionColor = Color.Blue;
                    rchOuput.AppendText(DateTime.Now.ToLongTimeString() + " 图片下载结束！共下载" + _downloadnum + "张，共耗时" + (DateTime.Now - _startTime).TotalSeconds + "秒");
                    button2.Enabled = true;
                });
            }
        }

        public string _path { get; set; }

        public int _thread { get; set; }

        public DateTime _startTime { get; set; }

        public int _downloadnum { get; set; }

        public int _zoom { get; set; }

        public bool _normal { get; set; }

        private void MapDownloadDialog_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_downloadnum == _waittodownload.Count && _downloadnum != 0)  //全部下载完毕
            {
                for (int zoom = _zoom; zoom <= _zoomEnd; ++zoom)
                {
                    Bitmap b = new Bitmap((int)_totalwidth, (int)_totalheight);
                    Graphics g = Graphics.FromImage(b);
                    int startx = ((RectInfo)(_waittodownload[0])).x;
                    int starty = ((RectInfo)(_waittodownload[0])).y;
                    foreach (RectInfo rf in _waittodownload)
                    {
                        g.DrawImage(rf.Bitmap, new Rectangle(new Point((rf.x - startx) * 256, (int)_totalheight - (rf.y - starty + 1) * 256), new Size(256, 256)));
                    }
                    g.Dispose();
                    b.Save(_path + "\\" + _zoom + "_total.jpg");
                    b.Dispose();
                    System.Diagnostics.Process.Start(_path + "\\" + _zoom + "_total.jpg");
                }
            }
        }

        public int _totalwidth { get; set; }

        public int _totalheight { get; set; }

        public int _zoomEnd { get; set; }
    }


    /// <summary>
    /// 地图中每个256*256尺寸的方块
    /// </summary>
    public class RectInfo
    {
        public int serverId;  //目标服务器
        public int threadId;  //目标下载线程
        public string url;  //下载url
        public int x;  //列
        public int y;  //行
        public int z;  //缩放级别
        public bool bComplete;  //是否完成
        public Bitmap Bitmap; //图片
    }
}
