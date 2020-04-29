using System.Windows.Forms;

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
            this.components = new System.ComponentModel.Container();
            this.TurnTrack = new System.Windows.Forms.TrackBar();
            this.RotationTrack = new System.Windows.Forms.TrackBar();
            this.OptionsMenu = new System.Windows.Forms.Panel();
            this.spinBar = new System.Windows.Forms.TrackBar();
            this.DrawPanel = new System.Windows.Forms.PictureBox();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.CloseBtn = new System.Windows.Forms.ToolStripButton();
            this.DisplayTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.TurnTrack.Margin = new System.Windows.Forms.Padding(6);
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
            this.RotationTrack.Margin = new System.Windows.Forms.Padding(6);
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
            this.OptionsMenu.Controls.Add(this.label5);
            this.OptionsMenu.Controls.Add(this.label4);
            this.OptionsMenu.Controls.Add(this.label3);
            this.OptionsMenu.Controls.Add(this.label2);
            this.OptionsMenu.Controls.Add(this.label1);
            this.OptionsMenu.Controls.Add(this.spinBar);
            this.OptionsMenu.Location = new System.Drawing.Point(1322, -85);
            this.OptionsMenu.Margin = new System.Windows.Forms.Padding(6);
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(400, 1298);
            this.OptionsMenu.TabIndex = 5;
            // 
            // spinBar
            // 
            this.spinBar.BackColor = System.Drawing.Color.GhostWhite;
            this.spinBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.spinBar.Location = new System.Drawing.Point(130, 65);
            this.spinBar.Margin = new System.Windows.Forms.Padding(6);
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
            this.DrawPanel.Margin = new System.Windows.Forms.Padding(6);
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
            this.CloseBtn.Image = global::Optimator.Properties.Resources.CloseIcon;
            this.CloseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CloseBtn.Size = new System.Drawing.Size(36, 36);
            this.CloseBtn.Text = "Close";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // DisplayTimer
            // 
            this.DisplayTimer.Interval = 5;
            this.DisplayTimer.Tick += new System.EventHandler(this.DisplayTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 521);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
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
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private Timer DisplayTimer;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
