using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HistoryMap.Shared_Classes
{
    class GenericWebWrapper
    {
        private readonly string _creds;

        private const string _baseurl = "http://localhost:3000/";


        public GenericWebWrapper(string user, string password)
        {
            TestConnection(user, password);

            _creds = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{user}:{password}"));
        }

        private void TestConnection(string user, string password)
        {
            var req = (HttpWebRequest)WebRequest.Create("");

        }
        public async Task<bool> CreateRecord<T>(T obj)
        {
            var req = (HttpWebRequest)WebRequest.Create($"{_baseurl}/{GetObjectType(obj)}/create");
            AddAuthorizationHeader(req);

            //Write the json

            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                writer.Write(json);
                writer.Flush();
                writer.Close();
            }

            //Get the response & check insert happened successfully
            using (var response = (HttpWebResponse)req.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                    return (await reader.ReadToEndAsync()) == "true";
            }
        }

        private void AddAuthorizationHeader(HttpWebRequest req)
        {
            req.Headers.Add("Authorization", $"Basic {_creds}");
        }

        public async Task<List<T>> View<T>()
        {
            var req = (HttpWebRequest)WebRequest.Create($"{_baseurl}/{GetObjectType(typeof(T))}/view");
            AddAuthorizationHeader(req);

            string json;
            using (var response = (HttpWebResponse)req.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    json = await reader.ReadToEndAsync();
                }
            }

            if (json == null)
                throw new ApplicationException($"Null json while viewing {GetObjectType(typeof(T))}");

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(json);


        }
        private static string GetObjectType(object t)
        {
            switch (t)
            {
                case GenericLabelForWorldMap gl:
                    return "label";
                case BorderStorageClass bsc:
                    return "border";
                default:
                    throw new ArgumentOutOfRangeException($"Unknown object type {t.GetType().Name}");
            }
        }
    }
}
