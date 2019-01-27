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
        private Part loaded = null;

        private Graphics g;

        private Color button = Color.LightPink;
        private Color selected = Color.FromArgb(255, 255, 153, 179);
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
        /// Loads the entered piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender == LoadSetBtn)
                {
                    loaded = new Set(NameTb.Text);
                }
                else
                {
                    loaded = new Piece(NameTb.Text);
                }
                loaded.ToPiece().Recentre = false;
                DrawPanel.Refresh();
                g = DrawPanel.CreateGraphics();
                loaded.Draw(g);
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
                if (AllBtn.BackColor == selected) { AllBtn.BackColor = button; }
                FillColourBtn.BackColor = (FillColourBtn.BackColor == button) ? selected : button;
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
                if (AllBtn.BackColor == selected) { AllBtn.BackColor = button; }
                OutlineColourBtn.BackColor = (OutlineColourBtn.BackColor == button) ? selected : button;
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
                if (AllBtn.BackColor == selected) { AllBtn.BackColor = button; }
                OutlineWidthBtn.BackColor = (OutlineWidthBtn.BackColor == button) ? selected : button;
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
                if (AllBtn.BackColor == selected) { AllBtn.BackColor = button; }
                PieceDetailsBtn.BackColor = (PieceDetailsBtn.BackColor == button) ? selected : button;
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
                ShapeBtn.BackColor = (ShapeBtn.BackColor == button) ? selected : button;
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
                FillColourBtn.BackColor = selected;
                OutlineColourBtn.BackColor = selected;
                OutlineWidthBtn.BackColor = selected;
                PieceDetailsBtn.BackColor = selected;
                ShapeBtn.BackColor = selected;
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
                SketchBtn.BackColor = (SketchBtn.BackColor == button) ? selected : button;
            }
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            if (FillColourBtn.BackColor == selected || AllBtn.BackColor == selected)
            {
                WIP.FillColour = loaded.ToPiece().FillColour;
            }
            if (OutlineColourBtn.BackColor == selected || AllBtn.BackColor == selected)
            {
                WIP.OutlineColour = loaded.ToPiece().OutlineColour;
            }
            if (OutlineWidthBtn.BackColor == selected || AllBtn.BackColor == selected)
            {
                WIP.OutlineWidth = loaded.ToPiece().OutlineWidth;
            }
            if (PieceDetailsBtn.BackColor == selected || AllBtn.BackColor == selected)
            {
                WIP.PieceDetails = loaded.ToPiece().PieceDetails;
            }
            if (ShapeBtn.BackColor == selected)
            {
                WIP.Data = loaded.ToPiece().Data;
                from.DataRow = loaded.ToPiece().Data[loaded.ToPiece().FindRow()].ToSimple();
                WIP.Data[WIP.FindRow()] = from.DataRow;
            }
            if (SketchBtn.BackColor == selected)
            {
                from.AddSketch(loaded);
            }

            from.DisplayDrawings();
            from.UpdateAttributes();
            Close();
        }
    }
}
