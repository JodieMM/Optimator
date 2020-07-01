namespace Optimator.Forms.Compile
{
    partial class SavePanel
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
            this.ExportBtn = new System.Windows.Forms.Button();
            this.SaveLbl = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.ProgBar = new System.Windows.Forms.ProgressBar();
            this.LocationLbl = new System.Windows.Forms.Label();
            this.SaveAsBtn = new System.Windows.Forms.Button();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExportBtn
            // 
            this.ExportBtn.BackColor = System.Drawing.Color.LightCoral;
            this.ExportBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.ExportBtn.Location = new System.Drawing.Point(0, 232);
            this.ExportBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(519, 116);
            this.ExportBtn.TabIndex = 14;
            this.ExportBtn.Text = "Export";
            this.ExportBtn.UseVisualStyleBackColor = false;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // SaveLbl
            // 
            this.SaveLbl.AutoSize = true;
            this.SaveLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.SaveLbl.Location = new System.Drawing.Point(32, 56);
            this.SaveLbl.Name = "SaveLbl";
            this.SaveLbl.Size = new System.Drawing.Size(307, 72);
            this.SaveLbl.TabIndex = 11;
            this.SaveLbl.Text = "Save Video";
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.LightCoral;
            this.SaveBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SaveBtn.Location = new System.Drawing.Point(0, 0);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(519, 116);
            this.SaveBtn.TabIndex = 10;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 1;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPnl.Controls.Add(this.ProgBar, 0, 3);
            this.TableLayoutPnl.Controls.Add(this.LocationLbl, 0, 4);
            this.TableLayoutPnl.Controls.Add(this.SaveAsBtn, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.SaveBtn, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.ExportBtn, 0, 2);
            this.TableLayoutPnl.Location = new System.Drawing.Point(54, 197);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 5;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(519, 580);
            this.TableLayoutPnl.TabIndex = 13;
            // 
            // ProgBar
            // 
            this.ProgBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgBar.Location = new System.Drawing.Point(0, 348);
            this.ProgBar.Margin = new System.Windows.Forms.Padding(0);
            this.ProgBar.Name = "ProgBar";
            this.ProgBar.Size = new System.Drawing.Size(519, 58);
            this.ProgBar.TabIndex = 14;
            this.ProgBar.Visible = false;
            // 
            // LocationLbl
            // 
            this.LocationLbl.AutoSize = true;
            this.LocationLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocationLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.LocationLbl.Location = new System.Drawing.Point(3, 406);
            this.LocationLbl.Name = "LocationLbl";
            this.LocationLbl.Size = new System.Drawing.Size(513, 174);
            this.LocationLbl.TabIndex = 16;
            this.LocationLbl.Text = "*Videos can only be opened if they are in the same directory as their scenes and " +
    "the scenes\' sub-parts";
            // 
            // SaveAsBtn
            // 
            this.SaveAsBtn.BackColor = System.Drawing.Color.LightCoral;
            this.SaveAsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveAsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveAsBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SaveAsBtn.Location = new System.Drawing.Point(0, 116);
            this.SaveAsBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SaveAsBtn.Name = "SaveAsBtn";
            this.SaveAsBtn.Size = new System.Drawing.Size(519, 116);
            this.SaveAsBtn.TabIndex = 12;
            this.SaveAsBtn.Text = "Save As";
            this.SaveAsBtn.UseVisualStyleBackColor = false;
            this.SaveAsBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SavePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.SaveLbl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SavePanel";
            this.Size = new System.Drawing.Size(820, 877);
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Label SaveLbl;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Button SaveAsBtn;
        private System.Windows.Forms.Label LocationLbl;
        private System.Windows.Forms.ProgressBar ProgBar;
    }
}
