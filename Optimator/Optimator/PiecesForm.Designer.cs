namespace Optimator
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
            this.DrawBase = new System.Windows.Forms.PictureBox();
            this.OptionsMenu = new System.Windows.Forms.TabControl();
            this.ShapeTab = new System.Windows.Forms.TabPage();
            this.ShowFixedBtn = new System.Windows.Forms.Button();
            this.OutlineWLbl = new System.Windows.Forms.Label();
            this.OutlineWidthBox = new System.Windows.Forms.NumericUpDown();
            this.PieceLbl = new System.Windows.Forms.Label();
            this.PointLbl = new System.Windows.Forms.Label();
            this.FixedCb = new System.Windows.Forms.CheckBox();
            this.ConnectorsLbl = new System.Windows.Forms.Label();
            this.ConnectorOptions = new System.Windows.Forms.ComboBox();
            this.OutlineBox = new System.Windows.Forms.PictureBox();
            this.FillBox = new System.Windows.Forms.PictureBox();
            this.OutlineLbl = new System.Windows.Forms.Label();
            this.FillLbl = new System.Windows.Forms.Label();
            this.ColoursLbl = new System.Windows.Forms.Label();
            this.NameTb = new System.Windows.Forms.TextBox();
            this.SketchesTab = new System.Windows.Forms.TabPage();
            this.YLbl = new System.Windows.Forms.Label();
            this.XLbl = new System.Windows.Forms.Label();
            this.SpinLbl = new System.Windows.Forms.Label();
            this.SizeBar = new System.Windows.Forms.TrackBar();
            this.TurnLbl = new System.Windows.Forms.Label();
            this.SpinBar = new System.Windows.Forms.TrackBar();
            this.RotationLbl = new System.Windows.Forms.Label();
            this.TurnBar = new System.Windows.Forms.TrackBar();
            this.RotationBar = new System.Windows.Forms.TrackBar();
            this.SMLbl = new System.Windows.Forms.Label();
            this.YUpDown = new System.Windows.Forms.NumericUpDown();
            this.XUpDown = new System.Windows.Forms.NumericUpDown();
            this.DeleteSketchBtn = new System.Windows.Forms.Button();
            this.SketchesLbl = new System.Windows.Forms.Label();
            this.SketchLb = new System.Windows.Forms.CheckedListBox();
            this.DrawDown = new System.Windows.Forms.PictureBox();
            this.DrawRight = new System.Windows.Forms.PictureBox();
            this.PointBtn = new System.Windows.Forms.Button();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.CompleteBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.EmptyBtn = new System.Windows.Forms.Button();
            this.EmptyBtn2 = new System.Windows.Forms.Button();
            this.EraseRightBtn = new System.Windows.Forms.Button();
            this.EraseDownBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawBase)).BeginInit();
            this.OptionsMenu.SuspendLayout();
            this.ShapeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutlineWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutlineBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillBox)).BeginInit();
            this.SketchesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRight)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawBase
            // 
            this.DrawBase.BackColor = System.Drawing.Color.White;
            this.DrawBase.Location = new System.Drawing.Point(30, 30);
            this.DrawBase.Margin = new System.Windows.Forms.Padding(6);
            this.DrawBase.Name = "DrawBase";
            this.DrawBase.Size = new System.Drawing.Size(300, 300);
            this.DrawBase.TabIndex = 0;
            this.DrawBase.TabStop = false;
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.Controls.Add(this.ShapeTab);
            this.OptionsMenu.Controls.Add(this.SketchesTab);
            this.OptionsMenu.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsMenu.Location = new System.Drawing.Point(700, 0);
            this.OptionsMenu.Margin = new System.Windows.Forms.Padding(6);
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.SelectedIndex = 0;
            this.OptionsMenu.Size = new System.Drawing.Size(400, 700);
            this.OptionsMenu.TabIndex = 2;
            // 
            // ShapeTab
            // 
            this.ShapeTab.BackColor = System.Drawing.Color.Azure;
            this.ShapeTab.Controls.Add(this.ShowFixedBtn);
            this.ShapeTab.Controls.Add(this.OutlineWLbl);
            this.ShapeTab.Controls.Add(this.OutlineWidthBox);
            this.ShapeTab.Controls.Add(this.PieceLbl);
            this.ShapeTab.Controls.Add(this.PointLbl);
            this.ShapeTab.Controls.Add(this.FixedCb);
            this.ShapeTab.Controls.Add(this.ConnectorsLbl);
            this.ShapeTab.Controls.Add(this.ConnectorOptions);
            this.ShapeTab.Controls.Add(this.OutlineBox);
            this.ShapeTab.Controls.Add(this.FillBox);
            this.ShapeTab.Controls.Add(this.OutlineLbl);
            this.ShapeTab.Controls.Add(this.FillLbl);
            this.ShapeTab.Controls.Add(this.ColoursLbl);
            this.ShapeTab.Controls.Add(this.NameTb);
            this.ShapeTab.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShapeTab.Location = new System.Drawing.Point(8, 50);
            this.ShapeTab.Margin = new System.Windows.Forms.Padding(6);
            this.ShapeTab.Name = "ShapeTab";
            this.ShapeTab.Padding = new System.Windows.Forms.Padding(6);
            this.ShapeTab.Size = new System.Drawing.Size(384, 642);
            this.ShapeTab.TabIndex = 0;
            this.ShapeTab.Text = "Shape";
            // 
            // ShowFixedBtn
            // 
            this.ShowFixedBtn.BackColor = System.Drawing.Color.LightCyan;
            this.ShowFixedBtn.Enabled = false;
            this.ShowFixedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowFixedBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowFixedBtn.Location = new System.Drawing.Point(139, 419);
            this.ShowFixedBtn.Margin = new System.Windows.Forms.Padding(6);
            this.ShowFixedBtn.Name = "ShowFixedBtn";
            this.ShowFixedBtn.Size = new System.Drawing.Size(239, 35);
            this.ShowFixedBtn.TabIndex = 13;
            this.ShowFixedBtn.Text = "Show Fixed";
            this.ShowFixedBtn.UseVisualStyleBackColor = false;
            this.ShowFixedBtn.Click += new System.EventHandler(this.ShowFixedBtn_Click);
            // 
            // OutlineWLbl
            // 
            this.OutlineWLbl.AutoSize = true;
            this.OutlineWLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutlineWLbl.Location = new System.Drawing.Point(11, 247);
            this.OutlineWLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OutlineWLbl.Name = "OutlineWLbl";
            this.OutlineWLbl.Size = new System.Drawing.Size(250, 46);
            this.OutlineWLbl.TabIndex = 121;
            this.OutlineWLbl.Text = "Outline Width";
            // 
            // OutlineWidthBox
            // 
            this.OutlineWidthBox.Location = new System.Drawing.Point(139, 248);
            this.OutlineWidthBox.Name = "OutlineWidthBox";
            this.OutlineWidthBox.Size = new System.Drawing.Size(239, 46);
            this.OutlineWidthBox.TabIndex = 120;
            this.OutlineWidthBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.OutlineWidthBox.ValueChanged += new System.EventHandler(this.OutlineWidthBox_ValueChanged);
            // 
            // PieceLbl
            // 
            this.PieceLbl.AutoSize = true;
            this.PieceLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PieceLbl.Location = new System.Drawing.Point(135, 70);
            this.PieceLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PieceLbl.Name = "PieceLbl";
            this.PieceLbl.Size = new System.Drawing.Size(249, 46);
            this.PieceLbl.TabIndex = 119;
            this.PieceLbl.Text = "Piece Based";
            // 
            // PointLbl
            // 
            this.PointLbl.AutoSize = true;
            this.PointLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointLbl.Location = new System.Drawing.Point(135, 333);
            this.PointLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PointLbl.Name = "PointLbl";
            this.PointLbl.Size = new System.Drawing.Size(246, 46);
            this.PointLbl.TabIndex = 118;
            this.PointLbl.Text = "Point Based";
            // 
            // FixedCb
            // 
            this.FixedCb.AutoSize = true;
            this.FixedCb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FixedCb.Checked = true;
            this.FixedCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FixedCb.Enabled = false;
            this.FixedCb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FixedCb.Location = new System.Drawing.Point(10, 427);
            this.FixedCb.Name = "FixedCb";
            this.FixedCb.Size = new System.Drawing.Size(141, 50);
            this.FixedCb.TabIndex = 117;
            this.FixedCb.Text = "Fixed";
            this.FixedCb.UseVisualStyleBackColor = true;
            this.FixedCb.CheckedChanged += new System.EventHandler(this.FixedCb_CheckedChanged);
            // 
            // ConnectorsLbl
            // 
            this.ConnectorsLbl.AutoSize = true;
            this.ConnectorsLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectorsLbl.Location = new System.Drawing.Point(11, 372);
            this.ConnectorsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ConnectorsLbl.Name = "ConnectorsLbl";
            this.ConnectorsLbl.Size = new System.Drawing.Size(192, 46);
            this.ConnectorsLbl.TabIndex = 116;
            this.ConnectorsLbl.Text = "Connector";
            // 
            // ConnectorOptions
            // 
            this.ConnectorOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConnectorOptions.Enabled = false;
            this.ConnectorOptions.FormattingEnabled = true;
            this.ConnectorOptions.Items.AddRange(new object[] {
            "Line",
            "Blank"});
            this.ConnectorOptions.Location = new System.Drawing.Point(139, 372);
            this.ConnectorOptions.Name = "ConnectorOptions";
            this.ConnectorOptions.Size = new System.Drawing.Size(239, 47);
            this.ConnectorOptions.TabIndex = 115;
            this.ConnectorOptions.SelectedIndexChanged += new System.EventHandler(this.ConnectorOptions_SelectedIndexChanged);
            // 
            // OutlineBox
            // 
            this.OutlineBox.BackColor = System.Drawing.Color.White;
            this.OutlineBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutlineBox.Location = new System.Drawing.Point(139, 184);
            this.OutlineBox.Name = "OutlineBox";
            this.OutlineBox.Size = new System.Drawing.Size(239, 30);
            this.OutlineBox.TabIndex = 114;
            this.OutlineBox.TabStop = false;
            this.OutlineBox.Click += new System.EventHandler(this.OutlineBox_Click);
            // 
            // FillBox
            // 
            this.FillBox.BackColor = System.Drawing.Color.White;
            this.FillBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FillBox.Location = new System.Drawing.Point(139, 143);
            this.FillBox.Name = "FillBox";
            this.FillBox.Size = new System.Drawing.Size(239, 30);
            this.FillBox.TabIndex = 113;
            this.FillBox.TabStop = false;
            this.FillBox.Click += new System.EventHandler(this.FillBox_Click);
            // 
            // OutlineLbl
            // 
            this.OutlineLbl.AutoSize = true;
            this.OutlineLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutlineLbl.Location = new System.Drawing.Point(11, 184);
            this.OutlineLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OutlineLbl.Name = "OutlineLbl";
            this.OutlineLbl.Size = new System.Drawing.Size(118, 39);
            this.OutlineLbl.TabIndex = 112;
            this.OutlineLbl.Text = "Outline";
            // 
            // FillLbl
            // 
            this.FillLbl.AutoSize = true;
            this.FillLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FillLbl.Location = new System.Drawing.Point(11, 143);
            this.FillLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FillLbl.Name = "FillLbl";
            this.FillLbl.Size = new System.Drawing.Size(55, 39);
            this.FillLbl.TabIndex = 111;
            this.FillLbl.Text = "Fill";
            // 
            // ColoursLbl
            // 
            this.ColoursLbl.AutoSize = true;
            this.ColoursLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColoursLbl.Location = new System.Drawing.Point(11, 107);
            this.ColoursLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ColoursLbl.Name = "ColoursLbl";
            this.ColoursLbl.Size = new System.Drawing.Size(146, 46);
            this.ColoursLbl.TabIndex = 92;
            this.ColoursLbl.Text = "Colours";
            // 
            // NameTb
            // 
            this.NameTb.BackColor = System.Drawing.Color.White;
            this.NameTb.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTb.Location = new System.Drawing.Point(15, 15);
            this.NameTb.Margin = new System.Windows.Forms.Padding(6);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(300, 58);
            this.NameTb.TabIndex = 5;
            this.NameTb.Text = "Piece Name";
            // 
            // SketchesTab
            // 
            this.SketchesTab.BackColor = System.Drawing.Color.Azure;
            this.SketchesTab.Controls.Add(this.YLbl);
            this.SketchesTab.Controls.Add(this.XLbl);
            this.SketchesTab.Controls.Add(this.SpinLbl);
            this.SketchesTab.Controls.Add(this.SizeBar);
            this.SketchesTab.Controls.Add(this.TurnLbl);
            this.SketchesTab.Controls.Add(this.SpinBar);
            this.SketchesTab.Controls.Add(this.RotationLbl);
            this.SketchesTab.Controls.Add(this.TurnBar);
            this.SketchesTab.Controls.Add(this.RotationBar);
            this.SketchesTab.Controls.Add(this.SMLbl);
            this.SketchesTab.Controls.Add(this.YUpDown);
            this.SketchesTab.Controls.Add(this.XUpDown);
            this.SketchesTab.Controls.Add(this.DeleteSketchBtn);
            this.SketchesTab.Controls.Add(this.SketchesLbl);
            this.SketchesTab.Controls.Add(this.SketchLb);
            this.SketchesTab.Location = new System.Drawing.Point(8, 50);
            this.SketchesTab.Name = "SketchesTab";
            this.SketchesTab.Size = new System.Drawing.Size(384, 642);
            this.SketchesTab.TabIndex = 2;
            this.SketchesTab.Text = "Sketch";
            // 
            // YLbl
            // 
            this.YLbl.AutoSize = true;
            this.YLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YLbl.Location = new System.Drawing.Point(212, 323);
            this.YLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.YLbl.Name = "YLbl";
            this.YLbl.Size = new System.Drawing.Size(35, 39);
            this.YLbl.TabIndex = 133;
            this.YLbl.Text = "Y";
            // 
            // XLbl
            // 
            this.XLbl.AutoSize = true;
            this.XLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XLbl.Location = new System.Drawing.Point(212, 261);
            this.XLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.XLbl.Name = "XLbl";
            this.XLbl.Size = new System.Drawing.Size(36, 39);
            this.XLbl.TabIndex = 132;
            this.XLbl.Text = "X";
            // 
            // SpinLbl
            // 
            this.SpinLbl.AutoSize = true;
            this.SpinLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpinLbl.Location = new System.Drawing.Point(11, 385);
            this.SpinLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SpinLbl.Name = "SpinLbl";
            this.SpinLbl.Size = new System.Drawing.Size(78, 39);
            this.SpinLbl.TabIndex = 122;
            this.SpinLbl.Text = "Spin";
            // 
            // SizeBar
            // 
            this.SizeBar.Location = new System.Drawing.Point(12, 477);
            this.SizeBar.Maximum = 1000;
            this.SizeBar.Name = "SizeBar";
            this.SizeBar.Size = new System.Drawing.Size(189, 90);
            this.SizeBar.SmallChange = 5;
            this.SizeBar.TabIndex = 131;
            this.SizeBar.TickFrequency = 100;
            this.SizeBar.Value = 100;
            this.SizeBar.Scroll += new System.EventHandler(this.SketchUpdate);
            // 
            // TurnLbl
            // 
            this.TurnLbl.AutoSize = true;
            this.TurnLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnLbl.Location = new System.Drawing.Point(11, 321);
            this.TurnLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TurnLbl.Name = "TurnLbl";
            this.TurnLbl.Size = new System.Drawing.Size(84, 39);
            this.TurnLbl.TabIndex = 127;
            this.TurnLbl.Text = "Turn";
            // 
            // SpinBar
            // 
            this.SpinBar.Location = new System.Drawing.Point(12, 409);
            this.SpinBar.Maximum = 359;
            this.SpinBar.Name = "SpinBar";
            this.SpinBar.Size = new System.Drawing.Size(189, 90);
            this.SpinBar.TabIndex = 130;
            this.SpinBar.TickFrequency = 30;
            this.SpinBar.Scroll += new System.EventHandler(this.SketchUpdate);
            // 
            // RotationLbl
            // 
            this.RotationLbl.AutoSize = true;
            this.RotationLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotationLbl.Location = new System.Drawing.Point(11, 256);
            this.RotationLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RotationLbl.Name = "RotationLbl";
            this.RotationLbl.Size = new System.Drawing.Size(135, 39);
            this.RotationLbl.TabIndex = 126;
            this.RotationLbl.Text = "Rotation";
            // 
            // TurnBar
            // 
            this.TurnBar.Location = new System.Drawing.Point(12, 342);
            this.TurnBar.Maximum = 359;
            this.TurnBar.Name = "TurnBar";
            this.TurnBar.Size = new System.Drawing.Size(189, 90);
            this.TurnBar.TabIndex = 129;
            this.TurnBar.TickFrequency = 30;
            this.TurnBar.Scroll += new System.EventHandler(this.SketchUpdate);
            // 
            // RotationBar
            // 
            this.RotationBar.Location = new System.Drawing.Point(12, 278);
            this.RotationBar.Maximum = 359;
            this.RotationBar.Name = "RotationBar";
            this.RotationBar.Size = new System.Drawing.Size(189, 90);
            this.RotationBar.TabIndex = 128;
            this.RotationBar.TickFrequency = 30;
            this.RotationBar.Scroll += new System.EventHandler(this.SketchUpdate);
            // 
            // SMLbl
            // 
            this.SMLbl.AutoSize = true;
            this.SMLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SMLbl.Location = new System.Drawing.Point(11, 455);
            this.SMLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SMLbl.Name = "SMLbl";
            this.SMLbl.Size = new System.Drawing.Size(143, 39);
            this.SMLbl.TabIndex = 125;
            this.SMLbl.Text = "Size Mod";
            // 
            // YUpDown
            // 
            this.YUpDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YUpDown.Location = new System.Drawing.Point(216, 347);
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
            this.YUpDown.TabIndex = 124;
            this.YUpDown.ValueChanged += new System.EventHandler(this.SketchUpdate);
            // 
            // XUpDown
            // 
            this.XUpDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XUpDown.Location = new System.Drawing.Point(216, 283);
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
            this.XUpDown.TabIndex = 123;
            this.XUpDown.ValueChanged += new System.EventHandler(this.SketchUpdate);
            // 
            // DeleteSketchBtn
            // 
            this.DeleteSketchBtn.BackColor = System.Drawing.Color.LightCyan;
            this.DeleteSketchBtn.Enabled = false;
            this.DeleteSketchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteSketchBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSketchBtn.Location = new System.Drawing.Point(15, 211);
            this.DeleteSketchBtn.Margin = new System.Windows.Forms.Padding(6);
            this.DeleteSketchBtn.Name = "DeleteSketchBtn";
            this.DeleteSketchBtn.Size = new System.Drawing.Size(363, 35);
            this.DeleteSketchBtn.TabIndex = 121;
            this.DeleteSketchBtn.Text = "Delete Sketch";
            this.DeleteSketchBtn.UseVisualStyleBackColor = false;
            this.DeleteSketchBtn.Click += new System.EventHandler(this.SketchUpdate);
            // 
            // SketchesLbl
            // 
            this.SketchesLbl.AutoSize = true;
            this.SketchesLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SketchesLbl.Location = new System.Drawing.Point(135, 10);
            this.SketchesLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SketchesLbl.Name = "SketchesLbl";
            this.SketchesLbl.Size = new System.Drawing.Size(193, 46);
            this.SketchesLbl.TabIndex = 120;
            this.SketchesLbl.Text = "Sketches";
            // 
            // SketchLb
            // 
            this.SketchLb.BackColor = System.Drawing.SystemColors.Window;
            this.SketchLb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SketchLb.FormattingEnabled = true;
            this.SketchLb.Location = new System.Drawing.Point(15, 42);
            this.SketchLb.Name = "SketchLb";
            this.SketchLb.Size = new System.Drawing.Size(363, 127);
            this.SketchLb.TabIndex = 14;
            // 
            // DrawDown
            // 
            this.DrawDown.BackColor = System.Drawing.Color.White;
            this.DrawDown.Location = new System.Drawing.Point(30, 360);
            this.DrawDown.Margin = new System.Windows.Forms.Padding(6);
            this.DrawDown.Name = "DrawDown";
            this.DrawDown.Size = new System.Drawing.Size(300, 300);
            this.DrawDown.TabIndex = 3;
            this.DrawDown.TabStop = false;
            // 
            // DrawRight
            // 
            this.DrawRight.BackColor = System.Drawing.Color.White;
            this.DrawRight.Location = new System.Drawing.Point(360, 30);
            this.DrawRight.Margin = new System.Windows.Forms.Padding(6);
            this.DrawRight.Name = "DrawRight";
            this.DrawRight.Size = new System.Drawing.Size(300, 300);
            this.DrawRight.TabIndex = 4;
            this.DrawRight.TabStop = false;
            // 
            // PointBtn
            // 
            this.PointBtn.BackColor = System.Drawing.Color.LightCyan;
            this.PointBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PointBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointBtn.Location = new System.Drawing.Point(360, 360);
            this.PointBtn.Margin = new System.Windows.Forms.Padding(6);
            this.PointBtn.Name = "PointBtn";
            this.PointBtn.Size = new System.Drawing.Size(90, 90);
            this.PointBtn.TabIndex = 6;
            this.PointBtn.Text = "Select";
            this.PointBtn.UseVisualStyleBackColor = false;
            this.PointBtn.Click += new System.EventHandler(this.PointBtn_Click);
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.BackColor = System.Drawing.Color.LightCyan;
            this.PreviewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewBtn.Location = new System.Drawing.Point(570, 360);
            this.PreviewBtn.Margin = new System.Windows.Forms.Padding(6);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(90, 90);
            this.PreviewBtn.TabIndex = 7;
            this.PreviewBtn.Text = "Preview";
            this.PreviewBtn.UseVisualStyleBackColor = false;
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // CompleteBtn
            // 
            this.CompleteBtn.BackColor = System.Drawing.Color.LightCyan;
            this.CompleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompleteBtn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompleteBtn.Location = new System.Drawing.Point(360, 570);
            this.CompleteBtn.Margin = new System.Windows.Forms.Padding(6);
            this.CompleteBtn.Name = "CompleteBtn";
            this.CompleteBtn.Size = new System.Drawing.Size(300, 90);
            this.CompleteBtn.TabIndex = 9;
            this.CompleteBtn.Text = "Complete";
            this.CompleteBtn.UseVisualStyleBackColor = false;
            this.CompleteBtn.Click += new System.EventHandler(this.CompleteBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.LightCyan;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.Location = new System.Drawing.Point(570, 465);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(6);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(90, 90);
            this.ExitBtn.TabIndex = 11;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // LoadBtn
            // 
            this.LoadBtn.BackColor = System.Drawing.Color.LightCyan;
            this.LoadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadBtn.Location = new System.Drawing.Point(360, 465);
            this.LoadBtn.Margin = new System.Windows.Forms.Padding(6);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(90, 90);
            this.LoadBtn.TabIndex = 10;
            this.LoadBtn.Text = "Load";
            this.LoadBtn.UseVisualStyleBackColor = false;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // EmptyBtn
            // 
            this.EmptyBtn.BackColor = System.Drawing.Color.LightCyan;
            this.EmptyBtn.Enabled = false;
            this.EmptyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EmptyBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmptyBtn.Location = new System.Drawing.Point(465, 465);
            this.EmptyBtn.Margin = new System.Windows.Forms.Padding(6);
            this.EmptyBtn.Name = "EmptyBtn";
            this.EmptyBtn.Size = new System.Drawing.Size(90, 90);
            this.EmptyBtn.TabIndex = 13;
            this.EmptyBtn.Text = "TBD";
            this.EmptyBtn.UseVisualStyleBackColor = false;
            this.EmptyBtn.Visible = false;
            // 
            // EmptyBtn2
            // 
            this.EmptyBtn2.BackColor = System.Drawing.Color.LightCyan;
            this.EmptyBtn2.Enabled = false;
            this.EmptyBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EmptyBtn2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmptyBtn2.Location = new System.Drawing.Point(465, 360);
            this.EmptyBtn2.Margin = new System.Windows.Forms.Padding(6);
            this.EmptyBtn2.Name = "EmptyBtn2";
            this.EmptyBtn2.Size = new System.Drawing.Size(90, 90);
            this.EmptyBtn2.TabIndex = 14;
            this.EmptyBtn2.Text = "TBD";
            this.EmptyBtn2.UseVisualStyleBackColor = false;
            this.EmptyBtn2.Visible = false;
            // 
            // EraseRightBtn
            // 
            this.EraseRightBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.EraseRightBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EraseRightBtn.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EraseRightBtn.Location = new System.Drawing.Point(615, 30);
            this.EraseRightBtn.Margin = new System.Windows.Forms.Padding(6);
            this.EraseRightBtn.Name = "EraseRightBtn";
            this.EraseRightBtn.Size = new System.Drawing.Size(45, 45);
            this.EraseRightBtn.TabIndex = 15;
            this.EraseRightBtn.Text = "Clear";
            this.EraseRightBtn.UseVisualStyleBackColor = false;
            this.EraseRightBtn.Click += new System.EventHandler(this.EraseAngleBtn_Click);
            // 
            // EraseDownBtn
            // 
            this.EraseDownBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.EraseDownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EraseDownBtn.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EraseDownBtn.Location = new System.Drawing.Point(285, 360);
            this.EraseDownBtn.Margin = new System.Windows.Forms.Padding(6);
            this.EraseDownBtn.Name = "EraseDownBtn";
            this.EraseDownBtn.Size = new System.Drawing.Size(45, 45);
            this.EraseDownBtn.TabIndex = 16;
            this.EraseDownBtn.Text = "Clear";
            this.EraseDownBtn.UseVisualStyleBackColor = false;
            this.EraseDownBtn.Click += new System.EventHandler(this.EraseAngleBtn_Click);
            // 
            // PiecesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.EraseDownBtn);
            this.Controls.Add(this.EraseRightBtn);
            this.Controls.Add(this.EmptyBtn2);
            this.Controls.Add(this.EmptyBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.LoadBtn);
            this.Controls.Add(this.CompleteBtn);
            this.Controls.Add(this.PreviewBtn);
            this.Controls.Add(this.PointBtn);
            this.Controls.Add(this.DrawRight);
            this.Controls.Add(this.DrawDown);
            this.Controls.Add(this.OptionsMenu);
            this.Controls.Add(this.DrawBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "PiecesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Piece";
            ((System.ComponentModel.ISupportInitialize)(this.DrawBase)).EndInit();
            this.OptionsMenu.ResumeLayout(false);
            this.ShapeTab.ResumeLayout(false);
            this.ShapeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutlineWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutlineBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillBox)).EndInit();
            this.SketchesTab.ResumeLayout(false);
            this.SketchesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawBase;
        private System.Windows.Forms.TabControl OptionsMenu;
        private System.Windows.Forms.TabPage ShapeTab;
        private System.Windows.Forms.PictureBox DrawDown;
        private System.Windows.Forms.PictureBox DrawRight;
        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.Button PointBtn;
        private System.Windows.Forms.Button PreviewBtn;
        private System.Windows.Forms.Button CompleteBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.TabPage SketchesTab;
        private System.Windows.Forms.Label ColoursLbl;
        private System.Windows.Forms.Label FillLbl;
        private System.Windows.Forms.PictureBox OutlineBox;
        private System.Windows.Forms.PictureBox FillBox;
        private System.Windows.Forms.Label OutlineLbl;
        private System.Windows.Forms.Label PieceLbl;
        private System.Windows.Forms.Label PointLbl;
        private System.Windows.Forms.CheckBox FixedCb;
        private System.Windows.Forms.Label ConnectorsLbl;
        private System.Windows.Forms.ComboBox ConnectorOptions;
        private System.Windows.Forms.Label OutlineWLbl;
        private System.Windows.Forms.NumericUpDown OutlineWidthBox;
        private System.Windows.Forms.Button ShowFixedBtn;
        private System.Windows.Forms.Button EmptyBtn;
        private System.Windows.Forms.CheckedListBox SketchLb;
        private System.Windows.Forms.Label SketchesLbl;
        private System.Windows.Forms.Button DeleteSketchBtn;
        private System.Windows.Forms.Label SpinLbl;
        private System.Windows.Forms.TrackBar SizeBar;
        private System.Windows.Forms.Label TurnLbl;
        private System.Windows.Forms.TrackBar SpinBar;
        private System.Windows.Forms.Label RotationLbl;
        private System.Windows.Forms.TrackBar TurnBar;
        private System.Windows.Forms.TrackBar RotationBar;
        private System.Windows.Forms.Label SMLbl;
        private System.Windows.Forms.NumericUpDown YUpDown;
        private System.Windows.Forms.NumericUpDown XUpDown;
        private System.Windows.Forms.Label YLbl;
        private System.Windows.Forms.Label XLbl;
        private System.Windows.Forms.Button EmptyBtn2;
        private System.Windows.Forms.Button EraseRightBtn;
        private System.Windows.Forms.Button EraseDownBtn;
    }
}