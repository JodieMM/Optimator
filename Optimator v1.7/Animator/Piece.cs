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
        public List<Spot> Data { get; set; } = new List<Spot>();

        // Coords and Angles
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public double R { get; set; } = 0;
        public double T { get; set; } = 0;
        public double S { get; set; } = 0;
        public double SM { get; set; } = 100;
        private readonly double[] middle;

        // Colours and Details
        public string ColourType { get; set; }                     // Solid/Gradient colour and direction
        public Color[] FillColour { get; set; }                    // Multiple colours for gradients
        public Color OutlineColour { get; set; }
        public decimal OutlineWidth { get; set; }
        public string PieceDetails { get; set; }                   // Wind resistance and more

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

            // Get Points and Colours from File
            string[] angleData = data[0].Split(Constants.Semi);

            // Colour Type
            ColourType = angleData[0];

            // Colours (Outline and Fill)
            string[] colours = angleData[1].Split(Constants.Colon);
            FillColour = new Color[colours.Length - 1];
            for (int index = 0; index < colours.Length; index++)
            {
                string[] rgbValues = colours[index].Split(Constants.Comma);
                if (index == 0)
                {
                    OutlineColour = Color.FromArgb(int.Parse(rgbValues[0]), int.Parse(rgbValues[1]), int.Parse(rgbValues[2]), int.Parse(rgbValues[3]));
                }
                else
                {
                    FillColour[index - 1] = Color.FromArgb(int.Parse(rgbValues[0]), int.Parse(rgbValues[1]), int.Parse(rgbValues[2]), int.Parse(rgbValues[3]));
                }
            }

            // Outline Width
            OutlineWidth = int.Parse(angleData[2]);

            // Piece Details
            PieceDetails = angleData[3];

            // Spots
            List<double[]> currentPoints = new List<double[]>();
            for (int index = 1; index < data.Count; index++)
            {
                string[] spotData = data[index].Split(Constants.Semi);
                string[] coords = spotData[0].Split(Constants.Colon);

                Data.Add(new Spot(double.Parse(coords[0]), double.Parse(coords[1]), double.Parse(coords[2]),
                    double.Parse(coords[3]), spotData[1], spotData[2]));
                currentPoints.Add(Data[Data.Count - 1].GetCoordCombination(0));
            }
            middle = Utilities.FindMid(currentPoints);
        }

        /// <summary>
        /// Piece constructor used when developing a
        /// piece for the first time.
        /// </summary>
        public Piece()
        {
            Name = Constants.WIPName;
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
            List<string> newData = new List<string>();

            // Update first line of data            [0] colour type     [1] colour array        [2] outline width       [3] pieceDetails
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

        /// <summary>
        /// Finds the points to print based on the rotation, turn, spin and size of the piece
        /// </summary>
        /// <returns></returns>
        public List<double[]> CurrentPoints()
        {
            var coordsY = new List<double[]>();
            for (int index = 0; index < Data.Count; index++)
                coordsY.AddRange(LineCoords(Data[index].GetCoordCombination(0),
                    Data[(index + 1) % Data.Count].GetCoordCombination(0), Data[index].Connector));


            // Put in X matches
            // Move X direction
            // Put in Y matches (for all)
            // Move Y direction (returning final coords)




            //// Get Current Spot Coords
            //var currentPoints = new List<double[]>();
            //foreach (Spot spot in Data)
            //    currentPoints.Add(spot.GetCurrentCoords(GetAngles()[0], GetAngles()[1], middle));

            //// Recentre
            //for (int index = 0; index < currentPoints.Count; index++)
            //{
            //    currentPoints[index][0] = GetCoords()[0] + (currentPoints[index][0] - middle[0]);
            //    currentPoints[index][1] = GetCoords()[1] + (currentPoints[index][1] - middle[1]);
            //}

            //// Spin and Size Adjustment
            //currentPoints = SpinMeRound(currentPoints);

            //return currentPoints;
            return coordsY;
        }

        /// <summary>
        /// Spins the coords provided and modifies their size.
        /// </summary>
        /// <param name="pointsArray">The points to be spun</param>
        /// <returns></returns>
        public List<double[]> SpinMeRound(List<double[]> pointsArray)
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
        /// Finds all of the coordinates between two points.
        /// Focuses on a Y-across system.
        /// </summary>
        /// <param name="from">The starting point</param>
        /// <param name="to">The end point</param>
        /// <param name="join">How the two points are connected</param>
        /// <returns>A list of double[ x, (int)y ] with the point coords</returns>
        public List<double[]> LineCoords(double[] from, double[] to, string join)
        {
            var line = new List<double[]> { from };
            double[] lower = from[1] >= to[1] ? to : from;
            double[] upper = from[1] >= to[1] ? from : to;

            // Solid Line
            if (join == Constants.connectorOptions[0] || join == Constants.connectorOptions[1])
            {
                // If straight vertical line
                if (from[0] - to[0] == 0)
                    for (int index = (int)lower[1] + 1; index < upper[1]; index++)
                        line.Add(new double[] { from[0], index });

                // If diagonal line
                else if(from[1] - to[1] != 0)
                {
                    var gradient = (lower[1] - upper[1]) / (lower[0] - upper[0]);
                    for (int index = (int)lower[1] + 1; index < upper[1]; index++)
                        line.Add(new double[] { lower[0] + ((index - lower[1]) / gradient), index });
                }
            }
            // Curve
            else if (join == Constants.connectorOptions[2])
            {
            }
            return line;
        }

        /// <summary>
        /// Finds the ranges where the piece has space.
        /// </summary>
        /// <returns>double[ y, x min, x max]</returns>
        public List<double[]> LineBounds()
        {
            var coordsY = new List<double[]>();
            for (int index = 0; index < Data.Count; index++)
                coordsY.AddRange(LineCoords(Data[index].GetCoordCombination(0),
                    Data[(index + 1) % Data.Count].GetCoordCombination(0), Data[index].Connector));

            var minMax = Utilities.FindMinMax(coordsY);
            var ranges = new List<double[]>();
            for (int index = (int)minMax[2]; index <= (int)minMax[3]; index++)
            {
                // Find all coords with that y = index
                // Create relevant bound(s)
                // Repeat
            }

            return ranges;
        }



        // ----- OTHER FUNCTIONS -----

        /// <summary>
        /// Finds how much the join has changed from its original join position.
        /// </summary>
        /// <returns>double[] { X change, Y change }</returns>
        private double[] PointChange()
        {
            var spotCoords = Join.GetCurrentCoords(GetCoords()[0], GetCoords()[1], middle);
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
