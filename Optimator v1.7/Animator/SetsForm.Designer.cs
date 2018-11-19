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
            this.DoneBtn = new System.Windows.Forms.Button();
            this.NameTb = new System.Windows.Forms.TextBox();
            this.AddSetBtn = new System.Windows.Forms.Button();
            this.AddTb = new System.Windows.Forms.TextBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.AddPieceBtn = new System.Windows.Forms.Button();
            this.DrawPanel = new System.Windows.Forms.PictureBox();
            this.OptionsMenu = new System.Windows.Forms.TabControl();
            this.SetPage = new System.Windows.Forms.TabPage();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.OrderLbl = new System.Windows.Forms.Label();
            this.AddPartLbl = new System.Windows.Forms.Label();
            this.FlipsUpDown = new System.Windows.Forms.NumericUpDown();
            this.FlipsCb = new System.Windows.Forms.CheckBox();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.UpBtn = new System.Windows.Forms.Button();
            this.DownBtn = new System.Windows.Forms.Button();
            this.OriginalLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).BeginInit();
            this.OptionsMenu.SuspendLayout();
            this.SetPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlipsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // DoneBtn
            // 
            this.DoneBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoneBtn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneBtn.Location = new System.Drawing.Point(206, 611);
            this.DoneBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(165, 40);
            this.DoneBtn.TabIndex = 2;
            this.DoneBtn.Text = "Done";
            this.DoneBtn.UseVisualStyleBackColor = false;
            this.DoneBtn.Click += new System.EventHandler(this.DoneBtn_Click);
            // 
            // NameTb
            // 
            this.NameTb.BackColor = System.Drawing.Color.White;
            this.NameTb.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTb.Location = new System.Drawing.Point(15, 15);
            this.NameTb.Margin = new System.Windows.Forms.Padding(2);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(178, 33);
            this.NameTb.TabIndex = 1;
            this.NameTb.Text = "Set Name";
            // 
            // AddSetBtn
            // 
            this.AddSetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AddSetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSetBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSetBtn.Location = new System.Drawing.Point(206, 138);
            this.AddSetBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddSetBtn.Name = "AddSetBtn";
            this.AddSetBtn.Size = new System.Drawing.Size(165, 40);
            this.AddSetBtn.TabIndex = 81;
            this.AddSetBtn.Text = "+ Set  ";
            this.AddSetBtn.UseVisualStyleBackColor = false;
            this.AddSetBtn.Click += new System.EventHandler(this.AddSetBtn_Click);
            // 
            // AddTb
            // 
            this.AddTb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTb.Location = new System.Drawing.Point(21, 97);
            this.AddTb.Margin = new System.Windows.Forms.Padding(2);
            this.AddTb.Name = "AddTb";
            this.AddTb.Size = new System.Drawing.Size(350, 27);
            this.AddTb.TabIndex = 69;
            this.AddTb.Text = "Item Name";
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.Location = new System.Drawing.Point(21, 192);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(350, 40);
            this.DeleteBtn.TabIndex = 30;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // AddPieceBtn
            // 
            this.AddPieceBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AddPieceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPieceBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPieceBtn.Location = new System.Drawing.Point(21, 138);
            this.AddPieceBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddPieceBtn.Name = "AddPieceBtn";
            this.AddPieceBtn.Size = new System.Drawing.Size(165, 40);
            this.AddPieceBtn.TabIndex = 26;
            this.AddPieceBtn.Text = "+ Piece";
            this.AddPieceBtn.UseVisualStyleBackColor = false;
            this.AddPieceBtn.Click += new System.EventHandler(this.AddPieceBtn_Click);
            // 
            // DrawPanel
            // 
            this.DrawPanel.BackColor = System.Drawing.Color.White;
            this.DrawPanel.Location = new System.Drawing.Point(25, 25);
            this.DrawPanel.Margin = new System.Windows.Forms.Padding(2);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(650, 650);
            this.DrawPanel.TabIndex = 2;
            this.DrawPanel.TabStop = false;
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.Controls.Add(this.SetPage);
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
            this.SetPage.Controls.Add(this.OriginalLbl);
            this.SetPage.Controls.Add(this.UpBtn);
            this.SetPage.Controls.Add(this.DownBtn);
            this.SetPage.Controls.Add(this.ExitBtn);
            this.SetPage.Controls.Add(this.OrderLbl);
            this.SetPage.Controls.Add(this.AddPartLbl);
            this.SetPage.Controls.Add(this.FlipsUpDown);
            this.SetPage.Controls.Add(this.AddTb);
            this.SetPage.Controls.Add(this.FlipsCb);
            this.SetPage.Controls.Add(this.DoneBtn);
            this.SetPage.Controls.Add(this.NameTb);
            this.SetPage.Controls.Add(this.AddPieceBtn);
            this.SetPage.Controls.Add(this.AddSetBtn);
            this.SetPage.Controls.Add(this.DeleteBtn);
            this.SetPage.Location = new System.Drawing.Point(4, 27);
            this.SetPage.Name = "SetPage";
            this.SetPage.Padding = new System.Windows.Forms.Padding(3);
            this.SetPage.Size = new System.Drawing.Size(392, 669);
            this.SetPage.TabIndex = 0;
            this.SetPage.Text = "Set";
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.Location = new System.Drawing.Point(21, 611);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(165, 40);
            this.ExitBtn.TabIndex = 93;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // OrderLbl
            // 
            this.OrderLbl.AutoSize = true;
            this.OrderLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderLbl.Location = new System.Drawing.Point(15, 434);
            this.OrderLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OrderLbl.Name = "OrderLbl";
            this.OrderLbl.Size = new System.Drawing.Size(58, 23);
            this.OrderLbl.TabIndex = 92;
            this.OrderLbl.Text = "Order";
            // 
            // AddPartLbl
            // 
            this.AddPartLbl.AutoSize = true;
            this.AddPartLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPartLbl.Location = new System.Drawing.Point(15, 61);
            this.AddPartLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddPartLbl.Name = "AddPartLbl";
            this.AddPartLbl.Size = new System.Drawing.Size(82, 23);
            this.AddPartLbl.TabIndex = 91;
            this.AddPartLbl.Text = "Add Part";
            // 
            // FlipsUpDown
            // 
            this.FlipsUpDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlipsUpDown.Location = new System.Drawing.Point(133, 533);
            this.FlipsUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.FlipsUpDown.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.FlipsUpDown.Name = "FlipsUpDown";
            this.FlipsUpDown.Size = new System.Drawing.Size(60, 27);
            this.FlipsUpDown.TabIndex = 89;
            // 
            // FlipsCb
            // 
            this.FlipsCb.AutoSize = true;
            this.FlipsCb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlipsCb.Location = new System.Drawing.Point(21, 534);
            this.FlipsCb.Margin = new System.Windows.Forms.Padding(2);
            this.FlipsCb.Name = "FlipsCb";
            this.FlipsCb.Size = new System.Drawing.Size(68, 23);
            this.FlipsCb.TabIndex = 88;
            this.FlipsCb.Text = "Flips?";
            this.FlipsCb.UseVisualStyleBackColor = true;
            // 
            // SettingsPage
            // 
            this.SettingsPage.BackColor = System.Drawing.Color.Honeydew;
            this.SettingsPage.Location = new System.Drawing.Point(4, 27);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsPage.Size = new System.Drawing.Size(392, 669);
            this.SettingsPage.TabIndex = 1;
            this.SettingsPage.Text = "Settings";
            // 
            // UpBtn
            // 
            this.UpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.UpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpBtn.Location = new System.Drawing.Point(21, 472);
            this.UpBtn.Margin = new System.Windows.Forms.Padding(2);
            this.UpBtn.Name = "UpBtn";
            this.UpBtn.Size = new System.Drawing.Size(165, 40);
            this.UpBtn.TabIndex = 94;
            this.UpBtn.Text = "Move Up";
            this.UpBtn.UseVisualStyleBackColor = false;
            // 
            // DownBtn
            // 
            this.DownBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownBtn.Location = new System.Drawing.Point(206, 472);
            this.DownBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DownBtn.Name = "DownBtn";
            this.DownBtn.Size = new System.Drawing.Size(165, 40);
            this.DownBtn.TabIndex = 95;
            this.DownBtn.Text = "Move Down";
            this.DownBtn.UseVisualStyleBackColor = false;
            // 
            // OriginalLbl
            // 
            this.OriginalLbl.AutoSize = true;
            this.OriginalLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginalLbl.Location = new System.Drawing.Point(15, 258);
            this.OriginalLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OriginalLbl.Name = "OriginalLbl";
            this.OriginalLbl.Size = new System.Drawing.Size(151, 23);
            this.OriginalLbl.TabIndex = 96;
            this.OriginalLbl.Text = "Original Positions";
            // 
            // SetsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.OptionsMenu);
            this.Controls.Add(this.DrawPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SetsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetsForm";
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).EndInit();
            this.OptionsMenu.ResumeLayout(false);
            this.SetPage.ResumeLayout(false);
            this.SetPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlipsUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.Button DoneBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button AddPieceBtn;
        private System.Windows.Forms.TextBox AddTb;
        private System.Windows.Forms.Button AddSetBtn;
        private System.Windows.Forms.PictureBox DrawPanel;
        private System.Windows.Forms.TabControl OptionsMenu;
        private System.Windows.Forms.TabPage SetPage;
        private System.Windows.Forms.TabPage SettingsPage;
        private System.Windows.Forms.Label AddPartLbl;
        private System.Windows.Forms.NumericUpDown FlipsUpDown;
        private System.Windows.Forms.CheckBox FlipsCb;
        private System.Windows.Forms.Label OrderLbl;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button UpBtn;
        private System.Windows.Forms.Button DownBtn;
        private System.Windows.Forms.Label OriginalLbl;
    }
}