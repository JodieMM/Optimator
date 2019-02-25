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
            this.DrawPanel = new System.Windows.Forms.PictureBox();
            this.OptionsMenu = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.RotationTrack = new System.Windows.Forms.TrackBar();
            this.TurnTrack = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).BeginInit();
            this.OptionsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawBoard
            // 
            this.DrawPanel.BackColor = System.Drawing.Color.White;
            this.DrawPanel.Location = new System.Drawing.Point(25, 25);
            this.DrawPanel.Name = "DrawBoard";
            this.DrawPanel.Size = new System.Drawing.Size(650, 650);
            this.DrawPanel.TabIndex = 0;
            this.DrawPanel.TabStop = false;
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.BackColor = System.Drawing.Color.GhostWhite;
            this.OptionsMenu.Controls.Add(this.CloseBtn);
            this.OptionsMenu.Location = new System.Drawing.Point(700, 0);
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(200, 700);
            this.OptionsMenu.TabIndex = 1;
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.MediumPurple;
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
            // PreviewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.TurnTrack);
            this.Controls.Add(this.RotationTrack);
            this.Controls.Add(this.OptionsMenu);
            this.Controls.Add(this.DrawPanel);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PreviewForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview";
            this.Shown += new System.EventHandler(this.PiecesPreviewForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).EndInit();
            this.OptionsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RotationTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawPanel;
        private System.Windows.Forms.Panel OptionsMenu;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.TrackBar RotationTrack;
        private System.Windows.Forms.TrackBar TurnTrack;
    }
}