using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Sets
{
    /// <summary>
    /// A panel to manage the erasure of rotation/turned boards.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class OrderPanel : PanelControl
    {
        private readonly SetsTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public OrderPanel(SetsTab owner)
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
            var bigWidthPercent = 0.8F;
            var heightPercent = 0.2F;

            var smallWidth = (int)(Width * widthPercent);
            var bigWidth = (int)(Width * bigWidthPercent);
            var bigHeight = (int)(Height * heightPercent);

            OrderLbl.Location = new Point(smallWidth, smallWidth);

            TableLayoutPnl.Size = new Size(bigWidth, bigHeight);
            TableLayoutPnl.Location = new Point((int)((Width - bigWidth) / 2.0), 3 * smallWidth + OrderLbl.Height);
        }

        /// <summary>
        /// Moves the selected piece upwards or downwards in order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpDownBtn_Click(object sender, System.EventArgs e)
        {
            if (Owner.selected == null)
            {
                return;
            }

            var selectedIndex = Owner.WIP.PiecesList.IndexOf(Owner.selected);
            var condition = sender == UpBtn ? selectedIndex != -1 && selectedIndex < Owner.WIP.PiecesList.Count - 1 : selectedIndex > 0;
            if (condition)
            {
                var change = sender == UpBtn ? 1 : -1;
                var holding = Owner.WIP.PiecesList[selectedIndex];
                Owner.WIP.PiecesList[selectedIndex] = Owner.WIP.PiecesList[selectedIndex + change];
                Owner.WIP.PiecesList[selectedIndex + change] = holding;
                Owner.DisplayDrawings();
            }
        }
    }
}
