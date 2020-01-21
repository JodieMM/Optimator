using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace Animator
{
    /// <summary>
    /// The form for building sets.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class SetsForm : Form
    {
        #region Sets Form Variables
        private Set WIP = new Set();
        private Piece selected = null;
        private Join selectedJoin = null;

        private Graphics original;
        private Graphics rotated;
        private Graphics turned;

        private int moving = -1;                // -1 = not, 0 = X & Y, 1 = X, 2 = Y
        private bool movingFar = false;         // Whether the piece is being selected or moved
        private int[] originalMoving;

        private Color unpressed = Color.FromArgb(192, 255, 192);
        private Color pressed = Color.FromArgb(153, 255, 153);
        #endregion


        /// <summary>
        /// SetsForm constructor.
        /// </summary>
        public SetsForm()
        {
            InitializeComponent();

            KeyPreview = true;
            KeyUp += KeyPress;

            DrawBase.MouseDown += new MouseEventHandler(DrawBase_MouseDown);
            DrawBase.MouseMove += new MouseEventHandler(DrawBase_MouseMove);
            DrawBase.MouseUp += new MouseEventHandler(DrawBase_MouseUp);
            DrawRight.MouseDown += new MouseEventHandler(DrawBase_MouseDown);
            DrawRight.MouseMove += new MouseEventHandler(DrawBase_MouseMove);
            DrawRight.MouseUp += new MouseEventHandler(DrawBase_MouseUp);
            DrawDown.MouseDown += new MouseEventHandler(DrawBase_MouseDown);
            DrawDown.MouseMove += new MouseEventHandler(DrawBase_MouseMove);
            DrawDown.MouseUp += new MouseEventHandler(DrawBase_MouseUp);
            DrawBase.BackColor = Settings.BackgroundColour;
            DrawRight.BackColor = Settings.BackgroundColour;
            DrawDown.BackColor = Settings.BackgroundColour;

            Utils.CheckValidFolder();            
        }



        // ----- OPTION BUTTONS -----

        /// <summary>
        /// Displays a preview of the set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            if (CheckSingularBasePiece())
            {
                PreviewForm previewForm = new PreviewForm(WIP);
                previewForm.Show();
            }
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            if (Utils.ExitBtn_Click(WIP.PiecesList.Count > 1))
            {
                Close();
            }
        }

        /// <summary>
        /// Saves the set and/or closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            if (WIP.PiecesList.Count < 1)
            {
                Close();
            }
            else if (!CheckSingularBasePiece())
            {
                MessageBox.Show("Please connect all pieces but one or remove unconnected pieces.", "Multiple Sets", MessageBoxButtons.OK);
            }
            else if (!Utils.CheckValidNewName(NameTb.Text, Consts.SetsFolder))
            {
                return;
            }            
            else
            {
                try
                {
                    Utils.SaveFile(Utils.GetDirectory(Consts.SetsFolder, NameTb.Text, Consts.Optr), WIP.GetData());
                    Close();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("No data entered for point.", "Missing Data", MessageBoxButtons.OK);
                }
            }
        }



        // ----- SET TAB -----
        #region Set Tab

        /// <summary>
        /// Adds a part to the set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Part justAdded;
                if (sender == AddPieceBtn)
                {
                    justAdded = new Piece(AddTb.Text);
                    WIP.PiecesList.Add(justAdded.ToPiece());
                    justAdded.ToPiece().State.SetCoordsBasedOnBoard(DrawBase);
                    WIP.PersonalStates.Add(justAdded as Piece, Utils.CloneState(justAdded.ToPiece().State));
                }
                else
                {
                    justAdded = new Set(AddTb.Text);
                    WIP.PiecesList.AddRange((justAdded as Set).PiecesList);
                    justAdded.ToPiece().State.SetCoordsBasedOnBoard(DrawBase);
                    foreach(var piece in (justAdded as Set).PiecesList)
                    {
                        WIP.PersonalStates.Add(piece, Utils.CloneState(piece.State));
                    }
                    (justAdded as Set).CalculateStates();
                }
                DeselectPiece();

                // If first piece, set as base
                if (WIP.PiecesList.Count == 1)
                {
                    WIP.BasePiece = justAdded.ToPiece();
                }

                DisplayDrawings();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Suspected outdated file.", "File Indexing Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Toggles whether a base piece is being selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectBaseBtn_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                if (SelectBaseBtn.BackColor == unpressed)
                {
                    JoinBtn.BackColor = unpressed;
                    SelectBaseBtn.BackColor = pressed;
                }
                else
                {
                    SelectBaseBtn.BackColor = unpressed;
                }
            }            
        }

        /// <summary>
        /// Toggles whether the join is being moved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JoinBtn_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                if (JoinBtn.BackColor == unpressed)
                {
                    SelectBaseBtn.BackColor = unpressed;
                    JoinBtn.BackColor = pressed;

                    // Change base piece angle to ensure selected is rts 0
                    WIP.CalculateStates();
                    WIP.BasePiece.State.R = (WIP.BasePiece.State.R - selected.State.R) % 360;
                    WIP.BasePiece.State.T = (WIP.BasePiece.State.T - selected.State.T) % 360;
                    WIP.BasePiece.State.S = (WIP.BasePiece.State.S - selected.State.S) % 360;
                }
                else
                {
                    JoinBtn.BackColor = unpressed;
                }
                DisplayDrawings();
            }            
        }

        /// <summary>
        /// Moves the selected piece upwards or downwards in order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpOrDownBtn_Click(object sender, EventArgs e)
        {
            if (selected == null)
            {
                return;
            }

            int selectedIndex = WIP.PiecesList.IndexOf(selected);
            bool condition = sender == UpBtn ? selectedIndex != -1 && selectedIndex < WIP.PiecesList.Count - 1 : selectedIndex > 0;
            if (condition)
            {
                int change = sender == UpBtn ? 1 : -1;
                Piece holding = WIP.PiecesList[selectedIndex];
                WIP.PiecesList[selectedIndex] = WIP.PiecesList[selectedIndex + change];
                WIP.PiecesList[selectedIndex + change] = holding;
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Changes the flipped attributes of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlipsCb_CheckedChanged(object sender, EventArgs e)
        {
            if (selected != null && WIP.JoinsIndex.ContainsKey(selected))
            {
                FlipsOptionsPanel.Visible = FlipsCb.Checked;
                WIP.JoinsIndex[selected].FlipAngle = FlipsCb.Checked ? (double)FlipsRotation.Value : -1;    
                // SortOrder: Turn value
            }
        }

        /// <summary>
        /// Changes the flip angle of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlipsUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (selected != null && WIP.JoinsIndex.ContainsKey(selected))
            {
                WIP.JoinsIndex[selected].FlipAngle = (double)FlipsRotation.Value;
            }
        }

        #endregion



        // ----- PIECES TAB -----

        /// <summary>
        /// Updates the selected piece based on the UI object
        /// that was interacted with.
        /// </summary>
        /// <param name="sender">Touched UI object</param>
        /// <param name="e"></param>
        private void UpdateSelectedPiece(object sender, EventArgs e)
        {
            if (selected == null)
            {
                return;
            }

            if (sender == RotationBar)
            {
                WIP.PersonalStates[selected].R = RotationBar.Value;
            }
            else if (sender == TurnBar)
            {
                WIP.PersonalStates[selected].T = TurnBar.Value;
            }
            else if (sender == SpinBar)
            {
                WIP.PersonalStates[selected].S = SpinBar.Value;
            }
            else if (sender == SizeBar)
            {
                WIP.PersonalStates[selected].SM = SizeBar.Value / 100.0;
            }

            DisplayDrawings();
        }



        // ----- DRAW PANEL I/O -----
        #region Draw Panel I/O

        /// <summary>
        /// Starts click preparation, checking for a click or drag.
        /// May act differently if buttons are pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBase_MouseDown(object sender, MouseEventArgs e)
        {
            var sent = sender == DrawBase ? 0 : sender == DrawRight ? 1 : 2;

            // Move the Piece's Join            
            if (JoinBtn.BackColor == pressed)
            {
                State baseState = WIP.BasePiece.State;
                FindCorrectStates(sent);
                var clickedJoin = Utils.FindClickedJoin(new List<Join>(WIP.FindPieceJoins(selected).Keys),
                    e.X, e.Y, SelectFromTopCb.Checked);

                if (clickedJoin != null)
                {
                    selectedJoin = clickedJoin;
                    originalMoving = new int[] { e.X, e.Y };
                    moving = sent;
                }
                WIP.BasePiece.State = baseState;
            }
            else
            {
                // Check if Piece Selected
                FindCorrectStates(sent);
                var newSelected = Utils.FindClickedSelection(WIP.PiecesList, e.X, e.Y, SelectFromTopCb.Checked);
                if (newSelected != null)
                {
                    // Set a new base for the selected piece and adjust coords and join
                    if (SelectBaseBtn.BackColor == pressed && selected != newSelected)
                    {
                        // Remove old joinings
                        if (WIP.JoinsIndex.ContainsKey(selected))
                        {
                            var basePiece = WIP.JoinsIndex[selected].B;
                            WIP.JoinedPieces[basePiece].Remove(selected);
                            if (WIP.JoinedPieces[basePiece].Count < 1)
                            {
                                WIP.JoinedPieces.Remove(basePiece);
                            }
                            WIP.JoinsIndex.Remove(selected);
                        }
                        JoinPieces(selected, newSelected);
                        SelectBaseBtn.BackColor = unpressed;
                        WIP.SortOrder();
                    }
                    // Select a new piece
                    else
                    {
                        SelectPiece(newSelected);
                        originalMoving = new int[] { e.X, e.Y };
                        moving = sent;
                    }
                }
                // If clicked nothing
                else if (SelectBaseBtn.BackColor != pressed)
                {
                    DeselectPiece();
                }
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Checks if a piece is being moved or just clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBase_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving == -1)
            {
                return;
            }
            var sent = sender == DrawBase ? 0 : sender == DrawRight ? 1 : 2;

            // Invalid Mouse Position
            if (selected is null || e.X < 0 || e.Y < 0 || e.X > DrawBase.Size.Width || e.Y > DrawBase.Size.Height)
            {
                StopMoving();
            }
            // Move Point
            else if (!movingFar)
            {
                movingFar = Math.Abs(selected.State.X - e.X) > Consts.ClickPrecision
                    || Math.Abs(selected.State.Y - e.Y) > Consts.ClickPrecision;
            }
            DisplayDrawings();

            // Shadows
            if (movingFar)
            {
                var xChange = sent == 2 ? 0 : e.X - originalMoving[0];
                var yChange = sent == 1 ? 0 : e.Y - originalMoving[1];
                var board = sent == 0 ? original : sent == 1 ? rotated : turned;

                // Move Join
                if (JoinBtn.BackColor == pressed)
                {
                    Visuals.DrawCross(selectedJoin.AngledCentre(sent)[0] + xChange,
                        selectedJoin.AngledCentre(sent)[1] + yChange, Consts.shadowShade, board);
                }
                // Move Piece
                else
                {
                    for (int index = 0; index < selected.Data.Count; index++)
                    {
                        State modState = Utils.CloneState(selected.State);
                        if (sent == 1)
                        {
                            modState.R = (modState.R + 90) % 360;
                        }
                        else if (sent == 2)
                        {
                            modState.T = (modState.T + 90) % 360;
                        }
                        modState.X += xChange;
                        modState.Y += yChange;
                        selected.Draw(board, modState, new ColourState(selected.ColourState, 
                            Consts.shadowShade, new Color[] { Consts.shadowShade }));
                    }
                }
            }
        }

        /// <summary>
        /// Updates the user interface for the selected piece and stops
        /// the movement search, actioning it if necessary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBase_MouseUp(object sender, MouseEventArgs e)
        {
            if (moving == -1 || selected is null)
            {
                return;
            }
            var sent = sender == DrawBase ? 0 : sender == DrawRight ? 1 : 2;

            if (movingFar)
            {
                var x = sent == 2 ? 0 : e.X - originalMoving[0];
                var y = sent == 1 ? 0 : e.Y - originalMoving[1];

                // Move Join
                if (JoinBtn.BackColor == pressed)
                {
                    if (selectedJoin != null)
                    {
                        double[] position = selectedJoin.AngledCentre(sent);
                        double[] newJoinPosition = new double[2] { position[0] + x, position[1] + y };

                        // Change different angles based on board
                        if (sent == 0)
                        {
                            // Change different angles based on whether selected is the attached or base
                            if (WIP.JoinsIndex.ContainsKey(selected) && WIP.JoinsIndex[selected] == selectedJoin)
                            {
                                selectedJoin.AX = selectedJoin.AXRight = selected.State.GetCoords()[0] - newJoinPosition[0];
                                selectedJoin.AY = selectedJoin.AYDown = selected.State.GetCoords()[1] - newJoinPosition[1];
                            }
                            else
                            {
                                selectedJoin.BX = selectedJoin.BXRight = newJoinPosition[0] - selectedJoin.B.State.GetCoords()[0];
                                selectedJoin.BY = selectedJoin.BYDown = newJoinPosition[1] - selectedJoin.B.State.GetCoords()[1];
                            }
                        }
                        else if (sent == 1)
                        {
                            // Change different angles based on whether selected is the attached or base
                            if (WIP.JoinsIndex.ContainsKey(selected) && WIP.JoinsIndex[selected] == selectedJoin)
                            {
                                selectedJoin.AXRight = selected.State.GetCoords()[0] - newJoinPosition[0];
                            }
                            else
                            {
                                selectedJoin.BXRight = newJoinPosition[0] - selectedJoin.B.State.GetCoords()[0];
                            }
                        }
                        else if (sent == 2)
                        {
                            // Change different angles based on whether selected is the attached or base
                            if (WIP.JoinsIndex.ContainsKey(selected) && WIP.JoinsIndex[selected] == selectedJoin)
                            {
                                selectedJoin.AYDown = selected.State.GetCoords()[1] - newJoinPosition[1];
                            }
                            else
                            {
                                selectedJoin.BYDown = newJoinPosition[1] - selectedJoin.B.State.GetCoords()[1];
                            }
                        }
                    }
                }
                // Move Piece
                else if (WIP.JoinsIndex.ContainsKey(selected))
                {
                    // Piece in Set
                    if (sent == 0)
                    {
                        WIP.JoinsIndex[selected].AXRight = WIP.JoinsIndex[selected].AX += x;
                        WIP.JoinsIndex[selected].AYDown = WIP.JoinsIndex[selected].AY += y;
                    }
                    else if (sent == 1)
                    {
                        WIP.JoinsIndex[selected].AXRight += x;
                    }
                    else if (sent == 2)
                    {
                        WIP.JoinsIndex[selected].AYDown += y;
                    }
                    WIP.CalculateStates();
                }
                else
                {
                    // Piece Solo
                    WIP.PersonalStates[selected].X += x;
                    WIP.PersonalStates[selected].Y += y;
                    WIP.CalculateStates();
                }
            }
            StopMoving();
            DisplayDrawings();
        }

        /// <summary>
        /// Resets all moving variables.
        /// </summary>
        private void StopMoving()
        {
            moving = -1;
            movingFar = false;
            selectedJoin = null;
        }

        /// <summary>
        /// Erases the changes made to one of the angles and returns it to base.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EraseAngleBtn_Click(object sender, EventArgs e)
        {
            var angle = sender == EraseRightBtn ? "rotated" : "turned";
            var result = MessageBox.Show("Are you sure you wish to erase all changes to the set's " + angle + " state?",
                "Erase Changes", MessageBoxButtons.OKCancel);

            foreach (var join in WIP.JoinsIndex)
            {
                if (angle == "rotated")
                {
                    join.Value.AXRight = join.Value.AX;
                    join.Value.BXRight = join.Value.BX;
                }
                else
                {
                    join.Value.AYDown = join.Value.AY;
                    join.Value.BYDown = join.Value.BY;
                }
            }
            DisplayDrawings();
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
                // Delete Selected Piece
                case Keys.Delete:
                    if (selected == null)
                    {
                        return;
                    }
                    RemovePiece(selected);
                    selected = null;
                    DisplayDrawings();
                    break;

                // Do nothing for any other key
                default:
                    break;
            }
        }

        #endregion



        // ----- OTHER FUNCTIONS -----

        /// <summary>
        /// Displays all of the current pieces to the screen.
        /// </summary>
        private void DisplayDrawings()
        {
            // Prepare Boards
            DrawBase.Refresh();
            DrawRight.Refresh();
            DrawDown.Refresh();
            original = DrawBase.CreateGraphics();
            rotated = DrawRight.CreateGraphics();
            turned = DrawDown.CreateGraphics();

            var boards = new Graphics[3] { original, rotated, turned };
            State baseState = WIP.BasePiece.State;

            // For Each Angle
            for (int angle = 0; angle < 3; angle++)
            {
                FindCorrectStates(angle);

                // Draw Pieces
                foreach (Piece piece in WIP.PiecesList)
                {
                    // Moving
                    if (selected != null && piece == selected && movingFar)
                    {
                        piece.Draw(boards[angle], piece.State, new ColourState(piece.ColourState, Consts.shadowShade));
                    }
                    // Selected
                    else if (selected != null && piece == selected)
                    {
                        piece.Draw(boards[angle], piece.State, new ColourState(piece.ColourState, Consts.select));
                    }
                    // Attached to Selected
                    else if (selected != null && WIP.JoinedPieces.ContainsKey(selected) && WIP.JoinedPieces[selected].Contains(piece))
                    {
                        piece.Draw(boards[angle], piece.State, new ColourState(piece.ColourState, Consts.highlight));
                    }
                    // Base of Selected
                    else if (selected != null && WIP.JoinsIndex.ContainsKey(selected) && WIP.JoinsIndex[selected].B == piece)
                    {
                        piece.Draw(boards[angle], piece.State, new ColourState(piece.ColourState, Consts.lowlight));
                    }
                    else
                    {
                        piece.Draw(boards[angle], piece.State);
                    }
                }

                // Draw Joins if JoinBtn Pressed
                if (JoinBtn.BackColor == pressed)
                {
                    var joinsDraw = WIP.FindPieceJoins(selected);
                    foreach (KeyValuePair<Join, bool> joinDraw in joinsDraw)
                    {
                        joinDraw.Key.Draw(joinDraw.Key == selectedJoin ? Consts.select : joinDraw.Value ? Consts.option1 : Consts.option2, boards[angle]);
                    }
                    WIP.BasePiece.State = baseState;
                }
            }
        }

        /// <summary>
        /// Selects a piece.
        /// </summary>
        /// <param name="piece">The piece to select</param>
        private void SelectPiece(Piece piece)
        {
            DeselectPiece();
            selected = piece;
            SizeBar.Enabled = true;
            SizeBar.Value = (int)(WIP.PersonalStates[selected].SM * 100.0);
            if (selected != WIP.BasePiece)
            {
                Utils.EnableObjects(new List<Control>() { RotationBar, TurnBar, SpinBar,
                    SelectBaseBtn, JoinBtn});           
                RotationBar.Value = (int)WIP.PersonalStates[selected].R;
                TurnBar.Value = (int)WIP.PersonalStates[selected].T;
                SpinBar.Value = (int)WIP.PersonalStates[selected].S;                
            }
        }

        /// <summary>
        /// Deselects a piece.
        /// </summary>
        private void DeselectPiece()
        {
            if (selected != null)
            {
                selected = null;                
            }
            JoinBtn.BackColor = unpressed;
            SelectBaseBtn.BackColor = unpressed;
            //Utils.EnableObjects(new List<Control>() { RotationBar, TurnBar, SpinBar,
              //      SizeBar, MoveJoinBtn, SelectBaseBtn }, false); // HIDDEN: Base piece movement
        }

        /// <summary>
        /// Checks that all pieces bar one are connected to something.
        /// Also sets the base piece of the set.
        /// </summary>
        /// <returns>True if only one unconnected piece</returns>
        private bool CheckSingularBasePiece()
        {
            if (WIP.PiecesList.Count == 1)
            {
                return true;
            }
            WIP.BasePiece = null;
            foreach (Piece piece in WIP.PiecesList)
            {
                if (WIP.JoinedPieces.ContainsKey(piece) && !WIP.JoinsIndex.ContainsKey(piece))
                {
                    if (WIP.BasePiece == null)
                    {
                        WIP.BasePiece = piece;
                    }
                    else
                    {
                        WIP.BasePiece = null;
                        return false;
                    }
                }
                else if(!WIP.JoinedPieces.ContainsKey(piece) && !WIP.JoinsIndex.ContainsKey(piece))
                {
                    return false;
                }
            }
            return WIP.BasePiece == null ? false: true;
        }

        /// <summary>
        /// Creates a join between two pieces.
        /// </summary>
        /// <param name="a">The attaching piece</param>
        /// <param name="b">The base piece</param>
        private void JoinPieces(Piece a, Piece b)
        {
            WIP.JoinsIndex.Add(a, new Join(a, b, WIP));
            WIP.AddToJoinedPieces(a, b);
            WIP.PersonalStates[a].X = 0;
            WIP.PersonalStates[a].Y = 0;
        }

        /// <summary>
        /// Removes all mentions of a piece from the set.
        /// </summary>
        /// <param name="piece">The piece to remove</param>
        public void RemovePiece(Piece piece)
        {
            if (WIP.JoinedPieces.ContainsKey(piece))
            {
                WIP.JoinedPieces.Remove(piece);
            }
            if (WIP.JoinsIndex.ContainsKey(piece))
            {
                Piece joinedTo = WIP.JoinsIndex[piece].B;
                WIP.JoinedPieces[joinedTo].Remove(piece);
                WIP.JoinsIndex.Remove(piece);
            }
            WIP.PiecesList.Remove(piece);
        }       

        /// <summary>
        /// Finds the correct state of the set based on the required angle
        /// </summary>
        /// <param name="angle">0 original, 1 rotated, 2 turned</param>
        private void FindCorrectStates(int angle = 0)
        {
            // Take current state if flat join in progress
            WIP.CalculateStates(angle, JoinBtn.BackColor == pressed ? WIP.BasePiece.State : null);

            // Reangle Unattached Pieces        //TODO: Only moves solo pieces, not joins unattached to base (Remove altogether?)
            foreach (var piece in WIP.PiecesList)
            {
                if (!WIP.JoinsIndex.ContainsKey(piece))
                {
                    piece.State = angle > 0 ? new State(WIP.PersonalStates[piece], angle,
                        (WIP.PersonalStates[piece].GetAngles()[angle - 1] + 90) % 360) : WIP.PersonalStates[piece];
                }
            }
        }
    }
}
