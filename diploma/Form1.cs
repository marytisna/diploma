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
        int _id;
        string imagePath;

        public Form1(int id)
        {
            InitializeComponent();
            _id = id;
            route = new Routes(id);
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
        Routes route;
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["diploma.Properties.Settings.KyivCityGuideDBConnectionString"].ConnectionString);
        private void AddSightseen(Panel parent, Sightseen sightseen)
        {
            Panel p = new Panel();
            p.Dock = DockStyle.Top;
            p.Visible = true;
            p.AutoSize = true;
            PictureBox pb = new PictureBox();
            Label label = new Label();
            Label l = new Label();
            pb.Visible = true;
            label.Visible = true;
            l.Visible = true;
            label.Font = new Font("Georgia", 12, FontStyle.Bold);
            l.Font = new Font("Georgia", 9, FontStyle.Regular);
            l.AutoSize = true;
            l.MaximumSize = new Size(280, 0);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            label.AutoSize = true;
            label.Text = sightseen.Name;
            l.Text = sightseen.Description;
            pb.ImageLocation = sightseen.Image;
            pb.Left = 5;
            pb.Top = 5;
            pb.Size = new Size(350, 230);
            label.Top = 5;
            label.Left = pb.Right + 5;
            l.Left = pb.Right + 5;
            l.Top = label.Bottom + 3;
            l.Parent = p;
            label.Parent = p;
            pb.Parent = p;
            p.Parent = parent;
        }
        
        private void AddNewSighseen()
        {
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["diploma.Properties.Settings.KyivCityGuideDBConnectionString"].ConnectionString;
            //sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.Open();
            for (int i = route.Sightseens.Count-1; i >=0; i--)
            {
                AddSightseen(panel1, route.Sightseens[i]);
            }
            pictureBox1.ImageLocation = route.Image;
            label1.Text = route.Name;
            label4.Text = route.Description;


            //    LoadRouteImage("2");
            //    LoadRouteName("2");
            //    LoadRouteDescription("2");
            //    LoadSightseenName("2");
            //    LoadSightseenDescription("2");
            //    LoadSightseenImage("2");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName; //получение пути к файлу
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            route.AddNewSightseen(textBox1.Text, richTextBox1.Text, imagePath);
            for (int i = route.Sightseens.Count - 1; i >= 0; i--)
            {
                AddSightseen(panel1, route.Sightseens[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            int index;
            string selectedItem = (string)comboBox1.Items[comboBox1.SelectedIndex];
            SqlCommand getSightseen = new SqlCommand("SELECT ID FROM Sightseens WHERE NAME = @selectedItem", sqlConnection);
            getSightseen.Parameters.AddWithValue("@selectedItem", selectedItem);
            index = (int)getSightseen.ExecuteScalar();
            SqlCommand deleteSightseen = new SqlCommand("DELETE FROM RoutesToSightseens WHERE SightseenID = @SightseenID", sqlConnection);
            deleteSightseen.Parameters.AddWithValue("@SightseenID", index);
            deleteSightseen.ExecuteNonQuery();
            SqlCommand deleteSightseen1 = new SqlCommand("DELETE FROM Sightseens WHERE ID = @SightseenID", sqlConnection);
            deleteSightseen1.Parameters.AddWithValue("@SightseenID", index);
            deleteSightseen1.ExecuteNonQuery();
            sqlConnection.Close();
            panel1.Controls.Clear();
            route.LoadSigheseens();
            for (int i = route.Sightseens.Count - 1; i >= 0; i--)
            {
                AddSightseen(panel1, route.Sightseens[i]);
            }
        }
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

