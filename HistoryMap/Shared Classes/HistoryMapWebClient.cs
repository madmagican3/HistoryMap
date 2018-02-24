using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using NodaTime;

namespace HistoryMap.Shared_Classes
{
    public class HistoryMapWebClient
    {
        /// <summary>
        /// This is the base url of the website we want to connect too
        /// </summary>
        private const string _baseurl = "https://historymap.madmagican3.co.uk:3000";//TODO modify to the website when it's setup
        /// <summary>
        /// This is the credentials we're going to use
        /// </summary>
        private readonly string _creds;
        /// <summary>
        /// This is a local instance of the username field so that we can use it where required
        /// </summary>
        public string username;

        /// <summary>
        /// This sets the username and password as credentials then tests the connection to see if they're correct
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public HistoryMapWebClient(string user, string password)
        {
            username = user;
            _creds = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{password}"));

            TestConnection();
        }

        /// <summary>
        /// This allows you to test a connection to see if it's working correctly before trying to use the site
        /// </summary>
        private void TestConnection()
        {
            var req = (HttpWebRequest)WebRequest.Create($"{_baseurl}/checkLogin");
            AddAuthorizationHeader(req);//create the web request and set the credentials

            try
            {
                using (var response = (HttpWebResponse)req.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK) //if the web request didnt work
                        throw new Exception("Login status code is not 'OK'");
                }
            }
            catch (WebException we) //if we where unauthed
            {
                var res = we.Response as HttpWebResponse;
                if (res?.StatusCode == HttpStatusCode.Unauthorized)
                    throw new Exception("Incorrect username/password combination, or user doesn't exist");
                throw;
            }
        }

        /// <summary>
        /// adds the specified authorisation headers
        /// </summary>
        /// <param name="req">the web request specified</param>
        private void AddAuthorizationHeader(WebRequest req)
        {
            req.Headers.Add("Authorization", $"Basic {_creds}");
        }
        /// <summary>
        /// This allows you to create a record of any value
        /// </summary>
        /// <typeparam name="T">The type param for this instance</typeparam>
        /// <param name="obj">The object we want to save</param>
        /// <returns></returns>
        public async Task<JsonResponse> CreateRecord<T>(T obj)
        {
            return await Post(obj, "", "Create");
        }
        /// <summary>
        /// This allows you to update a record
        /// </summary>
        /// <typeparam name="T">The type param for this instance</typeparam>
        /// <param name="obj">The object we want to save</param>
        /// <returns></returns>
        public async Task<JsonResponse> UpdateRecord<T>(T obj)
        {
            return await Post(obj, "", "Update");
        }

        #region Delete
        /// <summary>
        /// This is a delete post
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<JsonResponse> Delete<T>(string id)
        {
            return await Post(default(T), $"_id={id}", "Delete");
        }

        #endregion
        /// <summary>
        /// This allows posting of the data we need 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="query"></param>
        /// <param name="urlMethod"></param>
        /// <returns></returns>
        public async Task<JsonResponse> Post<T>(T t, string query, string urlMethod)
        {
            var req = (HttpWebRequest)WebRequest.Create($"{_baseurl}/{GetObjectType(typeof(T))}/{urlMethod}?{query}");
            AddAuthorizationHeader(req);
            req.MediaType = "application/json; charset=utf-8";
            req.Method = "POST";
            if (t != null)
                using (var writer = new StreamWriter(req.GetRequestStream()))
                {
                    var json = JsonConvert.SerializeObject(t);
                    Console.WriteLine(json);
                    writer.Write(json);
                    writer.Flush();
                    writer.Close();
                }

            req.ContentType = "application/json; charset=utf-8";
            string receivedJson;
            using (var response = (HttpWebResponse)req.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    receivedJson = await reader.ReadToEndAsync();
                }
            }

            if (receivedJson == null)
                throw new ApplicationException($"Null json while viewing {GetObjectType(typeof(T))}");
            return JsonConvert.DeserializeObject<JsonResponse>(receivedJson);
        }
        /// <summary>
        /// This assigns types to properley construct the web system
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static string GetObjectType(Type t)
        {
            if (t == typeof(GenericLabelForWorldMap))
                return "button";
            if (t == typeof(BorderStorageClass))
                return "border";
            if (t == typeof(UserClass))
                return "users";
            throw new ArgumentOutOfRangeException($"Unknown object type {t.GetType().Name}");
        }

        #region Getters
        /// <summary>
        /// This allows you To get view objects based on the type
        /// </summary>
        /// <typeparam name="T">The type of object we're searching for</typeparam>
        /// <param name="query">The query we're lkooking for</param>
        /// <returns></returns>
        public async Task<List<T>> View<T>(string query)
        {
            var req = (HttpWebRequest)WebRequest.Create($"{_baseurl}/{GetObjectType(typeof(T))}/view?{query}");
            AddAuthorizationHeader(req);
            req.MediaType = "application/json; charset=utf-8";//sets up the web request

            string json;
            using (var response = (HttpWebResponse)req.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    json = reader.ReadToEnd(); //read a response code
                }
            }

            if (json == null)//if error
                throw new ApplicationException($"Null json while viewing {GetObjectType(typeof(T))}");

            return JsonConvert.DeserializeObject<List<T>>(json);
        }
        /// <summary>
        /// This allows you to get all the borders we've created thus far
        /// </summary>
        /// <returns></returns>
        public async Task<List<BorderStorageClass>> GetBorders()
        {
            return await View<BorderStorageClass>("all=true");
        }
        /// <summary>
        /// This allows you to get the borders with the specified date as the base
        /// </summary>
        /// <param name="date">The date we're searching for</param>
        /// <returns></returns>
        public async Task<List<BorderStorageClass>> GetBorders(LocalDate date)
        {
            var sd1 = date.ToString("gg yyyy MM dd", CultureInfo.InvariantCulture);
            var query = $"currentTime={sd1}"; //sd1+"&" + sd2;
            return await View<BorderStorageClass>(query);
        }

        public async Task<List<UserClass>> getUsers()
        {
            return await View<UserClass>("");
        }

        /// <summary>
        /// If we want to get all the buttons we call this one (this should only be referenced for admin)
        /// </summary>
        /// <returns></returns>
        public async Task<List<GenericLabelForWorldMap>> GetButtons()
        {
            return await View<GenericLabelForWorldMap>("all=true");
        }
        /// <summary>
        /// This allows you to get the buttons based on the start date and end date
        /// </summary>
        /// <param name="startDate">the date we want to select from</param>
        /// <param name="endDate">the date we want to select till</param>
        /// <returns></returns>
        public async Task<List<GenericLabelForWorldMap>> GetButtons(LocalDate startDate, LocalDate endDate)
        {
            var sd1 = startDate.ToString("gg yyyy MM dd", CultureInfo.InvariantCulture);
            var sd2 = endDate.ToString("gg yyyy MM dd", CultureInfo.InvariantCulture);

            var query = $"startDate={sd1}&endDate={sd2}";

            return await View<GenericLabelForWorldMap>(query);
        }

        #endregion
    }
    /// <summary>
    /// This sets up the json response codes
    /// </summary>
    public class JsonResponse
    {
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}