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
                Part loaded;
                if (sender == AddPieceBtn)
                {
                    loaded = new Piece(NameTb.Text);
                    loaded.ToPiece().SetCoordsAsMid(DrawPanel);
                    loaded.ToPiece().Originally = new Originals(loaded.ToPiece());
                }
                else
                {
                    loaded = new Set(NameTb.Text);
                    loaded.ToPiece().SetCoordsAsMid(DrawPanel);
                    foreach (Piece piece in loaded.ToSet().PiecesList)
                        piece.Originally = new Originals(piece);
                }
                WIP.PartsList.Add(loaded);
                SelectPart(loaded);
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
        /// Reacts to UI elements to update the selected piece.
        /// </summary>
        /// <param name="sender">Modified UI element</param>
        /// <param name="e"></param>
        private void UpdateSelectedPiece(object sender, EventArgs e)
        {
            if (selected == null) { return; }
            if (sender == RotationBar)
            {
                selected.ToPiece().Originally.R = RotationBar.Value;
            }
            else if (sender == TurnBar)
            {
                selected.ToPiece().Originally.T = TurnBar.Value;
            }
            else if (sender == SpinBar)
            {
                selected.ToPiece().Originally.S = SpinBar.Value;
            }
            else if (sender == XUpDown)
            {
                selected.ToPiece().Originally.X = (int)XUpDown.Value;
            }
            else if (sender == YUpDown)
            {
                selected.ToPiece().Originally.Y = (int)YUpDown.Value;
            }
            else if (sender == SizeBar)
            {
                selected.ToPiece().Originally.SM = SizeBar.Value;
            }
            if (sender == ActiveControl) { DisplayDrawings(); }
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
            if (CurrentTimeUpDown.Value + SecondsUpDown.Value > WIP.TimeLength)
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
                Visuals.DrawParts(WIP.PartsList, g, DrawPanel);
        }



        // ----- SCENE TAB -----

        /// <summary>
        /// Completes and saves the scene to a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinishSceneBtn_Click(object sender, EventArgs e)
        {
            if (!Utilities.CheckValidNewName(NameTb.Text, Constants.ScenesFolder)) { return; }            
            try
            {
                Utilities.SaveData(Utilities.GetDirectory(Constants.ScenesFolder, SceneTb.Text, Constants.Txt), WIP.GetData());
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
            if (Utilities.ExitBtn_Click(WIP.PartsList.Count > 0)) { Close(); }
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
            if (CurrentTimeUpDown.Value > WIP.TimeLength)
                UpdateVideoLength(CurrentTimeUpDown.Value);

            DisplayDrawings();
        }

        /// <summary>
        /// Updates the code and visuals for the video length.
        /// </summary>
        /// <param name="newTime">The new video length</param>
        private void UpdateVideoLength(decimal newTime)
        {
            WIP.TimeLength = newTime;
            int hr = (int)Math.Floor(WIP.TimeLength / 3600);
            int min = (int)Math.Floor((WIP.TimeLength - hr * 3600) / 60);
            int s = (int)Math.Floor(WIP.TimeLength - (hr * 3600 + min * 60));
            VidLengthLbl.Text = "Video Length: ";
            if (hr > 0)
                VidLengthLbl.Text += hr + "hrs ";
            if (min > 0)
                VidLengthLbl.Text += min + "mins ";
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
            if (WIP.TimeLength < CurrentTimeUpDown.Value)
                WIP.TimeLength = CurrentTimeUpDown.Value;

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
                Deselect();

            else
                SelectPart(WIP.PiecesList[selectedIndex]);

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
                                WIP.PartsList.Remove(piece);
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
                                WIP.Changes.Remove(change);
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
                PastPreviewBox.BackColor = Color.PaleGoldenrod;
            else
            {
                PastPreviewBox.BackColor = Color.White;
                WIP.RunScene(CurrentTimeUpDown.Value - timeIncrement);
                Visuals.DrawPartsScaled(WIP.PartsList, g, PastPreviewBox, 3/11.0F);
            }

            // Draw Panel (Current)
            WIP.RunScene(CurrentTimeUpDown.Value);
            Visuals.DrawParts(WIP.PartsList, g, DrawPanel);

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
                    summary += change.AffectedPiece.AttachedTo != null ? "** " : "* ";

                summary += change.AffectedPiece.Name + " :" + change.Action + " :" + 
                    change.HowMuch.ToString() + " :" + change.StartTime.ToString();

                if (CurrentTimeUpDown.Value >= change.StartTime && CurrentTimeUpDown.Value <= change.StartTime + change.HowLong)
                    AnimationLb.Items.Add(summary);
                else
                    back.Add(summary);
            }
            foreach (string summary in back)
                AnimationLb.Items.Add(summary);

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