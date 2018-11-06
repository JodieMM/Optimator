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
        List<Piece> partOrder = new List<Piece>();
        List<Changes> changes = new List<Changes>();

        int frameRate;
        int numFrames;

        const string originalsSegment = "Originals";
        const string scenesFolder = "\\Scenes\\";

        public Scene(string fileName)
        {
            try
            {
                //Read and assign
                // Open File
                string filePath = Environment.CurrentDirectory + scenesFolder + fileName + ".txt";
                System.IO.StreamReader file = new System.IO.StreamReader(@filePath);

                // Read Data
                string[] dataLines = file.ReadLine().Split(new Char[] { ';' });
                frameRate = int.Parse(dataLines[0]);
                numFrames = int.Parse(dataLines[1]);

                // Read parts
                string dataLine = file.ReadLine();
                while (dataLine != originalsSegment)
                {
                    if (dataLine.StartsWith("p"))
                    {
                        piecesList.Add(new Piece(dataLine.Remove(0, 2)));
                    }
                    else
                    {
                        Set newSet = new Set(dataLine.Remove(0, 2));
                        piecesList.AddRange(newSet.GetPiecesList());
                    }
                    dataLine = file.ReadLine();
                }

                // Set Part Order
                for (int index = 0; index < piecesList.Count; index++)
                {
                    piecesList[index].SceneIndex = index;
                }

                // Assign Original States
                Boolean found = false;
                for (int index = 0; index < piecesList.Count; index++)      // piecesList.Count is the same as the number of lines to read
                {
                    dataLines = file.ReadLine().Split(new Char[] { ';' });
                    found = false;
                    for (int i = 0; index < piecesList.Count && !found; index++)
                    {
                        if (piecesList[i].SceneIndex == int.Parse(dataLines[0]))
                        {
                            piecesList[i].SetValues(double.Parse(dataLines[1]), double.Parse(dataLines[2]), double.Parse(dataLines[3]), 
                                double.Parse(dataLines[4]), double.Parse(dataLines[5]), double.Parse(dataLines[6]));
                            piecesList[i].Originally = new Originals(piecesList[i]);
                            found = true;
                        }
                    }
                }


                // Read frame changes
                while ((dataLine = file.ReadLine()) != null)
                {
                    string[] data = dataLine.Split(new Char[] { ';' });
                                // ** TO DO if options: use different initiliser
                    changes.Add(new Changes(int.Parse(data[0]), data[1], piecesList[int.Parse(data[2])], double.Parse(data[3]), int.Parse(data[4])));
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


        // Get Functions

        public int GetNumFrames()
        {
            return numFrames;
        }

        public int GetFrameRate()
        {
            return frameRate;
        }

        public List<Piece> GetPiecesList()
        {
            return piecesList;
        }

        public List<Changes> GetChanges()
        {
            return changes;
        }


        // General Functions
        public void AssignOriginalPositions()
        {
            foreach (Piece piece in piecesList)
            {
                piece.TakeOriginalState();
            }

            // Reset partOrder
            partOrder.Clear();
            partOrder.AddRange(piecesList);
        }
    }
}
