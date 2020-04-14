using Animator.Forms;
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
        /// <summary>
        /// Constructor for the form.
        /// </summary>
        public HomeForm()
        {
            InitializeComponent();
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the sub-elements of the form.
        /// </summary>
        /// <param name="eventargs"></param>
        protected override void OnResize(EventArgs eventargs)
        {
            TabControl.Width = Width;
            TabControl.Height = Height;
            foreach (TabPage page in TabControl.Controls)
            {
                foreach (Control cntl in page.Controls)
                {
                    if (cntl is PiecesTab)
                    {
                        (cntl as PiecesTab).Resize();
                    }
                    else if (cntl is PreviewTab)
                    {
                        (cntl as PreviewTab).Resize();
                    }
                }
            }
        }



        // ----- TOOL STRIP -----

        public void AddTabPage(string name, UserControl tab)
        {
            TabPage page = new TabPage(name);
            tab.Dock = DockStyle.Fill;
            page.Controls.Add(tab);
            TabControl.Controls.Add(page);
            TabControl.SelectedIndex = TabControl.Controls.Count - 1;
        }

        #region Tool Strip Clicks

        // ----- NEW -----

        /// <summary>
        /// Adds a new PiecesTab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPieceTSMI_Click(object sender, EventArgs e)
        {
            PiecesTab tab = new PiecesTab(this);
            AddTabPage("New Piece", tab);
            tab.Resize();
        }



        // ----- OPEN -----

        /// <summary>
        /// Opens an existing piece in a new PiecesTab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPieceTSMI_Click(object sender, EventArgs e)
        {
            PiecesTab tab = new PiecesTab(this);    //PieceName = ...
            AddTabPage("New Piece", tab);
            tab.Resize();
        }


        #endregion
    }
}
