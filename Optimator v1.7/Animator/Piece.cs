using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        // Piece Variables
        public string Name { get; set; }
        public List<string> Data { get; set; }

        // Coords and Angles
        public double X { get; set; }
        public double Y { get; set; }
        public double R { get; set; }
        public double T { get; set; }
        public double S { get; set; }
        public double SM { get; set; }
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
        public Set PieceOf { get; set; } = null;
        // Set Ordering
        public bool InFront { get; set; } = true;
        public double AngleFlip { get; set; } = -1;

        // Scenes
        public int SceneIndex { get; set; } = -1;
        public Originals Originally { get; set; } = null;


        /// <summary>
        /// Assigns starting values to the piece variables. 
        /// Piece values stored in files are accessed.
        /// </summary>
        /// <param Name="inName">The (file) name of the piece</param>
        public Piece(string inName)
        {
            // Get Piece Data
            Name = inName;
            Data = Utilities.ReadFile(Environment.CurrentDirectory + Constants.PiecesFolder + Name + ".txt");

            // Get Points and Colours from File
            AssignValues(Data[0]);
        }


        // ----- GET FUNCTIONS -----

        /// <summary>
        /// Gets the size modifier with considerations
        /// </summary>
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
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
        public string[] GetLineArray(double r, double t)          // Type of joining line
        {
            return Data[Utilities.FindRow(r, t, Data, 1)].ToString().Split(new Char[] { ';' })[5].Split(new Char[] { ',' });
        }

        /// <summary>
        /// Finds the type, solid or float, of each point at a specified angle.
        /// </summary>
        /// <param name="r">Rotation</param>
        /// <param name="t">Turn</param>
        /// <returns>Point Type</returns>
        public string[] GetPointDataArray(double r, double t)     // Solid or float
        {
            return Data[Utilities.FindRow(r, t, Data, 1)].ToString().Split(new Char[] { ';' })[6].Split(new Char[] { ',' });
        }

        /// <summary>
        /// Finds coordinates within a row
        /// Original angle = 2, rotated angle = 3, turned angle = 4
        /// </summary>
        /// <param name="r"></param>
        /// <param name="t"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public double[,] GetAnglePoints(double r, double t, int angle)
        {
            return FindPoints(Utilities.FindRow(r, t, Data, 1), angle);
        }


        // ----- SET FUNCTIONS -----

        public void SetRotation(double inRotation)
        {
            R = inRotation % 360;
        }

        public void SetTurn(double inTurn)
        {
            T = inTurn % 360;
        }

        public void SetSpin(double inSpin)
        {
            S = inSpin % 360;
        }

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
            this.AngleFlip = angleFlip;
            X = 0;
            Y = 0;
        }



        // ----- DATA MODIFICATION -----

        public void AddDataLine(string line)
        {
            Data.Add(line);
        }

        public void ReplaceDataLine(string line)
        {
            Data.RemoveAt(Data.Count - 1);
            Data.Add(line);
        }

        public void RemoveDataLine(int index)
        {
            Data.RemoveAt(index);
        }


        // Other Functions
        /// <summary>
        /// Takes the first line of a piece's data and initialises variables accordingly
        /// </summary>
        /// <param name="inData">The first line of piece data</param>
        public void AssignValues(string inData)
        {
            string[] angleData = inData.Split(new Char[] { ';' });
            // angleData    [0] colour type     [1] colour array   [2] outline width   [3] pieceDetails

            // Colour Type
            ColourType = angleData[0];

            // Colours (Outline and Fill)
            string[] colours = angleData[1].Split(new Char[] { ':' });
            FillColour = new Color[colours.Length - 1];

            for (int index = 0; index < colours.Length; index++)
            {
                string[] rgbValues = colours[index].Split(new Char[] { ',' });

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
            NumCoords = Data[1].Split(new Char[] { ';' })[2].Count();
        }

        /// <summary>
        /// Find original, rotated or turned points
        /// </summary>
        /// <param name="row">The row in the piece data that is being searched</param>
        /// <param name="angle">2 for original, 3 for rotated, 4 for turned</param>
        /// <returns></returns>
        public double[,] FindPoints(int row, int angle)
        {
            // Find Points
            if (row != -1)
            {
                int numPoints = Data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' }).Length;
                if (numPoints > 1)
                {
                    double[,] returnPoints = new double[numPoints, 2];
                    for (int index = 0; index < numPoints; index++)
                    {
                        returnPoints[index, 0] = double.Parse(Data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' })[index].Split(new Char[] { ',' })[0]);
                        returnPoints[index, 1] = double.Parse(Data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' })[index].Split(new Char[] { ',' })[1]);
                    }
                    return returnPoints;
                }
                else if (Data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' })[0] != "")
                {
                    return new double[1, 2] { { double.Parse(Data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' })[0].Split(new Char[] { ',' })[0]), double.Parse(Data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' })[0].Split(new Char[] { ',' })[1]) } };
                }
            }
            return new double[0, 0];
        }

        /// <summary>
        /// Finds the points to print based on the rotation, turn and size of the piece
        /// </summary>
        /// <returns></returns>
        public double[,] GetCurrentPoints(Boolean recentre, Boolean spinSize)
        {
            UpdateDataInfoLine();
            int row = Utilities.FindRow(GetAngles()[0], GetAngles()[1], Data, 1);
            string dataLine = Data[row];

            // Prepare Points
            double[,] pointsArrayInitial = GetAnglePoints(GetAngles()[0], GetAngles()[1], 2);
            double[,] pointsArrayRotated = GetAnglePoints(GetAngles()[0], GetAngles()[1], 3);
            double[,] pointsArrayTurned = GetAnglePoints(GetAngles()[0], GetAngles()[1], 4);
            double[,] pointsArray = new double[NumCoords, 2];           // To be filled and returned below

            // Find Multipliers - How far into the rotation range is required
            double rotationMultiplier = (GetAngles()[0] - double.Parse(dataLine.Substring(0, 3))) / (double.Parse(dataLine.Substring(4, 3)) - double.Parse(dataLine.Substring(0, 3)));
            double turnMultiplier = (GetAngles()[1] - double.Parse(dataLine.Substring(8, 3))) / (double.Parse(dataLine.Substring(12, 3)) - double.Parse(dataLine.Substring(8, 3)));

            // Find Points
            // Rotation Adjustment
            for (int index = 0; index < NumCoords; index++)
            {
                if (double.Parse(dataLine.Substring(4, 3)) != double.Parse(dataLine.Substring(0, 3)))
                {
                    // X
                    pointsArray[index, 0] = pointsArrayInitial[index, 0] + (pointsArrayRotated[index, 0] - pointsArrayInitial[index, 0]) * rotationMultiplier;
                    // Y
                    pointsArray[index, 1] = pointsArrayInitial[index, 1] + (pointsArrayRotated[index, 1] - pointsArrayInitial[index, 1]) * rotationMultiplier;
                }
                else
                {
                    // X
                    pointsArray[index, 0] = pointsArrayInitial[index, 0];
                    // Y
                    pointsArray[index, 1] = pointsArrayInitial[index, 1];

                }
            }

            // Turn Adjustment
            for (int index = 0; index < NumCoords; index++)
            {
                if (double.Parse(dataLine.Substring(12, 3)) != double.Parse(dataLine.Substring(8, 3)))
                {
                    // X
                    pointsArray[index, 0] += (pointsArrayTurned[index, 0] - pointsArrayInitial[index, 0]) * turnMultiplier;
                    // Y
                    pointsArray[index, 1] += (pointsArrayTurned[index, 1] - pointsArrayInitial[index, 1]) * turnMultiplier;
                }
            }

            //Recentre
            pointsArray = Recentre(pointsArray, NumCoords, recentre);

            // Spin and Size Adjustment
            if (spinSize)
            {
                pointsArray = SpinMeRound(pointsArray, GetSizeMod() / 100.0);
            }
        
            //Recentre -- This was purposefully removed but has been kept for future-proofing purposes
            // When this is kept in, the piece is always exactly on centre but the spins are not smooth as the x and y coordinates
            // are adjusted by the spin rather than following it
            // This may be re-added at a later time for set compatability smoothness later, potentially with a boolean include/exclude variable
            //pointsArray = Recentre(pointsArray, numPoints, recentre);

            return pointsArray;
        }

        /// <summary>
        /// Spins the coords provided and modifies their size
        /// </summary>
        /// <param name="pointsArray">The points to be spun</param>
        /// <param name="sizeModifier">The size modifier to be applied</param>
        /// <returns></returns>
        public double[,] SpinMeRound(double[,] pointsArray, double sizeModifier)
        {
            // Spin Adjustment
            for (int index = 0; index < pointsArray.Length / 2; index++)
            {
                if (!(pointsArray[index, 0] == GetCoords()[0] && pointsArray[index, 1] == GetCoords()[1]))
                {
                    double hypotenuse = Math.Sqrt(Math.Pow(GetCoords()[0] - pointsArray[index, 0], 2) + Math.Pow(GetCoords()[1] - pointsArray[index, 1], 2)) * sizeModifier;
                    // Find Angle
                    double pointAngle;
                    if (pointsArray[index, 0] == GetCoords()[0] && pointsArray[index, 1] < GetCoords()[1])
                    {
                        pointAngle = 0;
                    }
                    else if (pointsArray[index, 0] == GetCoords()[0] && pointsArray[index, 1] > GetCoords()[1])
                    {
                        pointAngle = 180;
                    }
                    else if (pointsArray[index, 0] > GetCoords()[0] && pointsArray[index, 1] == GetCoords()[1])
                    {
                        pointAngle = 90;
                    }
                    else if (pointsArray[index, 0] < GetCoords()[0] && pointsArray[index, 1] == GetCoords()[1])
                    {
                        pointAngle = 270;
                    }
                    //  Second || First
                    //  Third  || Fourth
                    else if (pointsArray[index, 0] > GetCoords()[0] && pointsArray[index, 1] < GetCoords()[1]) // First Quadrant
                    {
                        pointAngle = (180 / Math.PI) * Math.Atan(Math.Abs(((double)GetCoords()[0] - pointsArray[index, 0]) / ((double)GetCoords()[1] - pointsArray[index, 1])));
                    }
                    else if (pointsArray[index, 0] > GetCoords()[0] && pointsArray[index, 1] > GetCoords()[1]) // Fourth Quadrant
                    {
                        pointAngle = 90 + (180 / Math.PI) * Math.Atan(Math.Abs((double)(GetCoords()[1] - pointsArray[index, 1]) / ((double)GetCoords()[0] - pointsArray[index, 0])));
                    }
                    else if (pointsArray[index, 0] < GetCoords()[0] && pointsArray[index, 1] < GetCoords()[1]) // Second Quadrant
                    {
                        pointAngle = 270 + (180 / Math.PI) * Math.Atan(Math.Abs(((double)GetCoords()[1] - pointsArray[index, 1]) / ((double)GetCoords()[0] - pointsArray[index, 0])));
                    }
                    else  // Third Quadrant
                    {
                        pointAngle = 180 + (180 / Math.PI) * Math.Atan(Math.Abs(((double)GetCoords()[0] - pointsArray[index, 0]) / ((double)GetCoords()[1] - pointsArray[index, 1])));
                    }
                    double findAngle = ((pointAngle + GetAngles()[2]) % 360) * Math.PI / 180;

                    // Find Points
                    pointsArray[index, 0] = Convert.ToInt32((GetCoords()[0] + hypotenuse * Math.Sin(findAngle)));
                    pointsArray[index, 1] = Convert.ToInt32((GetCoords()[1] - hypotenuse * Math.Cos(findAngle)));
                }
            }
            return pointsArray;
        }

        private double[,] Recentre(double[,] pointsArray, int numPoints, Boolean recentre)
        {
            double[,] holder = new double[numPoints, 2];
            holder = (double[,])pointsArray.Clone();
            for (int index = 0; index < numPoints && recentre; index++)
            {
                pointsArray[index, 0] = GetCoords()[0] + (holder[index, 0] - Utilities.FindMid(holder)[0]);
                pointsArray[index, 1] = GetCoords()[1] + (holder[index, 1] - Utilities.FindMid(holder)[1]);
            }
            return pointsArray;
        }

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

        public void TakeOriginalState()
        {
            X = Originally.GetX(); Y = Originally.GetY(); R = Originally.GetR();
            T = Originally.GetT(); S = Originally.GetS(); SM = Originally.GetSM();
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
            

            return sum;
        }
    }
}
