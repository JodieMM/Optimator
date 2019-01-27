using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

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
        public List<DataRow> Data { get; set; } = new List<DataRow>();
        public bool Recentre { get; set; } = true;

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

        // Sets         //TODO: Remove excess
        public Piece AttachedTo { get; set; } = null;
        public Join AttachPoint { get; set; } = null;
        public Join OwnPoint { get; set; } = null;
        public Set PieceOf { get; set; } = null;
        public List<Join> Joins { get; set; } = new List<Join>();
        // Set Ordering
        public bool InFront { get; set; } = true;
        public double AngleFlip { get; set; } = -1;

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
            for (int index = 1; index < data.Count; index++)
            {
                Data.Add(new DataRow(data[index]));
            }
        }

        /// <summary>
        /// Piece constructor used when developing a
        /// piece for the first time.
        /// </summary>
        public Piece()
        {
            Name = Constants.WIPName;
            Recentre = false;
            ColourType = Constants.fillOptions[0];
            FillColour = new Color[] { Constants.defaultFill };
            OutlineColour = Constants.defaultOutline;
            OutlineWidth = Constants.defaultOutlineWidth;
            PieceDetails = Constants.defaultPieceDetails;
        }



        // ----- GET FUNCTIONS -----
        #region Get Functions
       
        /// <summary>
        /// Gets the size modifier with considerations
        /// </summary>
        /// <returns>Size Modifier</returns>
        public double GetSizeMod()
        {
            if (GetIsAttached())
            {
                return (SM/100.0) * (AttachedTo.GetSizeMod()/100.0) * 100.0;
            }
            return SM;
        }

        /// <summary>
        /// Gets the X and Y values of the piece with considerations
        /// </summary>
        /// <returns>double[] { X, Y }</returns>
        public double[] GetCoords()
        {
            if (GetIsAttached())
            {
                return new double[] { X + AttachedTo.GetCoords()[0] + GetPointChange()[0], Y + AttachedTo.GetCoords()[1] + GetPointChange()[1] };
            }
            return new double[] { X, Y };
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
            angles[1] = T + S * Math.Sin(Utilities.ToRad(R));
            angles[2] = S * Math.Cos(Utilities.ToRad(R)); // + S * Math.Cos(Utilities.ToRad(T));

            // Build Off Attached
            if (GetIsAttached())
            {
                angles[0] += AttachedTo.GetAngles()[0];
                angles[1] += AttachedTo.GetAngles()[1];
                angles[2] += AttachedTo.GetAngles()[2];
            }

            // Modulus of 360 degrees
            angles[0] = Utilities.Modulo(angles[0], 360);
            angles[1] = Utilities.Modulo(angles[1], 360);
            angles[2] = Utilities.Modulo(angles[2], 360);
            return angles;
        }

        /// <summary>
        /// Finds whether the piece is attached to another piece
        /// </summary>
        /// <returns>If attached</returns>
        public bool GetIsAttached()
        {
            return AttachedTo != null;
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
            {
                pieceInfo += col.A + "," + col.R + "," + col.G + "," + col.B + ":";
            }
            pieceInfo = pieceInfo.Remove(pieceInfo.Length - 1, 1) + ";" + OutlineWidth + ";" + PieceDetails;
            newData.Add(pieceInfo);

            // Add DataRows
            foreach (DataRow row in Data)
            {
                newData.Add(row.ToString());
            }
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
        /// Attaches this piece to another, forming or continuing a set
        /// </summary>
        /// <param name="attach">The piece being attached to</param>
        /// <param name="attachmentPoint">The point of the attaching piece</param>
        /// <param name="point">The point of the current piece</param>
        /// <param name="front">Whether this piece goes in front of the other</param>
        /// <param name="angleFlip">The angle when front is changed</param>
        public void AttachToPiece(Piece attach, Join attachmentPoint, Join point, bool front, double angleFlip)
        {
            AttachedTo = attach;
            AttachPoint = attachmentPoint;
            OwnPoint = point;
            InFront = front;
            AngleFlip = angleFlip;
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Finds all of the points that connect to this piece.
        /// </summary>
        public void FindJoins()
        {
            string directory = Utilities.GetDirectory(Constants.JoinsFolder, Name);
            if (Directory.Exists(directory))
            {
                string[] fileArray = Directory.GetFiles(directory, "*.txt");
                foreach (string file in fileArray)
                {
                    string fileName = Path.GetFileName(file);
                    Joins.Add(new Join(fileName.Substring(0, fileName.Length - 4), this));
                }
            }
        }

        #endregion



        // ----- OTHER FUNCTIONS -----

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
        public override void Draw(Graphics g)
        {
            Visuals.DrawPiece(this, g);
        }

        /// <summary>
        /// Finds the correct row in the piece data for the given rotation and turn values.
        /// </summary>
        /// <returns>The index of the DataRow relevant to the provided angles or -1 if not found</returns>
        public int FindRow()
        {
            double r = GetAngles()[0];
            double t = GetAngles()[1];
            for (int index = 0; index < Data.Count; index++)
            {
                if (Data[index].IsWithin(r, t) && Data[index].Spots.Count > 0)
                {
                    return index;
                }
            }
            return -1;
        }

        /// <summary>
        /// Finds the points to print based on the rotation, turn, spin and size of the piece
        /// </summary>
        /// <returns></returns>
        public List<double[]> GetCurrentPoints()
        {
            // Prepare Variables
            int row = FindRow();
            if (row == -1) { return null; }
            DataRow dataRow = Data[row];
            List<Spot> spts = dataRow.Spots;
            List<double[]> currentPoints = new List<double[]>();

            // Find Multipliers - How far into the rotation range is required
            double rotationMultiplier = (GetAngles()[0] - dataRow.RotFrom) / (dataRow.RotTo - dataRow.RotFrom);
            double turnMultiplier = (GetAngles()[1] - dataRow.TurnFrom) / (dataRow.TurnTo - dataRow.TurnFrom);

            // Rotation Adjustment
            foreach (Spot spt in spts)
            {
                if (dataRow.RotTo != dataRow.RotFrom)
                {
                    currentPoints.Add(new double[] { spt.X + (spt.XRight - spt.X) * rotationMultiplier, spt.Y });
                }
                else
                {
                    currentPoints.Add(new double[] { spt.X, spt.Y });
                }
            }

            // Turn Adjustment
            for (int index = 0; index < spts.Count; index++)
            {
                if (dataRow.TurnTo != dataRow.TurnFrom)
                {
                    currentPoints[index][1] += (spts[index].YDown - spts[index].Y) * turnMultiplier;
                }
            }

            // Recentre
            if (Recentre)
            {
                double[] middle = Utilities.FindMid(currentPoints);
                for (int index = 0; index < spts.Count; index++)
                {
                    currentPoints[index][0] = GetCoords()[0] + (currentPoints[index][0] - middle[0]);
                    currentPoints[index][1] = GetCoords()[1] + (currentPoints[index][1] - middle[1]);
                }
            }

            // Spin and Size Adjustment
            currentPoints = SpinMeRound(currentPoints, GetSizeMod() / 100.0);

            return currentPoints;
        }

        /// <summary>
        /// Spins the coords provided and modifies their size.
        /// </summary>
        /// <param name="pointsArray">The points to be spun</param>
        /// <param name="sizeModifier">The size modifier to be applied</param>
        /// <returns></returns>
        public List<double[]> SpinMeRound(List<double[]> pointsArray, double sizeModifier)
        {
            // Spin Adjustment
            for (int index = 0; index < pointsArray.Count; index++)
            {
                if (!(pointsArray[index][0] == GetCoords()[0] && pointsArray[index][1] == GetCoords()[1]))
                {
                    double hypotenuse = Math.Sqrt(Math.Pow(GetCoords()[0] - pointsArray[index][0], 2) + Math.Pow(GetCoords()[1] - pointsArray[index][1], 2)) * sizeModifier;
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
        /// Finds how much the point has changed from its attached to piece.
        /// </summary>
        /// <returns>double[] { X change, Y change }</returns>
        private double[] GetPointChange()
        {
            if (!GetIsAttached()) { return new double[] { 0, 0 }; }
            double[] baseCoords = AttachPoint.GetCurrentPoints(Constants.MidX, Constants.MidY);
            double[] thisCoords = OwnPoint.GetCurrentPoints(Constants.MidX, Constants.MidY);
            return new double[] { baseCoords[0] - thisCoords[0], baseCoords[1] - thisCoords[1] };
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
