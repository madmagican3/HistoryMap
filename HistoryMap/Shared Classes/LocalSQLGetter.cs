using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using NodaTime;
using MongoDB.Driver;
using Newtonsoft;
using Newtonsoft.Json;
using MongoDB.Bson;
using NodaTime.Text;
using NodaTime.Calendars;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json.Linq;

namespace HistoryMap.Shared_Classes
{
    class LocalSqlGetter
    {
        public static Dictionary<Color, List<Point>> GetCountries(DateTime currentTime)
        {
            return new Dictionary<Color, List<Point>>()
            {
                {
                    Color.Blue, new List<Point>()
                    {
                        new Point(0,0),new Point(0,200), new Point (20,200), new Point(200,200), new Point(0,50)
                    }
                }
            };
        }



        /// <summary>
        /// This gets the list of buttons and filters them
        /// </summary>
        /// <param name="startDate">The staring date we want to filter from</param>
        /// <param name="endDate">the end date we want to filter from</param>
        /// <returns>an array of genericlabelforworldmap forms</returns>
        public static List<GenericLabelForWorldMap> GetListFromDateSelection(LocalDate startDate,LocalDate endDate)
        {
            HiddenVars tempVars = new HiddenVars();
            List<GenericLabelForWorldMap> localList = new List<GenericLabelForWorldMap>();
            //create a new connection
            var connection = new MongoClient(tempVars.GetConnectionString());
            var database = connection.GetDatabase("WebProject");
            var collection = database.GetCollection<GenericLabelForWorldMap>("test3");

            var ResultList = collection.Find(_ => true).ToList();

            foreach (var result in ResultList)
            {

                if (!result.verified&&(result.timeOf >= startDate && result.timeOf <= endDate))//TODO reverse this verified thing
                {
                    localList.Add(result);
                }
               
            }
            return localList;
        }



        /// <summary>
        /// This will save the button item
        /// </summary>
        /// <param name="label">The button we want to save</param>
        internal static void addButton(GenericLabelForWorldMap label, LocalDate DateOfButton)
        {
            HiddenVars tempVars = new HiddenVars();
            //create a new connection
            var connection = new MongoClient(tempVars.GetConnectionString());
            var database = connection.GetDatabase("WebProject");
            var collection = database.GetCollection<GenericLabelForWorldMap>("test3");

            collection.InsertOne(label);          
        }
    }
}
