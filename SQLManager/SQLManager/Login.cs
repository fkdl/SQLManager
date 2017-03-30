using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLManager
{
    public partial class frmLogin: Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DatabaseConfiguration dbConfig = new DatabaseConfiguration();
            Dictionary<string, string> connectionData = dbConfig.getConnectionData();

            cmbServer.Text = connectionData["serverName"];
            cmbDatabase.Text = connectionData["database"];
            cmbAuthentication.SelectedIndex = connectionData["integratedSecurity"] == "SSPI" ? 0 : 1 ;
            txtUser.Text = connectionData["username"];
            //txtPassword.Text = connectionData["password"];
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            DatabaseConfiguration dbConfig = new DatabaseConfiguration();

            dbConfig.updateAttribute("ServerName", cmbServer.Text);
            dbConfig.updateAttribute("Database", cmbDatabase.Text);

            switch (cmbAuthentication.SelectedIndex)
            {
                case 0:
                    dbConfig.updateAttribute("IntegratedSecurity", "SSPI");
                    break;
                case 1:
                    dbConfig.updateAttribute("IntegratedSecurity", "False");
                    dbConfig.updateAttribute("Username", txtUser.Text);
                    dbConfig.updateAttribute("Password", txtPassword.Text);
                    break;
            }

            Database db = new Database();

            if (db.isConnected())
            {
                dbConfig.save();

                DialogResult = DialogResult.OK;
                Close();
            }
           

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbAuthentication_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbAuthentication.SelectedIndex == 0)
            {
                //Windows Authentication
                txtUser.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                //SQL Server Authentication
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
            }

        }
    }
}
