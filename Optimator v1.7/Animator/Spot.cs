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

        public Spot MatchX { get; set; }
        public Spot MatchY { get; set; }
        public bool IsDrawn { get; set; }
        public bool Set { get; set; }
        #endregion


        /// <summary>
        /// Constructor for a drawn spot.
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        public Spot(double x, double y)
        {
            IsDrawn = true;
            X = x;
            XRight = x;
            Y = y;
            YDown = y;
            Connector = Constants.connectorOptions[0];
            Solid = Constants.solidOptions[0];
        }

        /// <summary>
        /// Constructor for a spot built during refinement.
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="xr">Rotated X position</param>
        /// <param name="y">Y position</param>
        /// <param name="yd">Turned Y position</param>
        public Spot(double x, double xr, double y, double yd, string connect, string solid)
        {
            IsDrawn = false;
            X = x;
            XRight = xr;
            Y = y;
            YDown = yd;
            Connector = connect;
            Solid = solid;
        }



        // ----- GET FUNCTIONS -----

        /// <summary>
        /// Converts the coordinates to doubles to allow
        /// easier input into arrays/searches.
        /// </summary>
        /// <param name="angle">Original [0], rotated [1], turned [2]</param>
        /// <returns>Coordinates of the piece as a double</returns>
        public double[] GetCoords(int angle)
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
                {
                    X = value;
                }
                else
                {
                    XRight = value;
                }
            }
            else
            {
                if (angle == 0 || angle == 1)
                {
                    Y = value;
                }
                else
                {
                    YDown = value;
                }
            }
        }
    }
}
