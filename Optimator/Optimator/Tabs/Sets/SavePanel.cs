using Optimator.Tabs;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System;
using Optimator.Tabs.Sets;

namespace Optimator.Forms.Sets
{
    /// <summary>
    /// A panel for saving parts.
    /// </summary>
    public partial class SavePanel : PanelControl
    {
        private readonly SetsTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public SavePanel(SetsTab owner)
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
        /// Saves the video.
        /// </summary>
        /// <returns>True if successful</returns>
        private bool Save(object sender)
        {
            if (Owner.WIP.PiecesList.Count < 1)
            {
                return false;
            }
            else if (!Owner.CheckSingularBasePiece())
            {
                MessageBox.Show("Please connect all pieces or remove unconnected pieces.", "Multiple Sets", MessageBoxButtons.OK);
            }
            else
            {
                Owner.Directory = Utils.SaveFile(Owner.WIP.GetData(), Consts.SetFilter, sender == SaveAsBtn ? "" : Owner.Directory);
                if (Owner.Directory != "")
                {
                    Owner.Parent.Text = Path.GetFileNameWithoutExtension(Owner.Directory);
                    return true;
                }
            }
            return false;
        }
    }
}
