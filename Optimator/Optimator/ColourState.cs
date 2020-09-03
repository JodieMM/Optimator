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
        public FillOption Type { get; set; }                     // Solid/Gradient colour and direction
        public Color[] Fill { get; set; }                    // Multiple colours for gradients
        public Color Outline { get; set; }


        /// <summary>
        /// Constructor for a new colour state with default colours.
        /// </summary>
        public ColourState()
        {
            Type = FillOption.Fill;
            Fill = new Color[] { defaultFill };
            Outline = defaultOutline;
        }

        /// <summary>
        /// Constructor for a new state with known values.
        /// </summary>
        /// <param name="CT">Colour Type string</param>
        /// <param name="FC">Fill Colour array</param>
        /// <param name="OC">Outline Colour</param>
        public ColourState(FillOption CT, Color[] FC, Color OC)
        {
            Type = CT;
            Fill = FC;
            Outline = OC;
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
            Outline = OC;
            Fill = FC ?? basis.Fill;
            Type = FC == null ? basis.Type : FillOption.Fill; 
            // GRADIENT: Need to modify colour type to match fill colour amount
        }



        // ----- GET FUNCTIONS -----

        /// <summary>
        /// Convert the colour state into a saveable string.
        /// </summary>
        /// <returns>ColourState data</returns>
        public string GetData()
        {
            var data = Type.ToString("d") + SemiS + Utils.ColorToString(Outline) + SemiS;
            for (int index = 0; index < Fill.Length - 1; index++)
            {
                data += Utils.ColorToString(Fill[index]) + ColonS;
            }
            return data + Utils.ColorToString(Fill[Fill.Length - 1]);
        }



        // ----- GENERAL FUNCTIONS -----

        /// <summary>
        /// Checks if the shape is visible and should be drawn.
        /// </summary>
        /// <returns>True if visible</returns>
        public bool IsVisible()
        {
            if (Type == FillOption.None)
            {
                return false;
            }
            else
            {
                foreach (var col in Fill)
                {
                    if (col.A != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
