using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DBDataToJson.SqlLiteCommand
{

    /// <summary>
    /// sqllite首次运行初始化相关表
    /// </summary>
    public class SqlLiteInit
    {

        public static bool hasDBStringTable = false;

        public static bool hasSqlStringTable = false;


        public static void Init(SQLiteConnection conn)
        {
            //数据库字符串表是否存在
            if (!hasDBStringTable)
            {
                hasDBStringTable = HasTable("DBStringLog", conn);
            }
            //sql日志表是否存在
            if (!hasSqlStringTable)
            {
                hasSqlStringTable = HasTable("SqlStringLog", conn);
            }
            CreateDBStringLogTable(conn);
            CreateSqlStringLogTable(conn);
        }


        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private static bool HasTable(string table, SQLiteConnection conn)
        {
            string sql = $"SELECT 1 FROM sqlite_master where type='table' and name='{table}'";
            return conn.ExecuteScalar<string>(sql)?.Equals("1") ?? false;

        }

        /// <summary>
        /// 创建用户数据库字符串表
        /// </summary>
        private static void CreateDBStringLogTable(SQLiteConnection conn)
        {
            if (!hasDBStringTable)
            {
                string sql = @"CREATE TABLE DBStringLog
                                        (
                                          DBString VARCHAR(200) ,
                                          CreateTime DATE
                                        )";
                conn.Execute(sql);
            }
        }

        /// <summary>
        /// sql语句表
        /// </summary>
        /// <param name="conn"></param>
        public static void CreateSqlStringLogTable(SQLiteConnection conn)
        {
            if (!hasSqlStringTable)
            {
                string sql = @"CREATE TABLE SqlStringLog
                            (
	                          SqlString VARCHAR(8000),
                              DBStringID INT ,
                              CreateTime DATE
                            )";
                conn.Execute(sql);
            }           
        }

    }
}
