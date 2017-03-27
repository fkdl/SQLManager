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
using System.Text.RegularExpressions;
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

        private void button2_Click(object sender, EventArgs e)
        {

            DataTable rows = new DataTable();


            string query;
            if (queryString.SelectedText.Length > 0)
            {
                query = queryString.SelectedText;
            }
            else
            {
                query = queryString.Text;
            }

            var regex = new Regex(@"(^|\s|\n)(?:use\s)(?<word>\b\S+\b)", RegexOptions.IgnoreCase);
            var matchCollection = regex.Matches(query);

            foreach (Match match in matchCollection)
            {
                MessageBox.Show(match.Groups["word"].Value);
            }

            
           


        }

        SqlConnection conn;
        SqlCommand cmd;
        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SOF105;Integrated Security=true; User ID=; Password=";
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }
    }
}
