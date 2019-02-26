using System.Drawing;

namespace Animator
{
    /// <summary>
    /// A class to hold information about an
    /// individual coordinate.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class Spot
    {
        #region Spot Variables
        public double X { get; set; }
        public double XRight { get; set; }
        public double Y { get; set; }
        public double YDown { get; set; }

        public string Connector { get; set; }
        public string Solid { get; set; }

        public Spot MatchX { get; set; } = null;
        public Spot MatchY { get; set; } = null;
        public int DrawnLevel { get; set; }
        #endregion
        

        /// <summary>
        /// Constructor for a spot.
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="xr">Rotated X position</param>
        /// <param name="yd">Turned Y position</param>
        /// <param name="connect">Connector from this spot to the next</param>
        /// <param name="solid">Flexibility of the spot</param>
        /// /// <param name="drawn">DrawLevel integer</param>
        public Spot(double x, double y, double? xr = null, double? yd = null, string connect = null, string solid = null, int drawn = 0)
        {
            X = x;
            Y = y;
            XRight = xr ?? x;
            YDown = yd ?? y;
            Connector = connect ?? Constants.connectorOptions[0];
            Solid = solid ?? Constants.solidOptions[0];
            DrawnLevel = drawn;
        }



        // ----- GET FUNCTIONS -----

        /// <summary>
        /// Returns the save data of the spot.
        /// </summary>
        /// <returns>Spot data</returns>
        public override string ToString()
        {
            return X + Constants.ColonS + Y + Constants.ColonS + XRight + Constants.ColonS + YDown + Constants.SemiS +
                Connector + Constants.SemiS + Solid;
        }

        /// <summary>
        /// Converts the coordinates to doubles to allow
        /// easier input into arrays/searches.
        /// </summary>
        /// <param name="angle">Original [0], rotated [1], turned [2]</param>
        /// <returns>Coordinates of the piece as a double</returns>
        public double[] GetCoordCombination(int angle)
        {
            switch (angle)
            {
                case 1:
                    return new double[] { XRight, Y };
                case 2:
                    return new double[] { X, YDown };
                case 3:
                    return new double[] { XRight, YDown };
                default:
                    return new double[] { X, Y };
            }
        }

        /// <summary>
        /// Gets the current coordinates of the spot based on
        /// the current angles.
        /// Does not include spin adjustment.
        /// </summary>
        /// <param name="r">Current rotation</param>
        /// <param name="t">Current turn</param>
        /// <param name="mid">The middle of the piece the spot belongs to</param>
        public double[] GetCurrentCoords(double r, double t, double[] mid)
        {
            double[] currentCoords = new double[2];
            double lower;
            double upper;
            int bottomAngle;

            // X / Rotation
            if (r < 90)
            {
                lower = X;
                upper = XRight;
                bottomAngle = 0;
            }
            else if (r < 180)
            {
                lower = XRight;
                upper = (MatchX == null) ? Utilities.FlipPoint(mid[0], X) : Utilities.FlipPoint(mid[0], MatchX.X);
                bottomAngle = 90;
            }
            else if (r < 270)
            {
                lower = (MatchX == null) ? Utilities.FlipPoint(mid[0], X) : Utilities.FlipPoint(mid[0], MatchX.X);
                upper = (MatchX == null) ? Utilities.FlipPoint(mid[0], XRight): Utilities.FlipPoint(mid[0], MatchX.XRight);
                bottomAngle = 180;
            }
            else
            {
                lower = (MatchX == null) ? Utilities.FlipPoint(mid[0], XRight): Utilities.FlipPoint(mid[0], MatchX.XRight);
                upper = X;
                bottomAngle = 270;
            }
            double rMod = (r - bottomAngle) / 90.0;
            currentCoords[0] = lower + (upper - lower) * rMod;

            // Y / Turn
            if (t < 90)
            {
                lower = Y;
                upper = YDown;
                bottomAngle = 0;
            }
            else if (t < 180)
            {
                lower = YDown;
                upper = (MatchY == null) ? Y : Utilities.FlipPoint(mid[1], MatchY.Y);
                bottomAngle = 90;
            }
            else if (t < 270)
            {
                lower = (MatchY == null) ? Utilities.FlipPoint(mid[1], Y) : Utilities.FlipPoint(mid[1], MatchY.Y);
                upper = (MatchY == null) ? Utilities.FlipPoint(mid[1], YDown) : Utilities.FlipPoint(mid[1], MatchY.YDown);
                bottomAngle = 180;
            }
            else
            {
                lower = (MatchY == null) ? -YDown : 2 * mid[0] - MatchY.YDown;
                upper = Y;
                bottomAngle = 270;
            }
            double tMod = (t - bottomAngle) / 90.0;
            currentCoords[1] = lower + (upper - lower) * tMod;

            return currentCoords;
        }



        // ----- SET FUNCTIONS -----

        /// <summary>
        /// Sets a coordinate value based on the inputs provided.
        /// </summary>
        /// <param name="angle">The angle the coord is affected in</param>
        /// <param name="xy">Whether the x (0) or y (1) coord is changed</param>
        /// <param name="value">The new value for the coord</param>
        public void SetCoords(int angle, int xy, double value)
        {
            if (xy == 0)
            {
                if (angle == 0 || angle == 2)
                    X = value;
                else
                    XRight = value;
            }
            else
            {
                if (angle == 0 || angle == 1)
                    Y = value;
                else
                    YDown = value;
            }
        }



        // ----- DRAW FUNCTIONS -----

        /// <summary>
        /// Draws a + at the given spot.
        /// </summary>
        /// <param name="angle">Whether the spot is drawn at original (0), rotated (1) or turned(2) angle</param>
        /// <param name="colour">Colour of the +</param>
        /// <param name="board">The graphics board to be drawn on</param>
        public void Draw(int angle, Color colour, Graphics board)
        {
            Visuals.DrawCross(GetCoordCombination(angle)[0], GetCoordCombination(angle)[1], colour, board);
        }
    }
}
