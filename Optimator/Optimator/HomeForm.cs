using Optimator.Forms;
using Optimator.Tabs;
using Optimator.Tabs.Compile;
using Optimator.Tabs.Scenes;
using Optimator.Tabs.Sets;
using Optimator.Tabs.SoloTabs;
using System;
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
            Settings.InitialSettings();
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
                


        // --- OPEN ---

        /// <summary>
        /// Opens an existing piece in a new PiecesTab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPieceTSMI_Click(object sender, EventArgs e)
        {
            var open = new OpenDialog(this, "Piece", new PiecesTab(this));
            AddTabPage("Add Piece", open);
            open.Resize();
        }

        /// <summary>
        /// Opens an existing set in a new SetsTab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSetTSMI_Click(object sender, EventArgs e)
        {
            var open = new OpenDialog(this, "Set", new SetsTab(this));
            AddTabPage("Add Set", open);
            open.Resize();
        }

        /// <summary>
        /// Opens an existing scene in a new ScenesTab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSceneTSMI_Click(object sender, EventArgs e)
        {
            var open = new OpenDialog(this, "Scene", new ScenesTab(this));
            AddTabPage("Add Scene", open);
            open.Resize();
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
        /// Adds a user control to the TabControl as a TabPage.
        /// </summary>
        /// <param name="name">Tab label</param>
        /// <param name="tab">The tab to add</param>
        public void AddTabPage(string name, UserControl tab)
        {
            if (Utils.CheckValidFolder())
            {
                var page = new TabPage(name);
                tab.Dock = DockStyle.Fill;
                page.Controls.Add(tab);
                TabControl.Controls.Add(page);
                TabControl.SelectedIndex = TabControl.Controls.Count - 1;
                TabControl.SelectedTab.Focus();
            }
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
                    TabControl.Controls.RemoveAt(index);
                    found = true;
                }
                index++;
            }
        }
    }
}
