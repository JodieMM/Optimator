﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

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
        #region File I/O

        /// <summary>
        /// Reads information from a text file and returns it
        /// </summary>
        /// <param name="directory">The file to read from</param>
        /// <returns>A list of strings containing the data</returns>
        public static List<string> ReadFile(string directory)
        {
            // Open File
            string filePath = directory;
            StreamReader file = new StreamReader(@filePath);

            // Read Data
            List<string> data = new List<string>();
            string line;
            while ((line = file.ReadLine()) != null)
                data.Add(line);

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
            StreamWriter file = new StreamWriter(@directory);
            for (int index = 0; index < data.Count; index++)
                file.WriteLine(data[index]);
            file.Close();
        }

        /// <summary>
        /// Takes a folder, item name and file type and returns the directory name to reach that file.
        /// </summary>
        /// <param name="folder">The folder the item is in</param>
        /// <param name="name">The item name</param>
        /// <param name="fileType">The file's type, e.g. txt, png</param>
        /// <returns></returns>
        public static string GetDirectory(string folder, string name, string fileType = "", string subfolder = "")
        {
            string fileFolder = Path.Combine(Environment.CurrentDirectory, folder);
            if (subfolder != "") { fileFolder = Path.Combine(fileFolder, subfolder); }
            return Path.Combine(fileFolder, name + fileType);
        }

        /// <summary>
        /// Checks that the name given for the file is valid for use.
        /// </summary>
        /// <param name="name">The name of the file</param>
        /// <param name="folder">The folder the file belongs in</param>
        /// <returns></returns>
        public static bool CheckValidNewName(string name, string folder)
        {
            // Check Name is Valid for Saving
            if (!Constants.PermittedName.IsMatch(name))
            {
                MessageBox.Show("Please choose a valid name for your file. Name can only include letters and numbers.", "Name Invalid", MessageBoxButtons.OK);
                return false;
            }

            // Check name not already in use, or that overriding is okay
            if (File.Exists(GetDirectory(folder, name, Constants.Txt)))
            {
                DialogResult result = MessageBox.Show("This name is already in use. Do you want to override the existing file?", "Override Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) { return false; }
            }
            return true;
        }

        #endregion



        // ----- GENERAL FUNCTIONS -----
        #region General Functions

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
        /// Finds the minimum and maximum x and y coordinates of a point.
        /// </summary>
        /// <param name="coords">Shape points</param>
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
            return new double[] { minMax[0] + (minMax[1] - minMax[0]) / 2.0, minMax[2] + (minMax[3] - minMax[2]) / 2.0 };
        }

        /// <summary>
        /// Flips a point around a center. 
        /// Works for either x or y flips.
        /// </summary>
        /// <param name="mid">The axis to flip on</param>
        /// <param name="point">The point to flip</param>
        /// <returns>The point reflected on the axis</returns>
        public static double FlipPoint(double mid, double point)
        {
            return 2 * mid - point;
        }

        /// <summary>
        /// Converts the spots into a list of their original
        /// coordinates as double[].
        /// </summary>
        /// <param name="spots">The list of spots to convert</param>
        /// <param name="angle">Original [0], rotated[1], turned[2]</param>
        /// <returns>A list of coordinates</returns>
        public static List<double[]> ConvertSpotsToCoords(List<Spot> spots, int angle = 0)
        {
            List<double[]> toReturn = new List<double[]>();
            foreach (Spot spot in spots)
                toReturn.Add(spot.GetCoordCombination(angle));

            return toReturn;
        }

        #endregion



        // ----- BUTTON FUNCTIONS -----

        /// <summary>
        /// Checks whether the user wants to exit without saving.
        /// </summary>
        /// <param name="saveCondition">The test to see if there is anything worth saving</param>
        /// <returns>True if the form should be closed</returns>
        public static bool ExitBtn_Click(bool saveCondition)
        {
            DialogResult result = DialogResult.Yes;

            // Only check saving if something to save
            if (saveCondition)
                result = MessageBox.Show("Do you want to exit without saving? Your work will be lost.", "Exit Confirmation", MessageBoxButtons.YesNo);

            return result == DialogResult.Yes;
        }



        // ----- CLICK FUNCTIONS -----

        /// <summary>
        /// Finds the piece clicked from the list.
        /// </summary>
        /// <param name="piecesList">The list of pieces that could be clicked</param>
        /// <param name="x">The x coordinate of the click</param>
        /// <param name="y">The y coordinate of the click</param>
        /// <returns>The index of the piece clicked, or negative one if none selected</returns>
        public static int FindClickedSelection(List<Piece> piecesList, int x, int y, bool fromTop = true)
        {
            // Searches pieces either from the top or the bottom of the list
            int index;
            int increment = (fromTop) ? -1 : 1;
            for (index = (fromTop) ? piecesList.Count - 1 : 0; (fromTop) ? index >= 0 : index < piecesList.Count; index += increment)
            {
                List<int[]> contents = FindPieceSpace(FindPieceLines(piecesList[index]));

                foreach (int[] dot in contents)
                {
                    if (dot[0] == x && dot[1] == y)
                        return index;
                }
            }
            return -1;
        }

        /// <summary>
        /// Finds the closest coordinate from the list.
        /// Returns -1 if none within 9 pixels of the given position.
        /// </summary>
        /// <param name="toSearch">The list of spots to search</param>
        /// <param name="x">The x coord to be close to</param>
        /// <param name="y">The y coord to be close to</param>
        /// <returns>Index of list that is closest</returns>
        public static int FindClosestIndex(List<Spot> toSearch, int angle, int x, int y)
        {
            foreach (int range in Constants.Ranges)
            {
                for (int index = 0; index < toSearch.Count(); index++)
                {
                    if (x >= toSearch[index].GetCoordCombination(angle)[0] - range && x <= toSearch[index].GetCoordCombination(angle)[0] + range
                        && y >= toSearch[index].GetCoordCombination(angle)[1] - range && y <= toSearch[index].GetCoordCombination(angle)[1] + range)
                    {
                        return index;
                    }
                }
            }
            return -1;
        }



        // ----- SHAPE SURFACE FUNCTIONS -----
        #region Shape Surface Functions

        /// <summary>
        /// Finds the coordinates along the outline of the shape.
        /// </summary>
        /// <param name="coords">Coordinates of the shape</param>
        /// <param name="lineArray">Lines that connect points</param>
        /// <returns>A list of int[] with the outline coordinates</returns>
        public static List<double[]> FindPieceLines(Piece piece)
        {
            List<double[]> coords = piece.CurrentPoints();
            List<double[]> lines = new List<double[]>();

            //// If lines exist for this piece
            //if (coords.Count > 2)
            //{
            //    for (int index = 0; index < coords.Count; index++)
            //    {
            //        if (index == coords.Count - 1)
            //            lines.AddRange(FindLineCoords(new double[] { coords[index][0], coords[index][1] },
            //                new double[] { coords[0][0], coords[0][1] }, piece.Data[index].Connector));
            //        else
            //            lines.AddRange(FindLineCoords(new double[] { coords[index][0], coords[index][1] },
            //                new double[] { coords[index + 1][0], coords[index + 1][1] }, piece.Data[index].Connector));
            //    }
            //}
            //// Single or no point
            //else
            //    lines.AddRange(coords);

            return lines;
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
            if (outline.Count > 2)
            {
                // Sort pieceSpace by Y, then by X
                for (int spot = 0; spot < outline.Count - 1; spot++)
                {
                    for (int position = 0; position < outline.Count - spot - 1; position++)
                    {
                        if (outline[position][1] > outline[position + 1][1]
                            || (outline[position][1] == outline[position + 1][1] && outline[position][0] > outline[position + 1][0]))
                        {
                            double[] holding = outline[position];
                            outline[position] = outline[position + 1];
                            outline[position + 1] = holding;
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
            }
            else
            {
                // TEMPORARY FIX FOR STRAIGHT LINES (NO FILL)
                foreach (double[] point in outline)
                {
                    pieceSpace.Add(new int[] { (int)point[0], (int)point[1] });
                    pieceSpace.Add(new int[] { (int)point[0]+1, (int)point[1] });
                    pieceSpace.Add(new int[] { (int)point[0]-1, (int)point[1] });
                    pieceSpace.Add(new int[] { (int)point[0], (int)point[1]+1 });
                    pieceSpace.Add(new int[] { (int)point[0], (int)point[1]-1 });
                    pieceSpace.Add(new int[] { (int)point[0]+1, (int)point[1]+1 });
                    pieceSpace.Add(new int[] { (int)point[0]-1, (int)point[1]-1 });
                    pieceSpace.Add(new int[] { (int)point[0] + 1, (int)point[1] - 1 });
                    pieceSpace.Add(new int[] { (int)point[0] - 1, (int)point[1] + 1 });
                }
            }
            return pieceSpace;
        }

        #endregion
    }
}
