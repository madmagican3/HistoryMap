using System.Drawing;

namespace HistoryMap.Shared_Classes
{
    class GenericLabelForWorldMap
    {
        /// <summary>
        /// This should mark the center point of the button
        /// </summary>
        public Point ButtonCenterPoint { get; }
        /// <summary>
        /// This is the width of the icon
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// this is the height of the icon
        /// </summary>
        public int Height { get; }

        /// <summary>
        ///  this should mark the type for easier checking to see if the image is correct
        /// </summary>
        public string Type { get; }
        /// <summary>
        /// This should be the full statement the user should be displayed. 
        /// * * for headings, | for enviroment.newline
        /// </summary>

        //TODO make sure you warn the user that they should not use these chars
        public string Text { get; }
        /// <summary>
        /// This is an int for showing what sort of zoom level this should be displayed at. Currently 0
        /// is max zoom level and 1 is min zoom level, int for further expansion if required
        /// </summary>
        public int ViewLevel { get; }
        public GenericLabelForWorldMap(Point buttonCenterPoint, string type, string text, int viewLevel, int height, int width)
        {
            this.ButtonCenterPoint = buttonCenterPoint;
            this.Type = type;
            this.Text = text;
            this.ViewLevel = viewLevel;
            this.Height = height;
            this.Width = width;
        }
    }
}
