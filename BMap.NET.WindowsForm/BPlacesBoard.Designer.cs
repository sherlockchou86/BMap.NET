namespace BMap.NET.WindowsForm
{
    partial class BPlacesBoard
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
            this.flpPlaces = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpPlaces
            // 
            this.flpPlaces.AutoScroll = true;
            this.flpPlaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPlaces.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPlaces.Location = new System.Drawing.Point(0, 0);
            this.flpPlaces.Name = "flpPlaces";
            this.flpPlaces.Size = new System.Drawing.Size(269, 369);
            this.flpPlaces.TabIndex = 0;
            this.flpPlaces.WrapContents = false;
            // 
            // BPlacesBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpPlaces);
            this.Name = "BPlacesBoard";
            this.Size = new System.Drawing.Size(269, 369);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpPlaces;
    }
}
