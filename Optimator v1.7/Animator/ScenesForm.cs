using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
        private List<Piece> piecesList = new List<Piece>();     // Contains ALL pieces, INCLUDING sets (Lone pieces found with piece.GetIsAttached() )
        private List<Set> setList = new List<Set>();            // Contains sets ONLY for saving purposes
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
                setList.Add(new Set(NameTb.Text));
                piecesList.AddRange(setList[setList.Count - 1].PiecesList);
                selected = setList[setList.Count - 1].BasePiece;

                // Set Originals
                foreach (Piece piece in setList[setList.Count - 1].PiecesList)
                {
                    piece.Originally = new Originals(piece);
                }

                // Draw the Piece on the Scene
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

            // TEMP **
            SceneNumber.Text = workingFrame.ToString();
        }

        /// <summary>
        /// Returns to the previous frame of the animation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            if (workingFrame > 0)
            {
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

                // TEMP **
                SceneNumber.Text = workingFrame.ToString();
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
            // Save as a Scene
            bool doEet = true;
            DialogResult result = MessageBox.Show("Do you want to save this scene?", "Save Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                doEet = false;
            }

            if (doEet)
            {
                try
                {
                    // Save Data
                    List<string> file = new List<string>();

                    // Save FPS & Number of Frames (Line 1)
                    file.Add(FpsUpDown.Value + ";" + numFrames);

                    // Save Parts
                    for (int index = 0; index < piecesList.Count; index++)
                    {
                        piecesList[index].SceneIndex = index;

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

                    // Write Original States Notifier
                    file.Add("Originals");

                    // Save Original States
                    foreach (Piece piece in piecesList)
                    {
                        file.Add(piece.Originally != null ? piece.SceneIndex + ";" + piece.Originally.GetSaveData()
                            : piece.SceneIndex + ";500;250;0;0;0;100");    // This should never be needed- JIC

                    }

                    // Save Animation Changes
                    foreach (Change change in changes)
                    {
                        file.Add(change.StartFrame + ";" + change.Action + ";" +
                            change.AffectedPiece.SceneIndex + ";" + change.HowMuch + ";" + change.HowLong);
                    }

                    // Write to File
                    Utilities.SaveData(Environment.CurrentDirectory + Constants.ScenesFolder + SceneNameTb.Text + Constants.Txt, file);

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



        // ----- NEEDS UPDATING -----

        // Should be run on click of screen
        /*
        private void PartsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RotationUpDown.Value = (decimal)selected.R;
            TurnUpDown.Value = (decimal)selected.T;
            SpinUpDown.Value = (decimal)selected.S;
            XUpDown.Value = (decimal)selected.X;
            YUpDown.Value = (decimal)selected.Y;
            SizeUpDown.Value = (decimal)selected.SM;
            // ** Update outline
            Utilities.DrawPieces(piecesList, g, DrawPanel);
        }*/

        // Should be on delete key press
        /*
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (selected == null) { return; }

            // If piece is involved in set
            if (selected.PieceOf != null)
            {
                DialogResult result = MessageBox.Show("This will delete the entire set. Do you wish to continue?",
                    "Overwrite Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Set deleting = selected.PieceOf;
                    setList.Remove(deleting);
                    foreach (Piece piece in piecesList)
                    {
                        if (piece.PieceOf == deleting)
                        {
                            piecesList.Remove(piece);
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
                piecesList.Remove(selected);
            }

            foreach (Change change in changes)
            {
                if (!piecesList.Contains(change.AffectedPiece))
                {
                    changes.Remove(change);
                }
            }

            selected = null;
            Utilities.DrawPieces(piecesList, g, DrawPanel);
        }*/
    }
}
