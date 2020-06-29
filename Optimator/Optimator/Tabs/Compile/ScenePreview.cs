using System.Drawing;
using System.Windows.Forms;

namespace Optimator.Tabs.Compile
{
    /// <summary>
    /// A small panel to show the first and last frames of
    /// a scene with its name.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class ScenePreview : UserControl
    {
        public Scene scene;

        /// <summary>
        /// ScenePreview Constructor
        /// </summary>
        public ScenePreview(Scene previewed, Bitmap original, Bitmap final)
        {
            InitializeComponent();

            scene = previewed;
            SceneNameLbl.Text = Utils.BaseName(previewed.Name);

            OriginalPreview.BackgroundImage = Visuals.ScaleBitmap(OriginalPreview.Width,
                OriginalPreview.Height, original, Color.MistyRose);
            FinalPreview.BackgroundImage = Visuals.ScaleBitmap(FinalPreview.Width,
                FinalPreview.Height, final, Color.MistyRose);
        }



        // ----- FUNCTIONS -----

        /// <summary>
        /// Checks if checkbox checked.
        /// </summary>
        /// <returns>True if checkbox selected</returns>
        public bool GetChecked()
        {
            return SelectPreviewCb.Checked;
        }

        /// <summary>
        /// Selects (or deselects) the preview.
        /// </summary>
        /// <param name="show">True if being selected</param>
        private void SelectPreviewCb_CheckedChanged(object sender, System.EventArgs e)
        {
            TableLayoutPnl.BackColor = SelectPreviewCb.Checked ? Color.FromArgb(255, 192, 192) : Color.MistyRose;
        }    
    }
}
