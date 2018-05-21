using System;
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
        public string ID { get; set; }
        public string Name { get;  private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["diploma.Properties.Settings.KyivCityGuideDBConnectionString"].ConnectionString);

       public string LoadRouteImage()
        {
            sqlConnection.Open();
            SqlCommand getRouteImageCommand = new SqlCommand("SELECT Image FROM Routes WHERE ID = '" + ID + "'", sqlConnection);
            Image = (string)getRouteImageCommand.ExecuteScalar();
            return Image;
        }

       public string LoadRouteName()
        {
            sqlConnection.Open();
            SqlCommand getRouteNameCommand = new SqlCommand("SELECT Name FROM Routes WHERE ID = '" + ID + "'", sqlConnection);
            Name = (string)getRouteNameCommand.ExecuteScalar();
            return Name;
        }

       public string LoadRouteDescription()
        {
            sqlConnection.Open();
            SqlCommand getRouteDescriptionCommand = new SqlCommand("SELECT Description FROM Routes WHERE ID = '" + ID + "'", sqlConnection);
            Description = (string)getRouteDescriptionCommand.ExecuteScalar();
            return Description;
        }
    }
}
