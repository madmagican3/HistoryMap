using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HistoryMap.WorldMapCreate
{
    public partial class AgreementForm : Form
    {
        public AgreementForm()
        {
            InitializeComponent();
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            new WorldMapUsers.WorldMapUser().Show();
            Hide();
        }

        private void RefuseBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
