using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Models
{
    public class AppSettings
    {
        public String MongoDbConnection { get; set; }
        public String MongoDbDatabaseName { get; set; }

        public int ListLimit { get; set; }
    }
}
