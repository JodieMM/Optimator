using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.SoloTabs
{
    public partial class LoadingMessage : UserControl
    {
        public LoadingMessage()
        {
            InitializeComponent();
            int panelWidth = (int)(TableLayoutPnl.Width / 3.0);
            LoadingLbl.Location = new Point(0, (int)((panelWidth - LoadingLbl.Height) / 2.0));
            PatienceLbl.Location = new Point(0, (int)(panelWidth * 2 + (panelWidth - PatienceLbl.Height) / 2.0));
        }
    }
}
