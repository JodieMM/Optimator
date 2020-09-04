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
            this.TensionLbl = new System.Windows.Forms.Label();
            this.TensionUpDown = new System.Windows.Forms.NumericUpDown();
            this.OutlineLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OutlineWidthBox)).BeginInit();
            this.TableLayoutPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TensionUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // OutlineWLbl
            // 
            this.OutlineWLbl.AutoSize = true;
            this.OutlineWLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.OutlineWLbl.Location = new System.Drawing.Point(2, 0);
            this.OutlineWLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 30);
            this.OutlineWLbl.Name = "OutlineWLbl";
            this.OutlineWLbl.Size = new System.Drawing.Size(288, 59);
            this.OutlineWLbl.TabIndex = 123;
            this.OutlineWLbl.Text = "Outline Width";
            // 
            // OutlineWidthBox
            // 
            this.OutlineWidthBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutlineWidthBox.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.OutlineWidthBox.Location = new System.Drawing.Point(345, 3);
            this.OutlineWidthBox.Name = "OutlineWidthBox";
            this.OutlineWidthBox.Size = new System.Drawing.Size(340, 64);
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
            this.ConnectorsLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.ConnectorsLbl.Location = new System.Drawing.Point(2, 89);
            this.ConnectorsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 30);
            this.ConnectorsLbl.Name = "ConnectorsLbl";
            this.ConnectorsLbl.Size = new System.Drawing.Size(222, 59);
            this.ConnectorsLbl.TabIndex = 125;
            this.ConnectorsLbl.Text = "Connector";
            // 
            // ConnectorOptions
            // 
            this.ConnectorOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectorOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConnectorOptions.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.ConnectorOptions.FormattingEnabled = true;
            this.ConnectorOptions.Location = new System.Drawing.Point(345, 92);
            this.ConnectorOptions.Name = "ConnectorOptions";
            this.ConnectorOptions.Size = new System.Drawing.Size(340, 67);
            this.ConnectorOptions.TabIndex = 124;
            this.ConnectorOptions.SelectedIndexChanged += new System.EventHandler(this.ConnectorOptions_SelectedIndexChanged);
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.74227F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.25773F));
            this.TableLayoutPnl.Controls.Add(this.ConnectorsLbl, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.OutlineWidthBox, 1, 0);
            this.TableLayoutPnl.Controls.Add(this.ConnectorOptions, 1, 1);
            this.TableLayoutPnl.Controls.Add(this.TensionLbl, 0, 2);
            this.TableLayoutPnl.Controls.Add(this.TensionUpDown, 1, 2);
            this.TableLayoutPnl.Controls.Add(this.OutlineWLbl, 0, 0);
            this.TableLayoutPnl.Location = new System.Drawing.Point(92, 207);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 3;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(688, 462);
            this.TableLayoutPnl.TabIndex = 126;
            // 
            // TensionLbl
            // 
            this.TensionLbl.AutoSize = true;
            this.TensionLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.TensionLbl.Location = new System.Drawing.Point(2, 178);
            this.TensionLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 30);
            this.TensionLbl.Name = "TensionLbl";
            this.TensionLbl.Size = new System.Drawing.Size(288, 59);
            this.TensionLbl.TabIndex = 126;
            this.TensionLbl.Text = "Curve Tension";
            this.TensionLbl.Visible = false;
            // 
            // TensionUpDown
            // 
            this.TensionUpDown.DecimalPlaces = 3;
            this.TensionUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TensionUpDown.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.TensionUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.TensionUpDown.Location = new System.Drawing.Point(345, 181);
            this.TensionUpDown.Name = "TensionUpDown";
            this.TensionUpDown.Size = new System.Drawing.Size(340, 64);
            this.TensionUpDown.TabIndex = 127;
            this.TensionUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.TensionUpDown.Visible = false;
            this.TensionUpDown.ValueChanged += new System.EventHandler(this.TensionUpDown_ValueChanged);
            // 
            // OutlineLbl
            // 
            this.OutlineLbl.AutoSize = true;
            this.OutlineLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.OutlineLbl.Location = new System.Drawing.Point(82, 69);
            this.OutlineLbl.Name = "OutlineLbl";
            this.OutlineLbl.Size = new System.Drawing.Size(217, 72);
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
            ((System.ComponentModel.ISupportInitialize)(this.TensionUpDown)).EndInit();
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
        private System.Windows.Forms.Label TensionLbl;
        private System.Windows.Forms.NumericUpDown TensionUpDown;
    }
}
