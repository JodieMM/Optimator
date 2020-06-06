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
            var data = Utils.ReadFile(Utils.GetDirectory(Name, Consts.PieceExt));

            // Get Version
            Version = data[0].Split(Consts.Semi)[1];
            Utils.CheckValidVersion(Version);

            // Get Points and Colours from File
            var angleData = data[1].Split(Consts.Semi);

            // Colour State
            ColourState = new ColourState
            {
                ColourType = angleData[0],
                OutlineColour = Utils.ColourFromString(angleData[1])
            };

            // Fill Colour Array
            var colours = angleData[2].Split(Consts.Colon);
            ColourState.FillColour = new Color[colours.Length];
            for (var index = 0; index < colours.Length; index++)
            {
                ColourState.FillColour[index] = Utils.ColourFromString(colours[index]);
            }

            // Outline Width
            OutlineWidth = int.Parse(angleData[3]);

            // Piece Details
            PieceDetails = angleData[4];

            // Spots
            for (var index = 2; index < data.Count; index++)
            {
                var spotData = data[index].Split(Consts.Semi);
                var coords = Utils.ConvertStringArrayToFloats(spotData[0].Split(Consts.Colon));

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
        public List<Spot> GetPoints(State state)
        {
            if (Data.Count < 1)
            {
                return new List<Spot>();
            }

            // CLEANING
            // Get Points
            var basePoints = GetAnchorStatePoints(state, 0);
            var rightPoints = GetAnchorStatePoints(state, 1);
            var downPoints = GetAnchorStatePoints(state, 2);

            // Find Middle Ground
            var r = Utils.AngleAnchorFromAngle(state.R);
            if (state.SBase && (r == 0 || r == 2) || !state.SBase && (r == 1 || r == 3))
            {
                rightPoints = ResizeToMatch(basePoints, rightPoints);
                downPoints = ResizeToMatch(basePoints, downPoints, false);
            }
            else
            {
                basePoints = ResizeToMatch(rightPoints, basePoints);
                basePoints = ResizeToMatch(downPoints, basePoints, false);
            }
            
            var merge1 = MergeShapes(basePoints, rightPoints, state.R);
            var points = MergeShapes(merge1, downPoints, state.T, false);

            // Recentre & Resize
            for (var index = 0; index < points.Count; index++)
            {
                points[index].X = points[index].X * state.SM + state.X;
                points[index].Y = points[index].Y * state.SM + state.Y;
            }

            return points;
        }

        private List<Spot> GetAnchorStatePoints(State state, int brd)
        {
            // CLEANING
            // brd 0 = base 1 = right (max r min t) 2 = down (min r max t)
            var points = new List<Spot>();
            var minR = brd != 1;
            var minT = brd != 2;
            int r, t, s = new int();

            //r = Utils.AngleAnchorFromAngle(state.R, minR);
            //if (state.SBase && (r == 0 || r == 2))
            //{
            //    r += Utils.AngleAnchorFromAngle(state.T, minR); //TODO: minR? minT?
            //}

            r = Utils.AngleAnchorFromAngle(state.R, minR);
            t = Utils.AngleAnchorFromAngle(state.T, minT);
            //s = r;

            //if (state.SBase && (r == 0 || r == 2) || !state.SBase && (r == 1 || r == 3))
            //{
            //    r = Utils.Modulo(r + t, 4);
            //}

            // TO CONSIDER:
            // turn is increased if rotation is spun

            //if (!state.SBase)
            //{
            //    s = Utils.Modulo(s + 1, 4); 
            //}

            foreach (var spot in Data)
            {
                var point = spot.GetCoordAtAnchorAngle(r, t);
                //if (state.S != 0)
                //{
                //    // Flipped Shape
                //    if (state.S > 90 && state.S < 270)
                //    {
                //        if (state.SBase)
                //    }
                //}
                //if (state.S != 0 && )
                //{
                //    point = Utils.SpinAndSizeCoord(s, 1, point);
                //}
                points.Add(point);
            }
            // TODO: Get spin state accurately

            //points = SpinMeRound(points, state);

            //CalculateMatches(minMax);
            //foreach (var spot in Data)
            //{
            //    spot.CurrentX = spot.CalculateCurrentValue(state.R);
            //}
            //CalculateMatches(minMax, 0);
            //foreach (var spot in Data)
            //{
            //    spot.CurrentY = spot.CalculateCurrentValue(state.T, 0);    //HIDDEN (RTS) CurrentY
            //    points.Add(new float[] { spot.CurrentX, spot.CalculateCurrentValue(state.T, 0) });
            //}

            //points = SpinMeRound(points, state);
            return Utils.SortCoordinates(points);
        }

        private List<Spot> ResizeToMatch(List<Spot> constantPoints, List<Spot> changePoints, bool xChange = true)
        {
            //CLEANING
            var goalSize = Utils.FindMinMax(constantPoints);
            var currSize = Utils.FindMinMax(changePoints);
            var multiplier = currSize[xChange ? 1 : 3] != 0 ? goalSize[xChange ? 1 : 3] / currSize[xChange ? 1 : 3] : 1;
            foreach (var point in changePoints)
            {
                if (xChange)
                {
                    point.X *= multiplier;
                }
                else
                {
                    point.Y *= multiplier;
                }
            }
            return changePoints;
        }

        private List<Spot> MergeShapes(List<Spot> s1, List<Spot> s2, float angle, bool xChange = true)
        {
            // CLEANING
            // TODO
            // NOTE: ** xMatch = false means the y coords [1] are being matched
            // Ensure All Spots Have Match
            // Find Mid Point Between Spots
            var index1 = 0;
            var index2 = 0;
            var shape1 = s1;
            var shape2 = s2;
            var isSwapped = false;
            var i1 = 0;
            var i2 = 0;
            var reachedBottom1 = false;
            var reachedBottom2 = false;
            var z = xChange ? 1 : 0;
            var altz = xChange ? 0 : 1;
            List<Spot> merged = new List<Spot>();

            while (i1 < s1.Count || i2 < s2.Count)
            {
                // Check if reached the bottom
                if (!reachedBottom1 && i1 != 0 && i1 < s1.Count && s1[i1].Y > s1[i1 - 1].Y)
                {
                    reachedBottom1 = true;
                }
                if (!reachedBottom2 && i2 != 0 && i2 < s2.Count && s2[i2].Y > s2[i2 - 1].Y)
                {
                    reachedBottom2 = true;
                }
                // Find dominant shape
                if (i2 < s2.Count && (reachedBottom1 && !reachedBottom2 || i1 >= s1.Count || !reachedBottom1 && !reachedBottom2 && s1[i1].Y < s2[i2].Y
                    || reachedBottom1 && reachedBottom2 & s1[i1].Y > s2[i2].Y))
                {
                    shape1 = s2;
                    shape2 = s1;
                    index1 = i2;
                    index2 = i1;
                    isSwapped = true;
                }
                else
                {
                    shape1 = s1;
                    shape2 = s2;
                    index1 = i1;
                    index2 = i2;
                    isSwapped = false;
                }

                //CLEANING: Remove some of the repetition
                // Check for neighbouring spots
                if (index1 < shape1.Count - 1 && shape1[index1].GetCoord(z) == shape1[index1 + 1].GetCoord(z))
                {
                    // If the neighbours have a pre-made matching spot
                    if (index2 < shape2.Count && shape2[index2].GetCoord(z) == shape1[index1].GetCoord(z))
                    {
                        // If the matching spots also have a neighbour
                        if (index2 < shape2.Count - 1 && shape2[index2 + 1].GetCoord(z) == shape2[index2].GetCoord(z))
                        {
                            float unchanged = shape1[index1].GetCoord(z);
                            float changed = Utils.FindMiddleSpot(shape1[index1].GetCoord(altz), shape2[index2].GetCoord(altz), angle);
                            var newSpot = new Spot(xChange ? changed : unchanged, xChange ? unchanged : changed);
                            merged.Add(newSpot);
                            changed = Utils.FindMiddleSpot(shape1[index1 + 1].GetCoord(altz), shape2[index2 + 1].GetCoord(altz), angle);
                            if (xChange)
                            {
                                newSpot.X = changed;
                            }
                            else
                            {
                                newSpot.Y = changed;
                            }
                            merged.Add(newSpot);
                            // CLEANING
                            //if (xMatch)
                            //{
                            //    merged.Add(new float[2] { Utils.FindMiddleSpot(shape1[index1][0], shape2[index2][0], angle), shape1[index1][1] });
                            //    merged.Add(new float[2] { Utils.FindMiddleSpot(shape1[index1 + 1][0], shape2[index2 + 1][0], angle), shape1[index1][1] });
                            //}
                            //else
                            //{
                            //    merged.Add(new float[2] { shape1[index1][0], Utils.FindMiddleSpot(shape1[index1][1], shape2[index2][1], angle) });
                            //    merged.Add(new float[2] { shape1[index1][0], Utils.FindMiddleSpot(shape1[index1 + 1][1], shape2[index2 + 1][1], angle) });
                            //}
                            i1 += 2;
                            i2 += 2;
                        }
                        else
                        {
                            float unchanged = shape1[index1].GetCoord(z);
                            float changed = Utils.FindMiddleSpot(shape1[index1].GetCoord(altz), shape2[index2].GetCoord(altz), angle);
                            Spot newSpot = new Spot(xChange ? changed : unchanged, xChange ? unchanged : changed);
                            merged.Add(newSpot);
                            changed = Utils.FindMiddleSpot(shape1[index1 + 1].GetCoord(altz), shape2[index2].GetCoord(altz), angle);
                            if (xChange)
                            {
                                newSpot.X = changed;
                            }
                            else
                            {
                                newSpot.Y = changed;
                            }
                            merged.Add(newSpot);
                            i1 += isSwapped ? 1 : 2;
                            i2 += isSwapped ? 2 : 1;
                        }
                    }
                    // If the neighbours need a spot to be made for them
                    else
                    {
                        var newShape2 = FindSymmetricalOppositeCoord(shape2[Utils.Modulo(Utils.NextIndex(shape2, index2, false), shape2.Count)], 
                            shape2[Utils.Modulo(index2, shape2.Count)], shape1[index1].GetCoord(z), z);

                        float unchanged = shape1[index1].GetCoord(z);
                        float changed = Utils.FindMiddleSpot(shape1[index1].GetCoord(altz), newShape2[altz], angle);
                        Spot newSpot = new Spot(xChange ? changed : unchanged, xChange ? unchanged : changed);
                        merged.Add(newSpot);
                        changed = Utils.FindMiddleSpot(shape1[index1 + 1].GetCoord(altz), newShape2[altz], angle);
                        if (xChange)
                        {
                            newSpot.X = changed;
                        }
                        else
                        {
                            newSpot.Y = changed;
                        }
                        merged.Add(newSpot);
                        i1 += isSwapped ? 0 : 2;
                        i2 += isSwapped ? 2 : 0;
                    }
                }
                // Single spot, not in a line
                else
                {
                    // Has match
                    if (index2 < shape2.Count && shape2[index2].GetCoord(z) == shape1[index1].GetCoord(z))
                    {
                        // Match has neighbours
                        if (index2 < shape2.Count - 1 && shape2[index2 + 1].GetCoord(z) == shape2[index2].GetCoord(z))
                        {
                            float unchanged = shape1[index1].GetCoord(z);
                            float changed = Utils.FindMiddleSpot(shape1[index1].GetCoord(altz), shape2[index2].GetCoord(altz), angle);
                            Spot newSpot = new Spot(xChange ? changed : unchanged, xChange ? unchanged : changed);
                            merged.Add(newSpot);
                            changed = Utils.FindMiddleSpot(shape1[index1].GetCoord(altz), shape2[index2 + 1].GetCoord(altz), angle);
                            if (xChange)
                            {
                                newSpot.X = changed;
                            }
                            else
                            {
                                newSpot.Y = changed;
                            }
                            merged.Add(newSpot);
                            i1 += isSwapped ? 2 : 1;
                            i2 += isSwapped ? 1 : 2;
                        }
                        else
                        {
                            float unchanged = shape1[index1].GetCoord(z);
                            float changed = Utils.FindMiddleSpot(shape1[index1].GetCoord(altz), shape2[index2].GetCoord(altz), angle);
                            Spot newSpot = new Spot(xChange ? changed : unchanged, xChange ? unchanged : changed);
                            merged.Add(newSpot);
                            i1++;
                            i2++;
                        }
                    }
                    // Need to build match
                    else
                    {
                        var newShape2 = FindSymmetricalOppositeCoord(shape2[Utils.Modulo(Utils.NextIndex(shape2, index2, false), shape2.Count)], 
                            shape2[Utils.Modulo(index2, shape2.Count)], shape1[index1].GetCoord(z), z);

                        float unchanged = shape1[index1].GetCoord(z);
                        float changed = Utils.FindMiddleSpot(shape1[index1].GetCoord(altz), newShape2[altz], angle);
                        Spot newSpot = new Spot(xChange ? changed : unchanged, xChange ? unchanged : changed);
                        merged.Add(newSpot);
                        i1 += isSwapped ? 0 : 1;
                        i2 += isSwapped ? 1 : 0;
                    }
                }
            }
            return merged;
        }

        /// <summary>
        /// Spins the coords provided.
        /// </summary>
        /// <param name="pointsArray">The points to be spun</param>
        /// <returns>A list of float[] containing shape's new coordinates</returns>
        private List<float[]> SpinMeRound(List<float[]> pointsArray, State state)
        {
            for (var index = 0; index < pointsArray.Count; index++)
            {
                if (!(pointsArray[index][0] == state.GetCoords()[0] && pointsArray[index][1] == state.GetCoords()[1]))
                {
                    var hypotenuse = Math.Sqrt(Math.Pow(state.GetCoords()[0] - pointsArray[index][0], 2) + Math.Pow(state.GetCoords()[1] - pointsArray[index][1], 2));
                    // Find Angle
                    float pointAngle;
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
                        pointAngle = (180 / (float)Math.PI) * (float)Math.Atan(Math.Abs((state.GetCoords()[0] - pointsArray[index][0]) / (state.GetCoords()[1] - pointsArray[index][1])));
                    }
                    else if (pointsArray[index][0] > state.GetCoords()[0] && pointsArray[index][1] > state.GetCoords()[1]) // Fourth Quadrant
                    {
                        pointAngle = 90 + (180 / (float)Math.PI) * (float)Math.Atan(Math.Abs((state.GetCoords()[1] - pointsArray[index][1]) / (state.GetCoords()[0] - pointsArray[index][0])));
                    }
                    else if (pointsArray[index][0] < state.GetCoords()[0] && pointsArray[index][1] < state.GetCoords()[1]) // Second Quadrant
                    {
                        pointAngle = 270 + (180 / (float)Math.PI) * (float)Math.Atan(Math.Abs((state.GetCoords()[1] - pointsArray[index][1]) / (state.GetCoords()[0] - pointsArray[index][0])));
                    }
                    else  // Third Quadrant
                    {
                        pointAngle = 180 + (180 / (float)Math.PI) * (float)Math.Atan(Math.Abs((state.GetCoords()[0] - pointsArray[index][0]) / (state.GetCoords()[1] - pointsArray[index][1])));
                    }
                    var findAngle = (pointAngle + state.GetAngles()[2]) * (float)Math.PI / 180 % 360;

                    // Find Points
                    pointsArray[index][0] = Convert.ToInt32(state.GetCoords()[0] + hypotenuse * Math.Sin(findAngle));
                    pointsArray[index][1] = Convert.ToInt32(state.GetCoords()[1] - hypotenuse * Math.Cos(findAngle));
                }
            }
            return pointsArray;
        }

        ///// <summary>
        ///// Calculates where the spots with the same Y coordinate as drawnlevel 0
        ///// spots would go and adds them to Data.
        ///// </summary>
        ///// <param name="xy">Whether searching for an X match (0) or Y match (1)</param>
        //private void CalculateMatches(float[] minMax, int xy = 1)
        //{
        //    // Setup
        //    CleanseData(xy == 0 ? false : true);
        //    if (Data.Count < 3)
        //    {
        //        return;
        //    }
        //    var drawn = xy == 0 ? 2 : 1;
        //    var coordCombo = xy == 0 ? 3 : 0;
        //    var coordRot = xy == 0 ? 3 : 1;
        //    var coordTurn = xy == 0 ? 4 : 2;
        //    //var increase = xy == 0 ? 2 : 0;

        //    for (int index = 0; index < Data.Count; index++)
        //    {
        //        // Setup
        //        var spot = Data[index];
        //        var validDrawn = xy == 0 ? spot.DrawnLevel < 2 : spot.DrawnLevel == 0;

        //        // Only search for match if needed
        //        if (validDrawn && spot.GetMatch(xy) == null)
        //        {
        //            // If spot has existing match
        //            var symmIndex = FindExistingSymmetricalCoord(index, xy);
        //            if (symmIndex != -1)
        //            {
        //                Data[symmIndex].SetMatch(xy, spot);
        //                spot.SetMatch(xy, Data[symmIndex]);
        //            }
        //            // If spot has no existing match
        //            else
        //            {
        //                var insertIndex = FindSymmetricalCoordHome(index, xy);
        //                if (insertIndex != -1 && !(xy == 1 && (insertIndex == index || insertIndex == (index + 1) % Data.Count)))
        //                {
        //                    var original = FindSymmetricalOppositeCoord(Data[insertIndex].GetCoordCombination(coordCombo),
        //                        Data[Utils.Modulo(insertIndex - 1, Data.Count)].GetCoordCombination(coordCombo),
        //                        spot.GetCoordCombination(coordCombo)[xy], xy, Data[insertIndex].Connector);

        //                    var rotated = FindSymmetricalOppositeCoord(Data[insertIndex].GetCoordCombination(coordRot),
        //                        Data[Utils.Modulo(insertIndex - 1, Data.Count)].GetCoordCombination(coordRot),
        //                        original[1], 1, Data[insertIndex].Connector)[0];

        //                    var turned = FindSymmetricalOppositeCoord(Data[insertIndex].GetCoordCombination(coordTurn),
        //                        Data[Utils.Modulo(insertIndex - 1, Data.Count)].GetCoordCombination(coordTurn),
        //                        original[0], 0, Data[insertIndex].Connector)[1];

        //                    var basedIndex = Utils.NextIndex(Data, insertIndex, false);
        //                    var newSpot = new Spot(original[0], original[1], rotated, turned, Data[basedIndex].Connector, Data[basedIndex].Solid, drawn);
        //                    newSpot.SetMatch(xy, spot);
        //                    spot.SetMatch(xy, newSpot);
        //                    if (drawn == 2)
        //                    {
        //                        newSpot.CurrentX = newSpot.X;
        //                    }
        //                    Data.Insert(insertIndex, newSpot);
        //                    index--;
        //                }
        //            }
        //        }
        //    }
        //}
                
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
            var yx = xy == 0 ? 1 : 0;
            for (var index = 0; index < Data.Count; index++)
            {
                // Check same, but not the same-same
                if (index != matchIndex && Data[index].GetCoordCombination(3)[xy] == Data[matchIndex].GetCoordCombination(3)[xy])
                {
                    if (Data[index].GetCoordCombination(3)[yx] != Data[matchIndex].GetCoordCombination(3)[yx])
                    {
                        matches.Add(index);
                    }
                    // Check not on the same line
                    else
                    {
                        // Check index --> matchIndex
                        var bends = true;
                        var round = false;
                        var sibling = index;
                        while (!round && bends)
                        {
                            sibling = (sibling + 1) % Data.Count;
                            if (sibling == matchIndex)
                            {
                                bends = false;
                            }
                            else if (Data[index].GetCoordCombination(3)[yx] != Data[sibling].GetCoordCombination(3)[yx])
                            {
                                round = true;
                            }
                        }
                        // Check matchIndex --> index
                        round = false;
                        sibling = matchIndex;
                        while (!round && bends)
                        {
                            sibling = (sibling + 1) % Data.Count;
                            if (sibling == index)
                            {
                                bends = false;
                            }
                            else if (Data[index].GetCoordCombination(3)[yx] != Data[sibling].GetCoordCombination(3)[yx])
                            {
                                round = true;
                            }
                        }
                        if (bends)
                        {
                            matches.Add(index);
                        }
                    }
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
                var min = 0;
                var max = 0;
                for (var index = 1; index < matches.Count; index++)
                {
                    if (Data[matches[index]].GetCoordCombination(3)[yx] < Data[matches[min]].GetCoordCombination(3)[yx])
                    {
                        min = index;
                    }
                    else if (Data[matches[index]].GetCoordCombination(3)[yx] > Data[matches[max]].GetCoordCombination(3)[yx])
                    {
                        max = index;
                    }
                }
                if (Data[matchIndex].GetCoordCombination(3)[yx] <= Data[matches[min]].GetCoordCombination(3)[yx])
                {
                    return max;
                }
                else if (Data[matchIndex].GetCoordCombination(3)[yx] >= Data[matches[max]].GetCoordCombination(3)[yx])
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
        public int FindSymmetricalCoordHome(int matchIndex, int xy)
        {
            var goal = Data[matchIndex].GetCoordCombination(3)[xy];
            var bigger = false;
            var searchIndex = -1;

            // Find whether we're searching above or below the goal
            for (var index = 0; index < Data.Count && searchIndex == -1; index++)
            {
                if (Data[index].GetCoordCombination(3)[xy] != goal)
                {
                    bigger = (Data[index].GetCoordCombination(3)[xy] > goal);
                    searchIndex = (index + 1) % Data.Count;
                }
            }

            // Find index position
            for (var index = 0; index < Data.Count; index++)
            {
                if (Data[searchIndex].GetCoordCombination(3)[xy] == goal)
                {
                    bigger = !bigger;
                }
                else if (Data[searchIndex].GetCoordCombination(3)[xy] > goal != bigger)
                {
                    return searchIndex;
                }

                searchIndex = (searchIndex + 1) % Data.Count;
            }
            return -1;       // None Found
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
        public float[] FindSymmetricalOppositeCoord(Spot from, Spot to, float value, int xy)
        {
            float gradient = -1;
            // TODO: Check correct line is chosen
            if (from.Connector == Consts.connectorOptions[0] || from.Connector == Consts.connectorOptions[1])
            {
                if (from.X == to.X)
                {
                    if (xy == 0)
                    {
                        return new float[] { value, to.Y };
                    }
                    else
                    {
                        return new float[] { from.X, value };
                    }
                }
                else if (from.Y == to.Y)
                {
                    if (xy == 0)
                    {
                        return new float[] { value, from.Y };
                    }
                    else
                    {
                        return new float[] { to.X, value };
                    }
                }

                gradient = (from.Y - to.Y) / (from.X - to.X);
                if (xy == 0)
                {
                    return new float[] { value, from.Y + (value - from.X) * gradient };  // y = x * gradient
                }
                else
                {
                    return new float[] { from.X + (value - from.Y) / gradient, value };  // x = y / gradient
                }
            }
            // else if (line == Constants.connectorOptions[2])      
            //CURVE

            return new float[] { -1 }; // Error
        }



        /// <summary>
        /// Finds all of the coordinates between two points.
        /// Uses a Y-across system.
        /// </summary>
        /// <param name="from">The starting point</param>
        /// <param name="to">The end point</param>
        /// <param name="join">How the two points are connected</param>
        /// <returns>A list of float[ x, (int)y ] with the point coords</returns>
        private List<float[]> LineCoords(Spot from, Spot to, string join)
        {
            var line = new List<float[]> { new float[] { from.X, from.Y } };
            var fromUpper = from.Y >= to.Y;
            var lower = fromUpper ? to : from;
            var upper = fromUpper ? from : to;

            // Solid Line
            if (join == Consts.connectorOptions[0] || join == Consts.connectorOptions[1])
            {
                var section = new List<float[]>();

                // If straight vertical line
                if (from.X - to.X == 0)
                {
                    for (var index = (int)lower.Y + 1; index < upper.Y; index++)
                    {
                        section.Add(new float[] { from.X, index });
                    }
                }

                // If diagonal line
                else if (from.Y - to.Y != 0)
                {
                    var gradient = (lower.Y - upper.Y) / (lower.X - upper.X);
                    for (var index = (int)lower.Y + 1; index < upper.Y; index++)
                    {
                        section.Add(new float[] { lower.X + ((index - lower.Y) / gradient), index });
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
        /// <returns>A list of float [ x, (int)y ] with the shape outline</returns>
        private List<float[]> LinesCoords()
        {
            var linesCoords = new List<float[]>();
            var data = GetPoints(State);
            for (var index = 0; index < data.Count; index++)
            {
                linesCoords.AddRange(LineCoords(data[index],
                    data[Utils.Modulo(index + 1, data.Count)], Data[index].Connector));
            }
            return linesCoords;
        }

        /// <summary>
        /// Finds the ranges where the piece has space.
        /// </summary>
        /// <returns>float[ y, x min, x max]</returns>
        public List<float[]> LineBounds()
        {
            // Turn coords into bound ranges
            var outlineShape = LinesCoords();
            var minMax = Utils.FindMinMax(outlineShape);
            var ranges = new List<float[]>();
            for (var index = (int)minMax[2]; index <= (int)minMax[3]; index++)
            {
                // Get coords for the specific Y value that aren't corners
                var yMatches = new List<float[]>();
                for (var coordIndex = 0; coordIndex < outlineShape.Count; coordIndex++)
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
                    float min1 = float.MaxValue;
                    float min2 = float.MaxValue;
                    var min1Index = -1;
                    var min2Index = -1;
                    for (var match = 0; match < yMatches.Count; match++)
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
                    ranges.Add(new float[3] { index, min1, min2 });
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
            for (var index = 0; index < Data.Count; index++)
            {
                var spot = Data[index];
                if (spot.DrawnLevel < (xMatch ? 1 : 2))
                {
                    spot.MatchX = null;
                    if (xMatch)
                    {
                        spot.MatchY = null;
                    }
                }
                else
                {
                    Data.RemoveAt(index);
                    index--;
                }
            }
        }
    }
}
