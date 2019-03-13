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

            // Display Current Settings
            VersionLbl.Text = Constants.Version;
        }



        // ----- BUTTONS -----

        /// <summary>
        /// Saves the changes made to settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, System.EventArgs e)
        {
            // TODO: for each option in the form, update the settings class

            Settings.UpdateSettings();
        }

        /// <summary>
        /// Closes the form. Any unsaved changes will be lost.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitBtn_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
