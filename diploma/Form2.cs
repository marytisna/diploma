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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["diploma.Properties.Settings.KyivCityGuideDBConnectionString"].ConnectionString);
        private void metroButton1_Click(object sender, EventArgs e)
        {
           

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 route1 = new Form1(1);
            route1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 route2 = new Form1(2);
            route2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 route3 = new Form1(3);
            route3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 route4 = new Form1(4);
            route4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 route5 = new Form1(5);
            route5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 route6 = new Form1(6);
            route6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 route7 = new Form1(7);
            route7.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 newRoute = new Form3();
            newRoute.Show();
           
    }

        private void Form2_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand getRoutes = new SqlCommand("SELECT ID FROM Routes", sqlConnection);
            SqlDataReader sqlDataReader = null;
            sqlDataReader = getRoutes.ExecuteReader();
            while (sqlDataReader.Read())
            {
                DisplayRoutes(panel1, new Routes(Convert.ToInt32(sqlDataReader.GetValue(0))));
            }
            sqlDataReader.Close();
            sqlConnection.Close();
        }

        private void DisplayRoutes (Panel parent, Routes route)
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
            label.Text = route.Name;
            l.Text = route.Description;
            pb.ImageLocation = route.Image;
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
            pb.Click += delegate (object sender, EventArgs e)
            {
                Form1 f = new Form1(Convert.ToInt32(route.Id));
                f.Show();
            };
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for(int i=0; i<panel1.Controls.Count; i++)
            {
                Control[] control =  panel1.Controls[i].Controls.Find("l", true) ;
                for(int j=0; j<control.Length; j++)
                {
                    if (control[j].Text.Contains("Дніпро")) ;
                }
                
            }

           
        }
    }

}
