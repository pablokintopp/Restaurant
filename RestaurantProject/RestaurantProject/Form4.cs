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
    public partial class Form4 : Form
    {
        Restaurant restaurant;
        Form parent;
        List<int> OrderPRowsChanged = new List<int>();
        List<int> OrderURowsChanged = new List<int>();
    
        public Form4(Form menu, Restaurant r)
        {
            InitializeComponent();
            restaurant = r;
            parent = menu;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonCheckP_Click(object sender, EventArgs e)
        {
            string[] parametersName = { "p_id" };
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                object[] parametersValue = { row.Cells[0].Value };
                MySqlCommand cmd = restaurant.callProcedure("Rest_Check", parametersName, parametersValue);
                cmd.ExecuteNonQuery();
            }



            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowPendentOrders"), dataGridView1);
            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowUnpaidOrders"), dataGridView3);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowPendentOrders"), dataGridView1);

            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowFinishedOrders"), dataGridView2);

            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowUnpaidOrders"), dataGridView3);
        }

        private void ButtonDltP_Click(object sender, EventArgs e)
        {
            string[] parametersName = { "p_id" };
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                object[] parametersValue = { row.Cells[0].Value };
                MySqlCommand cmd = restaurant.callProcedure("Rest_DeleteOrder", parametersName, parametersValue);
                cmd.ExecuteNonQuery();
            }

            

            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowPendentOrders"), dataGridView1);
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void buttonDltU_Click(object sender, EventArgs e)
        {
            string[] parametersName = { "p_id" };
            DataGridViewSelectedRowCollection rows = dataGridView2.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                object[] parametersValue = { row.Cells[0].Value };
                MySqlCommand cmd = restaurant.callProcedure("Rest_DeleteOrder", parametersName, parametersValue);
                cmd.ExecuteNonQuery();
            }



            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowPendentOrders"), dataGridView2);
        }
    }
}
