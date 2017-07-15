using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HistoryMap.Properties;
using HistoryMap.Shared_Classes;
using HistoryMap.WorldMapUsers;
using static HistoryMap.Properties.Resources;

namespace HistoryMap
{
    public partial class WorldMapUser : Form
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
        private double _zoom = 1;
        /// <summary>
        /// these track the level of max and min zoom along with the zoom increment
        /// </summary>
        private const double MinZoom = 1, MaxZoom = 50, ZoomIncrement = 1.5;
        /// <summary>
        /// this is a local bitmap to avoid recreating the variable multiple times
        /// </summary>
        private readonly Bitmap _bitmap;


        /// <summary>
        /// This initiliazes the form and assigns the scroll event to the worldmap
        /// </summary>
        public WorldMapUser()
        {
            InitializeComponent();
            this.WorldMap.MouseWheel += WorldMap_MouseWheel;
            this.WorldMap.MouseUp += WorldMap_Up;
            _renderRectangle = new Rectangle(0, 0, LocalMap.Width, LocalMap.Height);
            LocalMap = PolygonCreator.DrawBorders(LocalMap);
            _bitmap = new Bitmap(LocalMap);
            RenderMap();
        }

        /// <summary>
        /// This event hooks into the drawing of the map in order to draw the polygon on it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorldMap_Paint(object sender, PaintEventArgs e)
        {
        }
        /// <summary>
        /// This event hooks into the mouse scroll event to attempt to zoom in on the image 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorldMap_MouseWheel(object sender, MouseEventArgs e)
        {
            //First increment/decriment the zoom level depending on direction of scroll
            _zoom = e.Delta > 0 ? Math.Min(_zoom * ZoomIncrement, MaxZoom) : Math.Max(_zoom / ZoomIncrement, MinZoom);
            //Due to zoom + imagebox size not being 1:1 pixel representation, calculate the actual mouse X,Y on raw image dimensions
            var actualClickPoint = CalculateActualMouseClick(e.X, e.Y);

            //Now we have the actual click location on the image, calculate the area to render
            CalculateRenderArea(actualClickPoint);
            RenderMap();
        }

        private void RenderMap()
        {
            var cropRect = new Rectangle(0, 0, WorldMap.Width, WorldMap.Height);

            using (var g = Graphics.FromImage(_bitmap))
            {
                g.DrawImage(LocalMap, cropRect, _renderRectangle, GraphicsUnit.Pixel);
                WorldMap.Image = _bitmap;
            }
        }


        /// <summary>
        /// This checks to see if the left mouse is released, if it is it stops the thread handling the dragging by disabling the boolean
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorldMap_Up(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            //Due to zoom + imagebox size not being 1:1 pixel representation, calculate the actual mouse X,Y on raw image dimensions
            var actualClickPoint = CalculateActualMouseClick(e.X, e.Y);
            //Now we have the actual click location on the image, calculate the area to render
            CalculateRenderArea(actualClickPoint);
            RenderMap();
        }

        private void WorldMap_SizeChanged(object sender, EventArgs e)
        {
            RenderMap();
        }

        private Point CalculateActualMouseClick(int x, int y)
        {
            //Ratio between the rectangle size we are rendering, including zoom level
            var ratioX = _renderRectangle.Width / (double)WorldMap.Width;
            var ratioY = _renderRectangle.Height / (double)WorldMap.Height;

            //Calculate the actual width across the cropped image you are pressing
            var widthD = (x * ratioX);
            var heightD = (y * ratioY);
            //Add on the top left coordinate of the cropped location, stored in renderRectangle
            var xClicked = (int)(widthD) + _renderRectangle.X;
            var yClicked = (int)(heightD) + _renderRectangle.Y;
            return new Point(xClicked, yClicked);
        }

        private void CalculateRenderArea(Point clicked)
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
    }
}