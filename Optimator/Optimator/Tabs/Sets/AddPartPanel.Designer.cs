namespace Optimator.Forms.Sets
{
    partial class AddPartPanel
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
            this.AddPartBtn = new System.Windows.Forms.Button();
            this.AddPartLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddPartBtn
            // 
            this.AddPartBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TableLayoutPnl.SetColumnSpan(this.AddPartBtn, 2);
            this.AddPartBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddPartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPartBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.AddPartBtn.Location = new System.Drawing.Point(2, 2);
            this.AddPartBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddPartBtn.Name = "AddPartBtn";
            this.TableLayoutPnl.SetRowSpan(this.AddPartBtn, 2);
            this.AddPartBtn.Size = new System.Drawing.Size(433, 194);
            this.AddPartBtn.TabIndex = 82;
            this.AddPartBtn.Text = "Select Part";
            this.AddPartBtn.UseVisualStyleBackColor = false;
            this.AddPartBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // AddPartLbl
            // 
            this.AddPartLbl.AutoSize = true;
            this.AddPartLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.AddPartLbl.Location = new System.Drawing.Point(34, 46);
            this.AddPartLbl.Name = "AddPartLbl";
            this.AddPartLbl.Size = new System.Drawing.Size(254, 72);
            this.AddPartLbl.TabIndex = 84;
            this.AddPartLbl.Text = "Add Part";
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Controls.Add(this.AddPartBtn, 0, 0);
            this.TableLayoutPnl.Location = new System.Drawing.Point(44, 172);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 2;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(437, 198);
            this.TableLayoutPnl.TabIndex = 85;
            // 
            // AddPartPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.AddPartLbl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddPartPanel";
            this.Size = new System.Drawing.Size(620, 527);
            this.TableLayoutPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Button AddPartBtn;
        private System.Windows.Forms.Label AddPartLbl;
    }
}
