using System;
using System.Collections.Generic;
using System.Net;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using NodaTime;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using Newtonsoft;

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
            //tempVars.getHttpAsync();
            List<BorderStorageClass> localList = new List<BorderStorageClass>();
            //create a new connection
            var connection = new MongoClient(tempVars.GetConnectionString());
            var database = connection.GetDatabase("HistoryMap");
            var collection = database.GetCollection<BorderStorageClass>("Border");

            var resultList = collection.Find(_ => true).ToList();

            foreach (var result in resultList)
            {

                if (!result.Verified && (result.TimeOf <= currentTime && result.ValidTill >= currentTime))//TODO reverse this verified thing
                {
                    localList.Add(result);
                }

            }
            return localList;
         
          
        }

        public static List<BorderStorageClass> GetCountries()
        {
            HiddenVars tempVars = new HiddenVars();
            //tempVars.getHttpAsync();
            List<BorderStorageClass> localList = new List<BorderStorageClass>();
            //create a new connection
            var connection = new MongoClient(tempVars.GetConnectionString());
            var database = connection.GetDatabase("HistoryMap");
            var collection = database.GetCollection<BorderStorageClass>("Border");

            var resultList = collection.Find(_ => true).ToList();
            var fullReturn = new List<BorderStorageClass>();
            foreach (var result in resultList)
            {
                if (!result.Verified)
                {
                    fullReturn.Add(result);
                }
            }
            return fullReturn;
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

        public static List<GenericLabelForWorldMap> GetListFromDateSelection()
        {
            HiddenVars tempVars = new HiddenVars();
            List<GenericLabelForWorldMap> localList = new List<GenericLabelForWorldMap>();
            //create a new connection
            var connection = new MongoClient(tempVars.GetConnectionString());
            var database = connection.GetDatabase("HistoryMap");
            var collection = database.GetCollection<GenericLabelForWorldMap>("Button");

            var resultList = collection.Find(_ => true).ToList();
            var fullReturn = new List<GenericLabelForWorldMap>();
            foreach (var result in resultList)
            {
                if (!result.verified)
                {
                    fullReturn.Add(result);
                }
            }
            return fullReturn;
        }


        /// <summary>
        /// This will save the button item
        /// </summary>
        /// <param name="label">The button we want to save</param>
        /// <param name="dateOfButton">The date we're looking for</param>
        internal static void AddButton(GenericLabelForWorldMap label, LocalDate dateOfButton)
        {

            var tempObject = JObject.FromObject(label);
            Console.WriteLine(tempObject);
            HiddenVars tempVars = new HiddenVars();
            //create a new connection
            var connection = new MongoClient(tempVars.GetConnectionString());
            var database = connection.GetDatabase("HistoryMap");
            var collection = database.GetCollection<GenericLabelForWorldMap>("Button");

            collection.InsertOne(label);          
        }
    }
}
