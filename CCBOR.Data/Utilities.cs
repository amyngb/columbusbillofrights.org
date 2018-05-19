using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCBOR.Data
{
    class Utilities
    {
        public static String GetConnectionString()
        {
            String connectionString = String.Empty;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return connectionString;
        }
    }
}
