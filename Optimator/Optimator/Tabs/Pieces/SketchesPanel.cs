using Optimator.Tabs.SoloTabs;
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
        /// Enable controls when a sketch is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SketchLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableControls(SketchLb.SelectedIndex != -1);
            if (SketchLb.SelectedIndex != -1)
            {
                var selectedPart = (Part)SketchLb.SelectedItem;
                XUpDown.Value = (decimal)selectedPart.ToPiece().State.X;
                YUpDown.Value = (decimal)selectedPart.ToPiece().State.Y;
                SpinBar.Value = (int)selectedPart.ToPiece().State.S;
                SizeBar.Value = (int)(selectedPart.ToPiece().State.SM * 100);
                RotationBar.Value = (int)selectedPart.ToPiece().State.R;
                TurnBar.Value = (int)selectedPart.ToPiece().State.T;
            }
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
                ValueToolTip.SetToolTip(sender as Control, (sender as TrackBar).Value.ToString());
            }
            else if (sender == TurnBar)
            {
                selectedPart.ToPiece().State.T = TurnBar.Value;
                ValueToolTip.SetToolTip(sender as Control, (sender as TrackBar).Value.ToString());
            }
            else if (sender == SpinBar)
            {
                selectedPart.ToPiece().State.S = SpinBar.Value;
                ValueToolTip.SetToolTip(sender as Control, (sender as TrackBar).Value.ToString());
            }
            else if (sender == SizeBar)
            {
                selectedPart.ToPiece().State.SM = SizeBar.Value / 100.0F;
                ValueToolTip.SetToolTip(sender as Control, (sender as TrackBar).Value.ToString());
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

        /// <summary>
        /// Adds a tool tip to the track bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackHover(object sender, EventArgs e)
        {
            ValueToolTip.SetToolTip(sender as Control, (sender as TrackBar).Value.ToString());
        }

        /// <summary>
        /// Enables or disables the sketch controls.
        /// </summary>
        /// <param name="enable">True if enabled</param>
        private void EnableControls(bool enable = true)
        {
            XUpDown.Enabled = enable;
            YUpDown.Enabled = enable;
            SpinBar.Enabled = enable;
            SizeBar.Enabled = enable;
            RotationBar.Enabled = enable;
            TurnBar.Enabled = enable;
            DeleteSketchBtn.Enabled = enable;
        }
    }
}
