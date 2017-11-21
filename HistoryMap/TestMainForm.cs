using System;
using System.Windows.Forms;
using HistoryMap.WorldMapUsers;

namespace HistoryMap
{
    static class TestMainForm
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WorldMapUser());
        }
    }
}
