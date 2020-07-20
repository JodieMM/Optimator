using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Pieces
{
    /// <summary>
    /// A panel to manage the pieces tab settings.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class SettingsPanel : PanelControl
    {
        private readonly PiecesTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public SettingsPanel(PiecesTab owner)
        {
            InitializeComponent();
            Owner = owner;
            ShowPointsCb.Checked = Owner.showPoints;
            BackColourBox.BackColor = Owner.GetBoardColor();
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.05F;

            var smallWidth = (int)(Width * widthPercent);

            SettingsLbl.Location = new Point(smallWidth, smallWidth);
            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 3 + SettingsLbl.Height);
            TableLayoutPnl.Size = new Size(Width - 2 * smallWidth, TableLayoutPnl.Size.Height);
        }

        /// <summary>
        /// Changes whether points should be drawn or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPointsCb_CheckedChanged(object sender, System.EventArgs e)
        {
            Owner.showPoints = ShowPointsCb.Checked;
            Owner.DisplayDrawings();
        }

        /// <summary>
        /// Changes the background colour of the display.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackColourBox_Click(object sender, System.EventArgs e)
        {
            var MyDialog = new ColorDialog
            {
                Color = BackColourBox.BackColor,
                FullOpen = true
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                BackColourBox.BackColor = MyDialog.Color;
                Owner.ChangeDrawingBgs(MyDialog.Color);
                Owner.DisplayDrawings();
            }
        }
    }
}
