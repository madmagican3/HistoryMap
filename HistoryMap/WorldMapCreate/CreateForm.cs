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
        /// <summary>
        /// Set up the form upon load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            ControlsPanel.Height = this.Height;
            ControlsPanel.Left = this.Width - 180;
            if (!InterestingInfoBtn.Checked && !BorderDrawingBtn.Checked)
                createForminstance();
            else
                createFormWithNoButtons();
        }

        /// <summary>
        /// This sets the form up to be able to create interesting information buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InterestingInfoBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (InterestingInfoBtn.Checked)
            {
                BorderDrawingBtn.Checked = false;
                createFormWithNoButtons();
            }
            else if (!BorderDrawingBtn.Checked)
            {
                createForminstance();
            }
        }

        /// <summary>
        /// This sets the form up for drawing borders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderDrawingBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (BorderDrawingBtn.Checked)
            {
                InterestingInfoBtn.Checked = false;
                createFormWithNoButtons();
            }
            else if (!InterestingInfoBtn.Checked)
            {
                createForminstance();
            }
        }

        /// <summary>
        /// This creates a copy of the form with no buttons and makes the interaction panel interactable
        /// </summary>
        private void createFormWithNoButtons()
        {
            WorldMapUsers.WorldMapUser viewForm = new WorldMapUsers.WorldMapUser();
            viewForm.TopLevel = false;
            viewForm.AutoScroll = true;
            viewForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            viewForm.renderButtons = false;
            this.WorldMapPanel.Controls.Clear();
            this.WorldMapPanel.Controls.Add(viewForm);
            viewForm.Show();

        }

    }
}
