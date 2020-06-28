using System;
using System.Windows.Forms;

namespace Optimator.Tabs
{
    /// <summary>
    /// An abstract class to define the mutual needs of UserControls 
    /// filling TabPages of TabControls.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public abstract class TabPageControl : UserControl
    {
        public abstract HomeForm Owner { get; set; }


        /// <summary>
        /// Resizes the tab contents.
        /// </summary>
        public new abstract void Resize();

        /// <summary>
        /// Redraws the visuals on the tab page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void RefreshDrawPanel(object sender, EventArgs e);

        /// <summary>
        /// Closes this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CloseBtn_Click(object sender, EventArgs e)
        {
            Owner.RemoveTabPage(this);
        }
    }
}
