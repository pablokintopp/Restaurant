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

        public Restaurant(MySqlConnection c) {
            connection = c;
        }

        public void Clear(DataGridView dataGridView) {
            dataGridView.Rows.Clear();
        }

        public void Clear(TextBox textBox) {
            textBox.Clear();
        }

        public void displayGridView(MySqlCommand cmd, DataGridView dataGridView)
        {
            MySqlDataAdapter mcd = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            mcd.Fill(ds);
            dataGridView.DataSource = ds.Tables[0];
        }

        public void callProcedure(string procedureName, DataGridView outPutData) {
            MySqlCommand cmd = new MySqlCommand(procedureName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //TODO  XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        }

        public void callProcedure(string procedureName, Label outPutData)
        {
            MySqlCommand cmd = new MySqlCommand(procedureName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                //outPutData.setText(dr);
                // using DataGridView
                //outPutData.Text = dr[0].ToString() ;
              //  MessageBox.Show(dr["Message"]);
                //TODO XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
