using System;
using System.Collections.Generic;
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
        #region Scene Variables
        public List<Piece> PiecesList { get; } = new List<Piece>();
        private List<Piece> partOrder = new List<Piece>();
        public List<Change> Changes { get; } = new List<Change>();

        public int FrameRate { get; }
        public int NumFrames { get; }
        #endregion


        /// <summary>
        /// Scene constructor. Assigns variables based
        /// on the scene file that is loaded.
        /// </summary>
        /// <param name="fileName">Name of scene to load</param>
        public Scene(string fileName)
        {
            try
            {
                // Read and assign
                // Open File
                string filePath = Environment.CurrentDirectory + Constants.ScenesFolder + fileName + Constants.Txt;
                System.IO.StreamReader file = new System.IO.StreamReader(@filePath);

                // Read Data
                string[] dataLines = file.ReadLine().Split(Constants.Semi);
                FrameRate = int.Parse(dataLines[0]);
                NumFrames = int.Parse(dataLines[1]);

                // Read parts
                string dataLine = file.ReadLine();
                while (dataLine != "Originals")
                {
                    if (dataLine.StartsWith("p"))
                    {
                        PiecesList.Add(new Piece(dataLine.Remove(0, 2)));
                    }
                    else
                    {
                        Set newSet = new Set(dataLine.Remove(0, 2));
                        PiecesList.AddRange(newSet.PiecesList);
                    }
                    dataLine = file.ReadLine();
                }

                // Set Part Order
                for (int index = 0; index < PiecesList.Count; index++)
                {
                    PiecesList[index].SceneIndex = index;
                }

                // Assign Original States
                bool found = false;
                for (int index = 0; index < PiecesList.Count; index++)      // piecesList.Count is the same as the number of lines to read
                {
                    dataLines = file.ReadLine().Split(Constants.Semi);
                    found = false;
                    for (int i = 0; index < PiecesList.Count && !found; index++)
                    {
                        if (PiecesList[i].SceneIndex == int.Parse(dataLines[0]))
                        {
                            PiecesList[i].SetValues(double.Parse(dataLines[1]), double.Parse(dataLines[2]), double.Parse(dataLines[3]), 
                                double.Parse(dataLines[4]), double.Parse(dataLines[5]), double.Parse(dataLines[6]));
                            PiecesList[i].Originally = new Originals(PiecesList[i]);
                            found = true;
                        }
                    }
                }


                // Read frame changes
                while ((dataLine = file.ReadLine()) != null)
                {
                    string[] data = dataLine.Split(Constants.Semi);
                                // ** TO DO if options: use different initiliser
                    Changes.Add(new Change(int.Parse(data[0]), data[1], PiecesList[int.Parse(data[2])], double.Parse(data[3]), int.Parse(data[4])));
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



        // ----- GENERAL FUNCTIONS -----

        /// <summary>
        /// Assigns the original values to all pieces
        /// in the scene, restarting the scene.
        /// </summary>
        public void AssignOriginalPositions()
        {
            foreach (Piece piece in PiecesList)
            {
                piece.TakeOriginalState();
            }

            // Reset partOrder
            partOrder.Clear();
            partOrder.AddRange(PiecesList);
        }
    }
}
