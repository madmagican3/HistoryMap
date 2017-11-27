using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using HistoryMap.WorldMapUsers;
using NodaTime;

namespace HistoryMap.Shared_Classes
{
    class ButtonCreationClass
    {
        /// <summary>
        /// This is the end date time for the _buttonsForTimePeriodList
        /// </summary>
        private LocalDate _endDateTime = new LocalDate();
        /// <summary>
        /// This is the start date time for the _buttonsForTimePeriodList
        /// </summary>
        private LocalDate _startDateTime = new LocalDate();
        /// <summary>
        /// This is a list for all the dates in the time period stored in the global date 
        /// </summary>
        private readonly List<ButtonStorage> _buttonsForTimePeriodList = new List<ButtonStorage>();
        /// <summary>
        /// This contains a list of all the buttons currently displayed 
        /// </summary>
        List<Label> _buttonControlList = new List<Label>();
        /// <summary>
        /// This is used in order to make sure that the method is only running once, if this is not included
        /// there is a high likelehood of issues with accessing the button array
        /// </summary>
        private bool inUse = false;




        /// <summary>
        /// this creates and displays all the buttons that should be shown on the ui at this point in time
        /// </summary>
        public void CreateButtons(WorldMapUser localForm, DrawClass localClass, LocalDate startDate, LocalDate endDate)
        {
            if (inUse)
            {
                return;
            }
            inUse = true;
            if (!startDate.Equals(_startDateTime)|| !endDate.Equals(_endDateTime))
            {
                _startDateTime = startDate;
                _endDateTime = endDate;
                GetButtons(startDate, endDate);
            }
            //get rid of all the old buttons
            foreach (var tempButton in _buttonControlList)
            {
                tempButton.Dispose();
            }
            //empty the list
            _buttonControlList.Clear();
            //Check if we should continue to attempt to draw the buttons on
            if (DrawClass.Zoom < 1.5 || DrawClass.Zoom > 25)
            {
                foreach (var localButtonStorage in _buttonsForTimePeriodList)
                {
                    Point location = ButtonLocation(localForm, localClass, localButtonStorage);
                    //If the point returned is invalid we no longer want to add the label to the list
                    if (location.X == -1 && location.Y == -1) { }
                    //If they should be drawn at this view level
                    else if ((localButtonStorage.viewLevel < 1.5 && (DrawClass.Zoom < 1.5)) ||
                        (localButtonStorage.viewLevel > 25) && (DrawClass.Zoom > 25))
                    {
                        //Create the label and assign it the correct values
                        Label tempButton = new Label();
                        tempButton.Height = 32;
                        tempButton.Width = 32;
                        tempButton.Image = HistoryMap.Properties.Resources.if_thefreeforty_location_1243686;
                        tempButton.Location = ButtonLocation(localForm, localClass, localButtonStorage);
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
            inUse = false;
        }
        /// <summary>
        /// this should calculate its location based on current zoom level, returning -1,-1 means that it's 
        /// not viewable at the stated view level
        /// </summary>
        private Point ButtonLocation(WorldMapUser localForm, DrawClass localDrawClass, ButtonStorage localStorage)
        {
            Point localPoint = localDrawClass.CalculateActualMouseClick(localStorage.ButtonCenterPoint.X,
                localStorage.ButtonCenterPoint.Y);
            if (localPoint.X < 0 || localPoint.X > localForm.WorldMap.Height || localPoint.Y < 0 || localPoint.Y > localForm.WorldMap.Width)
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
        private void GetButtons(LocalDate startDate, LocalDate endDate)
        {
            ButtonStorage testButton = new ButtonStorage(new Point(100,100),"City", "This is a test object", 0 );
            _buttonsForTimePeriodList.Add(testButton);
        }
    }
}
