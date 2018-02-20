using MongoDB.Bson.Serialization.Attributes;
using NodaTime;
using NodaTime.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using Newtonsoft.Json;

namespace HistoryMap.Shared_Classes
{
    public class GenericLabelForWorldMap
    {
        /// <summary>
        /// This bool is used for saying if the data is verified by an admin
        /// </summary>
        public bool verified { get; set; }
        /// <summary>
        /// The id for saving
        /// </summary>
        public string _id { get; set; }
        /// <summary>
        /// This should mark the center point of the button
        /// </summary>
        [BsonIgnore]
        [JsonIgnore]
        public Point ButtonCenterPoint { get; set; }
        /// <summary>
        /// This is the width of the icon
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// this is the height of the icon
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        ///  this should mark the type for easier checking to see if the image is correct
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// This should be the full statement the user should be displayed. 
        /// </summary>
        public Dictionary<string, string> Text { get; set; }
        /// <summary>
        /// This should be a ID for the list
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// The date of this interesting point occuring
        /// </summary>
        [BsonIgnore]
        [JsonIgnore]
        public LocalDate timeOf { get; set; }
        /// <summary>
        /// This is used to format the string correctly when saving it to the db
        /// </summary>
        private const string NodaTimeFormat = "gg yyyy MM dd";
        /// <summary>
        /// This is used to put the date into a loadable format
        /// </summary>
        public string _dateString
        {
            get => timeOf.ToString(NodaTimeFormat, CultureInfo.InvariantCulture);
            set => timeOf = LocalDatePattern.CreateWithInvariantCulture(NodaTimeFormat).Parse(value).Value;
        }
        /// <summary>
        /// This is used for loading the point into a loadable format
        /// </summary>
        public List<int> _pointString
        {
            get => new List<int> { ButtonCenterPoint.X, ButtonCenterPoint.Y };
            set => ButtonCenterPoint = new Point(value[0], value[1]);
        }

        public GenericLabelForWorldMap()
        {
        }
        public GenericLabelForWorldMap(LocalDate time, Point buttonCenterPoint, string type, Dictionary<string, string> text, int height, int width, string id)
        {
            ButtonCenterPoint = buttonCenterPoint;
            Type = type;
            Text = text;
            Height = height;
            Width = width;
            name = id;
            timeOf = time;
            _id = System.Guid.NewGuid().ToString();
            verified = false;
        }

    }
}
