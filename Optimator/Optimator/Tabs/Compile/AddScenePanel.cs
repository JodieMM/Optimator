using Optimator.Tabs;
using System.Windows.Forms;
using System.Drawing;
using System;
using Optimator.Tabs.Compile;

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
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            float widthPercent = 0.9F;
            float smallWidthPercent = 0.05F;
            float heightPercent = 0.3F;

            int bigWidth = (int)(Width * widthPercent);
            int lilWidth = (int)(Width * smallWidthPercent);
            int bigHeight = (int)(Height * heightPercent);

            AddSceneLbl.Location = new Point(lilWidth, lilWidth);

            TableLayoutPnl.Location = new Point(lilWidth, lilWidth * 2 + AddSceneLbl.Height);
            TableLayoutPnl.Size = new Size(bigWidth, bigHeight);
        }

        /// <summary>
        /// Adds the entered scene into the video.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitScene_Click(object sender, EventArgs e)
        {
            Owner.videoScenes.Add(new Scene(AddTb.Text));
        }

        /// <summary>
        /// Previews what the video will look like.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayBtn_Click(object sender, EventArgs e)
        {
            Owner.sceneIndex = 0;
            Owner.workingTime = 0;
            Owner.DrawFrame(Owner.videoScenes[0]);
            Owner.StartTimer();
        }
    }
}
