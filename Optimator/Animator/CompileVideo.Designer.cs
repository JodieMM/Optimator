namespace Optimator
{
    partial class CompileVideo
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
            this.components = new System.ComponentModel.Container();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.PlayBtn = new System.Windows.Forms.Button();
            this.SubmitScene = new System.Windows.Forms.Button();
            this.SceneTb = new System.Windows.Forms.TextBox();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.DrawPanel = new System.Windows.Forms.PictureBox();
            this.OptionsMenu = new System.Windows.Forms.TabControl();
            this.ScenesTab = new System.Windows.Forms.TabPage();
            this.VideoTab = new System.Windows.Forms.TabPage();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.NameTb = new System.Windows.Forms.TextBox();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.TimeIntervalLbl = new System.Windows.Forms.Label();
            this.TimeIncrementUpDown = new System.Windows.Forms.NumericUpDown();
            this.PreviewCb = new System.Windows.Forms.CheckBox();
            this.FpsLbl = new System.Windows.Forms.Label();
            this.FpsUpDown = new System.Windows.Forms.NumericUpDown();
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.UpArrowImg = new System.Windows.Forms.Label();
            this.Future2PreviewBox = new System.Windows.Forms.PictureBox();
            this.FuturePreviewBox = new System.Windows.Forms.PictureBox();
            this.PastPreviewBox = new System.Windows.Forms.PictureBox();
            this.CurrentTimeLbl = new System.Windows.Forms.Label();
            this.CurrentTimeUpDown = new System.Windows.Forms.NumericUpDown();
            this.ForwardBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).BeginInit();
            this.OptionsMenu.SuspendLayout();
            this.ScenesTab.SuspendLayout();
            this.VideoTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeIncrementUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FpsUpDown)).BeginInit();
            this.DisplayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Future2PreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuturePreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PastPreviewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTimeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.LightCoral;
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.Location = new System.Drawing.Point(10, 550);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(182, 50);
            this.SaveBtn.TabIndex = 4;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // PlayBtn
            // 
            this.PlayBtn.BackColor = System.Drawing.Color.Salmon;
            this.PlayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayBtn.Location = new System.Drawing.Point(10, 128);
            this.PlayBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(182, 50);
            this.PlayBtn.TabIndex = 2;
            this.PlayBtn.Text = "Play";
            this.PlayBtn.UseVisualStyleBackColor = false;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // SubmitScene
            // 
            this.SubmitScene.BackColor = System.Drawing.Color.Salmon;
            this.SubmitScene.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitScene.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitScene.Location = new System.Drawing.Point(10, 58);
            this.SubmitScene.Margin = new System.Windows.Forms.Padding(2);
            this.SubmitScene.Name = "SubmitScene";
            this.SubmitScene.Size = new System.Drawing.Size(182, 50);
            this.SubmitScene.TabIndex = 1;
            this.SubmitScene.Text = "Get Scene";
            this.SubmitScene.UseVisualStyleBackColor = false;
            this.SubmitScene.Click += new System.EventHandler(this.SubmitScene_Click);
            // 
            // SceneTb
            // 
            this.SceneTb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SceneTb.Location = new System.Drawing.Point(10, 10);
            this.SceneTb.Margin = new System.Windows.Forms.Padding(2);
            this.SceneTb.Name = "SceneTb";
            this.SceneTb.Size = new System.Drawing.Size(182, 53);
            this.SceneTb.TabIndex = 0;
            this.SceneTb.Text = "Scene Name";
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // DrawPanel
            // 
            this.DrawPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DrawPanel.BackColor = System.Drawing.Color.White;
            this.DrawPanel.Location = new System.Drawing.Point(0, 10);
            this.DrawPanel.Margin = new System.Windows.Forms.Padding(2);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(880, 495);
            this.DrawPanel.TabIndex = 1;
            this.DrawPanel.TabStop = false;
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.Controls.Add(this.ScenesTab);
            this.OptionsMenu.Controls.Add(this.VideoTab);
            this.OptionsMenu.Controls.Add(this.SettingsTab);
            this.OptionsMenu.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsMenu.Location = new System.Drawing.Point(890, 0);
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.SelectedIndex = 0;
            this.OptionsMenu.Size = new System.Drawing.Size(210, 700);
            this.OptionsMenu.TabIndex = 2;
            // 
            // ScenesTab
            // 
            this.ScenesTab.BackColor = System.Drawing.Color.MistyRose;
            this.ScenesTab.Controls.Add(this.PlayBtn);
            this.ScenesTab.Controls.Add(this.SceneTb);
            this.ScenesTab.Controls.Add(this.SubmitScene);
            this.ScenesTab.Location = new System.Drawing.Point(8, 50);
            this.ScenesTab.Name = "ScenesTab";
            this.ScenesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ScenesTab.Size = new System.Drawing.Size(194, 642);
            this.ScenesTab.TabIndex = 0;
            this.ScenesTab.Text = "Scenes";
            // 
            // VideoTab
            // 
            this.VideoTab.BackColor = System.Drawing.Color.MistyRose;
            this.VideoTab.Controls.Add(this.SaveBtn);
            this.VideoTab.Controls.Add(this.ExitBtn);
            this.VideoTab.Controls.Add(this.NameTb);
            this.VideoTab.Location = new System.Drawing.Point(8, 50);
            this.VideoTab.Name = "VideoTab";
            this.VideoTab.Padding = new System.Windows.Forms.Padding(3);
            this.VideoTab.Size = new System.Drawing.Size(194, 642);
            this.VideoTab.TabIndex = 1;
            this.VideoTab.Text = "Video";
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.LightCoral;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.Black;
            this.ExitBtn.Location = new System.Drawing.Point(10, 610);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(182, 50);
            this.ExitBtn.TabIndex = 26;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // NameTb
            // 
            this.NameTb.BackColor = System.Drawing.Color.White;
            this.NameTb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTb.Location = new System.Drawing.Point(10, 10);
            this.NameTb.Margin = new System.Windows.Forms.Padding(6);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(182, 53);
            this.NameTb.TabIndex = 25;
            this.NameTb.Text = "Video Name";
            // 
            // SettingsTab
            // 
            this.SettingsTab.BackColor = System.Drawing.Color.MistyRose;
            this.SettingsTab.Controls.Add(this.TimeIntervalLbl);
            this.SettingsTab.Controls.Add(this.TimeIncrementUpDown);
            this.SettingsTab.Controls.Add(this.PreviewCb);
            this.SettingsTab.Controls.Add(this.FpsLbl);
            this.SettingsTab.Controls.Add(this.FpsUpDown);
            this.SettingsTab.Location = new System.Drawing.Point(8, 50);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Size = new System.Drawing.Size(194, 642);
            this.SettingsTab.TabIndex = 2;
            this.SettingsTab.Text = "Settings";
            // 
            // TimeIntervalLbl
            // 
            this.TimeIntervalLbl.AutoSize = true;
            this.TimeIntervalLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeIntervalLbl.Location = new System.Drawing.Point(13, 154);
            this.TimeIntervalLbl.Name = "TimeIntervalLbl";
            this.TimeIntervalLbl.Size = new System.Drawing.Size(274, 39);
            this.TimeIntervalLbl.TabIndex = 39;
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
            this.TimeIncrementUpDown.Location = new System.Drawing.Point(17, 176);
            this.TimeIncrementUpDown.Name = "TimeIncrementUpDown";
            this.TimeIncrementUpDown.Size = new System.Drawing.Size(153, 46);
            this.TimeIncrementUpDown.TabIndex = 38;
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
            this.PreviewCb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewCb.Location = new System.Drawing.Point(17, 105);
            this.PreviewCb.Name = "PreviewCb";
            this.PreviewCb.Size = new System.Drawing.Size(247, 43);
            this.PreviewCb.TabIndex = 37;
            this.PreviewCb.Text = "Show Preview";
            this.PreviewCb.UseVisualStyleBackColor = true;
            this.PreviewCb.Visible = false;
            this.PreviewCb.CheckedChanged += new System.EventHandler(this.PreviewCb_CheckedChanged);
            // 
            // FpsLbl
            // 
            this.FpsLbl.AutoSize = true;
            this.FpsLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FpsLbl.Location = new System.Drawing.Point(13, 11);
            this.FpsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FpsLbl.Name = "FpsLbl";
            this.FpsLbl.Size = new System.Drawing.Size(291, 39);
            this.FpsLbl.TabIndex = 36;
            this.FpsLbl.Text = "Frames Per Second";
            // 
            // FpsUpDown
            // 
            this.FpsUpDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FpsUpDown.Location = new System.Drawing.Point(17, 45);
            this.FpsUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.FpsUpDown.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.FpsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FpsUpDown.Name = "FpsUpDown";
            this.FpsUpDown.Size = new System.Drawing.Size(162, 46);
            this.FpsUpDown.TabIndex = 30;
            this.FpsUpDown.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.BackColor = System.Drawing.Color.MistyRose;
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
            this.DisplayPanel.TabIndex = 30;
            this.DisplayPanel.Visible = false;
            // 
            // UpArrowImg
            // 
            this.UpArrowImg.AutoSize = true;
            this.UpArrowImg.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpArrowImg.Location = new System.Drawing.Point(298, 48);
            this.UpArrowImg.Name = "UpArrowImg";
            this.UpArrowImg.Size = new System.Drawing.Size(67, 65);
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
            this.CurrentTimeLbl.Size = new System.Drawing.Size(204, 39);
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
            this.CurrentTimeUpDown.Size = new System.Drawing.Size(125, 46);
            this.CurrentTimeUpDown.TabIndex = 37;
            // 
            // ForwardBtn
            // 
            this.ForwardBtn.BackColor = System.Drawing.Color.LightCoral;
            this.ForwardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForwardBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForwardBtn.Location = new System.Drawing.Point(670, 10);
            this.ForwardBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ForwardBtn.Name = "ForwardBtn";
            this.ForwardBtn.Size = new System.Drawing.Size(200, 30);
            this.ForwardBtn.TabIndex = 19;
            this.ForwardBtn.Text = "Forward";
            this.ForwardBtn.UseVisualStyleBackColor = false;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.LightCoral;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBtn.Location = new System.Drawing.Point(460, 10);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(2);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(200, 30);
            this.BackBtn.TabIndex = 23;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = false;
            // 
            // CompileVideo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.OptionsMenu);
            this.Controls.Add(this.DrawPanel);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CompileVideo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compile Video";
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).EndInit();
            this.OptionsMenu.ResumeLayout(false);
            this.ScenesTab.ResumeLayout(false);
            this.ScenesTab.PerformLayout();
            this.VideoTab.ResumeLayout(false);
            this.VideoTab.PerformLayout();
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeIncrementUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FpsUpDown)).EndInit();
            this.DisplayPanel.ResumeLayout(false);
            this.DisplayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Future2PreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuturePreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PastPreviewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTimeUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SubmitScene;
        private System.Windows.Forms.TextBox SceneTb;
        private System.Windows.Forms.Button PlayBtn;
        private System.Windows.Forms.Timer AnimationTimer;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.PictureBox DrawPanel;
        private System.Windows.Forms.TabControl OptionsMenu;
        private System.Windows.Forms.TabPage ScenesTab;
        private System.Windows.Forms.TabPage VideoTab;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.Label FpsLbl;
        private System.Windows.Forms.NumericUpDown FpsUpDown;
        private System.Windows.Forms.Panel DisplayPanel;
        private System.Windows.Forms.Label UpArrowImg;
        private System.Windows.Forms.PictureBox Future2PreviewBox;
        private System.Windows.Forms.PictureBox FuturePreviewBox;
        private System.Windows.Forms.PictureBox PastPreviewBox;
        private System.Windows.Forms.Label CurrentTimeLbl;
        private System.Windows.Forms.NumericUpDown CurrentTimeUpDown;
        private System.Windows.Forms.Button ForwardBtn;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.CheckBox PreviewCb;
        private System.Windows.Forms.Label TimeIntervalLbl;
        private System.Windows.Forms.NumericUpDown TimeIncrementUpDown;
    }
}