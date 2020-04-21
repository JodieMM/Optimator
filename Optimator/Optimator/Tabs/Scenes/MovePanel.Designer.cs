namespace Optimator.Tabs.Scenes
{
    partial class MovePanel
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
            this.MoveLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.AnimationLb = new System.Windows.Forms.ListBox();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.ChangeTypeCb = new System.Windows.Forms.ComboBox();
            this.AddAnimationBtn = new System.Windows.Forms.Button();
            this.SecondsUpDown = new System.Windows.Forms.NumericUpDown();
            this.SecondsLbl = new System.Windows.Forms.Label();
            this.AmountLbl = new System.Windows.Forms.Label();
            this.AnimationAmountTb = new System.Windows.Forms.NumericUpDown();
            this.TableLayoutPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationAmountTb)).BeginInit();
            this.SuspendLayout();
            // 
            // MoveLbl
            // 
            this.MoveLbl.AutoSize = true;
            this.MoveLbl.Font = Consts.headingLblFont;
            this.MoveLbl.Location = new System.Drawing.Point(17, 23);
            this.MoveLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MoveLbl.Name = "MoveLbl";
            this.MoveLbl.Size = new System.Drawing.Size(151, 29);
            this.MoveLbl.TabIndex = 0;
            this.MoveLbl.Text = "Movements";
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TableLayoutPnl.Controls.Add(this.AnimationLb, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.PreviewBtn, 0, 5);
            this.TableLayoutPnl.Controls.Add(this.ChangeTypeCb, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.AddAnimationBtn, 0, 4);
            this.TableLayoutPnl.Controls.Add(this.SecondsUpDown, 1, 3);
            this.TableLayoutPnl.Controls.Add(this.SecondsLbl, 0, 3);
            this.TableLayoutPnl.Controls.Add(this.AmountLbl, 0, 2);
            this.TableLayoutPnl.Controls.Add(this.AnimationAmountTb, 1, 2);
            this.TableLayoutPnl.Font = Consts.contentFont;
            this.TableLayoutPnl.Location = new System.Drawing.Point(22, 66);
            this.TableLayoutPnl.Margin = new System.Windows.Forms.Padding(2);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 6;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(409, 349);
            this.TableLayoutPnl.TabIndex = 124;
            // 
            // AnimationLb
            // 
            this.TableLayoutPnl.SetColumnSpan(this.AnimationLb, 2);
            this.AnimationLb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnimationLb.Font = Consts.contentFont;
            this.AnimationLb.FormattingEnabled = true;
            this.AnimationLb.ItemHeight = 23;
            this.AnimationLb.Location = new System.Drawing.Point(2, 2);
            this.AnimationLb.Margin = new System.Windows.Forms.Padding(2);
            this.AnimationLb.Name = "AnimationLb";
            this.AnimationLb.Size = new System.Drawing.Size(405, 170);
            this.AnimationLb.TabIndex = 125;
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.BackColor = System.Drawing.Color.Khaki;
            this.TableLayoutPnl.SetColumnSpan(this.PreviewBtn, 2);
            this.PreviewBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewBtn.Font = Consts.contentFont;
            this.PreviewBtn.Location = new System.Drawing.Point(1, 311);
            this.PreviewBtn.Margin = new System.Windows.Forms.Padding(1);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(407, 37);
            this.PreviewBtn.TabIndex = 131;
            this.PreviewBtn.Text = "Preview";
            this.PreviewBtn.UseVisualStyleBackColor = false;
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // ChangeTypeCb
            // 
            this.TableLayoutPnl.SetColumnSpan(this.ChangeTypeCb, 2);
            this.ChangeTypeCb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChangeTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChangeTypeCb.Font = Consts.contentFont;
            this.ChangeTypeCb.FormattingEnabled = true;
            this.ChangeTypeCb.Items.AddRange(new object[] {
            "X",
            "Y",
            "Rotation",
            "Turn",
            "Spin",
            "Size",
            "Order",
            "Removed"});
            this.ChangeTypeCb.Location = new System.Drawing.Point(1, 175);
            this.ChangeTypeCb.Margin = new System.Windows.Forms.Padding(1);
            this.ChangeTypeCb.Name = "ChangeTypeCb";
            this.ChangeTypeCb.Size = new System.Drawing.Size(407, 31);
            this.ChangeTypeCb.TabIndex = 126;
            // 
            // AddAnimationBtn
            // 
            this.AddAnimationBtn.BackColor = System.Drawing.Color.Khaki;
            this.TableLayoutPnl.SetColumnSpan(this.AddAnimationBtn, 2);
            this.AddAnimationBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddAnimationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAnimationBtn.Font = Consts.contentFont;
            this.AddAnimationBtn.Location = new System.Drawing.Point(1, 277);
            this.AddAnimationBtn.Margin = new System.Windows.Forms.Padding(1);
            this.AddAnimationBtn.Name = "AddAnimationBtn";
            this.AddAnimationBtn.Size = new System.Drawing.Size(407, 32);
            this.AddAnimationBtn.TabIndex = 125;
            this.AddAnimationBtn.Text = "Add";
            this.AddAnimationBtn.UseVisualStyleBackColor = false;
            this.AddAnimationBtn.Click += new System.EventHandler(this.AddAnimationBtn_Click);
            // 
            // SecondsUpDown
            // 
            this.SecondsUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SecondsUpDown.DecimalPlaces = 3;
            this.SecondsUpDown.Font = Consts.contentFont;
            this.SecondsUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.SecondsUpDown.Location = new System.Drawing.Point(164, 243);
            this.SecondsUpDown.Margin = new System.Windows.Forms.Padding(1);
            this.SecondsUpDown.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.SecondsUpDown.Name = "SecondsUpDown";
            this.SecondsUpDown.Size = new System.Drawing.Size(244, 30);
            this.SecondsUpDown.TabIndex = 128;
            // 
            // SecondsLbl
            // 
            this.SecondsLbl.AutoSize = true;
            this.SecondsLbl.Font = Consts.contentFont;
            this.SecondsLbl.Location = new System.Drawing.Point(1, 242);
            this.SecondsLbl.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.SecondsLbl.Name = "SecondsLbl";
            this.SecondsLbl.Size = new System.Drawing.Size(80, 23);
            this.SecondsLbl.TabIndex = 130;
            this.SecondsLbl.Text = "Seconds";
            // 
            // AmountLbl
            // 
            this.AmountLbl.AutoSize = true;
            this.AmountLbl.Font = Consts.contentFont;
            this.AmountLbl.Location = new System.Drawing.Point(1, 208);
            this.AmountLbl.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.AmountLbl.Name = "AmountLbl";
            this.AmountLbl.Size = new System.Drawing.Size(75, 23);
            this.AmountLbl.TabIndex = 129;
            this.AmountLbl.Text = "Amount";
            // 
            // AnimationAmountTb
            // 
            this.AnimationAmountTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimationAmountTb.Font = Consts.contentFont;
            this.AnimationAmountTb.Location = new System.Drawing.Point(164, 209);
            this.AnimationAmountTb.Margin = new System.Windows.Forms.Padding(1);
            this.AnimationAmountTb.Name = "AnimationAmountTb";
            this.AnimationAmountTb.Size = new System.Drawing.Size(244, 30);
            this.AnimationAmountTb.TabIndex = 127;
            // 
            // MovePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.MoveLbl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MovePanel";
            this.Size = new System.Drawing.Size(454, 516);
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationAmountTb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MoveLbl;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Button PreviewBtn;
        private System.Windows.Forms.ComboBox ChangeTypeCb;
        private System.Windows.Forms.Button AddAnimationBtn;
        private System.Windows.Forms.NumericUpDown SecondsUpDown;
        private System.Windows.Forms.Label SecondsLbl;
        private System.Windows.Forms.Label AmountLbl;
        private System.Windows.Forms.NumericUpDown AnimationAmountTb;
        private System.Windows.Forms.ListBox AnimationLb;
    }
}
