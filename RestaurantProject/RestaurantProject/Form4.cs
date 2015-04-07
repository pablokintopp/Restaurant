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

//STATUS 'P' = pendent , 'U' = Unpaid  and 'D' = Done/finished/paid

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
            DataGridViewSelectedRowCollection rows = dataGridView3.SelectedRows;
            if (rows.Count == 1) { 
                string[] parametersName = { "p_id", "p_status" };
                object[] parametersValue = { rows[0].Cells[0].Value, 'D' };
                MySqlCommand cmd = restaurant.callProcedure("Rest_ChangeStatus", parametersName, parametersValue);
                cmd.ExecuteNonQuery();
                restaurant.displayGridView(restaurant.callProcedure("Rest_ShowUnpaidOrders"), dataGridView3);

                restaurant.displayGridView(restaurant.callProcedure("Rest_ShowPaidOrders"), dataGridView2);
            }
            else
            {
                MessageBox.Show("Please select ONE row!");

            }
        }

        private void ButtonCheckP_Click(object sender, EventArgs e)
        {
            string[] parametersName = { "p_id","p_status" };
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            if (rows.Count > 0) { 
                foreach (DataGridViewRow row in rows)
                {
                    object[] parametersValue = { row.Cells[0].Value , 'U' };
                    MySqlCommand cmd = restaurant.callProcedure("Rest_ChangeStatus", parametersName, parametersValue);
                    cmd.ExecuteNonQuery();
                }



                restaurant.displayGridView(restaurant.callProcedure("Rest_ShowPendentOrders"), dataGridView1);
                restaurant.displayGridView(restaurant.callProcedure("Rest_ShowUnpaidOrders"), dataGridView3);
            }
            else
            {
                MessageBox.Show("No rows selected to check!");

            }
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
            if(rows.Count > 0){
                foreach (DataGridViewRow row in rows)
                {
                    object[] parametersValue = { row.Cells[0].Value };
                    MySqlCommand cmd = restaurant.callProcedure("Rest_DeleteOrder", parametersName, parametersValue);
                    cmd.ExecuteNonQuery();
                }

            

                restaurant.displayGridView(restaurant.callProcedure("Rest_ShowPendentOrders"), dataGridView1);

            }
            else
            {
                MessageBox.Show("No rows selected to delete.");

            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void buttonDltU_Click(object sender, EventArgs e)
        {
            string[] parametersName = { "p_id" };
            DataGridViewSelectedRowCollection rows = dataGridView3.SelectedRows;
            if (rows.Count > 0)
            {
                foreach (DataGridViewRow row in rows)
                {
                    object[] parametersValue = { row.Cells[0].Value };
                    MySqlCommand cmd = restaurant.callProcedure("Rest_DeleteOrder", parametersName, parametersValue);
                    cmd.ExecuteNonQuery();
                }



                restaurant.displayGridView(restaurant.callProcedure("Rest_ShowUnpaidOrders"), dataGridView3);

            }
            else
            {
                MessageBox.Show("No rows selected to delete.");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //PAYMENT FOR ALL ORDERS RELATED WITH THIS TABLE
            double total = 0;
            string[] parametersName = { "p_id","p_status" };
            
            DataGridViewSelectedRowCollection rows = dataGridView3.SelectedRows;

            if (rows.Count == 1) { 
                int tableNumber = (int)rows[0].Cells[2].Value;
                DataGridViewRowCollection allRows = dataGridView3.Rows;

                foreach (DataGridViewRow row in allRows)
                {
                    if ((int)row.Cells[2].Value == tableNumber) {
                        total += Convert.ToDouble(row.Cells[6].Value);

                        object[] parametersValue = { row.Cells[0].Value , 'D' };
                        MySqlCommand cmd = restaurant.callProcedure("Rest_ChangeStatus", parametersName, parametersValue);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Total is : $"+total.ToString());

                restaurant.displayGridView(restaurant.callProcedure("Rest_ShowUnpaidOrders"), dataGridView3);

                restaurant.displayGridView(restaurant.callProcedure("Rest_ShowPaidOrders"), dataGridView2);
            }
            else
            {
                MessageBox.Show("Please select one row!.");

            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex>=0) // To avoid error
                dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0) 
                dataGridView3.Rows[e.RowIndex].Selected = true;
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Close();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Close();
        }
    }
}
