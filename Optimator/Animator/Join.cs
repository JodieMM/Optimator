using System;
using System.Drawing;

namespace Optimator
{
    /// <summary>
    /// A class to indicate how two pieces
    /// connect in a set.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class Join
    {
        #region Join Variables
        public Piece A { get; } // Attaching Piece
        public Piece B { get; } // Base Piece
        public Set Set { get; } // Set Belonging To

        // Join Positions (Set at A rts = 0, B rts = 0 respectively; B --> Join, Join --> A)
        public double AX { get; set; } = 0;
        public double AY { get; set; } = 0;
        public double AXRight { get; set; } = 0;
        public double AYDown { get; set; } = 0;

        public double BX { get; set; } = 0;
        public double BY { get; set; } = 0;
        public double BXRight { get; set; } = 0;
        public double BYDown { get; set; } = 0;

        // Depth Variables
        public double FlipAngle { get; set; } = -1;
        public int IndexSwitch { get; set; } = 0;
        #endregion


        /// <summary>
        /// Constructor for creating a new join.
        /// </summary>
        /// <param name="piece">The piece being joined</param>
        public Join(Piece a, Piece b, Set set)
        {
            A = a;
            B = b;
            Set = set;
            double[] centre = new double[] { (B.State.X + A.State.X) / 2.0, (B.State.Y + A.State.Y) / 2.0 };
            BX = BXRight = centre[0] - B.State.X;
            BY = BYDown = centre[1] - B.State.Y;
            AX = AXRight = A.State.X - centre[0];
            AY = AYDown = A.State.Y - centre[1];
        }

        /// <summary>
        /// Constructor for loading a join.
        /// </summary>
        /// <param name="a">The attaching piece</param>
        /// <param name="ax">A's X coord</param>
        /// <param name="ay">A's Y coord</param>
        /// <param name="axr">A's XRight coord</param>
        /// <param name="ayd">A's YDown coord</param>
        /// <param name="b">The base piece</param>
        /// <param name="bx">B's X coord</param>
        /// <param name="by">B's Y coord</param>
        /// <param name="bxr">B's XRight coord</param>
        /// <param name="byd">V's YDown coord</param>
        /// <param name="flipAngle">When the piece flips, -1 if it doesn't</param>
        /// <param name="indexSwitch">What index the piece flips to, 0 if it doesn't flip</param>
        public Join(Piece a, Piece b, Set set, double ax, double ay, double axr, double ayd, double bx, double by, double bxr, double byd, double flipAngle, int indexSwitch)
        {
            A = a;
            B = b;
            Set = set;
            AX = ax;
            AY = ay;
            AXRight = axr;
            AYDown = ayd;
            BX = bx;
            BY = by;
            BXRight = bxr;
            BYDown = byd;
            FlipAngle = flipAngle;
            IndexSwitch = indexSwitch;
        }



        // ----- GENERAL FUNCTIONS -----

        /// <summary>
        /// Converts the join's data into a string
        /// for saving.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return AX + Consts.ColonS + AY + Consts.ColonS + AXRight + Consts.ColonS + AYDown + Consts.Semi +
                BX + Consts.ColonS + BY + Consts.ColonS + BXRight + Consts.ColonS + BYDown + Consts.Semi +
                FlipAngle + Consts.SemiS + IndexSwitch;
        }

        /// <summary>
        /// Draws a + at the given spot.
        /// </summary>
        /// <param name="angle">Whether the spot is drawn at original (0), rotated (1), turned(2) angle</param>
        /// <param name="colour">Colour of the +</param>
        /// <param name="board">The graphics board to be drawn on</param>
        public void Draw(int angle, Color colour, Graphics board)
        {
            var x = angle == 1 ? BXRight : BX;
            var y = angle == 2 ? BYDown : BY;
            Visuals.DrawCross(B.State.GetCoords()[0] + x, B.State.GetCoords()[1] + y, colour, board);
        }

        /// <summary>
        /// Draws a + at the given spot.
        /// </summary>
        /// <param name="colour">Colour of +</param>
        /// <param name="board">Board to draw to</param>
        public void Draw(Color colour, Graphics board)
        {
            Visuals.DrawCross(CurrentCentre()[0], CurrentCentre()[1], colour, board);
        }

        /// <summary>
        /// Determines if the attached piece should be in front
        /// of the base piece.
        /// </summary>
        /// <returns>True if the attached piece is in front</returns>
        public bool AttachedInFront()
        {
            // SortOrder: Implement function (X & Y First?)
            return true;
        }

        /// <summary>
        /// Finds the current state for the attached piece.
        /// </summary>
        /// <returns>State representing xyrtssm</returns>
        public State CurrentStateOfAttached(State personalState)
        {
            double attachedR = (B.State.R + personalState.R) % 360;
            double attachedT = (B.State.T + personalState.T) % 360;
            double attachedS = (B.State.S + personalState.S) % 360;
            double attachedSM = B.State.SM * personalState.SM;

            double[] attachedJoinB = Utils.SpinAndSizeCoord(B.State.S, B.State.SM,
                new double[] { Utils.RotOrTurnCalculation(B.State.R, BX, BXRight), Utils.RotOrTurnCalculation(B.State.T, BY, BYDown) });
            double[] attachedJoinA = Utils.SpinAndSizeCoord(attachedS, attachedSM,
                new double[] { Utils.RotOrTurnCalculation(attachedR, AX, AXRight), Utils.RotOrTurnCalculation(attachedT, AY, AYDown) });

            double attachedX = B.State.X + attachedJoinB[0] + attachedJoinA[0] + personalState.X;
            double attachedY = B.State.Y + attachedJoinB[1] + attachedJoinA[1] + personalState.Y;

            return new State(attachedX, attachedY, attachedR, attachedT, attachedS, attachedSM);
        }

        /// <summary>
        /// Uses base's current state to determine join's centre
        /// </summary>
        /// <returns>Join's current centre</returns>
        public double[] CurrentCentre()
        {
            double[] bJoin = new double[2] {Utils.RotOrTurnCalculation(B.State.R, BX, BXRight),
                Utils.RotOrTurnCalculation(B.State.T, BY, BYDown) };

            return new double[2] {B.State.X + bJoin[0], B.State.Y + bJoin[1]};
        }

        /// <summary>
        /// Finds the centre of the join based on an angle.
        /// </summary>
        /// <param name="angle">0 original, 1 rotated, 2 turned</param>
        /// <returns></returns>
        public double[] AngledCentre(int angle)
        {
            return new double[2] { B.State.X + (angle == 1 ? BXRight : BX), B.State.Y + (angle == 2 ? BYDown : BY) };            
        }
    }
}
