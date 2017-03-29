using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace SQLManager
{
    public partial class frmLogin: Form
    {
        SqlConnection con;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           /* try
            {
                con = new SqlConnection("Data Source=" + cmbServer.Text + "; Integrated Security=True;");

                con.Open();


                DataTable databases = con.GetSchema("Databases");
                foreach (DataRow database in databases.Rows)
                {
                    String databaseName = database.Field<String>("database_name");
                    cmbDatabase.Items.Add(databaseName);
                    short dbID = database.Field<short>("dbid");
                    DateTime creationDate = database.Field<DateTime>("create_date");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            */
        }

        private void cmbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAuthentication.SelectedIndex == 0)
            {
                enabled(true);
            }
            else
            {
                enabled(false);
            }
        }

        private void enabled(bool b)
        {
            txtUser.Enabled = !b;
            txtPassword.Enabled = !b;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private string CheckForms(string connectionString)
        {

            return "";
        }

        private bool checkConecction(string connectionString)
        {
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                con.Close();
                // MessageBox.Show("Inicio de sesion valido");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error en la conexion, revise los datos ingresados", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form2_Load(null, null);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            DatabaseConfiguration dbConfig = new DatabaseConfiguration();

            dbConfig.updateAttribute("ServerName", cmbServer.Text);
            dbConfig.updateAttribute("Database", cmbDatabase.Text);

            switch (cmbAuthentication.SelectedIndex)
            {
                case 0:
                    dbConfig.updateAttribute("IntegratedSecurit", "SSPI");
                    break;
                case 1:
                    dbConfig.updateAttribute("IntegratedSecurit", "False");
                    dbConfig.updateAttribute("Username", txtUser.Text);
                    dbConfig.updateAttribute("Password", txtPassword.Text);
                    break;
            }

            Database db = new Database();

            if (db.isConnected())
            {
                MessageBox.Show("Conectado Correctamente");
                var frmSQLBuilder = Application.OpenForms["frmSQLBuilder"];
                //frmSQLBuilder.Enabled = true;
                ((frmSQLBuilder)this.Owner).showQueryContainer();
                this.Close();
            }
           

        }
    }
}
