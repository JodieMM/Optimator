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
            this.StartTimeUpDown = new System.Windows.Forms.NumericUpDown();
            this.StartLbl = new System.Windows.Forms.Label();
            this.AnimationLv = new System.Windows.Forms.ListView();
            this.Part = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Start = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HowLong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PartLbl = new System.Windows.Forms.Label();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.ChangeTypeCb = new System.Windows.Forms.ComboBox();
            this.AddAnimationBtn = new System.Windows.Forms.Button();
            this.SecondsUpDown = new System.Windows.Forms.NumericUpDown();
            this.SecondsLbl = new System.Windows.Forms.Label();
            this.AmountLbl = new System.Windows.Forms.Label();
            this.AnimationAmountTb = new System.Windows.Forms.NumericUpDown();
            this.PartNameLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartTimeUpDown)).BeginInit();
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
            this.TableLayoutPnl.Controls.Add(this.StartTimeUpDown, 1, 4);
            this.TableLayoutPnl.Controls.Add(this.StartLbl, 0, 4);
            this.TableLayoutPnl.Controls.Add(this.AnimationLv, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.PartLbl, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.PreviewBtn, 0, 7);
            this.TableLayoutPnl.Controls.Add(this.ChangeTypeCb, 0, 2);
            this.TableLayoutPnl.Controls.Add(this.AddAnimationBtn, 0, 6);
            this.TableLayoutPnl.Controls.Add(this.SecondsUpDown, 1, 5);
            this.TableLayoutPnl.Controls.Add(this.SecondsLbl, 0, 5);
            this.TableLayoutPnl.Controls.Add(this.AmountLbl, 0, 3);
            this.TableLayoutPnl.Controls.Add(this.AnimationAmountTb, 1, 3);
            this.TableLayoutPnl.Controls.Add(this.PartNameLbl, 1, 1);
            this.TableLayoutPnl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.TableLayoutPnl.Location = new System.Drawing.Point(44, 127);
            this.TableLayoutPnl.Margin = new System.Windows.Forms.Padding(4);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 8;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.004F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.570857F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.570857F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.570857F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.570857F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.570857F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.570857F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.570857F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(912, 885);
            this.TableLayoutPnl.TabIndex = 124;
            // 
            // StartTimeUpDown
            // 
            this.StartTimeUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartTimeUpDown.DecimalPlaces = 2;
            this.StartTimeUpDown.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.StartTimeUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.StartTimeUpDown.Location = new System.Drawing.Point(366, 581);
            this.StartTimeUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.StartTimeUpDown.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.StartTimeUpDown.Name = "StartTimeUpDown";
            this.StartTimeUpDown.Size = new System.Drawing.Size(544, 64);
            this.StartTimeUpDown.TabIndex = 128;
            this.StartTimeUpDown.ValueChanged += new System.EventHandler(this.StartTimeUpDown_ValueChanged);
            // 
            // StartLbl
            // 
            this.StartLbl.AutoSize = true;
            this.StartLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.StartLbl.Location = new System.Drawing.Point(2, 579);
            this.StartLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StartLbl.Name = "StartLbl";
            this.StartLbl.Size = new System.Drawing.Size(218, 59);
            this.StartLbl.TabIndex = 130;
            this.StartLbl.Text = "Start Time";
            // 
            // AnimationLv
            // 
            this.AnimationLv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.AnimationLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Part,
            this.Action,
            this.Amount,
            this.Start,
            this.HowLong});
            this.TableLayoutPnl.SetColumnSpan(this.AnimationLv, 2);
            this.AnimationLv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnimationLv.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnimationLv.FullRowSelect = true;
            this.AnimationLv.GridLines = true;
            this.AnimationLv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.AnimationLv.HideSelection = false;
            this.AnimationLv.Location = new System.Drawing.Point(0, 0);
            this.AnimationLv.Margin = new System.Windows.Forms.Padding(0);
            this.AnimationLv.MultiSelect = false;
            this.AnimationLv.Name = "AnimationLv";
            this.AnimationLv.Size = new System.Drawing.Size(912, 354);
            this.AnimationLv.TabIndex = 125;
            this.AnimationLv.UseCompatibleStateImageBehavior = false;
            this.AnimationLv.View = System.Windows.Forms.View.Details;
            this.AnimationLv.SelectedIndexChanged += new System.EventHandler(this.AnimationLv_SelectedIndexChanged);
            // 
            // Part
            // 
            this.Part.Text = "Part ";
            this.Part.Width = 100;
            // 
            // Action
            // 
            this.Action.Text = "Action ";
            this.Action.Width = 146;
            // 
            // Amount
            // 
            this.Amount.Text = "Amount ";
            this.Amount.Width = 177;
            // 
            // Start
            // 
            this.Start.Text = "Start ";
            this.Start.Width = 114;
            // 
            // HowLong
            // 
            this.HowLong.Text = "Time ";
            this.HowLong.Width = 126;
            // 
            // PartLbl
            // 
            this.PartLbl.AutoSize = true;
            this.PartLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.PartLbl.Location = new System.Drawing.Point(2, 354);
            this.PartLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PartLbl.Name = "PartLbl";
            this.PartLbl.Size = new System.Drawing.Size(100, 59);
            this.PartLbl.TabIndex = 130;
            this.PartLbl.Text = "Part";
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.BackColor = System.Drawing.Color.Khaki;
            this.TableLayoutPnl.SetColumnSpan(this.PreviewBtn, 2);
            this.PreviewBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.PreviewBtn.Location = new System.Drawing.Point(2, 806);
            this.PreviewBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(908, 77);
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
            this.ChangeTypeCb.Location = new System.Drawing.Point(2, 431);
            this.ChangeTypeCb.Margin = new System.Windows.Forms.Padding(2);
            this.ChangeTypeCb.Name = "ChangeTypeCb";
            this.ChangeTypeCb.Size = new System.Drawing.Size(908, 67);
            this.ChangeTypeCb.TabIndex = 126;
            this.ChangeTypeCb.SelectedIndexChanged += new System.EventHandler(this.ChangeTypeCb_SelectedIndexChanged);
            // 
            // AddAnimationBtn
            // 
            this.AddAnimationBtn.BackColor = System.Drawing.Color.Khaki;
            this.TableLayoutPnl.SetColumnSpan(this.AddAnimationBtn, 2);
            this.AddAnimationBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddAnimationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAnimationBtn.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.AddAnimationBtn.Location = new System.Drawing.Point(2, 731);
            this.AddAnimationBtn.Margin = new System.Windows.Forms.Padding(2);
            this.AddAnimationBtn.Name = "AddAnimationBtn";
            this.AddAnimationBtn.Size = new System.Drawing.Size(908, 71);
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
            this.SecondsUpDown.Location = new System.Drawing.Point(366, 656);
            this.SecondsUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.SecondsUpDown.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.SecondsUpDown.Name = "SecondsUpDown";
            this.SecondsUpDown.Size = new System.Drawing.Size(544, 64);
            this.SecondsUpDown.TabIndex = 128;
            this.SecondsUpDown.ValueChanged += new System.EventHandler(this.SecondsUpDown_ValueChanged);
            // 
            // SecondsLbl
            // 
            this.SecondsLbl.AutoSize = true;
            this.SecondsLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SecondsLbl.Location = new System.Drawing.Point(2, 654);
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
            this.AmountLbl.Location = new System.Drawing.Point(2, 504);
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
            this.AnimationAmountTb.Location = new System.Drawing.Point(366, 506);
            this.AnimationAmountTb.Margin = new System.Windows.Forms.Padding(2);
            this.AnimationAmountTb.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.AnimationAmountTb.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.AnimationAmountTb.Name = "AnimationAmountTb";
            this.AnimationAmountTb.Size = new System.Drawing.Size(544, 64);
            this.AnimationAmountTb.TabIndex = 127;
            this.AnimationAmountTb.ValueChanged += new System.EventHandler(this.AnimationAmountTb_ValueChanged);
            // 
            // PartNameLbl
            // 
            this.PartNameLbl.AutoSize = true;
            this.PartNameLbl.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.PartNameLbl.Location = new System.Drawing.Point(366, 354);
            this.PartNameLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PartNameLbl.Name = "PartNameLbl";
            this.PartNameLbl.Size = new System.Drawing.Size(0, 59);
            this.PartNameLbl.TabIndex = 131;
            // 
            // MovePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.MoveLbl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MovePanel";
            this.Size = new System.Drawing.Size(1760, 1082);
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartTimeUpDown)).EndInit();
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
        private System.Windows.Forms.Label PartLbl;
        private System.Windows.Forms.ListView AnimationLv;
        private System.Windows.Forms.ColumnHeader Part;
        private System.Windows.Forms.ColumnHeader Action;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.ColumnHeader Start;
        private System.Windows.Forms.ColumnHeader HowLong;
        private System.Windows.Forms.Label PartNameLbl;
        private System.Windows.Forms.NumericUpDown StartTimeUpDown;
        private System.Windows.Forms.Label StartLbl;
    }
}
