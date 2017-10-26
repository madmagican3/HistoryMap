using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HistoryMap.WorldMapUsers;

namespace HistoryMap.Shared_Classes
{
    class ButtonCreationClass
    {
        /// <summary>
        /// This is the end date time for the _buttonsForTimePeriodList
        /// </summary>
        private DateTime endDateTime;
        /// <summary>
        /// This is the start date time for the _buttonsForTimePeriodList
        /// </summary>
        private DateTime startDateTime;
        /// <summary>
        /// This is a list for all the dates in the time period stored in the global date 
        /// </summary>
        private List<ButtonStorage> _buttonsForTimePeriodList = new List<ButtonStorage>();
        /// <summary>
        /// This contains a list of all the buttons currently displayed 
        /// </summary>
        List<Label> _buttonControlList = new List<Label>();


   

        /// <summary>
        /// this creates and displays all the buttons that should be shown on the ui at this point in time
        /// </summary>
        public void CreateButtons(WorldMapUser localForm, DrawClass localClass, DateTime startDate, DateTime endDate)
        {
            if (startDate != startDateTime || endDate != endDateTime)
            {
                GetButtons(startDate,endDate);   
            }
            //get rid of all the old buttons
            foreach (var tempButton in _buttonControlList)
            {
                tempButton.Dispose();
            }
            //empty the list
            _buttonControlList.Clear();
            //Check if we should continue to attempt to draw the buttons on
            if (DrawClass._zoom < 1.5 || DrawClass._zoom > 25)
            {
                foreach (var localButtonStorage in _buttonsForTimePeriodList)
                {
                    Point location = ButtonLocation(localForm, localClass, localButtonStorage);
                    //If the point returned is invalid we no longer want to add the label to the list
                    if (location.X == -1 && location.Y == -1 ) {}
                    //If they should be drawn at this view level
                    else if ((localButtonStorage.viewLevel < 1.5 && (DrawClass._zoom < 1.5)) ||
                        (localButtonStorage.viewLevel > 25) && (DrawClass._zoom > 25))
                    {
                        Label tempButton = new Label();
                        tempButton.Height = 32;
                        tempButton.Width = 32;
                        tempButton.Image = HistoryMap.Properties.Resources.if_thefreeforty_location_1243686;
                        tempButton.Location = ButtonLocation(localForm,localClass, localButtonStorage);
                        //set up transparency
                        tempButton.Parent = localForm.WorldMap;
                        _buttonControlList.Add(tempButton);
                    }
                }
                //add it to the control list for later removal
                foreach (var tempButton in _buttonControlList)
                {
                    localForm.Controls.Add(tempButton);
                }
            }           
        }
        /// <summary>
        /// this should calculate its location based on current zoom level, returning -1,-1 means that it's null
        /// </summary>
        private Point ButtonLocation(WorldMapUser localForm, DrawClass localDrawClass, ButtonStorage localStorage)
        {
            Point localPoint = localDrawClass.CalculateActualMouseClick(localStorage.ButtonCenterPoint.X,
                localStorage.ButtonCenterPoint.Y);
            if (localPoint.X < 0 || localPoint.X > localForm.WorldMap.Height|| localPoint.Y < 0 || localPoint.Y > localForm.WorldMap.Width )
            {
                return new Point(-1, -1);
            }
            else
            {
                return localPoint;
            }
        }

        /// <summary>
        /// This should update the _buttonsForTimePeriod list
        /// </summary>
        private void GetButtons(DateTime startDate, DateTime endDate)
        {

        }
    }
}
