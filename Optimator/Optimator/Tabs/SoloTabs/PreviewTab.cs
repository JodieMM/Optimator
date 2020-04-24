using Optimator.Tabs;
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
    public partial class PreviewTab : TabPageControl
    {
        public override HomeForm Owner { get; set; }
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
            Validated += RefreshDrawPanel;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.75F;
            var widthSmallPercent = 0.2F;
            var heightPercent = 0.9F;

            var trackLong = 0.8F;
            var trackShort = 0.1F;

            var bigWidth = (int)(Width * widthPercent);
            var bigHeight = (int)(Height * heightPercent);
            var bigLength = bigHeight < bigWidth ? bigHeight : bigWidth;


            var smallWidth = (int)(Width * widthSmallPercent);
            var lilWidth = (int)((Width - bigLength - smallWidth) / 4.0);
            var smallHeight = (int)((Height - bigHeight - ToolStrip.Height) / 2.0);

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

            DisplayDrawings();
        }

        /// <summary>
        /// Starts the drawing timer once the tab has been created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RefreshDrawPanel(object sender, EventArgs e)
        {
            DisplayTimer.Start();
        }

        /// <summary>
        /// Displays the drawings a short time after the tab has validated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayTimer_Tick(object sender, EventArgs e)
        {
            DisplayTimer.Stop();
            DisplayDrawings();            
        }

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
            else if (sender == spinBar) // HIDDEN (RTS) Temporary Spin Bar
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
        public void DisplayDrawings()
        {
            DrawPanel.Refresh();
            g = DrawPanel.CreateGraphics();
            WIP.Draw(g, Position);
            //HIDDEN (RTS) EXTRAS BELOW

            if (WIP is Piece)
            {
                //foreach (Join join in (WIP as Set).JoinsIndex.Values)
                //{
                //    Visuals.DrawCross(join.CurrentCentre()[0], join.CurrentCentre()[1], Color.Red, g);
                //}
                //foreach (Piece piece in (WIP as Set).PiecesList)
                //{
                //    if (piece != (WIP as Set).BasePiece)
                //    {
                //        //foreach (Spot spot in piece.Data)
                //        //{
                //        //    Visuals.DrawCross(spot.CurrentX + piece.State.X, spot.CurrentY + piece.State.Y, Color.Blue, g);
                //        //}
                //    }
                //}
            }
        }       
    }
}
