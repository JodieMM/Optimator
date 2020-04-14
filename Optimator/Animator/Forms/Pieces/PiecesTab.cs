using Animator.Forms;
using Optimator;
using System.Drawing;
using System.Windows.Forms;

namespace Animator
{
    /// <summary>
    /// A tab used to create new pieces.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class PiecesTab : UserControl
    {
        private HomeForm Owner;
        private Piece WIP = new Piece();

        /// <summary>
        /// Constructor for the control.
        /// </summary>
        /// <param name="owner"></param>
        public PiecesTab(HomeForm owner)
        {
            InitializeComponent();
            Owner = owner;
            SelectedInfoLbl.Text = "Click on the top left square to outline the front view of your shape.";
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab.
        /// </summary>
        public new void Resize()
        {
            float widthPercent = Width > 950 ? 0.25F : 0.3F;
            float widthBigPercent = Width > 950 ? 0.3F : 0.33F;
            float heightPercent = Height > 560 ? 0.45F : 0.4F;

            int bigWidth = (int)(Width * widthPercent);
            int largeWidth = (int)(Width * widthBigPercent);
            int bigHeight = (int)(Height * heightPercent);
            int bigLength = bigWidth > bigHeight ? bigHeight : bigWidth;

            int lilWidth = (int)((Width - 2 * bigLength - largeWidth) / 3.0);
            int lilHeight = (int)((Height - 2 * bigLength - ToolStrip.Height) / 3.0);

            DrawBase.Size = DrawRight.Size = DrawDown.Size = SelectedInfoLbl.Size = new Size(bigLength, bigLength);
            DrawBase.Location = new Point(lilWidth, lilHeight + ToolStrip.Height);           
            DrawRight.Location = new Point(lilWidth * 2 + bigLength, lilHeight + ToolStrip.Height);
            DrawDown.Location = new Point(lilWidth, lilHeight * 2 + bigLength + ToolStrip.Height);
            SelectedInfoLbl.Location = new Point(lilWidth * 2 + bigLength, lilHeight * 2 + bigLength + ToolStrip.Height);

            Panel.Width = largeWidth;

            EraseRightBtn.Size = EraseDownBtn.Size = new Size((int)(bigLength * 0.1), (int)(bigLength * 0.1));
            EraseRightBtn.Location = new Point(DrawRight.Location.X + DrawRight.Size.Width -
                EraseRightBtn.Width, DrawRight.Location.Y);
            EraseDownBtn.Location = new Point(DrawDown.Location.X + DrawDown.Size.Width -
                EraseDownBtn.Width, DrawDown.Location.Y);
        }

        #region ToolStrip

        /// <summary>
        /// Opens a preview form for the WIP Piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Click(object sender, System.EventArgs e)
        {
            PreviewTab tab = new PreviewTab(WIP);
            Owner.AddTabPage("Preview " + WIP.Name, tab);
            tab.Resize();
        }

        #endregion


        // ----- PIECE FUNCTIONS -----
    }
}
