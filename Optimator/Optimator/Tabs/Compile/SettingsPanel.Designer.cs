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
            this.PreviewCb = new System.Windows.Forms.CheckBox();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.FpsUpDown = new System.Windows.Forms.NumericUpDown();
            this.FpsLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FpsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsLbl
            // 
            this.SettingsLbl.AutoSize = true;
            this.SettingsLbl.Font = Consts.headingLblFont;
            this.SettingsLbl.Location = new System.Drawing.Point(34, 44);
            this.SettingsLbl.Name = "SettingsLbl";
            this.SettingsLbl.Size = new System.Drawing.Size(234, 71);
            this.SettingsLbl.TabIndex = 0;
            this.SettingsLbl.Text = "Settings";
            // 
            // PreviewCb
            // 
            this.PreviewCb.AutoSize = true;
            this.PreviewCb.Checked = true;
            this.PreviewCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TableLayoutPnl.SetColumnSpan(this.PreviewCb, 2);
            this.PreviewCb.Font = Consts.contentFont;
            this.PreviewCb.Location = new System.Drawing.Point(3, 116);
            this.PreviewCb.Name = "PreviewCb";
            this.PreviewCb.Size = new System.Drawing.Size(317, 63);
            this.PreviewCb.TabIndex = 120;
            this.PreviewCb.Text = "Show Preview";
            this.PreviewCb.UseVisualStyleBackColor = true;
            this.PreviewCb.CheckedChanged += new System.EventHandler(this.PreviewCb_CheckedChanged);
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayoutPnl.Controls.Add(this.FpsUpDown, 1, 0);
            this.TableLayoutPnl.Controls.Add(this.FpsLbl, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.PreviewCb, 0, 1);
            this.TableLayoutPnl.Location = new System.Drawing.Point(44, 182);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 2;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(818, 226);
            this.TableLayoutPnl.TabIndex = 124;
            // 
            // FpsUpDown
            // 
            this.FpsUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FpsUpDown.Font = Consts.contentFont;
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
            this.FpsUpDown.Size = new System.Drawing.Size(324, 65);
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
            this.FpsLbl.Font = Consts.contentFont;
            this.FpsLbl.Location = new System.Drawing.Point(2, 0);
            this.FpsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FpsLbl.Name = "FpsLbl";
            this.FpsLbl.Size = new System.Drawing.Size(382, 59);
            this.FpsLbl.TabIndex = 126;
            this.FpsLbl.Text = "Frames Per Second";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SettingsLbl;
        private System.Windows.Forms.CheckBox PreviewCb;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.NumericUpDown FpsUpDown;
        private System.Windows.Forms.Label FpsLbl;
    }
}
