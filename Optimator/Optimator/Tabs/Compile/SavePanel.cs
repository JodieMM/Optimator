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
            var heightPercent = 0.4F;

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
                Owner.Parent.Text = Path.GetFileNameWithoutExtension(Owner.Directory);
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



        // ----- UTILITY FUNCTIONS -----

        /// <summary>
        /// Exports the video.
        /// </summary>
        /// <returns>True if successful</returns>
        private bool ExportVideo()
        {
            //TODO: EXPORT NAME SELECT
            var name = "holder";
            if (!Utils.CheckValidNewName(name))
            {
                return false;
            }
            try
            {
                Cursor = Cursors.WaitCursor;

                // Prepare Save Location
                var directory = Utils.GetDirectory(name);
                Directory.CreateDirectory(directory);
                var imagesDirectory = @"""" + Utils.GetDirectory(directory, "%d", Consts.Png) + @"""";
                var videosDirectory = @"""" + Utils.GetDirectory(directory, name, Consts.Avi) + @"""";

                // Save Images
                var numFrames = 0;                
                var timeIncrement = 1 / Owner.WIP.FPS;
                for (Owner.sceneIndex = 0; Owner.sceneIndex < Owner.WIP.videoScenes.Count; Owner.sceneIndex++)
                {
                    for (Owner.workingTime = 0; Owner.workingTime <= Owner.WIP.videoScenes[Owner.sceneIndex].TimeLength; Owner.workingTime += timeIncrement)
                    {
                        var bitmap = Owner.DrawOnBitmap();
                        bitmap.Save(Utils.GetDirectory(directory, numFrames.ToString(), Consts.Png), System.Drawing.Imaging.ImageFormat.Png);
                        numFrames++;
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

                try
                {
                    process.Start();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Exception - Please Report to jodie@opti.technology", MessageBoxButtons.OK);
                    return false;
                }

                Cursor = Cursors.Default;
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
