using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using NodaTime;
using NodaTime.Text;

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
        public LocalDate TimeOf { get; set; }
        /// <summary>
        /// This is used to format the string correctly when saving it to the db
        /// </summary>
        private const string NodaTimeFormat = "gg yyyy MM dd";
        /// <summary>
        /// This is used to put the date into a loadable format
        /// </summary>
        public string DateString
        {
            get => TimeOf.ToString(NodaTimeFormat, CultureInfo.InvariantCulture);
            set => TimeOf = LocalDatePattern.CreateWithInvariantCulture(NodaTimeFormat).Parse(value).Value;
        }
        [BsonIgnore]
        public LocalDate ValidTill { get; set; }
        public string ValidTillDateString
        {
            get => ValidTill.ToString(NodaTimeFormat, CultureInfo.InvariantCulture);
            set => ValidTill = LocalDatePattern.CreateWithInvariantCulture(NodaTimeFormat).Parse(value).Value;
        }
        /// <summary>
        /// This stores an instance of colour for shading the borders
        /// </summary>
        [BsonIgnore]
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
        }
        public BorderStorageClass(LocalDate time,Color colour, List<Point> allPointsofBorder)
        {

            this.Colour = colour;
            this.AllPointsofBorder = allPointsofBorder;
            this.TimeOf = time;
            _id = System.Guid.NewGuid().ToString();
            Verified = false;
        }

    }
}
