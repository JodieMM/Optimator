using Optimator;
using System;
using System.Windows.Forms;

namespace Optimator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// 
        /// Author Jodie Muller
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HomeForm home = new HomeForm();
            Application.Run(home);
        }
    }
}
