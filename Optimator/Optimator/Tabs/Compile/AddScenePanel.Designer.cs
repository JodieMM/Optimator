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
            this.SubmitScene = new System.Windows.Forms.Button();
            this.TableLayoutPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddTb
            // 
            this.AddTb.BackColor = System.Drawing.Color.White;
            this.AddTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddTb.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.AddTb.Location = new System.Drawing.Point(0, 0);
            this.AddTb.Margin = new System.Windows.Forms.Padding(0);
            this.AddTb.Name = "AddTb";
            this.AddTb.Size = new System.Drawing.Size(507, 64);
            this.AddTb.TabIndex = 6;
            this.AddTb.Text = "Scene Name";
            // 
            // AddSceneLbl
            // 
            this.AddSceneLbl.AutoSize = true;
            this.AddSceneLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.AddSceneLbl.Location = new System.Drawing.Point(34, 46);
            this.AddSceneLbl.Name = "AddSceneLbl";
            this.AddSceneLbl.Size = new System.Drawing.Size(296, 72);
            this.AddSceneLbl.TabIndex = 84;
            this.AddSceneLbl.Text = "Add Scene";
            // 
            // TableLayoutPnl
            // 
            this.TableLayoutPnl.ColumnCount = 1;
            this.TableLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPnl.Controls.Add(this.AddTb, 0, 0);
            this.TableLayoutPnl.Controls.Add(this.SubmitScene, 0, 1);
            this.TableLayoutPnl.Location = new System.Drawing.Point(44, 172);
            this.TableLayoutPnl.Name = "TableLayoutPnl";
            this.TableLayoutPnl.RowCount = 2;
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPnl.Size = new System.Drawing.Size(507, 260);
            this.TableLayoutPnl.TabIndex = 85;
            // 
            // SubmitScene
            // 
            this.SubmitScene.BackColor = System.Drawing.Color.Salmon;
            this.SubmitScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubmitScene.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitScene.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.SubmitScene.Location = new System.Drawing.Point(2, 132);
            this.SubmitScene.Margin = new System.Windows.Forms.Padding(2);
            this.SubmitScene.Name = "SubmitScene";
            this.SubmitScene.Size = new System.Drawing.Size(503, 126);
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
            this.Size = new System.Drawing.Size(620, 913);
            this.TableLayoutPnl.ResumeLayout(false);
            this.TableLayoutPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AddTb;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPnl;
        private System.Windows.Forms.Label AddSceneLbl;
        private System.Windows.Forms.Button SubmitScene;
    }
}
