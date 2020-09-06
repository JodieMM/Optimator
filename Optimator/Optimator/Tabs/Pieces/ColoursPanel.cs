using System;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Pieces
{
    /// <summary>
    /// A panel for changing the fill colours of a piece.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class ColoursPanel : PanelControl
    {
        private readonly PiecesTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public ColoursPanel(PiecesTab owner)
        {
            InitializeComponent();
            Owner = owner;
            FillBox.BackColor = Utils.ColourFromString(Owner.WIP.ColourState.Details[0]);
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab's contents.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.05F;
            var heightPercent = 0.3F;

            var smallWidth = (int)(Width * widthPercent);
            var bigHeight = (int)(Height * heightPercent);

            ColoursLbl.Location = new Point(smallWidth, smallWidth);
            FillBox.Height = (int)(bigHeight / 4.0);

            TableLayoutPnl.Size = new Size(smallWidth * 12, bigHeight);
            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 3 + ColoursLbl.Height);
        }

        /// <summary>
        /// Changes the fill colour of the shape.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillBox_Click(object sender, EventArgs e)
        {
            var MyDialog = new ColorDialog
            {
                Color = FillBox.BackColor,
                FullOpen = true
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                FillBox.BackColor = MyDialog.Color;
                Owner.WIP.ColourState.Layers[0] = Consts.FillOption.Fill;
                Owner.WIP.ColourState.Details[0] = Utils.ColorToString(MyDialog.Color);
                Owner.DisplayDrawings();
            }
        }
    }
}
