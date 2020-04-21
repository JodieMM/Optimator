﻿using System.Windows.Forms;

namespace Optimator.Tabs.Compile
{
    partial class CompileTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompileTab));
            this.Panel = new System.Windows.Forms.Panel();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.SaveBtn = new System.Windows.Forms.ToolStripButton();
            this.AddSceneBtn = new System.Windows.Forms.ToolStripButton();
            this.CloseBtn = new System.Windows.Forms.ToolStripButton();
            this.SettingsBtn = new System.Windows.Forms.ToolStripButton();
            this.VidLengthLbl = new System.Windows.Forms.Label();
            this.FuturePreviewBox = new System.Windows.Forms.PictureBox();
            this.Past2PreviewBox = new System.Windows.Forms.PictureBox();
            this.PastPreviewBox = new System.Windows.Forms.PictureBox();
            this.CurrentTimeLbl = new System.Windows.Forms.Label();
            this.CurrentTimeUpDown = new System.Windows.Forms.NumericUpDown();
            this.ForwardBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.DrawPanel = new System.Windows.Forms.PictureBox();
            this.DisplayPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DPDisplayTableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.UpArrowImg = new System.Windows.Forms.Label();
            this.DPControlsTableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.LoadingMessage = new Optimator.Tabs.SoloTabs.LoadingMessage();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FuturePreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Past2PreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PastPreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).BeginInit();
            this.DisplayPanel.SuspendLayout();
            this.DPDisplayTableLayoutPnl.SuspendLayout();
            this.DPControlsTableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.MistyRose;
            this.Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel.Location = new System.Drawing.Point(1784, 39);
            this.Panel.Margin = new System.Windows.Forms.Padding(6);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(442, 1092);
            this.Panel.TabIndex = 25;
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveBtn,
            this.AddSceneBtn,
            this.CloseBtn,
            this.SettingsBtn});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip.Size = new System.Drawing.Size(2226, 39);
            this.ToolStrip.TabIndex = 24;
            this.ToolStrip.Text = "ToolStrip";
            // 
            // SaveBtn
            // 
            this.SaveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("SaveBtn.Image")));
            this.SaveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(36, 36);
            this.SaveBtn.Text = "Save";
            this.SaveBtn.Click += new System.EventHandler(this.BtnWithPanel_Click);
            // 
            // AddSceneBtn
            // 
            this.AddSceneBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddSceneBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddSceneBtn.Image")));
            this.AddSceneBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddSceneBtn.Name = "AddSceneBtn";
            this.AddSceneBtn.Size = new System.Drawing.Size(36, 36);
            this.AddSceneBtn.Text = "Add Scene";
            this.AddSceneBtn.Click += new System.EventHandler(this.BtnWithPanel_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CloseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloseBtn.Image = ((System.Drawing.Image)(resources.GetObject("CloseBtn.Image")));
            this.CloseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CloseBtn.Size = new System.Drawing.Size(36, 36);
            this.CloseBtn.Text = "Close";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("SettingsBtn.Image")));
            this.SettingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(36, 36);
            this.SettingsBtn.Text = "Settings";
            this.SettingsBtn.Click += new System.EventHandler(this.BtnWithPanel_Click);
            // 
            // VidLengthLbl
            // 
            this.VidLengthLbl.AutoSize = true;
            this.VidLengthLbl.Font = Consts.contentFont;
            this.VidLengthLbl.Location = new System.Drawing.Point(712, 0);
            this.VidLengthLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VidLengthLbl.Name = "VidLengthLbl";
            this.VidLengthLbl.Size = new System.Drawing.Size(338, 59);
            this.VidLengthLbl.TabIndex = 41;
            this.VidLengthLbl.Text = "Video Length: 0s";
            // 
            // FuturePreviewBox
            // 
            this.FuturePreviewBox.BackColor = System.Drawing.Color.White;
            this.FuturePreviewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FuturePreviewBox.Location = new System.Drawing.Point(1333, 4);
            this.FuturePreviewBox.Margin = new System.Windows.Forms.Padding(4);
            this.FuturePreviewBox.Name = "FuturePreviewBox";
            this.FuturePreviewBox.Size = new System.Drawing.Size(435, 243);
            this.FuturePreviewBox.TabIndex = 39;
            this.FuturePreviewBox.TabStop = false;
            // 
            // Past2PreviewBox
            // 
            this.Past2PreviewBox.BackColor = System.Drawing.Color.White;
            this.Past2PreviewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Past2PreviewBox.Location = new System.Drawing.Point(447, 4);
            this.Past2PreviewBox.Margin = new System.Windows.Forms.Padding(4);
            this.Past2PreviewBox.Name = "Past2PreviewBox";
            this.Past2PreviewBox.Size = new System.Drawing.Size(435, 243);
            this.Past2PreviewBox.TabIndex = 38;
            this.Past2PreviewBox.TabStop = false;
            // 
            // PastPreviewBox
            // 
            this.PastPreviewBox.BackColor = System.Drawing.Color.White;
            this.PastPreviewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PastPreviewBox.Location = new System.Drawing.Point(4, 4);
            this.PastPreviewBox.Margin = new System.Windows.Forms.Padding(4);
            this.PastPreviewBox.Name = "PastPreviewBox";
            this.PastPreviewBox.Size = new System.Drawing.Size(435, 243);
            this.PastPreviewBox.TabIndex = 30;
            this.PastPreviewBox.TabStop = false;
            // 
            // CurrentTimeLbl
            // 
            this.CurrentTimeLbl.AutoSize = true;
            this.CurrentTimeLbl.Font = Consts.contentFont;
            this.CurrentTimeLbl.Location = new System.Drawing.Point(4, 0);
            this.CurrentTimeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentTimeLbl.Name = "CurrentTimeLbl";
            this.CurrentTimeLbl.Size = new System.Drawing.Size(271, 59);
            this.CurrentTimeLbl.TabIndex = 37;
            this.CurrentTimeLbl.Text = "Current Time";
            // 
            // CurrentTimeUpDown
            // 
            this.CurrentTimeUpDown.DecimalPlaces = 3;
            this.CurrentTimeUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentTimeUpDown.Font = Consts.contentFont;
            this.CurrentTimeUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.CurrentTimeUpDown.Location = new System.Drawing.Point(358, 4);
            this.CurrentTimeUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.CurrentTimeUpDown.Name = "CurrentTimeUpDown";
            this.CurrentTimeUpDown.Size = new System.Drawing.Size(346, 64);
            this.CurrentTimeUpDown.TabIndex = 37;
            // 
            // ForwardBtn
            // 
            this.ForwardBtn.BackColor = System.Drawing.Color.LightCoral;
            this.ForwardBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ForwardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForwardBtn.Font = Consts.contentFont;
            this.ForwardBtn.Location = new System.Drawing.Point(1420, 4);
            this.ForwardBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ForwardBtn.Name = "ForwardBtn";
            this.ForwardBtn.Size = new System.Drawing.Size(348, 67);
            this.ForwardBtn.TabIndex = 19;
            this.ForwardBtn.Text = "Forward";
            this.ForwardBtn.UseVisualStyleBackColor = false;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.LightCoral;
            this.BackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = Consts.contentFont;
            this.BackBtn.Location = new System.Drawing.Point(1066, 4);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(4);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(346, 67);
            this.BackBtn.TabIndex = 23;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = false;
            // 
            // DrawPanel
            // 
            this.DrawPanel.BackColor = System.Drawing.Color.White;
            this.DrawPanel.Location = new System.Drawing.Point(116, 129);
            this.DrawPanel.Margin = new System.Windows.Forms.Padding(4);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(1062, 540);
            this.DrawPanel.TabIndex = 31;
            this.DrawPanel.TabStop = false;
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.BackColor = System.Drawing.Color.MistyRose;
            this.DisplayPanel.ColumnCount = 1;
            this.DisplayPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DisplayPanel.Controls.Add(this.DPDisplayTableLayoutPnl, 0, 1);
            this.DisplayPanel.Controls.Add(this.DPControlsTableLayoutPnl, 0, 0);
            this.DisplayPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DisplayPanel.Location = new System.Drawing.Point(0, 781);
            this.DisplayPanel.Margin = new System.Windows.Forms.Padding(6);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.RowCount = 2;
            this.DisplayPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DisplayPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.DisplayPanel.Size = new System.Drawing.Size(1784, 350);
            this.DisplayPanel.TabIndex = 42;
            this.DisplayPanel.Visible = false;
            // 
            // DPDisplayTableLayoutPnl
            // 
            this.DPDisplayTableLayoutPnl.ColumnCount = 4;
            this.DPDisplayTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DPDisplayTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DPDisplayTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DPDisplayTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DPDisplayTableLayoutPnl.Controls.Add(this.UpArrowImg, 2, 0);
            this.DPDisplayTableLayoutPnl.Controls.Add(this.FuturePreviewBox, 3, 0);
            this.DPDisplayTableLayoutPnl.Controls.Add(this.PastPreviewBox, 0, 0);
            this.DPDisplayTableLayoutPnl.Controls.Add(this.Past2PreviewBox, 1, 0);
            this.DPDisplayTableLayoutPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DPDisplayTableLayoutPnl.Location = new System.Drawing.Point(6, 93);
            this.DPDisplayTableLayoutPnl.Margin = new System.Windows.Forms.Padding(6);
            this.DPDisplayTableLayoutPnl.Name = "DPDisplayTableLayoutPnl";
            this.DPDisplayTableLayoutPnl.RowCount = 1;
            this.DPDisplayTableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DPDisplayTableLayoutPnl.Size = new System.Drawing.Size(1772, 251);
            this.DPDisplayTableLayoutPnl.TabIndex = 43;
            // 
            // UpArrowImg
            // 
            this.UpArrowImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpArrowImg.AutoSize = true;
            this.UpArrowImg.Font = Consts.headingLblFont;
            this.UpArrowImg.Location = new System.Drawing.Point(1070, 86);
            this.UpArrowImg.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.UpArrowImg.Name = "UpArrowImg";
            this.UpArrowImg.Size = new System.Drawing.Size(75, 78);
            this.UpArrowImg.TabIndex = 43;
            this.UpArrowImg.Text = "^";
            // 
            // DPControlsTableLayoutPnl
            // 
            this.DPControlsTableLayoutPnl.ColumnCount = 5;
            this.DPControlsTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.DPControlsTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.DPControlsTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.DPControlsTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.DPControlsTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.DPControlsTableLayoutPnl.Controls.Add(this.CurrentTimeLbl, 0, 0);
            this.DPControlsTableLayoutPnl.Controls.Add(this.CurrentTimeUpDown, 1, 0);
            this.DPControlsTableLayoutPnl.Controls.Add(this.BackBtn, 3, 0);
            this.DPControlsTableLayoutPnl.Controls.Add(this.ForwardBtn, 4, 0);
            this.DPControlsTableLayoutPnl.Controls.Add(this.VidLengthLbl, 2, 0);
            this.DPControlsTableLayoutPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DPControlsTableLayoutPnl.Location = new System.Drawing.Point(6, 6);
            this.DPControlsTableLayoutPnl.Margin = new System.Windows.Forms.Padding(6);
            this.DPControlsTableLayoutPnl.Name = "DPControlsTableLayoutPnl";
            this.DPControlsTableLayoutPnl.RowCount = 1;
            this.DPControlsTableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DPControlsTableLayoutPnl.Size = new System.Drawing.Size(1772, 75);
            this.DPControlsTableLayoutPnl.TabIndex = 43;
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // LoadingMessage
            // 
            this.LoadingMessage.Location = new System.Drawing.Point(1253, 285);
            this.LoadingMessage.Name = "LoadingMessage";
            this.LoadingMessage.Size = new System.Drawing.Size(500, 350);
            this.LoadingMessage.TabIndex = 43;
            this.LoadingMessage.Visible = false;
            // 
            // CompileTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.Controls.Add(this.LoadingMessage);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.DrawPanel);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.ToolStrip);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CompileTab";
            this.Size = new System.Drawing.Size(2226, 1131);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FuturePreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Past2PreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PastPreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).EndInit();
            this.DisplayPanel.ResumeLayout(false);
            this.DPDisplayTableLayoutPnl.ResumeLayout(false);
            this.DPDisplayTableLayoutPnl.PerformLayout();
            this.DPControlsTableLayoutPnl.ResumeLayout(false);
            this.DPControlsTableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton SaveBtn;
        private System.Windows.Forms.ToolStripButton AddSceneBtn;
        private System.Windows.Forms.ToolStripButton CloseBtn;
        private System.Windows.Forms.ToolStripButton SettingsBtn;
        private System.Windows.Forms.Label VidLengthLbl;
        private System.Windows.Forms.PictureBox FuturePreviewBox;
        private System.Windows.Forms.PictureBox Past2PreviewBox;
        private System.Windows.Forms.PictureBox PastPreviewBox;
        private System.Windows.Forms.Label CurrentTimeLbl;
        private System.Windows.Forms.NumericUpDown CurrentTimeUpDown;
        private System.Windows.Forms.Button ForwardBtn;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.PictureBox DrawPanel;
        private System.Windows.Forms.TableLayoutPanel DisplayPanel;
        private System.Windows.Forms.TableLayoutPanel DPControlsTableLayoutPnl;
        private System.Windows.Forms.TableLayoutPanel DPDisplayTableLayoutPnl;
        private Label UpArrowImg;
        private Timer AnimationTimer;
        private SoloTabs.LoadingMessage LoadingMessage;
    }
}
