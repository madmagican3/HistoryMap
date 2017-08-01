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
        private Point ButtonCenterPoint { get; }
        private string Type { get;  }
        private string Text { get; }

        public ButtonStorage(Point buttonCenterPoint, string type, string text)
        {
            this.ButtonCenterPoint = buttonCenterPoint;
            this.Type = type;
            this.Text = text;
        }
    }
}
