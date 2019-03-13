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
            this.CompileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(57, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Optimator";
            // 
            // SceneBtn
            // 
            this.SceneBtn.BackColor = System.Drawing.Color.Aquamarine;
            this.SceneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SceneBtn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SceneBtn.ForeColor = System.Drawing.Color.Black;
            this.SceneBtn.Location = new System.Drawing.Point(40, 181);
            this.SceneBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SceneBtn.Name = "SceneBtn";
            this.SceneBtn.Size = new System.Drawing.Size(150, 66);
            this.SceneBtn.TabIndex = 1;
            this.SceneBtn.Text = "Scenes";
            this.SceneBtn.UseVisualStyleBackColor = false;
            this.SceneBtn.Click += new System.EventHandler(this.AnimateBtn_Click);
            // 
            // SpriteBtn
            // 
            this.SpriteBtn.BackColor = System.Drawing.Color.Aquamarine;
            this.SpriteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpriteBtn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpriteBtn.ForeColor = System.Drawing.Color.Black;
            this.SpriteBtn.Location = new System.Drawing.Point(203, 181);
            this.SpriteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SpriteBtn.Name = "SpriteBtn";
            this.SpriteBtn.Size = new System.Drawing.Size(107, 66);
            this.SpriteBtn.TabIndex = 2;
            this.SpriteBtn.Text = "Sprite";
            this.SpriteBtn.UseVisualStyleBackColor = false;
            // 
            // SetsBtn
            // 
            this.SetsBtn.BackColor = System.Drawing.Color.Aquamarine;
            this.SetsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetsBtn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetsBtn.ForeColor = System.Drawing.Color.Black;
            this.SetsBtn.Location = new System.Drawing.Point(40, 267);
            this.SetsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SetsBtn.Name = "SetsBtn";
            this.SetsBtn.Size = new System.Drawing.Size(270, 66);
            this.SetsBtn.TabIndex = 3;
            this.SetsBtn.Text = "Sets";
            this.SetsBtn.UseVisualStyleBackColor = false;
            this.SetsBtn.Click += new System.EventHandler(this.SetsBtn_Click);
            // 
            // PiecesBtn
            // 
            this.PiecesBtn.BackColor = System.Drawing.Color.Aquamarine;
            this.PiecesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PiecesBtn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PiecesBtn.ForeColor = System.Drawing.Color.Black;
            this.PiecesBtn.Location = new System.Drawing.Point(40, 353);
            this.PiecesBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PiecesBtn.Name = "PiecesBtn";
            this.PiecesBtn.Size = new System.Drawing.Size(270, 66);
            this.PiecesBtn.TabIndex = 4;
            this.PiecesBtn.Text = "Pieces";
            this.PiecesBtn.UseVisualStyleBackColor = false;
            this.PiecesBtn.Click += new System.EventHandler(this.PiecesBtn_Click);
            // 
            // QuitBtn
            // 
            this.QuitBtn.BackColor = System.Drawing.Color.Aquamarine;
            this.QuitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitBtn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitBtn.ForeColor = System.Drawing.Color.Black;
            this.QuitBtn.Location = new System.Drawing.Point(40, 439);
            this.QuitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(270, 66);
            this.QuitBtn.TabIndex = 5;
            this.QuitBtn.Text = "Quit";
            this.QuitBtn.UseVisualStyleBackColor = false;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // CompileBtn
            // 
            this.CompileBtn.BackColor = System.Drawing.Color.Aquamarine;
            this.CompileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompileBtn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompileBtn.ForeColor = System.Drawing.Color.Black;
            this.CompileBtn.Location = new System.Drawing.Point(40, 95);
            this.CompileBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CompileBtn.Name = "CompileBtn";
            this.CompileBtn.Size = new System.Drawing.Size(270, 66);
            this.CompileBtn.TabIndex = 6;
            this.CompileBtn.Text = "Compile Video";
            this.CompileBtn.UseVisualStyleBackColor = false;
            this.CompileBtn.Click += new System.EventHandler(this.CompileBtn_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(350, 550);
            this.Controls.Add(this.CompileBtn);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.PiecesBtn);
            this.Controls.Add(this.SetsBtn);
            this.Controls.Add(this.SpriteBtn);
            this.Controls.Add(this.SceneBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(350, 550);
            this.MinimumSize = new System.Drawing.Size(350, 550);
            this.Name = "MenuForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button CompileBtn;
    }
}

