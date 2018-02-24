using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryMap.Shared_Classes
{
    public class UserClass
    {
        public string user { get; set; }
        public string pass { get; set; }

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
