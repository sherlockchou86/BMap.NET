namespace BMap.NET.WindowsForm
{
    partial class BTransitStepItem
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
            this.SuspendLayout();
            // 
            // BTransitStepItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BTransitStepItem";
            this.Size = new System.Drawing.Size(298, 70);
            this.Click += new System.EventHandler(this.BTransitStepItem_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BTransitStepItem_Paint);
            this.MouseEnter += new System.EventHandler(this.BTransitStepItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.BTransitStepItem_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
