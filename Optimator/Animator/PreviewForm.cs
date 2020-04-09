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
            else if (sender == spinBar) // HIDDEN Temporary Spin Bar
            {
                (WIP as Set).PersonalStates[(WIP as Set).PiecesList[1]].T = spinBar.Value;
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
            //HIDDEN EXTRAS BELOW
            if (WIP is Set)
            {
                foreach (Join join in (WIP as Set).JoinsIndex.Values)
                {
                    Visuals.DrawCross(join.CurrentCentre()[0], join.CurrentCentre()[1], Color.Red, g);
                }
                foreach (Piece piece in (WIP as Set).PiecesList)
                {
                    if (piece != (WIP as Set).BasePiece)
                    {
                        //foreach (Spot spot in piece.Data)
                        //{
                        //    Visuals.DrawCross(spot.CurrentX + piece.State.X, spot.CurrentY + piece.State.Y, Color.Blue, g);
                        //}
                        //label1.Text = "" + piece.State.X;
                        //label2.Text = "" + piece.State.Y;
                        //piece.Draw(g, new State(340, 253, 0, 40, 0, 1));
                        //g.DrawLine(new Pen(Color.Aquamarine), -300, (int)piece.State.Y + 127, 300, (int)piece.State.Y + 127);
                    }
                }
            }
        }
    }
}
