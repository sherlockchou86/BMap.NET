namespace BMap.NET.WindowsForm
{
    partial class BMapControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BMapControl));
            this.cm_popup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsWhere = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSetStart = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSetEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLarge = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSmall = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsRegionSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsClearDrawings = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsClearMarkers = new System.Windows.Forms.ToolStripMenuItem();
            this.cm_popup.SuspendLayout();
            this.SuspendLayout();
            // 
            // cm_popup
            // 
            this.cm_popup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsWhere,
            this.cmsSetStart,
            this.cmsSetEnd,
            this.toolStripSeparator1,
            this.cmsCenter,
            this.cmsLarge,
            this.cmsSmall,
            this.toolStripSeparator2,
            this.cmsRegionSaveAs,
            this.toolStripSeparator3,
            this.cmsClearDrawings,
            this.cmsClearMarkers});
            this.cm_popup.Name = "cm_popup";
            this.cm_popup.Size = new System.Drawing.Size(180, 242);
            // 
            // cmsWhere
            // 
            this.cmsWhere.Image = ((System.Drawing.Image)(resources.GetObject("cmsWhere.Image")));
            this.cmsWhere.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsWhere.Name = "cmsWhere";
            this.cmsWhere.Size = new System.Drawing.Size(179, 22);
            this.cmsWhere.Text = "这是哪里?";
            this.cmsWhere.Click += new System.EventHandler(this.cm_popup_Click);
            // 
            // cmsSetStart
            // 
            this.cmsSetStart.Image = ((System.Drawing.Image)(resources.GetObject("cmsSetStart.Image")));
            this.cmsSetStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsSetStart.Name = "cmsSetStart";
            this.cmsSetStart.Size = new System.Drawing.Size(179, 22);
            this.cmsSetStart.Text = "以此为起点";
            this.cmsSetStart.Click += new System.EventHandler(this.cm_popup_Click);
            // 
            // cmsSetEnd
            // 
            this.cmsSetEnd.Image = ((System.Drawing.Image)(resources.GetObject("cmsSetEnd.Image")));
            this.cmsSetEnd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsSetEnd.Name = "cmsSetEnd";
            this.cmsSetEnd.Size = new System.Drawing.Size(179, 22);
            this.cmsSetEnd.Text = "以此为终点";
            this.cmsSetEnd.Click += new System.EventHandler(this.cm_popup_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // cmsCenter
            // 
            this.cmsCenter.Image = ((System.Drawing.Image)(resources.GetObject("cmsCenter.Image")));
            this.cmsCenter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsCenter.Name = "cmsCenter";
            this.cmsCenter.Size = new System.Drawing.Size(179, 22);
            this.cmsCenter.Text = "居中";
            this.cmsCenter.Click += new System.EventHandler(this.cm_popup_Click);
            // 
            // cmsLarge
            // 
            this.cmsLarge.Image = ((System.Drawing.Image)(resources.GetObject("cmsLarge.Image")));
            this.cmsLarge.Name = "cmsLarge";
            this.cmsLarge.Size = new System.Drawing.Size(179, 22);
            this.cmsLarge.Text = "放大";
            this.cmsLarge.Click += new System.EventHandler(this.cm_popup_Click);
            // 
            // cmsSmall
            // 
            this.cmsSmall.Image = ((System.Drawing.Image)(resources.GetObject("cmsSmall.Image")));
            this.cmsSmall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsSmall.Name = "cmsSmall";
            this.cmsSmall.Size = new System.Drawing.Size(179, 22);
            this.cmsSmall.Text = "缩小";
            this.cmsSmall.Click += new System.EventHandler(this.cm_popup_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(176, 6);
            // 
            // cmsRegionSaveAs
            // 
            this.cmsRegionSaveAs.Name = "cmsRegionSaveAs";
            this.cmsRegionSaveAs.Size = new System.Drawing.Size(179, 22);
            this.cmsRegionSaveAs.Text = "\"可视区域\"另存为...";
            this.cmsRegionSaveAs.Click += new System.EventHandler(this.cm_popup_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(176, 6);
            // 
            // cmsClearDrawings
            // 
            this.cmsClearDrawings.Image = ((System.Drawing.Image)(resources.GetObject("cmsClearDrawings.Image")));
            this.cmsClearDrawings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsClearDrawings.Name = "cmsClearDrawings";
            this.cmsClearDrawings.Size = new System.Drawing.Size(179, 22);
            this.cmsClearDrawings.Text = "清空所有绘图";
            this.cmsClearDrawings.Click += new System.EventHandler(this.cm_popup_Click);
            // 
            // cmsClearMarkers
            // 
            this.cmsClearMarkers.Image = ((System.Drawing.Image)(resources.GetObject("cmsClearMarkers.Image")));
            this.cmsClearMarkers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsClearMarkers.Name = "cmsClearMarkers";
            this.cmsClearMarkers.Size = new System.Drawing.Size(179, 22);
            this.cmsClearMarkers.Text = "清空所有标记";
            this.cmsClearMarkers.Click += new System.EventHandler(this.cm_popup_Click);
            // 
            // BMapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BMapControl";
            this.Size = new System.Drawing.Size(232, 172);
            this.cm_popup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cm_popup;
        private System.Windows.Forms.ToolStripMenuItem cmsWhere;
        private System.Windows.Forms.ToolStripMenuItem cmsSetStart;
        private System.Windows.Forms.ToolStripMenuItem cmsSetEnd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsCenter;
        private System.Windows.Forms.ToolStripMenuItem cmsLarge;
        private System.Windows.Forms.ToolStripMenuItem cmsSmall;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmsClearMarkers;
        //private System.Windows.Forms.ToolStripMenuItem cmsClearDrawings;
        private System.Windows.Forms.ToolStripMenuItem cmsClearDrawings;
        private System.Windows.Forms.ToolStripMenuItem cmsRegionSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
