﻿using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Pieces
{
    /// <summary>
    /// A panel to manage the erasure of rotation/turned boards.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class ErasePanel : PanelControl
    {
        private readonly PiecesTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public ErasePanel(PiecesTab owner)
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

            EraseLbl.Location = new Point(smallWidth, smallWidth);
        }
    }
}
