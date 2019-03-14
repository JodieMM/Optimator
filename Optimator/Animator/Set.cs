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
        public override string Version { get; }
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
            Version = data[0].Split(Constants.Semi)[1];
            Utilities.CheckValidVersion(Version);

            // Add all pieces to the list
            for (int index = 1; index < data.Count; index++)
            {
                string[] dataSections = data[index].Split(Constants.Semi);
                Piece WIP = new Piece(dataSections[0])
                {
                    PieceOf = this
                };
                PiecesList.Add(WIP);
            }

            // Add piece details
            for (int index = 1; index < data.Count; index++)
            {
                string[] dataSections = data[index].Split(Constants.Semi);
                string[] pieceData = dataSections[1].Split(Constants.Colon);
                Piece WIP = PiecesList[index];
                WIP.SetValues(double.Parse(pieceData[0]), double.Parse(pieceData[1]), double.Parse(pieceData[2]),
                        double.Parse(pieceData[3]), double.Parse(pieceData[4]), double.Parse(pieceData[5]));

                // Set base piece or attach piece to base
                if (dataSections.Length == 2)
                    BasePiece = WIP;
                else
                {
                    string[] spotCoords = dataSections[3].Split(Constants.Colon);
                    WIP.AttachToPiece(PiecesList[int.Parse(dataSections[2])], new Spot(double.Parse(spotCoords[0]), double.Parse(spotCoords[1]),
                        double.Parse(spotCoords[2]), double.Parse(spotCoords[3])), double.Parse(dataSections[4]), int.Parse(dataSections[5]));
                }
            }
        }

        /// <summary>
        /// Set constructor for creating a new set.
        /// </summary>
        public Set()
        {
            Name = "";
            Version = Constants.Version;
        }



        // ----- FUNCTIONS -----

        /// <summary>
        /// Gets set's current details in a string format.
        /// </summary>
        public override List<string> GetData()
        {
            // Type and Version
            List<string> newData = new List<string>
            {
                Constants.Set + Constants.Semi + Constants.Version
            };

            // Reset Set to Save
            BasePiece.R = 0; BasePiece.T = 0; BasePiece.S = 0;
            PiecesList = SortOrder();

            // Save Each Piece
            for (int index = 0; index < PiecesList.Count; index++)
            {
                Piece piece = PiecesList[index];
                string pieceDetails = piece.Name + Constants.SemiS + piece.X + Constants.ColonS + piece.Y + Constants.ColonS +
                        piece.R + Constants.ColonS + piece.T + Constants.ColonS + piece.S + Constants.ColonS + piece.SM;
                if (piece != BasePiece)
                    pieceDetails += Constants.SemiS + PiecesList.IndexOf(piece.AttachedTo) + Constants.SemiS + piece.Join.X + Constants.ColonS +
                        piece.Join.Y + Constants.ColonS + piece.Join.XRight + Constants.ColonS + piece.Join.YDown + Constants.SemiS +
                        piece.AngleFlip + Constants.SemiS + piece.IndexSwitch;
                newData.Add(pieceDetails);
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
        public override void Draw(Graphics g, Color? outline)
        {
            List<Piece> orderedPieces = SortOrder();
            foreach (Piece piece in orderedPieces)
                piece.Draw(g);
        }

        /// <summary>
        /// Finds the correct order to draw pieces so they are layered correctly.
        /// </summary>
        /// <returns>Ordered list of pieces</returns>
        private List<Piece> SortOrder()
        {
            // TODO: (SortOrder) Fix, including incorporating flip index
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
                        putInFront.Add(working);
                    else
                        order.Add(working);
                }
                // In Front of Base
                else if (index > baseIndex)
                {
                    if (working.GetAngles()[0] > working.AngleFlip && working.GetAngles()[0] < working.AngleFlip + 180)
                        order.Add(working);
                    else
                        putInFront.Add(working);
                }
                // Is Base
                else
                    order.Add(BasePiece);
                order.AddRange(putInFront);
            }
            return order;
        }
    }
}
