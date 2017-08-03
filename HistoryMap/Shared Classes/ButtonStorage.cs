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
        public Point ButtonCenterPoint { get; }
        public string Type { get;  }
        public string Text { get; }

        public ButtonStorage(Point buttonCenterPoint, string type, string text)
        {
            this.ButtonCenterPoint = buttonCenterPoint;
            this.Type = type;
            this.Text = text;
        }
    }
}
