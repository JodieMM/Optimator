namespace Optimator.Tabs.Compile
{
    partial class ScenePreview
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
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SceneNameLbl = new System.Windows.Forms.Label();
            this.SelectPreviewCb = new System.Windows.Forms.CheckBox();
            this.OriginalPreview = new System.Windows.Forms.PictureBox();
            this.FinalPreview = new System.Windows.Forms.PictureBox();
            this.TableLayoutPnl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FinalPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.BackColor = System.Drawing.Color.MistyRose;
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.OriginalPreview, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.FinalPreview, 1, 1);
            this.TableLayoutPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPnl.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 2;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(550, 315);
            this.TableLayoutPnl.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPnl.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Controls.Add(this.SceneNameLbl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.SelectPreviewCb, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 72);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // SceneNameLbl
            // 
            this.SceneNameLbl.AutoSize = true;
            this.SceneNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneNameLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SceneNameLbl.Location = new System.Drawing.Point(84, 0);
            this.SceneNameLbl.Name = "SceneNameLbl";
            this.SceneNameLbl.Size = new System.Drawing.Size(457, 72);
            this.SceneNameLbl.TabIndex = 3;
            this.SceneNameLbl.Text = "Scene Name";
            this.SceneNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectPreviewCb
            // 
            this.SelectPreviewCb.AutoSize = true;
            this.SelectPreviewCb.BackColor = System.Drawing.Color.Transparent;
            this.SelectPreviewCb.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SelectPreviewCb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectPreviewCb.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SelectPreviewCb.Location = new System.Drawing.Point(3, 3);
            this.SelectPreviewCb.Name = "SelectPreviewCb";
            this.SelectPreviewCb.Size = new System.Drawing.Size(75, 66);
            this.SelectPreviewCb.TabIndex = 4;
            this.SelectPreviewCb.UseVisualStyleBackColor = false;
            this.SelectPreviewCb.CheckedChanged += new System.EventHandler(this.SelectPreviewCb_CheckedChanged);
            // 
            // OriginalPreview
            // 
            this.OriginalPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginalPreview.Location = new System.Drawing.Point(3, 81);
            this.OriginalPreview.Name = "OriginalPreview";
            this.OriginalPreview.Size = new System.Drawing.Size(269, 231);
            this.OriginalPreview.TabIndex = 0;
            this.OriginalPreview.TabStop = false;
            // 
            // FinalPreview
            // 
            this.FinalPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FinalPreview.Location = new System.Drawing.Point(278, 81);
            this.FinalPreview.Name = "FinalPreview";
            this.FinalPreview.Size = new System.Drawing.Size(269, 231);
            this.FinalPreview.TabIndex = 3;
            this.FinalPreview.TabStop = false;
            // 
            // ScenePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.MinimumSize = new System.Drawing.Size(550, 315);
            this.Name = "ScenePreview";
            this.Size = new System.Drawing.Size(550, 315);
            this.TableLayoutPnl.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FinalPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox OriginalPreview;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.PictureBox FinalPreview;
        private System.Windows.Forms.Label SceneNameLbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox SelectPreviewCb;
    }
}
