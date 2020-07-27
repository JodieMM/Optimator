﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator
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
        public string Name { get; set; } = "";
        public string Version { get; }
        public decimal TimeLength { get; set; } = 0;

        public List<Part> PartsList { get; } = new List<Part>();
        public List<Piece> PiecesList { get; } = new List<Piece>();
        public List<Change> Changes { get; } = new List<Change>();
        public Dictionary<Part, State> Originals { get; } = new Dictionary<Part, State>();
        public Dictionary<Part, ColourState> OriginalColours { get; } = new Dictionary<Part, ColourState>();
        public Color Background = Color.White;
        #endregion


        /// <summary>
        /// Scene constructor. Assigns variables based
        /// on the scene file that is loaded.
        /// </summary>
        /// <param name="name">Name of scene to load</param>
        /// <param name="data">Scene data</param>
        public Scene(string name, List<string> data)
        {
            Name = name;
            Version = data[0];

            // Time Length
            TimeLength = decimal.Parse(data[1]);

            // Background Colour
            Background = Utils.ColourFromString(data[2]);

            // Parts
            var partEndIndex = data.IndexOf("Originals");
            if (partEndIndex == -1)
            {
                MessageBox.Show("Invalid Scene File", "Invalid File", MessageBoxButtons.OK);
                return;
            }
            for (var index = 3; index < partEndIndex; index++)
            {
                if (data[index].EndsWith(Consts.PieceExt))
                {
                    PartsList.Add(new Piece(data[index], Utils.ReadFile(Utils.GetDirectory(data[index]))));
                }
                else if (data[index].EndsWith(Consts.SetExt))
                {
                    PartsList.Add(new Set(data[index], Utils.ReadFile(Utils.GetDirectory(data[index]))));
                }
            }
            UpdatePiecesList();

            // Assign Original States
            var lastPieceIndex = partEndIndex + PiecesList.Count;
            for (var index = partEndIndex + 1; index <= lastPieceIndex; index++)
            {
                var workingIndex = index - partEndIndex - 1;
                var piece = PiecesList[workingIndex];
                var originals = Utils.ConvertStringArrayToFloats(data[index].Split(Consts.Colon));
                piece.State.SetValues(originals[0], originals[1], originals[2], originals[3], originals[4], originals[5]);
                Originals.Add(piece, Utils.CloneState(piece.State));
                OriginalColours.Add(piece, Utils.CloneColourState(piece.ColourState));
            }

            // Read frame changes
            for (var index = lastPieceIndex + 1; index < data.Count; index++)
            {
                var changes = data[index].Split(Consts.Colon);
                Changes.Add(new Change(decimal.Parse(changes[0]), changes[1], PiecesList[int.Parse(changes[2])],
                    float.Parse(changes[3]), decimal.Parse(changes[4]), this));
            }                                               
        }

        /// <summary>
        /// Scene constructor for creating a new scene.
        /// </summary>
        public Scene()
        {
            Version = Properties.Settings.Default.Version;
        }



        // ----- GENERAL FUNCTIONS -----

        /// <summary>
        /// Converts the scene into a string format for saving.
        /// </summary>
        /// <returns></returns>
        public List<string> GetData()
        {
            var data = new List<string>
            {
                Properties.Settings.Default.Version,
                TimeLength.ToString(),
                Utils.ColorToString(Background)
            };

            // Save Parts
            foreach (var part in PartsList)
            {
                data.Add(part.Name);
            }

            // Save Original States
            data.Add("Originals");
            foreach (var piece in PiecesList)
            {
                data.Add(Originals.ContainsKey(piece) ? Originals[piece].GetData() : new State().GetData());
            }

            // Save Animation Changes
            foreach (var change in Changes)
            {
                data.Add(change.ToString());
            }

            return data;
        }

        /// <summary>
        /// Assigns the original values to all pieces
        /// in the scene and runs all changes to
        /// the specified time.
        /// </summary>
        public void RunScene(decimal time)
        {
            foreach (var part in PartsList)
            {
                if (part is Piece)
                {
                    (part as Piece).State = Utils.CloneState(Originals[part]);
                }
                else if (part is Set)
                {
                    foreach (var piece in (part as Set).PiecesList)
                    {
                        if (Originals.ContainsKey(piece) && (part as Set).PersonalStates.ContainsKey(piece))
                        {
                            (part as Set).PersonalStates[piece] = Utils.CloneState(Originals[piece]);                            
                        }
                        if (piece == (part as Set).BasePiece)
                        {
                            piece.State = Utils.CloneState(Originals[piece]);
                        }
                    }
                }
            }            
            foreach (var change in Changes)
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
            for (var index = 0; index < PartsList.Count; index++)
            {
                if (PartsList[index] is Piece)
                {
                    PiecesList.Add(PartsList[index].ToPiece());
                }
                else if (PartsList[index] is Set)
                {
                    PiecesList.AddRange((PartsList[index] as Set).PiecesList);
                }
            }
        }

        /// <summary>
        /// Gets a piece's state or a set component's personal state.
        /// </summary>
        /// <param name="piece">The piece owning the state</param>
        /// <returns>State of provided piece</returns>
        public State GetPieceState(Piece piece)
        {
            foreach (var part in PartsList)
            {
                if (part is Set)
                {                    
                    if ((part as Set).PersonalStates.ContainsKey(piece))
                    {
                        if ((part as Set).BasePiece == piece)
                        {
                            return piece.State;
                        }
                        return (part as Set).PersonalStates[piece];
                    }
                }
                else if (part is Piece && part == piece)
                {
                    return piece.State;
                }
            }
            return new State(); // Error 
        }
    }
}
