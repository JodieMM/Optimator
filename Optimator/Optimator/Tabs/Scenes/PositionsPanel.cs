using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Scenes
{
    /// <summary>
    /// A panel to manage parts' original positions.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class PositionsPanel : PanelControl
    {
        private readonly ScenesTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public PositionsPanel(ScenesTab owner)
        {
            InitializeComponent();
            Owner = owner;
            EnableControls(Owner.selected != null);
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var bigWidthPercent = 0.9F;
            var widthPercent = 0.05F;
            var bigHeightPercent = 0.75F;

            var smallWidth = (int)(Width * widthPercent);
            var bigWidth = (int)(Width * bigWidthPercent);
            var bigHeight = (int)(Height * bigHeightPercent);

            PositionsLbl.Location = new Point(smallWidth, smallWidth);
            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 3 + PositionsLbl.Height);
            TableLayoutPnl.Size = new Size(bigWidth, bigHeight);
            UpBtn.Height = DownBtn.Height = (int)(Height < 600 ? bigHeight / 7.0 : bigHeight / 10.0);
        }

        /// <summary>
        /// Moves the selected set or piece upwards in position.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpBtn_Click(object sender, EventArgs e)
        {
            if (Owner.selected == null)
            {
                return;
            }
            var selectedIndex = Owner.WIP.PartsList.IndexOf(Owner.selected);
            if (selectedIndex == -1 || selectedIndex == Owner.WIP.PartsList.Count - 1)
            {
                return;
            }

            // Update PartsList
            Owner.WIP.PartsList[selectedIndex] = Owner.WIP.PartsList[selectedIndex + 1];
            Owner.WIP.PartsList[selectedIndex + 1] = Owner.selected;

            Owner.DisplayDrawings();
        }

        /// <summary>
        /// Moves the selected set or piece downwards in position.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownBtn_Click(object sender, EventArgs e)
        {
            if (Owner.selected == null)
            {
                return;
            }
            var selectedIndex = Owner.WIP.PartsList.IndexOf(Owner.selected);
            if (selectedIndex == -1 || selectedIndex == 0)
            {
                return;
            }

            // Update PartsList
            Owner.WIP.PartsList[selectedIndex] = Owner.WIP.PartsList[selectedIndex - 1];
            Owner.WIP.PartsList[selectedIndex - 1] = Owner.selected;

            Owner.DisplayDrawings();
        }

        /// <summary>
        /// Reacts to UI elements to update the selected piece.
        /// </summary>
        /// <param name="sender">Modified UI element</param>
        /// <param name="e"></param>
        private void UpdateSelectedPiece(object sender, EventArgs e)
        {
            if (Owner.selected == null)
            {
                return;
            }
            Part modifying = Owner.subSelected ?? Owner.selected;
            if (sender == RotationBar)
            {
                Owner.WIP.Originals[modifying].R = RotationBar.Value;
                ValueToolTip.SetToolTip(sender as Control, (sender as TrackBar).Value.ToString());
            }
            else if (sender == TurnBar)
            {
                Owner.WIP.Originals[modifying].T = TurnBar.Value;
                ValueToolTip.SetToolTip(sender as Control, (sender as TrackBar).Value.ToString());
            }
            else if (sender == SpinBar)
            {
                Owner.WIP.Originals[modifying].S = SpinBar.Value;
                ValueToolTip.SetToolTip(sender as Control, (sender as TrackBar).Value.ToString());
            }
            else if (sender == XUpDown)
            {
                Owner.WIP.Originals[modifying].X = (int)XUpDown.Value;
            }
            else if (sender == YUpDown)
            {
                Owner.WIP.Originals[modifying].Y = (int)YUpDown.Value;
            }
            else if (sender == SizeBar)
            {
                Owner.WIP.Originals[modifying].SM = SizeBar.Value / 100.0F;
                ValueToolTip.SetToolTip(sender as Control, (sender as TrackBar).Value.ToString());
            }
            if (sender == ActiveControl)
            {
                Owner.DisplayDrawings();
            }
        }

        /// <summary>
        /// Update the UI to match drag movements.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void UpdateXY(int x, int y)
        {
            XUpDown.Value = x;
            YUpDown.Value = y;
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



        // ----- OTHER FUNCTIONS -----

        public void EnableControls(bool enable = true)
        {
            Utils.EnableObjects(new List<Control>() { RotationBar, TurnBar, SpinBar, XUpDown, YUpDown, SizeBar }, enable);
            if (enable)
            {
                RotationBar.Value = (int)Owner.WIP.Originals[Owner.selected].R;
                TurnBar.Value = (int)Owner.WIP.Originals[Owner.selected].T;
                SpinBar.Value = (int)Owner.WIP.Originals[Owner.selected].S;
                XUpDown.Value = (decimal)Owner.WIP.Originals[Owner.selected].X;
                YUpDown.Value = (decimal)Owner.WIP.Originals[Owner.selected].Y;
                SizeBar.Value = (int)Owner.WIP.Originals[Owner.selected].SM * 100;
            }
        }
    }
}
