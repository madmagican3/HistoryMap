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
    class LocalMongoGetter
    {
        /// <summary>
        /// This gets all the countries borders which are valid till that specified time period
        /// </summary>
        /// <param name="currentTime"></param>
        /// <returns></returns>
        public static List<BorderStorageClass> GetCountries(LocalDate currentTime)
        {
            HiddenVars tempVars = new HiddenVars();
            List<BorderStorageClass> localList = new List<BorderStorageClass>();
            //create a new connection
            var connection = new MongoClient(tempVars.GetConnectionString());
            var database = connection.GetDatabase("HistoryMap");
            var collection = database.GetCollection<BorderStorageClass>("Border");

            var resultList = collection.Find(_ => true).ToList();

            foreach (var result in resultList)
            {

                if (!result.Verified && (result.TimeOf >= currentTime && result.ValidTill >= currentTime))//TODO reverse this verified thing
                {
                    localList.Add(result);
                }

            }
            return localList;
         
          
        }
        /// <summary>
        /// This saves the border
        /// </summary>
        /// <param name="borderToSave"></param>
        public static void SaveBorder(BorderStorageClass borderToSave)
        {
            HiddenVars tempVars = new HiddenVars();
            //create a new connection
            var connection = new MongoClient(tempVars.GetConnectionString());
            var database = connection.GetDatabase("HistoryMap");
            var collection = database.GetCollection<BorderStorageClass>("Border");

            collection.InsertOne(borderToSave);
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
            var database = connection.GetDatabase("HistoryMap");
            var collection = database.GetCollection<GenericLabelForWorldMap>("Button");

            var resultList = collection.Find(_ => true).ToList();

            foreach (var result in resultList)
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
        internal static void AddButton(GenericLabelForWorldMap label, LocalDate DateOfButton)
        {
            HiddenVars tempVars = new HiddenVars();
            //create a new connection
            var connection = new MongoClient(tempVars.GetConnectionString());
            var database = connection.GetDatabase("HistoryMap");
            var collection = database.GetCollection<GenericLabelForWorldMap>("Button");

            collection.InsertOne(label);          
        }
    }
}
