using System;
using System.Net.Http;
using System.Net.Http.Headers;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace HistoryMap.Shared_Classes
{
    internal class HiddenVars
    {
       // private String connectionString = "mongodb://80.240.137.162:27017";
        private String connectionString = String.Format("mongodb://localhost:27017");
        private static readonly HttpClient client = new HttpClient();

        public async System.Threading.Tasks.Task<HttpClient> getHttpAsync()
        {
            client.BaseAddress =  new Uri("http://localhost:3000");


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                        System.Text.Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "admin", "andrewb11"))));


            var response = await client.GetAsync("/button/view");
            var tempResult = response.Content.ReadAsStringAsync();
            var jsonList = JsonConvert.DeserializeObject<GenericLabelForWorldMap>(tempResult.Result);
            Console.Write("Dicks");
            return client;
        }


        public String GetConnectionString()
        {
            return connectionString;
        }
    }
}
