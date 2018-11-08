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
using System.IO;

namespace Animator
{
    public partial class PiecesForm : Form
    {
        // Variables
        Graphics original;
        Graphics rotated;
        Graphics turned;
        List<Piece> sketch = new List<Piece>();
        Piece WIP = new Piece(Constants.PieceStructure);

        List<double[]> oCoords = new List<double[]>();
        List<double[]> rCoords = new List<double[]>();
        List<double[]> tCoords = new List<double[]>();
        List<string> joins = new List<string>();
        List<string> solid = new List<string>();

        // TEMP
        double rotationTo = 90;
        double turnTo = 90;
        double rotationFrom = 0;
        double turnFrom = 0;

        /// <summary>
        /// Constructor creates a PiecesForm page
        /// </summary>
        public PiecesForm()
        {
            InitializeComponent();
            DrawBase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawBase_MouseDown);
            DrawRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawRight_MouseDown);
            DrawDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawDown_MouseDown);
            WIP.Name = Constants.WIPName;
        }


        // ----- DRAWING BOARDS -----

        /// <summary>
        /// Places or selects a point on the main board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBase_MouseDown(object sender, MouseEventArgs e)
        {
            if (EraserBtn.Text == "Select")
            {
                // Erase
            }
            else if (PointBtn.Text == "Select")
            {
                oCoords.Add(new double[] { e.X, e.Y });
                rCoords.Add(new double[] { e.X, e.Y });
                tCoords.Add(new double[] { e.X, e.Y });
                joins.Add("line");
                solid.Add("s");
                ConvertVariablesToData(rotationFrom, rotationTo, turnFrom, turnTo, oCoords, rCoords, tCoords, joins, solid);
                DisplayDrawings();
            }
            else
            {
                // Move
            }
        }

        /// <summary>
        /// Places or selects a point on the rotation board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawRight_MouseDown(object sender, MouseEventArgs e)
        {
            int mouseX = e.X; int mouseY = e.Y;
        }

        /// <summary>
        /// Places or selects a point on the turn board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawDown_MouseDown(object sender, MouseEventArgs e)
        {
            int mouseX = e.X; int mouseY = e.Y;
        }



        // ----- MAIN BUTTONS -----

        /// <summary>
        /// Changes between placing points and selecting them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointBtn_Click(object sender, EventArgs e)
        {
            PointBtn.Text = (PointBtn.Text == "Select") ? "Place" : "Select";
        }

        /// <summary>
        /// When active, overrides point placement/selection and removes points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EraserBtn_Click(object sender, EventArgs e)
        {
            EraserBtn.Text = (EraserBtn.Text == "Eraser") ? "Point" : "Eraser";
        }

        /// <summary>
        /// Opens a preview panel to display the piece in full angles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            // Currently inaccessible
            //ApplySegmentFully();
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Yes;
            // Only ask if there is something to save
            if (oCoords.Count > 0)
            {
                result = MessageBox.Show("Do you want to exit without saving? Your piece will be lost.", "Exit Confirmation", MessageBoxButtons.YesNo);
            }
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Saves the piece and closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteBtn_Click(object sender, EventArgs e)
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
                if (File.Exists(Constants.GetDirectory(Constants.PiecesFolder, NameTb.Text)))
                {
                    result = MessageBox.Show("This name is already in use. Do you want to override the existing piece?", "Override Confirmation", MessageBoxButtons.YesNo);
                }

                // Save Piece and Close Form
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        ApplySegmentFully();
                        Utilities.SaveData(Constants.GetDirectory(Constants.PiecesFolder, NameTb.Text), WIP.Data);
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
            }
        }



        // ----- DRAWING FUNCTIONS -----

        /// <summary>
        /// Draws a + at the given coordinate
        /// </summary>
        /// <param name="xcood">X coordinate of + centre</param>
        /// <param name="ycood">Y coordinate of + centre</param>
        /// <param name="colour">Colour of the +</param>
        /// <param name="board">The graphics board to be drawn on</param>
        private void DrawPoint(double xcood, double ycood, Color colour, Graphics board)
        {
            int x = (int)xcood;
            int y = (int)ycood;
            Pen pen = new Pen(colour);
            board.DrawLine(pen, new Point(x - 2, y), new Point(x + 2, y));
            board.DrawLine(pen, new Point(x, y - 2), new Point(x, y + 2));
        }

        /// <summary>
        /// Draws the points of the WIP to the board
        /// Angle: Original = 2, Rotated = 3, Turned = 4
        /// </summary>
        /// <param name="board">The graphics board to be drawn on</param>
        /// <param name="angle">The angle to be drawn</param>
        private void DrawPoints(Graphics board, int angle)
        {
            double[,] coords = WIP.GetAnglePoints(WIP.R, WIP.T, angle);

            for (int index = 0; index < coords.Length / 2; index++)
            {
                DrawPoint(coords[index, 0], coords[index, 1], Color.Black, board);
            }
        }

        /// <summary>
        /// Draws the pieces on the 3 boards
        /// </summary>
        private void DisplayDrawings()
        {
            // Prepare Boards
            DrawBase.Refresh();
            DrawRight.Refresh();
            DrawDown.Refresh();
            original = DrawBase.CreateGraphics();
            rotated = DrawRight.CreateGraphics();
            turned = DrawDown.CreateGraphics();

            // Draw Base Board
            WIP.R = 0;
            WIP.T = 0;
            Utilities.DrawPiece(WIP, original, false);
            DrawPoints(original, 2);
            

            // Draw Rotated Board
            WIP.R = 89.9999;
            WIP.T = 0;
            Utilities.DrawPiece(WIP, rotated, false);
            DrawPoints(rotated, 3);

            // Draw Turned Board
            WIP.R = 0;
            WIP.T = 89.9999;
            Utilities.DrawPiece(WIP, turned, false);
            DrawPoints(turned, 4);
            WIP.T = 0;
        }



        // ----- DATA FUNCTIONS -----

        /// <summary>
        /// Applies the 3-board segment across the entire piece
        /// </summary>
        private void ApplySegmentFully()
        {
            WIP.UpdateDataInfoLine();

            // Get 4th (Combo R and T)
            List<double[]> bCoords = new List<double[]>();
            for (int index = 0; index < rCoords.Count; index++)
            {
                bCoords.Add(new double[] { rCoords[index][0], tCoords[index][1] });
            }
            
            ConvertVariablesToData(0, 90, 0, 90, oCoords, rCoords, tCoords, joins, solid);
            ConvertVariablesToData(90, 180, 0, 90, rCoords, Utilities.FlipCoords(oCoords, true, false), bCoords, joins, solid);
            ConvertVariablesToData(180, 270, 0, 90, Utilities.FlipCoords(oCoords, true, false), Utilities.FlipCoords(rCoords, true, false), Utilities.FlipCoords(tCoords, true, false), joins, solid);
            ConvertVariablesToData(270, 360, 0, 90, Utilities.FlipCoords(rCoords, true, false), oCoords, Utilities.FlipCoords(bCoords, true, false), joins, solid);

            ConvertVariablesToData(0, 90, 90, 180, tCoords, bCoords, Utilities.FlipCoords(oCoords, false, true), joins, solid);
            ConvertVariablesToData(90, 180, 90, 180, bCoords, Utilities.FlipCoords(tCoords, true, false), Utilities.FlipCoords(rCoords, false, true), joins, solid);
            ConvertVariablesToData(180, 270, 90, 180, Utilities.FlipCoords(tCoords, true, false), Utilities.FlipCoords(bCoords, true, false), Utilities.FlipCoords(oCoords, true, true), joins, solid);
            ConvertVariablesToData(270, 360, 90, 180, Utilities.FlipCoords(bCoords, true, false), tCoords, Utilities.FlipCoords(rCoords, true, true), joins, solid);

            ConvertVariablesToData(0, 90, 180, 270, Utilities.FlipCoords(oCoords, false, true), Utilities.FlipCoords(rCoords, false, true), Utilities.FlipCoords(tCoords, false, true), joins, solid);
            ConvertVariablesToData(90, 180, 180, 270, Utilities.FlipCoords(rCoords, false, true), Utilities.FlipCoords(oCoords, true, true), Utilities.FlipCoords(bCoords, false, true), joins, solid);
            ConvertVariablesToData(180, 270, 180, 270, Utilities.FlipCoords(oCoords, true, true), Utilities.FlipCoords(rCoords, true, true), Utilities.FlipCoords(tCoords, true, true), joins, solid);
            ConvertVariablesToData(270, 360, 180, 270, Utilities.FlipCoords(rCoords, true, true), Utilities.FlipCoords(oCoords, false, true), Utilities.FlipCoords(bCoords, true, true), joins, solid);

            ConvertVariablesToData(0, 90, 270, 360, Utilities.FlipCoords(tCoords, false, true), Utilities.FlipCoords(bCoords, false, true), oCoords, joins, solid);
            ConvertVariablesToData(90, 180, 270, 360, Utilities.FlipCoords(bCoords, false, true), Utilities.FlipCoords(tCoords, true, true), rCoords, joins, solid);
            ConvertVariablesToData(180, 270, 270, 360, Utilities.FlipCoords(tCoords, true, true), Utilities.FlipCoords(bCoords, true, true), Utilities.FlipCoords(oCoords, true, false), joins, solid);
            ConvertVariablesToData(270, 360, 270, 360, Utilities.FlipCoords(bCoords, true, true), Utilities.FlipCoords(tCoords, false, true), Utilities.FlipCoords(rCoords, true, false), joins, solid);
        }

        /// <summary>
        /// Converts relevant variables for a piece's angle into a data line and saves to piece data.
        /// </summary>
        /// <param name="rFrom">Rotation start</param>
        /// <param name="rTo">Rotation end</param>
        /// <param name="tFrom">Turn start</param>
        /// <param name="tTo">Turn end</param>
        /// <param name="originalCoords">Coordinates for original state</param>
        /// <param name="rotatedCoords">Coordinates for rotated state</param>
        /// <param name="turnedCoords">Coordinates for turned state</param>
        /// <param name="joinsList">Joins between points</param>
        /// <param name="detailsList">Details of points</param>
        private void ConvertVariablesToData (double rFrom, double rTo, double tFrom, double tTo, 
            List<double[]> originalCoords, List<double[]> rotatedCoords, List<double[]> turnedCoords,
            List<string> joinsList, List<string> detailsList)
        {
            // Angles
            string WIPstring = rFrom.ToString().PadLeft(3, '0') + ":" + rTo.ToString().PadLeft(3, '0') + ";" +
                tFrom.ToString().PadLeft(3, '0') + ":" + tTo.ToString().PadLeft(3, '0') + ";";

            // Original Coords
            for (int index = 0; index < originalCoords.Count; index++)
            {
                WIPstring += originalCoords[index][0] + "," + originalCoords[index][1];
                WIPstring += (index == originalCoords.Count - 1) ? ";" : ":";
            }

            // Rotated Coords
            for (int index = 0; index < rotatedCoords.Count; index++)
            {
                WIPstring += rotatedCoords[index][0] + "," + rotatedCoords[index][1];
                WIPstring += (index == rotatedCoords.Count - 1) ? ";" : ":";
            }

            // Turned Coords
            for (int index = 0; index < turnedCoords.Count; index++)
            {
                WIPstring += turnedCoords[index][0] + "," + turnedCoords[index][1];
                WIPstring += (index == turnedCoords.Count - 1) ? ";" : ":";
            }

            // Joins
            for (int index = 0; index < joinsList.Count; index++)
            {
                WIPstring += joinsList[index];
                WIPstring += (index == joinsList.Count - 1) ? ";" : ",";
            }

            // Details
            for (int index = 0; index < detailsList.Count; index++)
            {
                WIPstring += detailsList[index];
                WIPstring += (index == detailsList.Count - 1) ? "" : ",";
            }

            WIP.UpdateDataLine(rFrom, tFrom, WIPstring);
        }
    }
}
