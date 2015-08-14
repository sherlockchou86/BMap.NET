namespace BMap.NET.WindowsForm
{
    partial class BWalkingStepItem
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
            this.lblStepInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStepInfo
            // 
            this.lblStepInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStepInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStepInfo.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStepInfo.ForeColor = System.Drawing.Color.DimGray;
            this.lblStepInfo.Location = new System.Drawing.Point(37, 7);
            this.lblStepInfo.Name = "lblStepInfo";
            this.lblStepInfo.Size = new System.Drawing.Size(294, 39);
            this.lblStepInfo.TabIndex = 2;
            this.lblStepInfo.Text = "这里是步骤说明这里是步骤说明这里是步骤说明这里是步\r\n撒旦法阿斯蒂芬撒旦法撒旦发射点发\r\n撒旦法骤说明";
            this.lblStepInfo.Click += new System.EventHandler(this.BWalkingStepItem_Click);
            this.lblStepInfo.MouseEnter += new System.EventHandler(this.BWalkingStepItem_MouseEnter);
            this.lblStepInfo.MouseLeave += new System.EventHandler(this.BWalkingStepItem_MouseLeave);
            // 
            // BWalkingStepItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblStepInfo);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "BWalkingStepItem";
            this.Size = new System.Drawing.Size(338, 52);
            this.Click += new System.EventHandler(this.BWalkingStepItem_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BWalkingStepItem_Paint);
            this.MouseEnter += new System.EventHandler(this.BWalkingStepItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.BWalkingStepItem_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStepInfo;

    }
}
