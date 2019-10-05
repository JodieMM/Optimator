using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System;

namespace Animator
{
    /// <summary>
    /// Holds utility functions common to multiple classes and/or forms.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class Utils
    {
        // ----- FILE I/O -----
        #region File I/O

        /// <summary>
        /// Reads information from a user-selected file and returns it.
        /// </summary>
        /// <param name="types">The acceptable file types</param>
        /// <returns>Contents of file</returns>
        public static List<string> ReadData(string[] types)
        {
            var data = new List<string>();
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var file = new StreamReader(openFileDialog.FileName);
                    string line;
                    while ((line = file.ReadLine()) != null)
                        data.Add(line);
                    file.Close();
                }
                catch (System.Security.SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }

            // Check correct file type
            if (!types.Contains(data[0].Split(Consts.Semi)[0]))
            {
                if (types.Length == 1)
                    MessageBox.Show("File is of the wrong type. Please select a " 
                        + types[0] + " file");
                else
                    MessageBox.Show("File is of the wrong type. Please select a " 
                        + types[0] + " or " + types[1] + " file");
                return null;
            }
            return data;
        }

        /// <summary>
        /// Saves provided data to a user selected location.
        /// </summary>
        /// <param name="data">The data to save</param>
        public static void SaveData(List<string> data)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "optr files (*.optr)|*.optr|All files (*.*)|*.*",
                FilterIndex = 0
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!CheckValidNewName(Path.GetFileNameWithoutExtension(saveFileDialog.FileName)))
                {
                    SaveData(data);
                    return;
                }

                var file = new StreamWriter(saveFileDialog.OpenFile());
                if (file != null)
                {
                    foreach (var line in data)
                        file.WriteLine(line);
                    file.Close();
                }
            }
        }
                
        /// <summary>
        /// Reads information from a file and returns it.
        /// </summary>
        /// <param name="directory">The file to read from</param>
        /// <returns>A list of strings containing the data</returns>
        public static List<string> ReadFile(string directory)
        {
            var data = new List<string>();
            var file = new StreamReader(directory);
            string line;
            while ((line = file.ReadLine()) != null)
                data.Add(line);
            file.Close();

            return data;
        }

        /// <summary>
        /// Saves a file to a provided location.
        /// </summary>
        /// <param name="directory">The file to save to</param>
        /// <param name="data">The data to save</param>
        public static void SaveFile(string directory, List<string> data)
        {
            var file = new StreamWriter(@directory);
            for (int index = 0; index < data.Count; index++)
                file.WriteLine(data[index]);
            file.Close();
        }

        /// <summary>
        /// Takes a folder, item name and file type and returns the directory name to reach that file.
        /// </summary>
        /// <param name="folder">The folder the item is in</param>
        /// <param name="name">The item name</param>
        /// <param name="fileType">The file's type, e.g. optr</param>
        /// <returns></returns>
        public static string GetDirectory(string folder, string name, string fileType = "")
        {
            return Path.Combine(Settings.WorkingDirectory, folder, name + fileType);
        }

        /// <summary>
        /// Selects a folder at a user's selected location.
        /// </summary>
        /// <param name="baseFolder">Whether the initial four sub-folders should be added</param>
        /// <returns>Path for new folder</returns>
        public static string SelectFolder(bool baseFolder = false)
        {
            var path = "";
            var openFileDialog = new FolderBrowserDialog();
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = openFileDialog.SelectedPath;
            }

            // Create sub-folders if this is the base directory
            if (baseFolder && path != "")
            {
                Settings.WorkingDirectory = path;
                Settings.UpdateSettings();
                Directory.CreateDirectory(Path.Combine(Settings.WorkingDirectory, Consts.PiecesFolder));
                Directory.CreateDirectory(Path.Combine(Settings.WorkingDirectory, Consts.SetsFolder));
                Directory.CreateDirectory(Path.Combine(Settings.WorkingDirectory, Consts.ScenesFolder));
                Directory.CreateDirectory(Path.Combine(Settings.WorkingDirectory, Consts.VideosFolder));
            }
            return path;
        }

        /// <summary>
        /// Checks that a working directory has been set, and creates
        /// one if necessary.
        /// </summary>
        public static void CheckValidFolder()
        {
            if (Settings.WorkingDirectory == "Blank" || !Directory.Exists(Settings.WorkingDirectory))
            {
                MessageBox.Show("Select a directory to work from.", "Directory Selection");
                while (SelectFolder(true) == "");
            }
        }

        /// <summary>
        /// Checks that the version provided is file compatible with the current version.
        /// </summary>
        /// <param name="version">The version of the file</param>
        /// <param name="message">Whether an error message should be shown on fail</param>
        /// <returns>True if the versions are compatible</returns>
        public static bool CheckValidVersion(string version, bool message = true)
        {
            string[] thisVer = version.Split(Consts.Stop);
            string[] currVer = Consts.Version.Split(Consts.Stop);
            if (thisVer[0] == currVer[0] && thisVer[1] == currVer[1])
                return true;

            if (message)
                MessageBox.Show("The file version is not compatible.");
            return false;
        }

        /// <summary>
        /// Checks that the name given for the file is valid for use.
        /// </summary>
        /// <param name="name">The name of the file</param>
        /// <param name="folder">The folder the file belongs in</param>
        /// <returns>True if the name is valid</returns>
        public static bool CheckValidNewName(string name, string folder = "")
        {
            Regex PermittedName = new Regex(@"^[A-Za-z0-9]+$");
            if (!PermittedName.IsMatch(name))
            {
                MessageBox.Show("Please choose a valid name for your file. Name can only include letters and numbers.", "Name Invalid", MessageBoxButtons.OK);
                return false;
            }

            // Check name not already in use, or that overriding is okay
            if (folder != "" && File.Exists(GetDirectory(folder, name, Consts.Optr)))
            {
                var result = MessageBox.Show("This name is already in use. Do you want to override the existing file?", "Override Confirmation", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel) { return false; }
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
        /// Converts an array of strings into an array of doubles.
        /// Used when loading from text files.
        /// </summary>
        /// <param name="strArray">The array of strings to be converted</param>
        /// <returns>A double array of the values in the input</returns>
        public static double[] ConvertStringArrayToDoubles(string[] strArray)
        {
            double[] dblArray = new double[strArray.Length];
            for (int index = 0; index < strArray.Length; index++)
            {
                dblArray[index] = double.Parse(strArray[index]);
            }
            return dblArray;
        }

        /// <summary>
        /// Converts a colour into its ARGB values.
        /// </summary>
        /// <param name="color">The colour to convert</param>
        /// <returns>A string array of ARGB values</returns>
        public static string ColorToString(Color color)
        {
            return color.A + Consts.CommaS + color.R + Consts.CommaS +
                color.G + Consts.CommaS + color.B;
        }

        /// <summary>
        /// Converts a string of ARGB value into a colour.
        /// </summary>
        /// <param name="color">A string of comma-seperated argb values</param>
        /// <returns>A colour with the given ARGB value</returns>
        public static Color ColourFromString(string color)
        {
            string[] argb = color.Split(Consts.Comma);
            return Color.FromArgb(int.Parse(argb[0]), int.Parse(argb[1]), 
                int.Parse(argb[2]), int.Parse(argb[3]));
        }

        /// <summary>
        /// Copies the details from a state into a separate entity.
        /// </summary>
        /// <param name="state">The state to clone</param>
        /// <param name="colours">Whether colours should be added to the state</param>
        /// <returns>A separate State</returns>
        public static State CloneState(State state, bool colours = false)
        {
            return colours? new State(state.X, state.Y, state.R, state.T, state.S, state.SM, state.FC, state.OC) 
                : new State(state.X, state.Y, state.R, state.T, state.S, state.SM);
            // CLEANING: Only leave one option?
        }

        #endregion




        // ----- COORDINATE FUNCTIONS -----

        /// <summary>
        /// Finds the mid-way point between an original and rotated
        /// or turned point based on the current R or S state.
        /// </summary>
        /// <param name="angle">The relevant R or S state value</param>
        /// <param name="initial">The original X or Y value</param>
        /// <param name="angled">The rotated/turned x/y value</param>
        /// <returns></returns>
        public static double RotOrTurnCalculation(double angle, double initial, double angled)
        {
            double lower;
            double upper;
            double bottomAngle;

            if (angle < 90)
            {
                lower = initial;
                upper = angled;
                bottomAngle = 0;
            }
            else if (angle < 180)
            {
                lower = angled;
                upper = -initial;
                bottomAngle = 90;
            }
            else if (angle < 270)
            {
                lower = -initial;
                upper = -angled;
                bottomAngle = 180;
            }
            else
            {
                lower = -angled;
                upper = initial;
                bottomAngle = 270;
            }

            return lower + (upper - lower) * ((angle - bottomAngle) / 90.0);
        }

        /// <summary>
        /// Spins and resizes a coordinate based on the provided 
        /// spin and sizemod state.
        /// </summary>
        /// <param name="spinAngle">The spin state</param>
        /// <param name="sizeMod">The size modifier state</param>
        /// <param name="coord">The x and y coord of the spun point</param>
        /// <returns></returns>
        public static double[] SpinAndSizeCoord(double spinAngle, double sizeMod, double[] coord)
        {
            double hypotenuse = Math.Sqrt(Math.Pow(coord[0], 2) + Math.Pow(coord[1], 2)) * sizeMod;

            // Find Angle
            double pointAngle;
            if (coord[0] == 0 && coord[1] < 0)
            {
                pointAngle = 0;
            }
            else if (coord[0] == 0 && coord[1] > 0)
            {
                pointAngle = 180;
            }
            else if (coord[0] > 0 && coord[1] == 0)
            {
                pointAngle = 90;
            }
            else if (coord[0] < 0 && coord[1] == 0)
            {
                pointAngle = 270;
            }
            //  Second || First
            //  Third  || Fourth
            else if (coord[0] > 0 && coord[1] < 0) // First Quadrant
            {
                pointAngle = 180 / Math.PI * Math.Atan(Math.Abs((0 - coord[0]) / (0 - coord[1])));
            }
            else if (coord[0] > 0 && coord[1] > 0) // Fourth Quadrant
            {
                pointAngle = 90 + 180 / Math.PI * Math.Atan(Math.Abs((0 - coord[1]) / (0 - coord[0])));
            }
            else if (coord[0] < 0 && coord[1] < 0) // Second Quadrant
            {
                pointAngle = 270 + 180 / Math.PI * Math.Atan(Math.Abs((0 - coord[1]) / (0 - coord[0])));
            }
            else  // Third Quadrant
            {
                pointAngle = 180 + 180 / Math.PI * Math.Atan(Math.Abs((0 - coord[0]) / (0 - coord[1])));
            }
            double findAngle = (pointAngle + spinAngle) * Math.PI / 180 % 360;

            // Find Points
            return new double[] 
            {
                Convert.ToInt32(0 + hypotenuse * Math.Sin(findAngle)),
                coord[1] = Convert.ToInt32(0 - hypotenuse * Math.Cos(findAngle))
            };
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



        // ----- BUTTON FUNCTIONS -----

        /// <summary>
        /// Checks whether the user wants to exit without saving.
        /// </summary>
        /// <param name="saveCondition">The test to see if there is anything worth saving</param>
        /// <returns>True if the form should be closed</returns>
        public static bool ExitBtn_Click(bool saveCondition)
        {
            var result = DialogResult.OK;

            // Only check saving if something to save
            if (saveCondition)
                result = DialogResult.OK; // HIDDEN: Add back MessageBox.Show("Do you want to exit without saving? Your work will be lost.", "Exit Confirmation", MessageBoxButtons.OKCancel);

            return result == DialogResult.OK;
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
            int increment = fromTop ? -1 : 1;
            for (index = fromTop ? piecesList.Count - 1 : 0; fromTop ? index >= 0 : index < piecesList.Count; index += increment)
            {
                var outline = piecesList[index].LineBounds();
                foreach (var range in outline)
                    if (y == range[0] && x >= range[1] && x <= range[2])
                        return index;
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
            foreach (int range in Consts.Ranges)
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
    }
}
