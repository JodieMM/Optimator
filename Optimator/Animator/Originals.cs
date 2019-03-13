using System.Drawing;

namespace Animator
{
    /// <summary>
    /// Maintains a copy of the original values of a piece.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class Originals
    {
        #region Originals Variables
        public double X { get; set; }
        public double Y { get; set; }
        public double R { get; set; }
        public double T { get; set; }
        public double S { get; set; }
        public double SM { get; set; }
        public Color OC { get; set; }
        public Color[] FC { get; set; }
        public string CT { get; set; }
        #endregion


        /// <summary>
        /// Originals constructor. Keeps a copy of the 
        /// current (original) state of the provided piece.
        /// </summary>
        /// <param name="piece">Piece to keep original copy of</param>
        public Originals(Piece piece)
        {
            X = piece.X;
            Y = piece.Y;
            R = piece.R;
            T = piece.T;
            S = piece.S;
            SM = piece.SM;
            OC = piece.OutlineColour;
            FC = piece.FillColour;
            CT = piece.ColourType;
        }



        // ----- GENERAL FUNCTIONS -----

        /// <summary>
        /// Returns the piece attributes seperated by colons.
        /// </summary>
        /// <returns>Semicolon-seperated attribute string</returns>
        public string GetSaveData()
        {
            return X + ";" + Y + ";" + R + ";" + T + ";" + S + ";" + SM;
        }
    }
}
