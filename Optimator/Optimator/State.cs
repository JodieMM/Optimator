﻿using System.Windows.Forms;

namespace Optimator
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
        public double SM { get; set; } = 1;
        #endregion


        /// <summary>
        /// Constructor for a new state.
        /// </summary>
        public State()
        {

        }

        /// <summary>
        /// Constructor for loading state.
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

        /// <summary>
        /// Constructor for state with modified r or t.
        /// </summary>
        /// <param name="basis">Original state</param>
        /// <param name="angle">1 for rotated, 2 for turn, 3 for both</param>
        /// <param name="degree">New r or t value</param>
        /// <param name="degree2">Potential t value if angle is 3</param>
        public State(State basis, int angle, double degree, double degree2 = 0)
        {
            X = basis.X;
            Y = basis.Y;
            S = basis.S;
            SM = basis.SM;
            if (angle == 1)
            {
                R = degree % 360;
                T = basis.T;
            }
            else if (angle == 2)
            {
                T = degree % 360;
                R = basis.R;
            }
            else if (angle == 3)
            {
                R = degree % 360;
                T = degree2 % 360;
            }
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
        /// Gets the X and Y values of the piece.
        /// </summary>
        /// <returns>double[] { X, Y }</returns>
        public double[] GetCoords()
        {
            return new double[] { X, Y };
        }

        /// <summary>
        /// Gets the rotation, turn and spin of the piece.
        /// </summary>
        /// <returns>double[] { Rotation, Turn, Spin }</returns>
        public double[] GetAngles()
        {
            return new double[3] { R, T, S };
            //R + S * Math.Sin(Utilities.ToRad(T));      // NOTE: Unsure if accurate
            //T + S * Math.Sin(Utilities.ToRad(R));
            //S * Math.Cos(Utilities.ToRad(R)); // + S * Math.Cos(Utilities.ToRad(T));
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

        /// <summary>
        /// Sets the middle of the piece to the centre of its
        /// display window.
        /// </summary>
        /// <param name="board">The board to centre on</param>
        public void SetCoordsBasedOnBoard(PictureBox board)
        {
            // CLEANING: Check validity/necessity of this function now 0,0 considered centre
            // CLEANING: If this is removed, modify SetsTab GetFormSizing
            X = board.Width / 2.0;
            Y = board.Height / 2.0;
        }
    }
}
