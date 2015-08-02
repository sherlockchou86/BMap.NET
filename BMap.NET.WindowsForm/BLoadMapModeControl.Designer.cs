namespace BMap.NET.WindowsForm
{
    partial class BLoadMapModeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLoadMapModeControl));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rdoCache = new System.Windows.Forms.RadioButton();
            this.rdoCachefirst = new System.Windows.Forms.RadioButton();
            this.rdoServer = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(101, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 13);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // rdoCache
            // 
            this.rdoCache.AutoSize = true;
            this.rdoCache.BackColor = System.Drawing.SystemColors.Control;
            this.rdoCache.Checked = true;
            this.rdoCache.Location = new System.Drawing.Point(15, 34);
            this.rdoCache.Name = "rdoCache";
            this.rdoCache.Size = new System.Drawing.Size(71, 16);
            this.rdoCache.TabIndex = 1;
            this.rdoCache.TabStop = true;
            this.rdoCache.Text = "仅从本地";
            this.rdoCache.UseVisualStyleBackColor = true;
            this.rdoCache.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoCachefirst
            // 
            this.rdoCachefirst.AutoSize = true;
            this.rdoCachefirst.Location = new System.Drawing.Point(15, 56);
            this.rdoCachefirst.Name = "rdoCachefirst";
            this.rdoCachefirst.Size = new System.Drawing.Size(71, 16);
            this.rdoCachefirst.TabIndex = 2;
            this.rdoCachefirst.Text = "本地优先";
            this.rdoCachefirst.UseVisualStyleBackColor = true;
            this.rdoCachefirst.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoServer
            // 
            this.rdoServer.AutoSize = true;
            this.rdoServer.Location = new System.Drawing.Point(15, 78);
            this.rdoServer.Name = "rdoServer";
            this.rdoServer.Size = new System.Drawing.Size(71, 16);
            this.rdoServer.TabIndex = 3;
            this.rdoServer.Text = "仅从远程";
            this.rdoServer.UseVisualStyleBackColor = true;
            this.rdoServer.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 1);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // BLoadMapModeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoServer);
            this.Controls.Add(this.rdoCachefirst);
            this.Controls.Add(this.rdoCache);
            this.Controls.Add(this.pictureBox1);
            this.Name = "BLoadMapModeControl";
            this.Size = new System.Drawing.Size(126, 105);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rdoCache;
        private System.Windows.Forms.RadioButton rdoCachefirst;
        private System.Windows.Forms.RadioButton rdoServer;
        private System.Windows.Forms.Label label1;
    }
}
