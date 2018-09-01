using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Animator
{
    public partial class CompileVideo : Form
    {

        //Initialise Video Variables
        List<Scene> videoScenes = new List<Scene>();
        int sceneIndex = 0;
        int frameIndex = 0;
        int numFrames = 0;
        Graphics g;
        Graphics b;

        public CompileVideo()
        {
            InitializeComponent();
        }

        private void submitScene_Click(object sender, EventArgs e)
        {
            videoScenes.Add(new Scene(sceneTb.Text));
            numFrames += videoScenes[videoScenes.Count - 1].GetNumFrames();
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            sceneIndex = 0;
            frameIndex = 0;
            videoScenes[sceneIndex].AssignOriginalPositions();
            DrawFrame(videoScenes[sceneIndex], this.DrawPanel.CreateGraphics(), true);
            animationTimer.Start();
        }

        private void DrawFrame(Scene baseScene, Graphics g, Boolean refresh)
        {
            // Prepare
            if (refresh) { DrawPanel.Refresh(); }
            List<Piece> piecesList = baseScene.GetPiecesList();

            // Update Pieces
            foreach (Changes change in baseScene.GetChanges())
            {
                if (frameIndex >= change.GetStartFrame() && (frameIndex <= change.GetStartFrame() + change.GetHowLong() - 1))
                {
                    change.Run(true);
                }
            }            

            // Draw Parts
            foreach(Piece piece in baseScene.GetPiecesList())
            {
                Utilities.DrawPiece(piece, g, true);
            }
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            frameIndex++;
            if (frameIndex >= videoScenes[sceneIndex].GetNumFrames())
            {
                sceneIndex++;
                frameIndex = 0;
                if (sceneIndex >= videoScenes.Count)
                {
                    animationTimer.Stop();
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

        private void saveBtn_Click(object sender, EventArgs e)
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
                        for (frameIndex = 0; frameIndex < videoScenes[sceneIndex].GetNumFrames(); frameIndex++)
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

        private Bitmap DrawOnBitmap(Scene toDraw)
        {
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(DrawPanel.Width, DrawPanel.Height);
            g = Graphics.FromImage(bitmap);
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                g.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
            }

            DrawFrame(toDraw, g, false);
            return bitmap;
        }
    }
}
