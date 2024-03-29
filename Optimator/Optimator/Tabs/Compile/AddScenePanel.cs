﻿using Optimator.Tabs;
using System.Windows.Forms;
using System.Drawing;
using System;
using Optimator.Tabs.Compile;
using System.IO;
using Optimator.Properties;

namespace Optimator.Forms.Compile
{
    /// <summary>
    /// A panel for saving parts.
    /// </summary>
    public partial class AddScenePanel : PanelControl
    {
        private readonly CompileTab Owner;


        /// <summary>
        /// Constructor for the panel.
        /// </summary>
        public AddScenePanel(CompileTab owner)
        {
            InitializeComponent();
            Owner = owner;
            Owner.Owner.GetTabControl().KeyDown += KeyPress;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.9F;
            var smallWidthPercent = 0.05F;
            var heightPercent = 0.2F;

            var bigWidth = (int)(Width * widthPercent);
            var lilWidth = (int)(Width * smallWidthPercent);
            var bigHeight = (int)(Height * heightPercent);

            AddSceneLbl.Location = new Point(lilWidth, lilWidth);

            TableLayoutPnl.Location = new Point(lilWidth, lilWidth * 3 + AddSceneLbl.Height);
            TableLayoutPnl.Size = new Size(bigWidth, bigHeight);
        }

        /// <summary>
        /// Adds the entered scene into the video.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SubmitScene_Click(object sender, EventArgs e)
        {
            var names = Utils.OpenFiles(Consts.SceneFilter);
            if (names != null)
            {
                try
                {
                    foreach (var name in names)
                    {
                        var newScene = new Scene(name, Utils.ReadFile(Utils.GetDirectory(name)));
                        Owner.WIP.videoScenes.Add(newScene);
                        Owner.AddToSceneViewPanel(newScene);
                        var unchangedSize = Owner.WIP.videoWidth == Settings.Default.SceneWidth && 
                            Owner.WIP.videoHeight == Settings.Default.SceneHeight;
                        if (newScene.Width > Owner.WIP.videoWidth || 
                            Owner.WIP.videoScenes.Count == 1 && unchangedSize && newScene.Width != Owner.WIP.videoWidth)
                        {
                            Owner.WIP.videoWidth = newScene.Width;
                            Owner.RedrawSceneViewPanel();
                        }
                        if (newScene.Height > Owner.WIP.videoHeight || 
                            Owner.WIP.videoScenes.Count == 1 && unchangedSize && newScene.Height != Owner.WIP.videoHeight)
                        {
                            Owner.WIP.videoHeight = newScene.Height;
                            Owner.RedrawSceneViewPanel();
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file and sub-files and try again.", "File Not Found", MessageBoxButtons.OK);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Suspected outdated file or sub-file.", "File Indexing Error", MessageBoxButtons.OK);
                }
                catch (VersionException)
                {
                    // Handled by Exception
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("You do not have access to this file.", "Unauthorised Access Error", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("An error has occurred.", "Error", MessageBoxButtons.OK);
                }
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
                        SubmitScene_Click(sender, e);
                        break;

                    // Do nothing for any other key
                    default:
                        break;
                }
            }
        }
    }
}
