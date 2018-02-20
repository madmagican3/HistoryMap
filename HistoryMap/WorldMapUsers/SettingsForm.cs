using System.Windows.Forms;

namespace HistoryMap.WorldMapUsers
{
    public partial class SettingsForm : Form
    {
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
            Hide();
            worldMapUsers.Hide();
            new AdminPanel.AdminPanel().Show();
        }
    }
}
