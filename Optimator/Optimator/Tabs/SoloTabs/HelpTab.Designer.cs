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
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.CloseBtn = new System.Windows.Forms.ToolStripButton();
            this.HelpLbl = new System.Windows.Forms.Label();
            this.VersionLbl = new System.Windows.Forms.Label();
            this.InfoLbl = new System.Windows.Forms.Label();
            this.YoutubeLinkLbl = new System.Windows.Forms.LinkLabel();
            this.OptiSiteLbl = new System.Windows.Forms.LinkLabel();
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
            this.CloseBtn.Image = global::Optimator.Properties.Resources.CloseIcon;
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
            this.HelpLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
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
            this.VersionLbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic);
            this.VersionLbl.Location = new System.Drawing.Point(50, 208);
            this.VersionLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new System.Drawing.Size(182, 65);
            this.VersionLbl.TabIndex = 123;
            this.VersionLbl.Text = "Version";
            // 
            // InfoLbl
            // 
            this.InfoLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.InfoLbl.Location = new System.Drawing.Point(50, 331);
            this.InfoLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InfoLbl.Name = "InfoLbl";
            this.InfoLbl.Size = new System.Drawing.Size(1158, 323);
            this.InfoLbl.TabIndex = 130;
            this.InfoLbl.Text = "Unfortunately at this version of the software, comprehensive in-app help is not a" +
    "vailable. To access assistance, please view the tutorials available on YouTube o" +
    "r through the Opti website.";
            // 
            // YoutubeLinkLbl
            // 
            this.YoutubeLinkLbl.ActiveLinkColor = System.Drawing.Color.DarkSeaGreen;
            this.YoutubeLinkLbl.AutoSize = true;
            this.YoutubeLinkLbl.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YoutubeLinkLbl.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.YoutubeLinkLbl.LinkColor = System.Drawing.Color.Black;
            this.YoutubeLinkLbl.Location = new System.Drawing.Point(51, 654);
            this.YoutubeLinkLbl.Name = "YoutubeLinkLbl";
            this.YoutubeLinkLbl.Size = new System.Drawing.Size(197, 59);
            this.YoutubeLinkLbl.TabIndex = 131;
            this.YoutubeLinkLbl.TabStop = true;
            this.YoutubeLinkLbl.Text = "YouTube";
            this.YoutubeLinkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.YoutubeLinkLbl_LinkClicked);
            // 
            // OptiSiteLbl
            // 
            this.OptiSiteLbl.ActiveLinkColor = System.Drawing.Color.DarkSeaGreen;
            this.OptiSiteLbl.AutoSize = true;
            this.OptiSiteLbl.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptiSiteLbl.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.OptiSiteLbl.LinkColor = System.Drawing.Color.Black;
            this.OptiSiteLbl.Location = new System.Drawing.Point(51, 790);
            this.OptiSiteLbl.Name = "OptiSiteLbl";
            this.OptiSiteLbl.Size = new System.Drawing.Size(289, 59);
            this.OptiSiteLbl.TabIndex = 132;
            this.OptiSiteLbl.TabStop = true;
            this.OptiSiteLbl.Text = "Opti Website";
            this.OptiSiteLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OptiSiteLbl_LinkClicked);
            // 
            // HelpTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.OptiSiteLbl);
            this.Controls.Add(this.YoutubeLinkLbl);
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
        private System.Windows.Forms.LinkLabel YoutubeLinkLbl;
        private System.Windows.Forms.LinkLabel OptiSiteLbl;
    }
}
