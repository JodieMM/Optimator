using System;
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
        private void SketchLbSelectChange(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate {
                Owner.DisplayDrawings();
            });
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
            if (sender == DeleteSketchBtn)
            {
                Owner.Sketches.RemoveAt(SketchLb.SelectedIndex);
                SketchLb.Items.RemoveAt(SketchLb.SelectedIndex);
            }
            else if (sender == RotationBar)
            {
                Owner.Sketches[SketchLb.SelectedIndex].ToPiece().State.R = RotationBar.Value;
            }
            else if (sender == TurnBar)
            {
                Owner.Sketches[SketchLb.SelectedIndex].ToPiece().State.T = TurnBar.Value;
            }
            else if (sender == SpinBar)
            {
                Owner.Sketches[SketchLb.SelectedIndex].ToPiece().State.S = SpinBar.Value;
            }
            else if (sender == SizeBar)
            {
                Owner.Sketches[SketchLb.SelectedIndex].ToPiece().State.SM = SizeBar.Value;
            }
            else if (sender == XUpDown)
            {
                Owner.Sketches[SketchLb.SelectedIndex].ToPiece().State.X = (double)XUpDown.Value;
            }
            else if (sender == YUpDown)
            {
                Owner.Sketches[SketchLb.SelectedIndex].ToPiece().State.Y = (double)YUpDown.Value;
            }
            Owner.DisplayDrawings();
        }
    }
}
