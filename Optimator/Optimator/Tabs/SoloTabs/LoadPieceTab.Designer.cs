namespace Animator.Tabs.SoloTabs
{
    partial class LoadPieceTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadPieceTab));
            this.LoadSetBtn = new System.Windows.Forms.Button();
            this.SketchBtn = new System.Windows.Forms.Button();
            this.AllBtn = new System.Windows.Forms.Button();
            this.OutlineWidthBtn = new System.Windows.Forms.Button();
            this.PieceDetailsBtn = new System.Windows.Forms.Button();
            this.ShapeBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.OutlineColourBtn = new System.Windows.Forms.Button();
            this.LoadPieceBtn = new System.Windows.Forms.Button();
            this.NameTb = new System.Windows.Forms.TextBox();
            this.FillColourBtn = new System.Windows.Forms.Button();
            this.DrawPanel = new System.Windows.Forms.PictureBox();
            this.LoadLbl = new System.Windows.Forms.Label();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.CloseBtn = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).BeginInit();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadSetBtn
            // 
            this.LoadSetBtn.BackColor = System.Drawing.Color.LightPink;
            this.LoadSetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadSetBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadSetBtn.Location = new System.Drawing.Point(511, 165);
            this.LoadSetBtn.Name = "LoadSetBtn";
            this.LoadSetBtn.Size = new System.Drawing.Size(95, 33);
            this.LoadSetBtn.TabIndex = 38;
            this.LoadSetBtn.Text = "Set";
            this.LoadSetBtn.UseVisualStyleBackColor = false;
            this.LoadSetBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // SketchBtn
            // 
            this.SketchBtn.BackColor = System.Drawing.Color.LightPink;
            this.SketchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SketchBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SketchBtn.Location = new System.Drawing.Point(406, 448);
            this.SketchBtn.Name = "SketchBtn";
            this.SketchBtn.Size = new System.Drawing.Size(95, 70);
            this.SketchBtn.TabIndex = 37;
            this.SketchBtn.Text = "Sketch";
            this.SketchBtn.UseVisualStyleBackColor = false;
            this.SketchBtn.Click += new System.EventHandler(this.ToggleButton);
            // 
            // AllBtn
            // 
            this.AllBtn.BackColor = System.Drawing.Color.LightPink;
            this.AllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AllBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllBtn.Location = new System.Drawing.Point(511, 372);
            this.AllBtn.Name = "AllBtn";
            this.AllBtn.Size = new System.Drawing.Size(95, 70);
            this.AllBtn.TabIndex = 36;
            this.AllBtn.Text = "All";
            this.AllBtn.UseVisualStyleBackColor = false;
            this.AllBtn.Click += new System.EventHandler(this.AllBtn_Click);
            // 
            // OutlineWidthBtn
            // 
            this.OutlineWidthBtn.BackColor = System.Drawing.Color.LightPink;
            this.OutlineWidthBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutlineWidthBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutlineWidthBtn.Location = new System.Drawing.Point(406, 295);
            this.OutlineWidthBtn.Name = "OutlineWidthBtn";
            this.OutlineWidthBtn.Size = new System.Drawing.Size(95, 70);
            this.OutlineWidthBtn.TabIndex = 35;
            this.OutlineWidthBtn.Text = "Outline Width";
            this.OutlineWidthBtn.UseVisualStyleBackColor = false;
            this.OutlineWidthBtn.Click += new System.EventHandler(this.ToggleButton);
            // 
            // PieceDetailsBtn
            // 
            this.PieceDetailsBtn.BackColor = System.Drawing.Color.LightPink;
            this.PieceDetailsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PieceDetailsBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PieceDetailsBtn.Location = new System.Drawing.Point(511, 295);
            this.PieceDetailsBtn.Name = "PieceDetailsBtn";
            this.PieceDetailsBtn.Size = new System.Drawing.Size(95, 70);
            this.PieceDetailsBtn.TabIndex = 34;
            this.PieceDetailsBtn.Text = "Piece Details";
            this.PieceDetailsBtn.UseVisualStyleBackColor = false;
            this.PieceDetailsBtn.Click += new System.EventHandler(this.ToggleButton);
            // 
            // ShapeBtn
            // 
            this.ShapeBtn.BackColor = System.Drawing.Color.LightPink;
            this.ShapeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShapeBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShapeBtn.Location = new System.Drawing.Point(406, 372);
            this.ShapeBtn.Name = "ShapeBtn";
            this.ShapeBtn.Size = new System.Drawing.Size(95, 70);
            this.ShapeBtn.TabIndex = 33;
            this.ShapeBtn.Text = "Shape";
            this.ShapeBtn.UseVisualStyleBackColor = false;
            this.ShapeBtn.Click += new System.EventHandler(this.ToggleButton);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.LightPink;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.Location = new System.Drawing.Point(511, 448);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(95, 70);
            this.ExitBtn.TabIndex = 32;
            this.ExitBtn.Text = "Done";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // OutlineColourBtn
            // 
            this.OutlineColourBtn.BackColor = System.Drawing.Color.LightPink;
            this.OutlineColourBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutlineColourBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutlineColourBtn.Location = new System.Drawing.Point(511, 218);
            this.OutlineColourBtn.Name = "OutlineColourBtn";
            this.OutlineColourBtn.Size = new System.Drawing.Size(95, 70);
            this.OutlineColourBtn.TabIndex = 31;
            this.OutlineColourBtn.Text = "Outline Colour";
            this.OutlineColourBtn.UseVisualStyleBackColor = false;
            this.OutlineColourBtn.Click += new System.EventHandler(this.ToggleButton);
            // 
            // LoadPieceBtn
            // 
            this.LoadPieceBtn.BackColor = System.Drawing.Color.LightPink;
            this.LoadPieceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadPieceBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadPieceBtn.Location = new System.Drawing.Point(406, 165);
            this.LoadPieceBtn.Name = "LoadPieceBtn";
            this.LoadPieceBtn.Size = new System.Drawing.Size(95, 33);
            this.LoadPieceBtn.TabIndex = 26;
            this.LoadPieceBtn.Text = "Piece";
            this.LoadPieceBtn.UseVisualStyleBackColor = false;
            this.LoadPieceBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // NameTb
            // 
            this.NameTb.BackColor = System.Drawing.Color.White;
            this.NameTb.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTb.Location = new System.Drawing.Point(176, 165);
            this.NameTb.Margin = new System.Windows.Forms.Padding(6);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(210, 58);
            this.NameTb.TabIndex = 30;
            this.NameTb.Text = "Part Name";
            // 
            // FillColourBtn
            // 
            this.FillColourBtn.BackColor = System.Drawing.Color.LightPink;
            this.FillColourBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FillColourBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FillColourBtn.Location = new System.Drawing.Point(406, 218);
            this.FillColourBtn.Name = "FillColourBtn";
            this.FillColourBtn.Size = new System.Drawing.Size(95, 70);
            this.FillColourBtn.TabIndex = 29;
            this.FillColourBtn.Text = "Fill Colour";
            this.FillColourBtn.UseVisualStyleBackColor = false;
            this.FillColourBtn.Click += new System.EventHandler(this.ToggleButton);
            // 
            // DrawPanel
            // 
            this.DrawPanel.BackColor = System.Drawing.Color.White;
            this.DrawPanel.Location = new System.Drawing.Point(86, 218);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(300, 300);
            this.DrawPanel.TabIndex = 28;
            this.DrawPanel.TabStop = false;
            // 
            // LoadLbl
            // 
            this.LoadLbl.AutoSize = true;
            this.LoadLbl.Font = new System.Drawing.Font("Tahoma", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadLbl.Location = new System.Drawing.Point(78, 163);
            this.LoadLbl.Name = "LoadLbl";
            this.LoadLbl.Size = new System.Drawing.Size(140, 64);
            this.LoadLbl.TabIndex = 27;
            this.LoadLbl.Text = "Load";
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseBtn});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip.Size = new System.Drawing.Size(1932, 39);
            this.ToolStrip.TabIndex = 39;
            this.ToolStrip.Text = "ToolStrip";
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
            // LoadPieceTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.LoadSetBtn);
            this.Controls.Add(this.SketchBtn);
            this.Controls.Add(this.AllBtn);
            this.Controls.Add(this.OutlineWidthBtn);
            this.Controls.Add(this.PieceDetailsBtn);
            this.Controls.Add(this.ShapeBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.OutlineColourBtn);
            this.Controls.Add(this.LoadPieceBtn);
            this.Controls.Add(this.NameTb);
            this.Controls.Add(this.FillColourBtn);
            this.Controls.Add(this.DrawPanel);
            this.Controls.Add(this.LoadLbl);
            this.Name = "LoadPieceTab";
            this.Size = new System.Drawing.Size(1932, 1176);
            ((System.ComponentModel.ISupportInitialize)(this.DrawPanel)).EndInit();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadSetBtn;
        private System.Windows.Forms.Button SketchBtn;
        private System.Windows.Forms.Button AllBtn;
        private System.Windows.Forms.Button OutlineWidthBtn;
        private System.Windows.Forms.Button PieceDetailsBtn;
        private System.Windows.Forms.Button ShapeBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button OutlineColourBtn;
        private System.Windows.Forms.Button LoadPieceBtn;
        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.Button FillColourBtn;
        private System.Windows.Forms.PictureBox DrawPanel;
        private System.Windows.Forms.Label LoadLbl;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton CloseBtn;
    }
}
