namespace Optimator
{
    partial class SettingsForm
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
            this.VersionLbl = new System.Windows.Forms.Label();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.BackColourBox = new System.Windows.Forms.PictureBox();
            this.BackColourLbl = new System.Windows.Forms.Label();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.SettingsLbl = new System.Windows.Forms.Label();
            this.WorkingDirLbl = new System.Windows.Forms.Label();
            this.WorkingDirValueLbl = new System.Windows.Forms.Label();
            this.NewWorkingDirectoryBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BackColourBox)).BeginInit();
            this.SuspendLayout();
            // 
            // VersionLbl
            // 
            this.VersionLbl.AutoSize = true;
            this.VersionLbl.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLbl.Location = new System.Drawing.Point(32, 83);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new System.Drawing.Size(81, 25);
            this.VersionLbl.TabIndex = 0;
            this.VersionLbl.Text = "Version";
            // 
            // QuitBtn
            // 
            this.QuitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.QuitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitBtn.ForeColor = System.Drawing.Color.Black;
            this.QuitBtn.Location = new System.Drawing.Point(469, 539);
            this.QuitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(170, 50);
            this.QuitBtn.TabIndex = 7;
            this.QuitBtn.Text = "Quit";
            this.QuitBtn.UseVisualStyleBackColor = false;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.Black;
            this.SaveBtn.Location = new System.Drawing.Point(240, 539);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(170, 50);
            this.SaveBtn.TabIndex = 8;
            this.SaveBtn.Text = "Save Changes";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // BackColourBox
            // 
            this.BackColourBox.BackColor = System.Drawing.Color.White;
            this.BackColourBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackColourBox.Location = new System.Drawing.Point(249, 155);
            this.BackColourBox.Name = "BackColourBox";
            this.BackColourBox.Size = new System.Drawing.Size(49, 30);
            this.BackColourBox.TabIndex = 117;
            this.BackColourBox.TabStop = false;
            this.BackColourBox.Click += new System.EventHandler(this.BackColourBox_Click);
            // 
            // BackColourLbl
            // 
            this.BackColourLbl.AutoSize = true;
            this.BackColourLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackColourLbl.Location = new System.Drawing.Point(33, 159);
            this.BackColourLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BackColourLbl.Name = "BackColourLbl";
            this.BackColourLbl.Size = new System.Drawing.Size(203, 19);
            this.BackColourLbl.TabIndex = 116;
            this.BackColourLbl.Text = "Drawing Board Back Colour";
            // 
            // ResetBtn
            // 
            this.ResetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ResetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetBtn.ForeColor = System.Drawing.Color.Black;
            this.ResetBtn.Location = new System.Drawing.Point(11, 539);
            this.ResetBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(170, 50);
            this.ResetBtn.TabIndex = 118;
            this.ResetBtn.Text = "Reset to Defaults";
            this.ResetBtn.UseVisualStyleBackColor = false;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // SettingsLbl
            // 
            this.SettingsLbl.AutoSize = true;
            this.SettingsLbl.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsLbl.Location = new System.Drawing.Point(30, 30);
            this.SettingsLbl.Name = "SettingsLbl";
            this.SettingsLbl.Size = new System.Drawing.Size(148, 39);
            this.SettingsLbl.TabIndex = 119;
            this.SettingsLbl.Text = "Settings";
            // 
            // WorkingDirLbl
            // 
            this.WorkingDirLbl.AutoSize = true;
            this.WorkingDirLbl.Location = new System.Drawing.Point(33, 218);
            this.WorkingDirLbl.Name = "WorkingDirLbl";
            this.WorkingDirLbl.Size = new System.Drawing.Size(137, 19);
            this.WorkingDirLbl.TabIndex = 120;
            this.WorkingDirLbl.Text = "Working Directory";
            // 
            // WorkingDirValueLbl
            // 
            this.WorkingDirValueLbl.AutoSize = true;
            this.WorkingDirValueLbl.Location = new System.Drawing.Point(33, 252);
            this.WorkingDirValueLbl.Name = "WorkingDirValueLbl";
            this.WorkingDirValueLbl.Size = new System.Drawing.Size(131, 19);
            this.WorkingDirValueLbl.TabIndex = 121;
            this.WorkingDirValueLbl.Text = "Current Directory";
            // 
            // NewWorkingDirectoryBtn
            // 
            this.NewWorkingDirectoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.NewWorkingDirectoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewWorkingDirectoryBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewWorkingDirectoryBtn.ForeColor = System.Drawing.Color.Black;
            this.NewWorkingDirectoryBtn.Location = new System.Drawing.Point(209, 212);
            this.NewWorkingDirectoryBtn.Margin = new System.Windows.Forms.Padding(2);
            this.NewWorkingDirectoryBtn.Name = "NewWorkingDirectoryBtn";
            this.NewWorkingDirectoryBtn.Size = new System.Drawing.Size(89, 30);
            this.NewWorkingDirectoryBtn.TabIndex = 122;
            this.NewWorkingDirectoryBtn.Text = "Find New";
            this.NewWorkingDirectoryBtn.UseVisualStyleBackColor = false;
            this.NewWorkingDirectoryBtn.Click += new System.EventHandler(this.NewWorkingDirectoryBtn_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(650, 600);
            this.Controls.Add(this.NewWorkingDirectoryBtn);
            this.Controls.Add(this.WorkingDirValueLbl);
            this.Controls.Add(this.WorkingDirLbl);
            this.Controls.Add(this.SettingsLbl);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.BackColourBox);
            this.Controls.Add(this.BackColourLbl);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.VersionLbl);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.BackColourBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VersionLbl;
        private System.Windows.Forms.Button QuitBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.PictureBox BackColourBox;
        private System.Windows.Forms.Label BackColourLbl;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Label SettingsLbl;
        private System.Windows.Forms.Label WorkingDirLbl;
        private System.Windows.Forms.Label WorkingDirValueLbl;
        private System.Windows.Forms.Button NewWorkingDirectoryBtn;
    }
}