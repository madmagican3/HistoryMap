using System;
using System.Windows.Forms;

namespace HistoryMap.AdminPanel
{
    public partial class ManageUsersForm : Form
    {
        public ManageUsersForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Upon a list index being changed we want to prep for delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
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
            //TODO get all users here
        }
        /// <summary>
        /// This will delete the specified user from the db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            //TODO delete specified user here
            listBox1.SelectedIndex = -1;
            DeleteBtn.Enabled = false;
        }
        /// <summary>
        /// This should save a new user based on the populated fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveNewUserBtn_Click(object sender, EventArgs e)
        {
            //TODO add new user here
        }
    }
}
