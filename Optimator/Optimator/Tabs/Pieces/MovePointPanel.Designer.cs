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
            this.ConnectorsLbl = new System.Windows.Forms.Label();
            this.ConnectorOptions = new System.Windows.Forms.ComboBox();
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
            // ConnectorsLbl
            // 
            this.ConnectorsLbl.AutoSize = true;
            this.ConnectorsLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectorsLbl.Location = new System.Drawing.Point(105, 453);
            this.ConnectorsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ConnectorsLbl.Name = "ConnectorsLbl";
            this.ConnectorsLbl.Size = new System.Drawing.Size(192, 46);
            this.ConnectorsLbl.TabIndex = 118;
            this.ConnectorsLbl.Text = "Connector";
            // 
            // ConnectorOptions
            // 
            this.ConnectorOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConnectorOptions.FormattingEnabled = true;
            this.ConnectorOptions.Items.AddRange(new object[] {
            "Line",
            "Blank"});
            this.ConnectorOptions.Location = new System.Drawing.Point(363, 468);
            this.ConnectorOptions.Name = "ConnectorOptions";
            this.ConnectorOptions.Size = new System.Drawing.Size(239, 33);
            this.ConnectorOptions.TabIndex = 117;
            this.ConnectorOptions.SelectedIndexChanged += new System.EventHandler(this.ConnectorOptions_SelectedIndexChanged);
            // 
            // MovePointPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConnectorsLbl);
            this.Controls.Add(this.ConnectorOptions);
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
        private System.Windows.Forms.Label ConnectorsLbl;
        private System.Windows.Forms.ComboBox ConnectorOptions;
    }
}
