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
            EnableScrolls(Owner.selected != null);
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.9F;
            var heightPercent = 0.3F;

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
        public void EnableScrolls(bool enable = true)
        {
            SizeBar.Enabled = enable;
            if (enable)
            {
                SizeBar.Value = (int)(Owner.WIP.PersonalStates[Owner.selected].SM * 100.0F);
            }
            Utils.EnableObjects(new List<Control>() { RotationBar, TurnBar, SpinBar }, enable && Owner.selected != Owner.WIP.BasePiece);
            if (enable && Owner.selected != Owner.WIP.BasePiece)
            {               
                RotationBar.Value = (int)Owner.WIP.PersonalStates[Owner.selected].R;
                TurnBar.Value = (int)Owner.WIP.PersonalStates[Owner.selected].T;
                SpinBar.Value = (int)Owner.WIP.PersonalStates[Owner.selected].S;
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

            Owner.DisplayDrawings();
        }
    }
}
