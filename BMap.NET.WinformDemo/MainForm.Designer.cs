namespace BMap.NET.WinformDemo
{
    partial class MainForm
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bMapControl1 = new BMap.NET.WindowsForm.BMapControl();
            this.bPlacesBoard1 = new BMap.NET.WindowsForm.BPlacesBoard();
            this.bDirectionBoard1 = new BMap.NET.WindowsForm.BDirectionBoard();
            this.bPlaceBox1 = new BMap.NET.WindowsForm.BPlaceBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.bTabControl1.Location = new System.Drawing.Point(0, 82);
            this.bTabControl1.Multiline = true;
            this.bTabControl1.Name = "bTabControl1";
            this.bTabControl1.SelectedIndex = 0;
            this.bTabControl1.Size = new System.Drawing.Size(389, 601);
            this.bTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bPlacesBoard1);
            this.tabPage1.Location = new System.Drawing.Point(74, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(311, 593);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "搜索";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bDirectionBoard1);
            this.tabPage2.Location = new System.Drawing.Point(74, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(311, 593);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "路线";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.bMapControl1.Location = new System.Drawing.Point(388, 83);
            this.bMapControl1.Mode = BMap.NET.MapMode.Normal;
            this.bMapControl1.Name = "bMapControl1";
            this.bMapControl1.Size = new System.Drawing.Size(632, 599);
            this.bMapControl1.TabIndex = 1;
            this.bMapControl1.Zoom = 12;
            // 
            // bPlacesBoard1
            // 
            this.bPlacesBoard1.BDirectionBoard = this.bDirectionBoard1;
            this.bPlacesBoard1.BMapControl = this.bMapControl1;
            this.bPlacesBoard1.CurrentCity = null;
            this.bPlacesBoard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bPlacesBoard1.Location = new System.Drawing.Point(3, 3);
            this.bPlacesBoard1.Name = "bPlacesBoard1";
            this.bPlacesBoard1.Size = new System.Drawing.Size(305, 587);
            this.bPlacesBoard1.TabIndex = 0;
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
            this.bDirectionBoard1.Size = new System.Drawing.Size(305, 587);
            this.bDirectionBoard1.TabIndex = 0;
            // 
            // bPlaceBox1
            // 
            this.bPlaceBox1.BPlacesBoard = this.bPlacesBoard1;
            this.bPlaceBox1.CurrentCity = null;
            this.bPlaceBox1.Enter2Search = true;
            this.bPlaceBox1.InputFont = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bPlaceBox1.Location = new System.Drawing.Point(12, 26);
            this.bPlaceBox1.Name = "bPlaceBox1";
            this.bPlaceBox1.QueryText = "";
            this.bPlaceBox1.Size = new System.Drawing.Size(318, 28);
            this.bPlaceBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(336, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 683);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bPlaceBox1);
            this.Controls.Add(this.bMapControl1);
            this.Controls.Add(this.bTabControl1);
            this.Name = "MainForm";
            this.Text = "BMap.NET Demo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.bTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsForm.FunctionalControls.BTabControl bTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private WindowsForm.BPlacesBoard bPlacesBoard1;
        private System.Windows.Forms.TabPage tabPage2;
        private WindowsForm.BDirectionBoard bDirectionBoard1;
        private WindowsForm.BMapControl bMapControl1;
        private WindowsForm.BPlaceBox bPlaceBox1;
        private System.Windows.Forms.Button button1;
    }
}