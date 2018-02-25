using System;
using System.Windows.Forms;

namespace HistoryMap.WorldMapCreate
{
    public partial class AgreementForm : Form
    {
        public AgreementForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// upon the accept button being clicked create a new instance of the world map users form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            new WorldMapUsers.WorldMapUser().Show();
            Hide();
        }

        private void RefuseBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
