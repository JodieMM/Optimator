using System.Windows.Forms;

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
        /// <param name="angle">1 for rotated, 2 for turn</param>
        /// <param name="degree">New r or t value</param>
        public State(State basis, int angle, double degree)
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
            // NOTE: AttachedTo != null ? new double[] { State.X + AttachedTo.GetCoords()[0] + Join.CurrentDifference()[0],
            // State.Y + AttachedTo.GetCoords()[1] + Join.CurrentDifference()[1] } : 
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
            X = board.Width / 2.0;
            Y = board.Height / 2.0;
        }



        // ----- GENERAL FUNCTIONS

        /// <summary>
        /// Subtracts a state from this one.
        /// </summary>
        /// <param name="state2">The state to subtract</param>
        /// <returns>This state - the supplied state</returns>
        public State Subtract(State state2)
        {
            return new State(X - state2.X, Y - state2.Y, R - state2.R, T - state2.T, S - state2.S, SM / state2.SM);
        }
    }
}
