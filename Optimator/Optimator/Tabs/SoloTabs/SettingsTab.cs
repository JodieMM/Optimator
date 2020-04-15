using Optimator.Tabs;
using System;

namespace Optimator.Forms
{
    /// <summary>
    /// A tab to display and manage the program settings.
    /// </summary>
    public partial class SettingsTab : TabPageControl
    {
        public override HomeForm Owner { get; set; }

        /// <summary>
        /// Constructor for the tab.
        /// </summary>
        public SettingsTab(HomeForm owner)
        {
            InitializeComponent();
            Owner = owner;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab.
        /// </summary>
        public override void Resize()
        {
            //float widthPercent = 0.75F;
            //float widthSmallPercent = 0.2F;
            //float heightPercent = 0.9F;

            //float trackLong = 0.8F;
            //float trackShort = 0.1F;

            //int bigWidth = (int)(Width * widthPercent);
            //int bigHeight = (int)(Height * heightPercent);
            //int bigLength = bigHeight < bigWidth ? bigHeight : bigWidth;


            //int smallWidth = (int)(Width * widthSmallPercent);
            //int lilWidth = (int)((Width - bigLength - smallWidth) / 4.0);
            //int smallHeight = (int)((Height - bigHeight - ToolStrip.Height) / 2.0);

            //DrawPanel.Size = new Size(bigLength, bigLength);
            //DrawPanel.Location = new Point(lilWidth, smallHeight + ToolStrip.Height);

            //OptionsMenu.Size = new Size(smallWidth, bigLength);
            //OptionsMenu.Location = new Point(bigLength + 3 * lilWidth, smallHeight + ToolStrip.Height);

            //RotationTrack.Size = new Size((int)(DrawPanel.Width * trackLong), (int)(DrawPanel.Height * trackShort));
            //RotationTrack.Location = new Point((int)(DrawPanel.Location.X + (DrawPanel.Width - RotationTrack.Width) / 2.0),
            //    (int)(DrawPanel.Location.Y + DrawPanel.Height - RotationTrack.Height * 1.25));

            //TurnTrack.Size = new Size((int)(DrawPanel.Width * trackShort), (int)(DrawPanel.Height * trackLong));
            //TurnTrack.Location = new Point((int)(DrawPanel.Location.X + DrawPanel.Width - TurnTrack.Width * 1.25),
            //    (int)(DrawPanel.Location.Y + (DrawPanel.Height - TurnTrack.Height) / 2.0));
        }
    }
}
