using Optimator.Forms.Scenes;
using Optimator.Tabs.SoloTabs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Scenes
{
    /// <summary>
    /// A tab page for creating and modifying scenes.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class ScenesTab : TabPageControl
    {
        #region Scenes Form Variables
        public override HomeForm Owner { get; set; }
        private PanelControl Baby = null;

        public Scene WIP = new Scene();
        public Part selected = null;
        public Piece subSelected = null;
        private Graphics g;

        public decimal TimeIncrement = (decimal)0.5;
        public bool SelectFromTop = true;
        #endregion
        

        /// <summary>
        /// Constructor for the tab.
        /// </summary>
        public ScenesTab(HomeForm owner)
        {
            InitializeComponent();
            Owner = owner;
            
            KeyUp += KeyPress;            

            g = DrawPanel.CreateGraphics();            
        }



        // ----- GETTERS & SETTERS -----

        /// <summary>
        /// Gets a board to use in a utils sizing function in AddPartPanel.
        /// </summary>
        /// <returns>A PictureBox used as a board</returns>
        public PictureBox GetBoardSizing()
        {
            return DrawPanel;
        }

        /// <summary>
        /// Gets the CurrentTimeUpDown value.
        /// </summary>
        /// <returns>Decimal current time</returns>
        public decimal GetCurrentTimeUpDownValue()
        {
            return CurrentTimeUpDown.Value;
        }

        /// <summary>
        /// Finds visibility of display panel.
        /// </summary>
        /// <returns>True if panel visible</returns>
        public bool GetPreviewVisible()
        {
            return DisplayPanel.Visible;
        }

        /// <summary>
        /// Shows or hides the display panel.
        /// </summary>
        /// <param name="visible">False if panel invisible</param>
        public void ShowPreview(bool visible = true)
        {
            DisplayPanel.Visible = visible;
        }



        // ----- FORM FUNCTIONS -----

        public override void Resize()
        {
            var widthPercent = 0.75F;
            var heightPercent = 0.75F;

            var bigWidth = (int)(Width * widthPercent);
            var bigHeight = (int)((Height - ToolStrip.Height) * heightPercent);
            var fraction = (bigWidth / 16.0) > (bigHeight / 9.0) ? (int)(bigHeight / 9.0) : (int)(bigWidth / 16.0);

            DrawPanel.Size = new Size(fraction * 16, fraction * 9);
            DrawPanel.Location = new Point((int)((bigWidth - DrawPanel.Width ) / 2.0), 
                (int)((bigHeight - DrawPanel.Height) / 2.0 + ToolStrip.Height));

            Panel.Width = Width - bigWidth;
            DisplayPanel.Height = Height - bigHeight - ToolStrip.Height;

            var panelWidth = (int)(UpArrowImg.Parent.Width / 4.0);
            UpArrowImg.Location = new Point((int)(panelWidth + (panelWidth - UpArrowImg.Width / 2.0)),
                (int)((UpArrowImg.Parent.Height - UpArrowImg.Height) / 2.0));

            if (Width < 1140)
            {
                CurrentTimeLbl.Text = "Now";
                VidLengthLbl.Text = ConvertTimeToText();
            }
            else
            {
                CurrentTimeLbl.Text = "Current Time";
                VidLengthLbl.Text = "Video Length: " + ConvertTimeToText();
            }
            Utils.ResizePanel(Panel);

            DisplayDrawings();
        }

        #region ToolStrip

        /// <summary>
        /// Unchecks all of the checkable buttons and checks the provided one.
        /// </summary>
        private void SelectButton(ToolStripButton btn)
        {
            var check = btn.Checked;
            SaveBtn.Checked = false;
            AddPartBtn.Checked = false;
            PositionsBtn.Checked = false;
            MoveBtn.Checked = false;
            SettingsBtn.Checked = false;
            Baby = null;
            btn.Checked = !check;
            DisplayDrawings();
        }

        /// <summary>
        /// Unchecks all buttons and clears panel.
        /// </summary>
        private void DeselectButtons()
        {
            SelectButton(SaveBtn);
            SaveBtn.Checked = false;
            Panel.Controls.Clear();
        }

        /// <summary>
        /// Opens or closes panel based on tool strip button press.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWithPanel_Click(object sender, EventArgs e)
        {
            if (!(sender as ToolStripButton).Checked)
            {
                // Set Baby
                if (sender == SaveBtn)
                {
                    Baby = new SavePanel(this);
                }
                else if (sender == AddPartBtn)
                {
                    Baby = new AddPartPanel(this);
                }
                else if (sender == PositionsBtn)
                {
                    Baby = new PositionsPanel(this);
                }
                else if (sender == MoveBtn)
                {
                    Baby = new MovePanel(this);
                }
                else if (sender == SettingsBtn)
                {
                    Baby = new SettingsPanel(this);
                }
                Utils.NewPanelContent(Panel, Baby);
                SelectButton(sender as ToolStripButton);
            }
            else
            {
                DeselectButtons();
            }
        }

        /// <summary>
        /// Closes this tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void CloseBtn_Click(object sender, EventArgs e)
        {
            if (Utils.ExitBtn_Click(WIP.PartsList.Count > 0))
            {
                Owner.RemoveTabPage(this);
            }
        }

        #endregion



        // --- DISPLAY PANEL ---

        /// <summary>
        /// Changes the current working time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentTimeUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (CurrentTimeUpDown.Value > WIP.TimeLength)
            {
                UpdateVideoLength(CurrentTimeUpDown.Value);
            }

            DisplayDrawings();
        }

        /// <summary>
        /// Progresses to the next frame of the animation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForwardBtn_Click(object sender, EventArgs e)
        {
            CurrentTimeUpDown.Value += TimeIncrement;
            if (WIP.TimeLength < CurrentTimeUpDown.Value)
            {
                WIP.TimeLength = CurrentTimeUpDown.Value;
            }

            DisplayDrawings();
        }

        /// <summary>
        /// Returns to the previous frame of the animation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            if (CurrentTimeUpDown.Value < TimeIncrement)
            {
                return;
            }
            CurrentTimeUpDown.Value -= TimeIncrement;
            DisplayDrawings();
        }



        // -----  I/O -----

        /// <summary>
        /// Selects a piece if it is clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // Choose and Update Selected Piece (If Any)
            var newSelected = Utils.FindClickedSelection(WIP.PiecesList, e.X, e.Y, SelectFromTop);
            if (newSelected is null)
            {
                Deselect();
            }
            else if (selected != null && selected is Set && (selected as Set).PiecesList.Contains(newSelected))
            {
                SelectPart(newSelected, true);
            }
            else
            {
                SelectPart(newSelected);
            }

            DisplayDrawings();
        }

        /// <summary>
        /// Makes the entered part selected, 
        /// deselecting the old selected if necessary.
        /// </summary>
        /// <param name="select"></param>
        public void SelectPart(Part select, bool subSelect = false)
        {
            if (!subSelect)
            {
                Deselect();
                selected = select;
            }
            else
            {
                subSelected = select as Piece;
            }
            select.ToPiece().ColourState.OutlineColour = (select is Piece) ? Color.Red : Color.Purple;
            if (Baby != null && Baby is PositionsPanel)
            {
                (Baby as PositionsPanel).EnableControls();
            }
        }

        /// <summary>
        /// Deselects the selected piece, returning
        /// its outline colour to normal.
        /// </summary>
        private void Deselect()
        {
            if (selected != null)
            {
                if (subSelected != null)
                {
                    subSelected.ColourState.OutlineColour = WIP.OriginalColours[selected.ToPiece()].OutlineColour;
                    subSelected = null;
                }
                selected.ToPiece().ColourState.OutlineColour = WIP.OriginalColours[selected.ToPiece()].OutlineColour;
                selected = null;
                if (Baby != null && Baby is PositionsPanel)
                {
                    (Baby as PositionsPanel).EnableControls(false);
                }
            }
        }

        /// <summary>
        /// Runs when a key is pressed.
        /// If delete is pressed and a piece is selected, it will be deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void KeyPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // Delete Selected Shape
                case Keys.Delete:
                    if (selected == null)
                    {
                        return;
                    }

                    // If Listbox is highlighted, delete change/animation
                    if (Baby != null && Baby is MovePanel && (Baby as MovePanel).DeleteAnimation())
                    {
                        // Done in DeleteAnimation() Bool Check
                    }
                    // Delete selected
                    else
                    {
                        if (selected is Set)
                        {
                            var result = MessageBox.Show("This will delete the entire set. Do you wish to continue?",
                                "Overwrite Confirmation", MessageBoxButtons.OKCancel);
                            if (result == DialogResult.Cancel)
                            {
                                return;
                            }

                            foreach (var piece in (selected as Set).PiecesList)
                            {
                                WIP.PiecesList.Remove(piece);
                            }
                            WIP.PartsList.Remove(selected);
                        }
                        else
                        {
                            WIP.PartsList.Remove(selected);
                            WIP.PiecesList.Remove(selected.ToPiece());
                        }

                        // Update changes to remove those made redundant by deleting a piece/set
                        foreach (var change in WIP.Changes)
                        {
                            if (!WIP.PiecesList.Contains(change.AffectedPiece))
                            {
                                WIP.Changes.Remove(change);
                            }
                        }
                        Deselect();
                    }
                    DisplayDrawings();
                    break;

                // Do nothing for any other key
                default:
                    break;
            }
        }



        // ----- OTHER FUNCTIONS -----

        /// <summary>
        /// Draws the relevant scene to the screen.
        /// </summary>
        public void DisplayDrawings()
        {
            LoadingMessage.Visible = true;
            LoadingMessage.Location = new Point((int)((Width - LoadingMessage.Width) / 2.0),
                (int)((Height - LoadingMessage.Height) / 2.0));

            // Past Preview
            if (DisplayPanel.Visible && CurrentTimeUpDown.Value < TimeIncrement)
            {
                PastPreviewBox.BackColor = Color.PaleGoldenrod;
            }
            else
            {
                PastPreviewBox.BackColor = Color.White;
                WIP.RunScene(CurrentTimeUpDown.Value - TimeIncrement);
                Visuals.DrawParts(WIP.PartsList, g, PastPreviewBox, 3 / 11.0F);
            }

            // Draw Panel (Current)
            WIP.RunScene(CurrentTimeUpDown.Value);
            Visuals.DrawParts(WIP.PartsList, g, DrawPanel);

            // Preview Panels (Future, Future++)
            if (DisplayPanel.Visible)
            {
                WIP.RunScene(CurrentTimeUpDown.Value + TimeIncrement);
                Visuals.DrawParts(WIP.PartsList, g, FuturePreviewBox, 3 / 11.0F);
                WIP.RunScene(CurrentTimeUpDown.Value + 2 * TimeIncrement);
                Visuals.DrawParts(WIP.PartsList, g, Future2PreviewBox, 3 / 11.0F);
            }

            // Update Animation listbox
            if (Baby != null && Baby is MovePanel)
            {
                (Baby as MovePanel).UpdateListbox();
            }

            LoadingMessage.Visible = false;
        }

        /// <summary>
        /// Updates the code and visuals for the video length.
        /// </summary>
        /// <param name="newTime">The new video length</param>
        public void UpdateVideoLength(decimal newTime)
        {
            WIP.TimeLength = newTime;
            Resize();
        }

        /// <summary>
        /// Converts the current time length into a readable format.
        /// </summary>
        /// <returns>Time as string</returns>
        private string ConvertTimeToText()
        {
            var text = "";
            var hr = (int)Math.Floor(WIP.TimeLength / 3600);
            var min = (int)Math.Floor((WIP.TimeLength - hr * 3600) / 60);
            var s = (int)Math.Floor(WIP.TimeLength - (hr * 3600 + min * 60));

            if (hr > 0)
            {
                text += hr + "hrs ";
            }
            if (min > 0)
            {
                text += min + "mins ";
            }
            return text += s + "s";
        }

        /// <summary>
        /// Draws the relevant scene to the draw panel only.
        /// </summary>
        public void DisplayDrawPanel()
        {
            Visuals.DrawParts(WIP.PartsList, g, DrawPanel);
        }
    }
}
