﻿using System;
using System.Drawing;
using System.Windows.Forms;
using HistoryMap.Properties;
using HistoryMap.WorldMapUsers;
using NodaTime;
using NodaTime.Calendars;

namespace HistoryMap.Shared_Classes
{
    public class DrawClass
    {
        /// <summary>
        /// This is used to control if left mouse click should move the screen
        /// </summary>
        public bool MoveForm = true;
        /// <summary>
        /// This is a local version of the history map to minimise the amount of times i have to write the long reference
        /// </summary>
        private Image _localMap = Resources.maps_world_map_02;
        /// <summary>
        /// This should hold the date the user is looking at currently
        /// </summary>
        public LocalDate CurrentDate = new LocalDate(Era.Common, 302, 6, 1);

        /// <summary>
        /// This is the rectangle we render into
        /// </summary>
        public Rectangle RenderRectangle { get; private set; }

        /// <summary>
        /// This tracks the current zoom level
        /// </summary>
        public static double Zoom = 1;
        /// <summary>
        /// these track the level of max and min zoom along with the zoom increment
        /// </summary>
        private const double MinZoom = 1, MaxZoom = 50, ZoomIncrement = 1.5;

        /// <summary>
        /// this is a local bitmap to avoid recreating the variable multiple times
        /// </summary>
        private readonly Bitmap _bitmap;
        /// <summary>
        /// This is a pointer to the actual form so as to manipulate it
        /// </summary>
        private WorldMapUser _formMapUser;

        /// <summary>
        /// This is a pointer to the button creation class so as to allow us to draw the buttons whenever we render/re-render the map
        /// it's public as listHandlerClass needs access
        /// </summary>
        public ButtonCreationClass LocalButtonCreationClass = new ButtonCreationClass();

        /// <summary>
        /// Draws the map at the current zoom level to the main UI
        /// </summary>
        /// <param name="user"></param>
        public DrawClass(WorldMapUser user)
        {
            //set up the rectangle based on the image size (incase we want to modify the image later)
            RenderRectangle = new Rectangle(0, 0, _localMap.Width, _localMap.Height);
            //We then draw the polygons on the map so as to allow them to zoom correctly
            _localMap = PolygonCreator.DrawBorders(Resources.maps_world_map_02, CurrentDate, Zoom);
            //Then we create a local bitmap of the image so as to have something to draw on
            _bitmap = new Bitmap(_localMap);
            _formMapUser = user;
            //finaly we draw the map
            RenderMap();
        }

        /// <summary>
        /// calculates the zoom level for the map and the pixel size and location for zooming
        /// </summary>
        public void WorldMap_SizeChanged(object sender, EventArgs e)
        {
            var ratioX = _formMapUser.Width / (double)_localMap.Width;
            var ratioY = _formMapUser.Height / (double)_localMap.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var width = (int)(_localMap.Width * ratio);
            var height = (int)(_localMap.Height * ratio);
            if (Math.Abs(_formMapUser.Width - width) >= 5 || Math.Abs(_formMapUser.Height - height) >= 5)
                _formMapUser.WorldMap.Size = new Size(width, height);
            RenderMap();
            _formMapUser.WorldMapUser_ResizeEnd(this,e );
        }

        /// <summary>
        /// calculate where the mouse was actually clicked on the larger version of the image
        /// </summary>
        /// <param name="x">x for the mouse click</param>
        /// <param name="y">y for the mouse click</param>
        /// <returns></returns>
        public Point CalculateUiToMap(int x, int y)
        {
            var ratioX = GetUiToMapRatio().Item2;
            var ratioY = GetUiToMapRatio().Item1;

            //Calculate the actual width across the cropped image you are pressing
            var widthD = (x * ratioX);
            var heightD = (y * ratioY);
            //Add on the top left coordinate of the cropped location, stored in renderRectangle
            var xClicked = (int)(widthD) + RenderRectangle.X;
            var yClicked = (int)(heightD) + RenderRectangle.Y;
            return new Point(xClicked, yClicked);
        }
        /// <summary>
        /// Ratio between the rectangle size we are rendering, including zoom level
        /// </summary>
        /// <returns></returns>
        public Tuple<double, double> GetUiToMapRatio()
        {
            //Ratio between the rectangle size we are rendering, including zoom level
            var ratioX = RenderRectangle.Width / (double)_formMapUser.WorldMap.Width;
            var ratioY = RenderRectangle.Height / (double)_formMapUser.WorldMap.Height;
            return new Tuple<double, double>(ratioX, ratioY);
        }
        /// <summary>
        /// Calculates the maps actual locations of a specified point in relation to the UI and returns a point with the updated values based on 
        /// the UI
        /// </summary>
        public Point CalculateMapToUi(int x, int y)
        {
            // remove the top left coordinate of the cropped location stored in renderrectangle
            x -= RenderRectangle.X;
            y -= RenderRectangle.Y;
            //work out the ratio between the rectangle size we are rendering including zoom level
            var ratioX = RenderRectangle.Width / (double)_formMapUser.WorldMap.Width;
            var ratioY = RenderRectangle.Height / (double)_formMapUser.WorldMap.Height;
            
            //calculate the actual width across the UI
            var newX = (x / ratioX);
            var newY = (y / ratioY);
            //return the point
            return new Point((int)newX, (int)newY);
        }

        public Rectangle CalculateRenderArea(Point clicked)
        {
            //Create the point we clicked, as well as the width/height of the zoomed in area.
            var point = new Point(clicked.X, clicked.Y);
            var width = _localMap.Width / Zoom;
            var height = _localMap.Height / Zoom;

            var widthD = (int)(width / 2);
            var heightD = (int)(height / 2);

            //The Mouse point should be zoomed in to - so we want to center it [0,0 is min coords]
            point.X = Math.Max(0, point.X - widthD);
            point.Y = Math.Max(0, point.Y - heightD);

            //If we went above the maximmaximum X,Y to be able to render wholly on the screen, offset the render
            if (point.X > _localMap.Width - width)
                point.X = (int)(_localMap.Width - width);

            if (point.Y > _localMap.Height - height)
                point.Y = (int)(_localMap.Height - height);
            //Setup the rectangle to render
            return new Rectangle(point.X, point.Y, (int)width, (int)height);
        }

        /// <summary>
        /// This event hooks into the mouse scroll event to attempt to zoom in on the image 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WorldMap_MouseWheel(object sender, MouseEventArgs e)
        {
            //First increment/decriment the zoom level depending on direction of scroll
            Zoom = e.Delta > 0 ? Math.Min(Zoom * ZoomIncrement, MaxZoom) : Math.Max(Zoom / ZoomIncrement, MinZoom);
            //Due to zoom + imagebox size not being 1:1 pixel representation, calculate the actual mouse X,Y on raw image dimensions
            var actualClickPoint = CalculateUiToMap(e.X, e.Y);

            //Now we have the actual click location on the image, calculate the area to render
            RenderRectangle = CalculateRenderArea(actualClickPoint);
            RenderMap();
        }
        /// <summary>
        /// This event is used to center on a button when the list is pressed
        /// </summary>
        public void CenterOnButton(Point locationOfButton)
        {
            //Due to zoom + imagebox size not being 1:1 pixel representation, calculate the actual mouse X,Y on raw image dimensions
            Zoom = MaxZoom / 2;

            //Now we have the actual click location on the image, calculate the area to render
            RenderRectangle = CalculateRenderArea(locationOfButton);
            RenderMap();
        }
        /// <summary>
        /// This handles the zoom in from the button, zooming in on the center of the screen
        /// </summary>
        public void WorldMap_zoomIn(object sender, EventArgs e)
        {
            //first increment the _zoom level
            Zoom = Math.Min(Zoom * ZoomIncrement, MaxZoom);
            //calculate the actual center area
            var actualClickPoint = CalculateUiToMap(_formMapUser.WorldMap.Width / 2, _formMapUser.WorldMap.Height / 2);
            //then calculate the area of the map to render and render it
            RenderRectangle = CalculateRenderArea(actualClickPoint);
            RenderMap();
        }
        /// <summary>
        /// This handles the zoom in from the button, zooming out from the center of the screen
        /// </summary>
        public void WorldMap_ZoomOut(object sender, EventArgs e)
        {
            //first increment the zoom level
            Zoom = Math.Max(Zoom / ZoomIncrement, MinZoom);
            //then calculte the actual center area
            var actualClickPoint = CalculateUiToMap(_formMapUser.WorldMap.Width / 2, _formMapUser.WorldMap.Height / 2);
            //then calculate the area of the map to render and render it
            RenderRectangle = CalculateRenderArea(actualClickPoint);
            RenderMap();
        }
        /// <summary>
        /// This checks to see if the left mouse is released, if it is it stops the thread handling the dragging by disabling the boolean
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WorldMap_Up(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || !MoveForm) return;
            //Due to zoom + imagebox size not being 1:1 pixel representation, calculate the actual mouse X,Y on raw image dimensions
            var actualClickPoint = CalculateUiToMap(e.X, e.Y);
            //Now we have the actual click location on the image, calculate the area to render
            RenderRectangle = CalculateRenderArea(actualClickPoint);
            RenderMap();
        }
        public void RenderMap()
        {
            //We create a temporary rectangle for the size of the persons screen so as to create it to fit correctly
            var cropRect = new Rectangle(0, 0, _formMapUser.WorldMap.Width, _formMapUser.WorldMap.Height);
            //redraw the map with the new borders on it
            _localMap = PolygonCreator.DrawBorders(Resources.maps_world_map_02, CurrentDate, Zoom);

            using (var g = Graphics.FromImage(_bitmap))
            {
                //formMapUser draws it to the local bitmap based on the size of the screen taking it from the renderrectangle
                g.DrawImage(_localMap, cropRect, RenderRectangle, GraphicsUnit.Pixel);
                _formMapUser.WorldMap.Image = _bitmap;
            }
            var timeTuple = GetTimes(_formMapUser);
            LocalButtonCreationClass.CreateButtons(_formMapUser, this,timeTuple.Item1,timeTuple.Item2);
            _formMapUser.WorldMap.Refresh();
        }
        /// <summary>
        /// This should get the start and end date for the sql statement by adding a value of the combobox to a second date and then returning
        /// the original selected date and the combo box date
        /// </summary>
        /// <param name="formMapUser"></param>
        /// <returns></returns>
        private Tuple<LocalDate, LocalDate> GetTimes(WorldMapUser formMapUser)
        {
            var endDate = CurrentDate;
            switch (formMapUser.TimeSkipInterval.SelectedIndex)
            {
                case 0:
                    endDate = endDate.PlusDays(1);
                    break;
                case 1:
                    endDate = endDate.PlusDays(7);
                    break;
                case 2:
                    endDate = endDate.PlusMonths(1);
                    break;
                case 3:
                    endDate = endDate.PlusYears(1);
                    break;
                case 4:
                    endDate = endDate.PlusYears(10);
                    break;
                case 5:
                    endDate = endDate.PlusYears(100);
                    break;
            }
            return new Tuple<LocalDate, LocalDate>(CurrentDate, endDate);
        }
        /// <summary>
        /// This handles the displaying of the date modal and then sets the date to the date to currentDate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DateHandler(object sender, EventArgs e)
        {
            using (var form = new DateSelectionModal(CurrentDate))
            {
                var dialogResult = form.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    CurrentDate = form.ReturnTime;
                    _formMapUser.CurrentDate.Text = CurrentDate.ToString() + @" " + CurrentDate.Era;
                    RenderMap();
                }
            }
        }
        /// <summary>
        /// This should increment current date by the amount selected in the combobox and display it to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnLeftArrowClick(object sender, EventArgs e)
        {
            switch (_formMapUser.TimeSkipInterval.SelectedIndex)
            {
                case 0:
                    CurrentDate = CurrentDate.PlusDays(-1);
                    break;
                case 1:
                    CurrentDate = CurrentDate.PlusDays(-7);
                    break;
                case 2:
                    CurrentDate = CurrentDate.PlusMonths(-1);
                    break;
                case 3:
                    CurrentDate = CurrentDate.PlusYears(-1);
                    break;
                case 4:
                    CurrentDate = CurrentDate.PlusYears(-10);
                    break;
                case 5:
                    CurrentDate = CurrentDate.PlusYears(-100);
                    break;
            }
            _formMapUser.CurrentDate.Text = CurrentDate.ToString() + @" " + CurrentDate.Era;
            RenderMap();
        }
        /// <summary>
        /// this should handle the incrementation of time by the amount selected in the combobox and displays it to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void OnRightArrowClick(object sender, EventArgs e)
        {
            LocalDate verifyDate = CurrentDate;
            switch (_formMapUser.TimeSkipInterval.SelectedIndex)
            {
                case 0:
                    verifyDate = verifyDate.PlusDays(1);
                    break;
                case 1:
                    verifyDate = verifyDate.PlusDays(7);
                    break;
                case 2:
                    verifyDate = verifyDate.PlusMonths(1);
                    break;
                case 3:
                    verifyDate = verifyDate.PlusYears(1);
                    break;
                case 4:
                    verifyDate = verifyDate.PlusYears(10);
                    break;
                case 5:
                    verifyDate = verifyDate.PlusYears(100);
                    break;
            }
            if (verifyDate.Year < DateTime.Today.Year - 20)
            {
                CurrentDate = verifyDate;
                _formMapUser.CurrentDate.Text = CurrentDate.ToString() + @" " + CurrentDate.Era;
                RenderMap();
            }
            else
            {
                MessageBox.Show(
                    @"Sorry but we only deal with history, not current events, please try a date 20 years less than our current year");
            }
        }
    }
}