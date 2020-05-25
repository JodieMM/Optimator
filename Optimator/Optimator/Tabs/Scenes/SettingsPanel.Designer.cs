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
            this.TableLayoutPnl.SuspendLayout();
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
            this.SelectFromTopCb.Location = new System.Drawing.Point(2, 2);
            this.SelectFromTopCb.Margin = new System.Windows.Forms.Padding(2);
            this.SelectFromTopCb.Name = "SelectFromTopCb";
            this.SelectFromTopCb.Size = new System.Drawing.Size(439, 63);
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
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SettingsLbl;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.CheckBox SelectFromTopCb;
    }
}
