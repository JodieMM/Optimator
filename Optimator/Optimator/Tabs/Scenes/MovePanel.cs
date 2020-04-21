using System;
using System.Collections.Generic;
using System.Drawing;
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

        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public MovePanel(ScenesTab owner)
        {
            InitializeComponent();
            Owner = owner;
            UpdateListbox();
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            float bigWidthPercent = 0.9F;
            float widthPercent = 0.05F;
            float bigHeightPercent = 0.75F;

            int smallWidth = (int)(Width * widthPercent);
            int bigWidth = (int)(Width * bigWidthPercent);
            int bigHeight = (int)(Height * bigHeightPercent);

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
            if (Owner.selected == null || ChangeTypeCb.SelectedIndex == -1 || AnimationAmountTb.Value == 0)
            {
                return;
            }

            // Adds new change to scene
            Owner.WIP.Changes.Add(new Change(Owner.GetCurrentTimeUpDownValue(), 
                ChangeTypeCb.Text, Owner.selected.ToPiece(), (double)AnimationAmountTb.Value, SecondsUpDown.Value, Owner.WIP));
            if (Owner.GetCurrentTimeUpDownValue() + SecondsUpDown.Value > Owner.WIP.TimeLength)
            {
                Owner.UpdateVideoLength(Owner.GetCurrentTimeUpDownValue() + SecondsUpDown.Value);
            }

            // Displays previews if previews are on
            if (Owner.GetPreviewVisible())
            {
                PreviewBtn_Click(sender, e);
            }
            Owner.DisplayDrawings();
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
                if (Owner.selected == null || ChangeTypeCb.SelectedIndex == -1 || AnimationAmountTb.Value == 0)
                {
                    return;
                }
                PreviewBtn.BackColor = pressed;
                Owner.WIP.RunScene(Owner.GetCurrentTimeUpDownValue() + SecondsUpDown.Value);
                Change tempChange = new Change(Owner.GetCurrentTimeUpDownValue(), ChangeTypeCb.Text,
                    Owner.selected.ToPiece(), (double)AnimationAmountTb.Value, SecondsUpDown.Value, Owner.WIP);
                tempChange.Run(Owner.GetCurrentTimeUpDownValue() + SecondsUpDown.Value);
            }
            if (PreviewBtn == ActiveControl)
            {
                Owner.DisplayDrawPanel();
            }
        }



        // ----- OTHER FUNCTIONS -----

        /// <summary>
        /// Updates the listbox based on owner's animation changes.
        /// </summary>
        public void UpdateListbox()
        {
            AnimationLb.Items.Clear();
            AnimationLb.Items.Add("Piece: Action: How Much: Start");
            List<string> back = new List<string>();
            foreach (Change change in Owner.WIP.Changes)
            {
                string summary = "";
                summary += change.AffectedPiece.Name + " :" + change.Action + " :" +
                    change.HowMuch.ToString() + " :" + change.StartTime.ToString();

                if (Owner.GetCurrentTimeUpDownValue() >= change.StartTime &&
                    Owner.GetCurrentTimeUpDownValue() <= change.StartTime + change.HowLong)
                {
                    AnimationLb.Items.Add(summary);
                }
                else
                {
                    back.Add(summary);
                }
            }
            foreach (string summary in back)
            {
                AnimationLb.Items.Add(summary);
            }
        }

        /// <summary>
        /// Removes the change at the entered
        /// AnimationLb index.
        /// </summary>
        /// <param name="index"></param>
        private void RemoveChangeIndex(int index)
        {
            int counter = 0;

            // Search Running Changes
            foreach (Change change in Owner.WIP.Changes)
            {
                if (Owner.GetCurrentTimeUpDownValue() >= change.StartTime &&
                    Owner.GetCurrentTimeUpDownValue() <= change.StartTime + change.HowLong)
                {
                    if (counter == index)
                    {
                        Owner.WIP.Changes.Remove(change);
                        return;
                    }
                    counter++;
                }
            }
            // Search Back Changes
            foreach (Change change in Owner.WIP.Changes)
            {
                if (!(Owner.GetCurrentTimeUpDownValue() >= change.StartTime) ||
                    !(Owner.GetCurrentTimeUpDownValue() <= change.StartTime + change.HowLong))
                {
                    if (counter == index)
                    {
                        Owner.WIP.Changes.Remove(change);
                        return;
                    }
                    counter++;
                }
            }
        }

        /// <summary>
        /// Deletes the animation change if request is valid.
        /// </summary>
        /// <returns>True if removal valid</returns>
        public bool DeleteAnimation()
        {
            if (ActiveControl == AnimationLb && AnimationLb.SelectedIndex != -1)
            {
                RemoveChangeIndex(AnimationLb.SelectedIndex);
                AnimationLb.Items.RemoveAt(AnimationLb.SelectedIndex);
                return true;
            }
            return false;
        }
    }
}
