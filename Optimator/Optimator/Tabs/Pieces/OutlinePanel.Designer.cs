namespace Optimator.Tabs.Pieces
{
    partial class OutlinePanel
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
            this.OutlineWLbl = new System.Windows.Forms.Label();
            this.OutlineWidthBox = new System.Windows.Forms.NumericUpDown();
            this.ConnectorsLbl = new System.Windows.Forms.Label();
            this.ConnectorOptions = new System.Windows.Forms.ComboBox();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.OutlineLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OutlineWidthBox)).BeginInit();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutlineWLbl
            // 
            this.OutlineWLbl.AutoSize = true;
            this.OutlineWLbl.Font = Consts.contentFont;
            this.OutlineWLbl.Location = new System.Drawing.Point(2, 0);
            this.OutlineWLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OutlineWLbl.Name = "OutlineWLbl";
            this.OutlineWLbl.Size = new System.Drawing.Size(147, 90);
            this.OutlineWLbl.TabIndex = 123;
            this.OutlineWLbl.Text = "Outline Width";
            // 
            // OutlineWidthBox
            // 
            this.OutlineWidthBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutlineWidthBox.Font = Consts.contentFont;
            this.OutlineWidthBox.Location = new System.Drawing.Point(197, 3);
            this.OutlineWidthBox.Name = "OutlineWidthBox";
            this.OutlineWidthBox.Size = new System.Drawing.Size(188, 52);
            this.OutlineWidthBox.TabIndex = 122;
            this.OutlineWidthBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.OutlineWidthBox.ValueChanged += new System.EventHandler(this.OutlineWidthBox_ValueChanged);
            // 
            // ConnectorsLbl
            // 
            this.ConnectorsLbl.AutoSize = true;
            this.ConnectorsLbl.Font = Consts.contentFont;
            this.ConnectorsLbl.Location = new System.Drawing.Point(2, 112);
            this.ConnectorsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ConnectorsLbl.Name = "ConnectorsLbl";
            this.ConnectorsLbl.Size = new System.Drawing.Size(185, 45);
            this.ConnectorsLbl.TabIndex = 125;
            this.ConnectorsLbl.Text = "Connector";
            this.ConnectorsLbl.Visible = false;
            // 
            // ConnectorOptions
            // 
            this.ConnectorOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectorOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConnectorOptions.Font = Consts.contentFont;
            this.ConnectorOptions.FormattingEnabled = true;
            this.ConnectorOptions.Items.AddRange(new object[] {
            "Line",
            "Blank"});
            this.ConnectorOptions.Location = new System.Drawing.Point(197, 115);
            this.ConnectorOptions.Name = "ConnectorOptions";
            this.ConnectorOptions.Size = new System.Drawing.Size(188, 53);
            this.ConnectorOptions.TabIndex = 124;
            this.ConnectorOptions.SelectedIndexChanged += new System.EventHandler(this.ConnectorOptions_SelectedIndexChanged);
            this.ConnectorOptions.Visible = false;
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Controls.Add(this.OutlineWLbl, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.ConnectorOptions, 1, 1);
            this.TableLayoutPnl.Controls.Add(this.ConnectorsLbl, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.OutlineWidthBox, 1, 0);
            this.TableLayoutPnl.Location = new System.Drawing.Point(92, 207);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 2;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(388, 224);
            this.TableLayoutPnl.TabIndex = 126;
            // 
            // OutlineLbl
            // 
            this.OutlineLbl.AutoSize = true;
            this.OutlineLbl.Font = Consts.headingLblFont;
            this.OutlineLbl.Location = new System.Drawing.Point(82, 69);
            this.OutlineLbl.Name = "OutlineLbl";
            this.OutlineLbl.Size = new System.Drawing.Size(201, 58);
            this.OutlineLbl.TabIndex = 127;
            this.OutlineLbl.Text = "Outline";
            // 
            // OutlinePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OutlineLbl);
            this.Controls.Add(this.TableLayoutPnl);
            this.Name = "OutlinePanel";
            this.Size = new System.Drawing.Size(868, 792);
            ((System.ComponentModel.ISupportInitialize)(this.OutlineWidthBox)).EndInit();
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OutlineWLbl;
        private System.Windows.Forms.NumericUpDown OutlineWidthBox;
        private System.Windows.Forms.Label ConnectorsLbl;
        private System.Windows.Forms.ComboBox ConnectorOptions;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Label OutlineLbl;
    }
}
