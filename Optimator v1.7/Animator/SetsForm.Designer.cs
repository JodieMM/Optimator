namespace Animator
{
    partial class SetsForm
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
            this.CompleteBtn = new System.Windows.Forms.Button();
            this.NameTb = new System.Windows.Forms.TextBox();
            this.AddSetBtn = new System.Windows.Forms.Button();
            this.AddTb = new System.Windows.Forms.TextBox();
            this.AddPieceBtn = new System.Windows.Forms.Button();
            this.OptionsMenu = new System.Windows.Forms.TabControl();
            this.SetPage = new System.Windows.Forms.TabPage();
            this.PiecesTab = new System.Windows.Forms.TabPage();
            this.SizeLbl = new System.Windows.Forms.Label();
            this.SizeBar = new System.Windows.Forms.TrackBar();
            this.SpinLbl = new System.Windows.Forms.Label();
            this.SpinBar = new System.Windows.Forms.TrackBar();
            this.TurnLbl = new System.Windows.Forms.Label();
            this.TurnBar = new System.Windows.Forms.TrackBar();
            this.RotationLbl = new System.Windows.Forms.Label();
            this.RotationBar = new System.Windows.Forms.TrackBar();
            this.OriginalLbl = new System.Windows.Forms.Label();
            this.UpBtn = new System.Windows.Forms.Button();
            this.DownBtn = new System.Windows.Forms.Button();
            this.OrderLbl = new System.Windows.Forms.Label();
            this.FlipsUpDown = new System.Windows.Forms.NumericUpDown();
            this.FlipsCb = new System.Windows.Forms.CheckBox();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.SelectFromTopCb = new System.Windows.Forms.CheckBox();
            this.BackColourBox = new System.Windows.Forms.PictureBox();
            this.BackColourLbl = new System.Windows.Forms.Label();
            this.DrawRight = new System.Windows.Forms.PictureBox();
            this.DrawDown = new System.Windows.Forms.PictureBox();
            this.DrawBase = new System.Windows.Forms.PictureBox();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.AddPartLbl = new System.Windows.Forms.Label();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.OptionsMenu.SuspendLayout();
            this.SetPage.SuspendLayout();
            this.PiecesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlipsUpDown)).BeginInit();
            this.SettingsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackColourBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawBase)).BeginInit();
            this.SuspendLayout();
            // 
            // CompleteBtn
            // 
            this.CompleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CompleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompleteBtn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompleteBtn.Location = new System.Drawing.Point(360, 570);
            this.CompleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CompleteBtn.Name = "CompleteBtn";
            this.CompleteBtn.Size = new System.Drawing.Size(300, 90);
            this.CompleteBtn.TabIndex = 2;
            this.CompleteBtn.Text = "Complete";
            this.CompleteBtn.UseVisualStyleBackColor = false;
            this.CompleteBtn.Click += new System.EventHandler(this.CompleteBtn_Click);
            // 
            // NameTb
            // 
            this.NameTb.BackColor = System.Drawing.Color.White;
            this.NameTb.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTb.Location = new System.Drawing.Point(15, 15);
            this.NameTb.Margin = new System.Windows.Forms.Padding(2);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(300, 33);
            this.NameTb.TabIndex = 1;
            this.NameTb.Text = "Set Name";
            // 
            // AddSetBtn
            // 
            this.AddSetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AddSetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSetBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSetBtn.Location = new System.Drawing.Point(206, 148);
            this.AddSetBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddSetBtn.Name = "AddSetBtn";
            this.AddSetBtn.Size = new System.Drawing.Size(165, 40);
            this.AddSetBtn.TabIndex = 81;
            this.AddSetBtn.Text = "+ Set  ";
            this.AddSetBtn.UseVisualStyleBackColor = false;
            this.AddSetBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // AddTb
            // 
            this.AddTb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTb.Location = new System.Drawing.Point(21, 107);
            this.AddTb.Margin = new System.Windows.Forms.Padding(2);
            this.AddTb.Name = "AddTb";
            this.AddTb.Size = new System.Drawing.Size(350, 27);
            this.AddTb.TabIndex = 69;
            this.AddTb.Text = "Part Name";
            // 
            // AddPieceBtn
            // 
            this.AddPieceBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AddPieceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPieceBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPieceBtn.Location = new System.Drawing.Point(21, 148);
            this.AddPieceBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddPieceBtn.Name = "AddPieceBtn";
            this.AddPieceBtn.Size = new System.Drawing.Size(165, 40);
            this.AddPieceBtn.TabIndex = 26;
            this.AddPieceBtn.Text = "+ Piece";
            this.AddPieceBtn.UseVisualStyleBackColor = false;
            this.AddPieceBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.Controls.Add(this.SetPage);
            this.OptionsMenu.Controls.Add(this.PiecesTab);
            this.OptionsMenu.Controls.Add(this.SettingsPage);
            this.OptionsMenu.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsMenu.Location = new System.Drawing.Point(700, 0);
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.SelectedIndex = 0;
            this.OptionsMenu.Size = new System.Drawing.Size(400, 700);
            this.OptionsMenu.TabIndex = 90;
            // 
            // SetPage
            // 
            this.SetPage.BackColor = System.Drawing.Color.Honeydew;
            this.SetPage.Controls.Add(this.AddPartLbl);
            this.SetPage.Controls.Add(this.AddTb);
            this.SetPage.Controls.Add(this.NameTb);
            this.SetPage.Controls.Add(this.AddPieceBtn);
            this.SetPage.Controls.Add(this.AddSetBtn);
            this.SetPage.Location = new System.Drawing.Point(4, 27);
            this.SetPage.Name = "SetPage";
            this.SetPage.Padding = new System.Windows.Forms.Padding(3);
            this.SetPage.Size = new System.Drawing.Size(392, 669);
            this.SetPage.TabIndex = 0;
            this.SetPage.Text = "Set";
            // 
            // PiecesTab
            // 
            this.PiecesTab.BackColor = System.Drawing.Color.MintCream;
            this.PiecesTab.Controls.Add(this.SizeLbl);
            this.PiecesTab.Controls.Add(this.SizeBar);
            this.PiecesTab.Controls.Add(this.SpinLbl);
            this.PiecesTab.Controls.Add(this.SpinBar);
            this.PiecesTab.Controls.Add(this.TurnLbl);
            this.PiecesTab.Controls.Add(this.TurnBar);
            this.PiecesTab.Controls.Add(this.RotationLbl);
            this.PiecesTab.Controls.Add(this.RotationBar);
            this.PiecesTab.Controls.Add(this.OriginalLbl);
            this.PiecesTab.Controls.Add(this.UpBtn);
            this.PiecesTab.Controls.Add(this.DownBtn);
            this.PiecesTab.Controls.Add(this.OrderLbl);
            this.PiecesTab.Controls.Add(this.FlipsUpDown);
            this.PiecesTab.Controls.Add(this.FlipsCb);
            this.PiecesTab.Location = new System.Drawing.Point(4, 27);
            this.PiecesTab.Name = "PiecesTab";
            this.PiecesTab.Size = new System.Drawing.Size(392, 669);
            this.PiecesTab.TabIndex = 2;
            this.PiecesTab.Text = "Pieces";
            // 
            // SizeLbl
            // 
            this.SizeLbl.AutoSize = true;
            this.SizeLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SizeLbl.Location = new System.Drawing.Point(15, 295);
            this.SizeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SizeLbl.Name = "SizeLbl";
            this.SizeLbl.Size = new System.Drawing.Size(37, 19);
            this.SizeLbl.TabIndex = 116;
            this.SizeLbl.Text = "Size";
            // 
            // SizeBar
            // 
            this.SizeBar.Location = new System.Drawing.Point(21, 322);
            this.SizeBar.Maximum = 1000;
            this.SizeBar.Name = "SizeBar";
            this.SizeBar.Size = new System.Drawing.Size(350, 45);
            this.SizeBar.SmallChange = 5;
            this.SizeBar.TabIndex = 115;
            this.SizeBar.TickFrequency = 100;
            this.SizeBar.Value = 100;
            this.SizeBar.Scroll += new System.EventHandler(this.SizeBar_Scroll);
            // 
            // SpinLbl
            // 
            this.SpinLbl.AutoSize = true;
            this.SpinLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpinLbl.Location = new System.Drawing.Point(15, 215);
            this.SpinLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SpinLbl.Name = "SpinLbl";
            this.SpinLbl.Size = new System.Drawing.Size(40, 19);
            this.SpinLbl.TabIndex = 114;
            this.SpinLbl.Text = "Spin";
            // 
            // SpinBar
            // 
            this.SpinBar.Location = new System.Drawing.Point(21, 242);
            this.SpinBar.Maximum = 359;
            this.SpinBar.Name = "SpinBar";
            this.SpinBar.Size = new System.Drawing.Size(350, 45);
            this.SpinBar.TabIndex = 113;
            this.SpinBar.TickFrequency = 10;
            this.SpinBar.Scroll += new System.EventHandler(this.SpinBar_Scroll);
            // 
            // TurnLbl
            // 
            this.TurnLbl.AutoSize = true;
            this.TurnLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnLbl.Location = new System.Drawing.Point(15, 135);
            this.TurnLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TurnLbl.Name = "TurnLbl";
            this.TurnLbl.Size = new System.Drawing.Size(43, 19);
            this.TurnLbl.TabIndex = 112;
            this.TurnLbl.Text = "Turn";
            // 
            // TurnBar
            // 
            this.TurnBar.Location = new System.Drawing.Point(21, 162);
            this.TurnBar.Maximum = 359;
            this.TurnBar.Name = "TurnBar";
            this.TurnBar.Size = new System.Drawing.Size(350, 45);
            this.TurnBar.TabIndex = 111;
            this.TurnBar.TickFrequency = 10;
            this.TurnBar.Scroll += new System.EventHandler(this.TurnBar_Scroll);
            // 
            // RotationLbl
            // 
            this.RotationLbl.AutoSize = true;
            this.RotationLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotationLbl.Location = new System.Drawing.Point(15, 55);
            this.RotationLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RotationLbl.Name = "RotationLbl";
            this.RotationLbl.Size = new System.Drawing.Size(68, 19);
            this.RotationLbl.TabIndex = 110;
            this.RotationLbl.Text = "Rotation";
            // 
            // RotationBar
            // 
            this.RotationBar.Location = new System.Drawing.Point(21, 82);
            this.RotationBar.Maximum = 359;
            this.RotationBar.Name = "RotationBar";
            this.RotationBar.Size = new System.Drawing.Size(350, 45);
            this.RotationBar.TabIndex = 109;
            this.RotationBar.TickFrequency = 10;
            this.RotationBar.Scroll += new System.EventHandler(this.RotationBar_Scroll);
            // 
            // OriginalLbl
            // 
            this.OriginalLbl.AutoSize = true;
            this.OriginalLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginalLbl.Location = new System.Drawing.Point(15, 15);
            this.OriginalLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OriginalLbl.Name = "OriginalLbl";
            this.OriginalLbl.Size = new System.Drawing.Size(151, 23);
            this.OriginalLbl.TabIndex = 108;
            this.OriginalLbl.Text = "Original Positions";
            // 
            // UpBtn
            // 
            this.UpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.UpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpBtn.Location = new System.Drawing.Point(24, 462);
            this.UpBtn.Margin = new System.Windows.Forms.Padding(2);
            this.UpBtn.Name = "UpBtn";
            this.UpBtn.Size = new System.Drawing.Size(165, 40);
            this.UpBtn.TabIndex = 106;
            this.UpBtn.Text = "Move Up";
            this.UpBtn.UseVisualStyleBackColor = false;
            this.UpBtn.Click += new System.EventHandler(this.UpBtn_Click);
            // 
            // DownBtn
            // 
            this.DownBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownBtn.Location = new System.Drawing.Point(209, 462);
            this.DownBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DownBtn.Name = "DownBtn";
            this.DownBtn.Size = new System.Drawing.Size(165, 40);
            this.DownBtn.TabIndex = 107;
            this.DownBtn.Text = "Move Down";
            this.DownBtn.UseVisualStyleBackColor = false;
            this.DownBtn.Click += new System.EventHandler(this.DownBtn_Click);
            // 
            // OrderLbl
            // 
            this.OrderLbl.AutoSize = true;
            this.OrderLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderLbl.Location = new System.Drawing.Point(18, 424);
            this.OrderLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OrderLbl.Name = "OrderLbl";
            this.OrderLbl.Size = new System.Drawing.Size(58, 23);
            this.OrderLbl.TabIndex = 105;
            this.OrderLbl.Text = "Order";
            // 
            // FlipsUpDown
            // 
            this.FlipsUpDown.Enabled = false;
            this.FlipsUpDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlipsUpDown.Location = new System.Drawing.Point(136, 523);
            this.FlipsUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.FlipsUpDown.Maximum = new decimal(new int[] {
            179,
            0,
            0,
            0});
            this.FlipsUpDown.Name = "FlipsUpDown";
            this.FlipsUpDown.Size = new System.Drawing.Size(60, 27);
            this.FlipsUpDown.TabIndex = 104;
            this.FlipsUpDown.ValueChanged += new System.EventHandler(this.FlipsUpDown_ValueChanged);
            // 
            // FlipsCb
            // 
            this.FlipsCb.AutoSize = true;
            this.FlipsCb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlipsCb.Location = new System.Drawing.Point(24, 524);
            this.FlipsCb.Margin = new System.Windows.Forms.Padding(2);
            this.FlipsCb.Name = "FlipsCb";
            this.FlipsCb.Size = new System.Drawing.Size(68, 23);
            this.FlipsCb.TabIndex = 103;
            this.FlipsCb.Text = "Flips?";
            this.FlipsCb.UseVisualStyleBackColor = true;
            this.FlipsCb.CheckedChanged += new System.EventHandler(this.FlipsCb_CheckedChanged);
            // 
            // SettingsPage
            // 
            this.SettingsPage.BackColor = System.Drawing.Color.Honeydew;
            this.SettingsPage.Controls.Add(this.SelectFromTopCb);
            this.SettingsPage.Controls.Add(this.BackColourBox);
            this.SettingsPage.Controls.Add(this.BackColourLbl);
            this.SettingsPage.Location = new System.Drawing.Point(4, 27);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsPage.Size = new System.Drawing.Size(392, 669);
            this.SettingsPage.TabIndex = 1;
            this.SettingsPage.Text = "Settings";
            // 
            // SelectFromTopCb
            // 
            this.SelectFromTopCb.AutoSize = true;
            this.SelectFromTopCb.Checked = true;
            this.SelectFromTopCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelectFromTopCb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFromTopCb.Location = new System.Drawing.Point(18, 81);
            this.SelectFromTopCb.Margin = new System.Windows.Forms.Padding(2);
            this.SelectFromTopCb.Name = "SelectFromTopCb";
            this.SelectFromTopCb.Size = new System.Drawing.Size(182, 23);
            this.SelectFromTopCb.TabIndex = 118;
            this.SelectFromTopCb.Text = "Select Piece from Top";
            this.SelectFromTopCb.UseVisualStyleBackColor = true;
            // 
            // BackColourBox
            // 
            this.BackColourBox.BackColor = System.Drawing.Color.White;
            this.BackColourBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackColourBox.Location = new System.Drawing.Point(132, 16);
            this.BackColourBox.Name = "BackColourBox";
            this.BackColourBox.Size = new System.Drawing.Size(239, 30);
            this.BackColourBox.TabIndex = 117;
            this.BackColourBox.TabStop = false;
            this.BackColourBox.Click += new System.EventHandler(this.BackColourBox_Click);
            // 
            // BackColourLbl
            // 
            this.BackColourLbl.AutoSize = true;
            this.BackColourLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackColourLbl.Location = new System.Drawing.Point(14, 21);
            this.BackColourLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BackColourLbl.Name = "BackColourLbl";
            this.BackColourLbl.Size = new System.Drawing.Size(93, 19);
            this.BackColourLbl.TabIndex = 116;
            this.BackColourLbl.Text = "Back Colour";
            // 
            // DrawRight
            // 
            this.DrawRight.BackColor = System.Drawing.Color.White;
            this.DrawRight.Location = new System.Drawing.Point(360, 30);
            this.DrawRight.Margin = new System.Windows.Forms.Padding(6);
            this.DrawRight.Name = "DrawRight";
            this.DrawRight.Size = new System.Drawing.Size(300, 300);
            this.DrawRight.TabIndex = 93;
            this.DrawRight.TabStop = false;
            // 
            // DrawDown
            // 
            this.DrawDown.BackColor = System.Drawing.Color.White;
            this.DrawDown.Location = new System.Drawing.Point(30, 360);
            this.DrawDown.Margin = new System.Windows.Forms.Padding(6);
            this.DrawDown.Name = "DrawDown";
            this.DrawDown.Size = new System.Drawing.Size(300, 300);
            this.DrawDown.TabIndex = 92;
            this.DrawDown.TabStop = false;
            // 
            // DrawBase
            // 
            this.DrawBase.BackColor = System.Drawing.Color.White;
            this.DrawBase.Location = new System.Drawing.Point(30, 30);
            this.DrawBase.Margin = new System.Windows.Forms.Padding(6);
            this.DrawBase.Name = "DrawBase";
            this.DrawBase.Size = new System.Drawing.Size(300, 300);
            this.DrawBase.TabIndex = 91;
            this.DrawBase.TabStop = false;
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.Location = new System.Drawing.Point(360, 465);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(300, 90);
            this.ExitBtn.TabIndex = 94;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            // 
            // AddPartLbl
            // 
            this.AddPartLbl.AutoSize = true;
            this.AddPartLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPartLbl.Location = new System.Drawing.Point(135, 70);
            this.AddPartLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddPartLbl.Name = "AddPartLbl";
            this.AddPartLbl.Size = new System.Drawing.Size(92, 23);
            this.AddPartLbl.TabIndex = 120;
            this.AddPartLbl.Text = "Add Part";
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PreviewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewBtn.Location = new System.Drawing.Point(360, 360);
            this.PreviewBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(300, 90);
            this.PreviewBtn.TabIndex = 95;
            this.PreviewBtn.Text = "Preview";
            this.PreviewBtn.UseVisualStyleBackColor = false;
            // 
            // SetsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.PreviewBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.DrawRight);
            this.Controls.Add(this.DrawDown);
            this.Controls.Add(this.CompleteBtn);
            this.Controls.Add(this.DrawBase);
            this.Controls.Add(this.OptionsMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SetsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetsForm";
            this.OptionsMenu.ResumeLayout(false);
            this.SetPage.ResumeLayout(false);
            this.SetPage.PerformLayout();
            this.PiecesTab.ResumeLayout(false);
            this.PiecesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlipsUpDown)).EndInit();
            this.SettingsPage.ResumeLayout(false);
            this.SettingsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackColourBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.Button CompleteBtn;
        private System.Windows.Forms.Button AddPieceBtn;
        private System.Windows.Forms.TextBox AddTb;
        private System.Windows.Forms.Button AddSetBtn;
        private System.Windows.Forms.TabControl OptionsMenu;
        private System.Windows.Forms.TabPage SetPage;
        private System.Windows.Forms.TabPage SettingsPage;
        private System.Windows.Forms.TabPage PiecesTab;
        private System.Windows.Forms.Label SizeLbl;
        private System.Windows.Forms.TrackBar SizeBar;
        private System.Windows.Forms.Label SpinLbl;
        private System.Windows.Forms.TrackBar SpinBar;
        private System.Windows.Forms.Label TurnLbl;
        private System.Windows.Forms.TrackBar TurnBar;
        private System.Windows.Forms.Label RotationLbl;
        private System.Windows.Forms.TrackBar RotationBar;
        private System.Windows.Forms.Label OriginalLbl;
        private System.Windows.Forms.Button UpBtn;
        private System.Windows.Forms.Button DownBtn;
        private System.Windows.Forms.Label OrderLbl;
        private System.Windows.Forms.NumericUpDown FlipsUpDown;
        private System.Windows.Forms.CheckBox FlipsCb;
        private System.Windows.Forms.PictureBox BackColourBox;
        private System.Windows.Forms.Label BackColourLbl;
        private System.Windows.Forms.CheckBox SelectFromTopCb;
        private System.Windows.Forms.PictureBox DrawRight;
        private System.Windows.Forms.PictureBox DrawDown;
        private System.Windows.Forms.PictureBox DrawBase;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label AddPartLbl;
        private System.Windows.Forms.Button PreviewBtn;
    }
}