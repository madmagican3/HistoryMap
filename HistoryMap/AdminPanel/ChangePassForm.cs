using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HistoryMap.Shared_Classes;

namespace HistoryMap.AdminPanel
{
    public partial class ChangePassForm : Form
    {
        /// <summary>
        /// This is an intance of the web client which is already authed
        /// </summary>
        private HistoryMapWebClient _client;
        public ChangePassForm(HistoryMapWebClient client)
        {
            _client = client;
            InitializeComponent();
        }
        /// <summary>
        /// This saves the pass after verifying that the user has entered the same password twice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SavePassBtn_Click(object sender, EventArgs e)
        {
            if (PassTxt.Text.Equals(DupePassTxt.Text))
            {
                List<UserClass> userList = _client.GetUsers().GetAwaiter().GetResult();
                UserClass user = new UserClass();
                foreach (var users in userList)
                {
                    if (users.user == _client.Username)
                    {
                        user = users;
                    }
                }

                if (user.user!= null)
                {
                    user.pass = PassTxt.Text;
                    _client.UpdateRecord(user).GetAwaiter();
                    Close();
                }
                else
                {
                    MessageBox.Show(@"An error has occured");
                }

            }
            else
            {
                MessageBox.Show(@"The 2 passwords are not the same");
            }
        }
    }
}
