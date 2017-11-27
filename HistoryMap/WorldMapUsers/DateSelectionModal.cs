using System;
using System.Windows.Forms;
using NodaTime;
using NodaTime.Calendars;

namespace HistoryMap.WorldMapUsers
{
    public partial class DateSelectionModal : Form
    {
        /// <summary>
        ///     This is the item that should be grabbed before the modal closes, it will
        ///     return a valid localDate
        /// </summary>
        public LocalDate ReturnTime;

        public DateSelectionModal(LocalDate startDate)
        {
            InitializeComponent();
            Year.Text = startDate.Year.ToString();
            if (startDate.Era == Era.Common)
            {
                TimeFrame.SelectedIndex = 0;
            }
            else
            {
                TimeFrame.SelectedIndex = 1;
            }
            DateTime tempDate = startDate.ToDateTimeUnspecified();
            dateTimePicker1.Value = new DateTime(1753, tempDate.Month,tempDate.Day);
        }

        /// <summary>
        ///     Set the selected index to 0
        /// </summary>
        private void DateSelectionModal_Load(object sender, EventArgs e)
        {
            TimeFrame.SelectedIndex = 0;
        }

        /// <summary>
        ///     Verify if the date the user has entered is correct, then if it is
        ///     parse it and close it
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (VerifyDate())
            {
                var era = TimeFrame.SelectedIndex == 0 ? Era.Common : Era.BeforeCommon;
                ReturnTime = new LocalDate(era, int.Parse(Year.Text), dateTimePicker1.Value.Month,
                    dateTimePicker1.Value.Day);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        ///     This should verify if the dates are correct according to the gregorian calendar
        /// </summary>
        /// <returns></returns>
        private bool VerifyDate()
        {
            if (!int.TryParse(Year.Text, out var years))
            {
                MessageBox.Show(@"Sorry but your year is not valid");
                return false;
            }
            if (years > DateTime.Today.Year - 20 && TimeFrame.SelectedIndex != 1)
            {
                MessageBox.Show(@"Sorry but we need atleast a 20 year gap before considering an item history");
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Listens for a keypress of enter and attempts to submit the modal
        /// </summary>
        private void EnterPressed(object sender, KeyPressEventArgs e)
        {
            if (IsKeyEnter(e))
                button1_Click(sender, EventArgs.Empty);
        }

        /// <summary>
        ///     This checks if the key pressed is enter
        /// </summary>
        private bool IsKeyEnter(KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                return true;
            return false;
        }
    }
}