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
            var heightPercent = 0.1F;

            var bigWidth = (int)(Width * widthPercent);
            var lilWidth = (int)((Width - bigWidth) / 2.0);

            SaveLbl.Location = new Point(lilWidth, lilWidth);

            NameTb.Width = bigWidth;
            NameTb.Location = new Point(lilWidth, lilWidth * 3 + SaveLbl.Height);

            ExportBtn.Size = SaveBtn.Size = new Size(bigWidth, (int)(Height * heightPercent));
            ExportBtn.Location = new Point(lilWidth, Height - lilWidth - ExportBtn.Height);
            SaveBtn.Location = new Point(lilWidth, ExportBtn.Location.Y - lilWidth - SaveBtn.Height);
        }

        /// <summary>
        /// Saves the video created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (Utils.CheckValidNewName(NameTb.Text))
            {
                try
                {
                    Utils.SaveFile(Utils.GetDirectory(NameTb.Text, Consts.VideoExt), Owner.WIP.GetData());
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not found. Check your file name and try again.", "File Not Found", MessageBoxButtons.OK);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Possible Outdated File", "File Error", MessageBoxButtons.OK);
                }
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
        /// Updates the tab name based on the name of the new video.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTb_TextChanged(object sender, EventArgs e)
        {
            Owner.Parent.Text = NameTb.Text;
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
            if (!Utils.CheckValidNewName(NameTb.Text))
            {
                return false;
            }
            try
            {
                Cursor = Cursors.WaitCursor;

                // Prepare Save Location
                var directory = Utils.GetDirectory(NameTb.Text);
                Directory.CreateDirectory(directory);
                var imagesDirectory = @"""" + Utils.GetDirectory(directory, "%d", Consts.Png) + @"""";
                var videosDirectory = @"""" + Utils.GetDirectory(directory, NameTb.Text, Consts.Avi) + @"""";

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
                // TODO: FFMPEG Resource Used Below
                process.StartInfo.FileName = @"""" + Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\ffmpeg\bin\ffmpeg.exe""";
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
