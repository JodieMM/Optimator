namespace Animator
{
    partial class PiecesForm_LoadMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.fillBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.outlineBtn = new System.Windows.Forms.Button();
            this.bothBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.singleTurnedBtn = new System.Windows.Forms.Button();
            this.singleRotatedBtn = new System.Windows.Forms.Button();
            this.singleOriginalBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.singleRotationUpDown = new System.Windows.Forms.NumericUpDown();
            this.singleTurnedUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.singleRotationUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleTurnedUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Colours";
            // 
            // fillBtn
            // 
            this.fillBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fillBtn.Location = new System.Drawing.Point(75, 225);
            this.fillBtn.Name = "fillBtn";
            this.fillBtn.Size = new System.Drawing.Size(183, 58);
            this.fillBtn.TabIndex = 1;
            this.fillBtn.Text = "Fill";
            this.fillBtn.UseVisualStyleBackColor = true;
            this.fillBtn.Click += new System.EventHandler(this.fillBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(533, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 63);
            this.label2.TabIndex = 2;
            this.label2.Text = "Load";
            // 
            // outlineBtn
            // 
            this.outlineBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outlineBtn.Location = new System.Drawing.Point(75, 315);
            this.outlineBtn.Name = "outlineBtn";
            this.outlineBtn.Size = new System.Drawing.Size(183, 58);
            this.outlineBtn.TabIndex = 3;
            this.outlineBtn.Text = "Outline";
            this.outlineBtn.UseVisualStyleBackColor = true;
            this.outlineBtn.Click += new System.EventHandler(this.outlineBtn_Click);
            // 
            // bothBtn
            // 
            this.bothBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bothBtn.Location = new System.Drawing.Point(75, 405);
            this.bothBtn.Name = "bothBtn";
            this.bothBtn.Size = new System.Drawing.Size(183, 58);
            this.bothBtn.TabIndex = 4;
            this.bothBtn.Text = "Both";
            this.bothBtn.UseVisualStyleBackColor = true;
            this.bothBtn.Click += new System.EventHandler(this.bothBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(303, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 44);
            this.label3.TabIndex = 5;
            this.label3.Text = "Single Angle";
            // 
            // singleTurnedBtn
            // 
            this.singleTurnedBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleTurnedBtn.Location = new System.Drawing.Point(326, 472);
            this.singleTurnedBtn.Name = "singleTurnedBtn";
            this.singleTurnedBtn.Size = new System.Drawing.Size(183, 58);
            this.singleTurnedBtn.TabIndex = 8;
            this.singleTurnedBtn.Text = "Turned";
            this.singleTurnedBtn.UseVisualStyleBackColor = true;
            // 
            // singleRotatedBtn
            // 
            this.singleRotatedBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleRotatedBtn.Location = new System.Drawing.Point(326, 408);
            this.singleRotatedBtn.Name = "singleRotatedBtn";
            this.singleRotatedBtn.Size = new System.Drawing.Size(183, 58);
            this.singleRotatedBtn.TabIndex = 7;
            this.singleRotatedBtn.Text = "Rotated";
            this.singleRotatedBtn.UseVisualStyleBackColor = true;
            // 
            // singleOriginalBtn
            // 
            this.singleOriginalBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleOriginalBtn.Location = new System.Drawing.Point(326, 344);
            this.singleOriginalBtn.Name = "singleOriginalBtn";
            this.singleOriginalBtn.Size = new System.Drawing.Size(183, 58);
            this.singleOriginalBtn.TabIndex = 6;
            this.singleOriginalBtn.Text = "Original";
            this.singleOriginalBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(335, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 39);
            this.label4.TabIndex = 9;
            this.label4.Text = "R";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(335, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 39);
            this.label5.TabIndex = 10;
            this.label5.Text = "T";
            // 
            // singleRotationUpDown
            // 
            this.singleRotationUpDown.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleRotationUpDown.Location = new System.Drawing.Point(395, 223);
            this.singleRotationUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.singleRotationUpDown.Name = "singleRotationUpDown";
            this.singleRotationUpDown.Size = new System.Drawing.Size(120, 47);
            this.singleRotationUpDown.TabIndex = 11;
            // 
            // singleTurnedUpDown
            // 
            this.singleTurnedUpDown.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleTurnedUpDown.Location = new System.Drawing.Point(395, 284);
            this.singleTurnedUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.singleTurnedUpDown.Name = "singleTurnedUpDown";
            this.singleTurnedUpDown.Size = new System.Drawing.Size(120, 47);
            this.singleTurnedUpDown.TabIndex = 12;
            // 
            // PiecesForm_LoadMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(1221, 931);
            this.Controls.Add(this.singleTurnedUpDown);
            this.Controls.Add(this.singleRotationUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.singleTurnedBtn);
            this.Controls.Add(this.singleRotatedBtn);
            this.Controls.Add(this.singleOriginalBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bothBtn);
            this.Controls.Add(this.outlineBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fillBtn);
            this.Controls.Add(this.label1);
            this.Name = "PiecesForm_LoadMenu";
            this.ShowIcon = false;
            this.Text = "Load";
            ((System.ComponentModel.ISupportInitialize)(this.singleRotationUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleTurnedUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button fillBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button outlineBtn;
        private System.Windows.Forms.Button bothBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button singleTurnedBtn;
        private System.Windows.Forms.Button singleRotatedBtn;
        private System.Windows.Forms.Button singleOriginalBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown singleRotationUpDown;
        private System.Windows.Forms.NumericUpDown singleTurnedUpDown;
    }
}