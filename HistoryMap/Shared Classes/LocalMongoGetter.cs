using System;
using System.Collections.Generic;
using NodaTime;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace HistoryMap.Shared_Classes
{
    class LocalMongoGetter
    {
        private static HistoryMapWebClient _client;
        public LocalMongoGetter()
        {
            _client = new HistoryMapWebClient("defaultUser", "ry3kGKijkF12Abwxczm1");
        }
        /// <summary>
        /// This gets all the countries borders which are valid till that specified time period
        /// </summary>
        /// <param name="currentTime"></param>
        /// <returns></returns>
        public static List<BorderStorageClass> GetCountries(LocalDate currentTime)
        {
            if (_client == null)
            {
                _client = new HistoryMapWebClient("defaultUser", "ry3kGKijkF12Abwxczm1");
            }
            var result = _client.GetBorders(currentTime).GetAwaiter().GetResult();
            var list = new List<BorderStorageClass>();
            foreach (var item in result)
            {
                if (item.Verified)
                    list.Add(item);
            }
            return list;
        }

        public static List<BorderStorageClass> GetCountries(bool all, HistoryMapWebClient client)
        {
            var result = client.GetBorders().GetAwaiter().GetResult();
            List<int> indexesToRemove = new List<int>();
            if (!all)
            {
                foreach (var button in result)
                {
                    if (button.Verified)
                    {
                        indexesToRemove.Add(result.IndexOf(button));
                    }
                }
                int i = 0;
                foreach (var index in indexesToRemove)
                {
                    result.RemoveAt(index - i);
                    i++;
                }
            }

          
            return result;
        }
        /// <summary>
        /// This saves the border
        /// </summary>
        /// <param name="borderToSave"></param>
        public static void SaveBorder(BorderStorageClass borderToSave)
        {
            if (_client == null)
            {
                _client = new HistoryMapWebClient("defaultUser", "ry3kGKijkF12Abwxczm1");
            }

            _client.CreateRecord(borderToSave).GetAwaiter();
        }



        /// <summary>
        /// This gets the list of buttons and filters them
        /// </summary>
        /// <param name="startDate">The staring date we want to filter from</param>
        /// <param name="endDate">the end date we want to filter from</param>
        /// <returns>an array of genericlabelforworldmap forms</returns>
        public static List<GenericLabelForWorldMap> GetListFromDateSelection(LocalDate startDate,LocalDate endDate)
        {
            if (_client == null)
            {
                _client = new HistoryMapWebClient("defaultUser", "ry3kGKijkF12Abwxczm1");
            }
            var result = _client.GetButtons(startDate,endDate).GetAwaiter().GetResult();
            var list = new List<GenericLabelForWorldMap>();
            foreach (var item in result)
            {
                if (item.verified) 
                    list.Add(item);
            }
            return list;
        }

        public static List<GenericLabelForWorldMap> GetListFromDateSelection(bool all, HistoryMapWebClient client)
        {
            var result = client.GetButtons().GetAwaiter().GetResult();
            List <int> indexesToRemove = new List<int>();
            if (!all)
            {
                foreach (var button in result)
                {
                    if (button.verified)
                    {
                        indexesToRemove.Add(result.IndexOf(button));
                    }
                }
                int i = 0;
                foreach (var index in indexesToRemove)
                {
                    result.RemoveAt(index - i);
                    i++;
                }
            }


            return result;
        }


        /// <summary>
        /// This will save the button item
        /// </summary>
        /// <param name="label">The button we want to save</param>
        /// <param name="dateOfButton">The date we're looking for</param>
        internal static void AddButton(GenericLabelForWorldMap label, LocalDate dateOfButton)
        {
            if (_client == null)
            {
                _client = new HistoryMapWebClient("defaultUser", "ry3kGKijkF12Abwxczm1");
            }

            _client.CreateRecord(label).GetAwaiter();
        }
    }
}
