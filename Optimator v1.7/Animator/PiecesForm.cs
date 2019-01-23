using System;
using System.Collections.Generic;
using System.Drawing;
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
        public List<Part> Sketches { get; set; } = new List<Part>();
        private List<Join> joins = new List<Join>();
        public Piece WIP { get; } = new Piece();
        private List<Spot> spots = new List<Spot>();

        private Spot selectedSpot = null;
        private Join selectedJoin = null;
        private bool movingFar = false;
        private int[] positionMoving = new int[] { -2, -2 };

        private Color button = Color.LightCyan;
        private Color pressed = Color.FromArgb(255, 153, 255, 255);
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

            KeyPreview = true;
            KeyUp += KeyPress;

            SketchLb.ItemCheck += new ItemCheckEventHandler(SketchLbSelectChange);

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
            movingFar = false;

            // Place Point
            if (PointBtn.BackColor == button)
            {
                if (selectedSpot != null && spots.IndexOf(selectedSpot) != spots.Count - 1)
                {
                    spots.Insert(spots.IndexOf(selectedSpot) + 1, new Spot(e.X, e.Y));
                }
                else
                {
                    spots.Add(new Spot(e.X, e.Y));
                }
                SelectSpot(spots[spots.Count - 1]);
                positionMoving = new int[] { -2, -2 };
            }
            // Move Point
            else
            {
                // Select Point or Join
                int closestIndex = Utilities.FindClosestIndex(CombineCoordTypes(spots, joins, 0), e.X, e.Y);
                if (closestIndex != -1)
                {
                    if (closestIndex < spots.Count)
                    {
                        SelectSpot(spots[closestIndex]);
                        positionMoving = new int[] { (int)selectedSpot.X, (int)selectedSpot.Y };
                    }
                    else
                    {
                        SelectJoin(joins[closestIndex - spots.Count]);
                        positionMoving = new int[] { (int)selectedJoin.X, (int)selectedJoin.Y };
                    }
                }
                else
                {
                    Deselect();
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
            if (movingFar && positionMoving[0] != -1 && positionMoving[1] != -1 && positionMoving[0] != -2)
            {
                if (selectedSpot != null)
                {
                    selectedSpot.X = e.X;
                    selectedSpot.Y = e.Y;
                    selectedSpot.XRight = e.X;
                    selectedSpot.YDown = e.Y;
                }
                else if (selectedJoin != null)
                {
                    selectedJoin.X = e.X;
                    selectedJoin.Y = e.Y;
                    selectedJoin.XRight = e.X;
                    selectedJoin.YDown = e.Y;
                }
            }
            movingFar = false;
            positionMoving = new int[] { -2, -2 };
            DisplayDrawings();
        }

        /// <summary>
        /// Updates movement as mouse position changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBase_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > DrawBase.Size.Width || e.Y > DrawBase.Size.Height || e.X < 0 || e.Y < 0 || (selectedSpot == null && selectedJoin == null))
            {
                movingFar = false;
                return;
            }

            if (positionMoving[0] != -1 && positionMoving[1] != -1 && positionMoving[0] != -2)
            {
                positionMoving = new int[] { e.X, e.Y };
                if (!movingFar && selectedSpot != null)
                {
                    movingFar = Math.Abs(selectedSpot.X - positionMoving[0]) > Constants.ClickPrecision
                        || Math.Abs(selectedSpot.Y - positionMoving[1]) > Constants.ClickPrecision;
                }
                else if (!movingFar)
                {
                    movingFar = Math.Abs(selectedJoin.X - positionMoving[0]) > Constants.ClickPrecision
                        || Math.Abs(selectedJoin.Y - positionMoving[1]) > Constants.ClickPrecision;
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
            movingFar = false;
            int closestIndex = Utilities.FindClosestIndex(CombineCoordTypes(spots, joins, 1), e.X, e.Y);
            if (closestIndex != -1)
            {
                // Select a Point
                if (closestIndex < spots.Count)
                {
                    SelectSpot(spots[closestIndex]);
                    positionMoving = new int[] { (int)selectedSpot.XRight, -1 };
                }
                // Select a Join
                else
                {
                    SelectJoin(joins[closestIndex - spots.Count]);
                    positionMoving = new int[] { (int)selectedJoin.XRight, -1 };
                }
            }
            else
            {
                Deselect();
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
            if (movingFar && positionMoving[1] == -1)
            {
                if (selectedSpot != null)
                {
                    selectedSpot.XRight = e.X;
                }
                else if (selectedJoin != null)
                {
                    selectedJoin.XRight = e.X;
                }
            }
            movingFar = false;
            positionMoving = new int[] { -2, -2 };
            DisplayDrawings();
        }

        /// <summary>
        /// Updates movement as mouse position changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > DrawRight.Size.Width || e.Y > DrawRight.Size.Height || e.X < 0 || e.Y < 0 || (selectedSpot == null && selectedJoin == null))
            {
                movingFar = false;
                return;
            }

            if (positionMoving[1] == -1)
            { 
                positionMoving = new int[] { e.X, -1 };
                if (!movingFar && selectedSpot != null)
                {
                    movingFar = Math.Abs(selectedSpot.XRight - positionMoving[0]) > Constants.ClickPrecision;
                }
                else if (!movingFar)
                {
                    movingFar = Math.Abs(selectedJoin.XRight - positionMoving[0]) > Constants.ClickPrecision;
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
            movingFar = false;
            int closestIndex = Utilities.FindClosestIndex(CombineCoordTypes(spots, joins, 2), e.X, e.Y);
            if (closestIndex != -1)
            {
                if (closestIndex < spots.Count)
                {
                    // Select a Point
                    SelectSpot(spots[closestIndex]);
                    positionMoving = new int[] { -1, (int)selectedSpot.YDown };
                }
                else
                {
                    // Select a Join
                    SelectJoin(joins[closestIndex - spots.Count]);
                    positionMoving = new int[] { -1, (int)selectedJoin.YDown };
                }
            }
            else
            {
                Deselect();
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
            if (movingFar && positionMoving[0] == -1)
            {
                if (selectedSpot != null)
                {
                    selectedSpot.YDown = e.Y;
                }
                else if (selectedJoin != null)
                {
                    selectedJoin.YDown = e.Y;
                }
            }
            movingFar = false;
            positionMoving = new int[] { -2, -2 };
            DisplayDrawings();
        }

        /// <summary>
        /// Updates movement as mouse position changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawDown_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > DrawRight.Size.Width || e.Y > DrawRight.Size.Height || e.X < 0 || e.Y < 0 || (selectedSpot == null && selectedJoin == null))
            {
                movingFar = false;
                return;
            }

            if (positionMoving[0] == -1)
            {
                positionMoving = new int[] { -1, e.Y };
                if (!movingFar && selectedSpot != null)
                {
                    movingFar = Math.Abs(selectedSpot.YDown - positionMoving[1]) > Constants.ClickPrecision;
                }
                else if (!movingFar)
                {
                    movingFar = Math.Abs(selectedJoin.YDown - positionMoving[1]) > Constants.ClickPrecision;
                }
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Runs when a key is pressed.
        /// If delete is pressed and a piece is selected, it will be deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void KeyPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // Delete Selected
                case Keys.Delete:
                    // Delete Spot
                    if (selectedSpot != null)
                    {
                        int selectedIndex = spots.IndexOf(selectedSpot);
                        spots.Remove(selectedSpot);
                        if (spots.Count == 0)
                        {
                            Deselect();
                        }
                        else
                        {
                            SelectSpot(spots[Utilities.Modulo(selectedIndex - 1, spots.Count)]);
                        }
                    }
                    // Delete Join
                    else if (selectedJoin != null)
                    {
                        joins.Remove(selectedJoin);
                    }
                    // Delete Piece
                    else
                    {
                        DialogResult result = MessageBox.Show("Would you like to restart the piece?", "Restart Confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            spots.Clear();
                            WIP.Data.Clear();
                            WIP.UpdateDataInfoLine();
                            Deselect();
                        }
                    }
                    DisplayDrawings();
                    break;

                // Do nothing for any other key
                default:
                    break;
            }
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
            RefineBtn.Text = (RefineBtn.Text == "Refine") ? "Simplify" : "Refine";
            RefineBtn.BackColor = (RefineBtn.BackColor == button) ? pressed : button;

            if (RefineBtn.BackColor == pressed)
            {
                ApplySegmentFully();
            }
            else
            {
                //TODO: Undo Refinement
            }
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
            if (File.Exists(Utilities.GetDirectory(Constants.PiecesFolder, NameTb.Text, Constants.Txt)))
            {
                DialogResult result = MessageBox.Show("This name is already in use. Do you want to override the existing piece?", "Override Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) { return; }
            }

            // Save Piece and Close Form
            try
            {
                if (!CheckPiecesValid(spots)) { return; }
                ApplySegmentFully();

                // Save Points
                WIP.Name = NameTb.Text;
                double[] middle = Utilities.FindMid(Utilities.ConvertSpotsToCoords(spots, 0));            //POTERROR: Middle of original, not r/t
                if (!Directory.Exists(Utilities.GetDirectory(Constants.JoinsFolder, WIP.Name)))
                {
                    Directory.CreateDirectory(Utilities.GetDirectory(Constants.JoinsFolder, WIP.Name));
                }
                for (int index = 0; index < joins.Count; index++)
                {
                    joins[index].Name = index.ToString();
                    joins[index].SaveJoin(middle);
                }

                Utilities.SaveData(Utilities.GetDirectory(Constants.PiecesFolder, NameTb.Text, Constants.Txt), WIP.Data);
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
            if (selectedSpot != null)
            {
                selectedSpot.Connector = Constants.connectorOptions[ConnectorOptions.SelectedIndex];
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
            if (selectedSpot != null)
            {
                selectedSpot.Solid = (FixedCb.Checked) ? Constants.solidOptions[0] : Constants.solidOptions[1];
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
        private void AddJoinBtn_Click(object sender, EventArgs e)
        {
            joins.Add(new Join(WIP));
            SelectJoin(joins[joins.Count - 1]);
            DisplayDrawings();
        }

        /// <summary>
        /// Deletes the selected sketch from the listbox and the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteSketchBtn_Click(object sender, EventArgs e)
        {
            if (SketchLb.SelectedIndex == -1) { return; }
            Sketches.RemoveAt(SketchLb.SelectedIndex);
            SketchLb.Items.RemoveAt(SketchLb.SelectedIndex);
            DisplayDrawings();
        }

        /// <summary>
        /// Rotates the selected sketch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotationBar_Scroll(object sender, EventArgs e)
        {
            if (SketchLb.SelectedIndex == -1) { return; }
            Sketches[SketchLb.SelectedIndex].ToPiece().R = RotationBar.Value;
            DisplayDrawings();
        }

        /// <summary>
        /// Turns the selected sketch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TurnBar_Scroll(object sender, EventArgs e)
        {
            if (SketchLb.SelectedIndex == -1) { return; }
            Sketches[SketchLb.SelectedIndex].ToPiece().T = TurnBar.Value;
            DisplayDrawings();
        }

        /// <summary>
        /// Spins the selected sketch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpinBar_Scroll(object sender, EventArgs e)
        {
            if (SketchLb.SelectedIndex == -1) { return; }
            Sketches[SketchLb.SelectedIndex].ToPiece().S = SpinBar.Value;
            DisplayDrawings();
        }

        /// <summary>
        /// Resizes the selected sketch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SizeBar_Scroll(object sender, EventArgs e)
        {
            if (SketchLb.SelectedIndex == -1) { return; }
            Sketches[SketchLb.SelectedIndex].ToPiece().SM = SizeBar.Value;
            DisplayDrawings();
        }

        /// <summary>
        /// Moves the selected sketch horizontally.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (SketchLb.SelectedIndex == -1) { return; }
            Sketches[SketchLb.SelectedIndex].ToPiece().X = (double)XUpDown.Value;
            DisplayDrawings();
        }

        /// <summary>
        /// Moves the selected sketch vertically.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (SketchLb.SelectedIndex == -1) { return; }
            Sketches[SketchLb.SelectedIndex].ToPiece().Y = (double)YUpDown.Value;
            DisplayDrawings();
        }



        // ----- SETTINGS TAB -----

        /// <summary>
        /// Changes the back colour of the drawing panels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackColourBox_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog
            {
                Color = BackColourBox.BackColor,
                FullOpen = true
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                DrawBase.BackColor = MyDialog.Color;
                DrawRight.BackColor = MyDialog.Color;
                DrawDown.BackColor = MyDialog.Color;
                BackColourBox.BackColor = MyDialog.Color;
                DisplayDrawings();
            }
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
                if (ShowFixedBtn.BackColor == pressed)
                {
                    color = (spots[index].Solid == Constants.solidOptions[0]) ? Color.SaddleBrown: Color.PeachPuff;
                }
                else
                {
                    color = (index == spots.IndexOf(selectedSpot)) ? Constants.select : Color.Black;
                }
                Visuals.DrawCross(coords[index][0], coords[index][1], color, board);
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

            // DRAW SKETCHES
            for (int index = 0; index < Sketches.Count; index++)
            {
                if (SketchLb.GetItemCheckState(index) == CheckState.Checked)
                {
                    Part sketch = Sketches[index];
                    sketch.Draw(original);
                    sketch.ToPiece().R += rotationTo - rotationFrom;
                    sketch.Draw(rotated);
                    sketch.ToPiece().R -= rotationTo - rotationFrom;
                    sketch.ToPiece().T += turnTo - turnFrom;
                    sketch.Draw(turned);
                    sketch.ToPiece().T -= turnTo - turnFrom;
                }
            }

            // DRAW BASE BOARD
            WIP.R = 0;
            WIP.T = 0;
            Visuals.DrawPiece(WIP, original, false);
            DrawPoints(original, 2);
            // Draw Joins
            foreach (Join join in joins)
            {
                if (join == selectedJoin)
                {
                    Visuals.DrawCross(join.X, join.Y, Constants.select, original);
                }
                else
                {
                    Visuals.DrawCross(join.X, join.Y, join.FillColour, original);
                }
            }
            // Draw Shadow Point
            if (movingFar && selectedSpot != null && positionMoving[0] != -1 && positionMoving[1] != -1)
            {
                Visuals.DrawCross(positionMoving[0], positionMoving[1], Constants.shadowShade, original);
            }
            // Draw Shadow Join
            if (selectedJoin != null && movingFar && positionMoving[0] != -1 && positionMoving[1] != -1)
            {
                Visuals.DrawCross(positionMoving[0], positionMoving[1], Constants.shadowShade, original);
            }

            // DRAW ROTATED BOARD
            WIP.R = 89.9999;
            WIP.T = 0;
            Visuals.DrawPiece(WIP, rotated, false);
            DrawPoints(rotated, 3);
            // Draw Joins
            foreach (Join join in joins)
            {
                if (join == selectedJoin)
                {
                    Visuals.DrawCross(join.XRight, join.Y, Constants.select, rotated);
                }
                else
                {
                    Visuals.DrawCross(join.XRight, join.Y, join.FillColour, rotated);
                }
            }
            // Draw Shadow Point
            if (movingFar && selectedSpot != null)
            {
                if (positionMoving[1] == -1)
                {
                    Visuals.DrawCross(positionMoving[0], selectedSpot.Y, Constants.shadowShade, rotated);
                }
                else if (positionMoving[0] != -1)
                {
                    Visuals.DrawCross(positionMoving[0], positionMoving[1], Constants.shadowShade, rotated);
                }
            }
            // Draw Shadow Joint
            else if (movingFar && selectedJoin != null)
            {
                if (positionMoving[1] == -1)
                {
                    Visuals.DrawCross(positionMoving[0], selectedJoin.Y, Constants.shadowShade, rotated);
                }
                else if (positionMoving[0] != -1)
                {
                    Visuals.DrawCross(positionMoving[0], positionMoving[1], Constants.shadowShade, rotated);
                }
            }

            // DRAW TURNED BOARD
            WIP.R = 0;
            WIP.T = 89.9999;
            Visuals.DrawPiece(WIP, turned, false);
            DrawPoints(turned, 4);
            // Draw Joins
            foreach (Join join in joins)
            {
                if (join == selectedJoin)
                {
                    Visuals.DrawCross(join.X, join.YDown, Constants.select, turned);
                }
                else
                {
                    Visuals.DrawCross(join.X, join.YDown, join.FillColour, turned);
                }
            }
            // Draw Shadow Point
            if (movingFar && selectedSpot != null)
            {
                if (positionMoving[0] == -1)
                {
                    Visuals.DrawCross(selectedSpot.X, positionMoving[1], Constants.shadowShade, turned);
                }
                else if (positionMoving[1] != -1)
                {
                    Visuals.DrawCross(positionMoving[0], positionMoving[1], Constants.shadowShade, turned);
                }
            }
            // Draw Shadow Joint
            else if (movingFar && selectedJoin != null)
            {
                if (positionMoving[0] == -1)
                {
                    Visuals.DrawCross(selectedJoin.X, positionMoving[1], Constants.shadowShade, turned);
                }
                else if (positionMoving[1] != -1)
                {
                    Visuals.DrawCross(positionMoving[0], positionMoving[1], Constants.shadowShade, turned);
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
        /// <param name="spotsList">Spot representation of the coordinates in the same order</param>
        private void ConvertVariablesToData (double rFrom, double rTo, double tFrom, double tTo, List<double[]> o,
            List<double[]> r, List<double[]> t, List<Spot> spotsList)
        {
            // When No Coords
            if (o.Count < 1)
            {
                int workingRow = Utilities.FindRow(rFrom, tFrom, WIP.Data, 2);
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
        /// Selects a spot and updates the form to
        /// display relevant values.
        /// </summary>
        /// <param name="index"></param>
        private void SelectSpot(Spot select)
        {
            Deselect();
            selectedSpot = select;
            ConnectorOptions.Enabled = true;
            ConnectorOptions.SelectedIndex = Array.IndexOf(Constants.connectorOptions, selectedSpot.Connector);
            ShowFixedBtn.Enabled = true;
            FixedCb.Enabled = true;
            FixedCb.Checked = selectedSpot.Solid == Constants.solidOptions[0];
        }

        /// <summary>
        /// Selects a join.
        /// </summary>
        /// <param name="select"></param>
        private void SelectJoin(Join select)
        {
            Deselect();
            selectedJoin = select;
        }

        /// <summary>
        /// Deselects a point and disables features
        /// that require a point be selected.
        /// </summary>
        private void Deselect()
        {
            selectedSpot = null;
            selectedJoin = null;
            ConnectorOptions.Enabled = false;
            ShowFixedBtn.Enabled = false;
            FixedCb.Enabled = false;
        }



        // ----- LOAD MENU FUNCTIONS -----

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

        /// <summary>
        /// Takes the shape of the loaded piece and implements it for WIP.
        /// </summary>
        /// <param name="spots">Shape coordinates</param>
        public void LoadPieceOutline(List<Spot> spots)
        {
            this.spots = spots;
        }



        // ----- SKETCH FUNCTIONS -----

        /// <summary>
        /// Adds a piece to the sketch list and listbox.
        /// </summary>
        /// <param name="toLoad">Piece to add to the sketch list</param>
        public void AddSketch(Part toLoad)
        {
            Sketches.Add(toLoad);
            SketchLb.Items.Add(toLoad, true);
        }

        /// <summary>
        /// Displays drawing with/without sketch item after
        /// its visability is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SketchLbSelectChange(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate {
                DisplayDrawings();
            });
        }
    }
}
