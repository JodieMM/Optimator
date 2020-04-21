using System;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Pieces
{
    /// <summary>
    /// A panel for changing the fill and outline colours of a piece.
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
            FillBox.BackColor = Owner.WIP.ColourState.FillColour[0];
            OutlineBox.BackColor = Owner.WIP.ColourState.OutlineColour;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab's contents.
        /// </summary>
        public override void Resize()
        {
            float widthPercent = 0.05F;
            float heightPercent = 0.3F;

            int smallWidth = (int)(Width * widthPercent);
            int bigHeight = (int)(Height * heightPercent);

            ColoursLbl.Location = new Point(smallWidth, smallWidth);
            OutlineBox.Height = FillBox.Height = (int)(bigHeight / 4.0);

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
            ColorDialog MyDialog = new ColorDialog
            {
                Color = FillBox.BackColor,
                FullOpen = true
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                FillBox.BackColor = MyDialog.Color;
                Owner.WIP.ColourState.FillColour = new Color[] { MyDialog.Color };
                Owner.DisplayDrawings();
            }
        }

        /// <summary>
        /// Changes the outline colour of the shape.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutlineBox_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog
            {
                Color = OutlineBox.BackColor,
                FullOpen = true
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                OutlineBox.BackColor = MyDialog.Color;
                Owner.WIP.ColourState.OutlineColour = MyDialog.Color;
                Owner.DisplayDrawings();
            }
        }
    }
}
