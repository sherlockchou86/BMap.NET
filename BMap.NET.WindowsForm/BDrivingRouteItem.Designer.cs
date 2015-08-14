namespace BMap.NET.WindowsForm
{
    partial class BDrivingRouteItem
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
            this.flpSteps = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpSteps
            // 
            this.flpSteps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpSteps.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSteps.Location = new System.Drawing.Point(0, 70);
            this.flpSteps.Margin = new System.Windows.Forms.Padding(0);
            this.flpSteps.Name = "flpSteps";
            this.flpSteps.Size = new System.Drawing.Size(298, 303);
            this.flpSteps.TabIndex = 0;
            this.flpSteps.WrapContents = false;
            // 
            // BDrivingRouteItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flpSteps);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "BDrivingRouteItem";
            this.Size = new System.Drawing.Size(298, 373);
            this.Click += new System.EventHandler(this.BDrivingRouteItem_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BDrivingRouteItem_Paint);
            this.MouseEnter += new System.EventHandler(this.BDrivingRouteItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.BDrivingRouteItem_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSteps;
    }
}
