namespace BMap.NET.WindowsForm
{
    partial class BPlacesSuggestionControl
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
            this.flpPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpPlaces.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPlaces.Location = new System.Drawing.Point(0, 50);
            this.flpPlaces.Margin = new System.Windows.Forms.Padding(0);
            this.flpPlaces.Name = "flpPlaces";
            this.flpPlaces.Size = new System.Drawing.Size(298, 253);
            this.flpPlaces.TabIndex = 1;
            this.flpPlaces.WrapContents = false;
            // 
            // BPlacesSuggestionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpPlaces);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "BPlacesSuggestionControl";
            this.Size = new System.Drawing.Size(298, 303);
            this.Click += new System.EventHandler(this.BPlacesSuggestionControl_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BPlacesSuggestionControl_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpPlaces;
    }
}
