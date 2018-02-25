using System.Collections.Generic;
using System.Drawing;
using HistoryMap.Properties;
using NodaTime;

namespace HistoryMap.Shared_Classes
{
    internal static class PolygonCreator
    {
        /// <summary>
        /// This is a flag used to indicate if we're drawing
        /// </summary>
        public static bool Drawing = false;
        /// <summary>
        /// This is a local instance of the current date used to stop wasted calls on initalization
        /// </summary>
        public static LocalDate CurrentDate;
        /// <summary>
        /// This is a local instance of the current dates current borders to stop wasted calls on initalization
        /// </summary>
        public static List<BorderStorageClass> CurrentBorders;

        /// <summary>
        /// This draws the polygons for borders based on the image passed to it
        /// </summary>
        /// <param name="localMap">The image we're drawing on</param>
        /// <param name="localDate">The date we're searching for</param>
        /// <param name="zoom">the zoom level</param>
        /// <returns>a version of the drawing with the polygons drawn on</returns>
        public static Image DrawBorders(Image localMap, LocalDate localDate, double zoom)
        {
            if (CurrentDate != localDate)
            {
                CurrentDate = localDate;
                CurrentBorders = LocalMongoGetter.GetCountries(localDate);
            }
            if (AdminPanel.AdminPanel.BorderStorage != null)
            {
                List<BorderStorageClass> tempBordersStorageList = new List<BorderStorageClass>();
                tempBordersStorageList.Add(AdminPanel.AdminPanel.BorderStorage);
                return DrawImage(localMap, tempBordersStorageList, zoom, false);
            }
            else if (!Drawing)
                return DrawImage(localMap, CurrentBorders, zoom, false);
            else
            {
                List<BorderStorageClass> tempBorderStorageList =
                    new List<BorderStorageClass> {WorldMapCreate.CreateForm.LocalBorderStorageClass};
                localMap = DrawImage(localMap, CurrentBorders, zoom, true);
                return DrawImage(localMap, tempBorderStorageList, zoom, false);
            }

        }

        /// <summary>
        /// This draws all the borders on the countries
        /// </summary>
        /// <param name="localMap"> This is a copy of the main image</param>
        /// <param name="allBordersList">this is a dictionary returned from the sql that gets all the colours</param>
        /// <param name="zoom">the zoom level of the form</param>
        /// <param name="forceGetBorders">If we want to force getting the borders</param>
        /// <returns>a modified version of the map with polygons drawn on</returns>
        public static Image DrawImage(Image localMap, List<BorderStorageClass> allBordersList, double zoom, bool forceGetBorders)
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
                        if (!Drawing|| forceGetBorders)
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
                                    if (i != WorldMapCreate.CreateForm.SelectedIndex)
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
