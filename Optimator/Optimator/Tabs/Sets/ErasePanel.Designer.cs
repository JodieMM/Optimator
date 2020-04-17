namespace Optimator.Tabs.Sets
{
    partial class ErasePanel
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
            this.EraseLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EraseLbl
            // 
            this.EraseLbl.AutoSize = true;
            this.EraseLbl.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EraseLbl.Location = new System.Drawing.Point(34, 44);
            this.EraseLbl.Name = "EraseLbl";
            this.EraseLbl.Size = new System.Drawing.Size(159, 58);
            this.EraseLbl.TabIndex = 0;
            this.EraseLbl.Text = "Erase";
            // 
            // ErasePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EraseLbl);
            this.Name = "ErasePanel";
            this.Size = new System.Drawing.Size(908, 992);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EraseLbl;
    }
}
