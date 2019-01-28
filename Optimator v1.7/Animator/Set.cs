using System.Collections.Generic;
using System.Drawing;

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
            List<string> data = Utilities.ReadFile(Utilities.GetDirectory(Constants.SetsFolder, Name, Constants.Txt));
            for (int index = 0; index < data.Count; index++)
            {
                string[] dataSections = data[index].Split(Constants.Semi);
                Piece WIP = new Piece(dataSections[0])
                {
                    PieceOf = this
                };
                PiecesList.Add(WIP);
            }
            for (int index = 0; index < data.Count; index++)
            {
                string[] dataSections = data[index].Split(Constants.Semi);
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
        /// Gets set's current details in a string format.
        /// </summary>
        public override List<string> GetData()
        {
            List<string> newData = new List<string>();

            // Reset Set to Save
            BasePiece.R = 0; BasePiece.T = 0; BasePiece.S = 0;
            PiecesList = SortOrder();
            int baseIndex = PiecesList.IndexOf(BasePiece);

            // Save Each Piece
            for (int index = 0; index < PiecesList.Count; index++)
            {
                Piece piece = PiecesList[index];
                if (piece == BasePiece)
                {
                    newData.Add(piece.Name + Constants.SemiS + piece.X + Constants.SemiS + piece.Y + Constants.SemiS +
                        piece.R + Constants.SemiS + piece.T + Constants.SemiS + piece.S + Constants.SemiS + piece.SM);
                }
                else
                {
                    newData.Add(piece.Name + Constants.SemiS + piece.OwnPoint.Name + Constants.SemiS + PiecesList.IndexOf(piece.AttachedTo) +
                        Constants.SemiS + piece.AttachPoint.Name + Constants.SemiS + piece.X + Constants.SemiS + piece.Y + Constants.SemiS +
                        piece.R + Constants.SemiS + piece.T + Constants.SemiS + piece.S + Constants.SemiS + piece.SM + Constants.SemiS +
                        (index > baseIndex) + Constants.SemiS + piece.AngleFlip);
                }
            }
            return newData;
        }

        /// <summary>
        /// Returns the piece representation of a set.
        /// </summary>
        /// <returns>Base piece</returns>
        public override Piece ToPiece()
        {
            return BasePiece;
        }

        /// <summary>
        /// Returns itself to accommodate pieces as parts.
        /// </summary>
        /// <returns>Itself</returns>
        public override Set ToSet()
        {
            return this;
        }

        /// <summary>
        /// Draws the set to the provided graphics.
        /// </summary>
        /// <param name="g">Provided graphics</param>
        public override void Draw(Graphics g)
        {
            //TODO: Sort order!
            //List<Piece> orderedPieces = Utilities.SortOrder(partsList); <<< OLD
            foreach (Piece piece in PiecesList)
            {
                piece.Draw(g);
            }
        }

        /// <summary>
        /// Finds the correct order to draw pieces so they are layered correctly.
        /// </summary>
        /// <returns>Ordered list of pieces</returns>
        private List<Piece> SortOrder() //TODO: Check
        {
            List<Piece> order = new List<Piece>();
            List<Piece> putInFront = new List<Piece>();
            int baseIndex = PiecesList.IndexOf(BasePiece);

            for (int index = 0; index < PiecesList.Count; index++)
            {
                Piece working = PiecesList[index];

                // Behind Base
                if (index < baseIndex)
                {
                    if (working.GetAngles()[0] > working.AngleFlip && working.GetAngles()[0] < working.AngleFlip + 180)
                    {
                        putInFront.Add(working);
                    }
                    else
                    {
                        order.Add(working);
                    }
                }
                // In Front of Base
                else if (index > baseIndex)
                {
                    if (working.GetAngles()[0] > working.AngleFlip && working.GetAngles()[0] < working.AngleFlip + 180)
                    {
                        order.Add(working);
                    }
                    else
                    {
                        putInFront.Add(working);
                    }
                }
                // Is Base
                else
                {
                    order.Add(BasePiece);
                }
                order.AddRange(putInFront);
            }
            return order;
        }
    }
}
