namespace Animator
{
    partial class PiecesForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NamePanel = new System.Windows.Forms.Panel();
            this.pointCb = new System.Windows.Forms.CheckBox();
            this.DoneBtn = new System.Windows.Forms.Button();
            this.NameTb = new System.Windows.Forms.TextBox();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.SwitchBtnOptions = new System.Windows.Forms.Button();
            this.loadTb = new System.Windows.Forms.TextBox();
            this.tToUpDown = new System.Windows.Forms.NumericUpDown();
            this.tFromUpDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.rToUpDown = new System.Windows.Forms.NumericUpDown();
            this.rFromUpDown = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.midFillCb = new System.Windows.Forms.CheckBox();
            this.sketchBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.wrUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.gradAngleUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numColUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.OutlineRb = new System.Windows.Forms.RadioButton();
            this.FillRb = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.AlphaUpDown = new System.Windows.Forms.NumericUpDown();
            this.BlueUpDown = new System.Windows.Forms.NumericUpDown();
            this.GreenUpDown = new System.Windows.Forms.NumericUpDown();
            this.RedUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PiecePanel = new System.Windows.Forms.Panel();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.PointsLb = new System.Windows.Forms.ListBox();
            this.OutlineWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.BaseBtn = new System.Windows.Forms.Button();
            this.RotateBtn = new System.Windows.Forms.Button();
            this.TurnBtn = new System.Windows.Forms.Button();
            this.NextAngleBtn = new System.Windows.Forms.Button();
            this.FixedCb = new System.Windows.Forms.CheckBox();
            this.UpBtn = new System.Windows.Forms.Button();
            this.DownBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.YUpDown = new System.Windows.Forms.NumericUpDown();
            this.JoinOptions = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.XUpDown = new System.Windows.Forms.NumericUpDown();
            this.AddPointBtn = new System.Windows.Forms.Button();
            this.SwitchBtn = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.DrawPanel = new System.Windows.Forms.PictureBox();
            this.NamePanel.SuspendLayout();
            this.OptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tToUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tFromUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rToUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFromUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wrUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradAngleUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedUpDown)).BeginInit();
            this.PiecePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutlineWidthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // NamePanel
            // 
            this.NamePanel.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.NamePanel.Controls.Add(this.pointCb);
            this.NamePanel.Controls.Add(this.DoneBtn);
            this.NamePanel.Controls.Add(this.NameTb);
            this.NamePanel.Location = new System.Drawing.Point(0, 0);
            this.NamePanel.Name = "NamePanel";
            this.NamePanel.Size = new System.Drawing.Size(1312, 100);
            this.NamePanel.TabIndex = 1;
            // 
            // pointCb
            // 
            this.pointCb.AutoSize = true;
            this.pointCb.Font = new System.Drawing.Font("Century Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointCb.ForeColor = System.Drawing.Color.Black;
            this.pointCb.Location = new System.Drawing.Point(862, 29);
            this.pointCb.Name = "pointCb";
            this.pointCb.Size = new System.Drawing.Size(140, 48);
            this.pointCb.TabIndex = 48;
            this.pointCb.Text = "Point";
            this.pointCb.UseVisualStyleBackColor = true;
            this.pointCb.CheckedChanged += new System.EventHandler(this.pointCb_CheckedChanged);
            // 
            // DoneBtn
            // 
            this.DoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoneBtn.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneBtn.Location = new System.Drawing.Point(1031, 15);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(259, 71);
            this.DoneBtn.TabIndex = 1;
            this.DoneBtn.Text = "Done";
            this.DoneBtn.UseVisualStyleBackColor = true;
            this.DoneBtn.Click += new System.EventHandler(this.DoneBtn_Click);
            // 
            // NameTb
            // 
            this.NameTb.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.NameTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameTb.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTb.Location = new System.Drawing.Point(69, 21);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(627, 59);
            this.NameTb.TabIndex = 0;
            this.NameTb.Text = "Item Name";
            this.NameTb.TextChanged += new System.EventHandler(this.NameTb_TextChanged);
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.BackColor = System.Drawing.Color.SlateBlue;
            this.OptionsPanel.Controls.Add(this.SwitchBtnOptions);
            this.OptionsPanel.Controls.Add(this.loadTb);
            this.OptionsPanel.Controls.Add(this.tToUpDown);
            this.OptionsPanel.Controls.Add(this.tFromUpDown);
            this.OptionsPanel.Controls.Add(this.label13);
            this.OptionsPanel.Controls.Add(this.rToUpDown);
            this.OptionsPanel.Controls.Add(this.rFromUpDown);
            this.OptionsPanel.Controls.Add(this.label12);
            this.OptionsPanel.Controls.Add(this.midFillCb);
            this.OptionsPanel.Controls.Add(this.sketchBtn);
            this.OptionsPanel.Controls.Add(this.loadBtn);
            this.OptionsPanel.Controls.Add(this.wrUpDown);
            this.OptionsPanel.Controls.Add(this.label11);
            this.OptionsPanel.Controls.Add(this.gradAngleUpDown);
            this.OptionsPanel.Controls.Add(this.label10);
            this.OptionsPanel.Controls.Add(this.label8);
            this.OptionsPanel.Controls.Add(this.numColUpDown);
            this.OptionsPanel.Controls.Add(this.label4);
            this.OptionsPanel.Controls.Add(this.OutlineRb);
            this.OptionsPanel.Controls.Add(this.FillRb);
            this.OptionsPanel.Controls.Add(this.label6);
            this.OptionsPanel.Controls.Add(this.AlphaUpDown);
            this.OptionsPanel.Controls.Add(this.BlueUpDown);
            this.OptionsPanel.Controls.Add(this.GreenUpDown);
            this.OptionsPanel.Controls.Add(this.RedUpDown);
            this.OptionsPanel.Controls.Add(this.label3);
            this.OptionsPanel.Controls.Add(this.label2);
            this.OptionsPanel.Controls.Add(this.label1);
            this.OptionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.OptionsPanel.Location = new System.Drawing.Point(1312, 0);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(412, 1329);
            this.OptionsPanel.TabIndex = 2;
            this.OptionsPanel.Visible = false;
            // 
            // SwitchBtnOptions
            // 
            this.SwitchBtnOptions.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SwitchBtnOptions.Location = new System.Drawing.Point(32, 22);
            this.SwitchBtnOptions.Name = "SwitchBtnOptions";
            this.SwitchBtnOptions.Size = new System.Drawing.Size(361, 82);
            this.SwitchBtnOptions.TabIndex = 71;
            this.SwitchBtnOptions.Text = "Define Shape";
            this.SwitchBtnOptions.UseVisualStyleBackColor = true;
            this.SwitchBtnOptions.Click += new System.EventHandler(this.SwitchBtnOptions_Click);
            // 
            // loadTb
            // 
            this.loadTb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadTb.Location = new System.Drawing.Point(26, 996);
            this.loadTb.Name = "loadTb";
            this.loadTb.Size = new System.Drawing.Size(361, 47);
            this.loadTb.TabIndex = 68;
            this.loadTb.Text = "Item Name";
            // 
            // tToUpDown
            // 
            this.tToUpDown.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tToUpDown.Location = new System.Drawing.Point(237, 882);
            this.tToUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.tToUpDown.Name = "tToUpDown";
            this.tToUpDown.Size = new System.Drawing.Size(150, 41);
            this.tToUpDown.TabIndex = 54;
            this.tToUpDown.ValueChanged += new System.EventHandler(this.tToUpDown_ValueChanged);
            // 
            // tFromUpDown
            // 
            this.tFromUpDown.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tFromUpDown.Location = new System.Drawing.Point(70, 882);
            this.tFromUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.tFromUpDown.Name = "tFromUpDown";
            this.tFromUpDown.Size = new System.Drawing.Size(150, 41);
            this.tFromUpDown.TabIndex = 52;
            this.tFromUpDown.ValueChanged += new System.EventHandler(this.tFromUpDown_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(22, 879);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 39);
            this.label13.TabIndex = 53;
            this.label13.Text = "T";
            // 
            // rToUpDown
            // 
            this.rToUpDown.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rToUpDown.Location = new System.Drawing.Point(237, 827);
            this.rToUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.rToUpDown.Name = "rToUpDown";
            this.rToUpDown.Size = new System.Drawing.Size(150, 41);
            this.rToUpDown.TabIndex = 51;
            this.rToUpDown.ValueChanged += new System.EventHandler(this.rToUpDown_ValueChanged);
            // 
            // rFromUpDown
            // 
            this.rFromUpDown.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rFromUpDown.Location = new System.Drawing.Point(70, 827);
            this.rFromUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.rFromUpDown.Name = "rFromUpDown";
            this.rFromUpDown.Size = new System.Drawing.Size(150, 41);
            this.rFromUpDown.TabIndex = 49;
            this.rFromUpDown.ValueChanged += new System.EventHandler(this.rFromUpDown_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(22, 824);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 39);
            this.label12.TabIndex = 50;
            this.label12.Text = "R";
            // 
            // midFillCb
            // 
            this.midFillCb.AutoSize = true;
            this.midFillCb.Enabled = false;
            this.midFillCb.Font = new System.Drawing.Font("Century Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.midFillCb.ForeColor = System.Drawing.Color.Black;
            this.midFillCb.Location = new System.Drawing.Point(53, 343);
            this.midFillCb.Name = "midFillCb";
            this.midFillCb.Size = new System.Drawing.Size(200, 48);
            this.midFillCb.TabIndex = 46;
            this.midFillCb.Text = "Centred";
            this.midFillCb.UseVisualStyleBackColor = true;
            this.midFillCb.CheckedChanged += new System.EventHandler(this.midFillCb_CheckedChanged);
            // 
            // sketchBtn
            // 
            this.sketchBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sketchBtn.Location = new System.Drawing.Point(26, 1162);
            this.sketchBtn.Name = "sketchBtn";
            this.sketchBtn.Size = new System.Drawing.Size(361, 82);
            this.sketchBtn.TabIndex = 45;
            this.sketchBtn.Text = "Sketch";
            this.sketchBtn.UseVisualStyleBackColor = true;
            this.sketchBtn.Click += new System.EventHandler(this.sketchBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadBtn.Location = new System.Drawing.Point(26, 1064);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(361, 82);
            this.loadBtn.TabIndex = 44;
            this.loadBtn.Text = "Load ";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // wrUpDown
            // 
            this.wrUpDown.BackColor = System.Drawing.SystemColors.HighlightText;
            this.wrUpDown.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wrUpDown.Location = new System.Drawing.Point(144, 760);
            this.wrUpDown.Name = "wrUpDown";
            this.wrUpDown.Size = new System.Drawing.Size(123, 47);
            this.wrUpDown.TabIndex = 10;
            this.wrUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.wrUpDown.ValueChanged += new System.EventHandler(this.wrUpDown_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(51, 702);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(309, 44);
            this.label11.TabIndex = 43;
            this.label11.Text = "Wind Resistance";
            // 
            // gradAngleUpDown
            // 
            this.gradAngleUpDown.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gradAngleUpDown.Enabled = false;
            this.gradAngleUpDown.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradAngleUpDown.Location = new System.Drawing.Point(221, 286);
            this.gradAngleUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.gradAngleUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.gradAngleUpDown.Name = "gradAngleUpDown";
            this.gradAngleUpDown.Size = new System.Drawing.Size(123, 47);
            this.gradAngleUpDown.TabIndex = 42;
            this.gradAngleUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(53, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 44);
            this.label10.TabIndex = 41;
            this.label10.Text = "Angle";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(52, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 44);
            this.label8.TabIndex = 40;
            this.label8.Text = "Number";
            // 
            // numColUpDown
            // 
            this.numColUpDown.BackColor = System.Drawing.SystemColors.HighlightText;
            this.numColUpDown.Enabled = false;
            this.numColUpDown.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numColUpDown.Location = new System.Drawing.Point(221, 232);
            this.numColUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numColUpDown.Name = "numColUpDown";
            this.numColUpDown.Size = new System.Drawing.Size(123, 47);
            this.numColUpDown.TabIndex = 39;
            this.numColUpDown.ValueChanged += new System.EventHandler(this.numColUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(136, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 44);
            this.label4.TabIndex = 37;
            this.label4.Text = "Colour";
            // 
            // OutlineRb
            // 
            this.OutlineRb.AutoSize = true;
            this.OutlineRb.Checked = true;
            this.OutlineRb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutlineRb.Location = new System.Drawing.Point(211, 182);
            this.OutlineRb.Name = "OutlineRb";
            this.OutlineRb.Size = new System.Drawing.Size(159, 43);
            this.OutlineRb.TabIndex = 15;
            this.OutlineRb.TabStop = true;
            this.OutlineRb.Text = "Outline";
            this.OutlineRb.UseVisualStyleBackColor = true;
            this.OutlineRb.CheckedChanged += new System.EventHandler(this.OutlineRb_CheckedChanged);
            // 
            // FillRb
            // 
            this.FillRb.AutoSize = true;
            this.FillRb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FillRb.Location = new System.Drawing.Point(60, 182);
            this.FillRb.Name = "FillRb";
            this.FillRb.Size = new System.Drawing.Size(83, 43);
            this.FillRb.TabIndex = 14;
            this.FillRb.Text = "Fill";
            this.FillRb.UseVisualStyleBackColor = true;
            this.FillRb.CheckedChanged += new System.EventHandler(this.FillRb_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 407);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 44);
            this.label6.TabIndex = 13;
            this.label6.Text = "Alpha";
            // 
            // AlphaUpDown
            // 
            this.AlphaUpDown.BackColor = System.Drawing.SystemColors.HighlightText;
            this.AlphaUpDown.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlphaUpDown.Location = new System.Drawing.Point(221, 408);
            this.AlphaUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AlphaUpDown.Name = "AlphaUpDown";
            this.AlphaUpDown.Size = new System.Drawing.Size(120, 47);
            this.AlphaUpDown.TabIndex = 12;
            this.AlphaUpDown.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AlphaUpDown.ValueChanged += new System.EventHandler(this.AlphaUpDown_ValueChanged);
            // 
            // BlueUpDown
            // 
            this.BlueUpDown.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BlueUpDown.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueUpDown.Location = new System.Drawing.Point(221, 606);
            this.BlueUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueUpDown.Name = "BlueUpDown";
            this.BlueUpDown.Size = new System.Drawing.Size(120, 47);
            this.BlueUpDown.TabIndex = 11;
            this.BlueUpDown.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueUpDown.ValueChanged += new System.EventHandler(this.BlueUpDown_ValueChanged);
            // 
            // GreenUpDown
            // 
            this.GreenUpDown.BackColor = System.Drawing.SystemColors.HighlightText;
            this.GreenUpDown.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenUpDown.Location = new System.Drawing.Point(221, 540);
            this.GreenUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenUpDown.Name = "GreenUpDown";
            this.GreenUpDown.Size = new System.Drawing.Size(120, 47);
            this.GreenUpDown.TabIndex = 10;
            this.GreenUpDown.Value = new decimal(new int[] {
            204,
            0,
            0,
            0});
            this.GreenUpDown.ValueChanged += new System.EventHandler(this.GreenUpDown_ValueChanged);
            // 
            // RedUpDown
            // 
            this.RedUpDown.BackColor = System.Drawing.SystemColors.HighlightText;
            this.RedUpDown.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedUpDown.Location = new System.Drawing.Point(221, 474);
            this.RedUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedUpDown.Name = "RedUpDown";
            this.RedUpDown.Size = new System.Drawing.Size(120, 47);
            this.RedUpDown.TabIndex = 9;
            this.RedUpDown.Value = new decimal(new int[] {
            204,
            0,
            0,
            0});
            this.RedUpDown.ValueChanged += new System.EventHandler(this.RedUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 605);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 44);
            this.label3.TabIndex = 2;
            this.label3.Text = "Blue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 539);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "Green";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 473);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Red";
            // 
            // PiecePanel
            // 
            this.PiecePanel.BackColor = System.Drawing.Color.SlateBlue;
            this.PiecePanel.Controls.Add(this.ClearBtn);
            this.PiecePanel.Controls.Add(this.ResetBtn);
            this.PiecePanel.Controls.Add(this.PointsLb);
            this.PiecePanel.Controls.Add(this.OutlineWidthUpDown);
            this.PiecePanel.Controls.Add(this.label15);
            this.PiecePanel.Controls.Add(this.BaseBtn);
            this.PiecePanel.Controls.Add(this.RotateBtn);
            this.PiecePanel.Controls.Add(this.TurnBtn);
            this.PiecePanel.Controls.Add(this.NextAngleBtn);
            this.PiecePanel.Controls.Add(this.FixedCb);
            this.PiecePanel.Controls.Add(this.UpBtn);
            this.PiecePanel.Controls.Add(this.DownBtn);
            this.PiecePanel.Controls.Add(this.DeleteBtn);
            this.PiecePanel.Controls.Add(this.YUpDown);
            this.PiecePanel.Controls.Add(this.JoinOptions);
            this.PiecePanel.Controls.Add(this.label18);
            this.PiecePanel.Controls.Add(this.XUpDown);
            this.PiecePanel.Controls.Add(this.AddPointBtn);
            this.PiecePanel.Controls.Add(this.SwitchBtn);
            this.PiecePanel.Controls.Add(this.label23);
            this.PiecePanel.Controls.Add(this.label24);
            this.PiecePanel.Location = new System.Drawing.Point(1312, 0);
            this.PiecePanel.Name = "PiecePanel";
            this.PiecePanel.Size = new System.Drawing.Size(412, 1329);
            this.PiecePanel.TabIndex = 3;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.Location = new System.Drawing.Point(213, 1124);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(174, 82);
            this.ClearBtn.TabIndex = 70;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            // 
            // ResetBtn
            // 
            this.ResetBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetBtn.Location = new System.Drawing.Point(26, 1124);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(181, 82);
            this.ResetBtn.TabIndex = 69;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = true;
            // 
            // PointsLb
            // 
            this.PointsLb.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointsLb.FormattingEnabled = true;
            this.PointsLb.ItemHeight = 33;
            this.PointsLb.Location = new System.Drawing.Point(26, 267);
            this.PointsLb.Name = "PointsLb";
            this.PointsLb.Size = new System.Drawing.Size(360, 235);
            this.PointsLb.TabIndex = 17;
            // 
            // OutlineWidthUpDown
            // 
            this.OutlineWidthUpDown.BackColor = System.Drawing.SystemColors.HighlightText;
            this.OutlineWidthUpDown.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutlineWidthUpDown.Location = new System.Drawing.Point(156, 949);
            this.OutlineWidthUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.OutlineWidthUpDown.Name = "OutlineWidthUpDown";
            this.OutlineWidthUpDown.Size = new System.Drawing.Size(123, 47);
            this.OutlineWidthUpDown.TabIndex = 66;
            this.OutlineWidthUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(78, 882);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(257, 44);
            this.label15.TabIndex = 67;
            this.label15.Text = "Outline Width";
            // 
            // BaseBtn
            // 
            this.BaseBtn.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseBtn.Location = new System.Drawing.Point(25, 202);
            this.BaseBtn.Name = "BaseBtn";
            this.BaseBtn.Size = new System.Drawing.Size(116, 59);
            this.BaseBtn.TabIndex = 63;
            this.BaseBtn.Text = "Base";
            this.BaseBtn.UseVisualStyleBackColor = true;
            // 
            // RotateBtn
            // 
            this.RotateBtn.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotateBtn.Location = new System.Drawing.Point(148, 202);
            this.RotateBtn.Name = "RotateBtn";
            this.RotateBtn.Size = new System.Drawing.Size(116, 59);
            this.RotateBtn.TabIndex = 64;
            this.RotateBtn.Text = "Rot";
            this.RotateBtn.UseVisualStyleBackColor = true;
            // 
            // TurnBtn
            // 
            this.TurnBtn.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnBtn.Location = new System.Drawing.Point(271, 202);
            this.TurnBtn.Name = "TurnBtn";
            this.TurnBtn.Size = new System.Drawing.Size(116, 59);
            this.TurnBtn.TabIndex = 65;
            this.TurnBtn.Text = "Turn";
            this.TurnBtn.UseVisualStyleBackColor = true;
            // 
            // NextAngleBtn
            // 
            this.NextAngleBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextAngleBtn.Location = new System.Drawing.Point(26, 1223);
            this.NextAngleBtn.Name = "NextAngleBtn";
            this.NextAngleBtn.Size = new System.Drawing.Size(361, 82);
            this.NextAngleBtn.TabIndex = 62;
            this.NextAngleBtn.Text = "Next Angle";
            this.NextAngleBtn.UseVisualStyleBackColor = true;
            // 
            // FixedCb
            // 
            this.FixedCb.AutoSize = true;
            this.FixedCb.Checked = true;
            this.FixedCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FixedCb.Font = new System.Drawing.Font("Century Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FixedCb.ForeColor = System.Drawing.Color.Black;
            this.FixedCb.Location = new System.Drawing.Point(40, 801);
            this.FixedCb.Name = "FixedCb";
            this.FixedCb.Size = new System.Drawing.Size(145, 48);
            this.FixedCb.TabIndex = 47;
            this.FixedCb.Text = "Fixed";
            this.FixedCb.UseVisualStyleBackColor = true;
            // 
            // UpBtn
            // 
            this.UpBtn.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpBtn.Location = new System.Drawing.Point(27, 512);
            this.UpBtn.Name = "UpBtn";
            this.UpBtn.Size = new System.Drawing.Size(116, 59);
            this.UpBtn.TabIndex = 23;
            this.UpBtn.Text = "Up";
            this.UpBtn.UseVisualStyleBackColor = true;
            // 
            // DownBtn
            // 
            this.DownBtn.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownBtn.Location = new System.Drawing.Point(148, 512);
            this.DownBtn.Name = "DownBtn";
            this.DownBtn.Size = new System.Drawing.Size(116, 59);
            this.DownBtn.TabIndex = 24;
            this.DownBtn.Text = "Down";
            this.DownBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.Location = new System.Drawing.Point(270, 512);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(116, 59);
            this.DeleteBtn.TabIndex = 25;
            this.DeleteBtn.Text = "Del";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // YUpDown
            // 
            this.YUpDown.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YUpDown.Location = new System.Drawing.Point(250, 624);
            this.YUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.YUpDown.Name = "YUpDown";
            this.YUpDown.Size = new System.Drawing.Size(120, 41);
            this.YUpDown.TabIndex = 22;
            // 
            // JoinOptions
            // 
            this.JoinOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.JoinOptions.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinOptions.FormattingEnabled = true;
            this.JoinOptions.Items.AddRange(new object[] {
            "line",
            "none"});
            this.JoinOptions.Location = new System.Drawing.Point(112, 693);
            this.JoinOptions.Name = "JoinOptions";
            this.JoinOptions.Size = new System.Drawing.Size(258, 41);
            this.JoinOptions.TabIndex = 35;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(16, 691);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 39);
            this.label18.TabIndex = 34;
            this.label18.Text = "Join";
            // 
            // XUpDown
            // 
            this.XUpDown.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XUpDown.Location = new System.Drawing.Point(67, 624);
            this.XUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.XUpDown.Name = "XUpDown";
            this.XUpDown.Size = new System.Drawing.Size(120, 41);
            this.XUpDown.TabIndex = 21;
            // 
            // AddPointBtn
            // 
            this.AddPointBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPointBtn.Location = new System.Drawing.Point(26, 114);
            this.AddPointBtn.Name = "AddPointBtn";
            this.AddPointBtn.Size = new System.Drawing.Size(361, 82);
            this.AddPointBtn.TabIndex = 16;
            this.AddPointBtn.Text = "Add Point";
            this.AddPointBtn.UseVisualStyleBackColor = true;
            // 
            // SwitchBtn
            // 
            this.SwitchBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SwitchBtn.Location = new System.Drawing.Point(26, 22);
            this.SwitchBtn.Name = "SwitchBtn";
            this.SwitchBtn.Size = new System.Drawing.Size(361, 82);
            this.SwitchBtn.TabIndex = 36;
            this.SwitchBtn.Text = "Define Shape";
            this.SwitchBtn.UseVisualStyleBackColor = true;
            this.SwitchBtn.Click += new System.EventHandler(this.SwitchBtn_Click_2);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(193, 621);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 39);
            this.label23.TabIndex = 27;
            this.label23.Text = "Y";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(25, 626);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(36, 39);
            this.label24.TabIndex = 26;
            this.label24.Text = "X";
            // 
            // DrawPanel
            // 
            this.DrawPanel.Location = new System.Drawing.Point(0, 100);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(1312, 1229);
            this.DrawPanel.TabIndex = 4;
            this.DrawPanel.TabStop = false;
            // 
            // PiecesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1724, 1329);
            this.Controls.Add(this.DrawPanel);
            this.Controls.Add(this.PiecePanel);
            this.Controls.Add(this.OptionsPanel);
            this.Controls.Add(this.NamePanel);
            this.Name = "PiecesForm";
            this.ShowIcon = false;
            this.Text = "Pieces";
            this.NamePanel.ResumeLayout(false);
            this.NamePanel.PerformLayout();
            this.OptionsPanel.ResumeLayout(false);
            this.OptionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tToUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tFromUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rToUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFromUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wrUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradAngleUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedUpDown)).EndInit();
            this.PiecePanel.ResumeLayout(false);
            this.PiecePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutlineWidthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel NamePanel;
        private System.Windows.Forms.Button DoneBtn;
        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown AlphaUpDown;
        private System.Windows.Forms.NumericUpDown BlueUpDown;
        private System.Windows.Forms.NumericUpDown GreenUpDown;
        private System.Windows.Forms.NumericUpDown RedUpDown;
        private System.Windows.Forms.RadioButton OutlineRb;
        private System.Windows.Forms.RadioButton FillRb;
        private System.Windows.Forms.NumericUpDown gradAngleUpDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numColUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown wrUpDown;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button sketchBtn;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.CheckBox midFillCb;
        private System.Windows.Forms.NumericUpDown tToUpDown;
        private System.Windows.Forms.NumericUpDown tFromUpDown;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown rToUpDown;
        private System.Windows.Forms.NumericUpDown rFromUpDown;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox loadTb;
        private System.Windows.Forms.CheckBox pointCb;
        private System.Windows.Forms.Button SwitchBtnOptions;
        private System.Windows.Forms.Panel PiecePanel;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.ListBox PointsLb;
        private System.Windows.Forms.NumericUpDown OutlineWidthUpDown;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button BaseBtn;
        private System.Windows.Forms.Button RotateBtn;
        private System.Windows.Forms.Button TurnBtn;
        private System.Windows.Forms.Button NextAngleBtn;
        private System.Windows.Forms.CheckBox FixedCb;
        private System.Windows.Forms.Button UpBtn;
        private System.Windows.Forms.Button DownBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.NumericUpDown YUpDown;
        private System.Windows.Forms.ComboBox JoinOptions;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown XUpDown;
        private System.Windows.Forms.Button AddPointBtn;
        private System.Windows.Forms.Button SwitchBtn;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.PictureBox DrawPanel;
    }
}