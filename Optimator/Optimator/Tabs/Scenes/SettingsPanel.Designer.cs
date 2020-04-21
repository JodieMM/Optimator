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
            this.TimeIntervalLbl = new System.Windows.Forms.Label();
            this.TimeIncrementUpDown = new System.Windows.Forms.NumericUpDown();
            this.PreviewCb = new System.Windows.Forms.CheckBox();
            this.SelectFromTopCb = new System.Windows.Forms.CheckBox();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.TimeIncrementUpDown)).BeginInit();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsLbl
            // 
            this.SettingsLbl.AutoSize = true;
            this.SettingsLbl.Font = Consts.headingLblFont;
            this.SettingsLbl.Location = new System.Drawing.Point(34, 44);
            this.SettingsLbl.Name = "SettingsLb";
            this.SettingsLbl.Size = new System.Drawing.Size(224, 58);
            this.SettingsLbl.TabIndex = 0;
            this.SettingsLbl.Text = "Settings";
            // 
            // TimeIntervalLbl
            // 
            this.TimeIntervalLbl.AutoSize = true;
            this.TimeIntervalLbl.Font = Consts.contentFont;
            this.TimeIntervalLbl.Location = new System.Drawing.Point(3, 150);
            this.TimeIntervalLbl.Name = "TimeIntervalLbl";
            this.TimeIntervalLbl.Size = new System.Drawing.Size(383, 46);
            this.TimeIntervalLbl.TabIndex = 122;
            this.TimeIntervalLbl.Text = "Preview Time Gap (s)";
            // 
            // TimeIncrementUpDown
            // 
            this.TimeIncrementUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeIncrementUpDown.DecimalPlaces = 1;
            this.TimeIncrementUpDown.Font = Consts.contentFont;
            this.TimeIncrementUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.TimeIncrementUpDown.Location = new System.Drawing.Point(493, 153);
            this.TimeIncrementUpDown.Name = "TimeIncrementUpDown";
            this.TimeIncrementUpDown.Size = new System.Drawing.Size(322, 53);
            this.TimeIncrementUpDown.TabIndex = 121;
            this.TimeIncrementUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.TimeIncrementUpDown.ValueChanged += new System.EventHandler(this.TimeIncrementUpDown_ValueChanged);
            // 
            // PreviewCb
            // 
            this.PreviewCb.AutoSize = true;
            this.PreviewCb.Checked = true;
            this.PreviewCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TableLayoutPnl.SetColumnSpan(this.PreviewCb, 2);
            this.PreviewCb.Font = Consts.contentFont;
            this.PreviewCb.Location = new System.Drawing.Point(3, 78);
            this.PreviewCb.Name = "PreviewCb";
            this.PreviewCb.Size = new System.Drawing.Size(286, 50);
            this.PreviewCb.TabIndex = 120;
            this.PreviewCb.Text = "Show Preview";
            this.PreviewCb.UseVisualStyleBackColor = true;
            this.PreviewCb.CheckedChanged += new System.EventHandler(this.PreviewCb_CheckedChanged);
            // 
            // SelectFromTopCb
            // 
            this.SelectFromTopCb.AutoSize = true;
            this.SelectFromTopCb.Checked = true;
            this.SelectFromTopCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TableLayoutPnl.SetColumnSpan(this.SelectFromTopCb, 2);
            this.SelectFromTopCb.Font = Consts.contentFont;
            this.SelectFromTopCb.Location = new System.Drawing.Point(2, 2);
            this.SelectFromTopCb.Margin = new System.Windows.Forms.Padding(2);
            this.SelectFromTopCb.Name = "SelectFromTopCb";
            this.SelectFromTopCb.Size = new System.Drawing.Size(400, 50);
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
            this.TableLayoutPnl.Controls.Add(this.SelectFromTopCb, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.TimeIntervalLbl, 0, 2);
            this.TableLayoutPnl.Controls.Add(this.PreviewCb, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.TimeIncrementUpDown, 1, 2);
            this.TableLayoutPnl.Location = new System.Drawing.Point(44, 182);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 3;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(818, 226);
            this.TableLayoutPnl.TabIndex = 124;
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.SettingsLbl);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(908, 992);
            ((System.ComponentModel.ISupportInitialize)(this.TimeIncrementUpDown)).EndInit();
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SettingsLbl;
        private System.Windows.Forms.Label TimeIntervalLbl;
        private System.Windows.Forms.NumericUpDown TimeIncrementUpDown;
        private System.Windows.Forms.CheckBox PreviewCb;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.CheckBox SelectFromTopCb;
    }
}
