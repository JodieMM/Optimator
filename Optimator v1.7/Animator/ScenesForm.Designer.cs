namespace Animator
{
    partial class ScenesForm
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
            this.SecondsUpDown = new System.Windows.Forms.NumericUpDown();
            this.BackBtn = new System.Windows.Forms.Button();
            this.ForwardBtn = new System.Windows.Forms.Button();
            this.AnimationAmountTb = new System.Windows.Forms.NumericUpDown();
            this.ChangeTypeCb = new System.Windows.Forms.ComboBox();
            this.AnimationLb = new System.Windows.Forms.ListBox();
            this.AddAnimationBtn = new System.Windows.Forms.Button();
            this.SMLbl = new System.Windows.Forms.Label();
            this.YLbl = new System.Windows.Forms.Label();
            this.YUpDown = new System.Windows.Forms.NumericUpDown();
            this.XLbl = new System.Windows.Forms.Label();
            this.XUpDown = new System.Windows.Forms.NumericUpDown();
            this.SpinLbl = new System.Windows.Forms.Label();
            this.AttributesLbl = new System.Windows.Forms.Label();
            this.NameTb = new System.Windows.Forms.TextBox();
            this.DrawPanel = new System.Windows.Forms.PictureBox();
            this.OptionsMenu = new System.Windows.Forms.TabControl();
            this.PartsTab = new System.Windows.Forms.TabPage();
            this.SizeBar = new System.Windows.Forms.TrackBar();
            this.OrderLbl = new System.Windows.Forms.Label();
            this.TurnLbl = new System.Windows.Forms.Label();
            this.SpinBar = new System.Windows.Forms.TrackBar();
            this.RotationLbl = new System.Windows.Forms.Label();
            this.TurnBar = new System.Windows.Forms.TrackBar();
            this.DownBtn = new System.Windows.Forms.Button();
            this.RotationBar = new System.Windows.Forms.TrackBar();
            this.UpBtn = new System.Windows.Forms.Button();
            this.AddSetBtn = new System.Windows.Forms.Button();
            this.AddPieceBtn = new System.Windows.Forms.Button();
            this.AnimationTab = new System.Windows.Forms.TabPage();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.SecondsLbl = new System.Windows.Forms.Label();
            this.AmountLbl = new System.Windows.Forms.Label();
            this.SceneTab = new System.Windows.Forms.TabPage();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.SceneTb = new System.Windows.Forms.TextBox();
            this.FinishSceneBtn = new System.Windows.Forms.Button();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.SelectFromTopCb = new System.Windows.Forms.CheckBox();
            this.TimeIntervalLbl = new System.Windows.Forms.Label();
            this.TimeIncrementUpDown = new System.Windows.Forms.NumericUpDown();
            this.PreviewCb = new System.Windows.Forms.CheckBox();
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.VidLengthLbl = new System.Windows.Forms.Label();
            this.UpArrowImg = new System.Windows.Forms.Label();
            this.Future2PreviewBox = new System.Windows.Forms.PictureBox();
            this.FuturePreviewBox = new System.Windows.Forms.PictureBox();
            this.PastPreviewBox = new System.Windows.Forms.PictureBox();
            this.CurrentTimeLbl = new System.Windows.Forms.Label();
            this.CurrentTimeUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.SecondsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationAmountTb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).BeginInit();
            this.OptionsMenu.SuspendLayout();
            this.PartsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).BeginInit();
            this.AnimationTab.SuspendLayout();
            this.SceneTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeIncrementUpDown)).BeginInit();
            this.DisplayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Future2PreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuturePreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PastPreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTimeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SecondsUpDown
            // 
            this.SecondsUpDown.DecimalPlaces = 3;
            this.SecondsUpDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondsUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.SecondsUpDown.Location = new System.Drawing.Point(72, 289);
            this.SecondsUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.SecondsUpDown.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.SecondsUpDown.Name = "SecondsUpDown";
            this.SecondsUpDown.Size = new System.Drawing.Size(125, 27);
            this.SecondsUpDown.TabIndex = 27;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.Khaki;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBtn.Location = new System.Drawing.Point(460, 10);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(2);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(200, 30);
            this.BackBtn.TabIndex = 23;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // ForwardBtn
            // 
            this.ForwardBtn.BackColor = System.Drawing.Color.Khaki;
            this.ForwardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForwardBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForwardBtn.Location = new System.Drawing.Point(670, 10);
            this.ForwardBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ForwardBtn.Name = "ForwardBtn";
            this.ForwardBtn.Size = new System.Drawing.Size(200, 30);
            this.ForwardBtn.TabIndex = 19;
            this.ForwardBtn.Text = "Forward";
            this.ForwardBtn.UseVisualStyleBackColor = false;
            this.ForwardBtn.Click += new System.EventHandler(this.ForwardBtn_Click);
            // 
            // AnimationAmountTb
            // 
            this.AnimationAmountTb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnimationAmountTb.Location = new System.Drawing.Point(72, 240);
            this.AnimationAmountTb.Margin = new System.Windows.Forms.Padding(2);
            this.AnimationAmountTb.Name = "AnimationAmountTb";
            this.AnimationAmountTb.Size = new System.Drawing.Size(125, 27);
            this.AnimationAmountTb.TabIndex = 12;
            // 
            // ChangeTypeCb
            // 
            this.ChangeTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChangeTypeCb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeTypeCb.FormattingEnabled = true;
            this.ChangeTypeCb.Items.AddRange(new object[] {
            "X",
            "Y",
            "Rotation",
            "Turn",
            "Spin",
            "Size",
            "Order",
            "Removed"});
            this.ChangeTypeCb.Location = new System.Drawing.Point(5, 198);
            this.ChangeTypeCb.Margin = new System.Windows.Forms.Padding(2);
            this.ChangeTypeCb.Name = "ChangeTypeCb";
            this.ChangeTypeCb.Size = new System.Drawing.Size(192, 27);
            this.ChangeTypeCb.TabIndex = 11;
            // 
            // AnimationLb
            // 
            this.AnimationLb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnimationLb.FormattingEnabled = true;
            this.AnimationLb.ItemHeight = 19;
            this.AnimationLb.Location = new System.Drawing.Point(0, 0);
            this.AnimationLb.Margin = new System.Windows.Forms.Padding(2);
            this.AnimationLb.Name = "AnimationLb";
            this.AnimationLb.Size = new System.Drawing.Size(202, 42);
            this.AnimationLb.TabIndex = 4;
            // 
            // AddAnimationBtn
            // 
            this.AddAnimationBtn.BackColor = System.Drawing.Color.Khaki;
            this.AddAnimationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAnimationBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddAnimationBtn.Location = new System.Drawing.Point(5, 331);
            this.AddAnimationBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddAnimationBtn.Name = "AddAnimationBtn";
            this.AddAnimationBtn.Size = new System.Drawing.Size(192, 29);
            this.AddAnimationBtn.TabIndex = 1;
            this.AddAnimationBtn.Text = "Add";
            this.AddAnimationBtn.UseVisualStyleBackColor = false;
            this.AddAnimationBtn.Click += new System.EventHandler(this.AddAnimationBtn_Click);
            // 
            // SMLbl
            // 
            this.SMLbl.AutoSize = true;
            this.SMLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SMLbl.Location = new System.Drawing.Point(6, 596);
            this.SMLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SMLbl.Name = "SMLbl";
            this.SMLbl.Size = new System.Drawing.Size(72, 19);
            this.SMLbl.TabIndex = 18;
            this.SMLbl.Text = "Size Mod";
            // 
            // YLbl
            // 
            this.YLbl.AutoSize = true;
            this.YLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YLbl.Location = new System.Drawing.Point(6, 534);
            this.YLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.YLbl.Name = "YLbl";
            this.YLbl.Size = new System.Drawing.Size(19, 19);
            this.YLbl.TabIndex = 16;
            this.YLbl.Text = "Y";
            // 
            // YUpDown
            // 
            this.YUpDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YUpDown.Location = new System.Drawing.Point(10, 560);
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
            this.YUpDown.Size = new System.Drawing.Size(182, 27);
            this.YUpDown.TabIndex = 15;
            this.YUpDown.ValueChanged += new System.EventHandler(this.YUpDown_ValueChanged);
            // 
            // XLbl
            // 
            this.XLbl.AutoSize = true;
            this.XLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XLbl.Location = new System.Drawing.Point(7, 477);
            this.XLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.XLbl.Name = "XLbl";
            this.XLbl.Size = new System.Drawing.Size(18, 19);
            this.XLbl.TabIndex = 14;
            this.XLbl.Text = "X";
            // 
            // XUpDown
            // 
            this.XUpDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XUpDown.Location = new System.Drawing.Point(10, 498);
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
            this.XUpDown.Size = new System.Drawing.Size(182, 27);
            this.XUpDown.TabIndex = 13;
            this.XUpDown.ValueChanged += new System.EventHandler(this.XUpDown_ValueChanged);
            // 
            // SpinLbl
            // 
            this.SpinLbl.AutoSize = true;
            this.SpinLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpinLbl.Location = new System.Drawing.Point(6, 406);
            this.SpinLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SpinLbl.Name = "SpinLbl";
            this.SpinLbl.Size = new System.Drawing.Size(40, 19);
            this.SpinLbl.TabIndex = 9;
            this.SpinLbl.Text = "Spin";
            // 
            // AttributesLbl
            // 
            this.AttributesLbl.AutoSize = true;
            this.AttributesLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttributesLbl.Location = new System.Drawing.Point(6, 162);
            this.AttributesLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AttributesLbl.Name = "AttributesLbl";
            this.AttributesLbl.Size = new System.Drawing.Size(160, 23);
            this.AttributesLbl.TabIndex = 6;
            this.AttributesLbl.Text = "Original Attributes";
            // 
            // NameTb
            // 
            this.NameTb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTb.Location = new System.Drawing.Point(10, 13);
            this.NameTb.Margin = new System.Windows.Forms.Padding(2);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(182, 30);
            this.NameTb.TabIndex = 0;
            this.NameTb.Text = "Part Name";
            // 
            // DrawPanel
            // 
            this.DrawPanel.BackColor = System.Drawing.Color.White;
            this.DrawPanel.Location = new System.Drawing.Point(0, 10);
            this.DrawPanel.Margin = new System.Windows.Forms.Padding(2);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(880, 495);
            this.DrawPanel.TabIndex = 20;
            this.DrawPanel.TabStop = false;
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.Controls.Add(this.PartsTab);
            this.OptionsMenu.Controls.Add(this.AnimationTab);
            this.OptionsMenu.Controls.Add(this.SceneTab);
            this.OptionsMenu.Controls.Add(this.SettingsTab);
            this.OptionsMenu.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsMenu.Location = new System.Drawing.Point(890, 0);
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.SelectedIndex = 0;
            this.OptionsMenu.Size = new System.Drawing.Size(210, 700);
            this.OptionsMenu.TabIndex = 21;
            // 
            // PartsTab
            // 
            this.PartsTab.BackColor = System.Drawing.Color.LemonChiffon;
            this.PartsTab.Controls.Add(this.SpinLbl);
            this.PartsTab.Controls.Add(this.SizeBar);
            this.PartsTab.Controls.Add(this.OrderLbl);
            this.PartsTab.Controls.Add(this.TurnLbl);
            this.PartsTab.Controls.Add(this.SpinBar);
            this.PartsTab.Controls.Add(this.RotationLbl);
            this.PartsTab.Controls.Add(this.TurnBar);
            this.PartsTab.Controls.Add(this.DownBtn);
            this.PartsTab.Controls.Add(this.RotationBar);
            this.PartsTab.Controls.Add(this.UpBtn);
            this.PartsTab.Controls.Add(this.AddSetBtn);
            this.PartsTab.Controls.Add(this.SMLbl);
            this.PartsTab.Controls.Add(this.AddPieceBtn);
            this.PartsTab.Controls.Add(this.NameTb);
            this.PartsTab.Controls.Add(this.YLbl);
            this.PartsTab.Controls.Add(this.AttributesLbl);
            this.PartsTab.Controls.Add(this.YUpDown);
            this.PartsTab.Controls.Add(this.XUpDown);
            this.PartsTab.Controls.Add(this.XLbl);
            this.PartsTab.Location = new System.Drawing.Point(4, 27);
            this.PartsTab.Name = "PartsTab";
            this.PartsTab.Size = new System.Drawing.Size(202, 669);
            this.PartsTab.TabIndex = 2;
            this.PartsTab.Text = "Parts";
            // 
            // SizeBar
            // 
            this.SizeBar.Location = new System.Drawing.Point(7, 621);
            this.SizeBar.Maximum = 1000;
            this.SizeBar.Name = "SizeBar";
            this.SizeBar.Size = new System.Drawing.Size(189, 45);
            this.SizeBar.SmallChange = 5;
            this.SizeBar.TabIndex = 119;
            this.SizeBar.TickFrequency = 100;
            this.SizeBar.Value = 100;
            this.SizeBar.ValueChanged += new System.EventHandler(this.SizeBar_ValueChanged);
            // 
            // OrderLbl
            // 
            this.OrderLbl.AutoSize = true;
            this.OrderLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderLbl.Location = new System.Drawing.Point(6, 192);
            this.OrderLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OrderLbl.Name = "OrderLbl";
            this.OrderLbl.Size = new System.Drawing.Size(50, 19);
            this.OrderLbl.TabIndex = 33;
            this.OrderLbl.Text = "Order";
            // 
            // TurnLbl
            // 
            this.TurnLbl.AutoSize = true;
            this.TurnLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnLbl.Location = new System.Drawing.Point(6, 340);
            this.TurnLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TurnLbl.Name = "TurnLbl";
            this.TurnLbl.Size = new System.Drawing.Size(43, 19);
            this.TurnLbl.TabIndex = 32;
            this.TurnLbl.Text = "Turn";
            // 
            // SpinBar
            // 
            this.SpinBar.Location = new System.Drawing.Point(7, 431);
            this.SpinBar.Maximum = 359;
            this.SpinBar.Name = "SpinBar";
            this.SpinBar.Size = new System.Drawing.Size(189, 45);
            this.SpinBar.TabIndex = 118;
            this.SpinBar.TickFrequency = 30;
            this.SpinBar.ValueChanged += new System.EventHandler(this.SpinBar_ValueChanged);
            // 
            // RotationLbl
            // 
            this.RotationLbl.AutoSize = true;
            this.RotationLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotationLbl.Location = new System.Drawing.Point(6, 278);
            this.RotationLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RotationLbl.Name = "RotationLbl";
            this.RotationLbl.Size = new System.Drawing.Size(68, 19);
            this.RotationLbl.TabIndex = 31;
            this.RotationLbl.Text = "Rotation";
            // 
            // TurnBar
            // 
            this.TurnBar.Location = new System.Drawing.Point(7, 364);
            this.TurnBar.Maximum = 359;
            this.TurnBar.Name = "TurnBar";
            this.TurnBar.Size = new System.Drawing.Size(189, 45);
            this.TurnBar.TabIndex = 117;
            this.TurnBar.TickFrequency = 30;
            this.TurnBar.ValueChanged += new System.EventHandler(this.TurnBar_ValueChanged);
            // 
            // DownBtn
            // 
            this.DownBtn.BackColor = System.Drawing.Color.Khaki;
            this.DownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownBtn.Location = new System.Drawing.Point(106, 221);
            this.DownBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DownBtn.Name = "DownBtn";
            this.DownBtn.Size = new System.Drawing.Size(86, 34);
            this.DownBtn.TabIndex = 30;
            this.DownBtn.Text = "Down";
            this.DownBtn.UseVisualStyleBackColor = false;
            // 
            // RotationBar
            // 
            this.RotationBar.Location = new System.Drawing.Point(7, 300);
            this.RotationBar.Maximum = 359;
            this.RotationBar.Name = "RotationBar";
            this.RotationBar.Size = new System.Drawing.Size(189, 45);
            this.RotationBar.TabIndex = 116;
            this.RotationBar.TickFrequency = 30;
            this.RotationBar.ValueChanged += new System.EventHandler(this.RotationBar_ValueChanged);
            // 
            // UpBtn
            // 
            this.UpBtn.BackColor = System.Drawing.Color.Khaki;
            this.UpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpBtn.Location = new System.Drawing.Point(10, 221);
            this.UpBtn.Margin = new System.Windows.Forms.Padding(2);
            this.UpBtn.Name = "UpBtn";
            this.UpBtn.Size = new System.Drawing.Size(86, 34);
            this.UpBtn.TabIndex = 29;
            this.UpBtn.Text = "Up";
            this.UpBtn.UseVisualStyleBackColor = false;
            // 
            // AddSetBtn
            // 
            this.AddSetBtn.BackColor = System.Drawing.Color.Khaki;
            this.AddSetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSetBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSetBtn.Location = new System.Drawing.Point(10, 107);
            this.AddSetBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddSetBtn.Name = "AddSetBtn";
            this.AddSetBtn.Size = new System.Drawing.Size(182, 34);
            this.AddSetBtn.TabIndex = 28;
            this.AddSetBtn.Text = "+ Set  ";
            this.AddSetBtn.UseVisualStyleBackColor = false;
            this.AddSetBtn.Click += new System.EventHandler(this.AddSetBtn_Click);
            // 
            // AddPieceBtn
            // 
            this.AddPieceBtn.BackColor = System.Drawing.Color.Khaki;
            this.AddPieceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPieceBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPieceBtn.Location = new System.Drawing.Point(10, 59);
            this.AddPieceBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddPieceBtn.Name = "AddPieceBtn";
            this.AddPieceBtn.Size = new System.Drawing.Size(182, 34);
            this.AddPieceBtn.TabIndex = 27;
            this.AddPieceBtn.Text = "+ Piece";
            this.AddPieceBtn.UseVisualStyleBackColor = false;
            this.AddPieceBtn.Click += new System.EventHandler(this.AddPieceBtn_Click);
            // 
            // AnimationTab
            // 
            this.AnimationTab.BackColor = System.Drawing.Color.LemonChiffon;
            this.AnimationTab.Controls.Add(this.PreviewBtn);
            this.AnimationTab.Controls.Add(this.SecondsLbl);
            this.AnimationTab.Controls.Add(this.AmountLbl);
            this.AnimationTab.Controls.Add(this.AnimationLb);
            this.AnimationTab.Controls.Add(this.SecondsUpDown);
            this.AnimationTab.Controls.Add(this.AddAnimationBtn);
            this.AnimationTab.Controls.Add(this.ChangeTypeCb);
            this.AnimationTab.Controls.Add(this.AnimationAmountTb);
            this.AnimationTab.Location = new System.Drawing.Point(4, 27);
            this.AnimationTab.Name = "AnimationTab";
            this.AnimationTab.Padding = new System.Windows.Forms.Padding(3);
            this.AnimationTab.Size = new System.Drawing.Size(202, 669);
            this.AnimationTab.TabIndex = 0;
            this.AnimationTab.Text = "Move";
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.BackColor = System.Drawing.Color.Khaki;
            this.PreviewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewBtn.Location = new System.Drawing.Point(5, 364);
            this.PreviewBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(192, 29);
            this.PreviewBtn.TabIndex = 36;
            this.PreviewBtn.Text = "Preview";
            this.PreviewBtn.UseVisualStyleBackColor = false;
            this.PreviewBtn.MouseHover += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // SecondsLbl
            // 
            this.SecondsLbl.AutoSize = true;
            this.SecondsLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondsLbl.Location = new System.Drawing.Point(2, 291);
            this.SecondsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SecondsLbl.Name = "SecondsLbl";
            this.SecondsLbl.Size = new System.Drawing.Size(67, 19);
            this.SecondsLbl.TabIndex = 35;
            this.SecondsLbl.Text = "Seconds";
            // 
            // AmountLbl
            // 
            this.AmountLbl.AutoSize = true;
            this.AmountLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountLbl.Location = new System.Drawing.Point(2, 242);
            this.AmountLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AmountLbl.Name = "AmountLbl";
            this.AmountLbl.Size = new System.Drawing.Size(66, 19);
            this.AmountLbl.TabIndex = 34;
            this.AmountLbl.Text = "Amount";
            // 
            // SceneTab
            // 
            this.SceneTab.BackColor = System.Drawing.Color.LemonChiffon;
            this.SceneTab.Controls.Add(this.ExitBtn);
            this.SceneTab.Controls.Add(this.SceneTb);
            this.SceneTab.Controls.Add(this.FinishSceneBtn);
            this.SceneTab.Location = new System.Drawing.Point(4, 27);
            this.SceneTab.Name = "SceneTab";
            this.SceneTab.Padding = new System.Windows.Forms.Padding(3);
            this.SceneTab.Size = new System.Drawing.Size(202, 669);
            this.SceneTab.TabIndex = 1;
            this.SceneTab.Text = "Scene";
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.Khaki;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.Black;
            this.ExitBtn.Location = new System.Drawing.Point(10, 610);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(182, 50);
            this.ExitBtn.TabIndex = 23;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // SceneTb
            // 
            this.SceneTb.BackColor = System.Drawing.Color.White;
            this.SceneTb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SceneTb.Location = new System.Drawing.Point(10, 9);
            this.SceneTb.Margin = new System.Windows.Forms.Padding(6);
            this.SceneTb.Name = "SceneTb";
            this.SceneTb.Size = new System.Drawing.Size(182, 30);
            this.SceneTb.TabIndex = 22;
            this.SceneTb.Text = "Scene Name";
            // 
            // FinishSceneBtn
            // 
            this.FinishSceneBtn.BackColor = System.Drawing.Color.Khaki;
            this.FinishSceneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FinishSceneBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinishSceneBtn.ForeColor = System.Drawing.Color.Black;
            this.FinishSceneBtn.Location = new System.Drawing.Point(10, 550);
            this.FinishSceneBtn.Margin = new System.Windows.Forms.Padding(2);
            this.FinishSceneBtn.Name = "FinishSceneBtn";
            this.FinishSceneBtn.Size = new System.Drawing.Size(182, 50);
            this.FinishSceneBtn.TabIndex = 21;
            this.FinishSceneBtn.Text = "Finish Scene";
            this.FinishSceneBtn.UseVisualStyleBackColor = false;
            this.FinishSceneBtn.Click += new System.EventHandler(this.FinishSceneBtn_Click);
            // 
            // SettingsTab
            // 
            this.SettingsTab.BackColor = System.Drawing.Color.LemonChiffon;
            this.SettingsTab.Controls.Add(this.SelectFromTopCb);
            this.SettingsTab.Controls.Add(this.TimeIntervalLbl);
            this.SettingsTab.Controls.Add(this.TimeIncrementUpDown);
            this.SettingsTab.Controls.Add(this.PreviewCb);
            this.SettingsTab.Location = new System.Drawing.Point(4, 27);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Size = new System.Drawing.Size(202, 669);
            this.SettingsTab.TabIndex = 3;
            this.SettingsTab.Text = "Settings";
            // 
            // SelectFromTopCb
            // 
            this.SelectFromTopCb.AutoSize = true;
            this.SelectFromTopCb.Checked = true;
            this.SelectFromTopCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelectFromTopCb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFromTopCb.Location = new System.Drawing.Point(15, 142);
            this.SelectFromTopCb.Margin = new System.Windows.Forms.Padding(2);
            this.SelectFromTopCb.Name = "SelectFromTopCb";
            this.SelectFromTopCb.Size = new System.Drawing.Size(182, 23);
            this.SelectFromTopCb.TabIndex = 119;
            this.SelectFromTopCb.Text = "Select Piece from Top";
            this.SelectFromTopCb.UseVisualStyleBackColor = true;
            // 
            // TimeIntervalLbl
            // 
            this.TimeIntervalLbl.AutoSize = true;
            this.TimeIntervalLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeIntervalLbl.Location = new System.Drawing.Point(11, 53);
            this.TimeIntervalLbl.Name = "TimeIntervalLbl";
            this.TimeIntervalLbl.Size = new System.Drawing.Size(138, 19);
            this.TimeIntervalLbl.TabIndex = 2;
            this.TimeIntervalLbl.Text = "Preview Time Gap";
            // 
            // TimeIncrementUpDown
            // 
            this.TimeIncrementUpDown.DecimalPlaces = 1;
            this.TimeIncrementUpDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeIncrementUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.TimeIncrementUpDown.Location = new System.Drawing.Point(15, 75);
            this.TimeIncrementUpDown.Name = "TimeIncrementUpDown";
            this.TimeIncrementUpDown.Size = new System.Drawing.Size(153, 27);
            this.TimeIncrementUpDown.TabIndex = 1;
            this.TimeIncrementUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.TimeIncrementUpDown.ValueChanged += new System.EventHandler(this.TimeIncrementUpDown_ValueChanged);
            // 
            // PreviewCb
            // 
            this.PreviewCb.AutoSize = true;
            this.PreviewCb.Checked = true;
            this.PreviewCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PreviewCb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewCb.Location = new System.Drawing.Point(15, 15);
            this.PreviewCb.Name = "PreviewCb";
            this.PreviewCb.Size = new System.Drawing.Size(127, 23);
            this.PreviewCb.TabIndex = 0;
            this.PreviewCb.Text = "Show Preview";
            this.PreviewCb.UseVisualStyleBackColor = true;
            this.PreviewCb.CheckedChanged += new System.EventHandler(this.PreviewCb_CheckedChanged);
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.DisplayPanel.Controls.Add(this.VidLengthLbl);
            this.DisplayPanel.Controls.Add(this.UpArrowImg);
            this.DisplayPanel.Controls.Add(this.Future2PreviewBox);
            this.DisplayPanel.Controls.Add(this.FuturePreviewBox);
            this.DisplayPanel.Controls.Add(this.PastPreviewBox);
            this.DisplayPanel.Controls.Add(this.CurrentTimeLbl);
            this.DisplayPanel.Controls.Add(this.CurrentTimeUpDown);
            this.DisplayPanel.Controls.Add(this.ForwardBtn);
            this.DisplayPanel.Controls.Add(this.BackBtn);
            this.DisplayPanel.Location = new System.Drawing.Point(0, 515);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(880, 185);
            this.DisplayPanel.TabIndex = 29;
            // 
            // VidLengthLbl
            // 
            this.VidLengthLbl.AutoSize = true;
            this.VidLengthLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VidLengthLbl.Location = new System.Drawing.Point(265, 15);
            this.VidLengthLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VidLengthLbl.Name = "VidLengthLbl";
            this.VidLengthLbl.Size = new System.Drawing.Size(129, 19);
            this.VidLengthLbl.TabIndex = 41;
            this.VidLengthLbl.Text = "Video Length: 0s";
            // 
            // UpArrowImg
            // 
            this.UpArrowImg.AutoSize = true;
            this.UpArrowImg.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpArrowImg.Location = new System.Drawing.Point(298, 48);
            this.UpArrowImg.Name = "UpArrowImg";
            this.UpArrowImg.Size = new System.Drawing.Size(35, 33);
            this.UpArrowImg.TabIndex = 40;
            this.UpArrowImg.Text = "^";
            // 
            // Future2PreviewBox
            // 
            this.Future2PreviewBox.BackColor = System.Drawing.Color.White;
            this.Future2PreviewBox.Location = new System.Drawing.Point(630, 48);
            this.Future2PreviewBox.Margin = new System.Windows.Forms.Padding(2);
            this.Future2PreviewBox.Name = "Future2PreviewBox";
            this.Future2PreviewBox.Size = new System.Drawing.Size(240, 135);
            this.Future2PreviewBox.TabIndex = 39;
            this.Future2PreviewBox.TabStop = false;
            // 
            // FuturePreviewBox
            // 
            this.FuturePreviewBox.BackColor = System.Drawing.Color.White;
            this.FuturePreviewBox.Location = new System.Drawing.Point(380, 48);
            this.FuturePreviewBox.Margin = new System.Windows.Forms.Padding(2);
            this.FuturePreviewBox.Name = "FuturePreviewBox";
            this.FuturePreviewBox.Size = new System.Drawing.Size(240, 135);
            this.FuturePreviewBox.TabIndex = 38;
            this.FuturePreviewBox.TabStop = false;
            // 
            // PastPreviewBox
            // 
            this.PastPreviewBox.BackColor = System.Drawing.Color.White;
            this.PastPreviewBox.Location = new System.Drawing.Point(10, 48);
            this.PastPreviewBox.Margin = new System.Windows.Forms.Padding(2);
            this.PastPreviewBox.Name = "PastPreviewBox";
            this.PastPreviewBox.Size = new System.Drawing.Size(240, 135);
            this.PastPreviewBox.TabIndex = 30;
            this.PastPreviewBox.TabStop = false;
            // 
            // CurrentTimeLbl
            // 
            this.CurrentTimeLbl.AutoSize = true;
            this.CurrentTimeLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTimeLbl.Location = new System.Drawing.Point(11, 16);
            this.CurrentTimeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentTimeLbl.Name = "CurrentTimeLbl";
            this.CurrentTimeLbl.Size = new System.Drawing.Size(103, 19);
            this.CurrentTimeLbl.TabIndex = 37;
            this.CurrentTimeLbl.Text = "Current Time";
            // 
            // CurrentTimeUpDown
            // 
            this.CurrentTimeUpDown.DecimalPlaces = 3;
            this.CurrentTimeUpDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTimeUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.CurrentTimeUpDown.Location = new System.Drawing.Point(127, 13);
            this.CurrentTimeUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.CurrentTimeUpDown.Name = "CurrentTimeUpDown";
            this.CurrentTimeUpDown.Size = new System.Drawing.Size(125, 27);
            this.CurrentTimeUpDown.TabIndex = 37;
            this.CurrentTimeUpDown.ValueChanged += new System.EventHandler(this.CurrentTimeUpDown_ValueChanged);
            // 
            // ScenesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.OptionsMenu);
            this.Controls.Add(this.DrawPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ScenesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScenesForm";
            ((System.ComponentModel.ISupportInitialize)(this.SecondsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationAmountTb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).EndInit();
            this.OptionsMenu.ResumeLayout(false);
            this.PartsTab.ResumeLayout(false);
            this.PartsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).EndInit();
            this.AnimationTab.ResumeLayout(false);
            this.AnimationTab.PerformLayout();
            this.SceneTab.ResumeLayout(false);
            this.SceneTab.PerformLayout();
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeIncrementUpDown)).EndInit();
            this.DisplayPanel.ResumeLayout(false);
            this.DisplayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Future2PreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuturePreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PastPreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTimeUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown SecondsUpDown;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button ForwardBtn;
        private System.Windows.Forms.NumericUpDown AnimationAmountTb;
        private System.Windows.Forms.ComboBox ChangeTypeCb;
        private System.Windows.Forms.ListBox AnimationLb;
        private System.Windows.Forms.Button AddAnimationBtn;
        private System.Windows.Forms.Label SMLbl;
        private System.Windows.Forms.Label YLbl;
        private System.Windows.Forms.NumericUpDown YUpDown;
        private System.Windows.Forms.Label XLbl;
        private System.Windows.Forms.NumericUpDown XUpDown;
        private System.Windows.Forms.Label SpinLbl;
        private System.Windows.Forms.Label AttributesLbl;
        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.PictureBox DrawPanel;
        private System.Windows.Forms.TabControl OptionsMenu;
        private System.Windows.Forms.TabPage AnimationTab;
        private System.Windows.Forms.TabPage PartsTab;
        private System.Windows.Forms.Button AddSetBtn;
        private System.Windows.Forms.Button AddPieceBtn;
        private System.Windows.Forms.Label OrderLbl;
        private System.Windows.Forms.Label TurnLbl;
        private System.Windows.Forms.Label RotationLbl;
        private System.Windows.Forms.Button DownBtn;
        private System.Windows.Forms.Button UpBtn;
        private System.Windows.Forms.TabPage SceneTab;
        private System.Windows.Forms.Button FinishSceneBtn;
        private System.Windows.Forms.TextBox SceneTb;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label SecondsLbl;
        private System.Windows.Forms.Label AmountLbl;
        private System.Windows.Forms.Panel DisplayPanel;
        private System.Windows.Forms.Button PreviewBtn;
        private System.Windows.Forms.Label CurrentTimeLbl;
        private System.Windows.Forms.NumericUpDown CurrentTimeUpDown;
        private System.Windows.Forms.PictureBox Future2PreviewBox;
        private System.Windows.Forms.PictureBox FuturePreviewBox;
        private System.Windows.Forms.PictureBox PastPreviewBox;
        private System.Windows.Forms.Label UpArrowImg;
        private System.Windows.Forms.Label VidLengthLbl;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.CheckBox PreviewCb;
        private System.Windows.Forms.TrackBar SizeBar;
        private System.Windows.Forms.TrackBar SpinBar;
        private System.Windows.Forms.TrackBar TurnBar;
        private System.Windows.Forms.TrackBar RotationBar;
        private System.Windows.Forms.Label TimeIntervalLbl;
        private System.Windows.Forms.NumericUpDown TimeIncrementUpDown;
        private System.Windows.Forms.CheckBox SelectFromTopCb;
    }
}