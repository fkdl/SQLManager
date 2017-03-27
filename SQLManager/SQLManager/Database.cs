using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace SQLManager
{
    class Database
    {
        private string connectionString;

        public Database()
        {   
            string connectionMask = "Data Source={0}\\SQLEXPRESS; Initial Catalog={1}; Integrated Security={2}; User ID={3}; Password={4}";

            try
            {
                Dictionary<string, string> connectionData = getConnectionData();

                connectionString = string.Format(connectionMask, connectionData["serverName"], connectionData["database"], connectionData["integratedSecurity"]);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            

        }

        public Database(string database)
        {
            string connectionMask = "Data Source={0}\\SQLEXPRESS; Initial Catalog={1}; Integrated Security={2}; User ID={3}; Password={4}";

            try
            {
                Dictionary<string, string> connectionData = getConnectionData();

                connectionString = string.Format(connectionMask, connectionData["serverName"], database, connectionData["integratedSecurity"]);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }
        
        private Dictionary<string, string> getConnectionData()
        {
            Dictionary<string, string> connectionData = null;
            try
            {
                string serverName = ConfigurationManager.AppSettings["ServerName"];
                string database = ConfigurationManager.AppSettings["Database"];
                string integratedSecurity = ConfigurationManager.AppSettings["IntegratedSecurity"];
                string username = ConfigurationManager.AppSettings["Username"];
                string password = ConfigurationManager.AppSettings["Passwprd"];

                 connectionData = new Dictionary<string, string>
                {
                    { "serverName", serverName },
                    { "database", database },
                    { "integratedSecurity", integratedSecurity },
                    { "username", username },
                    { "password", password }
                };
                
            }
            catch
            {
                throw;
            }

            return connectionData;
        }

        public DataTable query(string query, out string msg)
        {
            DataTable dt = new DataTable();
            msg = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return dt;
        }

        public bool isConnected()
        {
            try
            {
                using (conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Connection Successful.");
                    using (SqlCommand cmd = new SqlCommand("SELECT 1", conn))
                    {
                        cmd.ExecuteScalar();
                        Console.WriteLine("Sql Query Execution Successful.");
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure", ex.Message);
                return false;
            }
        }
        
       

        public DataTable getRows()
        {
            DataTable rows = new DataTable();
            
            string query = "SELECT * FROM DEPARTAMENTOS";
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.WriteLine(reader.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(rows);
                        return rows;
                    }
                }
                
            }
 
        }


    }
}
