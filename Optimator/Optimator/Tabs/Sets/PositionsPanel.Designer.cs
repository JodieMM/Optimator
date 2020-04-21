namespace Optimator.Tabs.Sets
{
    partial class PositionsPanel
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
            this.PositionsLbl = new System.Windows.Forms.Label();
            this.SizeLbl = new System.Windows.Forms.Label();
            this.SizeBar = new System.Windows.Forms.TrackBar();
            this.SpinLbl = new System.Windows.Forms.Label();
            this.SpinBar = new System.Windows.Forms.TrackBar();
            this.TurnLbl = new System.Windows.Forms.Label();
            this.TurnBar = new System.Windows.Forms.TrackBar();
            this.RotationLbl = new System.Windows.Forms.Label();
            this.RotationBar = new System.Windows.Forms.TrackBar();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).BeginInit();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // PositionsLbl
            // 
            this.PositionsLbl.AutoSize = true;
            this.PositionsLbl.Font = Consts.headingLblFont;
            this.PositionsLbl.Location = new System.Drawing.Point(33, 50);
            this.PositionsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PositionsLbl.Name = "PositionsLbl";
            this.PositionsLbl.Size = new System.Drawing.Size(221, 58);
            this.PositionsLbl.TabIndex = 130;
            this.PositionsLbl.Text = "Position";
            // 
            // SizeLbl
            // 
            this.SizeLbl.AutoSize = true;
            this.SizeLbl.Font = Consts.contentFont;
            this.SizeLbl.Location = new System.Drawing.Point(2, 354);
            this.SizeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SizeLbl.Name = "SizeLbl";
            this.SizeLbl.Size = new System.Drawing.Size(84, 45);
            this.SizeLbl.TabIndex = 129;
            this.SizeLbl.Text = "Size";
            // 
            // SizeBar
            // 
            this.SizeBar.Location = new System.Drawing.Point(205, 357);
            this.SizeBar.Maximum = 500;
            this.SizeBar.Name = "SizeBar";
            this.SizeBar.Size = new System.Drawing.Size(350, 90);
            this.SizeBar.SmallChange = 5;
            this.SizeBar.TabIndex = 128;
            this.SizeBar.TickFrequency = 50;
            this.SizeBar.Value = 100;
            this.SizeBar.Scroll += new System.EventHandler(this.ScrollBar_Scroll);
            // 
            // SpinLbl
            // 
            this.SpinLbl.AutoSize = true;
            this.SpinLbl.Font = Consts.contentFont;
            this.SpinLbl.Location = new System.Drawing.Point(2, 236);
            this.SpinLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SpinLbl.Name = "SpinLbl";
            this.SpinLbl.Size = new System.Drawing.Size(90, 45);
            this.SpinLbl.TabIndex = 127;
            this.SpinLbl.Text = "Spin";
            // 
            // SpinBar
            // 
            this.SpinBar.Location = new System.Drawing.Point(205, 239);
            this.SpinBar.Maximum = 359;
            this.SpinBar.Name = "SpinBar";
            this.SpinBar.Size = new System.Drawing.Size(350, 90);
            this.SpinBar.TabIndex = 126;
            this.SpinBar.TickFrequency = 10;
            this.SpinBar.Scroll += new System.EventHandler(this.ScrollBar_Scroll);
            // 
            // TurnLbl
            // 
            this.TurnLbl.AutoSize = true;
            this.TurnLbl.Font = Consts.contentFont;
            this.TurnLbl.Location = new System.Drawing.Point(2, 118);
            this.TurnLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TurnLbl.Name = "TurnLbl";
            this.TurnLbl.Size = new System.Drawing.Size(97, 45);
            this.TurnLbl.TabIndex = 125;
            this.TurnLbl.Text = "Turn";
            // 
            // TurnBar
            // 
            this.TurnBar.Location = new System.Drawing.Point(205, 121);
            this.TurnBar.Maximum = 359;
            this.TurnBar.Name = "TurnBar";
            this.TurnBar.Size = new System.Drawing.Size(350, 90);
            this.TurnBar.TabIndex = 124;
            this.TurnBar.TickFrequency = 10;
            this.TurnBar.Scroll += new System.EventHandler(this.ScrollBar_Scroll);
            // 
            // RotationLbl
            // 
            this.RotationLbl.AutoSize = true;
            this.RotationLbl.Font = Consts.contentFont;
            this.RotationLbl.Location = new System.Drawing.Point(2, 0);
            this.RotationLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RotationLbl.Name = "RotationLbl";
            this.RotationLbl.Size = new System.Drawing.Size(155, 45);
            this.RotationLbl.TabIndex = 123;
            this.RotationLbl.Text = "Rotation";
            // 
            // RotationBar
            // 
            this.RotationBar.Location = new System.Drawing.Point(205, 3);
            this.RotationBar.Maximum = 359;
            this.RotationBar.Name = "RotationBar";
            this.RotationBar.Size = new System.Drawing.Size(350, 90);
            this.RotationBar.TabIndex = 122;
            this.RotationBar.TickFrequency = 10;
            this.RotationBar.Scroll += new System.EventHandler(this.ScrollBar_Scroll);
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 2;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.TableLayoutPnl.Controls.Add(this.RotationLbl, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.TurnLbl, 0, 1);
            this.TableLayoutPnl.Controls.Add(this.RotationBar, 1, 0);
            this.TableLayoutPnl.Controls.Add(this.TurnBar, 1, 1);
            this.TableLayoutPnl.Controls.Add(this.SizeBar, 1, 3);
            this.TableLayoutPnl.Controls.Add(this.SizeLbl, 0, 3);
            this.TableLayoutPnl.Controls.Add(this.SpinLbl, 0, 2);
            this.TableLayoutPnl.Controls.Add(this.SpinBar, 1, 2);
            this.TableLayoutPnl.Location = new System.Drawing.Point(33, 168);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 4;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(578, 474);
            this.TableLayoutPnl.TabIndex = 131;
            // 
            // PositionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.PositionsLbl);
            this.Name = "PositionsPanel";
            this.Size = new System.Drawing.Size(804, 1072);
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationBar)).EndInit();
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PositionsLbl;
        private System.Windows.Forms.Label SizeLbl;
        private System.Windows.Forms.TrackBar SizeBar;
        private System.Windows.Forms.Label SpinLbl;
        private System.Windows.Forms.TrackBar SpinBar;
        private System.Windows.Forms.Label TurnLbl;
        private System.Windows.Forms.TrackBar TurnBar;
        private System.Windows.Forms.Label RotationLbl;
        private System.Windows.Forms.TrackBar RotationBar;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
    }
}
