namespace Optimator.Tabs.Sets
{
    partial class SettingsPanel
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
            this.SettingsLb = new System.Windows.Forms.Label();
            this.SelectFromTopCb = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // SettingsLb
            // 
            this.SettingsLb.AutoSize = true;
            this.SettingsLb.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsLb.Location = new System.Drawing.Point(34, 44);
            this.SettingsLb.Name = "SettingsLb";
            this.SettingsLb.Size = new System.Drawing.Size(224, 58);
            this.SettingsLb.TabIndex = 0;
            this.SettingsLb.Text = "Settings";
            // 
            // SelectFromTopCb
            // 
            this.SelectFromTopCb.AutoSize = true;
            this.SelectFromTopCb.Checked = true;
            this.SelectFromTopCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelectFromTopCb.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFromTopCb.Location = new System.Drawing.Point(44, 170);
            this.SelectFromTopCb.Name = "SelectFromTopCb";
            this.SelectFromTopCb.Size = new System.Drawing.Size(405, 49);
            this.SelectFromTopCb.TabIndex = 1;
            this.SelectFromTopCb.Text = "Select Piece from Top";
            this.SelectFromTopCb.UseVisualStyleBackColor = true;
            this.SelectFromTopCb.CheckedChanged += new System.EventHandler(this.SelectFromTopCb_CheckedChanged);
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SelectFromTopCb);
            this.Controls.Add(this.SettingsLb);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(908, 992);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SettingsLb;
        private System.Windows.Forms.CheckBox SelectFromTopCb;
    }
}
