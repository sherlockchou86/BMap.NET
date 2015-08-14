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
            this.bTabControl1 = new BMap.NET.WindowsForm.FunctionalControls.BTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bPlacesBoard1 = new BMap.NET.WindowsForm.BPlacesBoard();
            this.bDirectionBoard1 = new BMap.NET.WindowsForm.BDirectionBoard();
            this.bMapControl1 = new BMap.NET.WindowsForm.BMapControl();
            this.bPlaceBox1 = new BMap.NET.WindowsForm.BPlaceBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bTabControl1
            // 
            this.bTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.bTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bTabControl1.Controls.Add(this.tabPage1);
            this.bTabControl1.Controls.Add(this.tabPage2);
            this.bTabControl1.ItemSize = new System.Drawing.Size(70, 70);
            this.bTabControl1.Location = new System.Drawing.Point(-1, 69);
            this.bTabControl1.Multiline = true;
            this.bTabControl1.Name = "bTabControl1";
            this.bTabControl1.SelectedIndex = 0;
            this.bTabControl1.Size = new System.Drawing.Size(389, 564);
            this.bTabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bPlacesBoard1);
            this.tabPage1.Location = new System.Drawing.Point(74, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(311, 556);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "搜索";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bPlacesBoard1
            // 
            this.bPlacesBoard1.BDirectionBoard = this.bDirectionBoard1;
            this.bPlacesBoard1.BMapControl = this.bMapControl1;
            this.bPlacesBoard1.CurrentCity = null;
            this.bPlacesBoard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bPlacesBoard1.Location = new System.Drawing.Point(3, 3);
            this.bPlacesBoard1.Name = "bPlacesBoard1";
            this.bPlacesBoard1.Size = new System.Drawing.Size(305, 550);
            this.bPlacesBoard1.TabIndex = 5;
            // 
            // bDirectionBoard1
            // 
            this.bDirectionBoard1.BackColor = System.Drawing.Color.White;
            this.bDirectionBoard1.BMapControl = this.bMapControl1;
            this.bDirectionBoard1.BPlacesBoard = this.bPlacesBoard1;
            this.bDirectionBoard1.CurrentCity = null;
            this.bDirectionBoard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bDirectionBoard1.Location = new System.Drawing.Point(3, 3);
            this.bDirectionBoard1.Name = "bDirectionBoard1";
            this.bDirectionBoard1.Size = new System.Drawing.Size(305, 550);
            this.bDirectionBoard1.TabIndex = 0;
            // 
            // bMapControl1
            // 
            this.bMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bMapControl1.BDirectionBoard = this.bDirectionBoard1;
            this.bMapControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bMapControl1.BPlaceBox = this.bPlaceBox1;
            this.bMapControl1.BPlacesBoard = this.bPlacesBoard1;
            this.bMapControl1.LoadMode = BMap.NET.LoadMapMode.CacheServer;
            this.bMapControl1.Location = new System.Drawing.Point(387, 70);
            this.bMapControl1.Mode = BMap.NET.MapMode.Normal;
            this.bMapControl1.Name = "bMapControl1";
            this.bMapControl1.Size = new System.Drawing.Size(742, 563);
            this.bMapControl1.TabIndex = 0;
            this.bMapControl1.Zoom = 12;
            // 
            // bPlaceBox1
            // 
            this.bPlaceBox1.BPlacesBoard = this.bPlacesBoard1;
            this.bPlaceBox1.CurrentCity = null;
            this.bPlaceBox1.Enter2Search = true;
            this.bPlaceBox1.InputFont = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bPlaceBox1.Location = new System.Drawing.Point(74, 12);
            this.bPlaceBox1.Name = "bPlaceBox1";
            this.bPlaceBox1.QueryText = "停车场";
            this.bPlaceBox1.Size = new System.Drawing.Size(307, 28);
            this.bPlaceBox1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bDirectionBoard1);
            this.tabPage2.Location = new System.Drawing.Point(74, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(311, 556);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "路线";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 633);
            this.Controls.Add(this.bTabControl1);
            this.Controls.Add(this.bPlaceBox1);
            this.Controls.Add(this.bMapControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.bTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsForm.BMapControl bMapControl1;
        private WindowsForm.BPlaceBox bPlaceBox1;
        private WindowsForm.BPlacesBoard bPlacesBoard1;
        private WindowsForm.FunctionalControls.BTabControl bTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private WindowsForm.BDirectionBoard bDirectionBoard1;
    }
}

