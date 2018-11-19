using System;
using System.Collections.Generic;
using System.Drawing;
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
        private int frameIndex = 0;
        private int numFrames = 0;
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
            videoScenes.Add(new Scene(sceneTb.Text));
            numFrames += videoScenes[videoScenes.Count - 1].NumFrames;
        }

        /// <summary>
        /// Previews what the video will look like.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayBtn_Click(object sender, EventArgs e)
        {
            sceneIndex = 0;
            frameIndex = 0;
            videoScenes[sceneIndex].AssignOriginalPositions();
            DrawFrame(videoScenes[sceneIndex], DrawPanel.CreateGraphics(), true);
            AnimationTimer.Start();
        }

        /// <summary>
        /// Exports and saves the video created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save this video?", "Save Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Prepare Save Location
                    string filePath = Environment.CurrentDirectory + "\\Scenes\\" + saveLocationTb.Text;
                    System.IO.Directory.CreateDirectory(filePath);
                    int imageNumber = 1;
                    //System.IO.StreamWriter file = new System.IO.StreamWriter(@filePath);

                    // Save Images
                    for (sceneIndex = 0; sceneIndex < videoScenes.Count; sceneIndex++)
                    {
                        videoScenes[sceneIndex].AssignOriginalPositions();
                        for (frameIndex = 0; frameIndex < videoScenes[sceneIndex].NumFrames; frameIndex++)
                        {
                            Bitmap bitmap = DrawOnBitmap(videoScenes[sceneIndex]);
                            bitmap.Save(filePath + "\\" + imageNumber + ".png", System.Drawing.Imaging.ImageFormat.Png);
                            imageNumber++;
                        }

                    }
                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
                }
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
                if (frameIndex >= change.StartFrame && (frameIndex <= change.StartFrame + change.HowLong - 1))
                {
                    change.Run(true);
                }
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
            frameIndex++;
            if (frameIndex >= videoScenes[sceneIndex].NumFrames)
            {
                sceneIndex++;
                frameIndex = 0;
                if (sceneIndex >= videoScenes.Count)
                {
                    AnimationTimer.Stop();
                }
                else
                {
                    videoScenes[sceneIndex].AssignOriginalPositions();
                    DrawFrame(videoScenes[sceneIndex], this.DrawPanel.CreateGraphics(), true);
                }
            }
            else
            {
                DrawFrame(videoScenes[sceneIndex], this.DrawPanel.CreateGraphics(), true);
            }
        }
    }
}
