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
        public string name;
        public string folder;
        public List<string> data = new List<string>();

        public double x = 500;
        public double y = 250;
        public double rotation = 0;
        public double turn = 0;
        public double spin = 0;
        public double sizeMod = 100;

        private string colourType, pieceDetails;                  // File name, solid/gradient colour and direction, wind etc.
        private int outlineWidth;
        private Color[] fillColour;                               // Range of colours (single for solid, multiple for gradient)
        private Color outlineColour;

        private const string piecesFolder = "\\Pieces\\";
        private const double midX = 500;
        private const double midY = 250;

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
        /// <param name="inName">The (file) name of the piece</param>
        public Piece(string inName)
        {
            name = inName;
            folder = piecesFolder;
            data = Utilities.ReadFile(Environment.CurrentDirectory + folder + name + ".txt");

            //Get points and colours from file
            AssignValues(data[0]);
        }


        public Piece(string inName, string customFolder)
        {
            name = inName;
            folder = customFolder;
            data = Utilities.ReadFile(Environment.CurrentDirectory + folder + name + ".txt");
            fillColour = new Color[1] { Color.Black };
        }


        // Get Functions

        public string GetName()
        {
            return name;
        }

        public double GetSizeMod()
        {
            if (GetIsAttached())
            {
                return (sizeMod/100.0) * (attachedTo.GetSizeMod()/100.0) * 100.0;
            }
            return sizeMod;
        }

        public double[] GetCoords()
        {
            if (GetIsAttached())
            {
                return new double[] { x + attachedTo.GetCoords()[0] + GetPointChange()[0], y + attachedTo.GetCoords()[1] + GetPointChange()[1] };
            }
            return new double[] { x, y };
        }


        /// <summary>
        /// Gets the x, y, rotation, turn, spin and sizemod value as they are regardless of whether the piece is attached.
        /// </summary>
        /// <returns>Stored X, Y, R, T, S and SM values</returns>
        public double[] GetActualValues()
        {
            return new double[] { x, y, rotation, turn, spin, sizeMod };
        }

        public double[] GetAngles()
        {
            if (GetIsAttached())
            {
                return new double[] { (rotation + attachedTo.GetAngles()[0]) % 360, (turn + attachedTo.GetAngles()[1]
                    + HookAngle(1)) % 360, (spin + attachedTo.GetAngles()[2] + HookAngle(2)) % 360 };
            }
            return new double[] { rotation, turn, spin };
        }


        /// <summary>
        /// Returns the data of the piece so it can be saved. Used during piece creation.
        /// Also updates the first line of data; colour type, colour array, outline width and piece details to match
        /// current status.
        /// </summary>
        /// <returns>Piece data</returns>
        public List<string> GetData()
        {
            if (folder == piecesFolder)
            {
                // Update first line of data            [0] colour type     [1] colour array        [2] outline width       [3] pieceDetails
                string pieceInfo = colourType + ";" + outlineColour.A + "," + outlineColour.R + "," + outlineColour.G + "," + outlineColour.B + ":";
                if (fillColour != null)
                {
                    foreach (Color col in fillColour)
                    {
                        pieceInfo += col.A + "," + col.R + "," + col.G + "," + col.B + ":";
                    }
                }
                pieceInfo = pieceInfo.Remove(pieceInfo.Length - 1, 1) + ";" + outlineWidth + ";" + pieceDetails;
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
            if (attachedTo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        /// Finds the fill or gradient type.
        /// </summary>
        /// <returns>String code of colour type</returns>
        public string GetColourType()
        {
            return colourType;
        }

        /// <summary>
        /// Finds the outline colour of the piece.
        /// </summary>
        /// <returns>Outline colour</returns>
        public Color GetOutlineColour()
        {
            return outlineColour;
        }

        /// <summary>
        /// Finds the fill colour(s) of the piece.
        /// </summary>
        /// <returns>An array of colours</returns>
        public Color[] GetFillColour()
        {
            return fillColour;
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

        public string GetPieceDetails()
        {
            return pieceDetails;
        }

        public int GetOutlineWidth()
        {
            return outlineWidth;
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


        // Set Functions

        public void SetSizeMod(double inSize)
        {
            sizeMod = inSize;
        }

        public void SetX(double inX)
        {
            x = inX;
        }

        public void SetY(double inY)
        {
            y = inY;
        }

        public void SetRotation(double inRotation)
        {
            rotation = inRotation % 360;
        }

        public void SetTurn(double inTurn)
        {
            turn = inTurn % 360;
        }

        public void SetSpin(double inSpin)
        {
            spin = inSpin % 360;
        }

        public void SetFillColour(Color[] colourArray)
        {
            fillColour = colourArray;
        }

        public void SetOutlineColour(Color outline)
        {
            outlineColour = outline;
        }

        public void SetColourType(string inColourType)
        {
            colourType = inColourType;
        }

        public void SetOutlineWidth(int inOutlineWidth)
        {
            outlineWidth = inOutlineWidth;
        }

        public void SetPieceDetails(string deets)
        {
            pieceDetails = deets;
        }

        public void SetValues(double nx, double ny, double nr, double nt, double ns, double nsize)
        {
            x = nx; y = ny; rotation = nr; turn = nt; spin = ns; sizeMod = nsize;
        }


        public void AttachToPiece(Piece attach, Piece attachmentPoint, Piece point, Boolean front, double angleFlip)
        {
            attachedTo = attach;
            attachPoint = attachmentPoint;
            ownPoint = point;
            inFront = front;
            this.angleFlip = angleFlip;
            x = 0;
            y = 0;
        }

        public void SetName(string inName)
        {
            name = inName;
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
            colourType = angleData[0];

            // Colours (Outline and Fill)
            string[] colours = angleData[1].Split(new Char[] { ':' });
            fillColour = new Color[colours.Length - 1];

            for (int index = 0; index < colours.Length; index++)
            {
                string[] rgbValues = colours[index].Split(new Char[] { ',' });

                if (index == 0)
                {
                    outlineColour = Color.FromArgb(int.Parse(rgbValues[0]), int.Parse(rgbValues[1]), int.Parse(rgbValues[2]), int.Parse(rgbValues[3]));
                }
                else
                {
                    fillColour[index - 1] = Color.FromArgb(int.Parse(rgbValues[0]), int.Parse(rgbValues[1]), int.Parse(rgbValues[2]), int.Parse(rgbValues[3]));
                }
            }

            // Outline Width
            outlineWidth = int.Parse(angleData[2]);

            // Piece Details
            pieceDetails = angleData[3];
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
            if (folder != piecesFolder)
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
                attachPoint.SetValues(midX, midY, attachedTo.GetAngles()[0],
                    attachedTo.GetAngles()[1], attachedTo.GetAngles()[2], attachedTo.GetSizeMod());
                ownPoint.SetValues(midX, midY, GetAngles()[0], GetAngles()[1], GetAngles()[2], GetSizeMod());

                double[,] baseCoords = attachPoint.GetCurrentPoints(false, true);
                double[,] thisCoords = ownPoint.GetCurrentPoints(false, true);

                return new double[] { baseCoords[0, 0] - thisCoords[0, 0], baseCoords[0, 1] - thisCoords[0, 1] };
            }
        }

        public void TakeOriginalState()
        {
            x = originally.GetX();
            y = originally.GetY();
            rotation = originally.GetR();
            turn = originally.GetT();
            spin = originally.GetS();
            sizeMod = originally.GetSM();
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
            double getR = (rotation + attachedTo.GetAngles()[0]) % 360;
            double getT = (turn + attachedTo.GetAngles()[1]) % 360;
            double getS = (spin + attachedTo.GetAngles()[2]) % 360;

            if (angle == 0 && (turn != 0 || spin != 0))                     // Rotation
            {

            }
            else if (angle == 1 && (rotation != 0 || spin != 0))             // Turn
            {
                if (spin % 180 != 0)    // Spin Changed
                {
                    // ROTATION
                    // Exact quadrants && one value is 0
                    if (getR % 90 == 0)
                    {
                        if (getR == 90)
                        {
                            sum += spin;
                        }
                        else if (getR == 270)
                        {
                            sum -= spin;
                        }
                    }
                    // Rounded Sections
                    else
                    {
                        if (getR < 90)
                        {
                            sum += getR / 90 * spin;
                        }
                        else if (getR < 180)
                        {
                            sum += (getR - 90) / 90 * (1 / spin);
                        }
                        else if (getR < 270)
                        {
                            sum -= (getR - 180) / 90 * spin;
                        }
                        else
                        {
                            sum -= (getR - 270) / 90 * (1 / spin);
                        }
                    }

                    // TURN
                }
            }
            else if (angle == 2 && (rotation != 0 || turn != 0))      // Spin
            {
                if (spin % 180 != 0)    // Spin Changed
                {
                    // ROTATION
                    // Exact quadrants && one value is 0
                    if (getR % 90 == 0)
                    {
                        if (getR == 0)
                        {
                            sum += turn;
                        }
                        else if (getR == 180)
                        {
                            sum -= turn;
                        }
                    }
                    // Rounded Sections
                    else
                    {
                        if (getR < 90)
                        {
                            sum += getR / 90 * turn;
                        }
                        else if (getR < 180)
                        {
                            sum += (getR - 90) / 90 * (1 / turn);
                        }
                        else if (getR < 270)
                        {
                            sum -= (getR - 180) / 90 * turn;
                        }
                        else
                        {
                            sum -= (getR - 270) / 90 * (1 / turn);
                        }
                    }
                }
            }
            

            return sum;
        }
    }
}
