using System;
using System.Collections.Generic;
using System.Drawing;

namespace Optimator
{
    /// <summary>
    /// A class to hold information about each piece.
    /// A piece is an object that cannot be seperated further.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class Piece : Part
    {
        #region Piece Variables
        public override string Name { get; set; }
        public override string Version { get; }
        public List<Spot> Data { get; set; } = new List<Spot>();

        // Piece Details
        public State State { get; set; } = new State();
        public ColourState ColourState { get; set; } = new ColourState();
        public decimal OutlineWidth { get; set; }
        public string PieceDetails { get; set; }                   // Wind resistance and more

        #endregion


        /// <summary>
        /// Assigns starting values to the piece variables. 
        /// Piece values stored in files are accessed.
        /// </summary>
        /// <param Name="inName">The (file) name of the piece</param>
        public Piece(string inName)
        {
            // Get Piece Data
            Name = inName;
            var data = Utils.ReadFile(Utils.GetDirectory(Consts.PiecesFolder, Name, Consts.Optr));

            // Get Version
            Version = data[0].Split(Consts.Semi)[1];
            Utils.CheckValidVersion(Version);

            // Get Points and Colours from File
            var angleData = data[1].Split(Consts.Semi);
            var outlineARGB = angleData[1].Split(Consts.Comma);

            // Colour State
            ColourState = new ColourState
            {
                ColourType = angleData[0],
                OutlineColour = Color.FromArgb(int.Parse(outlineARGB[0]), int.Parse(outlineARGB[1]), int.Parse(outlineARGB[2]), int.Parse(outlineARGB[3]))
            };

            // Fill Colour Array
            var colours = angleData[2].Split(Consts.Colon);
            ColourState.FillColour = new Color[colours.Length];
            for (int index = 0; index < colours.Length; index++)
            {
                var argbValues = colours[index].Split(Consts.Comma);
                ColourState.FillColour[index] = Color.FromArgb(int.Parse(argbValues[0]), int.Parse(argbValues[1]), int.Parse(argbValues[2]), int.Parse(argbValues[3]));
            }

            // Outline Width
            OutlineWidth = int.Parse(angleData[3]);

            // Piece Details
            PieceDetails = angleData[4];

            // Spots
            for (int index = 2; index < data.Count; index++)
            {
                var spotData = data[index].Split(Consts.Semi);
                var coords = Utils.ConvertStringArrayToDoubles(spotData[0].Split(Consts.Colon));

                Data.Add(new Spot(coords[0], coords[1], coords[2], coords[3], spotData[1], spotData[2]));
            }
        }

        /// <summary>
        /// Piece constructor used when developing a
        /// piece for the first time.
        /// </summary>
        public Piece()
        {
            Name = "";
            Version = Consts.Version;
            ColourState = new ColourState();
            OutlineWidth = Consts.defaultOutlineWidth;
            PieceDetails = Consts.defaultPieceDetails;
        }



        // ----- PART FUNCTIONS -----

        /// <summary>
        /// Gets piece's current details in a string format.
        /// </summary>
        public override List<string> GetData()
        {
            // Type and Version
            var newData = new List<string>
            {
                Consts.Piece + Consts.SemiS + Version,
                ColourState.GetData() + Consts.SemiS + OutlineWidth + Consts.SemiS + PieceDetails
            };

            // Add Spots
            foreach (var spot in Data)
            {
                if (spot.DrawnLevel == 0)
                {
                    newData.Add(spot.ToString());
                }
            }
            return newData;
        }

        /// <summary>
        /// Converts into itself to accommodate sets
        /// in part.
        /// </summary>
        /// <returns>Itself</returns>
        public override Piece ToPiece()
        {
            return this;
        }

        /// <summary>
        /// Draws the piece to the provided graphics in
        /// the specified state and colour.
        /// </summary>
        /// <param name="g">Supplied graphics</param>
        /// <param name="state">Pieces position</param>
        /// <param name="colours">Pieces colours</param>
        public override void Draw(Graphics g, State state = null, ColourState colours = null)
        {
            state = state ?? State;
            if (colours == null)
            {
                Visuals.DrawPiece(this, g, state);
            }
            else
            {
                Visuals.DrawPiece(this, g, state, colours);
            }
        }



        // ----- SHAPE FUNCTIONS -----
        #region Shape Functions

        /// <summary>
        /// Finds the points to print based on the rotation, turn, spin and size of the piece
        /// </summary>
        /// <returns></returns>
        public List<double[]> GetPoints(State state)
        {
            var points = new List<double[]>();
            var minMax = Utils.FindMinMax(Utils.ConvertSpotsToCoords(Data, 0));

            // Get Points
            CalculateMatches(minMax);
            foreach (var spot in Data)
            {
                spot.CurrentX = spot.CalculateCurrentValue(state.GetAngles()[0]);
            }
            CalculateMatches(minMax, 0);
            foreach (var spot in Data)
            {
                points.Add(new double[] { spot.CurrentX, spot.CalculateCurrentValue(state.GetAngles()[1], 0) });
            }

            // Recentre
            for (int index = 0; index < points.Count; index++)
            {
                points[index][0] = state.GetCoords()[0] + points[index][0];
                points[index][1] = state.GetCoords()[1] + points[index][1];
            }

            // Spin and Size Adjustment
            points = SpinMeRound(points, state);

            return points;
        }

        /// <summary>
        /// Spins the coords provided and modifies their size.
        /// </summary>
        /// <param name="pointsArray">The points to be spun</param>
        /// <returns></returns>
        private List<double[]> SpinMeRound(List<double[]> pointsArray, State state)
        {
            for (int index = 0; index < pointsArray.Count; index++)
            {
                if (!(pointsArray[index][0] == state.GetCoords()[0] && pointsArray[index][1] == state.GetCoords()[1]))
                {
                    double hypotenuse = Math.Sqrt(Math.Pow(state.GetCoords()[0] - pointsArray[index][0], 2) + Math.Pow(state.GetCoords()[1] - pointsArray[index][1], 2)) * state.SM;
                    // Find Angle
                    double pointAngle;
                    if (pointsArray[index][0] == state.GetCoords()[0] && pointsArray[index][1] < state.GetCoords()[1])
                    {
                        pointAngle = 0;
                    }
                    else if (pointsArray[index][0] == state.GetCoords()[0] && pointsArray[index][1] > state.GetCoords()[1])
                    {
                        pointAngle = 180;
                    }
                    else if (pointsArray[index][0] > state.GetCoords()[0] && pointsArray[index][1] == state.GetCoords()[1])
                    {
                        pointAngle = 90;
                    }
                    else if (pointsArray[index][0] < state.GetCoords()[0] && pointsArray[index][1] == state.GetCoords()[1])
                    {
                        pointAngle = 270;
                    }
                    //  Second || First
                    //  Third  || Fourth
                    else if (pointsArray[index][0] > state.GetCoords()[0] && pointsArray[index][1] < state.GetCoords()[1]) // First Quadrant
                    {
                        pointAngle = (180 / Math.PI) * Math.Atan(Math.Abs((state.GetCoords()[0] - pointsArray[index][0]) / (state.GetCoords()[1] - pointsArray[index][1])));
                    }
                    else if (pointsArray[index][0] > state.GetCoords()[0] && pointsArray[index][1] > state.GetCoords()[1]) // Fourth Quadrant
                    {
                        pointAngle = 90 + (180 / Math.PI) * Math.Atan(Math.Abs((state.GetCoords()[1] - pointsArray[index][1]) / (state.GetCoords()[0] - pointsArray[index][0])));
                    }
                    else if (pointsArray[index][0] < state.GetCoords()[0] && pointsArray[index][1] < state.GetCoords()[1]) // Second Quadrant
                    {
                        pointAngle = 270 + (180 / Math.PI) * Math.Atan(Math.Abs((state.GetCoords()[1] - pointsArray[index][1]) / (state.GetCoords()[0] - pointsArray[index][0])));
                    }
                    else  // Third Quadrant
                    {
                        pointAngle = 180 + (180 / Math.PI) * Math.Atan(Math.Abs((state.GetCoords()[0] - pointsArray[index][0]) / (state.GetCoords()[1] - pointsArray[index][1])));
                    }
                    double findAngle = (pointAngle + state.GetAngles()[2]) * Math.PI / 180 % 360;

                    // Find Points
                    pointsArray[index][0] = Convert.ToInt32(state.GetCoords()[0] + hypotenuse * Math.Sin(findAngle));
                    pointsArray[index][1] = Convert.ToInt32(state.GetCoords()[1] - hypotenuse * Math.Cos(findAngle));
                }
            }
            return pointsArray;
        }

        /// <summary>
        /// Calculates where the spots with the same Y coordinate as drawnlevel 0
        /// spots would go and adds them to Data.
        /// </summary>
        /// <param name="xy">Whether searching for an X match (0) or Y match (1)</param>
        private void CalculateMatches(double[] minMax, int xy = 1)
        {
            // Setup
            CleanseData(xy == 0 ? false : true);
            if (Data.Count < 3)
            {
                return;
            }
            var drawn = xy == 0 ? 2 : 1;
            var coordCombo = xy == 0 ? 3 : 0;
            var coordRot = xy == 0 ? 3 : 1;
            var increase = xy == 0 ? 2 : 0;

            for (int index = 0; index < Data.Count; index++)
            {
                // Setup
                var spot = Data[index];
                var validDrawn = xy == 0 ? spot.DrawnLevel < 2 : spot.DrawnLevel == 0;

                // Only search for match if needed
                if (validDrawn && spot.GetMatch(xy) == null)
                {
                    // If spot has existing match
                    var symmIndex = FindExistingSymmetricalCoord(index, xy);
                    if (symmIndex != -1)
                    {
                        Data[symmIndex].SetMatch(xy, spot);
                        spot.SetMatch(xy, Data[symmIndex]);
                    }
                    // If spot has no existing match
                    else
                    {
                        // Only search for match if needed (not max)
                        if (spot.GetCoordCombination()[xy] != minMax[3 - increase] && spot.GetCoordCombination()[xy] != minMax[2 - increase])
                        {
                            var insertIndex = FindSymmetricalCoordHome(index, xy, coordCombo);
                            if (insertIndex != -1)
                            {
                                double[] original = FindSymmetricalOppositeCoord(Data[insertIndex].GetCoordCombination(coordCombo),
                                    Data[Utils.Modulo(insertIndex - 1, Data.Count)].GetCoordCombination(coordCombo),
                                    spot.GetCoordCombination(coordCombo)[xy], xy, Data[insertIndex].Connector);

                                double rotated = FindSymmetricalOppositeCoord(Data[insertIndex].GetCoordCombination(coordRot),
                                    Data[Utils.Modulo(insertIndex - 1, Data.Count)].GetCoordCombination(coordRot),
                                    original[1], 1, Data[insertIndex].Connector)[0];

                                double turned = FindSymmetricalOppositeCoord(Data[insertIndex].GetCoordCombination(2 + increase),
                                    Data[Utils.Modulo(insertIndex - 1, Data.Count)].GetCoordCombination(2 + increase),
                                    original[0], 0, Data[insertIndex].Connector)[1];

                                var basedIndex = Utils.NextIndex(Data, insertIndex, false);
                                var newSpot = new Spot(original[0], original[1], rotated, turned, Data[basedIndex].Connector, Data[basedIndex].Solid, drawn);
                                newSpot.SetMatch(xy, spot);
                                spot.SetMatch(xy, newSpot);
                                if (drawn == 2)
                                {
                                    newSpot.CurrentX = newSpot.X;
                                }
                                Data.Insert(insertIndex, newSpot);
                                index--;
                            }
                        }
                    }
                }
            }
        }
                
        /// <summary>
        /// Finds the index of the coordinate that has the same x or y value
        /// as the selected coordinate.
        /// </summary>
        /// <param name="matchIndex">The index of the selected coordinate</param>
        /// <param name="xy">Whether searching for a match in x (0) or y (1)</param>
        /// <returns>The symmetrical point's index or -1 if none exists</returns>
        private int FindExistingSymmetricalCoord(int matchIndex, int xy)
        {
            // Find Matches
            var matches = new List<int>();
            for (int index = 0; index < Data.Count; index++)
            {
                if (index != matchIndex && Data[index].GetCoordCombination()[xy] == Data[matchIndex].GetCoordCombination()[xy])
                {
                    matches.Add(index);
                }
            }

            // Decide which match is best
            if (matches.Count == 0)
            {
                return -1;
            }
            else if (matches.Count == 1)
            {
                return matches[0];
            }
            else
            {
                var yx = xy == 0 ? 1 : 0;
                var min = 0;
                var max = 0;
                for (int index = 1; index < matches.Count; index++)
                {
                    if (Data[matches[index]].GetCoordCombination()[yx] < Data[matches[min]].GetCoordCombination()[yx])
                    {
                        min = index;
                    }
                    else if (Data[matches[index]].GetCoordCombination()[yx] > Data[matches[max]].GetCoordCombination()[yx])
                    {
                        max = index;
                    }
                }
                if (Data[matchIndex].GetCoordCombination()[yx] <= Data[matches[min]].GetCoordCombination()[yx])
                {
                    return max;
                }
                else if (Data[matchIndex].GetCoordCombination()[yx] >= Data[matches[max]].GetCoordCombination()[yx])
                {
                    return min;
                }
                return matches[0];
            }
        }

        /// <summary>
        /// Finds where a matching point would go if it existed.
        /// </summary>
        /// <param name="matchIndex">The index of the selected coordinate</param>
        /// <param name="xy">Whether searching for a match in x (0) or y (1)</param>
        /// <returns>The index where the matching point would go or -1 in error</returns>
        public int FindSymmetricalCoordHome(int matchIndex, int xy, int angle)
        {
            double goal = Data[matchIndex].GetCoordCombination(angle)[xy];
            var bigger = false;
            int searchIndex = -1;

            // Find whether we're searching above or below the goal
            for (int index = 0; index < Data.Count && searchIndex == -1; index++)
            {
                if (Data[index].GetCoordCombination(angle)[xy] != goal)
                {
                    bigger = (Data[index].GetCoordCombination(angle)[xy] > goal);
                    searchIndex = (index + 1) % Data.Count;
                }
            }

            // Find index position
            for (int index = 0; index < Data.Count; index++)
            {
                if (Data[searchIndex].GetCoordCombination(angle)[xy] == goal)
                {
                    bigger = !bigger;
                }
                else if (Data[searchIndex].GetCoordCombination(angle)[xy] > goal != bigger)
                {
                    return searchIndex;
                }

                searchIndex = (searchIndex + 1) % Data.Count;
            }
            return -1;       // Error
        }

        /// <summary>
        /// Finds the coordinate that would be across from the selected coordinate.
        /// </summary>
        /// <param name="from">Coord before pending</param>
        /// <param name="to">Coord after pending</param>
        /// <param name="value">Selected value to match</param>
        /// <param name="xy">Whether the x (0) or y (1) should be matched</param>
        /// <param name="line">The join between the lines</param>
        /// <returns></returns>
        public double[] FindSymmetricalOppositeCoord(double[] from, double[] to, double value, int xy, string line)
        {
            double gradient = -1;
            if (line == Consts.connectorOptions[0] || line == Consts.connectorOptions[1])
            {
                if (from[0] == to[0])
                {
                    if (xy == 0)
                    {
                        return new double[] { value, to[1] };
                    }
                    else
                    {
                        return new double[] { from[0], value };
                    }
                }

                gradient = (from[1] - to[1]) / (from[0] - to[0]);
                if (xy == 0)
                {
                    return new double[] { value, from[1] + (value - from[0]) * gradient };  // y = x * gradient
                }
                else
                {
                    return new double[] { from[0] + (value - from[1]) / gradient, value };  // x = y / gradient
                }
            }
            // else if (line == Constants.connectorOptions[2])      
            //CURVE

            return new double[] { -1 }; // Error
        }

        /// <summary>
        /// Finds all of the coordinates between two points.
        /// Uses a Y-across system.
        /// </summary>
        /// <param name="from">The starting point</param>
        /// <param name="to">The end point</param>
        /// <param name="join">How the two points are connected</param>
        /// <returns>A list of double[ x, (int)y ] with the point coords</returns>
        private List<double[]> LineCoords(double[] from, double[] to, string join)
        {
            var line = new List<double[]> { new double[] { from[0], from[1] } };
            var fromUpper = from[1] >= to[1];
            double[] lower = fromUpper ? to : from;
            double[] upper = fromUpper ? from : to;

            // Solid Line
            if (join == Consts.connectorOptions[0] || join == Consts.connectorOptions[1])
            {
                var section = new List<double[]>();

                // If straight vertical line
                if (from[0] - to[0] == 0)
                {
                    for (int index = (int)lower[1] + 1; index < upper[1]; index++)
                    {
                        section.Add(new double[] { from[0], index });
                    }
                }

                // If diagonal line
                else if (from[1] - to[1] != 0)
                {
                    var gradient = (lower[1] - upper[1]) / (lower[0] - upper[0]);
                    for (int index = (int)lower[1] + 1; index < upper[1]; index++)
                    {
                        section.Add(new double[] { lower[0] + ((index - lower[1]) / gradient), index });
                    }
                }

                // Add section to line, reversing if calculated as to --> from
                if (fromUpper)
                {
                    section.Reverse();
                }
                line.AddRange(section);
            }
            // Curve
            else if (join == Consts.connectorOptions[2])
            {
            }
            return line;
        }

        /// <summary>
        /// Finds all of the coordinates in the outline of the piece.
        /// Uses a Y-across system.
        /// </summary>
        /// <returns>A list of double [ x, (int)y ] with the shape outline</returns>
        private List<double[]> LinesCoords()
        {
            var linesCoords = new List<double[]>();
            var data = GetPoints(State);
            for (int index = 0; index < data.Count; index++)
            {
                linesCoords.AddRange(LineCoords(data[index],
                    data[Utils.Modulo(index + 1, data.Count)], Data[index].Connector));
            }
            return linesCoords;
        }

        /// <summary>
        /// Finds the ranges where the piece has space.
        /// </summary>
        /// <returns>double[ y, x min, x max]</returns>
        public List<double[]> LineBounds()
        {
            // Turn coords into bound ranges
            var outlineShape = LinesCoords();
            var minMax = Utils.FindMinMax(outlineShape);
            var ranges = new List<double[]>();
            for (int index = (int)minMax[2]; index <= (int)minMax[3]; index++)
            {
                // Get coords for the specific Y value that aren't corners
                var yMatches = new List<double[]>();
                for (int coordIndex = 0; coordIndex < outlineShape.Count; coordIndex++)
                    if (outlineShape[coordIndex][1] == index &&
                        !((outlineShape[Utils.Modulo(coordIndex + 1, outlineShape.Count)][1] > outlineShape[coordIndex][1] &&
                            outlineShape[Utils.Modulo(coordIndex - 1, outlineShape.Count)][1] > outlineShape[coordIndex][1]) ||
                            (outlineShape[Utils.Modulo(coordIndex + 1, outlineShape.Count)][1] < outlineShape[coordIndex][1] &&
                            outlineShape[Utils.Modulo(coordIndex - 1, outlineShape.Count)][1] < outlineShape[coordIndex][1])))
                    {
                        yMatches.Add(outlineShape[coordIndex]);
                    }

                // Pair Remaining Coords into Bounds
                while (yMatches.Count > 1)
                {
                    double min1 = 999999;
                    double min2 = 999999;
                    int min1Index = -1;
                    int min2Index = -1;
                    for (int match = 0; match < yMatches.Count; match++)
                    {
                        if (yMatches[match][0] < min1)
                        {
                            min2 = min1;
                            min2Index = min1Index;
                            min1 = yMatches[match][0];
                            min1Index = match;
                        }
                        else if (yMatches[match][0] < min2)
                        {
                            min2 = yMatches[match][0];
                            min2Index = match;
                        }
                    }
                    ranges.Add(new double[3] { index, min1, min2 });
                    yMatches.RemoveAt(min1Index);
                    yMatches.RemoveAt(min2Index > min1Index ? min2Index - 1 : min2Index);
                }
            }
            return ranges;
        }

        #endregion



        // ----- OTHER FUNCTIONS -----

        /// <summary>
        /// Remove coords from Data.
        /// </summary>
        /// <param name="xMatch">If the drawn level 1 spots should be removed too</param>
        public void CleanseData(bool xMatch = false)
        {
            for (int index = 0; index < Data.Count; index++)
            {
                var eraseCheck = xMatch ? Data[index].DrawnLevel > 0 : Data[index].DrawnLevel == 2;
                if (eraseCheck)
                {
                    if (Data[index].MatchX != null)
                    {
                        Data[index].MatchX.MatchX = null;
                    }
                    if (xMatch && Data[index].MatchY != null)
                    {
                        Data[index].MatchY.MatchY = null;
                    }
                    Data.RemoveAt(index);
                    index--;
                }
            }
        }
    }
}
