namespace Optimator.Forms.Scenes
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
            this.CompleteBtn = new System.Windows.Forms.Button();
            this.SaveLbl = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.SaveAsBtn = new System.Windows.Forms.Button();
            this.LocationLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // CompleteBtn
            // 
            this.CompleteBtn.BackColor = System.Drawing.Color.Khaki;
            this.CompleteBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompleteBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.CompleteBtn.Location = new System.Drawing.Point(0, 234);
            this.CompleteBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CompleteBtn.Name = "CompleteBtn";
            this.CompleteBtn.Size = new System.Drawing.Size(612, 117);
            this.CompleteBtn.TabIndex = 13;
            this.CompleteBtn.Text = "Complete";
            this.CompleteBtn.UseVisualStyleBackColor = false;
            this.CompleteBtn.Click += new System.EventHandler(this.CompleteBtn_Click);
            // 
            // SaveLbl
            // 
            this.SaveLbl.AutoSize = true;
            this.SaveLbl.Font = new System.Drawing.Font("Segoe UI", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLbl.Location = new System.Drawing.Point(30, 37);
            this.SaveLbl.Name = "SaveLbl";
            this.SaveLbl.Size = new System.Drawing.Size(146, 71);
            this.SaveLbl.TabIndex = 12;
            this.SaveLbl.Text = "Save";
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.Khaki;
            this.SaveBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SaveBtn.Location = new System.Drawing.Point(0, 0);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(612, 117);
            this.SaveBtn.TabIndex = 10;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 1;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPnl.Controls.Add(this.LocationLbl, 0, 3);
            this.TableLayoutPnl.Controls.Add(this.SaveAsBtn, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.SaveBtn, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.CompleteBtn, 0, 2);
            this.TableLayoutPnl.Location = new System.Drawing.Point(42, 157);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 4;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(612, 588);
            this.TableLayoutPnl.TabIndex = 14;
            // 
            // SaveAsBtn
            // 
            this.SaveAsBtn.BackColor = System.Drawing.Color.Khaki;
            this.SaveAsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveAsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveAsBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SaveAsBtn.Location = new System.Drawing.Point(0, 117);
            this.SaveAsBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SaveAsBtn.Name = "SaveAsBtn";
            this.SaveAsBtn.Size = new System.Drawing.Size(612, 117);
            this.SaveAsBtn.TabIndex = 15;
            this.SaveAsBtn.Text = "Save As";
            this.SaveAsBtn.UseVisualStyleBackColor = false;
            this.SaveAsBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // LocationLbl
            // 
            this.LocationLbl.AutoSize = true;
            this.LocationLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocationLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.LocationLbl.Location = new System.Drawing.Point(3, 351);
            this.LocationLbl.Name = "LocationLbl";
            this.LocationLbl.Size = new System.Drawing.Size(606, 237);
            this.LocationLbl.TabIndex = 16;
            this.LocationLbl.Text = "*Scenes can only be opened if they are in the same directory as their sub-parts";
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
        private System.Windows.Forms.Button CompleteBtn;
        private System.Windows.Forms.Label SaveLbl;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Button SaveAsBtn;
        private System.Windows.Forms.Label LocationLbl;
    }
}
