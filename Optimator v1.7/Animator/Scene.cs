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
        public List<Part> PartsList { get; } = new List<Part>();
        public List<Piece> PiecesList { get; } = new List<Piece>();
        public List<Change> Changes { get; } = new List<Change>();
        public decimal TimeLength { get; set; }
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
                // Open File
                string filePath = Utilities.GetDirectory(Constants.ScenesFolder, fileName, Constants.Txt);
                System.IO.StreamReader file = new System.IO.StreamReader(@filePath);
                TimeLength = decimal.Parse(file.ReadLine());

                // Read parts
                string[] dataLines;
                string dataLine = file.ReadLine();
                while (dataLine != "Originals")
                {
                    if (dataLine.StartsWith("p"))
                        PartsList.Add(new Piece(dataLine.Remove(0, 2)));
                    else
                        PartsList.Add(new Set(dataLine.Remove(0, 2)));

                    dataLine = file.ReadLine();
                }
                UpdatePiecesList();

                // Assign Original States
                foreach (Piece piece in PiecesList)
                {
                    dataLines = file.ReadLine().Split(Constants.Semi);
                    piece.SetValues(double.Parse(dataLines[0]), double.Parse(dataLines[1]), double.Parse(dataLines[2]),
                                double.Parse(dataLines[3]), double.Parse(dataLines[4]), double.Parse(dataLines[5]));
                    piece.Originally = new Originals(piece);
                }

                // Read frame changes
                while ((dataLine = file.ReadLine()) != null)
                {
                    string[] data = dataLine.Split(Constants.Semi);
                    Changes.Add(new Change(int.Parse(data[0]), data[1], PiecesList[int.Parse(data[2])], double.Parse(data[3]), decimal.Parse(data[4]), this));
                }

                file.Close();
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Suspected outdated file.", "File Indexing Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Scene constructor for creating a new scene.
        /// </summary>
        public Scene()
        {
            TimeLength = 0;
        }



        // ----- GENERAL FUNCTIONS -----

        /// <summary>
        /// Assigns the original values to all pieces
        /// in the scene and runs all changes to
        /// the specified time.
        /// </summary>
        public void RunScene(decimal time)
        {
            foreach (Piece piece in PiecesList)
            {
                piece.TakeOriginalState();
            }
            foreach (Change change in Changes)
            {
                change.Run(time);
            }
        }

        /// <summary>
        /// Updates PiecesList to match PartsList.
        /// </summary>
        public void UpdatePiecesList()
        {
            PiecesList.Clear();
            for (int index = 0; index < PartsList.Count; index++)
            {
                if (PartsList[index] is Piece)
                {
                    PiecesList.Add(PartsList[index].ToPiece());
                }
                else
                {
                    PiecesList.AddRange(PartsList[index].ToSet().PiecesList);
                }
            }
        }
    }
}
