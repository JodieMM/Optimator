using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Animator
{
    /// <summary>
    /// A point used for indicating the position
    /// pieces connect in a set.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class PointSpot
    {
        #region Point Variables
        public string Name { get; set; }
        public List<string> Data { get; set; }
        private readonly Piece host;

        // Attributes
        public double X { get; set; }
        public double Y { get; set; }
        public double XRight { get; set; }
        public double YDown { get; set; }
        public Color FillColour { get; set; } = Color.Black;
        #endregion


        /// <summary>
        /// Point constructor for loading an existing point.
        /// </summary>
        /// <param name="inName">Point to load</param>
        /// <param name="owner">Piece point is in reference to</param>
        public PointSpot(string inName, Piece owner)
        {
            Name = inName;
            host = owner;
            Data = Utilities.ReadFile(Environment.CurrentDirectory + Constants.PointsFolder 
                + owner.Name + "//" + Name + Constants.Txt);
        }

        /// <summary>
        /// Point constructor for creating a new point.
        /// </summary>
        public PointSpot(int pointIndex, Piece owner)
        {
            Name = pointIndex.ToString();
            host = owner;
            Data = new List<string>();
            X = 150; Y = 150; XRight = 150; YDown = 150;
            FillColour = Constants.randomColours[Utilities.Modulo(pointIndex, Constants.randomColours.Count())];
        }



        // ----- FUNCTIONS -----

        /// <summary>
        /// Gets the coordinates of the point based on the host Piece's angles
        /// </summary>
        /// <returns></returns>
        public double[,] GetCurrentPoints()
        {
            string[] dataValues = Data[Utilities.FindRow(host.GetAngles()[0], host.GetAngles()[1], Data, 0)].Split(new Char[] { ';' });
            return new double[,] { { dataValues[2][0], dataValues[2][3] } };
        }

        /// <summary>
        /// Saves the current point spot to a file.
        /// Used when creating the spot for the first time.
        /// </summary>
        public void SavePointSpot()
        {
            // ** TO DO
        }
    }
}
