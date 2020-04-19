using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.SoloTabs
{
    /// <summary>
    /// A user control to alert the user the program is loading.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class LoadingMessage : UserControl
    {
        /// <summary>
        /// Constructor for the UserControl
        /// </summary>
        public LoadingMessage()
        {
            InitializeComponent();
            int panelWidth = (int)(TableLayoutPnl.Width / 3.0);
            LoadingLbl.Location = new Point(0, (int)((panelWidth - LoadingLbl.Height) / 2.0));
            PatienceLbl.Location = new Point(0, (int)(panelWidth * 2 + (panelWidth - PatienceLbl.Height) / 2.0));
        }
    }
}
