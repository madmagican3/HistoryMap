using HistoryMap.Shared_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using HistoryMap.WorldMapUsers;

namespace HistoryMap.WorldMapCreate
{
    public partial class CreateForm : Form
    {
        /// <summary>
        /// This is the instance of the form displayed on the creation class
        /// </summary>
        WorldMapUser viewForm = new WorldMapUser();

        /// <summary>
        /// This is used as a reference to get the dictionary to draw when needed
        /// </summary>
        public static BorderStorageClass LocalBorderStorageClass = new BorderStorageClass();

        /// <summary>
        /// This is used to store the onclick event when drawing borders
        /// </summary>
        public List<Point> LocalPointList = new List<Point>();

        /// <summary>
        /// This is the colour of the entry the user wants to draw
        /// </summary>
        public Color LocalColor;
        /// <summary>
        /// This is a pointer to the selcted index on the BorderPointList
        /// </summary>
        public static int SelectedIndex = -1;
        /// <summary>
        /// This a instance of the generic label for creation purposes
        /// </summary>
        public static GenericLabelForWorldMap NewGenericLabelForWorldMap;

        private ClickAndDrag _clickAndDrag;
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
            _clickAndDrag = new ClickAndDrag(viewForm, (ev) => BorderDrawingClickDelegate(null, ev));
            Closing += (a, b) => { _clickAndDrag.ClearEvents(); };

        }

        /// <summary>
        /// This will create an instance of the view form in the create form
        /// </summary>
        private void CreateFormInstance(bool showButtons)
        {
            WorldMapPanel.Width = Width - 180;
            WorldMapPanel.Height = Height;
            ControlsPanel.Height = Height;
            ControlsPanel.Left = Width - 180;
            viewForm.Height = WorldMapPanel.Height;
            viewForm.Width = WorldMapPanel.Width;
            viewForm.TopLevel = false;
            viewForm.RenderButtons = showButtons; //make the form conform to our style requirements
            if (InterestingInfoBtn.Checked)
            {
                viewForm.WorldMap.Click += ClickDelegate;
            }
            else if (BorderDrawingBtn.Checked)
            {
                viewForm.WorldMap.Click += BorderDrawingClickDelegate;
            }
            else
            {
                viewForm.WorldMap.Click -= ClickDelegate;
                viewForm.WorldMap.Click -= BorderDrawingClickDelegate;
            }
            viewForm.FormBorderStyle = FormBorderStyle.None;
            WorldMapPanel.Controls.Clear();
            WorldMapPanel.Controls.Add(viewForm);
            viewForm.LocalDrawClass.WorldMap_SizeChanged(this, new EventArgs());
            viewForm.Show();
        }
        /// <summary>
        /// This shuts down the form properley taking out any hidden forms to properley dispose of the program
        /// </summary>
        private void CreateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
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
            viewForm.LocalDrawClass.RenderMap();
        }

        /// <summary>
        /// This sets the form up for drawing borders
        /// </summary>
        private void BorderDrawingBtn_CheckedChanged(object sender, EventArgs e)
        {
            _clickAndDrag.IsEditing = BorderDrawingBtn.Checked;
            if (BorderDrawingBtn.Checked)
            {
                InterestingInfoBtn.Checked = false;
                CreateFormInstance(false);
                var result = ColourDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LocalColor = ColourDialog.Color;
                    PolygonCreator.Drawing = true;
                    LocalBorderStorageClass.Colour = LocalColor;
                    LocalBorderStorageClass.AllPointsofBorder = new List<Point>();
                    viewForm.LocalDrawClass.RenderMap();
                    IndexList.Visible = true;
                    DeleteIndexBtn.Visible = true;
                    viewForm.LocalDrawClass.MoveForm = false;
                    ViewCompleteBtn.Visible = true;
                }
                else
                {

                    BorderDrawingBtn.Checked = false;
                }
            }
            else if (!InterestingInfoBtn.Checked)
            {
                DeleteIndexBtn.Visible = false;
                CompleteBtn.Visible = false;
                ViewCompleteBtn.Visible = false;
                IndexList.Visible = false;
                BorderDrawingBtn.Checked = false;
                CreateFormInstance(true);
                PolygonCreator.Drawing = false;
                viewForm.WorldMap.Click -= BorderDrawingClickDelegate;
                viewForm.LocalDrawClass.MoveForm = false;
            }
            viewForm.LocalDrawClass.RenderMap();

        }

        /// <summary>
        /// This on click event should be passed to the world form in order to get the vals we need to work with
        /// </summary>
        public void ClickDelegate(object sender, EventArgs e)
        {
            MouseEventArgs click = (MouseEventArgs)e; //Static cast the event args to get them to be the only type they ever will be
            var actualClickPoint = viewForm.LocalDrawClass.CalculateUiToMap(click.X, click.Y);
            ButtonCreator infoPanel = new ButtonCreator(actualClickPoint, viewForm.LocalDrawClass.CurrentDate);
            var result = infoPanel.ShowDialog();
            if (result == DialogResult.OK)
            {
                LocalMongoGetter.AddButton(NewGenericLabelForWorldMap, viewForm.LocalDrawClass.CurrentDate);
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
            var actualClickPoint = viewForm.LocalDrawClass.CalculateUiToMap(click.X, click.Y);
            LocalPointList.Add(actualClickPoint);
            LocalBorderStorageClass.AllPointsofBorder.Clear();
            LocalBorderStorageClass.AllPointsofBorder.AddRange(LocalPointList);
            viewForm.LocalDrawClass.RenderMap();
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
        private void Button1_Click(object sender, EventArgs e)
        {
            if (IndexList.SelectedIndex == -1) return;
            LocalPointList.RemoveAt(IndexList.SelectedIndex);
            SelectedIndex = -1;
            IndexList.Items.Clear();
            for (int i = 0; i < LocalPointList.Count; i++)
            {
                IndexList.Items.Add(i);
            }
            viewForm.LocalDrawClass.RenderMap();
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
            if (LocalPointList[0].Equals(LocalPointList[LocalPointList.Count - 1]))
            {
                LocalPointList.RemoveAt(LocalPointList.Count - 1);
                LocalBorderStorageClass.AllPointsofBorder.Clear();
                LocalBorderStorageClass.AllPointsofBorder.AddRange(LocalPointList);
                viewForm.LocalDrawClass.RenderMap();
                IndexList.Items.Clear();
                for (int i = 0; i < LocalPointList.Count; i++)
                {
                    IndexList.Items.Add(i);
                }

                CompleteBtn.Visible = false;
                CompleteBtn.Enabled = false;
            }
            SelectedIndex = IndexList.SelectedIndex;
            viewForm.LocalDrawClass.RenderMap();
        }
        /// <summary>
        /// This makes us view the borders in a complete form as a polygon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewCompleteBtn_Click(object sender, EventArgs e)
        {
            LocalPointList.Add(LocalPointList[0]);
            LocalBorderStorageClass.AllPointsofBorder.Clear();
            LocalBorderStorageClass.AllPointsofBorder.AddRange(LocalPointList);
            viewForm.LocalDrawClass.RenderMap();
            IndexList.Items.Clear();
            for (int i = 0; i < LocalPointList.Count; i++)
            {
                IndexList.Items.Add(i);
            }

            CompleteBtn.Enabled = true;
            CompleteBtn.Visible = true;
        }
        /// <summary>
        /// This saves the border to the db 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            using (var form = new DateSelectionModal(viewForm.LocalDrawClass.CurrentDate))
            {
                var dialogResult = form.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    if (viewForm.LocalDrawClass.CurrentDate > form.ReturnTime)
                    {
                        MessageBox.Show(@"You're trying to create a start time before an end time");
                        return;
                    }
                    else
                    {
                        LocalBorderStorageClass.ValidTill = form.ReturnTime;
                    }
                    
                }
                else
                {
                    return;
                }
            }
            DeleteIndexBtn.Visible = false;
            CompleteBtn.Visible = false;
            ViewCompleteBtn.Visible = false;
            IndexList.Visible = false;
            BorderDrawingBtn.Checked = false;
            CreateFormInstance(true);
            PolygonCreator.Drawing = false;
            viewForm.WorldMap.Click -= BorderDrawingClickDelegate;
            viewForm.LocalDrawClass.MoveForm = false;
            LocalBorderStorageClass.TimeOf= viewForm.LocalDrawClass.CurrentDate;
            LocalBorderStorageClass._id = Guid.NewGuid().ToString();
            LocalBorderStorageClass.Verified = false;
            LocalMongoGetter.SaveBorder(LocalBorderStorageClass);
            LocalBorderStorageClass = null;
        }


        public class ClickAndDrag
        {
            private WorldMapUser _users;
            private Action<MouseEventArgs> _update;
            public bool IsEditing { get; set; }
            public bool IsDragging { get; private set; }
            public Point LastPoint { get; private set; }
            public int PixelDistance { get; set; }

            public ClickAndDrag(WorldMapUser users, Action<MouseEventArgs> eventCallback)
            {
                _users = users;
                PixelDistance = 24;
                _update = eventCallback;
                SetupEvents();
            }

            private void SetupEvents()
            {
                _users.WorldMap.MouseDown += MouseDown;
                _users.WorldMap.MouseMove += MouseDragEvent;
                _users.WorldMap.MouseUp += MouseUp;
            }
            public void ClearEvents()
            {
                _users.WorldMap.MouseDown -= MouseDown;
                _users.WorldMap.MouseMove -= MouseDragEvent;
                _users.WorldMap.MouseUp -= MouseUp;
            }

            public void MouseDown(object sender, EventArgs e)
            {
                IsDragging = true;
            }

            public void MouseUp(object sender, EventArgs e)
            {
                IsDragging = false;
            }
            public void MouseDragEvent(object sender, EventArgs e)
            {
                if (!IsDragging || !IsEditing) return;
                MouseEventArgs mouseMove = (MouseEventArgs) e;

                if (mouseMove != null && Math.Abs(mouseMove.X - LastPoint.X) + Math.Abs(mouseMove.Y - LastPoint.Y) >
                    PixelDistance)
                {
                    _update(mouseMove);
                    LastPoint = mouseMove.Location;
                }
            }
        }
    }
}
