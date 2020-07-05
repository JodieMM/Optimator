using Optimator.Tabs;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System;
using Optimator.Tabs.Compile;
using System.Diagnostics;

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
            Owner.Owner.GetTabControl().KeyDown += KeyPress;
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.9F;
            var heightPercent = 0.8F;

            var bigWidth = (int)(Width * widthPercent);
            var lilWidth = (int)((Width - bigWidth) / 2.0);

            SaveLbl.Location = new Point(lilWidth, lilWidth);
            TableLayoutPnl.Location = new Point(lilWidth, lilWidth * 3 + SaveLbl.Height);
            TableLayoutPnl.Size = new Size(bigWidth, (int)(Height * heightPercent));
        }

        /// <summary>
        /// Saves the video created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Owner.Directory = Utils.SaveFile(Owner.WIP.GetData(), Consts.VideoFilter, sender == SaveAsBtn ? "" : Owner.Directory);
            if (Owner.Directory != "")
            {
                Owner.Parent.Text = Utils.BaseName(Owner.Directory);
            }
        }

        /// <summary>
        /// Exports and saves the video created and closes the tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportBtn_Click(object sender, EventArgs e)
        {
            if (ExportVideo())
            {
                var result = MessageBox.Show("Export Successful! Would you like to close this tab?", "Close Tab Confirmation", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    Owner.Owner.RemoveTabPage(Owner);
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
                        SaveBtn_Click(sender, e);
                        break;

                    // Do nothing for any other key
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Shows the progress bar with fresh values.
        /// </summary>
        /// <param name="max"></param>
        private void ShowProgBar(int max)
        {
            ProgBar.Minimum = 1;
            ProgBar.Maximum = max;
            ProgBar.Value = 1;
            ProgBar.Step = 1;
            ProgBar.Visible = true;
        }

        /// <summary>
        /// Increases the loading bar progress.
        /// </summary>
        /// <param name="step">How much to progress</param>
        private void IncrementStep(int step = 1)
        {
            for (int index = 0; index < step; index++)
            {
                ProgBar.PerformStep();
            }
        }



        // ----- UTILITY FUNCTIONS -----

        /// <summary>
        /// Exports the video.
        /// </summary>
        /// <returns>True if successful</returns>
        private bool ExportVideo()
        {
            var chosenDirectory = Utils.SelectSaveDirectory(Consts.AviFilter);
            if (chosenDirectory == "")
            {
                return false;
            }
            try
            {
                // Prepare Loading Visuals
                var numFrames = 0;
                var timeIncrement = 1 / Owner.WIP.FPS;
                var totalFrames = 0;
                foreach (var scene in Owner.WIP.videoScenes)
                {
                    totalFrames += (int)(scene.TimeLength * Owner.WIP.FPS);
                }
                var ConvertExtras = (int)(0.1 * totalFrames);
                var DeleteFramesExtras = (int)(0.2 * ConvertExtras);
                ShowProgBar(totalFrames + ConvertExtras + (Properties.Settings.Default.SaveVideoFrames ? 0 : DeleteFramesExtras));
                

                // Prepare Save Location
                var imagesLocation = Path.Combine(Path.GetDirectoryName(chosenDirectory), Utils.BaseName(chosenDirectory));
                if (Directory.Exists(imagesLocation))
                {
                    Directory.Delete(imagesLocation, true);
                }
                if (File.Exists(chosenDirectory))
                {
                    File.Delete(chosenDirectory);
                }
                Directory.CreateDirectory(imagesLocation);
                var imagesDirectory = @"""" + Utils.GetDirectory(imagesLocation, "%d", Consts.Png) + @"""";
                var videosDirectory = @"""" + chosenDirectory + @"""";

                // Save Images                
                for (Owner.sceneIndex = 0; Owner.sceneIndex < Owner.WIP.videoScenes.Count; Owner.sceneIndex++)
                {
                    for (Owner.workingTime = 0; Owner.workingTime <= Owner.WIP.videoScenes[Owner.sceneIndex].TimeLength; Owner.workingTime += timeIncrement)
                    {
                        var bitmap = Owner.DrawOnBitmap();
                        bitmap.Save(Utils.GetDirectory(imagesLocation, numFrames.ToString(), Consts.Png), System.Drawing.Imaging.ImageFormat.Png);
                        numFrames++;
                        IncrementStep();
                        bitmap.Dispose();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }

                // Convert To Avi
                Process process = new Process();
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.FileName = "ffmpeg.exe";
                process.StartInfo.Arguments = "-framerate " + Owner.WIP.FPS + " -f image2 -i " + imagesDirectory + " -c:v mpeg4 -q:v 3 " + videosDirectory;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                var output = process.StandardError.ReadToEnd();
                var output2 = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                process.Close();
                IncrementStep(totalFrames - numFrames - (Properties.Settings.Default.SaveVideoFrames ? 0 : DeleteFramesExtras));


                // Delete Images if Settings Says So
                if (!Properties.Settings.Default.SaveVideoFrames)
                {
                    Directory.Delete(imagesLocation, true);
                    IncrementStep(DeleteFramesExtras);
                }

                ProgBar.Visible = false;
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
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("The program does not have permission to delete the images file." + 
                    " Your anti-virus may be blocking the process. However, this does not otherwise affect the export process."
                    , "Unauthorised Access", MessageBoxButtons.OK);
                ProgBar.Visible = false;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Exception - Please Report to jodie@opti.technology", MessageBoxButtons.OK);
            }
            ProgBar.Visible = false;
            return false;
        }
    }
}
