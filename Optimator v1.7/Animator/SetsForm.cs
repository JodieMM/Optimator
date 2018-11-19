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
        #endregion


        /// <summary>
        /// SetsForm constructor.
        /// </summary>
        public SetsForm()
        {
            InitializeComponent();
            DrawPanel.KeyDown += KeyPress;
            DrawPanel.MouseDown += new MouseEventHandler(DrawPanel_MouseDown);
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
                selected = justAdded;
                selectedOC = selected.OutlineColour;
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
                selected = addedSet.BasePiece;
                selectedOC = selected.OutlineColour;
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
            // Only ask if there is something to save
            if (piecesList.Count > 0)
            {
                result = MessageBox.Show("Do you want to exit without saving? Your set will be lost.", "Exit Confirmation", MessageBoxButtons.YesNo);
            }
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }



        // ----- SETTINGS TAB -----



        // ----- DRAW PANEL I/O -----

        /// <summary>
        /// Selects a piece if it is clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // Update old selected outline
            if (selected != null) { selected.OutlineColour = selectedOC; }

            // Choose and Update Selected Piece (If Any)
            int selectedIndex = Utilities.FindClickedSelection(piecesList, e.X, e.Y);
            if (selectedIndex == -1) { return; }
            selected = piecesList[selectedIndex];
            selectedOC = selected.OutlineColour;
            selected.OutlineColour = Color.Red;

            // Update UI
            /*RotationUpDown.Value = (decimal)selected.R;
            TurnUpDown.Value = (decimal)selected.T;
            SpinUpDown.Value = (decimal)selected.S;
            XUpDown.Value = (decimal)selected.X;
            YUpDown.Value = (decimal)selected.Y;
            SizeUpDown.Value = (decimal)selected.SM;*/

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



        // ----- OTHER FUNCTIONS -----

        /// <summary>
        /// Checks that all added pieces are connected to the set.
        /// Shows relevant warning message.
        /// </summary>
        /// <returns></returns>
        private bool PermitChange()
        {
            bool permitted = true;
            
            for (int index = 1; index < piecesList.Count && permitted; index++)
            {
                if (!piecesList[index].GetIsAttached())
                {
                    // ** TO DO SWITCH TO THIS PIECE
                    permitted = false;
                    MessageBox.Show("You must attach this piece to something, or delete it, to save the set.", "Detached Piece", MessageBoxButtons.OK);
                }
            }
            return permitted;
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
        }

        private void xInitUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                piecesList[partsLb.SelectedIndex].X = (double)xInitUpDown.Value;
                DrawParts();
            }
        }

        private void yInitUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                piecesList[partsLb.SelectedIndex].Y = (double)yInitUpDown.Value;
                DrawParts();
            }
        }

        private void rotInitUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (rotInitUpDown.Value == 360) { rotInitUpDown.Value = 0; }
            if (rotInitUpDown.Value == -1) { rotInitUpDown.Value = 359; }

            if (partsLb.SelectedIndex != -1)
            {
                piecesList[partsLb.SelectedIndex].SetRotation((double)rotInitUpDown.Value);
                DrawParts();
            }
        }

        private void turnInitUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (turnInitUpDown.Value == 360) { turnInitUpDown.Value = 0; }
            if (turnInitUpDown.Value == -1) { turnInitUpDown.Value = 359; }

            if (partsLb.SelectedIndex != -1)
            {
                piecesList[partsLb.SelectedIndex].SetTurn((double)turnInitUpDown.Value);
                DrawParts();
            }
        }

        private void spinInitUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (spinInitUpDown.Value == 360) { spinInitUpDown.Value = 0; }
            if (spinInitUpDown.Value == -1) { spinInitUpDown.Value = 359; }

            if (partsLb.SelectedIndex != -1)
            {
                piecesList[partsLb.SelectedIndex].SetSpin((double)spinInitUpDown.Value);
                DrawParts();
            }
        }

        private void sizeInitUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                piecesList[partsLb.SelectedIndex].SM = (double)sizeInitUpDown.Value;
                DrawParts();
            }
        }*/
        #endregion
    }
}
