using System.Windows.Forms;
using HistoryMap.AdminPanel;
using HistoryMap.Shared_Classes;

namespace HistoryMap.WorldMapUsers
{
    public partial class SettingsForm : Form
    {
        public HistoryMapWebClient Client;
        Form worldMapUsers;
        public SettingsForm(Form worldMapUsers)
        {
            this.worldMapUsers = worldMapUsers;
            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, System.EventArgs e)
        {
            Hide();
            worldMapUsers.Hide();
            new WorldMapCreate.CreateForm().Show();
        }

        private void AdminBtn_Click(object sender, System.EventArgs e)
        {
            var login = new LoginModal(this);
            var result = login.ShowDialog();
            if (result == DialogResult.OK)
            {
                Hide();
                worldMapUsers.Hide();
                new AdminPanel.AdminPanel(Client).Show();
            }    
        }


    }
}
