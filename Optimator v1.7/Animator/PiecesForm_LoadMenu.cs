using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Animator
{
    /// <summary>
    /// A form for viewing the load options.
    /// </summary>
    public partial class PiecesForm_LoadMenu : Form
    {
        #region Load Menu Variables
        private Piece WIP;
        private PiecesForm from;
        private Piece loaded = null;

        private Graphics g;

        private Color button = Color.LightPink;
        private Color select = Color.FromArgb(255, 255, 153, 179);
        #endregion


        /// <summary>
        /// Constructor for the Load Menu.
        /// </summary>
        /// <param name="from">PiecesForm that spawned the request</param>
        public PiecesForm_LoadMenu(PiecesForm fromBase)
        {
            InitializeComponent();
            from = fromBase;
            WIP = fromBase.WIP;
        }



        // ----- MENU BUTTONS -----

        /// <summary>
        /// Loads the entered point.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                loaded = new Piece(NameTb.Text);
                DrawPanel.Refresh();
                g = DrawPanel.CreateGraphics();
                Utilities.DrawPiece(loaded, g, false);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Suspected outdated file.", "File Indexing Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Sets the WIP fill colour to match the loaded piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillColourBtn_Click(object sender, EventArgs e)
        {
            if (loaded != null)
            {
                if (AllBtn.BackColor == select) { AllBtn.BackColor = button; }
                FillColourBtn.BackColor = (FillColourBtn.BackColor == button) ? select : button;
            }
        }

        /// <summary>
        /// Sets the WIP outline colour to match the loaded piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutlineColourBtn_Click(object sender, EventArgs e)
        {
            if (loaded != null)
            {
                if (AllBtn.BackColor == select) { AllBtn.BackColor = button; }
                OutlineColourBtn.BackColor = (OutlineColourBtn.BackColor == button) ? select : button;
            }
        }

        /// <summary>
        /// Sets the WIP outline width to match the loaded piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutlineWidthBtn_Click(object sender, EventArgs e)
        {
            if (loaded != null)
            {
                if (AllBtn.BackColor == select) { AllBtn.BackColor = button; }
                OutlineWidthBtn.BackColor = (OutlineWidthBtn.BackColor == button) ? select : button;
            }
        }

        /// <summary>
        /// Sets the WIP piece details to match the loaded piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PieceDetailsBtn_Click(object sender, EventArgs e)
        {
            if (loaded != null)
            {
                if (AllBtn.BackColor == select) { AllBtn.BackColor = button; }
                PieceDetailsBtn.BackColor = (PieceDetailsBtn.BackColor == button) ? select : button;
            }
        }

        /// <summary>
        /// Sets the WIP attributes to match the loaded piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllBtn_Click(object sender, EventArgs e)
        {
            if (loaded != null)
            {
                if (AllBtn.BackColor == button)
                {
                    if (FillColourBtn.BackColor == select) { FillColourBtn.BackColor = button; }
                    if (OutlineColourBtn.BackColor == select) { OutlineColourBtn.BackColor = button; }
                    if (OutlineWidthBtn.BackColor == select) { OutlineWidthBtn.BackColor = button; }
                    if (PieceDetailsBtn.BackColor == select) { PieceDetailsBtn.BackColor = button; }
                    AllBtn.BackColor = select;
                }
                else
                {
                    AllBtn.BackColor = button;
                }
            }
        }

        /// <summary>
        /// Loads the entire piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShapeBtn_Click(object sender, EventArgs e)
        {
            if (loaded != null)
            {
                ShapeBtn.BackColor = (ShapeBtn.BackColor == button) ? select : button;
            }
        }

        /// <summary>
        /// Adds the loaded piece to the sketch list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SketchBtn_Click(object sender, EventArgs e)
        {
            if (loaded != null)
            {
                SketchBtn.BackColor = (SketchBtn.BackColor == button) ? select : button;
            }
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            if (FillColourBtn.BackColor == select || AllBtn.BackColor == select)
            {
                WIP.FillColour = loaded.FillColour;
            }
            if (OutlineColourBtn.BackColor == select || AllBtn.BackColor == select)
            {
                WIP.OutlineColour = loaded.OutlineColour;
            }
            if (OutlineWidthBtn.BackColor == select || AllBtn.BackColor == select)
            {
                WIP.OutlineWidth = loaded.OutlineWidth;
            }
            if (PieceDetailsBtn.BackColor == select || AllBtn.BackColor == select)
            {
                WIP.PieceDetails = loaded.PieceDetails;
            }
            if (ShapeBtn.BackColor == select)
            {
                // ** TO DO
            }
            if (SketchBtn.BackColor == select)
            {
                from.Sketch.Add(loaded);
            }

            from.DisplayDrawings();
            from.UpdateAttributes();
            Close();
        }
    }
}
