using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMap.NET.WindowsForm.FunctionalControls
{
    /// <summary>
    /// 可以按拼音顺序、行政组织结构的方式显示城市列表的控件
    /// </summary>
    partial class CityList : UserControl
    {
        public event SelectedCityChangedEventHandler SelectedCityChanged;
        /// <summary>
        /// 构造方法
        /// </summary>
        public CityList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 城市控件显示方式
        /// </summary>
        public CityListMode Mode
        {
            get;
            set;
        }
        /// <summary>
        /// 拼音类型数据源
        /// </summary>
        public Dictionary<string, List<string>> DataByPinyin
        {
            get;
            set;
        }
        /// <summary>
        /// 行政组织结构类型数据源
        /// </summary>
        public CityNode DataByOrganization
        {
            get;
            set;
        }
        /// <summary>
        /// 刷新列表
        /// </summary>
        public void RefreshList()
        {
            flpList.Controls.Clear();
            flpList.BackColor = Color.White;
            flpList.Padding = new Padding(3);
            //按照拼音方式显示
            if (Mode == CityListMode.Pinyin)
            {
                if (DataByPinyin != null)
                {
                    var c = DataByPinyin.OrderBy((p) => p.Key); 
                    foreach (KeyValuePair<string, List<string>> p in c)  //遍历26个拼音
                    {
                        Label lbl_title = new Label();
                        lbl_title.BackColor = Color.LightGray;
                        lbl_title.Width = 150;
                        lbl_title.AutoSize = false;
                        lbl_title.Font = new System.Drawing.Font("微软雅黑", 12, FontStyle.Bold);
                        lbl_title.Height = 30;
                        lbl_title.Text = " " + p.Key;
                        lbl_title.TextAlign = ContentAlignment.MiddleLeft;
                        flpList.Controls.Add(lbl_title);
                        Application.DoEvents();
                        foreach (string city in p.Value)  //遍历拼音中的城市
                        {
                            Label lbl_item = new Label();
                            lbl_item.AutoSize = false;
                            lbl_item.BackColor = Color.White;
                            lbl_item.Font = new System.Drawing.Font("微软雅黑", 10);
                            lbl_item.Width = 150;
                            lbl_item.Height = 30;
                            lbl_item.TextAlign = ContentAlignment.MiddleLeft;
                            lbl_item.Text = city;
                            lbl_item.MouseEnter += new EventHandler(lbl_item_MouseEnter);
                            lbl_item.MouseLeave += new EventHandler(lbl_item_MouseLeave);
                            lbl_item.Click += new EventHandler(lbl_item_Click);
                            flpList.Controls.Add(lbl_item);
                            Application.DoEvents();
                        }
                    }
                }
            }
            //按照组织结构显示
            else if(Mode == CityListMode.Organization)
            {
                if (DataByOrganization != null)
                {
                    foreach (CityNode province in DataByOrganization.Nexts)  //遍历省份、直辖市
                    {
                        Label lbl_title = new Label();
                        lbl_title.Text = " " + province.CityName;
                        lbl_title.BackColor = Color.LightGray;
                        lbl_title.Width = 150;
                        lbl_title.AutoSize = false;
                        lbl_title.Font = new System.Drawing.Font("微软雅黑", 12, FontStyle.Bold);
                        lbl_title.Height = 30;
                        lbl_title.TextAlign = ContentAlignment.MiddleLeft;
                        flpList.Controls.Add(lbl_title);
                        Application.DoEvents();
                        foreach (CityNode city in province.Nexts)  //遍历省份中的市 直辖市中的县
                        {
                            Label lbl_item = new Label();
                            lbl_item.BackColor = Color.White;
                            lbl_item.Font = new System.Drawing.Font("微软雅黑", 10);
                            lbl_item.Width = 150;
                            lbl_item.Height = 30;
                            lbl_item.Text = city.CityName;
                            lbl_item.TextAlign = ContentAlignment.MiddleLeft;
                            lbl_item.AutoSize = false;
                            lbl_item.MouseEnter += new EventHandler(lbl_item_MouseEnter);
                            lbl_item.MouseLeave += new EventHandler(lbl_item_MouseLeave);
                            lbl_item.Click += new EventHandler(lbl_item_Click);
                            flpList.Controls.Add(lbl_item);
                            Application.DoEvents();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 鼠标选择项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lbl_item_Click(object sender, EventArgs e)
        {
            if (SelectedCityChanged != null)
            {
                SelectedCityChanged((sender as Label).Text);
            }
        }
        /// <summary>
        /// 鼠标离开选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lbl_item_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.White;
        }
        /// <summary>
        /// 鼠标进入选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lbl_item_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.FromArgb(100, Color.LightGray);
        }
    }
    /// <summary>
    /// 表示处理选择城市发生变化事件的方法
    /// </summary>
    /// <param name="cityName"></param>
    public delegate void SelectedCityChangedEventHandler(string cityName);
    /// <summary>
    /// 城市控件显示方式
    /// </summary>
    enum CityListMode
    {
        Pinyin,
        Organization
    }
    /// <summary>
    /// 城市节点
    /// </summary>
    class CityNode
    {
        public string CityName
        {
            get;
            set;
        }
        public string CityCode
        {
            get;
            set;
        }
        public string ParentCode
        {
            set;
            get;
        }
        public string CityLevel
        {
            set;
            get;
        }
        public List<CityNode> Nexts
        {
            set;
            get;
        }
        public CityNode(string cityName, string cityCode, string parentCode, string cityLevel)
        {
            CityName = cityName;
            CityCode = cityCode;
            parentCode = ParentCode;
            cityLevel = CityLevel;
        }
    }
}
