using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMap.NET.HTTPService;

using Newtonsoft.Json.Linq;
using BMap.NET.WindowsForm.BMapElements;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// 位置列表控件
    /// </summary>
    public partial class BPlacesBoard : UserControl
    {
        /// <summary>
        /// 与之关联的地图控件
        /// </summary>
        [Description("与之关联的地图控件"),Category("BMap.NET")]
        public BMapControl BMapControl
        {
            get;
            set;
        }
        /// <summary>
        /// 与之关联的导航面板控件
        /// </summary>
        [Description("与之关联的导航控件"),Category("BMap.NET")]
        public BDirectionBoard BDirectionBoard
        {
            get;
            set;
        }
        /// <summary>
        /// 当前建议搜索城市
        /// </summary>
        [Description("当前建议搜索城市"),Category("BMap.NET")]
        public string CurrentCity
        {
            get;
            set;
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public BPlacesBoard()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 将位置显示在列表中
        /// </summary>
        /// <param name="places"></param>
        internal void AddPlaces(JToken places)
        {
            flpPlaces.Controls.Clear(); //清空原来所有位置
            if (Parent != null && Parent is TabPage) //如果父控件是tabpage 则选中
            {
                ((Parent as TabPage).Parent as TabControl).SelectedTab = (Parent as TabPage);
            }
            if (BDirectionBoard != null) //导航控件初始化
            {
                BDirectionBoard.Clear();
            }

            //加载位置项
            int index = 0; List<BPOI> _list = new List<BPOI>();
            foreach (JObject place in places)
            {
                if (place["location"] != null && place["location"]["lng"] != null && (string)place["location"]["lng"] != "")
                {
                    LatLngPoint location = new LatLngPoint(double.Parse((string)place["location"]["lng"]), double.Parse((string)place["location"]["lat"]));
                    BPOI poi = new BPOI { DataSource = place, Index = index, Selected = false, Location = location };
                    _list.Add(poi);

                    BPlaceItem item = new BPlaceItem();
                    item.Index = index++;
                    item.POI = poi;
                    item.SetDestinationPlace += new SetDestinationPlaceEventHandler(item_SetDestinationPlace);
                    item.SetSourcePlace += new SetSourcePlaceEventHandler(item_SetSourcePlace);
                    item.PlaceSelectedChanged += new PlaceSelectedChangedEventHandler(item_PlaceSelectedChanged);
                    item.Height = 104;
                    flpPlaces.Controls.Add(item);
                }
            }
            if (BMapControl != null)
            {
                BMapControl.AddPlaces(_list);
            }
        }
        /// <summary>
        /// 清空所有位置（初始化控件）
        /// </summary>
        public void Clear()
        {
            flpPlaces.Controls.Clear(); //清空所有位置
            flpPlaces.Controls.Add(bQuickSearch);  //重新加载快速搜索控件
            if (BMapControl != null)
            {
                BMapControl.ClearPlaces();
            }
        }
        /// <summary>
        /// 点击快速搜索面板上的按钮
        /// </summary>
        /// <param name="searchName"></param>
        private void bQuickSearch_QuickSearch(string searchName)
        {
            ((Action)delegate()
            {
                PlaceService ps = new PlaceService();
                JObject places = ps.SearchInCity(searchName, CurrentCity);
                if (places != null)
                {
                    this.Invoke((Action)delegate()
                    {
                        flpPlaces.Controls.Remove(bQuickSearch);
                        AddPlaces(places["results"]);  //具体json格式参见api文档
                    });
                }
            }).BeginInvoke(null, null);
        }

        /// <summary>
        /// 选中位置改变
        /// </summary>
        /// <param name="poi"></param>
        void item_PlaceSelectedChanged(BPOI poi)
        {
            //BMapControl
            foreach (Control c in flpPlaces.Controls)
            {
                if (c is BPlaceItem && (c as BPlaceItem).POI != poi)
                {
                    (c as BPlaceItem).Selected = false;
                }
            }
            if (BMapControl != null)
            {
                BMapControl.SelectBPOI(poi);
            }
        }
        /// <summary>
        /// 设置起点
        /// </summary>
        /// <param name="sourceName"></param>
        void item_SetSourcePlace(string sourceName)
        {
            //BDirecttionBoard
            if (BDirectionBoard != null)
            {
                BDirectionBoard.SourcePlace = sourceName;
            }
        }
        /// <summary>
        /// 设置终点
        /// </summary>
        /// <param name="destinationName"></param>
        void item_SetDestinationPlace(string destinationName)
        {
            //BDirectionBoard
            if (BDirectionBoard != null)
            {
                BDirectionBoard.DestinationPlace = destinationName;
            }
        }
    }
}
