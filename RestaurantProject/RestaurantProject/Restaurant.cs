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
    public class Restaurant
    {
        public MySqlConnection connection;
        private User employee;

       

        public Restaurant(MySqlConnection c) {
            connection = c;
        }

        public User Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public void Clear(DataGridView dataGridView) {
            dataGridView.Rows.Clear();
        }

        public void Clear(TextBox textBox) {
            textBox.Clear();
        }

        //DISPLAY THE COMMAND RESULT (cmd) IN ANY DATAGRIDVIEW  BY PARAMETER 
        public void displayGridView(MySqlCommand cmd, DataGridView dataGridView)
        {
            MySqlDataAdapter mcd = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            mcd.Fill(ds);
            dataGridView.DataSource = ds.Tables[0];
        }

        //CALLING PROCEDURE WITHOUT PARAMETERS
        public MySqlCommand callProcedure(string procedureName)
        {
            MySqlCommand cmd = new MySqlCommand(procedureName, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }

        //CALLING PROCEDURE WITH  PARAMETERS
        public MySqlCommand callProcedure(string procedureName, string[] parameterName, object[] parameterValue)
        {
            MySqlCommand cmd = new MySqlCommand(procedureName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            for (int i = 0; i < parameterName.Length; i++)
            {
                cmd.Parameters.AddWithValue("@"+parameterName[i], parameterValue[i]);
                cmd.Parameters["@" + parameterName[i]].Direction = ParameterDirection.Input;
            }

            return cmd;
        }



    }
}
