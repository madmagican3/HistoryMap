﻿using System;
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
                        if (!drawing)
                        {
                            var brush = new SolidBrush(Color.FromArgb(128, tempEntry.Key.R, tempEntry.Key.G, tempEntry.Key.B));
                            g.FillPolygon(new SolidBrush(tempEntry.Key), tempEntry.Value.ToArray());
                            g.DrawPolygon(pen, tempEntry.Value.ToArray());
                        }
                        else
                        {
                            if ( tempEntry.Value.Count > 2&&tempEntry.Value[0].Equals(tempEntry.Value[tempEntry.Value.Count-1]))
                            {
                                var brush = new SolidBrush(Color.FromArgb(128, tempEntry.Key.R, tempEntry.Key.G, tempEntry.Key.B));
                                g.FillPolygon(brush, tempEntry.Value.ToArray());
                                g.DrawPolygon(pen, tempEntry.Value.ToArray());
                            }
                            else
                            {
                                var width = Resources.if_circle_red_10282.Width / 2;
                                var height = Resources.if_circle_red_10282.Height / 2;

                                int i = 0;
                                foreach (var point in tempEntry.Value.ToArray())
                                {
                                    const int finalPixels = 16;
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
