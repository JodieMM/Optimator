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
                    if (result == DialogResult.No) { doEet = false; }
                }
                else if (!PermitChange()) { doEet = false; }
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
                this.Close();
            }
        }


        private void addBtn_Click(object sender, EventArgs e)
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
                // Enable/Disable points
                SelectionChange();

                Piece highlightedPiece = piecesList[partsLb.SelectedIndex];

                // Assign Values to Match

                // Textboxes
                if (highlightedPiece.GetIsAttached())
                {
                    basePointTb.Text = highlightedPiece.GetAttachPoint().GetName();
                    joinPointTb.Text = highlightedPiece.GetOwnPoint().GetName();
                    basePieceTb.Text = piecesList.IndexOf(highlightedPiece.GetAttachedTo()).ToString();
                }
                else
                {
                    basePointTb.Text = "Point";
                    joinPointTb.Text = "Point";
                    basePieceTb.Text = "Index";
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
                int selectedIndex = partsLb.SelectedIndex;      // Must be 1 or greater
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
                basePieceTb.Enabled = false;
                label1.ForeColor = Color.DimGray;
                label2.ForeColor = Color.DimGray;
                label10.ForeColor = Color.DimGray;
            }
            else
            {
                // Enable Everything
                basePointTb.Enabled = true;
                joinPointTb.Enabled = true;
                loadPointsBtn.Enabled = true;
                basePieceTb.Enabled = true;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label10.ForeColor = Color.Black;
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
  
                    piecesList[partsLb.SelectedIndex].AttachToPiece(piecesList[int.Parse(basePieceTb.Text)], new Piece(basePointTb.Text, pointsFolder), 
                        new Piece(joinPointTb.Text, pointsFolder), front, flip);

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
            try
            {
                Set addedSet = new Set(addTb.Text);
                List<Piece> addedPieces = addedSet.GetPiecesList();
                piecesList.AddRange(addedPieces);

                // Update listbox
                foreach (Piece added in addedPieces)
                {
                    partsLb.Items.Add(added.GetName());
                }

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

        private Boolean PermitChange()
        {
            Boolean permitted = true;
            
            for (int index = 1; index < piecesList.Count && permitted; index++)
            {
                if (!piecesList[index].GetIsAttached())
                {
                    permitted = false;
                    partsLb.SelectedIndex = index;
                    MessageBox.Show("You must attach this piece to something, or delete it, to save the set.", "Detached Piece", MessageBoxButtons.OK);
                }
            }
            return permitted;
        }

        private List<string> GetSaveData()
        {
            List<string> returnData = new List<string>();
            for (int index = 0; index < piecesList.Count; index++)
            {
                string pieceData = piecesList[index].GetName() + ";";

                if (index != 0)
                {
                    pieceData += piecesList[index].GetOwnPoint().GetName() + ";" + piecesList.IndexOf(piecesList[index].GetAttachedTo())
                        + ";" + piecesList[index].GetAttachPoint().GetName() + ";"; 
                }

                //Save actual x, y, r, t, s and sm values
                double[] realData = piecesList[index].GetActualValues();
                pieceData += realData[0] + ";" + realData[1] + ";";
                pieceData += realData[2] + ";" + realData[3] + ";" + realData[4] + ";";
                pieceData += realData[5];

                // Save flip values
                if (index != 0)
                {
                    pieceData += ";" + piecesList[index].GetInFront() + ";" + piecesList[index].GetAngleFlip();
                }

                returnData.Add(pieceData);
            }
            return returnData;
        }
    }
}
