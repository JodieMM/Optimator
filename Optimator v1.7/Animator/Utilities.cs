using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Animator
{
    /// <summary>
    /// Holds functions common to multiple classes and/or forms
    /// </summary>
  

    public class Utilities
    {
        // ----- FILE I/O -----

        /// <summary>
        /// Reads information from a text file and returns it
        /// </summary>
        /// <param name="directory">The file to read from</param>
        /// <returns>A list of strings containing the data</returns>
        public static List<string> ReadFile(string directory)
        {
            // Open File
            string filePath = directory;
            System.IO.StreamReader file = new System.IO.StreamReader(@filePath);

            // Read Data
            List<string> data = new List<string>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                data.Add(line);
            }
            file.Close();

            // Return String
            return data;
        }

        /// <summary>
        /// Saves data to a provided location
        /// </summary>
        /// <param name="directory">The file to save to</param>
        /// <param name="data">The data to save</param>
        public static void SaveData(string directory, List<string> data)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(@directory);

            for (int index = 0; index < data.Count; index++)
            {
                file.WriteLine(data[index]);
            }
            file.Close();
        }



        // ----- OTHER FUNCTIONS -----

        /// <summary>
        /// Finds the middle of a shape
        /// </summary>
        /// <param name="arrayIn">Shape points</param>
        /// <returns>The middle as [middle x, middle y]</returns>
        public static double[] FindMid(double[,] arrayIn)
        {
            double minX = 99999;
            double maxX = -99999;
            double minY = 99999;
            double maxY = -99999;

            for (int index = 0; index < arrayIn.Length / 2; index++)
            {
                if (arrayIn[index, 0] < minX)
                {
                    minX = arrayIn[index, 0];
                }
                if (arrayIn[index, 0] > maxX)
                {
                    maxX = arrayIn[index, 0];
                }
                if (arrayIn[index, 1] < minY)
                {
                    minY = arrayIn[index, 1];
                }
                if (arrayIn[index, 1] > maxY)
                {
                    maxY = arrayIn[index, 1];
                }
            }
            return new double[] { minX + (maxX - minX) / 2, minY + (maxY - minY) / 2 };
        }

        /// <summary>
        /// Finds the middle of a shape
        /// </summary>
        /// <param name="coords">Shape points</param>
        /// <returns>The middle as [middle x, middle y]</returns>
        public static double[] GetMidListCoords(List<double[]> coords)
        {
            double minX = 99999;
            double maxX = -99999;
            double minY = 99999;
            double maxY = -99999;

            foreach (double[] entry in coords)
            {
                minX = (entry[0] < minX) ? entry[0] : minX;
                maxX = (entry[0] > maxX) ? entry[0] : maxX;
                minY = (entry[0] < minY) ? entry[1] : minY;
                maxY = (entry[0] > maxY) ? entry[1] : maxY;
            }

            return new double[] { minX + (maxX - minX) / 2, minY + (maxY - minY) / 2 };
        }

        /// <summary>
        /// Flips a shape vertically and/or horizontally
        /// </summary>
        /// <param name="coords">Shape coordinates</param>
        /// <param name="right">Flip vertically</param>
        /// <param name="down">Flip horizontally</param>
        /// <returns></returns>
        public static List<double[]> FlipCoords(List<double[]> coords, bool right, bool down)
        {
            double[] middle = Utilities.GetMidListCoords(coords);

            // Flip Vertically (Right)
            if (right)
            {
                for (int index = 0; index < coords.Count; index++)
                {
                    coords[index][0] = 2 * middle[0] - coords[index][0];
                }
            }

            // Flip Horizontally (Down)
            if (down)
            {
                for (int index = 0; index < coords.Count; index++)
                {
                    coords[index][1] = 2 * middle[1] - coords[index][1];
                }
            }

            return coords;
        }

        /// <summary>
        /// Draws a piece with outline and fill
        /// </summary>
        /// <param name="piece">The piece to be drawn</param>
        /// <param name="g">The graphics to draw to</param>
        /// <param name="recentre">See GetCurrentPoints</param>
        public static void DrawPiece(Piece piece, Graphics g, bool recentre)
        {
            //Check piece defined at that point
            if (FindRow(piece.GetAngles()[0], piece.GetAngles()[1], piece.Data, 1) != -1)
            {

                // Prepare for drawing
                Pen pen = new Pen(piece.OutlineColour, piece.OutlineWidth);
                SolidBrush fill = new SolidBrush(piece.FillColour[0]);                          // ** NEEDS UPDATING WITH GRADIENTS
                double[,] sketchCoords = piece.GetCurrentPoints(recentre, true);
                string[] joiners = piece.GetLineArray(piece.GetAngles()[0], piece.GetAngles()[1]);
                int numCoords = sketchCoords.Length / 2;


                // Fill Shape
                GraphicsPath path = new GraphicsPath();
                for (int pointIndex = 0; pointIndex < numCoords && numCoords > 2; pointIndex++)
                {
                    // Draw Line Between Final Point and First Point
                    if (pointIndex == numCoords - 1)
                    {
                        path.AddLine(new Point(Convert.ToInt32(sketchCoords[numCoords - 1, 0]), Convert.ToInt32(sketchCoords[numCoords - 1, 1])),
                            new Point(Convert.ToInt32(sketchCoords[0, 0]), Convert.ToInt32(sketchCoords[0, 1])));
                    }

                    // Draw Remaining Lines
                    else
                    {
                       path.AddLine(new Point(Convert.ToInt32(sketchCoords[pointIndex, 0]), Convert.ToInt32(sketchCoords[pointIndex, 1])),
                            new Point(Convert.ToInt32(sketchCoords[pointIndex + 1, 0]), Convert.ToInt32(sketchCoords[pointIndex + 1, 1])));
                    }
                }
                g.FillPath(fill, path);


                // Draw Connecting Lines
                for (int pointIndex = 0; pointIndex < numCoords && numCoords > 1 && piece.OutlineWidth > 0; pointIndex++)
                {
                    // Draw Line Between Final Point and First Point
                    if (pointIndex == numCoords - 1)
                    {
                        // Connected by Line
                        if (joiners[numCoords - 1] == "line")
                        {
                            g.DrawLine(pen, new Point(Convert.ToInt32(sketchCoords[0, 0]), Convert.ToInt32(sketchCoords[0, 1])),
                                new Point(Convert.ToInt32(sketchCoords[numCoords - 1, 0]), Convert.ToInt32(sketchCoords[numCoords - 1, 1])));
                        }
                        // Connected by Curve
                        // TO DO **
                    }

                    // Draw Remaining Lines
                    else
                    {
                        // Connected by Line
                        if (joiners[pointIndex] == "line")
                        {
                            g.DrawLine(pen, new Point(Convert.ToInt32(sketchCoords[pointIndex, 0]), Convert.ToInt32(sketchCoords[pointIndex, 1])),
                                new Point(Convert.ToInt32(sketchCoords[pointIndex + 1, 0]), Convert.ToInt32(sketchCoords[pointIndex + 1, 1])));
                        }
                        // Connected by Curve
                        // TO DO **
                    }
                }
            }
        }

        /// <summary>
        /// Draws all pieces in a list
        /// </summary>
        /// <param name="piecesList">Pieces to be drawn</param>
        /// <param name="g">Board to draw to</param>
        public static void DrawPieces(List<Piece> piecesList, Graphics g)
        {
            // Draw Parts
            for (int index = 0; index < piecesList.Count; index++)
            {
                // ** FIND BEST ORDER TO DRAW IN TO DO
                DrawPiece(piecesList[index], g, true);
            }
        }


        public List<Piece> SortOrder(List<Piece> piecesList)
        {
            List<Piece> order = new List<Piece>();
            order.AddRange(piecesList);

            Boolean change = true;
            while (change)
            {
                change = false;

                // Go from the bottom (first) to the top
                for (int index = 0; index < piecesList.Count;)
                {
                    // If attached and has to change height at some stage
                    if (order[index].AttachedTo != null && order[index].AngleFlip != -1)
                    {
                        // Find if should be above or below attachedTo
                        if (order[index].GetAngles()[0] <= order[index].AngleFlip &&                   // One set to is the one is at "most" of the time (181 vs 179 degrees)
                            order[index].GetAngles()[0] >= order[index].AngleFlip + 180 % 360)
                        {
                            // In given position

                            // If should be in front, and not
                            if (order[index].InFront == true && index < order.IndexOf(order[index].AttachedTo))
                            {
                                order.Insert(order.IndexOf(order[index].AttachedTo), order[index]);
                                order.RemoveAt(index + 1);
                                change = true;
                            }
                            // If should be behind, and not
                            else if (order[index].InFront == false && index > order.IndexOf(order[index].AttachedTo))
                            {
                                order.Insert(order.IndexOf(order[index].AttachedTo) - 1, order[index]);        // ** Potential error here calling and changing
                                order.RemoveAt(index);
                                change = true;
                            }
                        }
                        else
                        {
                            // In taken position

                            // If should be in front normally and still is in opposite
                            if (order[index].InFront == true && index > order.IndexOf(order[index].AttachedTo))
                            {
                                order.Insert(order.IndexOf(order[index].AttachedTo) - 1, order[index]);
                                order.RemoveAt(index);
                                change = true;
                            }
                            // If should be behind normally and still is in opposite
                            else if (order[index].InFront == false && index < order.IndexOf(order[index].AttachedTo))
                            {
                                order.Insert(order.IndexOf(order[index].AttachedTo), order[index]);
                                order.RemoveAt(index + 1);
                                change = true;
                            }
                        }
                    }
                    // No action if lone piece or base
                }
            }
            return order;
        }


        public static int CheckClose(int coord, int[] aims, int range)
        {
            foreach (int aim in aims)
            {
                if (coord > aim - range && coord < aim + range)
                {
                    return aim;
                }
            }
            return coord;
        }


        /// <summary>
        /// Finds the correct row in the piece data for the given rotation and turn values
        /// RowNum is 1 for pieces, 0 for points
        /// </summary>
        /// <param name="r">Rotation</param>
        /// <param name="t">Turn</param>
        /// <returns>The data row holding the information for the given angles</returns>
        public static int FindRow(double r, double t, List<string> data, int rowNum)
        {
            int row = rowNum;
            bool found = false;
            while (!found)
            {
                if (row == data.Count)
                {
                    found = true;
                    row = -1;
                }
                else
                {
                    if (r >= int.Parse(data[row].Substring(0, 3)) && r < int.Parse(data[row].Substring(4, 3))
                        && t >= int.Parse(data[row].Substring(8, 3)) && t < int.Parse(data[row].Substring(12, 3)))
                    {
                        found = true;
                    }
                    else
                    {
                        row++;
                    }
                }
            }
            return row;
        }
    }
}
