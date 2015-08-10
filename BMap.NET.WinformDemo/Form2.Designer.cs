namespace BMap.NET.WinformDemo
{
    partial class Form2
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
            this.bMarkerTipControl1 = new BMap.NET.WindowsForm.BMarkerTipControl();
            this.bPlaceBox1 = new BMap.NET.WindowsForm.BPlaceBox();
            this.bTabControl1 = new BMap.NET.WindowsForm.FunctionalControls.BTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bPlacesBoard1 = new BMap.NET.WindowsForm.BPlacesBoard();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bDirectionBoard1 = new BMap.NET.WindowsForm.BDirectionBoard();
            this.bpoiTipControl1 = new BMap.NET.WindowsForm.BPOITipControl();
            this.bTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bMarkerTipControl1
            // 
            this.bMarkerTipControl1.BackColor = System.Drawing.Color.White;
            this.bMarkerTipControl1.Location = new System.Drawing.Point(391, 16);
            this.bMarkerTipControl1.Name = "bMarkerTipControl1";
            this.bMarkerTipControl1.Size = new System.Drawing.Size(360, 235);
            this.bMarkerTipControl1.TabIndex = 5;
            // 
            // bPlaceBox1
            // 
            this.bPlaceBox1.BPlacesBoard = null;
            this.bPlaceBox1.CurrentCity = "天津";
            this.bPlaceBox1.Enter2Search = false;
            this.bPlaceBox1.InputFont = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bPlaceBox1.Location = new System.Drawing.Point(475, 353);
            this.bPlaceBox1.Name = "bPlaceBox1";
            this.bPlaceBox1.QueryText = "停车场";
            this.bPlaceBox1.Size = new System.Drawing.Size(326, 28);
            this.bPlaceBox1.TabIndex = 4;
            // 
            // bTabControl1
            // 
            this.bTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.bTabControl1.Controls.Add(this.tabPage1);
            this.bTabControl1.Controls.Add(this.tabPage2);
            this.bTabControl1.ItemSize = new System.Drawing.Size(70, 70);
            this.bTabControl1.Location = new System.Drawing.Point(12, 12);
            this.bTabControl1.Multiline = true;
            this.bTabControl1.Name = "bTabControl1";
            this.bTabControl1.SelectedIndex = 0;
            this.bTabControl1.Size = new System.Drawing.Size(359, 530);
            this.bTabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bPlacesBoard1);
            this.tabPage1.Location = new System.Drawing.Point(74, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(281, 522);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bPlacesBoard1
            // 
            this.bPlacesBoard1.BDirectionBoard = null;
            this.bPlacesBoard1.BMapControl = null;
            this.bPlacesBoard1.CurrentCity = null;
            this.bPlacesBoard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bPlacesBoard1.Location = new System.Drawing.Point(3, 3);
            this.bPlacesBoard1.Name = "bPlacesBoard1";
            this.bPlacesBoard1.Size = new System.Drawing.Size(275, 516);
            this.bPlacesBoard1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bDirectionBoard1);
            this.tabPage2.Location = new System.Drawing.Point(74, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(281, 522);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bDirectionBoard1
            // 
            this.bDirectionBoard1.BackColor = System.Drawing.Color.White;
            this.bDirectionBoard1.CurrentCity = "天津";
            this.bDirectionBoard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bDirectionBoard1.Location = new System.Drawing.Point(3, 3);
            this.bDirectionBoard1.Name = "bDirectionBoard1";
            this.bDirectionBoard1.Size = new System.Drawing.Size(275, 516);
            this.bDirectionBoard1.TabIndex = 0;
            // 
            // bpoiTipControl1
            // 
            this.bpoiTipControl1.BackColor = System.Drawing.Color.White;
            this.bpoiTipControl1.Location = new System.Drawing.Point(529, 228);
            this.bpoiTipControl1.Name = "bpoiTipControl1";
            this.bpoiTipControl1.Size = new System.Drawing.Size(360, 284);
            this.bpoiTipControl1.TabIndex = 6;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 732);
            this.Controls.Add(this.bpoiTipControl1);
            this.Controls.Add(this.bMarkerTipControl1);
            this.Controls.Add(this.bPlaceBox1);
            this.Controls.Add(this.bTabControl1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.bTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsForm.BDirectionBoard bDirectionBoard1;
        private WindowsForm.BPlacesBoard bPlacesBoard1;
        private WindowsForm.FunctionalControls.BTabControl bTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private WindowsForm.BPlaceBox bPlaceBox1;
        private WindowsForm.BMarkerTipControl bMarkerTipControl1;
        private WindowsForm.BPOITipControl bpoiTipControl1;
    }
}