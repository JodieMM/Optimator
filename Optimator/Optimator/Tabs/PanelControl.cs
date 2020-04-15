using System.Windows.Forms;

namespace Optimator.Tabs
{
    /// <summary>
    /// An abstract class to define the mutual needs of UserControls 
    /// filling Panels.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public abstract class PanelControl : UserControl
    {
        // private readonly BaseTab Owner;      Set in constructor


        /// <summary>
        /// Resizes the panel's contents.
        /// </summary>
        public new abstract void Resize();
    }
}
