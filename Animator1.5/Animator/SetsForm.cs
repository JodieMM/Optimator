using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace Animator
{
    public partial class SetsForm : Form
    {
        Graphics g;
        List<Piece> piecesList = new List<Piece>();

        const string tempSet = "tempSet";
        const string folder = "\\Sets\\";
        const string pointsFolder = "\\Points\\";
        const string defaultName = "Item Name";


        public SetsForm()
        {
            InitializeComponent();
        }


        private void DoneBtn_Click(object sender, EventArgs e)
        {
            if (piecesList.Count > 0)
            {
                Boolean doEet = true;
                Boolean exit = false;

                // Check file name does not already exist/ name has been entered
                if (NameTb.Text == defaultName || NameTb.Text == "")
                {
                    doEet = false;
                    MessageBox.Show("Please choose a name for your set", "Name Invalid", MessageBoxButtons.OK);
                }
                else if (File.Exists(Environment.CurrentDirectory + folder + NameTb.Text + ".txt"))
                {
                    DialogResult result = MessageBox.Show("This name is already in use. Do you wish to overwrite it?", "Overwrite Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        doEet = false;
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to save this set?", "Save Confirmation", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.No) { doEet = false; exit = true; }
                }

                // Save Piece
                if (doEet)
                {
                    // Save
                    Utilities.SaveData(Environment.CurrentDirectory + folder + NameTb.Text + ".txt", GetSaveData());

                    // Close Pieces Form
                    this.Close();
                }
                else if (exit)
                {
                    DialogResult query = MessageBox.Show("Do you wish to exit without saving?", "Exit Confirmation", MessageBoxButtons.YesNo);
                    if (query == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("No base assigned", "Save Error", MessageBoxButtons.OK);
            }
        }


        private void addBtn_Click(object sender, EventArgs e)
        {
            if (PermitChange())
            {
                try
                {
                    piecesList.Add(new Piece(addTb.Text));
                    partsLb.Items.Add(addTb.Text);
                    partsLb.SelectedIndex = partsLb.Items.Count - 1;
                    DrawParts();
                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Suspected outdated file.", "File Indexing Error", MessageBoxButtons.OK);
                }
            }
        }

        private void DrawParts()
        {
            // Prepare
            DrawPanel.Refresh();
            g = this.DrawPanel.CreateGraphics();

            Utilities.DrawPieces(piecesList, g);
        }

        private void partsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                if (!PermitChange() && partsLb.SelectedIndex != partsLb.Items.Count - 1)
                {
                    partsLb.SelectedIndex = partsLb.Items.Count - 1;
                    MessageBox.Show("You must attach this piece to something, or delete it, to continue.", "Detached Piece", MessageBoxButtons.OK);
                    return;
                }

                // Enable/Disable points
                SelectionChange();

                Piece highlightedPiece = piecesList[partsLb.SelectedIndex];

                // Assign Values to Match

                // Textboxes
                if (highlightedPiece.GetIsAttached())
                {
                    basePointTb.Text = highlightedPiece.GetAttachPoint().GetName();
                    joinPointTb.Text = highlightedPiece.GetOwnPoint().GetName();
                }

                // InitUpDowns
                xInitUpDown.Value = (decimal)highlightedPiece.x;
                yInitUpDown.Value = (decimal)highlightedPiece.y;
                rotInitUpDown.Value = (decimal)highlightedPiece.rotation;
                turnInitUpDown.Value = (decimal)highlightedPiece.turn;
                spinInitUpDown.Value = (decimal)highlightedPiece.spin;
                sizeInitUpDown.Value = (decimal)highlightedPiece.sizeMod;
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

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1 && partsLb.SelectedIndex != 0)
            {
                int selectedIndex = partsLb.SelectedIndex;
                piecesList.RemoveAt(partsLb.SelectedIndex);
                partsLb.Items.RemoveAt(partsLb.SelectedIndex);
                DrawParts();
            }
        }

        private void SelectionChange()
        {
            if (partsLb.SelectedIndex != -1 && partsLb.SelectedIndex == 0)
            {
                // Disable Everything
                basePointTb.Enabled = false;
                joinPointTb.Enabled = false;
                loadPointsBtn.Enabled = false;
                label1.ForeColor = Color.DimGray;
                label2.ForeColor = Color.DimGray;
            }
            else
            {
                // Enable Everything
                basePointTb.Enabled = true;
                joinPointTb.Enabled = true;
                loadPointsBtn.Enabled = true;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
            }
        }

        private void loadPointsBtn_Click(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1 && basePointTb.Text != "" && joinPointTb.Text != "")    // ** TO DO && basePieceIndex != -1
            {
                try
                {
                    piecesList[partsLb.SelectedIndex].AttachToPiece(piecesList[0], new Piece(basePointTb.Text, pointsFolder), new Piece(joinPointTb.Text, pointsFolder));
                    DrawParts();
                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file names and try again.", "File Not Found", MessageBoxButtons.OK);
                }
            }
        }


        private void xInitUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                piecesList[partsLb.SelectedIndex].SetX((double)xInitUpDown.Value);
                DrawParts();
            }
        }

        private void yInitUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                piecesList[partsLb.SelectedIndex].SetY((double)yInitUpDown.Value);
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
                piecesList[partsLb.SelectedIndex].SetSizeMod((double)sizeInitUpDown.Value);
                DrawParts();
            }
        }


        private void addSetBtn_Click(object sender, EventArgs e)
        {
            if (PermitChange())
            {
                try
                {
                    Set addedSet = new Set(addTb.Text);
                    piecesList.AddRange(addedSet.GetPiecesList());

                    // Update listbox
                    List<Piece> addedPieces = addedSet.GetPiecesList();
                    foreach (Piece added in addedPieces)
                    {
                        partsLb.Items.Add(added.GetName());
                    }

                    DrawParts();

                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Suspected outdated file.", "File Indexing Error", MessageBoxButtons.OK);
                }
            }
        }

        private Boolean PermitChange()
        {
            if (piecesList.Count > 1 && (piecesList[piecesList.Count -1].GetAttachPoint() == null || piecesList[piecesList.Count - 1].GetOwnPoint() == null))
            {
                return false;
            }
            return true;
        }

        private List<string> GetSaveData()
        {
            List<string> returnData = new List<string>();
            for (int index = 0; index < piecesList.Count; index++)
            {
                string pieceData = piecesList[index].GetName() + ";";

                if (index != 0)
                {
                    // ** TO DO REPLACE GetAttachedTo with its index!!
                    int attachedIndex = piecesList.IndexOf(piecesList[index].GetAttachedTo());
                    if (attachedIndex == -1)
                    {
                        attachedIndex = 0;
                    }
                    pieceData += piecesList[index].GetOwnPoint().GetName() + ";" + attachedIndex + ";" + piecesList[index].GetAttachPoint().GetName() + ";";
                }

                pieceData += piecesList[index].GetCoords()[0] + ";" + piecesList[index].GetCoords()[1] + ";";
                pieceData += piecesList[index].GetAngles()[0] + ";" + piecesList[index].GetAngles()[1] + ";" + piecesList[index].GetAngles()[2] + ";";
                pieceData += piecesList[index].GetSizeMod();

                returnData.Add(pieceData);
            }
            // TO DO **

            return returnData;
        }


    }
}
