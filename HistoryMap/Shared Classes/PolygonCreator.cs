using System;
using System.Collections.Generic;
using System.Drawing;
using HistoryMap.Properties;
using NodaTime;

namespace HistoryMap.Shared_Classes
{
    internal static class PolygonCreator
    {
        public static bool drawing = false;

        /// <summary>
        /// This draws the polygons for borders based on the image passed to it
        /// </summary>
        /// <param name="localMap"></param>
        /// <returns></returns>
        public static Image DrawBorders(Image localMap, LocalDate localDate, double zoom)
        {
            if (!drawing)
                return DrawImage(localMap, LocalMongoGetter.GetCountries(localDate), zoom);
            else
            {
                List<BorderStorageClass> tempBorderStorageList =
                    new List<BorderStorageClass> {WorldMapCreate.CreateForm.LocalBorderStorageClass};
                return DrawImage(localMap, tempBorderStorageList, zoom);
            }

        }
        /// <summary>
        /// This draws all the borders on the countries
        /// </summary>
        /// <param name="localMap"> This is a copy of the main image</param>
        /// <param name="allBordersList">this is a dictionary returned from the sql that gets all the colours</param>
        /// <returns></returns>
        public static Image DrawImage(Image localMap, List<BorderStorageClass> allBordersList, double zoom)
        {
            var pen = new Pen(Color.Black, 3);
            //this gets every entry in the dictionary
            if (allBordersList == null) return localMap;
            foreach (var tempEntry in allBordersList)
            {
                if (tempEntry.AllPointsofBorder.Count != 0)
                {
                    //then it writes them to the image to return
                    using (var g = Graphics.FromImage(localMap))
                    {
                        if (!drawing)
                        {
                            var brush = new SolidBrush(Color.FromArgb(128, tempEntry.Colour.R, tempEntry.Colour.G, tempEntry.Colour.B));
                            g.FillPolygon(brush, tempEntry.AllPointsofBorder.ToArray());
                            g.DrawPolygon(pen, tempEntry.AllPointsofBorder.ToArray());
                        }
                        else
                        {
                            if ( tempEntry.AllPointsofBorder.Count > 2&&tempEntry.AllPointsofBorder[0].Equals(tempEntry.AllPointsofBorder[tempEntry.AllPointsofBorder.Count-1]))
                            {
                                var brush = new SolidBrush(Color.FromArgb(128, tempEntry.Colour.R, tempEntry.Colour.G, tempEntry.Colour.B));
                                g.FillPolygon(brush, tempEntry.AllPointsofBorder.ToArray());
                                g.DrawPolygon(pen, tempEntry.AllPointsofBorder.ToArray());
                            }
                            else
                            {
                          
                                int i = 0;
                                foreach (var point in tempEntry.AllPointsofBorder.ToArray())
                                {
                                    const int finalPixels = 8;
                                    var rect = new Rectangle(point.X - finalPixels / 2, point.Y - finalPixels / 2, finalPixels, finalPixels);
                                    if (i != WorldMapCreate.CreateForm.selectedIndex)
                                        g.DrawIcon(Resources.if_circle_red_10282, rect);
                                    else
                                        g.DrawIcon(Resources.if_circle_blue_10279, rect);
                                    i += 1;
                                }
                            }
                        }
                    }
                } 

            }
            return localMap;
        }


    }
}
