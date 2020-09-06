using System.Drawing;
using static Optimator.Consts;

namespace Optimator
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
        public float X { get; set; }
        public float XRight { get; set; }
        public float Y { get; set; }
        public float YDown { get; set; }

        public SpotOption Connector { get; set; }
        public float Tension { get; set; } = 0.5F;
        public ConnectorDet Line { get; set; } = new ConnectorDet();
        #endregion


        /// <summary>
        /// Constructor for a new spot.
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="xr">Rotated X position</param>
        /// <param name="yd">Turned Y position</param>
        /// <param name="connect">Connector from this spot to the next</param>
        /// <param name="tension">Tension of curve</param>
        /// /// <param name="drawn">DrawLevel integer</param>
        public Spot(float x, float y)
        {
            X = XRight = x;
            Y = YDown = y;
            Connector = SpotOption.Corner;
            Tension = 0.5F;
            Line = new ConnectorDet();
        }

        /// <summary>
        /// Constructor for a coord spot.
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="connect">Connector from this spot to the next</param>
        /// <param name="tension">Tension of curve</param>
        public Spot(float x, float y, SpotOption connect, float tension, ConnectorDet conDet)
        {
            X = x;
            Y = y;
            Connector = connect;
            Tension = tension;
            Line = conDet;
        }

        /// <summary>
        /// Constructor from save file.
        /// </summary>
        /// <param name="data"></param>
        public Spot(string data)
        {
            var splitData = data.Split(Semi);       
            var coords = Utils.ConvertStringArrayToFloats(splitData[0].Split(Colon));
            var spotDets = splitData[1].Split(Colon);
            X = coords[0];
            Y = coords[1];
            XRight = coords[2];
            YDown = coords[3];
            Connector = (SpotOption)int.Parse(spotDets[0]);
            Tension = float.Parse(spotDets[1]);
            Line = new ConnectorDet(splitData[2]);
        }



        // ----- GET FUNCTIONS -----

        /// <summary>
        /// Returns the save data of the spot.
        /// </summary>
        /// <returns>Spot data</returns>
        public override string ToString()
        {
            return X + ColonS + Y + ColonS + XRight + ColonS + YDown + SemiS +
                Connector.ToString("d") + ColonS + Tension + SemiS + Line.ToString();
        }

        /// <summary>
        /// Get a single coord by integer.
        /// </summary>
        /// <param name="angle">0 X, 1 Y, 2 XR, 3 YD</param>
        /// <returns>The coord value represented by the provided angle</returns>
        public float GetCoord(int angle)
        {
            switch (angle)
            {
                case 1:
                    return Y;
                case 2:
                    return XRight;
                case 3:
                    return YDown;
                default:
                    return X;
            }
        }



        // ----- SET FUNCTIONS -----

        /// <summary>
        /// Sets a coordinate value based on the inputs provided.
        /// </summary>
        /// <param name="angle">The angle the coord is affected in</param>
        /// <param name="xy">Whether the x (0) or y (1) coord is changed</param>
        /// <param name="value">The new value for the coord</param>
        public void SetCoords(int angle, int xy, float value)
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
        /// Converts the coordinates to floats to allow
        /// easier input into arrays/searches.
        /// </summary>
        /// <param name="angle">Original [0], rotated [1], turned [2]</param>
        /// <returns>Coordinates of the piece as a float</returns>
        public float[] GetCoordCombination(int angle = 0)
        {
            switch (angle)
            {
                case 1:
                    return new float[] { XRight, Y };
                case 2:
                    return new float[] { X, YDown };
                default:
                    return new float[] { X, Y };
            }
        }

        /// <summary>
        /// Returns the coordinate at a border position.
        /// </summary>
        /// <param name="r">Rotation border</param>
        /// <param name="t">Turn border</param>
        /// <returns>Spot at provided angle</returns>
        public Spot GetCoordAtAnchorAngle(int r, int t)
        {
            // int 0 (<90), 1 (<180), 2 (<270), 3 (>=270)
            float[] coord = new float[2];
            coord[0] = r == 0 ? X : r == 1 ? XRight : r == 2 ? -X : -XRight;
            coord[1] = t == 0 ? Y : t == 1 ? YDown : t == 2 ? -Y : -YDown;
            return new Spot(coord[0], coord[1], Connector, Tension, Line);
        }
    }
}
