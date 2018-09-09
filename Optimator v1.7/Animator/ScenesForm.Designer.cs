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
            this.animationPanel = new System.Windows.Forms.Panel();
            this.addAnimationBtn = new System.Windows.Forms.Button();
            this.animationLb = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.changeTypeCb = new System.Windows.Forms.ComboBox();
            this.animationAmountTb = new System.Windows.Forms.NumericUpDown();
            this.nextFrameBtn = new System.Windows.Forms.Button();
            this.finishSceneBtn = new System.Windows.Forms.Button();
            this.basePrevCb = new System.Windows.Forms.CheckBox();
            this.calculatorBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.sceneNameTb = new System.Windows.Forms.TextBox();
            this.partsPanelBtn = new System.Windows.Forms.Button();
            this.switchSidesBtn2 = new System.Windows.Forms.Button();
            this.fpsUpDown = new System.Windows.Forms.NumericUpDown();
            this.frameLengthUpDown = new System.Windows.Forms.NumericUpDown();
            this.sceneNumber = new System.Windows.Forms.TextBox();
            this.partsPanel = new System.Windows.Forms.Panel();
            this.NameTb = new System.Windows.Forms.TextBox();
            this.AddPieceBtn = new System.Windows.Forms.Button();
            this.rotationUpDown = new System.Windows.Forms.NumericUpDown();
            this.turnUpDown = new System.Windows.Forms.NumericUpDown();
            this.partsLb = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.spinUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.upBtn = new System.Windows.Forms.Button();
            this.downBtn = new System.Windows.Forms.Button();
            this.xUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.yUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.sizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.AnimationPanelBtn = new System.Windows.Forms.Button();
            this.switchSidesBtn1 = new System.Windows.Forms.Button();
            this.AddSetBtn = new System.Windows.Forms.Button();
            this.DrawPanel = new System.Windows.Forms.PictureBox();
            this.animationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationAmountTb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameLengthUpDown)).BeginInit();
            this.partsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotationUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // animationPanel
            // 
            this.animationPanel.BackColor = System.Drawing.Color.PaleTurquoise;
            this.animationPanel.Controls.Add(this.sceneNumber);
            this.animationPanel.Controls.Add(this.frameLengthUpDown);
            this.animationPanel.Controls.Add(this.fpsUpDown);
            this.animationPanel.Controls.Add(this.switchSidesBtn2);
            this.animationPanel.Controls.Add(this.partsPanelBtn);
            this.animationPanel.Controls.Add(this.sceneNameTb);
            this.animationPanel.Controls.Add(this.backBtn);
            this.animationPanel.Controls.Add(this.calculatorBtn);
            this.animationPanel.Controls.Add(this.basePrevCb);
            this.animationPanel.Controls.Add(this.finishSceneBtn);
            this.animationPanel.Controls.Add(this.nextFrameBtn);
            this.animationPanel.Controls.Add(this.animationAmountTb);
            this.animationPanel.Controls.Add(this.changeTypeCb);
            this.animationPanel.Controls.Add(this.button3);
            this.animationPanel.Controls.Add(this.animationLb);
            this.animationPanel.Controls.Add(this.addAnimationBtn);
            this.animationPanel.Location = new System.Drawing.Point(0, 0);
            this.animationPanel.Name = "animationPanel";
            this.animationPanel.Size = new System.Drawing.Size(300, 1080);
            this.animationPanel.TabIndex = 19;
            this.animationPanel.Visible = false;
            // 
            // addAnimationBtn
            // 
            this.addAnimationBtn.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAnimationBtn.Location = new System.Drawing.Point(8, 357);
            this.addAnimationBtn.Name = "addAnimationBtn";
            this.addAnimationBtn.Size = new System.Drawing.Size(284, 55);
            this.addAnimationBtn.TabIndex = 1;
            this.addAnimationBtn.Text = "Add";
            this.addAnimationBtn.UseVisualStyleBackColor = true;
            this.addAnimationBtn.Click += new System.EventHandler(this.addAnimationBtn_Click);
            // 
            // animationLb
            // 
            this.animationLb.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animationLb.FormattingEnabled = true;
            this.animationLb.ItemHeight = 33;
            this.animationLb.Location = new System.Drawing.Point(8, 83);
            this.animationLb.Name = "animationLb";
            this.animationLb.Size = new System.Drawing.Size(284, 268);
            this.animationLb.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(8, 421);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(284, 55);
            this.button3.TabIndex = 10;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // changeTypeCb
            // 
            this.changeTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.changeTypeCb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeTypeCb.FormattingEnabled = true;
            this.changeTypeCb.Items.AddRange(new object[] {
            "X",
            "Y",
            "Rotation",
            "Turn",
            "Spin",
            "Size",
            "Order",
            "Removed"});
            this.changeTypeCb.Location = new System.Drawing.Point(8, 483);
            this.changeTypeCb.Name = "changeTypeCb";
            this.changeTypeCb.Size = new System.Drawing.Size(284, 47);
            this.changeTypeCb.TabIndex = 11;
            // 
            // animationAmountTb
            // 
            this.animationAmountTb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animationAmountTb.Location = new System.Drawing.Point(8, 542);
            this.animationAmountTb.Name = "animationAmountTb";
            this.animationAmountTb.Size = new System.Drawing.Size(284, 47);
            this.animationAmountTb.TabIndex = 12;
            // 
            // nextFrameBtn
            // 
            this.nextFrameBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextFrameBtn.Location = new System.Drawing.Point(8, 887);
            this.nextFrameBtn.Name = "nextFrameBtn";
            this.nextFrameBtn.Size = new System.Drawing.Size(284, 53);
            this.nextFrameBtn.TabIndex = 19;
            this.nextFrameBtn.Text = "Next Frame";
            this.nextFrameBtn.UseVisualStyleBackColor = true;
            this.nextFrameBtn.Click += new System.EventHandler(this.nextFrameBtn_Click);
            // 
            // finishSceneBtn
            // 
            this.finishSceneBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finishSceneBtn.Location = new System.Drawing.Point(8, 1007);
            this.finishSceneBtn.Name = "finishSceneBtn";
            this.finishSceneBtn.Size = new System.Drawing.Size(284, 46);
            this.finishSceneBtn.TabIndex = 20;
            this.finishSceneBtn.Text = "Finish Scene";
            this.finishSceneBtn.UseVisualStyleBackColor = true;
            this.finishSceneBtn.Click += new System.EventHandler(this.finishSceneBtn_Click);
            // 
            // basePrevCb
            // 
            this.basePrevCb.AutoSize = true;
            this.basePrevCb.Checked = true;
            this.basePrevCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.basePrevCb.Enabled = false;
            this.basePrevCb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.basePrevCb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.basePrevCb.Location = new System.Drawing.Point(39, 832);
            this.basePrevCb.Name = "basePrevCb";
            this.basePrevCb.Size = new System.Drawing.Size(209, 43);
            this.basePrevCb.TabIndex = 21;
            this.basePrevCb.Text = "Base Prev.";
            this.basePrevCb.UseVisualStyleBackColor = true;
            // 
            // calculatorBtn
            // 
            this.calculatorBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculatorBtn.Location = new System.Drawing.Point(8, 715);
            this.calculatorBtn.Name = "calculatorBtn";
            this.calculatorBtn.Size = new System.Drawing.Size(196, 97);
            this.calculatorBtn.TabIndex = 22;
            this.calculatorBtn.Text = "Movement Calculator";
            this.calculatorBtn.UseVisualStyleBackColor = true;
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.Location = new System.Drawing.Point(8, 946);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(284, 55);
            this.backBtn.TabIndex = 23;
            this.backBtn.Text = "Prev Frame";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // sceneNameTb
            // 
            this.sceneNameTb.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sceneNameTb.Location = new System.Drawing.Point(8, 660);
            this.sceneNameTb.Name = "sceneNameTb";
            this.sceneNameTb.Size = new System.Drawing.Size(284, 41);
            this.sceneNameTb.TabIndex = 19;
            this.sceneNameTb.Text = "Scene Name";
            // 
            // partsPanelBtn
            // 
            this.partsPanelBtn.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partsPanelBtn.Location = new System.Drawing.Point(8, 12);
            this.partsPanelBtn.Name = "partsPanelBtn";
            this.partsPanelBtn.Size = new System.Drawing.Size(137, 55);
            this.partsPanelBtn.TabIndex = 25;
            this.partsPanelBtn.Text = "Parts";
            this.partsPanelBtn.UseVisualStyleBackColor = true;
            this.partsPanelBtn.Click += new System.EventHandler(this.partsPanelBtn_Click);
            // 
            // switchSidesBtn2
            // 
            this.switchSidesBtn2.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.switchSidesBtn2.Location = new System.Drawing.Point(155, 12);
            this.switchSidesBtn2.Name = "switchSidesBtn2";
            this.switchSidesBtn2.Size = new System.Drawing.Size(137, 55);
            this.switchSidesBtn2.TabIndex = 26;
            this.switchSidesBtn2.Text = "< >";
            this.switchSidesBtn2.UseVisualStyleBackColor = true;
            this.switchSidesBtn2.Click += new System.EventHandler(this.switchSidesBtn2_Click);
            // 
            // fpsUpDown
            // 
            this.fpsUpDown.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fpsUpDown.Location = new System.Drawing.Point(139, 794);
            this.fpsUpDown.Name = "fpsUpDown";
            this.fpsUpDown.Size = new System.Drawing.Size(145, 47);
            this.fpsUpDown.TabIndex = 24;
            this.fpsUpDown.Visible = false;
            // 
            // frameLengthUpDown
            // 
            this.frameLengthUpDown.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameLengthUpDown.Location = new System.Drawing.Point(8, 595);
            this.frameLengthUpDown.Name = "frameLengthUpDown";
            this.frameLengthUpDown.Size = new System.Drawing.Size(284, 47);
            this.frameLengthUpDown.TabIndex = 27;
            // 
            // sceneNumber
            // 
            this.sceneNumber.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sceneNumber.Location = new System.Drawing.Point(223, 747);
            this.sceneNumber.Name = "sceneNumber";
            this.sceneNumber.Size = new System.Drawing.Size(61, 41);
            this.sceneNumber.TabIndex = 28;
            this.sceneNumber.Text = "0";
            // 
            // partsPanel
            // 
            this.partsPanel.BackColor = System.Drawing.Color.PaleTurquoise;
            this.partsPanel.Controls.Add(this.AddSetBtn);
            this.partsPanel.Controls.Add(this.switchSidesBtn1);
            this.partsPanel.Controls.Add(this.AnimationPanelBtn);
            this.partsPanel.Controls.Add(this.label6);
            this.partsPanel.Controls.Add(this.sizeUpDown);
            this.partsPanel.Controls.Add(this.label5);
            this.partsPanel.Controls.Add(this.yUpDown);
            this.partsPanel.Controls.Add(this.label4);
            this.partsPanel.Controls.Add(this.xUpDown);
            this.partsPanel.Controls.Add(this.downBtn);
            this.partsPanel.Controls.Add(this.upBtn);
            this.partsPanel.Controls.Add(this.deleteBtn);
            this.partsPanel.Controls.Add(this.label3);
            this.partsPanel.Controls.Add(this.spinUpDown);
            this.partsPanel.Controls.Add(this.label2);
            this.partsPanel.Controls.Add(this.label1);
            this.partsPanel.Controls.Add(this.partsLb);
            this.partsPanel.Controls.Add(this.turnUpDown);
            this.partsPanel.Controls.Add(this.rotationUpDown);
            this.partsPanel.Controls.Add(this.AddPieceBtn);
            this.partsPanel.Controls.Add(this.NameTb);
            this.partsPanel.Location = new System.Drawing.Point(0, 0);
            this.partsPanel.Name = "partsPanel";
            this.partsPanel.Size = new System.Drawing.Size(300, 1080);
            this.partsPanel.TabIndex = 1;
            // 
            // NameTb
            // 
            this.NameTb.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTb.Location = new System.Drawing.Point(8, 83);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(284, 41);
            this.NameTb.TabIndex = 0;
            // 
            // AddPieceBtn
            // 
            this.AddPieceBtn.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPieceBtn.Location = new System.Drawing.Point(8, 140);
            this.AddPieceBtn.Name = "AddPieceBtn";
            this.AddPieceBtn.Size = new System.Drawing.Size(89, 55);
            this.AddPieceBtn.TabIndex = 1;
            this.AddPieceBtn.Text = "Add";
            this.AddPieceBtn.UseVisualStyleBackColor = true;
            this.AddPieceBtn.Click += new System.EventHandler(this.AddPieceBtn_Click);
            // 
            // rotationUpDown
            // 
            this.rotationUpDown.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rotationUpDown.Location = new System.Drawing.Point(25, 575);
            this.rotationUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.rotationUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.rotationUpDown.Name = "rotationUpDown";
            this.rotationUpDown.Size = new System.Drawing.Size(158, 41);
            this.rotationUpDown.TabIndex = 2;
            this.rotationUpDown.ValueChanged += new System.EventHandler(this.rotationUpDown_ValueChanged);
            // 
            // turnUpDown
            // 
            this.turnUpDown.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnUpDown.Location = new System.Drawing.Point(25, 661);
            this.turnUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.turnUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.turnUpDown.Name = "turnUpDown";
            this.turnUpDown.Size = new System.Drawing.Size(158, 41);
            this.turnUpDown.TabIndex = 3;
            this.turnUpDown.ValueChanged += new System.EventHandler(this.turnUpDown_ValueChanged);
            // 
            // partsLb
            // 
            this.partsLb.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partsLb.FormattingEnabled = true;
            this.partsLb.ItemHeight = 33;
            this.partsLb.Location = new System.Drawing.Point(8, 210);
            this.partsLb.Name = "partsLb";
            this.partsLb.Size = new System.Drawing.Size(284, 235);
            this.partsLb.TabIndex = 4;
            this.partsLb.SelectedIndexChanged += new System.EventHandler(this.partsLb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 533);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rotation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 619);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 39);
            this.label2.TabIndex = 6;
            this.label2.Text = "Turn";
            // 
            // spinUpDown
            // 
            this.spinUpDown.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinUpDown.Location = new System.Drawing.Point(25, 747);
            this.spinUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.spinUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.spinUpDown.Name = "spinUpDown";
            this.spinUpDown.Size = new System.Drawing.Size(158, 41);
            this.spinUpDown.TabIndex = 8;
            this.spinUpDown.ValueChanged += new System.EventHandler(this.SpinUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 705);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 39);
            this.label3.TabIndex = 9;
            this.label3.Text = "Spin";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(215, 140);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(77, 55);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // upBtn
            // 
            this.upBtn.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upBtn.Location = new System.Drawing.Point(8, 458);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(137, 55);
            this.upBtn.TabIndex = 11;
            this.upBtn.Text = "Up";
            this.upBtn.UseVisualStyleBackColor = true;
            this.upBtn.Click += new System.EventHandler(this.upBtn_Click);
            // 
            // downBtn
            // 
            this.downBtn.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downBtn.Location = new System.Drawing.Point(155, 458);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(137, 55);
            this.downBtn.TabIndex = 12;
            this.downBtn.Text = "Dn";
            this.downBtn.UseVisualStyleBackColor = true;
            this.downBtn.Click += new System.EventHandler(this.downBtn_Click);
            // 
            // xUpDown
            // 
            this.xUpDown.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xUpDown.Location = new System.Drawing.Point(25, 830);
            this.xUpDown.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.xUpDown.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.xUpDown.Name = "xUpDown";
            this.xUpDown.Size = new System.Drawing.Size(158, 41);
            this.xUpDown.TabIndex = 13;
            this.xUpDown.ValueChanged += new System.EventHandler(this.xUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 788);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 39);
            this.label4.TabIndex = 14;
            this.label4.Text = "X";
            // 
            // yUpDown
            // 
            this.yUpDown.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yUpDown.Location = new System.Drawing.Point(25, 915);
            this.yUpDown.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.yUpDown.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            -2147483648});
            this.yUpDown.Name = "yUpDown";
            this.yUpDown.Size = new System.Drawing.Size(158, 41);
            this.yUpDown.TabIndex = 15;
            this.yUpDown.ValueChanged += new System.EventHandler(this.yUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 873);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 39);
            this.label5.TabIndex = 16;
            this.label5.Text = "Y";
            // 
            // sizeUpDown
            // 
            this.sizeUpDown.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeUpDown.Location = new System.Drawing.Point(25, 998);
            this.sizeUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sizeUpDown.Name = "sizeUpDown";
            this.sizeUpDown.Size = new System.Drawing.Size(158, 41);
            this.sizeUpDown.TabIndex = 17;
            this.sizeUpDown.ValueChanged += new System.EventHandler(this.sizeUpDown_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 956);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 39);
            this.label6.TabIndex = 18;
            this.label6.Text = "Size Mod";
            // 
            // AnimationPanelBtn
            // 
            this.AnimationPanelBtn.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnimationPanelBtn.Location = new System.Drawing.Point(8, 12);
            this.AnimationPanelBtn.Name = "AnimationPanelBtn";
            this.AnimationPanelBtn.Size = new System.Drawing.Size(137, 55);
            this.AnimationPanelBtn.TabIndex = 19;
            this.AnimationPanelBtn.Text = "Ani.";
            this.AnimationPanelBtn.UseVisualStyleBackColor = true;
            this.AnimationPanelBtn.Click += new System.EventHandler(this.AnimationPanelBtn_Click);
            // 
            // switchSidesBtn1
            // 
            this.switchSidesBtn1.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.switchSidesBtn1.Location = new System.Drawing.Point(155, 12);
            this.switchSidesBtn1.Name = "switchSidesBtn1";
            this.switchSidesBtn1.Size = new System.Drawing.Size(137, 55);
            this.switchSidesBtn1.TabIndex = 20;
            this.switchSidesBtn1.Text = "< >";
            this.switchSidesBtn1.UseVisualStyleBackColor = true;
            this.switchSidesBtn1.Click += new System.EventHandler(this.switchSidesBtn1_Click);
            // 
            // AddSetBtn
            // 
            this.AddSetBtn.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSetBtn.Location = new System.Drawing.Point(115, 140);
            this.AddSetBtn.Name = "AddSetBtn";
            this.AddSetBtn.Size = new System.Drawing.Size(89, 55);
            this.AddSetBtn.TabIndex = 21;
            this.AddSetBtn.Text = "Set";
            this.AddSetBtn.UseVisualStyleBackColor = true;
            this.AddSetBtn.Click += new System.EventHandler(this.AddSetBtn_Click);
            // 
            // DrawPanel
            // 
            this.DrawPanel.Location = new System.Drawing.Point(0, 0);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(1920, 1080);
            this.DrawPanel.TabIndex = 20;
            this.DrawPanel.TabStop = false;
            // 
            // ScenesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.animationPanel);
            this.Controls.Add(this.partsPanel);
            this.Controls.Add(this.DrawPanel);
            this.Name = "ScenesForm";
            this.ShowIcon = false;
            this.Text = "ScenesForm";
            this.animationPanel.ResumeLayout(false);
            this.animationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationAmountTb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameLengthUpDown)).EndInit();
            this.partsPanel.ResumeLayout(false);
            this.partsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotationUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel animationPanel;
        private System.Windows.Forms.TextBox sceneNumber;
        private System.Windows.Forms.NumericUpDown frameLengthUpDown;
        private System.Windows.Forms.NumericUpDown fpsUpDown;
        private System.Windows.Forms.Button switchSidesBtn2;
        private System.Windows.Forms.Button partsPanelBtn;
        private System.Windows.Forms.TextBox sceneNameTb;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button calculatorBtn;
        private System.Windows.Forms.CheckBox basePrevCb;
        private System.Windows.Forms.Button finishSceneBtn;
        private System.Windows.Forms.Button nextFrameBtn;
        private System.Windows.Forms.NumericUpDown animationAmountTb;
        private System.Windows.Forms.ComboBox changeTypeCb;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox animationLb;
        private System.Windows.Forms.Button addAnimationBtn;
        private System.Windows.Forms.Panel partsPanel;
        private System.Windows.Forms.Button AddSetBtn;
        private System.Windows.Forms.Button switchSidesBtn1;
        private System.Windows.Forms.Button AnimationPanelBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown sizeUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown yUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown xUpDown;
        private System.Windows.Forms.Button downBtn;
        private System.Windows.Forms.Button upBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown spinUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox partsLb;
        private System.Windows.Forms.NumericUpDown turnUpDown;
        private System.Windows.Forms.NumericUpDown rotationUpDown;
        private System.Windows.Forms.Button AddPieceBtn;
        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.PictureBox DrawPanel;
    }
}