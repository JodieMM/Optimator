using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Optimator.Forms.Compile;

namespace Optimator.Tabs.Compile
{
    /// <summary>
    /// A tab page for creating and modifying scenes.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class CompileTab : TabPageControl
    {
        #region Video Variables
        public override HomeForm Owner { get; set; }

        public List<Scene> videoScenes = new List<Scene>();
        public int sceneIndex = 0;
        public decimal workingTime = 0;

        private Graphics g;
        private Color backgroundColor = Color.White;

        public decimal FPS = 60;
        public bool PreviewOn = true;
        #endregion
        


        /// <summary>
        /// Constructor for the tab.
        /// </summary>
        public CompileTab(HomeForm owner)
        {
            InitializeComponent();
            Owner = owner;
        }



        // ----- GETTERS & SETTERS -----

        /// <summary>
        /// Finds visibility of display panel.
        /// </summary>
        /// <returns>True if panel visible</returns>
        public bool GetPreviewVisible()
        {
            return DisplayPanel.Visible;
        }

        /// <summary>
        /// Shows or hides the display panel.
        /// </summary>
        /// <param name="visible">False if panel invisible</param>
        public void ShowPreview(bool visible = true)
        {
            DisplayPanel.Visible = visible;
        }

        /// <summary>
        /// Shows the loading message.
        /// </summary>
        /// <param name="show">False if hiding the message</param>
        public void ShowLoadingMessage(bool show = true)
        {
            LoadingMessage.Visible = show;
            if (show)
            {
                LoadingMessage.Location = new Point((int)((Width - LoadingMessage.Width) / 2.0),
                (int)((Height - LoadingMessage.Height) / 2.0));
            }
        }



        // ----- FORM FUNCTIONS -----

        public override void Resize()
        {
            float widthPercent = 0.75F;
            float heightPercent = 0.75F;

            int bigWidth = (int)(Width * widthPercent);
            int bigHeight = (int)((Height - ToolStrip.Height) * heightPercent);
            int fraction = (bigWidth / 16.0) > (bigHeight / 9.0) ? (int)(bigHeight / 9.0) : (int)(bigWidth / 16.0);

            DrawPanel.Size = new Size(fraction * 16, fraction * 9);
            DrawPanel.Location = new Point((int)((bigWidth - DrawPanel.Width ) / 2.0), 
                (int)((bigHeight - DrawPanel.Height) / 2.0 + ToolStrip.Height));

            Panel.Width = Width - bigWidth;
            DisplayPanel.Height = Height - bigHeight - ToolStrip.Height;

            int panelWidth = (int)(UpArrowImg.Parent.Width / 4.0);
            UpArrowImg.Location = new Point((int)(2 * panelWidth + (panelWidth - UpArrowImg.Width / 2.0)),
                (int)((UpArrowImg.Parent.Height - UpArrowImg.Height) / 2.0));

            //TODO: Display panel for compile tab
            //if (Width < 1140)
            //{
            //    CurrentTimeLbl.Text = "Now";
            //    VidLengthLbl.Text = ConvertTimeToText();
            //}
            //else
            //{
            //    CurrentTimeLbl.Text = "Current Time";
            //    VidLengthLbl.Text = "Video Length: " + ConvertTimeToText();
            //}
        }

        #region ToolStrip

        /// <summary>
        /// Unchecks all of the checkable buttons and checks the provided one.
        /// </summary>
        private void SelectButton(ToolStripButton btn)
        {
            bool check = btn.Checked;
            SaveBtn.Checked = false;
            AddSceneBtn.Checked = false;
            SettingsBtn.Checked = false;
            btn.Checked = !check;
        }

        /// <summary>
        /// Opens the Save panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!SaveBtn.Checked)
            {
                Utils.NewPanelContent(Panel, new SavePanel(this));
            }
            SelectButton(SaveBtn);
        }

        /// <summary>
        /// Opens the Add Scene panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSceneBtn_Click(object sender, EventArgs e)
        {
            if (!AddSceneBtn.Checked)
            {
                Utils.NewPanelContent(Panel, new AddScenePanel(this));
            }
            SelectButton(AddSceneBtn);
        }

        /// <summary>
        /// Opens the Settings panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            if (!SettingsBtn.Checked)
            {
                Utils.NewPanelContent(Panel, new SettingsPanel(this));
            }
            SelectButton(SettingsBtn);
        }

        /// <summary>
        /// Closes this tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public new void CloseBtn_Click(object sender, EventArgs e)
        {
            if (Utils.ExitBtn_Click(videoScenes.Count > 0))
            {
                Owner.RemoveTabPage(this);
            }
        }

        #endregion



        // --- DISPLAY PANEL ---

        //TODO: Display Panel for CompileTab



        // ----- DRAWING FUNCTIONS -----

        /// <summary>
        /// Draws a frame to a bitmap.
        /// </summary>
        /// <param name="baseScene">The frame to draw</param>
        /// <param name="g">The graphics to display with</param>
        public void DrawFrame(Scene baseScene, Graphics g = null)
        {
            if (g == null)
            {
                DrawPanel.Refresh();
                g = DrawPanel.CreateGraphics();
            }
            baseScene.RunScene(workingTime);

            // Draw Parts
            foreach (Part part in baseScene.PartsList)
            {
                part.Draw(g);
            }
        }

        /// <summary>
        /// Draws the graphics created on a bitmap for exporting.
        /// </summary>
        /// <returns>Bitmap of current scene view</returns>
        public Bitmap DrawOnBitmap()
        {
            Bitmap bitmap = new Bitmap(DrawPanel.Width, DrawPanel.Height);
            g = Graphics.FromImage(bitmap);
            using (SolidBrush brush = new SolidBrush(backgroundColor))
            {
                g.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
            }

            DrawFrame(videoScenes[sceneIndex], g);
            return bitmap;
        }



        // ----- ANIMATION FUNCTIONS -----

        /// <summary>
        /// Updates the video by a frame.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (++workingTime > videoScenes[sceneIndex].TimeLength)
            {
                if (++sceneIndex >= videoScenes.Count)
                {
                    AnimationTimer.Stop();
                    return;
                }
                workingTime = 0;
            }
            DrawFrame(videoScenes[sceneIndex]);
        }

        /// <summary>
        /// Starts the animation timer.
        /// </summary>
        public void StartTimer()
        {
            AnimationTimer.Start();
        }
    }
}
