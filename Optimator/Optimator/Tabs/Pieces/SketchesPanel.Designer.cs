namespace Optimator.Tabs.Pieces
{
    partial class SketchesPanel
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
            this.YLbl = new System.Windows.Forms.Label();
            this.XLbl = new System.Windows.Forms.Label();
            this.SpinLbl = new System.Windows.Forms.Label();
            this.SizeBar = new System.Windows.Forms.TrackBar();
            this.TurnLbl = new System.Windows.Forms.Label();
            this.RotationLbl = new System.Windows.Forms.Label();
            this.YUpDown = new System.Windows.Forms.NumericUpDown();
            this.XUpDown = new System.Windows.Forms.NumericUpDown();
            this.DeleteSketchBtn = new System.Windows.Forms.Button();
            this.SketchesLbl = new System.Windows.Forms.Label();
            this.SketchLb = new System.Windows.Forms.CheckedListBox();
            this.SpinBar = new System.Windows.Forms.TrackBar();
            this.TurnBar = new System.Windows.Forms.TrackBar();
            this.RotationBar = new System.Windows.Forms.TrackBar();
            this.LoadSketchBtn = new System.Windows.Forms.Button();
            this.SizeLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.ValueToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).BeginInit();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // YLbl
            // 
            this.YLbl.AutoSize = true;
            this.YLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.YLbl.Location = new System.Drawing.Point(2, 568);
            this.YLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.YLbl.Name = "YLbl";
            this.YLbl.Size = new System.Drawing.Size(189, 73);
            this.YLbl.TabIndex = 144;
            this.YLbl.Text = "Y";
            // 
            // XLbl
            // 
            this.XLbl.AutoSize = true;
            this.XLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.XLbl.Location = new System.Drawing.Point(2, 495);
            this.XLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.XLbl.Name = "XLbl";
            this.XLbl.Size = new System.Drawing.Size(189, 73);
            this.XLbl.TabIndex = 143;
            this.XLbl.Text = "X";
            // 
            // SpinLbl
            // 
            this.SpinLbl.AutoSize = true;
            this.SpinLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpinLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SpinLbl.Location = new System.Drawing.Point(2, 787);
            this.SpinLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SpinLbl.Name = "SpinLbl";
            this.SpinLbl.Size = new System.Drawing.Size(189, 73);
            this.SpinLbl.TabIndex = 137;
            this.SpinLbl.Text = "Spin";
            // 
            // SizeBar
            // 
            this.SizeBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SizeBar.Enabled = false;
            this.SizeBar.Location = new System.Drawing.Point(197, 864);
            this.SizeBar.Margin = new System.Windows.Forms.Padding(4);
            this.SizeBar.Maximum = 1000;
            this.SizeBar.Name = "SizeBar";
            this.SizeBar.Size = new System.Drawing.Size(351, 65);
            this.SizeBar.SmallChange = 5;
            this.SizeBar.TabIndex = 142;
            this.SizeBar.TickFrequency = 100;
            this.SizeBar.Value = 100;
            this.SizeBar.Scroll += new System.EventHandler(this.SketchUpdate);
            this.SizeBar.MouseHover += new System.EventHandler(this.TrackHover);
            // 
            // TurnLbl
            // 
            this.TurnLbl.AutoSize = true;
            this.TurnLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TurnLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.TurnLbl.Location = new System.Drawing.Point(2, 714);
            this.TurnLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TurnLbl.Name = "TurnLbl";
            this.TurnLbl.Size = new System.Drawing.Size(189, 73);
            this.TurnLbl.TabIndex = 141;
            this.TurnLbl.Text = "Turn";
            // 
            // RotationLbl
            // 
            this.RotationLbl.AutoSize = true;
            this.RotationLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RotationLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.RotationLbl.Location = new System.Drawing.Point(2, 641);
            this.RotationLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RotationLbl.Name = "RotationLbl";
            this.RotationLbl.Size = new System.Drawing.Size(189, 73);
            this.RotationLbl.TabIndex = 140;
            this.RotationLbl.Text = "Rotation";
            // 
            // YUpDown
            // 
            this.YUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YUpDown.Enabled = false;
            this.YUpDown.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.YUpDown.Location = new System.Drawing.Point(195, 570);
            this.YUpDown.Margin = new System.Windows.Forms.Padding(2);
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
            this.YUpDown.Size = new System.Drawing.Size(355, 64);
            this.YUpDown.TabIndex = 139;
            this.YUpDown.ValueChanged += new System.EventHandler(this.SketchUpdate);
            // 
            // XUpDown
            // 
            this.XUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XUpDown.Enabled = false;
            this.XUpDown.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.XUpDown.Location = new System.Drawing.Point(195, 497);
            this.XUpDown.Margin = new System.Windows.Forms.Padding(2);
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
            this.XUpDown.Size = new System.Drawing.Size(355, 64);
            this.XUpDown.TabIndex = 138;
            this.XUpDown.ValueChanged += new System.EventHandler(this.SketchUpdate);
            // 
            // DeleteSketchBtn
            // 
            this.DeleteSketchBtn.BackColor = System.Drawing.Color.LightCyan;
            this.TableLayoutPnl.SetColumnSpan(this.DeleteSketchBtn, 2);
            this.DeleteSketchBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteSketchBtn.Enabled = false;
            this.DeleteSketchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteSketchBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.DeleteSketchBtn.Location = new System.Drawing.Point(0, 385);
            this.DeleteSketchBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteSketchBtn.Name = "DeleteSketchBtn";
            this.DeleteSketchBtn.Size = new System.Drawing.Size(552, 110);
            this.DeleteSketchBtn.TabIndex = 136;
            this.DeleteSketchBtn.Text = "Delete";
            this.DeleteSketchBtn.UseVisualStyleBackColor = false;
            this.DeleteSketchBtn.Click += new System.EventHandler(this.SketchUpdate);
            // 
            // SketchesLbl
            // 
            this.SketchesLbl.AutoSize = true;
            this.SketchesLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.SketchesLbl.Location = new System.Drawing.Point(41, 55);
            this.SketchesLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SketchesLbl.Name = "SketchesLbl";
            this.SketchesLbl.Size = new System.Drawing.Size(251, 72);
            this.SketchesLbl.TabIndex = 135;
            this.SketchesLbl.Text = "Sketches";
            // 
            // SketchLb
            // 
            this.SketchLb.BackColor = System.Drawing.SystemColors.Window;
            this.TableLayoutPnl.SetColumnSpan(this.SketchLb, 2);
            this.SketchLb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SketchLb.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SketchLb.FormattingEnabled = true;
            this.SketchLb.Location = new System.Drawing.Point(4, 4);
            this.SketchLb.Margin = new System.Windows.Forms.Padding(4);
            this.SketchLb.Name = "SketchLb";
            this.SketchLb.Size = new System.Drawing.Size(544, 377);
            this.SketchLb.TabIndex = 134;
            this.SketchLb.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.SketchLb_ItemCheck);
            this.SketchLb.SelectedIndexChanged += new System.EventHandler(this.SketchLb_SelectedIndexChanged);
            // 
            // SpinBar
            // 
            this.SpinBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpinBar.Enabled = false;
            this.SpinBar.Location = new System.Drawing.Point(197, 791);
            this.SpinBar.Margin = new System.Windows.Forms.Padding(4);
            this.SpinBar.Maximum = 359;
            this.SpinBar.Name = "SpinBar";
            this.SpinBar.Size = new System.Drawing.Size(351, 65);
            this.SpinBar.TabIndex = 147;
            this.SpinBar.TickFrequency = 30;
            this.SpinBar.Scroll += new System.EventHandler(this.SketchUpdate);
            this.SpinBar.MouseHover += new System.EventHandler(this.TrackHover);
            // 
            // TurnBar
            // 
            this.TurnBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TurnBar.Enabled = false;
            this.TurnBar.Location = new System.Drawing.Point(197, 718);
            this.TurnBar.Margin = new System.Windows.Forms.Padding(4);
            this.TurnBar.Maximum = 359;
            this.TurnBar.Name = "TurnBar";
            this.TurnBar.Size = new System.Drawing.Size(351, 65);
            this.TurnBar.TabIndex = 146;
            this.TurnBar.TickFrequency = 30;
            this.TurnBar.Scroll += new System.EventHandler(this.SketchUpdate);
            this.TurnBar.MouseHover += new System.EventHandler(this.TrackHover);
            // 
            // RotationBar
            // 
            this.RotationBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RotationBar.Enabled = false;
            this.RotationBar.Location = new System.Drawing.Point(197, 645);
            this.RotationBar.Margin = new System.Windows.Forms.Padding(4);
            this.RotationBar.Maximum = 359;
            this.RotationBar.Name = "RotationBar";
            this.RotationBar.Size = new System.Drawing.Size(351, 65);
            this.RotationBar.TabIndex = 145;
            this.RotationBar.TickFrequency = 30;
            this.RotationBar.Scroll += new System.EventHandler(this.SketchUpdate);
            this.RotationBar.MouseHover += new System.EventHandler(this.TrackHover);
            // 
            // LoadSketchBtn
            // 
            this.LoadSketchBtn.BackColor = System.Drawing.Color.LightCyan;
            this.TableLayoutPnl.SetColumnSpan(this.LoadSketchBtn, 2);
            this.LoadSketchBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadSketchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadSketchBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.LoadSketchBtn.Location = new System.Drawing.Point(6, 939);
            this.LoadSketchBtn.Margin = new System.Windows.Forms.Padding(6);
            this.LoadSketchBtn.Name = "LoadSketchBtn";
            this.LoadSketchBtn.Size = new System.Drawing.Size(540, 155);
            this.LoadSketchBtn.TabIndex = 148;
            this.LoadSketchBtn.Text = "Load Sketch";
            this.LoadSketchBtn.UseVisualStyleBackColor = false;
            this.LoadSketchBtn.Click += new System.EventHandler(this.LoadSketchBtn_Click);
            // 
            // SizeLbl
            // 
            this.SizeLbl.AutoSize = true;
            this.SizeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SizeLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SizeLbl.Location = new System.Drawing.Point(2, 860);
            this.SizeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SizeLbl.Name = "SizeLbl";
            this.SizeLbl.Size = new System.Drawing.Size(189, 73);
            this.SizeLbl.TabIndex = 149;
            this.SizeLbl.Text = "Size";
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.TableLayoutPnl.Controls.Add(this.DeleteSketchBtn, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.SketchLb, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.SizeBar, 1, 7);
            this.TableLayoutPnl.Controls.Add(this.SizeLbl, 0, 7);
            this.TableLayoutPnl.Controls.Add(this.SpinLbl, 0, 6);
            this.TableLayoutPnl.Controls.Add(this.YLbl, 0, 3);
            this.TableLayoutPnl.Controls.Add(this.SpinBar, 1, 6);
            this.TableLayoutPnl.Controls.Add(this.LoadSketchBtn, 0, 8);
            this.TableLayoutPnl.Controls.Add(this.TurnLbl, 0, 5);
            this.TableLayoutPnl.Controls.Add(this.XLbl, 0, 2);
            this.TableLayoutPnl.Controls.Add(this.TurnBar, 1, 5);
            this.TableLayoutPnl.Controls.Add(this.RotationLbl, 0, 4);
            this.TableLayoutPnl.Controls.Add(this.XUpDown, 1, 2);
            this.TableLayoutPnl.Controls.Add(this.YUpDown, 1, 3);
            this.TableLayoutPnl.Controls.Add(this.RotationBar, 1, 4);
            this.TableLayoutPnl.Location = new System.Drawing.Point(51, 151);
            this.TableLayoutPnl.MinimumSize = new System.Drawing.Size(0, 1100);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 9;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.014F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.004F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.662664F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.662664F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.662664F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.662664F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.662664F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.662664F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.006F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(552, 1100);
            this.TableLayoutPnl.TabIndex = 150;
            // 
            // ValueToolTip
            // 
            this.ValueToolTip.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // SketchesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.SketchesLbl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SketchesPanel";
            this.Size = new System.Drawing.Size(1848, 1305);
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).EndInit();
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label YLbl;
        private System.Windows.Forms.Label XLbl;
        private System.Windows.Forms.Label SpinLbl;
        private System.Windows.Forms.TrackBar SizeBar;
        private System.Windows.Forms.Label TurnLbl;
        private System.Windows.Forms.Label RotationLbl;
        private System.Windows.Forms.NumericUpDown YUpDown;
        private System.Windows.Forms.NumericUpDown XUpDown;
        private System.Windows.Forms.Button DeleteSketchBtn;
        private System.Windows.Forms.Label SketchesLbl;
        private System.Windows.Forms.CheckedListBox SketchLb;
        private System.Windows.Forms.TrackBar SpinBar;
        private System.Windows.Forms.TrackBar TurnBar;
        private System.Windows.Forms.TrackBar RotationBar;
        private System.Windows.Forms.Button LoadSketchBtn;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Label SizeLbl;
        private System.Windows.Forms.ToolTip ValueToolTip;
    }
}
