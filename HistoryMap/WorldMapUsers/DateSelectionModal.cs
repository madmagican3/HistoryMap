using System;
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
        public LocalDate returnTime;
        public DateSelectionModal()
        {
            InitializeComponent();
        }

        private void DateSelectionModal_Load(object sender, EventArgs e)
        {
            TimeFrame.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (verifyDate())
            {
                if (TimeFrame.SelectedIndex == 0)
                {
                    returnTime = new LocalDate(Era.Common, dateTimePicker1.Value.Year, 
                        dateTimePicker1.Value.Month,dateTimePicker1.Value.Day);

                }
                else
                {
                    returnTime = new LocalDate(Era.BeforeCommon, dateTimePicker1.Value.Year,
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
            if (years > DateTime.Today.Year - 20)
            {
                MessageBox.Show("Sorry but we need atleast a 20 year gap before considering an item history");
                return false;
            }
            return true;
        }
    }
}
