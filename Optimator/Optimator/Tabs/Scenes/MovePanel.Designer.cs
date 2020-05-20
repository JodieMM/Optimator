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
            this.MoveLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.MoveLbl.Location = new System.Drawing.Point(34, 44);
            this.MoveLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MoveLbl.Name = "MoveLbl";
            this.MoveLbl.Size = new System.Drawing.Size(320, 72);
            this.MoveLbl.TabIndex = 0;
            this.MoveLbl.Text = "Animations";
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
            this.TableLayoutPnl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.TableLayoutPnl.Location = new System.Drawing.Point(44, 127);
            this.TableLayoutPnl.Margin = new System.Windows.Forms.Padding(4);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 6;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(818, 671);
            this.TableLayoutPnl.TabIndex = 124;
            // 
            // AnimationLb
            // 
            this.TableLayoutPnl.SetColumnSpan(this.AnimationLb, 2);
            this.AnimationLb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnimationLb.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.AnimationLb.FormattingEnabled = true;
            this.AnimationLb.ItemHeight = 59;
            this.AnimationLb.Location = new System.Drawing.Point(4, 4);
            this.AnimationLb.Margin = new System.Windows.Forms.Padding(4);
            this.AnimationLb.Name = "AnimationLb";
            this.AnimationLb.Size = new System.Drawing.Size(810, 327);
            this.AnimationLb.TabIndex = 125;
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.BackColor = System.Drawing.Color.Khaki;
            this.TableLayoutPnl.SetColumnSpan(this.PreviewBtn, 2);
            this.PreviewBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.PreviewBtn.Location = new System.Drawing.Point(2, 605);
            this.PreviewBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(814, 64);
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
            this.ChangeTypeCb.Font = new System.Drawing.Font("Segoe UI", 16F);
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
            this.ChangeTypeCb.Location = new System.Drawing.Point(2, 337);
            this.ChangeTypeCb.Margin = new System.Windows.Forms.Padding(2);
            this.ChangeTypeCb.Name = "ChangeTypeCb";
            this.ChangeTypeCb.Size = new System.Drawing.Size(814, 67);
            this.ChangeTypeCb.TabIndex = 126;
            // 
            // AddAnimationBtn
            // 
            this.AddAnimationBtn.BackColor = System.Drawing.Color.Khaki;
            this.TableLayoutPnl.SetColumnSpan(this.AddAnimationBtn, 2);
            this.AddAnimationBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddAnimationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAnimationBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.AddAnimationBtn.Location = new System.Drawing.Point(2, 538);
            this.AddAnimationBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddAnimationBtn.Name = "AddAnimationBtn";
            this.AddAnimationBtn.Size = new System.Drawing.Size(814, 63);
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
            this.SecondsUpDown.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SecondsUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.SecondsUpDown.Location = new System.Drawing.Point(329, 471);
            this.SecondsUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.SecondsUpDown.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.SecondsUpDown.Name = "SecondsUpDown";
            this.SecondsUpDown.Size = new System.Drawing.Size(487, 64);
            this.SecondsUpDown.TabIndex = 128;
            // 
            // SecondsLbl
            // 
            this.SecondsLbl.AutoSize = true;
            this.SecondsLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SecondsLbl.Location = new System.Drawing.Point(2, 469);
            this.SecondsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SecondsLbl.Name = "SecondsLbl";
            this.SecondsLbl.Size = new System.Drawing.Size(182, 59);
            this.SecondsLbl.TabIndex = 130;
            this.SecondsLbl.Text = "Seconds";
            // 
            // AmountLbl
            // 
            this.AmountLbl.AutoSize = true;
            this.AmountLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.AmountLbl.Location = new System.Drawing.Point(2, 402);
            this.AmountLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AmountLbl.Name = "AmountLbl";
            this.AmountLbl.Size = new System.Drawing.Size(178, 59);
            this.AmountLbl.TabIndex = 129;
            this.AmountLbl.Text = "Amount";
            // 
            // AnimationAmountTb
            // 
            this.AnimationAmountTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimationAmountTb.DecimalPlaces = 2;
            this.AnimationAmountTb.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.AnimationAmountTb.Location = new System.Drawing.Point(329, 404);
            this.AnimationAmountTb.Margin = new System.Windows.Forms.Padding(2);
            this.AnimationAmountTb.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AnimationAmountTb.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.AnimationAmountTb.Name = "AnimationAmountTb";
            this.AnimationAmountTb.Size = new System.Drawing.Size(487, 64);
            this.AnimationAmountTb.TabIndex = 127;
            // 
            // MovePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.MoveLbl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MovePanel";
            this.Size = new System.Drawing.Size(908, 992);
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
