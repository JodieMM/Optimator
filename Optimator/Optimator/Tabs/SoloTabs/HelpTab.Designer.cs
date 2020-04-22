namespace Optimator.Forms
{
    partial class HelpTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpTab));
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.CloseBtn = new System.Windows.Forms.ToolStripButton();
            this.HelpLbl = new System.Windows.Forms.Label();
            this.VersionLbl = new System.Windows.Forms.Label();
            this.InfoLbl = new System.Windows.Forms.Label();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseBtn});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip.Size = new System.Drawing.Size(1314, 39);
            this.ToolStrip.TabIndex = 24;
            this.ToolStrip.Text = "ToolStrip";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CloseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloseBtn.Image = Properties.Resources.CloseIcon;
            this.CloseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CloseBtn.Size = new System.Drawing.Size(36, 36);
            this.CloseBtn.Text = "Close";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // HelpLbl
            // 
            this.HelpLbl.AutoSize = true;
            this.HelpLbl.Font = Consts.headingLblFont;
            this.HelpLbl.Location = new System.Drawing.Point(46, 104);
            this.HelpLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HelpLbl.Name = "HelpLbl";
            this.HelpLbl.Size = new System.Drawing.Size(148, 72);
            this.HelpLbl.TabIndex = 129;
            this.HelpLbl.Text = "Help";
            // 
            // VersionLbl
            // 
            this.VersionLbl.AutoSize = true;
            this.VersionLbl.Font = Consts.subLblFont;
            this.VersionLbl.Location = new System.Drawing.Point(50, 208);
            this.VersionLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new System.Drawing.Size(182, 65);
            this.VersionLbl.TabIndex = 123;
            this.VersionLbl.Text = "Version";
            // 
            // InfoLbl
            // 
            this.InfoLbl.Font = Consts.contentFont;
            this.InfoLbl.Location = new System.Drawing.Point(50, 331);
            this.InfoLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InfoLbl.Name = "InfoLbl";
            this.InfoLbl.Size = new System.Drawing.Size(1158, 567);
            this.InfoLbl.TabIndex = 130;
            this.InfoLbl.Text = "Unfortunately at this version of the software, comprehensive in-app help is not a" +
    "vailable. To access assistance, please view the tutorials available on YouTube o" +
    "r through the Opti website.";
            // 
            // HelpTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.InfoLbl);
            this.Controls.Add(this.HelpLbl);
            this.Controls.Add(this.VersionLbl);
            this.Controls.Add(this.ToolStrip);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HelpTab";
            this.Size = new System.Drawing.Size(1314, 1031);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton CloseBtn;
        private System.Windows.Forms.Label HelpLbl;
        private System.Windows.Forms.Label VersionLbl;
        private System.Windows.Forms.Label InfoLbl;
    }
}
