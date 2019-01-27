using System;
using System.Collections.Generic;

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
        public Piece Host { get; }
        public List<DataRow> Coords { get; set; } = new List<DataRow>();
        #endregion


        /// <summary>
        /// Join constructor for loading an existing join.
        /// </summary>
        /// <param name="inName">Join to load</param>
        /// <param name="owner">Piece join is in reference to</param>
        public Join(string inName, Piece owner)
        {
            Name = inName;
            Host = owner;
            List<string> data = Utilities.ReadFile(Utilities.GetDirectory(Constants.JoinsFolder, Host.Name, Name, Constants.Txt));
            foreach (string line in data)
            {
                Coords.Add(new DataRow(line));
            }
        }

        /// <summary>
        /// Join constructor for creating a new join.
        /// </summary>
        public Join(Piece owner, double X, double XR, double Y, double YD)
        {
            Host = owner;
            Coords.Add(new DataRow(0, 90, 0, 90));
            Coords[0].Spots.Add(new Spot(X, XR, Y, YD));
        }



        // ----- SAVE FUNCTIONS -----

        /// <summary>
        /// Saves the current join to a file.
        /// Used when creating the join for the first time.
        /// </summary>
        public void SaveJoin(double[] middle)
        {
            double X = Coords[0].Spots[0].X - middle[0];
            double Y = Coords[0].Spots[0].Y - middle[1];
            double XR = Coords[0].Spots[0].XRight - middle[0];
            double YD = Coords[0].Spots[0].YDown - middle[1];

            List<string> data = new List<string>
            {
                MakeDataLine(0, 90, 0, 90, new double[] { X, Y, XR, YD }),
                MakeDataLine(90, 180, 0, 90, new double[] { XR, Y, -X, YD }),
                MakeDataLine(180, 270, 0, 90, new double[] { -X, Y, -XR, YD }),
                MakeDataLine(270, 360, 0, 90, new double[] { -XR, Y, X, YD }),

                MakeDataLine(0, 90, 90, 180, new double[] { X, YD, XR, -Y }),
                MakeDataLine(90, 180, 90, 180, new double[] { XR, YD, -X, -Y }),
                MakeDataLine(180, 270, 90, 180, new double[] { -X, YD, -XR, -Y }),
                MakeDataLine(270, 360, 90, 180, new double[] { -XR, YD, X, -Y }),

                MakeDataLine(0, 90, 180, 270, new double[] { X, -Y, XR, -YD }),
                MakeDataLine(90, 180, 180, 270, new double[] { XR, -Y, -X, -YD }),
                MakeDataLine(180, 270, 180, 270, new double[] { -X, -Y, -XR, -YD }),
                MakeDataLine(270, 360, 180, 270, new double[] { -XR, -Y, X, -YD }),

                MakeDataLine(0, 90, 270, 360, new double[] { X, -YD, XR, Y }),
                MakeDataLine(90, 180, 270, 360, new double[] { XR, -YD, -X, Y }),
                MakeDataLine(180, 270, 270, 360, new double[] { -X, -YD, -XR, Y }),
                MakeDataLine(270, 360, 270, 360, new double[] { -XR, -YD, X, Y })
            };

            Utilities.SaveData(Utilities.GetDirectory(Constants.JoinsFolder, Host.Name, Name, Constants.Txt), data);
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
        private string MakeDataLine(double rFrom, double rTo, double tFrom, double tTo, double[] coords)
        {
            DataRow newRow = new DataRow(rFrom, rTo, tFrom, tTo);
            newRow.Spots.Add(new Spot(coords[0], coords[1], coords[2], coords[3]));
            return newRow.ToString();
        }



        // ----- FUNCTIONS -----

        /// <summary>
        /// Gets the coordinates of the join based 
        /// on the Host Piece's angles.
        /// </summary>
        /// <returns></returns>
        public double[] GetCurrentPoints(double HostX, double HostY)
        {
            double[] hostAng = Host.GetAngles();
            int row = Utilities.FindRow(hostAng[0], hostAng[1], Coords);
            DataRow dataRow = Coords[row];
            Spot line = dataRow.Spots[0];

            double[] returning;

            // Check if at start cutoff of angle
            if (dataRow.RotFrom == hostAng[0] && dataRow.TurnFrom == hostAng[1])
            {
                returning = new double[] { HostX + line.X, HostY + line.Y };
            }
            // Calculate rotated/turned point
            else
            {
                double rMod = (hostAng[0] - dataRow.RotFrom) / (dataRow.RotTo - dataRow.RotFrom);
                double tMod = (hostAng[1] - dataRow.TurnFrom) / (dataRow.TurnTo - dataRow.TurnFrom);
                returning = new double[] { HostX + (line.X + (line.XRight - line.X) * rMod),
                HostY + (line.Y + (line.YDown - line.Y) * tMod) };
            }

            // Calculate Spin
            return SpinMeRound(returning, Host.SM / 100.0, HostX, HostY);
        }

        /// <summary>
        /// Spins the coords provided and modifies their size
        /// </summary>
        /// <param name="point">The point to be spun</param>
        /// <param name="sizeModifier">The size modifier to be applied</param>
        /// <param name="HostX">Host's centre X position</param>
        /// <param name="HostY">Host's centre Y position</param>
        /// <returns></returns>
        public double[] SpinMeRound(double[] point, double sizeModifier, double HostX, double HostY)
        {
            // Spin Adjustment
                if (!(point[0] == HostX && point[1] == HostY))
                {
                    double hypotenuse = Math.Sqrt(Math.Pow(HostX - point[0], 2) + Math.Pow(HostY - point[1], 2)) * sizeModifier;
                    // Find Angle
                    double pointAngle;
                    if (point[0] == HostX && point[1] < HostY)
                    {
                        pointAngle = 0;
                    }
                    else if (point[0] == HostX && point[1] > HostY)
                    {
                        pointAngle = 180;
                    }
                    else if (point[0] > HostX && point[1] == HostY)
                    {
                        pointAngle = 90;
                    }
                    else if (point[0] < HostX && point[1] == HostY)
                    {
                        pointAngle = 270;
                    }
                    //  Second || First
                    //  Third  || Fourth
                    else if (point[0] > HostX && point[1] < HostY) // First Quadrant
                    {
                        pointAngle = (180 / Math.PI) * Math.Atan(Math.Abs((HostX - point[0]) / (HostY - point[1])));
                    }
                    else if (point[0] > HostX && point[1] > HostY) // Fourth Quadrant
                    {
                        pointAngle = 90 + (180 / Math.PI) * Math.Atan(Math.Abs((HostY - point[1]) / (HostX - point[0])));
                    }
                    else if (point[0] < HostX && point[1] < HostY) // Second Quadrant
                    {
                        pointAngle = 270 + (180 / Math.PI) * Math.Atan(Math.Abs((HostY - point[1]) / (HostX - point[0])));
                    }
                    else  // Third Quadrant
                    {
                        pointAngle = 180 + (180 / Math.PI) * Math.Atan(Math.Abs((HostX - point[0]) / (HostY - point[1])));
                    }
                    double findAngle = ((pointAngle + Host.GetAngles()[2]) % 360) * Math.PI / 180;

                    // Find Points
                    point[0] = Convert.ToInt32((HostX + hypotenuse * Math.Sin(findAngle)));
                    point[1] = Convert.ToInt32((HostY - hypotenuse * Math.Cos(findAngle)));
                }
            return point;
        }
    }
}
