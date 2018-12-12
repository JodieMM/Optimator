using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Animator
{
    /// <summary>
    /// Form for creating a scene, indicating how 
    /// pieces and sets should move over time, applying
    /// effects and setting other visual components.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class ScenesForm : Form
    {
        #region Scenes Form Variables
        private Scene WIP = new Scene();
        private decimal videoLength = 0;
        private Graphics g;
        private Piece selected = null;

        private double midX;
        private double midY;
        private decimal timeIncrement = (decimal)0.5;

        private Color button = Color.Khaki;
        private Color pressed = Color.Gold;
        #endregion


        /// <summary>
        /// ScenesForm constructor.
        /// </summary>
        public ScenesForm()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyUp += KeyPress;
            DrawPanel.MouseDown += new MouseEventHandler(DrawPanel_MouseDown);

            midX = DrawPanel.Size.Width / 2;
            midY = DrawPanel.Size.Height / 2;
            g = DrawPanel.CreateGraphics();
        }



        // ----- PARTS TAB -----
        #region Parts Tab

        /// <summary>
        /// Adds the entered piece to the scene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPieceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Piece added = new Piece(NameTb.Text);
                WIP.PiecesList.Add(added);
                added.X = midX; added.Y = midY;
                added.Originally = new Originals(added);
                SelectPiece(added);
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
        /// Adds the entered set to the scene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Set newbie = new Set(NameTb.Text);
                WIP.PiecesList.AddRange(newbie.PiecesList);
                newbie.BasePiece.X = midX; newbie.BasePiece.Y = midY;
                foreach (Piece piece in newbie.PiecesList)
                {
                    piece.Originally = new Originals(piece);
                }
                SelectPiece(newbie.BasePiece);
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
        /// Moves the selected set or piece upwards in position.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpBtn_Click(object sender, EventArgs e)
        {
            if (selected == null) { return; }
            int selectedIndex = WIP.PiecesList.IndexOf(selected);
            if (selectedIndex == -1 || selectedIndex == WIP.PiecesList.Count - 1) { return; }

            // Update piecesList
            WIP.PiecesList[selectedIndex] = WIP.PiecesList[selectedIndex + 1];
            WIP.PiecesList[selectedIndex + 1] = selected;

            DisplayDrawings();
        }

        /// <summary>
        /// Moves the selected set or piece downwards in position.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownBtn_Click(object sender, EventArgs e)
        {
            if (selected == null) { return; }
            int selectedIndex = WIP.PiecesList.IndexOf(selected);
            if (selectedIndex == -1 || selectedIndex == 0) { return; }

            // Update piecesList
            WIP.PiecesList[selectedIndex] = WIP.PiecesList[selectedIndex - 1];
            WIP.PiecesList[selectedIndex - 1] = selected;

            DisplayDrawings();
        }

        /// <summary>
        /// Sets the initial rotation of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotationBar_ValueChanged(object sender, EventArgs e)
        {
            if (selected == null) { return; }

            // Update Piece
            selected.Originally.R = RotationBar.Value;

            if (RotationBar == ActiveControl)
            {
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Sets the initial turn of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TurnBar_ValueChanged(object sender, EventArgs e)
        {
            if (selected == null) { return; }

            // Update Piece
            selected.Originally.T = TurnBar.Value;

            if (TurnBar == ActiveControl)
            {
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Sets the initial spin of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpinBar_ValueChanged(object sender, EventArgs e)
        {
            if (selected == null) { return; }

            // Update Piece
            selected.Originally.S = SpinBar.Value;

            if (SpinBar == ActiveControl)
            {
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Sets the initial X position of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (selected == null) { return; }

            // Update Piece
            selected.Originally.X = (int)XUpDown.Value;

            if (XUpDown == ActiveControl)
            {
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Sets the initial Y position of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (selected == null) { return; }

            // Update Piece
            selected.Originally.Y = (int)YUpDown.Value;

            if (YUpDown == ActiveControl)
            {
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Sets the initial size modifier of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SizeBar_ValueChanged(object sender, EventArgs e)
        {
            if (selected == null) { return; }

            // Update Piece
            selected.Originally.SM = SizeBar.Value;

            if (SizeBar == ActiveControl)
            {
                DisplayDrawings();
            }
        }

        #endregion



        // ----- ANIMATIONS TAB -----

        /// <summary>
        /// Adds a movement/effect to the animations of the scene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAnimationBtn_Click(object sender, EventArgs e)
        {
            if (selected == null || ChangeTypeCb.SelectedIndex == -1 || AnimationAmountTb.Value == 0) { return; }

            WIP.Changes.Add(new Change(CurrentTimeUpDown.Value, ChangeTypeCb.Text, selected, (double)AnimationAmountTb.Value, SecondsUpDown.Value, WIP));
            if (CurrentTimeUpDown.Value + SecondsUpDown.Value > videoLength)
            {
                UpdateVideoLength(CurrentTimeUpDown.Value + SecondsUpDown.Value);
            }

            if (PreviewBtn.BackColor == pressed)
            {
                PreviewBtn_Click(sender, e);
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Shows what the scene will look like with the suggested
        /// change after the change is completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            if (PreviewBtn.BackColor == pressed)
            {
                PreviewBtn.BackColor = button;
                WIP.RunScene(CurrentTimeUpDown.Value);
            }
            else
            {
                if (selected == null || ChangeTypeCb.SelectedIndex == -1 || AnimationAmountTb.Value == 0) { return; }
                PreviewBtn.BackColor = pressed;
                WIP.RunScene(CurrentTimeUpDown.Value + SecondsUpDown.Value);
                Change tempChange = new Change(CurrentTimeUpDown.Value, ChangeTypeCb.Text, selected, (double)AnimationAmountTb.Value, SecondsUpDown.Value, WIP);
                tempChange.Run(CurrentTimeUpDown.Value + SecondsUpDown.Value);
            }
            if (PreviewBtn == ActiveControl)
            {
                Utilities.DrawPieces(WIP.PiecesList, g, DrawPanel);
            }
        }



        // ----- SCENE TAB -----

        /// <summary>
        /// Completes and saves the scene to a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinishSceneBtn_Click(object sender, EventArgs e)
        {
            // Check Name is Valid for Saving
            if (!Constants.PermittedName.IsMatch(NameTb.Text))
            {
                MessageBox.Show("Please choose a valid name for your scene. Name can only include letters and numbers.", "Name Invalid", MessageBoxButtons.OK);
                return;
            }

            // Check name not already in use, or that overriding is okay
            if (File.Exists(Utilities.GetDirectory(Constants.ScenesFolder, NameTb.Text, Constants.Txt)))
            {
                DialogResult result = MessageBox.Show("This name is already in use. Do you want to override the existing scene?", "Override Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) { return; }
            }

            try
            {
                // Save Data
                List<string> file = new List<string>
                {
                    videoLength.ToString()
                };

                // Save Parts
                for (int index = 0; index < WIP.PiecesList.Count; index++)
                {
                    // If piece is in 
                    if (WIP.PiecesList[index].PieceOf != null)
                    {
                        // If piece is base
                        if (WIP.PiecesList[index].AttachedTo == null)
                        {
                            file.Add("s:" + WIP.PiecesList[index].PieceOf.Name);
                        }
                    }
                    else
                    {
                        file.Add("p:" + WIP.PiecesList[index].Name);
                    }
                }

                // Save Original States
                file.Add("Originals");
                foreach (Piece piece in WIP.PiecesList)
                {
                    file.Add(piece.Originally != null ? piece.Originally.GetSaveData() : "500;250;0;0;0;100");
                }

                // Save Animation Changes
                foreach (Change change in WIP.Changes)
                {
                    file.Add(change.StartTime + ";" + change.Action + ";" +
                        WIP.PiecesList.IndexOf(change.AffectedPiece) + ";" + change.HowMuch + ";" + change.HowLong);
                }

                Utilities.SaveData(Utilities.GetDirectory(Constants.ScenesFolder, SceneTb.Text, Constants.Txt), file);
                Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            // If nothing to save, exit without confirmation
            if (WIP.PiecesList.Count == 0)
            {
                Close();
            }
            else
            {
                DialogResult query = MessageBox.Show("Do you wish to exit without saving?", "Exit Confirmation", MessageBoxButtons.YesNo);
                if (query == DialogResult.Yes)
                {
                    Close();
                }
            }
        }



        // ----- SETTINGS TAB -----

        /// <summary>
        /// Hides or shows the preview panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewCb_CheckedChanged(object sender, EventArgs e)
        {
            DisplayPanel.Visible = PreviewCb.Checked;
        }



        // ----- DISPLAY PANEL -----

        /// <summary>
        /// Changes the current working time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentTimeUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (CurrentTimeUpDown.Value > videoLength)
            {
                UpdateVideoLength(CurrentTimeUpDown.Value);
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Updates the code and visuals for the video length.
        /// </summary>
        /// <param name="newTime">The new video length</param>
        private void UpdateVideoLength(decimal newTime)
        {
            videoLength = newTime;
            int hr = (int)Math.Floor(videoLength / 3600);
            int min = (int)Math.Floor((videoLength - hr * 3600) / 60);
            int s = (int)Math.Floor(videoLength - (hr * 3600 + min * 60));
            VidLengthLbl.Text = "Video Length: ";
            if (hr > 0)
            {
                VidLengthLbl.Text += hr + "hrs ";
            }
            if (min > 0)
            {
                VidLengthLbl.Text += min + "mins ";
            }
            VidLengthLbl.Text += s + "s";
        }

        /// <summary>
        /// Progresses to the next frame of the animation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForwardBtn_Click(object sender, EventArgs e)
        {
            CurrentTimeUpDown.Value += timeIncrement;
            if (videoLength < CurrentTimeUpDown.Value)
            {
                videoLength = CurrentTimeUpDown.Value;
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Returns to the previous frame of the animation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            if (CurrentTimeUpDown.Value < timeIncrement) { return; }
            CurrentTimeUpDown.Value -= timeIncrement;
            DisplayDrawings();
        }



        // ----- DRAW PANEL I/O -----
        #region Draw Panel I/O

        /// <summary>
        /// Selects a piece if it is clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // Choose and Update Selected Piece (If Any)
            int selectedIndex = Utilities.FindClickedSelection(WIP.PiecesList, e.X, e.Y);
            if (selectedIndex == -1)
            {
                Deselect();
            }
            else
            {
                SelectPiece(WIP.PiecesList[selectedIndex]);
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Makes the entered piece selected, 
        /// deselecting the old selected if
        /// necessary.
        /// </summary>
        /// <param name="select"></param>
        private void SelectPiece(Piece select)
        {
            Deselect();
            selected = select;
            selected.OutlineColour = Color.Red;
            RotationBar.Value = (int)selected.Originally.R;
            TurnBar.Value = (int)selected.Originally.T;
            SpinBar.Value = (int)selected.Originally.S;
            XUpDown.Value = (decimal)selected.Originally.X;
            YUpDown.Value = (decimal)selected.Originally.Y;
            SizeBar.Value = (int)selected.Originally.SM;
        }

        /// <summary>
        /// Deselects the selected piece, returning
        /// its outline colour to normal.
        /// </summary>
        private void Deselect()
        {
            if (selected != null)
            {
                selected.OutlineColour = selected.Originally.OC;
                selected = null;
            }
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
                // Delete Selected Shape
                case Keys.Delete:
                    if (selected == null) { return; }

                    // If Listbox is highlighted, delete change/animation
                    if (ActiveControl == AnimationLb && AnimationLb.SelectedIndex != -1)
                    {
                        RemoveChangeIndex(AnimationLb.SelectedIndex);
                        AnimationLb.Items.RemoveAt(AnimationLb.SelectedIndex);
                    }
                    // Delete selected piece
                    else
                    {
                        // If piece is involved in set
                        if (selected.PieceOf != null)
                        {
                            DialogResult result = MessageBox.Show("This will delete the entire set. Do you wish to continue?",
                                "Overwrite Confirmation", MessageBoxButtons.YesNo);
                            if (result == DialogResult.No) { return; }

                            Set deleting = selected.PieceOf;
                            foreach (Piece piece in deleting.PiecesList)
                            {
                                WIP.PiecesList.Remove(piece);
                            }
                        }
                        // Piece is lone
                        else
                        {
                            WIP.PiecesList.Remove(selected);
                        }

                        // Update changes to remove those made redundant by deleting a piece/set
                        foreach (Change change in WIP.Changes)
                        {
                            if (!WIP.PiecesList.Contains(change.AffectedPiece))
                            {
                                WIP.Changes.Remove(change);
                            }
                        }
                        selected = null;
                    }
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
        /// Draws the relevant scene to the screen.
        /// </summary>
        private void DisplayDrawings()
        {
            // Past Preview
            if (CurrentTimeUpDown.Value < timeIncrement && PreviewCb.Checked)
            {
                PastPreviewBox.BackColor = Color.PaleGoldenrod;
            }
            else
            {
                PastPreviewBox.BackColor = Color.White;
                WIP.RunScene(CurrentTimeUpDown.Value - timeIncrement);
                Utilities.DrawPieces(WIP.PiecesList, g, PastPreviewBox, 3/11.0F);
            }

            // Draw Panel (Current)
            WIP.RunScene(CurrentTimeUpDown.Value);
            Utilities.DrawPieces(WIP.PiecesList, g, DrawPanel);

            // Preview Panels (Future, Future++)
            if (PreviewCb.Checked)
            {
                WIP.RunScene(CurrentTimeUpDown.Value + timeIncrement);
                Utilities.DrawPieces(WIP.PiecesList, g, FuturePreviewBox, 3 / 11.0F);
                WIP.RunScene(CurrentTimeUpDown.Value + 2 * timeIncrement);
                Utilities.DrawPieces(WIP.PiecesList, g, Future2PreviewBox, 3 / 11.0F);
            }

            // Update Animation listbox
            AnimationLb.Items.Clear();
            AnimationLb.Items.Add("Piece: Action: How Much: Start");
            List<string> back = new List<string>();
            foreach (Change change in WIP.Changes)
            {
                string summary = "";
                if (change.AffectedPiece.PieceOf != null)
                {
                    summary += change.AffectedPiece.AttachedTo != null ? "** " : "* ";
                }
                summary += change.AffectedPiece.Name + " :" + change.Action + " :" + 
                    change.HowMuch.ToString() + " :" + change.StartTime.ToString();

                if (CurrentTimeUpDown.Value >= change.StartTime && CurrentTimeUpDown.Value <= change.StartTime + change.HowLong)
                {
                    AnimationLb.Items.Add(summary);
                }
                else
                {
                    back.Add(summary);
                }
            }
            foreach (string summary in back)
            {
                AnimationLb.Items.Add(summary);
            }
        }

        /// <summary>
        /// Removes the change at the entered
        /// AnimationLb index.
        /// </summary>
        /// <param name="index"></param>
        private void RemoveChangeIndex(int index)
        {
            int counter = 0;
            // Search Running Changes
            foreach (Change change in WIP.Changes)
            {
                if (CurrentTimeUpDown.Value >= change.StartTime && CurrentTimeUpDown.Value <= change.StartTime + change.HowLong)
                {
                    if (counter == index)
                    {
                        WIP.Changes.Remove(change);
                        return;
                    }
                    counter++;
                }
            }
            // Search Back Changes
            foreach (Change change in WIP.Changes)
            {
                if (!(CurrentTimeUpDown.Value >= change.StartTime) || !(CurrentTimeUpDown.Value <= change.StartTime + change.HowLong))
                {
                    if (counter == index)
                    {
                        WIP.Changes.Remove(change);
                        return;
                    }
                    counter++;
                }
            }
        }
    }
}