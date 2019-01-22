using System.Collections.Generic;
using System.Drawing;

namespace Animator
{
    /// <summary>
    /// A class to encapsulate individual pieces and their grouped form, sets.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public abstract class Part
    {
        public abstract string Name { get; set; }
        public abstract List<string> Data { get; set; }


        /// <summary>
        /// Converts the Part into a readable format.
        /// </summary>
        /// <returns>The part's name</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Converts a part to a piece.
        /// For pieces, it returns itself.
        /// For sets, it returns the base piece.
        /// </summary>
        /// <returns>A piece representation of the part</returns>
        public abstract Piece ToPiece();

        /// <summary>
        /// Draws the part to the supplied graphics.
        /// </summary>
        /// <param name="g">Supplied graphics</param>
        public abstract void Draw(Graphics g);
    }
}
