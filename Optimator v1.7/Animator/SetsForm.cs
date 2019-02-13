using System;
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
        private Set WIP = new Set();        //TODO: Add preview button and a save that records the new joins
        private Piece selected = null;
        private Color selectedOC;

        private Graphics original;
        private Graphics rotated;
        private Graphics turned;

        private int moving = 0;             // 0 = not, 1 = X & Y, 2 = X, 3 = Y
        private bool movingFar = false;     // Whether the piece is being selected or moved
        private int[] originalMoving = new int[] { 0, 0 };
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
        }



        // ----- OPTION BUTTONS -----

        /// <summary>
        /// Sets the selected piece as base piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetBasePiece_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                WIP.BasePiece = selected;
                SetBasePiece.Enabled = false;
            }
        }

        /// <summary>
        /// Displays a preview of the set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            CompleteSet();
            PreviewForm previewForm = new PreviewForm(WIP);
            previewForm.Show();
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Yes;
            if (WIP.PiecesList.Count > 1)
            {
                result = MessageBox.Show("Do you want to exit without saving? Your set will be lost.", "Exit Confirmation", MessageBoxButtons.YesNo);
            }
            if (result == DialogResult.Yes)
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
            else if (!Constants.PermittedName.IsMatch(NameTb.Text))
            {
                MessageBox.Show("Please choose a valid name for your set. Name can only include letters and numbers.", "Name Invalid", MessageBoxButtons.OK);
            }
            // Name is valid
            else
            {
                // Check name not already in use, or that overriding is okay
                if (File.Exists(Utilities.GetDirectory(Constants.SetsFolder, NameTb.Text, Constants.Txt)))
                {
                    DialogResult result = MessageBox.Show("This name is already in use. Do you want to override the existing set?", "Override Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) { return; }
                }

                // Save Set and Close Form
                try
                {
                    Utilities.SaveData(Utilities.GetDirectory(Constants.SetsFolder, NameTb.Text, Constants.Txt), WIP.GetData());
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

        /// <summary>
        /// Adds a piece to the set.
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
                    justAdded.ToPiece().X = DrawBase.Width / 2.0; justAdded.ToPiece().Y = DrawBase.Height / 2.0;
                    justAdded.ToPiece().PieceOf = WIP;
                }
                else
                {
                    justAdded = new Set(AddTb.Text);
                    WIP.PiecesList.AddRange(justAdded.ToSet().PiecesList);
                    justAdded.ToPiece().X = DrawBase.Width / 2.0; justAdded.ToPiece().Y = DrawBase.Height / 2.0;
                    foreach (Piece piece in justAdded.ToSet().PiecesList)
                    {
                        piece.PieceOf = WIP;
                    }
                }
                SelectPiece(justAdded.ToPiece());

                // If first piece, set as base
                if (WIP.PiecesList.Count == 1)
                {
                    WIP.BasePiece = selected;
                    SetBasePiece.Enabled = false;
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



        // ----- PIECES TAB -----
        #region Pieces Tab

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
            {
                selected.R = RotationBar.Value;
            }
            else if (sender == TurnBar)
            {
                selected.T = TurnBar.Value;
            }
            else if (sender == SpinBar)
            {
                selected.S = SpinBar.Value;
            }
            else if (sender == SizeBar)
            {
                selected.SM = SizeBar.Value;
            }
            DisplayDrawings();
        }
        
        /// <summary>
        /// Moves the selected piece upwards in order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpBtn_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                int selectedIndex = WIP.PiecesList.IndexOf(selected);
                if (selectedIndex != -1 && selectedIndex < WIP.PiecesList.Count - 1)
                {
                    Piece holding = WIP.PiecesList[selectedIndex];
                    WIP.PiecesList[selectedIndex] = WIP.PiecesList[selectedIndex + 1];
                    WIP.PiecesList[selectedIndex + 1] = holding;
                    DisplayDrawings();
                }
            }
        }

        /// <summary>
        /// Moves the selected piece down in order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownBtn_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                int selectedIndex = WIP.PiecesList.IndexOf(selected);
                if (selectedIndex > 0)
                {
                    Piece holding = WIP.PiecesList[selectedIndex];
                    WIP.PiecesList[selectedIndex] = WIP.PiecesList[selectedIndex - 1];
                    WIP.PiecesList[selectedIndex - 1] = holding;
                    DisplayDrawings();
                }
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
                selected.AngleFlip = (FlipsCb.Checked) ? (double)FlipsUpDown.Value : -1;
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
                selected.AngleFlip = (double)FlipsUpDown.Value;
            }
        }

        #endregion



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



        // ----- DRAW PANEL I/O -----
        #region Draw Panel I/O

        /// <summary>
        /// Starts click preparation, checking for a click or drag.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBase_MouseDown(object sender, MouseEventArgs e)
        {
            // Choose and Update Selected Piece (If Any)
            DeselectPiece();
            int selectedIndex = Utilities.FindClickedSelection(WIP.PiecesList, e.X, e.Y, SelectFromTopCb.Checked);
            if (selectedIndex != -1)
            {
                SelectPiece(WIP.PiecesList[selectedIndex]);
                originalMoving = new int[] { e.X, e.Y };
                moving = (sender == DrawBase) ? 1 : (sender == DrawRight) ? 2 : 3;
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
            int movingCheck = (sender == DrawBase) ? 1 : (sender == DrawRight) ? 2 : 3;
            if (moving != movingCheck) { return; }

            // Invalid Mouse Position
            if (e.X < 0 || e.Y < 0 || e.X > DrawBase.Size.Width || e.Y > DrawBase.Size.Height)
            {
                StopMoving();
            }
            // Move Point
            else
            {
                if (!movingFar)
                {
                    movingFar = Math.Abs(selected.X - e.X) > Constants.ClickPrecision
                        || Math.Abs(selected.Y - e.Y) > Constants.ClickPrecision;
                }
                // TODO: Fix!
                //if (movingFar)
                //{
                //    Piece shadow = new Piece();
                //    shadow.Data.Add(selected.Data[selected.FindRow()]);
                //    shadow.FillColour = new Color[] { Constants.shadowShade };
                //    shadow.OutlineColour = Constants.invisible;
                //    shadow.X = e.X; shadow.Y = e.Y;
                //    shadow.Draw(original);
                //}
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Updates the user interface for the selected piece and stops
        /// the movement search, actioning it if necessary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBase_MouseUp(object sender, MouseEventArgs e)
        {
            int movingCheck = (sender == DrawBase) ? 1 : (sender == DrawRight) ? 2 : 3;
            if (moving != movingCheck) { return; }
            if (movingFar)
            {
                // TODO: Fix!
                selected.X += e.X - originalMoving[0];
                selected.Y += e.Y - originalMoving[1];
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
                    if (selected == null) { return; }
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
        /// Displays all of the current piecesvto the screen.
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

            // Draw Base Board
            WIP.ToPiece().R = 0;
            WIP.ToPiece().T = 0;
            foreach (Piece piece in WIP.PiecesList)
            {
                piece.Draw(original);
            }

            // Draw Rotated Board
            WIP.ToPiece().R = 89.9999;
            WIP.ToPiece().T = 0;
            foreach (Piece piece in WIP.PiecesList)
            {
                piece.Draw(rotated);
            }

            // Draw Turned Board
            WIP.ToPiece().R = 0;
            WIP.ToPiece().T = 89.9999;
            foreach (Piece piece in WIP.PiecesList)
            {
                piece.Draw(turned);
            }
            WIP.ToPiece().T = 0;
        }

        /// <summary>
        /// Selects a piece and updates its outline.
        /// </summary>
        /// <param name="piece"></param>
        private void SelectPiece(Piece piece)
        {
            DeselectPiece();
            selected = piece;
            selectedOC = selected.OutlineColour;
            selected.OutlineColour = Constants.select;
            RotationBar.Enabled = true;
            TurnBar.Enabled = true;
            SpinBar.Enabled = true;
            SizeBar.Enabled = true;
            RotationBar.Value = (int)selected.R;
            TurnBar.Value = (int)selected.T;
            SpinBar.Value = (int)selected.S;
            SizeBar.Value = (int)selected.SM;
            SetBasePiece.Enabled = (WIP.BasePiece != selected);
        }

        /// <summary>
        /// Deselects a piece and returns its outline to original.
        /// </summary>
        private void DeselectPiece()
        {
            if (selected != null)
            {
                selected.OutlineColour = selectedOC;
                selected = null;
                RotationBar.Enabled = false;
                TurnBar.Enabled = false;
                SpinBar.Enabled = false;
                SizeBar.Enabled = false;
                SetBasePiece.Enabled = false;
            }
        }

        /// <summary>
        /// Adds joins to the set 
        /// </summary>
        /// <returns></returns>
        private void CompleteSet()
        {
            // TODO: Enter!
        }
    }
}
