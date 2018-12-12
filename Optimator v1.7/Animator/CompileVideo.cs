using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Animator
{
    /// <summary>
    /// The form used to combine scenes into a single video
    /// and export in a video file type.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class CompileVideo : Form
    {
        #region Video Variables
        private List<Scene> videoScenes = new List<Scene>();
        private int sceneIndex = 0;
        private decimal workingTime = 0;

        private Graphics g;
        private Color backgroundColor = Color.White;
        #endregion


        /// <summary>
        /// Form constructor.
        /// </summary>
        public CompileVideo()
        {
            InitializeComponent();
        }



        // ----- OPTIONS BUTTONS -----

        /// <summary>
        /// Adds the entered scene into the video.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitScene_Click(object sender, EventArgs e)
        {
            videoScenes.Add(new Scene(SceneTb.Text));
        }

        /// <summary>
        /// Previews what the video will look like.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayBtn_Click(object sender, EventArgs e)
        {
            sceneIndex = 0;
            workingTime = 0;
            DrawFrame(videoScenes[0]);
            AnimationTimer.Start();
        }

        /// <summary>
        /// Closes the form without saving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            // If nothing to save, exit without confirmation
            if (videoScenes.Count == 0)
            {
                Close();
            }
            else
            {
                DialogResult query = MessageBox.Show("Do you wish to exit without saving?", "Exit Confirmation", MessageBoxButtons.YesNo);
                if (query == DialogResult.Yes)
                {
                    Close();
                }
            }
        }

        /// <summary>
        /// Exports and saves the video created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!Constants.PermittedName.IsMatch(NameTb.Text))
            {
                MessageBox.Show("Please choose a valid name for your video. Name can only include letters and numbers.", "Name Invalid", MessageBoxButtons.OK);
                return;
            }

            // Check name not already in use, or that overriding is okay
            if (Directory.Exists(Utilities.GetDirectory(Constants.VideosFolder, NameTb.Text)))
            {
                DialogResult result = MessageBox.Show("This name is already in use. Do you want to override the existing video?", "Override Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) { return; }
            }

            // Save Video and Close Form
            try
            {
                // Prepare Save Location
                Directory.CreateDirectory(Utilities.GetDirectory(Constants.VideosFolder, NameTb.Text));

                // Save Images
                int numFrames = 0;
                decimal timeIncrement = 1 / FpsUpDown.Value;
                for (sceneIndex = 0; sceneIndex < videoScenes.Count; sceneIndex++)
                {
                    for (workingTime = 0; workingTime <= videoScenes[sceneIndex].TimeLength; workingTime += timeIncrement)
                    {
                        Bitmap bitmap = DrawOnBitmap();
                        bitmap.Save(Utilities.GetDirectory(Constants.VideosFolder, NameTb.Text, numFrames.ToString(), Constants.Png), System.Drawing.Imaging.ImageFormat.Png);
                        numFrames++;
                    }
                }
                Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No data entered for point", "Missing Data", MessageBoxButtons.OK);
            }
        }



        // ----- SETTINGS TAB -----

        /// <summary>
        /// Hides or shows the preview panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewCb_CheckedChanged(object sender, EventArgs e)
        {
            DisplayPanel.Visible = PreviewCb.Checked;
        }



        // ----- DRAWING FUNCTIONS -----

        /// <summary>
        /// Draws a frame to a bitmap.
        /// </summary>
        /// <param name="baseScene">The frame to draw</param>
        /// <param name="g">The graphics to display with</param>
        private void DrawFrame(Scene baseScene, Graphics g)
        {
            baseScene.RunScene(workingTime);      

            // Draw Parts
            foreach(Piece piece in baseScene.PiecesList)
            {
                Utilities.DrawPiece(piece, g, true);
            }
        }

        /// <summary>
        /// Draws a frame to the display.
        /// </summary>
        /// <param name="baseScene">The frame to draw</param>
        /// <param name="g">The graphics to display with</param>
        private void DrawFrame(Scene baseScene)
        {
            DrawPanel.Refresh();
            g = DrawPanel.CreateGraphics();
            baseScene.RunScene(workingTime);

            // Draw Parts
            foreach (Piece piece in baseScene.PiecesList)
            {
                Utilities.DrawPiece(piece, g, true);
            }
        }

        /// <summary>
        /// Draws the graphics created on a bitmap for exporting.
        /// </summary>
        /// <param name="toDraw">Scene to be drawn</param>
        /// <returns></returns>
        private Bitmap DrawOnBitmap()
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
    }
}
