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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PiecesBtn_Click(object sender, EventArgs e)
        {
            PiecesForm pieceform = new PiecesForm();
            pieceform.Show();
        }

        private void AnimateBtn_Click(object sender, EventArgs e)
        {
            ScenesForm sceneform = new ScenesForm();
            sceneform.Size = new System.Drawing.Size(976, 600);
            sceneform.Show();
        }

        private void SetsBtn_Click(object sender, EventArgs e)
        {
            SetsForm setform = new SetsForm();
            setform.Size = new System.Drawing.Size(875, 750);
            setform.Show();
        }

        private void animateBtn_Click_1(object sender, EventArgs e)
        {
            CompileVideo vidForm = new CompileVideo();
            vidForm.Size = new System.Drawing.Size(1186, 791);
            vidForm.Show();
        }
    }
}
