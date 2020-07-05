using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Optimator.Tabs.Scenes
{
    /// <summary>
    /// A panel to manage the changes within the scene.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class MovePanel : PanelControl
    {
        private readonly ScenesTab Owner;
        private Color button = Color.Khaki;
        private Color pressed = Color.Gold;
        private Change WIP;
        private Dictionary<int, Change> changeIndex = new Dictionary<int, Change>();

        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public MovePanel(ScenesTab owner)
        {
            InitializeComponent();
            Owner = owner;
            UpdateListbox();
            Owner.Owner.GetTabControl().KeyDown += KeyPress;

            WIP = new Change(0, "", null, 0, 0, Owner.WIP);
            if (Owner.selected != null)
            {
                PartSelected(Owner.selected.ToPiece());
            }
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var bigWidthPercent = 0.9F;
            var widthPercent = 0.05F;
            var bigHeightPercent = 0.75F;

            var smallWidth = (int)(Width * widthPercent);
            var bigWidth = (int)(Width * bigWidthPercent);
            var bigHeight = (int)(Height * bigHeightPercent);

            MoveLbl.Location = new Point(smallWidth, smallWidth);
            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 3 + MoveLbl.Height);
            TableLayoutPnl.Size = new Size(bigWidth, bigHeight);
        }

        /// <summary>
        /// Adds a movement/effect to the animations of the scene.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAnimationBtn_Click(object sender, EventArgs e)
        {
            if (AddAnimationBtn.Text == "Add")
            {
                if (WIP.Action == "" || WIP.AffectedPiece == null || WIP.HowMuch == 0 || WIP.HowLong == 0)
                {
                    return;
                }
                Owner.WIP.Changes.Add(Utils.CloneChange(WIP));

                if (WIP.StartTime + WIP.HowLong > Owner.WIP.TimeLength)
                {
                    Owner.UpdateVideoLength(WIP.StartTime + WIP.HowLong);
                }

                UpdateListbox();
                Owner.DisplayDrawings();
            }
            else
            {
                if (AnimationLv.SelectedIndices.Count > 0)
                {
                    AnimationLv.SelectedIndices.Clear();
                }

                if (Owner.selected == null)
                {
                    PartNameLbl.Text = WIP.AffectedPiece != null ? Utils.BaseName(WIP.AffectedPiece.Name) : "";
                }
                else
                {
                    WIP.AffectedPiece = Owner.selected.ToPiece();
                    PartNameLbl.Text = Utils.BaseName(WIP.AffectedPiece.Name);
                }
                ChangeTypeCb.SelectedText = WIP.Action;
                AnimationAmountTb.Value = (decimal)WIP.HowMuch;
                StartTimeUpDown.Value = WIP.StartTime;
                SecondsUpDown.Value = WIP.HowLong;

                AddAnimationBtn.Text = "Add";
            }
        }

        /// <summary>
        /// Shows what the scene will look like with the suggested
        /// change after the change is completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            if (PreviewBtn.BackColor == pressed)
            {
                PreviewBtn.BackColor = button;
                Owner.WIP.RunScene(Owner.GetCurrentTimeUpDownValue());
            }
            else
            {
                if (WIP.Action == "" || WIP.AffectedPiece == null || WIP.HowMuch == 0 || WIP.HowLong == 0)
                {
                    return;
                }
                PreviewBtn.BackColor = pressed;
                Owner.WIP.RunScene(Owner.GetCurrentTimeUpDownValue() + SecondsUpDown.Value);
                WIP.Run(Owner.GetCurrentTimeUpDownValue() + SecondsUpDown.Value);
            }
            if (PreviewBtn == ActiveControl)
            {
                Owner.DisplayDrawPanel();
            }
        }

        /// <summary>
        /// Runs when a key is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void KeyPress(object sender, KeyEventArgs e)
        {
            if (ContainsFocus)
            {
                switch (e.KeyCode)
                {
                    // Enter Pressed
                    case Keys.Enter:
                        AddAnimationBtn_Click(sender, e);
                        break;

                    // Do nothing for any other key
                    default:
                        break;
                }
            }
        }



        // ----- UPDATE ANIMATION -----

        /// <summary>
        /// Change the option settings to the selected animation's settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationLv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AnimationLv.SelectedIndices.Count > 0)
            {
                PartNameLbl.Text = Utils.BaseName(changeIndex[AnimationLv.SelectedIndices[0]].AffectedPiece.Name);
                ChangeTypeCb.SelectedText = changeIndex[AnimationLv.SelectedIndices[0]].Action;
                AnimationAmountTb.Value = (decimal)changeIndex[AnimationLv.SelectedIndices[0]].HowMuch;
                StartTimeUpDown.Value = changeIndex[AnimationLv.SelectedIndices[0]].StartTime;
                SecondsUpDown.Value = changeIndex[AnimationLv.SelectedIndices[0]].HowLong;

                AddAnimationBtn.Text = "New Animation";
            }
            else
            {
                AddAnimationBtn_Click(sender, e);
            }
        }

        /// <summary>
        /// Updates the selected animation or new animation affected piece.
        /// </summary>
        /// <param name="selected">Newly selected piece</param>
        public void PartSelected(Piece selected)
        {
            // Update Animation
            if (AnimationLv.SelectedIndices.Count != 0)
            {
                changeIndex[AnimationLv.SelectedIndices[0]].AffectedPiece = selected;
                AnimationLv.SelectedItems[0].Text = Utils.BaseName(selected.Name);
            }
            // Update New Animation Part
            else
            {
                PartNameLbl.Text = Utils.BaseName(selected.Name);
                WIP.AffectedPiece = selected;
            }
        }

        /// <summary>
        /// Updates the selected animation or new animation action type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update Animation
            if (AnimationLv.SelectedIndices.Count != 0)
            {
                changeIndex[AnimationLv.SelectedIndices[0]].Action = ChangeTypeCb.Text;
                AnimationLv.SelectedItems[0].SubItems[1].Text = ChangeTypeCb.Text;
            }
            // Update New Animation Part
            else
            {
                WIP.Action = ChangeTypeCb.Text;
            }
        }

        /// <summary>
        /// Updates the selected animation or new animation action amount.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationAmountTb_ValueChanged(object sender, EventArgs e)
        {
            // Update Animation
            if (AnimationLv.SelectedIndices.Count != 0)
            {
                changeIndex[AnimationLv.SelectedIndices[0]].HowMuch = (float)AnimationAmountTb.Value;
                AnimationLv.SelectedItems[0].SubItems[2].Text = AnimationAmountTb.Value.ToString();
            }
            // Update New Animation Part
            else
            {
                WIP.HowMuch = (float)AnimationAmountTb.Value;
            }
        }

        /// <summary>
        /// Updates the selected animation or new animation start time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartTimeUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Update Animation
            if (AnimationLv.SelectedIndices.Count != 0)
            {
                changeIndex[AnimationLv.SelectedIndices[0]].StartTime = StartTimeUpDown.Value;
                AnimationLv.SelectedItems[0].SubItems[3].Text = StartTimeUpDown.Value.ToString();
                if (changeIndex[AnimationLv.SelectedIndices[0]].StartTime + changeIndex[AnimationLv.SelectedIndices[0]].HowLong
                    > Owner.WIP.TimeLength)
                {
                    Owner.UpdateVideoLength(changeIndex[AnimationLv.SelectedIndices[0]].StartTime 
                        + changeIndex[AnimationLv.SelectedIndices[0]].HowLong);
                }
            }
            // Update New Animation Part
            else
            {
                WIP.StartTime = StartTimeUpDown.Value;
            }
        }

        /// <summary>
        /// Updates the selected animation or new animation length.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecondsUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Update Animation
            if (AnimationLv.SelectedIndices.Count != 0)
            {
                changeIndex[AnimationLv.SelectedIndices[0]].HowLong = SecondsUpDown.Value;
                AnimationLv.SelectedItems[0].SubItems[4].Text = SecondsUpDown.Value.ToString();
                if (changeIndex[AnimationLv.SelectedIndices[0]].StartTime + changeIndex[AnimationLv.SelectedIndices[0]].HowLong
                    > Owner.WIP.TimeLength)
                {
                    Owner.UpdateVideoLength(changeIndex[AnimationLv.SelectedIndices[0]].StartTime
                        + changeIndex[AnimationLv.SelectedIndices[0]].HowLong);
                }
            }
            // Update New Animation Part
            else
            {
                WIP.HowLong = SecondsUpDown.Value;
            }
        }



        // ----- OTHER FUNCTIONS -----

        /// <summary>
        /// Updates the listbox based on owner's animation changes.
        /// </summary>
        public void UpdateListbox()
        {
            AnimationLv.Items.Clear();
            changeIndex.Clear();

            // Sort Changes
            var back = new List<Change>();
            var mid = new List<Change>();
            foreach (var change in Owner.WIP.Changes)
            {          
                if (Owner.GetCurrentTimeUpDownValue() >= change.StartTime &&
                    Owner.GetCurrentTimeUpDownValue() <= change.StartTime + change.HowLong)
                {
                    var summary = new string[] { Utils.BaseName(change.AffectedPiece.Name), change.Action, change.HowMuch.ToString(),
                        change.StartTime.ToString(), change.HowLong.ToString() };
                    var item = new ListViewItem(summary)
                    {
                        BackColor = Consts.activeAnimation
                    };
                    changeIndex.Add(AnimationLv.Items.Count, change);
                    AnimationLv.Items.Add(item);
                }
                else if (Owner.GetCurrentTimeUpDownValue() < change.StartTime)
                {
                    mid.Add(change);
                }
                else
                {
                    back.Add(change);
                }
            }

            // Add Changes
            foreach (var change in mid)
            {
                var summary = new string[] { Utils.BaseName(change.AffectedPiece.Name), change.Action, change.HowMuch.ToString(),
                        change.StartTime.ToString(), change.HowLong.ToString() };
                var item = new ListViewItem(summary)
                {
                    BackColor = Consts.toDoAnimation
                };
                changeIndex.Add(AnimationLv.Items.Count, change);
                AnimationLv.Items.Add(item);
            }
            foreach (var change in back)
            {
                var summary = new string[] { Utils.BaseName(change.AffectedPiece.Name), change.Action, change.HowMuch.ToString(),
                        change.StartTime.ToString(), change.HowLong.ToString() };
                var item = new ListViewItem(summary)
                {
                    BackColor = Consts.finishedAnimation
                };
                changeIndex.Add(AnimationLv.Items.Count, change);
                AnimationLv.Items.Add(item);
            }
        }

        /// <summary>
        /// Deletes the animation change if request is valid.
        /// </summary>
        /// <returns>True if removal valid</returns>
        public bool DeleteAnimation()
        {
            if (ActiveControl == AnimationLv && AnimationLv.SelectedIndices != null)
            {
                Owner.WIP.Changes.Remove(changeIndex[AnimationLv.SelectedIndices[0]]);
                AnimationLv.Items.Remove(AnimationLv.SelectedItems[0]);
                return true;
            }
            return false;
        }
    }
}
