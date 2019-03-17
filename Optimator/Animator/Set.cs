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
            List<string> data = Utils.ReadFile(Utils.GetDirectory(Consts.SetsFolder, Name, Consts.Optr));
            Version = data[0].Split(Consts.Semi)[1];
            Utils.CheckValidVersion(Version);

            // Add all pieces to the list
            for (int index = 1; index < data.Count; index++)
            {
                string[] dataSections = data[index].Split(Consts.Semi);
                Piece WIP = new Piece(dataSections[0])
                {
                    PieceOf = this
                };
                PiecesList.Add(WIP);
            }

            // Add piece details
            for (int index = 1; index < data.Count; index++)
            {
                string[] dataSections = data[index].Split(Consts.Semi);
                string[] pieceData = dataSections[1].Split(Consts.Colon);
                Piece WIP = PiecesList[index];
                WIP.SetValues(double.Parse(pieceData[0]), double.Parse(pieceData[1]), double.Parse(pieceData[2]),
                        double.Parse(pieceData[3]), double.Parse(pieceData[4]), double.Parse(pieceData[5]));

                // Set base piece or attach piece to base
                if (dataSections.Length == 2)
                    BasePiece = WIP;
                else
                {
                    string[] spotCoords = dataSections[3].Split(Consts.Colon);
                    WIP.AttachToPiece(PiecesList[int.Parse(dataSections[2])], new Join(WIP, double.Parse(spotCoords[0]), double.Parse(spotCoords[1]),
                        double.Parse(spotCoords[2]), double.Parse(spotCoords[3]), double.Parse(dataSections[4]), int.Parse(dataSections[5])));
                }
            }
        }

        /// <summary>
        /// Set constructor for creating a new set.
        /// </summary>
        public Set()
        {
            Name = "";
            Version = Consts.Version;
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
                Consts.Set + Consts.Semi + Consts.Version
            };

            // Reset Set to Save
            BasePiece.R = 0; BasePiece.T = 0; BasePiece.S = 0;
            PiecesList = SortOrder();

            // Save Each Piece
            for (int index = 0; index < PiecesList.Count; index++)
            {
                Piece piece = PiecesList[index];
                string pieceDetails = piece.Name + Consts.SemiS + piece.X + Consts.ColonS + piece.Y + Consts.ColonS +
                        piece.R + Consts.ColonS + piece.T + Consts.ColonS + piece.S + Consts.ColonS + piece.SM;
                if (piece != BasePiece)
                    pieceDetails += Consts.SemiS + PiecesList.IndexOf(piece.AttachedTo) + Consts.SemiS + piece.Join.ToString();
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
            // Waiting Task: SortOrder: Fix, including incorporating flip index
            List<Piece> order = new List<Piece>();
            List<Piece> putInFront = new List<Piece>();
            int baseIndex = PiecesList.IndexOf(BasePiece);

            for (int index = 0; index < PiecesList.Count; index++)
            {
                Piece working = PiecesList[index];

                // Behind Base
                if (index < baseIndex)
                {
                    if (working.GetAngles()[0] > working.Join.FlipAngle && working.GetAngles()[0] < working.Join.FlipAngle + 180)
                        putInFront.Add(working);
                    else
                        order.Add(working);
                }
                // In Front of Base
                else if (index > baseIndex)
                {
                    if (working.GetAngles()[0] > working.Join.FlipAngle && working.GetAngles()[0] < working.Join.FlipAngle + 180)
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
