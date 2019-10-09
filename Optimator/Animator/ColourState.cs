using System.Drawing;

namespace Animator
{
    /// <summary>
    /// Holds the state of the fill and outline colours.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class ColourState
    {
        public string ColourType { get; set; }                     // Solid/Gradient colour and direction
        public Color[] FillColour { get; set; }                    // Multiple colours for gradients
        public Color OutlineColour { get; set; }


        /// <summary>
        /// Constructor for a new colour state with default colours.
        /// </summary>
        public ColourState()
        {
            ColourType = Consts.fillOptions[0];
            FillColour = new Color[] { Consts.defaultFill };
            OutlineColour = Consts.defaultOutline;
        }

        /// <summary>
        /// Constructor for a new state with known values.
        /// </summary>
        /// <param name="CT">Colour Type string</param>
        /// <param name="FC">Fill Colour array</param>
        /// <param name="OC">Outline Colour</param>
        public ColourState(string CT, Color[] FC, Color OC)
        {
            ColourType = CT;
            FillColour = FC;
            OutlineColour = OC;
        }

        /// <summary>
        /// A constructor for building a similar
        /// colour state to one already existing.
        /// </summary>
        /// <param name="basis">The original colour state</param>
        /// <param name="OC">New outline colour</param>
        /// <param name="FC">New fill colour</param>
        public ColourState(ColourState basis, Color OC, Color[] FC = null)
        {
            OutlineColour = OC;
            FillColour = FC ?? basis.FillColour;
            ColourType = FC == null ? basis.ColourType : Consts.fillOptions[0]; 
            // GRADIENT: Need to modify colour type to match fill colour amount
        }



        // ----- GET FUNCTIONS -----

        /// <summary>
        /// Convert the colour state into a saveable string.
        /// </summary>
        /// <returns>ColourState data</returns>
        public string GetData()
        {
            string data = ColourType + Consts.SemiS + Utils.ColorToString(OutlineColour) + Consts.SemiS;
            for (int index = 0; index < FillColour.Length - 1; index++)
            {
                data += Utils.ColorToString(FillColour[index]) + Consts.ColonS;
            }
            return data + Utils.ColorToString(FillColour[FillColour.Length - 1]);
        }
    }
}
