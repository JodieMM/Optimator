using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Optimator
{
    /// <summary>
    /// The form used to generate and modify pieces and points.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class PiecesForm : Form
    {
        #region PiecesForm Variables
        private Piece WIP;
        public List<Part> Sketches { get; set; } = new List<Part>();

        private Graphics original;
        private Graphics rotated;
        private Graphics turned;

        private Spot selectedSpot = null;
        private int moving = 0;                             // 0 = not, 1 = X & Y, 2 = X, 3 = Y
        private bool movingFar = false;                     // Whether a piece is being selected or moved

        private Color unpressed = Color.LightCyan;
        private Color pressed = Color.FromArgb(255, 153, 255, 255);
        #endregion
        

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

            DrawBase.BackColor = Settings.BackgroundColour;
            DrawRight.BackColor = Settings.BackgroundColour;
            DrawDown.BackColor = Settings.BackgroundColour;

            KeyPreview = true;
            KeyUp += KeyPress;

            SketchLb.ItemCheck += new ItemCheckEventHandler(SketchLbSelectChange);

            FillBox.BackColor = Consts.defaultFill;
            OutlineBox.BackColor = Consts.defaultOutline;
            OutlineWidthBox.Value = Consts.defaultOutlineWidth;

            WIP = new Piece();
            Utils.CheckValidFolder();
        }



        // ----- I/O -----
        #region I/O

        /// <summary>
        /// Places or selects a point on the main board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBase_MouseDown(object sender, MouseEventArgs e)
        {
            // Place Point
            if (PointBtn.BackColor == unpressed)
            {
                if (selectedSpot != null && WIP.Data.IndexOf(selectedSpot) != WIP.Data.Count - 1)
                {
                    WIP.Data.Insert(WIP.Data.IndexOf(selectedSpot) + 1, new Spot(e.X, e.Y));
                }
                else
                {
                    WIP.Data.Add(new Spot(e.X, e.Y));
                }

                SelectSpot(WIP.Data[WIP.Data.Count - 1]);
            }
            // Select Spot
            else
            {
                int closestIndex = Utils.FindClosestIndex(WIP.Data, 0, e.X, e.Y);
                if (closestIndex != -1)
                {
                    SelectSpot(WIP.Data[closestIndex]);
                    moving = 1;
                }
                else
                {
                    Deselect();
                }
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Moves a spot if move is in progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBase_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedSpot != null && movingFar && moving == 1)
            {
                    selectedSpot.X = e.X;
                    selectedSpot.Y = e.Y;
                    selectedSpot.XRight = e.X;
                    selectedSpot.YDown = e.Y;
            }
            StopMoving();
            DisplayDrawings();
        }

        /// <summary>
        /// Updates movement as mouse position changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBase_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedSpot == null || moving == 0 || e.X > DrawBase.Size.Width || e.Y > DrawBase.Size.Height || e.X < 0 || e.Y < 0)
            {
                StopMoving();
                return;
            }

            if (!movingFar)
            {
                movingFar = Math.Abs(selectedSpot.X - e.X) > Consts.ClickPrecision
                    || Math.Abs(selectedSpot.Y - e.Y) > Consts.ClickPrecision;
            }

            if (movingFar)
            {
                DisplayDrawings();
                Spot shadow = new Spot(e.X, e.Y);
                shadow.Draw(0, Consts.shadowShade, original);
                shadow.Draw(1, Consts.shadowShade, rotated);
                shadow.Draw(2, Consts.shadowShade, turned);
            }
        }

        /// <summary>
        /// Selects a spot on the rotation board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawRight_MouseDown(object sender, MouseEventArgs e)
        {
            // Select Spot
            int closestIndex = Utils.FindClosestIndex(WIP.Data, 1, e.X, e.Y);
            if (closestIndex != -1)
            {
                SelectSpot(WIP.Data[closestIndex]);
                moving = 2;
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
            if (movingFar && selectedSpot != null && moving == 2)
            {
                selectedSpot.XRight = e.X;
            }

            StopMoving();
            DisplayDrawings();
        }

        /// <summary>
        /// Updates movement as mouse position changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedSpot == null || moving == 0 || e.X > DrawRight.Size.Width || e.Y > DrawRight.Size.Height || e.X < 0 || e.Y < 0)
            {
                StopMoving();
                return;
            }

            if (!movingFar)
            {
                movingFar = Math.Abs(selectedSpot.XRight - e.X) > Consts.ClickPrecision;
            }

            if (movingFar)
            {
                DisplayDrawings();
                Spot shadow = new Spot(e.X, selectedSpot.Y);
                shadow.Draw(1, Consts.shadowShade, rotated);
            }
        }

        /// <summary>
        /// Selects a point on the turn board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawDown_MouseDown(object sender, MouseEventArgs e)
        {
            // Select Spot
            int closestIndex = Utils.FindClosestIndex(WIP.Data, 2, e.X, e.Y);
            if (closestIndex != -1)
            {
                SelectSpot(WIP.Data[closestIndex]);
                moving = 3;
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
            if (movingFar && selectedSpot != null && moving == 3)
            {
                selectedSpot.YDown = e.Y;
            }

            StopMoving();
            DisplayDrawings();
        }

        /// <summary>
        /// Updates movement as mouse position changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawDown_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedSpot == null || moving == 0 || e.X > DrawDown.Size.Width || e.Y > DrawDown.Size.Height || e.X < 0 || e.Y < 0)
            {
                StopMoving();
                return;
            }

            if (!movingFar)
            {
                movingFar = Math.Abs(selectedSpot.YDown - e.Y) > Consts.ClickPrecision;
            }

            if (movingFar)
            {
                DisplayDrawings();
                Spot shadow = new Spot(selectedSpot.X, e.Y);
                shadow.Draw(2, Consts.shadowShade, turned);
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
                        int selectedIndex = WIP.Data.IndexOf(selectedSpot);
                        WIP.Data.Remove(selectedSpot);
                        if (WIP.Data.Count == 0)
                        {
                            Deselect();
                        }
                        else
                        {
                            SelectSpot(WIP.Data[Utils.Modulo(selectedIndex - 1, WIP.Data.Count)]);
                        }
                    }
                    // Delete Piece
                    else
                    {
                        var result = MessageBox.Show("Would you like to restart the piece?", "Restart Confirmation", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            WIP.Data.Clear();
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
        #region Option Buttons

        /// <summary>
        /// Changes between placing points and selecting them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointBtn_Click(object sender, EventArgs e)
        {
            PointBtn.Text = (PointBtn.Text == "Select") ? "Place" : "Select";
            PointBtn.BackColor = (PointBtn.BackColor == unpressed) ? pressed : unpressed;
        }

        /// <summary>
        /// Opens a preview panel to display the piece in full angles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            if (CheckPiecesValid())
            {
                var previewForm = new PreviewForm(WIP);
                previewForm.Show();
            }
        }

        /// <summary>
        /// Load attributes and/or pieces.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadBtn_Click(object sender, EventArgs e)
        {
            PiecesForm_LoadMenu loadMenu = new PiecesForm_LoadMenu(this, WIP);
            loadMenu.Show();
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            if (Utils.ExitBtn_Click(WIP.Data.Count > 0))
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
            if (!Utils.CheckValidNewName(NameTb.Text, Consts.PiecesFolder) || !CheckPiecesValid())
            {
                return;
            }

            // Save Piece and Close Form
            try
            {
                // Centre 0,0
                State defaultState = new State();
                double[] centre = Utils.FindMid(WIP.GetPoints(defaultState));
                double[] centreR = Utils.FindMid(WIP.GetPoints(new State(defaultState, 1, 90)));
                double[] centreT = Utils.FindMid(WIP.GetPoints(new State(defaultState, 2, 90)));
                foreach (var spot in WIP.Data)
                {
                    spot.X -= centre[0];
                    spot.XRight -= centreR[0];
                    spot.Y -= centre[1];
                    spot.YDown -= centreT[1];
                }

                Utils.SaveFile(Utils.GetDirectory(Consts.PiecesFolder, NameTb.Text, Consts.Optr), WIP.GetData());
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

        /// <summary>
        /// Erases the changes to angled, making it the same as base.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EraseAngleBtn_Click(object sender, EventArgs e)
        {
            var angle = sender == EraseRightBtn ? new object[] { 0, 1, "rotated" } : new object[] { 1, 2, "turned" };
            var result = MessageBox.Show("Are you sure you want to set " + angle[2].ToString() + " to the base position?", "Confirm Erase", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                foreach (var spot in WIP.Data)
                {
                    spot.SetCoords((int)angle[1], (int)angle[0], spot.GetCoordCombination()[(int)angle[0]]);
                }
                DisplayDrawings();
            }  
        }

        #endregion



        // ----- SHAPE TAB -----
        #region Shape Tab

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
                WIP.ColourState.FillColour = new Color[] { MyDialog.Color };
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
                WIP.ColourState.OutlineColour = MyDialog.Color;
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
                selectedSpot.Connector = Consts.connectorOptions[ConnectorOptions.SelectedIndex];
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
                selectedSpot.Solid = (FixedCb.Checked) ? Consts.solidOptions[0] : Consts.solidOptions[1];
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
            ShowFixedBtn.BackColor = (ShowFixedBtn.BackColor == unpressed) ? pressed : unpressed;
            DisplayDrawings();
        }

        #endregion



        // ----- SKETCHES TAB ------

        /// <summary>
        /// Updates the selected sketch according to the sender's input.
        /// </summary>
        /// <param name="sender">The UI object that sent the update</param>
        /// <param name="e"></param>
        private void SketchUpdate(object sender, EventArgs e)
        {
            if (SketchLb.SelectedIndex == -1)
            {
                return;
            }
            if (sender == DeleteSketchBtn)
            {
                Sketches.RemoveAt(SketchLb.SelectedIndex);
                SketchLb.Items.RemoveAt(SketchLb.SelectedIndex);
            }
            else if (sender == RotationBar)
            {
                Sketches[SketchLb.SelectedIndex].ToPiece().State.R = RotationBar.Value;
            }
            else if (sender == TurnBar)
            {
                Sketches[SketchLb.SelectedIndex].ToPiece().State.T = TurnBar.Value;
            }
            else if (sender == SpinBar)
            {
                Sketches[SketchLb.SelectedIndex].ToPiece().State.S = SpinBar.Value;
            }
            else if (sender == SizeBar)
            {
                Sketches[SketchLb.SelectedIndex].ToPiece().State.SM = SizeBar.Value;
            }
            else if (sender == XUpDown)
            {
                Sketches[SketchLb.SelectedIndex].ToPiece().State.X = (double)XUpDown.Value;
            }
            else if (sender == YUpDown)
            {
                Sketches[SketchLb.SelectedIndex].ToPiece().State.Y = (double)YUpDown.Value;
            }
            DisplayDrawings();
        }



        // ----- DRAWING FUNCTIONS -----

        /// <summary>
        /// Draws the points of the WIP to the board
        /// Angle: Original = 0, Rotated = 1, Turned = 2
        /// </summary>
        /// <param name="board">The graphics board to be drawn on</param>
        /// <param name="angle">The angle to be drawn</param>
        private void DrawPoints(Graphics board, int angle)
        {
            foreach (Spot spot in WIP.Data)
            {
                if (spot.DrawnLevel == 0)
                {
                    Color color = (ShowFixedBtn.BackColor == pressed) ? (spot.Solid == Consts.solidOptions[0]) ? Consts.option1 : Consts.option2
                        : (selectedSpot == spot) ? Consts.select : Color.Black;
                    spot.Draw(angle, color, board);
                }
            }
        }

        /// <summary>
        /// Draws the pieces on the 3 boards
        /// </summary>
        public void DisplayDrawings()
        {
            // Prepare
            DrawBase.Refresh();
            DrawRight.Refresh();
            DrawDown.Refresh();
            original = DrawBase.CreateGraphics();
            rotated = DrawRight.CreateGraphics();
            turned = DrawDown.CreateGraphics();

            // Draw Sketches
            for (int index = 0; index < Sketches.Count; index++)
            {
                if (SketchLb.GetItemCheckState(index) == CheckState.Checked)
                {
                    Part sketch = Sketches[index];
                    sketch.Draw(original);
                    sketch.Draw(rotated, new State(sketch.ToPiece().State, 1, sketch.ToPiece().State.R + 90));
                    sketch.Draw(turned, new State(sketch.ToPiece().State, 2, sketch.ToPiece().State.T + 90));
                }
            }

            // Draw Base Board
            WIP.Draw(original, WIP.State);
            DrawPoints(original, 0);

            // Draw Rotated Board
            WIP.Draw(rotated, new State(WIP.State, 1, 90));
            DrawPoints(rotated, 1);

            // Draw Turned Board
            WIP.Draw(turned, new State(WIP.State, 2, 90));
            DrawPoints(turned, 2);
            WIP.State.T = 0;
        }



        // ----- UTILITY FUNCTIONS -----

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
            ConnectorOptions.SelectedIndex = Array.IndexOf(Consts.connectorOptions, selectedSpot.Connector);
            ShowFixedBtn.Enabled = true;
            FixedCb.Enabled = true;
            FixedCb.Checked = selectedSpot.Solid == Consts.solidOptions[0];
        }

        /// <summary>
        /// Deselects a point and disables features
        /// that require a point be selected.
        /// </summary>
        private void Deselect()
        {
            selectedSpot = null;
            ConnectorOptions.Enabled = false;
            ShowFixedBtn.Enabled = false;
            FixedCb.Enabled = false;
        }

        /// <summary>
        /// Changes moving variables to indicate no
        /// movement is in process.
        /// </summary>
        private void StopMoving()
        {
            moving = 0;
            movingFar = false;
        }

        /// <summary>
        /// Checks whether the pieces drawn can be calculated correctly.
        /// </summary>
        /// <returns>True if piece is valid</returns>
        private bool CheckPiecesValid()
        {
            var o = WIP.Data;
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



        // ----- LOAD MENU FUNCTIONS -----

        /// <summary>
        /// Updates colours and outline width
        /// in the display.
        /// </summary>
        public void UpdateAttributes()
        {
            FillBox.BackColor = WIP.ColourState.FillColour[0];
            OutlineBox.BackColor = WIP.ColourState.OutlineColour;
            OutlineWidthBox.Value = WIP.OutlineWidth;
        }

        /// <summary>
        /// Takes the shape of the loaded piece and implements it for WIP.
        /// </summary>
        /// <param name="spots">Shape coordinates</param>
        public void LoadPieceOutline(List<Spot> spots)
        {
            WIP.Data = spots;
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
