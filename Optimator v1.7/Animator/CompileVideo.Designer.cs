namespace Animator
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
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).BeginInit();
            this.OptionsMenu.SuspendLayout();
            this.ScenesTab.SuspendLayout();
            this.VideoTab.SuspendLayout();
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
            this.PlayBtn.Location = new System.Drawing.Point(10, 201);
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
            this.SceneTb.Size = new System.Drawing.Size(182, 30);
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
            this.ScenesTab.Location = new System.Drawing.Point(4, 27);
            this.ScenesTab.Name = "ScenesTab";
            this.ScenesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ScenesTab.Size = new System.Drawing.Size(202, 669);
            this.ScenesTab.TabIndex = 0;
            this.ScenesTab.Text = "Scenes";
            // 
            // VideoTab
            // 
            this.VideoTab.BackColor = System.Drawing.Color.MistyRose;
            this.VideoTab.Controls.Add(this.SaveBtn);
            this.VideoTab.Controls.Add(this.ExitBtn);
            this.VideoTab.Controls.Add(this.NameTb);
            this.VideoTab.Location = new System.Drawing.Point(4, 27);
            this.VideoTab.Name = "VideoTab";
            this.VideoTab.Padding = new System.Windows.Forms.Padding(3);
            this.VideoTab.Size = new System.Drawing.Size(202, 669);
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
            this.NameTb.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTb.Location = new System.Drawing.Point(10, 10);
            this.NameTb.Margin = new System.Windows.Forms.Padding(6);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(182, 33);
            this.NameTb.TabIndex = 25;
            this.NameTb.Text = "Video Name";
            // 
            // SettingsTab
            // 
            this.SettingsTab.BackColor = System.Drawing.Color.MistyRose;
            this.SettingsTab.Location = new System.Drawing.Point(4, 27);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Size = new System.Drawing.Size(202, 669);
            this.SettingsTab.TabIndex = 2;
            this.SettingsTab.Text = "Settings";
            // 
            // CompileVideo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(1100, 700);
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
    }
}