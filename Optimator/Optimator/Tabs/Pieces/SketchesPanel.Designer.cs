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
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).BeginInit();
            this.SuspendLayout();
            // 
            // YLbl
            // 
            this.YLbl.AutoSize = true;
            this.YLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YLbl.Location = new System.Drawing.Point(297, 430);
            this.YLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.YLbl.Name = "YLbl";
            this.YLbl.Size = new System.Drawing.Size(35, 39);
            this.YLbl.TabIndex = 144;
            this.YLbl.Text = "Y";
            // 
            // XLbl
            // 
            this.XLbl.AutoSize = true;
            this.XLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XLbl.Location = new System.Drawing.Point(297, 368);
            this.XLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.XLbl.Name = "XLbl";
            this.XLbl.Size = new System.Drawing.Size(36, 39);
            this.XLbl.TabIndex = 143;
            this.XLbl.Text = "X";
            // 
            // SpinLbl
            // 
            this.SpinLbl.AutoSize = true;
            this.SpinLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpinLbl.Location = new System.Drawing.Point(96, 492);
            this.SpinLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SpinLbl.Name = "SpinLbl";
            this.SpinLbl.Size = new System.Drawing.Size(78, 39);
            this.SpinLbl.TabIndex = 137;
            this.SpinLbl.Text = "Spin";
            // 
            // SizeBar
            // 
            this.SizeBar.Location = new System.Drawing.Point(97, 630);
            this.SizeBar.Maximum = 1000;
            this.SizeBar.Name = "SizeBar";
            this.SizeBar.Size = new System.Drawing.Size(189, 90);
            this.SizeBar.SmallChange = 5;
            this.SizeBar.TabIndex = 142;
            this.SizeBar.TickFrequency = 100;
            this.SizeBar.Value = 100;
            this.SizeBar.Scroll += new System.EventHandler(this.SketchUpdate);
            // 
            // TurnLbl
            // 
            this.TurnLbl.AutoSize = true;
            this.TurnLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnLbl.Location = new System.Drawing.Point(96, 428);
            this.TurnLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TurnLbl.Name = "TurnLbl";
            this.TurnLbl.Size = new System.Drawing.Size(84, 39);
            this.TurnLbl.TabIndex = 141;
            this.TurnLbl.Text = "Turn";
            // 
            // RotationLbl
            // 
            this.RotationLbl.AutoSize = true;
            this.RotationLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotationLbl.Location = new System.Drawing.Point(96, 363);
            this.RotationLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RotationLbl.Name = "RotationLbl";
            this.RotationLbl.Size = new System.Drawing.Size(135, 39);
            this.RotationLbl.TabIndex = 140;
            this.RotationLbl.Text = "Rotation";
            // 
            // YUpDown
            // 
            this.YUpDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YUpDown.Location = new System.Drawing.Point(301, 454);
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
            this.YUpDown.Size = new System.Drawing.Size(162, 46);
            this.YUpDown.TabIndex = 139;
            this.YUpDown.ValueChanged += new System.EventHandler(this.SketchUpdate);
            // 
            // XUpDown
            // 
            this.XUpDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XUpDown.Location = new System.Drawing.Point(301, 390);
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
            this.XUpDown.Size = new System.Drawing.Size(162, 46);
            this.XUpDown.TabIndex = 138;
            this.XUpDown.ValueChanged += new System.EventHandler(this.SketchUpdate);
            // 
            // DeleteSketchBtn
            // 
            this.DeleteSketchBtn.BackColor = System.Drawing.Color.LightCyan;
            this.DeleteSketchBtn.Enabled = false;
            this.DeleteSketchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteSketchBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSketchBtn.Location = new System.Drawing.Point(100, 318);
            this.DeleteSketchBtn.Margin = new System.Windows.Forms.Padding(6);
            this.DeleteSketchBtn.Name = "DeleteSketchBtn";
            this.DeleteSketchBtn.Size = new System.Drawing.Size(363, 35);
            this.DeleteSketchBtn.TabIndex = 136;
            this.DeleteSketchBtn.Text = "Delete Sketch";
            this.DeleteSketchBtn.UseVisualStyleBackColor = false;
            this.DeleteSketchBtn.Click += new System.EventHandler(this.SketchUpdate);
            // 
            // SketchesLbl
            // 
            this.SketchesLbl.AutoSize = true;
            this.SketchesLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SketchesLbl.Location = new System.Drawing.Point(220, 117);
            this.SketchesLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SketchesLbl.Name = "SketchesLbl";
            this.SketchesLbl.Size = new System.Drawing.Size(193, 46);
            this.SketchesLbl.TabIndex = 135;
            this.SketchesLbl.Text = "Sketches";
            // 
            // SketchLb
            // 
            this.SketchLb.BackColor = System.Drawing.SystemColors.Window;
            this.SketchLb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SketchLb.FormattingEnabled = true;
            this.SketchLb.Location = new System.Drawing.Point(100, 149);
            this.SketchLb.Name = "SketchLb";
            this.SketchLb.Size = new System.Drawing.Size(363, 127);
            this.SketchLb.TabIndex = 134;
            // 
            // SpinBar
            // 
            this.SpinBar.Location = new System.Drawing.Point(97, 534);
            this.SpinBar.Maximum = 359;
            this.SpinBar.Name = "SpinBar";
            this.SpinBar.Size = new System.Drawing.Size(189, 90);
            this.SpinBar.TabIndex = 147;
            this.SpinBar.TickFrequency = 30;
            this.SpinBar.Scroll += new System.EventHandler(this.SketchUpdate);
            // 
            // TurnBar
            // 
            this.TurnBar.Location = new System.Drawing.Point(97, 467);
            this.TurnBar.Maximum = 359;
            this.TurnBar.Name = "TurnBar";
            this.TurnBar.Size = new System.Drawing.Size(189, 90);
            this.TurnBar.TabIndex = 146;
            this.TurnBar.TickFrequency = 30;
            this.TurnBar.Scroll += new System.EventHandler(this.SketchUpdate);
            // 
            // RotationBar
            // 
            this.RotationBar.Location = new System.Drawing.Point(97, 403);
            this.RotationBar.Maximum = 359;
            this.RotationBar.Name = "RotationBar";
            this.RotationBar.Size = new System.Drawing.Size(189, 90);
            this.RotationBar.TabIndex = 145;
            this.RotationBar.TickFrequency = 30;
            this.RotationBar.Scroll += new System.EventHandler(this.SketchUpdate);
            // 
            // SketchesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.YLbl);
            this.Controls.Add(this.XLbl);
            this.Controls.Add(this.SpinLbl);
            this.Controls.Add(this.SizeBar);
            this.Controls.Add(this.TurnLbl);
            this.Controls.Add(this.RotationLbl);
            this.Controls.Add(this.YUpDown);
            this.Controls.Add(this.XUpDown);
            this.Controls.Add(this.DeleteSketchBtn);
            this.Controls.Add(this.SketchesLbl);
            this.Controls.Add(this.SketchLb);
            this.Controls.Add(this.SpinBar);
            this.Controls.Add(this.TurnBar);
            this.Controls.Add(this.RotationBar);
            this.Name = "SketchesPanel";
            this.Size = new System.Drawing.Size(830, 1086);
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).EndInit();
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
    }
}
