﻿using Optimator.Tabs;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System;
using Optimator.Tabs.Compile;
using FFMpegSharp.FFMPEG;

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
            var widthPercent = 0.9F;
            var heightPercent = 0.1F;

            var bigWidth = (int)(Width * widthPercent);
            var lilWidth = (int)((Width - bigWidth) / 2.0);

            SaveLbl.Location = new Point(lilWidth, lilWidth);

            NameTb.Width = bigWidth;
            NameTb.Location = new Point(lilWidth, lilWidth * 3 + SaveLbl.Height);

            CompleteBtn.Size = SaveBtn.Size = new Size(bigWidth, (int)(Height * heightPercent));
            CompleteBtn.Location = new Point(lilWidth, Height - lilWidth - CompleteBtn.Height);
            SaveBtn.Location = new Point(lilWidth, CompleteBtn.Location.Y - lilWidth - SaveBtn.Height);
        }

        /// <summary>
        /// Exports and saves the video created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Save();
        }

        /// <summary>
        /// Exports and saves the video created and closes the tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Owner.Owner.RemoveTabPage(Owner);
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



        // ----- UTILITY FUNCTIONS -----

        /// <summary>
        /// Saves the video.
        /// </summary>
        /// <returns>True if successful</returns>
        private bool Save()
        {
            if (!Utils.CheckValidNewName(NameTb.Text, Consts.VideosFolder))
            {
                return false;
            }
            try
            {
                Owner.ShowLoadingMessage();

                // Prepare Save Location
                var directory = Utils.GetDirectory(Consts.VideosFolder, NameTb.Text);
                Directory.CreateDirectory(directory);

                // Save Images
                var numFrames = 0;
                var timeIncrement = 1 / Owner.FPS;
                for (Owner.sceneIndex = 0; Owner.sceneIndex < Owner.videoScenes.Count; Owner.sceneIndex++)
                {
                    for (Owner.workingTime = 0; Owner.workingTime <= Owner.videoScenes[Owner.sceneIndex].TimeLength; Owner.workingTime += timeIncrement)
                    {
                        var bitmap = Owner.DrawOnBitmap();
                        bitmap.Save(Utils.GetDirectory(directory, numFrames.ToString(), Consts.Png), System.Drawing.Imaging.ImageFormat.Png);
                        numFrames++;
                    }
                }

                //TODO: Test below works
                // Save MP4
                var directory2 = Utils.GetDirectory(directory, NameTb.Text, Consts.Mp4); // TODO Allow for alternate file types
                new FFMpeg().JoinImageSequence(new FileInfo(directory2), (double)Owner.FPS, new FFMpegSharp.ImageInfo(directory));

                Owner.ShowLoadingMessage(false);
                return true;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No data entered for point", "Missing Data", MessageBoxButtons.OK);
            }
            return false;
        }
    }
}
