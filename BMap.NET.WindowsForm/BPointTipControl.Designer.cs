namespace BMap.NET.WindowsForm
{
    partial class BPointTipControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BPointTipControl));
            this.picClose = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lnknearby_bus_station = new System.Windows.Forms.LinkLabel();
            this.lnknearby_hospital = new System.Windows.Forms.LinkLabel();
            this.lnknearby_bank = new System.Windows.Forms.LinkLabel();
            this.lnknearby_eatting = new System.Windows.Forms.LinkLabel();
            this.lnknearby_hotel = new System.Windows.Forms.LinkLabel();
            this.btnsearch = new System.Windows.Forms.Button();
            this.txtNearby = new System.Windows.Forms.TextBox();
            this.lblPlace = new System.Windows.Forms.Label();
            this.btndriving = new System.Windows.Forms.Button();
            this.btntransit = new System.Windows.Forms.Button();
            this.bPlaceBox = new BMap.NET.WindowsForm.BPlaceBox();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
            this.picClose.Location = new System.Drawing.Point(334, 9);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(13, 14);
            this.picClose.TabIndex = 7;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(8, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(79, 19);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "位置点位置";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(1, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 1);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // lnknearby_bus_station
            // 
            this.lnknearby_bus_station.AutoSize = true;
            this.lnknearby_bus_station.Location = new System.Drawing.Point(309, 108);
            this.lnknearby_bus_station.Name = "lnknearby_bus_station";
            this.lnknearby_bus_station.Size = new System.Drawing.Size(41, 12);
            this.lnknearby_bus_station.TabIndex = 44;
            this.lnknearby_bus_station.TabStop = true;
            this.lnknearby_bus_station.Text = "公交站";
            this.lnknearby_bus_station.Visible = false;
            this.lnknearby_bus_station.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // lnknearby_hospital
            // 
            this.lnknearby_hospital.AutoSize = true;
            this.lnknearby_hospital.Location = new System.Drawing.Point(274, 108);
            this.lnknearby_hospital.Name = "lnknearby_hospital";
            this.lnknearby_hospital.Size = new System.Drawing.Size(29, 12);
            this.lnknearby_hospital.TabIndex = 43;
            this.lnknearby_hospital.TabStop = true;
            this.lnknearby_hospital.Text = "医院";
            this.lnknearby_hospital.Visible = false;
            this.lnknearby_hospital.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // lnknearby_bank
            // 
            this.lnknearby_bank.AutoSize = true;
            this.lnknearby_bank.Location = new System.Drawing.Point(239, 108);
            this.lnknearby_bank.Name = "lnknearby_bank";
            this.lnknearby_bank.Size = new System.Drawing.Size(29, 12);
            this.lnknearby_bank.TabIndex = 42;
            this.lnknearby_bank.TabStop = true;
            this.lnknearby_bank.Text = "银行";
            this.lnknearby_bank.Visible = false;
            this.lnknearby_bank.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // lnknearby_eatting
            // 
            this.lnknearby_eatting.AutoSize = true;
            this.lnknearby_eatting.Location = new System.Drawing.Point(204, 108);
            this.lnknearby_eatting.Name = "lnknearby_eatting";
            this.lnknearby_eatting.Size = new System.Drawing.Size(29, 12);
            this.lnknearby_eatting.TabIndex = 41;
            this.lnknearby_eatting.TabStop = true;
            this.lnknearby_eatting.Text = "餐馆";
            this.lnknearby_eatting.Visible = false;
            this.lnknearby_eatting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // lnknearby_hotel
            // 
            this.lnknearby_hotel.AutoSize = true;
            this.lnknearby_hotel.Location = new System.Drawing.Point(169, 108);
            this.lnknearby_hotel.Name = "lnknearby_hotel";
            this.lnknearby_hotel.Size = new System.Drawing.Size(29, 12);
            this.lnknearby_hotel.TabIndex = 40;
            this.lnknearby_hotel.TabStop = true;
            this.lnknearby_hotel.Text = "酒店";
            this.lnknearby_hotel.Visible = false;
            this.lnknearby_hotel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(116, 103);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(43, 23);
            this.btnsearch.TabIndex = 39;
            this.btnsearch.Text = "搜索";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Visible = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // txtNearby
            // 
            this.txtNearby.Location = new System.Drawing.Point(10, 104);
            this.txtNearby.Name = "txtNearby";
            this.txtNearby.Size = new System.Drawing.Size(100, 21);
            this.txtNearby.TabIndex = 38;
            this.txtNearby.Visible = false;
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPlace.ForeColor = System.Drawing.Color.Gray;
            this.lblPlace.Location = new System.Drawing.Point(8, 78);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(32, 17);
            this.lblPlace.TabIndex = 37;
            this.lblPlace.Text = "起点";
            // 
            // btndriving
            // 
            this.btndriving.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndriving.Location = new System.Drawing.Point(300, 75);
            this.btndriving.Name = "btndriving";
            this.btndriving.Size = new System.Drawing.Size(52, 23);
            this.btndriving.TabIndex = 36;
            this.btndriving.Text = "驾车";
            this.btndriving.UseVisualStyleBackColor = true;
            this.btndriving.Click += new System.EventHandler(this.btndriving_Click);
            // 
            // btntransit
            // 
            this.btntransit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btntransit.Location = new System.Drawing.Point(241, 75);
            this.btntransit.Name = "btntransit";
            this.btntransit.Size = new System.Drawing.Size(54, 23);
            this.btntransit.TabIndex = 35;
            this.btntransit.Text = "公交";
            this.btntransit.UseVisualStyleBackColor = true;
            this.btntransit.Click += new System.EventHandler(this.btntransit_Click);
            // 
            // bPlaceBox
            // 
            this.bPlaceBox.BPlacesBoard = null;
            this.bPlaceBox.CurrentCity = "天津";
            this.bPlaceBox.Enter2Search = false;
            this.bPlaceBox.InputFont = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bPlaceBox.Location = new System.Drawing.Point(42, 76);
            this.bPlaceBox.Name = "bPlaceBox";
            this.bPlaceBox.QueryText = "";
            this.bPlaceBox.Size = new System.Drawing.Size(193, 21);
            this.bPlaceBox.TabIndex = 34;
            // 
            // BPointTipControl
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
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Name = "BPointTipControl";
            this.Size = new System.Drawing.Size(360, 152);
            this.Load += new System.EventHandler(this.BPointTipControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BPointTipControl_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BPointTipControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BPointTipControl_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnknearby_bus_station;
        private System.Windows.Forms.LinkLabel lnknearby_hospital;
        private System.Windows.Forms.LinkLabel lnknearby_bank;
        private System.Windows.Forms.LinkLabel lnknearby_eatting;
        private System.Windows.Forms.LinkLabel lnknearby_hotel;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.TextBox txtNearby;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.Button btndriving;
        private System.Windows.Forms.Button btntransit;
        private BPlaceBox bPlaceBox;
    }
}
