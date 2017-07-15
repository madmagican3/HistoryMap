using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HistoryMap.Shared_Classes
{
    internal class PolygonCreator
    {
        public static Image DrawBorders(Image LocalMap)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            var pointList = new []
            {
                new Point(0, 0), 
                new Point(200, 0),
                new Point(200, 200),
                new Point(0, 200), 
            };
            using (var g = Graphics.FromImage(LocalMap))
            {
                g.FillPolygon(new SolidBrush(Color.FromArgb(100, Color.Blue)), pointList);
                g.DrawPolygon(blackPen, pointList.ToArray());
            }
            return LocalMap;
        }
    }
}
