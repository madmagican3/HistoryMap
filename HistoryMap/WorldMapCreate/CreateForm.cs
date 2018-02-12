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
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
           InitializeComponent();
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            CreateForm_ResizeEnd(this, new EventArgs());
        }

        /// <summary>
        /// This will create an instance of the view form in the create form
        /// </summary>
        private void createForminstance()
        {
            Form viewForm = new WorldMapUsers.WorldMapUser();
            viewForm.TopLevel = false;
            viewForm.AutoScroll = true;
            viewForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WorldMapPanel.Controls.Clear();
            this.WorldMapPanel.Controls.Add(viewForm);
            viewForm.Show();
        }
        /// <summary>
        /// This shuts down the form properley taking out any hidden forms to properley dispose of the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
        /// <summary>
        /// This will occur on someone resizing the form so as to display the form correctly
        /// at multiple different resolutions at different times. It will move around the control 
        /// elements to suit that
        /// </summary>
        private void CreateForm_ResizeEnd(object sender, EventArgs e)
        {
            WorldMapPanel.Width = this.Width - 180;
            WorldMapPanel.Height = this.Height;
            createForminstance();
        }

    }
}
