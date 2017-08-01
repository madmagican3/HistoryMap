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
            LocalSqlGetter.GetCountries(new DateTime());

            return localMap;
            // return DrawImage(localMap, LocalSQLGetter.getCountries(new DateTime()));
        }
        /// <summary>
        /// This draws all the borders on the countries
        /// </summary>
        /// <param name="localMap"> This is a copy of the main image</param>
        /// <param name="allBordersList">this is a dictionary returned from the sql that gets all the colours</param>
        /// <returns></returns>
        public static Image DrawImage(Image localMap, Dictionary<Color,List<Point>> allBordersList)
        {
            var Pen = new Pen(Color.Black,3);
            //this gets every entry in the dictionary
            foreach (var tempEntry in allBordersList)
            {
                //then it writes them to the image to return
                using (var g = Graphics.FromImage(localMap))
                {
                    g.FillPolygon(new SolidBrush(Color.FromArgb(100, tempEntry.Key)), tempEntry.Value.ToArray());
                    g.DrawPolygon(Pen, tempEntry.Value.ToArray());
                }
            }
            return localMap;
        }
    }
}
