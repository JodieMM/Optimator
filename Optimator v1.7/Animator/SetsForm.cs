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
        #endregion


        /// <summary>
        /// SetsForm constructor.
        /// </summary>
        public SetsForm()
        {
            InitializeComponent();
        }



        // ----- SET BUTTONS -----

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
                // Save Set and Close Form
                if (result == DialogResult.Yes)
                {
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
        /// Deletes a piece or set from the WIP set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            //piecesList.RemoveAt(partsLb.SelectedIndex);
            Utilities.DrawPieces(piecesList, g, DrawPanel);
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



        // ----- SETTINGS BUTTONS -----
        // **TO DO 



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
            for (int index = 0; index < piecesList.Count; index++)
            {
                string pieceData = piecesList[index].Name + ";";

                if (index != 0)
                {
                    pieceData += piecesList[index].OwnPoint.Name + ";" + piecesList.IndexOf(piecesList[index].AttachedTo)
                        + ";" + piecesList[index].AttachPoint.Name + ";"; 
                }

                //Save actual x, y, r, t, s and sm values
                double[] realData = new double[] {piecesList[index].X, piecesList[index].Y, piecesList[index].R,
                    piecesList[index].T, piecesList[index].S, piecesList[index].SM };
                pieceData += realData[0] + ";" + realData[1] + ";" + realData[2] + ";" + realData[3] 
                    + ";" + realData[4] + ";" + realData[5];

                // Save flip values
                if (index != 0)
                {
                    pieceData += ";" + piecesList[index].InFront + ";" + piecesList[index].AngleFlip;
                }

                returnData.Add(pieceData);
            }
            return returnData;
        }



        // ----- TO UPDATE -----
        #region To Update
        /*
        private void partsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                // Enable/Disable points
                SelectionChange();

                Piece highlightedPiece = piecesList[partsLb.SelectedIndex];

                // Assign Values to Match

                // Textboxes
                if (highlightedPiece.GetIsAttached())
                {
                    basePointTb.Text = highlightedPiece.AttachPoint.Name;
                    joinPointTb.Text = highlightedPiece.OwnPoint.Name;
                    basePieceTb.Text = piecesList.IndexOf(highlightedPiece.AttachedTo).ToString();
                }
                else
                {
                    basePointTb.Text = "Point";
                    joinPointTb.Text = "Point";
                    basePieceTb.Text = "Index";
                }

                // InitUpDowns
                xInitUpDown.Value = (decimal)highlightedPiece.X;
                yInitUpDown.Value = (decimal)highlightedPiece.Y;
                rotInitUpDown.Value = (decimal)highlightedPiece.R;
                turnInitUpDown.Value = (decimal)highlightedPiece.T;
                spinInitUpDown.Value = (decimal)highlightedPiece.S;
                sizeInitUpDown.Value = (decimal)highlightedPiece.SM;
            }

            try
            {
                DrawParts();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Suspected outdated file.", "File Indexing Error", MessageBoxButtons.OK);
            }
        }

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
