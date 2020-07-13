using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System;
using Optimator.Tabs;

namespace Optimator
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
        /// Finds directory of user-selected file.
        /// </summary>
        /// <param name="types">The acceptable file types</param>
        /// <returns>File name</returns>
        public static string OpenFile(string filter)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = filter
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.WorkingDirectory = Path.GetDirectoryName(openFileDialog.FileName);
                return openFileDialog.SafeFileName;
            }
            return "";
        }

        /// <summary>
        /// Finds directory of one or many user-selected files.
        /// </summary>
        /// <param name="types">The acceptable file types</param>
        /// <returns>File name(s)</returns>
        public static string[] OpenFiles(string filter)
        {
            var data = new List<string>();
            var openFileDialog = new OpenFileDialog
            {
                Filter = filter,
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.WorkingDirectory = Path.GetDirectoryName(openFileDialog.FileName);
                return openFileDialog.SafeFileNames;
            }
            return null;
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
            {
                data.Add(line);
                if (data.Count == 1)
                {
                    CheckValidVersion(data[0]);
                }
            }
            file.Close();
            return data;
        }

        /// <summary>
        /// Saves a file to a new or existing location.
        /// </summary>
        /// <param name="data">The data to save</param>
        /// <param name="filter">The permitted file extension</param>
        /// <param name="direct">The current directory</param>
        /// <returns>File directory</returns>
        public static string SaveFile(List<string> data, string filter, string direct = "")
        {
            var directory = direct == "" || !File.Exists(direct) ? SelectSaveDirectory(filter) : direct;
            if (directory != "")
            {
                if (!SaveData(directory, data))
                {
                    return "";
                }
            }
            return directory;
        }

        /// <summary>
        /// Saves data to a file location.
        /// </summary>
        /// <param name="directory">File location</param>
        /// <param name="data">Data to save</param>
        /// <returns>True if successful</returns>
        public static bool SaveData(string directory, List<string> data)
        {
            try
            {
                var file = new StreamWriter(@directory);
                for (var index = 0; index < data.Count; index++)
                {
                    file.WriteLine(data[index]);
                }
                file.Close();
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have access to this directory. Please try again.", "Invalid Directory Selection");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file and sub-files and try again.", "File Not Found", MessageBoxButtons.OK);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Suspected outdated file or sub-file.", "File Indexing Error", MessageBoxButtons.OK);
            }
            return false;
        }

        /// <summary>
        /// Selects a directory and file name to save to.
        /// </summary>
        /// <param name="filter">Permissable file extension(s)</param>
        /// <returns>File directory</returns>
        public static string SelectSaveDirectory(string filter)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = filter
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (CheckValidNewName(Utils.BaseName(saveFileDialog.FileName)))
                {
                    return saveFileDialog.FileName;
                }
            }
            return "";
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
            return Path.Combine(Properties.Settings.Default.WorkingDirectory, folder, name + fileType);
        }

        /// <summary>
        /// Takes an item name and file type and returns the directory name to reach that file.
        /// </summary>
        /// <param name="name">The item name</param>
        /// <param name="fileType">The file's type, e.g. optr</param>
        /// <returns></returns>
        public static string GetDirectory(string name, string fileType = "")
        {
            return Path.Combine(Properties.Settings.Default.WorkingDirectory, name + fileType);
        }

        /// <summary>
        /// Selects a folder at a user's selected location.
        /// </summary>
        /// <param name="baseFolder">Whether the initial four sub-folders should be added</param>
        /// <returns>Path for new folder</returns>
        public static string SelectFolder()
        {
            var path = "";
            var openFileDialog = new FolderBrowserDialog();
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = openFileDialog.SelectedPath;
            }
            return path;
        }

        /// <summary>
        /// Checks that the version provided is file compatible with the current version.
        /// </summary>
        /// <param name="version">The version of the file</param>
        /// <param name="message">Whether an error message should be shown on fail</param>
        /// <returns>True if the versions are compatible</returns>
        public static void CheckValidVersion(string version)
        {
            var thisVer = version.Split(Consts.Stop);
            var currVer = Properties.Settings.Default.Version.Split(Consts.Stop);
            if (!(thisVer[0] == currVer[0] && thisVer[1] == currVer[1]))
            {
                throw new VersionException();
            }           
        }

        /// <summary>
        /// Checks that the name given for the file is valid for use.
        /// </summary>
        /// <param name="name">The name of the file</param>
        /// <param name="folder">The folder the file belongs in</param>
        /// <returns>True if the name is valid</returns>
        public static bool CheckValidNewName(string name, string extension = "")
        {
            var PermittedName = new Regex(@"^[A-Za-z0-9]+$");
            if (!PermittedName.IsMatch(name))
            {
                MessageBox.Show("Please choose a valid name for your file. Name can only include letters and numbers.", "Name Invalid", MessageBoxButtons.OK);
                return false;
            }

            // Check name not already in use, or that overriding is okay
            if (File.Exists(GetDirectory(name, extension)))
            {
                var result = MessageBox.Show("This name is already in use. Do you want to override the existing file?", "Override Confirmation", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
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
        /// Finds the mathematical modulus of a mod b.
        /// </summary>
        /// <param name="a">Value to be divided</param>
        /// <param name="b">Modulus</param>
        /// <returns>a modulo b</returns>
        public static float Modulo(float a, float b)
        {
            return (a % b + b) % b;
        }

        /// <summary>
        /// Finds the minimum and maximum x and y coordinates of a shape.
        /// </summary>
        /// <param name="coords">Shape points</param>
        /// <returns>The mins and maxes as [minX, maxX, minY, maxY]</returns>
        public static float[] FindMinMax(List<Spot> coords)
        {
            float minX = float.MaxValue;
            float maxX = float.MinValue;
            float minY = float.MaxValue;
            float maxY = float.MinValue;
            foreach (var entry in coords)
            {
                minX = (entry.X < minX) ? entry.X : minX;
                maxX = (entry.X > maxX) ? entry.X : maxX;
                minY = (entry.Y < minY) ? entry.Y : minY;
                maxY = (entry.Y > maxY) ? entry.Y : maxY;
            }
            return new float[] { minX, maxX, minY, maxY };
        }

        /// <summary>
        /// Finds the minimum and maximum x and y coordinates of a shape.
        /// </summary>
        /// <param name="coords">Shape points</param>
        /// <returns>The mins and maxes as [minX, maxX, minY, maxY]</returns>
        public static float[] FindMinMax(List<float[]> coords)
        {
            float minX = float.MaxValue;
            float maxX = float.MinValue;
            float minY = float.MaxValue;
            float maxY = float.MinValue;
            foreach (var entry in coords)
            {
                minX = (entry[0] < minX) ? entry[0] : minX;
                maxX = (entry[0] > maxX) ? entry[0] : maxX;
                minY = (entry[1] < minY) ? entry[1] : minY;
                maxY = (entry[1] > maxY) ? entry[1] : maxY;
            }
            return new float[] { minX, maxX, minY, maxY };
        }

        /// <summary>
        /// Finds the spots that take the minimum and maximum positions.
        /// </summary>
        /// <param name="coords">The shape outline</param>
        /// <returns>Spot at minX, maxX, minY, maxY</returns>
        public static Spot[] FindMinMaxSpots(List<Spot> coords)
        {
            var spots = new Spot[4];
            float minX = float.MaxValue;
            float maxX = float.MinValue;
            float minY = float.MaxValue;
            float maxY = float.MinValue;
            foreach (var entry in coords)
            {
                if (entry.X < minX)
                {
                    minX = entry.X;
                    spots[0] = entry;
                }
                if (entry.X > maxX)
                {
                    maxX = entry.X;
                    spots[1] = entry;
                }
                if (entry.Y < minY)
                {
                    minY = entry.Y;
                    spots[2] = entry;
                }
                if (entry.Y > maxY)
                {
                    maxY = entry.Y;
                    spots[3] = entry;
                }
            }
            return spots;
        }

        /// <summary>
        /// Finds the middle of a shape.
        /// </summary>
        /// <param name="coords">Shape points</param>
        /// <returns>The middle as [middle x, middle y]</returns>
        public static float[] FindMid(List<Spot> coords)
        {
            var minMax = FindMinMax(coords);
            return new float[] { minMax[0] + (minMax[1] - minMax[0]) / 2.0F, minMax[2] + (minMax[3] - minMax[2]) / 2.0F };
        }

        /// <summary>
        /// Loops the index to the beginning (or end) of the list.
        /// </summary>
        /// <param name="list">The list to index through</param>
        /// <param name="currIndex">The index to be increased (or decreased)</param>
        /// <param name="next">True if next desired, false if previous</param>
        /// <returns>The next (or previous) index</returns>
        public static int NextIndex<T>(List<T> list, int currIndex, bool next = true)
        {
            if (next)
            {
                currIndex = (currIndex == list.Count - 1) ? 0 : currIndex + 1;
            }
            else
            {
                currIndex = (currIndex == 0) ? list.Count - 1 : currIndex - 1;
            }
            return Modulo(currIndex, list.Count);
        }

        /// <summary>
        /// Checks that the goal is within ranges of an overflowing list.
        /// </summary>
        /// <param name="minIndex">The lowest index the goal can be</param>
        /// <param name="maxIndex">The maximum index the goal can have</param>
        /// <param name="goal">The index to fit into the list</param>
        /// <returns>True if goal within ranges</returns>
        public static bool WithinRanges(int minIndex, int maxIndex, int goal)
        {
            if ((minIndex == maxIndex && minIndex == goal) ||                
                (minIndex < maxIndex && goal >= minIndex && goal < maxIndex) ||
                (minIndex > maxIndex && (goal >= minIndex || goal < maxIndex)))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if two values are practically identical.
        /// </summary>
        /// <param name="a">First value</param>
        /// <param name="b">Second value</param>
        /// <returns>True if values the same to 3dp</returns>
        public static bool SameValue(float a, float b)
        {
            return Math.Round(a, 3) == Math.Round(b, 3);
        }

        /// <summary>
        /// Adds 90 degrees to either the rotated or turned state, or makes no change.
        /// </summary>
        /// <param name="angle">0 original, 1 rotated, 2 turned</param>
        /// <param name="state">Original state</param>
        /// <returns></returns>
        public static State AdjustStateAngle(int angle, State state)
        {
            switch (angle)
            {
                case 1:
                    return new State(state, 1, (state.R + 90) % 360);
                case 2:
                    return new State(state, 2, (state.T + 90) % 360);
                default:
                    return state;
            }
        }

        #endregion



        // ----- CONVERSIONS -----

        /// <summary>
        /// Converts an angle in degrees to radians.
        /// </summary>
        /// <param name="degree">The degree to convert to radians</param>
        /// <param name="reverse">True if converting from radians to degrees</param>
        /// <returns>The degree in radians</returns>
        public static float ConvertDegreeToRadian(float degree, bool reverse = false)
        {
            if (!reverse)
            {
                return (float)Math.PI / 180.0F * degree;
            }
            else
            {
                return degree * 180.0F / (float)Math.PI;
            }
        }

        /// <summary>
        /// Converts an array of strings into an array of floats.
        /// Used when loading from text files.
        /// </summary>
        /// <param name="strArray">The array of strings to be converted</param>
        /// <returns>A float array of the values in the input</returns>
        public static float[] ConvertStringArrayToFloats(string[] strArray)
        {
            var dblArray = new float[strArray.Length];
            for (int index = 0; index < strArray.Length; index++)
            {
                dblArray[index] = float.Parse(strArray[index]);
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
            var argb = color.Split(Consts.Comma);
            return Color.FromArgb(int.Parse(argb[0]), int.Parse(argb[1]), 
                int.Parse(argb[2]), int.Parse(argb[3]));
        }

        /// <summary>
        /// Converts angle into its border value.
        /// </summary>
        /// <param name="angle">Angle to convert</param>
        /// <param name="min">If the minimum or maximum border is desired</param>
        /// <returns>Int value corresponding to border value</returns>
        public static int AngleAnchorFromAngle(float angle, bool min = true)
        {
            if (angle < 90)
            {
                return min || angle == 0 ? 0 : 1;
            }
            else if (angle < 180)
            {
                return min || angle == 90 ? 1 : 2;
            }
            else if (angle < 270)
            {
                return min || angle == 180 ? 2 : 3;
            }
            else
            {
                return min || angle == 270 ? 3 : 0;
            }
        }



        // ----- CLONE FUNCTIONS -----
        #region Clone Functions

        /// <summary>
        /// Clones a spot into a seperate object.
        /// </summary>
        /// <param name="spot">Spot to clone</param>
        /// <returns>Seperate object with the same contents</returns>
        public static Spot CloneSpot(Spot spot)
        {
            return new Spot(spot.X, spot.Y, spot.XRight, spot.YDown, spot.Connector, spot.Solid, spot.DrawnLevel);
        }

        /// <summary>
        /// Clones a list into a seperate object.
        /// </summary>
        /// <typeparam name="T">Type of list</typeparam>
        /// <param name="list">List to clone</param>
        /// <returns>Seperate object with the same contents</returns>
        public static List<Spot> CloneSpotList(List<Spot> list)
        {
            var clone = new List<Spot>();
            foreach (var spot in list)
            {
                clone.Add(CloneSpot(spot));
            }
            return clone;
        }

        /// <summary>
        /// Copies the details from a state into a separate object.
        /// </summary>
        /// <param name="state">The state to clone</param>
        /// <returns>A separate State</returns>
        public static State CloneState(State state)
        {
            return new State(state.X, state.Y, state.R, state.T, state.S, state.SM);
        }

        /// <summary>
        /// Copies the details from a colour state into a separate object.
        /// </summary>
        /// <param name="state">The colour state to clone</param>
        /// <returns>A separate ColourState</returns>
        public static ColourState CloneColourState(ColourState state)
        {
            return new ColourState(state.ColourType, state.FillColour, state.OutlineColour);
        }

        /// <summary>
        /// Copies the details from a piece into a seperate object.
        /// </summary>
        /// <param name="piece">Piece to clone</param>
        /// <returns>New piece object with same details</returns>
        public static Piece ClonePiece(Piece piece)
        {
            var clone = new Piece
            {
                Data = CloneSpotList(piece.Data),
                State = CloneState(piece.State),
                ColourState = CloneColourState(piece.ColourState),
                OutlineWidth = piece.OutlineWidth,
                PieceDetails = piece.PieceDetails
            };
            return clone;
        }

        /// <summary>
        /// Copies the details from a change into a seperate object.
        /// </summary>
        /// <param name="change">Change to clone</param>
        /// <returns>New piece object with same details</returns>
        public static Change CloneChange(Change change)
        {
            return new Change(change.StartTime, change.Action, change.AffectedPiece, change.HowMuch, change.HowLong, change.host);
        }

        #endregion



        // ----- COORDINATE FUNCTIONS -----

        /// <summary>
        /// Finds a percentage of the way between two points.
        /// </summary>
        /// <param name="a">Point a</param>
        /// <param name="b">Point b</param>
        /// <param name="angle">The angle percentage from a to b</param>
        /// <returns></returns>
        public static float FindMiddleSpot(float a, float b, float angle, bool swap = false)
        {
            if (swap)
            {
                var c = a;
                a = b;
                b = c;
            }
            float[] result = new float[2];
            var multiplier = Modulo(angle, 90) / 90;
            return a == b ? a : a + (b - a) * multiplier;
        }

        /// <summary>
        /// Finds the mid-way point between an original and rotated
        /// or turned point based on the current R or S state.
        /// </summary>
        /// <param name="angle">The relevant R or S state value</param>
        /// <param name="initial">The original X or Y value</param>
        /// <param name="angled">The rotated/turned x/y value</param>
        /// <returns></returns>
        public static float RotOrTurnCalculation(float angle, float initial, float angled)
        {
            float lower;
            float upper;
            float bottomAngle;

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

            return lower + (upper - lower) * ((angle - bottomAngle) / 90.0F);
        }

        /// <summary>
        /// Spins and resizes a coordinate based on the provided 
        /// spin and sizemod state.
        /// </summary>
        /// <param name="spinAngle">The spin state</param>
        /// <param name="sizeMod">The size modifier state</param>
        /// <param name="coord">The x and y coord of the spun point</param>
        /// <returns></returns>
        public static float[] SpinAndSizeCoord(float spinAngle, float sizeMod, float[] coord)
        {
            var hypotenuse = Math.Sqrt(Math.Pow(coord[0], 2) + Math.Pow(coord[1], 2)) * sizeMod;

            // Find Angle
            float pointAngle;
            if (coord[0] == 0 && coord[1] == 0)
            {
                return coord;
            }
            else if (coord[0] == 0 && coord[1] < 0)
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
                pointAngle = 180F / (float)Math.PI * (float)Math.Atan(Math.Abs(coord[0] / coord[1]));
            }
            else if (coord[0] > 0 && coord[1] > 0) // Fourth Quadrant
            {
                pointAngle = 90F + 180F / (float)Math.PI * (float)Math.Atan(Math.Abs(coord[1] / coord[0]));
            }
            else if (coord[0] < 0 && coord[1] < 0) // Second Quadrant
            {
                pointAngle = 270F + 180F / (float)Math.PI * (float)Math.Atan(Math.Abs(coord[1] / coord[0]));
            }
            else  // Third Quadrant
            {
                pointAngle = 180F + 180F / (float)Math.PI * (float)Math.Atan(Math.Abs(coord[0] / coord[1]));
            }
            float findAngle = (pointAngle + spinAngle) * (float)Math.PI / 180F % 360F;

            // Find Points
            return new float[] 
            {
                Convert.ToInt32(0 + hypotenuse * Math.Sin(findAngle)),
                coord[1] = Convert.ToInt32(0 - hypotenuse * Math.Cos(findAngle))
            };
        }

        /// <summary>
        /// Sorts the coordinates so they are in clockwise direction.
        /// </summary>
        /// <param name="spots">Spots to sort</param>
        /// <returns>Sorted spots</returns>
        public static List<Spot> SortCoordinates(List<Spot> spots)
        {
            // Make Spots Clockwise
            var minmax = FindMinMax(spots);
            var clockwise = false;
            var maxFound = false;
            var maxIndex = -1;
            var clockwiseIndex = 0;
            while (!clockwise)
            {
                if (maxIndex != clockwiseIndex)
                {
                    var currSpot = spots[clockwiseIndex];
                    // Check If Max
                    if (currSpot.Y == minmax[3] || maxFound)
                    {
                        // Set New Max
                        if (!maxFound)
                        {
                            maxFound = true;
                            maxIndex = clockwiseIndex;
                        }

                        // Check If In Line
                        if (currSpot.X != spots[NextIndex(spots, clockwiseIndex)].X)
                        {
                            // Check If Clockwise
                            var nextSpot = spots[NextIndex(spots, clockwiseIndex)];
                            var prevSpot = spots[NextIndex(spots, clockwiseIndex, false)];
                            if ((currSpot.X * nextSpot.Y + prevSpot.X * currSpot.Y + prevSpot.Y * nextSpot.X) -
                                (prevSpot.Y * currSpot.X + currSpot.Y * nextSpot.X + prevSpot.X * nextSpot.Y) > 0)
                            {
                                ReverseOrder(spots);
                            }                            
                            clockwise = true;
                        }
                    }
                    clockwiseIndex = NextIndex(spots, clockwiseIndex);
                }
                else
                {
                    clockwise = true;
                }
            }

            // Set Initial Spot As Top Left            
            int topLeftIndex = 0;
            bool inARow = false;
            float leftest = float.MaxValue;
            for (int index = 0; index < spots.Count; index++)
            {
                var spot = spots[index];
                if (spot.Y == minmax[3] && (spot.X < leftest || spot.X == leftest && !inARow))
                {
                    leftest = spot.X;
                    topLeftIndex = index;
                    inARow = true;
                }
                else
                {
                    inARow = false;
                }
            }
            // Reorder List
            if (topLeftIndex != 0)
            {
                var clone = CloneSpotList(spots);
                for (int index = 0; index < clone.Count; index++)
                {
                    spots[index] = clone[Modulo(index + topLeftIndex, clone.Count)];
                }
            }

            return spots;
        }

        /// <summary>
        /// Reverses the order of a sequence of spots.
        /// </summary>
        /// <param name="toReorder">Spots to be reordered and saved to this location</param>
        public static void ReverseOrder(List<Spot> toReorder)
        {
            var clone = CloneSpotList(toReorder);
            for (int index = 0; index < clone.Count; index++)
            {
                toReorder[toReorder.Count - 1 - index] = clone[index];
            }
        }

        /// <summary>
        /// Changes the centre of a WIP piece to 0,0
        /// </summary>
        /// <param name="WIP">The piece being built</param>
        public static void CentrePieceOnAxis(Piece WIP)
        {
            var defaultState = new State();
            var centre = FindMid(WIP.GetPoints(defaultState));
            var centreR = FindMid(WIP.GetPoints(new State(defaultState, 1, 90)));
            var centreT = FindMid(WIP.GetPoints(new State(defaultState, 2, 90)));
            foreach (var spot in WIP.Data)
            {
                spot.X -= centre[0];
                spot.Y -= centre[1];
                spot.XRight -= centreR[0];
                spot.YDown -= centreT[1];
            }
        }



        // ----- FORM CONTROL FUNCTIONS -----

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
            {
                result = MessageBox.Show("Do you want to exit without saving? Your work will be lost.", "Exit Confirmation", MessageBoxButtons.OKCancel);
                //HIDDEN DialogResult.OK; // HIDDEN: Add back 
            }

            return result == DialogResult.OK;
        }

        /// <summary>
        /// Removes the extension from a file name.
        /// </summary>
        /// <param name="name">Full file name with extension</param>
        /// <returns>Name only</returns>
        public static string BaseName(string name)
        {
            return Path.GetFileNameWithoutExtension(name);
        }

        /// <summary>
        /// Enables (or disables) several objects at once.
        /// </summary>
        /// <param name="objects">The objects to disable</param>
        /// <param name="enable">Whether the objects should be enabled or disabled</param>
        public static void EnableObjects(List<Control> objects, bool enable = true)
        {
            foreach (var item in objects)
            {
                item.Enabled = enable;
            }
        }

        /// <summary>
        /// Makes visible (or invisible) several objects at once.
        /// </summary>
        /// <param name="objects">The objects to change visability</param>
        /// <param name="enable">Whether the objects should be visible or invisible</param>
        public static void VisibleObjects(List<Control> objects, bool visible = true)
        {
            foreach (var item in objects)
            {
                item.Visible = visible;
            }
        }

        /// <summary>
        /// Creates a new TabPage in the TabControl of the provided home form.
        /// </summary>
        /// <param name="tab">The tab page to add</param>
        /// <param name="owner">The owner of the TabControl</param>
        public static void NewTabPage(TabPageControl tab, string name)
        {
            tab.Owner.AddTabPage(name, tab);
            tab.Resize();
        }

        /// <summary>
        /// Swaps the current panel contents.
        /// </summary>
        /// <param name="panel">Panel to put contents in</param>
        /// <param name="contents">New panel contents</param>
        public static void NewPanelContent(Panel panel, PanelControl contents)
        {
            panel.Controls.Clear();
            panel.Controls.Add(contents);
            panel.Parent.Focus();
            contents.Dock = DockStyle.Fill;
            contents.Resize();
        }

        /// <summary>
        /// Resizes all of the PanelControls of the provided panel.
        /// </summary>
        /// <param name="panel">Forms panel</param>
        public static void ResizePanel(Panel panel)
        {
            foreach (var cntl in panel.Controls)
            {
                if (cntl is PanelControl)
                {
                    (cntl as PanelControl).Resize();
                }
            }
        }


        // ----- CLICK FUNCTIONS -----

        /// <summary>
        /// Finds the piece clicked from the list.
        /// </summary>
        /// <param name="piecesList">The list of pieces that could be clicked</param>
        /// <param name="x">The x coordinate of the click</param>
        /// <param name="y">The y coordinate of the click</param>
        /// <param name="fromTop">Whether search starts from bottom or top of list</param>
        /// <returns>The index of the piece clicked, or negative one if none selected</returns>
        public static Piece FindClickedSelection(List<Piece> piecesList, int x, int y, bool fromTop = true)
        {
            // Searches pieces either from the top or the bottom of the list
            int index;
            int increment = fromTop ? -1 : 1;
            for (index = fromTop ? piecesList.Count - 1 : 0; fromTop ? index >= 0 : index < piecesList.Count; index += increment)
            {
                // Get Piece Shape
                var piece = piecesList[index];
                var outline = piecesList[index].LineBounds();

                // Check if Shape Clicked
                foreach (var range in outline)
                {
                    if (y == range[0] && x >= range[1] && x <= range[2])
                    { 
                        return piecesList[index];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Finds the join clicked from the list.
        /// </summary>
        /// <param name="joinsList">The list of joins that could be clicked</param>
        /// <param name="x">The x coordinate of the click</param>
        /// <param name="y">The y coordinate of the click</param>
        /// <param name="fromTop">Whether search starts from bottom or top of list</param>
        /// <returns>The index of the piece clicked, or negative one if none selected</returns>
        public static Join FindClickedJoin(List<Join> joinsList, int x, int y, bool fromTop = true)
        {
            // Searches joins either from the top or the bottom of the list
            int index;
            int increment = fromTop ? -1 : 1;
            foreach (var range in Consts.ClickPrecisions)
            {
                for (index = fromTop ? joinsList.Count - 1 : 0; fromTop ? index >= 0 :
                    index < joinsList.Count; index += increment)
                {
                    // Check if Join clicked
                    if (Math.Abs(x - joinsList[index].CurrentCentre()[0]) <= range &&
                        Math.Abs(y - joinsList[index].CurrentCentre()[1]) <= range)
                    {
                        return joinsList[index];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Finds the closest coordinate from the list.
        /// Returns -1 if none within 9 pixels of the given position.
        /// </summary>
        /// <param name="toSearch">The list of spots to search</param>
        /// <param name="x">The x coord to be close to</param>
        /// <param name="y">The y coord to be close to</param>
        /// <returns>Index of list that is closest</returns>
        public static int FindClosestIndex(List<Spot> toSearch, int angle, int x, int y, bool allDrawn = false)
        {
            foreach (var range in Consts.ClickPrecisions)
            {
                for (var index = 0; index < toSearch.Count(); index++)
                {
                    var spot = toSearch[index];
                    if ((allDrawn || spot.DrawnLevel == 0) 
                        && x >= spot.GetCoordCombination(angle)[0] - range && x <= spot.GetCoordCombination(angle)[0] + range
                        && y >= spot.GetCoordCombination(angle)[1] - range && y <= spot.GetCoordCombination(angle)[1] + range)
                    {
                        return index;
                    }
                }
            }
            return -1;
        }       
    }
}
