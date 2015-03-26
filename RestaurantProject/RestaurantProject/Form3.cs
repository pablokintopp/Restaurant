using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantProject
{
    public partial class Form3 : Form
    {
        Restaurant restaurant;
        public Form3(Restaurant r)
        {
            InitializeComponent();
            restaurant = r;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string instruction = "INSERT into Dish(name,descr,price) values (@vname,@v)";
            //open connection
            if (restaurant.connection != null)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = restaurant.connection.CreateCommand();
                //MySqlCommand cmd = new MySqlCommand(instruction, connection);
                cmd.CommandText = instruction;
               // cmd.Parameters.AddWithValue("@vname", textBox1.Text);
                //Execute command
                cmd.ExecuteNonQuery();
                
            }
            else
            {
                MessageBox.Show("Try to connect");
            }
        }
    }
}
