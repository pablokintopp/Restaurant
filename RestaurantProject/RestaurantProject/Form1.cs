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
        

        public Form1()
        {
            
            InitializeComponent();
            textBoxUser.Text = "f2014_user21";
            textBoxPassword.Text = "f2014_user21";
            string serverIP = "ec2-54-152-4-112.compute-1.amazonaws.com";
            string user =textBoxUser.Text;
            string password = textBoxPassword.Text;
            string database = textBoxUser.Text;
            server = new ConnectServer(serverIP,password,database,user);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            status = server.connectToDatabase();
            if (status.Equals("CONNECTED")) {
                Form formMain = new Form2(this);
                formMain.Show();
                this.Hide();
            }
        }
    }
}
