using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace SQLManager
{

    class Database
    {
        public string Message { get; private set; }
        public string DatabaseName { get; private set; }
        public string ServerName { get; private set; }
        public static bool Connected = false;

        private string InfoMessage;
        private string ConnectionString;
        

        //DEFAULT CONSTRUCTOR
        public Database()
        {   
            string connectionMask = "Data Source={0}; Initial Catalog={1}; Integrated Security={2}; User Id={3}; Password={4}";
            
            try
            {
                DatabaseConfiguration dbConfig = new DatabaseConfiguration();
                Dictionary<string, string> connectionData = dbConfig.getConnectionData();

                ServerName = connectionData["serverName"];
                DatabaseName = connectionData["database"];

                ConnectionString = string.Format(connectionMask,
                                                    ServerName,
                                                    DatabaseName,
                                                    connectionData["integratedSecurity"],
                                                    connectionData["username"],
                                                    connectionData["password"]
                                                );              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public string queryFilter(string query)
        {
            string output = Regex.Replace(query, @"(^|\s|\n)(?:go[\s;])", " ", RegexOptions.IgnoreCase);

            return output;
        }

        //QUERY EXECUTION
        public DataTable query(string query)
        {
            DataTable dt = new DataTable();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    conn.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);

                    using (SqlCommand cmd = new SqlCommand(queryFilter(query), conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);                        
                        conn.Close();                      
                    }                    

                    if (dt.Columns.Count>0)
                    {
                        Message += string.Format("({0} row(s) affected)" + Environment.NewLine, dt.Rows.Count.ToString());
                    }
                    else
                    {
                        Message += "Command(s) completed successfully" + Environment.NewLine;
                    }

                        Message += InfoMessage;

                    //Buscar el ultimo cambio de base de datos de sentencias sql USE
                    var regex = new Regex(@"(^|\s|\n)(?:use\s)(?<dbname>\b\S+\b)", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
                    var matchCollection = regex.Matches(query);

                    if (matchCollection.Count > 0)
                    {
                        DatabaseName = matchCollection[0].Groups["dbname"].Value;
                        DatabaseConfiguration dbConfig = new DatabaseConfiguration();
                        dbConfig.setDatabase(DatabaseName);
                        SqlConnection.ClearPool(conn);
                    }

                }

            }
            catch (Exception ex)
            {
                Message += ex.Message;
            }

            return dt;
        }

        //Obtener Info Message de Sql Server
        void OnInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            InfoMessage += e.Message + Environment.NewLine;
        }


        //VERIFICAR CONEXION
        public bool isConnected()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT 1", conn))
                    {
                        cmd.ExecuteScalar();
                        Connected = true;
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Connected = false;
            }

            return Connected;
        }


    }
}
