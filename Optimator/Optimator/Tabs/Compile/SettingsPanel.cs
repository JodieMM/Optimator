using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Compile
{
    /// <summary>
    /// A panel to manage the scenes tab settings.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class SettingsPanel : PanelControl
    {
        private readonly CompileTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public SettingsPanel(CompileTab owner)
        {
            InitializeComponent();
            Owner = owner;

            FpsUpDown.Value = Owner.FPS;
            PreviewCb.Checked = Owner.GetPreviewVisible();
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var bigWidthPercent = 0.8F;
            var widthPercent = 0.05F;
            var bigHeightPercent = 0.25F;

            var smallWidth = (int)(Width * widthPercent);
            var bigWidth = (int)(Width * bigWidthPercent);
            var bigHeight = (int)(Height * bigHeightPercent);

            SettingsLbl.Location = new Point(smallWidth, smallWidth);
            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 3 + SettingsLbl.Height);
            TableLayoutPnl.Size = new Size(bigWidth, bigHeight);
        }

        /// <summary>
        /// Modifies the DisplayPanel visibility.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewCb_CheckedChanged(object sender, System.EventArgs e)
        {
            Owner.ShowPreview(PreviewCb.Checked);
        }

        /// <summary>
        /// Updates the video's FPS.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FpsUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            Owner.FPS = FpsUpDown.Value;
        }
    }
}
