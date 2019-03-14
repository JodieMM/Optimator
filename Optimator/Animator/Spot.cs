﻿using System.Drawing;

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
        public double CurrentX { get; set; }

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
            Connector = connect ?? Consts.connectorOptions[0];
            Solid = solid ?? Consts.solidOptions[0];
            DrawnLevel = drawn;
        }



        // ----- GET FUNCTIONS -----

        /// <summary>
        /// Returns the save data of the spot.
        /// </summary>
        /// <returns>Spot data</returns>
        public override string ToString()
        {
            return X + Consts.ColonS + Y + Consts.ColonS + XRight + Consts.ColonS + YDown + Consts.SemiS +
                Connector + Consts.SemiS + Solid;
        }

        /// <summary>
        /// Gets either the MatchX or MatchY.
        /// </summary>
        /// <param name="xy"></param>
        /// <returns></returns>
        public Spot GetMatch(int xy)
        {
            if (xy == 0)
                return MatchX;
            else
                return MatchY;
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

        /// <summary>
        /// Sets either the MatchX or MatchY to assigned value.
        /// </summary>
        /// <param name="xy">MatchX (0) or MatchY(1)</param>
        /// <param name="match">Spot to assign</param>
        public void SetMatch(int xy, Spot match)
        {
            if (xy == 0)
                MatchX = match;
            else
                MatchY = match;
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



        // ----- COORDINATE FUNCTIONS -----

        /// <summary>
        /// Converts the coordinates to doubles to allow
        /// easier input into arrays/searches.
        /// </summary>
        /// <param name="angle">Original [0], rotated [1], turned [2], current [3], current down [4]</param>
        /// <returns>Coordinates of the piece as a double</returns>
        public double[] GetCoordCombination(int angle = 0)
        {
            switch (angle)
            {
                case 1:
                    return new double[] { XRight, Y };
                case 2:
                    return new double[] { X, YDown };
                case 3:
                    return new double[] { CurrentX, Y };
                case 4:
                    return new double[] { CurrentX, YDown };
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
        public double[] CurrentJoinCoords(double r, double t, double[] mid)
        {
            var currentCoords = new double[2];
            double lower;
            double upper;
            int bottomAngle;

            var angle = new double[] { r, t };
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
                    upper = Utilities.FlipPoint(mid[index], initial[index]);
                    bottomAngle = 90;
                }
                else if (angle[index] < 270)
                {
                    lower = Utilities.FlipPoint(mid[index], initial[index]);
                    upper = Utilities.FlipPoint(mid[index], angled[index]);
                    bottomAngle = 180;
                }
                else
                {
                    lower = Utilities.FlipPoint(mid[index], angled[index]);
                    upper = initial[index];
                    bottomAngle = 270;
                }
                currentCoords[index] = lower + (upper - lower) * ((angle[index] - bottomAngle) / 90.0);
            }
            return currentCoords;
        }

        /// <summary>
        /// Finds the current X value of the spot based on the piece's rotation.
        /// </summary>
        /// <param name="angle">The rotation or turn of the piece</param>
        /// <param name="mid">The middle of the piece</param>
        /// <param name="xy">Finding current x (0) or y (1)</param>
        /// <returns>The current value</returns>
        public double CalculateCurrentValue(double angle, double[] mid, int xy = 1)
        {
            double lower;
            double upper;
            int bottomAngle;

            var original = xy == 0 ? Y : X;
            var angled = xy == 0 ? YDown : XRight;
            var matchOrig = xy == 0 ? MatchX == null ? original : MatchX.Y : MatchY == null ? original :  MatchY.X;
            var matchAng = xy == 0 ? MatchX == null ? angled : MatchX.YDown : MatchY == null ? angled : MatchY.XRight;

            if (angle < 90)
            {
                lower = original;
                upper = angled;
                bottomAngle = 0;
            }
            else if (angle < 180)
            {
                lower = angled;
                upper = Utilities.FlipPoint(mid[xy], matchOrig);
                bottomAngle = 90;
            }
            else if (angle < 270)
            {
                lower = Utilities.FlipPoint(mid[xy], matchOrig);
                upper = Utilities.FlipPoint(mid[xy], matchAng);
                bottomAngle = 180;
            }
            else
            {
                lower = Utilities.FlipPoint(mid[xy], matchAng);
                upper = original;
                bottomAngle = 270;
            }
            return lower + (upper - lower) * ((angle - bottomAngle) / 90.0);
        }
    }
}
