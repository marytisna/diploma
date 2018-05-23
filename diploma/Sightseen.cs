using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace diploma
{
    class Sightseen
    {
      public string Name { get;  private set; }
      public string Description { get; private set; }
      public string Image { get; private set; }
      public string Id { get; private set; }
      public Sightseen(string id)
        {
            Id = id;
            LoadSightseenImage();
            LoadSightseenName();
            LoadSightseenDescription();
        }
       SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["diploma.Properties.Settings.KyivCityGuideDBConnectionString"].ConnectionString);

        private void LoadSightseenImage()
        {
            sqlConnection.Open();
            SqlCommand getSightseenImageCommand = new SqlCommand("SELECT Image FROM Sightseens WHERE ID = '" + Id + "'", sqlConnection);
            Image = (string)getSightseenImageCommand.ExecuteScalar();
            sqlConnection.Close();
        }

        private void LoadSightseenName()
        {
            sqlConnection.Open();
            SqlCommand getSightseenNameCommand = new SqlCommand("SELECT Name FROM Sightseens WHERE ID = '" + Id + "'", sqlConnection);
            Name = (string)getSightseenNameCommand.ExecuteScalar();
            sqlConnection.Close();
        }

        private void LoadSightseenDescription()
        {
            sqlConnection.Open();
            SqlCommand getSightseenDescriptionCommand = new SqlCommand("SELECT Description FROM Sightseens WHERE ID = '" + Id + "'", sqlConnection);
            Description = (string)getSightseenDescriptionCommand.ExecuteScalar();
            sqlConnection.Close();
        }

    }
}
