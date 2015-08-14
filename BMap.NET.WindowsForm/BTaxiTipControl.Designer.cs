namespace BMap.NET.WindowsForm
{
    partial class BTaxiTipControl
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
            this.lnkTaxiTip = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lnkTaxiTip
            // 
            this.lnkTaxiTip.AutoSize = true;
            this.lnkTaxiTip.BackColor = System.Drawing.Color.Linen;
            this.lnkTaxiTip.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkTaxiTip.LinkColor = System.Drawing.Color.Gray;
            this.lnkTaxiTip.Location = new System.Drawing.Point(85, 7);
            this.lnkTaxiTip.Name = "lnkTaxiTip";
            this.lnkTaxiTip.Size = new System.Drawing.Size(132, 17);
            this.lnkTaxiTip.TabIndex = 0;
            this.lnkTaxiTip.TabStop = true;
            this.lnkTaxiTip.Text = "打车需23元，共32分钟";
            this.lnkTaxiTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkTaxiTip.VisitedLinkColor = System.Drawing.Color.Gray;
            this.lnkTaxiTip.MouseEnter += new System.EventHandler(this.linkLabel1_MouseEnter);
            this.lnkTaxiTip.MouseLeave += new System.EventHandler(this.linkLabel1_MouseLeave);
            // 
            // BTaxiTipControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.lnkTaxiTip);
            this.Name = "BTaxiTipControl";
            this.Size = new System.Drawing.Size(303, 50);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BTaxiTipControl_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkTaxiTip;
    }
}
