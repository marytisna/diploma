using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace diploma
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["diploma.Properties.Settings.KyivCityGuideDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(sqlConnection != null && sqlConnection.State!=ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }
    }
}
