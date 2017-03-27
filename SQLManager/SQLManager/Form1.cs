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
using System.Configuration;


namespace SQLManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {

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

            //Llena datatable con el resultado del query
            dt = db.query(query);

            //Obtiene el mensaje del query
            string msj = db.Message;

            //Verifica si el query trajo algun dato
            if ( dt.Columns.Count > 0)
            {
                if ( !tabsRM.TabPages.Contains(tabResults) )
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

            if ( !tabsRM.TabPages.Contains(tabMessages) )
            {
                tabsRM.TabPages.Add(tabMessages);

            }
            
            txtMessages.Text = msj;
            splitContainer1.Panel2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Oculta los tabs del resultado del query
            tabsRM.TabPages.Remove(tabResults);
            tabsRM.TabPages.Remove(tabMessages);
            //splitContainer1.IsSplitterFixed = true;
            splitContainer1.Panel2.Hide();
            //splitContainer1.SplitterDistance = 999;

        }
    }
}
