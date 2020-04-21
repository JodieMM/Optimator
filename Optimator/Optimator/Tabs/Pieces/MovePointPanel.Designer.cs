namespace Optimator.Tabs.Pieces
{
    partial class MovePointPanel
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
            this.XCoordLbl = new System.Windows.Forms.Label();
            this.YCoordLbl = new System.Windows.Forms.Label();
            this.MovePointLbl = new System.Windows.Forms.Label();
            this.XUpDown = new System.Windows.Forms.NumericUpDown();
            this.YUpDown = new System.Windows.Forms.NumericUpDown();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).BeginInit();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // XCoordLbl
            // 
            this.XCoordLbl.AutoSize = true;
            this.XCoordLbl.Font = Consts.contentFont;
            this.XCoordLbl.Location = new System.Drawing.Point(3, 0);
            this.XCoordLbl.Name = "XCoordLbl";
            this.XCoordLbl.Size = new System.Drawing.Size(41, 45);
            this.XCoordLbl.TabIndex = 0;
            this.XCoordLbl.Text = "X";
            // 
            // YCoordLbl
            // 
            this.YCoordLbl.AutoSize = true;
            this.YCoordLbl.Font = Consts.contentFont;
            this.YCoordLbl.Location = new System.Drawing.Point(3, 118);
            this.YCoordLbl.Name = "YCoordLbl";
            this.YCoordLbl.Size = new System.Drawing.Size(41, 45);
            this.YCoordLbl.TabIndex = 1;
            this.YCoordLbl.Text = "Y";
            // 
            // MovePointLbl
            // 
            this.MovePointLbl.AutoSize = true;
            this.MovePointLbl.Font = Consts.headingLblFont;
            this.MovePointLbl.Location = new System.Drawing.Point(47, 53);
            this.MovePointLbl.Name = "MovePointLbl";
            this.MovePointLbl.Size = new System.Drawing.Size(296, 58);
            this.MovePointLbl.TabIndex = 2;
            this.MovePointLbl.Text = "Move Point";
            // 
            // XUpDown
            // 
            this.XUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XUpDown.Font = Consts.contentFont;
            this.XUpDown.Location = new System.Drawing.Point(94, 3);
            this.XUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.XUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.XUpDown.Name = "XUpDown";
            this.XUpDown.Size = new System.Drawing.Size(361, 52);
            this.XUpDown.TabIndex = 3;
            this.XUpDown.ValueChanged += new System.EventHandler(this.XUpDown_ValueChanged);
            // 
            // YUpDown
            // 
            this.YUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.YUpDown.Font = Consts.contentFont;
            this.YUpDown.Location = new System.Drawing.Point(94, 121);
            this.YUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.YUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.YUpDown.Name = "YUpDown";
            this.YUpDown.Size = new System.Drawing.Size(361, 52);
            this.YUpDown.TabIndex = 4;
            this.YUpDown.ValueChanged += new System.EventHandler(this.YUpDown_ValueChanged);
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TableLayoutPnl.Controls.Add(this.XCoordLbl, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.YUpDown, 1, 1);
            this.TableLayoutPnl.Controls.Add(this.YCoordLbl, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.XUpDown, 1, 0);
            this.TableLayoutPnl.Location = new System.Drawing.Point(57, 180);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 2;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(458, 236);
            this.TableLayoutPnl.TabIndex = 5;
            // 
            // MovePointPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.MovePointLbl);
            this.Name = "MovePointPanel";
            this.Size = new System.Drawing.Size(798, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).EndInit();
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label XCoordLbl;
        private System.Windows.Forms.Label YCoordLbl;
        private System.Windows.Forms.Label MovePointLbl;
        private System.Windows.Forms.NumericUpDown XUpDown;
        private System.Windows.Forms.NumericUpDown YUpDown;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
    }
}
