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
        // Initialise Piece Variables
        private string Name { get; set; }
        private readonly string folder;
        private List<string> data = new List<string>();

        private double X { get; set; }
        private double Y { get; set; }
        private double R;
        private double T;
        private double S;
        private double SM { get; set; }

        private string ColourType { get; set; }                     // Solid/Gradient colour and direction
        private string PieceDetails { get; set; }                   // Wind resistance and more
        private int OutlineWidth { get; set; }
        private Color[] FillColour { get; set; }                    // Multiple colours for gradients
        private Color OutlineColour { get; set; }

        // Sets
        private Piece attachedTo = null;
        private Piece attachPoint = null;
        private Piece ownPoint = null;
        private Boolean inFront = true;
        private double angleFlip = -1;
        private Set pieceOf = null;

        // Scenes
        private int sceneIndex = -1;
        private Originals originally = null;



        /// <summary>
        /// Assigns starting values to the piece variables. 
        /// Piece values stored in files are accessed.
        /// </summary>
        /// <param Name="inName">The (file) name of the piece</param>
        public Piece(string inName)
        {
            Name = inName;
            folder = Constants.PiecesFolder;
            data = Utilities.ReadFile(Environment.CurrentDirectory + folder + Name + ".txt");

            //Get points and colours from file
            AssignValues(data[0]);
        }


        public Piece(string inName, string customFolder)
        {
            Name = inName;
            folder = customFolder;
            data = Utilities.ReadFile(Environment.CurrentDirectory + folder + Name + ".txt");
            FillColour = new Color[1] { Color.Black };
        }


        // ----- GET FUNCTIONS -----
        public double GetSizeMod()
        {
            if (GetIsAttached())
            {
                return (SM/100.0) * (attachedTo.GetSizeMod()/100.0) * 100.0;
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
                return new double[] { X + attachedTo.GetCoords()[0] + GetPointChange()[0], Y + attachedTo.GetCoords()[1] + GetPointChange()[1] };
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
                return new double[] { (R + attachedTo.GetAngles()[0]) % 360, (T + attachedTo.GetAngles()[1]
                    + HookAngle(1)) % 360, (S + attachedTo.GetAngles()[2] + HookAngle(2)) % 360 };
            }
            return new double[] { R, T, S };
        }

        /// <summary>
        /// Returns the data of the piece so it can be saved. Used during piece creation.
        /// Also updates the first line of data; colour type, colour array, outline width and piece details to match
        /// current status.
        /// </summary>
        /// <returns>Piece data</returns>
        public List<string> GetData()
        {
            if (folder == Constants.PiecesFolder)
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
                data[0] = pieceInfo;
            }
            return data;
        }

        /// <summary>
        /// Finds whether the piece is attached to another piece
        /// </summary>
        /// <returns>If attached</returns>
        public Boolean GetIsAttached()
        {
            return attachedTo != null;
        }

        /// <summary>
        /// Finds the piece the current piece is attached to.
        /// </summary>
        /// <returns>Piece attached to</returns>
        public Piece GetAttachedTo()
        {
            return attachedTo;
        }

        public Piece GetAttachPoint()
        {
            return attachPoint;
        }

        public Piece GetOwnPoint()
        {
            return ownPoint;
        }

        /// <summary>
        /// Finds which join should be used to connect points- line, curve etc. at a specific angle.
        /// </summary>
        /// <param name="r">Rotation</param>
        /// <param name="t">Turn</param>
        /// <returns>Joins</returns>
        public string[] GetLineArray(double r, double t)          // Type of joining line
        {
            return data[FindRow(r, t)].ToString().Split(new Char[] { ';' })[5].Split(new Char[] { ',' });
        }

        /// <summary>
        /// Finds the type, solid or float, of each point at a specified angle.
        /// </summary>
        /// <param name="r">Rotation</param>
        /// <param name="t">Turn</param>
        /// <returns>Point Type</returns>
        public string[] GetPointDataArray(double r, double t)     // Solid or float
        {
            return data[FindRow(r, t)].ToString().Split(new Char[] { ';' })[6].Split(new Char[] { ',' });
        }

        public double[,] GetOriginalPoints(double r, double t)
        {
            return FindPoints(FindRow(r, t), 2);
        }

        public double[,] GetRotatedPoints(double r, double t)
        {
            return FindPoints(FindRow(r, t), 3);
        }

        public double[,] GetTurnedPoints(double r, double t)
        {
            return FindPoints(FindRow(r, t), 4);
        }

        public int GetNumPoints(double r, double t)
        {
            return GetOriginalPoints(r, t).Length / 2;
        }

        public int GetSceneIndex()
        {
            return sceneIndex;
        }

        public Set GetPieceOf()
        {
            return pieceOf;
        }

        public Originals GetOriginal()
        {
            return originally;
        }

        public Boolean GetInFront()
        {
            return inFront;
        }

        public double GetAngleFlip()
        {
            return angleFlip;
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

        public void AttachToPiece(Piece attach, Piece attachmentPoint, Piece point, Boolean front, double angleFlip)
        {
            attachedTo = attach;
            attachPoint = attachmentPoint;
            ownPoint = point;
            inFront = front;
            this.angleFlip = angleFlip;
            X = 0;
            Y = 0;
        }

        public void SetName(string inName)
        {
            Name = inName;
        }

        public void SetSceneIndex(int indexNum)
        {
            sceneIndex = indexNum;
        }

        public void SetPieceOf(Set set)
        {
            pieceOf = set;
        }

        public void SetOriginal(Originals origin)
        {
            originally = origin;
        }


        // Data Modification
        public void AddDataLine(string line)
        {
            data.Add(line);
        }

        public void ReplaceDataLine(string line)
        {
            data.RemoveAt(data.Count - 1);
            data.Add(line);
        }

        public void RemoveDataLine(int index)
        {
            data.RemoveAt(index);
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
                int numPoints = data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' }).Length;
                if (numPoints > 1)
                {
                    double[,] returnPoints = new double[numPoints, 2];
                    for (int index = 0; index < numPoints; index++)
                    {
                        returnPoints[index, 0] = double.Parse(data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' })[index].Split(new Char[] { ',' })[0]);
                        returnPoints[index, 1] = double.Parse(data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' })[index].Split(new Char[] { ',' })[1]);
                    }
                    return returnPoints;
                }
                else if (data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' })[0] != "")
                {
                    return new double[1, 2] { { double.Parse(data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' })[0].Split(new Char[] { ',' })[0]), double.Parse(data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' })[0].Split(new Char[] { ',' })[1]) } };
                }
            }
            return new double[0, 0];
        }

        /// <summary>
        /// Finds the correct row in the piece data for the given rotation and turn values
        /// </summary>
        /// <param name="r">Rotation</param>
        /// <param name="t">Turn</param>
        /// <returns>The data row holding the information for the given angles</returns>
        public int FindRow(double r, double t)
        {
            // Check rows until found
            int row = 1;
            if (folder != Constants.PiecesFolder)
            {
                row = 0;                
            }

            Boolean found = false;
            while (!found)
            {
                if (row == data.Count)
                {
                    found = true;
                    row = -1;
                }
                else
                {
                    if (r >= int.Parse(data[row].Substring(0, 3)) && r <= int.Parse(data[row].Substring(4, 3))
                        && t >= int.Parse(data[row].Substring(8, 3)) && t <= int.Parse(data[row].Substring(12, 3)))
                    {
                        found = true;
                    }
                    else
                    {
                        row++;
                    }
                }
            }
            return row;
        }


        /// <summary>
        /// Finds the points to print based on the rotation, turn and size of the piece
        /// </summary>
        /// <returns></returns>
        public double[,] GetCurrentPoints(Boolean recentre, Boolean spinSize)
        {
            // Find correct row of piece data
            int row = FindRow(GetAngles()[0], GetAngles()[1]);
            List<string> data = GetData();
            string dataLine = data[row];
            int numPoints = GetNumPoints(Convert.ToInt32(GetAngles()[0]), Convert.ToInt32(GetAngles()[1]));

            // Prepare Points
            double[,] pointsArrayInitial = GetOriginalPoints(GetAngles()[0], GetAngles()[1]);
            double[,] pointsArrayRotated = GetRotatedPoints(GetAngles()[0], GetAngles()[1]);
            double[,] pointsArrayTurned = GetTurnedPoints(GetAngles()[0], GetAngles()[1]);
            double[,] pointsArray = new double[numPoints, 2];           // To be filled and returned below

            // Find Multipliers - How far into the rotation range is required
            double rotationMultiplier = (GetAngles()[0] - double.Parse(dataLine.Substring(0, 3))) / (double.Parse(dataLine.Substring(4, 3)) - double.Parse(dataLine.Substring(0, 3)));
            double turnMultiplier = (GetAngles()[1] - double.Parse(dataLine.Substring(8, 3))) / (double.Parse(dataLine.Substring(12, 3)) - double.Parse(dataLine.Substring(8, 3)));

            // Find Points
            // Rotation Adjustment
            for (int index = 0; index < numPoints; index++)
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
            for (int index = 0; index < numPoints; index++)
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
            pointsArray = Recentre(pointsArray, numPoints, recentre);

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
                attachPoint.SetValues(Constants.MidX, Constants.MidY, attachedTo.GetAngles()[0],
                    attachedTo.GetAngles()[1], attachedTo.GetAngles()[2], attachedTo.GetSizeMod());
                ownPoint.SetValues(Constants.MidX, Constants.MidY, GetAngles()[0], GetAngles()[1], GetAngles()[2], GetSizeMod());

                double[,] baseCoords = attachPoint.GetCurrentPoints(false, true);
                double[,] thisCoords = ownPoint.GetCurrentPoints(false, true);

                return new double[] { baseCoords[0, 0] - thisCoords[0, 0], baseCoords[0, 1] - thisCoords[0, 1] };
            }
        }

        public void TakeOriginalState()
        {
            X = originally.GetX();
            Y = originally.GetY();
            R = originally.GetR();
            T = originally.GetT();
            S = originally.GetS();
            SM = originally.GetSM();
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
            double getR = (R + attachedTo.GetAngles()[0]) % 360;
            double getT = (T + attachedTo.GetAngles()[1]) % 360;
            double getS = (S + attachedTo.GetAngles()[2]) % 360;

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
