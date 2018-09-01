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
        private string name, colourType, pieceDetails;
        private double x = 500;
        private double y = 250;
        private int outlineWidth;
        private double rotation = 0;
        private double turn = 0;
        private double spin = 0;
        private double sizeMod = 100;
        private Color[] colourArray;
        List<string> data;
        Set belongsTo;
        //private string setConstraints;



        /// <summary>
        /// Assigns starting values to the piece variables. 
        /// Piece values stored in files are accessed.
        /// </summary>
        /// <param name="inName">The (file) name of the piece</param>
        public Piece(string inName)
        {
            name = inName;
            data = ReadFile(name);

            //Get points and colours from file
            AssignValues(data[0]);
        }

        /// <summary>
        /// Assigns starting values to the piece variables. 
        /// Piece values stored in files are accessed.
        /// This overflow accounts for the piece being a member of a set.
        /// </summary>
        /// <param name="inName">The (file) name of the piece</param>
        public Piece(string inName, Set belongs)
        {
            name = inName;
            belongsTo = belongs;
            //setConstraints =      ** TO DO **
            data = ReadFile(name);

            //Get points and colours from file
            AssignValues(data[0]);
        }


        // Get Functions
        public string GetName()
        {
            return name;
        }

        public double GetSizeMod()
        {
            return sizeMod;
        }

        public double[] GetCoords()
        {
            return new double[] { x, y };
        }

        public double[] GetAngles()
        {
            return new double[] { rotation, turn, spin };
        }

        public string GetColourType()
        {
            return colourType;
        }

        public Color[] GetColourArray()
        {
            return colourArray;
        }

        public string[] GetLineArray(int r, int t)
        {
            return data[FindRow(r, t)].ToString().Split(new Char[] { ';' })[5].Split(new Char[] { ',' });
        }

        public string[] GetPointDataArray(int r, int t)
        {
            return data[FindRow(r, t)].ToString().Split(new Char[] { ';' })[6].Split(new Char[] { ',' });
        }

        public List<string> GetData()
        {
            return data;
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

        public Boolean GetIsSet()
        {
            if (belongsTo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Set GetBelongsSet()
        {
            return belongsTo;
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

        public void SetColourArray(Color[] inColourArray)
        {
            colourArray = inColourArray;
        }

        public void SetColourType(string inColourType)
        {
            colourType = inColourType;
        }

        public void SetOutlineWidth(int inOutlineWidth)
        {
            outlineWidth = inOutlineWidth;
        }


        // Other Functions
        public Boolean CheckName(string inName)
        {
            if (name == inName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> ReadFile(string inName)
        {
            // Open File
            string filePath = Environment.CurrentDirectory + "\\Parts\\" + inName + ".txt";
            System.IO.StreamReader file = new System.IO.StreamReader(@filePath);

            // Read Data
            List<string> data = new List<string>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                data.Add(line);
            }
            file.Close();

            // Return String
            return data;
        }

        public void AssignValues(string inData)
        {
            if (!data[0].StartsWith("point"))
            {
                string[] angleData = inData.Split(new Char[] { ';' });
                // angleData [0] colour type     [1] colour array   [2] outline width   [3] pieceDetails

                // Colour Type
                colourType = angleData[0];

                // Colour Array
                string[] colours = angleData[1].Split(new Char[] { ':' });
                colourArray = new Color[colours.Length];
                for (int index = 0; index < colours.Length; index++)
                {
                    string[] rgbValues = colours[index].Split(new Char[] { ',' });
                    colourArray[index] = Color.FromArgb(int.Parse(rgbValues[0]), int.Parse(rgbValues[1]), int.Parse(rgbValues[2]), int.Parse(rgbValues[3]));
                }

                // Outline Width
                outlineWidth = int.Parse(angleData[2]);

                // Piece Details
                pieceDetails = angleData[3];
            }
        }

        public double[,] FindPoints(int row, int angle)
        {
            // Find Points
            if (row != -1)
            {
                int numPoints = data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' }).Length;
                double[,] returnPoints = new double[numPoints, 2];
                for (int index = 0; index < numPoints; index++)
                {
                    returnPoints[index, 0] = double.Parse(data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' })[index].Split(new Char[] { ',' })[0]);
                    returnPoints[index, 1] = double.Parse(data[row].Split(new Char[] { ';' })[angle].Split(new Char[] { ':' })[index].Split(new Char[] { ',' })[1]);
                }
                return returnPoints;
            }
            return new double[0, 0];
        }

        public int FindRow(double r, double t)
        {
            // Check rows until found
            int row = 1;
            Boolean found = false;
            while (!found)
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
                if (row == data.Count)
                {
                    found = true;
                    row = -1;
                }
            }
            return row;
        }

        public double[,] GetCurrentPoints(Boolean includeMovement, Boolean recentre)
        {
            // Find correct row of piece data
            int row = FindRow(GetAngles()[0], GetAngles()[1]);
            List<string> data = GetData();

            // Prepare Points
            double[,] pointsArrayInitial = GetOriginalPoints(GetAngles()[0], GetAngles()[1]);
            double[,] pointsArrayRotated = GetRotatedPoints(GetAngles()[0], GetAngles()[1]);
            double[,] pointsArrayTurned = GetTurnedPoints(GetAngles()[0], GetAngles()[1]);
            double[] xyCoords = GetCoords();
            double[,] pointsArray = new double[GetNumPoints((int)GetAngles()[0], (int)GetAngles()[1]), 2];

            // Find Multipliers
            int rotationMultiplier = (int)GetAngles()[0] - int.Parse(data[row].Substring(0, 3));
            int turnMultiplier = (int)GetAngles()[1] - int.Parse(data[row].Substring(8, 3));

            // Find Points
            // Rotation Adjustment
            for (int index = 0; index < GetNumPoints((int)GetAngles()[0], (int)GetAngles()[1]); index++)
            {
                if (double.Parse(data[row].Substring(4, 3)) != double.Parse(data[row].Substring(0, 3)))
                {
                    // X
                    pointsArray[index, 0] = pointsArrayInitial[index, 0] + ((rotationMultiplier * (int)(pointsArrayRotated[index, 0] - pointsArrayInitial[index, 0])) /
                        (int.Parse(data[row].Substring(4, 3)) - int.Parse(data[row].Substring(0, 3))));
                    // Y
                    pointsArray[index, 1] = pointsArrayInitial[index, 1] + ((rotationMultiplier * (int)(pointsArrayRotated[index, 1] - pointsArrayInitial[index, 1])) /
                        (int.Parse(data[row].Substring(4, 3)) - int.Parse(data[row].Substring(0, 3))));
                }
                else
                {
                    // X
                    pointsArray[index, 0] = pointsArrayInitial[index, 0];
                    // Y
                    pointsArray[index, 1] = pointsArrayInitial[index, 1];

                }
            }
            // Recentre
            if (recentre)
            {
                double xMid = FindMid(pointsArray)[0];
                for (int index = 0; index < GetNumPoints((int)GetAngles()[0], (int)GetAngles()[1]); index++)
                {
                    pointsArray[index, 0] += FindMid(GetOriginalPoints(0, 0))[0] - xMid;
                }
            }

            // Turn Adjustment
            for (int index = 0; index < GetNumPoints((int)GetAngles()[0], (int)GetAngles()[1]); index++)
            {
                if (double.Parse(data[row].Substring(12, 3)) != double.Parse(data[row].Substring(8, 3)))
                {
                    // X
                    pointsArray[index, 0] = pointsArray[index, 0] + ((turnMultiplier * (int)(pointsArrayTurned[index, 0] - pointsArrayInitial[index, 0]))
                        / (int.Parse(data[row].Substring(12, 3)) - int.Parse(data[row].Substring(8, 3))));
                    // Y
                    pointsArray[index, 1] = pointsArray[index, 1] + ((turnMultiplier * (int)(pointsArrayTurned[index, 1] - pointsArrayInitial[index, 1]))
                        / (int.Parse(data[row].Substring(12, 3)) - int.Parse(data[row].Substring(8, 3))));
                }
            }
            // Recentre
            if (recentre)
            {
                double yMid = FindMid(pointsArray)[1];
                for (int index = 0; index < GetNumPoints((int)GetAngles()[0], (int)GetAngles()[1]); index++)
                {
                    pointsArray[index, 1] += FindMid(GetOriginalPoints(0, 0))[1] - yMid;
                }
            }

            // Spin and Size Adjustment
            pointsArray = SpinMeRound(pointsArray, FindMid(GetOriginalPoints(0, 0))[0], FindMid(GetOriginalPoints(0, 0))[1], sizeMod/100.0);
            
            // Return Points
            if (includeMovement == false)
            {
                return pointsArray;
            }
            else
            {
                // Recentre
                for (int index = 0; index < GetNumPoints((int)GetAngles()[0], (int)GetAngles()[1]); index++)
                {
                    pointsArray[index, 0] += GetCoords()[0] - FindMid(GetOriginalPoints(0, 0))[0];
                    pointsArray[index, 1] += GetCoords()[1] - FindMid(GetOriginalPoints(0, 0))[1];
                }
                return pointsArray;
            }
        }

        private double[] FindMid(double[,] arrayIn)
        {
            double minX = 99999;
            double maxX = -99999;
            double minY = 99999;
            double maxY = -99999;
            for (int index = 0; index < arrayIn.Length / 2; index++)
            {
                if (arrayIn[index, 0] < minX)
                {
                    minX = arrayIn[index, 0];
                }
                if (arrayIn[index, 0] > maxX)
                {
                    maxX = arrayIn[index, 0];
                }
                if (arrayIn[index, 1] < minY)
                {
                    minY = arrayIn[index, 1];
                }
                if (arrayIn[index, 1] > maxY)
                {
                    maxY = arrayIn[index, 1];
                }
            }
            return new double[] { minX + (maxX - minX) / 2, minY + (maxY - minY) / 2 };
        }

        public double[,] SpinMeRound(double[,] pointsArray, double midX, double midY, double sizeModifier)
        {
            // Spin Adjustment
            for (int index = 0; index < pointsArray.Length / 2; index++)
            {
                if (!(pointsArray[index, 0] == midX && pointsArray[index, 1] == midY))
                {
                    double hypotenuse = Math.Sqrt(Math.Pow(midX - pointsArray[index, 0], 2) + Math.Pow(midY - pointsArray[index, 1], 2)) * sizeModifier;
                    // Find Angle
                    double pointAngle;
                    if (pointsArray[index, 0] == midX && pointsArray[index, 1] < midY)
                    {
                        pointAngle = 0;
                    }
                    else if (pointsArray[index, 0] == midX && pointsArray[index, 1] > midY)
                    {
                        pointAngle = 180;
                    }
                    else if (pointsArray[index, 0] > midX && pointsArray[index, 1] == midY)
                    {
                        pointAngle = 90;
                    }
                    else if (pointsArray[index, 0] < midX && pointsArray[index, 1] == midY)
                    {
                        pointAngle = 270;
                    }
                    //  Second || First
                    //  Third  || Fourth
                    else if (pointsArray[index, 0] > midX && pointsArray[index, 1] < midY) // First Quadrant
                    {
                        pointAngle = (180 / Math.PI) * Math.Atan(Math.Abs(((double)midX - pointsArray[index, 0]) / ((double)midY - pointsArray[index, 1])));
                    }
                    else if (pointsArray[index, 0] > midX && pointsArray[index, 1] > midY) // Fourth Quadrant
                    {
                        pointAngle = 90 + (180 / Math.PI) * Math.Atan(Math.Abs((double)(midY - pointsArray[index, 1]) / ((double)midX - pointsArray[index, 0])));
                    }
                    else if (pointsArray[index, 0] < midX && pointsArray[index, 1] < midY) // Second Quadrant
                    {
                        pointAngle = 270 + (180 / Math.PI) * Math.Atan(Math.Abs(((double)midY - pointsArray[index, 1]) / ((double)midX - pointsArray[index, 0])));
                    }
                    else  // Third Quadrant
                    {
                        pointAngle = 180 + (180 / Math.PI) * Math.Atan(Math.Abs(((double)midX - pointsArray[index, 0]) / ((double)midY - pointsArray[index, 1])));
                    }
                    double findAngle = ((pointAngle + spin) % 360) * Math.PI / 180;

                    // Find Points
                    pointsArray[index, 0] = (int)(midX + hypotenuse * Math.Sin(findAngle));
                    pointsArray[index, 1] = (int)(midY - hypotenuse * Math.Cos(findAngle));
                }
            }
            return pointsArray;
        }
    }
}
