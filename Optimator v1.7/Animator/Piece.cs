using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

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
        public override List<string> Data { get; set; }
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
            Data = Utilities.ReadFile(Utilities.GetDirectory(Constants.PiecesFolder, Name, Constants.Txt));

            // Get Points and Colours from File
            string[] angleData = Data[0].Split(Constants.Semi);

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
            Data = new List<string>();
            UpdateDataInfoLine();
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
        /// Finds which join should be used to connect points- line, curve etc. at a specific angle.
        /// </summary>
        /// <param name="r">Rotation</param>
        /// <param name="t">Turn</param>
        /// <returns>Joins</returns>
        public List<string> GetLineArray(double r, double t)
        {
            List<string> joins = new List<string>();
            string[] lineArray = Data[Utilities.FindRow(r, t, Data, 2)].ToString().Split(Constants.Semi)[5].Split(Constants.Comma);
            foreach (string join in lineArray)
            {
                joins.Add(join);
            }
            return joins;
        }

        /// <summary>
        /// Finds the type, solid or float, of each point at a specified angle.
        /// </summary>
        /// <param name="r">Rotation</param>
        /// <param name="t">Turn</param>
        /// <returns>Point Type</returns>
        public List<string> GetPointDataArray(double r, double t)
        {
            List<string> details = new List<string>();
            string[] detailsArray = Data[Utilities.FindRow(r, t, Data, 2)].ToString().Split(Constants.Semi)[6].Split(Constants.Comma);
            foreach (string detail in detailsArray)
            {
                details.Add(detail);
            }
            return details;
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



        // ----- DATA MODIFICATION -----

        /// <summary>
        /// Replaces the data for the piece at the given angle. Used when creating the piece.
        /// Adds a new data line if the current data does not exist.
        /// </summary>
        /// <param name="rot">Rotation to update</param>
        /// <param name="turn">Turn to update</param>
        /// <param name="newLine">Replacement data</param>
        public void UpdateDataLine(double rot, double turn, string newLine)
        {
            int row = Utilities.FindRow(rot, turn, Data, 2);
            if (row != -1)
            {
                Data[row] = newLine;
            }
            else
            {
                Data.Add(newLine);
            }
        }

        /// <summary>
        /// Updates the first line of data; colour type, colour array, outline width and piece details to match
        /// current status. Used during piece creation.
        /// </summary>
        public void UpdateDataInfoLine()
        {
            // Update first line of data            [0] colour type     [1] colour array        [2] outline width       [3] pieceDetails
            string pieceInfo = ColourType + ";" + OutlineColour.A + "," + OutlineColour.R + "," + OutlineColour.G + "," + OutlineColour.B + ":";
            if (FillColour != null)
            {
                foreach (Color col in FillColour)
                {
                    pieceInfo += col.A + "," + col.R + "," + col.G + "," + col.B + ":";
                }
            }
            pieceInfo = pieceInfo.Remove(pieceInfo.Length - 1, 1) + ";" + OutlineWidth + ";" + PieceDetails;
            if (Data.Count < 1)
            {
                Data.Add(pieceInfo);
            }
            else
            {
                Data[0] = pieceInfo;
            }
        }

        /// <summary>
        /// Updates the second line of data to display whether a spot is piece-defining
        /// or added through refinement. Used when re-loading a piece for modification.
        /// </summary>
        /// <param name="spots">The list of spots to define</param>
        public void UpdateDataSpotTypes(List<Spot> spots)
        {
            string dataSpotTypes = "";
            foreach (Spot spot in spots)
            {
                dataSpotTypes += spot.DrawnLevel + Constants.SemiS;
            }
            dataSpotTypes.Remove(dataSpotTypes.Length - 1);
            Data[1] = dataSpotTypes;
        }



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
        /// Draws the piece to the provided graphics.
        /// </summary>
        /// <param name="g">Provided graphics</param>
        public override void Draw(Graphics g)
        {
            Visuals.DrawPiece(this, g, Recentre);
        }

        /// <summary>
        /// Finds coordinates within a row.
        /// Original angle = 2, rotated angle = 3, turned angle = 4
        /// </summary>
        /// <param name="r">The rotation to be searched</param>
        /// <param name="t">The turn to be searched</param>
        /// <param name="angle">Original, rotated or turned perspective</param>
        /// <returns>A list of coordinates for that angle</returns>
        public List<double[]> FindPoints(double r, double t, int angle)
        {
            int row = Utilities.FindRow(r, t, Data, 2);
            if (row == -1) { return null; }
            List<double[]> returnPoints = new List<double[]>();
            string[] angleLine = Data[row].Split(Constants.Semi)[angle].Split(Constants.Colon);
            int numCoords = angleLine.Count();

            // Find Points
            if (row != -1 && numCoords > 0)
            {
                for (int index = 0; index < numCoords && angleLine[0] != ""; index++)
                {
                    returnPoints.Add(new double[] { double.Parse(angleLine[index].Split(Constants.Comma)[0]),
                    double.Parse(angleLine[index].Split(Constants.Comma)[1]) });
                }
                return returnPoints;
            }
            return null;
        }

        /// <summary>
        /// Finds the points to print based on the rotation, turn, spin and size of the piece
        /// </summary>
        /// <returns></returns>
        public List<double[]> GetCurrentPoints(bool recentre)
        {
            int row = Utilities.FindRow(GetAngles()[0], GetAngles()[1], Data, 2);
            if (row == -1) { return null; }
            string dataLine = Data[row];

            // Prepare Points
            List<double[]> pointsArrayInitial = FindPoints(GetAngles()[0], GetAngles()[1], 2);
            List<double[]> pointsArrayRotated = FindPoints(GetAngles()[0], GetAngles()[1], 3);
            List<double[]> pointsArrayTurned = FindPoints(GetAngles()[0], GetAngles()[1], 4);
            List<double[]> pointsArray = new List<double[]>();

            // Find Multipliers - How far into the rotation range is required
            double rotationMultiplier = (GetAngles()[0] - double.Parse(dataLine.Substring(0, 3))) / (double.Parse(dataLine.Substring(4, 3)) - double.Parse(dataLine.Substring(0, 3)));
            double turnMultiplier = (GetAngles()[1] - double.Parse(dataLine.Substring(8, 3))) / (double.Parse(dataLine.Substring(12, 3)) - double.Parse(dataLine.Substring(8, 3)));

            // FIND POINTS
            // Rotation Adjustment
            for (int index = 0; index < pointsArrayRotated.Count; index++)
            {
                if (double.Parse(dataLine.Substring(4, 3)) != double.Parse(dataLine.Substring(0, 3)))
                {
                    pointsArray.Add(new double[] { pointsArrayInitial[index][0] + (pointsArrayRotated[index][0] - pointsArrayInitial[index][0]) * rotationMultiplier,
                        pointsArrayInitial[index][1] + (pointsArrayRotated[index][1] - pointsArrayInitial[index][1]) * rotationMultiplier });
                }
                else
                {
                    pointsArray.Add(pointsArrayInitial[index]);
                }
            }

            // Turn Adjustment
            for (int index = 0; index < pointsArrayTurned.Count; index++)
            {
                if (double.Parse(dataLine.Substring(12, 3)) != double.Parse(dataLine.Substring(8, 3)))
                {
                    // X
                    pointsArray[index][0] += (pointsArrayTurned[index][0] - pointsArrayInitial[index][0]) * turnMultiplier;
                    // Y
                    pointsArray[index][1] += (pointsArrayTurned[index][1] - pointsArrayInitial[index][1]) * turnMultiplier;
                }
            }

            // Recentre
            if (recentre)
            {
                double[] middle = Utilities.FindMid(pointsArray);
                for (int index = 0; index < pointsArrayInitial.Count; index++)
                {
                    pointsArray[index][0] = GetCoords()[0] + (pointsArray[index][0] - middle[0]);
                    pointsArray[index][1] = GetCoords()[1] + (pointsArray[index][1] - middle[1]);
                }
            }

            // Spin and Size Adjustment
            pointsArray = SpinMeRound(pointsArray, GetSizeMod() / 100.0);

            return pointsArray;
        }

        /// <summary>
        /// Spins the coords provided and modifies their size
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
