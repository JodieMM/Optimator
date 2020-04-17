namespace Optimator.Tabs.Sets
{
    partial class JoinsPanel
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
            this.TurnFlipLbl = new System.Windows.Forms.Label();
            this.RotationFlipLbl = new System.Windows.Forms.Label();
            this.FlipsTurn = new System.Windows.Forms.NumericUpDown();
            this.FlipsRotation = new System.Windows.Forms.NumericUpDown();
            this.JoinBtn = new System.Windows.Forms.Button();
            this.FlipsCb = new System.Windows.Forms.CheckBox();
            this.SelectBaseBtn = new System.Windows.Forms.Button();
            this.JoinsLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.FlipsTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlipsRotation)).BeginInit();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TurnFlipLbl
            // 
            this.TurnFlipLbl.AutoSize = true;
            this.TurnFlipLbl.Location = new System.Drawing.Point(3, 512);
            this.TurnFlipLbl.Name = "TurnFlipLbl";
            this.TurnFlipLbl.Size = new System.Drawing.Size(97, 45);
            this.TurnFlipLbl.TabIndex = 131;
            this.TurnFlipLbl.Text = "Turn";
            // 
            // RotationFlipLbl
            // 
            this.RotationFlipLbl.AutoSize = true;
            this.RotationFlipLbl.Location = new System.Drawing.Point(3, 429);
            this.RotationFlipLbl.Name = "RotationFlipLbl";
            this.RotationFlipLbl.Size = new System.Drawing.Size(155, 45);
            this.RotationFlipLbl.TabIndex = 130;
            this.RotationFlipLbl.Text = "Rotation";
            // 
            // FlipsTurn
            // 
            this.FlipsTurn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlipsTurn.Enabled = false;
            this.FlipsTurn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlipsTurn.Location = new System.Drawing.Point(251, 514);
            this.FlipsTurn.Margin = new System.Windows.Forms.Padding(2);
            this.FlipsTurn.Maximum = new decimal(new int[] {
            179,
            0,
            0,
            0});
            this.FlipsTurn.Name = "FlipsTurn";
            this.FlipsTurn.Size = new System.Drawing.Size(245, 46);
            this.FlipsTurn.TabIndex = 129;
            this.FlipsTurn.ValueChanged += new System.EventHandler(this.FlipsUpDown_ValueChanged);
            // 
            // FlipsRotation
            // 
            this.FlipsRotation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlipsRotation.Enabled = false;
            this.FlipsRotation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlipsRotation.Location = new System.Drawing.Point(251, 431);
            this.FlipsRotation.Margin = new System.Windows.Forms.Padding(2);
            this.FlipsRotation.Maximum = new decimal(new int[] {
            179,
            0,
            0,
            0});
            this.FlipsRotation.Name = "FlipsRotation";
            this.FlipsRotation.Size = new System.Drawing.Size(245, 46);
            this.FlipsRotation.TabIndex = 124;
            this.FlipsRotation.ValueChanged += new System.EventHandler(this.FlipsUpDown_ValueChanged);
            // 
            // JoinBtn
            // 
            this.JoinBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.JoinBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TableLayoutPnl.SetColumnSpan(this.JoinBtn, 2);
            this.JoinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinBtn.Location = new System.Drawing.Point(2, 175);
            this.JoinBtn.Margin = new System.Windows.Forms.Padding(2);
            this.JoinBtn.Name = "JoinBtn";
            this.JoinBtn.Size = new System.Drawing.Size(494, 169);
            this.JoinBtn.TabIndex = 140;
            this.JoinBtn.Text = "Modify Join";
            this.JoinBtn.UseVisualStyleBackColor = false;
            this.JoinBtn.Click += new System.EventHandler(this.ToggleButton);
            // 
            // FlipsCb
            // 
            this.FlipsCb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlipsCb.AutoSize = true;
            this.TableLayoutPnl.SetColumnSpan(this.FlipsCb, 2);
            this.FlipsCb.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlipsCb.Location = new System.Drawing.Point(2, 348);
            this.FlipsCb.Margin = new System.Windows.Forms.Padding(2);
            this.FlipsCb.Name = "FlipsCb";
            this.FlipsCb.Size = new System.Drawing.Size(494, 79);
            this.FlipsCb.TabIndex = 139;
            this.FlipsCb.Text = "Flips?";
            this.FlipsCb.UseVisualStyleBackColor = true;
            this.FlipsCb.CheckedChanged += new System.EventHandler(this.FlipsCb_CheckedChanged);
            // 
            // SelectBaseBtn
            // 
            this.SelectBaseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectBaseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TableLayoutPnl.SetColumnSpan(this.SelectBaseBtn, 2);
            this.SelectBaseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectBaseBtn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectBaseBtn.Location = new System.Drawing.Point(2, 2);
            this.SelectBaseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SelectBaseBtn.Name = "SelectBaseBtn";
            this.SelectBaseBtn.Size = new System.Drawing.Size(494, 169);
            this.SelectBaseBtn.TabIndex = 138;
            this.SelectBaseBtn.Text = "Select Base";
            this.SelectBaseBtn.UseVisualStyleBackColor = false;
            this.SelectBaseBtn.Click += new System.EventHandler(this.ToggleButton);
            // 
            // JoinsLbl
            // 
            this.JoinsLbl.AutoSize = true;
            this.JoinsLbl.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinsLbl.Location = new System.Drawing.Point(82, 39);
            this.JoinsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.JoinsLbl.Name = "JoinsLbl";
            this.JoinsLbl.Size = new System.Drawing.Size(117, 46);
            this.JoinsLbl.TabIndex = 137;
            this.JoinsLbl.Text = "Joins";
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.Controls.Add(this.SelectBaseBtn, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.FlipsTurn, 1, 4);
            this.TableLayoutPnl.Controls.Add(this.JoinBtn, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.FlipsRotation, 1, 3);
            this.TableLayoutPnl.Controls.Add(this.TurnFlipLbl, 0, 4);
            this.TableLayoutPnl.Controls.Add(this.FlipsCb, 0, 2);
            this.TableLayoutPnl.Controls.Add(this.RotationFlipLbl, 0, 3);
            this.TableLayoutPnl.Font = new System.Drawing.Font("Tahoma", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableLayoutPnl.Location = new System.Drawing.Point(47, 113);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 5;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(498, 598);
            this.TableLayoutPnl.TabIndex = 141;
            // 
            // JoinsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.JoinsLbl);
            this.Name = "JoinsPanel";
            this.Size = new System.Drawing.Size(654, 796);
            ((System.ComponentModel.ISupportInitialize)(this.FlipsTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlipsRotation)).EndInit();
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TurnFlipLbl;
        private System.Windows.Forms.Label RotationFlipLbl;
        private System.Windows.Forms.NumericUpDown FlipsTurn;
        private System.Windows.Forms.NumericUpDown FlipsRotation;
        private System.Windows.Forms.Button JoinBtn;
        private System.Windows.Forms.CheckBox FlipsCb;
        private System.Windows.Forms.Button SelectBaseBtn;
        private System.Windows.Forms.Label JoinsLbl;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
    }
}
