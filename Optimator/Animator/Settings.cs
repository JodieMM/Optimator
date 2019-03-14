using System.Collections.Generic;
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
        public static string Version;
        public static Color BackgroundColour;
        #endregion

        
        // ----- LOADING AND SAVING -----

        /// <summary>
        /// Loads the settings that have been saved to the program.
        /// </summary>
        /// <param name="file">The file to load the settings from</param>
        public static void InitialSettings(string file = Constants.Settings)
        {
            var data = Utilities.ReadFile(file);
            if (data.Count < 2)
                data = Utilities.ReadFile(Constants.DefaultSettings);

            Version = data[0];
            if (!Utilities.CheckValidVersion(Version))
            {
                // TODO: Add extra rows from initial to settings if required
            }

            // Set Settings
            BackgroundColour = Utilities.ColourFromString(data[1]);           
        }

        /// <summary>
        /// Saves the current settings to the file in the program.
        /// </summary>
        public static void UpdateSettings()
        {
            var data = new List<string>
            {
                Version,
                Utilities.ColorToString(BackgroundColour)
            };
            Utilities.SaveData(Constants.Settings, data);
        }

        /// <summary>
        /// Returns the settings to their original values.
        /// </summary>
        public static void ResetSettings()
        {
            var result = MessageBox.Show("This will erase all custom settings. Continue?", "Setting Reset Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                InitialSettings(Constants.DefaultSettings);
                UpdateSettings();
            }
        }
    }
}
