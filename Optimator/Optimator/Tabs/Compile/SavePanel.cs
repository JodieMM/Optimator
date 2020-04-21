using Optimator.Tabs;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System;
using Optimator.Tabs.Compile;

namespace Optimator.Forms.Compile
{
    /// <summary>
    /// A panel for saving videos.
    /// </summary>
    public partial class SavePanel : PanelControl
    {
        private readonly CompileTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public SavePanel(CompileTab owner)
        {
            InitializeComponent();
            Owner = owner;
        }



        // ----- FORM FUNCTIONS -----

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
        /// Exports and saves the video created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteBtn_Click(object sender, System.EventArgs e)
        {
            //TODO: Add another button for simply 'save' rather than also closing the form
            if (!Utils.CheckValidNewName(NameTb.Text, Consts.VideosFolder))
            {
                return;
            }
            try
            {
                Owner.ShowLoadingMessage();

                // Prepare Save Location
                var directory = Utils.GetDirectory(Consts.VideosFolder, NameTb.Text);
                Directory.CreateDirectory(directory);

                // Save Images
                int numFrames = 0;
                decimal timeIncrement = 1 / Owner.FPS;
                for (Owner.sceneIndex = 0; Owner.sceneIndex < Owner.videoScenes.Count; Owner.sceneIndex++)
                {
                    for (Owner.workingTime = 0; Owner.workingTime <= Owner.videoScenes[Owner.sceneIndex].TimeLength; Owner.workingTime += timeIncrement)
                    {
                        Bitmap bitmap = Owner.DrawOnBitmap();
                        bitmap.Save(Utils.GetDirectory(directory, numFrames.ToString(), Consts.Png), System.Drawing.Imaging.ImageFormat.Png);
                        numFrames++;
                    }
                }
                Owner.ShowLoadingMessage(false);
                Owner.CloseBtn_Click(sender, e);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No data entered for point", "Missing Data", MessageBoxButtons.OK);
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
