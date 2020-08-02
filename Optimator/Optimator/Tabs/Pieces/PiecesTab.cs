using Optimator.Tabs;
using Optimator.Forms;
using Optimator.Forms.Pieces;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using Optimator.Tabs.Pieces;

namespace Optimator
{
    /// <summary>
    /// A tab used to generate and modify pieces and points.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class PiecesTab : TabPageControl
    {
        #region PiecesTab Variables
        public override HomeForm Owner { get; set; }
        public string Directory { get; set; } = "";

        public Piece WIP = new Piece();
        public Dictionary<Part, bool> Sketches { get; set; } = new Dictionary<Part, bool>();

        private Graphics original;
        private Graphics rotated;
        private Graphics turned;

        public Spot selectedSpot = null;
        private int moving = 0;                             // 0 = not, 1 = X & Y, 2 = X, 3 = Y
        private bool movingFar = false;                     // Whether a piece is being selected or moved

        public bool showPoints = true;
        #endregion


        /// <summary>
        /// Constructor for the control.
        /// </summary>
        /// <param name="owner"></param>
        public PiecesTab(HomeForm owner)
        {
            InitializeComponent();
            Owner = owner;

            ChangeDrawingBgs(Utils.ColourFromString(Properties.Settings.Default.BgColour));
            Owner.GetTabControl().KeyDown += KeyPress;
            Enter += RefreshDrawPanel;
            VisibleChanged += RefreshDrawPanel;
        }



        // ----- GETTERS -----

        /// <summary>
        /// Gets a board to use in a utils sizing function in AddPartPanel.
        /// </summary>
        /// <returns>A PictureBox used as a board</returns>
        public PictureBox GetBoardSizing()
        {
            return DrawBase;
        }

        /// <summary>
        /// Gets the back colour of the drawing boards.
        /// </summary>
        /// <returns></returns>
        public Color GetBoardColor()
        {
            return DrawBase.BackColor;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = Width > 950 ? 0.3F : 0.33F;
            var largeWidth = (int)(Width * widthPercent);
            var cell = DrawingLayoutPnl.GetCellPosition(DrawBase);
            var length = DrawingLayoutPnl.GetColumnWidths()[cell.Column] > DrawingLayoutPnl.GetRowHeights()[cell.Row] ?
                DrawingLayoutPnl.GetRowHeights()[cell.Row] : DrawingLayoutPnl.GetColumnWidths()[cell.Column];

            DrawBase.Size = DrawRight.Size = DrawDown.Size = new Size(length, length);
            Panel.Width = largeWidth;
            Utils.ResizePanel(Panel);
            DisplayDrawings();
        }

        #region ToolStrip

        /// <summary>
        /// Unchecks all of the checkable buttons and checks the provided one.
        /// </summary>
        private void SelectButton(ToolStripButton btn)
        {
            UncheckAllButtons();
            btn.Checked = true;
            DisplayDrawings();
        }

        /// <summary>
        /// Deselects all buttons. Used with LoadTab to ensure all 
        /// controls display correctly after the load.
        /// </summary>
        public void DeselectButtons()
        {
            UncheckAllButtons();
            Panel.Controls.Clear();
            DisplayDrawings();
        }

        /// <summary>
        /// Unchecks all of the toop strip buttons.
        /// </summary>
        private void UncheckAllButtons()
        {
            SaveBtn.Checked = false;
            MovePointBtn.Checked = false;
            ColoursBtn.Checked = false;
            FixedBtn.Checked = false;
            SketchesBtn.Checked = false;
            EraseBtn.Checked = false;
            OutlineBtn.Checked = false;
            SettingsBtn.Checked = false;
        }

        /// <summary>
        /// Opens or closes panel based on tool strip button press.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWithPanel_Click(object sender, EventArgs e)
        {
            if (!(sender as ToolStripButton).Checked)
            {
                PanelControl panel = new SavePanel(this);
                if (sender == SaveBtn)
                {
                    panel = new SavePanel(this);
                }
                else if (sender == MovePointBtn)
                {
                    panel = new MovePointPanel(this);
                }
                else if (sender == OutlineBtn)
                {
                    panel = new OutlinePanel(this);
                }
                else if (sender == ColoursBtn)
                {
                    panel = new ColoursPanel(this);
                }
                else if (sender == FixedBtn)
                {
                    panel = new SolidPanel(this);
                }
                else if (sender == EraseBtn)
                {
                    panel = new ErasePanel(this);
                }
                else if (sender == SketchesBtn)
                {
                    panel = new SketchesPanel(this);
                }
                else if (sender == SettingsBtn)
                {
                    panel = new SettingsPanel(this);
                }
                Utils.NewPanelContent(Panel, panel);
                SelectButton(sender as ToolStripButton);
            }
            else
            {
                DeselectButtons();
            }
        }

        /// <summary>
        /// Reloads the sketches.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            //var newSketches = new Dictionary<Part, bool>();
            //foreach (var sketch in Sketches)
            //{
            //    if (sketch.Key is Piece)
            //    {
            //        newSketches.Add(new Piece(sketch.Key.Name, Utils.ReadFile(Utils.GetDirectory(sketch.Key.Name))), sketch.Value);
            //    }
            //    else
            //    {
            //        newSketches.Add(new Set(sketch.Key.Name, Utils.ReadFile(Utils.GetDirectory(sketch.Key.Name))), sketch.Value);
            //    }                
            //}
            //Sketches = newSketches;
            DisplayDrawings();
        }

        /// <summary>
        /// Opens a preview form for the WIP Piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            if (CheckPiecesValid())
            {
                var clone = Utils.ClonePiece(WIP);
                Utils.CentrePieceOnAxis(clone);
                var newTab = new PreviewTab(Owner, clone);
                Utils.NewTabPage(newTab, "Preview " + Utils.BaseName(WIP.Name));
            }            
        }

        /// <summary>
        /// Closes this tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public new void CloseBtn_Click(object sender, EventArgs e)
        {
            if (Utils.ExitBtn_Click(WIP.Data.Count > 0))
            {
                Owner.RemoveTabPage(this);
            }
        }

        #endregion

        /// <summary>
        /// Changes the background colour of the drawing boards.
        /// </summary>
        /// <param name="color"></param>
        public void ChangeDrawingBgs(Color color)
        {
            DrawBase.BackColor = DrawRight.BackColor = DrawDown.BackColor = color;
        }



        // ----- PANEL REFRESH TIMER -----

        /// <summary>
        /// Starts the drawing timer once the tab has been created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void RefreshDrawPanel(object sender, EventArgs e)
        {
            DisplayTimer.Start();
        }

        /// <summary>
        /// Displays the drawings a short time after the tab has validated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayTimer_Tick(object sender, EventArgs e)
        {
            DisplayTimer.Stop();
            DisplayDrawings();
        }



        // ----- I/O -----

        #region I/O

        /// <summary>
        /// Places or selects a point on a board.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBoard_MouseDown(object sender, MouseEventArgs e)
        {
            var sent = sender == DrawBase ? 0 : sender == DrawRight ? 1 : 2;
            ActiveControl = DrawBase;

            // Select Spot to Move
            if (MovePointBtn.Checked)
            {
                var closestIndex = Utils.FindClosestIndex(WIP.Data, sent, e.X, e.Y);
                if (closestIndex != -1)
                {
                    SelectSpot(WIP.Data[closestIndex]);
                    moving = 1 + sent;
                    foreach(var cntl in Panel.Controls)
                    {
                        if (cntl is MovePointPanel)
                        {                            
                            (cntl as MovePointPanel).UpdateLabels(sent, sent == 1 ? selectedSpot.XRight : selectedSpot.X,
                                sent == 2 ? selectedSpot.YDown : selectedSpot.Y);
                        }
                    }
                }
                else
                {
                    Deselect();
                }
            }
            // Select Spot for Outline Updates
            else if (OutlineBtn.Checked)
            {
                var closestIndex = Utils.FindClosestIndex(WIP.Data, sent, e.X, e.Y);
                if (closestIndex != -1)
                {
                    SelectSpot(WIP.Data[closestIndex]);
                    foreach (var cntl in Panel.Controls)
                    {
                        if (cntl is OutlinePanel)
                        {
                            (cntl as OutlinePanel).UpdateValues(WIP.OutlineWidth, selectedSpot.Connector);                            
                        }
                    }
                }
                else
                {
                    Deselect();
                }
            }
            // Select Spot to Change its Fixed State
            else if (FixedBtn.Checked)
            {
                var closestIndex = Utils.FindClosestIndex(WIP.Data, sent, e.X, e.Y);
                if (closestIndex != -1)
                {
                    SelectSpot(WIP.Data[closestIndex]);
                    selectedSpot.Solid = selectedSpot.Solid == Consts.solidOptions[0] ? Consts.solidOptions[1] : Consts.solidOptions[0];
                }
            }
            // Select Spot to Erase
            else if (EraseBtn.Checked)
            {
                var closestIndex = Utils.FindClosestIndex(WIP.Data, sent, e.X, e.Y);
                if (closestIndex != -1)
                {
                    SelectSpot(WIP.Data[closestIndex]);
                    WIP.Data.Remove(selectedSpot);
                }
                else if (sent == 0)
                {
                    var result = MessageBox.Show("Are you sure you want to restart the piece?", "Confirm Erase", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        WIP.Data.Clear();
                    }
                }
                else
                {
                    var angle = sender == DrawRight ? new object[] { 0, 1, "rotated" } : new object[] { 1, 2, "turned" };
                    var result = MessageBox.Show("Are you sure you want to set the " + angle[2].ToString() + " view to the base position?",
                        "Confirm Erase", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        foreach (var spot in WIP.Data)
                        {
                            spot.SetCoords((int)angle[1], (int)angle[0], spot.GetCoordCombination()[(int)angle[0]]);
                        }
                    }
                }
                Deselect();
            }
            // Place Spot
            else
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
            DisplayDrawings();
        }

        /// <summary>
        /// Moves a spot if move is in progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBoard_MouseUp(object sender, MouseEventArgs e)
        {
            var sent = sender == DrawBase ? 0 : sender == DrawRight ? 1 : 2;

            if (selectedSpot != null && movingFar && moving == 1 + sent)
            {
                if (sent != 2)
                {
                    selectedSpot.XRight = e.X;
                }
                if (sent != 1)
                {
                    selectedSpot.YDown = e.Y;
                }
                if (sent == 0)
                {
                    selectedSpot.X = e.X;
                    selectedSpot.Y = e.Y;
                }          
            }
            StopMoving();
            DisplayDrawings();
        }

        /// <summary>
        /// Updates movement as mouse position changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedSpot == null || moving == 0 || e.X > DrawBase.Size.Width || e.Y > DrawBase.Size.Height || e.X < 0 || e.Y < 0)
            {
                StopMoving();
                return;
            }

            var sent = sender == DrawBase ? 0 : sender == DrawRight ? 1 : 2;

            if (!movingFar)
            {
                movingFar = Math.Abs(selectedSpot.X - e.X) > Consts.DragPrecision
                    || Math.Abs(selectedSpot.Y - e.Y) > Consts.DragPrecision;
            }

            if (movingFar)
            {
                DisplayDrawings();
                var shadow = new Spot(sent == 2 ? selectedSpot.X : e.X, sent == 1 ? selectedSpot.Y : e.Y);
                if (sent != 2)
                {
                    shadow.Draw(1, Consts.shadowShade, rotated);
                }
                if (sent != 1)
                {
                    shadow.Draw(2, Consts.shadowShade, turned);
                }
                if (sent == 0)
                {
                    shadow.Draw(0, Consts.shadowShade, original);
                }               
            }
        }

        /// <summary>
        /// Runs when a key is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void KeyPress(object sender, KeyEventArgs e)
        {
            if (ContainsFocus)
            {
                switch (e.KeyCode)
                {
                    // Delete Selected
                    case Keys.Delete:
                        // Delete Spot
                        if (selectedSpot != null)
                        {
                            var selectedIndex = WIP.Data.IndexOf(selectedSpot);
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

                    // Move Selected Point
                    case Keys.Up:
                        if (selectedSpot != null && Panel.Controls[0] is MovePointPanel)
                        {
                            (Panel.Controls[0] as MovePointPanel).ChangeUpDownValue(selectedSpot, false, false);
                        }
                        break;
                    case Keys.Down:
                        if (selectedSpot != null && Panel.Controls[0] is MovePointPanel)
                        {
                            (Panel.Controls[0] as MovePointPanel).ChangeUpDownValue(selectedSpot, true, false);
                        }
                        break;
                    case Keys.Left:
                        if (selectedSpot != null && Panel.Controls[0] is MovePointPanel)
                        {
                            (Panel.Controls[0] as MovePointPanel).ChangeUpDownValue(selectedSpot, false, true);
                        }
                        break;
                    case Keys.Right:
                        if (selectedSpot != null && Panel.Controls[0] is MovePointPanel)
                        {
                            (Panel.Controls[0] as MovePointPanel).ChangeUpDownValue(selectedSpot, true, true);
                        }
                        break;

                    // Do nothing for any other key
                    default:
                        break;
                }
            }
        }

        #endregion
        


        // ----- DRAWING FUNCTIONS -----

        /// <summary>
        /// Draws the points of the WIP to the board
        /// Angle: Original = 0, Rotated = 1, Turned = 2
        /// </summary>
        /// <param name="board">The graphics board to be drawn on</param>
        /// <param name="angle">The angle to be drawn</param>
        private void DrawPoints(Graphics board, int angle)
        {
            if (showPoints == true)
            {
                foreach (var spot in WIP.Data)
                {
                    var color = FixedBtn.Checked ? (spot.Solid == Consts.solidOptions[0]) ? Consts.option1 : Consts.option2
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
            foreach (var sketch in Sketches)
            {
                if (sketch.Value)
                {
                    var part = sketch.Key;
                    if (part is Set)
                    {
                        (part as Set).BasePiece.State = (part as Set).PersonalStates[(part as Set).BasePiece];
                    }
                    part.Draw(original);
                    part.Draw(rotated, new State(Utils.CloneState(part.ToPiece().State), 1, part.ToPiece().State.R + 90));
                    part.Draw(turned, new State(Utils.CloneState(part.ToPiece().State), 2, part.ToPiece().State.T + 90));
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
        }

        /// <summary>
        /// Deselects a point and disables features
        /// that require a point be selected.
        /// </summary>
        private void Deselect()
        {
            selectedSpot = null;
            foreach (var cntl in Panel.Controls)
            {
                if (cntl is OutlinePanel)
                {
                    (cntl as OutlinePanel).Enable(false);
                }
                else if (cntl is MovePointPanel)
                {
                    (cntl as MovePointPanel).UpdateLabels();
                }
            }
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
        /// Also re-orders the spots so the top left is first.
        /// </summary>
        /// <returns>True if piece is valid</returns>
        public bool CheckPiecesValid()
        {
            var spots = WIP.Data;
            if (spots.Count == 0)
            {
                return false;
            }
            else if (spots.Count < 2)
            {
                // Sort Spots
                if (spots[1].Y < spots[0].Y || spots[1].Y == spots[0].Y && spots[1].X < spots[0].X)
                {
                    var holder = Utils.CloneSpotList(spots);
                    spots[0] = holder[1];
                    spots[1] = holder[0];
                }
                return true;
            }

            Utils.SortCoordinates(spots);

            // Check X, Y, XR and YD for fold backs
            return CheckShapeDoubleBack(spots, 0, "base") && CheckShapeDoubleBack(spots, 1, "base")
                && CheckShapeDoubleBack(spots, 2, "rotated") && CheckShapeDoubleBack(spots, 3, "turned");
        }

        /// <summary>
        /// Checks that an individual angle does not contain multiple peaks or valleys.
        /// </summary>
        /// <param name="spots">The data</param>
        /// <param name="angle">X, Y, XR or YD</param>
        /// <param name="name">The angle name for error messages</param>
        /// <returns>True if only one valley and peak</returns>
        private bool CheckShapeDoubleBack(List<Spot> spots, int angle, string name)
        {
            var bigger = spots[0].GetCoord(angle) < spots[1].GetCoord(angle);
            var switchCount = 0;
            for (var index = 0; index < spots.Count - 1; index++)
            {
                if (spots[index].GetCoord(angle) != spots[Utils.NextIndex(spots, index)].GetCoord(angle))
                {
                    if (spots[index].GetCoord(angle) < spots[Utils.NextIndex(spots, index)].GetCoord(angle) != bigger)
                    {
                        bigger = !bigger;
                        switchCount++;
                    }
                }
            }
            if (switchCount > 2)
            {
                MessageBox.Show("Invalid " + name + " shape. Ensure shape does not fold back on itself.",
                    "Invalid " + name + " shape", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
    }
}
