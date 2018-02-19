using System;

namespace HistoryMap.Shared_Classes
{
    internal class HiddenVars
    {
        private String connectionString = "mongodb://80.240.137.162:27017";
       // private String connectionString = String.Format("mongodb://localhost:27017");

        public String GetConnectionString()
        {
            return connectionString;
        }
    }
}
