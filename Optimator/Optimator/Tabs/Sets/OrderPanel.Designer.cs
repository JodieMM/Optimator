namespace Optimator.Tabs.Sets
{
    partial class OrderPanel
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
            this.OrderLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.UpBtn = new System.Windows.Forms.Button();
            this.DownBtn = new System.Windows.Forms.Button();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrderLbl
            // 
            this.OrderLbl.AutoSize = true;
            this.OrderLbl.Font = Consts.headingLblFont;
            this.OrderLbl.Location = new System.Drawing.Point(34, 44);
            this.OrderLbl.Name = "OrderLbl";
            this.OrderLbl.Size = new System.Drawing.Size(163, 58);
            this.OrderLbl.TabIndex = 0;
            this.OrderLbl.Text = "Order";
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 1;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Controls.Add(this.UpBtn, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.DownBtn, 0, 1);
            this.TableLayoutPnl.Location = new System.Drawing.Point(44, 172);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 2;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(378, 274);
            this.TableLayoutPnl.TabIndex = 1;
            // 
            // UpBtn
            // 
            this.UpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.UpBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpBtn.Font = Consts.contentFont;
            this.UpBtn.Location = new System.Drawing.Point(2, 2);
            this.UpBtn.Margin = new System.Windows.Forms.Padding(2);
            this.UpBtn.Name = "UpBtn";
            this.UpBtn.Size = new System.Drawing.Size(374, 133);
            this.UpBtn.TabIndex = 127;
            this.UpBtn.TabStop = false;
            this.UpBtn.Text = "Move Up";
            this.UpBtn.UseVisualStyleBackColor = false;
            this.UpBtn.Click += new System.EventHandler(this.UpDownBtn_Click);
            // 
            // DownBtn
            // 
            this.DownBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DownBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownBtn.Font = Consts.contentFont;
            this.DownBtn.Location = new System.Drawing.Point(2, 139);
            this.DownBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DownBtn.Name = "DownBtn";
            this.DownBtn.Size = new System.Drawing.Size(374, 133);
            this.DownBtn.TabIndex = 128;
            this.DownBtn.TabStop = false;
            this.DownBtn.Text = "Move Down";
            this.DownBtn.UseVisualStyleBackColor = false;
            this.DownBtn.Click += new System.EventHandler(this.UpDownBtn_Click);
            // 
            // OrderPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.OrderLbl);
            this.Name = "OrderPanel";
            this.Size = new System.Drawing.Size(908, 992);
            this.TableLayoutPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OrderLbl;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Button UpBtn;
        private System.Windows.Forms.Button DownBtn;
    }
}
