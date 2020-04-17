namespace Optimator.Tabs.Pieces
{
    partial class ColoursPanel
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
            this.OutlineBox = new System.Windows.Forms.PictureBox();
            this.FillBox = new System.Windows.Forms.PictureBox();
            this.OutlineLbl = new System.Windows.Forms.Label();
            this.FillLbl = new System.Windows.Forms.Label();
            this.ColoursLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.OutlineBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillBox)).BeginInit();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutlineBox
            // 
            this.OutlineBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutlineBox.BackColor = System.Drawing.Color.White;
            this.OutlineBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutlineBox.Location = new System.Drawing.Point(236, 178);
            this.OutlineBox.Name = "OutlineBox";
            this.OutlineBox.Size = new System.Drawing.Size(227, 30);
            this.OutlineBox.TabIndex = 119;
            this.OutlineBox.TabStop = false;
            this.OutlineBox.Click += new System.EventHandler(this.OutlineBox_Click);
            // 
            // FillBox
            // 
            this.FillBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FillBox.BackColor = System.Drawing.Color.White;
            this.FillBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FillBox.Location = new System.Drawing.Point(236, 3);
            this.FillBox.Name = "FillBox";
            this.FillBox.Size = new System.Drawing.Size(227, 30);
            this.FillBox.TabIndex = 118;
            this.FillBox.TabStop = false;
            this.FillBox.Click += new System.EventHandler(this.FillBox_Click);
            // 
            // OutlineLbl
            // 
            this.OutlineLbl.AutoSize = true;
            this.OutlineLbl.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutlineLbl.Location = new System.Drawing.Point(2, 175);
            this.OutlineLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OutlineLbl.Name = "OutlineLbl";
            this.OutlineLbl.Size = new System.Drawing.Size(135, 45);
            this.OutlineLbl.TabIndex = 117;
            this.OutlineLbl.Text = "Outline";
            // 
            // FillLbl
            // 
            this.FillLbl.AutoSize = true;
            this.FillLbl.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FillLbl.Location = new System.Drawing.Point(2, 0);
            this.FillLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FillLbl.Name = "FillLbl";
            this.FillLbl.Size = new System.Drawing.Size(63, 45);
            this.FillLbl.TabIndex = 116;
            this.FillLbl.Text = "Fill";
            // 
            // ColoursLbl
            // 
            this.ColoursLbl.AutoSize = true;
            this.ColoursLbl.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColoursLbl.Location = new System.Drawing.Point(32, 51);
            this.ColoursLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ColoursLbl.Name = "ColoursLbl";
            this.ColoursLbl.Size = new System.Drawing.Size(208, 58);
            this.ColoursLbl.TabIndex = 115;
            this.ColoursLbl.Text = "Colours";
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Controls.Add(this.FillLbl, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.OutlineBox, 1, 1);
            this.TableLayoutPnl.Controls.Add(this.OutlineLbl, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.FillBox, 1, 0);
            this.TableLayoutPnl.Location = new System.Drawing.Point(42, 163);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 2;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(466, 350);
            this.TableLayoutPnl.TabIndex = 120;
            // 
            // ColoursPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.ColoursLbl);
            this.Name = "ColoursPanel";
            this.Size = new System.Drawing.Size(742, 1018);
            ((System.ComponentModel.ISupportInitialize)(this.OutlineBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillBox)).EndInit();
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OutlineBox;
        private System.Windows.Forms.PictureBox FillBox;
        private System.Windows.Forms.Label OutlineLbl;
        private System.Windows.Forms.Label FillLbl;
        private System.Windows.Forms.Label ColoursLbl;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
    }
}
