using System;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator
{
    /// <summary>
    /// Displays a rotating/turning view of the part to get a 3D perspective
    /// of what it will look like.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class PreviewForm : Form
    {
        #region Preview Variables
        private Part WIP;
        private State Position = new State();
        private Graphics g;
        #endregion


        // ----- CONSTRUCTOR AND SHOWN -----

        /// <summary>
        /// Constructor for the Preview form.
        /// </summary>
        public PreviewForm(Part part)
        {
            InitializeComponent();
            WIP = part;
            Position.SetCoordsBasedOnBoard(DrawPanel);
        }

        /// <summary>
        /// Runs when the screen is displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PiecesPreviewForm_Shown(object sender, EventArgs e)
        {
            DisplayDrawings();
        }



        // ----- FORM BUTTONS -----

        /// <summary>
        /// Closes the preview form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }



        // ----- DRAWING BOARD AND OPTIONS -----

        /// <summary>
        /// Changes the rotation of the piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Track_Scroll(object sender, EventArgs e)
        {
            if (sender == RotationTrack)
            {
                Position.R = RotationTrack.Value;
            }
            else if (sender == TurnTrack)
            {
                Position.T = TurnTrack.Value;
            }

            DisplayDrawings();
        }

        /// <summary>
        /// Draws the piece to the screen.
        /// </summary>
        private void DisplayDrawings()
        {
            DrawPanel.Refresh();
            g = DrawPanel.CreateGraphics();
            WIP.Draw(g, Position);

            //// HIDDEN: Used in testing rot/turn mixing
            foreach (Spot spot in WIP.ToPiece().Data)
            {
                Color colour = spot.DrawnLevel == 0 ? Color.Black : spot.DrawnLevel == 1 ? Color.Blue : Color.ForestGreen;
                if (WIP.ToPiece().Data.IndexOf(spot) == 6)
                {
                    colour = Color.Red;
                }
                else if (WIP.ToPiece().Data.IndexOf(spot) == 9)
                {
                    colour = Color.Silver;
                }
                if (spot.DrawnLevel == 0)
                {
                    Visuals.DrawCross(spot.CurrentX + Position.X, spot.CurrentY + Position.Y, colour, g);
                }
                else if (spot.DrawnLevel >= 1)
                {
                    Visuals.DrawX(spot.CurrentX + Position.X, spot.CurrentY + Position.Y, colour, g);
                }
            }
        }
    }
}
