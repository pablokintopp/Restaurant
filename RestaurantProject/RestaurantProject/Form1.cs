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
    public partial class Form1 : Form
    {
        private ConnectServer server;
        private string status;
        private Restaurant restaurant;
        

        public Form1()
        {
            
            InitializeComponent();
           // textBoxUser.Text = "f2014_user20";
           // textBoxPassword.Text = "f2014_user20";
            string serverIP = "ec2-54-152-4-112.compute-1.amazonaws.com";
            string user = "f2014_user20";
            string password = "f2014_user20";
            string database = "f2014_user20";
            server = new ConnectServer(serverIP,password,database,user);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            status = server.connectToDatabase();
            labelStatus.Text = "Server Status : " + status;
            restaurant = new Restaurant(server.Connection);
            textBoxUser.Text = "admin";
            textBoxPassword.Text = "admin";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (status.Equals("CONNECTED")) {
                string[] parameterName = {"p_username","p_password"};
                object[] parameterValue = { textBoxUser.Text.ToString(), textBoxPassword.Text.ToString() };
                
                MySqlCommand cmd = restaurant.callProcedure("Rest_Login",parameterName,parameterValue);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int id = Convert.ToInt32(dr[0]);
                    char type = Convert.ToChar(dr[5]);

                    restaurant.Employee = new User(id, dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), type);
                    Form formMain = new Form2(this,restaurant);
                    formMain.Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show("Login and/or Password invalid");
                }
                dr.Close();
                restaurant.Clear(textBoxUser);
                restaurant.Clear(textBoxPassword);
                
            }
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //MessageBox.Show("test");
                button1_Click(null, null);
            }
        
        }
    }
}
