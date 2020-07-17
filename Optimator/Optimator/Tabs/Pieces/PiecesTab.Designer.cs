using System.Windows.Forms;

namespace Optimator
{
    partial class PiecesTab
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PiecesTab));
            this.Panel = new System.Windows.Forms.Panel();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.SaveBtn = new System.Windows.Forms.ToolStripButton();
            this.MovePointBtn = new System.Windows.Forms.ToolStripButton();
            this.CloseBtn = new System.Windows.Forms.ToolStripButton();
            this.OutlineBtn = new System.Windows.Forms.ToolStripButton();
            this.ColoursBtn = new System.Windows.Forms.ToolStripButton();
            this.FixedBtn = new System.Windows.Forms.ToolStripButton();
            this.EraseBtn = new System.Windows.Forms.ToolStripButton();
            this.SketchesBtn = new System.Windows.Forms.ToolStripButton();
            this.HidePointsBtn = new System.Windows.Forms.ToolStripButton();
            this.ReloadBtn = new System.Windows.Forms.ToolStripButton();
            this.PreviewBtn = new System.Windows.Forms.ToolStripButton();
            this.DisplayTimer = new System.Windows.Forms.Timer(this.components);
            this.DrawingLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.TopLbl = new System.Windows.Forms.Label();
            this.DrawBase = new System.Windows.Forms.PictureBox();
            this.DrawDown = new System.Windows.Forms.PictureBox();
            this.DrawRight = new System.Windows.Forms.PictureBox();
            this.FrontLbl = new System.Windows.Forms.Label();
            this.SideLbl = new System.Windows.Forms.Label();
            this.ToolStrip.SuspendLayout();
            this.DrawingLayoutPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRight)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.Azure;
            this.Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel.Location = new System.Drawing.Point(994, 39);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(450, 887);
            this.Panel.TabIndex = 23;
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveBtn,
            this.MovePointBtn,
            this.CloseBtn,
            this.OutlineBtn,
            this.ColoursBtn,
            this.FixedBtn,
            this.EraseBtn,
            this.SketchesBtn,
            this.HidePointsBtn,
            this.ReloadBtn,
            this.PreviewBtn});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip.Size = new System.Drawing.Size(1444, 39);
            this.ToolStrip.TabIndex = 22;
            this.ToolStrip.Text = "ToolStrip";
            // 
            // SaveBtn
            // 
            this.SaveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("SaveBtn.Image")));
            this.SaveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(36, 36);
            this.SaveBtn.Text = "Save";
            this.SaveBtn.Click += new System.EventHandler(this.BtnWithPanel_Click);
            // 
            // MovePointBtn
            // 
            this.MovePointBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MovePointBtn.Image = global::Optimator.Properties.Resources.MoveIcon;
            this.MovePointBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MovePointBtn.Name = "MovePointBtn";
            this.MovePointBtn.Size = new System.Drawing.Size(36, 36);
            this.MovePointBtn.Text = "Move Point";
            this.MovePointBtn.Click += new System.EventHandler(this.BtnWithPanel_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CloseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloseBtn.Image = global::Optimator.Properties.Resources.CloseIcon;
            this.CloseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CloseBtn.Size = new System.Drawing.Size(36, 36);
            this.CloseBtn.Text = "Close";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // OutlineBtn
            // 
            this.OutlineBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OutlineBtn.Image = ((System.Drawing.Image)(resources.GetObject("OutlineBtn.Image")));
            this.OutlineBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OutlineBtn.Name = "OutlineBtn";
            this.OutlineBtn.Size = new System.Drawing.Size(36, 36);
            this.OutlineBtn.Text = "Outline";
            this.OutlineBtn.Click += new System.EventHandler(this.BtnWithPanel_Click);
            // 
            // ColoursBtn
            // 
            this.ColoursBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ColoursBtn.Image = global::Optimator.Properties.Resources.ColourIcon;
            this.ColoursBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ColoursBtn.Name = "ColoursBtn";
            this.ColoursBtn.Size = new System.Drawing.Size(36, 36);
            this.ColoursBtn.Text = "Colours";
            this.ColoursBtn.Click += new System.EventHandler(this.BtnWithPanel_Click);
            // 
            // FixedBtn
            // 
            this.FixedBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FixedBtn.Image = global::Optimator.Properties.Resources.FixedIcon;
            this.FixedBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FixedBtn.Name = "FixedBtn";
            this.FixedBtn.Size = new System.Drawing.Size(36, 36);
            this.FixedBtn.Text = "Fixed Points";
            this.FixedBtn.Click += new System.EventHandler(this.BtnWithPanel_Click);
            // 
            // EraseBtn
            // 
            this.EraseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EraseBtn.Image = global::Optimator.Properties.Resources.EraseIcon;
            this.EraseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EraseBtn.Name = "EraseBtn";
            this.EraseBtn.Size = new System.Drawing.Size(36, 36);
            this.EraseBtn.Text = "Erase";
            this.EraseBtn.Click += new System.EventHandler(this.BtnWithPanel_Click);
            // 
            // SketchesBtn
            // 
            this.SketchesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SketchesBtn.Image = global::Optimator.Properties.Resources.SketchesIcon;
            this.SketchesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SketchesBtn.Name = "SketchesBtn";
            this.SketchesBtn.Size = new System.Drawing.Size(36, 36);
            this.SketchesBtn.Text = "Sketches";
            this.SketchesBtn.Click += new System.EventHandler(this.BtnWithPanel_Click);
            // 
            // HidePointsBtn
            // 
            this.HidePointsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HidePointsBtn.Image = global::Optimator.Properties.Resources.HidePoints01;
            this.HidePointsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HidePointsBtn.Name = "HidePointsBtn";
            this.HidePointsBtn.Size = new System.Drawing.Size(36, 36);
            this.HidePointsBtn.Text = "Hide Points";
            this.HidePointsBtn.Click += new System.EventHandler(this.HidePointsBtn_Click);
            // 
            // ReloadBtn
            // 
            this.ReloadBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReloadBtn.Image = global::Optimator.Properties.Resources.Refresh01;
            this.ReloadBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReloadBtn.Name = "ReloadBtn";
            this.ReloadBtn.Size = new System.Drawing.Size(36, 36);
            this.ReloadBtn.Text = "Reload";
            this.ReloadBtn.Click += new System.EventHandler(this.ReloadBtn_Click);
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PreviewBtn.Image = ((System.Drawing.Image)(resources.GetObject("PreviewBtn.Image")));
            this.PreviewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(36, 36);
            this.PreviewBtn.Text = "Preview";
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // DisplayTimer
            // 
            this.DisplayTimer.Interval = 5;
            this.DisplayTimer.Tick += new System.EventHandler(this.DisplayTimer_Tick);
            // 
            // DrawingLayoutPnl
            // 
            this.DrawingLayoutPnl.ColumnCount = 2;
            this.DrawingLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DrawingLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DrawingLayoutPnl.Controls.Add(this.TopLbl, 0, 2);
            this.DrawingLayoutPnl.Controls.Add(this.DrawBase, 0, 1);
            this.DrawingLayoutPnl.Controls.Add(this.DrawDown, 0, 3);
            this.DrawingLayoutPnl.Controls.Add(this.DrawRight, 1, 1);
            this.DrawingLayoutPnl.Controls.Add(this.FrontLbl, 0, 0);
            this.DrawingLayoutPnl.Controls.Add(this.SideLbl, 1, 0);
            this.DrawingLayoutPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawingLayoutPnl.Location = new System.Drawing.Point(0, 39);
            this.DrawingLayoutPnl.Name = "DrawingLayoutPnl";
            this.DrawingLayoutPnl.Padding = new System.Windows.Forms.Padding(30, 10, 0, 20);
            this.DrawingLayoutPnl.RowCount = 4;
            this.DrawingLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.DrawingLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.DrawingLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.DrawingLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.DrawingLayoutPnl.Size = new System.Drawing.Size(994, 887);
            this.DrawingLayoutPnl.TabIndex = 27;
            // 
            // TopLbl
            // 
            this.TopLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TopLbl.AutoSize = true;
            this.TopLbl.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.TopLbl.Location = new System.Drawing.Point(33, 437);
            this.TopLbl.Name = "TopLbl";
            this.TopLbl.Size = new System.Drawing.Size(99, 42);
            this.TopLbl.TabIndex = 29;
            this.TopLbl.Text = "Top";
            // 
            // DrawBase
            // 
            this.DrawBase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrawBase.Location = new System.Drawing.Point(30, 52);
            this.DrawBase.Margin = new System.Windows.Forms.Padding(0);
            this.DrawBase.Name = "DrawBase";
            this.DrawBase.Size = new System.Drawing.Size(300, 300);
            this.DrawBase.TabIndex = 24;
            this.DrawBase.TabStop = false;
            this.DrawBase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawBoard_MouseDown);
            this.DrawBase.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawBoard_MouseMove);
            this.DrawBase.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawBoard_MouseUp);
            // 
            // DrawDown
            // 
            this.DrawDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrawDown.Location = new System.Drawing.Point(30, 479);
            this.DrawDown.Margin = new System.Windows.Forms.Padding(0);
            this.DrawDown.Name = "DrawDown";
            this.DrawDown.Size = new System.Drawing.Size(300, 300);
            this.DrawDown.TabIndex = 25;
            this.DrawDown.TabStop = false;
            this.DrawDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawBoard_MouseDown);
            this.DrawDown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawBoard_MouseMove);
            this.DrawDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawBoard_MouseUp);
            // 
            // DrawRight
            // 
            this.DrawRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrawRight.Location = new System.Drawing.Point(512, 52);
            this.DrawRight.Margin = new System.Windows.Forms.Padding(0);
            this.DrawRight.Name = "DrawRight";
            this.DrawRight.Size = new System.Drawing.Size(300, 300);
            this.DrawRight.TabIndex = 26;
            this.DrawRight.TabStop = false;
            this.DrawRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawBoard_MouseDown);
            this.DrawRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawBoard_MouseMove);
            this.DrawRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawBoard_MouseUp);
            // 
            // FrontLbl
            // 
            this.FrontLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FrontLbl.AutoSize = true;
            this.FrontLbl.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.FrontLbl.Location = new System.Drawing.Point(33, 10);
            this.FrontLbl.Name = "FrontLbl";
            this.FrontLbl.Size = new System.Drawing.Size(133, 42);
            this.FrontLbl.TabIndex = 27;
            this.FrontLbl.Text = "Front";
            // 
            // SideLbl
            // 
            this.SideLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SideLbl.AutoSize = true;
            this.SideLbl.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.SideLbl.Location = new System.Drawing.Point(515, 10);
            this.SideLbl.Name = "SideLbl";
            this.SideLbl.Size = new System.Drawing.Size(111, 42);
            this.SideLbl.TabIndex = 28;
            this.SideLbl.Text = "Side";
            // 
            // PiecesTab
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Controls.Add(this.DrawingLayoutPnl);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.ToolStrip);
            this.Name = "PiecesTab";
            this.Size = new System.Drawing.Size(1444, 926);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.DrawingLayoutPnl.ResumeLayout(false);
            this.DrawingLayoutPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox DrawRight;
        private System.Windows.Forms.PictureBox DrawDown;
        private System.Windows.Forms.PictureBox DrawBase;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton SaveBtn;
        private System.Windows.Forms.ToolStripButton MovePointBtn;
        private System.Windows.Forms.ToolStripButton PreviewBtn;
        private System.Windows.Forms.ToolStripButton CloseBtn;
        private System.Windows.Forms.ToolStripButton ColoursBtn;
        private System.Windows.Forms.ToolStripButton FixedBtn;
        private System.Windows.Forms.ToolStripButton SketchesBtn;
        private System.Windows.Forms.ToolStripButton EraseBtn;
        private System.Windows.Forms.ToolStripButton OutlineBtn;
        private Timer DisplayTimer;
        private TableLayoutPanel DrawingLayoutPnl;
        private Label TopLbl;
        private Label FrontLbl;
        private Label SideLbl;
        private ToolStripButton HidePointsBtn;
        private ToolStripButton ReloadBtn;
    }
}
