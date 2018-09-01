namespace Animator
{
    partial class MenuForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.SceneBtn = new System.Windows.Forms.Button();
            this.SpriteBtn = new System.Windows.Forms.Button();
            this.SetsBtn = new System.Windows.Forms.Button();
            this.PiecesBtn = new System.Windows.Forms.Button();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.animateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Light", 25.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 74);
            this.label1.TabIndex = 0;
            this.label1.Text = "Optimator";
            // 
            // SceneBtn
            // 
            this.SceneBtn.BackColor = System.Drawing.Color.SlateBlue;
            this.SceneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SceneBtn.Font = new System.Drawing.Font("Copperplate Gothic Light", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SceneBtn.Location = new System.Drawing.Point(115, 310);
            this.SceneBtn.Name = "SceneBtn";
            this.SceneBtn.Size = new System.Drawing.Size(299, 127);
            this.SceneBtn.TabIndex = 1;
            this.SceneBtn.Text = "Scenes";
            this.SceneBtn.UseVisualStyleBackColor = false;
            this.SceneBtn.Click += new System.EventHandler(this.AnimateBtn_Click);
            // 
            // SpriteBtn
            // 
            this.SpriteBtn.BackColor = System.Drawing.Color.SlateBlue;
            this.SpriteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpriteBtn.Font = new System.Drawing.Font("Copperplate Gothic Light", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpriteBtn.Location = new System.Drawing.Point(442, 310);
            this.SpriteBtn.Name = "SpriteBtn";
            this.SpriteBtn.Size = new System.Drawing.Size(214, 127);
            this.SpriteBtn.TabIndex = 2;
            this.SpriteBtn.Text = "Sprite";
            this.SpriteBtn.UseVisualStyleBackColor = false;
            // 
            // SetsBtn
            // 
            this.SetsBtn.BackColor = System.Drawing.Color.SlateBlue;
            this.SetsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetsBtn.Font = new System.Drawing.Font("Copperplate Gothic Light", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetsBtn.Location = new System.Drawing.Point(115, 470);
            this.SetsBtn.Name = "SetsBtn";
            this.SetsBtn.Size = new System.Drawing.Size(541, 127);
            this.SetsBtn.TabIndex = 3;
            this.SetsBtn.Text = "Sets";
            this.SetsBtn.UseVisualStyleBackColor = false;
            this.SetsBtn.Click += new System.EventHandler(this.SetsBtn_Click);
            // 
            // PiecesBtn
            // 
            this.PiecesBtn.BackColor = System.Drawing.Color.SlateBlue;
            this.PiecesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PiecesBtn.Font = new System.Drawing.Font("Copperplate Gothic Light", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PiecesBtn.Location = new System.Drawing.Point(115, 630);
            this.PiecesBtn.Name = "PiecesBtn";
            this.PiecesBtn.Size = new System.Drawing.Size(541, 127);
            this.PiecesBtn.TabIndex = 4;
            this.PiecesBtn.Text = "Pieces";
            this.PiecesBtn.UseVisualStyleBackColor = false;
            this.PiecesBtn.Click += new System.EventHandler(this.PiecesBtn_Click);
            // 
            // QuitBtn
            // 
            this.QuitBtn.BackColor = System.Drawing.Color.SlateBlue;
            this.QuitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitBtn.Font = new System.Drawing.Font("Copperplate Gothic Light", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitBtn.Location = new System.Drawing.Point(115, 790);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(541, 127);
            this.QuitBtn.TabIndex = 5;
            this.QuitBtn.Text = "Quit";
            this.QuitBtn.UseVisualStyleBackColor = false;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // animateBtn
            // 
            this.animateBtn.BackColor = System.Drawing.Color.SlateBlue;
            this.animateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.animateBtn.Font = new System.Drawing.Font("Copperplate Gothic Light", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animateBtn.Location = new System.Drawing.Point(115, 150);
            this.animateBtn.Name = "animateBtn";
            this.animateBtn.Size = new System.Drawing.Size(541, 127);
            this.animateBtn.TabIndex = 6;
            this.animateBtn.Text = "Compile Video";
            this.animateBtn.UseVisualStyleBackColor = false;
            this.animateBtn.Click += new System.EventHandler(this.animateBtn_Click_1);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(759, 1010);
            this.Controls.Add(this.animateBtn);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.PiecesBtn);
            this.Controls.Add(this.SetsBtn);
            this.Controls.Add(this.SpriteBtn);
            this.Controls.Add(this.SceneBtn);
            this.Controls.Add(this.label1);
            this.Name = "MenuForm";
            this.ShowIcon = false;
            this.Text = "Optimator V1.4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SceneBtn;
        private System.Windows.Forms.Button SpriteBtn;
        private System.Windows.Forms.Button SetsBtn;
        private System.Windows.Forms.Button PiecesBtn;
        private System.Windows.Forms.Button QuitBtn;
        private System.Windows.Forms.Button animateBtn;
    }
}

