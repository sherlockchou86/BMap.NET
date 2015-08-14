namespace BMap.NET.WindowsForm
{
    partial class BWalkingRouteItem
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
            this.flpSteps.Size = new System.Drawing.Size(298, 235);
            this.flpSteps.TabIndex = 1;
            this.flpSteps.WrapContents = false;
            // 
            // BWalkingRouteItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flpSteps);
            this.Name = "BWalkingRouteItem";
            this.Size = new System.Drawing.Size(298, 305);
            this.Click += new System.EventHandler(this.BWalkingRouteItem_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BWalkingRouteItem_Paint);
            this.MouseEnter += new System.EventHandler(this.BWalkingRouteItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.BWalkingRouteItem_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSteps;
    }
}
