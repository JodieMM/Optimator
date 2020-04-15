using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optimator.Tabs.Pieces
{
    /// <summary>
    /// A panel to manage a piece's outline.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class OutlinePanel : PanelControl
    {
        private readonly PiecesTab Owner;

        
        /// <summary>
        /// Constructor for the tab.
        /// </summary>
        public OutlinePanel(PiecesTab owner)
        {
            InitializeComponent();
            Owner = owner;
            OutlineWidthBox.Value = Owner.WIP.OutlineWidth;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            //TODO: Resize
        }

        /// <summary>
        /// Changes the outline width of the piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutlineWidthBox_ValueChanged(object sender, EventArgs e)
        {
            Owner.WIP.OutlineWidth = OutlineWidthBox.Value;
            Owner.DisplayDrawings();
        }
    }
}
