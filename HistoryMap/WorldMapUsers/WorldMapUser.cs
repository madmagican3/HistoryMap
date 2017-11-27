using System;
using System.Drawing;
using System.Windows.Forms;
using HistoryMap.Shared_Classes;
using Color = System.Drawing.Color;

namespace HistoryMap.WorldMapUsers
{
    public partial class WorldMapUser : Form
    {
        /// <summary>
        /// This contains a local instance of the drawclass
        /// </summary>
        readonly DrawClass _localDrawClass;
        /// <summary>
        /// This contains a local instance of the listhandlerclass
        /// </summary>
        private readonly ListHandlerClass _localListHandlerClass;

        /// <summary>
        /// This initiliazes the form and assigns the scroll event to the worldmap
        /// </summary>
        public WorldMapUser()
        {
            InitializeComponent();
            _localDrawClass = new DrawClass(this);
            _localListHandlerClass = new ListHandlerClass(this);
            worldMapHandler();
            buttonHandler();
            panelHandler();
            ControlPanelHandler();
            SettingsIcon.Click += SettingsOpen;
        }

        private void ControlPanelHandler()
        {
            ControlPanel.BackColor = Color.Transparent;
            ControlPanel.Parent = WorldMap;
            TimeSkipInterval.SelectedIndex = 3;
        }

        private void SettingsOpen(object sender, EventArgs e)
        {
            new SettingsForm().Visible = true;
        }
        /// <summary>
        /// This should hold all the other buttons which the user will interact with on the main 
        /// </summary>
        private void panelHandler()
        {
            //make the buttons back colour transparent
            ZoomOutLabel.Parent = WorldMap;
            ZoomInLabel.Parent = WorldMap;
            SettingsIcon.Parent = WorldMap;
            ZoomOutLabel.BackColor = Color.Transparent;
            ZoomInLabel.BackColor = Color.Transparent;
            SettingsIcon.BackColor = Color.Transparent;

            ZoomInLabel.Click += _localDrawClass.WorldMap_zoomIn;
            ZoomOutLabel.Click += _localDrawClass.WorldMap_ZoomOut;
        }
        /// <summary>
        /// This handles the button creation for the list to the left and the hooks required for it 
        /// </summary>
        private void buttonHandler()
        {
            //This is so that the transparency actually works
            MaximiseButton.Parent = WorldMap;
            MaximiseButton.BackColor = Color.Transparent;
            //set up the handlers
            MaximiseButton.Click += _localListHandlerClass.MaximisedScreen;
            MinButton.Click += _localListHandlerClass.MinimisedScreen;
            InterestingItemsList.SelectedIndexChanged += _localListHandlerClass.ChoseItem;
            SearchTxtBox.KeyPress += _localListHandlerClass.Search;
            SearchIcoLabel.Click += _localListHandlerClass.Search;
        }
        /// <summary>
        /// This creates all the hooks for the worldMap
        /// </summary>
        private void worldMapHandler()
        {
            WorldMap.MouseWheel += _localDrawClass.WorldMap_MouseWheel;
            WorldMap.MouseUp += _localDrawClass.WorldMap_Up;
            WorldMap.SizeChanged += _localDrawClass.WorldMap_SizeChanged;
            CurrentDate.Click += _localDrawClass.DateHandler;
            SearchIcon.Click += _localDrawClass.DateHandler;
            timeSkipArrowLeft.Click += _localDrawClass.OnLeftArrowClick;
            timeSkipArrowRight.Click += _localDrawClass.OnRightArrowClick;
        }
        /// <summary>
        /// This will occur on someone resizing the form so as to display the form correctly
        /// at multiple different resolutions at different times. It will move around the control 
        /// elements to suit that
        /// </summary>
        public void WorldMapUser_ResizeEnd(object sender, EventArgs e)
        {
            ControlPanel.Left = WorldMap.Width / 2 - (ControlPanel.Width / 2);
            ControlPanel.Top = Math.Min(WorldMap.Height, Height - 60) - 32;
            MaximiseButton.Location = new Point(0, Height / 2);
            MinButton.Location = new Point(MinButton.Location.X, Height / 2);
            SettingsIcon.Left = WorldMap.Width - 64;
            ZoomOutLabel.Left = WorldMap.Width - 96;
            ZoomInLabel.Left = WorldMap.Width - 128;
            ListPanel.Height = Height - 40;
            InterestingItemsList.Height = Height - 40;
        }

        private void WorldMapUser_Load(object sender, EventArgs e)
        {
            WorldMapUser_ResizeEnd(this, new EventArgs());
        }
    }
}