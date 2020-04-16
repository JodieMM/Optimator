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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PiecesTab));
            this.DrawRight = new System.Windows.Forms.PictureBox();
            this.DrawDown = new System.Windows.Forms.PictureBox();
            this.DrawBase = new System.Windows.Forms.PictureBox();
            this.Panel = new System.Windows.Forms.Panel();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.SaveBtn = new System.Windows.Forms.ToolStripButton();
            this.MovePointBtn = new System.Windows.Forms.ToolStripButton();
            this.CloseBtn = new System.Windows.Forms.ToolStripButton();
            this.ColoursBtn = new System.Windows.Forms.ToolStripButton();
            this.FixedBtn = new System.Windows.Forms.ToolStripButton();
            this.SketchesBtn = new System.Windows.Forms.ToolStripButton();
            this.EraseBtn = new System.Windows.Forms.ToolStripButton();
            this.OutlineBtn = new System.Windows.Forms.ToolStripButton();
            this.PreviewBtn = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.DrawRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawBase)).BeginInit();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawRight
            // 
            this.DrawRight.BackColor = System.Drawing.Color.White; //HIDDEN Settings.BackgroundColour;
            this.DrawRight.Location = new System.Drawing.Point(363, 100);
            this.DrawRight.Margin = new System.Windows.Forms.Padding(6);
            this.DrawRight.Name = "DrawRight";
            this.DrawRight.Size = new System.Drawing.Size(300, 300);
            this.DrawRight.TabIndex = 26;
            this.DrawRight.TabStop = false;
            this.DrawRight.MouseDown += new MouseEventHandler(DrawBoard_MouseDown);
            this.DrawRight.MouseUp += new MouseEventHandler(DrawBoard_MouseUp);
            this.DrawRight.MouseMove += new MouseEventHandler(DrawBoard_MouseMove);
            // 
            // DrawDown
            // 
            this.DrawDown.BackColor = System.Drawing.Color.White;
            this.DrawDown.Location = new System.Drawing.Point(33, 430);
            this.DrawDown.Margin = new System.Windows.Forms.Padding(6);
            this.DrawDown.Name = "DrawDown";
            this.DrawDown.Size = new System.Drawing.Size(300, 300);
            this.DrawDown.TabIndex = 25;
            this.DrawDown.TabStop = false;
            this.DrawDown.MouseDown += new MouseEventHandler(DrawBoard_MouseDown);
            this.DrawDown.MouseUp += new MouseEventHandler(DrawBoard_MouseUp);
            this.DrawDown.MouseMove += new MouseEventHandler(DrawBoard_MouseMove);
            // 
            // DrawBase
            // 
            this.DrawBase.BackColor = System.Drawing.Color.White;
            this.DrawBase.Location = new System.Drawing.Point(33, 100);
            this.DrawBase.Margin = new System.Windows.Forms.Padding(6);
            this.DrawBase.Name = "DrawBase";
            this.DrawBase.Size = new System.Drawing.Size(300, 300);
            this.DrawBase.TabIndex = 24;
            this.DrawBase.TabStop = false;
            this.DrawBase.MouseDown += new MouseEventHandler(DrawBoard_MouseDown);
            this.DrawBase.MouseUp += new MouseEventHandler(DrawBoard_MouseUp);
            this.DrawBase.MouseMove += new MouseEventHandler(DrawBoard_MouseMove);
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
            this.ColoursBtn,
            this.FixedBtn,
            this.SketchesBtn,
            this.EraseBtn,
            this.OutlineBtn,
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
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // MovePointBtn
            // 
            this.MovePointBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MovePointBtn.Image = ((System.Drawing.Image)(resources.GetObject("MovePointBtn.Image")));
            this.MovePointBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MovePointBtn.Name = "MovePointBtn";
            this.MovePointBtn.Size = new System.Drawing.Size(36, 36);
            this.MovePointBtn.Text = "Move Point";
            this.MovePointBtn.Click += new System.EventHandler(this.MovePointBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CloseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloseBtn.Image = ((System.Drawing.Image)(resources.GetObject("CloseBtn.Image")));
            this.CloseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CloseBtn.Size = new System.Drawing.Size(36, 36);
            this.CloseBtn.Text = "Close";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // ColoursBtn
            // 
            this.ColoursBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ColoursBtn.Image = ((System.Drawing.Image)(resources.GetObject("ColoursBtn.Image")));
            this.ColoursBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ColoursBtn.Name = "ColoursBtn";
            this.ColoursBtn.Size = new System.Drawing.Size(36, 36);
            this.ColoursBtn.Text = "Colours";
            this.ColoursBtn.Click += new System.EventHandler(this.ColoursBtn_Click);
            // 
            // FixedBtn
            // 
            this.FixedBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FixedBtn.Image = ((System.Drawing.Image)(resources.GetObject("FixedBtn.Image")));
            this.FixedBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FixedBtn.Name = "FixedBtn";
            this.FixedBtn.Size = new System.Drawing.Size(36, 36);
            this.FixedBtn.Text = "Fixed Points";
            this.FixedBtn.Click += new System.EventHandler(this.FixedBtn_Click);
            // 
            // SketchesBtn
            // 
            this.SketchesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SketchesBtn.Image = ((System.Drawing.Image)(resources.GetObject("SketchesBtn.Image")));
            this.SketchesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SketchesBtn.Name = "SketchesBtn";
            this.SketchesBtn.Size = new System.Drawing.Size(36, 36);
            this.SketchesBtn.Text = "Sketches";
            this.SketchesBtn.Click += new System.EventHandler(this.SketchesBtn_Click);
            // 
            // EraseBtn
            // 
            this.EraseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EraseBtn.Image = ((System.Drawing.Image)(resources.GetObject("EraseBtn.Image")));
            this.EraseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EraseBtn.Name = "EraseBtn";
            this.EraseBtn.Size = new System.Drawing.Size(36, 36);
            this.EraseBtn.Text = "Erase";
            this.EraseBtn.Click += new System.EventHandler(this.EraseBtn_Click);
            // 
            // OutlineBtn
            // 
            this.OutlineBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OutlineBtn.Image = ((System.Drawing.Image)(resources.GetObject("OutlineBtn.Image")));
            this.OutlineBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OutlineBtn.Name = "OutlineBtn";
            this.OutlineBtn.Size = new System.Drawing.Size(36, 36);
            this.OutlineBtn.Text = "Outline";
            this.OutlineBtn.Click += new System.EventHandler(this.OutlineBtn_Click);
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
            // PiecesTab
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Controls.Add(this.DrawRight);
            this.Controls.Add(this.DrawDown);
            this.Controls.Add(this.DrawBase);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.ToolStrip);
            this.Name = "PiecesTab";
            this.Size = new System.Drawing.Size(1444, 926);
            ((System.ComponentModel.ISupportInitialize)(this.DrawRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawBase)).EndInit();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
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
    }
}
