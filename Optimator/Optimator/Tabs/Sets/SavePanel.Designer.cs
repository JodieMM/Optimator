namespace Optimator.Forms.Sets
{
    partial class SavePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameTb = new System.Windows.Forms.TextBox();
            this.CompleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameTb
            // 
            this.NameTb.BackColor = System.Drawing.Color.White;
            this.NameTb.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTb.Location = new System.Drawing.Point(42, 52);
            this.NameTb.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(596, 58);
            this.NameTb.TabIndex = 6;
            this.NameTb.Text = "Piece Name";
            // 
            // CompleteBtn
            // 
            this.CompleteBtn.BackColor = System.Drawing.Color.LightCyan;
            this.CompleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompleteBtn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompleteBtn.Location = new System.Drawing.Point(42, 512);
            this.CompleteBtn.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.CompleteBtn.Name = "CompleteBtn";
            this.CompleteBtn.Size = new System.Drawing.Size(600, 173);
            this.CompleteBtn.TabIndex = 10;
            this.CompleteBtn.Text = "Save";
            this.CompleteBtn.UseVisualStyleBackColor = false;
            this.CompleteBtn.Click += new System.EventHandler(this.CompleteBtn_Click);
            // 
            // SavePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CompleteBtn);
            this.Controls.Add(this.NameTb);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SavePanel";
            this.Size = new System.Drawing.Size(820, 877);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.Button CompleteBtn;
    }
}
