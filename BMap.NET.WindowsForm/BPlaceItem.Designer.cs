namespace BMap.NET.WindowsForm
{
    partial class BPlaceItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BPlaceItem));
            this.lnkName = new System.Windows.Forms.LinkLabel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_there = new System.Windows.Forms.Button();
            this.btn_here = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lnkName
            // 
            this.lnkName.AutoSize = true;
            this.lnkName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkName.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkName.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkName.Location = new System.Drawing.Point(29, 9);
            this.lnkName.Name = "lnkName";
            this.lnkName.Size = new System.Drawing.Size(109, 17);
            this.lnkName.TabIndex = 0;
            this.lnkName.TabStop = true;
            this.lnkName.Text = "天津城建大学-详情";
            this.lnkName.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lnkName.Click += new System.EventHandler(this.BPlaceItem_Click);
            this.lnkName.MouseEnter += new System.EventHandler(this.BPlaceItem_MouseEnter);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddress.Location = new System.Drawing.Point(31, 31);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(221, 16);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Text = "天津市西青区津京公路26号";
            this.txtAddress.Click += new System.EventHandler(this.BPlaceItem_Click);
            this.txtAddress.MouseEnter += new System.EventHandler(this.BPlaceItem_MouseEnter);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPhone.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPhone.Location = new System.Drawing.Point(31, 52);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(221, 16);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.Text = "电话 022-563269612";
            this.txtPhone.Click += new System.EventHandler(this.BPlaceItem_Click);
            this.txtPhone.MouseEnter += new System.EventHandler(this.BPlaceItem_MouseEnter);
            // 
            // txtTag
            // 
            this.txtTag.BackColor = System.Drawing.Color.White;
            this.txtTag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTag.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTag.Location = new System.Drawing.Point(31, 80);
            this.txtTag.Name = "txtTag";
            this.txtTag.ReadOnly = true;
            this.txtTag.Size = new System.Drawing.Size(156, 16);
            this.txtTag.TabIndex = 3;
            this.txtTag.Text = "学校，中餐厅";
            this.txtTag.Click += new System.EventHandler(this.BPlaceItem_Click);
            this.txtTag.MouseEnter += new System.EventHandler(this.BPlaceItem_MouseEnter);
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.White;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPrice.ForeColor = System.Drawing.Color.Red;
            this.txtPrice.Location = new System.Drawing.Point(193, 80);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(71, 16);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.Text = "人均 $78";
            this.txtPrice.Click += new System.EventHandler(this.BPlaceItem_Click);
            this.txtPrice.MouseEnter += new System.EventHandler(this.BPlaceItem_MouseEnter);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(7, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 1);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            this.label1.MouseEnter += new System.EventHandler(this.BPlaceItem_MouseEnter);
            // 
            // btn_there
            // 
            this.btn_there.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_there.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_there.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_there.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_there.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_there.Image = ((System.Drawing.Image)(resources.GetObject("btn_there.Image")));
            this.btn_there.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_there.Location = new System.Drawing.Point(9, 113);
            this.btn_there.Name = "btn_there";
            this.btn_there.Size = new System.Drawing.Size(108, 26);
            this.btn_there.TabIndex = 8;
            this.btn_there.Text = "到这里去";
            this.btn_there.UseVisualStyleBackColor = true;
            this.btn_there.Click += new System.EventHandler(this.btn_there_Click);
            this.btn_there.MouseEnter += new System.EventHandler(this.BPlaceItem_MouseEnter);
            // 
            // btn_here
            // 
            this.btn_here.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_here.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_here.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_here.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_here.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_here.Image = ((System.Drawing.Image)(resources.GetObject("btn_here.Image")));
            this.btn_here.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_here.Location = new System.Drawing.Point(123, 113);
            this.btn_here.Name = "btn_here";
            this.btn_here.Size = new System.Drawing.Size(118, 26);
            this.btn_here.TabIndex = 9;
            this.btn_here.Text = "从这里出发";
            this.btn_here.UseVisualStyleBackColor = true;
            this.btn_here.Click += new System.EventHandler(this.btn_here_Click);
            this.btn_here.MouseEnter += new System.EventHandler(this.BPlaceItem_MouseEnter);
            // 
            // BPlaceItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_here);
            this.Controls.Add(this.btn_there);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lnkName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "BPlaceItem";
            this.Size = new System.Drawing.Size(269, 145);
            this.Load += new System.EventHandler(this.BPlaceItem_Load);
            this.Click += new System.EventHandler(this.BPlaceItem_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BPlaceItem_Paint);
            this.MouseEnter += new System.EventHandler(this.BPlaceItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.BPlaceItem_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_there;
        private System.Windows.Forms.Button btn_here;
    }
}
