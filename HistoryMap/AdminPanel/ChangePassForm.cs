using System;
using System.Windows.Forms;

namespace HistoryMap.AdminPanel
{
    public partial class ChangePassForm : Form
    {
        public ChangePassForm()
        {
            InitializeComponent();
        }

        private void SavePassBtn_Click(object sender, EventArgs e)
        {
            if (PassTxt.Text.Equals(DupePassTxt.Text))
            {
                //TODO save new pass
            }
            else
            {
                MessageBox.Show(@"The 2 passwords are not the same");
            }
        }
    }
}
