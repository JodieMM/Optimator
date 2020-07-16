using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Optimator.Tabs.SoloTabs
{
    /// <summary>
    /// A tab for loading components of a piece or set into the current Part.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class LoadPieceTab : TabPageControl
    {
        #region Load Menu Variables
        public override HomeForm Owner { get; set; }
        private readonly PiecesTab from;
        private Part loaded = null;

        private Graphics g;

        private Color button = Color.LightPink;
        private Color selected = Color.FromArgb(255, 255, 153, 179);
        #endregion
        

        /// <summary>
        /// Consutrctor for the tab.
        /// </summary>
        /// <param name="owner">HomeForm base</param>
        /// <param name="from">PiecesTab base</param>
        public LoadPieceTab(HomeForm owner, PiecesTab from)
        {
            InitializeComponent();
            Owner = owner;
            this.from = from;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab's contents.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.65F;
            var widthSmallPercent = 0.3F;
            var heightPercent = 0.9F;

            var bigWidth = (int)(Width * widthPercent);
            var bigHeight = (int)((Height - ToolStrip.Height) * heightPercent);
            var bigLength = bigHeight < bigWidth ? bigHeight : bigWidth;

            var smallWidth = (int)(Width * widthSmallPercent);
            var lilWidth = (int)((Width - smallWidth - bigLength) / 4.0);
            var smallHeight = (int)((Height - ToolStrip.Height - bigLength) / 2.0);

            DrawPanel.Size = new Size(bigLength, bigLength);
            DrawPanel.Location = new Point(lilWidth, smallHeight + ToolStrip.Height);

            TableLayoutPnl.Size = new Size(smallWidth, bigLength);
            TableLayoutPnl.Location = new Point(bigLength + lilWidth * 3, smallHeight + ToolStrip.Height);

            DisplayDrawings();
        }

        /// <summary>
        /// Display any loaded part to the display screen.
        /// </summary>
        private void DisplayDrawings()
        {
            if (loaded != null)
            {
                DrawPanel.Refresh();
                g = DrawPanel.CreateGraphics();
                loaded.Draw(g);
            }
        }



        // ----- PANEL REFRESH TIMER

        /// <summary>
        /// Starts the drawing timer once the tab has been created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void RefreshDrawPanel(object sender, EventArgs e)
        {
            DisplayTimer.Start();
        }

        /// <summary>
        /// Displays the drawings a short time after the tab has validated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayTimer_Tick(object sender, EventArgs e)
        {
            DisplayTimer.Stop();
            DisplayDrawings();
        }



        // ----- MENU BUTTONS -----

        /// <summary>
        /// Loads the entered piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadBtn_Click(object sender, EventArgs e)
        {
            var name = Utils.OpenFile(Consts.PartFilter);
            if (name != "")
            {
                try
                {
                    if (name.EndsWith(Consts.PieceExt))
                    {
                        loaded = new Piece(name, Utils.ReadFile(Utils.GetDirectory(name)));
                    }
                    else if (name.EndsWith(Consts.SetExt))
                    {
                        loaded = new Set(name, Utils.ReadFile(Utils.GetDirectory(name)));
                    }
                    loaded.ToPiece().State.SetCoordsBasedOnBoard(DrawPanel);
                    DisplayDrawings();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file and sub-files and try again.", "File Not Found", MessageBoxButtons.OK);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Suspected outdated file or sub-file.", "File Indexing Error", MessageBoxButtons.OK);
                }
                catch (VersionException)
                {
                    // Handled by Exception
                }
            }
        }

        /// <summary>
        /// Changes the background colour of the clicked button to indicate
        /// selection/deselection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleButton(object sender, EventArgs e)
        {
            if (loaded != null && sender is Button)
            {
                var clicked = (Button)sender;
                clicked.BackColor = (clicked.BackColor == button) ? selected : button;
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
        /// Closes the tab and sends off data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            if (FillColourBtn.BackColor != selected && OutlineColourBtn.BackColor != selected && OutlineWidthBtn.BackColor != selected &&
                PieceDetailsBtn.BackColor != selected && ShapeBtn.BackColor != selected && SketchBtn.BackColor != selected)
            {
                var result = MessageBox.Show("No options have been selected. Continue closing the tab?", "Tab Close Confirmation", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (FillColourBtn.BackColor == selected || AllBtn.BackColor == selected)
            {
                from.WIP.ColourState.FillColour = loaded.ToPiece().ColourState.FillColour;
            }
            if (OutlineColourBtn.BackColor == selected || AllBtn.BackColor == selected)
            {
                from.WIP.ColourState.OutlineColour = loaded.ToPiece().ColourState.OutlineColour;
            }
            if (OutlineWidthBtn.BackColor == selected || AllBtn.BackColor == selected)
            {
                from.WIP.OutlineWidth = loaded.ToPiece().OutlineWidth;
            }
            if (PieceDetailsBtn.BackColor == selected || AllBtn.BackColor == selected)
            {
                from.WIP.PieceDetails = loaded.ToPiece().PieceDetails;
            }
            if (ShapeBtn.BackColor == selected)
            {
                var panel = from.GetBoardSizing();
                foreach (var spot in loaded.ToPiece().Data)
                {
                    spot.X += panel.Width / 2.0F;
                    spot.Y += panel.Height / 2.0F;
                    spot.XRight += panel.Width / 2.0F;
                    spot.YDown += panel.Height / 2.0F;
                }
                from.WIP.Data = loaded.ToPiece().Data;
            }
            if (SketchBtn.BackColor == selected)
            {
                loaded.ToPiece().State.SetCoordsBasedOnBoard(from.GetBoardSizing());
                from.Sketches.Add(loaded, true);
            }
            from.DeselectButtons();
            CloseBtn_Click(sender, e);
        }
    }
}
