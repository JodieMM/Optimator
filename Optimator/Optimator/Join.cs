﻿using System;
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
        public float AX { get; set; } = 0;
        public float AY { get; set; } = 0;
        public float AXRight { get; set; } = 0;
        public float AYDown { get; set; } = 0;

        public float BX { get; set; } = 0;
        public float BY { get; set; } = 0;
        public float BXRight { get; set; } = 0;
        public float BYDown { get; set; } = 0;

        // Depth Variables
        public float FlipAngle { get; set; } = -1;
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
        public Join(Piece a, Piece b, Set set, float ax, float ay, float axr, float ayd, float bx, float by, float bxr, float byd, float flipAngle, int indexSwitch)
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
            //TODO (RTS) Fix loaned base values
            //var rChange = B.State.R; //Utils.Modulo(B.State.R - Set.PersonalStates[B].R, 360);
            //var tChange = Utils.Modulo(B.State.T - Set.PersonalStates[B].T, 360);

            var modR = aState.R + B.State.R;
            var modT = aState.T + B.State.T;
            var modS = aState.S;
            var modSM = B.State.SM;
            var modX = 0F;
            var modY = 0F;

            if (modR != 0 && modR != 180)
            {
                if (modT != 0 && modT != 180)
                {
                    if (modS != 0 && modS != 180)
                    {
                        // Turn and Spin
                        //TODO RTS
                    }
                    else
                    {
                        // Just Turn
                        //TODO RTS
                        modS += modT * (float)Math.Sin(Utils.ConvertDegreeToRadian(modR));
                        modT *= (float)Math.Cos(Utils.ConvertDegreeToRadian(modR));
                    }
                }





                else if (modS != 0 && modS != 180)
                {
                    // Just Spin
                    if (modS < 90)
                    {
                        //modT += Math.Abs(modS * (float)Math.Sin(Utils.ConvertDegreeToRadian(modR)));
                        modS *= (float)Math.Cos(Utils.ConvertDegreeToRadian(modR));
                    }
                    else if (modS == 90)
                    {
                        //modT += modR;
                    }
                    else if (modS < 270)
                    {
                        modS = 180 + (180 - modS) * -(float)Math.Cos(Utils.ConvertDegreeToRadian(modR));
                    }
                    else if (modS < 270)
                    {
                        //modT += Math.Abs(modS * (float)Math.Sin(Utils.ConvertDegreeToRadian(modR))); //TODO Check
                        modS = 90 + (modS - 90) * - (float)Math.Sin(Utils.ConvertDegreeToRadian(modR));
                    }
                    else if (modS < 360)
                    {
                        modS = (360 - modS) * -(float)Math.Cos(Utils.ConvertDegreeToRadian(modR));
                    }
                    else if (modS < 360)
                    {
                        modS = 360 + (360 - modS);
                        //modT += Math.Abs((modS - 360) * (float)Math.Sin(Utils.ConvertDegreeToRadian(modR))); //TODO Check
                        modS *= -(float)Math.Cos(Utils.ConvertDegreeToRadian(modR));
                    }
                }
            }












            //// Adjust Turn
            //if (aState.T != 0 && aState.T != 180)
            //{
            //    if (aState.S < 90)
            //    {
            //        modT += aState.T * (float)Math.Sin(Utils.ConvertDegreeToRadian(rChange));
            //    }
            //    else if (aState.S < 270)
            //    {
            //        modT += 180 + (180 - aState.T) * -(float)Math.Sin(Utils.ConvertDegreeToRadian(rChange));
            //    }
            //    else if (aState.S < 360)
            //    {
            //        modT += 360 + (360 - aState.T) * -(float)Math.Sin(Utils.ConvertDegreeToRadian(rChange));
            //    }
            //}

            //// Adjust Spin
            //if (aState.S != 0 && aState.S != 180)
            //{                
            //    if (aState.S < 90)
            //    {
            //        modS = aState.S * (float)Math.Cos(Utils.ConvertDegreeToRadian(rChange));
            //    }
            //    else if (aState.S < 270)
            //    {
            //        modS = 180 + (180 - aState.S) * -(float)Math.Cos(Utils.ConvertDegreeToRadian(rChange));
            //    }
            //    else if (aState.S < 360)
            //    {
            //        modS = 360 + (360 - aState.S) * -(float)Math.Cos(Utils.ConvertDegreeToRadian(rChange));
            //    }
            //}

            //// Adjust Size
            //if (aState.T != 0 && aState.T != 180 || aState.S != 0 && aState.S != 180)
            //{
            //    var height = Utils.FindHeight(A.GetPoints(new State(0, 0, aState.R, modT, aState.S, modSM)));
            //    var flatHeight = Utils.FindHeight(A.GetPoints(new State(0, 0, modR, modT, modS, modSM)));
            //    modSM *= flatHeight > 0 ? height / flatHeight : height > 0 ? 1 : 0;
            //}

            modR = Utils.Modulo(modR, 360);
            modT = Utils.Modulo(modT, 360);
            modS = Utils.Modulo(modS + B.State.S, 360);
            modSM *= aState.SM;

            //var minMax = Utils.FindMid(A.GetPoints(new State(0, 0, aState.R, modT, aState.S, B.State.SM * aState.SM)));
            //var minMax2 = Utils.FindMid(A.GetPoints(new State(0, 0, modR, modT, modS, modSM)));

            var attachedJoinB = Utils.SpinAndSizeCoord(B.State.S, B.State.SM,
                new float[] { Utils.RotOrTurnCalculation(B.State.R, BX, BXRight), Utils.RotOrTurnCalculation(B.State.T, BY, BYDown) });
            var attachedJoinA = Utils.SpinAndSizeCoord(modS, modSM,
                new float[] { Utils.RotOrTurnCalculation(modR, AX, AXRight), Utils.RotOrTurnCalculation(modT, AY, AYDown) });

            //var originalAttachedJoinA = Utils.SpinAndSizeCoord(aState.S, B.State.SM * aState.SM,
            //    new float[] { Utils.RotOrTurnCalculation(aState.R, AX, AXRight), Utils.RotOrTurnCalculation(aState.T, AY, AYDown) });
            //modY = minMax[1] - minMax2[1];
            //TODO (RTS)
            //modY = (minMax[3] - B.State.Y - originalAttachedJoinA[1]) - (minMax2[3] - B.State.Y - attachedJoinA[1]);
            //modY = (attachedJoinA[1] - minMax2[3]) - (originalAttachedJoinA[1] - minMax[3]);//aState.R, modT, aState.S, modSM

            modX += B.State.X + attachedJoinB[0] + attachedJoinA[0] + aState.X;
            modY += B.State.Y + attachedJoinB[1] + attachedJoinA[1] + aState.Y;
            return new State(modX, modY, modR, modT, modS, modSM);
        }

        /// <summary>
        /// Uses attached's current state to determine join's centre
        /// </summary>
        /// <returns>Join's current centre</returns>
        public float[] CurrentCentre()
        {
            var aJoin = new float[2] {Utils.RotOrTurnCalculation(A.State.R, AX, AXRight),
                Utils.RotOrTurnCalculation(A.State.T, AY, AYDown)};
            aJoin = Utils.SpinAndSizeCoord(A.State.S, A.State.SM, aJoin);
            return new float[2] {A.State.X - aJoin[0], A.State.Y - aJoin[1]};
        }
    }
}