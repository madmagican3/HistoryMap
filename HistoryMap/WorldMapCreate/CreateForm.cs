using HistoryMap.Shared_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HistoryMap.WorldMapCreate
{
    public partial class CreateForm : Form
    {
        /// <summary>
        /// This is the instance of the form displayed on the creation class
        /// </summary>
        WorldMapUsers.WorldMapUser viewForm = new WorldMapUsers.WorldMapUser();

        /// <summary>
        /// This is used as a reference to get the dictionary to draw when needed
        /// </summary>
        public static Dictionary<Color, List<Point>> drawingListDictionary = new Dictionary<Color, List<Point>>();

        /// <summary>
        /// This is used to store the onclick event when drawing borders
        /// </summary>
        public List<Point> LocalPointList = new List<Point>();

        /// <summary>
        /// This is the colour of the entry the user wants to draw
        /// </summary>
        public Color localColor;

        public static int selectedIndex = -1;

        public static GenericLabelForWorldMap NewGenericLabelForWorldMap;
        public CreateForm()
        {
           InitializeComponent();
        }
        /// <summary>
        /// Set up the form upon load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateForm_Load(object sender, EventArgs e)
        { 
            CreateFormInstance(true);
        }

        /// <summary>
        /// This will create an instance of the view form in the create form
        /// </summary>
        private void CreateFormInstance(bool showButtons)
        {
            WorldMapPanel.Width = this.Width - 180;
            WorldMapPanel.Height = this.Height;
            ControlsPanel.Height = this.Height;
            ControlsPanel.Left = this.Width - 180;
            viewForm.Height = WorldMapPanel.Height;
            viewForm.Width = WorldMapPanel.Width;
            viewForm.TopLevel = false;
            viewForm.renderButtons = showButtons; //make the form conform to our style requirements
            if (InterestingInfoBtn.Checked) 
            {
                viewForm.WorldMap.Click += clickDelegate;
            }
            else if (BorderDrawingBtn.Checked)
            {
                viewForm.WorldMap.Click += BorderDrawingClickDelegate;
            }else
            {
                viewForm.WorldMap.Click -= clickDelegate;
                viewForm.WorldMap.Click -= BorderDrawingClickDelegate;
            }
            viewForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WorldMapPanel.Controls.Clear();
            this.WorldMapPanel.Controls.Add(viewForm);
            viewForm._localDrawClass.WorldMap_SizeChanged(this, new EventArgs());
            viewForm.Show();
        }
        /// <summary>
        /// This shuts down the form properley taking out any hidden forms to properley dispose of the program
        /// </summary>
        private void CreateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
        /// <summary>
        /// This will occur on someone resizing the form so as to display the form correctly
        /// at multiple different resolutions at different times. It will move around the control 
        /// elements to suit that
        /// </summary>
        private void CreateForm_ResizeEnd(object sender, EventArgs e)
        {
            if (!BorderDrawingBtn.Checked && !InterestingInfoBtn.Checked)
                CreateFormInstance(true);
            else
                CreateFormInstance(false);
        }

        /// <summary>
        /// This sets the form up to be able to create interesting information buttons
        /// </summary>
        private void InterestingInfoBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (InterestingInfoBtn.Checked)
            {
                BorderDrawingBtn.Checked = false;
                CreateFormInstance(false);
            }
            else if (!BorderDrawingBtn.Checked)
            {
                CreateFormInstance(true);
            }
            viewForm._localDrawClass.RenderMap();
        }

        /// <summary>
        /// This sets the form up for drawing borders
        /// </summary>
        private void BorderDrawingBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (BorderDrawingBtn.Checked)
            {
                InterestingInfoBtn.Checked = false;
                CreateFormInstance(false);
                var result = ColourDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var colour = ColourDialog.Color;
                    PolygonCreator.drawing = true;
                    drawingListDictionary.Add(colour, new List<Point>());
                    viewForm._localDrawClass.RenderMap();
                    IndexList.Visible = true;
                    DeleteIndexBtn.Visible = true;
                    viewForm._localDrawClass.MoveForm = false;
                }
                else
                {
                    BorderDrawingBtn.Checked = false;
                }
            }
            else if (!InterestingInfoBtn.Checked)
            {
                CreateFormInstance(true);
            }
            viewForm._localDrawClass.RenderMap();

        }

        /// <summary>
        /// This on click event should be passed to the world form in order to get the vals we need to work with
        /// </summary>
        public void clickDelegate(object sender, EventArgs e)
        {
            MouseEventArgs click = (MouseEventArgs)e; //Static cast the event args to get them to be the only type they ever will be
            var actualClickPoint = viewForm._localDrawClass.CalculateUiToMap(click.X, click.Y);
            ButtonCreator infoPanel = new ButtonCreator(actualClickPoint, viewForm._localDrawClass._currentDate);
            var result = infoPanel.ShowDialog();
            if (result == DialogResult.OK)
            {
                LocalMongoGetter.AddButton(NewGenericLabelForWorldMap, viewForm._localDrawClass._currentDate);
                NewGenericLabelForWorldMap = null;
            }
        }

        /// <summary>
        /// This delegate is used for recording click points and displaying them on the map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BorderDrawingClickDelegate(object sender, EventArgs e)
        {
            MouseEventArgs click = (MouseEventArgs)e; //Static cast the event args to get them to be the only type they ever will be
            var actualClickPoint = viewForm._localDrawClass.CalculateUiToMap(click.X, click.Y);
            LocalPointList.Add(actualClickPoint);
            drawingListDictionary.Clear();
            drawingListDictionary.Add(localColor, LocalPointList);
            viewForm._localDrawClass.RenderMap();
            IndexList.Items.Clear();
            for (int i = 0; i < LocalPointList.Count; i++)
            {
                IndexList.Items.Add(i);
            }
        }
        /// <summary>
        /// This will remove the sleected index and refresh the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (IndexList.SelectedIndex == -1) return;
            LocalPointList.RemoveAt(IndexList.SelectedIndex);
            selectedIndex = -1;
            IndexList.Items.Clear();
            for (int i = 0; i < LocalPointList.Count; i++)
            {
                IndexList.Items.Add(i);
            }
            viewForm._localDrawClass.RenderMap();
            IndexList.SelectedIndex = -1;
            DeleteIndexBtn.Enabled = false;
        }

        /// <summary>
        /// This is used to set up the ui and inform the user what index they've selected and how it appears on the map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IndexList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IndexList.SelectedIndex != -1)
                DeleteIndexBtn.Enabled = true;
            selectedIndex = IndexList.SelectedIndex;
            viewForm._localDrawClass.RenderMap();
        }
    }
}
