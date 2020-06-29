using Optimator.Tabs;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System;

namespace Optimator.Forms.Pieces
{
    /// <summary>
    /// A panel for saving parts.
    /// </summary>
    public partial class SavePanel : PanelControl
    {
        private readonly PiecesTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public SavePanel(PiecesTab owner)
        {
            InitializeComponent();
            Owner = owner;
            Owner.Owner.GetTabControl().KeyDown += KeyPress;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.9F;
            var heightPercent = 0.4F;

            var bigWidth = (int)(Width * widthPercent);
            var lilWidth = (int)((Width - bigWidth) / 2.0);

            SaveLbl.Location = new Point(lilWidth, lilWidth);
            TableLayoutPnl.Location = new Point(lilWidth, lilWidth * 3 + SaveLbl.Height);
            TableLayoutPnl.Size = new Size(bigWidth, (int)(Height * heightPercent));
        }

        /// <summary>
        /// Saves the WIP.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Save(sender);
        }

        /// <summary>
        /// Save the WIP and close the tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            if (Save(sender))
            {
                Owner.Owner.RemoveTabPage(Owner);
            }            
        }

        /// <summary>
        /// Runs when a key is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void KeyPress(object sender, KeyEventArgs e)
        {
            if (ContainsFocus)
            {
                switch (e.KeyCode)
                {
                    // Enter Pressed
                    case Keys.Enter:
                        SaveBtn_Click(sender, e);
                        break;

                    // Do nothing for any other key
                    default:
                        break;
                }
            }
        }



        // ----- UTILITY FUNCTIONS -----

        /// <summary>
        /// Saves the piece.
        /// </summary>
        /// <returns>True if successful</returns>
        private bool Save(object sender)
        {
            if (!Owner.CheckPiecesValid())
            {
                return false;
            }

            var clone = Utils.ClonePiece(Owner.WIP);
            Utils.CentrePieceOnAxis(clone);
            Owner.Directory = Utils.SaveFile(clone.GetData(), Consts.PieceFilter, sender == SaveAsBtn ? "" : Owner.Directory);
            if (Owner.Directory != "")
            {
                Owner.Parent.Text = Utils.BaseName(Owner.Directory);
                return true;
            }
            return false;
        }
    }
}
