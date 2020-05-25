using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Scenes
{
    /// <summary>
    /// A panel to manage the scenes tab settings.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class SettingsPanel : PanelControl
    {
        private readonly ScenesTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public SettingsPanel(ScenesTab owner)
        {
            InitializeComponent();
            Owner = owner;

            SelectFromTopCb.Checked = Owner.SelectFromTop;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var bigWidthPercent = 0.8F;
            var widthPercent = 0.05F;
            var bigHeightPercent = 0.2F;

            var smallWidth = (int)(Width * widthPercent);
            var bigWidth = (int)(Width * bigWidthPercent);
            var bigHeight = (int)(Height * bigHeightPercent);

            SettingsLbl.Location = new Point(smallWidth, smallWidth);
            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 3 + SettingsLbl.Height);
            TableLayoutPnl.Size = new Size(bigWidth, bigHeight);
        }

        /// <summary>
        /// Modifies the SelectFromTop setting in owner.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFromTopCb_CheckedChanged(object sender, System.EventArgs e)
        {
            Owner.SelectFromTop = SelectFromTopCb.Checked;
        }
    }
}
