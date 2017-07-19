using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryMap.Shared_Classes
{
    class LocalSqlGetter
    {
        public static Dictionary<Color, List<Point>> getCountries(DateTime currentTime)
        {
            string connectionString = "Data Source=192.168.1.83;Initial Catalog=History_Map;Integrated Security=SSPI;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(null, connection))
                {
                    command.CommandText = "Select id from IMAGES where date = @date";
                    SqlParameter dateParam = new SqlParameter("@date",SqlDbType.Date);
                    dateParam.Value = currentTime;

                    command.Prepare();

                    DataSet actualId = SelectRows(new DataSet(), command);
                }
            }
            return null;
        }

        private static DataSet SelectRows(DataSet dataset, SqlCommand command)
        {

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dataset);
                return dataset;
        }
    }
}
