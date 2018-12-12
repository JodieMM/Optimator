namespace Animator
{
    partial class LoadingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
            this.PatienceLbl = new System.Windows.Forms.Label();
            this.LoadingLbl = new System.Windows.Forms.Label();
            this.ImgBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PatienceLbl
            // 
            this.PatienceLbl.Location = new System.Drawing.Point(20, 177);
            this.PatienceLbl.Name = "PatienceLbl";
            this.PatienceLbl.Size = new System.Drawing.Size(225, 52);
            this.PatienceLbl.TabIndex = 0;
            this.PatienceLbl.Text = "Please be patient, this shouldn\'t take long...";
            this.PatienceLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LoadingLbl
            // 
            this.LoadingLbl.AutoSize = true;
            this.LoadingLbl.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadingLbl.Location = new System.Drawing.Point(13, 17);
            this.LoadingLbl.Name = "LoadingLbl";
            this.LoadingLbl.Size = new System.Drawing.Size(239, 25);
            this.LoadingLbl.TabIndex = 1;
            this.LoadingLbl.Text = "Optimator is Loading!";
            // 
            // ImgBox
            // 
            this.ImgBox.Image = ((System.Drawing.Image)(resources.GetObject("ImgBox.Image")));
            this.ImgBox.Location = new System.Drawing.Point(82, 62);
            this.ImgBox.Name = "ImgBox";
            this.ImgBox.Size = new System.Drawing.Size(100, 100);
            this.ImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgBox.TabIndex = 2;
            this.ImgBox.TabStop = false;
            // 
            // LoadingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(264, 238);
            this.Controls.Add(this.ImgBox);
            this.Controls.Add(this.LoadingLbl);
            this.Controls.Add(this.PatienceLbl);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "LoadingForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadingForm";
            ((System.ComponentModel.ISupportInitialize)(this.ImgBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PatienceLbl;
        private System.Windows.Forms.Label LoadingLbl;
        private System.Windows.Forms.PictureBox ImgBox;
    }
}