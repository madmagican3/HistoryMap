using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HistoryMap.Shared_Classes
{
    internal class HiddenVars
    {
        private String connectionString = string.Format("mongodb://80.240.137.162:27017");


        public String GetConnectionString()
        {
            return connectionString;
        }
    }
}
