using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.form = panel;
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (usernameTxt.Text != null && passwordTxt.Text != null)
            {
                var success = LocalMongoGetter.checkLogin(usernameTxt.Text, passwordTxt.Text);
                if (success)
                {
                    form.username = usernameTxt.Text;
                    form.password = passwordTxt.Text;
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
