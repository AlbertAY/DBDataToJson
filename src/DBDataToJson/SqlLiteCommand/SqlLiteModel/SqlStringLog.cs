using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDataToJson.SqlLiteCommand.SqlLiteModel
{
    public class SqlStringLog
    {
        public string SqlString { set; get; }

        public int DBStringID { set; get; }

        public DateTime CreateTime { set; get; }
    }
}
