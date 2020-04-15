using System;
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
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the panel.
        /// </summary>
        public override void Resize()
        {
            //TODO: Resize panel
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
