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

            NameTb.Width = bigWidth;
            NameTb.Location = new Point(lilWidth, lilWidth);

            CompleteBtn.Size = new Size(bigWidth, (int)(Height * heightPercent));
            CompleteBtn.Location = new Point(lilWidth, Height - lilWidth - CompleteBtn.Height);
        }

        /// <summary>
        /// Save the WIP and close the tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteBtn_Click(object sender, System.EventArgs e)
        {
            //TODO: Add another button for simply 'save' rather than also closing the form
            if (!Utils.CheckValidNewName(NameTb.Text, Consts.PiecesFolder) || !Owner.CheckPiecesValid())
            {
                return;
            }

            // Save Piece and Close Form
            try
            {
                Utils.CentrePieceOnAxis(Owner.WIP);
                Utils.SaveFile(Utils.GetDirectory(Consts.PiecesFolder, NameTb.Text, Consts.Optr), Owner.WIP.GetData());
                Owner.CloseBtn_Click(sender, e);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No data entered for point", "Missing Data", MessageBoxButtons.OK);
            }
        }
    }
}
