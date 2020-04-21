namespace Optimator.Forms.Scenes
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
            this.AddTb = new System.Windows.Forms.TextBox();
            this.AddPieceBtn = new System.Windows.Forms.Button();
            this.AddSetBtn = new System.Windows.Forms.Button();
            this.AddPartLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddTb
            // 
            this.AddTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddTb.BackColor = System.Drawing.Color.White;
            this.TableLayoutPnl.SetColumnSpan(this.AddTb, 2);
            this.AddTb.Font = Consts.contentFont;
            this.AddTb.Location = new System.Drawing.Point(12, 12);
            this.AddTb.Margin = new System.Windows.Forms.Padding(12);
            this.AddTb.Name = "AddTb";
            this.AddTb.Size = new System.Drawing.Size(413, 52);
            this.AddTb.TabIndex = 6;
            this.AddTb.Text = "Part Name";
            // 
            // AddPieceBtn
            // 
            this.AddPieceBtn.BackColor = System.Drawing.Color.Khaki;
            this.AddPieceBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddPieceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPieceBtn.Font = Consts.contentFont;
            this.AddPieceBtn.Location = new System.Drawing.Point(2, 101);
            this.AddPieceBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddPieceBtn.Name = "AddPieceBtn";
            this.AddPieceBtn.Size = new System.Drawing.Size(214, 95);
            this.AddPieceBtn.TabIndex = 82;
            this.AddPieceBtn.Text = "+ Piece";
            this.AddPieceBtn.UseVisualStyleBackColor = false;
            this.AddPieceBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // AddSetBtn
            // 
            this.AddSetBtn.BackColor = System.Drawing.Color.Khaki;
            this.AddSetBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddSetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSetBtn.Font = Consts.contentFont;
            this.AddSetBtn.Location = new System.Drawing.Point(220, 101);
            this.AddSetBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddSetBtn.Name = "AddSetBtn";
            this.AddSetBtn.Size = new System.Drawing.Size(215, 95);
            this.AddSetBtn.TabIndex = 83;
            this.AddSetBtn.Text = "+ Set  ";
            this.AddSetBtn.UseVisualStyleBackColor = false;
            this.AddSetBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // AddPartLbl
            // 
            this.AddPartLbl.AutoSize = true;
            this.AddPartLbl.Font = Consts.headingLblFont;
            this.AddPartLbl.Location = new System.Drawing.Point(34, 46);
            this.AddPartLbl.Name = "AddPartLbl";
            this.AddPartLbl.Size = new System.Drawing.Size(234, 58);
            this.AddPartLbl.TabIndex = 84;
            this.AddPartLbl.Text = "Add Part";
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Controls.Add(this.AddPieceBtn, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.AddSetBtn, 1, 1);
            this.TableLayoutPnl.Controls.Add(this.AddTb, 0, 0);
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
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AddTb;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Button AddPieceBtn;
        private System.Windows.Forms.Button AddSetBtn;
        private System.Windows.Forms.Label AddPartLbl;
    }
}
