namespace Optimator.Tabs.Pieces
{
    partial class OptionsPanel
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
            this.TypeLbl = new System.Windows.Forms.Label();
            this.PieceOptionsCb = new System.Windows.Forms.ComboBox();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.OptionsLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TypeLbl
            // 
            this.TypeLbl.AutoSize = true;
            this.TypeLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.TypeLbl.Location = new System.Drawing.Point(2, 0);
            this.TypeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TypeLbl.Name = "TypeLbl";
            this.TypeLbl.Size = new System.Drawing.Size(135, 112);
            this.TypeLbl.TabIndex = 125;
            this.TypeLbl.Text = "Piece Type";
            // 
            // PieceOptionsCb
            // 
            this.PieceOptionsCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PieceOptionsCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PieceOptionsCb.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.PieceOptionsCb.FormattingEnabled = true;
            this.PieceOptionsCb.Location = new System.Drawing.Point(197, 3);
            this.PieceOptionsCb.Name = "PieceOptionsCb";
            this.PieceOptionsCb.Size = new System.Drawing.Size(188, 67);
            this.PieceOptionsCb.TabIndex = 124;
            this.PieceOptionsCb.SelectedIndexChanged += new System.EventHandler(this.PieceOptionsCb_SelectedIndexChanged);
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Controls.Add(this.TypeLbl, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.PieceOptionsCb, 1, 0);
            this.TableLayoutPnl.Location = new System.Drawing.Point(92, 207);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 2;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(388, 224);
            this.TableLayoutPnl.TabIndex = 126;
            // 
            // OptionsLbl
            // 
            this.OptionsLbl.AutoSize = true;
            this.OptionsLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.OptionsLbl.Location = new System.Drawing.Point(82, 69);
            this.OptionsLbl.Name = "OptionsLbl";
            this.OptionsLbl.Size = new System.Drawing.Size(230, 72);
            this.OptionsLbl.TabIndex = 127;
            this.OptionsLbl.Text = "Options";
            // 
            // OptionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OptionsLbl);
            this.Controls.Add(this.TableLayoutPnl);
            this.Name = "OptionsPanel";
            this.Size = new System.Drawing.Size(868, 792);
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TypeLbl;
        private System.Windows.Forms.ComboBox PieceOptionsCb;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Label OptionsLbl;
    }
}
