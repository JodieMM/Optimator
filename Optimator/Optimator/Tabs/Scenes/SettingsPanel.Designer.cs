namespace Optimator.Tabs.Scenes
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
            this.SelectFromTopCb = new System.Windows.Forms.CheckBox();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.BgColourBox = new System.Windows.Forms.PictureBox();
            this.SceneBgLbl = new System.Windows.Forms.Label();
            this.SceneSizeMsgLbl = new System.Windows.Forms.Label();
            this.SceneHeightUpDown = new System.Windows.Forms.NumericUpDown();
            this.SceneWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.SceneHeightLbl = new System.Windows.Forms.Label();
            this.SceneWidthLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BgColourBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SceneHeightUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SceneWidthUpDown)).BeginInit();
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
            // SelectFromTopCb
            // 
            this.SelectFromTopCb.AutoSize = true;
            this.SelectFromTopCb.Checked = true;
            this.SelectFromTopCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TableLayoutPnl.SetColumnSpan(this.SelectFromTopCb, 2);
            this.SelectFromTopCb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectFromTopCb.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SelectFromTopCb.Location = new System.Drawing.Point(2, 2);
            this.SelectFromTopCb.Margin = new System.Windows.Forms.Padding(2);
            this.SelectFromTopCb.Name = "SelectFromTopCb";
            this.SelectFromTopCb.Size = new System.Drawing.Size(814, 87);
            this.SelectFromTopCb.TabIndex = 123;
            this.SelectFromTopCb.Text = "Select Part from Top";
            this.SelectFromTopCb.UseVisualStyleBackColor = true;
            this.SelectFromTopCb.CheckedChanged += new System.EventHandler(this.SelectFromTopCb_CheckedChanged);
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayoutPnl.Controls.Add(this.BgColourBox, 1, 1);
            this.TableLayoutPnl.Controls.Add(this.SceneBgLbl, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.SceneSizeMsgLbl, 0, 4);
            this.TableLayoutPnl.Controls.Add(this.SceneHeightUpDown, 1, 3);
            this.TableLayoutPnl.Controls.Add(this.SceneWidthUpDown, 1, 2);
            this.TableLayoutPnl.Controls.Add(this.SceneHeightLbl, 0, 3);
            this.TableLayoutPnl.Controls.Add(this.SelectFromTopCb, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.SceneWidthLbl, 0, 2);
            this.TableLayoutPnl.Location = new System.Drawing.Point(44, 182);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 5;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(818, 608);
            this.TableLayoutPnl.TabIndex = 124;
            // 
            // BgColourBox
            // 
            this.BgColourBox.BackColor = System.Drawing.Color.White;
            this.BgColourBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BgColourBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BgColourBox.Location = new System.Drawing.Point(494, 95);
            this.BgColourBox.Margin = new System.Windows.Forms.Padding(4);
            this.BgColourBox.Name = "BgColourBox";
            this.BgColourBox.Size = new System.Drawing.Size(320, 83);
            this.BgColourBox.TabIndex = 128;
            this.BgColourBox.TabStop = false;
            this.BgColourBox.Click += new System.EventHandler(this.BgColourBox_Click);
            // 
            // SceneBgLbl
            // 
            this.SceneBgLbl.AutoSize = true;
            this.SceneBgLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneBgLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SceneBgLbl.Location = new System.Drawing.Point(3, 91);
            this.SceneBgLbl.Name = "SceneBgLbl";
            this.SceneBgLbl.Size = new System.Drawing.Size(484, 91);
            this.SceneBgLbl.TabIndex = 126;
            this.SceneBgLbl.Text = "Scene Background";
            // 
            // SceneSizeMsgLbl
            // 
            this.SceneSizeMsgLbl.AutoSize = true;
            this.TableLayoutPnl.SetColumnSpan(this.SceneSizeMsgLbl, 2);
            this.SceneSizeMsgLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneSizeMsgLbl.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SceneSizeMsgLbl.Location = new System.Drawing.Point(3, 364);
            this.SceneSizeMsgLbl.Name = "SceneSizeMsgLbl";
            this.SceneSizeMsgLbl.Size = new System.Drawing.Size(812, 244);
            this.SceneSizeMsgLbl.TabIndex = 129;
            this.SceneSizeMsgLbl.Text = "* The width and height of the scene will be overridden by the video size if the t" +
    "wo are different\r\n";
            // 
            // SceneHeightUpDown
            // 
            this.SceneHeightUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneHeightUpDown.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SceneHeightUpDown.Location = new System.Drawing.Point(493, 276);
            this.SceneHeightUpDown.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.SceneHeightUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SceneHeightUpDown.Name = "SceneHeightUpDown";
            this.SceneHeightUpDown.Size = new System.Drawing.Size(322, 64);
            this.SceneHeightUpDown.TabIndex = 128;
            this.SceneHeightUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SceneHeightUpDown.ValueChanged += new System.EventHandler(this.SceneSizeUpDown_ValueChanged);
            // 
            // SceneWidthUpDown
            // 
            this.SceneWidthUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneWidthUpDown.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SceneWidthUpDown.Location = new System.Drawing.Point(493, 185);
            this.SceneWidthUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.SceneWidthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SceneWidthUpDown.Name = "SceneWidthUpDown";
            this.SceneWidthUpDown.Size = new System.Drawing.Size(322, 64);
            this.SceneWidthUpDown.TabIndex = 126;
            this.SceneWidthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SceneWidthUpDown.ValueChanged += new System.EventHandler(this.SceneSizeUpDown_ValueChanged);
            // 
            // SceneHeightLbl
            // 
            this.SceneHeightLbl.AutoSize = true;
            this.SceneHeightLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneHeightLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SceneHeightLbl.Location = new System.Drawing.Point(3, 273);
            this.SceneHeightLbl.Name = "SceneHeightLbl";
            this.SceneHeightLbl.Size = new System.Drawing.Size(484, 91);
            this.SceneHeightLbl.TabIndex = 127;
            this.SceneHeightLbl.Text = "Scene Height*";
            // 
            // SceneWidthLbl
            // 
            this.SceneWidthLbl.AutoSize = true;
            this.SceneWidthLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneWidthLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SceneWidthLbl.Location = new System.Drawing.Point(3, 182);
            this.SceneWidthLbl.Name = "SceneWidthLbl";
            this.SceneWidthLbl.Size = new System.Drawing.Size(484, 91);
            this.SceneWidthLbl.TabIndex = 125;
            this.SceneWidthLbl.Text = "Scene Width*";
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
            ((System.ComponentModel.ISupportInitialize)(this.BgColourBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SceneHeightUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SceneWidthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SettingsLbl;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.CheckBox SelectFromTopCb;
        private System.Windows.Forms.NumericUpDown SceneHeightUpDown;
        private System.Windows.Forms.NumericUpDown SceneWidthUpDown;
        private System.Windows.Forms.Label SceneHeightLbl;
        private System.Windows.Forms.Label SceneWidthLbl;
        private System.Windows.Forms.Label SceneSizeMsgLbl;
        private System.Windows.Forms.Label SceneBgLbl;
        private System.Windows.Forms.PictureBox BgColourBox;
    }
}
