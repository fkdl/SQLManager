using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SQLManager
{
    class DatabaseConfiguration
    {
        public DatabaseConfiguration()
        {

        }

        public Dictionary<string, string> getConnectionData()
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

        public void setDatabase(string database)
        {
            try
            {
                ConfigurationManager.AppSettings["Database"] = database; 
            }
            catch
            {
                throw;
            }
            
        }

        public void updateAttribute(string key, string value)
        {
            try
            {
                ConfigurationManager.AppSettings[key] = value;
            }
            catch
            {
                throw;
            }
        }

    }
}
