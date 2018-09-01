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
    public partial class PiecesForm_LoadMenu : Form
    {
        string goal;
        PiecesForm baseForm;

        public PiecesForm_LoadMenu(PiecesForm from)
        {
            InitializeComponent();
            baseForm = from;
        }

        private void fillBtn_Click(object sender, EventArgs e)
        {
            goal = "fillColour";
            end();
        }

        private void outlineBtn_Click(object sender, EventArgs e)
        {
            goal = "outlineColour";
            end();
        }

        private void bothBtn_Click(object sender, EventArgs e)
        {
            goal = "colours";
            end();
        }

        private void end()
        {
            baseForm.LoadIn(goal);
            this.Close();
        }
    }
}
