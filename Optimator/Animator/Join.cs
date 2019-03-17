using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override string ToString()
        {
            return X + Consts.ColonS + Y + Consts.ColonS + XRight + Consts.ColonS + YDown +
                Consts.SemiS + FlipAngle + Consts.SemiS + IndexSwitch;
        }

        /// <summary>
        /// Finds how much the join has changed from its original join position.
        /// </summary>
        /// <returns>double[] { X change, Y change }</returns>
        private double[] PointChange()
        {
            //if (Join == null)
            return new double[] { 0, 0 };
            //var spotCoords = Join.CurrentJoinCoords(GetAngles()[0], GetAngles()[1], middle);
            //var spotCoordsList = new List<double[]> { spotCoords };
            //spotCoords = SpinMeRound(spotCoordsList)[0];
            //return new double[] { spotCoords[0] - Join.X, spotCoords[1] - Join.Y };
        }
    }
}
