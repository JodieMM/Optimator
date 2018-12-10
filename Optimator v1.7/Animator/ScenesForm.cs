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

        private decimal timeLength = 0;
        private decimal workingTime = 0;

        private Graphics g;
        private Piece selected = null;

        private double midX;
        private double midY;
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
                // Add piece to lists
                WIP.PiecesList.Add(new Piece(NameTb.Text));
                WIP.PiecesList[WIP.PiecesList.Count - 1].X = midX; WIP.PiecesList[WIP.PiecesList.Count - 1].Y = midY;
                WIP.PiecesList[WIP.PiecesList.Count - 1].Originally = new Originals(WIP.PiecesList[WIP.PiecesList.Count - 1]);
                selected = WIP.PiecesList[WIP.PiecesList.Count - 1];

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
                // Add pieces to lists
                Set newbie = new Set(NameTb.Text);
                WIP.PiecesList.AddRange(newbie.PiecesList);
                selected = newbie.BasePiece;
                selected.X = midX; selected.Y = midY;

                // Set Originals
                foreach (Piece piece in newbie.PiecesList)
                {
                    piece.Originally = new Originals(piece);
                }

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
        private void RotationUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (selected == null) { return; }

            // Check for Overflow
            if (RotationUpDown.Value == 360) { RotationUpDown.Value = 0; }
            else if (RotationUpDown.Value == -1) { RotationUpDown.Value = 359; }

            // Update Piece
            selected.Originally.R = (double)RotationUpDown.Value;

            DisplayDrawings();
        }

        /// <summary>
        /// Sets the initial turn of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TurnUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (selected == null) { return; }

            // Check for Overflow
            if (TurnUpDown.Value == 360) { TurnUpDown.Value = 0; }
            else if (TurnUpDown.Value == -1) { TurnUpDown.Value = 359; }

            // Update Piece
            selected.Originally.T = (int)TurnUpDown.Value;

            DisplayDrawings();
        }

        /// <summary>
        /// Sets the initial spin of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpinUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (selected == null) { return; }

            // Check for Overflow
            if (SpinUpDown.Value == 360) { SpinUpDown.Value = 0; }
            else if (SpinUpDown.Value == -1) { SpinUpDown.Value = 359; }

            // Update Piece
            selected.Originally.S = (int)SpinUpDown.Value;

            DisplayDrawings();
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

            DisplayDrawings();
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

            DisplayDrawings();
        }

        /// <summary>
        /// Sets the initial size modifier of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (selected == null) { return; }

            // Update Piece
            selected.Originally.SM = (int)SizeUpDown.Value;

            DisplayDrawings();
        }

        #endregion



        // ----- ANIMATIONS TAB -----

        /// <summary>
        /// Selects a change for modification.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ** TO DO
        }

        /// <summary>
        /// Adds a movement/effect to the animations of the scene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAnimationBtn_Click(object sender, EventArgs e)
        {
            if (selected == null) { return; }

            WIP.Changes.Add(new Change(workingTime, ChangeTypeCb.Text, selected, (double)AnimationAmountTb.Value, (int)SecondsUpDown.Value, WIP));
            UpdateAnimationListbox();
        }

        /// <summary>
        /// Shows what the scene will look like with the suggested
        /// change after the change is completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Hover(object sender, EventArgs e)
        {
            // ** TO DO
        }

        /// <summary>
        /// Updates the animation listbox to show all current animations.
        /// </summary>
        private void UpdateAnimationListbox()
        {
            AnimationLb.Items.Clear();
            foreach (Change change in WIP.Changes)
            {
                if (workingTime >= change.StartTime && workingTime <= change.StartTime + change.HowLong)
                {
                    string summary = "";
                    if (change.AffectedPiece.PieceOf != null)
                    {
                        summary += change.AffectedPiece.AttachedTo != null ? "** " : "* ";
                    }

                    summary += change.Action + " : " + change.AffectedPiece.Name + " : " + change.HowMuch.ToString()
                        + " : " + (change.HowLong - (workingTime - change.StartTime)).ToString();

                    AnimationLb.Items.Add(summary);
                }
            }
        }

        /// <summary>
        /// Updates what attribute is changing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ** TO DO
        }

        /// <summary>
        /// Updates how much the selected item will change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationAmountTb_ValueChanged(object sender, EventArgs e)
        {
            // ** TO DO
        }

        /// <summary>
        /// Updates how long the change will take affect.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecondsUpDown_ValueChanged(object sender, EventArgs e)
        {
            // ** TO DO
        }



        // ----- DISPLAY PANEL -----

        /// <summary>
        /// Changes the current working time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentTimeUpDown_ValueChanged(object sender, EventArgs e)
        {
            workingTime = CurrentTimeUpDown.Value;
        }

        /// <summary>
        /// Progresses to the next frame of the animation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForwardBtn_Click(object sender, EventArgs e)
        {
            workingTime += (decimal)0.5;
            CurrentTimeUpDown.Value = workingTime;
            if (timeLength < workingTime) { timeLength = workingTime; }

            // Run Changes
            foreach (Change change in WIP.Changes)
            {
                change.Run(true, workingTime);
            }
            DisplayDrawings();
            UpdateAnimationListbox();
        }

        /// <summary>
        /// Returns to the previous frame of the animation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            if (workingTime < (decimal)0.5) { return; }
            workingTime -= (decimal)0.5;
            CurrentTimeUpDown.Value = workingTime;

            // Undo Changes
            foreach (Change change in WIP.Changes)
            {
                change.Run(false, workingTime);
            }
            DisplayDrawings();
            UpdateAnimationListbox();
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
                MessageBox.Show("Please choose a valid name for your piece. Name can only include letters and numbers.", "Name Invalid", MessageBoxButtons.OK);
            }

            // Check name not already in use, or that overriding is okay
            DialogResult result = DialogResult.Yes;
            if (File.Exists(Utilities.GetDirectory(Constants.PiecesFolder, NameTb.Text)))
            {
                result = MessageBox.Show("This name is already in use. Do you want to override the existing piece?", "Override Confirmation", MessageBoxButtons.YesNo);
            }
            if (result == DialogResult.No) { return; }

            try
            {
                // Save Data
                List<string> file = new List<string>
                {
                    timeLength.ToString()
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

                Utilities.SaveData(Environment.CurrentDirectory + Constants.ScenesFolder + SceneTb.Text + Constants.Txt, file);
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
            if (WIP.PiecesList.Count == 0) { Close(); return; } // If nothing to save, exit without confirmation
            DialogResult query = MessageBox.Show("Do you wish to exit without saving?", "Exit Confirmation", MessageBoxButtons.YesNo);
            if (query == DialogResult.Yes) { Close(); }
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
            RotationUpDown.Value = (decimal)selected.R;
            TurnUpDown.Value = (decimal)selected.T;
            SpinUpDown.Value = (decimal)selected.S;
            XUpDown.Value = (decimal)selected.X;
            YUpDown.Value = (decimal)selected.Y;
            SizeUpDown.Value = (decimal)selected.SM;
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
                    DisplayDrawings();
                    break;

                // Do nothing for any other key
                default:
                    break;
            }
        }

        #endregion



        // ----- OTHER FUNTCIONS -----

        /// <summary>
        /// Draws the relevant scene to the screen.
        /// </summary>
        private void DisplayDrawings()
        {
            Utilities.DrawPieces(WIP.PiecesList, g, DrawPanel);
        }
    }
}
