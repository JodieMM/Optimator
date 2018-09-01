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
            this.playBtn = new System.Windows.Forms.Button();
            this.submitScene = new System.Windows.Forms.Button();
            this.sceneTb = new System.Windows.Forms.TextBox();
            this.DrawPanel = new System.Windows.Forms.Panel();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.saveLocationTb = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.insertPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // insertPanel
            // 
            this.insertPanel.Controls.Add(this.saveBtn);
            this.insertPanel.Controls.Add(this.saveLocationTb);
            this.insertPanel.Controls.Add(this.playBtn);
            this.insertPanel.Controls.Add(this.submitScene);
            this.insertPanel.Controls.Add(this.sceneTb);
            this.insertPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.insertPanel.Location = new System.Drawing.Point(1647, 0);
            this.insertPanel.Name = "insertPanel";
            this.insertPanel.Size = new System.Drawing.Size(273, 1241);
            this.insertPanel.TabIndex = 0;
            // 
            // playBtn
            // 
            this.playBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.Location = new System.Drawing.Point(35, 587);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(202, 66);
            this.playBtn.TabIndex = 2;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // submitScene
            // 
            this.submitScene.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitScene.Location = new System.Drawing.Point(30, 151);
            this.submitScene.Name = "submitScene";
            this.submitScene.Size = new System.Drawing.Size(202, 66);
            this.submitScene.TabIndex = 1;
            this.submitScene.Text = "Get Scene";
            this.submitScene.UseVisualStyleBackColor = true;
            this.submitScene.Click += new System.EventHandler(this.submitScene_Click);
            // 
            // sceneTb
            // 
            this.sceneTb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sceneTb.Location = new System.Drawing.Point(30, 59);
            this.sceneTb.Name = "sceneTb";
            this.sceneTb.Size = new System.Drawing.Size(202, 47);
            this.sceneTb.TabIndex = 0;
            // 
            // DrawPanel
            // 
            this.DrawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawPanel.Location = new System.Drawing.Point(0, 0);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(1647, 1241);
            this.DrawPanel.TabIndex = 1;
            // 
            // animationTimer
            // 
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // saveLocationTb
            // 
            this.saveLocationTb.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveLocationTb.Location = new System.Drawing.Point(30, 743);
            this.saveLocationTb.Name = "saveLocationTb";
            this.saveLocationTb.Size = new System.Drawing.Size(202, 47);
            this.saveLocationTb.TabIndex = 3;
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(30, 826);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(202, 66);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel insertPanel;
        private System.Windows.Forms.Button submitScene;
        private System.Windows.Forms.TextBox sceneTb;
        private System.Windows.Forms.Panel DrawPanel;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox saveLocationTb;
    }
}