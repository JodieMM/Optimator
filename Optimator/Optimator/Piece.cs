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
        /// <param name="data">Piece data</param>
        public Piece(string name, List<string> data)
        {
            Name = name;
            Version = data[0];

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
            Version = Properties.Settings.Default.Version;
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
                Version,
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
            if (Data.Count < 1 || state.SM <= 0)
            {
                return new List<Spot>();
            }
            
            // Get Points
            var basePoints = Utils.SortCoordinates(GetAnchorStatePoints(state, 0));
            var rightPoints = Utils.SortCoordinates(GetAnchorStatePoints(state, 1));
            var downPoints = Utils.SortCoordinates(GetAnchorStatePoints(state, 2));
            var downRightPoints = Utils.SortCoordinates(GetAnchorStatePoints(state, 3));

            // Find Middle Ground
            var r = Utils.AngleAnchorFromAngle(state.R);
            if (state.SBase && (r == 0 || r == 2) || !state.SBase && (r == 1 || r == 3))
            {
                rightPoints = ResizeToMatch(basePoints, rightPoints, false);
                downPoints = ResizeToMatch(basePoints, downPoints);                
            }
            else
            {
                basePoints = ResizeToMatch(rightPoints, basePoints, false);
                basePoints = ResizeToMatch(downPoints, basePoints);
            }
            downRightPoints = ResizeToMatch(downPoints, downRightPoints, false);

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
        /// <param name="brd">Base, right, down or right down angle (0, 1, 2 or 3)</param>
        /// <returns>Shape at that border case</returns>
        private List<Spot> GetAnchorStatePoints(State state, int brd)
        {
            // CLEANING RTS
            // brd 0 = base 1 = right (max r min t) 2 = down (min r max t) 3 = right down (max r max t)
            var points = new List<Spot>();
            var minR = brd != 1 && brd != 3;
            var minT = brd < 2;
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
            var goal = xChange ? goalSize[1] - goalSize[0] : goalSize[3] - goalSize[2];
            var currSize = Utils.FindMinMax(changePoints);
            var curr = xChange ? currSize[1] - currSize[0] : currSize[3] - currSize[2];

            // Flat Goal (Horizontal/Vertical Line)
            if (goal == 0)
            {
                // Set all curr to goal height/width
                foreach (var point in changePoints)
                {
                    if (xChange)
                    {
                        point.X = constantPoints[0].GetCoord(0);
                    }
                    else
                    {
                        point.Y = constantPoints[0].GetCoord(1);
                    }
                }
                return changePoints;
            }
            // Flat Current with Non-Flat Goal
            else if (curr == 0)
            {
                // TODO: NON FLAT GOAL
                // Find bottom/top or left/right split and set all lower to lower value and higher to higher value
                return changePoints;
            }

            var multiplier = goal / curr;
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
            // Find Mid Point Between Spots
            var index1 = 0;
            var index2 = 0;
            var shape1 = s1;
            var shape2 = s2;
            var swapped = false;
            var minmax = Utils.FindMinMax(s1);
            var minmax1 = Utils.FindMinMaxSpots(s1);
            var minmax2 = Utils.FindMinMaxSpots(s2);
            List<int[]> holdingIndexes = new List<int[]>();
            var i1 = 0;
            var i2 = 0;
            var z = xChange ? 1 : 0;
            var altz = xChange ? 0 : 1;
            List<Spot> merged = new List<Spot>();
                        
            while (i1 < s1.Count || i2 < s2.Count)
            {
                #region Find Dominant Shape

                swapped = false;

                // Finished One Shape
                if (i1 >= s1.Count || i2 >= s2.Count)
                {
                    swapped = i1 >= s1.Count;
                }
                // xChange (Match Height)
                else if (xChange)
                {
                    // Before or At Bottom
                    if (s1.IndexOf(minmax1[2]) >= i1)
                    {
                        // Shape 2 Matches
                        if (s2.IndexOf(minmax2[2]) >= i2)
                        {
                            // Sort by Height
                            if (s1[i1].Y < s2[i2].Y)
                            {
                                swapped = true;
                            }
                            // Sort by X
                            else if (s1[i1].Y == s2[i2].Y)
                            {
                                if (s1.IndexOf(minmax1[1]) > i1 && s2.IndexOf(minmax2[1]) > i2 && s1[i1].X > s2[i2].X ||
                                    s1.IndexOf(minmax1[1]) < i1 && s2.IndexOf(minmax2[1]) < i2 && s1[i1].X < s2[i2].X)
                                {
                                    swapped = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        // Shape 2 Doesn't Match
                        if (s2.IndexOf(minmax2[2]) >= i2 || s1.IndexOf(minmax1[0]) < i1 && s2.IndexOf(minmax2[0]) >= i2)
                        {
                            swapped = true;
                        }
                        // Sort by Height
                        else if (s1[i1].Y > s2[i2].Y)
                        {
                            swapped = true;
                        }
                        // Sort by X
                        else if (s1[i1].Y == s2[i2].Y)
                        {
                            if (s1.IndexOf(minmax1[0]) > i1 && s2.IndexOf(minmax2[0]) > i2 && s1[i1].X > s2[i2].X ||
                                    s1.IndexOf(minmax1[0]) < i1 && s2.IndexOf(minmax2[0]) < i2 && s1[i1].X < s2[i2].X)
                            {
                                swapped = true;
                            }
                        }
                    }
                }
                // yChange (Match Width)
                else
                {
                    // Quadrant 1
                    if (s1.IndexOf(minmax1[1]) >= i1)
                    {
                        // Shape 2 Matches
                        if (s2.IndexOf(minmax2[1]) >= i2)
                        {
                            // Check X
                            if (s1[Utils.Modulo(i1, s1.Count)].X > s2[Utils.Modulo(i2, s2.Count)].X)
                            {
                                swapped = true;
                            }
                            // Check Height
                            else if (s1[Utils.Modulo(i1, s1.Count)].X == s2[Utils.Modulo(i2, s2.Count)].X &&
                                s1[Utils.Modulo(i1, s1.Count)].Y < s2[Utils.Modulo(i2, s2.Count)].Y)
                            {
                                swapped = true;
                            }
                        }
                    }
                    // Quadrant 2
                    else if (s1.IndexOf(minmax1[2]) >= i1)
                    {
                        // Shape 2 Matches
                        if (s2.IndexOf(minmax2[2]) >= i2 && s2.IndexOf(minmax2[1]) < i2)
                        {
                            // Check X
                            if (s1[Utils.Modulo(i1, s1.Count)].X < s2[Utils.Modulo(i2, s2.Count)].X)
                            {
                                swapped = true;
                            }
                            // Check Height
                            else if (s1[Utils.Modulo(i1, s1.Count)].X == s2[Utils.Modulo(i2, s2.Count)].X &&
                                s1[Utils.Modulo(i1, s1.Count)].Y < s2[Utils.Modulo(i2, s2.Count)].Y)
                            {
                                swapped = true;
                            }
                        }
                        // Shape 2 Earlier
                        else if (s2.IndexOf(minmax2[1]) >= i2)
                        {
                            swapped = true;
                        }
                    }
                    // Quadrant 3
                    else if (s1.IndexOf(minmax1[0]) >= i1)
                    {
                        // Shape 2 Matches
                        if (s2.IndexOf(minmax2[0]) >= i2 && s2.IndexOf(minmax2[2]) < i2)
                        {
                            // Check X
                            if (s1[Utils.Modulo(i1, s1.Count)].X < s2[Utils.Modulo(i2, s2.Count)].X)
                            {
                                swapped = true;
                            }
                            // Check Height
                            else if (s1[Utils.Modulo(i1, s1.Count)].X == s2[Utils.Modulo(i2, s2.Count)].X &&
                                s1[Utils.Modulo(i1, s1.Count)].Y > s2[Utils.Modulo(i2, s2.Count)].Y)
                            {
                                swapped = true;
                            }
                        }
                        // Shape 2 Earlier
                        else if (s2.IndexOf(minmax2[2]) >= i2)
                        {
                            swapped = true;
                        }
                    }
                    // Quadrant 4
                    else
                    {
                        // Shape 2 Matches
                        if (s2.IndexOf(minmax2[0]) < i2)
                        {
                            // Check X
                            if (s1[Utils.Modulo(i1, s1.Count)].X > s2[Utils.Modulo(i2, s2.Count)].X)
                            {
                                swapped = true;
                            }
                            // Check Height
                            else if (s1[Utils.Modulo(i1, s1.Count)].X == s2[Utils.Modulo(i2, s2.Count)].X &&
                                s1[Utils.Modulo(i1, s1.Count)].Y > s2[Utils.Modulo(i2, s2.Count)].Y)
                            {
                                swapped = true;
                            }
                        }
                        // Shape 2 Earlier
                        else if (s2.IndexOf(minmax2[0]) >= i2)
                        {
                            swapped = true;
                        }
                    }
                }
                #endregion

                shape1 = swapped ? s2 : s1;
                shape2 = swapped ? s1 : s2;
                index1 = swapped ? Utils.Modulo(i2, s2.Count) : Utils.Modulo(i1, s1.Count);
                index2 = swapped ? Utils.Modulo(i1, s1.Count) : Utils.Modulo(i2, s2.Count);

                // Check Dominant Point not Already Drawn
                var undrawn = true;
                var index = 0;
                while (index < holdingIndexes.Count && undrawn)
                {
                    if (holdingIndexes[index][0] == (swapped ? 1 : 0) && holdingIndexes[index][1] == index1)
                    {
                        undrawn = false;
                        holdingIndexes.RemoveAt(index);
                        i1 += swapped ? 0 : 1;
                        i2 += swapped ? 1 : 0;
                    }
                    index++;
                }
                if (undrawn)
                {
                    var matchPosition = FindSymmetricalCoordHome(shape1, shape2, shape1[index1], z);

                    // Single Matching Spot
                    if (matchPosition.Length == 1 && matchPosition[0] != -1)
                    {                        
                        var match = Utils.Modulo(matchPosition[0], shape2.Count);
                        var unchanged = shape1[index1].GetCoord(z);
                        var changed = Utils.FindMiddleSpot(shape1[index1].GetCoord(altz), shape2[match].GetCoord(altz), angle, swapped);
                        var newSpot = new Spot(xChange ? changed : unchanged, xChange ? unchanged : changed);
                        merged.Add(newSpot);
                        index1++;
                        i1 += swapped ? 0 : 1;
                        i2 += swapped ? 1 : 0;
                        if (match == index2)
                        {
                            index2++;
                            i1 += swapped ? 1 : 0;
                            i2 += swapped ? 0 : 1;
                        }
                        else if (match > index2)
                        {
                            // Will Re-Do Later when Match Occurs
                            if (Utils.Modulo(angle, 90) < 45)
                            {
                                merged.Remove(newSpot);
                            }
                            // Don't Do Match When It Occurs
                            else
                            {
                                holdingIndexes.Add(new int[] { swapped ? 0 : 1, match });
                            }
                        }
                        var newSpot2 = Utils.CloneSpot(newSpot);

                        // Check for Self Neighbours
                        if (index1 < shape1.Count && shape1[index1 - 1].GetCoord(z) == shape1[index1].GetCoord(z))
                        {             
                            // Self and Match Neighbours
                            if (shape2[match].GetCoord(z) == shape2[Utils.NextIndex(shape2, match)].GetCoord(z) && shape2.Count > 1)
                            {
                                changed = Utils.FindMiddleSpot(shape1[index1].GetCoord(altz),
                                    shape2[Utils.NextIndex(shape2, match)].GetCoord(altz), angle, swapped);
                                if (xChange)
                                {
                                    newSpot2.X = changed;
                                }
                                else
                                {
                                    newSpot2.Y = changed;
                                }
                                merged.Add(newSpot2);
                                index1++;
                                i1 += swapped ? 0 : 1;
                                i2 += swapped ? 1 : 0;
                                if (Utils.NextIndex(shape2, match) == index2)
                                {
                                    index2++;
                                    i1 += swapped ? 1 : 0;
                                    i2 += swapped ? 0 : 1;
                                }
                                else if (Utils.NextIndex(shape2, match) > index2)
                                {
                                    holdingIndexes.Add(new int[] { swapped ? 1 : 0, Utils.NextIndex(shape2, match) });
                                }
                            }
                            // Self Neighbour Only
                            else
                            {
                                changed = Utils.FindMiddleSpot(shape1[index1].GetCoord(z),
                                    shape2[match].GetCoord(z), angle, swapped);
                                if (xChange)
                                {
                                    newSpot2.X = changed;
                                }
                                else
                                {
                                    newSpot2.Y = changed;
                                }
                                merged.Add(newSpot2);
                                index1++;
                                i1 += swapped ? 0 : 1;
                                i2 += swapped ? 1 : 0;
                            }
                        }
                        // Check for Match Neighbours
                        else if (shape2[match].GetCoord(z) == shape2[Utils.NextIndex(shape2, match)].GetCoord(z) && shape2.Count > 1)
                        {
                            changed = Utils.FindMiddleSpot(shape1[Utils.NextIndex(shape1, index1, false)].GetCoord(altz),
                                    shape2[Utils.NextIndex(shape2, match)].GetCoord(altz), angle, swapped);
                            if (xChange)
                            {
                                newSpot2.X = changed;
                            }
                            else
                            {
                                newSpot2.Y = changed;
                            }
                            merged.Add(newSpot2);
                            if (Utils.NextIndex(shape2, match) == index2)
                            {
                                index2++;
                                i1 += swapped ? 1 : 0;
                                i2 += swapped ? 0 : 1;
                            }
                            else if (Utils.NextIndex(shape2, match) > index2)
                            {
                                holdingIndexes.Add(new int[] { swapped ? 1 : 0, Utils.NextIndex(shape2, match) });
                            }
                        }
                    }
                    // Spaced Between Two Spots
                    else if (matchPosition.Length == 2)
                    {
                        var match = FindSymmetricalOppositeCoord(shape2[Utils.Modulo(matchPosition[0], shape2.Count)],
                                shape2[Utils.Modulo(matchPosition[1], shape2.Count)], shape1[index1].GetCoord(z), z);
                        var unchanged = shape1[index1].GetCoord(z);
                        var changed = Utils.FindMiddleSpot(shape1[index1].GetCoord(altz), match[altz], angle, swapped);
                        var newSpot = new Spot(xChange ? changed : unchanged, xChange ? unchanged : changed);
                        // TODO: New spots need to retain old features
                        merged.Add(newSpot);
                        index1++;
                        i1 += swapped ? 0 : 1;
                        i2 += swapped ? 1 : 0;

                        // Check for Self Neighbours
                        if (index1 < shape1.Count && shape1[index1 - 1].GetCoord(z) == shape1[index1].GetCoord(z))
                        {
                            changed = Utils.FindMiddleSpot(shape1[index1].GetCoord(altz),
                                    match[altz], angle, swapped);
                            if (xChange)
                            {
                                newSpot.X = changed;
                            }
                            else
                            {
                                newSpot.Y = changed;
                            }
                            merged.Add(newSpot);
                            index1++;
                            i1 += swapped ? 0 : 1;
                            i2 += swapped ? 1 : 0;
                        }
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
        public int[] FindSymmetricalCoordHome(List<Spot> s1, List<Spot> s2, Spot match, int xy)
        {
            // Determine if Coord Occurs Top or Bottom / Left or Right
            var minmax = Utils.FindMinMaxSpots(s1);
            bool topRight = (xy == 0 && Utils.WithinRanges(s1.IndexOf(minmax[0]), s1.IndexOf(minmax[1]), s1.IndexOf(match))) ||
                (xy == 1 && Utils.WithinRanges(s1.IndexOf(minmax[3]), s1.IndexOf(minmax[2]), s1.IndexOf(match)));

            // Find Matching Position
            var backup = new int[1] { -1 };
            minmax = Utils.FindMinMaxSpots(s2);
            var goal = match.GetCoord(xy);
            for (int index = 0; index < s2.Count; index++)
            {
                // Top/Right and in Top/Right
                if (topRight && ((xy == 0 && Utils.WithinRanges(s2.IndexOf(minmax[0]), s2.IndexOf(minmax[1]), index)) ||
                    (xy == 1 && Utils.WithinRanges(s2.IndexOf(minmax[3]), s2.IndexOf(minmax[2]), index))))
                {
                    // Exact Match
                    if (Utils.SameValue(s2[index].GetCoord(xy), goal))
                    {
                        return new int[] { index };
                    }
                    // Between Two Points
                    else if (s2[index].GetCoord(xy) > goal && s2[Utils.NextIndex(s2, index)].GetCoord(xy) < goal)
                    {
                        return new int[] { index, Utils.NextIndex(s2, index) };
                    }
                    else if (s2[index].GetCoord(xy) < goal && s2[Utils.NextIndex(s2, index)].GetCoord(xy) > goal)
                    {
                        return new int[] { index, Utils.NextIndex(s2, index) };
                    }
                }
                // Bottom/Left and in Bottom/Left
                else if (!topRight && !((xy == 0 && Utils.WithinRanges(s2.IndexOf(minmax[0]), s2.IndexOf(minmax[1]), index)) ||
                    (xy == 1 && Utils.WithinRanges(s2.IndexOf(minmax[3]), s2.IndexOf(minmax[2]), index))))
                {
                    // Exact Match
                    if (Utils.SameValue(s2[index].GetCoord(xy), goal))
                    {
                        return new int[] { index };
                    }
                    // Between Two Points
                    else if (s2[index].GetCoord(xy) > goal && s2[Utils.NextIndex(s2, index)].GetCoord(xy) < goal)
                    {
                        return new int[] { index, Utils.NextIndex(s2, index) };
                    }
                    else if (s2[index].GetCoord(xy) < goal && s2[Utils.NextIndex(s2, index)].GetCoord(xy) > goal)
                    {
                        return new int[] { index, Utils.NextIndex(s2, index) };
                    }
                }
            }
            return backup;      // None Found, Spare Used If Found
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
                    data[Utils.Modulo(index + 1, data.Count)], data[index].Connector));
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
