using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMap.NET.WindowsForm.FunctionalControls;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// 城市切换控件
    /// </summary>
    partial class BCityControl : UserControl
    {
        public event SelectedCityChangedEventHandler SelectedCityChanged;
        private string _currentCity = "";
        /// <summary>
        /// 当前城市
        /// </summary>
        public string CurrentCity
        {
            get
            {
                return _currentCity;
            }
            set
            {
                _currentCity = value;
                lbl_current_city.Text = "当前城市：" + _currentCity;
            }
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public BCityControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 控件加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCityControl_Load(object sender, EventArgs e)
        {
            LoadCities();
            Init();
        }
        /// <summary>
        /// 初始化城市列表
        /// </summary>
        private void LoadCities()
        {
            Dictionary<string, List<string>> data_pinyin = new Dictionary<string, List<string>>();  //拼音数据源
            CityNode root = new CityNode("中国", "1", null, "0");  //组织结构数据源

            ((Action)delegate()
            {
                string areas = Properties.BMap.baidu_citys;
                string[] cities = areas.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                foreach (string city in cities)
                {
                    string[] items = city.Split('|');
                    if (items.Length == 4)
                    {
                        if (items[3] != "0" && items[3] != "1")  //忽略国家 省份
                        {
                            string pinyin = GetSpellCodeAt(items[0][0].ToString());  //首汉字拼音
                            if (!data_pinyin.ContainsKey(pinyin))
                            {
                                data_pinyin.Add(pinyin, new List<string> { items[0] });
                            }
                            data_pinyin[pinyin].Add(items[0]);
                        }
                        if (items[3] != "0")  //忽略国家
                        {
                            if (items[2] == root.CityCode)  //省份、直辖市
                            {
                                if (root.Nexts == null)
                                {
                                    root.Nexts = new List<CityNode>();
                                }
                                root.Nexts.Add(new CityNode(items[0], items[1], items[2], items[3]));
                            }
                            else  //地级市 直辖市中的县区
                            {
                                foreach (CityNode province in root.Nexts)
                                {
                                    if (province.CityCode == items[2])
                                    {
                                        if (province.Nexts == null)
                                        {
                                            province.Nexts = new List<CityNode>();
                                        }
                                        province.Nexts.Add(new CityNode(items[0], items[1], items[2], items[3]));
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                this.Invoke((Action)delegate()
                {
                    cityList1.DataByOrganization = root;
                    cityList1.DataByPinyin = data_pinyin;
                    cityList1.Mode = CityListMode.Pinyin;
                    cityList1.RefreshList();
                });
            }).BeginInvoke(null, null);
        }
        /// <summary>
        /// 获取汉字拼音开头字母
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string GetSpellCodeAt(string s)
        {
            long iCnChar;

            byte[] ZW = System.Text.Encoding.Default.GetBytes(s);
            if (ZW.Length == 1)
            {
                return s.ToUpper();
            }

            int i1 = (short)ZW[0];
            int i2 = (short)ZW[1];
            iCnChar = i1 * 256 + i2;

            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {
                return "A";
            }
            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {
                return "B";
            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {
                return "C";
            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {
                return "D";
            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {
                return "E";
            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {
                return "F";
            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {
                return "G";
            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {
                return "H";
            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {
                return "J";
            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {
                return "K";
            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {
                return "L";
            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {
                return "M";
            }

            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {
                return "N";
            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {
                return "O";
            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {
                return "P";
            }
            else if ((iCnChar >= 50906) && (iCnChar <= 51386))
            {
                return "Q";
            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {
                return "R";
            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {
                return "S";
            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {
                return "T";
            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {
                return "W";
            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
            {
                return "X";
            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {
                return "Y";
            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {
                return "Z";
            }
            else return ("?");
        }
        /// <summary>
        /// 初始化工作
        /// </summary>
        private void Init()
        {
            string[] hot_cities = new string[] { "北京", "天津", "上海", "重庆", "广州", "武汉", "成都", "南京", "深圳", "合肥", "厦门" };
            foreach (string city in hot_cities)
            {
                LinkLabel lkb = new LinkLabel();
                lkb.Text = city;
                lkb.AutoSize = true;
                lkb.VisitedLinkColor = Color.Blue;
                lkb.Click += new EventHandler(lkb_Click);
                flp_hot_cities.Controls.Add(lkb);
            }
        }
        /// <summary>
        /// 点击热门城市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lkb_Click(object sender, EventArgs e)
        {
            CurrentCity = (sender as LinkLabel).Text;
            if (SelectedCityChanged != null)
            {
                SelectedCityChanged((sender as LinkLabel).Text);
            }
        }
        /// <summary>
        /// 排列方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_by_pinyin.Checked)
            {
                cityList1.Mode = CityListMode.Pinyin;
            }
            else
            {
                cityList1.Mode = CityListMode.Organization;
            }
            rdo_by_pinyin.Enabled = false;
            rdo_by_province.Enabled = false;
            cityList1.RefreshList();
            rdo_by_province.Enabled = true;
            rdo_by_pinyin.Enabled = true;
        }
        /// <summary>
        /// 选择城市变化
        /// </summary>
        /// <param name="cityName"></param>
        private void cityList1_SelectedCityChanged(string cityName)
        {
            CurrentCity = cityName;
            if (SelectedCityChanged != null)
            {
                SelectedCityChanged(cityName);
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pic_close_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
