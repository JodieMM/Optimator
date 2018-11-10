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
    /// <summary>
    /// A collection of pieces and how they interact with each other.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class Set
    {
        // Set Variables
        public string Name { get; set; }
        public List<string> Data { get; set; }
        List<Piece> piecesList = new List<Piece>();
        List<int> basePiecesList = new List<int>();



        /// <summary>
        /// Set constructor.
        /// </summary>
        /// <param name="inName"></param>
        public Set(string inName)
        {
            Name = inName;
            Data = Utilities.ReadFile(Environment.CurrentDirectory + Constants.SetsFolder + Name + ".txt");
            ConvertData();
        }



        // ----- DATA FUNCTIONS

        /// <summary>
        /// Used in constructor to create pieces and assign them correct values.
        /// </summary>
        private void ConvertData()
        {
            for (int index = 0; index < Data.Count; index++)
            {
                string[] dataSections = Data[index].Split(Constants.Semi);

                // New Piece
                Piece WIP = new Piece(dataSections[0]);
                
                // If piece is not base
                if (index > 0)   //piecesList.Count
                {
                    WIP.AttachToPiece(piecesList[int.Parse(dataSections[2])], new PointSpot(dataSections[3], piecesList[int.Parse(dataSections[2])]), 
                        new PointSpot(dataSections[1], WIP), bool.Parse(dataSections[10]), double.Parse(dataSections[11]));

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

                WIP.PieceOf = this;
                piecesList.Add(WIP);

            }
        }

        /// <summary>
        /// Takes the current state and saves it in the data.
        /// </summary>
        public void CreateData()
        {

        }



        // ----- GET FUNCTIONS -----

        /// <summary>
        /// Returns the list of pieces that make up the set.
        /// </summary>
        /// <returns>List of pieces.</returns>
        public List<Piece> GetPiecesList()
        {
            return piecesList;
        }

        /// <summary>
        /// Gets the base piece indexes.
        /// </summary>
        /// <returns>List of base piece indexes</returns>
        public List<int> GetBasePiecesList()
        {
            return basePiecesList;
        }        
    }
}
