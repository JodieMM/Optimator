using System;
using System.Drawing;
using System.Windows.Forms;

namespace Animator
{
    /// <summary>
    /// Displays a rotating/turning view of the piece to get a 3D perspective
    /// of what it will look like.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class PreviewForm : Form
    {
        #region Preview Variables
        private Piece WIP;
        private Graphics g;
        #endregion


        // ----- CONSTRUCTOR AND SHOWN -----

        /// <summary>
        /// Constructor for the Preview form.
        /// </summary>
        public PreviewForm(Piece piece)
        {
            InitializeComponent();
            WIP = piece;
            WIP.X = DrawBoard.Width / 2.0; WIP.Y = DrawBoard.Height / 2.0;
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

        private void button1_Click(object sender, EventArgs e)
        {
            WIP.R = 0;
            DrawScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WIP.R = 90;
            DrawScreen();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WIP.R = 180;
            DrawScreen();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WIP.R = 270;
            DrawScreen();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WIP.T = 0;
            DrawScreen();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WIP.T = 90;
            DrawScreen();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WIP.T = 180;
            DrawScreen();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WIP.T = 270;
            DrawScreen();
        }
    }
}
