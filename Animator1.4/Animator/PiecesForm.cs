using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Animator
{
    public partial class PiecesForm : Form
    {
        Graphics g;
        Color outlineColour, fillColour;
        List<string> joins, solid, saveData;
        List<int[]> original, rotated, turned, rAtT0;
        List<Piece> sketch;
        int outlineWidth;
        string angleType = "base";

        public PiecesForm()
        {
            InitializeComponent();
            outlineColour = Color.FromArgb(255, 204, 204, 255);
            fillColour = Color.FromArgb(255, 204, 240, 255);
            joins = new List<string>();
            solid = new List<string>();
            saveData = new List<string>();
            original = new List<int[]>();
            rotated = new List<int[]>();
            turned = new List<int[]>();
            rAtT0 = new List<int[]>();
            sketch = new List<Piece>();
            outlineWidth = 3;
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            Boolean doEet = true;
            DialogResult result = MessageBox.Show("Do you want to save this piece?", "Save Confirmation", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                doEet = false;
            }
            if (doEet)
            {
                try
                {
                    // Save Data
                    string filePath = Environment.CurrentDirectory + "\\Parts\\" + NameTb.Text + ".txt";
                    System.IO.StreamWriter file = new System.IO.StreamWriter(@filePath);

                    // Save Point
                    if (pointCb.Checked == true)
                    {
                        file.WriteLine("point");
                        for (int index = 0; index < saveData.Count; index++)
                        {
                            file.WriteLine(saveData[index]);
                        }
                    }
                    else
                    {
                        string save = "";
                        string save2 = "";
                        if (outlineColour.A > 0 || outlineWidthUpDown.Value != 0)
                        {
                            save += "y:" + numColUpDown.Value + ":";
                            OutlineRb.Checked = true;
                            save2 += AlphaUpDown.Value + "," + RedUpDown.Value + "," + GreenUpDown.Value + "," + BlueUpDown.Value + ";";
                        }
                        else
                        {
                            save += "n:" + numColUpDown.Value + ":";
                        }
                        save += (midFillCb.Checked == true) ? "c;" : gradAngleUpDown.Value + ";";
                        if (numColUpDown.Value != 0)
                        {
                            FillRb.Checked = true;
                            save += AlphaUpDown.Value + "," + RedUpDown.Value + "," + GreenUpDown.Value + "," + BlueUpDown.Value;   // GRADIENT NEEDED ** TO DO **
                                                                                                                                    //save2 += (numColUpDown.Value == 0) ? ";" : ":";
                            save += (outlineColour.A > 0 || outlineWidthUpDown.Value != 0) ? ":" : ";";
                        }
                        save += save2;
                        save += outlineWidth + ";";
                        save += "wr" + wrUpDown.Value;
                        file.WriteLine(save);
                        for (int index = 0; index < saveData.Count; index++)
                        {
                            file.WriteLine(saveData[index]);
                        }
                        file.WriteLine("000:360;000:360;400,400;400,400;400,400;none;s");
                    }
                    file.Close();

                    // Close Pieces Form
                    this.Close();
                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
                }
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

        private void DrawPoint(double xcood, double ycood, Color colour)
        {
            int x = (int)xcood;
            int y = (int)ycood;
            Pen pen = new Pen(colour);
            g.DrawLine(pen, new Point(x - 2, y), new Point(x + 2, y));
            g.DrawLine(pen, new Point(x, y - 2), new Point(x, y + 2));
        }

        private void PointsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                int[,] coords = ConvertListbox();
                xUpDown.Value = coords[PointsLb.SelectedIndex, 0];
                yUpDown.Value = coords[PointsLb.SelectedIndex, 1];
                if (joins[PointsLb.SelectedIndex].StartsWith("curve"))
                {
                    joinOptions.SelectedItem = "curve";
                }
                else
                {
                    joinOptions.SelectedItem = joins[PointsLb.SelectedIndex];
                }
                fixedCb.Checked = (solid[PointsLb.SelectedIndex] == "s") ? true : false;
                if (joins[PointsLb.SelectedIndex].StartsWith("curve"))
                {
                    flexibilityUpDown.Enabled = true;
                    flexibilityUpDown.Value = decimal.Parse(joins[PointsLb.SelectedIndex].Remove(0, 5));
                }
                else
                {
                    flexibilityUpDown.Enabled = false;
                }
                DrawPoints();
            }
            
        }

        private void DrawPoints()
        {
            // Prepare
            DrawPanel.Refresh();
            g = this.DrawPanel.CreateGraphics();

            // Draw Sketch
            Pen sketchPen = new Pen(Color.LightGreen, 2);
            double[,] sketchCoords;
            string[] joiners;
            for (int index = 0; index < sketch.Count; index++)
            {
                if (angleType == "base")
                {
                    sketch[index].SetRotation((int)rFromUpDown.Value);
                    sketch[index].SetTurn((int)tFromUpDown.Value);
                    sketchCoords = sketch[index].GetCurrentPoints(false, true);
                }
                else if (angleType == "rotated")
                {
                    sketch[index].SetRotation((int)rToUpDown.Value);
                    sketch[index].SetTurn((int)tFromUpDown.Value);
                    sketchCoords = sketch[index].GetCurrentPoints(false, true);
                }
                else
                {
                    sketch[index].SetRotation((int)rFromUpDown.Value);
                    sketch[index].SetTurn((int)tToUpDown.Value);
                    sketchCoords = sketch[index].GetCurrentPoints(false, true);
                }
                // Draw line between points
                joiners = sketch[index].GetLineArray((int)rFromUpDown.Value, (int)tFromUpDown.Value);
                for (int pointIndex = 0; pointIndex < sketchCoords.Length/2; pointIndex++)
                {
                    if (pointIndex != 0 && joiners[pointIndex - 1] == "line")
                    {
                        g.DrawLine(sketchPen, new Point((int)sketchCoords[pointIndex - 1, 0], (int)sketchCoords[pointIndex - 1, 1]),
                            new Point((int)sketchCoords[pointIndex, 0], (int)sketchCoords[pointIndex, 1]));
                    }
                    else if (pointIndex != 0 && joiners[pointIndex - 1].StartsWith("curve"))
                    {
                        decimal tension = decimal.Parse(joiners[pointIndex - 1].Remove(0, 5));
                        // Find number of points in curve
                        int numCurves = 2;
                        Boolean endCurve = false;
                        Boolean finishesAtStart = false;
                        while (!endCurve && pointIndex < sketchCoords.Length / 2)
                        {
                            if (joiners[pointIndex] == "contcurve" && pointIndex == PointsLb.Items.Count - 1)
                            {
                                finishesAtStart = true;
                                numCurves++;
                                pointIndex++;
                            }
                            else if (joiners[pointIndex] == "contcurve")
                            {
                                numCurves++;
                                pointIndex++;
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
                                thePoints[curveIndex] = new Point((int)sketchCoords[0, 0], (int)sketchCoords[0, 1]);
                            }
                            else
                            {
                                thePoints[curveIndex] = new Point((int)sketchCoords[pointIndex - (numCurves - 1 - curveIndex), 0], (int)sketchCoords[pointIndex - (numCurves - 1 - curveIndex), 1]);
                            }
                        }
                        // Draw Curve
                        g.DrawCurve(sketchPen, thePoints, (float)tension);
                    }
                    // Draw closing line between first and last point
                    if (pointIndex != 0 && pointIndex == sketchCoords.Length/2 - 1 && joiners[pointIndex] == "line")
                    {
                        g.DrawLine(sketchPen, new Point((int)sketchCoords[0, 0], (int)sketchCoords[0, 1]),
                            new Point((int)sketchCoords[pointIndex, 0], (int)sketchCoords[pointIndex, 1]));
                    }
                }
            }

            int[,] coords = ConvertListbox();

            // Fill WIP
            int fillIndex = 0;
            Boolean endShape = false;
            while (fillIndex < PointsLb.Items.Count - 1)
            {
                GraphicsPath path = new GraphicsPath();
                while (!endShape && fillIndex < PointsLb.Items.Count - 1)
                {
                    if (joins[fillIndex] == "line")
                    {
                        path.AddLine(new Point(coords[fillIndex, 0], coords[fillIndex, 1]), new Point(coords[fillIndex + 1, 0], coords[fillIndex + 1, 1]));
                    }
                    else if (fillIndex != 0 && joins[fillIndex - 1].StartsWith("curve"))
                    {
                        decimal tension = decimal.Parse(joins[fillIndex - 1].Remove(0, 5));
                        // Find number of points in curve
                        int numCurves = 2;
                        Boolean endCurve = false;
                        Boolean finishesAtStart = false;
                        while (!endCurve && fillIndex < PointsLb.Items.Count)
                        {
                            if (joins[fillIndex] == "contcurve" && fillIndex == PointsLb.Items.Count - 1)
                            {
                                finishesAtStart = true;
                                numCurves++;
                                fillIndex++;
                            }
                            else if (joins[fillIndex] == "contcurve")
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
                                thePoints[curveIndex] = new Point(coords[0, 0], coords[0, 1]);
                            }
                            else
                            {
                                thePoints[curveIndex] = new Point(coords[fillIndex - (numCurves - 1 - curveIndex), 0], coords[fillIndex - (numCurves - 1 - curveIndex), 1]);
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
                if (fillIndex < PointsLb.Items.Count && joins[joins.Count - 1] == "line")
                {
                    path.AddLine(new Point(coords[fillIndex, 0], coords[fillIndex, 1]), new Point(coords[0, 0], coords[0, 1]));
                }

                endShape = false;
                // Fill
                if (numColUpDown.Value == 1)
                {
                    SolidBrush fill = new SolidBrush(fillColour);
                    g.FillPath(fill, path);

                }
                else if (numColUpDown.Value > 1)
                {
                    SolidBrush fill = new SolidBrush(fillColour);
                    g.FillPath(fill, path);
                }
            }
            

            // Draw WIP
            for (int index = 0; index < PointsLb.Items.Count; index++)
            {
                if (PointsLb.SelectedIndex == index)
                {
                    DrawPoint(coords[index,0], coords[index, 1], Color.Red);
                }
                else
                {
                    DrawPoint(coords[index, 0], coords[index, 1], Color.Black);
                }
                // Draw line between points
                if (index != 0 && joins[index - 1] == "line")
                {
                    Pen pen = new Pen(outlineColour, outlineWidth);
                    g.DrawLine(pen, new Point(coords[index - 1, 0], coords[index - 1, 1]), 
                        new Point(coords[index, 0], coords[index, 1]));
                }
                else if (index != 0 && joins[index - 1] == "contcurve")
                {
                    MessageBox.Show("You need to set the start of the curve to continue it. This join has been changed to a line.", "Curve Error", MessageBoxButtons.OK);
                    joins[index - 1] = "line";
                }
                else if (index != 0 && joins[index - 1].StartsWith("curve"))
                {
                    Pen pen = new Pen(outlineColour, outlineWidth);
                    decimal tension = decimal.Parse(joins[index - 1].Remove(0, 5));
                    // Find number of points in curve
                    int numCurves = 2;
                    Boolean endCurve = false;
                    Boolean finishesAtStart = false;
                    while (!endCurve && index < PointsLb.Items.Count)
                    {
                        if (joins[index] == "contcurve" && index == PointsLb.Items.Count - 1)
                        {
                            finishesAtStart = true;
                            numCurves++;
                            index++;
                        }
                        else if (joins[index] == "contcurve")
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
                            thePoints[curveIndex] = new Point(coords[0, 0], coords[0, 1]);
                        }
                        else
                        {
                            thePoints[curveIndex] = new Point(coords[index - (numCurves - 1 - curveIndex), 0], coords[index - (numCurves - 1 - curveIndex), 1]);
                        }
                    }
                    // Draw Curve
                    g.DrawCurve(pen, thePoints, (float)tension);
                }
                // Draw closing line between first and last point
                if (index != 0 && index == PointsLb.Items.Count - 1 && joins[index] == "line")
                {
                    Pen pen = new Pen(outlineColour, outlineWidth);
                    g.DrawLine(pen, new Point(coords[0, 0], coords[0, 1]),
                        new Point(coords[index, 0], coords[index, 1]));
                }
            }
        }

        private void AddPointBtn_Click(object sender, EventArgs e)
        {
            PointsLb.Items.Add("400,400");
            joins.Add("line");
            solid.Add("s");
            DrawPoints();
        }

        private void xUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                int[,] coords = ConvertListbox();
                PointsLb.Items[PointsLb.SelectedIndex] = xUpDown.Value + "," + coords[PointsLb.SelectedIndex, 1];
                DrawPoints();
            }
        }

        private void yUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                int[,] coords = ConvertListbox();
                PointsLb.Items[PointsLb.SelectedIndex] = coords[PointsLb.SelectedIndex, 0] + "," + yUpDown.Value;
                DrawPoints();
            }
        }

        private void upBtn_Click(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                Object holdingValue = PointsLb.Items[PointsLb.SelectedIndex - 1];
                PointsLb.Items[PointsLb.SelectedIndex - 1] = PointsLb.Items[PointsLb.SelectedIndex];
                PointsLb.Items[PointsLb.SelectedIndex] = holdingValue;
                string holdJoin = joins[PointsLb.SelectedIndex - 1];
                joins[PointsLb.SelectedIndex - 1] = joins[PointsLb.SelectedIndex];
                joins[PointsLb.SelectedIndex] = holdJoin;
                string holdSolid = solid[PointsLb.SelectedIndex - 1];
                solid[PointsLb.SelectedIndex - 1] = solid[PointsLb.SelectedIndex];
                solid[PointsLb.SelectedIndex] = holdSolid;
            }
        }

        private void downBtn_Click(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                Object holdingValue = PointsLb.Items[PointsLb.SelectedIndex + 1];
                PointsLb.Items[PointsLb.SelectedIndex + 1] = PointsLb.Items[PointsLb.SelectedIndex];
                PointsLb.Items[PointsLb.SelectedIndex] = holdingValue;
                string holdJoin = joins[PointsLb.SelectedIndex + 1];
                joins[PointsLb.SelectedIndex + 1] = joins[PointsLb.SelectedIndex];
                joins[PointsLb.SelectedIndex] = holdJoin;
                string holdSolid= solid[PointsLb.SelectedIndex + 1];
                solid[PointsLb.SelectedIndex + 1] = solid[PointsLb.SelectedIndex];
                solid[PointsLb.SelectedIndex] = holdSolid;
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                PointsLb.Items.RemoveAt(PointsLb.SelectedIndex);
                joins.RemoveAt(PointsLb.SelectedIndex);
                solid.RemoveAt(PointsLb.SelectedIndex);
                DrawPoints();
            }
        }

        private void AlphaUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateColours();
        }

        private void RedUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateColours();
        }

        private void GreenUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateColours();
        }

        private void BlueUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateColours();
        }

        private int[,] ConvertListbox()
        {
            int[,] coords = new int[PointsLb.Items.Count, 2];
            for (int index = 0; index < PointsLb.Items.Count; index++)
            {
                coords[index, 0] = int.Parse(PointsLb.Items[index].ToString().Split(new Char[] { ',' })[0]);
                coords[index, 1] = int.Parse(PointsLb.Items[index].ToString().Split(new Char[] { ',' })[1]);
            }
            return coords;
        }

        private void FillRb_CheckedChanged(object sender, EventArgs e)
        {
            if (FillRb.Checked == true)
            {
                int[] coloursHold = new int[] { fillColour.A, fillColour.R, fillColour.G, fillColour.B};
                AlphaUpDown.Value = coloursHold[0];
                RedUpDown.Value = coloursHold[1];
                GreenUpDown.Value = coloursHold[2];
                BlueUpDown.Value = coloursHold[3];
                label8.ForeColor = Color.Black;
                label10.ForeColor = Color.Black;
                midFillCb.Enabled = true;
                numColUpDown.Enabled = true;
                gradAngleUpDown.Enabled = true;
            }
            DrawPoints();
        }

        private void OutlineRb_CheckedChanged(object sender, EventArgs e)
        {
            if (OutlineRb.Checked == true)
            {
                int[] coloursHold = new int[] { outlineColour.A, outlineColour.R, outlineColour.G, outlineColour.B};
                AlphaUpDown.Value = coloursHold[0];
                RedUpDown.Value = coloursHold[1];
                GreenUpDown.Value = coloursHold[2];
                BlueUpDown.Value = coloursHold[3];
                label8.ForeColor = Color.DimGray;
                label10.ForeColor = Color.DimGray;
                midFillCb.Enabled = false;
                numColUpDown.Enabled = false;
                gradAngleUpDown.Enabled = false;
            }
            DrawPoints();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                joins[PointsLb.SelectedIndex] = (string)joinOptions.SelectedItem;
                if ((string)joinOptions.SelectedItem == "curve")
                {
                    flexibilityUpDown.Enabled = true;
                    joins[PointsLb.SelectedIndex] = "curve0.5";
                }
                else
                {
                    flexibilityUpDown.Enabled = false;
                }
            }
        }

        private void switchBtn_Click(object sender, EventArgs e)
        {
            if (switchBtn.Text == "Define Shape")
            {
                // Show Shape Components
                AddPointBtn.Visible = true;
                PointsLb.Visible = true;
                upBtn.Visible = true;
                downBtn.Visible = true;
                DeleteBtn.Visible = true;
                label5.Visible = true;
                label7.Visible = true;
                xUpDown.Visible = true;
                yUpDown.Visible = true;
                label9.Visible = true;
                joinOptions.Visible = true;
                fixedCb.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                rFromUpDown.Visible = true;
                rToUpDown.Visible = true;
                tFromUpDown.Visible = true;
                tToUpDown.Visible = true;
                nextBtn.Visible = true;
                BaseBtn.Visible = true;
                RotateBtn.Visible = true;
                TurnBtn.Visible = true;
                label15.Visible = true;
                flexibilityUpDown.Visible = true;

                // Hide Piece Components
                FillRb.Visible = false;
                OutlineRb.Visible = false;
                label6.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                AlphaUpDown.Visible = false;
                RedUpDown.Visible = false;
                GreenUpDown.Visible = false;
                BlueUpDown.Visible = false;
                label8.Visible = false;
                label10.Visible = false;
                numColUpDown.Visible = false;
                gradAngleUpDown.Visible = false;
                label4.Visible = false;
                wrUpDown.Visible = false;
                label11.Visible = false;
                midFillCb.Visible = false;
                loadBtn.Visible = false;
                sketchBtn.Visible = false;
                label14.Visible = false;
                outlineWidthUpDown.Visible = false;
                loadTb.Visible = false;

                // Change Button Text
                switchBtn.Text = "Define Piece";
            }
            else
            {
                // Show Piece Components
                FillRb.Visible = true;
                OutlineRb.Visible = true;
                label6.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                AlphaUpDown.Visible = true;
                RedUpDown.Visible = true;
                GreenUpDown.Visible = true;
                BlueUpDown.Visible = true;
                label8.Visible = true;
                label10.Visible = true;
                numColUpDown.Visible = true;
                gradAngleUpDown.Visible = true;
                label4.Visible = true;
                wrUpDown.Visible = true;
                label11.Visible = true;
                midFillCb.Visible = true;
                loadBtn.Visible = true;
                sketchBtn.Visible = true;
                label14.Visible = true;
                outlineWidthUpDown.Visible = true;
                loadTb.Visible = true;

                // Hide Shape Components
                AddPointBtn.Visible = false;
                PointsLb.Visible = false;
                upBtn.Visible = false;
                downBtn.Visible = false;
                DeleteBtn.Visible = false;
                label5.Visible = false;
                label7.Visible = false;
                xUpDown.Visible = false;
                yUpDown.Visible = false;
                label9.Visible = false;
                joinOptions.Visible = false;
                fixedCb.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label13.Visible = false;
                label13.Visible = false;
                rFromUpDown.Visible = false;
                rToUpDown.Visible = false;
                tFromUpDown.Visible = false;
                tToUpDown.Visible = false;
                nextBtn.Visible = false;
                BaseBtn.Visible = false;
                RotateBtn.Visible = false;
                TurnBtn.Visible = false;
                label15.Visible = false;
                flexibilityUpDown.Visible = false;

                // Change Button Text
                switchBtn.Text = "Define Shape";
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Check Overflow
            if (gradAngleUpDown.Value == -1)
            {
                gradAngleUpDown.Value = 359;
            } 
            else if (gradAngleUpDown.Value == 360)
            {
                gradAngleUpDown.Value = 0;
            }
        }

        private void midFillCb_CheckedChanged(object sender, EventArgs e)
        {
            UpdateColours();
            gradAngleUpDown.Enabled = (midFillCb.Checked == true) ? false: true;
            label10.ForeColor = (midFillCb.Checked == true) ? Color.DimGray : Color.Black;
        }

        private void fixedCb_CheckedChanged(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                solid[PointsLb.SelectedIndex] = (fixedCb.Checked == true) ? "s" : "f";
            }

        }

        private void rFromUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Test Range Fair
            if (rFromUpDown.Value > rToUpDown.Value)
            {
                decimal hold = rFromUpDown.Value;
                rFromUpDown.Value = rToUpDown.Value;
                rToUpDown.Value = hold;
            }
        }

        private void RotateBtn_Click(object sender, EventArgs e)
        {
            // Save Current Angle
            if (angleType == "base")
            {
                original = SaveAngles();
            }
            else if (angleType == "turned")
            {
                turned = SaveAngles();
            }
            else
            {
                rotated = SaveAngles();
            }
            angleType = "rotated";

            // Fill LB
            if (rotated.Count != 0)
            {
                PointsLb.Items.Clear();
                for (int index = 0; index < rotated.Count; index++)
                {
                    PointsLb.Items.Add(rotated[index][0] + "," + rotated[index][1]);
                }
                DrawPoints();
            }
            else
            {
                PointsLb.Items.Clear();
                for (int index = 0; index < original.Count; index++)
                {
                    PointsLb.Items.Add(original[index][0] + "," + original[index][1]);
                }
                DrawPoints();
            }
        }

        private void TurnBtn_Click(object sender, EventArgs e)
        {
            // Save Current Angle
            if (angleType == "base")
            {
                original = SaveAngles();
            }
            else if (angleType == "rotated")
            {
                rotated = SaveAngles();
            }
            else
            {
                turned = SaveAngles();
            }
            angleType = "turned";

            // Fill LB
            if (turned.Count != 0)
            {
                PointsLb.Items.Clear();
                for (int index = 0; index < turned.Count; index++)
                {
                    PointsLb.Items.Add(turned[index][0] + "," + turned[index][1]);
                }
                DrawPoints();
            }
            else
            {
                PointsLb.Items.Clear();
                for (int index = 0; index < original.Count; index++)
                {
                    PointsLb.Items.Add(original[index][0] + "," + original[index][1]);
                }
                DrawPoints();
            }
        }

        private void BaseBtn_Click(object sender, EventArgs e)
        {
            // Save Current Angle
            if (angleType == "turned")
            {
                turned = SaveAngles();
            }
            else if (angleType == "rotated")
            {
                rotated = SaveAngles();
            }
            else
            {
                original = SaveAngles();
            }
            angleType = "base";

            // Fill LB
            PointsLb.Items.Clear();
            for (int index = 0; index < original.Count; index++)
            {
                PointsLb.Items.Add(original[index][0] + "," + original[index][1]);
            }
            DrawPoints();
        }

        private List<int[]> SaveAngles()
        {
            List<int[]> angles = new List<int[]>();
            for (int index = 0; index < PointsLb.Items.Count; index++)
            {
                int[] xypoint = new int[2];
                xypoint[0] = int.Parse(PointsLb.Items[index].ToString().Split(new Char[] { ',' })[0]);
                xypoint[1] = int.Parse(PointsLb.Items[index].ToString().Split(new Char[] { ',' })[1]);
                angles.Add(xypoint);
            }
            return angles;
        }

        private void outlineWidthUpDown_ValueChanged(object sender, EventArgs e)
        {
            outlineWidth = (int)outlineWidthUpDown.Value;
            DrawPoints();
        }

        private void sketchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                sketch.Add(new Piece(loadTb.Text));
                if (pointCb.Checked == true)
                {
                    sketchBtn.Enabled = false;
                }
                DrawPoints();
            } catch(System.IO.FileNotFoundException)        // ** ADD IN ERROR IF SET CHOSEN **
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
        }

        private void pointCb_CheckedChanged(object sender, EventArgs e)
        {
            Boolean doEet = true;

            if (pointCb.Checked == true)
            {
                // Confirm Intention
                if (PointsLb.Items.Count > 1)
                {
                    DialogResult result = MessageBox.Show("Points will be lost. Do you wish to continue?", "Change Confirmation", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.No)
                    {
                        doEet = false;
                        pointCb.Checked = false;
                    }
                }

                // Prepare LB, Enables/disables
                if (doEet)
                {
                    if (sketch.Count > 0)
                    {
                        sketchBtn.Enabled = false;
                    }
                    loadBtn.Enabled = false;
                    foreach (Object lbpoint in PointsLb.Items)
                    {
                        if (lbpoint != PointsLb.Items[0])
                        {
                            PointsLb.Items.Remove(lbpoint);
                        }
                    }
                    if (PointsLb.Items.Count == 0)
                    {
                        AddPointBtn_Click(sender, e);
                    }
                    AddPointBtn.Enabled = false;
                    DeleteBtn.Enabled = false;
                    joinOptions.Enabled = false;
                }

                // Disable Piece Settings
                FillRb.Enabled = false;
                OutlineRb.Enabled = false;
                label6.Enabled = false;
                label1.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = false;
                AlphaUpDown.Enabled = false;
                RedUpDown.Enabled = false;
                GreenUpDown.Enabled = false;
                BlueUpDown.Enabled = false;
                label8.Enabled = false;
                label10.Enabled = false;
                numColUpDown.Enabled = false;
                gradAngleUpDown.Enabled = false;
                label4.Enabled = false;
                wrUpDown.Enabled = false;
                label11.Enabled = false;
                midFillCb.Enabled = false;
                label14.Enabled = false;
                outlineWidthUpDown.Enabled = false;
            }
            else
            {
                sketchBtn.Enabled = true;
                loadBtn.Enabled = true;
                AddPointBtn.Enabled = true;
                DeleteBtn.Enabled = true;
                joinOptions.Enabled = true;

                // Enable Piece Settings
                FillRb.Enabled = true;
                OutlineRb.Enabled = true;
                label6.Enabled = true;
                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;
                AlphaUpDown.Enabled = true;
                RedUpDown.Enabled = true;
                GreenUpDown.Enabled = true;
                BlueUpDown.Enabled = true;
                label8.Enabled = true;
                label10.Enabled = true;
                numColUpDown.Enabled = true;
                gradAngleUpDown.Enabled = true;
                label4.Enabled = true;
                wrUpDown.Enabled = true;
                label11.Enabled = true;
                midFillCb.Enabled = true;
                label14.Enabled = true;
                outlineWidthUpDown.Enabled = true;
            }
            
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                new Piece(loadTb.Text);
                PiecesForm_LoadMenu loadForm = new PiecesForm_LoadMenu(this);
                //loadForm.Size = new System.Drawing.Size(875, 750);
                loadForm.Show();
            }
            catch (System.IO.FileNotFoundException) // ** SET ERROR **
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
        }

        private void flexibilityUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                joins[PointsLb.SelectedIndex] = "curve" + flexibilityUpDown.Value;
                DrawPoints();
            }
        }

        private void numColUpDown_ValueChanged(object sender, EventArgs e)
        {
            DrawPoints();
        }

        private void tFromUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Test Range Fair
            if (tFromUpDown.Value > tToUpDown.Value)
            {
                decimal hold = tFromUpDown.Value;
                tFromUpDown.Value = tToUpDown.Value;
                tToUpDown.Value = hold;
            }
        }

        private void rToUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Test Range Fair
            if (rFromUpDown.Value > rToUpDown.Value)
            {
                decimal hold = rFromUpDown.Value;
                rFromUpDown.Value = rToUpDown.Value;
                rToUpDown.Value = hold;
            }
        }

        private void tToUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Test Range Fair
            if (tFromUpDown.Value > tToUpDown.Value)
            {
                decimal hold = tFromUpDown.Value;
                tFromUpDown.Value = tToUpDown.Value;
                tToUpDown.Value = hold;
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            Boolean doEet = true;
            if (rFromUpDown.Value == rToUpDown.Value || tFromUpDown.Value == tToUpDown.Value)
            {
                DialogResult result = MessageBox.Show("Rotation or Turn unchanged. Is this intentional?", "Input Confirmation", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    doEet = false;
                }
            }
            if (doEet)
            {
                string save = "";

                // Rotation and Turn
                save += rFromUpDown.Value.ToString().PadLeft(3, '0') + "," + rToUpDown.Value.ToString().PadLeft(3, '0') + ";" +
                    tFromUpDown.Value.ToString().PadLeft(3, '0') + "," + tToUpDown.Value.ToString().PadLeft(3, '0') + ";";

                // POINTS
                if (angleType == "base")
                {
                    original = SaveAngles();
                }
                else if (angleType == "rotated")
                {
                    rotated = SaveAngles();
                }
                else
                {
                    turned = SaveAngles();
                }

                // Original Points
                if (original.Count != 0)
                {
                    for (int index = 0; index < original.Count - 1; index++)
                    {
                        save += original[index][0] + "," + original[index][1] + ":";
                    }
                    save += original[original.Count - 1][0] + "," + original[original.Count - 1][1] + ";";
                }
                else
                {
                    save += ";";
                }

                // Rotated Points
                if (original.Count != 0 && rotated.Count == 0)
                {
                    rotated = original;
                }
                if (rotated.Count != 0)
                {
                    for (int index = 0; index < rotated.Count - 1; index++)
                    {
                        save += rotated[index][0] + "," + rotated[index][1] + ":";
                    }
                    save += rotated[rotated.Count - 1][0] + "," + rotated[rotated.Count - 1][1] + ";";
                }
                else
                {
                    save += ";";
                }

                //Turned Points
                if (original.Count != 0 && turned.Count == 0)
                {
                    turned = original;
                }
                if (turned.Count != 0)
                {
                    for (int index = 0; index < turned.Count - 1; index++)
                    {
                        save += turned[index][0] + "," + turned[index][1] + ":";
                    }
                    save += turned[turned.Count - 1][0] + "," + turned[turned.Count - 1][1] + ";";
                }
                else
                {
                    save += ";";
                }

                if (pointCb.Checked == false)
                {
                    // Lines
                    for (int index = 0; index < joins.Count - 1; index++)
                    {
                        save += joins[index] + ",";
                    }
                    save += joins[joins.Count - 1] + ";";

                    // Solid
                    for (int index = 0; index < solid.Count - 1; index++)
                    {
                        save += solid[index] + ",";
                    }
                    save += solid[solid.Count - 1];
                }
                else
                {
                    save.Remove(save.Length - 1, 1);
                }

                // Add to saveData
                saveData.Add(save);

                // Set rAtT0
                if (tFromUpDown.Value == 0)
                {
                    rAtT0 = AssignPiecesArray(rotated);
                }

                // Change Provided Angles and Points
                if (tToUpDown.Value == 360)
                {
                    tFromUpDown.Value = 0;
                    tToUpDown.Value = 0;
                    rFromUpDown.Value = rToUpDown.Value;
                    original = AssignPiecesArray(rAtT0);
                }
                else
                {
                    tFromUpDown.Value = tToUpDown.Value;
                    original = AssignPiecesArray(turned);
                }

                // Clear Angles and Reset
                turned.Clear();
                rotated.Clear();
                angleType = "base";
                PointsLb.Items.Clear();
                for (int index = 0; index < original.Count; index++)
                {
                    PointsLb.Items.Add(original[index][0] + "," + original[index][1]);
                }
                DrawPoints();
            }
        }

        private void UpdateColours()
        {
            if (FillRb.Checked == true)
            {
                // ALLOW FOR GRADIENTS      ** TO DO **
                fillColour = Color.FromArgb((int)AlphaUpDown.Value, (int)RedUpDown.Value, (int)GreenUpDown.Value, (int)BlueUpDown.Value);
            }
            else
            {
                outlineColour = Color.FromArgb((int)AlphaUpDown.Value, (int)RedUpDown.Value, (int)GreenUpDown.Value, (int)BlueUpDown.Value);
            }
            DrawPoints();
        }

        private List<int[]> AssignPiecesArray(List<int[]> old)
        {
            List<int[]> newArray = new List<int[]>();
            for (int index = 0; index < old.Count; index++)
            {
                int[] xypoints = new int[2];
                xypoints[0] = old[index][0];
                xypoints[1] = old[index][1];
                newArray.Add(xypoints);
            }
            return newArray;
        }

        public void LoadIn(string goal)
        {
            Piece loadPiece = new Piece(loadTb.Text);

            // Select Goal
            switch (goal)
            {
                case "exit":
                    break;

                case "fillColour":
                    fillColour = loadPiece.GetColourArray()[0];   //** CHANGE WITH GRADIENTS**
                    break;

                case "outlineColour":
                    if (loadPiece.GetData()[0][0] == 'y')
                    {
                        outlineColour = loadPiece.GetColourArray()[loadPiece.GetColourArray().Length - 1];
                    }
                    else
                    {
                        outlineColour = Color.FromArgb(0, 255, 255, 255);
                    }
                    break;

                case "colours":
                    // Fill/ Gradient
                    fillColour = loadPiece.GetColourArray()[0];   //** CHANGE WITH GRADIENTS**
                    // Outline
                    if (loadPiece.GetData()[0][0] == 'y')
                    {
                        outlineColour = loadPiece.GetColourArray()[loadPiece.GetColourArray().Length - 1];
                    }
                    else
                    {
                        outlineColour = Color.FromArgb(0, 255, 255, 255);
                    }
                    break;

                default:
                    break;

            }
            DrawPoints();
        }
    }
}
