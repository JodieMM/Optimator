using Optimator.Tabs;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System;
using Optimator.Tabs.Sets;

namespace Optimator.Forms.Sets
{
    /// <summary>
    /// A panel for saving parts.
    /// </summary>
    public partial class AddPartPanel : PanelControl
    {
        private readonly SetsTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public AddPartPanel(SetsTab owner)
        {
            InitializeComponent();
            Owner = owner;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.8F;
            var smallWidthPercent = 0.05F;
            var heightPercent = 0.15F;

            var bigWidth = (int)(Width * widthPercent);
            var lilWidth = (int)(Width * smallWidthPercent);
            var bigHeight = (int)(Height * heightPercent);

            AddPartLbl.Location = new Point(lilWidth, lilWidth);

            TableLayoutPnl.Location = new Point(lilWidth, lilWidth * 3 + AddPartLbl.Height);
            TableLayoutPnl.Size = new Size(bigWidth, bigHeight);
        }

        /// <summary>
        /// Adds a part to the set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            var names = Utils.OpenFiles(Consts.PartFilter);
            if (names != null)
            {
                try
                {
                    foreach (var name in names)
                    {
                        Part justAdded;
                        if (name.EndsWith(Consts.PieceExt))
                        {
                            justAdded = new Piece(name, Utils.ReadFile(Utils.GetDirectory(name)));
                            Owner.WIP.PiecesList.Add(justAdded.ToPiece());
                            justAdded.ToPiece().State.SetCoordsBasedOnBoard(Owner.GetBoardSizing());
                            Owner.WIP.PersonalStates.Add(justAdded as Piece, Utils.CloneState(justAdded.ToPiece().State));
                        }
                        else if (name.EndsWith(Consts.SetExt))
                        {
                            justAdded = new Set(name, Utils.ReadFile(Utils.GetDirectory(name)));
                            Owner.WIP.PiecesList.AddRange((justAdded as Set).PiecesList);
                            justAdded.ToPiece().State.SetCoordsBasedOnBoard(Owner.GetBoardSizing());
                            foreach (var piece in (justAdded as Set).PiecesList)
                            {
                                Owner.WIP.PersonalStates.Add(piece, Utils.CloneState(piece.State));
                            }
                            (justAdded as Set).CalculateStates();
                        }
                    }
                    Owner.DeselectPiece();
                    Owner.CheckSingularBasePiece();
                    Owner.DisplayDrawings();
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
    }
}
