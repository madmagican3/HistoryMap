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
        public static Dictionary<Color, List<Point>> GetCountries(DateTime currentTime)
        {
            return null;
        }
        /// <summary>
        /// This takes the dataset and then selects the rows based on the command and passes the databset back
        /// </summary>
        /// <param name="command">This is the command run</param>
        /// <returns></returns>
        private static DataSet SelectRows(SqlCommand command)
        {
            //creates a new empty dataset and adapter
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();
            //set the adapter to use the command 
            adapter.SelectCommand = command;
            //then get the adapter to fill the dataset based on the returned values
            adapter.Fill(dataset);
            return dataset;
        }
        /// <summary>
        /// This gets the date id based on the current date
        /// </summary>
        /// <param name="currentTime">This is the current date</param>
        /// <returns></returns>
        private DataSet GetDateId(DateTime currentTime)
        {
            //This is the connection string, will probably be re-written soon for security purposes but unsure how to handle that currently (also no ports open so currently secure)
            var connectionString = "Data Source=192.168.1.83;Initial Catalog=History_Map;Integrated Security=SSPI;";
            //create a new connection
            using (var connection = new SqlConnection(connectionString))
            {
                //open that connection
                connection.Open();
                //create a new command
                using (var command = new SqlCommand(null, connection))
                {
                    //set that new command using a prepared statement
                    command.CommandText = "Select id from IMAGES where date = @date";
                    //safely put that paramater into the sql statement
                    var dateParam = new SqlParameter("@date", SqlDbType.Date) {Value = currentTime};
                    //prepare the new command
                    command.Prepare();
                    //get the dataset back and return it
                    var actualId = SelectRows( command);
                    return actualId;
                }
            }
        }

        private void testMethod()
        {
        }
    }
}
