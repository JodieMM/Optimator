namespace Optimator.Tabs.Sets
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
            this.BgColorLbl = new System.Windows.Forms.Label();
            this.BackColourBox = new System.Windows.Forms.PictureBox();
            this.TableLayoutPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackColourBox)).BeginInit();
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
            this.SelectFromTopCb.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SelectFromTopCb.Location = new System.Drawing.Point(0, 0);
            this.SelectFromTopCb.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.SelectFromTopCb.Name = "SelectFromTopCb";
            this.SelectFromTopCb.Size = new System.Drawing.Size(462, 63);
            this.SelectFromTopCb.TabIndex = 1;
            this.SelectFromTopCb.Text = "Select Piece from Top";
            this.SelectFromTopCb.UseVisualStyleBackColor = true;
            this.SelectFromTopCb.CheckedChanged += new System.EventHandler(this.SelectFromTopCb_CheckedChanged);
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Controls.Add(this.BgColorLbl, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.BackColourBox, 1, 1);
            this.TableLayoutPnl.Controls.Add(this.SelectFromTopCb, 0, 0);
            this.TableLayoutPnl.Location = new System.Drawing.Point(58, 177);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 2;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.Size = new System.Drawing.Size(648, 268);
            this.TableLayoutPnl.TabIndex = 130;
            // 
            // BgColorLbl
            // 
            this.BgColorLbl.AutoSize = true;
            this.BgColorLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.BgColorLbl.Location = new System.Drawing.Point(0, 93);
            this.BgColorLbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.BgColorLbl.Name = "BgColorLbl";
            this.BgColorLbl.Size = new System.Drawing.Size(263, 118);
            this.BgColorLbl.TabIndex = 130;
            this.BgColorLbl.Text = "Background Colour";
            // 
            // BackColourBox
            // 
            this.BackColourBox.BackColor = System.Drawing.Color.White;
            this.BackColourBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackColourBox.Location = new System.Drawing.Point(324, 93);
            this.BackColourBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.BackColourBox.Name = "BackColourBox";
            this.BackColourBox.Size = new System.Drawing.Size(324, 115);
            this.BackColourBox.TabIndex = 128;
            this.BackColourBox.TabStop = false;
            this.BackColourBox.Click += new System.EventHandler(this.BackColourBox_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.BackColourBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SettingsLbl;
        private System.Windows.Forms.CheckBox SelectFromTopCb;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Label BgColorLbl;
        private System.Windows.Forms.PictureBox BackColourBox;
    }
}
