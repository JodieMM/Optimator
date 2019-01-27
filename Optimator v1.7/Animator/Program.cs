using System;
using System.Windows.Forms;

namespace Animator
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
            MenuForm menu = new MenuForm();
            Application.Run(menu);
        }
    }
}
