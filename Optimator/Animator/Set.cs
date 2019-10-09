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
        public override State State { get; set; }

        public List<Piece> PiecesList { get; set; } = new List<Piece>();
        public Piece BasePiece { get; set; }

        // Base Piece --> Attached Pieces
        public Dictionary<Piece, List<Piece>> JoinedPieces { get; set; } = new Dictionary<Piece, List<Piece>>();  
        // Attached Piece --> Join
        public Dictionary<Piece, Join> JoinsIndex { get; set; } = new Dictionary<Piece, Join>();
        #endregion


        /// <summary>
        /// Set constructor.
        /// </summary>
        /// <param name="inName">File name to load</param>
        public Set(string inName)
        {
            Name = inName;
            var data = Utils.ReadFile(Utils.GetDirectory(Consts.SetsFolder, Name, Consts.Optr));
            Version = data[0].Split(Consts.Semi)[1];
            Utils.CheckValidVersion(Version);
            State = new State();

            // Pieces List
            int index = 1;
            while (data[index] != "Joins")
            {
                var dataSections = data[index].Split(Consts.Semi);
                var stateData = Utils.ConvertStringArrayToDoubles(dataSections[1].Split(Consts.Colon));
                Piece WIP = new Piece(dataSections[0])
                {
                    State = new State(stateData[0], stateData[1], stateData[2], stateData[3], stateData[4], stateData[5])
                };
                PiecesList.Add(WIP);

                // Check if Base Piece
                if (dataSections.Length == 3 && dataSections[2] == "base")
                {
                    BasePiece = WIP;
                }
            }

            // Joins
            for (int i = index++; i < data.Count; i++)
            {
                var dataSections = data[i].Split(Consts.Semi);
                var pieceA = PiecesList[int.Parse(dataSections[0])];
                var pieceB = PiecesList[int.Parse(dataSections[1])];
                var coordsA = Utils.ConvertStringArrayToDoubles(dataSections[2].Split(Consts.Colon));
                var coordsB = Utils.ConvertStringArrayToDoubles(dataSections[3].Split(Consts.Colon));

                Join WIP = new Join(pieceA, pieceB, this,
                    coordsA[0], coordsA[1], coordsA[2], coordsA[3], coordsB[0], coordsB[1], coordsB[2], coordsB[3], 
                    int.Parse(dataSections[4]), int.Parse(dataSections[5]));

                // Add To Dictionaries
                JoinsIndex.Add(pieceA, WIP);
                AddToJoinedPieces(pieceA, pieceB);
            }
        }

        /// <summary>
        /// Set constructor for creating a new set.
        /// </summary>
        public Set()
        {
            Name = "";
            Version = Consts.Version;
            State = new State();
        }



        // ----- FUNCTIONS -----

        /// <summary>
        /// Gets set's current details in a string format.
        /// </summary>
        public override List<string> GetData()
        {
            // Type and Version
            var newData = new List<string>
            {
                Consts.Set + Consts.Semi + Consts.Version
            };

            // Reset Set to Save
            BasePiece.State = new State();
            PiecesList = SortOrder();

            // Save Each Piece
            for (int index = 0; index < PiecesList.Count; index++)
            {
                Piece piece = PiecesList[index];
                string pieceDetails = piece.Name + Consts.SemiS + piece.State.GetData();

                // Base Piece
                if (piece == BasePiece)
                {
                    pieceDetails += Consts.SemiS + "base";
                }
                newData.Add(pieceDetails);
            }

            // Save Each Join
            newData.Add("Joins");
            foreach (Join join in JoinsIndex.Values)
            {
                newData.Add(PiecesList.IndexOf(join.A) + Consts.SemiS + PiecesList.IndexOf(join.B) + Consts.SemiS + join.ToString());
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
        /// Draws the set to the provided graphics.
        /// </summary>
        /// <param name="g">Supplied graphics</param>
        /// <param name="state">Sets position</param>
        /// <param name="colours">Sets colours</param>
        public override void Draw(Graphics g, State state = null, ColourState colours = null)
        {
            state = state ?? State;
            List<Piece> orderedPieces = SortOrder();
            foreach (Piece piece in orderedPieces)
            {
                piece.Draw(g, state, colours);
            }
            // TODO: Incorporate join changes to state
            // TODO: Calculate angles etc. from base outwards
        }

        /// <summary>
        /// Finds the correct order to draw pieces so they are layered correctly.
        /// </summary>
        /// <returns>Ordered list of pieces</returns>
        private List<Piece> SortOrder()
        {
            return SortOrderFromBasePiece(BasePiece);
        }

        /// <summary>
        /// Recursive function to find order of attached pieces to a base.
        /// </summary>
        /// <param name="baseIndex">Index of the piece being tested as a base</param>
        /// <returns>List of pieces surrounding the base in order</returns>
        private List<Piece> SortOrderFromBasePiece(Piece baseIndex)
        {
            var setSection = new List<Piece> { baseIndex };

            // Check if current piece is a base
            if (JoinedPieces.ContainsKey(baseIndex))
            {
                var attachedPieces = JoinedPieces[baseIndex];
                foreach(var attachedPiece in attachedPieces)
                {
                    var attachedJoin = JoinsIndex[attachedPiece];
                    var tempPieceList = SortOrderFromBasePiece(attachedPiece);

                    // Determine if attachment should be added to the front or back of base
                    if (attachedJoin.AttachedInFront())
                    {
                        setSection.AddRange(tempPieceList);
                    }
                    else
                    {
                        tempPieceList.AddRange(setSection);
                        setSection = tempPieceList;
                    }
                }
            }
            return setSection;
        }

        /// <summary>
        /// Adds an item to the JoinedPieces dictionary
        /// based on whether it is a key already.
        /// </summary>
        /// <param name="a">Attaching piece</param>
        /// <param name="b">Base piece</param>
        public void AddToJoinedPieces(Piece a, Piece b)
        {
            if (JoinedPieces.ContainsKey(b))
            {
                JoinedPieces[b].Add(a);
            }
            else
            {
                JoinedPieces.Add(b, new List<Piece> { a });
            }
        }
    }
}
