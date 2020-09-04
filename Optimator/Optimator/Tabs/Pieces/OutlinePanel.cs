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
                UpdateValues(Owner.WIP.OutlineWidth, Owner.selectedSpot.Connector, (decimal)Owner.selectedSpot.Tension);
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
            var heightPercent = 0.2F;

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
        }

        /// <summary>
        /// Updates the values of the panel's controls.
        /// </summary>
        /// <param name="outlineWidth">New outline width</param>
        /// <param name="connector">New connector option</param>
        /// <param name="tension">Curve tension</param>
        public void UpdateValues(decimal outlineWidth, Consts.SpotOption connector, decimal tension)
        {
            Enable();
            OutlineWidthBox.Value = outlineWidth;
            ConnectorOptions.SelectedIndex = (int)connector;
            if (connector == Consts.SpotOption.Curve)
            {
                TensionLbl.Visible = TensionUpDown.Visible = ConnectorOptions.SelectedIndex == (int)Consts.SpotOption.Curve;
                TensionUpDown.Value = tension;
            }
        }

        /// <summary>
        /// Changes the outline width of the piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutlineWidthBox_ValueChanged(object sender, EventArgs e)
        {
            Owner.WIP.OutlineWidth = OutlineWidthBox.Value;
            Owner.DisplayDrawings();
        }

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
    }
}
