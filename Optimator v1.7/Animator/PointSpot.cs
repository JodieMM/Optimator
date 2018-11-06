﻿using System;
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
        private string Name { get; set; }
        private List<string> Data { get; set; }
        private readonly Piece host;

        // Attributes
        private double X { get; set; }
        private double Y { get; set; }
        private readonly Color FillColour = Color.Black;


        public PointSpot(string inName, Piece owner)
        {
            Name = inName;
            host = owner;
            Data = Utilities.ReadFile(Environment.CurrentDirectory + Constants.PointsFolder + Name + ".txt");
        }

        public void SetValues(double x, double y)
        {
            X = x; Y = y;
        }

        public double[,] GetCurrentPoints()
        {
            string[] dataValues = Data[Utilities.FindRow(host.GetAngles()[0], host.GetAngles()[1], Data, 0)].Split(new Char[] { ';' });
            return new double[,] { { dataValues[2][0], dataValues[2][3] } };
        }


        // GET COORDS AT POINTS
    }
}
