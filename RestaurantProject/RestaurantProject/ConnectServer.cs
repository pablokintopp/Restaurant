using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject
{
    class ConnectServer
    {
        private string server;
        private string password;
        private string database;
        private string uid;
        private MySqlConnection connection;

        

       public ConnectServer(string s, string p, string d, string u) {
            server = s;
            password = p;
            database = d;
            uid = u;
        }


        public string Server
        {
            get { return server; }
            set { server = value; }
        }

        public MySqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public string Database
        {
            get { return database; }
            set { database = value; }
        }
        

        public string Uid
        {
            get { return uid; }
            set { uid = value; }
        }
        

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string connectToDatabase()
        {
            // MySQL default port is 3306       

            string ret;

            string connectionString;
            connectionString = "SERVER=" + server + ";DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            Connection = new MySqlConnection(connectionString);

            try
            {
                Connection.Open();
                ret = "CONNECTED";
            }
            catch (MySqlException ex)
            {
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                ret = "DISCONNECTED";
                switch (ex.Number)
                {
                    case 0:
                        ret = "Cannot connect to server.  Contact administrator";
                        break;

                    case 1045:
                        ret = "Invalid username/password, please try again";
                        break;
                }
            }

            return ret;
        }

        public string disconnectToDatabase()
        {
            if (Connection != null)
                Connection.Close();
            
            
            return "DISCONNECTED";
        }


    }
}
