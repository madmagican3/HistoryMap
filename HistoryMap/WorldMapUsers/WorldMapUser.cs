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
        public readonly DrawClass LocalDrawClass;
        /// <summary>
        /// This contains a local instance of the listhandlerclass
        /// </summary>
        private readonly ListHandlerClass _localListHandlerClass;
        /// <summary>
        /// This is used to hide buttons when we're creating new info
        /// </summary>
        public Boolean RenderButtons = true;

        /// <summary>
        /// This initiliazes the form and assigns the scroll event to the worldmap
        /// </summary>
        public WorldMapUser()
        {
            InitializeComponent();
            LocalDrawClass = new DrawClass(this);
            _localListHandlerClass = new ListHandlerClass(this);
            WorldMapHandler();
            ButtonHandler();
            PanelHandler();
            InterestingListHandler();
            ControlPanelHandler();
            SettingsIcon.Click += SettingsOpen;
        }

        private void ControlPanelHandler()
        {
            ControlPanel.BackColor = Color.Transparent;
            ControlPanel.Parent = WorldMap;
            TimeSkipInterval.SelectedIndex = 3;
        }
        /// <summary>
        /// this sets up the list handler panel and makes it so it doesnt start off visible
        /// </summary>
        private void InterestingListHandler()
        {
            ListPanel.BackColor = Color.Transparent;
            ListPanel.Parent = WorldMap;
            ListPanel.Enabled = false;
            ListPanel.Visible = false;
            MaximiseButton.Visible = true;
        }

        private void SettingsOpen(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(this) {Visible = true};
        }
        /// <summary>
        /// This should hold all the other buttons which the user will interact with on the main 
        /// </summary>
        public void PanelHandler()
        {
            //make the buttons back colour transparent
            ZoomOutLabel.Parent = WorldMap;
            ZoomInLabel.Parent = WorldMap;
            SettingsIcon.Parent = WorldMap;
            ZoomOutLabel.BackColor = Color.Transparent;
            ZoomInLabel.BackColor = Color.Transparent;
            SettingsIcon.BackColor = Color.Transparent;

            ZoomInLabel.Click += LocalDrawClass.WorldMap_zoomIn;
            ZoomOutLabel.Click += LocalDrawClass.WorldMap_ZoomOut;
        }
        /// <summary>
        /// This handles the button creation for the list to the left and the hooks required for it 
        /// </summary>
        private void ButtonHandler()
        {
            //This is so that the transparency actually works
            MaximiseButton.Parent = WorldMap;
            MaximiseButton.BackColor = Color.Transparent;
            //set up the handlers
            MaximiseButton.Click += _localListHandlerClass.MaximisedScreen;
            MinButton.Click += _localListHandlerClass.MinimisedScreen;
            InterestingItemsList.SelectedIndexChanged += _localListHandlerClass.ChoseItem;
            
            SearchTxtBox.KeyPress += _localListHandlerClass.KeyPress;
            SearchIcoLabel.Click += _localListHandlerClass.Search;
        }
        /// <summary>
        /// This creates all the hooks for the worldMap
        /// </summary>
        private void WorldMapHandler()
        {
            WorldMap.MouseWheel += LocalDrawClass.WorldMap_MouseWheel;
            WorldMap.MouseUp += LocalDrawClass.WorldMap_Up;
            WorldMap.SizeChanged += LocalDrawClass.WorldMap_SizeChanged;
            CurrentDate.Click += LocalDrawClass.DateHandler;
            SearchIcon.Click += LocalDrawClass.DateHandler;
            timeSkipArrowLeft.Click += LocalDrawClass.OnLeftArrowClick;
            timeSkipArrowRight.Click += LocalDrawClass.OnRightArrowClick;
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

        /// <summary>
        /// This shuts down the enviroment upon clicking close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorldMapUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}