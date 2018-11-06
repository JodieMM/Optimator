﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace Animator
{
    public partial class PiecesFormOrig : Form
    {
        Graphics g;
        List<Piece> sketch;
        Piece WIP;

        string angleType = "base";
        List<string> joins, solid;
        List<double[]> original, rotated, turned, rAtT0;

        private string folder;
        const string tempPiece = "tempPiece";
        const string tempPoint = "tempPoint";
        const string piecesFolder = "\\Pieces\\";
        const string pointsFolder = "\\Points\\";
        const string defaultName = "Item Name";


        public PiecesFormOrig()
        {
            InitializeComponent();
            DrawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseDown);
            joins = new List<string>();
            solid = new List<string>();
            original = new List<double[]>();
            rotated = new List<double[]>();
            turned = new List<double[]>();
            rAtT0 = new List<double[]>();
            sketch = new List<Piece>();
            folder = piecesFolder;

            // Create New Piece
            WIP = new Piece(tempPiece);
            WIP.SetName(defaultName);
        }


        private void DoneBtn_Click(object sender, EventArgs e)
        {
            Boolean doEet = true;
            Boolean exit = false;

            // Check file does not already exist/ name has been changed
            if (NameTb.Text == defaultName || NameTb.Text == "")
            {
                doEet = false;
                MessageBox.Show("Please choose a name for your piece", "Name Invalid", MessageBoxButtons.OK);
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
                DialogResult result = MessageBox.Show("Do you want to save this piece?", "Save Confirmation", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No) { doEet = false; exit = true; }
            }

            // Save file (or exit)
            if (doEet)
            {
                try
                {
                    Utilities.SaveData(Environment.CurrentDirectory + folder + NameTb.Text + ".txt", WIP.GetData());

                    this.Close();
                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("No data entered for point", "Missing Data", MessageBoxButtons.OK);
                }
            }
            else if (exit)
            {
                DialogResult query = MessageBox.Show("Do you wish to exit without saving?", "Exit Confirmation", MessageBoxButtons.YesNo);
                if (query == System.Windows.Forms.DialogResult.Yes) { this.Close(); }
            }
        }


        private void DrawPoint(double xcood, double ycood, Color colour)
        {
            int x = (int)xcood;
            int y = (int)ycood;
            Pen pen = new Pen(colour);
            g.DrawLine(pen, new Point(x - 2, y), new Point(x + 2, y));
            g.DrawLine(pen, new Point(x, y - 2), new Point(x, y + 2));
        }

        private void PointsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                int[,] coords = ConvertListbox();
                XUpDown.Value = coords[PointsLb.SelectedIndex, 0];
                YUpDown.Value = coords[PointsLb.SelectedIndex, 1];
                JoinOptions.SelectedItem = joins[PointsLb.SelectedIndex];
                FixedCb.Checked = (solid[PointsLb.SelectedIndex] == "s") ? true : false;
                DrawPoints();
            }
            
        }

        private void DrawPoints()
        {
            // Resave Points
            string save = ConvertCurrentAngle();
            WIP.ReplaceDataLine(save);
            string temporary = ConvertAnglesUpDown();
            if (angleType == "base")
            {
                temporary += ConvertCurrentAngleOriginal() + ConvertCurrentAngleOriginal() + ConvertCurrentAngleOriginal();
            }
            else if (angleType == "rotated")
            {
                temporary += ConvertCurrentAngleRotated() + ConvertCurrentAngleRotated() + ConvertCurrentAngleRotated();
            }
            else
            {
                temporary += ConvertCurrentAngleTurned() + ConvertCurrentAngleTurned() + ConvertCurrentAngleTurned();
            }
            temporary += ConvertCurrentAngleDetails();
            WIP.ReplaceDataLine(temporary);

            // Prepare
            DrawPanel.Refresh();
            g = this.DrawPanel.CreateGraphics();

            // Draw Sketch Pieces
            for (int index = 0; index < sketch.Count; index++)
            {
                Utilities.DrawPiece(sketch[index], g, true);
            }

            // Draw WIP Piece
            int[,] coords = ConvertListbox();

            // Set Rotation and Turn
            WIP.SetRotation((double)rFromUpDown.Value);
            WIP.SetTurn((double)tFromUpDown.Value);
            if (angleType == "rotated")
            {
                WIP.SetRotation((double)rToUpDown.Value);
            }
            else if (angleType == "turned")
            {
                WIP.SetTurn((double)tToUpDown.Value);
            }

            Utilities.DrawPiece(WIP, g, false);

            // Reinstate Correct Values
            WIP.ReplaceDataLine(save);

            // Draw WIP Points
            for (int index = 0; index < PointsLb.Items.Count; index++)
            {
                if (PointsLb.SelectedIndex == index)
                {
                    DrawPoint(coords[index, 0], coords[index, 1], Color.Red);
                }
                else
                {
                    DrawPoint(coords[index, 0], coords[index, 1], Color.Black);
                }
            }
        }

        private void AddPointBtn_Click(object sender, EventArgs e)
        {
            AddPoint(400, 400);
        }

        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (angleType == "base")
            {
                int mouseX = e.X;
                int mouseY = e.Y;
                AddPoint(mouseX, mouseY);
            }
        }

        private void XUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                int[,] coords = ConvertListbox();
                PointsLb.Items[PointsLb.SelectedIndex] = XUpDown.Value + "," + coords[PointsLb.SelectedIndex, 1];
                DrawPoints();
            }
        }

        private void YUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                int[,] coords = ConvertListbox();
                PointsLb.Items[PointsLb.SelectedIndex] = coords[PointsLb.SelectedIndex, 0] + "," + YUpDown.Value;
                DrawPoints();
            }
        }

        private void UpBtn_Click(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1 && PointsLb.SelectedIndex != 0)
            {
                Object holdingValue = PointsLb.Items[PointsLb.SelectedIndex - 1];
                PointsLb.Items[PointsLb.SelectedIndex - 1] = PointsLb.Items[PointsLb.SelectedIndex];
                PointsLb.Items[PointsLb.SelectedIndex] = holdingValue;
                string holdJoin = joins[PointsLb.SelectedIndex - 1];
                joins[PointsLb.SelectedIndex - 1] = joins[PointsLb.SelectedIndex];
                joins[PointsLb.SelectedIndex] = holdJoin;
                string holdSolid = solid[PointsLb.SelectedIndex - 1];
                solid[PointsLb.SelectedIndex - 1] = solid[PointsLb.SelectedIndex];
                solid[PointsLb.SelectedIndex] = holdSolid;
                PointsLb.SelectedIndex--;
            }
        }

        private void DownBtn_Click(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1 && PointsLb.SelectedIndex != PointsLb.Items.Count - 1)
            {
                Object holdingValue = PointsLb.Items[PointsLb.SelectedIndex + 1];
                PointsLb.Items[PointsLb.SelectedIndex + 1] = PointsLb.Items[PointsLb.SelectedIndex];
                PointsLb.Items[PointsLb.SelectedIndex] = holdingValue;
                string holdJoin = joins[PointsLb.SelectedIndex + 1];
                joins[PointsLb.SelectedIndex + 1] = joins[PointsLb.SelectedIndex];
                joins[PointsLb.SelectedIndex] = holdJoin;
                string holdSolid= solid[PointsLb.SelectedIndex + 1];
                solid[PointsLb.SelectedIndex + 1] = solid[PointsLb.SelectedIndex];
                solid[PointsLb.SelectedIndex] = holdSolid;
                PointsLb.SelectedIndex++;
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                // SHOW WARNING DELETING ROTATED/TURNED ANGLED ** TO DO
                rotated.Clear();
                turned.Clear();
                joins.RemoveAt(PointsLb.SelectedIndex);
                solid.RemoveAt(PointsLb.SelectedIndex);
                PointsLb.Items.RemoveAt(PointsLb.SelectedIndex);
                DrawPoints();
            }
        }

        private void AlphaUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateColours();
        }

        private void RedUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateColours();
        }

        private void GreenUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateColours();
        }

        private void BlueUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateColours();
        }

        private int[,] ConvertListbox()
        {
            int[,] coords = new int[PointsLb.Items.Count, 2];
            for (int index = 0; index < PointsLb.Items.Count; index++)
            {
                coords[index, 0] = int.Parse(PointsLb.Items[index].ToString().Split(new Char[] { ',' })[0]);
                coords[index, 1] = int.Parse(PointsLb.Items[index].ToString().Split(new Char[] { ',' })[1]);
            }
            return coords;
        }

        private void FillRb_CheckedChanged(object sender, EventArgs e)
        {
            if (FillRb.Checked == true)
            {
                int[] coloursHold = new int[] { WIP.GetFillColour()[0].A, WIP.GetFillColour()[0].R, WIP.GetFillColour()[0].G, WIP.GetFillColour()[0].B};
                AlphaUpDown.Value = coloursHold[0];
                RedUpDown.Value = coloursHold[1];
                GreenUpDown.Value = coloursHold[2];
                BlueUpDown.Value = coloursHold[3];
                label8.ForeColor = Color.Black;
                label10.ForeColor = Color.Black;
                midFillCb.ForeColor = Color.Black;
                midFillCb.Enabled = true;
                numColUpDown.Enabled = true;
                gradAngleUpDown.Enabled = true;
            }
            DrawPoints();
        }

        private void OutlineRb_CheckedChanged(object sender, EventArgs e)
        {
            if (OutlineRb.Checked == true)
            {
                int[] coloursHold = new int[] { WIP.GetOutlineColour().A, WIP.GetOutlineColour().R, WIP.GetOutlineColour().G, WIP.GetOutlineColour().B};
                AlphaUpDown.Value = coloursHold[0];
                RedUpDown.Value = coloursHold[1];
                GreenUpDown.Value = coloursHold[2];
                BlueUpDown.Value = coloursHold[3];
                label8.ForeColor = Color.DimGray;
                label10.ForeColor = Color.DimGray;
                midFillCb.ForeColor = Color.DimGray;
                midFillCb.Enabled = false;
                numColUpDown.Enabled = false;
                gradAngleUpDown.Enabled = false;
            }
            DrawPoints();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                joins[PointsLb.SelectedIndex] = (string)JoinOptions.SelectedItem;
            }
        }

        private void SwitchBtn_Click(object sender, EventArgs e)
        {
            OptionsPanel.Visible = true;
            PiecePanel.Visible = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Check Overflow
            if (gradAngleUpDown.Value == -1)
            {
                gradAngleUpDown.Value = 359;
            } 
            else if (gradAngleUpDown.Value == 360)
            {
                gradAngleUpDown.Value = 0;
            }
        }

        private void midFillCb_CheckedChanged(object sender, EventArgs e)
        {
            UpdateColours();
            gradAngleUpDown.Enabled = (midFillCb.Checked == true) ? false: true;
            label10.ForeColor = (midFillCb.Checked == true) ? Color.DimGray : Color.Black;
        }

        private void FixedCb_CheckedChanged(object sender, EventArgs e)
        {
            if (PointsLb.SelectedIndex != -1)
            {
                solid[PointsLb.SelectedIndex] = (FixedCb.Checked == true) ? "s" : "f";
            }

        }

        private void rFromUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Test Range Fair
            if (rFromUpDown.Value > rToUpDown.Value)
            {
                decimal hold = rFromUpDown.Value;
                rFromUpDown.Value = rToUpDown.Value;
                rToUpDown.Value = hold;
            }
        }

        private void RotateBtn_Click(object sender, EventArgs e)
        {
            // Get values from holding arrays
            if (original.Count != 0 && rotated.Count == 0)
            {
                rotated.AddRange(original);
            }
            string save = ConvertCurrentAngle();
            angleType = "rotated";

            // Add to piece data
            WIP.ReplaceDataLine(save);

            // Fill LB
            FillListbox(rotated);

            // Hide/Show Buttons
            YUpDown.Enabled = false;
            XUpDown.Enabled = true;
            UpBtn.Enabled = false;
            DownBtn.Enabled = false;
            AddPointBtn.Enabled = false;
            DeleteBtn.Enabled = false;
            ClearBtn.Enabled = false;
        }

        private void TurnBtn_Click(object sender, EventArgs e)
        {
            // Get values from holding arrays
            if (original.Count != 0 && turned.Count == 0)
            {
                turned.AddRange(original);
            }
            string save = ConvertCurrentAngle();
            angleType = "turned";

            // Add to piece data
            WIP.ReplaceDataLine(save);

            // Fill LB
            FillListbox(turned);

            // Hide/Show Buttons
            YUpDown.Enabled = true;
            XUpDown.Enabled = false;
            UpBtn.Enabled = false;
            DownBtn.Enabled = false;
            AddPointBtn.Enabled = false;
            DeleteBtn.Enabled = false;
            ClearBtn.Enabled = false;
        }

        private void BaseBtn_Click(object sender, EventArgs e)
        {
            // Get values from holding arrays
            string save = ConvertCurrentAngle();
            angleType = "base";

            // Add to piece data
            WIP.ReplaceDataLine(save);

            // Fill LB
            FillListbox(original);

            // Hide/Show Buttons
            YUpDown.Enabled = true;
            XUpDown.Enabled = true;
            UpBtn.Enabled = true;
            DownBtn.Enabled = true;
            AddPointBtn.Enabled = true;
            DeleteBtn.Enabled = true;
            ClearBtn.Enabled = true;
        }

        private List<double[]> SaveAngles()
        {
            List<double[]> angles = new List<double[]>();
            for (int index = 0; index < PointsLb.Items.Count; index++)
            {
                double[] xypoint = new double[2];
                xypoint[0] = double.Parse(PointsLb.Items[index].ToString().Split(new Char[] { ',' })[0]);
                xypoint[1] = double.Parse(PointsLb.Items[index].ToString().Split(new Char[] { ',' })[1]);
                angles.Add(xypoint);
            }
            return angles;
        }

        private void OutlineWidthUpDown_ValueChanged(object sender, EventArgs e)
        {
            WIP.SetOutlineWidth((int)OutlineWidthUpDown.Value);
            DrawPoints();
        }

        private void sketchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                sketch.Add(new Piece(loadTb.Text));
                if (pointCb.Checked == true)
                {
                    sketchBtn.Enabled = false;
                }
                DrawPoints();
            } catch(System.IO.FileNotFoundException)        // ** ADD IN ERROR IF SET CHOSEN **
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
        }

        private void pointCb_CheckedChanged(object sender, EventArgs e)
        {
            Boolean doEet = true;

            if (pointCb.Checked == true)
            {
                // Confirm Intention
                if (PointsLb.Items.Count > 1)
                {
                    DialogResult result = MessageBox.Show("Points will be lost. Do you wish to continue?", "Change Confirmation", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.No)
                    {
                        doEet = false;
                        pointCb.Checked = false;
                    }
                }

                // Prepare LB, Enables/disables
                if (doEet)
                {
                    //Remove excess points from listbox
                    foreach (Object lbpoint in PointsLb.Items)
                    {
                        if (lbpoint != PointsLb.Items[0])
                        {
                            PointsLb.Items.Remove(lbpoint);
                        }
                    }

                    //Remove excess points from original/rotated/turned
                    if (original.Count > 0)
                    {
                        double[] holder = original[0];
                        original.Clear();
                        original.Add(holder);
                    }
                    if (rotated.Count > 0)
                    {
                        double[] holder = rotated[0];
                        rotated.Clear();
                        rotated.Add(holder);
                    }
                    if (turned.Count > 0)
                    {
                        double[] holder = turned[0];
                        turned.Clear();
                        turned.Add(holder);
                    }

                    //If no point exists, add one (as adding functions are now disabled to prevent adding multiple points)
                    if (PointsLb.Items.Count == 0)
                    {
                        AddPoint(400, 400);
                    }

                    loadBtn.Enabled = false;
                    AddPointBtn.Enabled = false;
                    DeleteBtn.Enabled = false;
                    JoinOptions.Enabled = false;

                    folder = pointsFolder;
                    WIP = new Piece(tempPoint, folder);

                    
                    // ** POTENTIAL TO SAVE EXISTING DATA IS HERE BUT LOST
                }

                // Disable Piece Settings
                FillRb.Enabled = false;
                OutlineRb.Enabled = false;
                label6.Enabled = false;
                label1.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = false;
                AlphaUpDown.Enabled = false;
                RedUpDown.Enabled = false;
                GreenUpDown.Enabled = false;
                BlueUpDown.Enabled = false;
                label8.Enabled = false;
                label10.Enabled = false;
                numColUpDown.Enabled = false;
                gradAngleUpDown.Enabled = false;
                label4.Enabled = false;
                wrUpDown.Enabled = false;
                label11.Enabled = false;
                midFillCb.Enabled = false;
                label15.Enabled = false;
                OutlineWidthUpDown.Enabled = false;
            }
            else
            {
                folder = piecesFolder;
                WIP = new Piece(tempPiece);

                sketchBtn.Enabled = true;
                loadBtn.Enabled = true;
                AddPointBtn.Enabled = true;
                DeleteBtn.Enabled = true;
                JoinOptions.Enabled = true;

                // Enable Piece Settings
                FillRb.Enabled = true;
                OutlineRb.Enabled = true;
                label6.Enabled = true;
                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;
                AlphaUpDown.Enabled = true;
                RedUpDown.Enabled = true;
                GreenUpDown.Enabled = true;
                BlueUpDown.Enabled = true;
                label8.Enabled = true;
                label10.Enabled = true;
                numColUpDown.Enabled = true;
                gradAngleUpDown.Enabled = true;
                label4.Enabled = true;
                wrUpDown.Enabled = true;
                label11.Enabled = true;
                midFillCb.Enabled = true;
                label15.Enabled = true;
                OutlineWidthUpDown.Enabled = true;
            }

            DrawPoints();
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                new Piece(loadTb.Text);
                PiecesForm_LoadMenu loadForm = new PiecesForm_LoadMenu(this);
                //loadForm.Size = new System.Drawing.Size(875, 750);
                loadForm.Show();
            }
            catch (System.IO.FileNotFoundException) // ** SET ERROR **
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
        }

        private void numColUpDown_ValueChanged(object sender, EventArgs e)
        {
            DrawPoints();
        }

        private void tFromUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Test Range Fair
            if (tFromUpDown.Value > tToUpDown.Value)
            {
                decimal hold = tFromUpDown.Value;
                tFromUpDown.Value = tToUpDown.Value;
                tToUpDown.Value = hold;
            }
        }

        private void rToUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Test Range Fair
            if (rFromUpDown.Value > rToUpDown.Value)
            {
                decimal hold = rFromUpDown.Value;
                rFromUpDown.Value = rToUpDown.Value;
                rToUpDown.Value = hold;
            }
        }

        private void tToUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Test Range Fair
            if (tFromUpDown.Value > tToUpDown.Value)
            {
                decimal hold = tFromUpDown.Value;
                tFromUpDown.Value = tToUpDown.Value;
                tToUpDown.Value = hold;
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            Boolean doEet = true;
            if (rFromUpDown.Value == rToUpDown.Value || tFromUpDown.Value == tToUpDown.Value)
            {
                DialogResult result = MessageBox.Show("Rotation or Turn unchanged. Is this intentional?", "Input Confirmation", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    doEet = false;
                }
            }
            // CHECK FOR OVERRIDING AND CONFIRM INTENTION ** TO DO
            // CHECK FOR NO CHANGE TO ROTATION / TURN AND CHECK INTENTION ** TO DO
            if (doEet)
            {
                // Fill in blank data before continuing
                if (rotated.Count == 0)
                {
                    rotated.AddRange(original);
                }
                if (turned.Count == 0)
                {
                    turned.AddRange(original);
                }

                // Get values from holding arrays
                string save = ConvertCurrentAngle();

                // Add to piece data
                WIP.ReplaceDataLine(save);

                // Change Provided Angles and Points
                if (rToUpDown.Value == 360)
                {
                    rFromUpDown.Value = 0;
                    rToUpDown.Value = 0;
                    tFromUpDown.Value = tToUpDown.Value;
                }
                else
                {
                    rFromUpDown.Value = rToUpDown.Value;
                }

                // Clear Angles and Reset
                turned.Clear();
                rotated.Clear();
                original.Clear();
                angleType = "base";
                WIP.AddDataLine("000:000;000:000;;;;;");
                ResetOriginal();
                DrawPoints();
            }
        }

        private void UpdateColours()
        {
            if (OutlineRb.Checked == true)
            {
                WIP.SetOutlineColour(Color.FromArgb((int)AlphaUpDown.Value, (int)RedUpDown.Value, (int)GreenUpDown.Value, (int)BlueUpDown.Value));
            }
            else
            {
                // ALLOW FOR GRADIENTS      ** TO DO **
                WIP.SetFillColour(new Color[] { Color.FromArgb((int)AlphaUpDown.Value, (int)RedUpDown.Value, (int)GreenUpDown.Value, (int)BlueUpDown.Value) });
            }
            DrawPoints();
        }

        
        public void LoadIn(string goal)  // TO FINISH **
        {
            Piece loadPiece = new Piece(loadTb.Text);

            // Select Goal
            switch (goal)
            {
                case "exit":
                    break;

                case "fillColour":
                    WIP.SetFillColour(loadPiece.GetFillColour());
                    break;

                case "outlineColour":
                    WIP.SetOutlineColour(loadPiece.GetOutlineColour());
                    break;

                case "colours":
                    WIP.SetFillColour(loadPiece.GetFillColour());
                    WIP.SetOutlineColour(loadPiece.GetOutlineColour());
                    break;

                default:
                    break;

            }
            DrawPoints();
        }


        private string ConvertCurrentAngle()
        {
            string save = "";

            // Rotation and Turn
            save += ConvertAnglesUpDown();

            // POINTS
            SaveCurrentAnglesLists();

            save += ConvertCurrentAngleOriginal();
            save += ConvertCurrentAngleRotated();
            save += ConvertCurrentAngleTurned();
            save += ConvertCurrentAngleDetails();

            return save;
        }

        private void SaveCurrentAnglesLists()
        {
            if (angleType == "base")
            {
                original = SaveAngles();
            }
            else if (angleType == "turned")
            {
                turned = SaveAngles();
            }
            else
            {
                rotated = SaveAngles();
            }
        }

        /// <summary>
        /// Enters the current angle's coordinates into the list box. 
        /// Function also redraws points.
        /// </summary>
        /// <param name="anglesList">The current angle (original, rotation or turn)</param>
        private void FillListbox(List<double[]> anglesList)
        {
            PointsLb.Items.Clear();
            for (int index = 0; index < anglesList.Count; index++)
            {
                PointsLb.Items.Add(Convert.ToInt32(anglesList[index][0]) + "," + Convert.ToInt32(anglesList[index][1]));
            }
            DrawPoints();
        }

        private string ConvertAnglesUpDown()
        {
            return rFromUpDown.Value.ToString().PadLeft(3, '0') + ":" + rToUpDown.Value.ToString().PadLeft(3, '0') + ";" +
                tFromUpDown.Value.ToString().PadLeft(3, '0') + ":" + tToUpDown.Value.ToString().PadLeft(3, '0') + ";";
        }

        private string ConvertCurrentAngleOriginal()
        {
            string save = "";
            if (original.Count != 0)
            {
                for (int index = 0; index < original.Count - 1; index++)
                {
                    save += original[index][0] + "," + original[index][1] + ":";
                }
                save += original[original.Count - 1][0] + "," + original[original.Count - 1][1] + ";";
            }
            else
            {
                save += ";";
            }
            return save;
        }

        private void ResetAngleBtn_Click(object sender, EventArgs e)
        {
            if (angleType == "base")
            {
                // SHOW WARNING ** TO DO
                original.Clear();
                ResetOriginal();
            }
            else if (angleType == "rotated")
            {
                // SHOW WARNING ** TO DO
                rotated.Clear();
                rotated.AddRange(original);
                FillListbox(rotated);
            }
            else
            {
                // SHOW WARNING ** TO DO
                turned.Clear();
                turned.AddRange(original);
                FillListbox(turned);
            }
        }

        private void ClearAngleBtn_Click(object sender, EventArgs e)
        {
            // SHOW WARNING ** TO DO
            PointsLb.Items.Clear();
            original.Clear();
            rotated.Clear();
            turned.Clear();
            joins.Clear();
            solid.Clear();
            BaseBtn_Click(sender, e);
            DrawPoints();
        }

        private string ConvertCurrentAngleRotated()
        {
            string save = "";
            if (rotated.Count != 0)
            {
                for (int index = 0; index < rotated.Count - 1; index++)
                {
                    save += rotated[index][0] + "," + rotated[index][1] + ":";
                }
                save += rotated[rotated.Count - 1][0] + "," + rotated[rotated.Count - 1][1] + ";";
            }
            else
            {
                save += ";";
            }
            return save;
        }

        private string ConvertCurrentAngleTurned()
        {
            string save = "";
            if (turned.Count != 0)
            {
                for (int index = 0; index < turned.Count - 1; index++)
                {
                    save += turned[index][0] + "," + turned[index][1] + ":";
                }
                save += turned[turned.Count - 1][0] + "," + turned[turned.Count - 1][1] + ";";
            }
            else
            {
                save += ";";
            }
            return save;
        }


        private void NameTb_TextChanged(object sender, EventArgs e)
        {
            WIP.SetName(NameTb.Text);
        }

        private void wrUpDown_ValueChanged(object sender, EventArgs e)
        {
            WIP.SetPieceDetails("wr" + wrUpDown.Value);
        }

        private void SwitchBtn_Click_1(object sender, EventArgs e)
        {
            PiecePanel.Visible = false;
            OptionsPanel.Visible = true;
        }

        private void SwitchBtnOptions_Click(object sender, EventArgs e)
        {
            PiecePanel.Visible = true;
            OptionsPanel.Visible = false;
        }

        private void SwitchBtn_Click_2(object sender, EventArgs e)
        {
            PiecePanel.Visible = false;
            OptionsPanel.Visible = true;
        }

        private string ConvertCurrentAngleDetails()
        {
            string save = "";
            if (pointCb.Checked == false)
            {
                if (joins.Count == 0)
                {
                    save += ";";
                }
                else
                {
                    // Lines
                    for (int index = 0; index < joins.Count - 1; index++)
                    {
                        save += joins[index] + ",";
                    }
                    save += joins[joins.Count - 1] + ";";

                    // Solid
                    for (int index = 0; index < solid.Count - 1; index++)
                    {
                        save += solid[index] + ",";
                    }
                    save += solid[solid.Count - 1];
                }
            }
            return save;
        }

        private void AddPoint(int x, int y)
        {
            // ADD WARNING MESSAGE ABOUT ERASING ROTATION/TURN ANGLES ** TO DO
            rotated.Clear();
            turned.Clear();
            PointsLb.Items.Add(x + "," + y);
            joins.Add("line");
            solid.Add("s");
            DrawPoints();
        }

        private List<double[]> ConvertPieceDataToAnglesList(double[,] input)
        {
            List<double[]> converted = new List<double[]>();
            for (int index = 0; index < input.Length / 2; index++)
            {
                double[] line = new double[2];
                line[0] = input[index, 0];
                line[1] = input[index, 1];
                converted.Add(line);
            }
            return converted;
        }


        /// <summary>
        /// Searches for an existing instance of original at the current rFromUpDown and tFromUpDown points.
        /// If it finds one, sets original to those points.
        /// Does not include clearing original, does reset PointLb.
        /// </summary>
        private void ResetOriginal()
        {
            if (WIP.FindRow((double)rFromUpDown.Value, (double)tFromUpDown.Value) != -1 && WIP.FindRow((double)rFromUpDown.Value, (double)tFromUpDown.Value) != WIP.GetData().Count - 1)
            {
                WIP.SetRotation((double)rFromUpDown.Value);
                WIP.SetTurn((double)tFromUpDown.Value);
                original.AddRange(ConvertPieceDataToAnglesList(WIP.GetCurrentPoints(true, false)));
                FillListbox(original);
            }
            FillListbox(original);
        }



    }
}
