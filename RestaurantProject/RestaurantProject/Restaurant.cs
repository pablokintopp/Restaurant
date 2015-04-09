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

        //DISPLAY THE COMMAND RESULT (cmd) IN the  DATAGRIDVIEW  which come by PARAMETER 
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

        //CALLING PROCEDURE WITH  PARAMETERS(parameters name and parameters value)
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

        //using a stored procedure this method is goint to update every row saved in the list to update using the datagridview data as values
        public void updateTable(DataGridView dataGridView,string procedureName , string[] parametersName, List <int> rowsList ) {
            object[] parametersValues = new Object[parametersName.Length];

            foreach (int row in rowsList)
            {
                for(int i = 0 ; i< parametersValues.Length ; i++ ){
                    parametersValues[i] = dataGridView.Rows[row].Cells[i].Value;
                }

                MySqlCommand cmd = callProcedure(procedureName, parametersName, parametersValues);
                cmd.ExecuteNonQuery();
                

            }

        }
        // just check if a textfield is empty or not
        public Boolean validInput(TextBox textField) { 
            Boolean ret = true;

            if (textField.TextLength == 0)
                ret = false;            


            return ret;
        }



    }
}
