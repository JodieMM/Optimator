using Optimator.Tabs.Compile;
using Optimator.Tabs.Scenes;
using Optimator.Tabs.Sets;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Optimator.Tabs.SoloTabs
{
    /// <summary>
    /// A tab to allow users to enter the name of the part they wish to open.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class OpenDialog : TabPageControl
    {
        public override HomeForm Owner { get; set; }
        private TabPageControl attemptOpen;

        /// <summary>
        /// Constructor for the tab.
        /// </summary>
        /// <param name="partType">The name of the part type</param>
        public OpenDialog(HomeForm owner, string partType, TabPageControl tabPage)
        {
            InitializeComponent();
            Owner = owner;
            attemptOpen = tabPage;
            OpenLbl.Text = "Open " + partType;
            NameTb.Text = partType + " Name";            
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the page.
        /// </summary>
        public override void Resize()
        {
            var smallWidthPercent = 0.05F;
            var widthPercent = 0.4F;
            var heightPercent = 0.2F;

            var smallWidth = (int)(Width * smallWidthPercent);

            OpenLbl.Location = new Point(smallWidth, smallWidth + ToolStrip.Height);
            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 2 + OpenLbl.Height + ToolStrip.Height);
            TableLayoutPnl.Size = new Size((int)(Width * widthPercent), (int)(Height * heightPercent));
        }

        /// <summary>
        /// Attempts to open the entered part.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (attemptOpen is PiecesTab)
                {
                    (attemptOpen as PiecesTab).WIP = new Piece(NameTb.Text);
                }
                else if (attemptOpen is SetsTab)
                {
                    (attemptOpen as SetsTab).WIP = new Set(NameTb.Text);
                }
                else if (attemptOpen is ScenesTab)
                {
                    (attemptOpen as ScenesTab).WIP = new Scene(NameTb.Text);
                }
                //TODO: Save videos
                //else if (attemptOpen is CompileTab)
                //{
                //    (attemptOpen as PiecesTab).WIP = new Piece(NameTb.Text);
                //}
                Owner.AddTabPage(NameTb.Text, attemptOpen);
                attemptOpen.Resize();
                CancelBtn_Click(sender, e);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Suspected outdated file.", "File Indexing Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Cancels the open.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Owner.RemoveTabPage(this);
        }
    }
}
