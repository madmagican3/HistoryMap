using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryMap.WorldMapUsers
{
    class ButtonStorage
    {
        /// <summary>
        /// This should mark the center point of the button
        /// </summary>
        public Point ButtonCenterPoint { get; }
        /// <summary>
        ///  this should mark the type for easier checking to see if the image is correct
        /// </summary>
        public string Type { get;  }
        /// <summary>
        /// This should be the full statement the user should be displayed. 
        /// * * for headings, | for enviroment.newline
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// This is an int for showing what sort of zoom level this should be displayed at. Currently 0
        /// is max zoom level and 1 is min zoom level, int for further expansion if required
        /// </summary>
        public int viewLevel { get; }
        public ButtonStorage(Point buttonCenterPoint, string type, string text, int viewLevel)
        {
            this.ButtonCenterPoint = buttonCenterPoint;
            this.Type = type;
            this.Text = text;
            this.viewLevel = viewLevel;
        }
    }
}
