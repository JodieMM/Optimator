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

namespace Animator
{
    public partial class ScenesForm : Form
    {
        // Initialise Variables
        List<Piece> piecesList = new List<Piece>();     // Contains ALL pieces, INCLUDING sets (Lone pieces found with piece.GetIsAttached() )
        List<Set> setList = new List<Set>();            // Contains sets ONLY for saving purposes

        List<Changes> changes = new List<Changes>();

        int numFrames = 1;
        int workingFrame = 0;

        Graphics g;        


        public ScenesForm()
        {
            InitializeComponent();
        }

        private void AddPieceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Add piece to lists
                piecesList.Add(new Piece(NameTb.Text));
                partsLb.Items.Add(NameTb.Text);
                piecesList[piecesList.Count - 1].SetOriginal(new Originals(piecesList[piecesList.Count - 1]));

                partsLb.SelectedIndex = partsLb.Items.Count - 1;

                // Draw the Piece on the Scene
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

            // Update Originals if needed

            // Draw Parts
            foreach (Piece toDraw in piecesList)
            {
                Utilities.DrawPiece(toDraw, g, true);
            }
        }

        private void partsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                Piece selected = piecesList[partsLb.SelectedIndex];
                rotationUpDown.Value = (decimal)selected.rotation;
                turnUpDown.Value = (decimal)selected.turn;
                spinUpDown.Value = (decimal)selected.spin;
                xUpDown.Value = (decimal)selected.x;
                yUpDown.Value = (decimal)selected.y;
                sizeUpDown.Value = (decimal)selected.sizeMod;
                DrawParts();
            }
        }

        private void rotationUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                // Check for Overflow
                if (rotationUpDown.Value == 360)
                {
                    rotationUpDown.Value = 0;
                }
                else if (rotationUpDown.Value == -1)
                {
                    rotationUpDown.Value = 359;
                }

                // Update Piece
                piecesList[partsLb.SelectedIndex].GetOriginal().SetR((double)rotationUpDown.Value);

                DrawParts();
            }
        }

        private void turnUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                // Check for Overflow
                if (turnUpDown.Value == 360)
                {
                    turnUpDown.Value = 0;
                }
                else if (turnUpDown.Value == -1)
                {
                    turnUpDown.Value = 359;
                }

                // Update Piece
                piecesList[partsLb.SelectedIndex].GetOriginal().SetT((int)turnUpDown.Value);

                DrawParts();
            }
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            if (animationPanel.Visible)
            {
                animationPanel.Visible = false;
            }
            else
            {
                animationPanel.Visible = true;
            }
        }

        private void SpinUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                // Check for Overflow
                if (spinUpDown.Value == 360)
                {
                    spinUpDown.Value = 0;
                }
                else if (spinUpDown.Value == -1)
                {
                    spinUpDown.Value = 359;
                }

                // Update Piece
                piecesList[partsLb.SelectedIndex].GetOriginal().SetS((int)spinUpDown.Value);

                DrawParts();
            }
        }

        private void upBtn_Click(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex > 0)
            {
                // Update piecesList
                Piece holdingPiece = piecesList[partsLb.SelectedIndex - 1];
                piecesList[partsLb.SelectedIndex - 1] = piecesList[partsLb.SelectedIndex];
                piecesList[partsLb.SelectedIndex] = holdingPiece;

                // Update partsLb
                Object holdingObject = partsLb.Items[partsLb.SelectedIndex - 1];
                partsLb.Items[partsLb.SelectedIndex - 1] = partsLb.Items[partsLb.SelectedIndex];
                partsLb.Items[partsLb.SelectedIndex] = holdingObject;

                DrawParts();
            }
        }

        private void downBtn_Click(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1 && partsLb.SelectedIndex < piecesList.Count - 1)
            {

                // Update piecesList
                Piece holdingPiece = piecesList[partsLb.SelectedIndex + 1];
                piecesList[partsLb.SelectedIndex + 1] = piecesList[partsLb.SelectedIndex];
                piecesList[partsLb.SelectedIndex] = holdingPiece;

                // Update partsLb
                Object holdingObject = partsLb.Items[partsLb.SelectedIndex + 1];
                partsLb.Items[partsLb.SelectedIndex + 1] = partsLb.Items[partsLb.SelectedIndex];
                partsLb.Items[partsLb.SelectedIndex] = holdingObject;

                DrawParts();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                // If piece is involved in set
                if (piecesList[partsLb.SelectedIndex].GetPieceOf() != null)
                {
                    DialogResult result = MessageBox.Show("This will delete the entire set. Do you wish to continue?",
                        "Overwrite Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Set deleting = piecesList[partsLb.SelectedIndex].GetPieceOf();
                        setList.Remove(deleting);

                        for (int index = 0; index < piecesList.Count;)
                        {
                            if (piecesList[index].GetPieceOf() == deleting)
                            {
                                piecesList.RemoveAt(index);
                                partsLb.Items.RemoveAt(partsLb.SelectedIndex);
                            }
                            else
                            {
                                index++;
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else // Piece is lone
                {
                    piecesList.RemoveAt(partsLb.SelectedIndex);
                    partsLb.Items.RemoveAt(partsLb.SelectedIndex);
                }

                UpdateChanges();

                // Ensure selected index will not overflow
                if (partsLb.SelectedIndex == partsLb.Items.Count)
                {
                    partsLb.SelectedIndex = partsLb.Items.Count - 1;
                }

                DrawParts();
            }
        }

        private void xUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                // Update Piece
                piecesList[partsLb.SelectedIndex].GetOriginal().SetX((int)xUpDown.Value);

                DrawParts();
            }
        }

        private void yUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                // Update Piece
                piecesList[partsLb.SelectedIndex].GetOriginal().SetY((int)yUpDown.Value);

                DrawParts();
            }
        }

        private void sizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                // Update Piece
                piecesList[partsLb.SelectedIndex].GetOriginal().SetSM((int)sizeUpDown.Value);

                DrawParts();
            }
        }

        private void hideBtn_Click(object sender, EventArgs e)
        {
            animationPanel.Visible = false;
        }

        private void addAnimationBtn_Click(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                changes.Add(new Changes(workingFrame, changeTypeCb.Text, piecesList[partsLb.SelectedIndex], 
                    (double)animationAmountTb.Value, (int)frameLengthUpDown.Value));
            }
            updateAnimationListbox();
        }


        private void updateAnimationListbox()
        {
            animationLb.Items.Clear();
            foreach (Changes change in changes)
            {
                if (workingFrame >= change.GetStartFrame() && workingFrame <= change.GetStartFrame() + change.GetHowLong() - 1)
                {
                    string summary = "";
                    if (change.GetPiece().GetPieceOf() != null)
                    {
                        summary += change.GetPiece().GetAttachedTo() != null ? "** " : "* ";
                    }

                    summary += change.GetAction() + " : " + change.GetPiece().GetName() + " : " + change.GetHowMuch().ToString()
                        + " : " + (change.GetHowLong() - (workingFrame - change.GetStartFrame())).ToString();

                    animationLb.Items.Add(summary);
                }
            }
        }

        private void nextFrameBtn_Click(object sender, EventArgs e)
        {
            foreach (Changes change in changes)
            {
                if (workingFrame >= change.GetStartFrame() && workingFrame <= change.GetStartFrame() + change.GetHowLong() - 1)
                {
                    change.Run(true);
                }
            }

            DrawParts();

            // If new, create new frame
            if (numFrames - 1 == workingFrame) { numFrames++; }

            workingFrame++;
            updateAnimationListbox();

            // TEMP **
            sceneNumber.Text = workingFrame.ToString();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (workingFrame > 0)
            {
                foreach (Changes change in changes)
                {
                    if (workingFrame >= change.GetStartFrame() + 1 && workingFrame <= change.GetStartFrame() + change.GetHowLong())
                    {
                        change.Run(false);
                    }
                }

                DrawParts();

                workingFrame--;
                updateAnimationListbox();

                // TEMP **
                sceneNumber.Text = workingFrame.ToString();
            }
        }

        private void finishSceneBtn_Click(object sender, EventArgs e)
        {
            // Save as a Scene
            Boolean doEet = true;
            DialogResult result = MessageBox.Show("Do you want to save this scene?", "Save Confirmation", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                doEet = false;
            }


            if (doEet)
            {
                try
                {
                    // Save Data
                    string filePath = Environment.CurrentDirectory + "\\Scenes\\" + sceneNameTb.Text + ".txt";
                    System.IO.StreamWriter file = new System.IO.StreamWriter(@filePath);

                    // Save FPS & Number of Frames (Line 1)
                    file.WriteLine(fpsUpDown.Value + ";" + numFrames);

                    // Save Parts
                    for (int index = 0; index < piecesList.Count; index++)
                    {
                        piecesList[index].SetSceneIndex(index);

                        // If piece is in set
                        if (piecesList[index].GetPieceOf() != null)
                        {
                            // If piece is base
                            if (piecesList[index].GetAttachedTo() == null)
                            {
                                file.WriteLine("s:" + piecesList[index].GetPieceOf().GetName());
                            }
                        }
                        else
                        {
                            file.WriteLine("p:" + piecesList[index].GetName());
                        }
                    }

                    // Write Original States Notifier
                    file.WriteLine("Originals");

                    // Save Original States
                    foreach (Piece piece in piecesList)
                    {
                        file.WriteLine(piece.GetOriginal() != null ? piece.GetSceneIndex() + ";" + piece.GetOriginal().GetSaveData() 
                            : piece.GetSceneIndex() + ";500;250;0;0;0;100");    // This should never be needed- JIC
                        
                    }

                    // Save Animation Changes
                    foreach (Changes change in changes)
                    {
                        file.WriteLine(change.GetStartFrame() + ";" + change.GetAction() + ";" +
                            change.GetPiece().GetSceneIndex() + ";" + change.GetHowMuch() + ";" + change.GetHowLong());
                    }

                    // Close File and Form
                    file.Close();
                    this.Close();
                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
                }
            }
            else
            {
                DialogResult query = MessageBox.Show("Do you wish to exit without saving?", "Exit Confirmation", MessageBoxButtons.YesNo);
                if (query == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void switchSidesBtn2_Click(object sender, EventArgs e)
        {
            if (animationPanel.Location.X == 0)
            {
                animationPanel.Location = new Point(this.Width - 16 - animationPanel.Width, 0);
            }
            else
            {
                animationPanel.Location = new Point(0, 0);
            }
            DrawParts();
        }

        private void switchSidesBtn1_Click(object sender, EventArgs e)
        {
            if (partsPanel.Location.X == 0)
            {
                partsPanel.Location = new Point(this.Width - 16 - partsPanel.Width, 0);
            }
            else
            {
                partsPanel.Location = new Point(0, 0);
            }
            DrawParts();
        }

        private void AnimationPanelBtn_Click(object sender, EventArgs e)
        {
            animationPanel.Visible = true;
            partsPanel.Visible = false;
        }

        private void partsPanelBtn_Click(object sender, EventArgs e)
        {
            animationPanel.Visible = false;
            partsPanel.Visible = true;
        }

        /// <summary>
        /// Checks if any Changes have been made invalid/unnecessary due
        /// to the deletion of a piece and removes them if so.
        /// </summary>
        private void UpdateChanges()
        {
            // Update Changes
            for (int index = 0; index < changes.Count;)
            {
                if (!piecesList.Contains(changes[index].GetPiece()))
                {
                    changes.RemoveAt(index);
                }
                else
                {
                    index++;
                }
            }
        }

        private void AddSetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Add pieces to lists
                setList.Add(new Set(NameTb.Text));
                piecesList.AddRange(setList[setList.Count - 1].GetPiecesList());
                foreach (Piece piece in setList[setList.Count - 1].GetPiecesList())
                {
                    if (piece.GetAttachedTo() != null)
                    {
                        partsLb.Items.Add("* " + piece.GetName());
                    }
                    else
                    {
                        partsLb.Items.Add("** " + piece.GetName());
                    }
                    piece.SetOriginal(new Originals(piece));
                }

                partsLb.SelectedIndex = partsLb.Items.Count - 1;

                // Draw the Piece on the Scene
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
}
