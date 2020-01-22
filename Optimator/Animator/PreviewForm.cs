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
                WIP.ToPiece().State.R = RotationTrack.Value;
            }
            else if (sender == TurnTrack)
            {
                WIP.ToPiece().State.T = TurnTrack.Value;
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
            var tempState = Utils.CloneState(WIP.ToPiece().State);
            tempState.SetCoordsBasedOnBoard(DrawPanel);
            WIP.Draw(g);

            //// HIDDEN: Used in testing rot/turn mixing
            //foreach (Spot spot in WIP.ToPiece().Data)
            //{
            //    if (spot.DrawnLevel >= 0)
            //    {
            //        Visuals.DrawCross(spot.CurrentX, spot.CalculateCurrentValue(WIP.ToPiece().GetAngles()[1],
            //            new double[] { 150, 150 }, 0), Color.Black, g);
            //    }
            //}
        }
    }
}
