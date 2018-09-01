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
        List<string> partOrder = new List<string>();
        List<Piece> piecesList = new List<Piece>();
        List<Set> setList = new List<Set>();
        List<string[]> changes = new List<string[]>();      // FORMAT: start;what;who;much;length
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
                partOrder.Add("p:" + (piecesList.Count - 1));
                partsLb.Items.Add(NameTb.Text);


                // Add set to lists ** NEEDS OWN BUTTON
                /*
                setList.Add(new Set(NameTb.Text));
                partOrder.Add("s:" + (setList.Count - 1));
                partsLb.Items.Add(setList[setList.Count - 1].GetName());
                */


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

            // Draw Parts
            for (int partIndex = 0; partIndex < partOrder.Count; partIndex++)
            {
                if (partOrder[partIndex].StartsWith("p"))
                {
                    Utilities.DrawPiece(piecesList[int.Parse(partOrder[partIndex].Remove(0, 2))], g, true);
                }
                else
                {
                    //DrawSet(setList[int.Parse(partOrder[partIndex].Remove(0, 2))]);
                }
            }
        }

        private void partsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                string position = partOrder[partsLb.SelectedIndex];
                Piece currentPiece;
                currentPiece = piecesList[int.Parse(position.Remove(0, 2))];
                rotationUpDown.Value = (decimal)currentPiece.GetAngles()[0];
                turnUpDown.Value = (decimal)currentPiece.GetAngles()[1];
                spinUpDown.Value = (decimal)currentPiece.GetAngles()[2];
                xUpDown.Value = (decimal)currentPiece.GetCoords()[0];
                yUpDown.Value = (decimal)currentPiece.GetCoords()[1];
                sizeUpDown.Value = (decimal)currentPiece.GetSizeMod();
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
                piecesList[int.Parse(partOrder[partsLb.SelectedIndex].Remove(0, 2))].SetRotation((double)rotationUpDown.Value);

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
                piecesList[int.Parse(partOrder[partsLb.SelectedIndex].Remove(0, 2))].SetTurn((int)turnUpDown.Value);

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
                piecesList[int.Parse(partOrder[partsLb.SelectedIndex].Remove(0, 2))].SetSpin((int)spinUpDown.Value);

                DrawParts();
            }
        }

        private void upBtn_Click(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex > 0)
            {
                string holdingValue = partOrder[partsLb.SelectedIndex - 1];
                partOrder[partsLb.SelectedIndex - 1] = partOrder[partsLb.SelectedIndex];
                partOrder[partsLb.SelectedIndex] = holdingValue;
                Object holdingObject = partsLb.Items[partsLb.SelectedIndex - 1];
                partsLb.Items[partsLb.SelectedIndex - 1] = partsLb.Items[partsLb.SelectedIndex];
                partsLb.Items[partsLb.SelectedIndex] = holdingObject;
                DrawParts();
            }
        }

        private void downBtn_Click(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1 && partsLb.SelectedIndex < partOrder.Count - 1)
            {
                string holdingValue = partOrder[partsLb.SelectedIndex + 1];
                partOrder[partsLb.SelectedIndex + 1] = partOrder[partsLb.SelectedIndex];
                partOrder[partsLb.SelectedIndex] = holdingValue;
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
                if (partOrder[partsLb.SelectedIndex].StartsWith("p"))
                {
                    piecesList.RemoveAt(int.Parse(partOrder[partsLb.SelectedIndex].Remove(0,2)));
                }
                else
                {
                    setList.RemoveAt(int.Parse(partOrder[partsLb.SelectedIndex].Remove(0, 2)));
                }
                partOrder.RemoveAt(partsLb.SelectedIndex);
                partsLb.Items.RemoveAt(partsLb.SelectedIndex);
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
                piecesList[int.Parse(partOrder[partsLb.SelectedIndex].Remove(0, 2))].SetX((int)xUpDown.Value);

                DrawParts();
            }
        }

        private void yUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                // Update Piece
                piecesList[int.Parse(partOrder[partsLb.SelectedIndex].Remove(0, 2))].SetY((int)yUpDown.Value);

                DrawParts();
            }
        }

        private void sizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (partsLb.SelectedIndex != -1)
            {
                // Update Piece
                piecesList[int.Parse(partOrder[partsLb.SelectedIndex].Remove(0, 2))].SetSizeMod((int)sizeUpDown.Value);

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
                changes.Add(new string[] { workingFrame.ToString(), changeTypeCb.Text, partOrder[partsLb.SelectedIndex], animationAmountTb.Value.ToString(), frameLengthUpDown.Value.ToString() });
            }
            updateAnimationListbox();
        }


        private void updateAnimationListbox()
        {
            animationLb.Items.Clear();
            foreach (string[] change in changes)
            {
                if (workingFrame >= int.Parse(change[0]) && (workingFrame <= int.Parse(change[0]) + int.Parse(change[4]) - 1))
                {
                    animationLb.Items.Add(change[1] + " : " + change[2] + " : " + change[3] + " : " + (int.Parse(change[4]) - workingFrame - int.Parse(change[0])));
                }
            }
        }

        private void nextFrameBtn_Click(object sender, EventArgs e)
        {
            foreach (string[] change in changes)
            {
                if (workingFrame >= int.Parse(change[0]) && (workingFrame <= int.Parse(change[0]) + int.Parse(change[4]) - 1))
                {
                    updateFrame(change, true);
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
                foreach (string[] change in changes)
                {
                    if (workingFrame >= int.Parse(change[0] + 1) && (workingFrame <= int.Parse(change[0]) + int.Parse(change[4])))
                    {
                        updateFrame(change, false);
                    }
                }
                DrawParts();
                workingFrame--;
                updateAnimationListbox();
                // TEMP **
                sceneNumber.Text = workingFrame.ToString();
            }
        }

        private void updateFrame(string[] data, Boolean forward)
        {
            // Allow for subtraction/ going back in time
            int multiplier;
            if (forward)
            {
                multiplier = 1;
            }
            else
            {
                multiplier = -1;
            }
            // Update Parts
            
            Piece holdPiece = piecesList[int.Parse(data[2].Remove(0, 2))];
            if (data[1] == "X")
            {
                holdPiece.SetX(holdPiece.GetCoords()[0] + multiplier * int.Parse(data[3]));
            }
            else if (data[1] == "Y")
            {
                holdPiece.SetY(holdPiece.GetCoords()[1] + multiplier * int.Parse(data[3]));
            }
            else if (data[1] == "Rotation")
            {
                holdPiece.SetRotation((int)holdPiece.GetAngles()[0] + multiplier * int.Parse(data[3]));
            }
            else if (data[1] == "Turn")
            {
                holdPiece.SetTurn((int)holdPiece.GetAngles()[1] + multiplier * int.Parse(data[3]));
            }
            else if (data[1] == "Spin")
            {
                holdPiece.SetSpin((int)holdPiece.GetAngles()[2] + multiplier * int.Parse(data[3]));
            }
            else if (data[1] == "Size")
            {
                holdPiece.SetSizeMod(holdPiece.GetSizeMod() + multiplier * int.Parse(data[3]));
            }
            // Add other options ** TO DO **
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

                    // Save Scene Data
                    string saverString = "";
                    // Save FPS & Number of Frames (Line 1)
                    file.WriteLine(fpsUpDown.Value + ";" + numFrames);
                    // Save Part Order (Line 2)
                    foreach(string part in partOrder)
                    {
                        saverString += part + ";";
                    }
                    file.WriteLine(saverString.Remove(saverString.Length - 1));
                    // Save Parts (Line 3)
                    saverString = "";
                    foreach(string part in partOrder)
                    {
                        saverString = "p:" + piecesList[int.Parse(part.Remove(0, 2))].GetName() + ";";
                    }
                    file.WriteLine(saverString.Remove(saverString.Length - 1));
                    // Save Original States (Line 4)
                    while (workingFrame > 0)
                    {
                        foreach (string[] change in changes)
                        {
                            if (workingFrame >= int.Parse(change[0] + 1) && (workingFrame <= int.Parse(change[0]) + int.Parse(change[4])))
                            {
                                updateFrame(change, false);
                            }
                        }
                        workingFrame--;
                    }
                    saverString = "";
                    foreach (string part in partOrder)
                    {
                        Piece holdPiece = piecesList[int.Parse(part.Remove(0, 2))];
                        saverString += holdPiece.GetCoords()[0] + ":" + holdPiece.GetCoords()[1] + ":" + holdPiece.GetAngles()[0] + ":" +
                            holdPiece.GetAngles()[1] + ":" + holdPiece.GetAngles()[2] + ":" + holdPiece.GetSizeMod() + ";";
                    }
                    file.WriteLine(saverString.Remove(saverString.Length - 1));

                    // Save Animation Changes (Line 5+)
                    foreach (string[] change in changes)
                    {
                        saverString = change[0] + ";" + change[1] + ";" + change[2] + ";" + change[3] + ";" + change[4];
                        file.WriteLine(saverString);
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

        private Boolean isSelected(Piece currentPiece)
        {
            if (partsLb.SelectedIndex != -1)
            {
                string position = partOrder[partsLb.SelectedIndex];
                if (piecesList[int.Parse(position.Remove(0, 2))] == currentPiece)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
