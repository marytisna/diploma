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
using MetroFramework.Design;
using MetroFramework;
using MetroFramework.Fonts;

namespace diploma
{
    public partial class Form1 : Form
    {
        //private SqlConnection sqlConnection = null;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["diploma.Properties.Settings.KyivCityGuideDBConnectionString"].ConnectionString;
            //sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.Open();

            Routes route1 = new Routes();
            route1.ID = "2";
            pictureBox4.ImageLocation = route1.LoadRouteImage();
            metroLabel4.Text = route1.LoadRouteName();
            label4.Text = route1.LoadRouteDescription();

            //    LoadRouteImage("2");
            //    LoadRouteName("2");
            //    LoadRouteDescription("2");
            //    LoadSightseenName("2");
            //    LoadSightseenDescription("2");
            //    LoadSightseenImage("2");

        }

        //private void LoadRouteImage(string number)
        //{
        //    SqlCommand getRouteImageCommand = new SqlCommand("SELECT Image FROM Routes WHERE ID = '" + number + "'", sqlConnection);
        //    pictureBox4.ImageLocation = (string)getRouteImageCommand.ExecuteScalar();
        //}

        //private void LoadRouteName(string number)
        //{
        //    SqlCommand getRouteNameCommand = new SqlCommand("SELECT Name FROM Routes WHERE ID = '" + number + "'", sqlConnection);
        //    metroLabel4.Text = (string)getRouteNameCommand.ExecuteScalar();
        //}

        //private void LoadRouteDescription(string number)
        //{
        //    SqlCommand getRouteDescriptionCommand = new SqlCommand("SELECT Description FROM Routes WHERE ID = '" + number + "'", sqlConnection);
        //    label4.Text = (string)getRouteDescriptionCommand.ExecuteScalar();
        //}

        //private void LoadSightseenImage(string number)
        //{
        //    SqlDataReader sqlDataReader = null;
        //    SqlCommand getImageCommand = new SqlCommand("SELECT Sightseens.Image FROM Sightseens INNER JOIN RoutesToSightseens ON Sightseens.ID = RoutesToSightseens.SightseenID WHERE RoutesToSightseens.RouteID = '" + number + "'", sqlConnection);
        //    sqlDataReader = getImageCommand.ExecuteReader();
        //    List<string> images = new List<string>();
        //    while (sqlDataReader.Read())
        //    {
        //        images.Add(sqlDataReader.GetString(0));
        //    }
        //    sqlDataReader.Close();
        //    pictureBox1.ImageLocation = images[0];
        //    pictureBox2.ImageLocation = images[1];
        //    pictureBox3.ImageLocation = images[2];
        //}

        //private void LoadSightseenName(string number)
        //{
        //    SqlDataReader sqlDataReader = null;
        //    SqlCommand getNameCommand = new SqlCommand("SELECT Sightseens.Name FROM Sightseens INNER JOIN RoutesToSightseens ON Sightseens.ID = RoutesToSightseens.SightseenID WHERE RoutesToSightseens.RouteID = '" + number + "'", sqlConnection);
        //    sqlDataReader = getNameCommand.ExecuteReader();
        //    List<string> names = new List<string>();
        //    while (sqlDataReader.Read())
        //    {    
        //        names.Add(sqlDataReader.GetString(0)); 
        //    }
        //    sqlDataReader.Close();
        //    metroLabel1.Text = names[0];
        //    metroLabel2.Text = names[1];
        //    metroLabel3.Text = names[2];
        //}

        //private void LoadSightseenDescription(string number)
        //{
        //    SqlDataReader sqlDataReader = null;
        //    SqlCommand getDescriptionCommand = new SqlCommand("SELECT Sightseens.Description FROM Sightseens INNER JOIN RoutesToSightseens ON Sightseens.ID = RoutesToSightseens.SightseenID WHERE RoutesToSightseens.RouteID = '" + number + "'", sqlConnection);
        //    sqlDataReader = getDescriptionCommand.ExecuteReader();
        //    List<string> descriptions = new List<string>();
        //    while (sqlDataReader.Read())
        //    {
        //        descriptions.Add(sqlDataReader.GetString(0));
        //    }
        //    sqlDataReader.Close();
        //    label1.Text = descriptions[0];
        //    label2.Text = descriptions[1];
        //    label3.Text = descriptions[2];
        //}



        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if(sqlConnection != null && sqlConnection.State!=ConnectionState.Closed)
        //    {
        //        sqlConnection.Close();
        //    }
        //}
    }
}
