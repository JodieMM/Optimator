using System;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Pieces
{
    /// <summary>
    /// A panel to manage a piece's outline.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class OutlinePanel : PanelControl
    {
        private readonly PiecesTab Owner;

        
        /// <summary>
        /// Constructor for the tab.
        /// </summary>
        public OutlinePanel(PiecesTab owner)
        {
            InitializeComponent();
            Owner = owner;
            ConnectorOptions.Items.AddRange(Enum.GetNames(typeof(Consts.SpotOption)));
            if (Owner.selectedSpot != null)
            {
                var spot = Owner.selectedSpot;
                UpdateValues(spot.Connector, (decimal)spot.Tension, spot.Line.Width, spot.Line.Colour, spot.Line.Visible);
            }
            else
            {
                Enable(false);
            }
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.05F;
            var heightPercent = 0.7F;

            var smallWidth = (int)(Width * widthPercent);
            var bigHeight = (int)(Height * heightPercent);

            OutlineLbl.Location = new Point(smallWidth, smallWidth);

            TableLayoutPnl.Size = new Size(smallWidth * 16, bigHeight);
            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 3 + OutlineLbl.Height);

            Enable(Owner.selectedSpot != null);
        }

        /// <summary>
        /// Enables or disables the panel's controls.
        /// </summary>
        /// <param name="enable">False if disabling</param>
        public void Enable(bool enable = true)
        {
            ConnectorOptions.Enabled = enable;
            TensionUpDown.Enabled = enable;
            VisibleCb.Enabled = enable;
            WidthLbl.Text = enable ? "Width" : "Width (All)";
            OutlineColourLbl.Text = enable ? "Colour" : "Colour (All)";
        }

        /// <summary>
        /// Updates the values of the panel's controls.
        /// </summary>
        /// <param name="outlineWidth">New outline width</param>
        /// <param name="connector">New connector option</param>
        /// <param name="tension">Curve tension</param>
        public void UpdateValues(Consts.SpotOption connector, decimal tension, float[] outlineWidth, Color[] outlineColour, bool visible)
        {
            Enable();

            ConnectorOptions.SelectedIndex = (int)connector;
            TensionLbl.Visible = TensionUpDown.Visible = ConnectorOptions.SelectedIndex == (int)Consts.SpotOption.Curve;
            TensionUpDown.Value = tension;

            WidthUpDown.Value = (decimal)outlineWidth[0];
            ColourBox.BackColor = outlineColour[0];
            VisibleCb.Checked = visible;
        }



        // ----- POINT FUNCTIONS -----

        /// <summary>
        /// Changes the join at the selected point.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectorOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Owner.selectedSpot != null)
            {
                Owner.selectedSpot.Connector = (Consts.SpotOption)ConnectorOptions.SelectedIndex;
                Owner.DisplayDrawings();
                TensionLbl.Visible = TensionUpDown.Visible = ConnectorOptions.SelectedIndex == (int)Consts.SpotOption.Curve;
                TensionUpDown.Value = (decimal)Owner.selectedSpot.Tension;
            }
        }

        /// <summary>
        /// Changes the tension of the selected curve.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TensionUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Owner.selectedSpot != null && Owner.selectedSpot.Connector == Consts.SpotOption.Curve)
            {
                Owner.selectedSpot.Tension = (float)TensionUpDown.Value;

                // Also Convert Previous/Future Curves
                var spotIndex = Owner.WIP.Data.IndexOf(Owner.selectedSpot);
                if (spotIndex != -1)
                {
                    // Previous
                    var modIndex = Utils.NextIndex(Owner.WIP.Data, spotIndex, false);
                    while (Owner.WIP.Data[modIndex].Connector == Consts.SpotOption.Curve && modIndex != spotIndex)
                    {
                        Owner.WIP.Data[modIndex].Tension = (float)TensionUpDown.Value;
                        modIndex = Utils.NextIndex(Owner.WIP.Data, modIndex, false);
                    }
                    // Future
                    modIndex = Utils.NextIndex(Owner.WIP.Data, spotIndex);
                    while (Owner.WIP.Data[modIndex].Connector == Consts.SpotOption.Curve && modIndex != spotIndex)
                    {
                        Owner.WIP.Data[modIndex].Tension = (float)TensionUpDown.Value;
                        modIndex = Utils.NextIndex(Owner.WIP.Data, modIndex);
                    }
                }

                Owner.DisplayDrawings();
            }
        }



        // ----- LINE FUNCTIONS -----

        /// <summary>
        /// Changes the outline width of the piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WidthUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Owner.selectedSpot != null)
            {
                Owner.selectedSpot.Line.Width = new float[] { (float)WidthUpDown.Value };
            }
            else
            {
                foreach (var spot in Owner.WIP.Data)
                {
                    spot.Line.Width = new float[] { (float)WidthUpDown.Value };
                }
            }
            Owner.DisplayDrawings();
        }

        /// <summary>
        /// Changes the outline colour of the piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColourBox_Click(object sender, EventArgs e)
        {
            var MyDialog = new ColorDialog
            {
                Color = ColourBox.BackColor,
                FullOpen = true
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                ColourBox.BackColor = MyDialog.Color;
                if (Owner.selectedSpot != null)
                {
                    Owner.selectedSpot.Line.Colour = new Color[] { MyDialog.Color };
                }
                else
                {
                    foreach (var spot in Owner.WIP.Data)
                    {
                        spot.Line.Colour = new Color[] { MyDialog.Color };
                    }
                }
                Owner.DisplayDrawings();
            }
        }

        /// <summary>
        /// Changes whether the point is visible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisibleCb_CheckedChanged(object sender, EventArgs e)
        {
            if (Owner.selectedSpot != null)
            {
                Owner.selectedSpot.Line.Visible = VisibleCb.Checked;
                Owner.DisplayDrawings();
            }
        }
    }
}
