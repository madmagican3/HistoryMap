using System;
using System.Windows.Forms;
using HistoryMap.Shared_Classes;
using HistoryMap.WorldMapUsers;

namespace HistoryMap.AdminPanel
{
    public partial class LoginModal : Form
    {
        /// <summary>
        /// This is a local instance of the settings form so as to set vars
        /// </summary>
        private SettingsForm form;
        public LoginModal(SettingsForm panel)
        {
            form = panel;
            InitializeComponent();
        }
        /// <summary>
        /// This attempts to login the the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (usernameTxt.Text != null && passwordTxt.Text != null)
            {
                GetClient();
                if (_client != null)
                {
                    form.Client = _client;
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
        /// <summary>
        /// This is a copy of the local instance of the client
        /// </summary>
        private static HistoryMapWebClient _client;
        /// <summary>
        /// This tries to create the client and upon the catch of fail (so invalid password) it throws an error
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// This presses the loginbtn upon hitting enter on the password field (because it was annoying me)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                LoginBtn_Click(this, new EventArgs() );
        }
    }
}
