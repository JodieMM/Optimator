namespace Optimator.Forms
{
    partial class SettingsTab
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
            this.NewWorkingDirectoryBtn = new System.Windows.Forms.Button();
            this.WorkingDirValueLbl = new System.Windows.Forms.Label();
            this.WorkingDirLbl = new System.Windows.Forms.Label();
            this.SettingsLbl = new System.Windows.Forms.Label();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.BackColourBox = new System.Windows.Forms.PictureBox();
            this.BackColourLbl = new System.Windows.Forms.Label();
            this.VersionLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.SaveVideoFramesCb = new System.Windows.Forms.CheckBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackColourBox)).BeginInit();
            this.TableLayoutPnl.SuspendLayout();
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
            // NewWorkingDirectoryBtn
            // 
            this.NewWorkingDirectoryBtn.AutoSize = true;
            this.NewWorkingDirectoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.NewWorkingDirectoryBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewWorkingDirectoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewWorkingDirectoryBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.NewWorkingDirectoryBtn.ForeColor = System.Drawing.Color.Black;
            this.NewWorkingDirectoryBtn.Location = new System.Drawing.Point(585, 189);
            this.NewWorkingDirectoryBtn.Margin = new System.Windows.Forms.Padding(0);
            this.NewWorkingDirectoryBtn.Name = "NewWorkingDirectoryBtn";
            this.NewWorkingDirectoryBtn.Size = new System.Drawing.Size(585, 189);
            this.NewWorkingDirectoryBtn.TabIndex = 132;
            this.NewWorkingDirectoryBtn.Text = "Find New";
            this.NewWorkingDirectoryBtn.UseVisualStyleBackColor = false;
            this.NewWorkingDirectoryBtn.Click += new System.EventHandler(this.NewWorkingDirectoryBtn_Click);
            // 
            // WorkingDirValueLbl
            // 
            this.WorkingDirValueLbl.AutoSize = true;
            this.TableLayoutPnl.SetColumnSpan(this.WorkingDirValueLbl, 2);
            this.WorkingDirValueLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingDirValueLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.WorkingDirValueLbl.Location = new System.Drawing.Point(4, 0);
            this.WorkingDirValueLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WorkingDirValueLbl.Name = "WorkingDirValueLbl";
            this.WorkingDirValueLbl.Size = new System.Drawing.Size(1162, 189);
            this.WorkingDirValueLbl.TabIndex = 131;
            this.WorkingDirValueLbl.Text = "Current Directory";
            // 
            // WorkingDirLbl
            // 
            this.WorkingDirLbl.AutoSize = true;
            this.WorkingDirLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingDirLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.WorkingDirLbl.Location = new System.Drawing.Point(4, 189);
            this.WorkingDirLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WorkingDirLbl.Name = "WorkingDirLbl";
            this.WorkingDirLbl.Size = new System.Drawing.Size(577, 189);
            this.WorkingDirLbl.TabIndex = 130;
            this.WorkingDirLbl.Text = "Working Directory";
            // 
            // SettingsLbl
            // 
            this.SettingsLbl.AutoSize = true;
            this.SettingsLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.SettingsLbl.Location = new System.Drawing.Point(46, 104);
            this.SettingsLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SettingsLbl.Name = "SettingsLbl";
            this.SettingsLbl.Size = new System.Drawing.Size(236, 72);
            this.SettingsLbl.TabIndex = 129;
            this.SettingsLbl.Text = "Settings";
            // 
            // ResetBtn
            // 
            this.ResetBtn.AutoSize = true;
            this.ResetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ResetBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.ResetBtn.ForeColor = System.Drawing.Color.Black;
            this.ResetBtn.Location = new System.Drawing.Point(585, 756);
            this.ResetBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(585, 190);
            this.ResetBtn.TabIndex = 128;
            this.ResetBtn.Text = "Reset to Defaults\r\n";
            this.ResetBtn.UseVisualStyleBackColor = false;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // BackColourBox
            // 
            this.BackColourBox.BackColor = System.Drawing.Color.White;
            this.BackColourBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackColourBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackColourBox.Location = new System.Drawing.Point(589, 382);
            this.BackColourBox.Margin = new System.Windows.Forms.Padding(4);
            this.BackColourBox.Name = "BackColourBox";
            this.BackColourBox.Size = new System.Drawing.Size(577, 181);
            this.BackColourBox.TabIndex = 127;
            this.BackColourBox.TabStop = false;
            this.BackColourBox.Click += new System.EventHandler(this.BackColourBox_Click);
            // 
            // BackColourLbl
            // 
            this.BackColourLbl.AutoSize = true;
            this.BackColourLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackColourLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.BackColourLbl.Location = new System.Drawing.Point(2, 378);
            this.BackColourLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BackColourLbl.Name = "BackColourLbl";
            this.BackColourLbl.Size = new System.Drawing.Size(581, 189);
            this.BackColourLbl.TabIndex = 126;
            this.BackColourLbl.Text = "Drawing Board Back Colour";
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
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.AutoScroll = true;
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Controls.Add(this.SaveVideoFramesCb, 0, 3);
            this.TableLayoutPnl.Controls.Add(this.NewWorkingDirectoryBtn, 1, 1);
            this.TableLayoutPnl.Controls.Add(this.WorkingDirValueLbl, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.WorkingDirLbl, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.BackColourLbl, 0, 2);
            this.TableLayoutPnl.Controls.Add(this.BackColourBox, 1, 2);
            this.TableLayoutPnl.Controls.Add(this.ResetBtn, 1, 4);
            this.TableLayoutPnl.Controls.Add(this.SaveBtn, 0, 4);
            this.TableLayoutPnl.Location = new System.Drawing.Point(60, 309);
            this.TableLayoutPnl.Margin = new System.Windows.Forms.Padding(6);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 5;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(1204, 596);
            this.TableLayoutPnl.TabIndex = 133;
            // 
            // SaveVideoFramesCb
            // 
            this.SaveVideoFramesCb.AutoSize = true;
            this.TableLayoutPnl.SetColumnSpan(this.SaveVideoFramesCb, 2);
            this.SaveVideoFramesCb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveVideoFramesCb.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SaveVideoFramesCb.Location = new System.Drawing.Point(3, 570);
            this.SaveVideoFramesCb.Name = "SaveVideoFramesCb";
            this.SaveVideoFramesCb.Size = new System.Drawing.Size(1164, 183);
            this.SaveVideoFramesCb.TabIndex = 134;
            this.SaveVideoFramesCb.Text = "Save Video Frames on Export";
            this.SaveVideoFramesCb.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            this.SaveBtn.AutoSize = true;
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SaveBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SaveBtn.ForeColor = System.Drawing.Color.Black;
            this.SaveBtn.Location = new System.Drawing.Point(0, 756);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(585, 190);
            this.SaveBtn.TabIndex = 125;
            this.SaveBtn.Text = "Save Changes\r\n";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SettingsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.SettingsLbl);
            this.Controls.Add(this.VersionLbl);
            this.Controls.Add(this.ToolStrip);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsTab";
            this.Size = new System.Drawing.Size(1314, 1031);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackColourBox)).EndInit();
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton CloseBtn;
        private System.Windows.Forms.Button NewWorkingDirectoryBtn;
        private System.Windows.Forms.Label WorkingDirValueLbl;
        private System.Windows.Forms.Label WorkingDirLbl;
        private System.Windows.Forms.Label SettingsLbl;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.PictureBox BackColourBox;
        private System.Windows.Forms.Label BackColourLbl;
        private System.Windows.Forms.Label VersionLbl;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.CheckBox SaveVideoFramesCb;
    }
}
