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
            foreach (var scene in Owner.videoScenes)
            {
                SceneLb.Items.Add(scene.Name);
            }
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resize the panel's contents.
        /// </summary>
        public override void Resize()
        {
            var widthPercent = 0.9F;
            var smallWidthPercent = 0.05F;
            var heightPercent = 0.8F;

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
        private void SubmitScene_Click(object sender, EventArgs e)
        {
            var count = Owner.videoScenes.Count;
            Owner.videoScenes.Add(new Scene(AddTb.Text));
            if (count < Owner.videoScenes.Count)
            {
                SceneLb.Items.Add(AddTb.Text);
            }
        }
    }
}
