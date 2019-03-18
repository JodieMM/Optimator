using System;
using System.Drawing;

namespace Animator
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
        private readonly Piece joining;

        public double X { get; set; }
        public double Y { get; set; }
        public double XRight { get; set; }
        public double YDown { get; set; }


        public double FlipAngle { get; set; }
        public int IndexSwitch { get; set; }
        #endregion


        /// <summary>
        /// Constructor for creating a new join.
        /// </summary>
        /// <param name="piece">The piece being joined</param>
        public Join(Piece piece)
        {
            joining = piece;
            X = XRight = Y = YDown = IndexSwitch = 0;
            FlipAngle = -1;
        }

        /// <summary>
        /// Constructor for loading a join.
        /// </summary>
        /// <param name="piece">The piece being joined</param>
        /// <param name="x">The initial x of the join</param>
        /// <param name="y">The initial y of the join</param>
        /// <param name="xr">The rotated x of the join</param>
        /// <param name="yd">The turned y of the join</param>
        /// <param name="flipAngle">When the piece flips, -1 if it doesn't</param>
        /// <param name="indexSwitch">What index the piece flips to, 0 if it doesn't flip</param>
        public Join(Piece piece, double x, double y, double xr, double yd, double flipAngle, int indexSwitch)
        {
            joining = piece;
            X = x;
            Y = y;
            XRight = xr;
            YDown = yd;
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
            return X + Consts.ColonS + Y + Consts.ColonS + XRight + Consts.ColonS + YDown +
                Consts.SemiS + FlipAngle + Consts.SemiS + IndexSwitch;
        }

        /// <summary>
        /// Draws a + at the given spot.
        /// </summary>
        /// <param name="angle">Whether the spot is drawn at original (0), rotated (1), turned(2) angle</param>
        /// <param name="colour">Colour of the +</param>
        /// <param name="board">The graphics board to be drawn on</param>
        public void Draw(int angle, Color colour, Graphics board)
        {
            var x = angle == 1 ? XRight : X;
            var y = angle == 2 ? YDown : Y;
            Visuals.DrawCross(joining.GetCoords()[0] + x, joining.GetCoords()[1] + y, colour, board);
        }



        // ----- COORDINATE FUNCTIONS -----

        /// <summary>
        /// Finds the difference between the original join location and
        /// where it is now based on piece changes.
        /// </summary>
        /// <returns>Difference as [ x, y ]</returns>
        public double[] CurrentDifference()
        {
            var currentCoords = new double[2];
            double lower;
            double upper;
            int bottomAngle;

            var angle = joining.GetAngles();
            var initial = new double[] { X, Y };
            var angled = new double[] { XRight, YDown };

            // For X and Y
            for (int index = 0; index < 2; index++)
            {
                if (angle[index] < 90)
                {
                    lower = initial[index];
                    upper = angled[index];
                    bottomAngle = 0;
                }
                else if (angle[index] < 180)
                {
                    lower = angled[index];
                    upper = -initial[index];
                    bottomAngle = 90;
                }
                else if (angle[index] < 270)
                {
                    lower = -initial[index];
                    upper = -angled[index];
                    bottomAngle = 180;
                }
                else
                {
                    lower = -angled[index];
                    upper = initial[index];
                    bottomAngle = 270;
                }
                currentCoords[index] = lower + (upper - lower) * ((angle[index] - bottomAngle) / 90.0);
            }
            currentCoords = SpinMeRound(currentCoords);
            return new double[] { X - currentCoords[0], Y - currentCoords[1] };
        }

        /// <summary>
        /// Places a join in regards to the piece's position.
        /// </summary>
        /// <param name="angle">Original (0) rotated (1) turned (2)</param>
        /// <param name="join">The clicked location for the join</param>
        public void ReverseDifference(int angle, double[] join)
        {
            // Reverse Spin and Size Mod
            join = SpinMeRound(join, true);

            // Reverse Rotation and Turn
            int upper;
            int bottomAngle;
            for (int index = 0; index < 2; index++)
            {
                var angled = joining.GetAngles()[index];
                if (angle == 0)
                {
                    if (angled < 90)
                    {
                        upper = 1;
                        bottomAngle = 0;
                    }
                    else if (angled < 180)
                    {
                        upper = -1;
                        bottomAngle = 90;
                    }
                    else if (angled < 270)
                    {
                        upper = 1;
                        bottomAngle = 180;
                    }
                    else
                    {
                        upper = -1;
                        bottomAngle = 270;
                    }
                    if (upper == -1)
                        join[index] = join[index] / (1 - 2 * ((angled - bottomAngle) / 90.0));
                }
                else
                {
                    if (angle == 1 && index == 0 || angle == 2 && index == 1)
                    {
                        var known = index == 0 ? X : Y;
                        if (angled < 90)
                        {
                            bottomAngle = 0;
                            join[index] = (join[index] - known + known * ((angled - bottomAngle) / 90.0))/ ((angled - bottomAngle) / 90.0);
                        }
                        else if (angled < 180)
                        {
                            bottomAngle = 90;
                            join[index] = (join[index] + known * ((angled - bottomAngle) / 90.0)) / (1 - ((angled - bottomAngle) / 90.0));
                        }
                        else if (angled < 270)
                        {
                            bottomAngle = 180;
                            join[index] = -(join[index] + known - known * ((angled - bottomAngle) / 90.0)) / ((angled - bottomAngle) / 90.0);
                        }
                        else
                        {
                            bottomAngle = 270;
                            join[index] = (join[index] - known * ((angled - bottomAngle) / 90.0)) / (1 - ((angled - bottomAngle) / 90.0));
                        }
                    }
                }
            }            

            // Find X/Y in relation to piece
            join[0] -= joining.middle[0];
            join[1] -= joining.middle[1];

            // Assign To Value
            if (angle == 0)
            {
                X = join[0];
                Y = join[1];
            }
            if (angle != 2)
                XRight = join[0];
            if (angle != 1)
                YDown = join[1];
        }

        /// <summary>
        /// Spins the coords provided and modifies their size.
        /// </summary>
        /// <param name="join">The point to be spun</param>
        /// <returns>The spun coordinates of the join</returns>
        private double[] SpinMeRound(double[] join, bool reverse = false)
        {
            var sizeMod = reverse ? 2.0 - joining.GetSizeMod() : joining.GetSizeMod();
            var spin = reverse ? (360 - joining.GetAngles()[2]) % 360: joining.GetAngles()[2];

            if (!(join[0] == 0 && join[1] == 0))
            {
                double hypotenuse = Math.Sqrt(Math.Pow(0 - join[0], 2) + Math.Pow(0 - join[1], 2)) * sizeMod;
                // Find Angle
                double pointAngle;
                if (join[0] == 0 && join[1] < 0)
                {
                    pointAngle = 0;
                }
                else if (join[0] == 0 && join[1] > 0)
                {
                    pointAngle = 180;
                }
                else if (join[0] > 0 && join[1] == 0)
                {
                    pointAngle = 90;
                }
                else if (join[0] < 0 && join[1] == 0)
                {
                    pointAngle = 270;
                }
                //  Second || First
                //  Third  || Fourth
                else if (join[0] > 0 && join[1] < 0) // First Quadrant
                {
                    pointAngle = 180 / Math.PI * Math.Atan(Math.Abs((0 - join[0]) / (0 - join[1])));
                }
                else if (join[0] > 0 && join[1] > 0) // Fourth Quadrant
                {
                    pointAngle = 90 + 180 / Math.PI * Math.Atan(Math.Abs((0 - join[1]) / (0 - join[0])));
                }
                else if (join[0] < 0 && join[1] < 0) // Second Quadrant
                {
                    pointAngle = 270 + 180 / Math.PI * Math.Atan(Math.Abs((0 - join[1]) / (0 - join[0])));
                }
                else  // Third Quadrant
                {
                    pointAngle = 180 + 180 / Math.PI * Math.Atan(Math.Abs((0 - join[0]) / (0 - join[1])));
                }
                double findAngle = (pointAngle + spin) * Math.PI / 180 % 360;

                // Find Points
                join[0] = Convert.ToInt32(hypotenuse * Math.Sin(findAngle));
                join[1] = Convert.ToInt32(-hypotenuse * Math.Cos(findAngle));
            }
            return join;
        }
    }
}
