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

            FpsUpDown.Value = Owner.WIP.FPS;
            VideoWidthUpDown.Value = Owner.WIP.videoWidth;
            VideoHeightUpDown.Value = Owner.WIP.videoHeight;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var bigWidthPercent = 0.8F;
            var widthPercent = 0.05F;
            var bigHeightPercent = 0.15F;

            var smallWidth = (int)(Width * widthPercent);
            var bigWidth = (int)(Width * bigWidthPercent);
            var bigHeight = (int)(Height * bigHeightPercent);

            SettingsLbl.Location = new Point(smallWidth, smallWidth);
            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 3 + SettingsLbl.Height);
            TableLayoutPnl.Size = new Size(bigWidth, bigHeight);
        }

        /// <summary>
        /// Updates the video's FPS.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FpsUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            Owner.WIP.FPS = FpsUpDown.Value;
        }

        /// <summary>
        /// Updates the video's width.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoWidthUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            Owner.WIP.videoWidth = (int)VideoWidthUpDown.Value;
        }

        /// <summary>
        /// Updates the video's height.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoHeightUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            Owner.WIP.videoHeight = (int)VideoHeightUpDown.Value;
        }
    }
}
