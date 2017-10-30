using System;
using System.Drawing;
using System.Windows.Forms;
using HistoryMap.Shared_Classes;
using static HistoryMap.Properties.Resources;

namespace HistoryMap.WorldMapUsers
{
    public class DrawClass
    {
        /// <summary>
        /// This is a local version of the history map to minimise the amount of times i have to write the long reference
        /// </summary>
        public Image LocalMap = maps_world_map_02;

        /// <summary>
        /// This is the rectangle we render into
        /// </summary>
        private Rectangle _renderRectangle;
        /// <summary>
        /// This tracks the current zoom level
        /// </summary>
        public static double _zoom = 1;
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
        private WorldMapUser formMapUser;

        /// <summary>
        /// This is a pointer to the button creation class so as to allow us to draw the buttons whenever we render/re-render the map
        /// </summary>
        private ButtonCreationClass localButtonCreationClass = new ButtonCreationClass();

        /// <summary>
        /// Draws the map at the current zoom level to the main UI
        /// </summary>
        /// <param name="user"></param>
        public DrawClass(WorldMapUser user)
        {
            //set up the rectangle based on the image size (incase we want to modify the image later)
            _renderRectangle = new Rectangle(0, 0, LocalMap.Width, LocalMap.Height);
            //We then draw the polygons on the map so as to allow them to zoom correctly
            LocalMap = PolygonCreator.DrawBorders(LocalMap);
            //Then we create a local bitmap of the image so as to have something to draw on
            _bitmap = new Bitmap(LocalMap);
            formMapUser = user;
            //finaly we draw the map
            RenderMap();
        }

        /// <summary>
        /// calculates the zoom level for the map and the pixel size and location for zooming
        /// </summary>
        public void WorldMap_SizeChanged(object sender, EventArgs e)
        {
            var ratioX =  formMapUser.Width / (double)LocalMap.Width;
            var ratioY = formMapUser.Height / (double)LocalMap.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var width = (int)(LocalMap.Width * ratio);
            var height = (int)(LocalMap.Height * ratio);
            if (Math.Abs(formMapUser.Width - width) >= 5 || Math.Abs(formMapUser.Height - height) >= 5)
                formMapUser.WorldMap.Size = new Size(width, height);
            RenderMap();
        }

        /// <summary>
        /// calculate where the mouse was actually clicked on the larger version of the image
        /// </summary>
        /// <param name="x">x for the mouse click</param>
        /// <param name="y">y for the mouse click</param>
        /// <returns></returns>
        public Point CalculateActualMouseClick(int x, int y)
        {
            //Ratio between the rectangle size we are rendering, including zoom level
            var ratioX = _renderRectangle.Width / (double)formMapUser.WorldMap.Width;
            var ratioY = _renderRectangle.Height / (double)formMapUser.WorldMap.Height;

            //Calculate the actual width across the cropped image you are pressing
            var widthD = (x * ratioX);
            var heightD = (y * ratioY);
            //Add on the top left coordinate of the cropped location, stored in renderRectangle
            var xClicked = (int)(widthD) + _renderRectangle.X;
            var yClicked = (int)(heightD) + _renderRectangle.Y;
            return new Point(xClicked, yClicked);
        }

        public void CalculateRenderArea(Point clicked)
        {
            //Create the point we clicked, as well as the width/height of the zoomed in area.
            var point = new Point(clicked.X, clicked.Y);
            var width = LocalMap.Width / _zoom;
            var height = LocalMap.Height / _zoom;

            var widthD = (int)(width / 2);
            var heightD = (int)(height / 2);

            //The Mouse point should be zoomed in to - so we want to center it [0,0 is min coords]
            point.X = Math.Max(0, point.X - widthD);
            point.Y = Math.Max(0, point.Y - heightD);

            //If we went above the maximum X,Y to be able to render wholly on the screen, offset the render
            if (point.X > LocalMap.Width - width)
                point.X = (int)(LocalMap.Width - width);

            if (point.Y > LocalMap.Height - height)
                point.Y = (int)(LocalMap.Height - height);
            //Setup the rectangle to render
            _renderRectangle = new Rectangle(point.X, point.Y, (int)width, (int)height);
        }

        /// <summary>
        /// This event hooks into the mouse scroll event to attempt to zoom in on the image 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WorldMap_MouseWheel(object sender, MouseEventArgs e)
        {
            //First increment/decriment the zoom level depending on direction of scroll
            _zoom = e.Delta > 0 ? Math.Min(_zoom * ZoomIncrement, MaxZoom) : Math.Max(_zoom / ZoomIncrement, MinZoom);
            //Due to zoom + imagebox size not being 1:1 pixel representation, calculate the actual mouse X,Y on raw image dimensions
            var actualClickPoint = CalculateActualMouseClick(e.X, e.Y);

            //Now we have the actual click location on the image, calculate the area to render
            CalculateRenderArea(actualClickPoint);
            RenderMap();
        }
        /// <summary>
        /// This handles the zoom in from the button, zooming in on the center of the screen
        /// </summary>
        public void WorldMap_zoomIn(object sender, EventArgs e)
        {
            //first increment the _zoom level
            _zoom = Math.Min(_zoom * ZoomIncrement, MaxZoom);
            //calculate the actual center area
            var actualClickPoint = CalculateActualMouseClick(formMapUser.WorldMap.Width/2, formMapUser.WorldMap.Height/2);
            //then calculate the area of the map to render and render it
            CalculateRenderArea(actualClickPoint);
            RenderMap();
        }
        /// <summary>
        /// This handles the zoom in from the button, zooming out from the center of the screen
        /// </summary>
        public void WorldMap_ZoomOut(object sender, EventArgs e)
        {
            //first increment the zoom level
            _zoom = Math.Max(_zoom / ZoomIncrement, MinZoom);
            //then calculte the actual center area
            var actualClickPoint = CalculateActualMouseClick(formMapUser.WorldMap.Width / 2, formMapUser.WorldMap.Height / 2);
            //then calculate the area of the map to render and render it
            CalculateRenderArea(actualClickPoint);
            RenderMap();
        }
        /// <summary>
        /// This checks to see if the left mouse is released, if it is it stops the thread handling the dragging by disabling the boolean
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WorldMap_Up(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            //Due to zoom + imagebox size not being 1:1 pixel representation, calculate the actual mouse X,Y on raw image dimensions
            var actualClickPoint = CalculateActualMouseClick(e.X, e.Y);
            //Now we have the actual click location on the image, calculate the area to render
            CalculateRenderArea(actualClickPoint);
            RenderMap();
        }

        private void RenderMap()
        {
            //We create a temporary rectangle for the size of the persons screen so as to create it to fit correctly
            var cropRect = new Rectangle(0, 0, formMapUser.WorldMap.Width, formMapUser.WorldMap.Height);

            using (var g = Graphics.FromImage(_bitmap))
            {
                //formMapUser draws it to the local bitmap based on the size of the screen taking it from the renderrectangle
                g.DrawImage(LocalMap, cropRect, _renderRectangle, GraphicsUnit.Pixel);
                formMapUser.WorldMap.Image = _bitmap;
            }
            //Tuple<DateTime, DateTime> timeTuple = getTimes(formMapUser);
            //localButtonCreationClass.CreateButtons(formMapUser, this,timeTuple.Item1,timeTuple.Item2);
        }

        private Tuple<DateTime,DateTime> getTimes(WorldMapUser formMapUser)
        {
            DateTime StartDate = DateTime.Parse(formMapUser.CurrentDate.Text);
            DateTime EndDate = StartDate;
            switch (formMapUser.TimeSkipInterval.SelectedIndex)
            {
                case 0:
                    EndDate = EndDate.AddDays(1);
                    break;
                case 1:
                    EndDate = EndDate.AddDays(7);
                    break;
                case 2:
                    EndDate = EndDate.AddMonths(1);
                    break;
                case 3:
                    EndDate = EndDate.AddYears(1);
                    break;
                case 4:
                    EndDate = EndDate.AddYears(10);
                    break;
                case 5:
                    EndDate = EndDate.AddYears(100);
                    break;
            }
            return new Tuple<DateTime, DateTime>(StartDate,EndDate);
        }
    }
}