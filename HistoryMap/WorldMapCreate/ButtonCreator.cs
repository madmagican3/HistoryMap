using NodaTime;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HistoryMap.WorldMapCreate
{
    public partial class ButtonCreator : Form
    {
        /// <summary>
        /// This is a local dictionary to handle the sending of the text
        /// </summary>
        public static Dictionary<string, string> ButtonDictionary = new Dictionary<string, string>();
        /// <summary>
        /// This is a copy of the point for easier creation of the genericLabelForWOrldMap
        /// </summary>
        Point localPoint;
        LocalDate date;
        public ButtonCreator(Point pointOfNewButton, LocalDate date)
        {
            localPoint = pointOfNewButton;
            this.date = date;
            InitializeComponent();
        }


        /// <summary>
        /// This populates the textbox so as to demonstrate how it will appear to the user
        /// </summary>
        private void PopulateTextBox()
        {
            DemonstrationRtf.Clear();
            foreach (var text in ButtonDictionary)
            {
                DemonstrationRtf.SelectionFont = new Font(Font.Name, Font.Size, FontStyle.Bold);
                DemonstrationRtf.AppendText(text.Key + " :");
                DemonstrationRtf.SelectionFont = new Font(Font.Name, Font.Size, FontStyle.Regular);
                DemonstrationRtf.AppendText(" " + text.Value + Environment.NewLine + Environment.NewLine);
            }
        }

        /// <summary>
        /// This updates the list 
        /// </summary>
        private void UpdateList()
        {
            ItemsList.Items.Clear();
            foreach(var text in ButtonDictionary)
            {
                ItemsList.Items.Add(text.Key);
            }
        }
        /// <summary>
        /// Sets it up for adding 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (ItemsList.SelectedIndex != -1)
            {
                ModifyText();
            }
            else
            {
                NewText();
            } 
        }
        /// <summary>
        /// Sets up the text fields for modifying entry
        /// </summary>
        public void ModifyText()
        {
            if (!LabelTxt.Text.Equals("") && !TextTxt.Text.Equals(""))
            {
                Dictionary<string, string> tempDictionary = ButtonDictionary;
                tempDictionary.Remove(ItemsList.GetItemText(ItemsList.SelectedItem));
                if (tempDictionary.ContainsKey(LabelTxt.Text) || tempDictionary.ContainsValue(TextTxt.Text))
                {
                    MessageBox.Show(@"That key/Text is already in use");
                }
                else
                {
                    ButtonDictionary.Remove(ItemsList.GetItemText(ItemsList.SelectedItem));
                    ButtonDictionary.Add(LabelTxt.Text, TextTxt.Text);
                    PopulateTextBox();
                    UpdateList();
                    ItemsList.SelectedIndex = -1;
                    ItemsList_SelectedIndexChanged(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show(@"Please populate both the name and text field");
            }
        }
        /// <summary>
        /// Adds the item to the textbox and then updates the uI
        /// </summary>
        public void NewText()
        {
            if (!LabelTxt.Text.Equals("") && !TextTxt.Text.Equals(""))
            {
                if (ButtonDictionary.ContainsKey(LabelTxt.Text) || ButtonDictionary.ContainsValue(TextTxt.Text))
                {
                    MessageBox.Show(@"That key/Text is already in use");
                }
                else
                {
                    ButtonDictionary.Add(LabelTxt.Text, TextTxt.Text);
                    PopulateTextBox();
                    UpdateList();
                    ItemsList.SelectedIndex = -1;
                    ItemsList_SelectedIndexChanged(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show(@"Please populate both the name and text field");
            }
        }
        /// <summary>
        /// cleans and updates the ui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemsList.SelectedIndex != -1)
            {
                NewBtn.Enabled = true;
                DeleteBtn.Enabled = true;
                AddBtn.Text = @"Modify";
                var key = ItemsList.GetItemText(ItemsList.SelectedItem);
                TextTxt.Text = ButtonDictionary[key];
                LabelTxt.Text = key;
            }
            else
            {
                NewBtn.Enabled = false;
                DeleteBtn.Enabled = false;
                AddBtn.Text = @"Add";
                LabelTxt.Text = "";
                TextTxt.Text = "";
            }
        }
        /// <summary>
        /// This removes the dictionary index then updates the ui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (ItemsList.SelectedIndex != -1)
            {
                ButtonDictionary.Remove(ItemsList.GetItemText(ItemsList.SelectedItem));
                PopulateTextBox();
                UpdateList();
                ItemsList.SelectedIndex = -1;
                ItemsList_SelectedIndexChanged(this, new EventArgs());
            }
        }
        /// <summary>
        /// Clear the itemlist and update the ui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewBtn_Click(object sender, EventArgs e)
        {
            ItemsList.SelectedIndex = -1;
            ItemsList_SelectedIndexChanged(this, new EventArgs());
        }
        /// <summary>
        /// On the complete button double check the fields, create a genericlabel and send the ok dialog result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            if (NameField.Text.Equals("") || TypeOfInformation.Text.Equals("") || ButtonDictionary == null)
            {
                MessageBox.Show(@"Please populate all fields");
                return;
            }
            CreateForm.NewGenericLabelForWorldMap = new Shared_Classes.GenericLabelForWorldMap(date,  localPoint, TypeOfInformation.Text, ButtonDictionary, 50, 50,NameField.Text);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
