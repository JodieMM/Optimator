using System;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Pieces
{
    /// <summary>
    /// A panel to manage a piece's options.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class OptionsPanel : PanelControl
    {
        private readonly PiecesTab Owner;

        
        /// <summary>
        /// Constructor for the tab.
        /// </summary>
        public OptionsPanel(PiecesTab owner)
        {
            InitializeComponent();
            Owner = owner;
            PieceOptionsCb.Items.AddRange(Enum.GetNames(typeof(Consts.PieceOption)));
            PieceOptionsCb.SelectedIndex = (int)Owner.WIP.Type;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.05F;
            var heightPercent = 0.2F;

            var smallWidth = (int)(Width * widthPercent);
            var bigHeight = (int)(Height * heightPercent);

            OptionsLbl.Location = new Point(smallWidth, smallWidth);

            TableLayoutPnl.Size = new Size(smallWidth * 16, bigHeight);
            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 3 + OptionsLbl.Height);
        }

        /// <summary>
        /// Changes the piece type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PieceOptionsCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Owner.WIP.Type = (Consts.PieceOption)PieceOptionsCb.SelectedIndex;
            Owner.DisplayDrawings();
        }
    }
}
