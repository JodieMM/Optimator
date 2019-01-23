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
        public double RotationFrom { get; set; }
        public double RotationTo { get; set; }
        public double TurnFrom { get; set; }
        public double TurnTo { get; set; }
        public List<Spot> Spots { get; private set; } = new List<Spot>();
        public int NumSpots { get; private set; }
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
            RotationFrom = rf;
            RotationTo = rt;
            TurnFrom = tf;
            TurnTo = tt;
        }

        /// <summary>
        /// DataRow constructor for an existing piece, reading from a file.
        /// </summary>
        /// <param name="Data">DataRow information in string form</param>
        public DataRow(string Data)
        {
            // Split string into sections
            string[] dataLine = Data.Split(Constants.Semi);
            string[] rotations = dataLine[0].Split(Constants.Comma);
            string[] turns = dataLine[1].Split(Constants.Comma);
            string[] coords = dataLine[2].Split(Constants.Colon);
            string[] joins = dataLine[3].Split(Constants.Comma);
            string[] solids = dataLine[4].Split(Constants.Comma);
            string[] drawns = dataLine[5].Split(Constants.Comma);

            // Set Angles
            RotationFrom = Convert.ToDouble(rotations[0]);
            RotationTo = Convert.ToDouble(rotations[1]);
            TurnFrom = Convert.ToDouble(turns[0]);
            TurnTo = Convert.ToDouble(turns[1]);
            NumSpots = coords.Length;

            // Create Spots
            for (int index = 0; index < coords.Length; index++)
            {
                string[] individualCoords = coords[index].Split(Constants.Comma);
                Spots.Add(new Spot(Convert.ToDouble(individualCoords[0]), Convert.ToDouble(individualCoords[1]),
                    Convert.ToDouble(individualCoords[2]), Convert.ToDouble(individualCoords[3]), joins[index],
                    solids[index], Convert.ToInt32(drawns[index])));
                
            }
        }



        // ----- FUNCTIONS -----

        /// <summary>
        /// Checks if the data row is displayed at the given rotation and turn.
        /// </summary>
        /// <param name="rotation">Piece's rotation value</param>
        /// <param name="turn">Piece's turn value</param>
        /// <returns>True if data row is relevant to piece's current angles</returns>
        public bool IsWithin(double rotation, double turn)
        {
            return (rotation >= RotationFrom && rotation < RotationTo &&
                turn >= TurnFrom && turn < TurnTo);
        }

        /// <summary>
        /// Used when creating a piece to adjust its spots.
        /// </summary>
        /// <param name="spots">Updated list of spots</param>
        public void UpdateSpots(List<Spot> spots)
        {
            Spots = spots;
            NumSpots = Spots.Count;
        }
    }
}
