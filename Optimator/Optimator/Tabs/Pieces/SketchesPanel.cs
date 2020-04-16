using System;
using System.Collections.Generic;
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
            SketchLb.ItemCheck += new ItemCheckEventHandler(SketchLbSelectChange);

            foreach (KeyValuePair<Part, bool> sketch in Owner.Sketches)
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
            //TODO: Resize
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
                Owner.Sketches[(Part)SketchLb.SelectedItem] = SketchLb.GetItemChecked(SketchLb.SelectedIndex);
                Owner.DisplayDrawings();
                // HIDDEN: See if can be removed
                //BeginInvoke((MethodInvoker)delegate
                //{
                //    Owner.DisplayDrawings();
                //});
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
            Part selectedPart = (Part)SketchLb.SelectedItem;

            if (sender == DeleteSketchBtn)
            {
                Owner.Sketches.Remove(selectedPart);
                SketchLb.Items.RemoveAt(SketchLb.SelectedIndex);
            }
            else if (sender == XUpDown)
            {
                selectedPart.ToPiece().State.X = (double)XUpDown.Value;
            }
            else if (sender == YUpDown)
            {
                selectedPart.ToPiece().State.Y = (double)YUpDown.Value;
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
    }
}
