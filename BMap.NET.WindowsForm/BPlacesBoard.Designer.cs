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
            this.bQuickSearch = new BMap.NET.WindowsForm.BQuickSearchBoardcs();
            this.flpPlaces.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpPlaces
            // 
            this.flpPlaces.AutoScroll = true;
            this.flpPlaces.BackColor = System.Drawing.Color.White;
            this.flpPlaces.Controls.Add(this.bQuickSearch);
            this.flpPlaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPlaces.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPlaces.Location = new System.Drawing.Point(0, 0);
            this.flpPlaces.Name = "flpPlaces";
            this.flpPlaces.Size = new System.Drawing.Size(269, 436);
            this.flpPlaces.TabIndex = 0;
            this.flpPlaces.WrapContents = false;
            // 
            // bQuickSearch
            // 
            this.bQuickSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bQuickSearch.BackColor = System.Drawing.Color.White;
            this.bQuickSearch.Location = new System.Drawing.Point(3, 3);
            this.bQuickSearch.Name = "bQuickSearch";
            this.bQuickSearch.Size = new System.Drawing.Size(263, 406);
            this.bQuickSearch.TabIndex = 0;
            this.bQuickSearch.QuickSearch += new BMap.NET.WindowsForm.QuickSearchEventHandler(this.bQuickSearch_QuickSearch);
            // 
            // BPlacesBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpPlaces);
            this.Name = "BPlacesBoard";
            this.Size = new System.Drawing.Size(269, 436);
            this.flpPlaces.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpPlaces;
        private BQuickSearchBoardcs bQuickSearch;
    }
}
