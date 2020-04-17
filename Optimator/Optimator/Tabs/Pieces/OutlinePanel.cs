using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            OutlineWidthBox.Value = Owner.WIP.OutlineWidth;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            float widthPercent = 0.1F;
            float heightPercent = 0.2F;

            int smallWidth = (int)(Width * widthPercent);
            int bigHeight = (int)(Height * heightPercent);

            OutlineLbl.Location = new Point(smallWidth, smallWidth);

            TableLayoutPnl.Size = new Size(smallWidth * 8, bigHeight);
            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 2 + OutlineLbl.Height);

            Enable(Owner.selectedSpot != null);
        }

        /// <summary>
        /// Enables or disables the panel's controls.
        /// </summary>
        /// <param name="enable">False if disabling</param>
        public void Enable(bool enable = true)
        {
            ConnectorOptions.Enabled = enable;
        }

        /// <summary>
        /// Updates the values of the panel's controls.
        /// </summary>
        /// <param name="outlineWidth">New outline width</param>
        /// <param name="connector">New connector option</param>
        public void UpdateValues(decimal outlineWidth, string connector)
        {
            Enable();
            OutlineWidthBox.Value = outlineWidth;
            ConnectorOptions.SelectedIndex = Array.IndexOf(Consts.connectorOptions, connector);
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
                Owner.selectedSpot.Connector = Consts.connectorOptions[ConnectorOptions.SelectedIndex];
                Owner.DisplayDrawings();
            }
        }
    }
}
