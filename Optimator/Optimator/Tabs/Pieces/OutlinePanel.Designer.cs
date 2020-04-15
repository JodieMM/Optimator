namespace Optimator.Tabs.Pieces
{
    partial class OutlinePanel
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
            this.OutlineWLbl = new System.Windows.Forms.Label();
            this.OutlineWidthBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.OutlineWidthBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OutlineWLbl
            // 
            this.OutlineWLbl.AutoSize = true;
            this.OutlineWLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutlineWLbl.Location = new System.Drawing.Point(91, 225);
            this.OutlineWLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OutlineWLbl.Name = "OutlineWLbl";
            this.OutlineWLbl.Size = new System.Drawing.Size(250, 46);
            this.OutlineWLbl.TabIndex = 123;
            this.OutlineWLbl.Text = "Outline Width";
            // 
            // OutlineWidthBox
            // 
            this.OutlineWidthBox.Location = new System.Drawing.Point(371, 240);
            this.OutlineWidthBox.Name = "OutlineWidthBox";
            this.OutlineWidthBox.Size = new System.Drawing.Size(239, 31);
            this.OutlineWidthBox.TabIndex = 122;
            this.OutlineWidthBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.OutlineWidthBox.ValueChanged += new System.EventHandler(this.OutlineWidthBox_ValueChanged);
            // 
            // OutlinePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OutlineWLbl);
            this.Controls.Add(this.OutlineWidthBox);
            this.Name = "OutlinePanel";
            this.Size = new System.Drawing.Size(868, 792);
            ((System.ComponentModel.ISupportInitialize)(this.OutlineWidthBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OutlineWLbl;
        private System.Windows.Forms.NumericUpDown OutlineWidthBox;
    }
}
