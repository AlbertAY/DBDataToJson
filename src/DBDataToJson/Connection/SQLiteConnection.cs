using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDataToJson.SqlLiteCommand
{
    public class SQLiteConnectionCreate
    {

        private string _dbpath;
        private SQLiteConnection _conn;
        /// <summary>  
        /// SQLite连接  
        /// </summary>  
        internal SQLiteConnection Conn
        {
            get
            {
                if (_conn == null)
                {
                    _conn = new SQLiteConnection(
                        string.Format("Data Source={0};Version=3;",
                        this._dbpath
                        ));
                    _conn.Open();
                }
                return _conn;
            }
        }

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="dbpath">sqlite数据库文件路径，相对/绝对路径</param>  
        internal SQLiteConnectionCreate()
        {
            string dbpath = ConfigurationManager.AppSettings["sqlLitePath"];
            if (Path.IsPathRooted(dbpath))
            {
                this._dbpath = dbpath;
            }
            else
            {
                this._dbpath = string.Format("{0}/{1}", AppDomain.CurrentDomain.SetupInformation.ApplicationBase, dbpath);
            }
        }
    }
}
