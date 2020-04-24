using Optimator.Tabs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Forms
{
    /// <summary>
    /// A tab to display and manage the program settings.
    /// </summary>
    public partial class HelpTab : TabPageControl
    {
        public override HomeForm Owner { get; set; }

        /// <summary>
        /// Constructor for the tab.
        /// </summary>
        public HelpTab(HomeForm owner)
        {
            InitializeComponent();
            Owner = owner;
            VersionLbl.Text = "Version " + Consts.Version;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab.
        /// </summary>
        public override void Resize()
        {
            var smallWidthPercent = 0.02F;
            var heightPercent = 0.4F;

            var smallWidth = (int)(Width * smallWidthPercent);
            var bigHeight = (int)(Height * heightPercent);

            HelpLbl.Location = new Point(smallWidth, smallWidth + ToolStrip.Height);
            VersionLbl.Location = new Point(smallWidth, smallWidth * 2 + HelpLbl.Height + ToolStrip.Height);

            InfoLbl.Location = new Point(smallWidth, smallWidth * 3 + HelpLbl.Height 
                + VersionLbl.Height + ToolStrip.Height);
            InfoLbl.Size = new Size(Width - 2 * smallWidth, bigHeight);
        }
    }
}
