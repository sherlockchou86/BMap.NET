namespace BMap.NET.WinformDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bPlaceBox1 = new BMap.NET.WindowsForm.BPlaceBox();
            this.bMapControl1 = new BMap.NET.WindowsForm.BMapControl();
            this.SuspendLayout();
            // 
            // bPlaceBox1
            // 
            this.bPlaceBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bPlaceBox1.BPlacesBoard = null;
            this.bPlaceBox1.CurrentCity = null;
            this.bPlaceBox1.Enter2Search = false;
            this.bPlaceBox1.Location = new System.Drawing.Point(715, 51);
            this.bPlaceBox1.Name = "bPlaceBox1";
            this.bPlaceBox1.Size = new System.Drawing.Size(323, 33);
            this.bPlaceBox1.TabIndex = 4;
            // 
            // bMapControl1
            // 
            this.bMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bMapControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bMapControl1.BPlaceBox = this.bPlaceBox1;
            this.bMapControl1.LoadMode = BMap.NET.LoadMapMode.CacheServer;
            this.bMapControl1.Location = new System.Drawing.Point(0, 0);
            this.bMapControl1.Mode = BMap.NET.MapMode.Normal;
            this.bMapControl1.Name = "bMapControl1";
            this.bMapControl1.Size = new System.Drawing.Size(660, 632);
            this.bMapControl1.TabIndex = 0;
            this.bMapControl1.Zoom = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 633);
            this.Controls.Add(this.bPlaceBox1);
            this.Controls.Add(this.bMapControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsForm.BMapControl bMapControl1;
        private WindowsForm.BPlaceBox bPlaceBox1;
    }
}

