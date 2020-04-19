using Optimator.Tabs;
using System;
using System.Drawing;
using System.Windows.Forms;

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
            VersionLbl.Text = "Version " + Consts.Version;
            DisplaySettings();
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab.
        /// </summary>
        public override void Resize()
        {
            float smallWidthPercent = 0.02F;
            float heightPercent = 0.4F;

            int smallWidth = (int)(Width * smallWidthPercent);
            int bigHeight = (int)(Height * heightPercent);

            SettingsLbl.Location = new Point(smallWidth, smallWidth + ToolStrip.Height);
            VersionLbl.Location = new Point(smallWidth, smallWidth * 2 + SettingsLbl.Height + ToolStrip.Height);

            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 3 + SettingsLbl.Height 
                + VersionLbl.Height + ToolStrip.Height);
            TableLayoutPnl.Size = new Size(Width - 2 * smallWidth, bigHeight);
        }



        // ----- DISPLAY -----

        /// <summary>
        /// Displays the current settings to the screen.
        /// </summary>
        private void DisplaySettings()
        {
            BackColourBox.BackColor = Settings.BackgroundColour;
            WorkingDirValueLbl.Text = "Current Directory: " + Settings.WorkingDirectory;
        }



        // ----- BUTTONS -----

        /// <summary>
        /// Resets the settings to the default values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Settings.ResetSettings();
            DisplaySettings();
        }

        /// <summary>
        /// Saves the changes made to settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Settings.UpdateSettings();
        }

        /// <summary>
        /// Closes the form. Any unsaved changes will be lost.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void CloseBtn_Click(object sender, EventArgs e)
        {
            Settings.InitialSettings();
            Owner.RemoveTabPage(this);
        }



        // ----- SETTING CHANGES -----

        /// <summary>
        /// Changes the back colour of the drawing panels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackColourBox_Click(object sender, System.EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog
            {
                Color = BackColourBox.BackColor,
                FullOpen = true
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                BackColourBox.BackColor = MyDialog.Color;
                Settings.BackgroundColour = MyDialog.Color;
            }
        }

        /// <summary>
        /// Changes the current working directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewWorkingDirectoryBtn_Click(object sender, System.EventArgs e)
        {
            var path = Utils.SelectFolder(true);
            if (path != "")
            {
                WorkingDirValueLbl.Text = "Current Directory: " + path;
            }
        }
    }
}
