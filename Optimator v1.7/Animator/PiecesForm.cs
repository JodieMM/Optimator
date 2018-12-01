using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Animator
{
    /// <summary>
    /// The form used to generate and modify pieces and points.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class PiecesForm : Form
    {
        #region PiecesForm Variables
        private Graphics original;
        private Graphics rotated;
        private Graphics turned;
        private List<Piece> sketch = new List<Piece>();
        private Piece WIP = new Piece(Constants.PieceStructure);

        private List<double[]> oCoords = new List<double[]>();
        private List<double[]> rCoords = new List<double[]>();
        private List<double[]> tCoords = new List<double[]>();
        private List<string> joins = new List<string>();
        private List<string> solid = new List<string>();

        private int selectedIndex = 0;
        private bool oMoving = false;
        private bool rMoving = false;
        private bool tMoving = false;
        private bool movingFar = false;
        private int[] originalMoving;
        private int[] positionMoving;
        #endregion

        // TEMP
        private double rotationTo = 90;
        private double turnTo = 90;
        private double rotationFrom = 0;
        private double turnFrom = 0;


        /// <summary>
        /// Constructor creates a PiecesForm page
        /// </summary>
        public PiecesForm()
        {
            InitializeComponent();

            DrawBase.MouseDown += new MouseEventHandler(DrawBase_MouseDown);
            DrawBase.MouseUp += new MouseEventHandler(DrawBase_MouseUp);
            DrawBase.MouseMove += new MouseEventHandler(DrawBase_MouseMove);

            DrawRight.MouseDown += new MouseEventHandler(DrawRight_MouseDown);
            DrawRight.MouseUp += new MouseEventHandler(DrawRight_MouseUp);
            DrawRight.MouseMove += new MouseEventHandler(DrawRight_MouseMove);

            DrawDown.MouseDown += new MouseEventHandler(DrawDown_MouseDown);
            DrawDown.MouseUp += new MouseEventHandler(DrawDown_MouseUp);
            DrawDown.MouseMove += new MouseEventHandler(DrawDown_MouseMove);

            WIP.Name = Constants.WIPName;
        }



        // ----- DRAWING BOARDS -----
        #region Drawing Boards I/O

        /// <summary>
        /// Places or selects a point on the main board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBase_MouseDown(object sender, MouseEventArgs e)
        {
            StopMovement();

            if (EraserBtn.Text == "Point")
            {
                int closestIndex = Utilities.FindClosestIndex(oCoords, e.X, e.Y);
                if (closestIndex == -1)
                {
                    // Clear entire piece
                    DialogResult result = MessageBox.Show("Would you like to restart the piece?", "Restart Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        oCoords.Clear();
                        rCoords.Clear();
                        tCoords.Clear();
                        string dataLine = WIP.Data[0];
                        WIP.Data.Clear();
                        WIP.Data.Add(dataLine);
                        selectedIndex = 0;
                    }
                }
                else
                {
                    // Remove selected point
                    oCoords.RemoveAt(closestIndex);
                    rCoords.RemoveAt(closestIndex);
                    tCoords.RemoveAt(closestIndex);
                    // Update Selected Index
                    if (selectedIndex >= closestIndex)
                    {
                        selectedIndex = (selectedIndex - 1 < 0) ? 0 : selectedIndex - 1;
                    }
                }
            }
            else if (PointBtn.Text == "Select")
            {
                selectedIndex = (oCoords.Count() == 0) ? 0 : selectedIndex + 1;
                oCoords.Insert(selectedIndex, new double[] { e.X, e.Y });
                rCoords.Insert(selectedIndex, new double[] { e.X, e.Y });
                tCoords.Insert(selectedIndex, new double[] { e.X, e.Y });
                joins.Insert(selectedIndex, "line");
                solid.Insert(selectedIndex, "s");
            }
            else
            {
                int closestIndex = Utilities.FindClosestIndex(oCoords, e.X, e.Y);
                if (closestIndex != -1)
                {
                    selectedIndex = closestIndex;
                    oMoving = true;
                    originalMoving = new int[] { (int)oCoords[closestIndex][0], (int)oCoords[closestIndex][1] };
                }
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Moves a point if move is in progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBase_MouseUp(object sender, MouseEventArgs e)
        {
            if (oMoving && movingFar)
            {
                oCoords[selectedIndex] = new double[] { e.X, e.Y };
                rCoords[selectedIndex] = new double[] { e.X, e.Y };
                tCoords[selectedIndex] = new double[] { e.X, e.Y };
            }
            StopMovement();
            DisplayDrawings();
        }

        /// <summary>
        /// Updates movement as mouse position changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBase_MouseMove(object sender, MouseEventArgs e)
        {
            if (oMoving)
            {
                if (e.X < 0 || e.Y < 0 || e.X > DrawBase.Size.Width || e.Y > DrawBase.Size.Height)
                {
                    StopMovement();
                }
                else
                {
                    positionMoving = new int[] { e.X, e.Y };
                    if (!movingFar)
                    {
                        movingFar = Math.Abs(originalMoving[0] - positionMoving[0]) > Constants.ClickPrecision
                            || Math.Abs(originalMoving[1] - positionMoving[1]) > Constants.ClickPrecision;
                    }
                }
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Places or selects a point on the rotation board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawRight_MouseDown(object sender, MouseEventArgs e)
        {
            StopMovement();

            int mouseX = e.X; int mouseY = e.Y;
            if (EraserBtn.Text == "Point")
            {
                DialogResult result = MessageBox.Show("Would you like to reset the rotated perspective?", "Reset Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    rCoords.Clear();
                    rCoords.AddRange(oCoords);
                }
            }
            else
            {
                int closestIndex = Utilities.FindClosestIndex(rCoords, e.X, e.Y);
                if (closestIndex != -1)
                {
                    selectedIndex = closestIndex;
                    rMoving = true;
                    originalMoving = new int[] { (int)rCoords[closestIndex][0], (int)rCoords[closestIndex][1] };
                }
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Moves a point if move is in progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawRight_MouseUp(object sender, MouseEventArgs e)
        {
            if (rMoving && movingFar)
            {
                rCoords[selectedIndex] = new double[] { e.X, rCoords[selectedIndex][1] };
            }
            StopMovement();
            DisplayDrawings();
        }

        /// <summary>
        /// Updates movement as mouse position changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (rMoving)
            {
                if (e.X < 0 || e.Y < 0 || e.X > DrawRight.Size.Width || e.Y > DrawRight.Size.Height)
                {
                    StopMovement();
                }
                else
                {
                    positionMoving = new int[] { e.X, originalMoving[1] };
                    if (!movingFar)
                    {
                        movingFar = Math.Abs(originalMoving[0] - positionMoving[0]) > Constants.ClickPrecision
                            || Math.Abs(originalMoving[1] - positionMoving[1]) > Constants.ClickPrecision;
                    }
                }
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Places or selects a point on the turn board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawDown_MouseDown(object sender, MouseEventArgs e)
        {
            StopMovement();

            int mouseX = e.X; int mouseY = e.Y;
            if (EraserBtn.Text == "Point")
            {
                DialogResult result = MessageBox.Show("Would you like to reset the turned perspective?", "Reset Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    tCoords.Clear();
                    tCoords.AddRange(oCoords);
                }
            }
            else
            {
                int closestIndex = Utilities.FindClosestIndex(tCoords, e.X, e.Y);
                if (closestIndex != -1)
                {
                    selectedIndex = closestIndex;
                    tMoving = true;
                    originalMoving = new int[] { (int)tCoords[closestIndex][0], (int)tCoords[closestIndex][1] };
                }
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Moves a point if move is in progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (tMoving && movingFar)
            {
                tCoords[selectedIndex] = new double[] { tCoords[selectedIndex][0], e.Y };
            }
            StopMovement();
            DisplayDrawings();
        }

        /// <summary>
        /// Updates movement as mouse position changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawDown_MouseMove(object sender, MouseEventArgs e)
        {
            if (tMoving)
            {
                if (e.X < 0 || e.Y < 0 || e.X > DrawDown.Size.Width || e.Y > DrawDown.Size.Height)
                {
                    StopMovement();
                }
                else
                {
                    positionMoving = new int[] { originalMoving[0], e.Y };
                    if (!movingFar)
                    {
                        movingFar = Math.Abs(originalMoving[0] - positionMoving[0]) > Constants.ClickPrecision
                            || Math.Abs(originalMoving[1] - positionMoving[1]) > Constants.ClickPrecision;
                    }
                }
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Resets all movement boolean variables to false.
        /// </summary>
        private void StopMovement()
        {
            oMoving = false;
            rMoving = false;
            tMoving = false;
            movingFar = false;
        }

        #endregion



        // ----- MAIN BUTTONS -----

        /// <summary>
        /// Changes between placing points and selecting them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointBtn_Click(object sender, EventArgs e)
        {
            PointBtn.Text = (PointBtn.Text == "Select") ? "Place" : "Select";
        }

        /// <summary>
        /// When active, overrides point placement/selection and removes points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EraserBtn_Click(object sender, EventArgs e)
        {
            EraserBtn.Text = (EraserBtn.Text == "Eraser") ? "Point" : "Eraser";
        }

        /// <summary>
        /// Opens a preview panel to display the piece in full angles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            ApplySegmentFully();
            PreviewForm previewForm = new PreviewForm(WIP);
            previewForm.Show();
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Yes;
            // Only ask if there is something to save
            if (oCoords.Count > 0)
            {
                result = MessageBox.Show("Do you want to exit without saving? Your piece will be lost.", "Exit Confirmation", MessageBoxButtons.YesNo);
            }
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        /// <summary>
        /// Saves the piece and closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            // Check Name is Valid for Saving
            if (Constants.InvalidNames.Contains(NameTb.Text) || !Constants.PermittedName.IsMatch(NameTb.Text))
            {
                MessageBox.Show("Please choose a valid name for your piece. Name can only include letters and numbers.", "Name Invalid", MessageBoxButtons.OK);
            }
            else if (Constants.ReservedNames.Contains(NameTb.Text))
            {
                MessageBox.Show("This name is reserved. Please choose a new name for your piece.", "Name Reserved", MessageBoxButtons.OK);
            }
            // Name is Valid
            else
            {
                // Check name not already in use, or that overriding is okay
                DialogResult result = DialogResult.Yes;
                if (File.Exists(Utilities.GetDirectory(Constants.PiecesFolder, NameTb.Text)))
                {
                    result = MessageBox.Show("This name is already in use. Do you want to override the existing piece?", "Override Confirmation", MessageBoxButtons.YesNo);
                }
                if (result == DialogResult.No) { return; }

                // Save Piece and Close Form
                try
                {
                    ApplySegmentFully();
                    Utilities.SaveData(Utilities.GetDirectory(Constants.PiecesFolder, NameTb.Text), WIP.Data);
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
        }



        // ----- DRAWING FUNCTIONS -----

        /// <summary>
        /// Draws a + at the given coordinate
        /// </summary>
        /// <param name="xcood">X coordinate of + centre</param>
        /// <param name="ycood">Y coordinate of + centre</param>
        /// <param name="colour">Colour of the +</param>
        /// <param name="board">The graphics board to be drawn on</param>
        private void DrawPoint(double xcood, double ycood, Color colour, Graphics board)
        {
            int x = (int)xcood;
            int y = (int)ycood;
            Pen pen = new Pen(colour);
            board.DrawLine(pen, new Point(x - 2, y), new Point(x + 2, y));
            board.DrawLine(pen, new Point(x, y - 2), new Point(x, y + 2));
        }

        /// <summary>
        /// Draws the points of the WIP to the board
        /// Angle: Original = 2, Rotated = 3, Turned = 4
        /// </summary>
        /// <param name="board">The graphics board to be drawn on</param>
        /// <param name="angle">The angle to be drawn</param>
        private void DrawPoints(Graphics board, int angle)
        {
            List<double[]> coords = WIP.FindPoints(WIP.R, WIP.T, angle);
            Color color;

            for (int index = 0; index < coords.Count; index++)
            {
                color = (index == selectedIndex) ? Color.Red : Color.Black;
                DrawPoint(coords[index][0], coords[index][1], color, board);
            }
        }

        /// <summary>
        /// Draws the pieces on the 3 boards
        /// </summary>
        private void DisplayDrawings()
        {
            // Prepare Piece
            ConvertVariablesToData(rotationFrom, rotationTo, turnFrom, turnTo, oCoords, rCoords, tCoords, joins, solid);

            // Prepare Boards
            DrawBase.Refresh();
            DrawRight.Refresh();
            DrawDown.Refresh();
            original = DrawBase.CreateGraphics();
            rotated = DrawRight.CreateGraphics();
            turned = DrawDown.CreateGraphics();

            // Draw Base Board
            WIP.R = 0;
            WIP.T = 0;
            Utilities.DrawPiece(WIP, original, false);
            DrawPoints(original, 2);
            if (oMoving && movingFar) { DrawPoint(positionMoving[0], positionMoving[1], Color.DarkGray, original); }
            

            // Draw Rotated Board
            WIP.R = 89.9999;
            WIP.T = 0;
            Utilities.DrawPiece(WIP, rotated, false);
            DrawPoints(rotated, 3);
            if (rMoving && movingFar) { DrawPoint(positionMoving[0], positionMoving[1], Color.DarkGray, rotated); }

            // Draw Turned Board
            WIP.R = 0;
            WIP.T = 89.9999;
            Utilities.DrawPiece(WIP, turned, false);
            DrawPoints(turned, 4);
            if (tMoving && movingFar) { DrawPoint(positionMoving[0], positionMoving[1], Color.DarkGray, turned); }
            WIP.T = 0;
        }



        // ----- DATA FUNCTIONS -----

        /// <summary>
        /// Applies the 3-board segment across the entire piece.
        /// </summary>
        private void ApplySegmentFully()
        {
            WIP.UpdateDataInfoLine();

            // Update coords to include matching points to the right/left
            /*
            for (int index = 0; index < oCoords.Count; index++)
            {
                if (Utilities.FindMatchIndex(oCoords, index, 1) != -1)
                {
                    oCoords.Add(new double[] { oCoords[Utilities.FindMatchIndex(oCoords, index, 1)][0], oCoords[index][1] });
                }
                else
                {
                    oCoords.Add(oCoords[index]);
                }
            }*/

            // ** REPEAT ABOVE FOR r AND t coords
            Utilities.CoordsOnAllSides(oCoords, rCoords, tCoords, joins);

            // Get 4th (Combo R and T)
            List<double[]> bCoords = new List<double[]>();
            for (int index = 0; index < rCoords.Count; index++)
            {
                bCoords.Add(new double[] { rCoords[index][0], tCoords[index][1] });
            }
            
            ConvertVariablesToData(0, 90, 0, 90, oCoords, rCoords, tCoords, joins, solid);
            ConvertVariablesToData(90, 180, 0, 90, rCoords, Utilities.FlipCoords(oCoords, joins, true, false), bCoords, joins, solid);
            ConvertVariablesToData(180, 270, 0, 90, Utilities.FlipCoords(oCoords, joins, true, false), Utilities.FlipCoords(rCoords, joins, true, false), Utilities.FlipCoords(tCoords, joins, true, false), joins, solid);
            ConvertVariablesToData(270, 360, 0, 90, Utilities.FlipCoords(rCoords, joins, true, false), oCoords, Utilities.FlipCoords(bCoords, joins, true, false), joins, solid);

            ConvertVariablesToData(0, 90, 90, 180, tCoords, bCoords, Utilities.FlipCoords(oCoords, joins, false, true), joins, solid);
            ConvertVariablesToData(90, 180, 90, 180, bCoords, Utilities.FlipCoords(tCoords, joins, true, false), Utilities.FlipCoords(rCoords, joins, false, true), joins, solid);
            ConvertVariablesToData(180, 270, 90, 180, Utilities.FlipCoords(tCoords, joins, true, false), Utilities.FlipCoords(bCoords, joins, true, false), Utilities.FlipCoords(oCoords, joins, true, true), joins, solid);
            ConvertVariablesToData(270, 360, 90, 180, Utilities.FlipCoords(bCoords, joins, true, false), tCoords, Utilities.FlipCoords(rCoords, joins, true, true), joins, solid);

            ConvertVariablesToData(0, 90, 180, 270, Utilities.FlipCoords(oCoords, joins, false, true), Utilities.FlipCoords(rCoords, joins, false, true), Utilities.FlipCoords(tCoords, joins, false, true), joins, solid);
            ConvertVariablesToData(90, 180, 180, 270, Utilities.FlipCoords(rCoords, joins, false, true), Utilities.FlipCoords(oCoords, joins, true, true), Utilities.FlipCoords(bCoords, joins, false, true), joins, solid);
            ConvertVariablesToData(180, 270, 180, 270, Utilities.FlipCoords(oCoords, joins, true, true), Utilities.FlipCoords(rCoords, joins, true, true), Utilities.FlipCoords(tCoords, joins, true, true), joins, solid);
            ConvertVariablesToData(270, 360, 180, 270, Utilities.FlipCoords(rCoords, joins, true, true), Utilities.FlipCoords(oCoords, joins, false, true), Utilities.FlipCoords(bCoords, joins, true, true), joins, solid);

            ConvertVariablesToData(0, 90, 270, 360, Utilities.FlipCoords(tCoords, joins, false, true), Utilities.FlipCoords(bCoords, joins, false, true), oCoords, joins, solid);
            ConvertVariablesToData(90, 180, 270, 360, Utilities.FlipCoords(bCoords, joins, false, true), Utilities.FlipCoords(tCoords, joins, true, true), rCoords, joins, solid);
            ConvertVariablesToData(180, 270, 270, 360, Utilities.FlipCoords(tCoords, joins, true, true), Utilities.FlipCoords(bCoords, joins, true, true), Utilities.FlipCoords(oCoords, joins, true, false), joins, solid);
            ConvertVariablesToData(270, 360, 270, 360, Utilities.FlipCoords(bCoords, joins, true, true), Utilities.FlipCoords(tCoords, joins, false, true), Utilities.FlipCoords(rCoords, joins, true, false), joins, solid);
        }

        /// <summary>
        /// Converts relevant variables for a piece's angle into a data line and saves to piece data.
        /// </summary>
        /// <param name="rFrom">Rotation start</param>
        /// <param name="rTo">Rotation end</param>
        /// <param name="tFrom">Turn start</param>
        /// <param name="tTo">Turn end</param>
        /// <param name="originalCoords">Coordinates for original state</param>
        /// <param name="rotatedCoords">Coordinates for rotated state</param>
        /// <param name="turnedCoords">Coordinates for turned state</param>
        /// <param name="joinsList">Joins between points</param>
        /// <param name="detailsList">Details of points</param>
        private void ConvertVariablesToData (double rFrom, double rTo, double tFrom, double tTo, 
            List<double[]> originalCoords, List<double[]> rotatedCoords, List<double[]> turnedCoords,
            List<string> joinsList, List<string> detailsList)
        {
            // When No Coords
            if (originalCoords.Count < 1)
            {
                int workingRow = Utilities.FindRow(rFrom, tFrom, WIP.Data, 1);
                if (workingRow != -1) { WIP.Data.RemoveAt(workingRow); }
            }
            else
            {

                // Angles
                string WIPstring = rFrom.ToString().PadLeft(3, '0') + ":" + rTo.ToString().PadLeft(3, '0') + ";" +
                    tFrom.ToString().PadLeft(3, '0') + ":" + tTo.ToString().PadLeft(3, '0') + ";";

                // Original Coords
                for (int index = 0; index < originalCoords.Count; index++)
                {
                    WIPstring += originalCoords[index][0] + "," + originalCoords[index][1];
                    WIPstring += (index == originalCoords.Count - 1) ? ";" : ":";
                }

                // Rotated Coords
                for (int index = 0; index < rotatedCoords.Count; index++)
                {
                    WIPstring += rotatedCoords[index][0] + "," + rotatedCoords[index][1];
                    WIPstring += (index == rotatedCoords.Count - 1) ? ";" : ":";
                }

                // Turned Coords
                for (int index = 0; index < turnedCoords.Count; index++)
                {
                    WIPstring += turnedCoords[index][0] + "," + turnedCoords[index][1];
                    WIPstring += (index == turnedCoords.Count - 1) ? ";" : ":";
                }

                // Joins
                for (int index = 0; index < joinsList.Count; index++)
                {
                    WIPstring += joinsList[index];
                    WIPstring += (index == joinsList.Count - 1) ? ";" : ",";
                }

                // Details
                for (int index = 0; index < detailsList.Count; index++)
                {
                    WIPstring += detailsList[index];
                    WIPstring += (index == detailsList.Count - 1) ? "" : ",";
                }

                WIP.UpdateDataLine(rFrom, tFrom, WIPstring);
            }
        }



        // ----- TO INCLUDE/ REDO -----
        #region WIP
        /*
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

        private void UpdateColours()
        {
            if (OutlineRb.Checked == true)
            {
                WIP.SetOutlineColour(Color.FromArgb((int)AlphaUpDown.Value, (int)RedUpDown.Value, (int)GreenUpDown.Value, (int)BlueUpDown.Value));
            }
            else
            {
                // ALLOW FOR GRADIENTS      ** TO DO **
                WIP.SetFillColour(new Color[] { Color.FromArgb((int)AlphaUpDown.Value, (int)RedUpDown.Value, (int)GreenUpDown.Value, (int)BlueUpDown.Value) });
            }
            DrawPoints();
        }

        private void FillRb_CheckedChanged(object sender, EventArgs e)
        {
            if (FillRb.Checked == true)
            {
                int[] coloursHold = new int[] { WIP.GetFillColour()[0].A, WIP.GetFillColour()[0].R, WIP.GetFillColour()[0].G, WIP.GetFillColour()[0].B };
                AlphaUpDown.Value = coloursHold[0];
                RedUpDown.Value = coloursHold[1];
                GreenUpDown.Value = coloursHold[2];
                BlueUpDown.Value = coloursHold[3];
                label8.ForeColor = Color.Black;
                label10.ForeColor = Color.Black;
                midFillCb.ForeColor = Color.Black;
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
                int[] coloursHold = new int[] { WIP.GetOutlineColour().A, WIP.GetOutlineColour().R, WIP.GetOutlineColour().G, WIP.GetOutlineColour().B };
                AlphaUpDown.Value = coloursHold[0];
                RedUpDown.Value = coloursHold[1];
                GreenUpDown.Value = coloursHold[2];
                BlueUpDown.Value = coloursHold[3];
                label8.ForeColor = Color.DimGray;
                label10.ForeColor = Color.DimGray;
                midFillCb.ForeColor = Color.DimGray;
                midFillCb.Enabled = false;
                numColUpDown.Enabled = false;
                gradAngleUpDown.Enabled = false;
            }
            DrawPoints();
        }

        private void Joins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                joins[PointsLb.SelectedIndex] = (string)JoinOptions.SelectedItem;
            }
        }

        private void FixedCb_CheckedChanged(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                solid[PointsLb.SelectedIndex] = (FixedCb.Checked == true) ? "s" : "f";
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

        private void OutlineWidthUpDown_ValueChanged(object sender, EventArgs e)
        {
            WIP.SetOutlineWidth((int)OutlineWidthUpDown.Value);
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
            }
            catch (System.IO.FileNotFoundException)        // ** ADD IN ERROR IF SET CHOSEN **
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
                    //Remove excess points from listbox
                    foreach (Object lbpoint in PointsLb.Items)
                    {
                        if (lbpoint != PointsLb.Items[0])
                        {
                            PointsLb.Items.Remove(lbpoint);
                        }
                    }

                    //Remove excess points from original/rotated/turned
                    if (original.Count > 0)
                    {
                        double[] holder = original[0];
                        original.Clear();
                        original.Add(holder);
                    }
                    if (rotated.Count > 0)
                    {
                        double[] holder = rotated[0];
                        rotated.Clear();
                        rotated.Add(holder);
                    }
                    if (turned.Count > 0)
                    {
                        double[] holder = turned[0];
                        turned.Clear();
                        turned.Add(holder);
                    }

                    //If no point exists, add one (as adding functions are now disabled to prevent adding multiple points)
                    if (PointsLb.Items.Count == 0)
                    {
                        AddPoint(400, 400);
                    }

                    loadBtn.Enabled = false;
                    AddPointBtn.Enabled = false;
                    DeleteBtn.Enabled = false;
                    JoinOptions.Enabled = false;

                    folder = pointsFolder;
                    WIP = new Piece(tempPoint, folder);


                    // ** POTENTIAL TO SAVE EXISTING DATA IS HERE BUT LOST
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
                label15.Enabled = false;
                OutlineWidthUpDown.Enabled = false;
            }
            else
            {
                folder = piecesFolder;
                WIP = new Piece(tempPiece);

                sketchBtn.Enabled = true;
                loadBtn.Enabled = true;
                AddPointBtn.Enabled = true;
                DeleteBtn.Enabled = true;
                JoinOptions.Enabled = true;

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
                label15.Enabled = true;
                OutlineWidthUpDown.Enabled = true;
            }

            DrawPoints();
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
            // CHECK FOR OVERRIDING AND CONFIRM INTENTION ** TO DO
            // CHECK FOR NO CHANGE TO ROTATION / TURN AND CHECK INTENTION ** TO DO
            if (doEet)
            {
                // Fill in blank data before continuing
                if (rotated.Count == 0)
                {
                    rotated.AddRange(original);
                }
                if (turned.Count == 0)
                {
                    turned.AddRange(original);
                }

                // Get values from holding arrays
                string save = ConvertCurrentAngle();

                // Add to piece data
                WIP.ReplaceDataLine(save);

                // Change Provided Angles and Points
                if (rToUpDown.Value == 360)
                {
                    rFromUpDown.Value = 0;
                    rToUpDown.Value = 0;
                    tFromUpDown.Value = tToUpDown.Value;
                }
                else
                {
                    rFromUpDown.Value = rToUpDown.Value;
                }

                // Clear Angles and Reset
                turned.Clear();
                rotated.Clear();
                original.Clear();
                angleType = "base";
                WIP.AddDataLine("000:000;000:000;;;;;");
                ResetOriginal();
                DrawPoints();
            }
        }

        private void wrUpDown_ValueChanged(object sender, EventArgs e)
        {
            WIP.SetPieceDetails("wr" + wrUpDown.Value);
        }
        */
        #endregion

        private void TestingButton_Click(object sender, EventArgs e)
        {
            Utilities.CoordsOnAllSides(oCoords, rCoords, tCoords, joins);
            DisplayDrawings();
        }
    }
}
