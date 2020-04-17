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
            float widthPercent = 0.1F;
            float bigWidthPercent = 0.8F;
            float heightPercent = 0.4F;

            int smallWidth = (int)(Width * widthPercent);
            int bigWidth = (int)(Width * bigWidthPercent);
            int bigHeight = (int)(Height * heightPercent);

            OrderLbl.Location = new Point(smallWidth, smallWidth);

            TableLayoutPnl.Size = new Size(bigWidth, bigHeight);
            TableLayoutPnl.Location = new Point((int)((Width - bigWidth) / 2.0), 2 * smallWidth + OrderLbl.Height);
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

            int selectedIndex = Owner.WIP.PiecesList.IndexOf(Owner.selected);
            bool condition = sender == UpBtn ? selectedIndex != -1 && selectedIndex < Owner.WIP.PiecesList.Count - 1 : selectedIndex > 0;
            if (condition)
            {
                int change = sender == UpBtn ? 1 : -1;
                Piece holding = Owner.WIP.PiecesList[selectedIndex];
                Owner.WIP.PiecesList[selectedIndex] = Owner.WIP.PiecesList[selectedIndex + change];
                Owner.WIP.PiecesList[selectedIndex + change] = holding;
                Owner.DisplayDrawings();
            }
        }
    }
}
