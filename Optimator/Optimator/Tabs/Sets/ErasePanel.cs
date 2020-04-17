using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Sets
{
    /// <summary>
    /// A panel to manage the erasure of rotation/turned boards.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class ErasePanel : PanelControl
    {
        private readonly SetsTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public ErasePanel(SetsTab owner)
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
            float widthPercent = 0.1F;

            int smallWidth = (int)(Width * widthPercent);

            EraseLbl.Location = new Point(smallWidth, smallWidth);
        }
    }
}
