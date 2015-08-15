namespace BMap.NET.WindowsForm
{
    partial class BPlacesSuggestionItem
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblSelect = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.ForeColor = System.Drawing.Color.Blue;
            this.lblName.Location = new System.Drawing.Point(32, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(165, 26);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "这里是名称";
            this.lblName.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.lblName.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // lblAddress
            // 
            this.lblAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAddress.ForeColor = System.Drawing.Color.Gray;
            this.lblAddress.Location = new System.Drawing.Point(32, 36);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(164, 26);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "这里是名称\r\n撒发射点发阿斯蒂芬";
            this.lblAddress.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.lblAddress.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // lblSelect
            // 
            this.lblSelect.BackColor = System.Drawing.Color.PeachPuff;
            this.lblSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelect.ForeColor = System.Drawing.Color.Peru;
            this.lblSelect.Location = new System.Drawing.Point(208, 23);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(63, 23);
            this.lblSelect.TabIndex = 4;
            this.lblSelect.Text = "设为起点";
            this.lblSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSelect.Click += new System.EventHandler(this.lblSelect_Click);
            this.lblSelect.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.lblSelect.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIndex.Location = new System.Drawing.Point(3, 19);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(20, 22);
            this.lblIndex.TabIndex = 5;
            this.lblIndex.Text = "1";
            // 
            // BPlacesSuggestionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "BPlacesSuggestionItem";
            this.Size = new System.Drawing.Size(284, 67);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BPlacesSuggestionItem_Paint);
            this.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Label lblIndex;
    }
}
