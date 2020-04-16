namespace Optimator.Tabs.Pieces
{
    partial class MovePointPanel
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
            this.XCoordLbl = new System.Windows.Forms.Label();
            this.YCoordLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // XCoordLbl
            // 
            this.XCoordLbl.AutoSize = true;
            this.XCoordLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XCoordLbl.Location = new System.Drawing.Point(106, 202);
            this.XCoordLbl.Name = "XCoordLbl";
            this.XCoordLbl.Size = new System.Drawing.Size(100, 39);
            this.XCoordLbl.TabIndex = 0;
            this.XCoordLbl.Text = "label1";
            // 
            // YCoordLbl
            // 
            this.YCoordLbl.AutoSize = true;
            this.YCoordLbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YCoordLbl.Location = new System.Drawing.Point(106, 290);
            this.YCoordLbl.Name = "YCoordLbl";
            this.YCoordLbl.Size = new System.Drawing.Size(100, 39);
            this.YCoordLbl.TabIndex = 1;
            this.YCoordLbl.Text = "label2";
            // 
            // MovePointPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.YCoordLbl);
            this.Controls.Add(this.XCoordLbl);
            this.Name = "MovePointPanel";
            this.Size = new System.Drawing.Size(798, 1000);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label XCoordLbl;
        private System.Windows.Forms.Label YCoordLbl;
    }
}
