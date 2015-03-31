using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject
{
    public class User
    {
        string firstName, lastName, userName, password;
        char type;
        int id;
        

        public User(int id, string username, string firstName, string lastName, string password, char type)
        {
            // TODO: Complete member initialization
            this.id = id;
            this.firstName = firstName;
            this.userName = username;
            this.lastName = lastName;
            this.password = password;
            this.type = type;
        }


        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public char Type
        {
            get { return type; }
            set { type = value; }
        }
        

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


    }
}
