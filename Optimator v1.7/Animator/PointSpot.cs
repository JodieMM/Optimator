using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animator
{
    public class PointSpot
    {
        // Point Variables
        public string Name { get; set; }
        public List<string> Data { get; set; }
        private readonly Piece host;

        // Attributes
        public double X { get; set; }
        public double Y { get; set; }
        private readonly Color FillColour = Color.Black;


        /// <summary>
        /// Constructs a point and stores relevant data
        /// </summary>
        /// <param name="inName"></param>
        /// <param name="owner"></param>
        public PointSpot(string inName, Piece owner)
        {
            Name = inName;
            host = owner;
            Data = Utilities.ReadFile(Environment.CurrentDirectory + Constants.PointsFolder + Name + ".txt");
        }

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
