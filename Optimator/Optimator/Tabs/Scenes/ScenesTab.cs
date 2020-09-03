using Optimator.Forms.Scenes;
using Optimator.Properties;
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
        public string Directory { get; set; } = "";

        public Scene WIP = new Scene();
        public Part selected = null;
        public Piece subSelected = null;
        private Bitmap original;

        private int[] originalMoving;
        private State shadowState = null;
        private bool movingFar = false;

        public bool SelectFromTop = true;
        #endregion
        

        /// <summary>
        /// Constructor for the tab.
        /// </summary>
        public ScenesTab(HomeForm owner)
        {
            InitializeComponent();
            Owner = owner;
            
            Owner.GetTabControl().KeyUp += KeyPress;
            Enter += RefreshDrawPanel;
            VisibleChanged += RefreshDrawPanel;
            DrawPanelContainer.Scroll += RefreshDrawPanel;
            Paint += RefreshDrawPanel;

            SetDrawPanelSize(Settings.Default.SceneWidth, Settings.Default.SceneHeight);
            original = new Bitmap(DrawPanel.Width, DrawPanel.Height);
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
            WIP.Width = width;
            WIP.Height = height;
            DrawPanel.Width = width;
            DrawPanel.Height = height;
            original = new Bitmap(DrawPanel.Width, DrawPanel.Height);
        }

        /// <summary>
        /// Updates the draw panel back colour.
        /// </summary>
        /// <param name="color"></param>
        public void SetDrawPanelColour(Color color)
        {
            DrawPanel.BackColor = color;
            DisplayTimer.Start();
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the tab.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.25F;
            var heightPercent = 0.25F;

            DrawPanel.Size = new Size(WIP.Width, WIP.Height);

            Panel.Width = (int)(Width * widthPercent);
            DisplayPanel.Height = (int)(Height * heightPercent) - ToolStrip.Height;
            
            Utils.ResizePanel(Panel);

            DisplayDrawings();
            RefreshDrawPanel(this, new EventArgs());
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
                if (sender == SaveBtn)
                {
                    Utils.NewPanelContent(Panel, new SavePanel(this));
                }
                else if (sender == AddPartBtn)
                {
                    Utils.NewPanelContent(Panel, new AddPartPanel(this));
                }
                else if (sender == PositionsBtn)
                {
                    Utils.NewPanelContent(Panel, new PositionsPanel(this));
                }
                else if (sender == MoveBtn)
                {
                    Utils.NewPanelContent(Panel, new MovePanel(this));
                }
                else if (sender == SettingsBtn)
                {
                    Utils.NewPanelContent(Panel, new SettingsPanel(this));
                }                
                SelectButton(sender as ToolStripButton);
            }
            else
            {
                DeselectButtons();
            }
        }

        /// <summary>
        /// Reloads the parts on the scene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            //for (int index = 0; index < WIP.PiecesList.Count; index++)
            //{
            //    WIP.PiecesList[index] = new Piece(WIP.PiecesList[index].Name, 
            //        Utils.ReadFile(Utils.GetDirectory(WIP.PiecesList[index].Name)));
            //}
            //DisplayDrawings();
        }

        /// <summary>
        /// Snips excess time off of the scene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SnipBtn_Click(object sender, EventArgs e)
        {
            decimal maxTime = 0;
            foreach(var change in WIP.Changes)
            {
                if (change.StartTime + change.HowLong > maxTime)
                {
                    maxTime = change.StartTime + change.HowLong;
                }
            }
            UpdateVideoLength(maxTime);
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
        /// Programmatically updates the current working time.
        /// </summary>
        /// <param name="value">New working time</param>
        public void UpdateCurrentTime(decimal value)
        {
            CurrentTimeUpDown.Value = value;
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
            if (CurrentTimeUpDown.Value > WIP.TimeLength)
            {
                CurrentTimeUpDown.Value = WIP.TimeLength;
            }
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
            // TODO: Allow for set to be moved as a whole
            //else if (selected != null && selected is Set && (selected as Set).PiecesList.Contains(newSelected))
            //{
            //    SelectPart(newSelected, true);
            //    originalMoving = new int[] { e.X, e.Y };
            //}
            else
            {
                SelectPart(newSelected);
                originalMoving = new int[] { e.X, e.Y };
            }

            DisplayDrawings();
        }

        /// <summary>
        /// Checks if a piece is being moved or just clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (originalMoving != null)
            {
                // Invalid Mouse Position
                if (selected is null || e.X < 0 || e.Y < 0 || e.X > DrawPanel.Size.Width || e.Y > DrawPanel.Size.Height)
                {
                    StopMoving();
                }
                // Move Point
                else if (!movingFar)
                {
                    movingFar = Math.Abs(selected.ToPiece().State.X - e.X) > Consts.DragPrecision
                        || Math.Abs(selected.ToPiece().State.Y - e.Y) > Consts.DragPrecision;                    
                }

                // Shadows
                if (movingFar)
                {
                    var xChange = e.X - originalMoving[0];
                    var yChange = e.Y - originalMoving[1];

                    for (int index = 0; index < selected.ToPiece().Data.Count; index++)
                    {
                        shadowState = Utils.CloneState(selected.ToPiece().State);
                        shadowState.X += xChange;
                        shadowState.Y += yChange;
                    }
                }
                DisplayDrawings();
            }
        }

        /// <summary>
        /// Updates the user interface for the selected piece and stops
        /// the movement search, actioning it if necessary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (movingFar && selected != null && originalMoving != null)
            {
                WIP.Originals[selected].X += e.X - originalMoving[0];
                WIP.Originals[selected].Y += e.Y - originalMoving[1];                

                if (Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
                {
                    (Panel.Controls[0] as PositionsPanel).UpdateXY((int)WIP.Originals[selected].X, (int)WIP.Originals[selected].Y);
                }
            }
            StopMoving();
            DisplayDrawings();
        }

        /// <summary>
        /// Resets all moving variables.
        /// </summary>
        private void StopMoving()
        {
            movingFar = false;
            originalMoving = null;
            shadowState = null;
        }

        /// <summary>
        /// Makes the entered part selected, 
        /// deselecting the old selected if necessary.
        /// </summary>
        /// <param name="select"></param>
        public void SelectPart(Part select, bool subSelect = false)
        {
            // TODO: Allow for set to be moved as a whole
            if (!subSelect)
            {
                Deselect();
                selected = select;
            }
            else
            {
                subSelected = select as Piece;
            }
            select.ToPiece().ColourState.Outline = (select is Piece) ? Color.Red : Color.Purple;
            if (Panel.Controls.Count > 0)
            {
                if (Panel.Controls[0] is PositionsPanel)
                {
                    (Panel.Controls[0] as PositionsPanel).EnableControls();
                }
                else if (Panel.Controls[0] is MovePanel)
                {
                    (Panel.Controls[0] as MovePanel).PartSelected(select.ToPiece());
                }
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
                    subSelected.ColourState.Outline = WIP.OriginalColours[selected.ToPiece()].Outline;
                    subSelected = null;
                }
                selected.ToPiece().ColourState.Outline = WIP.OriginalColours[selected.ToPiece()].Outline;
                selected = null;
                if (Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
                {
                    (Panel.Controls[0] as PositionsPanel).EnableControls(false);
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
                        
                        // If Listbox is highlighted, delete change/animation
                        if (Panel.Controls.Count > 0 && Panel.Controls[0] is MovePanel && (Panel.Controls[0] as MovePanel).DeleteAnimation())
                        {
                            // Done in DeleteAnimation() Bool Check
                        }
                        // Delete selected
                        else
                        {
                            if (selected == null)
                            {
                                return;
                            }
                            if (selected is Set)
                            {
                                var result = MessageBox.Show("This will delete the entire set and its connected animations. Do you wish to continue?",
                                    "Delete Confirmation", MessageBoxButtons.OKCancel);
                                if (result == DialogResult.Cancel)
                                {
                                    return;
                                }

                                foreach (var piece in (selected as Set).PiecesList)
                                {
                                    WIP.PiecesList.Remove(piece);
                                    WIP.Originals.Remove(piece);
                                }
                                WIP.PartsList.Remove(selected);
                                WIP.Originals.Remove(selected);
                            }
                            else
                            {
                                var result = MessageBox.Show("This will delete the piece and its connected animations. Do you wish to continue?",
                                    "Delete Confirmation", MessageBoxButtons.OKCancel);
                                if (result == DialogResult.Cancel)
                                {
                                    return;
                                }

                                for (var index = 0; index < WIP.PartsList.Count; index++)
                                {
                                    var part = WIP.PartsList[index];
                                    if (part is Set && (part as Set).PiecesList.Contains(selected as Piece) || 
                                        part is Piece && part == selected)
                                    {
                                        if (part is Set)
                                        {
                                            (part as Set).RemovePiece(selected as Piece);
                                        }
                                        else
                                        {
                                            WIP.PartsList.Remove(selected);                                            
                                        }                                        
                                        WIP.PiecesList.Remove(selected.ToPiece());
                                        WIP.Originals.Remove(selected);
                                        index = WIP.PartsList.Count;
                                    }
                                }                                
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

                    // Move Selected Piece
                    case Keys.Up:
                        if (selected != null && Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
                        {
                            WIP.Originals[selected].Y -= 1;
                            (Panel.Controls[0] as PositionsPanel).EnableControls();
                            DisplayDrawings();
                        }
                        break;
                    case Keys.Down:
                        if (selected != null && Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
                        {
                            WIP.Originals[selected].Y += 1;
                            (Panel.Controls[0] as PositionsPanel).EnableControls();
                            DisplayDrawings();
                        }
                        break;
                    case Keys.Left:
                        if (selected != null && Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
                        {
                            WIP.Originals[selected].X -= 1;
                            (Panel.Controls[0] as PositionsPanel).EnableControls();
                            DisplayDrawings();
                        }
                        break;
                    case Keys.Right:
                        if (selected != null && Panel.Controls.Count > 0 && Panel.Controls[0] is PositionsPanel)
                        {
                            WIP.Originals[selected].X += 1;
                            (Panel.Controls[0] as PositionsPanel).EnableControls();
                            DisplayDrawings();
                        }
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
                // Draw Panel
                WIP.RunScene(CurrentTimeUpDown.Value);                

                // Update Animation listbox
                if (Panel.Controls.Count > 0 && Panel.Controls[0] is MovePanel)
                {
                    (Panel.Controls[0] as MovePanel).UpdateListbox();
                    (Panel.Controls[0] as MovePanel).AddWIPChange();
                }
                DisplayDrawPanel();
            }
            else
            {
                DrawPanel.Refresh();
            }
        }        

        /// <summary>
        /// Draws the relevant scene to the draw panel only.
        /// </summary>
        public void DisplayDrawPanel()
        {
            using (Graphics g = Graphics.FromImage(original))
            {
                // Draw BG
                g.FillRectangle(new SolidBrush(DrawPanel.BackColor), new Rectangle(0, 0, DrawPanel.Width, DrawPanel.Height));

                // Draw Content
                Visuals.DrawParts(WIP.PartsList, g);

                // Draw Shadows
                if (movingFar && selected != null && shadowState != null)
                {
                    selected.Draw(g, shadowState, new ColourState(selected.ToPiece().ColourState,
                        Consts.shadowShade, new Color[] { Consts.shadowShade }));
                }

                // Draw To Screen
                DrawPanel.CreateGraphics().DrawImageUnscaled(original, 0, 0);
            }            
        }
    }
}
