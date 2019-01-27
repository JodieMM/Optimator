using System;
using System.Collections.Generic;

namespace Animator
{
    /// <summary>
    /// Keeps a record of the spots within an angle range.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class DataRow
    {
        #region DataRow Variables
        public double RotFrom { get; set; }
        public double RotTo { get; set; }
        public double TurnFrom { get; set; }
        public double TurnTo { get; set; }
        public List<Spot> Spots { get; set; } = new List<Spot>();
        #endregion

        /// <summary>
        /// DataRow constructor for a new DataRow/ new Piece.
        /// </summary>
        /// <param name="rf">Starting rotation</param>
        /// <param name="rt">Ending rotation</param>
        /// <param name="tf">Starting turn</param>
        /// <param name="tt">Ending turn</param>
        public DataRow(double rf, double rt, double tf, double tt)
        {
            RotFrom = rf;
            RotTo = rt;
            TurnFrom = tf;
            TurnTo = tt;
        }

        /// <summary>
        /// DataRow constructor for an existing piece, reading from a file.
        /// Includes loading a join.
        /// </summary>
        /// <param name="Data">DataRow information in string form</param>
        public DataRow(string Data)
        {
            // Split string into sections
            string[] dataLine = Data.Split(Constants.Semi);
            string[] angles = dataLine[0].Split(Constants.Colon);
            string[] coords = dataLine[1].Split(Constants.Colon);

            // Set Angles
            RotFrom = Convert.ToDouble(angles[0]);
            RotTo = Convert.ToDouble(angles[1]);
            TurnFrom = Convert.ToDouble(angles[2]);
            TurnTo = Convert.ToDouble(angles[3]);

            if (dataLine.Length > 1)
            {
                string[] joins = dataLine[2].Split(Constants.Colon);
                string[] solids = dataLine[3].Split(Constants.Colon);
                string[] drawns = dataLine[4].Split(Constants.Colon);

                // Create Spots
                for (int index = 0; index < coords.Length; index++)
                {
                    string[] individualCoords = coords[index].Split(Constants.Comma);
                    Spots.Add(new Spot(Convert.ToDouble(individualCoords[0]), Convert.ToDouble(individualCoords[1]),
                        Convert.ToDouble(individualCoords[2]), Convert.ToDouble(individualCoords[3]), joins[index],
                        solids[index], int.Parse(drawns[index])));
                }
            }
            else
            {
                // Create Join
                string[] individualCoords = coords[0].Split(Constants.Comma);
                Spots.Add(new Spot(Convert.ToDouble(individualCoords[0]), Convert.ToDouble(individualCoords[1]),
                    Convert.ToDouble(individualCoords[2]), Convert.ToDouble(individualCoords[3])));
            }
        }



        // ----- FUNCTIONS -----

        /// <summary>
        /// Converts the DataRow into a saveable string format.
        /// </summary>
        /// <returns>String version of data row</returns>
        public override string ToString()
        {
            // Angles
            string WIPstring = RotFrom.ToString() + Constants.ColonS + RotTo.ToString() + Constants.ColonS +
                TurnFrom.ToString() + Constants.ColonS + TurnTo.ToString() + Constants.SemiS;

            // Coords
            for (int index = 0; index < Spots.Count; index++)
            {
                Spot spot = Spots[index];
                WIPstring += spot.X + Constants.CommaS + spot.XRight + Constants.CommaS + spot.Y + Constants.CommaS + spot.YDown;
                WIPstring += (index == Spots.Count - 1) ? "" : Constants.ColonS;
            }

            // Don't include if join
            if (Spots[0].Connector != null)
            {
                WIPstring += Constants.SemiS;


                // Connectors
                for (int index = 0; index < Spots.Count; index++)
                {
                    WIPstring += Spots[index].Connector;
                    WIPstring += (index == Spots.Count - 1) ? ";" : ":";
                }

                // Details
                for (int index = 0; index < Spots.Count; index++)
                {
                    WIPstring += Spots[index].Solid;
                    WIPstring += (index == Spots.Count - 1) ? ";" : ":";
                }

                // Drawns
                for (int index = 0; index < Spots.Count; index++)
                {
                    WIPstring += Spots[index].DrawnLevel;
                    WIPstring += (index == Spots.Count - 1) ? "" : ":";
                }
            }

            return WIPstring;
        }

        /// <summary>
        /// Converts the current data row into a non-refined version.
        /// </summary>
        /// <returns>A non-refined DataRow</returns>
        public DataRow ToSimple()
        {
            DataRow newRow = new DataRow(RotFrom, RotTo, TurnFrom, TurnTo);
            foreach (Spot spot in Spots)
            {
                if (spot.DrawnLevel == 0)
                {
                    newRow.Spots.Add(spot);
                }
            }
            return newRow;
        }

        /// <summary>
        /// Checks if the data row is displayed at the given rotation and turn.
        /// </summary>
        /// <param name="rotation">Piece's rotation value</param>
        /// <param name="turn">Piece's turn value</param>
        /// <returns>True if data row is relevant to piece's current angles</returns>
        public bool IsWithin(double rotation, double turn)
        {
            return (rotation >= RotFrom && rotation < RotTo &&
                turn >= TurnFrom && turn < TurnTo);
        }

        /// <summary>
        /// Creates a de-referenced copy of the DataRow's spots.
        /// </summary>
        /// <returns>DataRow's current spots</returns>
        public List<Spot> CopySpots()
        {
            List<Spot> newSpots = new List<Spot>();
            foreach (Spot spot in Spots)
            {
                newSpots.Add(new Spot(spot.X, spot.XRight, spot.Y, spot.YDown, spot.Connector, spot.Solid, spot.DrawnLevel));
            }

            // Set MatchX and MatchY of new spots based on index to de-reference matches
            for (int index = 0; index < Spots.Count; index++)
            {
                if (Spots[index].MatchX != null)
                {
                    int matchIndex = Spots.IndexOf(Spots[index].MatchX);
                    newSpots[index].MatchX = newSpots[matchIndex];
                }
                if (Spots[index].MatchY != null)
                {
                    int matchIndex = Spots.IndexOf(Spots[index].MatchY);
                    newSpots[index].MatchY = newSpots[matchIndex];
                }
            }
            return newSpots;
        }

        /// <summary>
        /// Converts the spot list to a double[] list for use
        /// in drawing the piece.
        /// </summary>
        /// <param name="angle">Original [0] rotated [1] turned[2]</param>
        /// <returns>A list of coords for the given angle</returns>
        public List<double[]> ConvertToDoubles(int angle)
        {
            List<double[]> returnList = new List<double[]>();
            foreach(Spot spot in Spots)
            {
                switch (angle)
                {
                    case 1:
                        returnList.Add(new double[] { spot.XRight, spot.Y });
                        break;
                    case 2:
                        returnList.Add(new double[] { spot.X, spot.YDown });
                        break;
                    default:
                        returnList.Add(new double[] { spot.X, spot.Y });
                        break;
                }
            }
            return returnList;
        }
    }
}
