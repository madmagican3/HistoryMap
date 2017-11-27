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
        private readonly List<GenericLabelForWorldMap> _buttonsForTimePeriodList = new List<GenericLabelForWorldMap>();
        /// <summary>
        /// This contains a list of all the buttons currently displayed 
        /// </summary>
        List<Label> _buttonControlList = new List<Label>();
        /// <summary>
        /// This is used in order to make sure that the method is only running once, if this is not included
        /// there is a high likelehood of issues with accessing the button array
        /// </summary>
        private bool _inUse = false;




        /// <summary>
        /// this creates and displays all the buttons that should be shown on the ui at this point in time
        /// </summary>
        public void CreateButtons(WorldMapUser localForm, DrawClass localClass, LocalDate startDate, LocalDate endDate)
        {
            //this had issues with being accessed multiple times on original load, added this to stop issues with pointers
            if (_inUse)
            {
                return;
            }
            _inUse = true;
            //if we have a new time
            if (!startDate.Equals(_startDateTime) || !endDate.Equals(_endDateTime))
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
            foreach (var localButtonStorage in _buttonsForTimePeriodList)
            {
                Point? location = ButtonLocation(localClass, localButtonStorage);
                //If the point returned is invalid we no longer want to add the label to the list
                if (!location.HasValue) { }
                else
                {
                    //Create the label and assign it the correct values
                    Label tempButton = new Label
                    {
                        Height = 50,
                        Width = 50,
                        Image = Properties.Resources.icons8_marker_50,
                        Location = location.Value,
                    };
                    //set up transparency
                    tempButton.BackColor = Color.Transparent;
                    tempButton.Parent = localForm.WorldMap;
                    //add it to the list
                    _buttonControlList.Add(tempButton);
                }
            }
            //add it to the control list for later removal
            foreach (var tempButton in _buttonControlList)
            {
                localForm.WorldMap.Controls.Add(tempButton);
            }

            _inUse = false;
        }
        /// <summary>
        /// this should calculate its location based on current zoom level, returning -1,-1 means that it's 
        /// not viewable at the stated view level
        /// </summary>
        private Point? ButtonLocation(DrawClass localDrawClass, GenericLabelForWorldMap local)
        {
            //this is to offset it to get it to the correct location
            var ratios = localDrawClass.GetUiToMapRatio();
            var xOffset = (local.Width / 2) * ratios.Item1;
            var yOffset = local.Height * ratios.Item2;

            var localPoint = local.ButtonCenterPoint;
            var renderRect = localDrawClass.RenderRectangle;
            //Check the point is in the render rectangle
            if (!renderRect.Contains(localPoint))
                return null;
            //The point is in the render rectangle of map - so lets translate back.
            //The Mouse point should be zoomed in to - so we want to center it [0,0 is min coords]
            return localDrawClass.CalculateMapToUi((int)(localPoint.X - xOffset), (int)(localPoint.Y - yOffset));
        }

        /// <summary>
        /// This should update the _buttonsForTimePeriod list
        /// </summary>
        private void GetButtons(LocalDate startDate, LocalDate endDate)
        {
            _buttonsForTimePeriodList.Clear();
            GenericLabelForWorldMap testGenericLabelForWorldMap = new GenericLabelForWorldMap(new Point(552, 565), "City", "This is a test object", 0, 50, 50);
            _buttonsForTimePeriodList.Add(testGenericLabelForWorldMap);
        }
    }
}
