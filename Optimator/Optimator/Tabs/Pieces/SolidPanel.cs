namespace Optimator.Tabs.Pieces
{
    /// <summary>
    /// A panel to manage a point's fixed status.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class SolidPanel : PanelControl
    {
        private readonly PiecesTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public SolidPanel(PiecesTab owner)
        {
            InitializeComponent();
            Owner = owner;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            
        }
    }
}
