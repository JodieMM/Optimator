namespace Optimator.Forms.Sets
{
    partial class AddPartPanel
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
            this.AddPartBtn = new System.Windows.Forms.Button();
            this.AddPartLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.CloneAttachmentsBtn = new System.Windows.Forms.Button();
            this.CloneSoloBtn = new System.Windows.Forms.Button();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddPartBtn
            // 
            this.AddPartBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AddPartBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddPartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPartBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.AddPartBtn.Location = new System.Drawing.Point(0, 0);
            this.AddPartBtn.Margin = new System.Windows.Forms.Padding(0);
            this.AddPartBtn.Name = "AddPartBtn";
            this.AddPartBtn.Size = new System.Drawing.Size(437, 107);
            this.AddPartBtn.TabIndex = 82;
            this.AddPartBtn.Text = "Select Part";
            this.AddPartBtn.UseVisualStyleBackColor = false;
            this.AddPartBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // AddPartLbl
            // 
            this.AddPartLbl.AutoSize = true;
            this.AddPartLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.AddPartLbl.Location = new System.Drawing.Point(34, 46);
            this.AddPartLbl.Name = "AddPartLbl";
            this.AddPartLbl.Size = new System.Drawing.Size(254, 72);
            this.AddPartLbl.TabIndex = 84;
            this.AddPartLbl.Text = "Add Part";
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 1;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPnl.Controls.Add(this.CloneAttachmentsBtn, 0, 2);
            this.TableLayoutPnl.Controls.Add(this.CloneSoloBtn, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.AddPartBtn, 0, 0);
            this.TableLayoutPnl.Location = new System.Drawing.Point(44, 172);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 3;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(437, 322);
            this.TableLayoutPnl.TabIndex = 85;
            // 
            // CloneAttachmentsBtn
            // 
            this.CloneAttachmentsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CloneAttachmentsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CloneAttachmentsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloneAttachmentsBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.CloneAttachmentsBtn.Location = new System.Drawing.Point(0, 214);
            this.CloneAttachmentsBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CloneAttachmentsBtn.Name = "CloneAttachmentsBtn";
            this.CloneAttachmentsBtn.Size = new System.Drawing.Size(437, 108);
            this.CloneAttachmentsBtn.TabIndex = 84;
            this.CloneAttachmentsBtn.Text = "Clone Attachments";
            this.CloneAttachmentsBtn.UseVisualStyleBackColor = false;
            this.CloneAttachmentsBtn.Visible = false;
            this.CloneAttachmentsBtn.Click += new System.EventHandler(this.CloneBtn_Click);
            // 
            // CloneSoloBtn
            // 
            this.CloneSoloBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CloneSoloBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CloneSoloBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloneSoloBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.CloneSoloBtn.Location = new System.Drawing.Point(0, 107);
            this.CloneSoloBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CloneSoloBtn.Name = "CloneSoloBtn";
            this.CloneSoloBtn.Size = new System.Drawing.Size(437, 107);
            this.CloneSoloBtn.TabIndex = 83;
            this.CloneSoloBtn.Text = "Clone";
            this.CloneSoloBtn.UseVisualStyleBackColor = false;
            this.CloneSoloBtn.Click += new System.EventHandler(this.CloneBtn_Click);
            // 
            // AddPartPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.AddPartLbl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddPartPanel";
            this.Size = new System.Drawing.Size(620, 1149);
            this.TableLayoutPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Button AddPartBtn;
        private System.Windows.Forms.Label AddPartLbl;
        private System.Windows.Forms.Button CloneAttachmentsBtn;
        private System.Windows.Forms.Button CloneSoloBtn;
    }
}
