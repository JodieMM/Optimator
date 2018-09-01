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

        private void DrawPiece(Piece currentPiece)
        {
            // Initialise
            string[] lineArray = currentPiece.GetLineArray((int)currentPiece.GetAngles()[0], (int)currentPiece.GetAngles()[1]);

            // Find correct row of piece data
            int row = currentPiece.FindRow((int)currentPiece.GetAngles()[0], (int)currentPiece.GetAngles()[1]);
            List<string> data = currentPiece.GetData();

            // Draw if data row is found
            if (row != -1)
            {
                // Prepare Colours
                string colourType = currentPiece.GetColourType();
                int colourIndex = 0;
                Color[] colourArray = currentPiece.GetColourArray();

                double[,] pointsArray = currentPiece.GetCurrentPoints(true, true);


                // Fill
                int fillIndex = 0;
                Boolean endShape = false;
                while (fillIndex < pointsArray.Length / 2 - 1)
                {
                    GraphicsPath path = new GraphicsPath();
                    while (!endShape && fillIndex < pointsArray.Length / 2 - 1)
                    {
                        if (lineArray[fillIndex] == "line")
                        {
                            path.AddLine(new Point((int)pointsArray[fillIndex, 0], (int)pointsArray[fillIndex, 1]), new Point((int)pointsArray[fillIndex + 1, 0], (int)pointsArray[fillIndex + 1, 1]));
                        }
                        else if (fillIndex != 0 && lineArray[fillIndex - 1].StartsWith("curve"))
                        {
                            decimal tension = decimal.Parse(lineArray[fillIndex - 1].Remove(0, 5));
                            // Find number of points in curve
                            int numCurves = 2;
                            Boolean endCurve = false;
                            Boolean finishesAtStart = false;
                            while (!endCurve && fillIndex < pointsArray.Length / 2)
                            {
                                if (lineArray[fillIndex] == "contcurve" && fillIndex == pointsArray.Length / 2 - 1)
                                {
                                    finishesAtStart = true;
                                    numCurves++;
                                    fillIndex++;
                                }
                                else if (lineArray[fillIndex] == "contcurve")
                                {
                                    numCurves++;
                                    fillIndex++;
                                }
                                else
                                {
                                    endCurve = true;
                                }
                            }
                            // Add points to curve
                            Point[] thePoints = new Point[numCurves];
                            for (int curveIndex = 0; curveIndex < numCurves; curveIndex++)
                            {
                                if (finishesAtStart && curveIndex == numCurves - 1)
                                {
                                    thePoints[curveIndex] = new Point((int)pointsArray[0, 0], (int)pointsArray[0, 1]);
                                }
                                else
                                {
                                    thePoints[curveIndex] = new Point((int)pointsArray[fillIndex - (numCurves - 1 - curveIndex), 0], (int)pointsArray[fillIndex - (numCurves - 1 - curveIndex), 1]);
                                }
                            }
                            // Draw Curve
                            path.AddCurve(thePoints, (float)tension);
                        }
                        else
                        {
                            endShape = true;
                        }
                        fillIndex++;
                    }
                    // Final Line
                    if (fillIndex < pointsArray.Length / 2 && lineArray[lineArray.Count() - 1] == "line")
                    {
                        path.AddLine(new Point((int)pointsArray[fillIndex, 0], (int)pointsArray[fillIndex, 1]), new Point((int)pointsArray[0, 0], (int)pointsArray[0, 1]));
                    }

                    endShape = false;
                    // Fill
                    if (int.Parse(colourType.Split(new Char[] { ':' })[1]) == 1)
                    {
                        SolidBrush fill = new SolidBrush(colourArray[colourIndex]);
                        g.FillPath(fill, path);
                    }
                    else if (int.Parse(colourType.Split(new Char[] { ':' })[1]) > 1)    //** GRADIENTS **
                    {
                        SolidBrush fill = new SolidBrush(colourArray[colourIndex]);
                        g.FillPath(fill, path);
                    }
                }
                // Update Colour Index
                if (int.Parse(colourType.Split(new Char[] { ':' })[1]) == 1)
                {
                    colourIndex++;
                }
                else if (int.Parse(colourType.Split(new Char[] { ':' })[1]) > 1)    //** GRADIENTS **
                {
                    colourIndex++;
                }

                // Outline
                if (colourType.StartsWith("y"))
                {
                    // Select draw outline
                    Pen outline = new Pen(colourArray[colourIndex], currentPiece.GetOutlineWidth());

                    // Draw
                    for (int index = 0; index < pointsArray.Length / 2 - 1; index++)
                    {
                        if (lineArray[index] == "line")
                        {
                            g.DrawLine(outline, new Point((int)pointsArray[index, 0], (int)pointsArray[index, 1]), new Point((int)pointsArray[index + 1, 0], (int)pointsArray[index + 1, 1]));
                        }
                        else if (index != 0 && lineArray[index - 1].StartsWith("curve"))
                        {
                            decimal tension = decimal.Parse(lineArray[index - 1].Remove(0, 5));
                            // Find number of points in curve
                            int numCurves = 2;
                            Boolean endCurve = false;
                            Boolean finishesAtStart = false;
                            while (!endCurve && index < pointsArray.Length / 2)
                            {
                                if (lineArray[index] == "contcurve" && index == pointsArray.Length / 2 - 1)
                                {
                                    finishesAtStart = true;
                                    numCurves++;
                                    index++;
                                }
                                else if (lineArray[index] == "contcurve")
                                {
                                    numCurves++;
                                    index++;
                                }
                                else
                                {
                                    endCurve = true;
                                }
                            }
                            // Add points to curve
                            Point[] thePoints = new Point[numCurves];
                            for (int curveIndex = 0; curveIndex < numCurves; curveIndex++)
                            {
                                if (finishesAtStart && curveIndex == numCurves - 1)
                                {
                                    thePoints[curveIndex] = new Point((int)pointsArray[0, 0], (int)pointsArray[0, 1]);
                                }
                                else
                                {
                                    thePoints[curveIndex] = new Point((int)pointsArray[index - (numCurves - 1 - curveIndex), 0], (int)pointsArray[index - (numCurves - 1 - curveIndex), 1]);
                                }
                            }
                            // Draw Curve
                            g.DrawCurve(outline, thePoints, (float)tension);
                        }
                    }
                    if (lineArray[pointsArray.Length / 2 - 1] == "line")
                    {
                        g.DrawLine(outline, new Point((int)pointsArray[lineArray.Length - 1, 0], (int)pointsArray[lineArray.Length - 1, 1]), new Point((int)pointsArray[0, 0], (int)pointsArray[0, 1]));
                    }
                }
            }
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
                        // UPDATE FOR SET ** TO DO **
                    }
                }
            }            

            // Draw Parts
            foreach (string part in partsList)
            {
                if (part.StartsWith("p"))
                {
                    DrawPiece(piecesList[int.Parse(part.Remove(0,2))]);
                }
                else
                {
                    DrawSet(setList[int.Parse(part.Remove(0, 2))]);
                }
            }
        }

        private void DrawSet(Set theSet)
        {
            // Update Set
            theSet.UpdateConnections();
            // Draw Pieces in Set
            for (int index = 0; index < theSet.GetPartOrder().Count; index++)
            {
                if (theSet.GetPartOrder()[index].StartsWith("p") && theSet.GetBasePiece() == theSet.GetPiecesList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))])
                {
                    // Draw basepiece
                    DrawPiece(theSet.GetPiecesList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))]);
                }
                else if (theSet.GetPartOrder()[index].StartsWith("s") && theSet.GetBasePiece() == theSet.GetSetsList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))].GetBasePiece())
                {
                    // Draw baseset
                    DrawSet(theSet.GetSetsList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))]);
                }
                else if (theSet.GetPartOrder()[index].StartsWith("p"))
                {
                    // Draw piece
                    // Alter duplicate piece to fit base
                    Piece workingWithPiece = theSet.GetPiecesList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))];
                    Piece alteredPiece = new Piece(workingWithPiece.GetName());
                    alteredPiece.SetX(workingWithPiece.GetCoords()[0]);
                    alteredPiece.SetY(workingWithPiece.GetCoords()[1]);
                    alteredPiece.SetRotation((int)workingWithPiece.GetAngles()[0]);
                    alteredPiece.SetTurn((int)workingWithPiece.GetAngles()[1]);
                    alteredPiece.SetSpin((int)workingWithPiece.GetAngles()[2]);
                    alteredPiece.SetSizeMod((int)workingWithPiece.GetSizeMod());
                    // Draw duplicate piece
                    DrawPiece(alteredPiece);
                }
                else if (theSet.GetPartOrder()[index].StartsWith("s"))
                {
                    // Draw set
                    DrawSet(theSet.GetSetsList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))]);
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

        private void DrawPieceBitmap(Piece currentPiece)
        {
            // Initialise
            string[] lineArray = currentPiece.GetLineArray((int)currentPiece.GetAngles()[0], (int)currentPiece.GetAngles()[1]);

            // Find correct row of piece data
            int row = currentPiece.FindRow((int)currentPiece.GetAngles()[0], (int)currentPiece.GetAngles()[1]);
            List<string> data = currentPiece.GetData();

            // Draw if data row is found
            if (row != -1)
            {
                // Prepare Colours
                string colourType = currentPiece.GetColourType();
                int colourIndex = 0;
                Color[] colourArray = currentPiece.GetColourArray();

                double[,] pointsArray = currentPiece.GetCurrentPoints(true, true);


                // Fill
                int fillIndex = 0;
                Boolean endShape = false;
                while (fillIndex < pointsArray.Length / 2 - 1)
                {
                    GraphicsPath path = new GraphicsPath();
                    while (!endShape && fillIndex < pointsArray.Length / 2 - 1)
                    {
                        if (lineArray[fillIndex] == "line")
                        {
                            path.AddLine(new Point((int)pointsArray[fillIndex, 0], (int)pointsArray[fillIndex, 1]), new Point((int)pointsArray[fillIndex + 1, 0], (int)pointsArray[fillIndex + 1, 1]));
                        }
                        else if (fillIndex != 0 && lineArray[fillIndex - 1].StartsWith("curve"))
                        {
                            decimal tension = decimal.Parse(lineArray[fillIndex - 1].Remove(0, 5));
                            // Find number of points in curve
                            int numCurves = 2;
                            Boolean endCurve = false;
                            Boolean finishesAtStart = false;
                            while (!endCurve && fillIndex < pointsArray.Length / 2)
                            {
                                if (lineArray[fillIndex] == "contcurve" && fillIndex == pointsArray.Length / 2 - 1)
                                {
                                    finishesAtStart = true;
                                    numCurves++;
                                    fillIndex++;
                                }
                                else if (lineArray[fillIndex] == "contcurve")
                                {
                                    numCurves++;
                                    fillIndex++;
                                }
                                else
                                {
                                    endCurve = true;
                                }
                            }
                            // Add points to curve
                            Point[] thePoints = new Point[numCurves];
                            for (int curveIndex = 0; curveIndex < numCurves; curveIndex++)
                            {
                                if (finishesAtStart && curveIndex == numCurves - 1)
                                {
                                    thePoints[curveIndex] = new Point((int)pointsArray[0, 0], (int)pointsArray[0, 1]);
                                }
                                else
                                {
                                    thePoints[curveIndex] = new Point((int)pointsArray[fillIndex - (numCurves - 1 - curveIndex), 0], (int)pointsArray[fillIndex - (numCurves - 1 - curveIndex), 1]);
                                }
                            }
                            // Draw Curve
                            path.AddCurve(thePoints, (float)tension);
                        }
                        else
                        {
                            endShape = true;
                        }
                        fillIndex++;
                    }
                    // Final Line
                    if (fillIndex < pointsArray.Length / 2 && lineArray[lineArray.Count() - 1] == "line")
                    {
                        path.AddLine(new Point((int)pointsArray[fillIndex, 0], (int)pointsArray[fillIndex, 1]), new Point((int)pointsArray[0, 0], (int)pointsArray[0, 1]));
                    }

                    endShape = false;
                    // Fill
                    if (int.Parse(colourType.Split(new Char[] { ':' })[1]) == 1)
                    {
                        SolidBrush fill = new SolidBrush(colourArray[colourIndex]);
                        g.FillPath(fill, path);
                    }
                    else if (int.Parse(colourType.Split(new Char[] { ':' })[1]) > 1)    //** GRADIENTS **
                    {
                        SolidBrush fill = new SolidBrush(colourArray[colourIndex]);
                        g.FillPath(fill, path);
                    }
                }
                // Update Colour Index
                if (int.Parse(colourType.Split(new Char[] { ':' })[1]) == 1)
                {
                    colourIndex++;
                }
                else if (int.Parse(colourType.Split(new Char[] { ':' })[1]) > 1)    //** GRADIENTS **
                {
                    colourIndex++;
                }

                // Outline
                if (colourType.StartsWith("y"))
                {
                    // Select draw outline
                    Pen outline = new Pen(colourArray[colourIndex], currentPiece.GetOutlineWidth());

                    // Draw
                    for (int index = 0; index < pointsArray.Length / 2 - 1; index++)
                    {
                        if (lineArray[index] == "line")
                        {
                            g.DrawLine(outline, new Point((int)pointsArray[index, 0], (int)pointsArray[index, 1]), new Point((int)pointsArray[index + 1, 0], (int)pointsArray[index + 1, 1]));
                        }
                        else if (index != 0 && lineArray[index - 1].StartsWith("curve"))
                        {
                            decimal tension = decimal.Parse(lineArray[index - 1].Remove(0, 5));
                            // Find number of points in curve
                            int numCurves = 2;
                            Boolean endCurve = false;
                            Boolean finishesAtStart = false;
                            while (!endCurve && index < pointsArray.Length / 2)
                            {
                                if (lineArray[index] == "contcurve" && index == pointsArray.Length / 2 - 1)
                                {
                                    finishesAtStart = true;
                                    numCurves++;
                                    index++;
                                }
                                else if (lineArray[index] == "contcurve")
                                {
                                    numCurves++;
                                    index++;
                                }
                                else
                                {
                                    endCurve = true;
                                }
                            }
                            // Add points to curve
                            Point[] thePoints = new Point[numCurves];
                            for (int curveIndex = 0; curveIndex < numCurves; curveIndex++)
                            {
                                if (finishesAtStart && curveIndex == numCurves - 1)
                                {
                                    thePoints[curveIndex] = new Point((int)pointsArray[0, 0], (int)pointsArray[0, 1]);
                                }
                                else
                                {
                                    thePoints[curveIndex] = new Point((int)pointsArray[index - (numCurves - 1 - curveIndex), 0], (int)pointsArray[index - (numCurves - 1 - curveIndex), 1]);
                                }
                            }
                            // Draw Curve
                            g.DrawCurve(outline, thePoints, (float)tension);
                        }
                    }
                    if (lineArray[pointsArray.Length / 2 - 1] == "line")
                    {
                        g.DrawLine(outline, new Point((int)pointsArray[lineArray.Length - 1, 0], (int)pointsArray[lineArray.Length - 1, 1]), new Point((int)pointsArray[0, 0], (int)pointsArray[0, 1]));
                    }
                }
            }
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
                    DrawPieceBitmap(piecesList[int.Parse(part.Remove(0, 2))]);
                }
                else
                {
                    DrawSetBitmap(setList[int.Parse(part.Remove(0, 2))]);
                }
            }
        }

        private void DrawSetBitmap(Set theSet)
        {
            // Update Set
            theSet.UpdateConnections();
            // Draw Pieces in Set
            for (int index = 0; index < theSet.GetPartOrder().Count; index++)
            {
                if (theSet.GetPartOrder()[index].StartsWith("p") && theSet.GetBasePiece() == theSet.GetPiecesList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))])
                {
                    // Draw basepiece
                    DrawPieceBitmap(theSet.GetPiecesList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))]);
                }
                else if (theSet.GetPartOrder()[index].StartsWith("s") && theSet.GetBasePiece() == theSet.GetSetsList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))].GetBasePiece())
                {
                    // Draw baseset
                    DrawSetBitmap(theSet.GetSetsList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))]);
                }
                else if (theSet.GetPartOrder()[index].StartsWith("p"))
                {
                    // Draw piece
                    // Alter duplicate piece to fit base
                    Piece workingWithPiece = theSet.GetPiecesList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))];
                    Piece alteredPiece = new Piece(workingWithPiece.GetName());
                    alteredPiece.SetX(workingWithPiece.GetCoords()[0]);
                    alteredPiece.SetY(workingWithPiece.GetCoords()[1]);
                    alteredPiece.SetRotation((int)workingWithPiece.GetAngles()[0]);
                    alteredPiece.SetTurn((int)workingWithPiece.GetAngles()[1]);
                    alteredPiece.SetSpin((int)workingWithPiece.GetAngles()[2]);
                    alteredPiece.SetSizeMod((int)workingWithPiece.GetSizeMod());
                    // Draw duplicate piece
                    DrawPieceBitmap(alteredPiece);
                }
                else if (theSet.GetPartOrder()[index].StartsWith("s"))
                {
                    // Draw set
                    DrawSetBitmap(theSet.GetSetsList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))]);
                }
            }
        }
    }
}
