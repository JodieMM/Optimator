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
            this.WidthLbl = new System.Windows.Forms.Label();
            this.WidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.ConnectorsLbl = new System.Windows.Forms.Label();
            this.ConnectorOptions = new System.Windows.Forms.ComboBox();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.ColourBox = new System.Windows.Forms.PictureBox();
            this.PointLbl = new System.Windows.Forms.Label();
            this.LineLbl = new System.Windows.Forms.Label();
            this.TensionLbl = new System.Windows.Forms.Label();
            this.TensionUpDown = new System.Windows.Forms.NumericUpDown();
            this.OutlineColourLbl = new System.Windows.Forms.Label();
            this.VisibleCb = new System.Windows.Forms.CheckBox();
            this.OutlineLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).BeginInit();
            this.TableLayoutPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColourBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TensionUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // WidthLbl
            // 
            this.WidthLbl.AutoSize = true;
            this.WidthLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WidthLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.WidthLbl.Location = new System.Drawing.Point(2, 368);
            this.WidthLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 30);
            this.WidthLbl.Name = "WidthLbl";
            this.WidthLbl.Size = new System.Drawing.Size(340, 59);
            this.WidthLbl.TabIndex = 123;
            this.WidthLbl.Text = "Width";
            // 
            // WidthUpDown
            // 
            this.WidthUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WidthUpDown.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.WidthUpDown.Location = new System.Drawing.Point(347, 371);
            this.WidthUpDown.Name = "WidthUpDown";
            this.WidthUpDown.Size = new System.Drawing.Size(338, 64);
            this.WidthUpDown.TabIndex = 122;
            this.WidthUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.WidthUpDown.ValueChanged += new System.EventHandler(this.WidthUpDown_ValueChanged);
            // 
            // ConnectorsLbl
            // 
            this.ConnectorsLbl.AutoSize = true;
            this.ConnectorsLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConnectorsLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.ConnectorsLbl.Location = new System.Drawing.Point(2, 95);
            this.ConnectorsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 30);
            this.ConnectorsLbl.Name = "ConnectorsLbl";
            this.ConnectorsLbl.Size = new System.Drawing.Size(340, 59);
            this.ConnectorsLbl.TabIndex = 125;
            this.ConnectorsLbl.Text = "Connector";
            // 
            // ConnectorOptions
            // 
            this.ConnectorOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConnectorOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConnectorOptions.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.ConnectorOptions.FormattingEnabled = true;
            this.ConnectorOptions.Location = new System.Drawing.Point(347, 98);
            this.ConnectorOptions.Name = "ConnectorOptions";
            this.ConnectorOptions.Size = new System.Drawing.Size(338, 67);
            this.ConnectorOptions.TabIndex = 124;
            this.ConnectorOptions.SelectedIndexChanged += new System.EventHandler(this.ConnectorOptions_SelectedIndexChanged);
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Controls.Add(this.ColourBox, 1, 5);
            this.TableLayoutPnl.Controls.Add(this.PointLbl, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.LineLbl, 0, 3);
            this.TableLayoutPnl.Controls.Add(this.ConnectorsLbl, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.TensionLbl, 0, 2);
            this.TableLayoutPnl.Controls.Add(this.ConnectorOptions, 1, 1);
            this.TableLayoutPnl.Controls.Add(this.TensionUpDown, 1, 2);
            this.TableLayoutPnl.Controls.Add(this.WidthLbl, 0, 4);
            this.TableLayoutPnl.Controls.Add(this.WidthUpDown, 1, 4);
            this.TableLayoutPnl.Controls.Add(this.OutlineColourLbl, 0, 5);
            this.TableLayoutPnl.Controls.Add(this.VisibleCb, 0, 6);
            this.TableLayoutPnl.Location = new System.Drawing.Point(92, 207);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 7;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(688, 768);
            this.TableLayoutPnl.TabIndex = 126;
            // 
            // ColourBox
            // 
            this.ColourBox.BackColor = System.Drawing.Color.White;
            this.ColourBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColourBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColourBox.Location = new System.Drawing.Point(344, 457);
            this.ColourBox.Margin = new System.Windows.Forms.Padding(0);
            this.ColourBox.Name = "ColourBox";
            this.ColourBox.Size = new System.Drawing.Size(344, 89);
            this.ColourBox.TabIndex = 128;
            this.ColourBox.TabStop = false;
            this.ColourBox.Click += new System.EventHandler(this.ColourBox_Click);
            // 
            // PointLbl
            // 
            this.PointLbl.AutoSize = true;
            this.TableLayoutPnl.SetColumnSpan(this.PointLbl, 2);
            this.PointLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PointLbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointLbl.Location = new System.Drawing.Point(2, 0);
            this.PointLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 30);
            this.PointLbl.Name = "PointLbl";
            this.PointLbl.Size = new System.Drawing.Size(684, 65);
            this.PointLbl.TabIndex = 130;
            this.PointLbl.Text = "Point";
            // 
            // LineLbl
            // 
            this.LineLbl.AutoSize = true;
            this.TableLayoutPnl.SetColumnSpan(this.LineLbl, 2);
            this.LineLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineLbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineLbl.Location = new System.Drawing.Point(2, 273);
            this.LineLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 30);
            this.LineLbl.Name = "LineLbl";
            this.LineLbl.Size = new System.Drawing.Size(684, 65);
            this.LineLbl.TabIndex = 131;
            this.LineLbl.Text = "Line";
            // 
            // TensionLbl
            // 
            this.TensionLbl.AutoSize = true;
            this.TensionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TensionLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.TensionLbl.Location = new System.Drawing.Point(2, 184);
            this.TensionLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 30);
            this.TensionLbl.Name = "TensionLbl";
            this.TensionLbl.Size = new System.Drawing.Size(340, 59);
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
            this.TensionUpDown.Location = new System.Drawing.Point(347, 187);
            this.TensionUpDown.Name = "TensionUpDown";
            this.TensionUpDown.Size = new System.Drawing.Size(338, 64);
            this.TensionUpDown.TabIndex = 127;
            this.TensionUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.TensionUpDown.Visible = false;
            this.TensionUpDown.ValueChanged += new System.EventHandler(this.TensionUpDown_ValueChanged);
            // 
            // OutlineColourLbl
            // 
            this.OutlineColourLbl.AutoSize = true;
            this.OutlineColourLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutlineColourLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.OutlineColourLbl.Location = new System.Drawing.Point(2, 457);
            this.OutlineColourLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 30);
            this.OutlineColourLbl.Name = "OutlineColourLbl";
            this.OutlineColourLbl.Size = new System.Drawing.Size(340, 59);
            this.OutlineColourLbl.TabIndex = 132;
            this.OutlineColourLbl.Text = "Colour";
            // 
            // VisibleCb
            // 
            this.VisibleCb.AutoSize = true;
            this.VisibleCb.Checked = true;
            this.VisibleCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TableLayoutPnl.SetColumnSpan(this.VisibleCb, 2);
            this.VisibleCb.Dock = System.Windows.Forms.DockStyle.Top;
            this.VisibleCb.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.VisibleCb.Location = new System.Drawing.Point(3, 549);
            this.VisibleCb.Name = "VisibleCb";
            this.VisibleCb.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.VisibleCb.Size = new System.Drawing.Size(682, 63);
            this.VisibleCb.TabIndex = 129;
            this.VisibleCb.Text = "Visible";
            this.VisibleCb.UseVisualStyleBackColor = true;
            this.VisibleCb.CheckedChanged += new System.EventHandler(this.VisibleCb_CheckedChanged);
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
            this.Size = new System.Drawing.Size(1024, 1204);
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).EndInit();
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColourBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TensionUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WidthLbl;
        private System.Windows.Forms.NumericUpDown WidthUpDown;
        private System.Windows.Forms.Label ConnectorsLbl;
        private System.Windows.Forms.ComboBox ConnectorOptions;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Label OutlineLbl;
        private System.Windows.Forms.Label TensionLbl;
        private System.Windows.Forms.NumericUpDown TensionUpDown;
        private System.Windows.Forms.CheckBox VisibleCb;
        private System.Windows.Forms.Label PointLbl;
        private System.Windows.Forms.Label LineLbl;
        private System.Windows.Forms.Label OutlineColourLbl;
        private System.Windows.Forms.PictureBox ColourBox;
    }
}
