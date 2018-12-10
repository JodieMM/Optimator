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
            this.SetsTab = new System.Windows.Forms.TabPage();
            this.AddPointBtn = new System.Windows.Forms.Button();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.BackColourBox = new System.Windows.Forms.PictureBox();
            this.BackColourLbl = new System.Windows.Forms.Label();
            this.DrawDown = new System.Windows.Forms.PictureBox();
            this.DrawRight = new System.Windows.Forms.PictureBox();
            this.PointBtn = new System.Windows.Forms.Button();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.CompleteBtn = new System.Windows.Forms.Button();
            this.RefineBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.EmptyBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawBase)).BeginInit();
            this.OptionsMenu.SuspendLayout();
            this.ShapeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutlineWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutlineBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillBox)).BeginInit();
            this.SetsTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackColourBox)).BeginInit();
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
            this.OptionsMenu.Controls.Add(this.SetsTab);
            this.OptionsMenu.Controls.Add(this.SettingsTab);
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
            // SetsTab
            // 
            this.SetsTab.BackColor = System.Drawing.Color.Azure;
            this.SetsTab.Controls.Add(this.AddPointBtn);
            this.SetsTab.Location = new System.Drawing.Point(8, 50);
            this.SetsTab.Name = "SetsTab";
            this.SetsTab.Size = new System.Drawing.Size(384, 642);
            this.SetsTab.TabIndex = 2;
            this.SetsTab.Text = "Sets";
            // 
            // AddPointBtn
            // 
            this.AddPointBtn.BackColor = System.Drawing.Color.LightCyan;
            this.AddPointBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPointBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPointBtn.Location = new System.Drawing.Point(15, 17);
            this.AddPointBtn.Margin = new System.Windows.Forms.Padding(6);
            this.AddPointBtn.Name = "AddPointBtn";
            this.AddPointBtn.Size = new System.Drawing.Size(363, 55);
            this.AddPointBtn.TabIndex = 13;
            this.AddPointBtn.Text = "Add Point";
            this.AddPointBtn.UseVisualStyleBackColor = false;
            this.AddPointBtn.Click += new System.EventHandler(this.AddPointBtn_Click);
            // 
            // SettingsTab
            // 
            this.SettingsTab.BackColor = System.Drawing.Color.Azure;
            this.SettingsTab.Controls.Add(this.BackColourBox);
            this.SettingsTab.Controls.Add(this.BackColourLbl);
            this.SettingsTab.Location = new System.Drawing.Point(8, 50);
            this.SettingsTab.Margin = new System.Windows.Forms.Padding(6);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(6);
            this.SettingsTab.Size = new System.Drawing.Size(384, 642);
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "Settings";
            // 
            // BackColourBox
            // 
            this.BackColourBox.BackColor = System.Drawing.Color.White;
            this.BackColourBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackColourBox.Location = new System.Drawing.Point(136, 18);
            this.BackColourBox.Name = "BackColourBox";
            this.BackColourBox.Size = new System.Drawing.Size(239, 30);
            this.BackColourBox.TabIndex = 115;
            this.BackColourBox.TabStop = false;
            this.BackColourBox.Click += new System.EventHandler(this.BackColourBox_Click);
            // 
            // BackColourLbl
            // 
            this.BackColourLbl.AutoSize = true;
            this.BackColourLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackColourLbl.Location = new System.Drawing.Point(18, 23);
            this.BackColourLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BackColourLbl.Name = "BackColourLbl";
            this.BackColourLbl.Size = new System.Drawing.Size(184, 39);
            this.BackColourLbl.TabIndex = 114;
            this.BackColourLbl.Text = "Back Colour";
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
            // RefineBtn
            // 
            this.RefineBtn.BackColor = System.Drawing.Color.LightCyan;
            this.RefineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefineBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefineBtn.Location = new System.Drawing.Point(465, 465);
            this.RefineBtn.Margin = new System.Windows.Forms.Padding(6);
            this.RefineBtn.Name = "RefineBtn";
            this.RefineBtn.Size = new System.Drawing.Size(90, 90);
            this.RefineBtn.TabIndex = 12;
            this.RefineBtn.Text = "Refine";
            this.RefineBtn.UseVisualStyleBackColor = false;
            this.RefineBtn.Click += new System.EventHandler(this.RefineBtn_Click);
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
            this.EmptyBtn.Location = new System.Drawing.Point(465, 360);
            this.EmptyBtn.Margin = new System.Windows.Forms.Padding(6);
            this.EmptyBtn.Name = "EmptyBtn";
            this.EmptyBtn.Size = new System.Drawing.Size(90, 90);
            this.EmptyBtn.TabIndex = 13;
            this.EmptyBtn.Text = "TBD";
            this.EmptyBtn.UseVisualStyleBackColor = false;
            // 
            // PiecesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.EmptyBtn);
            this.Controls.Add(this.RefineBtn);
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
            this.SetsTab.ResumeLayout(false);
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackColourBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawBase;
        private System.Windows.Forms.TabControl OptionsMenu;
        private System.Windows.Forms.TabPage ShapeTab;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.PictureBox DrawDown;
        private System.Windows.Forms.PictureBox DrawRight;
        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.Button PointBtn;
        private System.Windows.Forms.Button PreviewBtn;
        private System.Windows.Forms.Button CompleteBtn;
        private System.Windows.Forms.Button RefineBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.TabPage SetsTab;
        private System.Windows.Forms.Button AddPointBtn;
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
        private System.Windows.Forms.PictureBox BackColourBox;
        private System.Windows.Forms.Label BackColourLbl;
        private System.Windows.Forms.Button EmptyBtn;
    }
}