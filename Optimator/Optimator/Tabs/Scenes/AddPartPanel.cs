using Optimator.Tabs;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System;
using Optimator.Tabs.Scenes;

namespace Optimator.Forms.Scenes
{
    /// <summary>
    /// A panel for saving parts.
    /// </summary>
    public partial class AddPartPanel : PanelControl
    {
        private readonly ScenesTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public AddPartPanel(ScenesTab owner)
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
        /// Adds the entered part to the scene.
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
                        Part loaded;
                        if (name.EndsWith(Consts.PieceExt))
                        {
                            loaded = new Piece(name, Utils.ReadFile(Utils.GetDirectory(name)));
                            loaded.ToPiece().State.SetCoordsBasedOnBoard(Owner.GetBoardSizing());
                            Owner.WIP.Originals.Add(loaded, Utils.CloneState(loaded.ToPiece().State));
                            Owner.WIP.OriginalColours.Add(loaded, Utils.CloneColourState((loaded as Piece).ColourState));
                        }
                        else
                        {
                            loaded = new Set(name, Utils.ReadFile(Utils.GetDirectory(name)));
                            loaded.ToPiece().State.SetCoordsBasedOnBoard(Owner.GetBoardSizing());
                            Owner.WIP.Originals.Add(loaded, Utils.CloneState(loaded.ToPiece().State));
                            foreach (var piece in (loaded as Set).PiecesList)
                            {
                                Owner.WIP.Originals.Add(piece, Utils.CloneState(piece.State));
                                Owner.WIP.OriginalColours.Add(piece, Utils.CloneColourState(piece.ColourState));
                            }
                        }
                        Owner.WIP.PartsList.Add(loaded);
                        Owner.SelectPart(loaded);
                        Owner.WIP.UpdatePiecesList();
                    }
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
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("You do not have access to this file.", "Unauthorised Access Error", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("An error has occurred.", "Error", MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// Clones the selected part.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloneBtn_Click(object sender, EventArgs e)
        {
            if (Owner.selected != null && Owner.selected is Piece)
            {
                var clone = Utils.ClonePiece(Owner.selected as Piece);
                Owner.WIP.PiecesList.Add(clone);
                Owner.WIP.PartsList.Add(clone);
                clone.State.SetCoordsBasedOnBoard(Owner.GetBoardSizing());
                Owner.WIP.Originals.Add(clone, Utils.CloneState(Owner.WIP.Originals[Owner.selected]));
                Owner.WIP.OriginalColours.Add(clone, Utils.CloneColourState(Owner.WIP.OriginalColours[Owner.selected]));
                if (sender == CloneAttachmentsBtn)
                {
                    // TODO: Clone Attachments
                }
            }
            Owner.DisplayDrawings();
        }
    }
}
