﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Animator
{
    /// <summary>
    /// The form for building sets.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class SetsForm : Form
    {
        #region Sets Form Variables
        private Graphics g;
        private List<Piece> piecesList = new List<Piece>();
        private Set WIP = new Set();

        private Piece selected = null;
        private Join selectedSpot = null;
        private Color selectedOC;
        private Piece shadow = null;
        private bool moving = false;
        private bool movingFar = false;
        private int[] originalMoving;
        private int[] positionMoving;
        #endregion


        /// <summary>
        /// SetsForm constructor.
        /// </summary>
        public SetsForm()
        {
            InitializeComponent();
            DrawPanel.KeyDown += KeyPress;
            DrawPanel.MouseDown += new MouseEventHandler(DrawPanel_MouseDown);
            DrawPanel.MouseMove += new MouseEventHandler(DrawPanel_MouseMove);
            DrawPanel.MouseUp += new MouseEventHandler(DrawPanel_MouseUp);
        }



        // ----- SET TAB -----

        /// <summary>
        /// Adds a piece to the set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPieceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Piece justAdded = new Piece(AddTb.Text);
                piecesList.Add(justAdded);
                justAdded.X = DrawPanel.Width / 2.0; justAdded.Y = DrawPanel.Height / 2.0;
                justAdded.Originally = new Originals(justAdded);
                justAdded.FindPointSpots();
                SelectPiece(justAdded);
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
        /// Adds a set to the set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Set addedSet = new Set(AddTb.Text);
                piecesList.AddRange(addedSet.PiecesList);
                addedSet.BasePiece.X = DrawPanel.Width / 2.0; addedSet.BasePiece.Y = DrawPanel.Height / 2.0;
                foreach (Piece piece in addedSet.PiecesList)
                {
                    piece.FindPointSpots();
                    piece.Originally = new Originals(piece);
                }
                SelectPiece(addedSet.BasePiece);
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
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Yes;
            if (piecesList.Count > 1)
            {
                result = MessageBox.Show("Do you want to exit without saving? Your set will be lost.", "Exit Confirmation", MessageBoxButtons.YesNo);
            }
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        /// <summary>
        /// Saves the set and/or closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoneBtn_Click(object sender, EventArgs e)
        {
            if (piecesList.Count < 1)
            {
                Close();
            }
            else if (!PermitChange())
            {
                // Error message shown as part of PermitChange function
            }
            else if (!Constants.PermittedName.IsMatch(NameTb.Text))
            {
                MessageBox.Show("Please choose a valid name for your set. Name can only include letters and numbers.", "Name Invalid", MessageBoxButtons.OK);
            }
            // Name is valid
            else
            {
                // Check name not already in use, or that overriding is okay
                DialogResult result = DialogResult.Yes;
                if (File.Exists(Utilities.GetDirectory(Constants.SetsFolder, NameTb.Text)))
                {
                    result = MessageBox.Show("This name is already in use. Do you want to override the existing set?", "Override Confirmation", MessageBoxButtons.YesNo);
                }
                if (result == DialogResult.No) { return; }

                // Save Set and Close Form
                try
                {
                    WIP.CreateData();
                    Utilities.SaveData(Utilities.GetDirectory(Constants.SetsFolder, NameTb.Text), WIP.Data);
                    Close();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("No data entered for point.", "Missing Data", MessageBoxButtons.OK);
                }
            }
        }



        // ----- PIECES TAB -----

        /// <summary>
        /// Updates the original rotation of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotationBar_Scroll(object sender, EventArgs e)
        {
            if (selected == null) { return; }
            selected.Originally.R = RotationBar.Value;
            selected.R = (RotationBar.Value + RotationTrack.Value) % 360;
            DisplayDrawings();
        }

        /// <summary>
        /// Updates the original turn of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TurnBar_Scroll(object sender, EventArgs e)
        {
            if (selected == null) { return; }
            selected.Originally.T = TurnBar.Value;
            selected.T = (TurnBar.Value + TurnTrack.Value) % 360;
            DisplayDrawings();
        }

        /// <summary>
        /// Updates the original spin of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpinBar_Scroll(object sender, EventArgs e)
        {
            if (selected == null) { return; }
            selected.Originally.S = SpinBar.Value;
            selected.S = SpinBar.Value;
            DisplayDrawings();
        }

        /// <summary>
        /// Updates the original size of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SizeBar_Scroll(object sender, EventArgs e)
        {
            if (selected == null) { return; }
            selected.Originally.SM = SizeBar.Value;
            selected.SM = SizeBar.Value;
            DisplayDrawings();
        }

        /// <summary>
        /// Moves the selected piece upwards in order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpBtn_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                int selectedIndex = piecesList.IndexOf(selected);
                if (selectedIndex != -1 && selectedIndex < piecesList.Count - 1)
                {
                    Piece holding = piecesList[selectedIndex];
                    piecesList[selectedIndex] = piecesList[selectedIndex + 1];
                    piecesList[selectedIndex + 1] = holding;
                    DisplayDrawings();
                }
            }
        }

        /// <summary>
        /// Moves the selected piece down in order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownBtn_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                int selectedIndex = piecesList.IndexOf(selected);
                if (selectedIndex > 0)
                {
                    Piece holding = piecesList[selectedIndex];
                    piecesList[selectedIndex] = piecesList[selectedIndex - 1];
                    piecesList[selectedIndex - 1] = holding;
                    DisplayDrawings();
                }
            }
        }



        // ----- DRAW PANEL I/O -----
        #region Draw Panel I/O

        /// <summary>
        /// Starts click preparation, checking for a click or drag.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            int selectedIndex = -1;
            if (selected != null) { selectedIndex = FindClosestPoint(selected, selected.PiecePoints, e.X, e.Y); }
            if (selectedIndex != -1)
            {
                // Move Selected's Join
                selectedSpot = selected.PiecePoints[selectedIndex];
                moving = true;
                shadow = MakeShadow();
                originalMoving = new int[] { e.X, e.Y };
            }
            else
            {
                // Choose and Update Selected Piece (If Any)
                DeselectPiece();
                selectedIndex = Utilities.FindClickedSelection(piecesList, e.X, e.Y);
                if (selectedIndex != -1)
                {
                    SelectPiece(piecesList[selectedIndex]);
                    moving = true;
                    originalMoving = new int[] { e.X, e.Y };
                }
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Checks if a piece is being moved or just clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!moving) { return; }
            if (e.X < 0 || e.Y < 0 || e.X > DrawPanel.Size.Width || e.Y > DrawPanel.Size.Height)
            {
                StopMoving();
            }
            else if (selectedSpot != null)
            {
                positionMoving = new int[] { e.X, e.Y };
                UpdateShadowPosition();
                // CHECK IF HOVERING A PIECE
                // IF SO, SHOW THAT PIECE'S POINTS
                // IF THAT PIECE IS NOT SELECTED ** TO DO
            }
            else
            {
                positionMoving = new int[] { e.X, e.Y };
                if (!movingFar)
                {
                    movingFar = Math.Abs(originalMoving[0] - positionMoving[0]) > Constants.ClickPrecision
                        || Math.Abs(originalMoving[1] - positionMoving[1]) > Constants.ClickPrecision;
                    if (movingFar) { shadow = MakeShadow(); }
                }
                if (movingFar) { UpdateShadowPosition(); }
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Updates the user interface for the selected piece and stops
        /// the movement search, actioning it if necessary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (!moving) { return; }
            if (selectedSpot != null)
            {
                // Connect Piece if new position is valid
                int clickedIndex = Utilities.FindClickedSelection(piecesList, e.X, e.Y);
                if (clickedIndex != -1 && piecesList[clickedIndex] != selected)
                {
                    Piece connectedTo = piecesList[clickedIndex];
                    int joinIndex = FindClosestPoint(connectedTo, connectedTo.PiecePoints, e.X, e.Y);
                    if (joinIndex != -1)
                    {
                        selected.AttachToPiece(connectedTo, connectedTo.PiecePoints[joinIndex],
                            selectedSpot, true, -1);
                        DeselectPiece();
                        SelectPiece(connectedTo);
                    }
                }
            }
            else if (movingFar)
            {
                selected.X += positionMoving[0] - originalMoving[0];
                selected.Y += positionMoving[1] - originalMoving[1];
            }
            StopMoving();
            DisplayDrawings();
        }

        /// <summary>
        /// Runs when a key is pressed.
        /// If delete is pressed and a piece is selected, it will be deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void KeyPress(object sender, KeyEventArgs e)
        {
            // Delete selected piece
            if (e.KeyCode == Keys.Delete)
            {
                if (selected == null) { return; }
                piecesList.Remove(selected);
                selected = null;
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Rotates the set on the DrawPanel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RotationTrack_Scroll(object sender, EventArgs e)
        {
            foreach (Piece piece in piecesList)
            {
                if (piece.AttachedTo == null)
                {
                    piece.R = (piece.Originally.R + RotationTrack.Value) % 360;
                    DisplayDrawings();
                    return;
                }
            }
        }

        /// <summary>
        /// Turns the set on the DrawPanel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TurnTrack_Scroll(object sender, EventArgs e)
        {
            foreach (Piece piece in piecesList)
            {
                if (piece.AttachedTo == null)
                {
                    piece.T = (piece.Originally.T + TurnTrack.Value) % 360;
                    DisplayDrawings();
                    return;
                }
            }
        }

        #endregion



        // ----- OTHER FUNCTIONS -----

        /// <summary>
        /// Displays all of the current pieces and any
        /// relevant points to the screen.
        /// </summary>
        private void DisplayDrawings()
        {
            g = DrawPanel.CreateGraphics();
            Utilities.DrawPieces(piecesList, g, DrawPanel);
            // If moving a piece, draw the shadow
            if (movingFar || selectedSpot != null)
            {
                Utilities.DrawPiece(shadow, g, true);
            }
            // If a piece is selected, show its PointSpots
            else if (moving == false && selected != null)
            {
                foreach (Join spot in selected.PiecePoints)
                {
                    double[] spotCoords = spot.GetCurrentPoints(selected.GetCoords()[0], selected.GetCoords()[1]);
                    Utilities.DrawPoint(spotCoords[0], spotCoords[1], Constants.highlight, g);
                }
            }
        }

        /// <summary>
        /// Checks that all added pieces are connected to the set.
        /// Shows relevant warning message.
        /// </summary>
        /// <returns></returns>
        private bool PermitChange()
        {
            int count = 0;
            foreach (Piece piece in piecesList)
            {
                if (piece.GetIsAttached())
                {
                    count++;
                    if (count > 1)
                    {
                        selected = piece;
                        MessageBox.Show("You must attach this piece to something, or delete it, to save the set.", "Detached Piece", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Converts the set into string data for saving.
        /// </summary>
        /// <returns></returns>
        private List<string> GetSaveData()
        {
            List<string> returnData = new List<string>();
            foreach (Piece piece in piecesList)
            {
                bool notBase = WIP.BasePiece != piece;
                string pieceData = piece.Name + ";";

                if (notBase)
                {
                    pieceData += piece.OwnPoint.Name + ";" + piecesList.IndexOf(piece.AttachedTo)
                        + ";" + piece.AttachPoint.Name + ";";
                }

                // Save Piece Attributes
                pieceData += piece.X + ";" + piece.Y + ";" + piece.R + ";" + piece.T + ";" + piece.S + ";" + piece.SM;

                // Save flip values
                if (notBase)
                {
                    pieceData += ";" + piece.InFront + ";" + piece.AngleFlip;
                }
                returnData.Add(pieceData);
            }
            return returnData;
        }

        /// <summary>
        /// Selects a piece and updates its outline.
        /// </summary>
        /// <param name="piece"></param>
        private void SelectPiece(Piece piece)
        {
            DeselectPiece();
            selected = piece;
            selectedOC = selected.OutlineColour;
            selected.OutlineColour = Constants.select;
            RotationBar.Enabled = true;
            TurnBar.Enabled = true;
            SpinBar.Enabled = true;
            SizeBar.Enabled = true;
            RotationBar.Value = (int)selected.R;
            TurnBar.Value = (int)selected.T;
            SpinBar.Value = (int)selected.S;
            SizeBar.Value = (int)selected.SM;
        }

        /// <summary>
        /// Deselects a piece and returns its outline to original.
        /// </summary>
        private void DeselectPiece()
        {
            if (selected != null)
            {
                selected.OutlineColour = selectedOC;
                selected = null;
                RotationBar.Enabled = false;
                TurnBar.Enabled = false;
                SpinBar.Enabled = false;
                SizeBar.Enabled = false;
            }
        }

        /// <summary>
        /// Resets all movement variables.
        /// </summary>
        private void StopMoving()
        {
            moving = false;
            movingFar = false;
            selectedSpot = null;
        }

        /// <summary>
        /// Finds the closest spot to the click position.
        /// </summary>
        /// <param name="spots">Piece's PointSpots</param>
        /// <param name="x">Click X coordinate</param>
        /// <param name="y">Click y coordinate</param>
        /// <returns>The closest point index or -1 if none in range</returns>
        private int FindClosestPoint(Piece host, List<Join> spots, int x, int y)
        {
            foreach (int range in Constants.Ranges)
            {
                for (int index = 0; index < spots.Count(); index++)
                {
                    double[] coordinates = spots[index].GetCurrentPoints(host.GetCoords()[0], host.GetCoords()[1]);
                    if (x >= coordinates[0] - range && x <= coordinates[0] + range
                        && y >= coordinates[1] - range && y <= coordinates[1] + range)
                    {
                        return index;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Makes a copy of the selected piece
        /// in a dark colour.
        /// </summary>
        /// <returns></returns>
        private Piece MakeShadow()
        {
            return new Piece(selected.Name)
            {
                X = selected.GetCoords()[0],
                Y = selected.GetCoords()[1],
                R = selected.GetAngles()[0],
                T = selected.GetAngles()[1],
                S = selected.GetAngles()[2],
                SM = selected.GetSizeMod(),
                FillColour = new Color[] { Constants.shadowShade },
                OutlineWidth = 0
            };
        }

        /// <summary>
        /// Updates the shadow's position to reflect the
        /// mouse's position.
        /// </summary>
        private void UpdateShadowPosition()
        {
            if (selected == null || positionMoving.Length == 0 || originalMoving.Length == 0) { return; }
            shadow.X = selected.X + positionMoving[0] - originalMoving[0];
            shadow.Y = selected.Y + positionMoving[1] - originalMoving[1];
        }
    }
}
