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
                GetClient();
                if (_client != null)
                {
                    form._client = _client;
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

        private static HistoryMapWebClient _client;
        public HistoryMapWebClient GetClient()
        {
            if (_client == null)
            {
                try
                {
                    _client = new HistoryMapWebClient(usernameTxt.Text, passwordTxt.Text);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"An error occurred: {e.Message}");
                }
            }
            return _client;
        }
    }
}
