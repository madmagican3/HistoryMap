using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HistoryMap.Shared_Classes;

namespace HistoryMap.AdminPanel
{
    public partial class ManageUsersForm : Form
    {
        /// <summary>
        /// This is a local instance of the client and is authenticated
        /// </summary>
        private HistoryMapWebClient _client;
        /// <summary>
        /// This is a local copy of all the users on the system
        /// </summary>
        private List<UserClass> _userList;
        public ManageUsersForm(HistoryMapWebClient client)
        {
            _client = client;
            InitializeComponent();
        }
        /// <summary>
        /// Upon a list index being changed we want to prep for delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UsersList.SelectedIndex != -1)
            {
                DeleteBtn.Enabled = true;
            }
        }
        /// <summary>
        /// this will populate the list with all the users on the system but admin and defaultUser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            SetupList();
        }
        /// <summary>
        /// This setsup the list with new vars
        /// </summary>
        private void SetupList()
        {
            _userList = _client.GetUsers().GetAwaiter().GetResult();
            UsersList.Items.Clear();
            foreach (var user in _userList)
            {
                if (!user.user.Equals("admin") ||!user.user.Equals("defaultUser"))
                    UsersList.Items.Add(user.user);
            }
        }
        /// <summary>
        /// This will delete the specified user from the db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (UsersList.SelectedIndex == -1)
            {
                MessageBox.Show(@"Please select an index to delete");
                return;
            }
            _client.Delete<UserClass>(_userList[UsersList.SelectedIndex]._id).GetAwaiter();
            UsersList.SelectedIndex = -1;
            DeleteBtn.Enabled = false;
            SetupList();
        }
        /// <summary>
        /// This should save a new user based on the populated fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveNewUserBtn_Click(object sender, EventArgs e)
        {
            if (UserTxt.Text == "" || PassTxt.Text == "")
            {
                MessageBox.Show(@"Both the fields need to be filled in");
            }
            var tempUser = new UserClass(UserTxt.Text, PassTxt.Text);
            UserTxt.Text = "";
            PassTxt.Text = "";
            _client.CreateRecord(tempUser).GetAwaiter();
            SetupList();
        }
    }
}
