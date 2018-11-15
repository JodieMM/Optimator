using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animator
{
    /// <summary>
    /// The opening form.
    /// </summary>
    public partial class MenuForm : Form
    {

        /// <summary>
        /// Constructor for the form.
        /// </summary>
        public MenuForm()
        {
            InitializeComponent();
        }



        // ----- MENU BUTTONS -----

        /// <summary>
        /// Closes the application entirely.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

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
        /// Shows the form for compiling a video.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompileBtn_Click(object sender, EventArgs e)
        {
            CompileVideo vidForm = new CompileVideo();
            vidForm.Show();
        }
    }
}
