using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDataToJson
{
    public class ConnectionCreate
    {
        public static IDbConnection GetDBConection(string str)
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            return conn;
        }
    }
}
