using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using BMap.NET;
using BMap.NET.HTTPService;

namespace BMap.NET.WindowsForm
{
    /// <summary>
    /// 位置搜索输入框（带自动提示）
    /// </summary>
    public partial class BPlaceBox : UserControl
    {
        private string _city = "";
        /// <summary>
        /// 目标搜索城市
        /// </summary>
        [Browsable(false)]
        internal string City
        {
            get
            {
                return _city;
            }
        }

        private string _district = "";
        /// <summary>
        /// 目标搜索区县
        /// </summary>
        [Browsable(false)]
        internal string District
        {
            get
            {
                return _district;
            }
        }


        private Font _intputFont;
        /// <summary>
        /// 输入字体
        /// </summary>
        [Description("位置搜索时输入的字体"),Category("BMap.NET")]
        public Font InputFont
        {
            get
            {
                return txtInput.Font;
            }
            set
            {
                _intputFont = value;
                txtInput.Font = _intputFont;
            }
        }
        /// <summary>
        /// 当前建议搜索城市
        /// </summary>
        [Description("当前建议搜索城市"), Category("BMap.NET")]
        public string CurrentCity
        {
            get;
            set;
        }
        /// <summary>
        /// 回车键是否发起搜索
        /// </summary>
        [Description("指示回车键是否发起搜索"), Category("BMap.NET")]
        public bool Enter2Search
        {
            get;
            set;
        }
        /// <summary>
        /// 与之关联的位置列表控件
        /// </summary>
        [Description("与之关联的位置列表控件，该控件负责显示搜索得到的结果"), Category("BMap.NET")]
        public BPlacesBoard BPlacesBoard
        {
            get;
            set;
        }
        /// <summary>
        /// 输入搜索内容
        /// </summary>
        [Description("搜索输入框中的内容"),Category("BMap.NET")]
        public string QueryText
        {
            get
            {
                return txtInput.Text;
            }
            set
            {
                txtInput.Text = value;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public BPlaceBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 开始发起搜索
        /// </summary>
        public void StartSearch()
        {
            if (txtInput.Text != "")
            {
                ((Action)delegate()
                {
                    PlaceService ps = new PlaceService();
                    JObject places = ps.SearchInCity(_district +  txtInput.Text, _city == "" ? CurrentCity : _city);
                    if (places != null)
                    {
                        this.Invoke((Action)delegate()
                        {
                            if (BPlacesBoard != null)  //通知与之关联的位置列表控件
                            {
                                BPlacesBoard.AddPlaces(places["results"]);
                            }
                        });
                    }
                }).BeginInvoke(null, null);
            }
        }
        /// <summary>
        /// 设置下一次输入内容变化时 不显示位置建议下拉框
        /// </summary>
        public void DontSearchNextTime()
        {
            _search = false;
        }

        /// <summary>
        /// 建议位置
        /// </summary>
        private FlowLayoutPanel _suggestion_places = new FlowLayoutPanel();
        /// <summary>
        /// 当前可否发出位置建议请求
        /// </summary>
        private bool _search = true;
        /// <summary>
        /// 输入框发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (txtInput.Text != "")
            {
                if (!_search)
                {
                    _search = true;
                    return;
                }
                _district = ""; _city = "";
                ((Action)(delegate()  //异步调用API  获取建议位置
                {
                    PlaceSuggestionService pss = new PlaceSuggestionService();
                    JObject suggestion_places = pss.Suggestion(txtInput.Text, CurrentCity);  //建议位置
                    if (suggestion_places != null)
                    {
                        this.Invoke((Action)delegate()
                        {
                            _suggestion_places.Controls.Clear();
                            _suggestion_places.Padding = new System.Windows.Forms.Padding(3);
                            _suggestion_places.Width = Width;
                            _suggestion_places.BackColor = Color.White;
                            _suggestion_places.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            foreach (JObject place in suggestion_places["result"])  //返回JSON结构请参见百度API文档
                            {
                                Label lbl = new Label();
                                lbl.MouseEnter += new EventHandler(lbl_MouseEnter);
                                lbl.MouseLeave += new EventHandler(lbl_MouseLeave);
                                lbl.Click += new EventHandler(lbl_Click);
                                lbl.BackColor = Color.White;
                                lbl.AutoSize = false;
                                lbl.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
                                lbl.Font = new System.Drawing.Font("微软雅黑", 9);
                                lbl.Width = _suggestion_places.Width - 15;
                                lbl.Height = 30;
                                lbl.TextAlign = ContentAlignment.MiddleLeft;
                                lbl.Image = Properties.BMap.ico_search;
                                lbl.ImageAlign = ContentAlignment.MiddleLeft;
                                lbl.Tag = (string)place["name"] + "|" + (string)place["district"] + "|" + (string)place["city"];
                                lbl.Text = "       " + (string)place["name"] + "   " + (string)place["city"] + "-" + (string)place["district"];   //返回JSON结构请参见百度API文档
                                _suggestion_places.Controls.Add(lbl);
                            }
                            if (_suggestion_places.Controls.Count > 0)
                            {
                                Control top = FindTheTopControl();
                                if (top != null)
                                {
                                    Point p = new Point(txtInput.Left - 1, txtInput.Top + txtInput.Height);  //文本框在BPlaceBox中的位置
                                    Point location = top.PointToClient(PointToScreen(p));   //文本框位置转换为最顶层控件坐标系中对应位置
                                    _suggestion_places.Location = location;
                                    _suggestion_places.Height = _suggestion_places.Controls.Count * _suggestion_places.Controls[0].Height + 10;
                                    if (!top.Controls.Contains(_suggestion_places))
                                    {
                                        top.Controls.Add(_suggestion_places);
                                    }
                                    _suggestion_places.Visible = true;
                                    _suggestion_places.BringToFront();
                                }
                            }
                            else
                            {
                                _suggestion_places.Visible = false;
                            }
                        });
                    }
                })).BeginInvoke(null, null);
            }
            else
            {
                _suggestion_places.Visible = false;
            }
        }
        /// <summary>
        /// 遍历获得顶层控件
        /// </summary>
        /// <returns></returns>
        private Control FindTheTopControl()
        {
            Control top = this.Parent;
            while (top.Parent != null)
            {
                top = top.Parent;
            }
            return top;
        }
        /// <summary>
        /// 鼠标点击建议位置列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lbl_Click(object sender, EventArgs e)
        {
            _search = false;
            txtInput.Text = (sender as Label).Tag.ToString().Split('|')[0];  //选择位置
            _district = (sender as Label).Tag.ToString().Split('|')[1];  //所在区
            _city = (sender as Label).Tag.ToString().Split('|')[2];  //所在城市
            _suggestion_places.Visible = false;

            if (Enter2Search)
                StartSearch();
        }
        /// <summary>
        /// 鼠标离开建议位置列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lbl_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.White;
        }
        /// <summary>
        /// 鼠标进入建议位置列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lbl_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.FromArgb(100, Color.LightGray);
        }
        /// <summary>
        /// 输入框大小改变 父控件大小保持相同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInput_Resize(object sender, EventArgs e)
        {
            Size = new Size(txtInput.Width + 2, txtInput.Height + 2);
            txtInput.Location = new Point(1, 1);
        }
        /// <summary>
        /// 控件加载 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPlaceBox_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 回车键 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Enter2Search)
            {
                _suggestion_places.Visible = false;
                StartSearch();
            }
        }
        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPlaceBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.LightGray, new Rectangle(0, 0, Width - 1, Height - 1));
        }
        /// <summary>
        /// 失去焦点 隐藏建议下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInput_Leave(object sender, EventArgs e)
        {
            _suggestion_places.Visible = false;
        }
    }
}
