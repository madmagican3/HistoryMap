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

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            new WorldMapUsers.WorldMapUser().Show();
            Hide();
        }

        private void RefuseBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
