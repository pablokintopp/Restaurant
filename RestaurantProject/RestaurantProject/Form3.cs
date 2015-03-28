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
        Form parent;
        public Form3(Form menu,Restaurant r)
        {
            InitializeComponent();
            restaurant = r;
            parent = menu;
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

        private void Form3_Load(object sender, EventArgs e)
        {
            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowUsers"),dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            char type = comboBoxNewUser.Text.ToString().Equals("Admin") ? 'A' : 'E';
            string[] parametersNames = { "p_username", "p_firstname", "p_lastname", "p_password", "p_type" };
            object[] parametersValues = { textU1.Text.ToString(), textU2.Text.ToString(), textU3.Text.ToString(), textU4.Text.ToString(), type };

            restaurant.displayGridView(restaurant.callProcedure("Rest_NewUser", parametersNames, parametersValues), dataGridView2);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
