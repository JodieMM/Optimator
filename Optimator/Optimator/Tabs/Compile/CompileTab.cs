﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Optimator.Forms.Compile;
using Optimator.Tabs.SoloTabs;

namespace Optimator.Tabs.Compile
{
    /// <summary>
    /// A tab page for creating and modifying scenes.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class CompileTab : TabPageControl
    {
        #region Video Variables
        public override HomeForm Owner { get; set; }
        public string Directory { get; set; } = "";

        public Video WIP = new Video();
        public int sceneIndex = 0;
        public decimal workingTime = 0;

        private Graphics g;
        private Dictionary<string, Bitmap[]> scenePreviews = new Dictionary<string, Bitmap[]>();
        #endregion
        
        
        /// <summary>
        /// Constructor for the tab.
        /// </summary>
        public CompileTab(HomeForm owner)
        {
            InitializeComponent();
            Owner = owner;

            Owner.GetTabControl().KeyUp += KeyPress;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the form's contents.
        /// </summary>
        public override void Resize()
        {
            Utils.ResizePanel(Panel);
        }

        #region ToolStrip

        /// <summary>
        /// Unchecks all of the checkable buttons and checks the provided one.
        /// </summary>
        private void SelectButton(ToolStripButton btn)
        {
            var check = btn.Checked;
            SaveBtn.Checked = false;
            AddSceneBtn.Checked = false;
            SettingsBtn.Checked = false;
            btn.Checked = !check;
        }

        /// <summary>
        /// Deselects all buttons. Used with LoadTab to ensure all 
        /// controls display correctly after the load.
        /// </summary>
        public void DeselectButtons()
        {
            SaveBtn.Checked = false;
            AddSceneBtn.Checked = false;
            SettingsBtn.Checked = false;
            Panel.Controls.Clear();
        }

        /// <summary>
        /// Opens or closes panel based on tool strip button press.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWithPanel_Click(object sender, EventArgs e)
        {
            if (!(sender as ToolStripButton).Checked)
            {
                PanelControl panel = new SavePanel(this);
                if (sender == SaveBtn)
                {
                    panel = new SavePanel(this);
                }
                else if (sender == SettingsBtn)
                {
                    panel = new SettingsPanel(this);
                }
                else if (sender == AddSceneBtn)
                {
                    panel = new AddScenePanel(this);
                }
                Utils.NewPanelContent(Panel, panel);
                SelectButton(sender as ToolStripButton);
            }
            else
            {
                DeselectButtons();
            }
        }

        /// <summary>
        /// Reload all of the scenes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < WIP.videoScenes.Count; index++)
            {
                WIP.videoScenes[index] = new Scene(WIP.videoScenes[index].Name,
                    Utils.ReadFile(Utils.GetDirectory(WIP.videoScenes[index].Name)));
            }
            RedrawSceneViewPanel();
        }

        /// <summary>
        /// Closes this tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public new void CloseBtn_Click(object sender, EventArgs e)
        {
            if (Utils.ExitBtn_Click(WIP.videoScenes.Count > 0))
            {
                Owner.RemoveTabPage(this);
            }
        }

        #endregion



        // ----- PANEL REFRESH TIMER

        /// <summary>
        /// Starts the drawing timer once the tab has been created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void RefreshDrawPanel(object sender, EventArgs e)
        {
            //Nothing Needed
        }



        // ----- SCENE VIEW PANEL -----

        /// <summary>
        /// Adds a scene preview to the panel.
        /// </summary>
        /// <param name="scene"></param>
        public void AddToSceneViewPanel(Scene scene)
        {
            if (!scenePreviews.ContainsKey(scene.Name) || scenePreviews[scene.Name][0].Size != new Size(WIP.videoWidth, WIP.videoHeight))
            {
                workingTime = 0;
                sceneIndex = WIP.videoScenes.Count - 1;
                var image1 = DrawOnBitmap();
                workingTime = scene.TimeLength;
                if (scenePreviews.ContainsKey(scene.Name))
                {
                    scenePreviews[scene.Name] = new Bitmap[2] { image1, DrawOnBitmap() };
                }
                else
                {
                    scenePreviews.Add(scene.Name, new Bitmap[2] { image1, DrawOnBitmap() });
                }
            }
            SceneViewPanel.Controls.Add(new ScenePreview(scene, scenePreviews[scene.Name][0], scenePreviews[scene.Name][1]));
        }

        /// <summary>
        /// Clears the scene view panel and redraws all of the previews.
        /// </summary>
        public void RedrawSceneViewPanel()
        {
            SceneViewPanel.Controls.Clear();
            foreach (var scene in WIP.videoScenes)
            {
                AddToSceneViewPanel(scene);
            }
        }

        /// <summary>
        /// Runs when a key is pressed.
        /// If delete is pressed and a preview is selected, it will be deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void KeyPress(object sender, KeyEventArgs e)
        {
            if (ContainsFocus)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        // Delete Selected Previews
                        foreach (Control control in SceneViewPanel.Controls)
                        {
                            if (control is ScenePreview && (control as ScenePreview).GetChecked() == true)
                            {
                                WIP.videoScenes.Remove((control as ScenePreview).scene);
                                SceneViewPanel.Controls.Remove(control);
                            }
                        }
                        break;

                    case Keys.Enter:
                        // Enter Name Textbox
                        foreach (Control control in Panel.Controls)
                        {
                            if (control is AddScenePanel)
                            {
                                (control as AddScenePanel).SubmitScene_Click(sender, e);
                            }
                        }
                        break;


                    // Do nothing for any other key
                    default:
                        break;
                }
            }
        }



        // ----- DRAWING FUNCTIONS -----

        /// <summary>
        /// Draws a frame to a bitmap.
        /// </summary>
        /// <param name="baseScene">The frame to draw</param>
        /// <param name="g">The graphics to display with</param>
        public void DrawFrame(Scene baseScene, Graphics g)
        {
            baseScene.RunScene(workingTime);

            // Draw Parts
            foreach (var part in baseScene.PartsList)
            {
                part.Draw(g);
            }
        }

        /// <summary>
        /// Draws the graphics created on a bitmap for exporting.
        /// </summary>
        /// <returns>Bitmap of current scene view</returns>
        public Bitmap DrawOnBitmap()
        {
            var bitmap = new Bitmap(WIP.videoWidth, WIP.videoHeight);
            g = Graphics.FromImage(bitmap);
            using (var brush = new SolidBrush(WIP.videoScenes[sceneIndex].Background))
            {
                g.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
            }
            DrawFrame(WIP.videoScenes[sceneIndex], g);
            return bitmap;
        }
    }
}
