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
        /// This tracks the current zoom level of the image
        /// </summary>
        private int _zoomLevel = 1;
        /// <summary>
        /// This is a local version of the history map to minimise the amount of times i have to write the long reference
        /// </summary>
        public Image LocalMap = maps_world_map_02;
        /// <summary>
        /// This initiliazes the form and assigns the scroll event to the worldmap
        /// </summary>
        public Form1()
        { 
            InitializeComponent();
            this.WorldMap.MouseWheel += WorldMap_MouseWheel;
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
            if (e.Delta <= 0)
                _zoomLevel /= 2;
            else
                _zoomLevel *= 2;
            var cropRect = e.Delta > 0 ? new Rectangle(0, 0, LocalMap.Width / _zoomLevel, LocalMap.Height / _zoomLevel) : new Rectangle(0, 0, LocalMap.Width *_zoomLevel, LocalMap.Height * _zoomLevel);
            if (cropRect.Width > LocalMap.Width || cropRect.Width <= LocalMap.Width /64) return;
            var targetBitmap = new Bitmap(LocalMap,cropRect.Width, cropRect.Height);
            using (var g = Graphics.FromImage(targetBitmap))
            {
                GetZoom(e);
                //g.DrawImage(LocalMap,GetZoom(e), cropRect,GraphicsUnit.Pixel);
                WorldMap.Image = (targetBitmap);
            }
        }


        /// <summary>
        /// This gets the correct point data for the current image at the current zoom level
        /// </summary>
        /// <param name="e">This is the location of the mouse</param>
        /// <returns></returns>
        /// 
        // TODO redo this to work with the new zoom level system
        private Point[] GetZoom(MouseEventArgs e )
        {
            Point[] localPointList;
            if (e.Delta > 0)
            {
                localPointList = new Point[]
                {
                    new Point((e.X/2)/2 , (e.Y/2)/2) ,
                    new Point((e.X/2)/2 , (e.Y/2) + (WorldMap.Height/2)), 
                    new Point((e.X/2) + (WorldMap.Width/2),(e.Y/2)/2)
                };
            }
            else
            {
                localPointList = new Point[]
                {
                    new Point((e.X*2)/2 , (e.Y*2)/2) ,
                    new Point((e.X*2)/2 , (e.Y/2) + (WorldMap.Height/2)),
                    new Point((e.X*2) + (WorldMap.Width*2),(e.Y*2)/2)
                };
            }

            return localPointList;
        }
    }
}
