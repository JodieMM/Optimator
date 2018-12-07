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
        private List<Join> pointSpots = new List<Join>();
        private Piece WIP = new Piece();

        private List<double[]> oCoords = new List<double[]>();
        private List<double[]> rCoords = new List<double[]>();
        private List<double[]> tCoords = new List<double[]>();
        private List<double[]> oCoordsFull = new List<double[]>();
        private List<double[]> rCoordsFull = new List<double[]>();
        private List<double[]> tCoordsFull = new List<double[]>();
        private List<string> connectors = new List<string>();
        private List<string> solid = new List<string>();
        private List<string> joinsFull = new List<string>();
        private List<string> solidFull = new List<string>();

        private int selectedIndex = -1;
        private bool oMoving = false;
        private bool rMoving = false;
        private bool tMoving = false;
        private int joinMoving = -1;
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

            FillBox.BackColor = Constants.defaultFill;
            OutlineBox.BackColor = Constants.defaultOutline;
            OutlineWidthBox.Value = Constants.defaultOutlineWidth;
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
                int closestIndex = Utilities.FindClosestIndex(CombineCoordTypes(oCoords, pointSpots, 0), e.X, e.Y);
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
                        DeselectPoint();
                    }
                }
                else
                {
                    // Remove point or join
                    if (closestIndex < oCoords.Count)
                    {
                        // Remove selected point
                        oCoords.RemoveAt(closestIndex);
                        rCoords.RemoveAt(closestIndex);
                        tCoords.RemoveAt(closestIndex);
                        // Update Selected Index
                        if (selectedIndex >= closestIndex)
                        {
                            SelectPoint((selectedIndex - 1 < 0) ? -1 : selectedIndex - 1);
                        }
                    }
                    else
                    {
                        pointSpots.RemoveAt(closestIndex - oCoords.Count);
                    }
                }
            }
            else if (PointBtn.Text == "Select")
            {
                // Add Point
                int ToSelect = (oCoords.Count() == 0) ? 0 : selectedIndex + 1;
                oCoords.Insert(ToSelect, new double[] { e.X, e.Y });
                rCoords.Insert(ToSelect, new double[] { e.X, e.Y });
                tCoords.Insert(ToSelect, new double[] { e.X, e.Y });
                connectors.Insert(ToSelect, "line");
                solid.Insert(ToSelect, "s");
                SelectPoint(ToSelect);
            }
            else
            {
                // Select Point or Join
                int closestIndex = Utilities.FindClosestIndex(CombineCoordTypes(oCoords, pointSpots, 0), e.X, e.Y);
                if (closestIndex != -1)
                {
                    if (closestIndex < oCoords.Count)
                    {
                        SelectPoint(closestIndex);
                        oMoving = true;
                        originalMoving = new int[] { (int)oCoords[closestIndex][0], (int)oCoords[closestIndex][1] };
                    }
                    else
                    {
                        joinMoving = closestIndex - oCoords.Count;
                        positionMoving = new int[] { (int)pointSpots[joinMoving].X, (int)pointSpots[joinMoving].Y };
                    }
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
            else if (joinMoving != -1)
            {
                pointSpots[joinMoving].X = e.X;
                pointSpots[joinMoving].Y = e.Y;
                pointSpots[joinMoving].XRight = e.X;
                pointSpots[joinMoving].YDown = e.Y;
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
            if (e.X > DrawBase.Size.Width || e.Y > DrawBase.Size.Height || e.X < 0 || e.Y < 0)
            {
                StopMovement();
                return;
            }
            if (oMoving)
            {
                positionMoving = new int[] { e.X, e.Y };
                if (!movingFar)
                {
                    movingFar = Math.Abs(originalMoving[0] - positionMoving[0]) > Constants.ClickPrecision
                        || Math.Abs(originalMoving[1] - positionMoving[1]) > Constants.ClickPrecision;
                }
                DisplayDrawings();
            }
            else if (joinMoving != -1)
            {
                positionMoving = new int[] { e.X, e.Y };
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
            if (EraserBtn.Text == "Point")
            {
                // Erase Rotated
                DialogResult result = MessageBox.Show("Would you like to reset the rotated perspective?", "Reset Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    rCoords.Clear();
                    rCoords.AddRange(oCoords);
                }
            }
            else
            {
                int closestIndex = Utilities.FindClosestIndex(CombineCoordTypes(rCoords, pointSpots, 1), e.X, e.Y);
                if (closestIndex != -1)
                {
                    if (closestIndex < rCoords.Count)
                    {
                        // Select a Point
                        SelectPoint(closestIndex);
                        rMoving = true;
                        originalMoving = new int[] { (int)rCoords[closestIndex][0], (int)rCoords[closestIndex][1] };
                    }
                    else
                    {
                        // Select a Join
                        joinMoving = closestIndex - rCoords.Count;
                        positionMoving = new int[] { (int)pointSpots[joinMoving].XRight, -1 };
                    }
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
            else if (joinMoving != -1)
            {
                pointSpots[joinMoving].XRight = e.X;
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
            else if (joinMoving != -1)
            {
                positionMoving = new int[] { e.X, -1 };
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
            if (EraserBtn.Text == "Point")
            {
                // Erase Turned
                DialogResult result = MessageBox.Show("Would you like to reset the turned perspective?", "Reset Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    tCoords.Clear();
                    tCoords.AddRange(oCoords);
                }
            }
            else
            {
                int closestIndex = Utilities.FindClosestIndex(CombineCoordTypes(tCoords, pointSpots, 2), e.X, e.Y);
                if (closestIndex != -1)
                {
                    if (closestIndex < tCoords.Count)
                    {
                        // Select a Point
                        SelectPoint(closestIndex);
                        tMoving = true;
                        originalMoving = new int[] { (int)tCoords[closestIndex][0], (int)tCoords[closestIndex][1] };
                    }
                    else
                    {
                        // Select a Join
                        joinMoving = closestIndex - tCoords.Count;
                        positionMoving = new int[] { -1, (int)pointSpots[joinMoving].YDown };
                    }
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
            else if (joinMoving != -1)
            {
                pointSpots[joinMoving].YDown = e.Y;
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
            else if (joinMoving != -1)
            {
                positionMoving = new int[] { -1, e.Y };
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
            joinMoving = -1;
        }

        #endregion



        // ----- OPTION BUTTONS -----

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
            if (!CheckPiecesValid(oCoords, rCoords, tCoords)) { return; }
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
            if (!Constants.PermittedName.IsMatch(NameTb.Text))
            {
                MessageBox.Show("Please choose a valid name for your piece. Name can only include letters and numbers.", "Name Invalid", MessageBoxButtons.OK);
                return;
            }

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
                if (!CheckPiecesValid(oCoords, rCoords, tCoords)) { return; }
                ApplySegmentFully();

                // Save Points
                WIP.Name = NameTb.Text;
                double[] middle = Utilities.FindMid(oCoordsFull);
                Directory.CreateDirectory(Environment.CurrentDirectory + Constants.JoinsFolder + WIP.Name);
                for (int index = 0; index < pointSpots.Count; index++)
                {
                    pointSpots[index].Name = index.ToString();
                    pointSpots[index].SaveJoin(middle);
                }

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



        // ----- SHAPE TAB -----

        /// <summary>
        /// Changes the fill colour of the shape.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillBox_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog
            {
                Color = FillBox.BackColor,
                FullOpen = true
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                FillBox.BackColor = MyDialog.Color;
                WIP.FillColour = new Color[] { MyDialog.Color };
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Changes the outline colour of the shape.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutlineBox_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog
            {
                Color = OutlineBox.BackColor,
                FullOpen = true
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                OutlineBox.BackColor = MyDialog.Color;
                WIP.OutlineColour = MyDialog.Color;
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Changes the outline width of the piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutlineWidthBox_ValueChanged(object sender, EventArgs e)
        {
            WIP.OutlineWidth = OutlineWidthBox.Value;
            DisplayDrawings();
        }

        /// <summary>
        /// Changes the join at the selected point.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectorOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                connectors[selectedIndex] = Constants.connectorOptions[ConnectorOptions.SelectedIndex];
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Changes whether the selected point is
        /// solid or floating.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FixedCb_CheckedChanged(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                solid[selectedIndex] = (FixedCb.Checked) ? "s" : "f";
                DisplayDrawings();
            }
        }



        // ----- SETS TAB ------

        /// <summary>
        /// Adds a new point to the piece's connections.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPointBtn_Click(object sender, EventArgs e)
        {
            pointSpots.Add(new Join(WIP));
            DisplayDrawings();
        }



        // ----- DRAWING FUNCTIONS -----

        /// <summary>
        /// Draws the points of the WIP to the board
        /// Angle: Original = 2, Rotated = 3, Turned = 4
        /// </summary>
        /// <param name="board">The graphics board to be drawn on</param>
        /// <param name="angle">The angle to be drawn</param>
        private void DrawPoints(Graphics board, int angle)
        {
            List<double[]> coords = WIP.FindPoints(WIP.R, WIP.T, angle);
            if (coords == null) { return; }
            for (int index = 0; index < coords.Count; index++)
            {
                Color color = (index == selectedIndex) ? Color.Red : Color.Black;
                Utilities.DrawPoint(coords[index][0], coords[index][1], color, board);
            }
        }

        /// <summary>
        /// Draws the pieces on the 3 boards
        /// </summary>
        private void DisplayDrawings()
        {
            // Prepare Piece
            ConvertVariablesToData(rotationFrom, rotationTo, turnFrom, turnTo, oCoords, rCoords, tCoords, connectors, solid);

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
            foreach (Join spot in pointSpots)
            {
                Utilities.DrawPoint(spot.X, spot.Y, spot.FillColour, original);
            }
            if (oMoving && movingFar || (joinMoving != -1 && positionMoving[0] != -1 && positionMoving[1] != -1))
            {
                Utilities.DrawPoint(positionMoving[0], positionMoving[1], Constants.shadowShade, original);
            }

            // Draw Rotated Board
            WIP.R = 89.9999;
            WIP.T = 0;
            Utilities.DrawPiece(WIP, rotated, false);
            DrawPoints(rotated, 3);
            foreach (Join spot in pointSpots)
            {
                Utilities.DrawPoint(spot.XRight, spot.Y, spot.FillColour, rotated);
            }
            if (rMoving && movingFar)
            {
                Utilities.DrawPoint(positionMoving[0], positionMoving[1], Constants.shadowShade, rotated);
            }
            else if (joinMoving != -1)
            {
                if (positionMoving[1] == -1)
                {
                    Utilities.DrawPoint(positionMoving[0], pointSpots[joinMoving].Y, Constants.shadowShade, rotated);
                }
                else if (positionMoving[0] != -1)
                {
                    Utilities.DrawPoint(positionMoving[0], positionMoving[1], Constants.shadowShade, rotated);
                }
            }

            // Draw Turned Board
            WIP.R = 0;
            WIP.T = 89.9999;
            Utilities.DrawPiece(WIP, turned, false);
            DrawPoints(turned, 4);
            foreach (Join spot in pointSpots)
            {
                Utilities.DrawPoint(spot.X, spot.YDown, spot.FillColour, turned);
            }
            if (tMoving && movingFar)
            {
                Utilities.DrawPoint(positionMoving[0], positionMoving[1], Constants.shadowShade, turned);
            }
            else if (joinMoving != -1)
            {
                if (positionMoving[0] == -1)
                {
                    Utilities.DrawPoint(pointSpots[joinMoving].X, positionMoving[1], Constants.shadowShade, turned);
                }
                else if (positionMoving[1] != -1)
                {
                    Utilities.DrawPoint(positionMoving[0], positionMoving[1], Constants.shadowShade, turned);
                }
            }
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
            oCoordsFull.Clear(); tCoordsFull.Clear(); rCoordsFull.Clear(); joinsFull.Clear(); solidFull.Clear();
            oCoordsFull.AddRange(oCoords); tCoordsFull.AddRange(tCoords); rCoordsFull.AddRange(rCoords);
            joinsFull.AddRange(connectors); solidFull.AddRange(solid);
            Utilities.CoordsOnAllSides(oCoordsFull, rCoordsFull, tCoordsFull, joinsFull, solidFull);

            // Get 4th (Combo R and T)
            List<double[]> bCoords = new List<double[]>();
            for (int index = 0; index < rCoordsFull.Count; index++)
            {
                bCoords.Add(new double[] { rCoordsFull[index][0], tCoordsFull[index][1] });
            }
            
            ConvertVariablesToData(0, 90, 0, 90, oCoordsFull, rCoordsFull, tCoordsFull, joinsFull, solidFull);
            ConvertVariablesToData(90, 180, 0, 90, rCoordsFull, Utilities.FlipCoords(oCoordsFull, joinsFull, true, false), bCoords, joinsFull, solidFull);
            ConvertVariablesToData(180, 270, 0, 90, Utilities.FlipCoords(oCoordsFull, joinsFull, true, false), Utilities.FlipCoords(rCoordsFull, joinsFull, true, false), Utilities.FlipCoords(tCoordsFull, joinsFull, true, false), joinsFull, solidFull);
            ConvertVariablesToData(270, 360, 0, 90, Utilities.FlipCoords(rCoordsFull, joinsFull, true, false), oCoordsFull, Utilities.FlipCoords(bCoords, joinsFull, true, false), joinsFull, solidFull);

            ConvertVariablesToData(0, 90, 90, 180, tCoordsFull, bCoords, Utilities.FlipCoords(oCoordsFull, joinsFull, false, true), joinsFull, solidFull);
            ConvertVariablesToData(90, 180, 90, 180, bCoords, Utilities.FlipCoords(tCoordsFull, joinsFull, true, false), Utilities.FlipCoords(rCoordsFull, joinsFull, false, true), joinsFull, solidFull);
            ConvertVariablesToData(180, 270, 90, 180, Utilities.FlipCoords(tCoordsFull, joinsFull, true, false), Utilities.FlipCoords(bCoords, joinsFull, true, false), Utilities.FlipCoords(oCoordsFull, joinsFull, true, true), joinsFull, solidFull);
            ConvertVariablesToData(270, 360, 90, 180, Utilities.FlipCoords(bCoords, joinsFull, true, false), tCoordsFull, Utilities.FlipCoords(rCoordsFull, joinsFull, true, true), joinsFull, solidFull);

            ConvertVariablesToData(0, 90, 180, 270, Utilities.FlipCoords(oCoordsFull, joinsFull, false, true), Utilities.FlipCoords(rCoordsFull, joinsFull, false, true), Utilities.FlipCoords(tCoordsFull, joinsFull, false, true), joinsFull, solidFull);
            ConvertVariablesToData(90, 180, 180, 270, Utilities.FlipCoords(rCoordsFull, joinsFull, false, true), Utilities.FlipCoords(oCoordsFull, joinsFull, true, true), Utilities.FlipCoords(bCoords, joinsFull, false, true), joinsFull, solidFull);
            ConvertVariablesToData(180, 270, 180, 270, Utilities.FlipCoords(oCoordsFull, joinsFull, true, true), Utilities.FlipCoords(rCoordsFull, joinsFull, true, true), Utilities.FlipCoords(tCoordsFull, joinsFull, true, true), joinsFull, solidFull);
            ConvertVariablesToData(270, 360, 180, 270, Utilities.FlipCoords(rCoordsFull, joinsFull, true, true), Utilities.FlipCoords(oCoordsFull, joinsFull, false, true), Utilities.FlipCoords(bCoords, joinsFull, true, true), joinsFull, solidFull);

            ConvertVariablesToData(0, 90, 270, 360, Utilities.FlipCoords(tCoordsFull, joinsFull, false, true), Utilities.FlipCoords(bCoords, joinsFull, false, true), oCoordsFull, joinsFull, solidFull);
            ConvertVariablesToData(90, 180, 270, 360, Utilities.FlipCoords(bCoords, joinsFull, false, true), Utilities.FlipCoords(tCoordsFull, joinsFull, true, true), rCoordsFull, joinsFull, solidFull);
            ConvertVariablesToData(180, 270, 270, 360, Utilities.FlipCoords(tCoordsFull, joinsFull, true, true), Utilities.FlipCoords(bCoords, joinsFull, true, true), Utilities.FlipCoords(oCoordsFull, joinsFull, true, false), joinsFull, solidFull);
            ConvertVariablesToData(270, 360, 270, 360, Utilities.FlipCoords(bCoords, joinsFull, true, true), Utilities.FlipCoords(tCoordsFull, joinsFull, false, true), Utilities.FlipCoords(rCoordsFull, joinsFull, true, false), joinsFull, solidFull);
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

        /// <summary>
        /// Checks whether the pieces drawn can be calculated correctly.
        /// </summary>
        /// <param name="o">Base piece coordinates</param>
        /// <param name="r">Rotated piece coordinates</param>
        /// <param name="t">Turned piece coordinates</param>
        /// <returns></returns>
        private bool CheckPiecesValid(List<double[]> o, List<double[]> r, List<double[]> t)
        {
            if (o.Count < 2) { return true; }

            // Check oCoords
            for (int xy = 0; xy < 2; xy++)
            {
                bool bigger = (o[0][xy] < o[1][xy]);
                int switchCount = 0;
                for (int index = 0; index < o.Count - 1; index++)
                {
                    if (o[index][xy] < o[index + 1][xy] != bigger)
                    {
                        bigger = !bigger;
                        switchCount++;
                    }
                }
                if (switchCount > 2)
                {
                    MessageBox.Show("Invalid base shape. Ensure shape does not fold back on itself.", "Invalid base shape", MessageBoxButtons.OK);
                    return false;
                }
            }

            // Check rCoords
            for (int xy = 0; xy < 2; xy++)
            {
                bool bigger = (r[0][xy] < r[1][xy]);
                int switchCount = 0;
                for (int index = 0; index < r.Count - 1; index++)
                {
                    if (r[index][xy] < r[index + 1][xy] != bigger)
                    {
                        bigger = !bigger;
                        switchCount++;
                    }
                }
                if (switchCount > 2)
                {
                    MessageBox.Show("Invalid right shape. Ensure shape does not fold back on itself.", "Invalid right shape", MessageBoxButtons.OK);
                    return false;
                }
            }

            // Check tCoords
            for (int xy = 0; xy < 2; xy++)
            {
                bool bigger = (t[0][xy] < t[1][xy]);
                int switchCount = 0;
                for (int index = 0; index < t.Count - 1; index++)
                {
                    if (t[index][xy] < t[index + 1][xy] != bigger)
                    {
                        bigger = !bigger;
                        switchCount++;
                    }
                }
                if (switchCount > 2)
                {
                    MessageBox.Show("Invalid bottom shape. Ensure shape does not fold back on itself.", "Invalid bottom shape", MessageBoxButtons.OK);
                    return false;
                }
            }
            return true;
        }



        // ----- UTILITY FUNCTIONS -----

        /// <summary>
        /// Combines a list of coordinates with a list of points to
        /// return a searchable list of double arrays.
        /// </summary>
        /// <param name="coords">Piece coordinates</param>
        /// <param name="pointsList">Pointspots of the shape</param>
        /// <param name="pointAngle">0 original, 1 rotated, 2 turned</param>
        /// <returns></returns>
        public static List<double[]> CombineCoordTypes(List<double[]> coords, List<Join> pointsList, int pointAngle)
        {
            if (pointsList.Count == 0) { return coords; }
            List<double[]> searching = new List<double[]>();
            searching.AddRange(coords);
            // Original
            if (pointAngle == 0)
            {
                foreach (Join pointspot in pointsList)
                {
                    searching.Add(new double[] { pointspot.X, pointspot.Y });
                }
            }
            // Rotated
            else if (pointAngle == 1)
            {
                foreach (Join pointspot in pointsList)
                {
                    searching.Add(new double[] { pointspot.XRight, pointspot.Y });
                }
            }
            // Turned
            else
            {
                foreach (Join pointspot in pointsList)
                {
                    searching.Add(new double[] { pointspot.X, pointspot.YDown });
                }
            }
            return searching;
        }

        /// <summary>
        /// Selects a point and updates the form to
        /// display relevant values.
        /// </summary>
        /// <param name="index"></param>
        private void SelectPoint(int index)
        {
            if (index < 0)
            {
                DeselectPoint();
            }
            else
            {
                selectedIndex = index;
                ConnectorOptions.Enabled = true;
                ConnectorOptions.SelectedIndex = Array.IndexOf(Constants.connectorOptions, connectors[selectedIndex]);
                ShowFixedBtn.Enabled = true;
                FixedCb.Enabled = true;
                FixedCb.Checked = solid[selectedIndex] == "s";
            }
        }

        /// <summary>
        /// Deselects a point and disables features
        /// that require a point be selected.
        /// </summary>
        private void DeselectPoint()
        {
            selectedIndex = -1;
            ConnectorOptions.Enabled = false;
            ShowFixedBtn.Enabled = false;
            FixedCb.Enabled = false;
        }
    }
}
