namespace BMap.NET.WindowsForm
{
    partial class BMarkerTipControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BMarkerTipControl));
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picEdit = new System.Windows.Forms.PictureBox();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(1, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 1);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(8, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(79, 19);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "添加标记点";
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
            this.picClose.Location = new System.Drawing.Point(334, 9);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(13, 14);
            this.picClose.TabIndex = 4;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picEdit
            // 
            this.picEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEdit.Image = ((System.Drawing.Image)(resources.GetObject("picEdit.Image")));
            this.picEdit.Location = new System.Drawing.Point(290, 9);
            this.picEdit.Name = "picEdit";
            this.picEdit.Size = new System.Drawing.Size(14, 14);
            this.picEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEdit.TabIndex = 5;
            this.picEdit.TabStop = false;
            this.picEdit.Click += new System.EventHandler(this.picEdit_Click);
            // 
            // picDelete
            // 
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = ((System.Drawing.Image)(resources.GetObject("picDelete.Image")));
            this.picDelete.Location = new System.Drawing.Point(306, 9);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(14, 14);
            this.picDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDelete.TabIndex = 6;
            this.picDelete.TabStop = false;
            this.picDelete.Click += new System.EventHandler(this.picDelete_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemarks.Location = new System.Drawing.Point(12, 47);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ReadOnly = true;
            this.txtRemarks.Size = new System.Drawing.Size(324, 65);
            this.txtRemarks.TabIndex = 7;
            // 
            // lnknearby_bus_station
            // 
            this.lnknearby_bus_station.AutoSize = true;
            this.lnknearby_bus_station.Location = new System.Drawing.Point(309, 186);
            this.lnknearby_bus_station.Name = "lnknearby_bus_station";
            this.lnknearby_bus_station.Size = new System.Drawing.Size(41, 12);
            this.lnknearby_bus_station.TabIndex = 33;
            this.lnknearby_bus_station.TabStop = true;
            this.lnknearby_bus_station.Text = "公交站";
            this.lnknearby_bus_station.Visible = false;
            this.lnknearby_bus_station.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // lnknearby_hospital
            // 
            this.lnknearby_hospital.AutoSize = true;
            this.lnknearby_hospital.Location = new System.Drawing.Point(274, 186);
            this.lnknearby_hospital.Name = "lnknearby_hospital";
            this.lnknearby_hospital.Size = new System.Drawing.Size(29, 12);
            this.lnknearby_hospital.TabIndex = 32;
            this.lnknearby_hospital.TabStop = true;
            this.lnknearby_hospital.Text = "医院";
            this.lnknearby_hospital.Visible = false;
            this.lnknearby_hospital.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // lnknearby_bank
            // 
            this.lnknearby_bank.AutoSize = true;
            this.lnknearby_bank.Location = new System.Drawing.Point(239, 186);
            this.lnknearby_bank.Name = "lnknearby_bank";
            this.lnknearby_bank.Size = new System.Drawing.Size(29, 12);
            this.lnknearby_bank.TabIndex = 31;
            this.lnknearby_bank.TabStop = true;
            this.lnknearby_bank.Text = "银行";
            this.lnknearby_bank.Visible = false;
            this.lnknearby_bank.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // lnknearby_eatting
            // 
            this.lnknearby_eatting.AutoSize = true;
            this.lnknearby_eatting.Location = new System.Drawing.Point(204, 186);
            this.lnknearby_eatting.Name = "lnknearby_eatting";
            this.lnknearby_eatting.Size = new System.Drawing.Size(29, 12);
            this.lnknearby_eatting.TabIndex = 30;
            this.lnknearby_eatting.TabStop = true;
            this.lnknearby_eatting.Text = "餐馆";
            this.lnknearby_eatting.Visible = false;
            this.lnknearby_eatting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // lnknearby_hotel
            // 
            this.lnknearby_hotel.AutoSize = true;
            this.lnknearby_hotel.Location = new System.Drawing.Point(169, 186);
            this.lnknearby_hotel.Name = "lnknearby_hotel";
            this.lnknearby_hotel.Size = new System.Drawing.Size(29, 12);
            this.lnknearby_hotel.TabIndex = 29;
            this.lnknearby_hotel.TabStop = true;
            this.lnknearby_hotel.Text = "酒店";
            this.lnknearby_hotel.Visible = false;
            this.lnknearby_hotel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(116, 181);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(43, 23);
            this.btnsearch.TabIndex = 28;
            this.btnsearch.Text = "搜索";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Visible = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // txtNearby
            // 
            this.txtNearby.Location = new System.Drawing.Point(10, 182);
            this.txtNearby.Name = "txtNearby";
            this.txtNearby.Size = new System.Drawing.Size(100, 21);
            this.txtNearby.TabIndex = 27;
            this.txtNearby.Visible = false;
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPlace.ForeColor = System.Drawing.Color.Gray;
            this.lblPlace.Location = new System.Drawing.Point(8, 156);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(32, 17);
            this.lblPlace.TabIndex = 26;
            this.lblPlace.Text = "起点";
            // 
            // btndriving
            // 
            this.btndriving.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndriving.Location = new System.Drawing.Point(300, 153);
            this.btndriving.Name = "btndriving";
            this.btndriving.Size = new System.Drawing.Size(52, 23);
            this.btndriving.TabIndex = 25;
            this.btndriving.Text = "驾车";
            this.btndriving.UseVisualStyleBackColor = true;
            this.btndriving.Click += new System.EventHandler(this.btndriving_Click);
            // 
            // btntransit
            // 
            this.btntransit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btntransit.Location = new System.Drawing.Point(241, 153);
            this.btntransit.Name = "btntransit";
            this.btntransit.Size = new System.Drawing.Size(54, 23);
            this.btntransit.TabIndex = 24;
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
            this.bPlaceBox.Location = new System.Drawing.Point(42, 154);
            this.bPlaceBox.Name = "bPlaceBox";
            this.bPlaceBox.QueryText = "";
            this.bPlaceBox.Size = new System.Drawing.Size(193, 21);
            this.bPlaceBox.TabIndex = 23;
            // 
            // BMarkerTipControl
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
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.picDelete);
            this.Controls.Add(this.picEdit);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Name = "BMarkerTipControl";
            this.Size = new System.Drawing.Size(360, 229);
            this.Load += new System.EventHandler(this.BMarkerTipControl_Load);
            this.Click += new System.EventHandler(this.BMarkerTipControl_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BMarkerTipControl_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BMarkerTipControl_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picEdit;
        private System.Windows.Forms.PictureBox picDelete;
        private System.Windows.Forms.TextBox txtRemarks;
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
