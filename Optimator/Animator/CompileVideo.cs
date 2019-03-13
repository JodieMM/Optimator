﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Animator
{
    /// <summary>
    /// The form used to combine scenes into a single video
    /// and export in a video file type.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class CompileVideo : Form
    {
        #region Video Variables
        private List<Scene> videoScenes = new List<Scene>();
        private int sceneIndex = 0;
        private decimal workingTime = 0;
        private decimal timeIncrement = (decimal)0.5;

        private Graphics g;
        private Color backgroundColor = Color.White;
        #endregion


        /// <summary>
        /// Form constructor.
        /// </summary>
        public CompileVideo()
        {
            InitializeComponent();
        }



        // ----- OPTIONS BUTTONS -----

        /// <summary>
        /// Adds the entered scene into the video.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitScene_Click(object sender, EventArgs e)
        {
            videoScenes.Add(new Scene(SceneTb.Text));
        }

        /// <summary>
        /// Previews what the video will look like.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayBtn_Click(object sender, EventArgs e)
        {
            sceneIndex = 0;
            workingTime = 0;
            DrawFrame(videoScenes[0]);
            AnimationTimer.Start();
        }

        /// <summary>
        /// Closes the form without saving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Yes;

            // Only check if there is something to save
            if (videoScenes.Count > 0)
                result = MessageBox.Show("Do you wish to exit without saving?", "Exit Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
                Close();
        }

        /// <summary>
        /// Exports and saves the video created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!Utilities.CheckValidNewName(NameTb.Text, Constants.VideosFolder)) { return; }
            try
            {
                LoadingForm loading = new LoadingForm();
                loading.Show();
                Application.DoEvents();

                // Prepare Save Location
                Directory.CreateDirectory(Utilities.GetDirectory(Constants.VideosFolder, NameTb.Text));

                // Save Images
                int numFrames = 0;
                decimal timeIncrement = 1 / FpsUpDown.Value;
                for (sceneIndex = 0; sceneIndex < videoScenes.Count; sceneIndex++)
                {
                    for (workingTime = 0; workingTime <= videoScenes[sceneIndex].TimeLength; workingTime += timeIncrement)
                    {
                        Bitmap bitmap = DrawOnBitmap();
                        bitmap.Save(Utilities.GetDirectory(Constants.VideosFolder, numFrames.ToString(), Constants.Png, NameTb.Text), System.Drawing.Imaging.ImageFormat.Png);
                        numFrames++;
                    }
                }
                loading.Close();
                Close();
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



        // ----- SETTINGS TAB -----

        /// <summary>
        /// Hides or shows the preview panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewCb_CheckedChanged(object sender, EventArgs e)
        {
            DisplayPanel.Visible = PreviewCb.Checked;
        }

        /// <summary>
        /// Changes the time between preview frames.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeIncrementUpDown_ValueChanged(object sender, EventArgs e)
        {
            timeIncrement = TimeIncrementUpDown.Value;
        }



        // ----- DRAWING FUNCTIONS -----

        /// <summary>
        /// Draws a frame to a bitmap.
        /// </summary>
        /// <param name="baseScene">The frame to draw</param>
        /// <param name="g">The graphics to display with</param>
        private void DrawFrame(Scene baseScene, Graphics g = null)
        {
            if (g == null)
            {
                DrawPanel.Refresh();
                g = DrawPanel.CreateGraphics();
            }
            baseScene.RunScene(workingTime);      

            // Draw Parts
            foreach(Part part in baseScene.PartsList)
                part.Draw(g);
        }

        /// <summary>
        /// Draws the graphics created on a bitmap for exporting.
        /// </summary>
        /// <param name="toDraw">Scene to be drawn</param>
        /// <returns></returns>
        private Bitmap DrawOnBitmap()
        {
            Bitmap bitmap = new Bitmap(DrawPanel.Width, DrawPanel.Height);
            g = Graphics.FromImage(bitmap);
            using (SolidBrush brush = new SolidBrush(backgroundColor))
                g.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);

            DrawFrame(videoScenes[sceneIndex], g);
            return bitmap;
        }



        // ----- ANIMATION FUNCTIONS -----

        /// <summary>
        /// Updates the video by a frame.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (++workingTime > videoScenes[sceneIndex].TimeLength)
            {
                if (++sceneIndex >= videoScenes.Count)
                {
                    AnimationTimer.Stop();
                    return;
                }
                workingTime = 0;
            }
            DrawFrame(videoScenes[sceneIndex]);
        }
    }
}