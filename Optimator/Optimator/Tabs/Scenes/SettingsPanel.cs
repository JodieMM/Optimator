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
            PreviewCb.Checked = Owner.GetPreviewVisible();
            TimeIncrementUpDown.Value = Owner.TimeIncrement;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            float bigWidthPercent = 0.8F;
            float widthPercent = 0.05F;
            float bigHeightPercent = 0.2F;

            int smallWidth = (int)(Width * widthPercent);
            int bigWidth = (int)(Width * bigWidthPercent);
            int bigHeight = (int)(Height * bigHeightPercent);

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
        /// Changes the time between preview frames.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeIncrementUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            Owner.TimeIncrement = TimeIncrementUpDown.Value;
        }
    }
}
