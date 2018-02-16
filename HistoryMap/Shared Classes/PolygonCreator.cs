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
                return DrawImage(localMap, WorldMapCreate.CreateForm.drawingListDictionary, zoom);
            }

        }
        /// <summary>
        /// This draws all the borders on the countries
        /// </summary>
        /// <param name="localMap"> This is a copy of the main image</param>
        /// <param name="allBordersList">this is a dictionary returned from the sql that gets all the colours</param>
        /// <returns></returns>
        public static Image DrawImage(Image localMap, Dictionary<Color, List<Point>> allBordersList, double zoom)
        {
            var pen = new Pen(Color.Black, 3);
            //this gets every entry in the dictionary
            if (allBordersList == null) return localMap;
            foreach (var tempEntry in allBordersList)
            {
                if (tempEntry.Value.Count != 0)
                {
                    //then it writes them to the image to return
                    using (var g = Graphics.FromImage(localMap))
                    {
                        g.FillPolygon(new SolidBrush(tempEntry.Key), tempEntry.Value.ToArray());
                        if (!drawing)
                        {
                            g.DrawPolygon(pen, tempEntry.Value.ToArray());
                        }
                        else
                        {
                            int i = 0;
                           // if (theyIntersect) //TODO work out the maths for this
                            foreach (var point in  tempEntry.Value.ToArray())
                            {
                                if (i != WorldMapCreate.CreateForm.selectedIndex)
                                    g.DrawIcon(Resources.if_circle_red_10282, point.X -(Resources.if_circle_red_10282.Width/2), point.Y - (Resources.if_circle_red_10282.Height/2));
                                else
                                    g.DrawIcon(Resources.if_circle_blue_10279, point.X - (Resources.if_circle_blue_10279.Width / 2), point.Y - (Resources.if_circle_blue_10279.Height / 2));
                                i += 1;

                            }
                            //g.DrawPolygon(pen, tempEntry.Value.ToArray());
                        }
                    }
                } 

            }
            return localMap;
        }


    }
}
