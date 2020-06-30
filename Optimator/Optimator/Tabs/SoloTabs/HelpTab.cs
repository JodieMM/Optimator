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
            VersionLbl.Text = "Version " + Properties.Settings.Default.Version;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.02F;
            var heightPercent = 0.7F;

            var smallWidth = (int)(Width * widthPercent);
            var bigHeight = (int)(Height * heightPercent);

            HelpLbl.Location = new Point(smallWidth, smallWidth + ToolStrip.Height);
            VersionLbl.Location = new Point(smallWidth, smallWidth * 2 + HelpLbl.Height + ToolStrip.Height);

            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 3 + HelpLbl.Height 
                + VersionLbl.Height + ToolStrip.Height);
            TableLayoutPnl.Size = new Size(Width - 2 * smallWidth, bigHeight);
        }

        /// <summary>
        /// Sends users to the Opti YouTube page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YoutubeLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCiip8jvHNeyuF37XpmbgNog/");
        }

        /// <summary>
        /// Sends users to the Opti website.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptiSiteLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.opti.technology/");
        }



        // ----- PANEL REFRESH TIMER

        /// <summary>
        /// Starts the drawing timer once the tab has been created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void RefreshDrawPanel(object sender, EventArgs e)
        {
            //Nothing Needed
        }
    }
}
