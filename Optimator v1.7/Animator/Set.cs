using System.Collections.Generic;

namespace Animator
{
    /// <summary>
    /// A collection of pieces and how they interact with each other.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class Set : Part
    {
        #region Set Variables
        public override string Name { get; set; }
        public override List<string> Data { get; set; } = new List<string>();
        public List<Piece> PiecesList { get; set; } = new List<Piece>();
        public Piece BasePiece { get; set; }
        #endregion


        /// <summary>
        /// Set constructor.
        /// </summary>
        /// <param name="inName">File name to load</param>
        public Set(string inName)
        {
            Name = inName;
            Data = Utilities.ReadFile(Utilities.GetDirectory(Constants.SetsFolder, Name, Constants.Txt));
            for (int index = 0; index < Data.Count; index++)
            {
                string[] dataSections = Data[index].Split(Constants.Semi);
                Piece WIP = new Piece(dataSections[0])
                {
                    PieceOf = this
                };
                PiecesList.Add(WIP);
            }
            for (int index = 0; index < Data.Count; index++)
            {
                string[] dataSections = Data[index].Split(Constants.Semi);
                Piece WIP = PiecesList[index];
                if (dataSections.Length == 7)
                {
                    BasePiece = WIP;
                    WIP.SetValues(double.Parse(dataSections[1]), double.Parse(dataSections[2]), double.Parse(dataSections[3]),
                        double.Parse(dataSections[4]), double.Parse(dataSections[5]), double.Parse(dataSections[6]));
                }
                else
                {
                    WIP.AttachToPiece(PiecesList[int.Parse(dataSections[2])], new Join(dataSections[3], PiecesList[int.Parse(dataSections[2])]),
                        new Join(dataSections[1], WIP), bool.Parse(dataSections[10]), double.Parse(dataSections[11]));
                    WIP.SetValues(double.Parse(dataSections[4]), double.Parse(dataSections[5]), double.Parse(dataSections[6]),
                        double.Parse(dataSections[7]), double.Parse(dataSections[8]), double.Parse(dataSections[9]));
                }
            }
        }

        /// <summary>
        /// Set constructor for creating a new set.
        /// </summary>
        public Set()
        {
            Name = Constants.WIPName;
        }



        // ----- FUNCTIONS -----

        /// <summary>
        /// Takes the current state and saves it in the data.
        /// </summary>
        public void CreateData()
        {
            Data.Clear();
            FindBasePiece();
            BasePiece.R = 0; BasePiece.T = 0; BasePiece.S = 0;
            PiecesList = Utilities.SortOrder(PiecesList);
            int baseIndex = PiecesList.IndexOf(BasePiece);
            for (int index = 0; index < PiecesList.Count; index++)
            {
                Piece piece = PiecesList[index];
                if (piece == BasePiece)
                {
                    Data.Add(piece.Name + Constants.SemiS + piece.X + Constants.SemiS + piece.Y + Constants.SemiS +
                        piece.R + Constants.SemiS + piece.T + Constants.SemiS + piece.S + Constants.SemiS + piece.SM);
                }
                else
                {
                    Data.Add(piece.Name + Constants.SemiS + piece.OwnPoint.Name + Constants.SemiS + PiecesList.IndexOf(piece.AttachedTo) +
                        Constants.SemiS + piece.AttachPoint.Name + Constants.SemiS + piece.X + Constants.SemiS + piece.Y + Constants.SemiS +
                        piece.R + Constants.SemiS + piece.T + Constants.SemiS + piece.S + Constants.SemiS + piece.SM + Constants.SemiS +
                        (index > baseIndex) + Constants.SemiS + piece.AngleFlip);
                }
            }
        }

        /// <summary>
        /// Finds the base piece from the pieceslist.
        /// </summary>
        private void FindBasePiece()
        {
            foreach (Piece piece in PiecesList)
            {
                if (piece.AttachedTo == null)
                {
                    BasePiece = piece;
                    return;
                }
            }
        }
    }
}
