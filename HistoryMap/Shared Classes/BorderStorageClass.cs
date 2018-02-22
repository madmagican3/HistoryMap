using System;
using System.Collections.Generic;
using System.Drawing;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using NodaTime;

namespace HistoryMap.Shared_Classes
{
    public class BorderStorageClass
    {
        /// <summary>
        /// This says if this border has been verified by admins
        /// </summary>
        public Boolean Verified { get; set; }

        /// <summary>
        /// The id for saving
        /// </summary>
        public string _id { get; set; }
        /// <summary>
        /// The date of this interesting point occuring
        /// </summary>
        [BsonIgnore]
        [JsonIgnore]
        public LocalDate TimeOf { get; set; }
        /// <summary>
        /// This is used to put the date into a loadable format and stores the year and era
        /// </summary>
        public int year
        {
            get => TimeOf.Year;
            set
            {
                var era = NodaTime.Calendars.Era.Common;
                var year = value;
                if (value < 0)
                {
                    year = year * -1;
                    era = NodaTime.Calendars.Era.BeforeCommon;
                }
                TimeOf = new LocalDate(era, year, TimeOf.Month, TimeOf.Day);
            }

        }
        /// <summary>
        /// This is used to put the data into loadable format and stores the month
        /// </summary>
        public int month
        {
            get => TimeOf.Month;
            set => TimeOf = new LocalDate(TimeOf.Era, TimeOf.YearOfEra, value, TimeOf.Day);
        }
        /// <summary>
        /// This is used to put the data into loadable format and stores the day
        /// </summary>
        public int day
        {
            get => TimeOf.Day;
            set => TimeOf = new LocalDate(TimeOf.Era, TimeOf.YearOfEra, TimeOf.Month, value);
        }
        [BsonIgnore]
        [JsonIgnore]
        public LocalDate ValidTill { get; set; }
        /// <summary>
        /// This is used to put the date into a loadable format and stores the year and era
        /// </summary>
        public int yearTill
        {
            get => ValidTill.Year;
            set
            {
                var era = NodaTime.Calendars.Era.Common;
                var year = value;
                if (value < 0)
                {
                    year = year * -1;
                    era = NodaTime.Calendars.Era.BeforeCommon;
                }
                ValidTill = new LocalDate(era, year, ValidTill.Month, ValidTill.Day);
            }

        }
        /// <summary>
        /// This is used to put the data into loadable format and stores the month
        /// </summary>
        public int monthTill
        {
            get => ValidTill.Month;
            set => ValidTill = new LocalDate(ValidTill.Era, ValidTill.YearOfEra, value, ValidTill.Day);
        }
        /// <summary>
        /// This is used to put the data into loadable format and stores the day
        /// </summary>
        public int dayTill
        {
            get => ValidTill.Day;
            set => ValidTill = new LocalDate(ValidTill.Era, ValidTill.YearOfEra, ValidTill.Month, value);
        }
        /// <summary>
        /// This stores an instance of colour for shading the borders
        /// </summary>
        [BsonIgnore]
        [JsonIgnore]
        public Color Colour;
        /// <summary>
        /// This stores the argb value of the colour for easier reclamation
        /// </summary>
        public int ColourARGB
        {
            get => Colour.ToArgb();
            set => Colour = Color.FromArgb(value);
        }

        /// <summary>
        /// This stores a list of all the points of the border
        /// </summary>
        [BsonIgnore]
        [JsonIgnore]
        public List<Point> AllPointsofBorder;
        /// <summary>
        /// This is a point list used for storing allPointsOfBorder
        /// </summary>
        public List<int> PointList
        {
            get => GetAllPointsAsIntList();
            set => SetAllPointsAsIntList(value);
        }
        /// <summary>
        /// This turns the points into an integer array
        /// </summary>
        /// <param name="allInts"></param>
        public void SetAllPointsAsIntList(List<int> allInts)
        {
            List<Point> localPointsList = new List<Point>();
            for (int i = 0; i < allInts.Count; i += 2)
            {
                localPointsList.Add(new Point(allInts[i], allInts[i+1]));
            }

            AllPointsofBorder = localPointsList;
        }
        /// <summary>
        /// This creates all the points required from an int list
        /// </summary>
        /// <returns></returns>
        public List<int> GetAllPointsAsIntList()
        {
            List<int> tempList = new List<int>();
            foreach (var point in AllPointsofBorder)
            {
                tempList.Add(point.X);
                tempList.Add(point.Y);
            }

            return tempList;
        }

        public BorderStorageClass()
        {
            TimeOf = new LocalDate();
            ValidTill = new LocalDate();
        }
        public BorderStorageClass(LocalDate time,Color colour, List<Point> allPointsofBorder)
        {

            Colour = colour;
            AllPointsofBorder = allPointsofBorder;
            TimeOf = time;
            _id = Guid.NewGuid().ToString();
            Verified = false;
        }

    }
}
