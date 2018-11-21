using System;
using System.Collections.Generic;

namespace Animator
{
    /// <summary>
    /// A collection of pieces and how they interact with each other.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class Set
    {
        #region Set Variables
        public string Name { get; }
        public List<string> Data { get; }
        public List<Piece> PiecesList { get; } = new List<Piece>();
        public Piece BasePiece { get; set; }
        #endregion


        /// <summary>
        /// Set constructor.
        /// </summary>
        /// <param name="inName">File name to load</param>
        public Set(string inName)
        {
            Name = inName;
            Data = Utilities.ReadFile(Environment.CurrentDirectory + Constants.SetsFolder + Name + Constants.Txt);
            ConvertData();
        }



        // ----- DATA FUNCTIONS -----

        /// <summary>
        /// Used in constructor to create pieces and assign them correct values.
        /// </summary>
        private void ConvertData()
        {
            for (int index = 0; index < Data.Count; index++)
            {
                string[] dataSections = Data[index].Split(Constants.Semi);
                Piece WIP = new Piece(dataSections[0]);
                if (dataSections.Length == 7) { BasePiece = WIP; }

                if (BasePiece == WIP)
                {
                    WIP.AttachToPiece(PiecesList[int.Parse(dataSections[2])], new PointSpot(dataSections[3], PiecesList[int.Parse(dataSections[2])]), 
                        new PointSpot(dataSections[1], WIP), bool.Parse(dataSections[10]), double.Parse(dataSections[11]));

                    // Set Attributes
                    WIP.SetValues(double.Parse(dataSections[4]), double.Parse(dataSections[5]), double.Parse(dataSections[6]),
                        double.Parse(dataSections[7]), double.Parse(dataSections[8]), double.Parse(dataSections[9]));
                }
                else
                {
                    // Set Attributes
                    WIP.SetValues(double.Parse(dataSections[1]), double.Parse(dataSections[2]), double.Parse(dataSections[3]),
                        double.Parse(dataSections[4]), double.Parse(dataSections[5]), double.Parse(dataSections[6]));
                }

                WIP.PieceOf = this;
                PiecesList.Add(WIP);
            }
        }

        /// <summary>
        /// Takes the current state and saves it in the data.
        /// </summary>
        public void CreateData()
        {

        }    
    }
}
