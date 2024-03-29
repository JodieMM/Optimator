﻿namespace Optimator.Forms.Pieces
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
            this.CompleteBtn = new System.Windows.Forms.Button();
            this.SaveLbl = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.SaveAsBtn = new System.Windows.Forms.Button();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // CompleteBtn
            // 
            this.CompleteBtn.BackColor = System.Drawing.Color.LightCyan;
            this.CompleteBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompleteBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.CompleteBtn.Location = new System.Drawing.Point(0, 374);
            this.CompleteBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CompleteBtn.Name = "CompleteBtn";
            this.CompleteBtn.Size = new System.Drawing.Size(574, 188);
            this.CompleteBtn.TabIndex = 12;
            this.CompleteBtn.Text = "Complete";
            this.CompleteBtn.UseVisualStyleBackColor = false;
            this.CompleteBtn.Click += new System.EventHandler(this.CompleteBtn_Click);
            // 
            // SaveLbl
            // 
            this.SaveLbl.AutoSize = true;
            this.SaveLbl.Font = new System.Drawing.Font("Segoe UI", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLbl.Location = new System.Drawing.Point(56, 46);
            this.SaveLbl.Name = "SaveLbl";
            this.SaveLbl.Size = new System.Drawing.Size(146, 71);
            this.SaveLbl.TabIndex = 11;
            this.SaveLbl.Text = "Save";
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.LightCyan;
            this.SaveBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SaveBtn.Location = new System.Drawing.Point(0, 0);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(574, 187);
            this.SaveBtn.TabIndex = 10;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 1;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPnl.Controls.Add(this.SaveAsBtn, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.SaveBtn, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.CompleteBtn, 0, 2);
            this.TableLayoutPnl.Location = new System.Drawing.Point(91, 186);
            this.TableLayoutPnl.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 3;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(574, 562);
            this.TableLayoutPnl.TabIndex = 13;
            // 
            // SaveAsBtn
            // 
            this.SaveAsBtn.BackColor = System.Drawing.Color.LightCyan;
            this.SaveAsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveAsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveAsBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SaveAsBtn.Location = new System.Drawing.Point(0, 187);
            this.SaveAsBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SaveAsBtn.Name = "SaveAsBtn";
            this.SaveAsBtn.Size = new System.Drawing.Size(574, 187);
            this.SaveAsBtn.TabIndex = 14;
            this.SaveAsBtn.Text = "Save As";
            this.SaveAsBtn.UseVisualStyleBackColor = false;
            this.SaveAsBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SavePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.SaveLbl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SavePanel";
            this.Size = new System.Drawing.Size(758, 853);
            this.TableLayoutPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CompleteBtn;
        private System.Windows.Forms.Label SaveLbl;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Button SaveAsBtn;
    }
}
