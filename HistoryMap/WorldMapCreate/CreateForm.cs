using HistoryMap.Shared_Classes;
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
        /// <summary>
        /// This is the instance of the form displayed on the creation class
        /// </summary>
        WorldMapUsers.WorldMapUser viewForm = new WorldMapUsers.WorldMapUser();
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
            CreateFormInstance(true);
        }

        /// <summary>
        /// This will create an instance of the view form in the create form
        /// </summary>
        private void CreateFormInstance(bool showButtons)
        {
            WorldMapPanel.Width = this.Width - 180;
            WorldMapPanel.Height = this.Height;
            ControlsPanel.Height = this.Height;
            ControlsPanel.Left = this.Width - 180;
            viewForm.Height = WorldMapPanel.Height;
            viewForm.Width = WorldMapPanel.Width;
            viewForm.TopLevel = false;
            viewForm.renderButtons = showButtons; //make the form conform to our style requirements
            if (InterestingInfoBtn.Checked) 
            {
                viewForm.WorldMap.Click += clickDelegate;
            }
            else if (BorderDrawingBtn.Checked)
            {

            }else
            {
                viewForm.WorldMap.Click += null;
            }
            viewForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WorldMapPanel.Controls.Clear();
            this.WorldMapPanel.Controls.Add(viewForm);
            viewForm._localDrawClass.WorldMap_SizeChanged(this, new EventArgs());
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
            if (!BorderDrawingBtn.Checked && !InterestingInfoBtn.Checked)
                CreateFormInstance(true);
            else
                CreateFormInstance(false);
        }

        /// <summary>
        /// This sets the form up to be able to create interesting information buttons
        /// </summary>
        private void InterestingInfoBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (InterestingInfoBtn.Checked)
            {
                BorderDrawingBtn.Checked = false;
                CreateFormInstance(false);
            }
            else if (!BorderDrawingBtn.Checked)
            {
                CreateFormInstance(true);
            }
        }

        /// <summary>
        /// This sets the form up for drawing borders
        /// </summary>
        private void BorderDrawingBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (BorderDrawingBtn.Checked)
            {
                InterestingInfoBtn.Checked = false;
                CreateFormInstance(false);
            }
            else if (!InterestingInfoBtn.Checked)
            {
                CreateFormInstance(true);
            }
        }

        /// <summary>
        /// This on click event should be passed to the world form in order to get the vals we need to work with
        /// </summary>
        public void clickDelegate(object sender, EventArgs e)
        {
            MouseEventArgs click = (MouseEventArgs)e; //Static cast the event args to get them to be the only type they ever will be
            var actualClickPoint = viewForm._localDrawClass.CalculateUiToMap(click.X, click.Y);

            var newGenericLabelForWorldMap = new GenericLabelForWorldMap();
        }
    }
}
