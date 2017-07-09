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
using static HistoryMap.Properties.Resources;

namespace HistoryMap
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// This is a local version of the history map to minimise the amount of times i have to write the long reference
        /// </summary>
        public Image LocalMap = maps_world_map_02;

        private Rectangle renderRectangle;
        private double zoom = 1;

        private const double MinZoom = 1, MaxZoom = 50, ZoomIncrement = 1.5;
        private Bitmap _bitmap;
        /// <summary>
        /// This initiliazes the form and assigns the scroll event to the worldmap
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.WorldMap.MouseWheel += WorldMap_MouseWheel;
            renderRectangle = new Rectangle(0, 0, LocalMap.Width, LocalMap.Height);
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
            PolygonCreator.DrawBorders(e);
        }
        /// <summary>
        /// This event hooks into the mouse scroll event to attempt to zoom in on the image 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorldMap_MouseWheel(object sender, MouseEventArgs e)
        {
            //First increment/decriment the zoom level depending on direction of scroll
            zoom = e.Delta > 0 ? Math.Min(zoom * ZoomIncrement, MaxZoom) : Math.Max(zoom / ZoomIncrement, MinZoom);
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
                g.DrawImage(LocalMap, cropRect, renderRectangle, GraphicsUnit.Pixel);
                WorldMap.Image = _bitmap;
            }
        }

        private Point CalculateActualMouseClick(int x, int y)
        {
            //Ratio between the rectangle size we are rendering, including zoom level
            var ratioX = renderRectangle.Width / (double)WorldMap.Width;
            var ratioY = renderRectangle.Height / (double)WorldMap.Height;

            //Calculate the actual width across the cropped image you are pressing
            var widthD = (x * ratioX);
            var heightD = (y * ratioY);
            //Add on the top left coordinate of the cropped location, stored in renderRectangle
            var xClicked = (int)(widthD) + renderRectangle.X;
            var yClicked = (int)(heightD) + renderRectangle.Y;
            return new Point(xClicked, yClicked);
        }

        private void CalculateRenderArea(Point clicked)
        {
            //Create the point we clicked, as well as the width/height of the zoomed in area.
            var point = new Point(clicked.X, clicked.Y);
            var width = LocalMap.Width / zoom;
            var height = LocalMap.Height / zoom;

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
            renderRectangle = new Rectangle(point.X, point.Y, (int)width, (int)height);
        }
    }
}
