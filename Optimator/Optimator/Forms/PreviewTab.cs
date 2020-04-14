using Optimator;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Forms
{
    /// <summary>
    /// A tab used to preview WIP pieces and sets.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class PreviewTab : UserControl
    {
        private HomeForm Owner;
        private Part WIP;
        private State Position = new State();
        private Graphics g;


        /// <summary>
        /// Constructor for the control.
        /// </summary>
        public PreviewTab(HomeForm owner, Part part)
        {
            InitializeComponent();
            Owner = owner;
            WIP = part;
            Position.SetCoordsBasedOnBoard(DrawPanel);
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab.
        /// </summary>
        public new void Resize()
        {
            float widthPercent = 0.75F;
            float widthSmallPercent = 0.2F;
            float heightPercent = 0.9F;

            float trackLong = 0.8F;
            float trackShort = 0.1F;

            int bigWidth = (int)(Width * widthPercent);
            int bigHeight = (int)(Height * heightPercent);
            int bigLength = bigHeight < bigWidth ? bigHeight : bigWidth;


            int smallWidth = (int)(Width * widthSmallPercent);
            int lilWidth = (int)((Width - bigLength - smallWidth) / 4.0);
            int smallHeight = (int)((Height - bigHeight - ToolStrip.Height) / 2.0);

            DrawPanel.Size = new Size(bigLength, bigLength);
            DrawPanel.Location = new Point(lilWidth, smallHeight + ToolStrip.Height);

            OptionsMenu.Size = new Size(smallWidth, bigLength);
            OptionsMenu.Location = new Point(bigLength + 3 * lilWidth, smallHeight + ToolStrip.Height);

            RotationTrack.Size = new Size((int)(DrawPanel.Width * trackLong), (int)(DrawPanel.Height * trackShort));
            RotationTrack.Location = new Point((int)(DrawPanel.Location.X + (DrawPanel.Width - RotationTrack.Width) / 2.0),
                (int)(DrawPanel.Location.Y + DrawPanel.Height - RotationTrack.Height * 1.25));

            TurnTrack.Size = new Size((int)(DrawPanel.Width * trackShort), (int)(DrawPanel.Height * trackLong));
            TurnTrack.Location = new Point((int)(DrawPanel.Location.X + DrawPanel.Width - TurnTrack.Width * 1.25),
                (int)(DrawPanel.Location.Y + (DrawPanel.Height - TurnTrack.Height) / 2.0));
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



        // ----- DRAWING BOARD AND OPTIONS -----

        /// <summary>
        /// Changes the rotation or turn of the piece.
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
                if (WIP is Set)
                {
                    (WIP as Set).PersonalStates[(WIP as Set).PiecesList[1]].S = spinBar.Value;
                }
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
                    }
                }
            }
        }

        /// <summary>
        /// Closes this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Owner.RemoveTabPage(this);
        }
    }
}
