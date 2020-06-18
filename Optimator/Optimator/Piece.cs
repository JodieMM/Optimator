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
        /// Converts into itself to accommodate sets in part.
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
        /// Finds the points to print based on the rotation, turn, spin and size of the piece.
        /// </summary>
        /// <param name="state">Current angles of piece</param>
        /// <returns>List of spots to draw</returns>
        public List<Spot> GetPoints(State state)
        {
            if (Data.Count < 1)
            {
                return new List<Spot>();
            }
            
            // Get Points
            var basePoints = Utils.SortCoordinates(GetAnchorStatePoints(state, 0));
            var rightPoints = Utils.SortCoordinates(GetAnchorStatePoints(state, 1));
            var downPoints = Utils.SortCoordinates(GetAnchorStatePoints(state, 2));
            var downRightPoints = Utils.SortCoordinates(GetAnchorStatePoints(Utils.AdjustStateAngle(1, state), 2));

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
            downRightPoints = ResizeToMatch(downPoints, downRightPoints);

            var merge1 = Utils.SortCoordinates(MergeShapes(basePoints, rightPoints, state.R));
            var merge2 = Utils.SortCoordinates(MergeShapes(downPoints, downRightPoints, state.R));
            var points = Utils.SortCoordinates(MergeShapes(merge1, merge2, state.T, false));

            // Recentre & Resize
            for (var index = 0; index < points.Count; index++)
            {
                points[index].X = points[index].X * state.SM + state.X;
                points[index].Y = points[index].Y * state.SM + state.Y;
            }

            return points;
        }

        /// <summary>
        /// Determines the border cases of angled shapes.
        /// </summary>
        /// <param name="state">Shape angle</param>
        /// <param name="brd">Base, right or down angle (0, 1 or 2)</param>
        /// <returns>Shape at that border case</returns>
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

        /// <summary>
        /// Resize the change points to the same width or height as the constant points.
        /// </summary>
        /// <param name="constantPoints">Unchanging shape</param>
        /// <param name="changePoints">Changing shape</param>
        /// <param name="xChange">True if x changes (width)</param>
        /// <returns>Resized change shape</returns>
        private List<Spot> ResizeToMatch(List<Spot> constantPoints, List<Spot> changePoints, bool xChange = true)
        {
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

        /// <summary>
        /// Merge two shapes into one.
        /// </summary>
        /// <param name="s1">Initial shape</param>
        /// <param name="s2">Final shape</param>
        /// <param name="angle">Percentage from initial to final</param>
        /// <param name="xChange">Whether the x or y coords change</param>
        /// <returns></returns>
        private List<Spot> MergeShapes(List<Spot> s1, List<Spot> s2, float angle, bool xChange = true)
        {
            // TODO: Ensure points are not being found twice / no double-ups ***

            // Find Mid Point Between Spots
            var index1 = 0;
            var index2 = 0;
            var shape1 = s1;
            var shape2 = s2;
            var isSwapped = false;
            var reachedBottom1 = false;
            var reachedBottom2 = false;
            var reachedBelow1 = false;
            var reachedBelow2 = false;
            var i1 = 0;
            var i2 = 0;
            var z = xChange ? 1 : 0;
            var altz = xChange ? 0 : 1;
            List<Spot> merged = new List<Spot>();

            while (i1 < s1.Count || i2 < s2.Count)
            {
                // Find dominant shape
                if (!reachedBottom1 && i1 != 0 && i1 < s1.Count && s1[i1].Y > s1[i1 - 1].Y)
                {
                    reachedBottom1 = true;
                }
                if (!reachedBottom2 && i2 != 0 && i2 < s2.Count && s2[i2].Y > s2[i2 - 1].Y)
                {
                    reachedBottom2 = true;
                }
                if (xChange)
                {         
                    isSwapped = i2 < s2.Count && (i1 >= s1.Count || reachedBottom1 && !reachedBottom2 ||
                        !reachedBottom1 && !reachedBottom2 && s1[i1].Y < s2[i2].Y ||
                        reachedBottom1 && reachedBottom2 & s1[i1].Y > s2[i2].Y);
                }
                else
                {
                    if (!reachedBelow1 && i1 != 0 && i1 < s1.Count && s1[i1].X < s1[i1 - 1].X)
                    {
                        reachedBelow1 = true;
                    }
                    else if (reachedBelow1 && i1 != 0 && i1 < s1.Count && s1[i1].X > s1[i1 - 1].X)
                    {
                        reachedBelow1 = false;
                    }
                    if (!reachedBelow2 && i2 != 0 && i2 < s2.Count && s2[i2].X < s2[i2 - 1].X)
                    {
                        reachedBelow2 = true;
                    }
                    else if (reachedBelow2 && i2 != 0 && i2 < s2.Count && s2[i2].X > s2[i2 - 1].X)
                    {
                        reachedBelow2 = false;
                    }
                    isSwapped = i2 < s2.Count && (i1 >= s1.Count || reachedBottom1 && !reachedBottom2 ||
                        !reachedBottom1 && !reachedBottom2 &&
                        (s1[i1].Y < s2[i2].Y || s1[i1].Y == s2[i2].Y && (reachedBelow1 && reachedBelow2 && s1[i1].X < s2[i2].X ||
                        !reachedBelow1 && !reachedBelow2 && s1[i1].X > s2[i1].X)) ||
                        reachedBottom1 && reachedBottom2 &&
                        (s1[i1].Y > s2[i2].Y || s1[i1].Y == s2[i2].Y && (reachedBelow1 && reachedBelow2 && s1[i1].X < s2[i2].X ||
                        !reachedBelow1 && !reachedBelow2 && s1[i1].X > s2[i1].X)));
                }
                shape1 = isSwapped ? s2 : s1;
                shape2 = isSwapped ? s1 : s2;
                index1 = isSwapped ? i2 : i1;
                index2 = isSwapped ? i1 : i2;

                // Check for neighbouring spots
                if (index1 < shape1.Count - 1 && shape1[index1].GetCoord(z) == shape1[index1 + 1].GetCoord(z))
                {
                    // If the neighbours have a pre-made matching spot
                    if (shape2[Utils.Modulo(index2, shape2.Count)].GetCoord(z) == shape1[index1].GetCoord(z))
                    {
                        // If the matching spots also have a neighbour
                        if (shape2[Utils.NextIndex(shape2, index2)].GetCoord(z) == shape2[Utils.Modulo(index2, shape2.Count)].GetCoord(z))
                        {
                            float unchanged = shape1[index1].GetCoord(z);
                            float changed = Utils.FindMiddleSpot(s1[Utils.Modulo(i1, s1.Count)].GetCoord(altz), s2[Utils.Modulo(i2, s2.Count)].GetCoord(altz), angle);
                            var newSpot = new Spot(xChange ? changed : unchanged, xChange ? unchanged : changed);
                            merged.Add(newSpot);
                            changed = Utils.FindMiddleSpot(s1[Utils.NextIndex(s1, i1)].GetCoord(altz), s2[Utils.NextIndex(s2, i2)].GetCoord(altz), angle);
                            if (xChange)
                            {
                                newSpot.X = changed;
                            }
                            else
                            {
                                newSpot.Y = changed;
                            }
                            merged.Add(newSpot);
                            i1 += 2;
                            i2 += 2;
                        }
                        else
                        {
                            float unchanged = shape1[index1].GetCoord(z);
                            float changed = Utils.FindMiddleSpot(s1[Utils.Modulo(i1, s1.Count)].GetCoord(altz), s2[Utils.Modulo(i2, s2.Count)].GetCoord(altz), angle);
                            Spot newSpot = new Spot(xChange ? changed : unchanged, xChange ? unchanged : changed);
                            merged.Add(newSpot);
                            changed = isSwapped ? Utils.FindMiddleSpot(shape2[Utils.Modulo(index2, shape2.Count)].GetCoord(altz), shape1[index1 + 1].GetCoord(altz), angle) :
                                Utils.FindMiddleSpot(shape1[index1 + 1].GetCoord(altz), shape2[Utils.Modulo(index2, shape2.Count)].GetCoord(altz), angle);
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
                        var shapeSearch = FindSymmetricalCoordHome(shape1, shape2, shape1[index1], z);
                        var newShape = FindSymmetricalOppositeCoord(shape2[Utils.NextIndex(shape2, shapeSearch)],
                            shape2[Utils.Modulo(shapeSearch, shape2.Count)], shape1[index1].GetCoord(z), z);

                        float unchanged = shape1[index1].GetCoord(z);
                        float changed = isSwapped ? Utils.FindMiddleSpot(newShape[altz], shape1[index1].GetCoord(altz), angle) : 
                            Utils.FindMiddleSpot(shape1[index1].GetCoord(altz), newShape[altz], angle);
                        Spot newSpot = new Spot(xChange ? changed : unchanged, xChange ? unchanged : changed);
                        merged.Add(newSpot);
                        changed = isSwapped ? Utils.FindMiddleSpot(newShape[altz], shape1[index1 + 1].GetCoord(altz), angle) : 
                            Utils.FindMiddleSpot(shape1[index1 + 1].GetCoord(altz), newShape[altz], angle);
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
                    if (shape2[Utils.Modulo(index2, shape2.Count)].GetCoord(z) == shape1[index1].GetCoord(z))
                    {
                        // Match has neighbours
                        if (shape2[Utils.NextIndex(shape2, index2)].GetCoord(z) == shape2[Utils.Modulo(index2, shape2.Count)].GetCoord(z))
                        {
                            float unchanged = shape1[index1].GetCoord(z);
                            float changed = Utils.FindMiddleSpot(s1[Utils.Modulo(i1, s1.Count)].GetCoord(altz), s2[Utils.Modulo(i2, s2.Count)].GetCoord(altz), angle);
                            Spot newSpot = new Spot(xChange ? changed : unchanged, xChange ? unchanged : changed);
                            merged.Add(newSpot);
                            changed = isSwapped ? Utils.FindMiddleSpot(shape2[Utils.NextIndex(shape2, index2)].GetCoord(altz), shape1[index1].GetCoord(altz), angle) : 
                                Utils.FindMiddleSpot(shape1[index1].GetCoord(altz), shape2[Utils.NextIndex(shape2, index2)].GetCoord(altz), angle);
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
                            float changed = Utils.FindMiddleSpot(s1[Utils.Modulo(i1, s1.Count)].GetCoord(altz), s2[Utils.Modulo(i2, s2.Count)].GetCoord(altz), angle);
                            Spot newSpot = new Spot(xChange ? changed : unchanged, xChange ? unchanged : changed);
                            merged.Add(newSpot);
                            i1++;
                            i2++;
                        }
                    }
                    // Need to build match
                    else
                    {
                        var shapeSearch = FindSymmetricalCoordHome(shape1, shape2, shape1[index1], z);
                        var newShape = FindSymmetricalOppositeCoord(shape2[Utils.NextIndex(shape2, shapeSearch)], 
                            shape2[Utils.Modulo(shapeSearch, shape2.Count)], shape1[index1].GetCoord(z), z);

                        float unchanged = shape1[index1].GetCoord(z);
                        float changed = isSwapped ? Utils.FindMiddleSpot(newShape[altz], shape1[index1].GetCoord(altz), angle) : 
                            Utils.FindMiddleSpot(shape1[index1].GetCoord(altz), newShape[altz], angle);
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
        /// Finds where a matching point would go if it existed.
        /// </summary>
        /// <param name="s1">The first shape containing match</param>
        /// <param name="s2">The second shape searching for match</param>
        /// <param name="match">The spot to be matched</param>
        /// <param name="xy">Whether searching for a match in x (0) or y (1)</param>
        /// <returns>The index where the matching point would go or -1 in error</returns>
        public int FindSymmetricalCoordHome(List<Spot> s1, List<Spot> s2, Spot match, int xy)
        {
            // Determine if first or second instance required
            var goal = match.GetCoord(xy);
            var index = 0;
            var instance = 0;
            while (index < s1.Count)
            {
                if (s1[index].GetCoord(xy) == goal)
                {
                    if (s1[index] == match)
                    {
                        index = s1.Count;
                        instance++;
                    }
                    else if (s1[Utils.NextIndex(s1, index)].GetCoord(xy) != goal)
                    {
                        instance++;
                    }
                }
                else if (s1[index].GetCoord(xy) > goal && s1[Utils.NextIndex(s1, index)].GetCoord(xy) < goal ||
                    s1[index].GetCoord(xy) < goal && s1[Utils.NextIndex(s1, index)].GetCoord(xy) > goal)
                {
                    instance++;
                }
                index++;
            }

            // Find said instance
            if (instance > 0)
            {
                index = 0;
                var found = 0;
                var backup = -1;
                while (index < s2.Count)
                {
                    if (s2[index].GetCoord(xy) == goal ||
                        s2[index].GetCoord(xy) > goal && s2[Utils.NextIndex(s2, index)].GetCoord(xy) < goal ||
                        s2[index].GetCoord(xy) < goal && s2[Utils.NextIndex(s2, index)].GetCoord(xy) > goal)
                    {
                        if (instance == 1)
                        {
                            return index;
                        }
                        else if (found > 0)
                        {
                            return index;
                        }
                        else if (s2[index].GetCoord(xy) == goal && s2[Utils.NextIndex(s2, index)].GetCoord(xy) != goal
                            || s2[index].GetCoord(xy) != goal)
                        {
                            backup = index;
                            found++;
                        }
                    }
                    index++;
                }
                if (backup != -1)
                {
                    return backup;
                }
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
