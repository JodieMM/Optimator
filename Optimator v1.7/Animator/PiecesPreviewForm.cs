using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animator
{
    /// <summary>
    /// Displays a rotating/turning view of the piece to get a 3D perspective
    /// of what it will look like.
    /// </summary>
    public partial class PiecesPreviewForm : Form
    {
        // Variables
        Piece WIP;
        Graphics g;

        /// <summary>
        /// Constructor for the Preview form.
        /// </summary>
        public PiecesPreviewForm(Piece piece)
        {
            InitializeComponent();
            WIP = piece;
            WIP.X = Constants.MidX; WIP.Y = Constants.MidY;
        }

        /// <summary>
        /// Runs when the screen is displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PiecesPreviewForm_Shown(object sender, EventArgs e)
        {
            DrawScreen();
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
        private void RotationTrack_Scroll(object sender, EventArgs e)
        {
            WIP.R = RotationTrack.Value;
            DrawScreen();
        }

        /// <summary>
        /// Changes the turn of the piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TurnTrack_Scroll(object sender, EventArgs e)
        {
            WIP.T = TurnTrack.Value;
            DrawScreen();
        }

        /// <summary>
        /// Draws the piece to the screen.
        /// </summary>
        private void DrawScreen()
        {
            DrawBoard.Refresh();
            g = DrawBoard.CreateGraphics();
            Utilities.DrawPiece(WIP, g, true);
        }
    }
}
