using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Animator
{
    /// <summary>
    /// Holds functions common to multiple classes and/or forms.
    /// 
    /// Author Jodie Muller
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

        /// <summary>
        /// Takes a folder and item name and returns the directory name to reach that file
        /// </summary>
        /// <param name="folder">The folder the item is in</param>
        /// <param name="name">The item name</param>
        /// <returns></returns>
        public static string GetDirectory(string folder, string name)
        {
            return Environment.CurrentDirectory + folder + name + Constants.Txt;
        }



        // ----- DRAW & RELATED FUNCTIONS -----

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
                List<double[]> sketchCoords = piece.GetCurrentPoints(recentre);
                List<string> joiners = piece.GetLineArray(piece.GetAngles()[0], piece.GetAngles()[1]);
                int numCoords = sketchCoords.Count;

                // Fill Shape
                GraphicsPath path = new GraphicsPath();
                for (int pointIndex = 0; pointIndex < numCoords && numCoords > 2; pointIndex++)
                {
                    // Draw Line Between Final Point and First Point
                    if (pointIndex == numCoords - 1)
                    {
                        path.AddLine(new Point(Convert.ToInt32(sketchCoords[numCoords - 1][0]), Convert.ToInt32(sketchCoords[numCoords - 1][1])),
                            new Point(Convert.ToInt32(sketchCoords[0][0]), Convert.ToInt32(sketchCoords[0][1])));
                    }
                    // Draw Remaining Lines
                    else
                    {
                       path.AddLine(new Point(Convert.ToInt32(sketchCoords[pointIndex][0]), Convert.ToInt32(sketchCoords[pointIndex][1])),
                            new Point(Convert.ToInt32(sketchCoords[pointIndex + 1][0]), Convert.ToInt32(sketchCoords[pointIndex + 1][1])));
                    }
                }
                g.FillPath(fill, path);

                // Draw Connecting Lines
                for (int pointIndex = 0; pointIndex < numCoords && numCoords > 1 && piece.OutlineWidth > 0; pointIndex++)
                {
                    Point start; Point end;
                    // Draw Line Between Final Point and First Point
                    if (pointIndex == numCoords - 1)
                    {
                        start = new Point(Convert.ToInt32(sketchCoords[0][0]), Convert.ToInt32(sketchCoords[0][1]));
                        end = new Point(Convert.ToInt32(sketchCoords[numCoords - 1][0]), Convert.ToInt32(sketchCoords[numCoords - 1][1]));
                    }
                    // Draw Remaining Lines
                    else
                    {
                        start = new Point(Convert.ToInt32(sketchCoords[pointIndex][0]), Convert.ToInt32(sketchCoords[pointIndex][1]));
                        end = new Point(Convert.ToInt32(sketchCoords[pointIndex + 1][0]), Convert.ToInt32(sketchCoords[pointIndex + 1][1]));
                    }

                    // Connected by Line
                    if (joiners[numCoords - 1] == "line")
                    {
                        g.DrawLine(pen, start, end);
                    }
                    // Connected by Curve
                    else
                    {
                        // TO DO **
                    }
                }
            }
        }

        /// <summary>
        /// Draws all pieces in a list
        /// </summary>
        /// <param name="DrawPanel">Panel to be drawn on</param>
        /// <param name="piecesList">Pieces to be drawn</param>
        /// <param name="g">Graphics to draw</param>
        public static void DrawPieces(List<Piece> piecesList, Graphics g, PictureBox DrawPanel)
        {
            // Prepare
            DrawPanel.Refresh();
            g = DrawPanel.CreateGraphics();

            // Draw Parts
            // List<Piece> orderedPieces = SortOrder(piecesList);
            for (int index = 0; index < piecesList.Count; index++)
            {
                DrawPiece(piecesList[index], g, true);
                //DrawPiece(orderedPieces[index], g, true);
            }
        }

        /// <summary>
        /// Finds the correct order to draw pieces so they are layered correctly.
        /// </summary>
        /// <param name="piecesList">The list of pieces in original order</param>
        /// <returns>Ordered list of pieces</returns>
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

        /// <summary>
        /// Finds the closest coordinate from the list.
        /// Returns -1 if none within 9 pixels of the given position.
        /// </summary>
        /// <param name="toSearch">The list of coordinates to search</param>
        /// <param name="x">The x coord to be close to</param>
        /// <param name="y">The y coord to be close to</param>
        /// <returns>Index of list that is closest</returns>
        public static int FindClosestIndex(List<double[]> toSearch, int x, int y)
        {
            int[] ranges = Constants.Ranges;

            foreach (int range in ranges)
            {
                for (int index = 0; index < toSearch.Count(); index++)
                {
                    if (x >= toSearch[index][0] - range && x <= toSearch[index][0] + range 
                        && y >= toSearch[index][1] - range && y <= toSearch[index][1] + range)
                    {
                        return index;
                    }
                }
            }
            return -1;
        }



        // ----- OTHER FUNCTIONS -----

        /// <summary>
        /// Finds the mathematical modulus of a mod b.
        /// </summary>
        /// <param name="a">Value to be divided</param>
        /// <param name="b">Modulus</param>
        /// <returns>a modulo b</returns>
        public static int Modulo(int a, int b)
        {
            return (a % b + b) % b;
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
            int row; bool found = false;

            for (row = rowNum; row < data.Count && !found; row++)
            {
                if (r >= int.Parse(data[row].Substring(0, 3)) && r < int.Parse(data[row].Substring(4, 3))
                        && t >= int.Parse(data[row].Substring(8, 3)) && t < int.Parse(data[row].Substring(12, 3)))
                {
                    found = true;
                }
            }
            return (found) ? row - 1 : -1;
        }

        /// <summary>
        /// Finds the minimum and maximum x and y coordinates of a point.
        /// </summary>
        /// <param name="entries">Shape points</param>
        /// <returns>The mins and maxes as [minX, maxX, minY, maxY]</returns>
        public static double[] FindMinMax(List<double[]> coords)
        {
            double minX = 99999;
            double maxX = -99999;
            double minY = 99999;
            double maxY = -99999;
            foreach (double[] entry in coords)
            {
                minX = (entry[0] < minX) ? entry[0] : minX;
                maxX = (entry[0] > maxX) ? entry[0] : maxX;
                minY = (entry[1] < minY) ? entry[1] : minY;
                maxY = (entry[1] > maxY) ? entry[1] : maxY;
            }
            return new double[] { minX, maxX, minY, maxY };
        }

        /// <summary>
        /// Finds the middle of a shape.
        /// </summary>
        /// <param name="coords">Shape points</param>
        /// <returns>The middle as [middle x, middle y]</returns>
        public static double[] FindMid(List<double[]> coords)
        {
            double[] minMax = FindMinMax(coords);
            return new double[] { minMax[0] + (minMax[1] - minMax[0]) / 2, minMax[2] + (minMax[3] - minMax[2]) / 2 };
        }

        /// <summary>
        /// Flips a shape vertically and/or horizontally
        /// </summary>
        /// <param name="coords">Shape coordinates</param>
        /// <param name="lineArray">Lines that connect points</param>
        /// <param name="right">Flip vertically</param>
        /// <param name="down">Flip horizontally</param>
        /// <returns></returns>
        public static List<double[]> FlipCoords(List<double[]> coords, List<string> lineArray, bool right, bool down)
        {
            double[] middle = FindMid(coords);
            List<double[]> newCoords = new List<double[]>();

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

            return newCoords;
        }

        /// <summary>
        /// Checks shape coordinates are valid and returns a set of coordinates where
        /// all coordinates have a matching coord horizontally and vertically to them if
        /// it is valid.
        /// </summary>
        /// <param name="oCoords">Original coordinates</param>
        /// <param name="rCoords">Rotated coordinates</param>
        /// <param name="tCoords">Turned coordinates</param>
        /// <param name="lineArray">Lines that connect points</param>
        /// <returns>Shape coordinates with extra coords on both sides</returns>
        public static void CoordsOnAllSides(List<double[]> oCoords, List<double[]> rCoords, List<double[]> tCoords, List<string> lineArray)
        {
            // Check Viable Pieces
            // ** TO DO

            double[] highestPoints = FindMinMax(oCoords);
            List<int> clearIndexes = new List<int>();

            // Horizontal Allignment (Same Y Value)
            for (int index = 0; index < oCoords.Count; index++)
            {
                // Check if there is already a matching on the other side and that the coordinate is not the bottom
                if (FindSymmetricalCoord(oCoords, index, 1) == -1 && 
                    oCoords[index][1] != highestPoints[3] && oCoords[index][1] != highestPoints[2])
                {
                    int insertIndex = FindSymmetricalCoordHome(oCoords, index, 1);
                    oCoords.Insert(insertIndex, FindSymmetricalOppositeCoord(oCoords[insertIndex],
                        oCoords[Modulo(insertIndex - 1, oCoords.Count)], oCoords[index][1], 1, lineArray[insertIndex]));
                    rCoords.Insert(insertIndex, FindSymmetricalOppositeCoord(rCoords[insertIndex],
                        rCoords[Modulo(insertIndex - 1, rCoords.Count)], rCoords[index][1], 1, lineArray[insertIndex]));
                    tCoords.Insert(insertIndex, FindSymmetricalOppositeCoord(tCoords[insertIndex],
                        tCoords[Modulo(insertIndex - 1, tCoords.Count)], tCoords[index][1], 1, lineArray[insertIndex]));
                    lineArray.Insert(insertIndex, "line");
                }
            }

            // Vertical Allignment (Same X Value)
            for (int index = 0; index < oCoords.Count; index++)
            {
                // Check if there is already a matching on the other side and that the coordinate is not the bottom
                if (FindSymmetricalCoord(oCoords, index, 0) == -1 && 
                    oCoords[index][0] != highestPoints[1] && oCoords[index][0] != highestPoints[0])
                {
                    int insertIndex = FindSymmetricalCoordHome(oCoords, index, 0);
                    oCoords.Insert(insertIndex, FindSymmetricalOppositeCoord(oCoords[insertIndex],
                        oCoords[Modulo(insertIndex - 1, oCoords.Count)], oCoords[index][0], 0, lineArray[insertIndex]));
                    rCoords.Insert(insertIndex, FindSymmetricalOppositeCoord(rCoords[insertIndex],
                        rCoords[Modulo(insertIndex - 1, oCoords.Count)], rCoords[index][0], 0, lineArray[insertIndex]));
                    tCoords.Insert(insertIndex, FindSymmetricalOppositeCoord(tCoords[insertIndex],
                        tCoords[Modulo(insertIndex - 1, oCoords.Count)], tCoords[index][0], 0, lineArray[insertIndex]));
                    lineArray.Insert(insertIndex, "line");
                }
            }
        }

        /// <summary>
        /// Finds the index of the coordinate that has the same x or y value
        /// as the selected coordinate.
        /// </summary>
        /// <param name="coords">List of piece coordinates</param>
        /// <param name="matchIndex">The index of the selected coordinate</param>
        /// <param name="xy">Whether searching for a match in x (0) or y (1)</param>
        /// <returns>The symmetrical point's index or -1 if none exists</returns>
        public static int FindSymmetricalCoord(List<double[]> coords, int matchIndex, int xy)
        {
            for (int index = 0; index < coords.Count; index++)
            {
                if (coords[index][xy] == coords[matchIndex][xy] && index != matchIndex)
                {
                    return index;
                }
            }
            return -1;
        }

        /// <summary>
        /// Finds the coordinate across from the selected coordinate.
        /// </summary>
        /// <param name="from">Coord before pending</param>
        /// <param name="to">Coord after pending</param>
        /// <param name="value">Selected value to match</param>
        /// <param name="xy">Whether the x (0) or y (1) should be matched</param>
        /// <param name="line">The join between the lines</param>
        /// <returns></returns>
        public static double[] FindSymmetricalOppositeCoord(double[] from, double[] to, double value, int xy, string line)
        {
            double gradient = -1;
            if (line == "line")
            {
                gradient = (from[1] - to[1]) / (from[0] - to[0]);
            }

            if (xy == 0)
            {
                return new double[] { value, from[1] + (value - from[0]) * gradient };  // y = x * gradient
            }
            else
            {
                return new double[] { from[0] + (value - from[1]) / gradient, value };  // x = y / gradient
            }
        }

        /// <summary>
        /// Finds where a matching point would go if it existed.
        /// </summary>
        /// <param name="coords">List of piece coordinates</param>
        /// <param name="matchIndex">The index of the selected coordinate</param>
        /// <param name="xy">Whether searching for a match in x (0) or y (1)</param>
        /// <returns>The index where the matching point would go or -1 in error</returns>
        public static int FindSymmetricalCoordHome(List<double[]> coords, int matchIndex, int xy)
        {
            double goal = coords[matchIndex][xy];
            bool bigger = false;
            int searchIndex = -1;

            // Find whether we're searching above or below the goal
            for (int index = 0; index < coords.Count && searchIndex == -1; index++)
            {
                if (coords[index][xy] != goal)
                {
                    bigger = (coords[index][xy] > goal);
                    searchIndex = (index + 1) % coords.Count;
                }
            }

            // Find index position
            for (int index = 0; index < coords.Count; index++)
            {
                if (coords[searchIndex][xy] == goal)
                {
                    bigger = !bigger;
                }
                else if (coords[searchIndex][xy] > goal != bigger)
                {
                    return searchIndex;
                }
                searchIndex = (searchIndex + 1) % coords.Count;
            }
            return -1;       // Error
        }

        /// <summary>
        /// Switches the positions of two values in the list.
        /// Note that index order is not important.
        /// </summary>
        /// <param name="toSwitch">The list of values</param>
        /// <param name="index1">The index of the first value</param>
        /// <param name="index2">The index of the second value</param>
        public static void SwitchPositions(List<double[]> toSwitch, int index1, int index2)
        {
            double[] holding = toSwitch[index1];
            toSwitch[index1] = toSwitch[index2];
            toSwitch[index2] = holding;
        }



        // ----- SHAPE SURFACE FUNCTIONS -----

        /// <summary>
        /// Finds all of the coordinates between two points.
        /// </summary>
        /// <param name="from">The starting point</param>
        /// <param name="to">The end point</param>
        /// <param name="join">How the two points are connected</param>
        /// <returns>A list of int[] with the point coords</returns>
        public static List<double[]> FindLineCoords(double[] from, double[] to, string join)
        {
            List<double[]> line = new List<double[]>();
            double gradient = 1;
            double[] lower = (from[1] < to[1]) ? from : to;
            double[] upper = (from[1] < to[1]) ? to : from;

            // Find Gradient
            if (join == "line")
            {
                // If straight vertical line
                if (from[0] - to[0] == 0)
                {
                    for (int index = (int)lower[1]; index < upper[1]; index++)
                    {
                        line.Add(new double[] { from[0], index });
                    }
                    return line;
                }
                // If straight horizontal line
                else if (from[1] - to[1] == 0)
                {
                    line.Add(from);
                    line.Add(to);
                    return line;
                }
                // If diagonal line
                else
                {
                    gradient = (from[1] - to[1]) / (from[0] - to[0]);
                }
            }
            // ** TO DO - CURVES

            // Add point for each Y value
            line.Add(from);
            for (int index = (int)lower[1] + 1; index < upper[1]; index++)
            {
                line.Add(new double[] { lower[0] + ((index - lower[1]) * gradient), index });
            }
            line.Add(to);
            return line;
        }

        /// <summary>
        /// Finds the coordinates along the outline of the shape.
        /// </summary>
        /// <param name="coords">Coordinates of the shape</param>
        /// <param name="lineArray">Lines that connect points</param>
        /// <returns>A list of int[] with the outline coordinates</returns>
        public static List<double[]> FindPieceLines(List<double[]> coords, List<string> lineArray)
        {
            List<double[]> line = new List<double[]>();

            for (int index = 0; index < coords.Count; index++)
            {
                if (index == coords.Count - 1)
                {
                    line.AddRange(FindLineCoords(new double[] { coords[index][0], coords[index][1] },
                        new double[] { coords[0][0], coords[0][1] }, lineArray[index]));
                }
                else
                {
                    line.AddRange(FindLineCoords(new double[] { coords[index][0], coords[index][1] }, 
                        new double[] { coords[index + 1][0], coords[index + 1][1] }, lineArray[index]));
                }
            }
            return line;
        }

        /// <summary>
        /// Finds all of the coordinates that the shape covers.
        /// Includes both outlines and fill.
        /// </summary>
        /// <param name="outline">The coordinates around the outline of the shape</param>
        /// <returns>List of covered coordinates</returns>
        public static List<int[]> FindPieceSpace(List<double[]> outline)
        {
            List<int[]> pieceSpace = new List<int[]>();

            // Sort pieceSpace by Y, then by X
            for (int spot = 0; spot < outline.Count - 1; spot++)
            {
                for (int position = 0; position < outline.Count - spot - 1; position++)
                {
                    if (outline[position][1] > outline[position + 1][1] 
                        || (outline[position][1] == outline[position + 1][1] && outline[position][0] > outline[position + 1][0]))
                    {
                        SwitchPositions(outline, position, position + 1);
                    }
                }
            }

            double[] minMax = FindMinMax(outline);
            int y = (int)minMax[2];
            int index = 0;
            while (y < minMax[3])
            {
                // Find all points in that row (should be a multiple of 2)
                List<double[]> row = new List<double[]>();
                while (outline[index][1] == y)
                {
                    row.Add(outline[index]);
                    index++;
                }

                // Add coords between point pairs to pieceSpace
                for (int column = 0; column + 1 < row.Count; column += 2)
                {
                    for (int point = (int)row[column][0]; point < row[column + 1][0]; point++)
                    {
                        pieceSpace.Add(new int[] { point, y });
                    }
                }
                y++;
            }
            return pieceSpace;
        }

        /// <summary>
        /// Finds the top piece clicked from the list.
        /// </summary>
        /// <param name="piecesList">The list of pieces that could be clicked</param>
        /// <param name="x">The x coordinate of the click</param>
        /// <param name="y">The y coordinate of the click</param>
        /// <returns>The index of the piece clicked, or negative one if none selected</returns>
        public static int FindClickedSelection(List<Piece> piecesList, int x, int y)
        {
            for (int index = piecesList.Count - 1; index >= 0; index--)
            {
                List<double[]> coords = piecesList[index].GetCurrentPoints(true);
                List<int[]> contents = FindPieceSpace(FindPieceLines(coords, 
                    piecesList[index].GetLineArray(piecesList[index].R, piecesList[index].T)));

                foreach (int[] dot in contents)
                {
                    if (dot[0] == x && dot[1] == y)
                    {
                        return index;
                    }
                }
            }
            return -1;
        }
    }
}
