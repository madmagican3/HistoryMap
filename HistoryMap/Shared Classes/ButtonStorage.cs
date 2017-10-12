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
        //TODO note down the linebreaks and newline char we're using
        /// <summary>
        /// This should be the full statement the user should be displayed. 
        /// </summary>
        public string Text { get; }

        public ButtonStorage(Point buttonCenterPoint, string type, string text)
        {
            this.ButtonCenterPoint = buttonCenterPoint;
            this.Type = type;
            this.Text = text;
        }
    }
}
