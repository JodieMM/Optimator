using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
        private decimal sceneLength = 0;
        private Graphics g;
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
            sceneLength += videoScenes[videoScenes.Count - 1].TimeLength;
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
            videoScenes[sceneIndex].AssignOriginalPositions();
            DrawFrame(videoScenes[sceneIndex], DrawPanel.CreateGraphics(), true);
            AnimationTimer.Start();
        }

        /// <summary>
        /// Closes the form without saving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
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
            DialogResult result = DialogResult.Yes;
            if (File.Exists(Utilities.GetDirectory(Constants.VideosFolder, NameTb.Text)))
            {
                result = MessageBox.Show("This name is already in use. Do you want to override the existing video?", "Override Confirmation", MessageBoxButtons.YesNo);
            }
            if (result == DialogResult.No) { return; }

            // Save Video and Close Form
            try
            {
                // Prepare Save Location
                string filePath = Environment.CurrentDirectory + Constants.VideosFolder + NameTb.Text;
                Directory.CreateDirectory(filePath);
                StreamWriter file = new StreamWriter(@filePath);

                // Save Images
                for (sceneIndex = 0; sceneIndex < videoScenes.Count; sceneIndex++)
                {
                    videoScenes[sceneIndex].AssignOriginalPositions();
                    for (workingTime = 0; workingTime < videoScenes[sceneIndex].TimeLength; workingTime++)
                    {
                        Bitmap bitmap = DrawOnBitmap(videoScenes[sceneIndex]);
                        bitmap.Save(filePath + "\\" + (workingTime + 1) + Constants.Png, System.Drawing.Imaging.ImageFormat.Png);
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



        // ----- DRAWING FUNCTIONS -----

        /// <summary>
        /// Draws a frame to the display.
        /// </summary>
        /// <param name="baseScene">The frame to draw</param>
        /// <param name="g">The graphics to display with</param>
        /// <param name="refresh">Whether the drawing panel should be cleared first</param>
        private void DrawFrame(Scene baseScene, Graphics g, bool refresh)
        {
            // Prepare
            if (refresh) { DrawPanel.Refresh(); }
            List<Piece> piecesList = baseScene.PiecesList;

            // Update Pieces
            foreach (Change change in baseScene.Changes)
            {
                change.Run(true, workingTime);
            }            

            // Draw Parts
            foreach(Piece piece in baseScene.PiecesList)
            {
                Utilities.DrawPiece(piece, g, true);
            }
        }    

        /// <summary>
        /// Draws the graphics created on a bitmap for exporting.
        /// </summary>
        /// <param name="toDraw">Scene to be drawn</param>
        /// <returns></returns>
        private Bitmap DrawOnBitmap(Scene toDraw)
        {
            Bitmap bitmap = new Bitmap(DrawPanel.Width, DrawPanel.Height);
            g = Graphics.FromImage(bitmap);
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                g.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
            }

            DrawFrame(toDraw, g, false);
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
            workingTime++;
            if (workingTime >= videoScenes[sceneIndex].TimeLength)
            {
                sceneIndex++;
                workingTime = 0;
                if (sceneIndex >= videoScenes.Count)
                {
                    AnimationTimer.Stop();
                }
                else
                {
                    videoScenes[sceneIndex].AssignOriginalPositions();
                    DrawFrame(videoScenes[sceneIndex], DrawPanel.CreateGraphics(), true);
                }
            }
            else
            {
                DrawFrame(videoScenes[sceneIndex], DrawPanel.CreateGraphics(), true);
            }
        }
    }
}
