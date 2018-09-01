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
    public class Set
    {
        //Initialise Variables
        string name;
        List<string> data;
        List<Piece> piecesList = new List<Piece>();
        List<int> basePiecesList = new List<int>();

        const string folder = "\\Sets\\";
        const string pointsFolder = "\\Points\\";


        public Set(string inName)
        {
            SetName(inName);
            data = Utilities.ReadFile(Environment.CurrentDirectory + folder + name + ".txt");

            ConvertData();
        }

        /// <summary>
        /// Used in constructor to create pieces and assign them correct values.
        /// </summary>
        private void ConvertData()
        {
            for (int index = 0; index < data.Count; index++)
            {
                string[] dataSections = data[index].Split(new Char[] { ';' });

                // New Piece
                Piece WIP = new Piece(dataSections[0]);
                
                // If piece is not base
                if (index > 0)   //piecesList.Count
                {
                    WIP.AttachToPiece(piecesList[int.Parse(dataSections[2])], new Piece(dataSections[3], pointsFolder), new Piece(dataSections[1], pointsFolder));

                    basePiecesList.Add(int.Parse(dataSections[2]));

                    // Set x, y, rotation, turn, spin and sizeMod
                    WIP.SetValues(double.Parse(dataSections[4]), double.Parse(dataSections[5]), double.Parse(dataSections[6]),
                        double.Parse(dataSections[7]), double.Parse(dataSections[8]), double.Parse(dataSections[9]));

                }
                // If piece is base
                else
                {
                    basePiecesList.Add(-1);

                    // Set x, y, rotation, turn, spin and sizeMod
                    WIP.SetValues(double.Parse(dataSections[1]), double.Parse(dataSections[2]), double.Parse(dataSections[3]),
                        double.Parse(dataSections[4]), double.Parse(dataSections[5]), double.Parse(dataSections[6]));
                }

                WIP.SetPieceOf(this);
                piecesList.Add(WIP);

            }
        }


        // Get Functions
        public List<Piece> GetPiecesList()
        {
            return piecesList;
        }
        
        public List<string> GetData()
        {
            return data;
        }

        public List<int> GetBasePiecesList()
        {
            return basePiecesList;
        }

        public string GetName()
        {
            return name;
        }


        // Set Functions
        public void SetName(string inName)
        {
            name = inName;
        }
        
    }
}
