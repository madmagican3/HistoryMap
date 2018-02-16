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
    class BorderStorageClass
    {
        /// <summary>
        /// This says if this border has been verified by admins
        /// </summary>
        public Boolean verified { get; set; }

        /// <summary>
        /// The id for saving
        /// </summary>
        public string _id { get; set; }
        /// <summary>
        /// The date of this interesting point occuring
        /// </summary>
        [BsonIgnore]
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
        /// This contains a list of all the border points and the colour we should set them as
        /// </summary>
        public Dictionary<Color, List<Point>> BorderPointDictionary { get; set; }

        public BorderStorageClass()
        {
        }
        public BorderStorageClass(LocalDate time,Dictionary<Color, List<Point>> dictionary)
        {
            this.BorderPointDictionary = dictionary;
            this.timeOf = time;
            _id = System.Guid.NewGuid().ToString();
            verified = false;
        }

    }
}
