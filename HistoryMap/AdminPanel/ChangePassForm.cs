using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HistoryMap.Shared_Classes;

namespace HistoryMap.AdminPanel
{
    public partial class ChangePassForm : Form
    {
        private HistoryMapWebClient _client;
        public ChangePassForm(HistoryMapWebClient client)
        {
            this._client = client;
            InitializeComponent();
        }

        private void SavePassBtn_Click(object sender, EventArgs e)
        {
            if (PassTxt.Text.Equals(DupePassTxt.Text))
            {
                List<UserClass> _userList = _client.getUsers().GetAwaiter().GetResult();
                UserClass user = new UserClass();
                foreach (var users in _userList)
                {
                    if (users.user == _client.username)
                    {
                        user = users;
                    }
                }

                if (user.user!= null)
                {
                    user.pass = PassTxt.Text;
                    _client.UpdateRecord(user).GetAwaiter();
                    this.Close();
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
