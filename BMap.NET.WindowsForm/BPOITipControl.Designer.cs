namespace BMap.NET.WindowsForm
{
    partial class BPOITipControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BPOITipControl));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lnkName = new System.Windows.Forms.LinkLabel();
            this.piclogo = new System.Windows.Forms.PictureBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btntransit = new System.Windows.Forms.Button();
            this.btndriving = new System.Windows.Forms.Button();
            this.lblPlace = new System.Windows.Forms.Label();
            this.txtNearby = new System.Windows.Forms.TextBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.lnknearby_hotel = new System.Windows.Forms.LinkLabel();
            this.lnknearby_eatting = new System.Windows.Forms.LinkLabel();
            this.lnknearby_bank = new System.Windows.Forms.LinkLabel();
            this.lnknearby_hospital = new System.Windows.Forms.LinkLabel();
            this.lnknearby_bus_station = new System.Windows.Forms.LinkLabel();
            this.bPlaceBox = new BMap.NET.WindowsForm.BPlaceBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(1, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 1);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(338, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 14);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lnkName
            // 
            this.lnkName.AutoSize = true;
            this.lnkName.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkName.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkName.Location = new System.Drawing.Point(5, 6);
            this.lnkName.Name = "lnkName";
            this.lnkName.Size = new System.Drawing.Size(93, 19);
            this.lnkName.TabIndex = 2;
            this.lnkName.TabStop = true;
            this.lnkName.Text = "天津城建大学";
            this.lnkName.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // piclogo
            // 
            this.piclogo.Image = ((System.Drawing.Image)(resources.GetObject("piclogo.Image")));
            this.piclogo.Location = new System.Drawing.Point(9, 41);
            this.piclogo.Name = "piclogo";
            this.piclogo.Size = new System.Drawing.Size(342, 63);
            this.piclogo.TabIndex = 5;
            this.piclogo.TabStop = false;
            this.piclogo.Paint += new System.Windows.Forms.PaintEventHandler(this.piclogo_Paint);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddress.ForeColor = System.Drawing.Color.Gray;
            this.txtAddress.Location = new System.Drawing.Point(42, 108);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(308, 16);
            this.txtAddress.TabIndex = 6;
            this.txtAddress.Text = "阿斯顿发阿斯顿发生\r\n阿斯顿发";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(7, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "地址:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(7, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "电话:";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPhone.ForeColor = System.Drawing.Color.Gray;
            this.txtPhone.Location = new System.Drawing.Point(41, 129);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(311, 16);
            this.txtPhone.TabIndex = 8;
            this.txtPhone.Text = "123";
            // 
            // txtTag
            // 
            this.txtTag.BackColor = System.Drawing.Color.White;
            this.txtTag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTag.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTag.ForeColor = System.Drawing.Color.Gray;
            this.txtTag.Location = new System.Drawing.Point(10, 152);
            this.txtTag.Name = "txtTag";
            this.txtTag.ReadOnly = true;
            this.txtTag.Size = new System.Drawing.Size(212, 16);
            this.txtTag.TabIndex = 10;
            this.txtTag.Text = "餐饮;美食";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.White;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPrice.ForeColor = System.Drawing.Color.Red;
            this.txtPrice.Location = new System.Drawing.Point(239, 152);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(112, 16);
            this.txtPrice.TabIndex = 11;
            this.txtPrice.Text = "人均 ￥23";
            // 
            // btntransit
            // 
            this.btntransit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btntransit.Location = new System.Drawing.Point(240, 216);
            this.btntransit.Name = "btntransit";
            this.btntransit.Size = new System.Drawing.Size(54, 23);
            this.btntransit.TabIndex = 13;
            this.btntransit.Text = "公交";
            this.btntransit.UseVisualStyleBackColor = true;
            this.btntransit.Click += new System.EventHandler(this.btntransit_Click);
            // 
            // btndriving
            // 
            this.btndriving.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndriving.Location = new System.Drawing.Point(299, 216);
            this.btndriving.Name = "btndriving";
            this.btndriving.Size = new System.Drawing.Size(52, 23);
            this.btndriving.TabIndex = 14;
            this.btndriving.Text = "驾车";
            this.btndriving.UseVisualStyleBackColor = true;
            this.btndriving.Click += new System.EventHandler(this.btndriving_Click);
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPlace.ForeColor = System.Drawing.Color.Gray;
            this.lblPlace.Location = new System.Drawing.Point(7, 219);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(32, 17);
            this.lblPlace.TabIndex = 15;
            this.lblPlace.Text = "起点";
            // 
            // txtNearby
            // 
            this.txtNearby.Location = new System.Drawing.Point(9, 245);
            this.txtNearby.Name = "txtNearby";
            this.txtNearby.Size = new System.Drawing.Size(100, 21);
            this.txtNearby.TabIndex = 16;
            this.txtNearby.Visible = false;
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(115, 244);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(43, 23);
            this.btnsearch.TabIndex = 17;
            this.btnsearch.Text = "搜索";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Visible = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // lnknearby_hotel
            // 
            this.lnknearby_hotel.AutoSize = true;
            this.lnknearby_hotel.Location = new System.Drawing.Point(168, 249);
            this.lnknearby_hotel.Name = "lnknearby_hotel";
            this.lnknearby_hotel.Size = new System.Drawing.Size(29, 12);
            this.lnknearby_hotel.TabIndex = 18;
            this.lnknearby_hotel.TabStop = true;
            this.lnknearby_hotel.Text = "酒店";
            this.lnknearby_hotel.Visible = false;
            this.lnknearby_hotel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // lnknearby_eatting
            // 
            this.lnknearby_eatting.AutoSize = true;
            this.lnknearby_eatting.Location = new System.Drawing.Point(203, 249);
            this.lnknearby_eatting.Name = "lnknearby_eatting";
            this.lnknearby_eatting.Size = new System.Drawing.Size(29, 12);
            this.lnknearby_eatting.TabIndex = 19;
            this.lnknearby_eatting.TabStop = true;
            this.lnknearby_eatting.Text = "餐馆";
            this.lnknearby_eatting.Visible = false;
            this.lnknearby_eatting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // lnknearby_bank
            // 
            this.lnknearby_bank.AutoSize = true;
            this.lnknearby_bank.Location = new System.Drawing.Point(238, 249);
            this.lnknearby_bank.Name = "lnknearby_bank";
            this.lnknearby_bank.Size = new System.Drawing.Size(29, 12);
            this.lnknearby_bank.TabIndex = 20;
            this.lnknearby_bank.TabStop = true;
            this.lnknearby_bank.Text = "银行";
            this.lnknearby_bank.Visible = false;
            this.lnknearby_bank.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // lnknearby_hospital
            // 
            this.lnknearby_hospital.AutoSize = true;
            this.lnknearby_hospital.Location = new System.Drawing.Point(273, 249);
            this.lnknearby_hospital.Name = "lnknearby_hospital";
            this.lnknearby_hospital.Size = new System.Drawing.Size(29, 12);
            this.lnknearby_hospital.TabIndex = 21;
            this.lnknearby_hospital.TabStop = true;
            this.lnknearby_hospital.Text = "医院";
            this.lnknearby_hospital.Visible = false;
            this.lnknearby_hospital.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // lnknearby_bus_station
            // 
            this.lnknearby_bus_station.AutoSize = true;
            this.lnknearby_bus_station.Location = new System.Drawing.Point(308, 249);
            this.lnknearby_bus_station.Name = "lnknearby_bus_station";
            this.lnknearby_bus_station.Size = new System.Drawing.Size(41, 12);
            this.lnknearby_bus_station.TabIndex = 22;
            this.lnknearby_bus_station.TabStop = true;
            this.lnknearby_bus_station.Text = "公交站";
            this.lnknearby_bus_station.Visible = false;
            this.lnknearby_bus_station.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // bPlaceBox
            // 
            this.bPlaceBox.BPlacesBoard = null;
            this.bPlaceBox.CurrentCity = "天津";
            this.bPlaceBox.Enter2Search = false;
            this.bPlaceBox.InputFont = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bPlaceBox.Location = new System.Drawing.Point(41, 217);
            this.bPlaceBox.Name = "bPlaceBox";
            this.bPlaceBox.QueryText = "";
            this.bPlaceBox.Size = new System.Drawing.Size(193, 21);
            this.bPlaceBox.TabIndex = 12;
            // 
            // BPOITipControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lnknearby_bus_station);
            this.Controls.Add(this.lnknearby_hospital);
            this.Controls.Add(this.lnknearby_bank);
            this.Controls.Add(this.lnknearby_eatting);
            this.Controls.Add(this.lnknearby_hotel);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.txtNearby);
            this.Controls.Add(this.lblPlace);
            this.Controls.Add(this.btndriving);
            this.Controls.Add(this.btntransit);
            this.Controls.Add(this.bPlaceBox);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.piclogo);
            this.Controls.Add(this.lnkName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "BPOITipControl";
            this.Size = new System.Drawing.Size(360, 291);
            this.Load += new System.EventHandler(this.BPOITipControl_Load);
            this.Click += new System.EventHandler(this.BPOITipControl_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BPOITipControl_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BPOITipControl_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lnkName;
        private System.Windows.Forms.PictureBox piclogo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.TextBox txtPrice;
        private BPlaceBox bPlaceBox;
        private System.Windows.Forms.Button btntransit;
        private System.Windows.Forms.Button btndriving;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.TextBox txtNearby;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.LinkLabel lnknearby_hotel;
        private System.Windows.Forms.LinkLabel lnknearby_eatting;
        private System.Windows.Forms.LinkLabel lnknearby_bank;
        private System.Windows.Forms.LinkLabel lnknearby_hospital;
        private System.Windows.Forms.LinkLabel lnknearby_bus_station;
    }
}
