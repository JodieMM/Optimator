﻿using Optimator;
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
        public string Directory { get; set; } = "";

        public Set WIP = new Set();
        public Piece selected = null;
        public Join selectedJoin = null;

        private Bitmap original;
        private Bitmap rotated;
        private Bitmap turned;

        private int moving = -1;                // -1 = not, 0 = X & Y, 1 = X, 2 = Y
        private bool movingFar = false;         // Whether the piece is being selected or moved
        private int[] originalMoving;
        private Spot shadow = null;
        private State shadowState = null;

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

            Owner.GetTabControl().KeyDown += KeyPress;
            Owner.GetTabControl().KeyUp += KeyPress;
            Enter += RefreshDrawPanel;
            VisibleChanged += RefreshDrawPanel;
            Validated += RefreshDrawPanel;
            Paint += RefreshDrawPanel;

            original = new Bitmap(DrawBase.Width, DrawBase.Height);
            rotated = new Bitmap(DrawRight.Width, DrawRight.Height);
            turned = new Bitmap(DrawDown.Width, DrawDown.Height);

            ChangeDrawingBgs(Utils.ColourFromString(Properties.Settings.Default.BgColour));
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
        /// Gets the back colour of the drawing boards.
        /// </summary>
        /// <returns></returns>
        public Color GetBoardColor()
        {
            return DrawBase.BackColor;
        }

        /// <summary>
        /// Finds whether the join btn is pressed.
        /// </summary>
        /// <param name="baseBtn">True if checking base btn pressed instead</param>
        /// <returns>True if pressed</returns>
        public bool GetIfJoinBtnPressed(bool baseBtn = false)
        {
            if (Panel.Controls.Count > 0 && Panel.Controls[0] is JoinsPanel)
            {
                if (baseBtn)
                {
                    return JoinsBtn.Checked && (Panel.Controls[0] as JoinsPanel).SelectBaseBtnPressed();
                }
                return JoinsBtn.Checked && (Panel.Controls[0] as JoinsPanel).JoinBtnPressed();
            }
            return false;
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
            if (DrawBase.Width != 0 && DrawBase.Height != 0)
            {
                original = new Bitmap(DrawBase.Width, DrawBase.Height);
                rotated = new Bitmap(DrawRight.Width, DrawRight.Height);
                turned = new Bitmap(DrawDown.Width, DrawDown.Height);

                Panel.Width = largeWidth;
                Utils.ResizePanel(Panel);
                DisplayDrawings();
            }
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
            SaveBtn.Checked = false;
            AddPartBtn.Checked = false;
            JoinsBtn.Checked = false;
            PositionsBtn.Checked = false;
            OrderBtn.Checked = false;
            EraseBtn.Checked = false;
            SettingsBtn.Checked = false;
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
                if (sender == SaveBtn)
                {
                    Utils.NewPanelContent(Panel, new SavePanel(this));
                }
                else if (sender == AddPartBtn)
                {
                    Utils.NewPanelContent(Panel, new AddPartPanel(this));
                }
                else if (sender == JoinsBtn)
                {
                    Utils.NewPanelContent(Panel, new JoinsPanel(this));
                }
                else if (sender == PositionsBtn)
                {
                    Utils.NewPanelContent(Panel, new PositionsPanel(this));
                }
                else if (sender == OrderBtn)
                {
                    Utils.NewPanelContent(Panel, new OrderPanel(this));
                }
                else if (sender == EraseBtn)
                {
                    Utils.NewPanelContent(Panel, new ErasePanel(this));
                }
                else if (sender == SettingsBtn)
                {
                    Utils.NewPanelContent(Panel, new SettingsPanel(this));
                }
                SelectButton(sender as ToolStripButton);
            }
            else
            {
                DeselectButtons();
            }
        }

        /// <summary>
        /// Reloads the pieces in the set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            //for (int index = 0; index < WIP.PiecesList.Count; index++)
            //{
            //    WIP.PiecesList[index] = new Piece(WIP.PiecesList[index].Name,
            //        Utils.ReadFile(Utils.GetDirectory(WIP.PiecesList[index].Name)));
            //}
            DisplayDrawings();
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
                var newTab = new PreviewTab(Owner, WIP);
                Utils.NewTabPage(newTab, "Preview " + WIP.Name);
            }
            else
            {
                MessageBox.Show("Set has unconnected pieces.", "Invalid Preview", MessageBoxButtons.OK);
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



        // ----- PANEL REFRESH TIMER

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
            ActiveControl = DrawBase;

            // Move the Piece's Join            
            if (GetIfJoinBtnPressed())
            {
                var baseState = WIP.BasePiece.State;
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
            // Erase Panel
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
                    if (GetIfJoinBtnPressed(true) && selected != newSelected)
                    {
                        // Remove old joinings
                        if (WIP.JoinsIndex.ContainsKey(selected))
                        {
                            WIP.RemovePieceJoinings(selected);
                        }
                        JoinPieces(selected, newSelected);
                        (Panel.Controls[0] as JoinsPanel).UnselectBaseBtn();
                    }
                    // Select a new piece
                    else
                    {
                        SelectPiece(newSelected);
                        originalMoving = new int[] { e.X, e.Y };
                        moving = sent;
                    }
                }
                else
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
                movingFar = Math.Abs(originalMoving[0] - e.X) > Consts.DragPrecision
                    || Math.Abs(originalMoving[1] - e.Y) > Consts.DragPrecision;
            }

            // Shadows
            if (movingFar)
            {
                var xChange = sent == 2 ? 0 : e.X - originalMoving[0];
                var yChange = sent == 1 ? 0 : e.Y - originalMoving[1];
                var board = sent == 0 ? DrawBase : sent == 1 ? DrawRight : DrawDown;

                // Move Join
                if (GetIfJoinBtnPressed())
                {
                    var baseState = WIP.BasePiece.State;
                    FindCorrectStates(sent);
                    shadow = new Spot(selectedJoin.CurrentCentre()[0] + xChange, selectedJoin.CurrentCentre()[1] + yChange);
                    WIP.BasePiece.State = baseState;
                }
                // Move Piece
                else
                {
                    FindCorrectStates(sent);
                    for (int index = 0; index < selected.Data.Count; index++)
                    {
                        shadowState = Utils.CloneState(selected.State);
                        shadowState.X += xChange;
                        shadowState.Y += yChange;
                    }
                }
            }
            DisplayDrawings();
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
                                var reversedforBase = Utils.SpinAndSizeCoord(-selectedJoin.B.State.S, 1 / selectedJoin.B.State.SM,
                                    new float[] { x, y });
                                selectedJoin.BXRight = selectedJoin.BX += reversedforBase[0];
                                selectedJoin.BYDown = selectedJoin.BY += reversedforBase[1];
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
            shadow = null;
            shadowState = null;
    }

        /// <summary>
        /// Runs when a key is pressed.
        /// If delete is pressed and a piece is selected, it will be deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void KeyPress(object sender, KeyEventArgs e)
        {
            if (ContainsFocus)
            {
                switch (e.KeyCode)
                {
                    // Delete Selected Piece
                    case Keys.Delete:
                        if (selected == null || GetIfJoinBtnPressed())
                        {
                            return;
                        }
                        WIP.RemovePiece(selected);
                        selected = null;
                        DisplayDrawings();
                        break;

                    // Move Selected Piece
                    case Keys.Up:
                        if (selected != null)
                        {
                            if (WIP.JoinsIndex.ContainsKey(selected))
                            {
                                WIP.JoinsIndex[selected].BYDown = WIP.JoinsIndex[selected].BY -= 1;
                                if (Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
                                {
                                    (Panel.Controls[0] as PositionsPanel).UpdateXYValue(
                                        WIP.JoinsIndex[selected].CurrentStateOfAttached().Y, false);
                                }
                            }
                            else
                            {
                                WIP.PersonalStates[selected].Y -= 1;
                                if (Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
                                {
                                    (Panel.Controls[0] as PositionsPanel).UpdateXYValue(WIP.PersonalStates[selected].Y, false);
                                }
                            }
                            DisplayDrawings();
                        }
                        break;
                    case Keys.Down:
                        if (selected != null)
                        {
                            if (WIP.JoinsIndex.ContainsKey(selected))
                            {
                                WIP.JoinsIndex[selected].BYDown = WIP.JoinsIndex[selected].BY += 1;
                                if (Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
                                {
                                    (Panel.Controls[0] as PositionsPanel).UpdateXYValue(
                                        WIP.JoinsIndex[selected].CurrentStateOfAttached().Y, false);
                                }
                            }
                            else
                            {
                                WIP.PersonalStates[selected].Y += 1;
                                if (Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
                                {
                                    (Panel.Controls[0] as PositionsPanel).UpdateXYValue(WIP.PersonalStates[selected].Y, false);
                                }
                            }
                            DisplayDrawings();
                        }
                        break;
                    case Keys.Left:
                        if (selected != null)
                        {
                            if (WIP.JoinsIndex.ContainsKey(selected))
                            {
                                WIP.JoinsIndex[selected].BXRight = WIP.JoinsIndex[selected].BX -= 1;
                                if (Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
                                {
                                    (Panel.Controls[0] as PositionsPanel).UpdateXYValue(
                                        WIP.JoinsIndex[selected].CurrentStateOfAttached().X, true);
                                }
                            }
                            else
                            {
                                WIP.PersonalStates[selected].X -= 1;
                                if (Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
                                {
                                    (Panel.Controls[0] as PositionsPanel).UpdateXYValue(WIP.PersonalStates[selected].X, true);
                                }
                            }
                            DisplayDrawings();
                        }
                        break;
                    case Keys.Right:
                        if (selected != null)
                        {
                            if (WIP.JoinsIndex.ContainsKey(selected))
                            {
                                WIP.JoinsIndex[selected].BXRight = WIP.JoinsIndex[selected].BX += 1;
                                if (Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
                                {
                                    (Panel.Controls[0] as PositionsPanel).UpdateXYValue(
                                        WIP.JoinsIndex[selected].CurrentStateOfAttached().X, true);
                                }
                            }
                            else
                            {
                                WIP.PersonalStates[selected].X += 1;
                                if (Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
                                {
                                    (Panel.Controls[0] as PositionsPanel).UpdateXYValue(WIP.PersonalStates[selected].X, true);
                                }
                            }
                            DisplayDrawings();
                        }
                        break;

                    // Do nothing for any other key
                    default:
                        break;
                }
            }
        }

        #endregion



        // ----- OTHER FUNCTIONS -----

        /// <summary>
        /// Displays all of the current pieces to the screen.
        /// </summary>
        public void DisplayDrawings()
        {
            using (Graphics og = Graphics.FromImage(original))
            using (Graphics rt = Graphics.FromImage(rotated))
            using (Graphics td = Graphics.FromImage(turned))
            {
                // Draw BGs
                og.FillRectangle(new SolidBrush(GetBoardColor()), new Rectangle(0, 0, DrawBase.Width, DrawBase.Height));
                rt.FillRectangle(new SolidBrush(GetBoardColor()), new Rectangle(0, 0, DrawRight.Width, DrawRight.Height));
                td.FillRectangle(new SolidBrush(GetBoardColor()), new Rectangle(0, 0, DrawDown.Width, DrawDown.Height));

                var boards = new Graphics[3] { og, rt, td };
                CheckSingularBasePiece();
                var baseState = WIP.BasePiece != null ? WIP.BasePiece.State : new State();

                // For Each Angle
                for (int angle = 0; angle < 3; angle++)
                {
                    FindCorrectStates(angle);

                    // Draw Pieces
                    foreach (var piece in GetPiecesInOrder())
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
                        foreach (var joinDraw in joinsDraw)
                        {
                            joinDraw.Key.Draw(joinDraw.Key == selectedJoin ? Consts.select : joinDraw.Value ? Consts.option1 : Consts.option2, boards[angle]);
                        }
                        WIP.BasePiece.State = baseState;
                    }
                }

                // Shadows
                if (movingFar)
                {
                    if (shadow != null)
                    {
                        if (moving == 0)
                        {
                            Visuals.DrawCross(shadow.X, shadow.Y, Consts.shadowShade, og);
                            Visuals.DrawCross(shadow.X, shadow.Y, Consts.shadowShade, rt);
                            Visuals.DrawCross(shadow.X, shadow.Y, Consts.shadowShade, td);
                        }
                        else if (moving == 1)
                        {
                            Visuals.DrawCross(shadow.X, shadow.Y, Consts.shadowShade, rt);
                        }
                        else if (moving == 2)
                        {
                            Visuals.DrawCross(shadow.X, shadow.Y, Consts.shadowShade, td);
                        }
                    }
                    else if (shadowState != null)
                    {
                        if (moving == 0)
                        {
                            selected.Draw(og, shadowState, new ColourState(selected.ColourState, 
                                Consts.shadowShade, new Color[] { Consts.shadowShade }));
                            selected.Draw(rt, shadowState, new ColourState(selected.ColourState,
                                Consts.shadowShade, new Color[] { Consts.shadowShade }));
                            selected.Draw(td, shadowState, new ColourState(selected.ColourState,
                                Consts.shadowShade, new Color[] { Consts.shadowShade }));
                        }
                        else if (moving == 1)
                        {
                            selected.Draw(rt, shadowState, new ColourState(selected.ColourState,
                                Consts.shadowShade, new Color[] { Consts.shadowShade }));
                        }
                        else if (moving == 2)
                        {
                            selected.Draw(td, shadowState, new ColourState(selected.ColourState,
                                Consts.shadowShade, new Color[] { Consts.shadowShade }));
                        }
                    }
                }

                // Draw To Screen
                DrawBase.CreateGraphics().DrawImageUnscaled(original, 0, 0);
                DrawRight.CreateGraphics().DrawImageUnscaled(rotated, 0, 0);
                DrawDown.CreateGraphics().DrawImageUnscaled(turned, 0, 0);
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
            if (Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
            {
                (Panel.Controls[0] as PositionsPanel).EnableControls();
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
            if (Panel.Controls.Count > 0 && Panel.Controls[0] is JoinsPanel)
            {
                (Panel.Controls[0] as JoinsPanel).UnselectButtons();
            }
            else if (Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
            {
                (Panel.Controls[0] as PositionsPanel).EnableControls(false);
            }
        }

        /// <summary>
        /// Checks that all pieces bar one are connected to something.
        /// Also sets the base piece of the set.
        /// </summary>
        /// <returns>True if only one unconnected piece</returns>
        public bool CheckSingularBasePiece()
        {
            WIP.BasePiece = null;
            if (WIP.PiecesList.Count <= 1)
            {
                WarningBtn.Visible = false;
                return false;
            }
            WarningBtn.Visible = true;
            foreach (var piece in WIP.PiecesList)
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
                    WIP.BasePiece = null;
                    return false;
                }
            }
            if (WIP.BasePiece == null)
            {
                return false;
            }
            else
            {
                WIP.PersonalStates[WIP.BasePiece].R = 0;
                WIP.PersonalStates[WIP.BasePiece].T = 0;
                WIP.PersonalStates[WIP.BasePiece].S = 0;
                WarningBtn.Visible = false;
                return true;
            }
        }

        /// <summary>
        /// Finds a sorted list of pieces with extras added on at the end
        /// </summary>
        /// <returns>A sorted list of pieces including those not in the set</returns>
        private List<Piece> GetPiecesInOrder()
        {
            var sorted = WIP.BasePiece != null? WIP.SortOrder() : new List<Piece>();
            foreach (var piece in WIP.PiecesList)
            {
                if (!sorted.Contains(piece))
                {
                    sorted.Add(piece);
                }
            }
            return sorted;
        }

        /// <summary>
        /// Creates a join between two pieces.
        /// </summary>
        /// <param name="a">The attaching piece</param>
        /// <param name="b">The base piece</param>
        private void JoinPieces(Piece a, Piece b)
        {
            var baseState = WIP.JoinsIndex.ContainsKey(b) ?
                WIP.JoinsIndex[b].CurrentStateOfAttached() : WIP.PersonalStates[b];
            WIP.JoinsIndex.Add(a, new Join(a, b, WIP, WIP.PersonalStates[a], baseState));
            WIP.AddToJoinedPieces(a, b);            
            WIP.PersonalStates[a] = new State(0, 0, Utils.Modulo(WIP.PersonalStates[a].R - baseState.R, 360),
                Utils.Modulo(WIP.PersonalStates[a].T - baseState.T, 360),
                Utils.Modulo(WIP.PersonalStates[a].S - baseState.S, 360), 
                WIP.PersonalStates[a].SM / baseState.SM);
        }

        /// <summary>
        /// Finds the correct state of the set based on the required angle
        /// </summary>
        /// <param name="angle">0 original, 1 rotated, 2 turned</param>
        private void FindCorrectStates(int angle = 0)
        {
            // Take current state if flat join in progress
            WIP.CalculateStates(GetIfJoinBtnPressed() ? WIP.BasePiece.State : null, angle);

            // Consider unattached pieces
            if (WIP.JoinsIndex.Count != WIP.PiecesList.Count - 1)
            {
                foreach (var piece in WIP.PiecesList)
                {
                    if (!WIP.JoinsIndex.ContainsKey(piece))
                    {
                        piece.State = Utils.AdjustStateAngle(angle, WIP.PersonalStates[piece]);
                    }
                    else
                    {
                        piece.State = Utils.AdjustStateAngle(angle, 
                            WIP.JoinsIndex[piece].CurrentStateOfAttached());
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
