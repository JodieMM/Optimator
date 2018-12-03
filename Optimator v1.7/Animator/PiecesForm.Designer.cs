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
            this.NameTb = new System.Windows.Forms.TextBox();
            this.SetsTab = new System.Windows.Forms.TabPage();
            this.AddPointBtn = new System.Windows.Forms.Button();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.DrawDown = new System.Windows.Forms.PictureBox();
            this.DrawRight = new System.Windows.Forms.PictureBox();
            this.PointBtn = new System.Windows.Forms.Button();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.EraserBtn = new System.Windows.Forms.Button();
            this.CompleteBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.TestingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawBase)).BeginInit();
            this.OptionsMenu.SuspendLayout();
            this.ShapeTab.SuspendLayout();
            this.SetsTab.SuspendLayout();
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
            this.ShapeTab.Controls.Add(this.NameTb);
            this.ShapeTab.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShapeTab.Location = new System.Drawing.Point(4, 27);
            this.ShapeTab.Margin = new System.Windows.Forms.Padding(6);
            this.ShapeTab.Name = "ShapeTab";
            this.ShapeTab.Padding = new System.Windows.Forms.Padding(6);
            this.ShapeTab.Size = new System.Drawing.Size(392, 669);
            this.ShapeTab.TabIndex = 0;
            this.ShapeTab.Text = "Shape";
            // 
            // NameTb
            // 
            this.NameTb.BackColor = System.Drawing.Color.White;
            this.NameTb.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTb.Location = new System.Drawing.Point(15, 15);
            this.NameTb.Margin = new System.Windows.Forms.Padding(6);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(300, 33);
            this.NameTb.TabIndex = 5;
            this.NameTb.Text = "Piece Name";
            // 
            // SetsTab
            // 
            this.SetsTab.BackColor = System.Drawing.Color.Azure;
            this.SetsTab.Controls.Add(this.AddPointBtn);
            this.SetsTab.Location = new System.Drawing.Point(4, 27);
            this.SetsTab.Name = "SetsTab";
            this.SetsTab.Size = new System.Drawing.Size(392, 669);
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
            this.SettingsTab.Location = new System.Drawing.Point(4, 27);
            this.SettingsTab.Margin = new System.Windows.Forms.Padding(6);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(6);
            this.SettingsTab.Size = new System.Drawing.Size(392, 669);
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "Settings";
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
            // EraserBtn
            // 
            this.EraserBtn.BackColor = System.Drawing.Color.LightCyan;
            this.EraserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EraserBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EraserBtn.Location = new System.Drawing.Point(465, 360);
            this.EraserBtn.Margin = new System.Windows.Forms.Padding(6);
            this.EraserBtn.Name = "EraserBtn";
            this.EraserBtn.Size = new System.Drawing.Size(90, 90);
            this.EraserBtn.TabIndex = 8;
            this.EraserBtn.Text = "Eraser";
            this.EraserBtn.UseVisualStyleBackColor = false;
            this.EraserBtn.Click += new System.EventHandler(this.EraserBtn_Click);
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
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightCyan;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(465, 465);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 90);
            this.button2.TabIndex = 12;
            this.button2.Text = "TBD";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
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
            // TestingButton
            // 
            this.TestingButton.BackColor = System.Drawing.Color.LightCyan;
            this.TestingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestingButton.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestingButton.Location = new System.Drawing.Point(360, 465);
            this.TestingButton.Margin = new System.Windows.Forms.Padding(6);
            this.TestingButton.Name = "TestingButton";
            this.TestingButton.Size = new System.Drawing.Size(90, 90);
            this.TestingButton.TabIndex = 10;
            this.TestingButton.Text = "Testing";
            this.TestingButton.UseVisualStyleBackColor = false;
            this.TestingButton.Visible = false;
            // 
            // PiecesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.TestingButton);
            this.Controls.Add(this.CompleteBtn);
            this.Controls.Add(this.EraserBtn);
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
            this.SetsTab.ResumeLayout(false);
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
        private System.Windows.Forms.Button EraserBtn;
        private System.Windows.Forms.Button CompleteBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button TestingButton;
        private System.Windows.Forms.TabPage SetsTab;
        private System.Windows.Forms.Button AddPointBtn;
    }
}