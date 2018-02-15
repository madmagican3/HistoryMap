using MongoDB.Bson.Serialization.Attributes;
using NodaTime;
using NodaTime.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace HistoryMap.Shared_Classes
{
    public class GenericLabelForWorldMap
    {
        public string _id { get; set; }
        /// <summary>
        /// This should mark the center point of the button
        /// </summary>
        [BsonIgnore]
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
        /// * * for headings, | for enviroment.newline
        /// </summary>

        //TODO make sure you warn the user that they should not use these chars
        public Dictionary<string, string> Text { get; set; }
        /// <summary>
        /// This should be a ID for the list
        /// </summary>
        public string name { get; set; }
        [BsonIgnore]
        public LocalDate timeOf { get; set; }

        private const string NodaTimeFormat = "gg yyyy MM dd";

        public string _dateString
        {
            get => timeOf.ToString(NodaTimeFormat, CultureInfo.InvariantCulture);
            set => timeOf = LocalDatePattern.CreateWithInvariantCulture(NodaTimeFormat).Parse(value).Value;
        }

        public List<int> _pointString
        {
            get => new List<int> { ButtonCenterPoint.X, ButtonCenterPoint.Y };
            set => ButtonCenterPoint = new Point(value[0], value[1]);
        }

        public GenericLabelForWorldMap()
        {

        }
        public GenericLabelForWorldMap(LocalDate time, Point buttonCenterPoint, string type, Dictionary<string, string> text, int height, int width, string id, bool verified)
        {
            this.ButtonCenterPoint = buttonCenterPoint;
            this.Type = type;
            this.Text = text;
            this.Height = height;
            this.Width = width;
            this.name = id;
            this.timeOf = time;
            _id = System.Guid.NewGuid().ToString();
        }

    }
}
