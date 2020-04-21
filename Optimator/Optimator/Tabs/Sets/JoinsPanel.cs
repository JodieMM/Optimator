using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Sets
{
    /// <summary>
    /// A panel to modify the joins between parts.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class JoinsPanel : PanelControl
    {
        private readonly SetsTab Owner;

        private Color unpressed = Color.FromArgb(192, 255, 192);
        private Color pressed = Color.FromArgb(153, 255, 153);


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public JoinsPanel(SetsTab owner)
        {
            InitializeComponent();
            Owner = owner;
        }



        // ----- GETTERS & SETTERS -----

        /// <summary>
        /// Whether the join button is pressed.
        /// </summary>
        /// <returns></returns>
        public bool JoinBtnPressed()
        {
            return JoinBtn.BackColor == pressed;
        }

        /// <summary>
        /// Whether the select base button is pressed.
        /// </summary>
        /// <returns></returns>
        public bool SelectBaseBtnPressed()
        {
            return SelectBaseBtn.BackColor == pressed;
        }

        /// <summary>
        /// Unselects the select base button.
        /// </summary>
        public void UnselectBaseBtn()
        {
            SelectBaseBtn.BackColor = unpressed;
        }

        /// <summary>
        /// Unselects both buttons.
        /// </summary>
        public void UnselectButtons()
        {
            SelectBaseBtn.BackColor = JoinBtn.BackColor = unpressed;
        }


        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the panel's contents.
        /// </summary>
        public override void Resize()
        {
            float widthPercent = 0.05F;
            float heightPercent = 0.5F;

            int smallWidth = (int)(Width * widthPercent);
            int bigHeight = (int)(Height * heightPercent);

            JoinsLbl.Location = new Point(smallWidth, smallWidth);

            TableLayoutPnl.Size = new Size(smallWidth * 16, bigHeight);
            TableLayoutPnl.Location = new Point(smallWidth, smallWidth * 3 + JoinsLbl.Height);
        }

        /// <summary>
        /// Changes the backcolors of the panel buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleButton(object sender, EventArgs e)
        {
            if (Owner.selected != null)
            {
                SelectBaseBtn.BackColor = sender == SelectBaseBtn ? SelectBaseBtn.BackColor == pressed ? unpressed : pressed : unpressed;
                JoinBtn.BackColor = sender == JoinBtn ? JoinBtn.BackColor == pressed ? unpressed : pressed : unpressed;

                if (JoinBtn.BackColor == pressed)
                {
                    Owner.SelectedRTS0();
                    Owner.DisplayDrawings();
                }
                else if (sender == JoinBtn)
                {
                    Owner.WIP.CalculateStates();
                    Owner.DisplayDrawings();
                }
            }
        }

        /// <summary>
        /// Changes whether the selected piece should flip.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlipsCb_CheckedChanged(object sender, EventArgs e)
        {
            if (Owner.selected != null && Owner.WIP.JoinsIndex.ContainsKey(Owner.selected))
            {
                List<Control> controls = new List<Control>() { FlipsRotation, FlipsTurn, RotationFlipLbl, TurnFlipLbl };
                Utils.VisibleObjects(controls, FlipsCb.Checked);
                Owner.WIP.JoinsIndex[Owner.selected].FlipAngle = FlipsCb.Checked ? (double)FlipsRotation.Value : -1;
                // SortOrder: Turn value
            }
        }

        /// <summary>
        /// Changes the rotation flip angle of the selected piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlipsUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Owner.selected != null && Owner.WIP.JoinsIndex.ContainsKey(Owner.selected))
            {
                Owner.WIP.JoinsIndex[Owner.selected].FlipAngle = sender == FlipsRotation ?
                    (double)FlipsRotation.Value : (double)FlipsTurn.Value;
                //SortOrder: Turn Value
            }
        }
    }
}
