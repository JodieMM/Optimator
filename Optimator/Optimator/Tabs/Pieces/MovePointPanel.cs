using System;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Pieces
{
    /// <summary>
    /// A panel to display information and update the selected point.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class MovePointPanel : PanelControl
    {
        private readonly PiecesTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        /// <param name="owner"></param>
        public MovePointPanel(PiecesTab owner)
        {
            InitializeComponent();
            Owner = owner;
            if (Owner.selectedSpot == null)
            {
                UpdateLabels();
            }
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the panel.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.05F;
            var heightPercent = 0.2F;

            var smallWidth = (int)(Width * widthPercent);
            var bigHeight = (int)(Height * heightPercent);

            MovePointLbl.Location = new Point(smallWidth, smallWidth);

            TableLayoutPnl.Size = new Size(smallWidth * 12, bigHeight);
            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 3 + MovePointLbl.Height);
        }

        /// <summary>
        /// Updates the contents of the coord labels to be blank.
        /// </summary>
        public void UpdateLabels()
        {
            XUpDown.Value = YUpDown.Value = 0;
            XUpDown.Enabled = YUpDown.Enabled = false;
        }

        /// <summary>
        /// Updates the contents of the coord labels to provided coords.
        /// </summary>
        /// <param name="sent">Whether the update came from 0 Base 1 Rot or 2 Turn</param>
        /// <param name="x">X coord for label</param>
        /// <param name="y">Y coord for label</param>
        public void UpdateLabels(int sent, double x, double y)
        {
            XUpDown.Enabled = sent != 2;
            YUpDown.Enabled = sent != 1;
            XUpDown.Value = (decimal)x;
            YUpDown.Value = (decimal)y;
        }

        /// <summary>
        /// Update the selected spot's X coord.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Owner.selectedSpot != null)
            {
                if (YUpDown.Enabled)
                {
                    Owner.selectedSpot.X = (double)XUpDown.Value;
                }
                Owner.selectedSpot.XRight = (double)XUpDown.Value;
            }
        }

        /// <summary>
        /// Update the selected spot's Y coord.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Owner.selectedSpot != null)
            {
                if (XUpDown.Enabled)
                {
                    Owner.selectedSpot.Y = (double)YUpDown.Value;
                }
                Owner.selectedSpot.YDown = (double)YUpDown.Value;
            }
        }
    }
}
