namespace BMap.NET.WindowsForm
{
    partial class BCityControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCityControl));
            this.lbl_current_city = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flp_hot_cities = new System.Windows.Forms.FlowLayoutPanel();
            this.rdo_by_province = new System.Windows.Forms.RadioButton();
            this.rdo_by_pinyin = new System.Windows.Forms.RadioButton();
            this.cityList1 = new BMap.NET.WindowsForm.FunctionalControls.CityList();
            this.pic_close = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_close)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_current_city
            // 
            this.lbl_current_city.AutoSize = true;
            this.lbl_current_city.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_current_city.Location = new System.Drawing.Point(7, 17);
            this.lbl_current_city.Name = "lbl_current_city";
            this.lbl_current_city.Size = new System.Drawing.Size(59, 17);
            this.lbl_current_city.TabIndex = 1;
            this.lbl_current_city.Text = "当前城市:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(11, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 1);
            this.label2.TabIndex = 2;
            // 
            // flp_hot_cities
            // 
            this.flp_hot_cities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flp_hot_cities.Location = new System.Drawing.Point(11, 48);
            this.flp_hot_cities.Name = "flp_hot_cities";
            this.flp_hot_cities.Size = new System.Drawing.Size(244, 36);
            this.flp_hot_cities.TabIndex = 3;
            // 
            // rdo_by_province
            // 
            this.rdo_by_province.AutoSize = true;
            this.rdo_by_province.Checked = true;
            this.rdo_by_province.Location = new System.Drawing.Point(11, 96);
            this.rdo_by_province.Name = "rdo_by_province";
            this.rdo_by_province.Size = new System.Drawing.Size(59, 16);
            this.rdo_by_province.TabIndex = 4;
            this.rdo_by_province.TabStop = true;
            this.rdo_by_province.Text = "按省份";
            this.rdo_by_province.UseVisualStyleBackColor = true;
            this.rdo_by_province.Click += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdo_by_pinyin
            // 
            this.rdo_by_pinyin.AutoSize = true;
            this.rdo_by_pinyin.Location = new System.Drawing.Point(76, 96);
            this.rdo_by_pinyin.Name = "rdo_by_pinyin";
            this.rdo_by_pinyin.Size = new System.Drawing.Size(59, 16);
            this.rdo_by_pinyin.TabIndex = 5;
            this.rdo_by_pinyin.Text = "按拼音";
            this.rdo_by_pinyin.UseVisualStyleBackColor = true;
            this.rdo_by_pinyin.Click += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // cityList1
            // 
            this.cityList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cityList1.DataByOrganization = null;
            this.cityList1.DataByPinyin = null;
            this.cityList1.Location = new System.Drawing.Point(13, 118);
            this.cityList1.Mode = BMap.NET.WindowsForm.FunctionalControls.CityListMode.Pinyin;
            this.cityList1.Name = "cityList1";
            this.cityList1.Size = new System.Drawing.Size(242, 271);
            this.cityList1.TabIndex = 0;
            this.cityList1.SelectedCityChanged += new BMap.NET.WindowsForm.FunctionalControls.SelectedCityChangedEventHandler(this.cityList1_SelectedCityChanged);
            // 
            // pic_close
            // 
            this.pic_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_close.Image = ((System.Drawing.Image)(resources.GetObject("pic_close.Image")));
            this.pic_close.Location = new System.Drawing.Point(244, 9);
            this.pic_close.Name = "pic_close";
            this.pic_close.Size = new System.Drawing.Size(13, 14);
            this.pic_close.TabIndex = 6;
            this.pic_close.TabStop = false;
            this.pic_close.Click += new System.EventHandler(this.pic_close_Click);
            // 
            // BCityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pic_close);
            this.Controls.Add(this.rdo_by_pinyin);
            this.Controls.Add(this.rdo_by_province);
            this.Controls.Add(this.flp_hot_cities);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_current_city);
            this.Controls.Add(this.cityList1);
            this.Name = "BCityControl";
            this.Size = new System.Drawing.Size(264, 396);
            this.Load += new System.EventHandler(this.BCityControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FunctionalControls.CityList cityList1;
        private System.Windows.Forms.Label lbl_current_city;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flp_hot_cities;
        private System.Windows.Forms.RadioButton rdo_by_province;
        private System.Windows.Forms.RadioButton rdo_by_pinyin;
        private System.Windows.Forms.PictureBox pic_close;
    }
}
