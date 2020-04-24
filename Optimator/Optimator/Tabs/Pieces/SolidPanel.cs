using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Pieces
{
    /// <summary>
    /// A panel to manage a point's fixed status.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class SolidPanel : PanelControl
    {
        private readonly PiecesTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public SolidPanel(PiecesTab owner)
        {
            InitializeComponent();
            Owner = owner;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.05F;

            var smallWidth = (int)(Width * widthPercent);

            SolidLbl.Location = new Point(smallWidth, smallWidth);
        }
    }
}
