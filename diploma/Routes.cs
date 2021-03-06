﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace diploma
{
      class Routes
    {
        string _id;
        public Routes(int id)
        {
            this._id = Convert.ToString(id);
            LoadRouteImage();
            LoadRouteName();
            LoadRouteDescription();
            LoadSigheseens();
        }
        public string Id { get { return _id; } }
        public string Name { get;  private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        List<Sightseen> sightseens = new List<Sightseen>();
        public List<Sightseen> Sightseens { get { return sightseens; } }

        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["diploma.Properties.Settings.KyivCityGuideDBConnectionString"].ConnectionString);
        //SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["diploma.Properties.Settings.KyivCityGuideDBConnectionString1"].ConnectionString);

        private void LoadRouteImage()
        {
            sqlConnection.Open();
            SqlCommand getRouteImageCommand = new SqlCommand("SELECT Image FROM Routes WHERE ID = '" + Id + "'", sqlConnection);
            Image = (string)getRouteImageCommand.ExecuteScalar();
            sqlConnection.Close();
        }

       void LoadRouteName()
        {
            sqlConnection.Open();
            SqlCommand getRouteNameCommand = new SqlCommand("SELECT Name FROM Routes WHERE ID = '" + Id + "'", sqlConnection);
            Name = (string)getRouteNameCommand.ExecuteScalar();
            sqlConnection.Close();
        }

       void LoadRouteDescription()
        {
            sqlConnection.Open();
            SqlCommand getRouteDescriptionCommand = new SqlCommand("SELECT Description FROM Routes WHERE ID = '" + Id + "'", sqlConnection);
            Description = (string)getRouteDescriptionCommand.ExecuteScalar();
            sqlConnection.Close();
        }

        public void LoadSigheseens()
        {
            sightseens.Clear();
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            SqlCommand getImageCommand = new SqlCommand("SELECT Sightseens.ID FROM Sightseens INNER JOIN RoutesToSightseens ON Sightseens.ID = RoutesToSightseens.SightseenID WHERE RoutesToSightseens.RouteID = '" + Id + "'", sqlConnection);
            sqlDataReader = getImageCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                sightseens.Add(new Sightseen(Convert.ToString(sqlDataReader.GetValue(0))));
            }
            sqlDataReader.Close();
            sqlConnection.Close();
        }
        public void AddNewSightseen(string name, string description, string image)
        {
            int lastID;
            sqlConnection.Open();
            SqlCommand getlasIDcommand = new SqlCommand("SELECT ID FROM Sightseens WHERE ID = (SELECT MAX(ID) FROM Sightseens)", sqlConnection);
            lastID = (int)getlasIDcommand.ExecuteScalar();
            lastID++;
            SqlCommand addNewSightseenCommand = new SqlCommand("INSERT INTO [Sightseens] (ID, Name, Description, Image) VALUES (@ID, @Name, @Description, @Image)", sqlConnection);
            addNewSightseenCommand.Parameters.AddWithValue("@ID", lastID);
            addNewSightseenCommand.Parameters.AddWithValue("@Name", name);
            addNewSightseenCommand.Parameters.AddWithValue("@Description", description);
            addNewSightseenCommand.Parameters.AddWithValue("@Image", image);
            addNewSightseenCommand.ExecuteNonQuery();
            SqlCommand bindCommand = new SqlCommand("INSERT INTO [RoutesToSightseens](RouteID, SightseenID) VALUES (@RouteID, @SightseenID)", sqlConnection);
            bindCommand.Parameters.AddWithValue("@RouteID", Convert.ToInt32(Id));
            bindCommand.Parameters.AddWithValue("@SightseenID", lastID);
            bindCommand.ExecuteNonQuery();
            sqlConnection.Close();
            LoadSigheseens();

        }
    }
}
