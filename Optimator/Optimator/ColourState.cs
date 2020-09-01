using System.Drawing;
using static Optimator.Consts;

namespace Optimator
{
    /// <summary>
    /// Holds the state of the fill and outline colours.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class ColourState
    {
        public FillOption ColourType { get; set; }                     // Solid/Gradient colour and direction
        public Color[] FillColour { get; set; }                    // Multiple colours for gradients
        public Color OutlineColour { get; set; }


        /// <summary>
        /// Constructor for a new colour state with default colours.
        /// </summary>
        public ColourState()
        {
            ColourType = FillOption.Fill;
            FillColour = new Color[] { defaultFill };
            OutlineColour = defaultOutline;
        }

        /// <summary>
        /// Constructor for a new state with known values.
        /// </summary>
        /// <param name="CT">Colour Type string</param>
        /// <param name="FC">Fill Colour array</param>
        /// <param name="OC">Outline Colour</param>
        public ColourState(FillOption CT, Color[] FC, Color OC)
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
            ColourType = FC == null ? basis.ColourType : FillOption.Fill; 
            // GRADIENT: Need to modify colour type to match fill colour amount
        }



        // ----- GET FUNCTIONS -----

        /// <summary>
        /// Convert the colour state into a saveable string.
        /// </summary>
        /// <returns>ColourState data</returns>
        public string GetData()
        {
            var data = ColourType.ToString("d") + SemiS + Utils.ColorToString(OutlineColour) + SemiS;
            for (int index = 0; index < FillColour.Length - 1; index++)
            {
                data += Utils.ColorToString(FillColour[index]) + ColonS;
            }
            return data + Utils.ColorToString(FillColour[FillColour.Length - 1]);
        }
    }
}
