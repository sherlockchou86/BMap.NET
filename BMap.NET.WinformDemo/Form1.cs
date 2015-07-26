using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMap.NET;
using BMap.NET.HTTPService;
using Newtonsoft.Json.Linq;

namespace BMap.NET.WinformDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DirectionService ds = new DirectionService();
            JObject o = ds.DirectionByTransit("天津城建大学", "海光寺", "天津");
        }
    }
}
