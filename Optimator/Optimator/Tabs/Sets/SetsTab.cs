using Optimator;
using Optimator.Forms;
using Optimator.Tabs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Sets
{
    /// <summary>
    /// A tab used to generate and modify sets.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class SetsTab : TabPageControl
    {
        #region Sets Form Variables
        public override HomeForm Owner { get; set; }

        private Set WIP = new Set();
        private Piece selected = null;
        private Join selectedJoin = null;

        private Graphics original;
        private Graphics rotated;
        private Graphics turned;

        private int moving = -1;                // -1 = not, 0 = X & Y, 1 = X, 2 = Y
        private bool movingFar = false;         // Whether the piece is being selected or moved
        private int[] originalMoving;
        #endregion
        

        /// <summary>
        /// Constructor for the tab.
        /// </summary>
        /// <param name="owner"></param>
        public SetsTab(HomeForm owner)
        {
            InitializeComponent();
            Owner = owner;

            //HIDDEN KeyUp += KeyPress;

            //HIDDEN Utils.CheckValidFolder();
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab.
        /// </summary>
        public override void Resize()
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

            DrawBase.Size = DrawRight.Size = DrawDown.Size = new Size(bigLength, bigLength);
            DrawBase.Location = new Point(lilWidth, lilHeight + ToolStrip.Height);
            DrawRight.Location = new Point(lilWidth * 2 + bigLength, lilHeight + ToolStrip.Height);
            DrawDown.Location = new Point(lilWidth, lilHeight * 2 + bigLength + ToolStrip.Height);

            Panel.Width = largeWidth;
            Utils.ResizePanel(Panel);
        }

        #region ToolStrip

        private void SaveBtn_Click(object sender, EventArgs e)
        {

        }

        private void AddPartBtn_Click(object sender, EventArgs e)
        {

        }

        private void JoinsBtn_Click(object sender, EventArgs e)
        {

        }

        private void PositionsBtn_Click(object sender, EventArgs e)
        {

        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {

        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Opens a preview form for the WIP Set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            //if (CheckPiecesValid())
            //{
            //    Piece clone = Utils.ClonePiece(WIP);
            //    Utils.CentrePieceOnAxis(clone);
            //    PreviewTab newTab = new PreviewTab(Owner, clone);
            //    Utils.NewTabPage(newTab, "Preview " + WIP.Name);
            //}
        }

        #endregion
    }
}
