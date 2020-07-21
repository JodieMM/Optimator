namespace Optimator.Tabs.Sets
{
    partial class PositionsPanel
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
            this.components = new System.ComponentModel.Container();
            this.PositionsLbl = new System.Windows.Forms.Label();
            this.SizeLbl = new System.Windows.Forms.Label();
            this.SizeBar = new System.Windows.Forms.TrackBar();
            this.SpinLbl = new System.Windows.Forms.Label();
            this.SpinBar = new System.Windows.Forms.TrackBar();
            this.TurnLbl = new System.Windows.Forms.Label();
            this.TurnBar = new System.Windows.Forms.TrackBar();
            this.RotationLbl = new System.Windows.Forms.Label();
            this.RotationBar = new System.Windows.Forms.TrackBar();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.YLbl = new System.Windows.Forms.Label();
            this.XLbl = new System.Windows.Forms.Label();
            this.XUpDown = new System.Windows.Forms.NumericUpDown();
            this.YUpDown = new System.Windows.Forms.NumericUpDown();
            this.ValueToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).BeginInit();
            this.TableLayoutPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // PositionsLbl
            // 
            this.PositionsLbl.AutoSize = true;
            this.PositionsLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.PositionsLbl.Location = new System.Drawing.Point(33, 50);
            this.PositionsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PositionsLbl.Name = "PositionsLbl";
            this.PositionsLbl.Size = new System.Drawing.Size(235, 72);
            this.PositionsLbl.TabIndex = 130;
            this.PositionsLbl.Text = "Position";
            // 
            // SizeLbl
            // 
            this.SizeLbl.AutoSize = true;
            this.SizeLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SizeLbl.Location = new System.Drawing.Point(0, 548);
            this.SizeLbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.SizeLbl.Name = "SizeLbl";
            this.SizeLbl.Size = new System.Drawing.Size(99, 59);
            this.SizeLbl.TabIndex = 129;
            this.SizeLbl.Text = "Size";
            // 
            // SizeBar
            // 
            this.SizeBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SizeBar.Location = new System.Drawing.Point(202, 548);
            this.SizeBar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.SizeBar.Maximum = 500;
            this.SizeBar.Name = "SizeBar";
            this.SizeBar.Size = new System.Drawing.Size(376, 138);
            this.SizeBar.SmallChange = 5;
            this.SizeBar.TabIndex = 128;
            this.SizeBar.TickFrequency = 50;
            this.SizeBar.Value = 100;
            this.SizeBar.Scroll += new System.EventHandler(this.ScrollBar_Scroll);
            this.SizeBar.MouseHover += new System.EventHandler(this.TrackHover);
            // 
            // SpinLbl
            // 
            this.SpinLbl.AutoSize = true;
            this.SpinLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SpinLbl.Location = new System.Drawing.Point(0, 240);
            this.SpinLbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.SpinLbl.Name = "SpinLbl";
            this.SpinLbl.Size = new System.Drawing.Size(107, 59);
            this.SpinLbl.TabIndex = 127;
            this.SpinLbl.Text = "Spin";
            // 
            // SpinBar
            // 
            this.SpinBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpinBar.Location = new System.Drawing.Point(202, 240);
            this.SpinBar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.SpinBar.Maximum = 359;
            this.SpinBar.Name = "SpinBar";
            this.SpinBar.Size = new System.Drawing.Size(376, 90);
            this.SpinBar.TabIndex = 126;
            this.SpinBar.TickFrequency = 10;
            this.SpinBar.Scroll += new System.EventHandler(this.ScrollBar_Scroll);
            this.SpinBar.MouseHover += new System.EventHandler(this.TrackHover);
            // 
            // TurnLbl
            // 
            this.TurnLbl.AutoSize = true;
            this.TurnLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.TurnLbl.Location = new System.Drawing.Point(0, 120);
            this.TurnLbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.TurnLbl.Name = "TurnLbl";
            this.TurnLbl.Size = new System.Drawing.Size(111, 59);
            this.TurnLbl.TabIndex = 125;
            this.TurnLbl.Text = "Turn";
            // 
            // TurnBar
            // 
            this.TurnBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TurnBar.Location = new System.Drawing.Point(202, 120);
            this.TurnBar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.TurnBar.Maximum = 359;
            this.TurnBar.Name = "TurnBar";
            this.TurnBar.Size = new System.Drawing.Size(376, 90);
            this.TurnBar.TabIndex = 124;
            this.TurnBar.TickFrequency = 10;
            this.TurnBar.Scroll += new System.EventHandler(this.ScrollBar_Scroll);
            this.TurnBar.MouseHover += new System.EventHandler(this.TrackHover);
            // 
            // RotationLbl
            // 
            this.RotationLbl.AutoSize = true;
            this.RotationLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.RotationLbl.Location = new System.Drawing.Point(0, 0);
            this.RotationLbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.RotationLbl.Name = "RotationLbl";
            this.RotationLbl.Size = new System.Drawing.Size(186, 59);
            this.RotationLbl.TabIndex = 123;
            this.RotationLbl.Text = "Rotation";
            // 
            // RotationBar
            // 
            this.RotationBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RotationBar.Location = new System.Drawing.Point(202, 0);
            this.RotationBar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.RotationBar.Maximum = 359;
            this.RotationBar.Name = "RotationBar";
            this.RotationBar.Size = new System.Drawing.Size(376, 90);
            this.RotationBar.TabIndex = 122;
            this.RotationBar.TickFrequency = 10;
            this.RotationBar.Scroll += new System.EventHandler(this.ScrollBar_Scroll);
            this.RotationBar.MouseHover += new System.EventHandler(this.TrackHover);
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.TableLayoutPnl.Controls.Add(this.YLbl, 0, 4);
            this.TableLayoutPnl.Controls.Add(this.RotationLbl, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.XLbl, 0, 3);
            this.TableLayoutPnl.Controls.Add(this.TurnLbl, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.RotationBar, 1, 0);
            this.TableLayoutPnl.Controls.Add(this.TurnBar, 1, 1);
            this.TableLayoutPnl.Controls.Add(this.SizeLbl, 0, 5);
            this.TableLayoutPnl.Controls.Add(this.SpinLbl, 0, 2);
            this.TableLayoutPnl.Controls.Add(this.SpinBar, 1, 2);
            this.TableLayoutPnl.Controls.Add(this.SizeBar, 1, 5);
            this.TableLayoutPnl.Controls.Add(this.XUpDown, 1, 3);
            this.TableLayoutPnl.Controls.Add(this.YUpDown, 1, 4);
            this.TableLayoutPnl.Location = new System.Drawing.Point(33, 168);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 6;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPnl.Size = new System.Drawing.Size(578, 716);
            this.TableLayoutPnl.TabIndex = 131;
            // 
            // YLbl
            // 
            this.YLbl.AutoSize = true;
            this.YLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.YLbl.Location = new System.Drawing.Point(0, 454);
            this.YLbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.YLbl.Name = "YLbl";
            this.YLbl.Size = new System.Drawing.Size(49, 59);
            this.YLbl.TabIndex = 133;
            this.YLbl.Text = "Y";
            // 
            // XLbl
            // 
            this.XLbl.AutoSize = true;
            this.XLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.XLbl.Location = new System.Drawing.Point(0, 360);
            this.XLbl.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.XLbl.Name = "XLbl";
            this.XLbl.Size = new System.Drawing.Size(50, 59);
            this.XLbl.TabIndex = 132;
            this.XLbl.Text = "X";
            // 
            // XUpDown
            // 
            this.XUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XUpDown.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.XUpDown.InterceptArrowKeys = false;
            this.XUpDown.Location = new System.Drawing.Point(202, 360);
            this.XUpDown.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.XUpDown.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.XUpDown.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.XUpDown.Name = "XUpDown";
            this.XUpDown.Size = new System.Drawing.Size(376, 64);
            this.XUpDown.TabIndex = 132;
            this.XUpDown.ValueChanged += new System.EventHandler(this.UpDown_ValueChanged);
            // 
            // YUpDown
            // 
            this.YUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YUpDown.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.YUpDown.InterceptArrowKeys = false;
            this.YUpDown.Location = new System.Drawing.Point(202, 454);
            this.YUpDown.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.YUpDown.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.YUpDown.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.YUpDown.Name = "YUpDown";
            this.YUpDown.Size = new System.Drawing.Size(376, 64);
            this.YUpDown.TabIndex = 133;
            this.YUpDown.ValueChanged += new System.EventHandler(this.UpDown_ValueChanged);
            // 
            // ValueToolTip
            // 
            this.ValueToolTip.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // PositionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.PositionsLbl);
            this.Name = "PositionsPanel";
            this.Size = new System.Drawing.Size(804, 1072);
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).EndInit();
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PositionsLbl;
        private System.Windows.Forms.Label SizeLbl;
        private System.Windows.Forms.TrackBar SizeBar;
        private System.Windows.Forms.Label SpinLbl;
        private System.Windows.Forms.TrackBar SpinBar;
        private System.Windows.Forms.Label TurnLbl;
        private System.Windows.Forms.TrackBar TurnBar;
        private System.Windows.Forms.Label RotationLbl;
        private System.Windows.Forms.TrackBar RotationBar;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.ToolTip ValueToolTip;
        private System.Windows.Forms.Label YLbl;
        private System.Windows.Forms.Label XLbl;
        private System.Windows.Forms.NumericUpDown YUpDown;
        private System.Windows.Forms.NumericUpDown XUpDown;
    }
}
