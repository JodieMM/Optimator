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
            DrawFrame(videoScenes[sceneIndex]);
            animationTimer.Start();
        }

        private void DrawFrame(Scene baseScene)
        {
            // Prepare
            DrawPanel.Refresh();
            g = this.DrawPanel.CreateGraphics();
            List<string> partsList = baseScene.GetPartsList();
            List<Piece> piecesList = baseScene.GetPiecesList();
            List<Set> setList = baseScene.GetSetList();

            // Update Parts
            foreach (string[] change in baseScene.GetChanges())
            {
                if (frameIndex >= int.Parse(change[0]) && (frameIndex <= int.Parse(change[0]) + int.Parse(change[4]) - 1))
                {
                    if (change[2].StartsWith("p"))
                    {
                        Piece holdPiece = piecesList[int.Parse(change[2].Remove(0, 2))];
                        if (change[1] == "X")
                        {
                            holdPiece.SetX(holdPiece.GetCoords()[0] + int.Parse(change[3]));
                        }
                        else if (change[1] == "Y")
                        {
                            holdPiece.SetY(holdPiece.GetCoords()[1] + int.Parse(change[3]));
                        }
                        else if (change[1] == "Rotation")
                        {
                            holdPiece.SetRotation((int)holdPiece.GetAngles()[0] + int.Parse(change[3]));
                        }
                        else if (change[1] == "Turn")
                        {
                            holdPiece.SetTurn((int)holdPiece.GetAngles()[1] + int.Parse(change[3]));
                        }
                        else if (change[1] == "Spin")
                        {
                            holdPiece.SetSpin((int)holdPiece.GetAngles()[2] + int.Parse(change[3]));
                        }
                        else if (change[1] == "Size")
                        {
                            holdPiece.SetSizeMod(holdPiece.GetSizeMod() + int.Parse(change[3]));
                        }
                        // Add other options ** TO DO **
                    }
                    else
                    {
                        /*
                        Piece holdPiece = setList[int.Parse(change[2].Remove(0, 2))].GetBasePiece();
                        Set holdSet = setList[int.Parse(change[2].Remove(0, 2))];
                        if (change[1] == "Spin")
                        {
                            holdSet.UpdateSubpieces("Spin", (int)holdPiece.GetAngles()[2] + int.Parse(change[3]));
                        }
                        else if (change[1] == "Size")
                        {
                            holdSet.UpdateSubpieces("Size", holdPiece.GetSizeMod() + int.Parse(change[3]));
                        }
                        // UPDATE FOR SET ** TO DO **/
                    }
                }
            }            

            // Draw Parts
            foreach (string part in partsList)
            {
                if (part.StartsWith("p"))
                {
                    Utilities.DrawPiece(piecesList[int.Parse(part.Remove(0, 2))], g, true);
                }
                else
                {
                    //DrawSet(setList[int.Parse(part.Remove(0, 2))]);
                }
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
                    DrawFrame(videoScenes[sceneIndex]);
                }
            }
            else
            {
                DrawFrame(videoScenes[sceneIndex]);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Boolean doEet = true;
            DialogResult result = MessageBox.Show("Do you want to save this video?", "Save Confirmation", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                doEet = false;
            }
            if (doEet)
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
            DrawFrameBitmap(toDraw);
            return bitmap;
        }

        private void DrawFrameBitmap(Scene baseScene)
        {
            // Prepare
            List<string> partsList = baseScene.GetPartsList();
            List<Piece> piecesList = baseScene.GetPiecesList();
            List<Set> setList = baseScene.GetSetList();

            // Update Parts
            foreach (string[] change in baseScene.GetChanges())
            {
                if (frameIndex >= int.Parse(change[0]) && (frameIndex <= int.Parse(change[0]) + int.Parse(change[4]) - 1))
                {
                    if (change[2].StartsWith("p"))
                    {
                        Piece holdPiece = piecesList[int.Parse(change[2].Remove(0, 2))];
                        if (change[1] == "X")
                        {
                            holdPiece.SetX(holdPiece.GetCoords()[0] + int.Parse(change[3]));
                        }
                        else if (change[1] == "Y")
                        {
                            holdPiece.SetY(holdPiece.GetCoords()[1] + int.Parse(change[3]));
                        }
                        else if (change[1] == "Rotation")
                        {
                            holdPiece.SetRotation((int)holdPiece.GetAngles()[0] + int.Parse(change[3]));
                        }
                        else if (change[1] == "Turn")
                        {
                            holdPiece.SetTurn((int)holdPiece.GetAngles()[1] + int.Parse(change[3]));
                        }
                        else if (change[1] == "Spin")
                        {
                            holdPiece.SetSpin((int)holdPiece.GetAngles()[2] + int.Parse(change[3]));
                        }
                        else if (change[1] == "Size")
                        {
                            holdPiece.SetSizeMod(holdPiece.GetSizeMod() + int.Parse(change[3]));
                        }
                        // Add other options ** TO DO **
                    }
                    else
                    {
                        // UPDATE FOR SET ** TO DO **
                    }
                }
            }

            // Draw Parts
            foreach (string part in partsList)
            {
                if (part.StartsWith("p"))
                {
                    Utilities.DrawPiece(piecesList[int.Parse(part.Remove(0, 2))], g, true);
                }
                else
                {
                    //DrawSetBitmap(setList[int.Parse(part.Remove(0, 2))]);
                }
            }
        }

        
    }
}
