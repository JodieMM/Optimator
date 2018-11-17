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
    /// A form for viewing the load options.
    /// </summary>
    public partial class PiecesForm_LoadMenu : Form
    {
        #region Load Menu Variables
        private string goal;
        private PiecesForm baseForm;
        #endregion


        /// <summary>
        /// Constructor for the Load Menu.
        /// </summary>
        /// <param name="from">PiecesForm that spawned the request</param>
        public PiecesForm_LoadMenu(PiecesForm from)
        {
            InitializeComponent();
            baseForm = from;
        }



        // ----- MENU BUTTONS -----

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fillBtn_Click(object sender, EventArgs e)
        {
            goal = "fillColour";
            end();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outlineBtn_Click(object sender, EventArgs e)
        {
            goal = "outlineColour";
            end();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bothBtn_Click(object sender, EventArgs e)
        {
            goal = "colours";
            end();
        }



        // ----- OTHER FUNCTIONS -----

        /// <summary>
        /// 
        /// </summary>
        private void end()
        {
            baseForm.LoadIn(goal);
            Close();
        }
    }
}
