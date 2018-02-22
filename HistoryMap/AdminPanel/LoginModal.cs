using System;
using System.Windows.Forms;
using HistoryMap.Shared_Classes;
using HistoryMap.WorldMapUsers;

namespace HistoryMap.AdminPanel
{
    public partial class LoginModal : Form
    {
        private SettingsForm form;
        public LoginModal(SettingsForm panel)
        {
            form = panel;
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (usernameTxt.Text != null && passwordTxt.Text != null)
            {
                var success = LocalMongoGetter.CheckLogin(usernameTxt.Text, passwordTxt.Text);
                if (success)
                {
                    form.Username = usernameTxt.Text;
                    form.Password = passwordTxt.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(@"Login failed");
                }
            }
            else
            {
                MessageBox.Show(@"Please populate all required fields");
            }
        }
    }
}
