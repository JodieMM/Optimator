namespace Animator
{
    partial class PreviewForm
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
            this.DrawBoard = new System.Windows.Forms.PictureBox();
            this.OptionsMenu = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.RotationTrack = new System.Windows.Forms.TrackBar();
            this.TurnTrack = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawBoard)).BeginInit();
            this.OptionsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawBoard
            // 
            this.DrawBoard.BackColor = System.Drawing.Color.White;
            this.DrawBoard.Location = new System.Drawing.Point(25, 25);
            this.DrawBoard.Name = "DrawBoard";
            this.DrawBoard.Size = new System.Drawing.Size(650, 650);
            this.DrawBoard.TabIndex = 0;
            this.DrawBoard.TabStop = false;
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.BackColor = System.Drawing.Color.Honeydew;
            this.OptionsMenu.Controls.Add(this.CloseBtn);
            this.OptionsMenu.Location = new System.Drawing.Point(700, 0);
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(200, 700);
            this.OptionsMenu.TabIndex = 1;
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.PaleGreen;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.Location = new System.Drawing.Point(15, 635);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(170, 50);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // RotationTrack
            // 
            this.RotationTrack.BackColor = System.Drawing.Color.White;
            this.RotationTrack.Cursor = System.Windows.Forms.Cursors.Default;
            this.RotationTrack.Location = new System.Drawing.Point(80, 625);
            this.RotationTrack.Maximum = 359;
            this.RotationTrack.Name = "RotationTrack";
            this.RotationTrack.Size = new System.Drawing.Size(540, 45);
            this.RotationTrack.TabIndex = 2;
            this.RotationTrack.TickFrequency = 10;
            this.RotationTrack.Scroll += new System.EventHandler(this.RotationTrack_Scroll);
            // 
            // TurnTrack
            // 
            this.TurnTrack.BackColor = System.Drawing.Color.White;
            this.TurnTrack.Cursor = System.Windows.Forms.Cursors.Default;
            this.TurnTrack.Location = new System.Drawing.Point(625, 80);
            this.TurnTrack.Maximum = 359;
            this.TurnTrack.Name = "TurnTrack";
            this.TurnTrack.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TurnTrack.Size = new System.Drawing.Size(45, 540);
            this.TurnTrack.TabIndex = 3;
            this.TurnTrack.TickFrequency = 10;
            this.TurnTrack.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TurnTrack.Scroll += new System.EventHandler(this.TurnTrack_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "0";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(169, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 37);
            this.button2.TabIndex = 5;
            this.button2.Text = "90";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(298, 47);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 37);
            this.button3.TabIndex = 6;
            this.button3.Text = "180";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(427, 47);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(57, 37);
            this.button4.TabIndex = 7;
            this.button4.Text = "270";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(427, 108);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(57, 37);
            this.button5.TabIndex = 11;
            this.button5.Text = "270";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(298, 108);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(57, 37);
            this.button6.TabIndex = 10;
            this.button6.Text = "180";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(169, 108);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(57, 37);
            this.button7.TabIndex = 9;
            this.button7.Text = "90";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(46, 108);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(57, 37);
            this.button8.TabIndex = 8;
            this.button8.Text = "0";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // PreviewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TurnTrack);
            this.Controls.Add(this.RotationTrack);
            this.Controls.Add(this.OptionsMenu);
            this.Controls.Add(this.DrawBoard);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PreviewForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview";
            this.Shown += new System.EventHandler(this.PiecesPreviewForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DrawBoard)).EndInit();
            this.OptionsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawBoard;
        private System.Windows.Forms.Panel OptionsMenu;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.TrackBar RotationTrack;
        private System.Windows.Forms.TrackBar TurnTrack;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}