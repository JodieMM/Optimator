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
    public partial class PiecesForm : Form
    {
        // Variables
        Graphics g;
        List<Piece> sketch;
        Piece WIP;


        /// <summary>
        /// Constructor creates a PiecesForm page
        /// </summary>
        public PiecesForm()
        {
            InitializeComponent();
        }


        // ----- DRAWING BOARDS -----

        /// <summary>
        /// Places or selects a point on the main board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawBase_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Places or selects a point on the rotation board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawRight_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Places or selects a point on the turn board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawDown_Click(object sender, EventArgs e)
        {

        }


        // ----- MAIN BUTTONS -----

        /// <summary>
        /// Changes between placing points and selecting them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointBtn_Click(object sender, EventArgs e)
        {
            PointBtn.Text = (PointBtn.Text == "Select") ? "Place" : "Select";
        }

        /// <summary>
        /// When active, overrides point placement/selection and removes points
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EraserBtn_Click(object sender, EventArgs e)
        {
            EraserBtn.Text = (EraserBtn.Text == "Eraser") ? "Point" : "Eraser";
        }

        /// <summary>
        /// Opens a preview panel to display the piece in full angles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            // Currently inaccessible               ** EXTRA
        }
    }
}
