namespace Optimator.Forms.Compile
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
            this.ExportBtn = new System.Windows.Forms.Button();
            this.SaveLbl = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameTb
            // 
            this.NameTb.BackColor = System.Drawing.Color.White;
            this.NameTb.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.NameTb.Location = new System.Drawing.Point(42, 142);
            this.NameTb.Margin = new System.Windows.Forms.Padding(12);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(596, 64);
            this.NameTb.TabIndex = 6;
            this.NameTb.Text = "Video Name";
            this.NameTb.TextChanged += new System.EventHandler(this.NameTb_TextChanged);
            // 
            // ExportBtn
            // 
            this.ExportBtn.BackColor = System.Drawing.Color.LightCoral;
            this.ExportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.ExportBtn.Location = new System.Drawing.Point(54, 604);
            this.ExportBtn.Margin = new System.Windows.Forms.Padding(12);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(600, 173);
            this.ExportBtn.TabIndex = 10;
            this.ExportBtn.Text = "Export";
            this.ExportBtn.UseVisualStyleBackColor = false;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // SaveLbl
            // 
            this.SaveLbl.AutoSize = true;
            this.SaveLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.SaveLbl.Location = new System.Drawing.Point(32, 56);
            this.SaveLbl.Name = "SaveLbl";
            this.SaveLbl.Size = new System.Drawing.Size(307, 72);
            this.SaveLbl.TabIndex = 11;
            this.SaveLbl.Text = "Save Video";
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.LightCoral;
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SaveBtn.Location = new System.Drawing.Point(54, 394);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(12);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(600, 173);
            this.SaveBtn.TabIndex = 12;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SavePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.SaveLbl);
            this.Controls.Add(this.ExportBtn);
            this.Controls.Add(this.NameTb);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SavePanel";
            this.Size = new System.Drawing.Size(820, 877);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Label SaveLbl;
        private System.Windows.Forms.Button SaveBtn;
    }
}
