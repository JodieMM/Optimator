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
    public partial class SetsForm : Form
    {
        Graphics g;
        List<Piece> partsList = new List<Piece>();  //** UPDATE TO STRING**
        List<Piece> piecesList = new List<Piece>();
        List<Set> setList = new List<Set>();
        List<string[]> piecesPoints = new List<string[]>();
        List<string[]> piecesData = new List<string[]>();
        // [0] xMin [1] xMax    [2] yMin    [3] yMax    [4] rotMin  [5] rotMax 
        // [6] turnMin  [7] turnMax [8] spinMin [9] spinMax [10] sizeMin    [11] sizeMax
        // [12] initRot [13] initTurn   [14] initSpin   [15] initSize
        Piece basePiece;


        public SetsForm()
        {
            InitializeComponent();
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            if (basePiece != null && !(partsLb.SelectedIndex != -1 && partsList[partsLb.SelectedIndex] == basePiece && baseCb.Checked == false))
            {
                Boolean doEet = true;
                DialogResult result = MessageBox.Show("Do you want to save this set?", "Save Confirmation", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    doEet = false;
                }

                // Save Piece
                if (doEet)
                {
                    // Save Initialisers
                    string filePath = Environment.CurrentDirectory + "\\Parts\\" + NameTb.Text + ".txt";
                    System.IO.StreamWriter file = new System.IO.StreamWriter(@filePath);

                    // Save Data
                    file.WriteLine("set");
                    for (int index = 0; index < partsList.Count; index++)
                    {
                        string save = "";
                        if (partsList[index] == basePiece)
                        {
                            if (piecesList.Contains(partsList[index]))
                            {
                                save += "piecebase;";
                                save += partsList[index].GetName() + ";" + piecesPoints[index][0] + ":" + piecesPoints[index][1] + ";";
                            }
                            else
                            {
                                save += "setbase;";
                                // Find Set Index
                                Boolean isSet = false;
                                int setIndex = 0;
                                while (!isSet && setIndex < setList.Count)
                                {
                                    if (setList[setIndex].GetBasePiece() == partsList[index])
                                    {
                                        isSet = true;
                                    }
                                    else
                                    {
                                        setIndex++;
                                    }
                                }
                                save += setList[setIndex].GetName() + ";" + piecesPoints[index][0] + ":" + piecesPoints[index][1] + ";";
                            }
                        }
                        else
                        {
                            if (piecesList.Contains(partsList[index]))
                            {
                                save += "piece;";
                                save += partsList[index].GetName() + ";" + piecesPoints[index][0] + ":" + piecesPoints[index][1] + ";";
                            }
                            else
                            {
                                save += "set;";
                                // Find Set Index
                                Boolean isSet = false;
                                int setIndex = 0;
                                while (!isSet && setIndex < setList.Count)
                                {
                                    if (setList[setIndex].GetBasePiece() == partsList[index])
                                    {
                                        isSet = true;
                                    }
                                    else
                                    {
                                        setIndex++;
                                    }
                                }
                                save += setList[setIndex].GetName() + ";" + piecesPoints[index][0] + ":" + piecesPoints[index][1] + ";";
                            }
                        }
                        
                        for (int pdIndex = 0; pdIndex < 12; pdIndex++)
                        {
                            save += piecesData[index][pdIndex] + ";";
                        }
                        save += piecesData[index][12] + ";" + piecesData[index][13] + ";" + piecesData[index][14] + ";" + piecesData[index][15];
                        file.WriteLine(save);
                    }

                    file.Close();

                    // Close Pieces Form
                    this.Close();
                }
                else
                {
                    DialogResult query = MessageBox.Show("Do you wish to exit without saving?", "Exit Confirmation", MessageBoxButtons.YesNo);
                    if (query == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("No base assigned", "Save Error", MessageBoxButtons.OK);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                setList.Add(new Set(addTb.Text));
                if (!setList[setList.Count - 1].CheckSet())
                {
                    setList.RemoveAt(setList.Count - 1);
                    piecesList.Add(new Piece(addTb.Text));
                    partsList.Add(piecesList[piecesList.Count - 1]);
                    partsLb.Items.Add(addTb.Text);
                }
                else
                {
                    partsList.Add(setList[setList.Count - 1].GetBasePiece());
                    partsLb.Items.Add(addTb.Text);
                }
                piecesPoints.Add(new string[] { "", "" });
                piecesData.Add(new string[] { "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "s", "0", "0", "0", "100" });
                DrawParts();
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Suspected outdated file.", "File Indexing Error", MessageBoxButtons.OK);
            }
        }

        private void DrawParts()
        {
            // Prepare
            DrawPanel.Refresh();
            g = this.DrawPanel.CreateGraphics();

            // Draw Parts
            for (int partIndex = 0; partIndex < partsList.Count; partIndex++)
            {
                if (piecesList.Contains(partsList[partIndex]))
                {
                    DrawPiece(partsList[partIndex]);
                }
                else
                {
                    Boolean found = false;
                    int theIndex = 0;
                    while (!found)
                    {
                        if (partsList[partIndex] == setList[theIndex].GetBasePiece())
                        {
                            found = true;
                            DrawSet(setList[theIndex]);
                        }
                        else
                        {
                            theIndex++;
                        }
                    }
                }
            }
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
                if (colourType.StartsWith("y") || currentPiece == partsList[partsLb.SelectedIndex])
                {
                    // Selected item has red outline, otherwise draw outline
                    Pen outline;
                    if (partsLb.SelectedIndex != -1 && currentPiece == partsList[partsLb.SelectedIndex])
                    {
                        outline = new Pen(Color.Red, currentPiece.GetOutlineWidth());
                    }
                    else        // If has outline but not selected
                    {
                        outline = new Pen(colourArray[colourIndex], currentPiece.GetOutlineWidth());
                    }

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

        private void DrawSet(Set theSet)
        {
            // Draw Pieces in Set
            for (int index = 0; index < theSet.GetPartOrder().Count; index++)
            {
                if (theSet.GetPartOrder()[index].StartsWith("p") && theSet.GetBasePiece() == theSet.GetPiecesList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))])
                {
                    // Draw
                    DrawPiece(theSet.GetPiecesList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))]);
                }
                else if (theSet.GetPartOrder()[index].StartsWith("p"))
                {
                    // Alter duplicate piece to fit base
                    Piece workingWithPiece = theSet.GetPiecesList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))];
                    Piece alteredPiece = new Piece(workingWithPiece.GetName());
                    alteredPiece.SetX(workingWithPiece.GetCoords()[0]);
                    alteredPiece.SetY(workingWithPiece.GetCoords()[1]);
                    alteredPiece.SetRotation((int)workingWithPiece.GetAngles()[0]);
                    alteredPiece.SetTurn((int)workingWithPiece.GetAngles()[1]);
                    alteredPiece.SetSpin((int)workingWithPiece.GetAngles()[2]);
                    alteredPiece.SetSizeMod((int)workingWithPiece.GetSizeMod());
                    UpdateConnections(alteredPiece, theSet, index);
                    // Draw duplicate piece
                    DrawPiece(alteredPiece);
                }
                else if (theSet.GetPartOrder()[index].StartsWith("s"))
                {
                    DrawSet(theSet.GetSetsList()[int.Parse(theSet.GetPartOrder()[index].Remove(0, 2))]);
                }
            }
        }

        private void UpdateConnections(Piece toModify, Set from, int setLine)
        {
            double[] newCoords = from.GetPointPositions(from.GetData()[setLine + 1].Split(new Char[] { ';' })[2].Split(new Char[] { ':' })[0],
                from.GetData()[setLine + 1].Split(new Char[] { ';' })[2].Split(new Char[] { ':' })[1], toModify);
            toModify.SetX(newCoords[0]);
            toModify.SetY(newCoords[1]);
        }

        private void partsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                // Assign Values to Match
                // BaseBtn
                if (partsList[partsLb.SelectedIndex] == basePiece)
                {
                    baseCb.Checked = true;
                    baseCb_CheckedChanged(sender, e);
                }
                else
                {
                    baseCb.Checked = false;
                    baseCb_CheckedChanged(sender, e);
                }
                // Textboxes
                basePointTb.Text = piecesPoints[partsLb.SelectedIndex][0];
                joinPointTb.Text = piecesPoints[partsLb.SelectedIndex][1];
                // X
                if (piecesData[partsLb.SelectedIndex][0] == "s")
                {
                    xCb.Checked = false;
                    xCb_CheckedChanged(sender, e);
                    xMin.Value = 0;
                    xMax.Value = 0;
                }
                else
                {
                    xCb.Checked = true;
                    xCb_CheckedChanged(sender, e);
                    xMin.Value = int.Parse(piecesData[partsLb.SelectedIndex][0]);
                    xMax.Value = int.Parse(piecesData[partsLb.SelectedIndex][1]);
                }
                // Y
                if (piecesData[partsLb.SelectedIndex][2] == "s")
                {
                    yCb.Checked = false;
                    yCb_CheckedChanged(sender, e);
                    yMin.Value = 0;
                    yMax.Value = 0;
                }
                else
                {
                    yCb.Checked = true;
                    yCb_CheckedChanged(sender, e);
                    yMin.Value = int.Parse(piecesData[partsLb.SelectedIndex][2]);
                    yMax.Value = int.Parse(piecesData[partsLb.SelectedIndex][3]);
                }
                // Rotation
                if (piecesData[partsLb.SelectedIndex][4] == "s")
                {
                    RotateCb.Checked = false;
                    RotateCb_CheckedChanged(sender, e);
                    rotMin.Value = 0;
                    rotMax.Value = 0;
                }
                else
                {
                    RotateCb.Checked = true;
                    RotateCb_CheckedChanged(sender, e);
                    rotMin.Value = int.Parse(piecesData[partsLb.SelectedIndex][4]);
                    rotMax.Value = int.Parse(piecesData[partsLb.SelectedIndex][5]);
                }
                // Turn
                if (piecesData[partsLb.SelectedIndex][6] == "s")
                {
                    turnCb.Checked = false;
                    turnCb_CheckedChanged(sender, e);
                    turnMin.Value = 0;
                    turnMax.Value = 0;
                }
                else
                {
                    turnCb.Checked = true;
                    turnCb_CheckedChanged(sender, e);
                    turnMin.Value = int.Parse(piecesData[partsLb.SelectedIndex][6]);
                    turnMax.Value = int.Parse(piecesData[partsLb.SelectedIndex][7]);
                }
                // Spin
                if (piecesData[partsLb.SelectedIndex][8] == "s")
                {
                    spinCb.Checked = false;
                    spinCb_CheckedChanged(sender, e);
                    spinMin.Value = 0;
                    spinMax.Value = 0;
                }
                else
                {
                    spinCb.Checked = true;
                    spinCb_CheckedChanged(sender, e);
                    spinMin.Value = int.Parse(piecesData[partsLb.SelectedIndex][8]);
                    spinMax.Value = int.Parse(piecesData[partsLb.SelectedIndex][9]);
                }
                // Size
                if (piecesData[partsLb.SelectedIndex][10] == "s")
                {
                    sizeCb.Checked = false;
                    sizeCb_CheckedChanged(sender, e);
                    sizeMin.Value = 0;
                    sizeMax.Value = 0;
                }
                else
                {
                    sizeCb.Checked = true;
                    sizeCb_CheckedChanged(sender, e);
                    sizeMin.Value = int.Parse(piecesData[partsLb.SelectedIndex][10]);
                    sizeMax.Value = int.Parse(piecesData[partsLb.SelectedIndex][11]);
                }
                //Inits
                rotInitUpDown.Value = int.Parse(piecesData[partsLb.SelectedIndex][12]);
                turnInitUpDown.Value = int.Parse(piecesData[partsLb.SelectedIndex][13]);
                spinInitUpDown.Value = int.Parse(piecesData[partsLb.SelectedIndex][14]);
                sizeInitUpDown.Value = int.Parse(piecesData[partsLb.SelectedIndex][15]);
            }
            try
            {
                DrawParts();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Suspected outdated file.", "File Indexing Error", MessageBoxButtons.OK);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int holdIndex = partsLb.SelectedIndex;
            if (partsLb.SelectedIndex != -1)
            {
                // Reset Basepiece if Needed
                if (partsList[holdIndex] == basePiece)
                {
                    basePiece = null;
                }
                // Check if Set
                Boolean isSet = false;
                int setIndex = 0;
                while (!isSet && setIndex < setList.Count)
                {
                    if (setList[setIndex].GetBasePiece() == partsList[holdIndex])
                    {
                        isSet = true;
                    }
                    else
                    {
                        setIndex++;
                    }
                }

                // Remove Piece
                if (isSet)
                {
                    setList.RemoveAt(setIndex);
                }
                else
                {
                    piecesList.Remove(partsList[holdIndex]);
                }
                partsList.RemoveAt(holdIndex);
                piecesPoints.RemoveAt(holdIndex);
                piecesData.RemoveAt(holdIndex);
                partsLb.Items.RemoveAt(holdIndex);
                DrawParts();
            }
        }

        private void xCb_CheckedChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (xCb.Checked == true)
                {
                    xMin.Enabled = true;
                    xMax.Enabled = true;
                    if (piecesData[partsLb.SelectedIndex][0] == "s")
                    {
                        xMin.Value = 0;
                        piecesData[partsLb.SelectedIndex][0] = "0";
                        xMax.Value = 0;
                        piecesData[partsLb.SelectedIndex][1] = "0";
                    }
                    else
                    {
                        xMin.Value = int.Parse(piecesData[partsLb.SelectedIndex][0]);
                        xMax.Value = int.Parse(piecesData[partsLb.SelectedIndex][1]);
                    }
                }
                else
                {
                    xMin.Enabled = false;
                    xMax.Enabled = false;
                    piecesData[partsLb.SelectedIndex][0] = "s";
                    piecesData[partsLb.SelectedIndex][1] = "s";
                }
            }
        }

        private void yCb_CheckedChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (yCb.Checked == true)
                {
                    yMin.Enabled = true;
                    yMax.Enabled = true;
                    if (piecesData[partsLb.SelectedIndex][2] == "s")
                    {
                        yMin.Value = 0;
                        piecesData[partsLb.SelectedIndex][2] = "0";
                        yMax.Value = 0;
                        piecesData[partsLb.SelectedIndex][3] = "0";
                    }
                    else
                    {
                        yMin.Value = int.Parse(piecesData[partsLb.SelectedIndex][2]);
                        yMax.Value = int.Parse(piecesData[partsLb.SelectedIndex][3]);
                    }
                }
                else
                {
                    yMin.Enabled = false;
                    yMax.Enabled = false;
                    piecesData[partsLb.SelectedIndex][2] = "s";
                    piecesData[partsLb.SelectedIndex][3] = "s";
                }
            }
        }

        private void RotateCb_CheckedChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (RotateCb.Checked == true)
                {
                    rotMin.Enabled = true;
                    rotMax.Enabled = true;
                    if (piecesData[partsLb.SelectedIndex][4] == "s")
                    {
                        rotMin.Value = 0;
                        piecesData[partsLb.SelectedIndex][4] = "0";
                        rotMax.Value = 0;
                        piecesData[partsLb.SelectedIndex][5] = "0";
                    }
                    else
                    {
                        rotMin.Value = int.Parse(piecesData[partsLb.SelectedIndex][4]);
                        rotMax.Value = int.Parse(piecesData[partsLb.SelectedIndex][5]);
                    }
                }
                else
                {
                    rotMin.Enabled = false;
                    rotMax.Enabled = false;
                    piecesData[partsLb.SelectedIndex][4] = "s";
                    piecesData[partsLb.SelectedIndex][5] = "s";
                }
            }
        }

        private void turnCb_CheckedChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (turnCb.Checked == true)
                {
                    turnMin.Enabled = true;
                    turnMax.Enabled = true;
                    if (piecesData[partsLb.SelectedIndex][6] == "s")
                    {
                        turnMin.Value = 0;
                        piecesData[partsLb.SelectedIndex][6] = "0";
                        turnMax.Value = 0;
                        piecesData[partsLb.SelectedIndex][7] = "0";
                    }
                    else
                    {
                        turnMin.Value = int.Parse(piecesData[partsLb.SelectedIndex][6]);
                        turnMax.Value = int.Parse(piecesData[partsLb.SelectedIndex][7]);
                    }
                }
                else
                {
                    turnMin.Enabled = false;
                    turnMax.Enabled = false;
                    piecesData[partsLb.SelectedIndex][6] = "s";
                    piecesData[partsLb.SelectedIndex][7] = "s";
                }
            }
        }

        private void spinCb_CheckedChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (spinCb.Checked == true)
                {
                    spinMin.Enabled = true;
                    spinMax.Enabled = true;
                    if (piecesData[partsLb.SelectedIndex][8] == "s")
                    {
                        spinMin.Value = 0;
                        piecesData[partsLb.SelectedIndex][8] = "0";
                        spinMax.Value = 0;
                        piecesData[partsLb.SelectedIndex][9] = "0";
                    }
                    else
                    {
                        spinMin.Value = int.Parse(piecesData[partsLb.SelectedIndex][8]);
                        spinMax.Value = int.Parse(piecesData[partsLb.SelectedIndex][9]);
                    }
                }
                else
                {
                    spinMin.Enabled = false;
                    spinMax.Enabled = false;
                    piecesData[partsLb.SelectedIndex][8] = "s";
                    piecesData[partsLb.SelectedIndex][9] = "s";
                }
            }
        }

        private void sizeCb_CheckedChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (sizeCb.Checked == true)
                {
                    sizeMin.Enabled = true;
                    sizeMax.Enabled = true;
                    if (piecesData[partsLb.SelectedIndex][10] == "s")
                    {
                        sizeMin.Value = 0;
                        piecesData[partsLb.SelectedIndex][10] = "0";
                        sizeMax.Value = 0;
                        piecesData[partsLb.SelectedIndex][11] = "0";
                    }
                    else
                    {
                        sizeMin.Value = int.Parse(piecesData[partsLb.SelectedIndex][10]);
                        sizeMax.Value = int.Parse(piecesData[partsLb.SelectedIndex][11]);
                    }
                }
                else
                {
                    sizeMin.Enabled = false;
                    sizeMax.Enabled = false;
                    piecesData[partsLb.SelectedIndex][10] = "s";
                    piecesData[partsLb.SelectedIndex][11] = "s";
                }
            }
        }

        private void basePointTb_TextChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                piecesPoints[partsLb.SelectedIndex][0] = basePointTb.Text;
            }
        }

        private void joinPointTb_TextChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                piecesPoints[partsLb.SelectedIndex][1] = joinPointTb.Text;
            }
        }

        private void xMin_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (xMax.Value < xMin.Value)
                {
                    xMax.Value = xMin.Value;
                }
                if (piecesData[partsLb.SelectedIndex][0] != "s")
                {
                    piecesData[partsLb.SelectedIndex][0] = ((int)xMin.Value).ToString();
                    piecesData[partsLb.SelectedIndex][1] = ((int)xMax.Value).ToString();
                }
            }
        }

        private void xMax_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (xMin.Value > xMax.Value)
                {
                    xMin.Value = xMax.Value;
                }
                if (piecesData[partsLb.SelectedIndex][0] != "s")
                {
                    piecesData[partsLb.SelectedIndex][0] = ((int)xMin.Value).ToString();
                    piecesData[partsLb.SelectedIndex][1] = ((int)xMax.Value).ToString();
                }
            }
        }

        private void yMin_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            { 
                if (yMax.Value < yMin.Value)
                {
                    yMax.Value = yMin.Value;
                }
                if (piecesData[partsLb.SelectedIndex][2] != "s")
                {
                    piecesData[partsLb.SelectedIndex][2] = ((int)yMin.Value).ToString();
                    piecesData[partsLb.SelectedIndex][3] = ((int)yMax.Value).ToString();
                }
            }
        }

        private void yMax_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            { 
                if (yMin.Value > yMax.Value)
                {
                    yMin.Value = yMax.Value;
                }
                if (piecesData[partsLb.SelectedIndex][2] != "s")
                {
                    piecesData[partsLb.SelectedIndex][2] = ((int)yMin.Value).ToString();
                    piecesData[partsLb.SelectedIndex][3] = ((int)yMax.Value).ToString();
                }
            }
        }

        private void rotMin_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (rotMax.Value < rotMin.Value)
                {
                    rotMax.Value = rotMin.Value;
                }
                if (piecesData[partsLb.SelectedIndex][4] != "s")
                {
                    piecesData[partsLb.SelectedIndex][4] = ((int)rotMin.Value).ToString();
                    piecesData[partsLb.SelectedIndex][5] = ((int)rotMax.Value).ToString();
                }
            }
        }

        private void rotMax_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (rotMin.Value > rotMax.Value)
                {
                    rotMin.Value = rotMax.Value;
                }
                if (piecesData[partsLb.SelectedIndex][4] != "s")
                {
                    piecesData[partsLb.SelectedIndex][4] = ((int)rotMin.Value).ToString();
                    piecesData[partsLb.SelectedIndex][5] = ((int)rotMax.Value).ToString();
                }
            }
        }

        private void turnMin_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (turnMax.Value < turnMin.Value)
                {
                    turnMax.Value = turnMin.Value;
                }
                if (piecesData[partsLb.SelectedIndex][6] != "s")
                {
                    piecesData[partsLb.SelectedIndex][6] = ((int)turnMin.Value).ToString();
                    piecesData[partsLb.SelectedIndex][7] = ((int)turnMax.Value).ToString();
                }
            }
        }

        private void turnMax_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (turnMin.Value > turnMax.Value)
                {
                    turnMin.Value = turnMax.Value;
                }
                if (piecesData[partsLb.SelectedIndex][6] != "s")
                {
                    piecesData[partsLb.SelectedIndex][6] = ((int)turnMin.Value).ToString();
                    piecesData[partsLb.SelectedIndex][7] = ((int)turnMax.Value).ToString();
                }
            }
        }

        private void spinMin_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (spinMax.Value < spinMin.Value)
                {
                    spinMax.Value = spinMin.Value;
                }
                if (piecesData[partsLb.SelectedIndex][8] != "s")
                {
                    piecesData[partsLb.SelectedIndex][8] = ((int)spinMin.Value).ToString();
                    piecesData[partsLb.SelectedIndex][9] = ((int)spinMax.Value).ToString();
                }
            }
        }

        private void spinMax_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (spinMin.Value > spinMax.Value)
                {
                    spinMin.Value = spinMax.Value;
                }
                if (piecesData[partsLb.SelectedIndex][8] != "s")
                {
                    piecesData[partsLb.SelectedIndex][8] = ((int)spinMin.Value).ToString();
                    piecesData[partsLb.SelectedIndex][9] = ((int)spinMax.Value).ToString();
                }
            }
        }

        private void sizeMin_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (sizeMax.Value < sizeMin.Value)
                {
                    sizeMax.Value = sizeMin.Value;
                }
                if (piecesData[partsLb.SelectedIndex][10] != "s")
                {
                    piecesData[partsLb.SelectedIndex][10] = ((int)sizeMin.Value).ToString();
                    piecesData[partsLb.SelectedIndex][11] = ((int)sizeMax.Value).ToString();
                }
            }
        }

        private void sizeMax_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (sizeMin.Value > sizeMax.Value)
                {
                    sizeMin.Value = sizeMax.Value;
                }
                if (piecesData[partsLb.SelectedIndex][10] != "s")
                {
                    piecesData[partsLb.SelectedIndex][10] = ((int)sizeMin.Value).ToString();
                    piecesData[partsLb.SelectedIndex][11] = ((int)sizeMax.Value).ToString();
                }
            }
        }

        private void upBtn_Click(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1 && partsLb.SelectedIndex > 0)
            {
                // Move Piece
                Piece holdPiece = partsList[partsLb.SelectedIndex];
                partsList[partsLb.SelectedIndex] = partsList[partsLb.SelectedIndex - 1];
                partsList[partsLb.SelectedIndex - 1] = holdPiece;
                string[] holdString1 = piecesPoints[partsLb.SelectedIndex];
                piecesPoints[partsLb.SelectedIndex] = piecesPoints[partsLb.SelectedIndex - 1];
                piecesPoints[partsLb.SelectedIndex - 1] = holdString1;
                string[] holdString2 = piecesData[partsLb.SelectedIndex];
                piecesData[partsLb.SelectedIndex] = piecesData[partsLb.SelectedIndex - 1];
                piecesData[partsLb.SelectedIndex - 1] = holdString2;
                object holdObject = partsLb.Items[partsLb.SelectedIndex];
                partsLb.Items[partsLb.SelectedIndex] = partsLb.Items[partsLb.SelectedIndex - 1];
                partsLb.Items[partsLb.SelectedIndex - 1] = holdObject;
                partsLb.SelectedIndex -= 1;
                // Draw Changes
                DrawParts();
            }
        }

        private void downBtn_Click(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1 && partsLb.SelectedIndex < partsList.Count - 1)
            {
                // Move Piece
                Piece holdPiece = partsList[partsLb.SelectedIndex];
                partsList[partsLb.SelectedIndex] = partsList[partsLb.SelectedIndex + 1];
                partsList[partsLb.SelectedIndex + 1] = holdPiece;
                string[] holdString1 = piecesPoints[partsLb.SelectedIndex];
                piecesPoints[partsLb.SelectedIndex] = piecesPoints[partsLb.SelectedIndex + 1];
                piecesPoints[partsLb.SelectedIndex + 1] = holdString1;
                string[] holdString2 = piecesData[partsLb.SelectedIndex];
                piecesData[partsLb.SelectedIndex] = piecesData[partsLb.SelectedIndex + 1];
                piecesData[partsLb.SelectedIndex + 1] = holdString2;
                object holdObject = partsLb.Items[partsLb.SelectedIndex];
                partsLb.Items[partsLb.SelectedIndex] = partsLb.Items[partsLb.SelectedIndex + 1];
                partsLb.Items[partsLb.SelectedIndex + 1] = holdObject;
                partsLb.SelectedIndex += 1;
                // Draw Changes
                DrawParts();
            }
        }

        private double[] GetPointPositions(string pointOfBase, string pointOfJoin, Piece joiner)
        {
            double[] coords = new double[2];
            Piece basePoint = new Piece(pointOfBase);
            Piece joinPoint = new Piece(pointOfJoin);
            double sizeModifier = joiner.GetSizeMod() / 100.0;
            double sizeModBase = basePiece.GetSizeMod() / 100.0;
            // Find Mid
            double[] basePieceMid = FindMid(basePiece.GetOriginalPoints(0, 0));
            double[] joinPieceMid = FindMid(joiner.GetOriginalPoints(0, 0));
            // Set Values
            basePoint.SetRotation((int)basePiece.GetAngles()[0]);
            basePoint.SetTurn((int)basePiece.GetAngles()[1]);
            joinPoint.SetRotation((int)joiner.GetAngles()[0]);
            joinPoint.SetTurn((int)joiner.GetAngles()[1]);
            // Find Points
            double[,] basePoints = basePoint.GetCurrentPoints(false, false);
            double[,] joinPoints = joinPoint.GetCurrentPoints(false, false);
            // Alter Spin
            double[,] basePointsDupeX = basePoint.GetCurrentPoints(false, false);
            double[,] basePointsDupeY = basePoint.GetCurrentPoints(false, false);
            double[,] joinPointsDupeX = joinPoint.GetCurrentPoints(false, false);
            double[,] joinPointsDupeY = joinPoint.GetCurrentPoints(false, false);
            // Update points based on spin
            basePoints[0, 0] = (int)(basePiece.SpinMeRound(basePointsDupeX, basePieceMid[0], basePieceMid[1], sizeModBase)[0, 0]);
            basePoints[0, 1] = (int)(basePiece.SpinMeRound(basePointsDupeY, basePieceMid[0], basePieceMid[1], sizeModBase)[0, 1]);
            joinPoints[0, 0] = (int)(joiner.SpinMeRound(joinPointsDupeX, joinPieceMid[0], joinPieceMid[1], sizeModifier)[0, 0]);
            joinPoints[0, 1] = (int)(joiner.SpinMeRound(joinPointsDupeY, joinPieceMid[0], joinPieceMid[1], sizeModifier)[0, 1]);
            // Update points x/y
            coords[0] = basePiece.GetCoords()[0] + (basePoints[0, 0] - basePieceMid[0]) + (joinPieceMid[0] - joinPoints[0, 0]);
            coords[1] = basePiece.GetCoords()[1] + (basePoints[0, 1] - basePieceMid[1]) + (joinPieceMid[1] - joinPoints[0, 1]);
            // Return JoinPiece Coordinates
            return coords;
        }

        private void baseCb_CheckedChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1 && baseCb.Checked == true)
            {
                basePiece = partsList[partsLb.SelectedIndex];

                // Disable Everything
                xCb.Enabled = false;
                yCb.Enabled = false;
                RotateCb.Enabled = false;
                turnCb.Enabled = false;
                spinCb.Enabled = false;
                sizeCb.Enabled = false;
                xMin.Enabled = false;
                xMax.Enabled = false;
                yMin.Enabled = false;
                yMax.Enabled = false;
                rotMin.Enabled = false;
                rotMax.Enabled = false;
                turnMin.Enabled = false;
                turnMax.Enabled = false;
                spinMin.Enabled = false;
                spinMax.Enabled = false;
                sizeMin.Enabled = false;
                sizeMax.Enabled = false;
                basePointTb.Enabled = false;
                joinPointTb.Enabled = false;
                label1.ForeColor = Color.DimGray;
                label2.ForeColor = Color.DimGray;
            }
            else if (partsLb.SelectedIndex != -1)
            {
                // Check BasePiece
                if (partsList[partsLb.SelectedIndex] == basePiece && baseCb.Checked == false)
                {
                    basePiece = null;
                }

                // Enable Everything
                xCb.Enabled = true;
                yCb.Enabled = true;
                RotateCb.Enabled = true;
                turnCb.Enabled = true;
                spinCb.Enabled = true;
                sizeCb.Enabled = true;
                xMin.Enabled = true;
                xMax.Enabled = true;
                yMin.Enabled = true;
                yMax.Enabled = true;
                rotMin.Enabled = true;
                rotMax.Enabled = true;
                turnMin.Enabled = true;
                turnMax.Enabled = true;
                spinMin.Enabled = true;
                spinMax.Enabled = true;
                sizeMin.Enabled = true;
                sizeMax.Enabled = true;
                basePointTb.Enabled = true;
                joinPointTb.Enabled = true;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
            }
        }

        private void loadPointsBtn_Click(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1 && basePiece != null)
            {
                try
                {
                    double[] newCoords = new double[] { GetPointPositions(piecesPoints[partsLb.SelectedIndex][0], piecesPoints[partsLb.SelectedIndex][1], partsList[partsLb.SelectedIndex])[0],
                    GetPointPositions(piecesPoints[partsLb.SelectedIndex][0], piecesPoints[partsLb.SelectedIndex][1], partsList[partsLb.SelectedIndex])[1] };

                    if (!piecesList.Contains(partsList[partsLb.SelectedIndex]))
                    {
                        Boolean found = false;
                        int indexSet = 0;
                        while (!found)
                        {
                            if (setList[indexSet].GetBasePiece() == partsList[partsLb.SelectedIndex])
                            {
                                setList[indexSet].UpdateSubpieces("X", newCoords[0]);
                                setList[indexSet].UpdateSubpieces("Y", newCoords[1]);
                                found = true;
                            }
                            else
                            {
                                indexSet++;
                            }
                        }
                    }
                    else
                    {
                        partsList[partsLb.SelectedIndex].SetX(newCoords[0]);
                        partsList[partsLb.SelectedIndex].SetY(newCoords[1]);
                    }
                    DrawParts();
                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
                }
            }
        }

        private double[] FindMid(double[,] arrayIn)
        {
            double minX = 99999;
            double maxX = -99999;
            double minY = 99999;
            double maxY = -99999;
            for (int index = 0; index < arrayIn.Length / 2; index++)
            {
                if (arrayIn[index, 0] < minX)
                {
                    minX = arrayIn[index, 0];
                }
                if (arrayIn[index, 0] > maxX)
                {
                    maxX = arrayIn[index, 0];
                }
                if (arrayIn[index, 1] < minY)
                {
                    minY = arrayIn[index, 1];
                }
                if (arrayIn[index, 1] > maxY)
                {
                    maxY = arrayIn[index, 1];
                }
            }
            return new double[] { minX + (maxX - minX) / 2, minY + (maxY - minY) / 2 };
        }

        private void rotInitUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                piecesData[partsLb.SelectedIndex][12] = ((int)rotInitUpDown.Value).ToString();
                UpdateInits(partsLb.SelectedIndex);
                if (basePointTb.Text != "" && joinPointTb.Text != "")
                {
                    loadPointsBtn_Click(sender, e);
                }
                DrawParts();
            }
        }

        private void turnInitUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                piecesData[partsLb.SelectedIndex][13] = ((int)turnInitUpDown.Value).ToString();
                UpdateInits(partsLb.SelectedIndex);
                if (basePointTb.Text != "" && joinPointTb.Text != "")
                {
                    loadPointsBtn_Click(sender, e);
                }
                DrawParts();
            }
        }

        private void spinInitUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                piecesData[partsLb.SelectedIndex][14] = ((int)spinInitUpDown.Value).ToString();
                UpdateInits(partsLb.SelectedIndex);
                if (basePointTb.Text != "" && joinPointTb.Text != "")
                {
                    loadPointsBtn_Click(sender, e);
                }
                DrawParts();
            }
        }

        private void sizeInitUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                piecesData[partsLb.SelectedIndex][15] = ((int)sizeInitUpDown.Value).ToString();
                UpdateInits(partsLb.SelectedIndex);
                if (basePointTb.Text != "" && joinPointTb.Text != "")
                {
                    loadPointsBtn_Click(sender, e);
                }
                DrawParts();
            }
        }

        private void UpdateInits(int partIndex)
        {
            if (piecesList.Contains(partsList[partIndex]))
            {
                partsList[partIndex].SetRotation(int.Parse(piecesData[partIndex][12]));
                partsList[partIndex].SetTurn(int.Parse(piecesData[partIndex][13]));
                partsList[partIndex].SetSpin(int.Parse(piecesData[partIndex][14]));
                partsList[partIndex].SetSizeMod(int.Parse(piecesData[partIndex][15]));
            }
            else
            {
                Boolean found = false;
                int theIndex = 0;
                while (!found)
                {
                    if (partsList[partIndex] == setList[theIndex].GetBasePiece())
                    {
                        found = true;
                        setList[theIndex].UpdateSubpieces("rotation", int.Parse(piecesData[partIndex][12]));
                        setList[theIndex].UpdateSubpieces("turn", int.Parse(piecesData[partIndex][13]));
                        setList[theIndex].UpdateSubpieces("spin", int.Parse(piecesData[partIndex][14]));
                        setList[theIndex].UpdateSubpieces("size", int.Parse(piecesData[partIndex][15]));
                    }
                    else
                    {
                        theIndex++;
                    }
                }
            }
        }
    }
}
