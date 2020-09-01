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
            BgColourBox.BackColor = Owner.WIP.Background;
            SceneWidthUpDown.Value = Owner.WIP.Width;
            SceneHeightUpDown.Value = Owner.WIP.Height;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var bigWidthPercent = 0.8F;
            var widthPercent = 0.05F;
            var bigHeightPercent = 0.7F;

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

        /// <summary>
        /// Updates the scene width or height setting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SceneSizeUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            Owner.SetDrawPanelSize(sender == SceneWidthUpDown ? (int)SceneWidthUpDown.Value : Owner.WIP.Width,
                sender == SceneHeightUpDown ? (int)SceneHeightUpDown.Value : Owner.WIP.Height);
            Owner.DisplayDrawings();
        }

        /// <summary>
        /// Update the scene background colour.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgColourBox_Click(object sender, System.EventArgs e)
        {
            var MyDialog = new ColorDialog
            {
                Color = BgColourBox.BackColor,
                FullOpen = true
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                BgColourBox.BackColor = MyDialog.Color;
                Owner.WIP.Background = MyDialog.Color;
                Owner.SetDrawPanelColour(MyDialog.Color);
            }
        }
    }
}
