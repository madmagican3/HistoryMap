using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryMap.Shared_Classes
{
    public class UserClass
    {
        /// <summary>
        /// This holds the users username for passing as an object
        /// </summary>
        public string user { get; set; }
        /// <summary>
        /// This holds the users password for passing as an object
        /// </summary>
        public string pass { get; set; }
        /// <summary>
        /// This holds the users _id for passing as an object
        /// </summary>
        public string _id { get; set; }

        public UserClass()
        {

        }
        public UserClass(String user, string pass)
        {
            this._id = Guid.NewGuid().ToString();
            this.user = user;
            this.pass = pass;
        }
    }
}
