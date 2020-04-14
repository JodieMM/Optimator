using System;
using System.Windows.Forms;

namespace Optimator
{
    /// <summary>
    /// The opening form.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class MenuForm : Form
    {
        /// <summary>
        /// Constructor for the form.
        /// </summary>
        public MenuForm()
        {
            InitializeComponent();
            Settings.InitialSettings();
        }



        // ----- MENU BUTTONS -----

        /// <summary>
        /// Shows the form for creating a piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PiecesBtn_Click(object sender, EventArgs e)
        {
            PiecesForm pieceform = new PiecesForm();
            pieceform.Show();
        }

        /// <summary>
        /// Shows the form for creating a set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetsBtn_Click(object sender, EventArgs e)
        {
            SetsForm setform = new SetsForm();
            setform.Show();
        }

        /// <summary>
        /// Shows the form for animating a scene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimateBtn_Click(object sender, EventArgs e)
        {
            ScenesForm sceneform = new ScenesForm();
            sceneform.Show();
        }

        /// <summary>
        /// Shows the form for compiling a video.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompileBtn_Click(object sender, EventArgs e)
        {
            CompileVideo vidForm = new CompileVideo();
            vidForm.Show();
        }

        /// <summary>
        /// Shows the form for changing the settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }

        /// <summary>
        /// Closes the application entirely.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }    
    }
}
