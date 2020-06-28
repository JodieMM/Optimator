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
        public string Directory { get; set; } = "";

        public Scene WIP = new Scene();
        public Part selected = null;
        public Piece subSelected = null;
        private Graphics g;
        
        public bool SelectFromTop = true;
        public int sceneWidth = Consts.defaultWidth;
        public int sceneHeight = Consts.defaultHeight;
        #endregion
        

        /// <summary>
        /// Constructor for the tab.
        /// </summary>
        public ScenesTab(HomeForm owner)
        {
            InitializeComponent();
            Owner = owner;
            
            Owner.GetTabControl().KeyUp += KeyPress;
            Enter += FocusOn;
            VisibleChanged += FocusOn;

            DrawPanel.BackColor = Utils.ColourFromString(Properties.Settings.Default.BgColour);
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
        /// Updates the draw panel size.
        /// </summary>
        /// <param name="width">New panel width (x)</param>
        /// <param name="height">New panel height (y)</param>
        public void SetDrawPanelSize(int width, int height)
        {
            DrawPanel.Width = width;
            DrawPanel.Height = height;
        }

        /// <summary>
        /// Updates the draw panel back colour.
        /// </summary>
        /// <param name="color"></param>
        public void SetDrawPanelColour(Color color)
        {
            DrawPanel.BackColor = color;
            DisplayDrawings();
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.25F;
            var heightPercent = 0.25F;

            DrawPanel.Size = new Size(sceneWidth, sceneHeight);

            Panel.Width = (int)(Width * widthPercent);
            DisplayPanel.Height = (int)(Height * heightPercent) - ToolStrip.Height;
            
            Utils.ResizePanel(Panel);

            DisplayDrawings();
        }

        /// <summary>
        /// Redraws boards once focus is regained.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FocusOn(object sender, EventArgs e)
        {
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
            SaveBtn.Checked = false;
            AddPartBtn.Checked = false;
            PositionsBtn.Checked = false;
            MoveBtn.Checked = false;
            SettingsBtn.Checked = false;
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



        // --- DISPLAY PANEL ---

        /// <summary>
        /// Changes the current working time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateCurrentTime(object sender, EventArgs e)
        {
            if (sender == CurrentTimeUpDown)
            {
                if (CurrentTimeUpDown.Value > WIP.TimeLength)
                {
                    UpdateVideoLength(CurrentTimeUpDown.Value);
                }
                TimeTrackBar.Value = (int)(CurrentTimeUpDown.Value * 10);
            }
            else
            {
                CurrentTimeUpDown.Value = (decimal)(TimeTrackBar.Value / 10.0);
            }
            DisplayDrawings();
        }

        /// <summary>
        /// Updates the code and visuals for the video length.
        /// </summary>
        /// <param name="newTime">The new video length</param>
        public void UpdateVideoLength(decimal newTime)
        {
            WIP.TimeLength = newTime;
            VidLengthLbl.Text = "Video Length: " + ConvertTimeToText();
            TimeTrackBar.Maximum = (int)(newTime * 10);
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
            var s = Math.Round(WIP.TimeLength - (hr * 3600 + min * 60), 2);

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
            if (ContainsFocus)
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
                            for (int index = 0; index < WIP.Changes.Count; index++)
                            {
                                var change = WIP.Changes[index];
                                if (!WIP.PiecesList.Contains(change.AffectedPiece))
                                {
                                    WIP.Changes.Remove(change);
                                    index--;
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
        }



        // ----- DRAWING FUNCTIONS -----

        /// <summary>
        /// Draws the relevant scene to the screen.
        /// </summary>
        public void DisplayDrawings()
        {
            if (WIP.PartsList.Count > 0)
            {
                Cursor = Cursors.WaitCursor;

                // Draw Panel
                WIP.RunScene(CurrentTimeUpDown.Value);
                Visuals.DrawParts(WIP.PartsList, g, DrawPanel);

                // Update Animation listbox
                if (Baby != null && Baby is MovePanel)
                {
                    (Baby as MovePanel).UpdateListbox();
                }

                Cursor = Cursors.Default;
            }
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
