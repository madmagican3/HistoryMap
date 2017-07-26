using System;
using System.Drawing;
using System.Windows.Forms;
using HistoryMap.Shared_Classes;
using HistoryMap.WorldMapUsers;
using static HistoryMap.Properties.Resources;

namespace HistoryMap
{
    public partial class WorldMapUser : Form
    {
        readonly DrawClass localDrawClass;
        /// <summary>
        /// This initiliazes the form and assigns the scroll event to the worldmap
        /// </summary>
        public WorldMapUser()
        {
            InitializeComponent();
            localDrawClass = new DrawClass(this);
            //We set the events we're trying to hook into
            this.WorldMap.MouseWheel += localDrawClass.WorldMap_MouseWheel;
            this.WorldMap.MouseUp += localDrawClass.WorldMap_Up;
            this.WorldMap.SizeChanged += localDrawClass.WorldMap_SizeChanged;
        }

    }
}