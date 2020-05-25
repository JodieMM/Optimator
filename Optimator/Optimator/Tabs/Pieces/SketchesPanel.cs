﻿using Optimator.Tabs.SoloTabs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Pieces
{
    /// <summary>
    /// A panel to manage the displayed piece sketches.
    /// </summary>
    public partial class SketchesPanel : PanelControl
    {
        private readonly PiecesTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        /// <param name="owner"></param>
        public SketchesPanel(PiecesTab owner)
        {
            InitializeComponent();
            Owner = owner;

            foreach (var sketch in Owner.Sketches)
            {
                SketchLb.Items.Add(sketch.Key);
                SketchLb.SetItemChecked(SketchLb.Items.Count - 1, sketch.Value);
            }
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.05F;
            var widthMultiplier = Height < 650 ? 16 : 18;
            var heightPercent = 0.8F;

            var smallWidth = (int)(Width * widthPercent);
            var bigHeight = (int)(Height * heightPercent);

            SketchesLbl.Location = new Point(smallWidth, smallWidth);

            TableLayoutPnl.Size = new Size(smallWidth * widthMultiplier, bigHeight);
            TableLayoutPnl.Location = new Point((int)((Width - TableLayoutPnl.Width) / 2.0), smallWidth * 2 + SketchesLbl.Height);
        }

        /// <summary>
        /// Displays drawing with/without sketch item after
        /// its visability is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SketchLb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (SketchLb.SelectedIndex != -1)
            {
                Owner.Sketches[(Part)SketchLb.SelectedItem] = !SketchLb.GetItemChecked(SketchLb.SelectedIndex);
                Owner.DisplayDrawings();
            }
        }

        /// <summary>
        /// Updates the selected sketch according to the sender's input.
        /// </summary>
        /// <param name="sender">The UI object that sent the update</param>
        /// <param name="e"></param>
        private void SketchUpdate(object sender, EventArgs e)
        {
            if (SketchLb.SelectedIndex == -1)
            {
                return;
            }
            var selectedPart = (Part)SketchLb.SelectedItem;

            if (sender == DeleteSketchBtn)
            {
                Owner.Sketches.Remove(selectedPart);
                SketchLb.Items.RemoveAt(SketchLb.SelectedIndex);
            }
            else if (sender == XUpDown)
            {
                selectedPart.ToPiece().State.X = (float)XUpDown.Value;
            }
            else if (sender == YUpDown)
            {
                selectedPart.ToPiece().State.Y = (float)YUpDown.Value;
            }
            else if (sender == RotationBar)
            {
                selectedPart.ToPiece().State.R = RotationBar.Value;
            }
            else if (sender == TurnBar)
            {
                selectedPart.ToPiece().State.T = TurnBar.Value;
            }
            else if (sender == SpinBar)
            {
                selectedPart.ToPiece().State.S = SpinBar.Value;
            }
            else if (sender == SizeBar)
            {
                selectedPart.ToPiece().State.SM = SizeBar.Value;
            }

            Owner.DisplayDrawings();
        }

        /// <summary>
        /// Opens a LoadTab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadSketchBtn_Click(object sender, EventArgs e)
        {
            Utils.NewTabPage(new LoadPieceTab(Owner.Owner, Owner), "Load");
        }
    }
}