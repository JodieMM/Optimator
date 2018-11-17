﻿namespace Animator
{
    /// <summary>
    /// Maintains a copy of the original values of a piece.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class Originals
    {
        #region Originals Variables
        public Piece Piece { get; }
        public double X { get; set; }
        public double Y { get; set; }
        public double R { get; set; }
        public double T { get; set; }
        public double S { get; set; }
        public double SM { get; set; }
        #endregion


        /// <summary>
        /// Originals constructor. Keeps a copy of the 
        /// current (original) state of the provided piece.
        /// </summary>
        /// <param name="piece">Piece to keep original copt of</param>
        public Originals(Piece piece)
        {
            Piece = piece;
            X = piece.X;
            Y = piece.Y;
            R = piece.R;
            T = piece.T;
            S = piece.S;
            SM = piece.SM;
            // Colours/Outlines?
            // Attached sets etc?
        }



        // ----- GENERAL FUNCTIONS -----

        /// <summary>
        /// Returns the piece attributes seperated by colons.
        /// </summary>
        /// <returns>Colon-seperated attribute string</returns>
        public string GetSaveData()
        {
            return X + ";" + Y + ";" + R + ";" + T + ";" + S + ";" + SM;
        }

        /// <summary>
        /// Compares whether the entered piece matches the
        /// piece whose data is saved.
        /// </summary>
        /// <param name="compare">Piece to check with</param>
        /// <returns>Whether the two are a match</returns>
        public bool IsMatch(Piece compare)
        {
            return (Piece == compare) ? true : false;
        }
    }
}
