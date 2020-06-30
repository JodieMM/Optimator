namespace Optimator
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.NewTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.NewPieceTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.NewSetTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.NewSceneTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.NewVideoTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.NewSpriteSheetTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.HotTrack = true;
            this.TabControl.Location = new System.Drawing.Point(0, 42);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1174, 687);
            this.TabControl.TabIndex = 0;
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewTSMI,
            this.OpenTSMI,
            this.SettingsTSMI,
            this.HelpTSMI});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1174, 42);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // NewTSMI
            // 
            this.NewTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewPieceTSMI,
            this.NewSetTSMI,
            this.NewSceneTSMI,
            this.NewVideoTSMI,
            this.NewSpriteSheetTSMI});
            this.NewTSMI.Name = "NewTSMI";
            this.NewTSMI.Size = new System.Drawing.Size(75, 38);
            this.NewTSMI.Text = "New";
            // 
            // NewPieceTSMI
            // 
            this.NewPieceTSMI.Name = "NewPieceTSMI";
            this.NewPieceTSMI.Size = new System.Drawing.Size(324, 38);
            this.NewPieceTSMI.Text = "Piece";
            this.NewPieceTSMI.Click += new System.EventHandler(this.NewPieceTSMI_Click);
            // 
            // NewSetTSMI
            // 
            this.NewSetTSMI.Name = "NewSetTSMI";
            this.NewSetTSMI.Size = new System.Drawing.Size(324, 38);
            this.NewSetTSMI.Text = "Set";
            this.NewSetTSMI.Click += new System.EventHandler(this.NewSetTSMI_Click);
            // 
            // NewSceneTSMI
            // 
            this.NewSceneTSMI.Name = "NewSceneTSMI";
            this.NewSceneTSMI.Size = new System.Drawing.Size(324, 38);
            this.NewSceneTSMI.Text = "Scene";
            this.NewSceneTSMI.Click += new System.EventHandler(this.NewSceneTSMI_Click);
            // 
            // NewVideoTSMI
            // 
            this.NewVideoTSMI.Name = "NewVideoTSMI";
            this.NewVideoTSMI.Size = new System.Drawing.Size(324, 38);
            this.NewVideoTSMI.Text = "Video";
            this.NewVideoTSMI.Click += new System.EventHandler(this.NewVideoTSMI_Click);
            // 
            // NewSpriteSheetTSMI
            // 
            this.NewSpriteSheetTSMI.Name = "NewSpriteSheetTSMI";
            this.NewSpriteSheetTSMI.Size = new System.Drawing.Size(324, 38);
            this.NewSpriteSheetTSMI.Text = "Sprite Set";
            this.NewSpriteSheetTSMI.Click += new System.EventHandler(this.NewSpriteSheetTSMI_Click);
            // 
            // OpenTSMI
            // 
            this.OpenTSMI.Name = "OpenTSMI";
            this.OpenTSMI.Size = new System.Drawing.Size(86, 38);
            this.OpenTSMI.Text = "Open";
            this.OpenTSMI.Click += new System.EventHandler(this.OpenTSMI_Click);
            // 
            // SettingsTSMI
            // 
            this.SettingsTSMI.Name = "SettingsTSMI";
            this.SettingsTSMI.Size = new System.Drawing.Size(113, 38);
            this.SettingsTSMI.Text = "Settings";
            this.SettingsTSMI.Click += new System.EventHandler(this.SettingsTSMI_Click);
            // 
            // HelpTSMI
            // 
            this.HelpTSMI.Name = "HelpTSMI";
            this.HelpTSMI.Size = new System.Drawing.Size(77, 38);
            this.HelpTSMI.Text = "Help";
            this.HelpTSMI.Click += new System.EventHandler(this.HelpTSMI_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1174, 729);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.MenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(650, 450);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Optimator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem NewTSMI;
        private System.Windows.Forms.ToolStripMenuItem NewPieceTSMI;
        private System.Windows.Forms.ToolStripMenuItem NewSetTSMI;
        private System.Windows.Forms.ToolStripMenuItem NewSceneTSMI;
        private System.Windows.Forms.ToolStripMenuItem NewVideoTSMI;
        private System.Windows.Forms.ToolStripMenuItem NewSpriteSheetTSMI;
        private System.Windows.Forms.ToolStripMenuItem OpenTSMI;
        private System.Windows.Forms.ToolStripMenuItem HelpTSMI;
        private System.Windows.Forms.ToolStripMenuItem SettingsTSMI;
    }
}