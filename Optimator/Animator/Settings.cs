﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Animator
{
    /// <summary>
    /// Holds and updates the settings for the program.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public static class Settings
    {
        #region Settings Variables
        // When adding new settings, update Initial Settings and Update Settings
        public static string Version;
        public static Color BackgroundColour;
        public static string WorkingDirectory;
        #endregion

        
        // ----- LOADING AND SAVING -----

        /// <summary>
        /// Loads the settings that have been saved to the program.
        /// </summary>
        /// <param name="file">The file to load the settings from</param>
        public static void InitialSettings(string file = Consts.Settings)
        {
            // Read settings data and check valid
            var data = Utils.ReadFile(file);
            if (data.Count < 1 && file != Consts.DefaultSettings)
            {
                ResetSettings(false);
                return;
            } 

            // Check version and update if required
            Version = data[0];
            if (!Utils.CheckValidVersion(Version, false) && file == Consts.Settings)
            {
                var defaultData = Utils.ReadFile(Consts.DefaultSettings);
                defaultData.RemoveRange(0, data.Count);
                data.AddRange(defaultData);
            }

            // Set Settings
            BackgroundColour = Utils.ColourFromString(data[1]);
            WorkingDirectory = data[2];

            // Save Changes if Updated
            if (!Utils.CheckValidVersion(Version, false) && file == Consts.Settings)
                UpdateSettings();
        }

        /// <summary>
        /// Saves the current settings to the file in the program.
        /// </summary>
        public static void UpdateSettings()
        {
            var data = new List<string>
            {
                Version,
                Utils.ColorToString(BackgroundColour),
                WorkingDirectory
            };
            Utils.SaveFile(Consts.Settings, data);
        }

        /// <summary>
        /// Returns the settings to their original values.
        /// </summary>
        public static void ResetSettings(bool msg = true)
        {
            var result = msg ? MessageBox.Show("This will erase all custom settings. Continue?", "Setting Reset Confirmation", MessageBoxButtons.OKCancel)
                : DialogResult.OK;
            if (result == DialogResult.OK)
            {
                InitialSettings(Consts.DefaultSettings);
                UpdateSettings();
            }
        }
    }
}
