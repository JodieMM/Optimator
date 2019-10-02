namespace Animator
{
    /// <summary>
    /// A class to maintain the current position, angle and size of a part.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class State
    {
        #region State Variables
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public double R { get; set; } = 0;
        public double T { get; set; } = 0;
        public double S { get; set; } = 0;
        public double SM { get; set; } = 100;
        #endregion


        /// <summary>
        /// Constructor for a new state.
        /// </summary>
        public State()
        {

        }


        /// <summary>
        /// Constructor for loading State.
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        /// <param name="r">Rotation angle</param>
        /// <param name="t">Turn angle</param>
        /// <param name="s">Spin angle</param>
        /// <param name="sm">Size modifier</param>
        public State(double x, double y, double r, double t, double s, double sm)
        {
            X = x;
            Y = y;
            R = r;
            T = t;
            S = s;
            SM = sm;
        }



        // ----- GET FUNCTIONS -----
        
        /// <summary>
        /// Converts the state into a string format for saving.
        /// </summary>
        /// <returns>A string representing the state</returns>
        public string GetData()
        {
            return X + Consts.ColonS + Y + Consts.ColonS + R + Consts.ColonS + T + Consts.ColonS + S + Consts.ColonS + SM;
        }

        /// <summary>
        /// Gets the X and Y values of the piece
        /// </summary>
        /// <returns>double[] { X, Y }</returns>
        public double[] GetCoords()
        {
            return new double[] { X, Y };
            // NOTE: AttachedTo != null ? new double[] { State.X + AttachedTo.GetCoords()[0] + Join.CurrentDifference()[0],
            // State.Y + AttachedTo.GetCoords()[1] + Join.CurrentDifference()[1] } : 
        }

        /// <summary>
        /// Gets the rotation, turn and spin of the piece
        /// </summary>
        /// <returns>double[] { Rotation, Turn, Spin }</returns>
        public double[] GetAngles()
        {
            var angles = new double[3];
            angles[0] = R;      // + S * Math.Sin(Utilities.ToRad(T));      // Unsure if accurate
            angles[1] = T;      //+ S * Math.Sin(Utilities.ToRad(R));
            angles[2] = S;      //* Math.Cos(Utilities.ToRad(R)); // + S * Math.Cos(Utilities.ToRad(T));
            return angles;

            // NOTE: Attached angles
            //// Build Off Attached
            //if (AttachedTo != null)
            //{
            //    angles[0] += AttachedTo.GetAngles()[0];
            //    angles[1] += AttachedTo.GetAngles()[1];
            //    angles[2] += AttachedTo.GetAngles()[2];
            //}

            //// Modulus of 360 degrees
            //angles[0] = angles[0] % 360;
            //angles[1] = angles[1] % 360;
            //angles[2] = angles[2] % 360;
        }

        /// <summary>
        /// Converts the size mod into a decimal rather than a percentage.
        /// </summary>
        /// <returns>Size as decimal</returns>
        public double GetSizeMod()
        {
            return SM / 100.0;
            // NOTE: (State.SM / 100.0) * (AttachedTo.GetSizeMod())
        }



        // ----- SET FUNCTIONS -----

        /// <summary>
        /// Sets all of the position/angle/size parameters at once.
        /// </summary>
        /// <param name="x">New X Coord</param>
        /// <param name="y">New Y Coord</param>
        /// <param name="r">New Rotation</param>
        /// <param name="t">New Turn</param>
        /// <param name="s">New Spin</param>
        /// <param name="sm">New Size Modifier</param>
        public void SetValues(double x, double y, double r, double t, double s, double sm)
        {
            X = x;
            Y = y;
            R = r;
            T = t;
            S = s;
            SM = sm;
        }
    }
}
