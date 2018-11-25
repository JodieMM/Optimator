using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Animator
{
    /// <summary>
    /// A class to hold information about each piece.
    /// A piece is an object that cannot be seperated further.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class Piece
    {
        #region Piece Variables
        public string Name { get; set; }
        public List<string> Data { get; set; }

        // Coords and Angles
        public double X { get; set; } //= Constants.MidX;
        public double Y { get; set; } //= Constants.MidY;
        public double R { get; set; } = 0;
        public double T { get; set; } = 0;
        public double S { get; set; } = 0;
        public double SM { get; set; } = 100;
        public int NumCoords { get; set; }

        // Colours and Details
        public string ColourType { get; set; }                     // Solid/Gradient colour and direction
        public Color[] FillColour { get; set; }                    // Multiple colours for gradients
        public Color OutlineColour { get; set; }
        public int OutlineWidth { get; set; }
        public string PieceDetails { get; set; }                   // Wind resistance and more

        // Sets
        public Piece AttachedTo { get; set; } = null;
        public PointSpot AttachPoint { get; set; } = null;
        public PointSpot OwnPoint { get; set; } = null;
        public Set PieceOf { get; set; }
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
            Data = Utilities.ReadFile(Utilities.GetDirectory(Constants.PiecesFolder, Name));

            // Get Points and Colours from File
            AssignValues(Data[0]);
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
            if (GetIsAttached())
            {
                return new double[] { (R + AttachedTo.GetAngles()[0]) % 360, (T + AttachedTo.GetAngles()[1]
                    + HookAngle(1)) % 360, (S + AttachedTo.GetAngles()[2] + HookAngle(2)) % 360 };
            }
            return new double[] { R, T, S };
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
            string[] lineArray = Data[Utilities.FindRow(r, t, Data, 1)].ToString().Split(Constants.Semi)[5].Split(Constants.Comma);
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
            string[] detailsArray = Data[Utilities.FindRow(r, t, Data, 1)].ToString().Split(Constants.Semi)[6].Split(Constants.Comma);
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
        /// Sets the rotation within a 360 degree boundary.
        /// </summary>
        /// <param name="inRotation"></param>
        public void SetRotation(double inRotation)
        {
            R = inRotation % 360;
        }

        /// <summary>
        /// Sets the turn within a 360 degree boundary.
        /// </summary>
        /// <param name="inTurn"></param>
        public void SetTurn(double inTurn)
        {
            T = inTurn % 360;
        }

        /// <summary>
        /// Sets the spin within a 360 degree boundary.
        /// </summary>
        /// <param name="inSpin"></param>
        public void SetSpin(double inSpin)
        {
            S = inSpin % 360;
        }

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
        public void AttachToPiece(Piece attach, PointSpot attachmentPoint, PointSpot point, bool front, double angleFlip)
        {
            AttachedTo = attach;
            AttachPoint = attachmentPoint;
            OwnPoint = point;
            InFront = front;
            AngleFlip = angleFlip;
            X = 0;
            Y = 0;
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
            int row = Utilities.FindRow(rot, turn, Data, 1);
            if (row != -1)
            {
                Data[row] = newLine;
            }
            else
            {
                Data.Add(newLine);
            }

            CalculateNumCoords();
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
            Data[0] = pieceInfo;
        }



        // ----- OTHER FUNCTIONS -----

        /// <summary>
        /// Takes the first line of a piece's data and initialises variables accordingly.
        /// Used in piece constructor.
        /// </summary>
        /// <param name="inData">The first line of piece data</param>
        public void AssignValues(string inData)
        {
            string[] angleData = inData.Split(Constants.Semi);
            // angleData    [0] colour type     [1] colour array   [2] outline width   [3] pieceDetails

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

            // Get Num Points
            CalculateNumCoords();
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
            int row = Utilities.FindRow(r, t, Data, 1);
            List<double[]> returnPoints = new List<double[]>();
            string[] angleLine = Data[row].Split(Constants.Semi)[angle].Split(Constants.Colon);

            // Find Points
            if (row != -1 && NumCoords > 0)
            {
                for (int index = 0; index < NumCoords && angleLine[0] != ""; index++)
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
            int row = Utilities.FindRow(GetAngles()[0], GetAngles()[1], Data, 1);
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
            for (int index = 0; index < NumCoords; index++)
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
            for (int index = 0; index < NumCoords; index++)
            {
                if (double.Parse(dataLine.Substring(12, 3)) != double.Parse(dataLine.Substring(8, 3)))
                {
                    // X
                    pointsArray[index][0] += (pointsArrayTurned[index][0] - pointsArrayInitial[index][0]) * turnMultiplier;
                    // Y
                    pointsArray[index][1] += (pointsArrayTurned[index][1] - pointsArrayInitial[index][1]) * turnMultiplier;
                }
            }

            //Recentre
            if (recentre)
            {
                double middleX = Utilities.FindMid(pointsArray)[0];
                double middleY = Utilities.FindMid(pointsArray)[1];

                for (int index = 0; index < NumCoords; index++)
                {
                    pointsArray[index][0] = GetCoords()[0] + (pointsArray[index][0] - middleX);
                    pointsArray[index][1] = GetCoords()[1] + (pointsArray[index][1] - middleY);
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
            if (!GetIsAttached())
            {
                return new double[] { 0, 0 };
            }
            else
            {
                AttachPoint.X = Constants.MidX; AttachPoint.Y = Constants.MidY;
                OwnPoint.X = Constants.MidX; OwnPoint.Y = Constants.MidY;

                double[,] baseCoords = AttachPoint.GetCurrentPoints();
                double[,] thisCoords = OwnPoint.GetCurrentPoints();

                return new double[] { baseCoords[0, 0] - thisCoords[0, 0], baseCoords[0, 1] - thisCoords[0, 1] };
            }
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

        /// <summary>
        /// Finds how being at a different angle to the connected piece alters r/t/s
        /// Should only run if piece has been confirmed connected
        /// </summary>
        /// <param name="angle">The angle type; 0 = r, 1 = t, 2 = s</param>
        /// <returns>The amount the provided angle needs to be modified by</returns>
        private double HookAngle(int angle)
        {
            return 0;
            // TEMP ABOVE
            /*
            double sum = 0;
            double getR = (R + AttachedTo.GetAngles()[0]) % 360;
            double getT = (T + AttachedTo.GetAngles()[1]) % 360;
            double getS = (S + AttachedTo.GetAngles()[2]) % 360;

            if (angle == 0 && (T != 0 || S != 0))                     // Rotation
            {

            }
            else if (angle == 1 && (R != 0 || S != 0))             // Turn
            {
                if (S % 180 != 0)    // Spin Changed
                {
                    // ROTATION
                    // Exact quadrants && one value is 0
                    if (getR % 90 == 0)
                    {
                        if (getR == 90)
                        {
                            sum += S;
                        }
                        else if (getR == 270)
                        {
                            sum -= S;
                        }
                    }
                    // Rounded Sections
                    else
                    {
                        if (getR < 90)
                        {
                            sum += getR / 90 * S;
                        }
                        else if (getR < 180)
                        {
                            sum += (getR - 90) / 90 * (1 / S);
                        }
                        else if (getR < 270)
                        {
                            sum -= (getR - 180) / 90 * S;
                        }
                        else
                        {
                            sum -= (getR - 270) / 90 * (1 / S);
                        }
                    }

                    // TURN
                }
            }
            else if (angle == 2 && (R != 0 || T != 0))      // Spin
            {
                if (S % 180 != 0)    // Spin Changed
                {
                    // ROTATION
                    // Exact quadrants && one value is 0
                    if (getR % 90 == 0)
                    {
                        if (getR == 0)
                        {
                            sum += T;
                        }
                        else if (getR == 180)
                        {
                            sum -= T;
                        }
                    }
                    // Rounded Sections
                    else
                    {
                        if (getR < 90)
                        {
                            sum += getR / 90 * T;
                        }
                        else if (getR < 180)
                        {
                            sum += (getR - 90) / 90 * (1 / T);
                        }
                        else if (getR < 270)
                        {
                            sum -= (getR - 180) / 90 * T;
                        }
                        else
                        {
                            sum -= (getR - 270) / 90 * (1 / T);
                        }
                    }
                }
            }
            

            return sum;*/
        }

        /// <summary>
        /// Finds the number of points in the piece.
        /// </summary>
        private void CalculateNumCoords()
        {
            if (Data.Count < 2)
            {
                NumCoords = 0;
            }
            else
            {
                NumCoords = Data[1].Split(Constants.Semi)[2].Split(Constants.Colon).Count();
            }
        }
    }
}
