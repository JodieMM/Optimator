using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

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
        private List<Piece> piecesList = new List<Piece>();
        private List<Change> changes = new List<Change>();

        private int numFrames = 1;
        private int workingFrame = 0;

        private Graphics g;
        private Piece selected = null;
        #endregion


        /// <summary>
        /// ScenesForm constructor.
        /// </summary>
        public ScenesForm()
        {
            InitializeComponent();
            DrawPanel.KeyDown += KeyPress;
            DrawPanel.MouseDown += new MouseEventHandler(DrawPanel_MouseDown);
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
                piecesList.Add(new Piece(NameTb.Text));
                piecesList[piecesList.Count - 1].Originally = new Originals(piecesList[piecesList.Count - 1]);
                selected = piecesList[piecesList.Count - 1];

                Utilities.DrawPieces(piecesList, g, DrawPanel);
            }
            catch (System.IO.FileNotFoundException)
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
                piecesList.AddRange(newbie.PiecesList);
                selected = newbie.BasePiece;

                // Set Originals
                foreach (Piece piece in newbie.PiecesList)
                {
                    piece.Originally = new Originals(piece);
                }

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
        /// Moves the selected set or piece upwards in position.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpBtn_Click(object sender, EventArgs e)
        {
            if (selected == null) { return; }
            int selectedIndex = piecesList.IndexOf(selected);
            if (selectedIndex == -1 || selectedIndex == piecesList.Count - 1) { return; }

            // Update piecesList
            piecesList[selectedIndex] = piecesList[selectedIndex + 1];
            piecesList[selectedIndex + 1] = selected;

            Utilities.DrawPieces(piecesList, g, DrawPanel);
        }

        /// <summary>
        /// Moves the selected set or piece downwards in position.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownBtn_Click(object sender, EventArgs e)
        {
            if (selected == null) { return; }
            int selectedIndex = piecesList.IndexOf(selected);
            if (selectedIndex == -1 || selectedIndex == 0) { return; }

            // Update piecesList
            piecesList[selectedIndex] = piecesList[selectedIndex - 1];
            piecesList[selectedIndex - 1] = selected;

            Utilities.DrawPieces(piecesList, g, DrawPanel);
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

            Utilities.DrawPieces(piecesList, g, DrawPanel);
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

            Utilities.DrawPieces(piecesList, g, DrawPanel);
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

            Utilities.DrawPieces(piecesList, g, DrawPanel);
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

            Utilities.DrawPieces(piecesList, g, DrawPanel);
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

            Utilities.DrawPieces(piecesList, g, DrawPanel);
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

            Utilities.DrawPieces(piecesList, g, DrawPanel);
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
            if (selected == null) { return; }

            changes.Add(new Change(workingFrame, ChangeTypeCb.Text, selected, (double)AnimationAmountTb.Value, (int)FrameLengthUpDown.Value));
            UpdateAnimationListbox();
        }

        /// <summary>
        /// Updates the animation listbox to show all current animations.
        /// </summary>
        private void UpdateAnimationListbox()
        {
            AnimationLb.Items.Clear();
            foreach (Change change in changes)
            {
                if (workingFrame >= change.StartFrame && workingFrame <= change.StartFrame + change.HowLong - 1)
                {
                    string summary = "";
                    if (change.AffectedPiece.PieceOf != null)
                    {
                        summary += change.AffectedPiece.AttachedTo != null ? "** " : "* ";
                    }

                    summary += change.Action + " : " + change.AffectedPiece.Name + " : " + change.HowMuch.ToString()
                        + " : " + (change.HowLong - (workingFrame - change.StartFrame)).ToString();

                    AnimationLb.Items.Add(summary);
                }
            }
        }

        /// <summary>
        /// Progresses to the next frame of the animation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextFrameBtn_Click(object sender, EventArgs e)
        {
            foreach (Change change in changes)
            {
                if (workingFrame >= change.StartFrame && workingFrame <= change.StartFrame + change.HowLong - 1)
                {
                    change.Run(true);
                }
            }

            Utilities.DrawPieces(piecesList, g, DrawPanel);

            // If new, create new frame
            if (numFrames - 1 == workingFrame) { numFrames++; }

            workingFrame++;
            UpdateAnimationListbox();
            SceneNumber.Text = workingFrame.ToString();
        }

        /// <summary>
        /// Returns to the previous frame of the animation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            if (workingFrame <= 0) { return; }

            foreach (Change change in changes)
            {
                if (workingFrame >= change.StartFrame + 1 && workingFrame <= change.StartFrame + change.HowLong)
                {
                    change.Run(false);
                }
            }

            Utilities.DrawPieces(piecesList, g, DrawPanel);

            workingFrame--;
            UpdateAnimationListbox();
            SceneNumber.Text = workingFrame.ToString();
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
            if (Constants.InvalidNames.Contains(NameTb.Text) || !Constants.PermittedName.IsMatch(NameTb.Text))
            {
                MessageBox.Show("Please choose a valid name for your piece. Name can only include letters and numbers.", "Name Invalid", MessageBoxButtons.OK);
            }
            else if (Constants.ReservedNames.Contains(NameTb.Text))
            {
                MessageBox.Show("This name is reserved. Please choose a new name for your piece.", "Name Reserved", MessageBoxButtons.OK);
            }
            // Name is Valid
            else
            {
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
                        // Save FPS & Number of Frames (Line 1)
                        FpsUpDown.Value + ";" + numFrames
                    };

                    // Save Parts
                    for (int index = 0; index < piecesList.Count; index++)
                    {
                        // If piece is in 
                        if (piecesList[index].PieceOf != null)
                        {
                            // If piece is base
                            if (piecesList[index].AttachedTo == null)
                            {
                                file.Add("s:" + piecesList[index].PieceOf.Name);
                            }
                        }
                        else
                        {
                            file.Add("p:" + piecesList[index].Name);
                        }
                    }

                    // Save Original States
                    file.Add("Originals");
                    foreach (Piece piece in piecesList)
                    {
                        file.Add(piece.Originally != null ? ";" + piece.Originally.GetSaveData() : ";500;250;0;0;0;100");
                    }

                    // Save Animation Changes
                    foreach (Change change in changes)
                    {
                        file.Add(change.StartFrame + ";" + change.Action + ";" +
                            piecesList.IndexOf(change.AffectedPiece) + ";" + change.HowMuch + ";" + change.HowLong);
                    }

                    Utilities.SaveData(Environment.CurrentDirectory + Constants.ScenesFolder + SceneNameTb.Text + Constants.Txt, file);
                    Close();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            if (piecesList.Count == 0) { Close(); return; } // If nothing to save, exit without confirmation
            DialogResult query = MessageBox.Show("Do you wish to exit without saving?", "Exit Confirmation", MessageBoxButtons.YesNo);
            if (query == DialogResult.Yes) { Close(); }
        }



        // ----- DRAW PANEL I/O -----

        /// <summary>
        /// Selects a piece if it is clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // Update old selected outline
            if (selected != null) { selected.OutlineColour = selected.Originally.OC; }

            // Choose and Update Selected Piece (If Any)
            int selectedIndex = Utilities.FindClickedSelection(piecesList, e.X, e.Y);
            if (selectedIndex == -1) { return; }
            selected = piecesList[selectedIndex];
            selected.OutlineColour = Color.Red;

            // Update UI
            RotationUpDown.Value = (decimal)selected.R;
            TurnUpDown.Value = (decimal)selected.T;
            SpinUpDown.Value = (decimal)selected.S;
            XUpDown.Value = (decimal)selected.X;
            YUpDown.Value = (decimal)selected.Y;
            SizeUpDown.Value = (decimal)selected.SM;

            Utilities.DrawPieces(piecesList, g, DrawPanel);
        }

        /// <summary>
        /// Runs when a key is pressed.
        /// If delete is pressed and a piece is selected, it will be deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void KeyPress(object sender, KeyEventArgs e)
        {
            // Delete selected shape
            if (e.KeyCode == Keys.Delete)
            {
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
                        piecesList.Remove(piece);
                    }
                }
                else // Piece is lone
                {
                    piecesList.Remove(selected);
                }

                // Update changes to remove those made redundant by deleting a piece/set
                foreach (Change change in changes)
                {
                    if (!piecesList.Contains(change.AffectedPiece))
                    {
                        changes.Remove(change);
                    }
                }

                selected = null;
                Utilities.DrawPieces(piecesList, g, DrawPanel);
            }
        }
    }
}
