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
    public partial class frmSQLBuilder : Form
    {
        public frmSQLBuilder()
        {
            InitializeComponent();
        }

        private void execute()
        {
            splitContainer1.Panel2Collapsed = true;
            splitContainer1.IsSplitterFixed = true; 

            DataTable dt = new DataTable();
            Database db = new Database();

                //Verificar si hay texto seleccionado
                string query;
                if (txtQuery.SelectedText.Length > 0)
                {
                    query = txtQuery.SelectedText;
                }
                else
                {
                    query = txtQuery.Text;
                }

            //Verificar si el query no esta vacio
            if (query != "")
            {
                //Llenar datatable dt
                dt = db.query(query);

                FillDBList();

                //Obtiene el mensaje del query
                string msj = db.Message;

                //Verifica si el query trajo algun dato
                if (dt.Columns.Count > 0)
                {
                    if (!tabsRM.TabPages.Contains(tabResults))
                    {
                        tabsRM.TabPages.Insert(0, tabResults);

                    }

                    tabsRM.SelectedTab = tabResults;
                    viewResults.DataSource = dt;
                }
                else
                {
                    tabsRM.TabPages.Remove(tabResults);
                    tabResults.Hide();
                }
                
                txtMessages.Text = msj;
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.IsSplitterFixed = false;
            }
        }

        private void FillDBList()
        {
            Database db = new Database();
            DataTable dbList = new DataTable();

            dbList = db.query("EXEC SP_DATABASES");

            cbMenuDBList.ComboBox.DataSource = dbList;
            cbMenuDBList.ComboBox.DisplayMember = "DATABASE_NAME";
            cbMenuDBList.ComboBox.Text = db.DatabaseName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();


            splitContainer1.Panel2Collapsed = true;
            splitContainer1.IsSplitterFixed = true;

            FillDBList();

            //MessageBox.Show(db.DatabaseName);


        }

        private void cbMenuDBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cbMenuDBList.ComboBox.Text;
            if (selectedItem != "System.Data.DataRowView")
            {
                Database db = new Database();

                string query = "USE " + selectedItem;

                db.query(query);

                //MessageBox.Show(query);
            }
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            execute();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                execute();
            }
        }
    }
}
