﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NodaTime;
using NodaTime.Calendars;
using NodaTime.Text;

namespace HistoryMap.WorldMapUsers
{
    public partial class DateSelectionModal : Form
    {
        /// <summary>
        /// This is the item that should be grabbed before the modal closes, it will
        /// return a valid localDate
        /// </summary>
        public LocalDate returnTime;
        public DateSelectionModal()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Set the selected index to 0
        /// </summary>
        private void DateSelectionModal_Load(object sender, EventArgs e)
        {
            TimeFrame.SelectedIndex = 0;
        }
        /// <summary>
        /// Verify if the date the user has entered is correct, then if it is 
        /// parse it and close it
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (verifyDate())
            {
                if (TimeFrame.SelectedIndex == 0)
                {
                    returnTime = new LocalDate(Era.Common, int.Parse(Year.Text), 
                        dateTimePicker1.Value.Month,dateTimePicker1.Value.Day);

                }
                else
                {
                    returnTime = new LocalDate(Era.BeforeCommon, int.Parse(Year.Text),
                        dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// This should verify if the dates are correct according to the gregorian calendar
        /// </summary>
        /// <returns></returns>
        private bool verifyDate()
        {
            int years;
            if (!int.TryParse(Year.Text, out years))
            {
                MessageBox.Show("Sorry but your year is not valid");
                return false;
            }
            if (years > DateTime.Today.Year - 20||TimeFrame.SelectedIndex != 1)
            {
                MessageBox.Show("Sorry but we need atleast a 20 year gap before considering an item history");
                return false;
            }
            return true;
        }
        /// <summary>
        /// I'm not going to write a summary for all of these but they all listen for the 
        /// keypress of enter
        /// </summary>
        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsKeyEnter(e))
            {
                button1_Click(sender, EventArgs.Empty);
            }
        }

        private void Year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsKeyEnter(e))
            {
                button1_Click(sender, EventArgs.Empty);
            }
        }

        private void TimeFrame_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsKeyEnter(e))
            {
                button1_Click(sender, EventArgs.Empty);
            }
        }

        private void DateSelectionModal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsKeyEnter(e))
            {
                button1_Click(sender, EventArgs.Empty);
            }
        }
        /// <summary>
        /// This checks if the key pressed is enter
        /// </summary>
        private bool IsKeyEnter(KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                return true;
            }
            return false;
        }
    }
}
