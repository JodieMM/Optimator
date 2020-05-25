﻿using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Sets
{
    /// <summary>
    /// A panel to manage the sets tab settings.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class SettingsPanel : PanelControl
    {
        private readonly SetsTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public SettingsPanel(SetsTab owner)
        {
            InitializeComponent();
            Owner = owner;
            SelectFromTopCb.Checked = Owner.SelectFromTop;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.05F;

            var smallWidth = (int)(Width * widthPercent);

            SettingsLbl.Location = new Point(smallWidth, smallWidth);
            SelectFromTopCb.Location = new Point(smallWidth, smallWidth * 3 + SettingsLbl.Height);
        }

        /// <summary>
        /// Modifies the setting in owner.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFromTopCb_CheckedChanged(object sender, System.EventArgs e)
        {
            Owner.SelectFromTop = SelectFromTopCb.Checked;
        }
    }
}