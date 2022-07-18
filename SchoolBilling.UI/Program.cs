using MetroFramework;
using SchoolBilling.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolBilling.UI
{
    internal static class Program
    {
        public static MetroThemeStyle SelectedTheme = MetroThemeStyle.Light;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataLayer.UpdateDatabase();
            Application.Run(new MenuForm());
        }
    }
}
