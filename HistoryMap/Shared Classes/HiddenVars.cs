using System;
using System.Net.Http;
using System.Net.Http.Headers;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace HistoryMap.Shared_Classes
{
    internal class HiddenVars
    {
        //private String connectionString = "mongodb://80.240.137.162:27017";
        private String connectionString = String.Format("mongodb://localhost:27017");

        public readonly string Username = "defaultUser";
        public readonly string Password = "ry3kGKijkF12Abwxczm1";

        public String GetConnectionString()
        {
            return connectionString;
        }
    }
}
