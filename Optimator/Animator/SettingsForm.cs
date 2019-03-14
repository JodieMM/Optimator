using System.Windows.Forms;

namespace Animator
{
    /// <summary>
    /// The form for changing the settings.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// The constructor for the form.
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();
            VersionLbl.Text = "Version " + Consts.Version;
            DisplaySettings();
        }



        // ----- DISPLAY -----
        
        /// <summary>
        /// Displays the current settings to the screen.
        /// </summary>
        private void DisplaySettings()
        {
            BackColourBox.BackColor = Settings.BackgroundColour;
        }


            
        // ----- BUTTONS -----

        /// <summary>
        /// Resets the settings to the default values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetBtn_Click(object sender, System.EventArgs e)
        {
            Settings.ResetSettings();
            DisplaySettings();
        }

        /// <summary>
        /// Saves the changes made to settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, System.EventArgs e)
        {
            Settings.UpdateSettings();
        }

        /// <summary>
        /// Closes the form. Any unsaved changes will be lost.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitBtn_Click(object sender, System.EventArgs e)
        {
            Settings.InitialSettings();
            Close();
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
    }
}
