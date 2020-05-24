namespace Optimator.Tabs.Compile
{
    partial class SettingsPanel
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
            this.SettingsLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.FpsUpDown = new System.Windows.Forms.NumericUpDown();
            this.FpsLbl = new System.Windows.Forms.Label();
            this.VideoWidthLbl = new System.Windows.Forms.Label();
            this.VideoHeightLbl = new System.Windows.Forms.Label();
            this.VideoWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.VideoHeightUpDown = new System.Windows.Forms.NumericUpDown();
            this.TableLayoutPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FpsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoWidthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoHeightUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsLbl
            // 
            this.SettingsLbl.AutoSize = true;
            this.SettingsLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.SettingsLbl.Location = new System.Drawing.Point(34, 44);
            this.SettingsLbl.Name = "SettingsLbl";
            this.SettingsLbl.Size = new System.Drawing.Size(236, 72);
            this.SettingsLbl.TabIndex = 0;
            this.SettingsLbl.Text = "Settings";
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayoutPnl.Controls.Add(this.VideoHeightUpDown, 1, 2);
            this.TableLayoutPnl.Controls.Add(this.VideoWidthUpDown, 1, 1);
            this.TableLayoutPnl.Controls.Add(this.FpsUpDown, 1, 0);
            this.TableLayoutPnl.Controls.Add(this.FpsLbl, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.VideoWidthLbl, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.VideoHeightLbl, 0, 2);
            this.TableLayoutPnl.Location = new System.Drawing.Point(44, 182);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 3;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(818, 226);
            this.TableLayoutPnl.TabIndex = 124;
            // 
            // FpsUpDown
            // 
            this.FpsUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FpsUpDown.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.FpsUpDown.Location = new System.Drawing.Point(492, 2);
            this.FpsUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.FpsUpDown.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.FpsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FpsUpDown.Name = "FpsUpDown";
            this.FpsUpDown.Size = new System.Drawing.Size(324, 64);
            this.FpsUpDown.TabIndex = 125;
            this.FpsUpDown.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.FpsUpDown.ValueChanged += new System.EventHandler(this.FpsUpDown_ValueChanged);
            // 
            // FpsLbl
            // 
            this.FpsLbl.AutoSize = true;
            this.FpsLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.FpsLbl.Location = new System.Drawing.Point(2, 0);
            this.FpsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FpsLbl.Name = "FpsLbl";
            this.FpsLbl.Size = new System.Drawing.Size(382, 59);
            this.FpsLbl.TabIndex = 126;
            this.FpsLbl.Text = "Frames Per Second";
            // 
            // VideoWidthLbl
            // 
            this.VideoWidthLbl.AutoSize = true;
            this.VideoWidthLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.VideoWidthLbl.Location = new System.Drawing.Point(2, 75);
            this.VideoWidthLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VideoWidthLbl.Name = "VideoWidthLbl";
            this.VideoWidthLbl.Size = new System.Drawing.Size(260, 59);
            this.VideoWidthLbl.TabIndex = 127;
            this.VideoWidthLbl.Text = "Video Width";
            // 
            // VideoHeightLbl
            // 
            this.VideoHeightLbl.AutoSize = true;
            this.VideoHeightLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.VideoHeightLbl.Location = new System.Drawing.Point(2, 150);
            this.VideoHeightLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VideoHeightLbl.Name = "VideoHeightLbl";
            this.VideoHeightLbl.Size = new System.Drawing.Size(273, 59);
            this.VideoHeightLbl.TabIndex = 128;
            this.VideoHeightLbl.Text = "Video Height";
            // 
            // VideoWidthUpDown
            // 
            this.VideoWidthUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoWidthUpDown.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.VideoWidthUpDown.Location = new System.Drawing.Point(492, 77);
            this.VideoWidthUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.VideoWidthUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.VideoWidthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VideoWidthUpDown.Name = "VideoWidthUpDown";
            this.VideoWidthUpDown.Size = new System.Drawing.Size(324, 64);
            this.VideoWidthUpDown.TabIndex = 127;
            this.VideoWidthUpDown.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.VideoWidthUpDown.ValueChanged += new System.EventHandler(this.VideoWidthUpDown_ValueChanged);
            // 
            // VideoHeightUpDown
            // 
            this.VideoHeightUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoHeightUpDown.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.VideoHeightUpDown.Location = new System.Drawing.Point(492, 152);
            this.VideoHeightUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.VideoHeightUpDown.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.VideoHeightUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VideoHeightUpDown.Name = "VideoHeightUpDown";
            this.VideoHeightUpDown.Size = new System.Drawing.Size(324, 64);
            this.VideoHeightUpDown.TabIndex = 129;
            this.VideoHeightUpDown.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.VideoHeightUpDown.ValueChanged += new System.EventHandler(this.VideoHeightUpDown_ValueChanged);
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.SettingsLbl);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(908, 992);
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FpsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoWidthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoHeightUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SettingsLbl;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.NumericUpDown FpsUpDown;
        private System.Windows.Forms.Label FpsLbl;
        private System.Windows.Forms.Label VideoWidthLbl;
        private System.Windows.Forms.Label VideoHeightLbl;
        private System.Windows.Forms.NumericUpDown VideoHeightUpDown;
        private System.Windows.Forms.NumericUpDown VideoWidthUpDown;
    }
}
