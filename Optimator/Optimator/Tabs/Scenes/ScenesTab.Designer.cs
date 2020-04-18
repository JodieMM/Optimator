﻿using System.Windows.Forms;

namespace Optimator.Tabs.Scenes
{
    partial class ScenesTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScenesTab));
            this.Panel = new System.Windows.Forms.Panel();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.SaveBtn = new System.Windows.Forms.ToolStripButton();
            this.AddPartBtn = new System.Windows.Forms.ToolStripButton();
            this.CloseBtn = new System.Windows.Forms.ToolStripButton();
            this.PositionsBtn = new System.Windows.Forms.ToolStripButton();
            this.MoveBtn = new System.Windows.Forms.ToolStripButton();
            this.SettingsBtn = new System.Windows.Forms.ToolStripButton();
            this.VidLengthLbl = new System.Windows.Forms.Label();
            this.UpArrowImg = new System.Windows.Forms.Label();
            this.Future2PreviewBox = new System.Windows.Forms.PictureBox();
            this.FuturePreviewBox = new System.Windows.Forms.PictureBox();
            this.PastPreviewBox = new System.Windows.Forms.PictureBox();
            this.CurrentTimeLbl = new System.Windows.Forms.Label();
            this.CurrentTimeUpDown = new System.Windows.Forms.NumericUpDown();
            this.ForwardBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.DrawPanel = new System.Windows.Forms.PictureBox();
            this.DisplayPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DPControlsTableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.DPDisplayTableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Future2PreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuturePreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PastPreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).BeginInit();
            this.DisplayPanel.SuspendLayout();
            this.DPControlsTableLayoutPnl.SuspendLayout();
            this.DPDisplayTableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.LemonChiffon;
            this.Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel.Location = new System.Drawing.Point(892, 39);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(221, 549);
            this.Panel.TabIndex = 25;
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveBtn,
            this.AddPartBtn,
            this.CloseBtn,
            this.PositionsBtn,
            this.MoveBtn,
            this.SettingsBtn});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip.Size = new System.Drawing.Size(1113, 39);
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
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // AddPartBtn
            // 
            this.AddPartBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddPartBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddPartBtn.Image")));
            this.AddPartBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddPartBtn.Name = "AddPartBtn";
            this.AddPartBtn.Size = new System.Drawing.Size(36, 36);
            this.AddPartBtn.Text = "Add Part";
            this.AddPartBtn.Click += new System.EventHandler(this.AddPartBtn_Click);
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
            // PositionsBtn
            // 
            this.PositionsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PositionsBtn.Image = ((System.Drawing.Image)(resources.GetObject("PositionsBtn.Image")));
            this.PositionsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PositionsBtn.Name = "PositionsBtn";
            this.PositionsBtn.Size = new System.Drawing.Size(36, 36);
            this.PositionsBtn.Text = "Original Positions";
            this.PositionsBtn.Click += new System.EventHandler(this.PositionsBtn_Click);
            // 
            // MoveBtn
            // 
            this.MoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("MoveBtn.Image")));
            this.MoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveBtn.Name = "MoveBtn";
            this.MoveBtn.Size = new System.Drawing.Size(36, 36);
            this.MoveBtn.Text = "Movements";
            this.MoveBtn.Click += new System.EventHandler(this.MoveBtn_Click);
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("SettingsBtn.Image")));
            this.SettingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(36, 36);
            this.SettingsBtn.Text = "Settings";
            this.SettingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // VidLengthLbl
            // 
            this.VidLengthLbl.AutoSize = true;
            this.VidLengthLbl.Font = new System.Drawing.Font("Tahoma", 14F);
            this.VidLengthLbl.Location = new System.Drawing.Point(356, 0);
            this.VidLengthLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VidLengthLbl.Name = "VidLengthLbl";
            this.VidLengthLbl.Size = new System.Drawing.Size(151, 23);
            this.VidLengthLbl.TabIndex = 41;
            this.VidLengthLbl.Text = "Video Length: 0s";
            // 
            // UpArrowImg
            // 
            this.UpArrowImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpArrowImg.AutoSize = true;
            this.UpArrowImg.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpArrowImg.Location = new System.Drawing.Point(314, 49);
            this.UpArrowImg.Name = "UpArrowImg";
            this.UpArrowImg.Size = new System.Drawing.Size(35, 33);
            this.UpArrowImg.TabIndex = 40;
            this.UpArrowImg.Text = "^";
            // 
            // Future2PreviewBox
            // 
            this.Future2PreviewBox.BackColor = System.Drawing.Color.White;
            this.Future2PreviewBox.Location = new System.Drawing.Point(665, 2);
            this.Future2PreviewBox.Margin = new System.Windows.Forms.Padding(2);
            this.Future2PreviewBox.Name = "Future2PreviewBox";
            this.Future2PreviewBox.Size = new System.Drawing.Size(219, 127);
            this.Future2PreviewBox.TabIndex = 39;
            this.Future2PreviewBox.TabStop = false;
            // 
            // FuturePreviewBox
            // 
            this.FuturePreviewBox.BackColor = System.Drawing.Color.White;
            this.FuturePreviewBox.Location = new System.Drawing.Point(444, 2);
            this.FuturePreviewBox.Margin = new System.Windows.Forms.Padding(2);
            this.FuturePreviewBox.Name = "FuturePreviewBox";
            this.FuturePreviewBox.Size = new System.Drawing.Size(217, 127);
            this.FuturePreviewBox.TabIndex = 38;
            this.FuturePreviewBox.TabStop = false;
            // 
            // PastPreviewBox
            // 
            this.PastPreviewBox.BackColor = System.Drawing.Color.White;
            this.PastPreviewBox.Location = new System.Drawing.Point(2, 2);
            this.PastPreviewBox.Margin = new System.Windows.Forms.Padding(2);
            this.PastPreviewBox.Name = "PastPreviewBox";
            this.PastPreviewBox.Size = new System.Drawing.Size(217, 127);
            this.PastPreviewBox.TabIndex = 30;
            this.PastPreviewBox.TabStop = false;
            // 
            // CurrentTimeLbl
            // 
            this.CurrentTimeLbl.AutoSize = true;
            this.CurrentTimeLbl.Font = new System.Drawing.Font("Tahoma", 14F);
            this.CurrentTimeLbl.Location = new System.Drawing.Point(2, 0);
            this.CurrentTimeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentTimeLbl.Name = "CurrentTimeLbl";
            this.CurrentTimeLbl.Size = new System.Drawing.Size(120, 23);
            this.CurrentTimeLbl.TabIndex = 37;
            this.CurrentTimeLbl.Text = "Current Time";
            // 
            // CurrentTimeUpDown
            // 
            this.CurrentTimeUpDown.DecimalPlaces = 3;
            this.CurrentTimeUpDown.Font = new System.Drawing.Font("Tahoma", 14F);
            this.CurrentTimeUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.CurrentTimeUpDown.Location = new System.Drawing.Point(179, 2);
            this.CurrentTimeUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.CurrentTimeUpDown.Name = "CurrentTimeUpDown";
            this.CurrentTimeUpDown.Size = new System.Drawing.Size(125, 30);
            this.CurrentTimeUpDown.TabIndex = 37;
            this.CurrentTimeUpDown.ValueChanged += new System.EventHandler(this.CurrentTimeUpDown_ValueChanged);
            // 
            // ForwardBtn
            // 
            this.ForwardBtn.BackColor = System.Drawing.Color.Khaki;
            this.ForwardBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ForwardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForwardBtn.Font = new System.Drawing.Font("Tahoma", 14F);
            this.ForwardBtn.Location = new System.Drawing.Point(710, 2);
            this.ForwardBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ForwardBtn.Name = "ForwardBtn";
            this.ForwardBtn.Size = new System.Drawing.Size(174, 35);
            this.ForwardBtn.TabIndex = 19;
            this.ForwardBtn.Text = "Forward";
            this.ForwardBtn.UseVisualStyleBackColor = false;
            this.ForwardBtn.Click += new System.EventHandler(this.ForwardBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.Khaki;
            this.BackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Tahoma", 14F);
            this.BackBtn.Location = new System.Drawing.Point(533, 2);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(2);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(173, 35);
            this.BackBtn.TabIndex = 23;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // DrawPanel
            // 
            this.DrawPanel.BackColor = System.Drawing.Color.White;
            this.DrawPanel.Location = new System.Drawing.Point(58, 67);
            this.DrawPanel.Margin = new System.Windows.Forms.Padding(2);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(531, 281);
            this.DrawPanel.TabIndex = 31;
            this.DrawPanel.TabStop = false;
            this.DrawPanel.MouseDown += new MouseEventHandler(DrawPanel_MouseDown);
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.DisplayPanel.ColumnCount = 1;
            this.DisplayPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DisplayPanel.Controls.Add(this.DPDisplayTableLayoutPnl, 0, 1);
            this.DisplayPanel.Controls.Add(this.DPControlsTableLayoutPnl, 0, 0);
            this.DisplayPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DisplayPanel.Location = new System.Drawing.Point(0, 406);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.RowCount = 2;
            this.DisplayPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DisplayPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.DisplayPanel.Size = new System.Drawing.Size(892, 182);
            this.DisplayPanel.TabIndex = 42;
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
            this.DPControlsTableLayoutPnl.Location = new System.Drawing.Point(3, 3);
            this.DPControlsTableLayoutPnl.Name = "DPControlsTableLayoutPnl";
            this.DPControlsTableLayoutPnl.RowCount = 1;
            this.DPControlsTableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DPControlsTableLayoutPnl.Size = new System.Drawing.Size(886, 39);
            this.DPControlsTableLayoutPnl.TabIndex = 43;
            // 
            // DPDisplayTableLayoutPnl
            // 
            this.DPDisplayTableLayoutPnl.ColumnCount = 4;
            this.DPDisplayTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DPDisplayTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DPDisplayTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DPDisplayTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DPDisplayTableLayoutPnl.Controls.Add(this.Future2PreviewBox, 3, 0);
            this.DPDisplayTableLayoutPnl.Controls.Add(this.UpArrowImg, 1, 0);
            this.DPDisplayTableLayoutPnl.Controls.Add(this.FuturePreviewBox, 2, 0);
            this.DPDisplayTableLayoutPnl.Controls.Add(this.PastPreviewBox, 0, 0);
            this.DPDisplayTableLayoutPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DPDisplayTableLayoutPnl.Location = new System.Drawing.Point(3, 48);
            this.DPDisplayTableLayoutPnl.Name = "DPDisplayTableLayoutPnl";
            this.DPDisplayTableLayoutPnl.RowCount = 1;
            this.DPDisplayTableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DPDisplayTableLayoutPnl.Size = new System.Drawing.Size(886, 131);
            this.DPDisplayTableLayoutPnl.TabIndex = 43;
            // 
            // ScenesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.DrawPanel);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.ToolStrip);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ScenesTab";
            this.Size = new System.Drawing.Size(1113, 588);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Future2PreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuturePreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PastPreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).EndInit();
            this.DisplayPanel.ResumeLayout(false);
            this.DPControlsTableLayoutPnl.ResumeLayout(false);
            this.DPControlsTableLayoutPnl.PerformLayout();
            this.DPDisplayTableLayoutPnl.ResumeLayout(false);
            this.DPDisplayTableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton SaveBtn;
        private System.Windows.Forms.ToolStripButton AddPartBtn;
        private System.Windows.Forms.ToolStripButton CloseBtn;
        private System.Windows.Forms.ToolStripButton PositionsBtn;
        private System.Windows.Forms.ToolStripButton MoveBtn;
        private System.Windows.Forms.ToolStripButton SettingsBtn;
        private System.Windows.Forms.Label VidLengthLbl;
        private System.Windows.Forms.Label UpArrowImg;
        private System.Windows.Forms.PictureBox Future2PreviewBox;
        private System.Windows.Forms.PictureBox FuturePreviewBox;
        private System.Windows.Forms.PictureBox PastPreviewBox;
        private System.Windows.Forms.Label CurrentTimeLbl;
        private System.Windows.Forms.NumericUpDown CurrentTimeUpDown;
        private System.Windows.Forms.Button ForwardBtn;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.PictureBox DrawPanel;
        private System.Windows.Forms.TableLayoutPanel DisplayPanel;
        private System.Windows.Forms.TableLayoutPanel DPControlsTableLayoutPnl;
        private System.Windows.Forms.TableLayoutPanel DPDisplayTableLayoutPnl;
    }
}
