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
        public BMapControl BMapControl
        {
            get;
            set;
        }
        /// <summary>
        /// 与之关联的导航面板控件
        /// </summary>
        public BDirectionBoard BDirectionBoard
        {
            get;
            set;
        }
        /// <summary>
        /// 当前建议搜索城市
        /// </summary>
        public string CurrentCity
        {
            get;
            set;
        }
        public BPlacesBoard()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 将位置显示在列表中
        /// </summary>
        /// <param name="places"></param>
        public void AddPlaces(JToken places)
        {
            flpPlaces.Controls.Clear(); //清空所有位置

            //加载位置项
            int index = 0;
            foreach (JObject place in places)
            {
                BPlaceItem item = new BPlaceItem();
                item.Index = index++;
                item.DataSource = place;
                item.SetDestinationPlace += new SetDestinationPlaceEventHandler(item_SetDestinationPlace);
                item.SetSourcePlace += new SetSourcePlaceEventHandler(item_SetSourcePlace);
                item.PlaceSelectedChanged += new PlaceSelectedChangedEventHandler(item_PlaceSelectedChanged);
                item.Height = 104;
                flpPlaces.Controls.Add(item);
            }
            if (BMapControl != null)
            {
                BMapControl.AddPlaces(places);
            }
        }
        /// <summary>
        /// 清空所有位置
        /// </summary>
        public void ClearPlaces()
        {
            flpPlaces.Controls.Clear(); //清空所有位置
            flpPlaces.Controls.Add(bQuickSearch);  //重新加载快速搜索控件
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
        /// <param name="uid"></param>
        /// <param name="selected"></param>
        void item_PlaceSelectedChanged(string uid, bool selected)
        {
            //BMapControl
        }
        /// <summary>
        /// 设置起点
        /// </summary>
        /// <param name="sourceName"></param>
        void item_SetSourcePlace(string sourceName)
        {
            //BDirecttionBoard
        }
        /// <summary>
        /// 设置终点
        /// </summary>
        /// <param name="destinationName"></param>
        void item_SetDestinationPlace(string destinationName)
        {
            //BDirectionBoard
        }
    }
}
