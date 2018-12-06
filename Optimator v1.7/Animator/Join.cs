using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Animator
{
    /// <summary>
    /// A point used for indicating the position
    /// pieces connect in a set.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class Join
    {
        #region Point Variables
        public string Name { get; set; }
        public List<string> Data { get; set; }
        private readonly Piece host;

        // Attributes
        public double X { get; set; }
        public double Y { get; set; }
        public double XRight { get; set; }
        public double YDown { get; set; }
        public Color FillColour { get; set; } = Color.Black;
        #endregion


        /// <summary>
        /// Join constructor for loading an existing join.
        /// </summary>
        /// <param name="inName">Join to load</param>
        /// <param name="owner">Piece join is in reference to</param>
        public Join(string inName, Piece owner)
        {
            Name = inName;
            host = owner;
            Data = Utilities.ReadFile(GetFileDirectory());
        }

        /// <summary>
        /// Join constructor for creating a new join.
        /// </summary>
        public Join(Piece owner)
        {
            host = owner;
            Data = new List<string>();
            X = 150; Y = 150; XRight = 150; YDown = 150;
            Random rnd = new Random();
            FillColour = Constants.randomColours[rnd.Next(0, Constants.randomColours.Count())];
        }



        // ----- GET FUNCTIONS -----

        /// <summary>
        /// Returns the directory for the current join.
        /// </summary>
        /// <returns>String file path</returns>
        private string GetFileDirectory()
        {
            return Environment.CurrentDirectory + Constants.JoinsFolder
                + host.Name + "//" + Name + Constants.Txt;
        }



        // ----- SAVE FUNCTIONS -----

        /// <summary>
        /// Saves the current join to a file.
        /// Used when creating the join for the first time.
        /// </summary>
        public void SaveJoin(double[] middle)
        {
            X -= middle[0];
            Y -= middle[1];
            XRight -= middle[0];
            YDown -= middle[1];
            Data = new List<string>
            {
                MakeDataLine(0, 90, 0, 90, new double[] { X, Y }, new double[] { XRight, Y }, new double[] { X, YDown }),
                MakeDataLine(90, 180, 0, 90, new double[] { XRight, Y }, new double[] { -X, Y }, new double[] { XRight, YDown }),
                MakeDataLine(180, 270, 0, 90, new double[] { -X, Y }, new double[] { -XRight, Y }, new double[] { -X, YDown }),
                MakeDataLine(270, 360, 0, 90, new double[] { -XRight, Y }, new double[] { X, Y }, new double[] { -XRight, YDown }),

                MakeDataLine(0, 90, 90, 180, new double[] { X, YDown }, new double[] { XRight, YDown }, new double[] { X, -Y }),
                MakeDataLine(90, 180, 90, 180, new double[] { XRight, YDown }, new double[] { -X, YDown }, new double[] { XRight, -Y }),
                MakeDataLine(180, 270, 90, 180, new double[] { -X, YDown }, new double[] { -XRight, YDown }, new double[] { -X, -Y }),
                MakeDataLine(270, 360, 90, 180, new double[] { -XRight, YDown }, new double[] { X, YDown }, new double[] { -XRight, -Y }),

                MakeDataLine(0, 90, 180, 270, new double[] { X, -Y }, new double[] { XRight, -Y }, new double[] { X, -YDown }),
                MakeDataLine(90, 180, 180, 270, new double[] { XRight, -Y }, new double[] { -X, -Y }, new double[] { XRight, -YDown }),
                MakeDataLine(180, 270, 180, 270, new double[] { -X, -Y }, new double[] { -XRight, -Y }, new double[] { -X, -YDown }),
                MakeDataLine(270, 360, 180, 270, new double[] { -XRight, -Y }, new double[] { X, -Y }, new double[] { -XRight, -YDown }),

                MakeDataLine(0, 90, 270, 360, new double[] { X, -YDown }, new double[] { XRight, -YDown }, new double[] { X, Y }),
                MakeDataLine(90, 180, 270, 360, new double[] { XRight, -YDown }, new double[] { -X, -YDown }, new double[] { XRight, Y }),
                MakeDataLine(180, 270, 270, 360, new double[] { -X, -YDown }, new double[] { -XRight, -YDown }, new double[] { -X, Y }),
                MakeDataLine(270, 360, 270, 360, new double[] { -XRight, -YDown }, new double[] { X, -YDown }, new double[] { -XRight, Y })
            };

            Utilities.SaveData(GetFileDirectory(), Data);
        }

        /// <summary>
        /// Converts the join data into the join file format.
        /// </summary>
        /// <param name="rFrom">Starting rotation</param>
        /// <param name="rTo">Ending rotation</param>
        /// <param name="tFrom">Starting turn</param>
        /// <param name="tTo">Ending turn</param>
        /// <param name="original">Base coordinate</param>
        /// <param name="rotated">Rotated coordinate</param>
        /// <param name="turned">Turned coordinate</param>
        /// <returns></returns>
        private string MakeDataLine(double rFrom, double rTo, double tFrom, double tTo, double[] original, double[] rotated, double[] turned)
        {
            // Angles
            string WIPstring = rFrom.ToString().PadLeft(3, '0') + ":" + rTo.ToString().PadLeft(3, '0') + ";" +
                tFrom.ToString().PadLeft(3, '0') + ":" + tTo.ToString().PadLeft(3, '0') + ";";

            // Coordinates
            WIPstring += original[0] + "," + original[1] + ";";
            WIPstring += rotated[0] + "," + rotated[1] + ";";
            WIPstring += turned[0] + "," + turned[1];
            return WIPstring;
        }



        // ----- FUNCTIONS -----

        /// <summary>
        /// Gets the coordinates of the join based 
        /// on the host Piece's angles.
        /// </summary>
        /// <returns></returns>
        public double[] GetCurrentPoints(double hostX, double hostY)
        {
            // Host Variables
            double[] hostAngles = host.GetAngles();

            // Point Variables
            string[] dataValues = Data[Utilities.FindRow(hostAngles[0], hostAngles[1], Data, 0)].Split(Constants.Semi);
            double[] originals = new double[] { Convert.ToDouble(dataValues[2].Split(Constants.Comma)[0]),
                Convert.ToDouble(dataValues[2].Split(Constants.Comma)[1]) };
            double rotated = Convert.ToDouble(dataValues[3].Split(Constants.Comma)[0]);
            double turned = Convert.ToDouble(dataValues[4].Split(Constants.Comma)[1]);
            double[] angles = new double[] { Convert.ToDouble(dataValues[0].Split(Constants.Colon)[0]),
                Convert.ToDouble(dataValues[0].Split(Constants.Colon)[1]),
                Convert.ToDouble(dataValues[1].Split(Constants.Colon)[0]),
                Convert.ToDouble(dataValues[1].Split(Constants.Colon)[1]) };

            // Check if at start cutoff of angle
            if (angles[0] == hostAngles[0] && angles[2] == hostAngles[1])
            {
                return new double[] { hostX + originals[0], hostY + originals[1] };
            }

            // Calculate rotated/turned point
            double rMod = (hostAngles[0] - angles[0]) / (angles[1] - angles[0]);
            double tMod = (hostAngles[1] - angles[2]) / (angles[3] - angles[2]);
            return new double[] { hostX + (originals[0] + (rotated - originals[0]) * rMod),
                hostY + (originals[1] + (turned - originals[1]) * tMod) };
        }
    }
}
