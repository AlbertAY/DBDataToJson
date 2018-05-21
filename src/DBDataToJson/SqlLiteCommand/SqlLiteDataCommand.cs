using DBDataToJson.SqlLiteCommand.SqlLiteModel;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DBDataToJson.SqlLiteCommand
{
    internal class SqlLiteDataCommand
    {
        /// <summary>
        /// 插入数据库连接日志
        /// </summary>
        public static void InsertDBStringLog(DBStringLog dbStringLog, SQLiteConnection conn)
        {
            string sql = "INSERT INTO DBStringLog(DBString,CreateTime) VALUES (@DBString,@CreateTime)";
            conn.Execute(sql, dbStringLog);
        }
        
        //private static bool DBStringHas(string dbString, SQLiteConnection conn)
        //{
        //    string sql = "";
        //}

        /// <summary>
        /// 插入sql语句日志
        /// </summary>
        public static void InsertSqlStringLog(SqlStringLog sqlStringLog, SQLiteConnection conn)
        {
            string sql = "INSERT INTO SqlStringLog(SqlString,DBStringID,CreateTime) VALUES (@SqlString,@DBStringID,@CreateTime)";
            conn.Execute(sql, sqlStringLog);
        }

        //private static bool SqlStringHas(string sqlString, SQLiteConnection conn)
        //{
        //    string sql = "";
        //}

        /// <summary>
        /// 获取最新的一条数据库连接
        /// </summary>
        /// <returns></returns>
        public static string GetNewDBStringLog(SQLiteConnection conn)
        {
            string sql = @"SELECT DBString
                              FROM DBStringLog
                             ORDER BY createtime DESC
                             LIMIT 0, 1";

            return conn.ExecuteScalar<string>(sql);
        }

        public static string GetNewSqlStringLog(SQLiteConnection conn)
        {
            string sql = @"SELECT SqlString
                        FROM SqlStringLog
                        ORDER BY createtime DESC
                        LIMIT 0, 1";
            return conn.ExecuteScalar<string >(sql);
        }

    }
}
