using System.Drawing;
using static Optimator.Consts;

namespace Optimator
{
    /// <summary>
    /// A class to hold information about an
    /// individual coordinate.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class ConnectorDet
    {
        #region Line Variables
        public float[] Width { get; set; } = new float[] { defaultOutlineWidth };
        public Color[] Colour { get; set; } = new Color[] { defaultOutline };
        public bool Visible { get; set; } = true;
        #endregion


        /// <summary>
        /// Empty Constructor for a Line.
        /// </summary>
        public ConnectorDet()
        {

        }

        /// <summary>
        /// Constructor from save file.
        /// </summary>
        /// <param name="data"></param>
        public ConnectorDet(string data)
        {
            var arrays = data.Split(Colon);
            Width = Utils.ConvertStringArrayToFloats(arrays[0].Split(Comma));
            var outlineColours = arrays[1].Split(Comma);
            Visible = bool.Parse(arrays[2]);
            Colour = new Color[outlineColours.Length];
            for (int index = 0; index < outlineColours.Length; index++)
            {
                Colour[index] = Utils.ColourFromString(outlineColours[index]);
            }
        }



        // ----- GENERAL FUNCTIONS -----

        /// <summary>
        /// Returns the save data of the line.
        /// </summary>
        /// <returns>Spot data</returns>
        public override string ToString()
        {
            var dataString = "";
            for (int index = 0; index < Width.Length; index++)
            {
                dataString += Width[index];
                dataString += index == Width.Length - 1 ? ColonS : CommaS;
            }
            for (int index = 0; index < Colour.Length; index++)
            {
                dataString += Utils.ColorToString(Colour[index]);
                dataString += index == Colour.Length - 1 ? ColonS : CommaS;
            }
            return dataString + Visible.ToString();
        }

        /// <summary>
        /// Determines if the line should be drawn.
        /// </summary>
        /// <returns>True if visible</returns>
        public bool IsVisible()
        {
            if (!Visible)
            {
                return false;
            }
            foreach (var width in Width)
            {
                if (width > 0)
                {
                    foreach (var colour in Colour)
                    {
                        if (colour.A > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
