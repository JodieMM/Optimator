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
        private Part selected = null;
        private Graphics g;

        private decimal videoLength = 0;
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
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Part newbie;
                if (sender == AddPieceBtn)
                {
                    newbie = new Piece(NameTb.Text);
                    newbie.ToPiece().X = midX; newbie.ToPiece().Y = midY;
                    newbie.ToPiece().Originally = new Originals(newbie.ToPiece());
                }
                else
                {
                    newbie = new Set(NameTb.Text);
                    newbie.ToPiece().X = midX; newbie.ToPiece().Y = midY;
                    foreach (Piece piece in newbie.ToSet().PiecesList)
                    {
                        piece.Originally = new Originals(piece);
                    }
                }
                WIP.PartsList.Add(newbie);
                SelectPart(newbie);
                WIP.UpdatePiecesList();
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
            int selectedIndex = WIP.PartsList.IndexOf(selected);
            if (selectedIndex == -1 || selectedIndex == WIP.PartsList.Count - 1) { return; }

            // Update PartsList
            WIP.PartsList[selectedIndex] = WIP.PartsList[selectedIndex + 1];
            WIP.PartsList[selectedIndex + 1] = selected;

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
            int selectedIndex = WIP.PartsList.IndexOf(selected);
            if (selectedIndex == -1 || selectedIndex == 0) { return; }

            // Update PartsList
            WIP.PartsList[selectedIndex] = WIP.PartsList[selectedIndex - 1];
            WIP.PartsList[selectedIndex - 1] = selected;

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
            selected.ToPiece().Originally.R = RotationBar.Value;

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
            selected.ToPiece().Originally.T = TurnBar.Value;

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
            selected.ToPiece().Originally.S = SpinBar.Value;

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
            selected.ToPiece().Originally.X = (int)XUpDown.Value;

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
            selected.ToPiece().Originally.Y = (int)YUpDown.Value;

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
            selected.ToPiece().Originally.SM = SizeBar.Value;

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

            // Adds new change to scene
            WIP.Changes.Add(new Change(CurrentTimeUpDown.Value, ChangeTypeCb.Text, selected.ToPiece(), (double)AnimationAmountTb.Value, SecondsUpDown.Value, WIP));
            if (CurrentTimeUpDown.Value + SecondsUpDown.Value > videoLength)
            {
                UpdateVideoLength(CurrentTimeUpDown.Value + SecondsUpDown.Value);
            }

            // Displays previews if previews are on
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
                Change tempChange = new Change(CurrentTimeUpDown.Value, ChangeTypeCb.Text, selected.ToPiece(), (double)AnimationAmountTb.Value, SecondsUpDown.Value, WIP);
                tempChange.Run(CurrentTimeUpDown.Value + SecondsUpDown.Value);
            }
            if (PreviewBtn == ActiveControl)
            {
                Visuals.ResetPictureBox(g, DrawPanel);
                Visuals.DrawParts(WIP.PartsList, g);
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
                foreach (Part part in WIP.PartsList)
                {
                    file.Add((part is Piece ? "p:" : "s:") + part.Name);
                }

                // Save Original States
                file.Add("Originals");
                foreach (Piece piece in WIP.PiecesList)
                {
                    file.Add(piece.Originally != null ? piece.Originally.GetSaveData() : Constants.MidX + ";" + Constants.MidY + ";0;0;0;100");
                }

                // Save Animation Changes
                foreach (Change change in WIP.Changes)
                {
                    file.Add(change.ToString());
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
            if (WIP.PartsList.Count == 0)
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

        /// <summary>
        /// Changes the time between preview frames.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeIncrementUpDown_ValueChanged(object sender, EventArgs e)
        {
            timeIncrement = TimeIncrementUpDown.Value;
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
            int selectedIndex = Utilities.FindClickedSelection(WIP.PiecesList, e.X, e.Y, SelectFromTopCb.Checked);
            if (selectedIndex == -1)
            {
                Deselect();
            }
            else
            {
                SelectPart(WIP.PiecesList[selectedIndex]);
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Makes the entered part selected, 
        /// deselecting the old selected if necessary.
        /// </summary>
        /// <param name="select"></param>
        private void SelectPart(Part select)
        {
            Deselect();
            selected = select;
            selected.ToPiece().OutlineColour = (selected is Piece) ? Color.Red : Color.Purple;
            RotationBar.Value = (int)selected.ToPiece().Originally.R;
            TurnBar.Value = (int)selected.ToPiece().Originally.T;
            SpinBar.Value = (int)selected.ToPiece().Originally.S;
            XUpDown.Value = (decimal)selected.ToPiece().Originally.X;
            YUpDown.Value = (decimal)selected.ToPiece().Originally.Y;
            SizeBar.Value = (int)selected.ToPiece().Originally.SM;
        }

        /// <summary>
        /// Deselects the selected piece, returning
        /// its outline colour to normal.
        /// </summary>
        private void Deselect()
        {
            if (selected != null)
            {
                selected.ToPiece().OutlineColour = selected.ToPiece().Originally.OC;
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
                        if (selected.ToPiece().PieceOf != null)
                        {
                            DialogResult result = MessageBox.Show("This will delete the entire set. Do you wish to continue?",
                                "Overwrite Confirmation", MessageBoxButtons.YesNo);
                            if (result == DialogResult.No) { return; }

                            Set deleting = selected.ToPiece().PieceOf;
                            foreach (Piece piece in deleting.PiecesList)
                            {
                                WIP.PartsList.Remove(piece);
                            }
                        }
                        // Piece is lone
                        else
                        {
                            WIP.PartsList.Remove(selected);
                            WIP.PiecesList.Remove(selected.ToPiece());
                        }

                        // Update changes to remove those made redundant by deleting a piece/set
                        foreach (Change change in WIP.Changes)
                        {
                            if (!WIP.PartsList.Contains(change.AffectedPiece))
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
            LoadingForm loading = new LoadingForm();
            loading.Show();
            Application.DoEvents();

            // Past Preview
            if (CurrentTimeUpDown.Value < timeIncrement && PreviewCb.Checked)
            {
                PastPreviewBox.BackColor = Color.PaleGoldenrod;
            }
            else
            {
                PastPreviewBox.BackColor = Color.White;
                WIP.RunScene(CurrentTimeUpDown.Value - timeIncrement);
                Visuals.DrawPartsScaled(WIP.PartsList, g, PastPreviewBox, 3/11.0F);
            }

            // Draw Panel (Current)
            WIP.RunScene(CurrentTimeUpDown.Value);
            Visuals.ResetPictureBox(g, DrawPanel);
            Visuals.DrawParts(WIP.PartsList, g);

            // Preview Panels (Future, Future++)
            if (PreviewCb.Checked)
            {
                WIP.RunScene(CurrentTimeUpDown.Value + timeIncrement);
                Visuals.DrawPartsScaled(WIP.PartsList, g, FuturePreviewBox, 3 / 11.0F);
                WIP.RunScene(CurrentTimeUpDown.Value + 2 * timeIncrement);
                Visuals.DrawPartsScaled(WIP.PartsList, g, Future2PreviewBox, 3 / 11.0F);
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

            loading.Close();
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