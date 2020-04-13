using System;
using System.Windows.Forms;

namespace Animator
{
    /// <summary>
    /// The main form that hosts all others as sub elements.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        //protected override void OnResize(EventArgs eventargs)
        //{
        //    foreach(TabPage page in TabControl.Controls)
        //    {
        //        foreach (Control cntl in page.Controls)
        //        {
        //            if (cntl is PiecesTab)
        //            {
        //                (cntl as PiecesTab).Resize();
        //                (cntl as PiecesTab).PerformLayout();
        //                (cntl as PiecesTab).Invalidate();
        //            }
        //        }
        //    }
        //    Update();
        //}

        #region Tool Strip Clicks

        /// <summary>
        /// Adds a new PiecesTab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PieceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage page = new TabPage("New Piece");
            PiecesTab tab = new PiecesTab(page)
            {
                Dock = DockStyle.Fill
            };            
            page.Controls.Add(tab);
            TabControl.Controls.Add(page);
            tab.Resize();
            TabControl.SelectedIndex = TabControl.Controls.Count - 1;
        }

        #endregion
    }
}
