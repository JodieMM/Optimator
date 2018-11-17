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
            this.insertPanel = new System.Windows.Forms.Panel();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.saveLocationTb = new System.Windows.Forms.TextBox();
            this.PlayBtn = new System.Windows.Forms.Button();
            this.SubmitScene = new System.Windows.Forms.Button();
            this.sceneTb = new System.Windows.Forms.TextBox();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.DrawPanel = new System.Windows.Forms.PictureBox();
            this.insertPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // insertPanel
            // 
            this.insertPanel.Controls.Add(this.SaveBtn);
            this.insertPanel.Controls.Add(this.saveLocationTb);
            this.insertPanel.Controls.Add(this.PlayBtn);
            this.insertPanel.Controls.Add(this.SubmitScene);
            this.insertPanel.Controls.Add(this.sceneTb);
            this.insertPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.insertPanel.Location = new System.Drawing.Point(1647, 0);
            this.insertPanel.Name = "insertPanel";
            this.insertPanel.Size = new System.Drawing.Size(273, 1241);
            this.insertPanel.TabIndex = 0;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.Location = new System.Drawing.Point(30, 826);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(202, 66);
            this.SaveBtn.TabIndex = 4;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // saveLocationTb
            // 
            this.saveLocationTb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveLocationTb.Location = new System.Drawing.Point(30, 743);
            this.saveLocationTb.Name = "saveLocationTb";
            this.saveLocationTb.Size = new System.Drawing.Size(202, 47);
            this.saveLocationTb.TabIndex = 3;
            // 
            // PlayBtn
            // 
            this.PlayBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayBtn.Location = new System.Drawing.Point(35, 587);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(202, 66);
            this.PlayBtn.TabIndex = 2;
            this.PlayBtn.Text = "Play";
            this.PlayBtn.UseVisualStyleBackColor = true;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // SubmitScene
            // 
            this.SubmitScene.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitScene.Location = new System.Drawing.Point(30, 151);
            this.SubmitScene.Name = "SubmitScene";
            this.SubmitScene.Size = new System.Drawing.Size(202, 66);
            this.SubmitScene.TabIndex = 1;
            this.SubmitScene.Text = "Get Scene";
            this.SubmitScene.UseVisualStyleBackColor = true;
            this.SubmitScene.Click += new System.EventHandler(this.SubmitScene_Click);
            // 
            // sceneTb
            // 
            this.sceneTb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sceneTb.Location = new System.Drawing.Point(30, 59);
            this.sceneTb.Name = "sceneTb";
            this.sceneTb.Size = new System.Drawing.Size(202, 47);
            this.sceneTb.TabIndex = 0;
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // DrawPanel
            // 
            this.DrawPanel.Location = new System.Drawing.Point(0, 0);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(1647, 1241);
            this.DrawPanel.TabIndex = 1;
            this.DrawPanel.TabStop = false;
            // 
            // CompileVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1241);
            this.Controls.Add(this.DrawPanel);
            this.Controls.Add(this.insertPanel);
            this.Name = "CompileVideo";
            this.ShowIcon = false;
            this.Text = "Compile Video";
            this.insertPanel.ResumeLayout(false);
            this.insertPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel insertPanel;
        private System.Windows.Forms.Button SubmitScene;
        private System.Windows.Forms.TextBox sceneTb;
        private System.Windows.Forms.Button PlayBtn;
        private System.Windows.Forms.Timer AnimationTimer;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TextBox saveLocationTb;
        private System.Windows.Forms.PictureBox DrawPanel;
    }
}