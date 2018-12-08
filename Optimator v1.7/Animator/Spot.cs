using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Piece Host { get; set; }
        public bool IsDrawn { get; set; }

        public double X { get; set; }
        public double XRight { get; set; }
        public double Y { get; set; }
        public double YDown { get; set; }
        #endregion


        /// <summary>
        /// Constructor for a drawn spot.
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        public Spot(Piece owner, double x, double y)
        {
            Host = owner;
            IsDrawn = true;
            X = x;
            XRight = x;
            Y = y;
            YDown = y;
        }

        /// <summary>
        /// Constructor for a spot built during refinement.
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="xr">Rotated X position</param>
        /// <param name="y">Y position</param>
        /// <param name="yd">Turned Y position</param>
        public Spot(Piece owner, double x, double xr, double y, double yd)
        {
            Host = owner;
            IsDrawn = false;
            X = x;
            XRight = xr;
            Y = y;
            YDown = yd;
        }
    }
}
