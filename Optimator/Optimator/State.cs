using System.Windows.Forms;

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
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;
        public float R { get; set; } = 0;
        public float T { get; set; } = 0;
        public float S { get; set; } = 0;
        public float SM { get; set; } = 1;
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
        public State(float x, float y, float r, float t, float s, float sm)
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
        public State(State basis, int angle, float degree, float degree2 = 0)
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
        public void SetValues(float x, float y, float r, float t, float s, float sm)
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
            X = board.Width / 2.0F;
            Y = board.Height / 2.0F;
        }
    }
}
