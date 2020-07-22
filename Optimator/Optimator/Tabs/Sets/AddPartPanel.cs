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
            var heightPercent = 0.45F;

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

                            // Add JoinedPieces
                            foreach (var joinedPiece in (justAdded as Set).JoinedPieces)
                            {
                                Owner.WIP.JoinedPieces.Add(joinedPiece.Key, joinedPiece.Value);
                            }
                            // Add JoinsIndex
                            foreach (var joinIndex in (justAdded as Set).JoinsIndex)
                            {
                                Owner.WIP.JoinsIndex.Add(joinIndex.Key, joinIndex.Value);
                            }
                            // Add PersonalStates
                            foreach (var piece in (justAdded as Set).PiecesList)
                            {
                                Owner.WIP.PersonalStates.Add(piece, Utils.CloneState((justAdded as Set).PersonalStates[piece]));
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

        /// <summary>
        /// Clones the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloneBtn_Click(object sender, EventArgs e)
        {
            if (Owner.selected != null)
            {
                var clone = Utils.ClonePiece(Owner.selected);
                Owner.WIP.PiecesList.Add(clone);
                Owner.WIP.PersonalStates.Add(clone, new State());
                Owner.WIP.PersonalStates[clone].SetCoordsBasedOnBoard(Owner.GetBoardSizing());
                
                if (sender == CloneAttachmentsBtn)
                {
                    CloneAttached(Owner.selected, clone);
                }
            }
            Owner.DisplayDrawings();
        }

        /// <summary>
        /// Recursively clones all of the attached pieces.
        /// </summary>
        /// <param name="original">Pre-made instance of piece</param>
        /// <param name="clone">Cloned instance of piece</param>
        private void CloneAttached(Piece original, Piece clone)
        {
            foreach (var attached in Owner.WIP.JoinedPieces[original])
            {
                var clone2 = Utils.ClonePiece(attached);
                Owner.WIP.PiecesList.Add(clone2);
                clone2.State.SetCoordsBasedOnBoard(Owner.GetBoardSizing());
                Owner.WIP.PersonalStates.Add(clone2, Utils.CloneState(clone2.State));
                Owner.WIP.JoinsIndex.Add(clone2, Utils.CloneJoin(Owner.WIP.JoinsIndex[attached], clone2, clone, Owner.WIP));
                Owner.WIP.AddToJoinedPieces(clone2, clone);
                if (Owner.WIP.JoinedPieces.ContainsKey(attached))
                {
                    CloneAttached(attached, clone2);
                }
            }
        }
    }
}
