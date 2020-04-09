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
            BX = BXRight = A.State.X - B.State.X;
            BY = BYDown = A.State.Y - B.State.Y;
            AX = AXRight = AY = AYDown = 0;
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
        public State CurrentStateOfAttached(State aState)
        {
            //TODO: Fix loaned base values
            double rChange = Utils.Modulo(B.State.R - Set.PersonalStates[B].R, 360);
            double tChange = Utils.Modulo(B.State.T - Set.PersonalStates[B].T, 360);
            double modR = aState.R + B.State.R;
            double modT = aState.T;
            double modS = aState.S;
            double modSM = 1;

            // ATTEMPT SM

            // Adjust Turn
            modT += aState.S;

            // Should it be on an angle/spun?
            if (rChange > 0)
            {  
                // Adjust Spin
                if (aState.S != 0 && aState.S != 180)
                {                  
                    if (aState.S < 90)
                    {
                        modS = aState.S * Math.Cos(Utils.ConvertDegreeToRadian(rChange));

                        double height = Utils.FindHeight(A.GetPoints(new State(0, 0, modR, modT, aState.S, 1)));
                        double flatHeight = Utils.FindHeight(A.GetPoints(new State(0, 0, modR, modT, 0, 1)));

                        double newSM = height / flatHeight;

                        //double flatHeight = Utils.FindHeight(A.GetPoints(new State(0, 0, modR, modT, 0, 1)));                    
                        modSM = (1 - newSM) * Math.Abs(Math.Cos(Utils.ConvertDegreeToRadian(rChange))) + newSM;
                    }
                    else if (aState.S < 180)
                    {
                        modS = 90 + (aState.S - 90) * Math.Cos(Utils.ConvertDegreeToRadian(rChange));
                        double height = Utils.FindHeight(A.GetPoints(new State(0, 0, modR, modT, aState.S, 1)));
                        double flatHeight = Utils.FindHeight(A.GetPoints(new State(0, 0, modR, modT, 0, 1)));
                        double newSM = height / flatHeight;

                        //double flatHeight = Utils.FindHeight(A.GetPoints(new State(0, 0, modR, modT, 0, 1)));                    
                        modSM = (1 - newSM) * Math.Abs(Math.Cos(Utils.ConvertDegreeToRadian(rChange))) + newSM;
                    }
                }


                // Adjust Turn
                //if (aState.T != 0 && aState.T != 180)
                //{
                //    modS += aState.T * Math.Sin(Utils.ConvertDegreeToRadian(rChange));
                //    double height = Utils.FindHeight(A.GetPoints(new State(0, 0, modR, modT, 0, 1)));
                //    double angledHeight = Utils.FindHeight(A.GetPoints(new State(0, 0, modR, modT, modS, 1)));
                //    modSM = height / angledHeight;

                //    modS += aState.T * Math.Sin(Utils.ConvertDegreeToRadian(rChange));
                //    if (modS != 90 && modS != 270)
                //    {
                //        modSM = 1 / Math.Cos(Utils.ConvertDegreeToRadian(modS));
                //    }
                //    if (modT == 90)
                //    {
                //        modS = 90;
                //        modR = 0;
                //        modT += rChange;
                //    }

                //    if (aState.T <= 45)
                //    {
                //        // TODO ensure modS != 90/270, height != 0
                //        modS += aState.T * Math.Sin(Utils.ConvertDegreeToRadian(rChange));
                //        //double height = Utils.FindHeight(A.GetPoints(new State(0, 0, modR, modT, 0, 1)));
                //        modSM = 1 / Math.Cos(Utils.ConvertDegreeToRadian(modS));
                //        //double angledHeight = height / Math.Cos(Utils.ConvertDegreeToRadian(modS));
                //        //modSM = angledHeight / height;
                //    }
                //    else if (aState.T <= 90)
                //    {
                //        modS += aState.T * Math.Sin(Utils.ConvertDegreeToRadian(rChange));
                //        double width = Utils.FindHeight(A.GetPoints(new State(0, 0, modR, modT, 0, 1)), true);
                //        double angledWidth = width / Math.Cos(Utils.ConvertDegreeToRadian(modS));
                //        modSM = angledWidth / width;
                //    }
                //}
                // Adjust Spin
                //if (aState.S != 0 && aState.S != 180)
                //{
                //    modS += aState.S * Math.Cos(Utils.ConvertDegreeToRadian(rChange));
                //    double[] heights = Utils.FindMinMax(A.GetPoints(new State(0, 0, modR, modT, 0, 1)));
                //    double height = heights[3] - heights[2];
                //    double angledHeight = height / Math.Cos(Utils.ConvertDegreeToRadian(modS));
                //    modSM = angledHeight / height;
                //}
            }

            // END ATTEMPT SM
            // Convert Spun Values
            // -- ROTATION
            //if (personalState.R != 0)
            //{
            //    if (personalState.R <= 90)
            //    {
            //        modS += personalState.R * Math.Sin(Utils.ConvertDegreeToRadian(tChange));
            //        modR += Math.Abs(personalState.R * Math.Cos(Utils.ConvertDegreeToRadian(tChange)));
            //    }
            //    else if (personalState.R <= 180)
            //    {
            //        modS += personalState.R * Math.Sin(Utils.ConvertDegreeToRadian(tChange));
            //        modR += Math.Abs(personalState.R * Math.Cos(Utils.ConvertDegreeToRadian(tChange)));

            //        //modS += (personalState.T - 90) * -Math.Sin(Utils.ConvertDegreeToRadian(rChange));
            //        ////modS += rChange < 180 ? 90 : -90;
            //        //modT += personalState.T * Math.Cos(Utils.ConvertDegreeToRadian(rChange));
            //    }
            //    else if (personalState.R == 180)
            //    {

            //    }
            //}
            // -- TURN
            //if (personalState.T != 0)
            //{
            //    if (personalState.T <= 90)
            //    {
            //        modS += personalState.T * Math.Sin(Utils.ConvertDegreeToRadian(rChange));
            //        //modT += Math.Abs(personalState.T * Math.Cos(Utils.ConvertDegreeToRadian(rChange)));
                    

            //    }
            //    else if (personalState.T <= 180)
            //    {
            //        modS += (personalState.T - 90) * -Math.Sin(Utils.ConvertDegreeToRadian(rChange));
            //        modT += Math.Abs(personalState.T * Math.Cos(Utils.ConvertDegreeToRadian(rChange)));

            //        //modS += (personalState.T - 90) * -Math.Sin(Utils.ConvertDegreeToRadian(rChange));
            //        ////modS += rChange < 180 ? 90 : -90;
            //        //modT += personalState.T * Math.Cos(Utils.ConvertDegreeToRadian(rChange));
            //    }
            //    else if (personalState.T == 180)
            //    {

            //    }
            //}
            // -- SPIN
            //modT += rChange;
            //modR += -rChange;
            //modS += personalState.T;



            //modR = B.State.R;
            //modT = B.State.T + Math.Abs(personalState.S * Math.Sin(Utils.ConvertDegreeToRadian(rChange)));
            ////double modT = B.State.T + personalState.S * Math.Sin(Utils.ConvertDegreeToRadian(rChange));
            //modS = personalState.S * Math.Cos(Utils.ConvertDegreeToRadian(rChange));

            //double attachedR = Utils.Modulo(personalState.R + B.State.R * Math.Cos(Utils.ConvertDegreeToRadian(personalState.S)), 360);
            //double attachedT = Utils.Modulo(personalState.T + Math.Abs(personalState.S * Math.Sin(Utils.ConvertDegreeToRadian(B.State.R))), 360);
            //double attachedS = Utils.Modulo(B.State.S + personalState.S * Math.Cos(Utils.ConvertDegreeToRadian(B.State.R)), 360);
            //double attachedS = Utils.Modulo(B.State.S + personalState.S * Math.Cos(Utils.ConvertDegreeToRadian(B.State.R)), 360);
            //double attachedS = Utils.Modulo(B.State.S + personalState.S * Math.Cos(Utils.ConvertDegreeToRadian(B.State.R)), 360);

            double attachedR = Utils.Modulo(modR, 360);
            double attachedT = Utils.Modulo(modT, 360);
            double attachedS = Utils.Modulo(modS, 360);

            //double attachedR = Utils.Modulo(B.State.R + personalState.R, 360);
            //double attachedT = Utils.Modulo(B.State.T + personalState.T, 360);
            //double attachedS = Utils.Modulo(B.State.S + personalState.S, 360);

            double attachedSM = B.State.SM * aState.SM * modSM;

            double[] attachedJoinB = Utils.SpinAndSizeCoord(B.State.S, B.State.SM,
                new double[] { Utils.RotOrTurnCalculation(B.State.R, BX, BXRight), Utils.RotOrTurnCalculation(B.State.T, BY, BYDown) });
            double[] attachedJoinA = Utils.SpinAndSizeCoord(attachedS, attachedSM,
                new double[] { Utils.RotOrTurnCalculation(attachedR, AX, AXRight), Utils.RotOrTurnCalculation(attachedT, AY, AYDown) });

            double attachedX = B.State.X + attachedJoinB[0] + attachedJoinA[0] + aState.X;
            double attachedY = B.State.Y + attachedJoinB[1] + attachedJoinA[1] + aState.Y;

            return new State(attachedX, attachedY, attachedR, attachedT, attachedS, attachedSM);
        }

        /// <summary>
        /// Uses attached's current state to determine join's centre
        /// </summary>
        /// <returns>Join's current centre</returns>
        public double[] CurrentCentre()
        {
            double[] aJoin = new double[2] {Utils.RotOrTurnCalculation(A.State.R, AX, AXRight),
                Utils.RotOrTurnCalculation(A.State.T, AY, AYDown)};
            aJoin = Utils.SpinAndSizeCoord(A.State.S, A.State.SM, aJoin);
            return new double[2] {A.State.X - aJoin[0], A.State.Y - aJoin[1]};
        }
    }
}
