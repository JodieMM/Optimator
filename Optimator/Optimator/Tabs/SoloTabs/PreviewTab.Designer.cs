namespace Optimator.Forms
{
    partial class PreviewTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewTab));
            this.TurnTrack = new System.Windows.Forms.TrackBar();
            this.RotationTrack = new System.Windows.Forms.TrackBar();
            this.OptionsMenu = new System.Windows.Forms.Panel();
            this.spinBar = new System.Windows.Forms.TrackBar();
            this.DrawPanel = new System.Windows.Forms.PictureBox();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.CloseBtn = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.TurnTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrack)).BeginInit();
            this.OptionsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).BeginInit();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TurnTrack
            // 
            this.TurnTrack.BackColor = System.Drawing.Color.White;
            this.TurnTrack.Cursor = System.Windows.Forms.Cursors.Default;
            this.TurnTrack.Location = new System.Drawing.Point(1172, 69);
            this.TurnTrack.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.TurnTrack.Maximum = 359;
            this.TurnTrack.Name = "TurnTrack";
            this.TurnTrack.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TurnTrack.Size = new System.Drawing.Size(90, 1038);
            this.TurnTrack.TabIndex = 7;
            this.TurnTrack.TickFrequency = 10;
            this.TurnTrack.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TurnTrack.Scroll += new System.EventHandler(this.Track_Scroll);
            // 
            // RotationTrack
            // 
            this.RotationTrack.BackColor = System.Drawing.Color.White;
            this.RotationTrack.Cursor = System.Windows.Forms.Cursors.Default;
            this.RotationTrack.Location = new System.Drawing.Point(82, 1117);
            this.RotationTrack.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.RotationTrack.Maximum = 359;
            this.RotationTrack.Name = "RotationTrack";
            this.RotationTrack.Size = new System.Drawing.Size(1080, 90);
            this.RotationTrack.TabIndex = 6;
            this.RotationTrack.TickFrequency = 10;
            this.RotationTrack.Scroll += new System.EventHandler(this.Track_Scroll);
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.BackColor = System.Drawing.Color.GhostWhite;
            this.OptionsMenu.Controls.Add(this.spinBar);
            this.OptionsMenu.Location = new System.Drawing.Point(1322, -85);
            this.OptionsMenu.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(400, 1298);
            this.OptionsMenu.TabIndex = 5;
            // 
            // spinBar
            // 
            this.spinBar.BackColor = System.Drawing.Color.GhostWhite;
            this.spinBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.spinBar.Location = new System.Drawing.Point(130, 65);
            this.spinBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.spinBar.Maximum = 359;
            this.spinBar.Name = "spinBar";
            this.spinBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.spinBar.Size = new System.Drawing.Size(90, 1038);
            this.spinBar.TabIndex = 4;
            this.spinBar.TickFrequency = 10;
            this.spinBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.spinBar.Scroll += new System.EventHandler(this.Track_Scroll);
            // 
            // DrawPanel
            // 
            this.DrawPanel.BackColor = System.Drawing.Color.White;
            this.DrawPanel.Location = new System.Drawing.Point(-28, -37);
            this.DrawPanel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(1300, 1250);
            this.DrawPanel.TabIndex = 4;
            this.DrawPanel.TabStop = false;
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseBtn});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip.Size = new System.Drawing.Size(1750, 39);
            this.ToolStrip.TabIndex = 23;
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
            // PreviewTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.TurnTrack);
            this.Controls.Add(this.RotationTrack);
            this.Controls.Add(this.OptionsMenu);
            this.Controls.Add(this.DrawPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PreviewTab";
            this.Size = new System.Drawing.Size(1750, 1237);
            ((System.ComponentModel.ISupportInitialize)(this.TurnTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrack)).EndInit();
            this.OptionsMenu.ResumeLayout(false);
            this.OptionsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).EndInit();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar TurnTrack;
        private System.Windows.Forms.TrackBar RotationTrack;
        private System.Windows.Forms.Panel OptionsMenu;
        private System.Windows.Forms.TrackBar spinBar;
        private System.Windows.Forms.PictureBox DrawPanel;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton CloseBtn;
    }
}
