namespace Optimator.Tabs.Pieces
{
    partial class SolidPanel
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
            this.SolidLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SolidLbl
            // 
            this.SolidLbl.AutoSize = true;
            this.SolidLbl.Font = Consts.headingLblFont;
            this.SolidLbl.Location = new System.Drawing.Point(107, 123);
            this.SolidLbl.Name = "SolidLbl";
            this.SolidLbl.Size = new System.Drawing.Size(155, 58);
            this.SolidLbl.TabIndex = 0;
            this.SolidLbl.Text = "Fixed";
            // 
            // SolidPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SolidLbl);
            this.Name = "SolidPanel";
            this.Size = new System.Drawing.Size(908, 992);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SolidLbl;
    }
}
