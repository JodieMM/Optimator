namespace Optimator.Forms.Compile
{
    partial class AddScenePanel
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
            this.AddTb = new System.Windows.Forms.TextBox();
            this.AddSceneLbl = new System.Windows.Forms.Label();
            this.TableLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.PlayBtn = new System.Windows.Forms.Button();
            this.SubmitScene = new System.Windows.Forms.Button();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddTb
            // 
            this.AddTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddTb.BackColor = System.Drawing.Color.White;
            this.AddTb.Font = Consts.contentFont;
            this.AddTb.Location = new System.Drawing.Point(12, 12);
            this.AddTb.Margin = new System.Windows.Forms.Padding(12);
            this.AddTb.Name = "AddTb";
            this.AddTb.Size = new System.Drawing.Size(483, 65);
            this.AddTb.TabIndex = 6;
            this.AddTb.Text = "Scene Name";
            // 
            // AddSceneLbl
            // 
            this.AddSceneLbl.AutoSize = true;
            this.AddSceneLbl.Font = Consts.headingLblFont;
            this.AddSceneLbl.Location = new System.Drawing.Point(34, 46);
            this.AddSceneLbl.Name = "AddSceneLbl";
            this.AddSceneLbl.Size = new System.Drawing.Size(293, 71);
            this.AddSceneLbl.TabIndex = 84;
            this.AddSceneLbl.Text = "Add Scene";
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 1;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPnl.Controls.Add(this.PlayBtn, 0, 2);
            this.TableLayoutPnl.Controls.Add(this.AddTb, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.SubmitScene, 0, 1);
            this.TableLayoutPnl.Location = new System.Drawing.Point(44, 172);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 3;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(507, 284);
            this.TableLayoutPnl.TabIndex = 85;
            // 
            // PlayBtn
            // 
            this.PlayBtn.BackColor = System.Drawing.Color.Salmon;
            this.PlayBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayBtn.Font = Consts.contentFont;
            this.PlayBtn.Location = new System.Drawing.Point(2, 190);
            this.PlayBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(503, 92);
            this.PlayBtn.TabIndex = 87;
            this.PlayBtn.Text = "Play";
            this.PlayBtn.UseVisualStyleBackColor = false;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // SubmitScene
            // 
            this.SubmitScene.BackColor = System.Drawing.Color.Salmon;
            this.SubmitScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubmitScene.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitScene.Font = Consts.contentFont;
            this.SubmitScene.Location = new System.Drawing.Point(2, 96);
            this.SubmitScene.Margin = new System.Windows.Forms.Padding(2);
            this.SubmitScene.Name = "SubmitScene";
            this.SubmitScene.Size = new System.Drawing.Size(503, 90);
            this.SubmitScene.TabIndex = 86;
            this.SubmitScene.Text = "Get Scene";
            this.SubmitScene.UseVisualStyleBackColor = false;
            this.SubmitScene.Click += new System.EventHandler(this.SubmitScene_Click);
            // 
            // AddScenePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TableLayoutPnl);
            this.Controls.Add(this.AddSceneLbl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddScenePanel";
            this.Size = new System.Drawing.Size(620, 527);
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AddTb;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Label AddSceneLbl;
        private System.Windows.Forms.Button PlayBtn;
        private System.Windows.Forms.Button SubmitScene;
    }
}
