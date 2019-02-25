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
        public double[] GetCurrentCoords(double r, double t)
        {
            double[] currentCoords = new double[2];

            // X / Rotation


            // 0-90 : X -> XR
            // 90 - 180: XR -> Opp X Flipped Middle
            // 180 - 270: Opp X Flipped Middle -> Opp XR Flipped Middle
            // 270 - 360/0: Opp XR Flipped Middle -> X

            // TODO &Joins

            //double rMod = (dataRow.RotFrom == dataRow.RotTo) ? 0 : (R - dataRow.RotFrom) / (dataRow.RotTo - dataRow.RotFrom);
            //double tMod = (dataRow.TurnFrom == dataRow.TurnTo) ? 0 : (T - dataRow.TurnFrom) / (dataRow.TurnTo - dataRow.TurnFrom);
            // new double[] { (currentSpot.X + (currentSpot.XRight - currentSpot.X) * rMod) - Join.X,
            //(currentSpot.Y + (currentSpot.YDown - currentSpot.Y) * tMod) - Join.Y };



            //// Find Multipliers - How far into the rotation/turn range is required
            //double rotationMultiplier = dataRow.RotFrom == dataRow.RotTo ? (GetAngles()[0] - dataRow.RotFrom) / (dataRow.RotTo - dataRow.RotFrom) : 0;
            //double turnMultiplier = dataRow.TurnFrom == dataRow.TurnTo ? (GetAngles()[1] - dataRow.TurnFrom) / (dataRow.TurnTo - dataRow.TurnFrom) : 0;

            //// Rotation Adjustment
            //foreach (Spot spot in spots)
            //{
            //    if (dataRow.RotTo != dataRow.RotFrom)
            //        currentPoints.Add(new double[] { spot.X + (spot.XRight - spot.X) * rotationMultiplier, spot.Y });
            //    else
            //        currentPoints.Add(new double[] { spot.X, spot.Y });
            //}

            //// Turn Adjustment
            //for (int index = 0; index < spots.Count; index++)
            //    if (dataRow.TurnTo != dataRow.TurnFrom)
            //        currentPoints[index][1] += (spots[index].YDown - spots[index].Y) * turnMultiplier;

            return new double[] { 0, 0 };
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
