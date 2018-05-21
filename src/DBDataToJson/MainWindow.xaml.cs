using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dapper;
using DBDataToJson.SqlLiteCommand;
using DBDataToJson.SqlLiteCommand.SqlLiteModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DBDataToJson
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitSqlLite();
            InitTextValue();
            this.btnSearch.Click += btnSearch_Click;
            this.btnCopy.Click += btnCopy_Click;
        }
        SQLiteConnectionCreate sqliteConnectionCreate = new SQLiteConnectionCreate();
        public void InitSqlLite()
        {
            SqlLiteInit.Init(sqliteConnectionCreate.Conn);
        }

        /// <summary>
        /// 初始化相关控制的值，取最近的一条记录
        /// </summary>
        public void InitTextValue()
        {
            txtDbString.Text = SqlLiteDataCommand.GetNewDBStringLog(sqliteConnectionCreate.Conn);
            txtSqlString.Text = SqlLiteDataCommand.GetNewSqlStringLog(sqliteConnectionCreate.Conn);
        }


        /// <summary>
        /// 查询点击事件,todo此处需要改成异步的，否则长时间的查询会造成假死
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string conString = txtDbString.Text?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(conString))
                {
                    MessageBox.Show("数据库字符串不能为空");
                    return;
                }
                string sqlString = txtSqlString.Text?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(sqlString))
                {
                    MessageBox.Show("请输入sql语句");
                    return;
                }
                SqlLiteDataCommand.InsertDBStringLog(new DBStringLog() { DBString = conString, CreateTime = DateTime.Now }, sqliteConnectionCreate.Conn);
                SqlLiteDataCommand.InsertSqlStringLog(new SqlStringLog() { SqlString = sqlString, DBStringID = 1, CreateTime = DateTime.Now }, sqliteConnectionCreate.Conn);

                DataTable dataTable = new DataTable();
                using (IDbConnection conn = ConnectionCreate.GetDBConection(conString))
                {
                    dataTable.Load(conn.ExecuteReader(sqlString));
                }
                string result = JsonConvert.SerializeObject(dataTable, new DataTableConverter());
                txtJsonString.Text = ConvertJsonString(result);
            }
            catch (Exception ex)
            {
                txtJsonString.Text = ex.ToString();
            }
        }
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            CopyToClipboard(txtJsonString.Text,false);
        }

        /// <summary>
        /// 复制或剪切文件到剪切板
        /// </summary>
        /// <param name="files">文件路径数组</param>
        /// <param name="cut">true:剪切；false:复制</param>
        public static void CopyToClipboard(string txt, bool cut)
        {
            if (txt == null) return;
            IDataObject data = new DataObject(DataFormats.Text, txt);
            MemoryStream memo = new MemoryStream(4);
            byte[] bytes = new byte[] { (byte)(cut ? 2 : 5), 0, 0, 0 };
            memo.Write(bytes, 0, bytes.Length);
            data.SetData("PreferredDropEffect", memo);
            Clipboard.SetDataObject(data, false);
        }
        /// <summary>
        /// 格式化json字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string ConvertJsonString(string str)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }
    }
}
