namespace Optimator.Tabs.SoloTabs
{
    partial class LoadingMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingMessage));
            this.ImgBox = new System.Windows.Forms.PictureBox();
            this.LoadingLbl = new System.Windows.Forms.Label();
            this.PatienceLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBox)).BeginInit();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImgBox
            // 
            this.ImgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImgBox.Image = ((System.Drawing.Image)(resources.GetObject("ImgBox.Image")));
            this.ImgBox.Location = new System.Drawing.Point(3, 119);
            this.ImgBox.Name = "ImgBox";
            this.ImgBox.Size = new System.Drawing.Size(494, 110);
            this.ImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgBox.TabIndex = 5;
            this.ImgBox.TabStop = false;
            // 
            // LoadingLbl
            // 
            this.LoadingLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadingLbl.AutoSize = true;
            this.LoadingLbl.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadingLbl.Location = new System.Drawing.Point(3, 0);
            this.LoadingLbl.Name = "LoadingLbl";
            this.LoadingLbl.Size = new System.Drawing.Size(494, 116);
            this.LoadingLbl.TabIndex = 4;
            this.LoadingLbl.Text = "Optimator is Loading!";
            this.LoadingLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PatienceLbl
            // 
            this.PatienceLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PatienceLbl.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatienceLbl.Location = new System.Drawing.Point(3, 233);
            this.PatienceLbl.Name = "PatienceLbl";
            this.PatienceLbl.Size = new System.Drawing.Size(494, 116);
            this.PatienceLbl.TabIndex = 3;
            this.PatienceLbl.Text = "Please be patient, this shouldn\'t take long...";
            this.PatienceLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 1;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPnl.Controls.Add(this.LoadingLbl, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.PatienceLbl, 0, 2);
            this.TableLayoutPnl.Controls.Add(this.ImgBox, 0, 1);
            this.TableLayoutPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPnl.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 3;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(500, 350);
            this.TableLayoutPnl.TabIndex = 6;
            // 
            // LoadingMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Name = "LoadingMessage";
            this.Size = new System.Drawing.Size(500, 350);
            ((System.ComponentModel.ISupportInitialize)(this.ImgBox)).EndInit();
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ImgBox;
        private System.Windows.Forms.Label LoadingLbl;
        private System.Windows.Forms.Label PatienceLbl;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
    }
}
