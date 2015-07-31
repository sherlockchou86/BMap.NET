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
    /// 位置输入框（带自动提示）
    /// </summary>
    public partial class BPlaceBox : UserControl
    {
        /// <summary>
        /// 当前城市
        /// </summary>
        public string CurrentCity
        {
            get;
            set;
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public BPlaceBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 建议位置
        /// </summary>
        private FlowLayoutPanel _suggestion_places = new FlowLayoutPanel();
        /// <summary>
        /// 当前可否发出API请求
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
                                lbl.Tag = (string)place["name"];
                                lbl.Text = "       " + (string)place["name"] + "   " + (string)place["city"] + "-" + (string)place["district"];   //返回JSON结构请参见百度API文档
                                _suggestion_places.Controls.Add(lbl);
                            }
                            if (_suggestion_places.Controls.Count > 0)
                            {
                                _suggestion_places.Location = new Point(Left, Top + Height);
                                _suggestion_places.Height = _suggestion_places.Controls.Count * _suggestion_places.Controls[0].Height + 10;
                                if (!Parent.Controls.Contains(_suggestion_places))
                                {
                                    Parent.Controls.Add(_suggestion_places);
                                }
                                _suggestion_places.Visible = true;
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
        /// 鼠标点击建议位置列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lbl_Click(object sender, EventArgs e)
        {
            _search = false;
            txtInput.Text = (sender as Label).Tag.ToString();
            _suggestion_places.Visible = false;
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
            Size = txtInput.Size;
        }
        /// <summary>
        /// 控件加载 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPlaceBox_Load(object sender, EventArgs e)
        {

        }
    }
}
