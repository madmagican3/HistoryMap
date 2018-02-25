using System;
using System.Windows.Forms;
using HistoryMap.WorldMapCreate;

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
            Application.Run(new AgreementForm());
           // Application.Run(new CreateForm());
            //Application.Run(new AdminPanel.AdminPanel());
        }
    }
}
