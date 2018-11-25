﻿using System;
using System.Collections.Generic;
using System.Drawing;

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
        private readonly Color FillColour = Color.Black;
        #endregion


        /// <summary>
        /// Point constructor.
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
    }
}
