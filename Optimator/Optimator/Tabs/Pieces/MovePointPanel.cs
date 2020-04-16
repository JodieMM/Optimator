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
        /// Updates the contents of the coord labels to be blank.
        /// </summary>
        public void UpdateLabels()
        {
            XCoordLbl.Text = "";
            YCoordLbl.Text = "";
        }

        /// <summary>
        /// Updates the contents of the coord labels to provided coords.
        /// </summary>
        /// <param name="x">X coord for label</param>
        /// <param name="y">Y coord for label</param>
        public void UpdateLabels(double x, double y)
        {
            XCoordLbl.Text = x.ToString();
            YCoordLbl.Text = y.ToString();
        }
    }
}
