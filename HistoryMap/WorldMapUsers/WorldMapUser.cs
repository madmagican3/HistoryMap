﻿using System;
using System.Drawing;
using System.Security.AccessControl;
using System.Windows.Forms;
using HistoryMap.Shared_Classes;
using HistoryMap.WorldMapUsers;
using static HistoryMap.Properties.Resources;
using Color = System.Drawing.Color;

namespace HistoryMap
{
    public partial class WorldMapUser : Form
    {
        /// <summary>
        /// This contains a local instance of the drawclass
        /// </summary>
        readonly DrawClass localDrawClass;
        /// <summary>
        /// This contains a local instance of the buttoncreationclass
        /// </summary>
        private readonly ButtonCreationClass localButtonCreationClass;
        /// <summary>
        /// This contains a local instance of the listhandlerclass
        /// </summary>
        private readonly ListHandlerClass localListHandlerClass;

        /// <summary>
        /// This initiliazes the form and assigns the scroll event to the worldmap
        /// </summary>
        public WorldMapUser()
        {
            InitializeComponent();
            localDrawClass = new DrawClass(this);
            localListHandlerClass = new ListHandlerClass(this);
            localButtonCreationClass = new ButtonCreationClass();
            worldMapHandler();
            buttonHandler();
            panelHandler();
            SettingsIcon.Click += SettingsOpen;
        }

        public void SettingsOpen(object sender, EventArgs e)
        {
            new SettingsForm().Visible = true;
        }
        /// <summary>
        /// This should hold all the other buttons which the user will interact with on the main 
        /// </summary>
        public void panelHandler()
        {
            //make the buttons back colour transparent
            ZoomOutLabel.Parent = WorldMap;
            ZoomInLabel.Parent = WorldMap;
            SettingsIcon.Parent = WorldMap;
            ZoomOutLabel.BackColor = Color.Transparent;
            ZoomInLabel.BackColor = Color.Transparent;
            SettingsIcon.BackColor = Color.Transparent;

            ZoomInLabel.Click += localDrawClass.WorldMap_zoomIn;
            ZoomOutLabel.Click += localDrawClass.WorldMap_ZoomOut;
        }
        /// <summary>
        /// This handles the button creation for the list to the left and the hooks required for it 
        /// </summary>
        public void buttonHandler()
        {
            //This is so that the transparency actually works
            MaximiseButton.Parent = WorldMap;
            MaximiseButton.BackColor = System.Drawing.Color.Transparent;
            //place it in the correct location
            MaximiseButton.Location = new Point(0, this.Height / 2);
            MinButton.Location = new Point(MinButton.Location.X, this.Height / 2);
            //set up the handlers
            MaximiseButton.Click += localListHandlerClass.MaximisedScreen;
            MinButton.Click += localListHandlerClass.MinimisedScreen;
            InterestingItemsList.SelectedIndexChanged += localListHandlerClass.ChoseItem;
            SearchTxtBox.KeyPress += localListHandlerClass.Search;
            SearchIcoLabel.Click += localListHandlerClass.Search;
        }
        /// <summary>
        /// This creates all the hooks for the worldMap
        /// </summary>
        public void worldMapHandler()
        {
            this.WorldMap.MouseWheel += localDrawClass.WorldMap_MouseWheel;
            this.WorldMap.MouseUp += localDrawClass.WorldMap_Up;
            this.WorldMap.SizeChanged += localDrawClass.WorldMap_SizeChanged;
        }
    }
}