using System.Collections.Generic;

namespace Optimator
{
    /// <summary>
    /// A class to hold information about a video for exporting.
    /// A video is a collection of scenes.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class Video
    {
        #region Video Variables
        public string Name { get; set; } = "";
        public string Version { get; }

        public List<Scene> videoScenes = new List<Scene>();

        public decimal FPS = 60;
        public int videoWidth = Consts.defaultWidth;
        public int videoHeight = Consts.defaultHeight;
        #endregion


        /// <summary>
        /// Scene constructor. Assigns variables based
        /// on the scene file that is loaded.
        /// </summary>
        /// <param name="name">Name of scene to load</param>
        /// <param name="data">Video data</param>
        public Video(string name, List<string> data)
        {
            Name = name;
            Version = data[0];

            // FPS, Video Size
            var info = data[1].Split(Consts.Semi);
            FPS = int.Parse(info[0]);
            videoWidth = int.Parse(info[1].Split(Consts.Colon)[0]);
            videoHeight = int.Parse(info[1].Split(Consts.Colon)[1]);

            // Scenes
            for (var index = 2; index < data.Count; index++)
            {
                videoScenes.Add(new Scene(data[index] + Consts.SceneExt, 
                    Utils.ReadFile(Utils.GetDirectory(data[index] + Consts.SceneExt))));
            }                                             
        }

        /// <summary>
        /// Scene constructor for creating a new scene.
        /// </summary>
        public Video()
        {
            Version = Properties.Settings.Default.Version;
        }



        // ----- GENERAL FUNCTIONS -----

        /// <summary>
        /// Converts the scene into a string format for saving.
        /// </summary>
        /// <returns></returns>
        public List<string> GetData()
        {
            var data = new List<string>
            {
                Properties.Settings.Default.Version,
                FPS.ToString() + Consts.SemiS + videoWidth.ToString() + Consts.ColonS + videoHeight.ToString()
            };

            // Save Parts
            foreach (var scene in videoScenes)
            {
                data.Add(scene.Name);
            }

            return data;
        }
    }
}
