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
            this.spriteSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenPieceTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSetTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSceneTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenVideoTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.spriteSetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.HotTrack = true;
            this.TabControl.Location = new System.Drawing.Point(0, 40);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1174, 689);
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
            this.MenuStrip.Size = new System.Drawing.Size(1174, 40);
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
            this.spriteSetToolStripMenuItem});
            this.NewTSMI.Name = "NewTSMI";
            this.NewTSMI.Size = new System.Drawing.Size(75, 36);
            this.NewTSMI.Text = "New";
            // 
            // NewPieceTSMI
            // 
            this.NewPieceTSMI.Name = "NewPieceTSMI";
            this.NewPieceTSMI.Size = new System.Drawing.Size(217, 38);
            this.NewPieceTSMI.Text = "Piece";
            this.NewPieceTSMI.Click += new System.EventHandler(this.NewPieceTSMI_Click);
            // 
            // NewSetTSMI
            // 
            this.NewSetTSMI.Name = "NewSetTSMI";
            this.NewSetTSMI.Size = new System.Drawing.Size(217, 38);
            this.NewSetTSMI.Text = "Set";
            this.NewSetTSMI.Click += new System.EventHandler(this.NewSetTSMI_Click);
            // 
            // NewSceneTSMI
            // 
            this.NewSceneTSMI.Name = "NewSceneTSMI";
            this.NewSceneTSMI.Size = new System.Drawing.Size(217, 38);
            this.NewSceneTSMI.Text = "Scene";
            this.NewSceneTSMI.Click += new System.EventHandler(this.NewSceneTSMI_Click);
            // 
            // NewVideoTSMI
            // 
            this.NewVideoTSMI.Name = "NewVideoTSMI";
            this.NewVideoTSMI.Size = new System.Drawing.Size(217, 38);
            this.NewVideoTSMI.Text = "Video";
            this.NewVideoTSMI.Click += new System.EventHandler(this.NewVideoTSMI_Click);
            // 
            // spriteSetToolStripMenuItem
            // 
            this.spriteSetToolStripMenuItem.Name = "spriteSetToolStripMenuItem";
            this.spriteSetToolStripMenuItem.Size = new System.Drawing.Size(217, 38);
            this.spriteSetToolStripMenuItem.Text = "Sprite Set";
            // 
            // OpenTSMI
            // 
            this.OpenTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenPieceTSMI,
            this.OpenSetTSMI,
            this.OpenSceneTSMI,
            this.OpenVideoTSMI,
            this.spriteSetToolStripMenuItem1});
            this.OpenTSMI.Name = "OpenTSMI";
            this.OpenTSMI.Size = new System.Drawing.Size(86, 36);
            this.OpenTSMI.Text = "Open";
            // 
            // OpenPieceTSMI
            // 
            this.OpenPieceTSMI.Name = "OpenPieceTSMI";
            this.OpenPieceTSMI.Size = new System.Drawing.Size(217, 38);
            this.OpenPieceTSMI.Text = "Piece";
            this.OpenPieceTSMI.Click += new System.EventHandler(this.OpenPieceTSMI_Click);
            // 
            // OpenSetTSMI
            // 
            this.OpenSetTSMI.Name = "OpenSetTSMI";
            this.OpenSetTSMI.Size = new System.Drawing.Size(217, 38);
            this.OpenSetTSMI.Text = "Set";
            this.OpenSetTSMI.Click += new System.EventHandler(this.OpenSetTSMI_Click);
            // 
            // OpenSceneTSMI
            // 
            this.OpenSceneTSMI.Name = "OpenSceneTSMI";
            this.OpenSceneTSMI.Size = new System.Drawing.Size(217, 38);
            this.OpenSceneTSMI.Text = "Scene";
            this.OpenSceneTSMI.Click += new System.EventHandler(this.OpenSceneTSMI_Click);
            // 
            // OpenVideoTSMI
            // 
            this.OpenVideoTSMI.Name = "OpenVideoTSMI";
            this.OpenVideoTSMI.Size = new System.Drawing.Size(217, 38);
            this.OpenVideoTSMI.Text = "Video";
            this.OpenVideoTSMI.Click += new System.EventHandler(this.OpenVideoTSMI_Click);
            // 
            // spriteSetToolStripMenuItem1
            // 
            this.spriteSetToolStripMenuItem1.Name = "spriteSetToolStripMenuItem1";
            this.spriteSetToolStripMenuItem1.Size = new System.Drawing.Size(217, 38);
            this.spriteSetToolStripMenuItem1.Text = "Sprite Set";
            // 
            // SettingsTSMI
            // 
            this.SettingsTSMI.Name = "SettingsTSMI";
            this.SettingsTSMI.Size = new System.Drawing.Size(113, 36);
            this.SettingsTSMI.Text = "Settings";
            this.SettingsTSMI.Click += new System.EventHandler(this.SettingsTSMI_Click);
            // 
            // HelpTSMI
            // 
            this.HelpTSMI.Name = "HelpTSMI";
            this.HelpTSMI.Size = new System.Drawing.Size(77, 36);
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
        private System.Windows.Forms.ToolStripMenuItem spriteSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenTSMI;
        private System.Windows.Forms.ToolStripMenuItem OpenPieceTSMI;
        private System.Windows.Forms.ToolStripMenuItem OpenSetTSMI;
        private System.Windows.Forms.ToolStripMenuItem OpenSceneTSMI;
        private System.Windows.Forms.ToolStripMenuItem OpenVideoTSMI;
        private System.Windows.Forms.ToolStripMenuItem spriteSetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem HelpTSMI;
        private System.Windows.Forms.ToolStripMenuItem SettingsTSMI;
    }
}