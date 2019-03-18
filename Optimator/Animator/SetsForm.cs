﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

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

        private Graphics original;
        private Graphics rotated;
        private Graphics turned;

        private int moving = 0;             // 0 = not, 1 = X & Y, 2 = X, 3 = Y
        private bool movingFar = false;     // Whether the piece is being selected or moved
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
            if (Utils.ExitBtn_Click(WIP.PiecesList.Count > 1)) { Close(); }
        }

        /// <summary>
        /// Saves the set and/or closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            if (WIP.PiecesList.Count < 1)
                Close();
            else if (!Utils.CheckValidNewName(NameTb.Text, Consts.SetsFolder))
                return;
            else if (!CheckSingularBasePiece())
                MessageBox.Show("Please connect all pieces but one or remove unconnected pieces.", "Multiple Sets", MessageBoxButtons.OK);
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
                    justAdded.ToPiece().SetCoordsAsMid(DrawBase);
                    justAdded.ToPiece().PieceOf = WIP;
                }
                else
                {
                    justAdded = new Set(AddTb.Text);
                    WIP.PiecesList.AddRange(justAdded.ToSet().PiecesList);
                    justAdded.ToPiece().SetCoordsAsMid(DrawBase);
                    foreach (Piece piece in justAdded.ToSet().PiecesList)
                        piece.PieceOf = WIP;
                }
                SelectPiece(justAdded.ToPiece());

                // If first piece, set as base
                if (WIP.PiecesList.Count == 1)
                    WIP.BasePiece = selected;

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
            if (selected == null)
                return;

            if (SelectBaseBtn.BackColor == unpressed)
            {
                MoveJoinBtn.BackColor = unpressed;
                SelectBaseBtn.BackColor = pressed;
            }
            else
                SelectBaseBtn.BackColor = unpressed;
        }

        /// <summary>
        /// Toggles whether the join is being moved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveJoinBtn_Click(object sender, EventArgs e)
        {
            if (selected == null || selected.AttachedTo == null)
                return;

            if (MoveJoinBtn.BackColor == unpressed)
            {
                SelectBaseBtn.BackColor = unpressed;                
                MoveJoinBtn.BackColor = pressed;
            }
            else
                MoveJoinBtn.BackColor = unpressed;
            DisplayDrawings();
        }

        /// <summary>
        /// Moves the selected piece upwards or downwards in order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpOrDownBtn_Click(object sender, EventArgs e)
        {
            if (selected == null)
                return;

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
            if (selected != null)
            {
                FlipsUpDown.Enabled = FlipsCb.Checked;
                selected.Join.FlipAngle = (FlipsCb.Checked) ? (double)FlipsUpDown.Value : -1;
            }
        }

        /// <summary>
        /// Changes the flip angle of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlipsUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (selected != null)
            {
                selected.Join.FlipAngle = (double)FlipsUpDown.Value;
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
            if (selected == null) { return; }

            if (sender == RotationBar)
                selected.R = RotationBar.Value;
            else if (sender == TurnBar)
                selected.T = TurnBar.Value;
            else if (sender == SpinBar)
                selected.S = SpinBar.Value;
            else if (sender == SizeBar)
                selected.SM = SizeBar.Value;

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
            // Move the Piece's Join            
            if (MoveJoinBtn.BackColor == pressed && Math.Abs(e.X - selected.GetCoords()[0] - selected.Join.X) 
                <= Consts.ClickPrecision && Math.Abs(e.Y - selected.GetCoords()[1] - selected.Join.Y) <= Consts.ClickPrecision)
            {
                originalMoving = new int[] { e.X, e.Y };
                moving = 1;
            }
            else
            {
                // Check if Piece Selected
                int selectedIndex = Utils.FindClickedSelection(WIP.PiecesList, e.X, e.Y, SelectFromTopCb.Checked);
                if (selectedIndex != -1)
                {
                    // Set a new base for the selected piece and adjust coords and join
                    if (SelectBaseBtn.BackColor == pressed && selected != WIP.PiecesList[selectedIndex])
                        selected.AttachToPiece(WIP.PiecesList[selectedIndex]);

                    // Select self as base
                    else if (SelectBaseBtn.BackColor == pressed)
                        selected.Deattach();

                    // Select a new piece
                    else
                    {
                        DeselectPiece();
                        SelectPiece(WIP.PiecesList[selectedIndex]);
                        originalMoving = new int[] { e.X, e.Y };
                        moving = 1;
                    }
                }
                else
                    DeselectPiece();
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
            if (moving != 1)
                return;

            // Invalid Mouse Position
            if (e.X < 0 || e.Y < 0 || e.X > DrawBase.Size.Width || e.Y > DrawBase.Size.Height || selected is null)
                StopMoving();
            // Move Point
            else
            {
                if (!movingFar)
                    movingFar = Math.Abs(selected.X - e.X) > Consts.ClickPrecision
                        || Math.Abs(selected.Y - e.Y) > Consts.ClickPrecision;                
            }
            DisplayDrawings();

            // Shadows
            if (movingFar)
            {
                var xChange = e.X - originalMoving[0];
                var yChange = e.Y - originalMoving[1];
                
                // Move Join
                if (MoveJoinBtn.BackColor == pressed)
                    Visuals.DrawCross(selected.GetCoords()[0] + selected.Join.X + xChange,
                        selected.GetCoords()[1] + selected.Join.Y + yChange, Consts.shadowShade, original);
                // Move Piece
                else
                    for (int index = 0; index < selected.Data.Count; index++)
                    {
                        var X = selected.X; var Y = selected.Y;
                        selected.X += xChange; selected.Y += yChange;
                        selected.Draw(original, new Color[] { Consts.shadowShade, Consts.shadowShade });
                        selected.X = X; selected.Y = Y;
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
            if (moving != 1)
                return;
            if (movingFar)
            {
                var x = e.X - originalMoving[0];
                var y = e.Y - originalMoving[1];
                if (MoveJoinBtn.BackColor == pressed)
                {
                    selected.Join.X += x;
                    selected.Join.Y += y;
                }
                else
                {
                    selected.X += x;
                    selected.Y += y;
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
            moving = 0;
            movingFar = false;
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
            foreach (var piece in WIP.PiecesList)
                if (piece.Join != null)
                    if (angle == "rotated")
                        piece.Join.XRight = piece.Join.X;
                    else
                        piece.Join.YDown = piece.Join.Y;
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
                        return;
                    WIP.PiecesList.Remove(selected);
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

            // Draw To Boards
            WIP.ToPiece().R = 0; WIP.ToPiece().T = 0;
            DrawToBoard(original, 0);
            WIP.ToPiece().R = 89.9999; WIP.ToPiece().T = 0;
            DrawToBoard(rotated, 1);
            WIP.ToPiece().R = 0; WIP.ToPiece().T = 89.9999;
            DrawToBoard(turned, 2);
            WIP.ToPiece().T = 0;
        }

        /// <summary>
        /// Draws the WIP to the selected board including displaying
        /// select colours.
        /// </summary>
        /// <param name="board">The graphics to be display the piece on</param>
        /// <param name="angle">Original (0) rotated (1) turned (2)</param>
        private void DrawToBoard(Graphics board, int angle)
        {
            foreach (Piece piece in WIP.PiecesList)
            {
                if (selected != null && piece == selected && movingFar)
                    piece.Draw(board, new Color[] { Consts.shadowShade });
                else if (selected != null && piece == selected)
                    piece.Draw(board, new Color[] { Consts.select });
                else if (selected != null && piece == selected.AttachedTo)
                    piece.Draw(board, new Color[] { Consts.highlight });
                else
                    piece.Draw(board);              
            }
            if (MoveJoinBtn.BackColor == pressed)
                selected.Join.Draw(angle, Consts.select, board);
        }

        /// <summary>
        /// Selects a piece and updates its outline.
        /// </summary>
        /// <param name="piece"></param>
        private void SelectPiece(Piece piece)
        {
            DeselectPiece();
            selected = piece;
            SelectBaseBtn.Enabled = true;
            if (selected != WIP.BasePiece)
            {
                RotationBar.Enabled = true;
                TurnBar.Enabled = true;
                SpinBar.Enabled = true;
                SizeBar.Enabled = true;
                MoveJoinBtn.Enabled = true;                
                RotationBar.Value = (int)selected.R;
                TurnBar.Value = (int)selected.T;
                SpinBar.Value = (int)selected.S;
                SizeBar.Value = (int)selected.SM;
            }
        }

        /// <summary>
        /// Deselects a piece and returns its outline to original.
        /// </summary>
        private void DeselectPiece()
        {
            if (selected != null)
            {
                selected = null;
                RotationBar.Enabled = false;
                TurnBar.Enabled = false;
                SpinBar.Enabled = false;
                SizeBar.Enabled = false;
                MoveJoinBtn.BackColor = unpressed;
                SelectBaseBtn.BackColor = unpressed;
                MoveJoinBtn.Enabled = false;
                SelectBaseBtn.Enabled = false;
            }
        }

        /// <summary>
        /// Checks that all pieces bar one are connected to something.
        /// Also sets the base piece of the set.
        /// </summary>
        /// <returns>True if only one unconnected piece</returns>
        private bool CheckSingularBasePiece()
        {
            WIP.BasePiece = null;
            foreach(Piece piece in WIP.PiecesList)
            {
                if (piece.AttachedTo == null)
                {
                    if (WIP.BasePiece == null)
                        WIP.BasePiece = piece;
                    else
                        return false;
                }
            }
            return WIP.BasePiece == null ? false: true;
        }
    }
}
