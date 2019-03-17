using System;

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



        // ----- FUNCTIONS -----

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
                    upper = Utils.FlipPoint(0, initial[index]);
                    bottomAngle = 90;
                }
                else if (angle[index] < 270)
                {
                    lower = Utils.FlipPoint(0, initial[index]);
                    upper = Utils.FlipPoint(0, angled[index]);
                    bottomAngle = 180;
                }
                else
                {
                    lower = Utils.FlipPoint(0, angled[index]);
                    upper = initial[index];
                    bottomAngle = 270;
                }
                currentCoords[index] = lower + (upper - lower) * ((angle[index] - bottomAngle) / 90.0);
            }
            currentCoords = SpinMeRound(currentCoords);
            return new double[] { joining.X - currentCoords[0], joining.Y - currentCoords[1] };
        }

        // Takes a join's current position and the piece's current position to calculate the original join data
        public void ReverseDifference()
        {

        }

        /// <summary>
        /// Spins the coords provided and modifies their size.
        /// </summary>
        /// <param name="join">The points to be spun</param>
        /// <returns></returns>
        private double[] SpinMeRound(double[] join)
        {
            if (!(join[0] == 0 && join[1] == 0))
            {
                double hypotenuse = Math.Sqrt(Math.Pow(0 - join[0], 2) + Math.Pow(0 - join[1], 2)) * joining.GetSizeMod();
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
                    pointAngle = (180 / Math.PI) * Math.Atan(Math.Abs((0 - join[0]) / (0 - join[1])));
                }
                else if (join[0] > 0 && join[1] > 0) // Fourth Quadrant
                {
                    pointAngle = 90 + (180 / Math.PI) * Math.Atan(Math.Abs((0 - join[1]) / (0 - join[0])));
                }
                else if (join[0] < 0 && join[1] < 0) // Second Quadrant
                {
                    pointAngle = 270 + (180 / Math.PI) * Math.Atan(Math.Abs((0 - join[1]) / (0 - join[0])));
                }
                else  // Third Quadrant
                {
                    pointAngle = 180 + (180 / Math.PI) * Math.Atan(Math.Abs((0 - join[0]) / (0 - join[1])));
                }
                double findAngle = ((pointAngle + joining.GetAngles()[2]) % 360) * Math.PI / 180;

                // Find Points
                join[0] = Convert.ToInt32((0 + hypotenuse * Math.Sin(findAngle)));
                join[1] = Convert.ToInt32((0 - hypotenuse * Math.Cos(findAngle)));
            }
            return join;
        }
    }
}
