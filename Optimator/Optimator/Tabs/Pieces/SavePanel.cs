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
        }

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            float widthPercent = 0.9F;
            float heightPercent = 0.1F;

            int bigWidth = (int)(Width * widthPercent);
            int lilWidth = (int)((Width - bigWidth) / 2.0);

            SaveLbl.Location = new Point(lilWidth, lilWidth);
            NameTb.Width = bigWidth;
            NameTb.Location = new Point(lilWidth, lilWidth * 3 + SaveLbl.Height);

            CompleteBtn.Size = SaveBtn.Size = new Size(bigWidth, (int)(Height * heightPercent));
            CompleteBtn.Location = new Point(lilWidth, Height - lilWidth - CompleteBtn.Height);
            SaveBtn.Location = new Point(lilWidth, CompleteBtn.Location.Y - lilWidth - SaveBtn.Height);
        }

        /// <summary>
        /// Saves the WIP.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Save();
        }


        /// <summary>
        /// Save the WIP and close the tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteBtn_Click(object sender, System.EventArgs e)
        {
            if (Save())
            {
                Owner.Owner.RemoveTabPage(Owner);
            }            
        }

        /// <summary>
        /// Updates the tab name based on the name of the new piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTb_TextChanged(object sender, EventArgs e)
        {
            Owner.Parent.Text = NameTb.Text;
        }



        // ----- UTILITY FUNCTIONS -----

        /// <summary>
        /// Saves the piece.
        /// </summary>
        /// <returns>True if successful</returns>
        private bool Save()
        {
            if (!Utils.CheckValidNewName(NameTb.Text, Consts.PiecesFolder) || !Owner.CheckPiecesValid())
            {
                return false;
            }

            // Save Piece and Close Form
            try
            {
                Utils.CentrePieceOnAxis(Owner.WIP);
                Utils.SaveFile(Utils.GetDirectory(Consts.PiecesFolder, NameTb.Text, Consts.Optr), Owner.WIP.GetData());
                return true;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No data entered for point", "Missing Data", MessageBoxButtons.OK);
            }
            return false;
        }
    }
}
