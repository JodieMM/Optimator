using Optimator;
using Optimator.Forms;
using Optimator.Forms.Sets;
using Optimator.Tabs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Sets
{
    /// <summary>
    /// A tab used to generate and modify sets.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class SetsTab : TabPageControl
    {
        #region Sets Form Variables
        public override HomeForm Owner { get; set; }
        private PanelControl Baby;

        public Set WIP = new Set();
        public Piece selected = null;
        public Join selectedJoin = null;

        private Graphics original;
        private Graphics rotated;
        private Graphics turned;

        private int moving = -1;                // -1 = not, 0 = X & Y, 1 = X, 2 = Y
        private bool movingFar = false;         // Whether the piece is being selected or moved
        private int[] originalMoving;

        public bool SelectFromTop = true;
        #endregion
        

        /// <summary>
        /// Constructor for the tab.
        /// </summary>
        /// <param name="owner"></param>
        public SetsTab(HomeForm owner)
        {
            InitializeComponent();
            Owner = owner;

            KeyUp += KeyPress;
        }



        // ----- GET FUNCTIONS -----

        /// <summary>
        /// Gets a board to use in a utils sizing function in AddPartPanel.
        /// </summary>
        /// <returns>A PictureBox used as a board</returns>
        public PictureBox GetBoardSizing()
        {
            return DrawBase;
        }

        /// <summary>
        /// Finds whether the join btn is pressed.
        /// </summary>
        /// <returns>True if pressed</returns>
        public bool GetIfJoinBtnPressed()
        {
            return JoinsBtn.Checked && (Baby as JoinsPanel).JoinBtnPressed();
        }


        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab.
        /// </summary>
        public override void Resize()
        {
            float widthPercent = Width > 950 ? 0.25F : 0.3F;
            float widthBigPercent = Width > 950 ? 0.3F : 0.33F;
            float heightPercent = Height > 560 ? 0.45F : 0.4F;

            int bigWidth = (int)(Width * widthPercent);
            int largeWidth = (int)(Width * widthBigPercent);
            int bigHeight = (int)(Height * heightPercent);
            int bigLength = bigWidth > bigHeight ? bigHeight : bigWidth;

            int lilWidth = (int)((Width - 2 * bigLength - largeWidth) / 3.0);
            int lilHeight = (int)((Height - 2 * bigLength - ToolStrip.Height) / 3.0);

            DrawBase.Size = DrawRight.Size = DrawDown.Size = new Size(bigLength, bigLength);
            DrawBase.Location = new Point(lilWidth, lilHeight + ToolStrip.Height);
            DrawRight.Location = new Point(lilWidth * 2 + bigLength, lilHeight + ToolStrip.Height);
            DrawDown.Location = new Point(lilWidth, lilHeight * 2 + bigLength + ToolStrip.Height);

            Panel.Width = largeWidth;
            Utils.ResizePanel(Panel);
        }

        #region ToolStrip

        /// <summary>
        /// Unchecks all of the checkable buttons and checks the provided one.
        /// </summary>
        private void SelectButton(ToolStripButton btn)
        {
            SaveBtn.Checked = false;
            AddPartBtn.Checked = false;
            JoinsBtn.Checked = false;
            PositionsBtn.Checked = false;
            OrderBtn.Checked = false;
            EraseBtn.Checked = false;
            SettingsBtn.Checked = false;
            btn.Checked = true;
            DisplayDrawings();
        }

        /// <summary>
        /// Unchecks all buttons and clears panel.
        /// </summary>
        private void DeselectButtons()
        {
            SelectButton(SaveBtn);
            SaveBtn.Checked = false;
            Panel.Controls.Clear();
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
                // Set Baby
                if (sender == SaveBtn)
                {
                    Baby = new SavePanel(this);
                }
                else if (sender == AddPartBtn)
                {
                    Baby = new AddPartPanel(this);
                }
                else if (sender == JoinsBtn)
                {
                    Baby = new JoinsPanel(this);
                }
                else if (sender == PositionsBtn)
                {
                    Baby = new PositionsPanel(this);
                }
                else if (sender == OrderBtn)
                {
                    Baby = new OrderPanel(this);
                }
                else if (sender == EraseBtn)
                {
                    Baby = new ErasePanel(this);
                }
                else if (sender == SettingsBtn)
                {
                    Baby = new SettingsPanel(this);
                }
                Utils.NewPanelContent(Panel, Baby);
                SelectButton(sender as ToolStripButton);
            }
            else
            {
                DeselectButtons();
            }
        }

        /// <summary>
        /// Opens a preview form for the WIP Set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            if (CheckSingularBasePiece())
            {
                PreviewTab newTab = new PreviewTab(Owner, WIP);
                Utils.NewTabPage(newTab, "Preview " + WIP.Name);
            }
        }

        /// <summary>
        /// Closes this tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void CloseBtn_Click(object sender, EventArgs e)
        {
            if (Utils.ExitBtn_Click(WIP.PiecesList.Count > 1))
            {
                Owner.RemoveTabPage(this);
            }

            //HIDDEN: Below used for testing
            //WIP = new Set
            //{
            //    PiecesList = new List<Piece>() { new Piece("branch"), new Piece("tri") }
            //};
            //WIP.BasePiece = WIP.PiecesList[0];
            //WIP.JoinedPieces.Add(WIP.PiecesList[0], new List<Piece>() { WIP.PiecesList[1] });
            //WIP.JoinsIndex.Add(WIP.PiecesList[1], new Join(WIP.PiecesList[1], WIP.PiecesList[0], WIP, -5, -71, 12, -23, 20, -22, 3, -10, -1, 0));
            //WIP.PersonalStates.Add(WIP.PiecesList[0], new State(150, 150, 0, 0, 0, 1));
            //WIP.PersonalStates.Add(WIP.PiecesList[1], new State(0, 0, 0, 0, 40, 1));
            //DisplayDrawings();

            //WIP = new Set
            //{
            //    PiecesList = new List<Piece>() { new Piece("branch"), new Piece("line") }
            //};
            //WIP.BasePiece = WIP.PiecesList[0];
            //WIP.JoinedPieces.Add(WIP.PiecesList[0], new List<Piece>() { WIP.PiecesList[1] });
            //WIP.JoinsIndex.Add(WIP.PiecesList[1], new Join(WIP.PiecesList[1], WIP.PiecesList[0], WIP, 0, -54, 0, -54, 0, -46, 0, -6, -1, 0));
            //WIP.PersonalStates.Add(WIP.PiecesList[0], new State(150, 150, 0, 0, 0, 1));
            //WIP.PersonalStates.Add(WIP.PiecesList[1], new State(0, 0, 0, 0, 175, 1));
            //DisplayDrawings();
        }

        #endregion



        // ----- DRAW PANEL I/O -----

        #region Draw Panel I/O

        /// <summary>
        /// Starts click preparation, checking for a click or drag.
        /// May act differently if buttons are pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBoard_MouseDown(object sender, MouseEventArgs e)
        {
            var sent = sender == DrawBase ? 0 : sender == DrawRight ? 1 : 2;

            // Move the Piece's Join            
            if (GetIfJoinBtnPressed())
            {
                State baseState = WIP.BasePiece.State;
                FindCorrectStates(sent);
                var clickedJoin = Utils.FindClickedJoin(new List<Join>(WIP.FindPieceJoins(selected).Keys),
                    e.X, e.Y, SelectFromTop);

                if (clickedJoin != null)
                {
                    selectedJoin = clickedJoin;
                    originalMoving = new int[] { e.X, e.Y };
                    moving = sent;
                }
                WIP.BasePiece.State = baseState;
            }
            else if (EraseBtn.Checked && sender != DrawBase)
            {
                var angle = sender == DrawRight ? "rotated" : "turned";
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
            else
            {
                // Check if Piece Selected
                FindCorrectStates(sent);
                var newSelected = Utils.FindClickedSelection(WIP.PiecesList, e.X, e.Y, SelectFromTop);
                if (newSelected != null)
                {
                    // Set a new base for the selected piece and adjust coords and join
                    if (GetIfJoinBtnPressed() && selected != newSelected)
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
                        (Baby as JoinsPanel).UnselectBaseBtn();
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
                DeselectPiece();
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Checks if a piece is being moved or just clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBoard_MouseMove(object sender, MouseEventArgs e)
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
                movingFar = Math.Abs(selected.State.X - e.X) > Consts.DragPrecision
                    || Math.Abs(selected.State.Y - e.Y) > Consts.DragPrecision;
            }
            DisplayDrawings();

            // Shadows
            if (movingFar)
            {
                var xChange = sent == 2 ? 0 : e.X - originalMoving[0];
                var yChange = sent == 1 ? 0 : e.Y - originalMoving[1];
                var board = sent == 0 ? original : sent == 1 ? rotated : turned;

                // Move Join
                if (GetIfJoinBtnPressed())
                {
                    Visuals.DrawCross(selectedJoin.CurrentCentre()[0] + xChange,
                        selectedJoin.CurrentCentre()[1] + yChange, Consts.shadowShade, board);
                }
                // Move Piece
                else
                {
                    FindCorrectStates(sent);
                    for (int index = 0; index < selected.Data.Count; index++)
                    {
                        State modState = Utils.CloneState(selected.State);
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
        private void DrawBoard_MouseUp(object sender, MouseEventArgs e)
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
                if (GetIfJoinBtnPressed())
                {
                    if (selectedJoin != null)
                    {
                        // Change different angles based on board
                        if (sent == 0)
                        {
                            // Change different angles based on whether selected is the attached or base
                            if (WIP.JoinsIndex.ContainsKey(selected) && WIP.JoinsIndex[selected] == selectedJoin)
                            {
                                selectedJoin.AXRight = selectedJoin.AX -= x;
                                selectedJoin.AYDown = selectedJoin.AY -= y;
                            }
                            else
                            {
                                selectedJoin.BXRight = selectedJoin.BX += x;
                                selectedJoin.BYDown = selectedJoin.BY += y;
                            }
                        }
                        else if (sent == 1)
                        {
                            // Change different angles based on whether selected is the attached or base
                            if (WIP.JoinsIndex.ContainsKey(selected) && WIP.JoinsIndex[selected] == selectedJoin)
                            {
                                selectedJoin.AXRight -= x;
                            }
                            else
                            {
                                selectedJoin.BXRight += x;
                            }
                        }
                        else if (sent == 2)
                        {
                            // Change different angles based on whether selected is the attached or base
                            if (WIP.JoinsIndex.ContainsKey(selected) && WIP.JoinsIndex[selected] == selectedJoin)
                            {
                                selectedJoin.AYDown -= y;
                            }
                            else
                            {
                                selectedJoin.BYDown += y;
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
                        WIP.JoinsIndex[selected].BXRight = WIP.JoinsIndex[selected].BX += x;
                        WIP.JoinsIndex[selected].BYDown = WIP.JoinsIndex[selected].BY += y;
                    }
                    else if (sent == 1)
                    {
                        WIP.JoinsIndex[selected].BXRight += x;
                    }
                    else if (sent == 2)
                    {
                        WIP.JoinsIndex[selected].BYDown += y;
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
        public void DisplayDrawings()
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
                if (GetIfJoinBtnPressed())
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
            if (Baby is PositionsPanel)
            {
                (Baby as PositionsPanel).EnableScrolls();
            }
        }

        /// <summary>
        /// Deselects a piece.
        /// </summary>
        public void DeselectPiece()
        {
            if (selected != null)
            {
                selected = null;
            }
            if (Baby is JoinsPanel)
            {
                (Baby as JoinsPanel).UnselectButtons();
            }
            else if (Baby is PositionsPanel)
            {
                (Baby as PositionsPanel).EnableScrolls(false);
            }
        }

        /// <summary>
        /// Checks that all pieces bar one are connected to something.
        /// Also sets the base piece of the set.
        /// </summary>
        /// <returns>True if only one unconnected piece</returns>
        public bool CheckSingularBasePiece()
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
                else if (!WIP.JoinedPieces.ContainsKey(piece) && !WIP.JoinsIndex.ContainsKey(piece))
                {
                    return false;
                }
            }
            return WIP.BasePiece == null ? false : true;
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
            WIP.CalculateStates(angle, GetIfJoinBtnPressed() ? WIP.BasePiece.State : null);

            // Consider unattached pieces
            if (WIP.JoinsIndex.Count != WIP.PiecesList.Count - 1)
            {
                foreach (var piece in WIP.PiecesList)
                {
                    if (!WIP.JoinsIndex.ContainsKey(piece))
                    {
                        piece.State = Utils.AdjustStateAngle(angle, WIP.PersonalStates[piece]);
                    }
                }
            }
        }

        /// <summary>
        /// Change base piece angle to ensure selected is rts 0
        /// </summary>
        public void SelectedRTS0()
        {
            WIP.CalculateStates();
            WIP.BasePiece.State.R = Utils.Modulo(WIP.BasePiece.State.R - selected.State.R, 360);
            WIP.BasePiece.State.T = Utils.Modulo(WIP.BasePiece.State.T - selected.State.T, 360);
            WIP.BasePiece.State.S = Utils.Modulo(WIP.BasePiece.State.S - selected.State.S, 360);
        }
    }
}
