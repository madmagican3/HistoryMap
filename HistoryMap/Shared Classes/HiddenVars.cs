using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HistoryMap.Shared_Classes
{
    class HiddenVars
    {
        private String connectionString = string.Format("server=80.240.137.162;" +
            "database=HistoryMap; " +
            "uid=root ; " +
            "password=Ange1_Beats;");

        public String GetConnectionString()
        {
            return connectionString;
        }
    }
}
