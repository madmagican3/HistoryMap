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
using NodaTime;

namespace HistoryMap.AdminPanel
{
    public partial class AdminPanel : Form
    {
        /// <summary>
        /// This is the instance of the form displayed on the creation class
        /// </summary>
        WorldMapUser viewForm = new WorldMapUser();
        /// <summary>
        /// This stores all unverified borders
        /// </summary>
        private List<BorderStorageClass> unverifiedBordersList;
        /// <summary>
        /// This stores all the unverified buttons
        /// </summary>
        private List<GenericLabelForWorldMap> unverifiedButtonsList;
        /// <summary>
        /// This is used for populating the button on form whehn we only want to display said button for verification purposes
        /// </summary>
        public static GenericLabelForWorldMap buttonName;


        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            //TODO add login modal here
            CreateFormInstance(false, true);
        }

        /// <summary>
        /// This will create an instance of the view form in the create form
        /// </summary>
        private void CreateFormInstance(bool showButtons, bool refreshList)
        {
        
            WorldMapPanel.Width = Width - 360;
            WorldMapPanel.Height = Height;
            WorldMapPanel.Left = 360;
            ItemsList.Width = 360;
            ItemsList.Height = Height - 180;
            RejectBtn.Top= Height - 90;
            AcceptBtn.Top = Height - 90;
            viewForm.Height = WorldMapPanel.Height;
            viewForm.Width = WorldMapPanel.Width;
            viewForm.TopLevel = false;
            viewForm.RenderButtons = false;
            viewForm.RenderButtons = showButtons; //make the form conform to our style requirements
            viewForm.FormBorderStyle = FormBorderStyle.None;
            WorldMapPanel.Controls.Clear();
            if (refreshList)
                PopulateList();
            WorldMapPanel.Controls.Add(viewForm);
            viewForm.LocalDrawClass.WorldMap_SizeChanged(this, new EventArgs());
            viewForm.Show();
        }
        /// <summary>
        /// This populates every item in the list
        /// </summary>
        private void PopulateList()
        {
            unverifiedBordersList = LocalMongoGetter.GetCountries( );
            unverifiedButtonsList = LocalMongoGetter.GetListFromDateSelection();
            ItemsList.Items.Clear();
            foreach (var border in unverifiedBordersList)
            {
                ItemsList.Items.Add(border.DateString + " - Border");
            }

            foreach (var button in unverifiedButtonsList)
            {
                ItemsList.Items.Add(button.name + " - Information");
            }
        }

        private void AdminPanel_ResizeEnd(object sender, EventArgs e)
        {
            CreateFormInstance(false, true);
        }
        /// <summary>
        /// This should populate the localform with the one item we need to actually display
        /// </summary>
        private void ItemsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemsList.SelectedIndex == -1) return;
            if (ItemsList.SelectedIndex < unverifiedBordersList.Count)//If the item is in the borders list
            {
                buttonName = null;
            }
            else//if the items in the other list
            {
                int fieldToGet = ItemsList.SelectedIndex - unverifiedBordersList.Count;
                buttonName = unverifiedButtonsList[fieldToGet];
                viewForm.LocalDrawClass.CurrentDate = buttonName.timeOf;
                var localDate = viewForm.LocalDrawClass.CurrentDate;
                viewForm.CurrentDate.Text = localDate.ToString() +@" " +  localDate.Era;
                CreateFormInstance(false, false);
            }
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            if (ItemsList.SelectedIndex == -1)
            {
                MessageBox.Show(@"Please select an item to accept first");
                return;
            }

        }

        private void RejectBtn_Click(object sender, EventArgs e)
        {
            if (ItemsList.SelectedIndex == -1)
            {
                MessageBox.Show(@"Please select a item to reject first");
                return;
            }

        }
    }
}
