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

namespace diploma
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            sqlConnection.Open();
            SqlCommand getTheSightseens = new SqlCommand("SELECT NAME FROM Sightseens", sqlConnection);
            SqlDataReader sqlDataReader = null;
            sqlDataReader = getTheSightseens.ExecuteReader();
            while (sqlDataReader.Read())
            {
                comboBox1.Items.Add(sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();
            sqlConnection.Close();
        }
        int lastRouteID;
        string imagePathRoute;
        string imagePathSightseen;
        Routes newRoute;
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["diploma.Properties.Settings.KyivCityGuideDBConnectionString"].ConnectionString);
        public void AddNewRoute(string name, string description, string image)
        {
            sqlConnection.Open();
            SqlCommand getlastRouteIDcommand = new SqlCommand("SELECT ID FROM Routes WHERE ID = (SELECT MAX(ID) FROM Routes)", sqlConnection);
            lastRouteID = (int)getlastRouteIDcommand.ExecuteScalar();
            lastRouteID++;
            SqlCommand addNewRouteCommand = new SqlCommand("INSERT INTO [Routes] (ID, Name, Description, Image) VALUES (@ID, @Name, @Description, @Image)", sqlConnection);
            addNewRouteCommand.Parameters.AddWithValue("@ID", lastRouteID);
            addNewRouteCommand.Parameters.AddWithValue("@Name", name);
            addNewRouteCommand.Parameters.AddWithValue("@Description", description);
            addNewRouteCommand.Parameters.AddWithValue("@Image", image);
            addNewRouteCommand.ExecuteNonQuery();
            sqlConnection.Close();
            newRoute = new Routes(lastRouteID);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddNewRoute(textBox1.Text, richTextBox1.Text, imagePathRoute);
            MessageBox.Show("Маршрут створений! Додайте до нього пам'ятки!");
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePathRoute = openFileDialog1.FileName; 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                imagePathSightseen = openFileDialog2.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            newRoute.AddNewSightseen(textBox2.Text, richTextBox2.Text, imagePathSightseen);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(Convert.ToInt32(newRoute.Id));
            form1.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            int index;
            string selectedItem = (string)comboBox1.Items[comboBox1.SelectedIndex];
            SqlCommand getSightseen = new SqlCommand("SELECT ID FROM Sightseens WHERE NAME = @selectedItem", sqlConnection);
            getSightseen.Parameters.AddWithValue("@selectedItem", selectedItem);
            index = (int)getSightseen.ExecuteScalar();
            SqlCommand addSightseen = new SqlCommand("INSERT INTO [RoutesToSightseens](RouteID, SightseenID) VALUES (@RouteID, @SightseenID)", sqlConnection);
            addSightseen.Parameters.AddWithValue("@RouteID", Convert.ToInt32(newRoute.Id));
            addSightseen.Parameters.AddWithValue("@SightseenID", index);
            addSightseen.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
