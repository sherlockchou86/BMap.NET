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

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                bMapControl1.Mode = MapMode.Normal;
            }
            if (radioButton2.Checked)
            {
                bMapControl1.Mode = MapMode.Satellite;
            }
            if (radioButton3.Checked)
            {
                bMapControl1.Mode = MapMode.Sate_RoadNet;
            }
        }
    }
}
