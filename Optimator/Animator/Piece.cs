using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Animator
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

        // Coords and Angles
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public double R { get; set; } = 0;
        public double T { get; set; } = 0;
        public double S { get; set; } = 0;
        public double SM { get; set; } = 100;

        // Colours and Details
        public string ColourType { get; set; }                     // Solid/Gradient colour and direction
        public Color[] FillColour { get; set; }                    // Multiple colours for gradients
        public Color OutlineColour { get; set; }
        public decimal OutlineWidth { get; set; }
        public string PieceDetails { get; set; }                   // Wind resistance and more

        // Stored Values
        public double[] middle;
        private double[] minMax;

        // Sets
        public Piece AttachedTo { get; set; } = null;
        public Spot Join { get; set; } = null;
        public Set PieceOf { get; set; } = null;
        public double AngleFlip { get; set; } = -1;
        public int IndexSwitch { get; set; } = 0;

        //Scenes
        public Originals Originally { get; set; } = null;
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
            List<string> data = Utilities.ReadFile(Utilities.GetDirectory(Constants.PiecesFolder, Name, Constants.Txt));

            // Get Version
            Version = data[0].Split(Constants.Semi)[1];
            Utilities.CheckValidVersion(Version);

            // Get Points and Colours from File
            string[] angleData = data[1].Split(Constants.Semi);

            // Colour Type
            ColourType = angleData[0];

            // Colours (Outline and Fill)
            string[] colours = angleData[1].Split(Constants.Colon);
            FillColour = new Color[colours.Length - 1];
            for (int index = 0; index < colours.Length; index++)
            {
                string[] rgbValues = colours[index].Split(Constants.Comma);
                if (index == 0)
                    OutlineColour = Color.FromArgb(int.Parse(rgbValues[0]), int.Parse(rgbValues[1]), int.Parse(rgbValues[2]), int.Parse(rgbValues[3]));
                else
                    FillColour[index - 1] = Color.FromArgb(int.Parse(rgbValues[0]), int.Parse(rgbValues[1]), int.Parse(rgbValues[2]), int.Parse(rgbValues[3]));
            }

            // Outline Width
            OutlineWidth = int.Parse(angleData[2]);

            // Piece Details
            PieceDetails = angleData[3];

            // Spots
            for (int index = 2; index < data.Count; index++)
            {
                string[] spotData = data[index].Split(Constants.Semi);
                string[] coords = spotData[0].Split(Constants.Colon);

                Data.Add(new Spot(double.Parse(coords[0]), double.Parse(coords[1]), double.Parse(coords[2]),
                    double.Parse(coords[3]), spotData[1], spotData[2]));
            }
            RunCalculations();
        }

        /// <summary>
        /// Piece constructor used when developing a
        /// piece for the first time.
        /// </summary>
        public Piece()
        {
            Name = Constants.WIPName;
            Version = Constants.Version;
            ColourType = Constants.fillOptions[0];
            FillColour = new Color[] { Constants.defaultFill };
            OutlineColour = Constants.defaultOutline;
            OutlineWidth = Constants.defaultOutlineWidth;
            PieceDetails = Constants.defaultPieceDetails;
        }



        // ----- GET FUNCTIONS -----
        #region Get Functions
       
        /// <summary>
        /// Gets the size modifier with considerations as a decimal
        /// </summary>
        /// <returns>Size Modifier</returns>
        public double GetSizeMod()
        {
            return AttachedTo != null ? (SM / 100.0) * (AttachedTo.GetSizeMod()) : SM / 100;
        }

        /// <summary>
        /// Gets the X and Y values of the piece with considerations
        /// </summary>
        /// <returns>double[] { X, Y }</returns>
        public double[] GetCoords()
        {
            return AttachedTo != null ? new double[] { X + AttachedTo.GetCoords()[0] + PointChange()[0],
                Y + AttachedTo.GetCoords()[1] + PointChange()[1] } : new double[] { X, Y };
        }

        /// <summary>
        /// Gets the rotation, turn and spin of the piece with considerations
        /// </summary>
        /// <returns>double[] { Rotation, Turn, Spin }</returns>
        public double[] GetAngles()
        {
            double[] angles = new double[3];

            // Original Angles
            angles[0] = R; // + S * Math.Sin(Utilities.ToRad(T));
            angles[1] = T; //+ S * Math.Sin(Utilities.ToRad(R));
            angles[2] = S; //* Math.Cos(Utilities.ToRad(R)); // + S * Math.Cos(Utilities.ToRad(T));

            // Build Off Attached
            if (AttachedTo != null)
            {
                angles[0] += AttachedTo.GetAngles()[0];
                angles[1] += AttachedTo.GetAngles()[1];
                angles[2] += AttachedTo.GetAngles()[2];
            }

            // Modulus of 360 degrees
            angles[0] = angles[0] % 360;
            angles[1] = angles[1] % 360;
            angles[2] = angles[2] % 360;
            return angles;
        }

        /// <summary>
        /// Gets piece's current details in a string format.
        /// </summary>
        public override List<string> GetData()
        {
            // Type and Version
            List<string> newData = new List<string>
            {
                Constants.Piece + Constants.Semi + Version
            };

            // Update line of data            [0] colour type     [1] colour array        [2] outline width       [3] pieceDetails
            string pieceInfo = ColourType + ";" + OutlineColour.A + "," + OutlineColour.R + "," + OutlineColour.G + "," + OutlineColour.B + ":";
            foreach (Color col in FillColour)
                pieceInfo += col.A + "," + col.R + "," + col.G + "," + col.B + ":";
            pieceInfo = pieceInfo.Remove(pieceInfo.Length - 1, 1) + ";" + OutlineWidth + ";" + PieceDetails;
            newData.Add(pieceInfo);

            // Add DataRows
            foreach (Spot spot in Data)
                newData.Add(spot.ToString());
            return newData;
        }

        #endregion



        // ----- SET FUNCTIONS -----
        #region Set Functions

        /// <summary>
        /// Sets all of the position/angle/size parameters at once.
        /// </summary>
        /// <param name="x">New X Coord</param>
        /// <param name="y">New Y Coord</param>
        /// <param name="r">New Rotation</param>
        /// <param name="t">New Turn</param>
        /// <param name="s">New Spin</param>
        /// <param name="sm">New Size Modifier</param>
        public void SetValues(double x, double y, double r, double t, double s, double sm)
        {
            X = x; Y = y; R = r; T = t; S = s; SM = sm;
        }

        /// <summary>
        /// Sets the centre of the point to the board it's being displayed on.
        /// </summary>
        /// <param name="pictureBox">The board the piece is to be drawn on</param>
        public void SetCoordsAsMid(PictureBox pictureBox)
        {
            X = pictureBox.Width / 2.0;
            Y = pictureBox.Height / 2.0;
        }

        /// <summary>
        /// Attaches this piece to another, forming or continuing a set.
        /// </summary>
        /// <param name="attach">The piece being attached to</param>
        /// <param name="join">The point where the piece attaches to its base</param>
        /// <param name="angleFlip">The angle when front is changed</param>
        /// <param name="indexSwitch">The index position the piece takes when flipped</param>
        public void AttachToPiece(Piece attach, Spot join = null, double angleFlip = -1, int indexSwitch = 0)
        {
            AttachedTo = attach;
            if (join == null)
                join = new Spot(GetCoords()[0], GetCoords()[1]);
            Join = join;
            AngleFlip = angleFlip;
            IndexSwitch = indexSwitch;
        }

        /// <summary>
        /// Detaches the piece from its current base.
        /// </summary>
        public void Deattach()
        {
            X = GetCoords()[0];
            Y = GetCoords()[1];
            AttachedTo = null;
            Join = null;
            AngleFlip = -1;
            IndexSwitch = 0;
        }

        #endregion



        // ----- PART FUNCTIONS -----

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
        /// Returns the set a piece may belong to.
        /// </summary>
        /// <returns>Set it is part of</returns>
        public override Set ToSet()
        {
            return PieceOf;
        }

        /// <summary>
        /// Draws the piece to the provided graphics.
        /// </summary>
        /// <param name="g">Provided graphics</param>
        public override void Draw(Graphics g, Color? outline = null)
        {
            if (outline == null)
                Visuals.DrawPiece(this, g);
            else
                Visuals.DrawPiece(this, g, outline);
        }



        // ----- SHAPE FUNCTIONS -----
        #region Shape Functions

        /// <summary>
        /// Finds the points to print based on the rotation, turn, spin and size of the piece
        /// </summary>
        /// <returns></returns>
        public List<double[]> CurrentPoints()
        {
            var points = new List<double[]>();

            // Get Points
            CalculateMatches();
            foreach (var spot in Data)
                spot.CurrentX = spot.CalculateCurrentValue(GetAngles()[0], middle);
            CalculateMatches(0);
            foreach (var spot in Data)
                points.Add(new double[] { spot.CurrentX, spot.CalculateCurrentValue(GetAngles()[1], middle, 0) });

            // Recentre
            for (int index = 0; index < points.Count; index++)
            {
                points[index][0] = GetCoords()[0] + (points[index][0] - middle[0]);
                points[index][1] = GetCoords()[1] + (points[index][1] - middle[1]);
            }

            // Spin and Size Adjustment
            points = SpinMeRound(points);

            return points;
        }

        /// <summary>
        /// Spins the coords provided and modifies their size.
        /// </summary>
        /// <param name="pointsArray">The points to be spun</param>
        /// <returns></returns>
        private List<double[]> SpinMeRound(List<double[]> pointsArray)
        {
            // Spin Adjustment
            for (int index = 0; index < pointsArray.Count; index++)
            {
                if (!(pointsArray[index][0] == GetCoords()[0] && pointsArray[index][1] == GetCoords()[1]))
                {
                    double hypotenuse = Math.Sqrt(Math.Pow(GetCoords()[0] - pointsArray[index][0], 2) + Math.Pow(GetCoords()[1] - pointsArray[index][1], 2)) * GetSizeMod();
                    // Find Angle
                    double pointAngle;
                    if (pointsArray[index][0] == GetCoords()[0] && pointsArray[index][1] < GetCoords()[1])
                    {
                        pointAngle = 0;
                    }
                    else if (pointsArray[index][0] == GetCoords()[0] && pointsArray[index][1] > GetCoords()[1])
                    {
                        pointAngle = 180;
                    }
                    else if (pointsArray[index][0] > GetCoords()[0] && pointsArray[index][1] == GetCoords()[1])
                    {
                        pointAngle = 90;
                    }
                    else if (pointsArray[index][0] < GetCoords()[0] && pointsArray[index][1] == GetCoords()[1])
                    {
                        pointAngle = 270;
                    }
                    //  Second || First
                    //  Third  || Fourth
                    else if (pointsArray[index][0] > GetCoords()[0] && pointsArray[index][1] < GetCoords()[1]) // First Quadrant
                    {
                        pointAngle = (180 / Math.PI) * Math.Atan(Math.Abs((GetCoords()[0] - pointsArray[index][0]) / (GetCoords()[1] - pointsArray[index][1])));
                    }
                    else if (pointsArray[index][0] > GetCoords()[0] && pointsArray[index][1] > GetCoords()[1]) // Fourth Quadrant
                    {
                        pointAngle = 90 + (180 / Math.PI) * Math.Atan(Math.Abs((GetCoords()[1] - pointsArray[index][1]) / (GetCoords()[0] - pointsArray[index][0])));
                    }
                    else if (pointsArray[index][0] < GetCoords()[0] && pointsArray[index][1] < GetCoords()[1]) // Second Quadrant
                    {
                        pointAngle = 270 + (180 / Math.PI) * Math.Atan(Math.Abs((GetCoords()[1] - pointsArray[index][1]) / (GetCoords()[0] - pointsArray[index][0])));
                    }
                    else  // Third Quadrant
                    {
                        pointAngle = 180 + (180 / Math.PI) * Math.Atan(Math.Abs((GetCoords()[0] - pointsArray[index][0]) / (GetCoords()[1] - pointsArray[index][1])));
                    }
                    double findAngle = ((pointAngle + GetAngles()[2]) % 360) * Math.PI / 180;

                    // Find Points
                    pointsArray[index][0] = Convert.ToInt32((GetCoords()[0] + hypotenuse * Math.Sin(findAngle)));
                    pointsArray[index][1] = Convert.ToInt32((GetCoords()[1] - hypotenuse * Math.Cos(findAngle)));
                }
            }
            return pointsArray;
        }

        /// <summary>
        /// Calculates where the spots with the same Y coordinate as drawnlevel 0
        /// spots would go and adds them to Data.
        /// </summary>
        /// <param name="xy">Whether searching for an X match (0) or Y match (1)</param>
        private void CalculateMatches(int xy = 1)
        {
            // Setup
            CleanseData(xy == 0 ? false : true);
            if (Data.Count < 3)
                return;
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
                if (validDrawn && spot.GetMatch(xy) == null && spot.GetCoordCombination()[xy] != minMax[3 - increase]
                    && spot.GetCoordCombination()[xy] != minMax[2 - increase])
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
                        int insertIndex = FindSymmetricalCoordHome(index, xy, coordCombo);
                        if (insertIndex != -1)
                        {
                            double[] original = FindSymmetricalOppositeCoord(Data[insertIndex].GetCoordCombination(coordCombo),
                                Data[Utilities.Modulo(insertIndex - 1, Data.Count)].GetCoordCombination(coordCombo),
                                spot.GetCoordCombination(coordCombo)[xy], xy, Data[insertIndex].Connector);

                            double rotated = FindSymmetricalOppositeCoord(Data[insertIndex].GetCoordCombination(coordRot),
                                Data[Utilities.Modulo(insertIndex - 1, Data.Count)].GetCoordCombination(coordRot),
                                original[1], 1, Data[insertIndex].Connector)[0];

                            double turned = FindSymmetricalOppositeCoord(Data[insertIndex].GetCoordCombination(2 + increase),
                                Data[Utilities.Modulo(insertIndex - 1, Data.Count)].GetCoordCombination(2 + increase),
                                original[0], 0, Data[insertIndex].Connector)[1];

                            Spot newSpot = new Spot(original[0], original[1], rotated, turned, Data[insertIndex].Connector, Data[insertIndex].Solid, drawn);
                            newSpot.SetMatch(xy, spot);
                            spot.SetMatch(xy, newSpot);
                            if (drawn == 2)
                                newSpot.CurrentX = newSpot.X;
                            Data.Insert(insertIndex, newSpot);
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
            for (int index = 0; index < Data.Count; index++)
                if (index != matchIndex && Data[index].GetCoordCombination()[xy] == Data[matchIndex].GetCoordCombination()[xy])
                    return index;

            return -1;
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
            bool bigger = false;
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
                    bigger = !bigger;
                else if (Data[searchIndex].GetCoordCombination(angle)[xy] > goal != bigger)
                    return searchIndex;

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
            if (line == Constants.connectorOptions[0] || line == Constants.connectorOptions[1])
            {
                gradient = (from[1] - to[1]) / (from[0] - to[0]);
            }
            // else if (line == Constants.connectorOptions[2])      
            //CURVE

            if (xy == 0)
                return new double[] { value, from[1] + (value - from[0]) * gradient };  // y = x * gradient
            else
                return new double[] { from[0] + (value - from[1]) / gradient, value };  // x = y / gradient
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
            if (join == Constants.connectorOptions[0] || join == Constants.connectorOptions[1])
            {
                var section = new List<double[]>();

                // If straight vertical line
                if (from[0] - to[0] == 0)
                    for (int index = (int)lower[1] + 1; index < upper[1]; index++)
                        section.Add(new double[] { from[0], index });

                // If diagonal line
                else if (from[1] - to[1] != 0)
                {
                    var gradient = (lower[1] - upper[1]) / (lower[0] - upper[0]);
                    for (int index = (int)lower[1] + 1; index < upper[1]; index++)
                        section.Add(new double[] { lower[0] + ((index - lower[1]) / gradient), index });
                }

                // Add section to line, reversing if calculated as to --> from
                if (fromUpper)
                    section.Reverse();
                line.AddRange(section);
            }
            // Curve
            else if (join == Constants.connectorOptions[2])
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
            for (int index = 0; index < Data.Count; index++)
                linesCoords.AddRange(LineCoords(Data[index].GetCoordCombination(),
                    Data[Utilities.Modulo(index + 1, Data.Count)].GetCoordCombination(), Data[index].Connector));
            return linesCoords;
        }

        /// <summary>
        /// Finds the ranges where the piece has space.
        /// </summary>
        /// <returns>double[ y, x min, x max]</returns>
        public List<double[]> LineBounds()
        {
            // Turn coords into bound ranges
            var outlineShape = CurrentPoints();
            var minMax = Utilities.FindMinMax(outlineShape);
            var ranges = new List<double[]>();
            for (int index = (int)minMax[2]; index <= (int)minMax[3]; index++)
            {
                // Get coords for the specific Y value that aren't corners
                var yMatches = new List<double[]>();
                for (int coordIndex = 0; coordIndex < outlineShape.Count; coordIndex++)
                    if (outlineShape[coordIndex][1] == index &&
                        !((outlineShape[Utilities.Modulo(coordIndex + 1, outlineShape.Count)][1] > outlineShape[coordIndex][1] &&
                            outlineShape[Utilities.Modulo(coordIndex - 1, outlineShape.Count)][1] > outlineShape[coordIndex][1]) ||
                            (outlineShape[Utilities.Modulo(coordIndex + 1, outlineShape.Count)][1] < outlineShape[coordIndex][1] &&
                            outlineShape[Utilities.Modulo(coordIndex - 1, outlineShape.Count)][1] < outlineShape[coordIndex][1])))
                        yMatches.Add(outlineShape[coordIndex]);

                // Pair Remaining Coords into Bounds
                if (yMatches.Count % 2 != 0)
                    throw new Exception("A range item is missing a matching bound.");

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
        /// Calculates generics like the shape's drawn mid and
        /// the min/max points.
        /// </summary>
        public void RunCalculations()
        {
            var convertedData = Utilities.ConvertSpotsToCoords(Data, 3);
            middle = Utilities.FindMid(convertedData);
            minMax = Utilities.FindMinMax(convertedData);
        }

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
                        Data[index].MatchX.MatchX = null;
                    if (xMatch && Data[index].MatchY != null)
                        Data[index].MatchY.MatchY = null;
                    Data.RemoveAt(index);
                    index--;
                }
            }
        }

        /// <summary>
        /// Finds how much the join has changed from its original join position.
        /// </summary>
        /// <returns>double[] { X change, Y change }</returns>
        private double[] PointChange()
        {
            var spotCoords = Join.CurrentJoinCoords(GetCoords()[0], GetCoords()[1], middle);
            var spotCoordsList = new List<double[]> { spotCoords };
            spotCoords = SpinMeRound(spotCoordsList)[0];
            return new double[] { spotCoords[0] - Join.X, spotCoords[1] - Join.Y };            
        }

        /// <summary>
        /// Reverts the piece back to its original state before animation 
        /// operations were applied.
        /// </summary>
        public void TakeOriginalState()
        {
            if (Originally != null)
            {
                X = Originally.X; Y = Originally.Y; R = Originally.R;
                T = Originally.T; S = Originally.S; SM = Originally.SM;
            }
        }
    }
}
