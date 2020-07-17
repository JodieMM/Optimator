using System.Windows.Forms;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScenesTab));
            this.Panel = new System.Windows.Forms.Panel();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.SaveBtn = new System.Windows.Forms.ToolStripButton();
            this.AddPartBtn = new System.Windows.Forms.ToolStripButton();
            this.CloseBtn = new System.Windows.Forms.ToolStripButton();
            this.PositionsBtn = new System.Windows.Forms.ToolStripButton();
            this.MoveBtn = new System.Windows.Forms.ToolStripButton();
            this.ReloadBtn = new System.Windows.Forms.ToolStripButton();
            this.SettingsBtn = new System.Windows.Forms.ToolStripButton();
            this.VidLengthLbl = new System.Windows.Forms.Label();
            this.CurrentTimeLbl = new System.Windows.Forms.Label();
            this.CurrentTimeUpDown = new System.Windows.Forms.NumericUpDown();
            this.DrawPanel = new System.Windows.Forms.PictureBox();
            this.DisplayPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DPControlsTableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.SnipBtn = new System.Windows.Forms.Button();
            this.TimeTrackBar = new System.Windows.Forms.TrackBar();
            this.DrawPanelContainer = new System.Windows.Forms.Panel();
            this.DisplayTimer = new System.Windows.Forms.Timer(this.components);
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).BeginInit();
            this.DisplayPanel.SuspendLayout();
            this.DPControlsTableLayoutPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeTrackBar)).BeginInit();
            this.DrawPanelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.LemonChiffon;
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
            this.AddPartBtn,
            this.CloseBtn,
            this.PositionsBtn,
            this.MoveBtn,
            this.ReloadBtn,
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
            // AddPartBtn
            // 
            this.AddPartBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddPartBtn.Image = global::Optimator.Properties.Resources.AddPartIcon;
            this.AddPartBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddPartBtn.Name = "AddPartBtn";
            this.AddPartBtn.Size = new System.Drawing.Size(36, 36);
            this.AddPartBtn.Text = "Add Part";
            this.AddPartBtn.Click += new System.EventHandler(this.BtnWithPanel_Click);
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
            // PositionsBtn
            // 
            this.PositionsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PositionsBtn.Image = ((System.Drawing.Image)(resources.GetObject("PositionsBtn.Image")));
            this.PositionsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PositionsBtn.Name = "PositionsBtn";
            this.PositionsBtn.Size = new System.Drawing.Size(36, 36);
            this.PositionsBtn.Text = "Original Positions";
            this.PositionsBtn.Click += new System.EventHandler(this.BtnWithPanel_Click);
            // 
            // MoveBtn
            // 
            this.MoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("MoveBtn.Image")));
            this.MoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveBtn.Name = "MoveBtn";
            this.MoveBtn.Size = new System.Drawing.Size(36, 36);
            this.MoveBtn.Text = "Animations";
            this.MoveBtn.Click += new System.EventHandler(this.BtnWithPanel_Click);
            // 
            // ReloadBtn
            // 
            this.ReloadBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReloadBtn.Image = global::Optimator.Properties.Resources.Refresh01;
            this.ReloadBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReloadBtn.Name = "ReloadBtn";
            this.ReloadBtn.Size = new System.Drawing.Size(36, 36);
            this.ReloadBtn.Text = "Reload";
            this.ReloadBtn.Click += new System.EventHandler(this.ReloadBtn_Click);
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingsBtn.Image = global::Optimator.Properties.Resources.SettingsIcon;
            this.SettingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(36, 36);
            this.SettingsBtn.Text = "Settings";
            this.SettingsBtn.Click += new System.EventHandler(this.BtnWithPanel_Click);
            // 
            // VidLengthLbl
            // 
            this.VidLengthLbl.AutoSize = true;
            this.VidLengthLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VidLengthLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.VidLengthLbl.Location = new System.Drawing.Point(978, 0);
            this.VidLengthLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VidLengthLbl.Name = "VidLengthLbl";
            this.VidLengthLbl.Size = new System.Drawing.Size(612, 126);
            this.VidLengthLbl.TabIndex = 41;
            this.VidLengthLbl.Text = "Video Length: 0s";
            // 
            // CurrentTimeLbl
            // 
            this.CurrentTimeLbl.AutoSize = true;
            this.CurrentTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentTimeLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.CurrentTimeLbl.Location = new System.Drawing.Point(4, 0);
            this.CurrentTimeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentTimeLbl.Name = "CurrentTimeLbl";
            this.CurrentTimeLbl.Size = new System.Drawing.Size(346, 126);
            this.CurrentTimeLbl.TabIndex = 37;
            this.CurrentTimeLbl.Text = "Current Time";
            // 
            // CurrentTimeUpDown
            // 
            this.CurrentTimeUpDown.DecimalPlaces = 3;
            this.CurrentTimeUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentTimeUpDown.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.CurrentTimeUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.CurrentTimeUpDown.Location = new System.Drawing.Point(354, 0);
            this.CurrentTimeUpDown.Margin = new System.Windows.Forms.Padding(0);
            this.CurrentTimeUpDown.Name = "CurrentTimeUpDown";
            this.CurrentTimeUpDown.Size = new System.Drawing.Size(620, 64);
            this.CurrentTimeUpDown.TabIndex = 37;
            this.CurrentTimeUpDown.ValueChanged += new System.EventHandler(this.UpdateCurrentTime);
            // 
            // DrawPanel
            // 
            this.DrawPanel.Location = new System.Drawing.Point(30, 30);
            this.DrawPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(800, 530);
            this.DrawPanel.TabIndex = 31;
            this.DrawPanel.TabStop = false;
            this.DrawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseDown);
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.DisplayPanel.ColumnCount = 1;
            this.DisplayPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DisplayPanel.Controls.Add(this.DPControlsTableLayoutPnl, 0, 0);
            this.DisplayPanel.Controls.Add(this.TimeTrackBar, 0, 1);
            this.DisplayPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DisplayPanel.Location = new System.Drawing.Point(0, 933);
            this.DisplayPanel.Margin = new System.Windows.Forms.Padding(6);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.RowCount = 2;
            this.DisplayPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.DisplayPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.DisplayPanel.Size = new System.Drawing.Size(1784, 198);
            this.DisplayPanel.TabIndex = 42;
            // 
            // DPControlsTableLayoutPnl
            // 
            this.DPControlsTableLayoutPnl.ColumnCount = 4;
            this.DPControlsTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.DPControlsTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.DPControlsTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.DPControlsTableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.DPControlsTableLayoutPnl.Controls.Add(this.VidLengthLbl, 2, 0);
            this.DPControlsTableLayoutPnl.Controls.Add(this.CurrentTimeUpDown, 1, 0);
            this.DPControlsTableLayoutPnl.Controls.Add(this.CurrentTimeLbl, 0, 0);
            this.DPControlsTableLayoutPnl.Controls.Add(this.SnipBtn, 3, 0);
            this.DPControlsTableLayoutPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DPControlsTableLayoutPnl.Location = new System.Drawing.Point(6, 6);
            this.DPControlsTableLayoutPnl.Margin = new System.Windows.Forms.Padding(6);
            this.DPControlsTableLayoutPnl.Name = "DPControlsTableLayoutPnl";
            this.DPControlsTableLayoutPnl.RowCount = 1;
            this.DPControlsTableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DPControlsTableLayoutPnl.Size = new System.Drawing.Size(1772, 126);
            this.DPControlsTableLayoutPnl.TabIndex = 43;
            // 
            // SnipBtn
            // 
            this.SnipBtn.BackgroundImage = global::Optimator.Properties.Resources.SnipIcon;
            this.SnipBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SnipBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SnipBtn.FlatAppearance.BorderColor = System.Drawing.Color.PaleGoldenrod;
            this.SnipBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SnipBtn.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SnipBtn.Location = new System.Drawing.Point(1594, 0);
            this.SnipBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SnipBtn.Name = "SnipBtn";
            this.SnipBtn.Size = new System.Drawing.Size(178, 126);
            this.SnipBtn.TabIndex = 42;
            this.SnipBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.SnipBtn.UseVisualStyleBackColor = true;
            this.SnipBtn.Click += new System.EventHandler(this.SnipBtn_Click);
            // 
            // TimeTrackBar
            // 
            this.TimeTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeTrackBar.Location = new System.Drawing.Point(50, 138);
            this.TimeTrackBar.Margin = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.TimeTrackBar.Maximum = 5;
            this.TimeTrackBar.Name = "TimeTrackBar";
            this.TimeTrackBar.Size = new System.Drawing.Size(1684, 60);
            this.TimeTrackBar.TabIndex = 44;
            this.TimeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TimeTrackBar.Scroll += new System.EventHandler(this.UpdateCurrentTime);
            // 
            // DrawPanelContainer
            // 
            this.DrawPanelContainer.AutoScroll = true;
            this.DrawPanelContainer.AutoScrollMargin = new System.Drawing.Size(15, 15);
            this.DrawPanelContainer.Controls.Add(this.DrawPanel);
            this.DrawPanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawPanelContainer.Location = new System.Drawing.Point(0, 39);
            this.DrawPanelContainer.Margin = new System.Windows.Forms.Padding(0);
            this.DrawPanelContainer.Name = "DrawPanelContainer";
            this.DrawPanelContainer.Size = new System.Drawing.Size(1784, 894);
            this.DrawPanelContainer.TabIndex = 43;
            this.DrawPanelContainer.Scroll += new System.Windows.Forms.ScrollEventHandler(this.FocusOn);
            this.DrawPanelContainer.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FocusOn);
            // 
            // DisplayTimer
            // 
            this.DisplayTimer.Interval = 5;
            this.DisplayTimer.Tick += new System.EventHandler(this.DisplayTimer_Tick);
            // 
            // ScenesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.Controls.Add(this.DrawPanelContainer);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.ToolStrip);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScenesTab";
            this.Size = new System.Drawing.Size(2226, 1131);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).EndInit();
            this.DisplayPanel.ResumeLayout(false);
            this.DisplayPanel.PerformLayout();
            this.DPControlsTableLayoutPnl.ResumeLayout(false);
            this.DPControlsTableLayoutPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeTrackBar)).EndInit();
            this.DrawPanelContainer.ResumeLayout(false);
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
        private System.Windows.Forms.Label CurrentTimeLbl;
        private System.Windows.Forms.NumericUpDown CurrentTimeUpDown;
        private System.Windows.Forms.PictureBox DrawPanel;
        private System.Windows.Forms.TableLayoutPanel DisplayPanel;
        private System.Windows.Forms.TableLayoutPanel DPControlsTableLayoutPnl;
        private TrackBar TimeTrackBar;
        private Panel DrawPanelContainer;
        private Timer DisplayTimer;
        private Button SnipBtn;
        private ToolStripButton ReloadBtn;
    }
}
