using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.MemoryMappedFiles;
using System.Linq;
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
            Rectangle cropRect;
            if (e.Delta > 0)
            {
                cropRect = new Rectangle(0, 0, WorldMap.Image.Width / 2, WorldMap.Image.Height / 2);
            }
            else
            {
                cropRect = new Rectangle(0, 0, WorldMap.Image.Width * 2, WorldMap.Image.Height * 2);
            }
            if (cropRect.Width > LocalMap.Width || cropRect.Width <= LocalMap.Width / 16) return;
            Bitmap targetBitmap = new Bitmap(LocalMap,cropRect.Width, cropRect.Height);
            using (Graphics g = Graphics.FromImage(targetBitmap))
            {
                Point[] localPointList = new Point[]
                {
                    //TODO calculate the maths to make these points make a square around the mouse location
                    //https://msdn.microsoft.com/en-us/library/ms142038(v=vs.110).aspx
                   new Point() , 
                   new Point() , 
                   new Point()   
                };
                g.DrawImage(LocalMap,localPointList, cropRect,GraphicsUnit.Pixel);
                WorldMap.Image = (targetBitmap);
            }
        }
    }
}
