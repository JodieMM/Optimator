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
    public class Set
    {
        //Initialise Variables
        string name;
        List<string> data = new List<string>();
        Piece basePiece;
        List<Piece> piecesList = new List<Piece>();
        List<Set> setsList = new List<Set>();
        List<string> partOrder = new List<string>();

        public Set(string inName)
        {
            name = inName;
            data = ReadFile();
            if (CheckSet())
            {
                // Convert Data
                for (int index = 1; index < data.Count; index++)
                {
                    if (data[index].StartsWith("setbase"))
                    {
                        setsList.Add(new Set(data[index].Split(new Char[] { ';' })[1]));
                        partOrder.Add("s:" + (setsList.Count - 1));
                        basePiece = setsList[setsList.Count - 1].GetBasePiece();
                        SetInits(index, true);
                    }
                    else if (data[index].StartsWith("piecebase"))
                    {
                        piecesList.Add(new Piece(data[index].Split(new Char[] { ';' })[1], this));
                        partOrder.Add("p:" + (piecesList.Count - 1));
                        basePiece = piecesList[piecesList.Count - 1];
                        SetInits(index, false);
                    } 
                    else if (data[index].StartsWith("set"))
                    {
                        setsList.Add(new Set(data[index].Split(new Char[] { ';' })[1]));
                        partOrder.Add("s:" + (setsList.Count - 1));
                        SetInits(index, true);
                    }
                    else
                    {
                        piecesList.Add(new Piece(data[index].Split(new Char[] { ';' })[1], this));
                        partOrder.Add("p:" + (piecesList.Count - 1));
                        SetInits(index, false);
                    }
                }

                // Move Subsets
                UpdateConnections();
            }
        }

        // Get Functions
        public string GetName()
        {
            return name;
        }

        public List<string> GetData()
        {
            return data;
        }

        public Piece GetBasePiece()
        {
            return basePiece;
        }

        public List<Piece> GetPiecesList()
        {
            return piecesList;
        }

        public List<Set> GetSetsList()
        {
            return setsList;
        }

        public List<string> GetPartOrder()
        {
            return partOrder;
        }


        // Other Functions
        public Boolean CheckSet()
        {
            // Check Data
            if (data[0].StartsWith("set"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> ReadFile()
        {
            // Open File
            string filePath = Environment.CurrentDirectory + "\\Parts\\" + name + ".txt";
            System.IO.StreamReader file = new System.IO.StreamReader(@filePath);

            // Read Data
            List<string> dataTemp = new List<string>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                dataTemp.Add(line);
            }
            file.Close();

            // Return String
            return dataTemp;
        }

        public void UpdateSubpieces(string what, double howMuch)
        {
            // Update Subpieces
            for (int index = 0; index < GetPartOrder().Count; index++)
            {
                if (GetPartOrder()[index].StartsWith("s") && basePiece
                    != GetSetsList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].GetBasePiece())
                {
                    if (what != "X" && what != "Y")
                    {
                        GetSetsList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].UpdateSubpieces(what, howMuch);
                    }
                    else if (what == "X")
                    {
                        GetSetsList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].UpdateSubpieces(what, GetSetsList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].GetBasePiece().GetCoords()[0] + (howMuch - GetBasePiece().GetCoords()[0]));
                    }
                    else if (what == "Y")
                    {
                        GetSetsList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].UpdateSubpieces(what, GetSetsList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].GetBasePiece().GetCoords()[1] + (howMuch - GetBasePiece().GetCoords()[1]));
                    }
                }
                else if (GetPartOrder()[index].StartsWith("p") && basePiece != GetPiecesList()[int.Parse(GetPartOrder()[index].Remove(0, 2))])
                {
                    if (what == "X")
                    {
                        // X
                        GetPiecesList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].SetX(
                            GetPiecesList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].GetCoords()[0] +
                            (howMuch - GetBasePiece().GetCoords()[0]));
                    }
                    else if (what == "Y")
                    {
                        // Y
                        GetPiecesList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].SetY(
                            GetPiecesList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].GetCoords()[1] +
                            (howMuch - GetBasePiece().GetCoords()[1]));
                    }
                    else if (what == "Rotation")
                    {
                        // Rotation
                        GetPiecesList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].SetRotation(
                            (int)GetPiecesList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].GetAngles()[0] +
                            (howMuch - (int)GetBasePiece().GetAngles()[0]));
                    }
                    else if (what == "Turn")
                    {
                        // Turn
                        GetPiecesList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].SetTurn(
                            (int)GetPiecesList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].GetAngles()[1] +
                            (howMuch - (int)GetBasePiece().GetAngles()[1]));
                    }
                    else if (what == "Spin")
                    {
                        // Spin
                        GetPiecesList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].SetSpin(
                            (int)GetPiecesList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].GetAngles()[2] +
                            (howMuch - (int)GetBasePiece().GetAngles()[2]));
                    }
                    else if (what == "Size")
                    {
                        // Size
                        GetPiecesList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].SetSizeMod(
                            GetPiecesList()[int.Parse(GetPartOrder()[index].Remove(0, 2))].GetSizeMod() +
                            (howMuch - GetBasePiece().GetSizeMod()));
                    }
                }
            }
            // Update Base Piece
            if (what == "X")
            {
                basePiece.SetX(howMuch);
            }
            else if (what == "Y")
            {
                basePiece.SetY(howMuch);
            }
            else if (what == "Rotation")
            {
                basePiece.SetRotation(howMuch);
            }
            else if (what == "Turn")
            {
                basePiece.SetTurn(howMuch);
            }
            else if (what == "Spin")
            {
                basePiece.SetSpin(howMuch);
            }
            else if (what == "Size")
            {
                basePiece.SetSizeMod(howMuch);
            }
        }

        public double[] GetPointPositions(string pointOfBase, string pointOfJoin, Piece joinPieceIn)
        {
            double[] coords = new double[2];
            Piece basePoint = new Piece(pointOfBase);
            Piece joinPoint = new Piece(pointOfJoin);
            double sizeModifier = joinPieceIn.GetSizeMod() / 100.0;
            double sizeModBase = basePiece.GetSizeMod() / 100.0;
            // Find Mid
            double[] basePieceMid = FindMid(basePiece.GetOriginalPoints(0, 0));
            double[] joinPieceMid = FindMid(joinPieceIn.GetOriginalPoints(0, 0));
            // Set Values
            basePoint.SetRotation((int)basePiece.GetAngles()[0]);
            basePoint.SetTurn((int)basePiece.GetAngles()[1]);
            joinPoint.SetRotation((int)joinPieceIn.GetAngles()[0]);
            joinPoint.SetTurn((int)joinPieceIn.GetAngles()[1]);
            // Find Points
            double[,] basePoints = basePoint.GetCurrentPoints(false, false);
            double[,] joinPoints = joinPoint.GetCurrentPoints(false, false);
            // Alter Spin
            double[,] basePointsDupeX = basePoint.GetCurrentPoints(false, false);
            double[,] basePointsDupeY = basePoint.GetCurrentPoints(false, false);
            double[,] joinPointsDupeX = joinPoint.GetCurrentPoints(false, false);
            double[,] joinPointsDupeY = joinPoint.GetCurrentPoints(false, false);
            // Update points based on spin
            basePoints[0, 0] = (int)(basePiece.SpinMeRound(basePointsDupeX, basePieceMid[0], basePieceMid[1], sizeModBase)[0, 0]);
            basePoints[0, 1] = (int)(basePiece.SpinMeRound(basePointsDupeY, basePieceMid[0], basePieceMid[1], sizeModBase)[0, 1]);
            joinPoints[0, 0] = (int)(joinPieceIn.SpinMeRound(joinPointsDupeX, joinPieceMid[0], joinPieceMid[1], sizeModifier)[0, 0]);
            joinPoints[0, 1] = (int)(joinPieceIn.SpinMeRound(joinPointsDupeY, joinPieceMid[0], joinPieceMid[1], sizeModifier)[0, 1]);
            // Update points x/y        //** TO UPDATE WITH RANGES** // Add change in X and Y to coords
            coords[0] = basePiece.GetCoords()[0] + (basePoints[0, 0] - basePieceMid[0]) + (joinPieceMid[0] - joinPoints[0, 0]);
            coords[1] = basePiece.GetCoords()[1] + (basePoints[0, 1] - basePieceMid[1]) + (joinPieceMid[1] - joinPoints[0, 1]);
            // Return JoinPiece Coordinates
            return coords;
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

        private int[] FindMin(int[,] arrayIn)
        {
            int minX = 99999;
            int minY = 99999;
            for (int index = 0; index < arrayIn.Length / 2; index++)
            {
                if (arrayIn[index, 0] < minX)
                {
                    minX = arrayIn[index, 0];
                }
                if (arrayIn[index, 1] < minY)
                {
                    minY = arrayIn[index, 1];
                }
            }
            return new int[] { minX, minY };
        }

        public void UpdateConnections()
        {
            for (int index = 0; index < partOrder.Count; index++)
            {
                if (partOrder[index].StartsWith("p") && piecesList[int.Parse(partOrder[index].Remove(0, 2))] != basePiece)
                {
                    double[] newCoords = GetPointPositions(data[index + 1].Split(new Char[] { ';' })[2].Split(new Char[] { ':' })[0], data[index + 1].Split(new Char[] { ';' })[2].Split(new Char[] { ':' })[1], piecesList[int.Parse(partOrder[index].Remove(0, 2))]);
                    piecesList[int.Parse(partOrder[index].Remove(0, 2))].SetX(newCoords[0]);
                    piecesList[int.Parse(partOrder[index].Remove(0, 2))].SetY(newCoords[1]);
                }
                else if (partOrder[index].StartsWith("s") && setsList[int.Parse(partOrder[index].Remove(0, 2))].GetBasePiece() != basePiece)
                {
                    double[] newCoords = GetPointPositions(data[index + 1].Split(new Char[] { ';' })[2].Split(new Char[] { ':' })[0], data[index + 1].Split(new Char[] { ';' })[2].Split(new Char[] { ':' })[1], setsList[int.Parse(partOrder[index].Remove(0, 2))].GetBasePiece());
                    setsList[int.Parse(partOrder[index].Remove(0, 2))].UpdateSubpieces("X", newCoords[0]);
                    setsList[int.Parse(partOrder[index].Remove(0, 2))].UpdateSubpieces("Y", newCoords[1]);
                }
            }
        }

        public void SetInits(int index, Boolean isSet)
        {
            if (isSet)
            {
                setsList[setsList.Count - 1].UpdateSubpieces("rotation", int.Parse(data[index].Split(new Char[] { ';' })[15]));
                setsList[setsList.Count - 1].UpdateSubpieces("turn", int.Parse(data[index].Split(new Char[] { ';' })[16]));
                setsList[setsList.Count - 1].UpdateSubpieces("spin", int.Parse(data[index].Split(new Char[] { ';' })[17]));
                setsList[setsList.Count - 1].UpdateSubpieces("size", int.Parse(data[index].Split(new Char[] { ';' })[18]));
            }
            else
            {
                piecesList[piecesList.Count - 1].SetRotation(int.Parse(data[index].Split(new Char[] { ';' })[15]));
                piecesList[piecesList.Count - 1].SetTurn(int.Parse(data[index].Split(new Char[] { ';' })[16]));
                piecesList[piecesList.Count - 1].SetSpin(int.Parse(data[index].Split(new Char[] { ';' })[17]));
                piecesList[piecesList.Count - 1].SetSizeMod(int.Parse(data[index].Split(new Char[] { ';' })[18]));
            }
        }
    }
}
