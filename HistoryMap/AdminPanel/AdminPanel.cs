using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HistoryMap.Shared_Classes;
using HistoryMap.WorldMapUsers;

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
        private List<BorderStorageClass> _unverifiedBordersList;
        /// <summary>
        /// This stores all the unverified buttons
        /// </summary>
        private List<GenericLabelForWorldMap> _unverifiedButtonsList;
        /// <summary>
        /// This is used for populating the button on form whehn we only want to display said button for verification purposes
        /// </summary>
        public static GenericLabelForWorldMap ButtonName;
        /// <summary>
        /// This is used for populating the border when we only want to display said border for verification purposes
        /// </summary>
        public static BorderStorageClass BorderStorage;

        private HistoryMapWebClient _client;

        public AdminPanel(HistoryMapWebClient _client)
        {
            this._client = _client;
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            if (_client.username == "admin")
            {
                ManageUsersBtn.Visible = true;
                DeleteBtn.Visible = true;
                RejectBtn.Visible = false;
                AcceptBtn.Visible = false;
            }
                
            CreateFormInstance(false, true);
        }

        /// <summary>
        /// This will create an instance of the view form in the create form
        /// </summary>
        private void CreateFormInstance(bool showButtons, bool refreshList)
        {
            ChangePassBtn.Top = Height - 120;
            ManageUsersBtn.Top = Height - 160;
            DeleteBtn.Top = Height - 200;
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
            if (_client.username == "admin")
            {
                _unverifiedBordersList =
                    LocalMongoGetter.GetCountries(true, _client);
                _unverifiedButtonsList = LocalMongoGetter.GetListFromDateSelection(true, _client);
            }
            else
            {
                _unverifiedBordersList = LocalMongoGetter.GetCountries(false, _client);
                _unverifiedButtonsList = LocalMongoGetter.GetListFromDateSelection(false, _client);
            }
            ItemsList.Items.Clear();
            foreach (var border in _unverifiedBordersList)
            {
                ItemsList.Items.Add(border.TimeOf.ToString() + " - Border");
            }

            foreach (var button in _unverifiedButtonsList)
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
            if (ItemsList.SelectedIndex < _unverifiedBordersList.Count)//If the item is in the borders list
            {
                BorderStorage = _unverifiedBordersList[ItemsList.SelectedIndex];
                viewForm.LocalDrawClass.CurrentDate = BorderStorage.TimeOf;
                var localDate = viewForm.LocalDrawClass.CurrentDate;
                viewForm.CurrentDate.Text = localDate.ToString() + @" " + localDate.Era;
                ButtonName = null;
                CreateFormInstance(false, false);
            }
            else//if the items in the other list
            {
                int fieldToGet = ItemsList.SelectedIndex - _unverifiedBordersList.Count;
                ButtonName = _unverifiedButtonsList[fieldToGet];
                viewForm.LocalDrawClass.CurrentDate = ButtonName.timeOf;
                var localDate = viewForm.LocalDrawClass.CurrentDate;
                viewForm.CurrentDate.Text = localDate.ToString() +@" " +  localDate.Era;
                BorderStorage = null;
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

            if (ItemsList.SelectedIndex < _unverifiedBordersList.Count)
            {
                var border = _unverifiedBordersList[ItemsList.SelectedIndex];
                border.Verified = true;
                _client.UpdateRecord(border).GetAwaiter();
            }
            else
            {
                var button = _unverifiedButtonsList[ItemsList.SelectedIndex - _unverifiedBordersList.Count];
                button.verified = true;
                _client.UpdateRecord(button).GetAwaiter();
            }
            CreateFormInstance(true, true);
        }

        private void RejectBtn_Click(object sender, EventArgs e)
        {
            if (ItemsList.SelectedIndex == -1)
            {
                MessageBox.Show(@"Please select a item to reject first");
                return;
            }
            if (ItemsList.SelectedIndex < _unverifiedBordersList.Count)
            {
                var border = _unverifiedBordersList[ItemsList.SelectedIndex];
                border.Verified = true;
                _client.Delete<BorderStorageClass>(border._id).GetAwaiter();
            }
            else
            {
                var button = _unverifiedButtonsList[ItemsList.SelectedIndex - _unverifiedBordersList.Count];
                button.verified = true;
                _client.Delete<GenericLabelForWorldMap>(button._id).GetAwaiter();
            }
            CreateFormInstance(true, true);
        }

        private void ChangePassBtn_Click(object sender, EventArgs e)
        {
            new ChangePassForm().Show();
        }

        private void ManageUsersBtn_Click(object sender, EventArgs e)
        {
            new ManageUsersForm(_client).Show();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (ItemsList.SelectedIndex == -1)
            {
                MessageBox.Show(@"Please select a item to delete first");
                return;
            }
            if (ItemsList.SelectedIndex < _unverifiedBordersList.Count)
            {
                var border = _unverifiedBordersList[ItemsList.SelectedIndex];
                border.Verified = true;
                _client.Delete<BorderStorageClass>(border._id).GetAwaiter();
            }
            else
            {
                var button = _unverifiedButtonsList[ItemsList.SelectedIndex - _unverifiedBordersList.Count];
                button.verified = true;
                _client.Delete<GenericLabelForWorldMap>(button._id).GetAwaiter();
            }
            CreateFormInstance(true, true);
        }

        private void AdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
