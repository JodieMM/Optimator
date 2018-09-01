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
    /// A class to hold information about each scene.
    /// A scene is a collection of frames.
    /// 
    /// Author Jodie Muller
    /// </summary>

    public class Scene
    {
        // Initialise Scene Variables
        List<Piece> piecesList = new List<Piece>();
        List<Set> setList = new List<Set>();
        List<string> partOrder = new List<string>();
        List<string[]> changes = new List<string[]>();
        string[] originalState;
        int frameRate;
        int numFrames;

        public Scene(string fileName)
        {
            try
            {
                //Read and assign
                // Open File
                string filePath = Environment.CurrentDirectory + "\\Scenes\\" + fileName + ".txt";
                System.IO.StreamReader file = new System.IO.StreamReader(@filePath);

                // Read Data
                string[] dataLine = file.ReadLine().Split(new Char[] { ';' });
                frameRate = int.Parse(dataLine[0]);
                numFrames = int.Parse(dataLine[1]);

                // Read part order
                dataLine = file.ReadLine().Split(new Char[] { ';' });
                foreach(string data in dataLine)
                {
                    partOrder.Add(data);
                }

                // Read parts
                dataLine = file.ReadLine().Split(new Char[] { ';' });
                foreach(string data in dataLine)
                {
                    if (data.StartsWith("p"))
                    {
                        piecesList.Add(new Piece(data.Remove(0, 2)));
                    }
                    else
                    {
                        setList.Add(new Set(data.Remove(0, 2)));
                    }
                }

                // Assign Original States
                originalState = file.ReadLine().Split(new Char[] { ';' });
                AssignOriginalPositions();

                // Read frame changes
                while ((dataLine[0] = file.ReadLine()) != null)
                {
                    string[] data = dataLine[0].Split(new Char[] { ';' });
                    changes.Add(new string[] { data[0], data[1], data[2], data[3], data[4] });
                }
                file.Close();
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Suspected outdated file.", "File Indexing Error", MessageBoxButtons.OK);
            }
        }

        public int GetNumFrames()
        {
            return numFrames;
        }

        public int GetFrameRate()
        {
            return frameRate;
        }

        public List<string> GetPartsList()
        {
            return partOrder;
        }

        public List<Piece> GetPiecesList()
        {
            return piecesList;
        }

        public List<Set> GetSetList()
        {
            return setList;
        }

        public List<string[]> GetChanges()
        {
            return changes;
        }

        public void AssignOriginalPositions()
        {
            for (int index = 0; index < partOrder.Count; index++)
            {
                Piece holdPiece = piecesList[int.Parse(partOrder[index].Remove(0, 2))];
                string[] data = originalState[index].Split(new Char[] { ':' });
                holdPiece.SetX(double.Parse(data[0]));
                holdPiece.SetY(double.Parse(data[1]));
                holdPiece.SetRotation(double.Parse(data[2]));
                holdPiece.SetTurn(double.Parse(data[3]));
                holdPiece.SetSpin(double.Parse(data[4]));
                holdPiece.SetSizeMod(double.Parse(data[5]));
            }
        }
    }
}
