using Optimator.Forms;
using Optimator.Tabs;
using Optimator.Tabs.Compile;
using Optimator.Tabs.Scenes;
using Optimator.Tabs.Sets;
using System;
using System.IO;
using System.Windows.Forms;

namespace Optimator
{
    /// <summary>
    /// The main form that hosts all others as sub elements.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public partial class HomeForm : Form
    {
        /// <summary>
        /// Constructor for the form.
        /// </summary>
        public HomeForm()
        {
            InitializeComponent();
        }



        // ----- FORM FUNCTIONS -----

        /// <summary>
        /// Resizes the sub-elements of the form.
        /// </summary>
        /// <param name="eventargs"></param>
        protected override void OnResize(EventArgs eventargs)
        {
            TabControl.Width = Width;
            TabControl.Height = Height;
            foreach (TabPage page in TabControl.Controls)
            {
                foreach (var cntl in page.Controls)
                {
                    if (cntl is TabPageControl)
                    {
                        (cntl as TabPageControl).Resize();
                    }
                }
            }
        }



        // ----- TOOL STRIP -----

        #region Tool Strip Clicks

        // --- NEW ---

        /// <summary>
        /// Adds a new PiecesTab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPieceTSMI_Click(object sender, EventArgs e)
        {
            var tab = new PiecesTab(this);
            AddTabPage("New Piece", tab);
            tab.Resize();
        }

        /// <summary>
        /// Adds a new SetsTab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewSetTSMI_Click(object sender, EventArgs e)
        {
            var tab = new SetsTab(this);
            AddTabPage("New Set", tab);
            tab.Resize();
        }

        /// <summary>
        /// Adds a new ScenesTab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewSceneTSMI_Click(object sender, EventArgs e)
        {
            var tab = new ScenesTab(this);
            AddTabPage("New Scene", tab);
            tab.Resize();
        }

        /// <summary>
        /// Adds a new VideosTab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewVideoTSMI_Click(object sender, EventArgs e)
        {
            var tab = new CompileTab(this);
            AddTabPage("New Video", tab);
            tab.Resize();
        }

        /// <summary>
        /// Adds a new SpriteSheetTab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewSpriteSheetTSMI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not yet available.", "Feature Under Development", MessageBoxButtons.OK);
        }



        // --- OPEN ---

        /// <summary>
        /// Opens an Optimator file for editing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenTSMI_Click(object sender, EventArgs e)
        {
            var name = Utils.OpenFile(Consts.OptiFilter);
            if (name != "")
            {
                try
                {
                    TabPageControl attemptOpen;
                    if (name.EndsWith(Consts.PieceExt))
                    {
                        attemptOpen = new PiecesTab(this);
                        (attemptOpen as PiecesTab).WIP = new Piece(name, Utils.ReadFile(Utils.GetDirectory(name)));
                        
                        var panel = (attemptOpen as PiecesTab).GetBoardSizing();
                        foreach (var spot in (attemptOpen as PiecesTab).WIP.Data)
                        {
                            spot.X += panel.Width / 2.0F;
                            spot.Y += panel.Height / 2.0F;
                            spot.XRight += panel.Width / 2.0F;
                            spot.YDown += panel.Height / 2.0F;
                        }
                    }
                    else if (name.EndsWith(Consts.SetExt))
                    {
                        attemptOpen = new SetsTab(this);
                        (attemptOpen as SetsTab).WIP = new Set(name, Utils.ReadFile(Utils.GetDirectory(name)));
                    }
                    else if (name.EndsWith(Consts.SceneExt))
                    {
                        attemptOpen = new ScenesTab(this);
                        (attemptOpen as ScenesTab).WIP = new Scene(name, Utils.ReadFile(Utils.GetDirectory(name)));
                        (attemptOpen as ScenesTab).UpdateVideoLength((attemptOpen as ScenesTab).WIP.TimeLength);
                        (attemptOpen as ScenesTab).SetDrawPanelColour((attemptOpen as ScenesTab).WIP.Background);
                        (attemptOpen as ScenesTab).SetDrawPanelSize((attemptOpen as ScenesTab).WIP.Width,
                            (attemptOpen as ScenesTab).WIP.Height);
                    }
                    else
                    {
                        attemptOpen = new CompileTab(this);
                        (attemptOpen as CompileTab).WIP = new Video(name, Utils.ReadFile(Utils.GetDirectory(name)));
                        (attemptOpen as CompileTab).RedrawSceneViewPanel();
                    }
                    AddTabPage(Utils.BaseName(name), attemptOpen);
                    attemptOpen.Resize();
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



        // --- SETTINGS ---

        /// <summary>
        /// Adds a new SettingsTab or opens an existing one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsTSMI_Click(object sender, EventArgs e)
        {
            var tab = new SettingsTab(this);
            AddTabPageIfNew("Settings", tab);
            tab.DisplaySettings();
        }



        // --- HELP ---

        /// <summary>
        /// Adds a new HelpTab or opens an existing one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpTSMI_Click(object sender, EventArgs e)
        {
            AddTabPageIfNew("Help", new HelpTab(this));
        }

        #endregion



        // ----- TAB PAGES -----

        /// <summary>
        /// Gets the tab control to allow for key press controls.
        /// </summary>
        /// <returns>The TabControl</returns>
        public Control GetTabControl()
        {
            return TabControl;
        }

        /// <summary>
        /// Adds a user control to the TabControl as a TabPage.
        /// </summary>
        /// <param name="name">Tab label</param>
        /// <param name="tab">The tab to add</param>
        public void AddTabPage(string name, TabPageControl tab)
        {
            var page = new TabPage(name);
            tab.Dock = DockStyle.Fill;
            page.Controls.Add(tab);
            page.Enter += tab.RefreshDrawPanel;
            TabControl.Controls.Add(page);
            TabControl.SelectedIndex = TabControl.Controls.Count - 1;
            TabControl.SelectedTab.Focus();
        }

        /// <summary>
        /// Adds a user control to the TabControl as a TabPage or opens 
        /// an existing instance of that tab type.
        /// </summary>
        /// <param name="name">Tab label</param>
        /// <param name="tab">The tab to add</param>
        public void AddTabPageIfNew(string name, TabPageControl tab)
        {
            var found = false;
            var index = 0;
            while (!found && index < TabControl.TabPages.Count)
            {
                foreach (var cntl in TabControl.TabPages[index].Controls)
                {
                    if (tab.GetType() == cntl.GetType())
                    {
                        TabControl.SelectedIndex = index;
                        found = true;
                    }
                }
                index++;
            }
            if (!found)
            {
                AddTabPage(name, tab);
                tab.Resize();
            }
        }

        /// <summary>
        /// Removes a TabPage from the TabControl by finding a matching UserControl.
        /// </summary>
        /// <param name="tab"></param>
        public void RemoveTabPage(UserControl tab)
        {
            var found = false;
            var index = 0;
            while (!found && index < TabControl.Controls.Count)
            {
                if (TabControl.Controls[index].Contains(tab))
                {
                    if (TabControl.SelectedIndex == index && index > 0)
                    {
                        TabControl.SelectedIndex = index - 1;
                    }
                    TabControl.Controls.RemoveAt(index);
                    found = true;
                }
                index++;
            }
        }
    }
}
