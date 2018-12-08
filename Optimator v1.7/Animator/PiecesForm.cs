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
        public List<Piece> Sketch { get; set; } = new List<Piece>();
        private List<Join> joins = new List<Join>();
        public Piece WIP { get; } = new Piece();
        private List<Spot> spots = new List<Spot>();

        private int selectedIndex = -1;
        private bool oMoving = false;
        private bool rMoving = false;
        private bool tMoving = false;
        private int joinMoving = -1;
        private bool movingFar = false;
        private int[] originalMoving;
        private int[] positionMoving;

        private Color button = Color.LightCyan;
        private Color pressed = Color.FromArgb(255, 204, 255, 255);
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
                int closestIndex = Utilities.FindClosestIndex(CombineCoordTypes(spots, joins, 0), e.X, e.Y);
                if (closestIndex == -1)
                {
                    // Clear entire piece
                    DialogResult result = MessageBox.Show("Would you like to restart the piece?", "Restart Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        spots.Clear();
                        WIP.Data.Clear();
                        WIP.UpdateDataInfoLine();
                        DeselectPoint();
                    }
                }
                else
                {
                    // Remove point or join
                    if (closestIndex < spots.Count)
                    {
                        // Remove selected point
                        spots.RemoveAt(closestIndex);
                        // Update Selected Index
                        if (selectedIndex >= closestIndex)
                        {
                            SelectPoint((selectedIndex - 1 < 0) ? -1 : selectedIndex - 1);
                        }
                    }
                    else
                    {
                        joins.RemoveAt(closestIndex - spots.Count);
                    }
                }
            }
            else if (PointBtn.Text == "Select")
            {
                // Add Point
                int ToSelect = (spots.Count() == 0) ? 0 : selectedIndex + 1;
                spots.Insert(ToSelect, new Spot(e.X, e.Y));
                SelectPoint(ToSelect);
            }
            else
            {
                // Select Point or Join
                int closestIndex = Utilities.FindClosestIndex(CombineCoordTypes(spots, joins, 0), e.X, e.Y);
                if (closestIndex != -1)
                {
                    if (closestIndex < spots.Count)
                    {
                        SelectPoint(closestIndex);
                        oMoving = true;
                        originalMoving = new int[] { (int)spots[closestIndex].X, (int)spots[closestIndex].Y };
                    }
                    else
                    {
                        joinMoving = closestIndex - spots.Count;
                        positionMoving = new int[] { (int)joins[joinMoving].X, (int)joins[joinMoving].Y };
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
                spots[selectedIndex].X = e.X;
                spots[selectedIndex].Y = e.Y;
                spots[selectedIndex].XRight = e.X;
                spots[selectedIndex].YDown = e.Y;
            }
            else if (joinMoving != -1)
            {
                joins[joinMoving].X = e.X;
                joins[joinMoving].Y = e.Y;
                joins[joinMoving].XRight = e.X;
                joins[joinMoving].YDown = e.Y;
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
                    foreach (Spot spot in spots)
                    {
                        spot.XRight = spot.X;
                    }
                }
            }
            else
            {
                int closestIndex = Utilities.FindClosestIndex(CombineCoordTypes(spots, joins, 1), e.X, e.Y);
                if (closestIndex != -1)
                {
                    if (closestIndex < spots.Count)
                    {
                        // Select a Point
                        SelectPoint(closestIndex);
                        rMoving = true;
                        originalMoving = new int[] { (int)spots[closestIndex].XRight, (int)spots[closestIndex].Y };
                    }
                    else
                    {
                        // Select a Join
                        joinMoving = closestIndex - spots.Count;
                        positionMoving = new int[] { (int)joins[joinMoving].XRight, -1 };
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
                spots[selectedIndex].XRight = e.X;
            }
            else if (joinMoving != -1)
            {
                joins[joinMoving].XRight = e.X;
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
                    foreach (Spot spot in spots)
                    {
                        spot.YDown = spot.Y;
                    }
                }
            }
            else
            {
                int closestIndex = Utilities.FindClosestIndex(CombineCoordTypes(spots, joins, 2), e.X, e.Y);
                if (closestIndex != -1)
                {
                    if (closestIndex < spots.Count)
                    {
                        // Select a Point
                        SelectPoint(closestIndex);
                        tMoving = true;
                        originalMoving = new int[] { (int)spots[closestIndex].X, (int)spots[closestIndex].YDown };
                    }
                    else
                    {
                        // Select a Join
                        joinMoving = closestIndex - spots.Count;
                        positionMoving = new int[] { -1, (int)joins[joinMoving].YDown };
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
                spots[selectedIndex].YDown = e.Y;
            }
            else if (joinMoving != -1)
            {
                joins[joinMoving].YDown = e.Y;
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
            PointBtn.BackColor = (PointBtn.BackColor == button) ? pressed : button;
        }

        /// <summary>
        /// When active, overrides point placement/selection and removes points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EraserBtn_Click(object sender, EventArgs e)
        {
            EraserBtn.Text = (EraserBtn.Text == "Eraser") ? "Point" : "Eraser";
            EraserBtn.BackColor = (EraserBtn.BackColor == button) ? pressed : button;
        }

        /// <summary>
        /// Opens a preview panel to display the piece in full angles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            if (!CheckPiecesValid(spots)) { return; }
            ApplySegmentFully();
            DisplayDrawings();
            PreviewForm previewForm = new PreviewForm(WIP);
            previewForm.Show();
        }

        /// <summary>
        /// Load attributes and/or pieces.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadBtn_Click(object sender, EventArgs e)
        {
            PiecesForm_LoadMenu loadMenu = new PiecesForm_LoadMenu(this);
            loadMenu.Show();
        }

        /// <summary>
        /// Finds the spots needed for symmetry rotation/turns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefineBtn_Click(object sender, EventArgs e)
        {
            if (!CheckPiecesValid(spots)) { return; }
            ApplySegmentFully();
            DisplayDrawings();
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
            if (spots.Count > 0)
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
                if (!CheckPiecesValid(spots)) { return; }
                ApplySegmentFully();

                // Save Points
                WIP.Name = NameTb.Text;
                double[] middle = Utilities.FindMid(Utilities.ConvertSpotsToCoords(spots, 0));            // ** Potential Error: Middle of original, not r/t
                if (!Directory.Exists(Environment.CurrentDirectory + Constants.JoinsFolder + WIP.Name))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + Constants.JoinsFolder + WIP.Name);
                }
                for (int index = 0; index < joins.Count; index++)
                {
                    joins[index].Name = index.ToString();
                    joins[index].SaveJoin(middle);
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
                spots[selectedIndex].Connector = Constants.connectorOptions[ConnectorOptions.SelectedIndex];
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
                spots[selectedIndex].Solid = (FixedCb.Checked) ? Constants.solidOptions[0] : Constants.solidOptions[1];
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Draws a second layer of points that have different
        /// colours to signify whether or not they are solid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowFixedBtn_Click(object sender, EventArgs e)
        {
            ShowFixedBtn.Text = (ShowFixedBtn.Text == "Show Fixed") ? "Hide Fixed" : "Show Fixed";
            ShowFixedBtn.BackColor = (ShowFixedBtn.BackColor == button) ? pressed : button;
            DisplayDrawings();
        }


        // ----- SETS TAB ------

        /// <summary>
        /// Adds a new point to the piece's connections.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPointBtn_Click(object sender, EventArgs e)
        {
            joins.Add(new Join(WIP));
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
                Color color;
                if (ShowFixedBtn.Text == "Hide Fixed")
                {
                    color = (spots[index].Solid == Constants.solidOptions[0]) ? Color.SaddleBrown: Color.PeachPuff;
                }
                else
                {
                    color = (index == selectedIndex) ? Color.Red : Color.Black;
                }
                Utilities.DrawPoint(coords[index][0], coords[index][1], color, board);
            }
        }

        /// <summary>
        /// Draws the pieces on the 3 boards
        /// </summary>
        public void DisplayDrawings()
        {
            // Prepare Piece
            ConvertVariablesToData(rotationFrom, rotationTo, turnFrom, turnTo, Utilities.ConvertSpotsToCoords(spots, 0),
                Utilities.ConvertSpotsToCoords(spots, 1), Utilities.ConvertSpotsToCoords(spots, 2), spots);

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
            // Draw Sketches
            foreach (Piece piece in Sketch)
            {
                piece.R = rotationFrom;
                piece.T = turnFrom;
                Utilities.DrawPiece(piece, original, false);
            }
            Utilities.DrawPiece(WIP, original, false);
            DrawPoints(original, 2);
            // Draw Joins
            foreach (Join spot in joins)
            {
                Utilities.DrawPoint(spot.X, spot.Y, spot.FillColour, original);
            }
            // Draw Shadow Join
            if (oMoving && movingFar || (joinMoving != -1 && positionMoving[0] != -1 && positionMoving[1] != -1))
            {
                Utilities.DrawPoint(positionMoving[0], positionMoving[1], Constants.shadowShade, original);
            }

            // Draw Rotated Board
            WIP.R = 89.9999;
            WIP.T = 0;
            // Draw Sketches
            foreach (Piece piece in Sketch)
            {
                piece.R = rotationTo;
                Utilities.DrawPiece(piece, rotated, false);
            }
            Utilities.DrawPiece(WIP, rotated, false);
            DrawPoints(rotated, 3);
            // Draw Joins
            foreach (Join spot in joins)
            {
                Utilities.DrawPoint(spot.XRight, spot.Y, spot.FillColour, rotated);
            }
            // Draw Shadow Point
            if (rMoving && movingFar)
            {
                Utilities.DrawPoint(positionMoving[0], positionMoving[1], Constants.shadowShade, rotated);
            }
            // Draw Shadow Joint
            else if (joinMoving != -1)
            {
                if (positionMoving[1] == -1)
                {
                    Utilities.DrawPoint(positionMoving[0], joins[joinMoving].Y, Constants.shadowShade, rotated);
                }
                else if (positionMoving[0] != -1)
                {
                    Utilities.DrawPoint(positionMoving[0], positionMoving[1], Constants.shadowShade, rotated);
                }
            }

            // Draw Turned Board
            WIP.R = 0;
            WIP.T = 89.9999;
            // Draw Sketches
            foreach (Piece piece in Sketch)
            {
                piece.T = turnTo;
                Utilities.DrawPiece(piece, turned, false);
            }
            Utilities.DrawPiece(WIP, turned, false);
            DrawPoints(turned, 4);
            // Draw Joins
            foreach (Join spot in joins)
            {
                Utilities.DrawPoint(spot.X, spot.YDown, spot.FillColour, turned);
            }
            // Draw Shadow Point
            if (tMoving && movingFar)
            {
                Utilities.DrawPoint(positionMoving[0], positionMoving[1], Constants.shadowShade, turned);
            }
            // Draw Shadow Joint
            else if (joinMoving != -1)
            {
                if (positionMoving[0] == -1)
                {
                    Utilities.DrawPoint(joins[joinMoving].X, positionMoving[1], Constants.shadowShade, turned);
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
            Utilities.CoordsOnAllSides(spots);
            List<double[]> originals = Utilities.ConvertSpotsToCoords(spots, 0);
            List<double[]> rotateds = Utilities.ConvertSpotsToCoords(spots, 1);
            List<double[]> turneds = Utilities.ConvertSpotsToCoords(spots, 2);
            List<double[]> boths = Utilities.ConvertSpotsToCoords(spots, 3);

            ConvertVariablesToData(0, 90, 0, 90, originals, rotateds, turneds, spots);
            ConvertVariablesToData(90, 180, 0, 90, rotateds, Utilities.FlipCoords(spots, 0, true, false), boths, spots);
            ConvertVariablesToData(180, 270, 0, 90, Utilities.FlipCoords(spots, 0, true, false), Utilities.FlipCoords(spots, 1, true, false), Utilities.FlipCoords(spots, 2, true, false), spots);
            ConvertVariablesToData(270, 360, 0, 90, Utilities.FlipCoords(spots, 1, true, false), originals, Utilities.FlipCoords(spots, 3, true, false), spots);

            ConvertVariablesToData(0, 90, 90, 180, turneds, boths, Utilities.FlipCoords(spots, 0, false, true), spots);
            ConvertVariablesToData(90, 180, 90, 180, boths, Utilities.FlipCoords(spots, 2, true, false), Utilities.FlipCoords(spots, 1, false, true), spots);
            ConvertVariablesToData(180, 270, 90, 180, Utilities.FlipCoords(spots, 2, true, false), Utilities.FlipCoords(spots, 3, true, false), Utilities.FlipCoords(spots, 0, true, true), spots);
            ConvertVariablesToData(270, 360, 90, 180, Utilities.FlipCoords(spots, 3, true, false), turneds, Utilities.FlipCoords(spots, 1, true, true), spots);

            ConvertVariablesToData(0, 90, 180, 270, Utilities.FlipCoords(spots, 0, false, true), Utilities.FlipCoords(spots, 1, false, true), Utilities.FlipCoords(spots, 2, false, true), spots);
            ConvertVariablesToData(90, 180, 180, 270, Utilities.FlipCoords(spots, 1, false, true), Utilities.FlipCoords(spots, 0, true, true), Utilities.FlipCoords(spots, 3, false, true), spots);
            ConvertVariablesToData(180, 270, 180, 270, Utilities.FlipCoords(spots, 0, true, true), Utilities.FlipCoords(spots, 1, true, true), Utilities.FlipCoords(spots, 2, true, true), spots);
            ConvertVariablesToData(270, 360, 180, 270, Utilities.FlipCoords(spots, 1, true, true), Utilities.FlipCoords(spots, 0, false, true), Utilities.FlipCoords(spots, 3, true, true), spots);

            ConvertVariablesToData(0, 90, 270, 360, Utilities.FlipCoords(spots, 2, false, true), Utilities.FlipCoords(spots, 3, false, true), originals, spots);
            ConvertVariablesToData(90, 180, 270, 360, Utilities.FlipCoords(spots, 3, false, true), Utilities.FlipCoords(spots, 2, true, true), rotateds, spots);
            ConvertVariablesToData(180, 270, 270, 360, Utilities.FlipCoords(spots, 2, true, true), Utilities.FlipCoords(spots, 3, true, true), Utilities.FlipCoords(spots, 0, true, false), spots);
            ConvertVariablesToData(270, 360, 270, 360, Utilities.FlipCoords(spots, 3, true, true), Utilities.FlipCoords(spots, 2, false, true), Utilities.FlipCoords(spots, 1, true, false), spots);
        }

        /// <summary>
        /// Converts relevant variables for a piece's angle into a data line and saves to piece data.
        /// </summary>
        /// <param name="rFrom">Rotation start</param>
        /// <param name="rTo">Rotation end</param>
        /// <param name="tFrom">Turn start</param>
        /// <param name="tTo">Turn end</param>
        /// <param name="o">Original coordinates</param>
        /// <param name="r">Rotated coordinates</param>
        /// <param name="t">Turned coordinates</param>
        /// <param name="connectorsList">Connectors between points</param>
        /// <param name="detailsList">Details of points</param>
        private void ConvertVariablesToData (double rFrom, double rTo, double tFrom, double tTo, List<double[]> o,
            List<double[]> r, List<double[]> t, List<Spot> spotsList)
        {
            // When No Coords
            if (o.Count < 1)
            {
                int workingRow = Utilities.FindRow(rFrom, tFrom, WIP.Data, 1);
                if (workingRow != -1) { WIP.Data.RemoveAt(workingRow); }
            }
            else
            {
                // Angles
                string WIPstring = rFrom.ToString().PadLeft(3, '0') + ":" + rTo.ToString().PadLeft(3, '0') + ";" +
                    tFrom.ToString().PadLeft(3, '0') + ":" + tTo.ToString().PadLeft(3, '0') + ";";

                // Coords
                List<double[]>[] CoordsArray = new List<double[]>[] { o, r, t };
                foreach (List<double[]> coords in CoordsArray)
                {
                    for (int index = 0; index < coords.Count; index++)
                    {
                        WIPstring += coords[index][0] + "," + coords[index][1];
                        WIPstring += (index == coords.Count - 1) ? ";" : ":";
                    }
                }

                // Connectors
                for (int index = 0; index < spotsList.Count; index++)
                {
                    WIPstring += spotsList[index].Connector;
                    WIPstring += (index == spotsList.Count - 1) ? ";" : ",";
                }

                // Details
                for (int index = 0; index < spotsList.Count; index++)
                {
                    WIPstring += spotsList[index].Solid;
                    WIPstring += (index == spotsList.Count - 1) ? "" : ",";
                }

                WIP.UpdateDataLine(rFrom, tFrom, WIPstring);
            }
        }

        /// <summary>
        /// Checks whether the pieces drawn can be calculated correctly.
        /// </summary>
        /// <param name="o">Base piece coordinates</param>
        /// <returns>Whether piece is valid</returns>
        private bool CheckPiecesValid(List<Spot> o)
        {
            if (o.Count < 2) { return true; }

            // Check X
            bool bigger = (o[0].X < o[1].X);
            int switchCount = 0;
            for (int index = 0; index < o.Count - 1; index++)
            {
                if (o[index].X < o[index + 1].X != bigger)
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
            // Check Y
            bigger = (o[0].Y < o[1].Y);
            switchCount = 0;
            for (int index = 0; index < o.Count - 1; index++)
            {
                if (o[index].Y < o[index + 1].Y != bigger)
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
            // Check XRight
            bigger = (o[0].XRight < o[1].XRight);
            switchCount = 0;
            for (int index = 0; index < o.Count - 1; index++)
            {
                if (o[index].XRight < o[index + 1].XRight != bigger)
                {
                    bigger = !bigger;
                    switchCount++;
                }
            }
            if (switchCount > 2)
            {
                MessageBox.Show("Invalid rotated shape. Ensure shape does not fold back on itself.", "Invalid rotated shape", MessageBoxButtons.OK);
                return false;
            }
            // Check YDown
            bigger = (o[0].YDown < o[1].YDown);
            switchCount = 0;
            for (int index = 0; index < o.Count - 1; index++)
            {
                if (o[index].YDown < o[index + 1].YDown != bigger)
                {
                    bigger = !bigger;
                    switchCount++;
                }
            }
            if (switchCount > 2)
            {
                MessageBox.Show("Invalid turned shape. Ensure shape does not fold back on itself.", "Invalid turned shape", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }



        // ----- UTILITY FUNCTIONS -----

        /// <summary>
        /// Combines a list of coordinates with a list of points to
        /// return a searchable list of double arrays.
        /// </summary>
        /// <param name="coords">Piece coordinates</param>
        /// <param name="joinsList">Joins of the shape</param>
        /// <param name="pointAngle">0 original, 1 rotated, 2 turned</param>
        /// <returns></returns>
        public static List<double[]> CombineCoordTypes(List<Spot> coords, List<Join> joinsList, int pointAngle)
        {
            List<double[]> searching = new List<double[]>();
            // Original
            if (pointAngle == 0)
            {
                foreach (Spot spot in coords)
                {
                    searching.Add(new double[] { spot.X, spot.Y });
                }
                foreach (Join join in joinsList)
                {
                    searching.Add(new double[] { join.X, join.Y });
                }
            }
            // Rotated
            else if (pointAngle == 1)
            {
                foreach (Spot spot in coords)
                {
                    searching.Add(new double[] { spot.XRight, spot.Y });
                }
                foreach (Join join in joinsList)
                {
                    searching.Add(new double[] { join.XRight, join.Y });
                }
            }
            // Turned
            else
            {
                foreach (Spot spot in coords)
                {
                    searching.Add(new double[] { spot.X, spot.YDown });
                }
                foreach (Join join in joinsList)
                {
                    searching.Add(new double[] { join.X, join.YDown });
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
                ConnectorOptions.SelectedIndex = Array.IndexOf(Constants.connectorOptions, spots[selectedIndex].Connector);
                ShowFixedBtn.Enabled = true;
                FixedCb.Enabled = true;
                FixedCb.Checked = spots[selectedIndex].Solid == Constants.solidOptions[0];
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

        /// <summary>
        /// Updates colours and outline width
        /// in the display.
        /// </summary>
        public void UpdateAttributes()
        {
            FillBox.BackColor = WIP.FillColour[0];
            OutlineBox.BackColor = WIP.OutlineColour;
            OutlineWidthBox.Value = WIP.OutlineWidth;
        }
    }
}
