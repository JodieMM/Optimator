using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        private Graphics g;
        private List<Piece> piecesList = new List<Piece>();
        private Set WIP = new Set(Constants.SetStructure);

        private Piece selected = null;
        private Color selectedOC;
        private Piece shadow = null;
        private bool moving = false;
        private bool movingFar = false;
        private int[] originalMoving;
        private int[] positionMoving;
        #endregion


        /// <summary>
        /// SetsForm constructor.
        /// </summary>
        public SetsForm()
        {
            InitializeComponent();
            DrawPanel.KeyDown += KeyPress;
            DrawPanel.MouseDown += new MouseEventHandler(DrawPanel_MouseDown);
            DrawPanel.MouseMove += new MouseEventHandler(DrawPanel_MouseMove);
            DrawPanel.MouseUp += new MouseEventHandler(DrawPanel_MouseUp);
        }



        // ----- SET TAB -----

        /// <summary>
        /// Saves the set and/or closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoneBtn_Click(object sender, EventArgs e)
        {
            if (piecesList.Count < 1)
            {
                Close();
            }
            else if (!PermitChange())
            {
                // Error message shown as part of PermitChange function
            }
            else if (Constants.InvalidNames.Contains(NameTb.Text) || !Constants.PermittedName.IsMatch(NameTb.Text))
            {
                MessageBox.Show("Please choose a valid name for your set. Name can only include letters and numbers.", "Name Invalid", MessageBoxButtons.OK);
            }
            else if (Constants.ReservedNames.Contains(NameTb.Text))
            {
                MessageBox.Show("This name is reserved. Please choose a new name for your set.", "Name Reserved", MessageBoxButtons.OK);
            }
            // Name is valid
            else
            {
                // Check name not already in use, or that overriding is okay
                DialogResult result = DialogResult.Yes;
                if (File.Exists(Utilities.GetDirectory(Constants.SetsFolder, NameTb.Text)))
                {
                    result = MessageBox.Show("This name is already in use. Do you want to override the existing set?", "Override Confirmation", MessageBoxButtons.YesNo);
                }
                if (result == DialogResult.No) { return; }

                // Save Set and Close Form
                try
                {
                    WIP.CreateData();
                    Utilities.SaveData(Utilities.GetDirectory(Constants.SetsFolder, NameTb.Text), WIP.Data);
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

        /// <summary>
        /// Adds a piece to the set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPieceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Piece justAdded = new Piece(AddTb.Text);
                piecesList.Add(justAdded);
                justAdded.X = Constants.MidX; justAdded.Y = Constants.MidY;
                justAdded.FindPointSpots();
                SelectPiece(justAdded);
                Utilities.DrawPieces(piecesList, g, DrawPanel);
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
        /// Adds a set to the set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Set addedSet = new Set(AddTb.Text);
                piecesList.AddRange(addedSet.PiecesList);
                foreach (Piece piece in addedSet.PiecesList)
                {
                    piece.FindPointSpots();
                }
                SelectPiece(addedSet.BasePiece);
                Utilities.DrawPieces(piecesList, g, DrawPanel);
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
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Yes;
            if (piecesList.Count > 1)
            {
                result = MessageBox.Show("Do you want to exit without saving? Your set will be lost.", "Exit Confirmation", MessageBoxButtons.YesNo);
            }
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }



        // ----- PIECES TAB -----

        /// <summary>
        /// Updates the original rotation of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotationBar_Scroll(object sender, EventArgs e)
        {
            if (selected == null) { return; }
            selected.R = RotationBar.Value;
            Utilities.DrawPieces(piecesList, g, DrawPanel);
        }

        /// <summary>
        /// Updates the original turn of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TurnBar_Scroll(object sender, EventArgs e)
        {
            if (selected == null) { return; }
            selected.T = TurnBar.Value;
            Utilities.DrawPieces(piecesList, g, DrawPanel);
        }

        /// <summary>
        /// Updates the original spin of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpinBar_Scroll(object sender, EventArgs e)
        {
            if (selected == null) { return; }
            selected.S = SpinBar.Value;
            Utilities.DrawPieces(piecesList, g, DrawPanel);
        }

        /// <summary>
        /// Updates the original size of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SizeBar_Scroll(object sender, EventArgs e)
        {
            if (selected == null) { return; }
            selected.SM = SizeBar.Value;
            Utilities.DrawPieces(piecesList, g, DrawPanel);
        }



        // ----- DRAW PANEL I/O -----
        #region Draw Panel I/O

        /// <summary>
        /// Starts click preparation, checking for a click or drag.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // Choose and Update Selected Piece (If Any)
            DeselectPiece();
            int selectedIndex = Utilities.FindClickedSelection(piecesList, e.X, e.Y);
            if (selectedIndex != -1)
            {
                SelectPiece(piecesList[selectedIndex]);
                moving = true;
                originalMoving = new int[] { e.X, e.Y };
            }

            Utilities.DrawPieces(piecesList, g, DrawPanel);
        }

        /// <summary>
        /// Checks if a piece is being moved or just clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!moving) { return; }
            if (e.X < 0 || e.Y < 0 || e.X > DrawPanel.Size.Width || e.Y > DrawPanel.Size.Height)
            {
                moving = false; movingFar = false;
            }
            else
            {
                positionMoving = new int[] { e.X, e.Y };
                if (!movingFar)
                {
                    movingFar = Math.Abs(originalMoving[0] - positionMoving[0]) > Constants.ClickPrecision
                        || Math.Abs(originalMoving[1] - positionMoving[1]) > Constants.ClickPrecision;
                    if (movingFar)
                    {
                        shadow = new Piece(selected.Name)
                        {
                            R = selected.GetAngles()[0],
                            T = selected.GetAngles()[1],
                            S = selected.GetAngles()[2],
                            SM = selected.GetSizeMod(),
                            FillColour = new Color[] { Color.FromArgb(155, 163, 163, 194) },
                            OutlineWidth = 0
                        };
                    }
                }
            }
            g = DrawPanel.CreateGraphics();
            Utilities.DrawPieces(piecesList, g, DrawPanel);
            if (movingFar)
            {
                shadow.X = selected.GetCoords()[0] + positionMoving[0] - originalMoving[0];
                shadow.Y = selected.GetCoords()[1] + positionMoving[1] - originalMoving[1];
                Utilities.DrawPiece(shadow, g, true);
            }
        }

        /// <summary>
        /// Updates the user interface for the selected piece and stops
        /// the movement search, actioning it if necessary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (!moving) { return; }
            if (movingFar)
            {
                selected.X += positionMoving[0] - originalMoving[0];
                selected.Y += positionMoving[1] - originalMoving[1];
            }

            // Update UI
            RotationBar.Value = (int)selected.R;
            TurnBar.Value = (int)selected.T;
            SpinBar.Value = (int)selected.S;
            SizeBar.Value = (int)selected.SM;

            moving = false; movingFar = false;
            Utilities.DrawPieces(piecesList, g, DrawPanel);
        }

        /// <summary>
        /// Runs when a key is pressed.
        /// If delete is pressed and a piece is selected, it will be deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void KeyPress(object sender, KeyEventArgs e)
        {
            // Delete selected piece
            if (e.KeyCode == Keys.Delete)
            {
                if (selected == null) { return; }
                piecesList.Remove(selected);
                selected = null;
                Utilities.DrawPieces(piecesList, g, DrawPanel);
            }
        }

        /// <summary>
        /// Rotates the set on the DrawPanel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotationTrack_Scroll(object sender, EventArgs e)
        {
            foreach (Piece piece in piecesList)
            {
                if (piece.AttachedTo == null)
                {
                    piece.R += RotationTrack.Value;
                    Utilities.DrawPieces(piecesList, g, DrawPanel);
                    return;
                }
            }
        }

        /// <summary>
        /// Turns the set on the DrawPanel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TurnTrack_Scroll(object sender, EventArgs e)
        {
            foreach (Piece piece in piecesList)
            {
                if (piece.AttachedTo == null)
                {
                    piece.T += TurnTrack.Value;
                    Utilities.DrawPieces(piecesList, g, DrawPanel);
                    return;
                }
            }
        }

        #endregion



        // ----- OTHER FUNCTIONS -----

        /// <summary>
        /// Checks that all added pieces are connected to the set.
        /// Shows relevant warning message.
        /// </summary>
        /// <returns></returns>
        private bool PermitChange()
        {
            int count = 0;
            foreach (Piece piece in piecesList)
            {
                if (piece.GetIsAttached())
                {
                    count++;
                    if (count > 1)
                    {
                        selected = piece;
                        MessageBox.Show("You must attach this piece to something, or delete it, to save the set.", "Detached Piece", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Converts the set into string data for saving.
        /// </summary>
        /// <returns></returns>
        private List<string> GetSaveData()
        {
            List<string> returnData = new List<string>();
            foreach (Piece piece in piecesList)
            {
                bool notBase = WIP.BasePiece != piece;
                string pieceData = piece.Name + ";";

                if (notBase)
                {
                    pieceData += piece.OwnPoint.Name + ";" + piecesList.IndexOf(piece.AttachedTo)
                        + ";" + piece.AttachPoint.Name + ";";
                }

                // Save Piece Attributes
                pieceData += piece.X + ";" + piece.Y + ";" + piece.R + ";" + piece.T + ";" + piece.S + ";" + piece.SM;

                // Save flip values
                if (notBase)
                {
                    pieceData += ";" + piece.InFront + ";" + piece.AngleFlip;
                }
                returnData.Add(pieceData);
            }
            return returnData;
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
            selected.OutlineColour = Color.Red;
            RotationBar.Enabled = true;
            TurnBar.Enabled = true;
            SpinBar.Enabled = true;
            SizeBar.Enabled = true;
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
            }
        }




        // ----- TO UPDATE -----
        #region To Update
        /*
        private void loadPointsBtn_Click(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1 && basePointTb.Text != "" && joinPointTb.Text != "" && basePieceTb.Text != "-1")
            {
                try
                {
                    Boolean front = partsLb.SelectedIndex > int.Parse(basePieceTb.Text);
                    double flip = flipsCb.Checked ? (double)flipsUpDown.Value : -1;

                    piecesList[partsLb.SelectedIndex].AttachToPiece(piecesList[int.Parse(basePieceTb.Text)], new PointSpot(basePointTb.Text, piecesList[int.Parse(basePieceTb.Text)]),
                        new PointSpot(joinPointTb.Text, piecesList[partsLb.SelectedIndex]), front, flip);

                    xInitUpDown.Value = 0;
                    yInitUpDown.Value = 0;

                    DrawParts();
                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file names and try again.", "File Not Found", MessageBoxButtons.OK);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Index entered does not relate to any existing piece", "Invalid Index", MessageBoxButtons.OK);
                }
            }
        }*/
        #endregion
    }
}
