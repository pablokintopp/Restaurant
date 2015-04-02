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
    public partial class Form5 : Form
    {
        Restaurant restaurant;
        Form parent;

        public Form5(Form p, Restaurant r)
        {
            InitializeComponent();
            parent = p;
            restaurant = r;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //Loading dishes from the database
            MySqlCommand cmd = restaurant.callProcedure("Rest_showDishes");
            restaurant.displayGridView(cmd, dataGridView1);

            //Loading beverages from the database
            cmd = restaurant.callProcedure("Rest_showBeverages");
            restaurant.displayGridView(cmd, dataGridView2);
        }

      

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
           
        }

        private void dataGridView2_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView2.Rows[e.RowIndex].Selected = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object dishId = null;
            object bvgId = null;
            double total = 0;

            if (dataGridView1.SelectedRows.Count > 0) {
                dishId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                total += Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[3].Value);
            }

            if (dataGridView2.SelectedRows.Count > 0)
            {
                bvgId = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
                total += Convert.ToDouble(dataGridView2.SelectedRows[0].Cells[3].Value);
            }
        

            

            string[] parametersName = { "p_emp", "p_tb", "p_dish", "p_bevg", "p_total" };
            object[] parametersValue = { restaurant.Employee.Id, textBox1.Text, dishId, bvgId, total };
            MySqlCommand cmd = restaurant.callProcedure("Rest_NewOrder", parametersName, parametersValue);
            if (cmd.ExecuteNonQuery() != -1 ) {
                MessageBox.Show("New Order added!");
            }
            
            //clear selected rows
            if(dishId != null)
                dataGridView1.SelectedRows[0].Selected = false;
            if (bvgId != null)
                dataGridView2.SelectedRows[0].Selected = false;
           
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

     
    }
}
