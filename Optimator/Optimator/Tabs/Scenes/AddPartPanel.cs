﻿using Optimator.Tabs;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System;
using Optimator.Tabs.Scenes;

namespace Optimator.Forms.Scenes
{
    /// <summary>
    /// A panel for saving parts.
    /// </summary>
    public partial class AddPartPanel : PanelControl
    {
        private readonly ScenesTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public AddPartPanel(ScenesTab owner)
        {
            InitializeComponent();
            Owner = owner;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            float widthPercent = 0.5F;
            float smallWidthPercent = 0.1F;
            float heightPercent = 0.2F;

            int bigWidth = (int)(Width * widthPercent);
            int lilWidth = (int)(Width * smallWidthPercent);
            int bigHeight = (int)(Height * heightPercent);

            AddPartLbl.Location = new Point(lilWidth, lilWidth);

            TableLayoutPnl.Location = new Point(lilWidth, lilWidth * 2 + AddPartLbl.Height);
            TableLayoutPnl.Size = new Size(bigWidth, bigHeight);
        }

        /// <summary>
        /// Adds the entered part to the scene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Part loaded;
                if (sender == AddPieceBtn)
                {
                    loaded = new Piece(AddTb.Text);
                    loaded.ToPiece().State.SetCoordsBasedOnBoard(Owner.GetBoardSizing());
                    Owner.WIP.Originals.Add(loaded, Utils.CloneState(loaded.ToPiece().State));
                    Owner.WIP.OriginalColours.Add(loaded, Utils.CloneColourState((loaded as Piece).ColourState));
                }
                else
                {
                    loaded = new Set(AddTb.Text);
                    loaded.ToPiece().State.SetCoordsBasedOnBoard(Owner.GetBoardSizing());
                    Owner.WIP.Originals.Add(loaded, Utils.CloneState(loaded.ToPiece().State));
                    foreach (Piece piece in (loaded as Set).PiecesList)
                    {
                        Owner.WIP.Originals.Add(piece, Utils.CloneState(piece.State));
                        Owner.WIP.OriginalColours.Add(piece, Utils.CloneColourState(piece.ColourState));
                    }
                }
                Owner.WIP.PartsList.Add(loaded);
                Owner.SelectPart(loaded);
                Owner.WIP.UpdatePiecesList();
                Owner.DisplayDrawings();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Suspected outdated file.", "File Indexing Error", MessageBoxButtons.OK);
            }
        }
    }
}
