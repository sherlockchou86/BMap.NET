namespace BMap.NET.WindowsForm
{
    partial class BDirectionBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BDirectionBoard));
            this.picExchange = new System.Windows.Forms.PictureBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flpRoutes = new System.Windows.Forms.FlowLayoutPanel();
            this.bPlaceBoxDestination = new BMap.NET.WindowsForm.BPlaceBox();
            this.bPlaceBoxSource = new BMap.NET.WindowsForm.BPlaceBox();
            ((System.ComponentModel.ISupportInitialize)(this.picExchange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // picExchange
            // 
            this.picExchange.BackColor = System.Drawing.Color.White;
            this.picExchange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExchange.Image = ((System.Drawing.Image)(resources.GetObject("picExchange.Image")));
            this.picExchange.Location = new System.Drawing.Point(1, 47);
            this.picExchange.Name = "picExchange";
            this.picExchange.Size = new System.Drawing.Size(33, 58);
            this.picExchange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picExchange.TabIndex = 2;
            this.picExchange.TabStop = false;
            this.picExchange.Click += new System.EventHandler(this.picExchange_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSearch.ForeColor = System.Drawing.Color.DarkGray;
            this.lblSearch.Location = new System.Drawing.Point(266, 46);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(46, 59);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "搜索";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSearch.Click += new System.EventHandler(this.lblSearch_Click);
            this.lblSearch.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.lblSearch.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(33, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 17);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(33, 85);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(17, 17);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(2, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 1);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // flpRoutes
            // 
            this.flpRoutes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpRoutes.AutoScroll = true;
            this.flpRoutes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpRoutes.Location = new System.Drawing.Point(0, 171);
            this.flpRoutes.Name = "flpRoutes";
            this.flpRoutes.Size = new System.Drawing.Size(313, 286);
            this.flpRoutes.TabIndex = 7;
            this.flpRoutes.WrapContents = false;
            // 
            // bPlaceBoxDestination
            // 
            this.bPlaceBoxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bPlaceBoxDestination.BPlacesBoard = null;
            this.bPlaceBoxDestination.CurrentCity = null;
            this.bPlaceBoxDestination.Enter2Search = false;
            this.bPlaceBoxDestination.InputFont = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bPlaceBoxDestination.Location = new System.Drawing.Point(51, 83);
            this.bPlaceBoxDestination.Name = "bPlaceBoxDestination";
            this.bPlaceBoxDestination.QueryText = "";
            this.bPlaceBoxDestination.Size = new System.Drawing.Size(212, 21);
            this.bPlaceBoxDestination.TabIndex = 1;
            // 
            // bPlaceBoxSource
            // 
            this.bPlaceBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bPlaceBoxSource.BPlacesBoard = null;
            this.bPlaceBoxSource.CurrentCity = null;
            this.bPlaceBoxSource.Enter2Search = false;
            this.bPlaceBoxSource.InputFont = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bPlaceBoxSource.Location = new System.Drawing.Point(51, 46);
            this.bPlaceBoxSource.Name = "bPlaceBoxSource";
            this.bPlaceBoxSource.QueryText = "";
            this.bPlaceBoxSource.Size = new System.Drawing.Size(212, 21);
            this.bPlaceBoxSource.TabIndex = 0;
            // 
            // BDirectionBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flpRoutes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.picExchange);
            this.Controls.Add(this.bPlaceBoxDestination);
            this.Controls.Add(this.bPlaceBoxSource);
            this.Name = "BDirectionBoard";
            this.Size = new System.Drawing.Size(313, 457);
            this.Click += new System.EventHandler(this.BDirectionBoard_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BDirectionBoard_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BDirectionBoard_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picExchange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BPlaceBox bPlaceBoxSource;
        private BPlaceBox bPlaceBoxDestination;
        private System.Windows.Forms.PictureBox picExchange;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpRoutes;
    }
}
