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
    public partial class SavePanel : PanelControl
    {
        private readonly ScenesTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public SavePanel(ScenesTab owner)
        {
            InitializeComponent();
            Owner = owner;
        }

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            float widthPercent = 0.9F;
            float heightPercent = 0.1F;

            int bigWidth = (int)(Width * widthPercent);
            int lilWidth = (int)((Width - bigWidth) / 2.0);

            SaveLbl.Location = new Point(lilWidth, lilWidth);
            NameTb.Width = bigWidth;
            NameTb.Location = new Point(lilWidth, lilWidth * 3 + SaveLbl.Height);

            CompleteBtn.Size = new Size(bigWidth, (int)(Height * heightPercent));
            CompleteBtn.Location = new Point(lilWidth, Height - lilWidth - CompleteBtn.Height);
        }

        /// <summary>
        /// Completes and saves the scene to a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            //TODO: Add another button for simply 'save' rather than also closing the form
            if (!Utils.CheckValidNewName(NameTb.Text, Consts.ScenesFolder))
            {
                return;
            }
            try
            {
                Utils.SaveFile(Utils.GetDirectory(Consts.ScenesFolder, NameTb.Text, Consts.Optr), Owner.WIP.GetData());
                Owner.CloseBtn_Click(sender, e);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Updates the tab name based on the name of the new video.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTb_TextChanged(object sender, EventArgs e)
        {
            Owner.Parent.Text = NameTb.Text;
        }
    }
}
