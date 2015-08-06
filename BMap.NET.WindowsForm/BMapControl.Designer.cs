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
            this.cm_popup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.这是哪里ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设为起点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设为终点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.居中ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.清空所有绘图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空所有标记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cm_popup.SuspendLayout();
            this.SuspendLayout();
            // 
            // cm_popup
            // 
            this.cm_popup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.这是哪里ToolStripMenuItem,
            this.设为起点ToolStripMenuItem,
            this.设为终点ToolStripMenuItem,
            this.toolStripSeparator1,
            this.居中ToolStripMenuItem,
            this.放大ToolStripMenuItem,
            this.缩小ToolStripMenuItem,
            this.toolStripSeparator2,
            this.清空所有绘图ToolStripMenuItem,
            this.清空所有标记ToolStripMenuItem});
            this.cm_popup.Name = "cm_popup";
            this.cm_popup.Size = new System.Drawing.Size(153, 214);
            // 
            // 这是哪里ToolStripMenuItem
            // 
            this.这是哪里ToolStripMenuItem.Name = "这是哪里ToolStripMenuItem";
            this.这是哪里ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.这是哪里ToolStripMenuItem.Text = "这是哪里?";
            // 
            // 设为起点ToolStripMenuItem
            // 
            this.设为起点ToolStripMenuItem.Name = "设为起点ToolStripMenuItem";
            this.设为起点ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设为起点ToolStripMenuItem.Text = "以此为起点";
            // 
            // 设为终点ToolStripMenuItem
            // 
            this.设为终点ToolStripMenuItem.Name = "设为终点ToolStripMenuItem";
            this.设为终点ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设为终点ToolStripMenuItem.Text = "以此为终点";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // 居中ToolStripMenuItem
            // 
            this.居中ToolStripMenuItem.Name = "居中ToolStripMenuItem";
            this.居中ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.居中ToolStripMenuItem.Text = "居中";
            // 
            // 放大ToolStripMenuItem
            // 
            this.放大ToolStripMenuItem.Name = "放大ToolStripMenuItem";
            this.放大ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.放大ToolStripMenuItem.Text = "放大";
            // 
            // 缩小ToolStripMenuItem
            // 
            this.缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            this.缩小ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.缩小ToolStripMenuItem.Text = "缩小";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // 清空所有绘图ToolStripMenuItem
            // 
            this.清空所有绘图ToolStripMenuItem.Name = "清空所有绘图ToolStripMenuItem";
            this.清空所有绘图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.清空所有绘图ToolStripMenuItem.Text = "清空所有绘图";
            // 
            // 清空所有标记ToolStripMenuItem
            // 
            this.清空所有标记ToolStripMenuItem.Name = "清空所有标记ToolStripMenuItem";
            this.清空所有标记ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.清空所有标记ToolStripMenuItem.Text = "清空所有标记";
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
        private System.Windows.Forms.ToolStripMenuItem 这是哪里ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设为起点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设为终点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 居中ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 清空所有绘图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空所有标记ToolStripMenuItem;
    }
}
