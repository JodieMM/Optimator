using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Sets
{
    /// <summary>
    /// A panel to adjust a part's position.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class PositionsPanel : PanelControl
    {
        private readonly SetsTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        /// <param name="owner"></param>
        public PositionsPanel(SetsTab owner)
        {
            InitializeComponent();
            Owner = owner;
            EnableControls(Owner.selected != null);
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.9F;
            var heightPercent = 0.6F;

            var bigWidth = (int)(Width * widthPercent);
            var lilWidth = (int)((Width - bigWidth) / 2.0);
            var bigHeight = (int)(Height * heightPercent);

            PositionsLbl.Location = new Point(lilWidth, lilWidth);

            TableLayoutPnl.Location = new Point(lilWidth, lilWidth * 3 + PositionsLbl.Height);
            TableLayoutPnl.Size = new Size(bigWidth, bigHeight);
        }        

        /// <summary>
        /// Enable scroll bars.
        /// </summary>
        /// <param name="enable">False if disabling</param>
        public void EnableControls(bool enable = true)
        {
            if (Owner.selected != null)
            {
                Utils.EnableObjects(new List<Control>() { SizeBar, XUpDown, YUpDown });
                Utils.EnableObjects(new List<Control>() { RotationBar, TurnBar, SpinBar },
                    enable && Owner.selected != Owner.WIP.BasePiece);
                if (enable)
                {                    
                    SizeBar.Value = (int)(Owner.WIP.PersonalStates[Owner.selected].SM * 100.0F);
                    if (Owner.WIP.JoinsIndex.ContainsKey(Owner.selected))
                    {
                        XUpDown.Value = (decimal)Owner.WIP.JoinsIndex[Owner.selected].CurrentStateOfAttached(
                            Owner.WIP.PersonalStates[Owner.selected]).X;
                        YUpDown.Value = (decimal)Owner.WIP.JoinsIndex[Owner.selected].CurrentStateOfAttached(
                            Owner.WIP.PersonalStates[Owner.selected]).Y;
                    }
                    else
                    {
                        XUpDown.Value = (decimal)Owner.WIP.PersonalStates[Owner.selected].X;
                        YUpDown.Value = (decimal)Owner.WIP.PersonalStates[Owner.selected].Y;
                    }
                    if (Owner.selected != Owner.WIP.BasePiece)
                    {
                        RotationBar.Value = (int)Owner.WIP.PersonalStates[Owner.selected].R;
                        TurnBar.Value = (int)Owner.WIP.PersonalStates[Owner.selected].T;
                        SpinBar.Value = (int)Owner.WIP.PersonalStates[Owner.selected].S;
                    }
                }
            }
        }

        /// <summary>
        /// Updates the selected piece based on the UI object
        /// that was interacted with.
        /// </summary>
        /// <param name="sender">Touched UI object</param>
        /// <param name="e"></param>
        private void ScrollBar_Scroll(object sender, EventArgs e)
        {
            if (Owner.selected == null)
            {
                return;
            }

            if (sender == RotationBar)
            {
                Owner.WIP.PersonalStates[Owner.selected].R = RotationBar.Value;
            }
            else if (sender == TurnBar)
            {
                Owner.WIP.PersonalStates[Owner.selected].T = TurnBar.Value;
            }
            else if (sender == SpinBar)
            {
                Owner.WIP.PersonalStates[Owner.selected].S = SpinBar.Value;
                if (Owner.GetIfJoinBtnPressed())
                {
                    Owner.SelectedRTS0();
                }
            }
            else if (sender == SizeBar)
            {
                Owner.WIP.PersonalStates[Owner.selected].SM = SizeBar.Value / 100.0F;
            }
            ValueToolTip.SetToolTip(sender as Control, (sender as TrackBar).Value.ToString());
            Owner.DisplayDrawings();
        }

        /// <summary>
        /// Updates the values of the selected item based on updown value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Owner.selected == null)
            {
                return;
            }

            if (Owner.WIP.JoinsIndex.ContainsKey(Owner.selected))
            {
                if (sender == XUpDown)
                {
                    Owner.WIP.JoinsIndex[Owner.selected].BXRight = 
                        Owner.WIP.JoinsIndex[Owner.selected].BX += (float)XUpDown.Value - 
                        Owner.WIP.JoinsIndex[Owner.selected].CurrentStateOfAttached(
                            Owner.WIP.PersonalStates[Owner.selected]).X;
                }
                else if (sender == YUpDown)
                {
                    Owner.WIP.JoinsIndex[Owner.selected].BYDown =
                        Owner.WIP.JoinsIndex[Owner.selected].BY += (float)YUpDown.Value - 
                        Owner.WIP.JoinsIndex[Owner.selected].CurrentStateOfAttached(
                            Owner.WIP.PersonalStates[Owner.selected]).Y;
                }
            }
            else
            {
                if (sender == XUpDown)
                {
                    Owner.WIP.PersonalStates[Owner.selected].X = (float)XUpDown.Value;
                }
                else if (sender == YUpDown)
                {
                    Owner.WIP.PersonalStates[Owner.selected].Y = (float)YUpDown.Value;
                }
            }
            Owner.DisplayDrawings();
        }

        /// <summary>
        /// Update the UI to reflect changes to X or Y.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="x"></param>
        public void UpdateXYValue(float value, bool x)
        {
            if (x)
            {
                XUpDown.Value = (decimal)value;
            }
            else
            {
                YUpDown.Value = (decimal)value;
            }
        }

        /// <summary>
        /// Adds a tool tip to the track bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackHover(object sender, EventArgs e)
        {
            ValueToolTip.SetToolTip(sender as Control, (sender as TrackBar).Value.ToString());
        }
    }
}
