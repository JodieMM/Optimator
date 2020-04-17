﻿using Optimator.Forms;
using Optimator.Tabs;
using Optimator.Tabs.Sets;
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
                foreach (Control cntl in page.Controls)
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
            PiecesTab tab = new PiecesTab(this);
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
            SetsTab tab = new SetsTab(this);
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
            //TODO Update Tab Type
            PiecesTab tab = new PiecesTab(this);
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
            //TODO Update Tab Type
            PiecesTab tab = new PiecesTab(this);
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
            //TODO: Open Tabs
            PiecesTab tab = new PiecesTab(this);    //PieceName = ...
            AddTabPage("New Piece", tab);
            tab.Resize();
        }



        // --- DIRECTORY ---



        // --- SETTINGS ---

        /// <summary>
        /// Adds a new SettingsTab or opens an existing one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsTSMI_Click(object sender, EventArgs e)
        {
            bool found = false;
            int index = 0;
            while (!found && index < TabControl.TabPages.Count)
            {
                foreach (Control cntl in TabControl.TabPages[index].Controls)
                {
                    if (cntl is SettingsTab)
                    {
                        TabControl.SelectedIndex = index;
                        found = true;
                    }
                }
                index++;
            }
            if (!found)
            {
                SettingsTab tab = new SettingsTab(this);
                AddTabPage("Settings", tab);
                tab.Resize();
            }
        }



        // --- HELP ---



        #endregion



        // ----- TAB PAGES -----

        /// <summary>
        /// Adds a user control to the TabControl as a TabPage.
        /// </summary>
        /// <param name="name">Tab label</param>
        /// <param name="tab">The tab to add</param>
        public void AddTabPage(string name, UserControl tab)
        {
            TabPage page = new TabPage(name);
            tab.Dock = DockStyle.Fill;
            page.Controls.Add(tab);
            TabControl.Controls.Add(page);
            TabControl.SelectedIndex = TabControl.Controls.Count - 1;
            TabControl.SelectedTab.Focus();
        }

        /// <summary>
        /// Removes a TabPage from the TabControl by finding a matching UserControl.
        /// </summary>
        /// <param name="tab"></param>
        public void RemoveTabPage(UserControl tab)
        {
            bool found = false;
            int index = 0;
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
