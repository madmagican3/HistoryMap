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
        /// <summary>
        /// This draws the polygons for borders based on the image passed to it
        /// </summary>
        /// <param name="localMap"></param>
        /// <returns></returns>
        public static Image DrawBorders(Image localMap)
        {
            return localMap;
            // return DrawImage(localMap, LocalSQLGetter.getCountries(new DateTime()));
        }

        public static Image DrawImage(Image localMap, Dictionary<Pen,List<Point>> allBordersList)
        {
            //this gets every entry in the dictionary
            foreach (var tempEntry in allBordersList)
            {
                //then it writes them to the image to return
                using (var g = Graphics.FromImage(localMap))
                {
                    g.FillPolygon(new SolidBrush(Color.FromArgb(100, Color.Blue)), tempEntry.Value.ToArray());
                    g.DrawPolygon(tempEntry.Key, tempEntry.Value.ToArray());
                }
            }
            return localMap;
        }
    }
}
