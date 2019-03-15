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
        public string Version { get; }
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
                // Read File
                List<string> data = Utils.ReadFile(Utils.GetDirectory(Consts.ScenesFolder, fileName, Consts.Optr));
                Version = data[0].Split(Consts.Semi)[1];
                Utils.CheckValidVersion(Version);

                // Time Length
                TimeLength = decimal.Parse(data[1]);

                // Parts
                int partEndIndex = data.IndexOf("Originals");
                if (partEndIndex == -1)
                {
                    MessageBox.Show("Invalid Scene File", "Invalid File", MessageBoxButtons.OK);
                    return;
                }
                for (int index = 2; index < partEndIndex; index++)
                {
                    if (data[index].StartsWith("p"))
                        PartsList.Add(new Piece(data[index].Remove(0, 2)));
                    else
                        PartsList.Add(new Set(data[index].Remove(0, 2)));
                }
                UpdatePiecesList();

                // Assign Original States
                int lastPieceIndex = partEndIndex + PiecesList.Count;
                for (int index = partEndIndex + 1; index <= lastPieceIndex; index++)
                {
                    int workingIndex = index - partEndIndex - 1;
                    Piece piece = PiecesList[workingIndex];
                    string[] originals = data[index].Split(Consts.Semi);
                    piece.SetValues(double.Parse(originals[0]), double.Parse(originals[1]), double.Parse(originals[2]),
                                double.Parse(originals[3]), double.Parse(originals[4]), double.Parse(originals[5]));
                    piece.Originally = new Originals(piece);
                }

                // Read frame changes
                for (int index = lastPieceIndex + 1; index < data.Count; index++)
                {
                    string[] changes = data[index].Split(Consts.Semi);
                    Changes.Add(new Change(int.Parse(changes[0]), changes[1], PiecesList[int.Parse(changes[2])], double.Parse(changes[3]), decimal.Parse(changes[4]), this));
                }                                               
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
        /// Converts the scene into a string format for saving.
        /// </summary>
        /// <returns></returns>
        public List<string> GetData()
        {
            List<string> data = new List<string>
            {
                Consts.Scene + Consts.Semi + Consts.Version,
                TimeLength.ToString()
            };

            // Save Parts
            foreach (Part part in PartsList)
                data.Add((part is Piece ? "p:" : "s:") + part.Name);

            // Save Original States
            data.Add("Originals");
            foreach (Piece piece in PiecesList)
                data.Add(piece.Originally != null ? piece.Originally.GetSaveData() : Consts.defaultAngleOptions);

            // Save Animation Changes
            foreach (Change change in Changes)
                data.Add(change.ToString());

            return data;
        }

        /// <summary>
        /// Assigns the original values to all pieces
        /// in the scene and runs all changes to
        /// the specified time.
        /// </summary>
        public void RunScene(decimal time)
        {
            foreach (Piece piece in PiecesList)
                piece.TakeOriginalState();
            foreach (Change change in Changes)
                change.Run(time);
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
                    PiecesList.Add(PartsList[index].ToPiece());
                else
                    PiecesList.AddRange(PartsList[index].ToSet().PiecesList);
            }
        }
    }
}
