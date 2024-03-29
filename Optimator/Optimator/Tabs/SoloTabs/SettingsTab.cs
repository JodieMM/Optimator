﻿using Optimator.Tabs;
using Optimator.Properties;
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
        private string directory = "";

        /// <summary>
        /// Constructor for the tab.
        /// </summary>
        public SettingsTab(HomeForm owner)
        {
            InitializeComponent();
            Owner = owner;
            DisplaySettings();
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab.
        /// </summary>
        public override void Resize()
        {
            var smallWidthPercent = 0.02F;
            var bigWidthPercent = 1F;
            var heightPercent = Height < 600 ? Height < 500 ? 0.5F : 0.6F : 0.7F;

            var smallWidth = (int)(Width * smallWidthPercent);
            var bigWidth = (int)(Width * bigWidthPercent);
            var bigHeight = (int)(Height * heightPercent);

            SettingsLbl.Location = new Point(smallWidth, smallWidth + ToolStrip.Height);
            VersionLbl.Location = new Point(smallWidth, smallWidth * 2 + SettingsLbl.Height + ToolStrip.Height);

            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 3 + SettingsLbl.Height 
                + VersionLbl.Height + ToolStrip.Height);
            TableLayoutPnl.Size = new Size(bigWidth - 2 * smallWidth, bigHeight);
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



        // ----- DISPLAY -----

        /// <summary>
        /// Displays the current settings to the screen.
        /// </summary>
        public void DisplaySettings()
        {
            VersionLbl.Text = "Version " + "Beta 1.1";//TODO: Return Settings.Default.Version;
            BackColourBox.BackColor = Utils.ColourFromString(Settings.Default.BgColour);
            WorkingDirValueLbl.Text = "Current Directory: " + Settings.Default.WorkingDirectory;
            SaveVideoFramesCb.Checked = Settings.Default.SaveVideoFrames;
            SceneWidthUpDown.Value = Settings.Default.SceneWidth;
            SceneHeightUpDown.Value = Settings.Default.SceneHeight;
            FPSUpDown.Value = Settings.Default.FPS;
        }



        // ----- BUTTONS -----

        /// <summary>
        /// Resets the settings to the default values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Settings.Default.BgColour = Utils.ColorToString(Color.White);
            Settings.Default.WorkingDirectory = "Blank";
            Settings.Default.SceneWidth = 1920;
            Settings.Default.SceneHeight = 1080;
            Settings.Default.FPS = 60;
            DisplaySettings();
        }

        /// <summary>
        /// Saves the changes made to settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Settings.Default.BgColour = Utils.ColorToString(BackColourBox.BackColor);
            if (directory != "")
            {
                Settings.Default.WorkingDirectory = directory;
                directory = "";
            }
            Settings.Default.SceneWidth = (int)Math.Round(SceneWidthUpDown.Value, MidpointRounding.AwayFromZero);
            Settings.Default.SceneHeight = (int)Math.Round(SceneHeightUpDown.Value, MidpointRounding.AwayFromZero);
            Settings.Default.SaveVideoFrames = SaveVideoFramesCb.Checked;
            Settings.Default.FPS = (int)Math.Round(FPSUpDown.Value, MidpointRounding.AwayFromZero);
            Settings.Default.Save();
        }

        /// <summary>
        /// Closes the form. Any unsaved changes will be lost.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void CloseBtn_Click(object sender, EventArgs e)
        {
            var result = DialogResult.OK;

            // Only check saving if something to save
            if (SomethingToChange())
            {
                result = MessageBox.Show("Do you want to exit without saving? Modified settings will not be saved.", "Exit Confirmation", MessageBoxButtons.OKCancel);
            }
            if (result == DialogResult.OK)
            {
                Owner.RemoveTabPage(this);
            }
        }

        /// <summary>
        /// Checks if changes have been made that need saving/ will be lost.
        /// </summary>
        /// <returns>True if changes exist</returns>
        private bool SomethingToChange()
        {
            return BackColourBox.BackColor.ToArgb() != Utils.ColourFromString(Settings.Default.BgColour).ToArgb() ||
                directory != "" || SaveVideoFramesCb.Checked != Settings.Default.SaveVideoFrames ||
                SceneWidthUpDown.Value != Settings.Default.SceneWidth || SceneHeightUpDown.Value != Settings.Default.SceneHeight ||
                FPSUpDown.Value != Settings.Default.FPS;
        }



        // ----- SETTING CHANGES -----

        /// <summary>
        /// Changes the back colour of the drawing panels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackColourBox_Click(object sender, EventArgs e)
        {
            var MyDialog = new ColorDialog
            {
                Color = BackColourBox.BackColor,
                FullOpen = true
            };
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                BackColourBox.BackColor = MyDialog.Color;                
            }
        }

        /// <summary>
        /// Changes the current working directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewWorkingDirectoryBtn_Click(object sender, EventArgs e)
        {
            var path = Utils.SelectFolder();
            if (path != "")
            {
                WorkingDirValueLbl.Text = "Current Directory: " + path;
                directory = path;
            }
        }
    }
}
