using System.Collections.Generic;
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
        public List<FillOption> Layers { get; set; } = new List<FillOption>();
        public List<string> Details { get; set; } = new List<string>();

                     
        /// <summary>
        /// Constructor for a new colour state with default colours.
        /// </summary>
        public ColourState()
        {
            Layers.Add(FillOption.Fill);
            Details.Add(Utils.ColorToString(defaultFill));
        }

        /// <summary>
        /// Constructor for a new state with known values.
        /// </summary>
        /// <param name="data">String of layer data</param>
        public ColourState(string data)
        {
            var layers = data.Split(Semi);
            foreach (var layer in layers)
            {
                var layerData = layer.Split(Colon);
                Layers.Add((FillOption)int.Parse(layerData[0]));
                Details.Add(layerData[1]);
            }
        }



        // ----- GENERAL FUNCTIONS -----

        /// <summary>
        /// Convert the colour state into a saveable string.
        /// </summary>
        /// <returns>ColourState data</returns>
        public override string ToString()
        {
            var data = "";
            for (int index = 0; index < Layers.Count; index++)
            {
                data += Layers[index].ToString("d") + ColonS + Details[index] + SemiS;
            }
            return data.Remove(data.Length - 1);
        }

        /// <summary>
        /// Converts the colour state into brushes for drawing.
        /// </summary>
        /// <returns></returns>
        public Brush[] DrawingTools()
        {
            var brushes = new Brush[Layers.Count];
            for (int index = 0; index < Layers.Count; index++)
            {
                switch (Layers[index])
                {
                    case FillOption.None:
                        brushes[index] = null;
                        break;
                    case FillOption.Fill:
                        brushes[index] = new SolidBrush(Utils.ColourFromString(Details[index]));
                        break;
                    case FillOption.Gradient:
                        //https://docs.microsoft.com/en-us/dotnet/api/system.drawing.brush?view=dotnet-plat-ext-3.1
                        // PathGradientBrush, LinearGradientBrush
                        break;
                    case FillOption.LayeredGradient:
                        break;
                    case FillOption.Image:
                        // Opacity too
                        // TextureBrush
                        break;
                    // HatchBrush also? 
                    // GRADIENT
                }
            }
            return brushes;
        }

        /// <summary>
        /// Checks if the shape is visible and should be drawn.
        /// </summary>
        /// <returns>True if visible</returns>
        public bool IsVisible()
        {
            foreach (var type in Layers)
            {
                if (type != FillOption.None)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
