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
    public partial class Form3 : Form
    {
        Restaurant restaurant;
        Form parent;
        List <int> userRowsChanged = new List<int>();
        List<int> dishRowsChanged = new List<int>();
        List<int> beverageRowsChanged = new List<int>();
        public Form3(Form menu,Restaurant r)
        {
            InitializeComponent();
            restaurant = r;
            parent = menu;
            comboBoxNewUser.SelectedIndex = 0;
            comboBoxNewDish.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GETTING INFORMATION FROM THE DISH/BEVEREAGE AND CREATING THE ARRAYS TO USE A STORED PROCEDURE
            char type = comboBoxNewDish.Text.ToString().Equals("Dish") ? 'D' : 'B';
            string[] parametersNames = { "p_name", "p_descr", "p_price"};
            object[] parametersValues = { textD1.Text.ToString(), textD2.Text.ToString(), Convert.ToDouble(textD3.Text.ToString()) };

            MySqlCommand cmd = restaurant.callProcedure( (type == 'D') ? ("Rest_NewDish") : ("Rest_NewBeverage"), parametersNames, parametersValues);
            //NONQUERY BECAUSE THERE'S NO TABLE RETURNING FROM DATABASE IT'S JUST A INSERT
            cmd.ExecuteNonQuery();

            //SHOWING THE  DATAGRID OF Dishes WITH THE NEW dish JUST ADDED AS WELL
            if(type == 'D')            
                 restaurant.displayGridView(restaurant.callProcedure("Rest_ShowDishes"), dataGridView2);
            //SHOWING THE  DATAGRID OF beverages WITH THE NEW beverage JUST ADDED AS WELL
            else           
            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowBeverages"), dataGridView3);

            //clear textFields
            restaurant.Clear(textD1);
            restaurant.Clear(textD2);
            restaurant.Clear(textD3);
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowUsers"),dataGridView1);
           
            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowDishes"), dataGridView2);

            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowBeverages"), dataGridView3);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //GETTING INFORMATION FROM THE USER AND CREATING THE ARRAYS TO USE A STORED PROCEDURE
            char type = comboBoxNewUser.Text.ToString().Equals("Admin") ? 'A' : 'E';
            string[] parametersNames = { "p_username", "p_firstname", "p_lastname", "p_password", "p_type" };
            object[] parametersValues = { textU1.Text.ToString(), textU2.Text.ToString(), textU3.Text.ToString(), textU4.Text.ToString(), type };

            MySqlCommand cmd = restaurant.callProcedure("Rest_NewUser", parametersNames, parametersValues);
            //NONQUERY BECAUSE THERE'S NO TABLE RETURNING FROM DATABASE IT'S JUST A INSERT
            cmd.ExecuteNonQuery();
            
            
            //SHOWING THE  DATAGRID OF USERS WITH THE NEW USER JUST ADDED AS WELL
            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowUsers"), dataGridView1);

            //clear textFields
            restaurant.Clear(textU1);
            restaurant.Clear(textU2);
            restaurant.Clear(textU3);
            restaurant.Clear(textU4);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //check and add to the list to make updates if it doesn't exist in the list already
            if (!userRowsChanged.Contains(e.RowIndex))
                userRowsChanged.Add(e.RowIndex);
            buttonUpdateU.Visible = true;
        }

        private void buttonUpdateU_Click(object sender, EventArgs e)
        {
           
            string[] parametersNames = { "p_id","p_username", "p_firstname", "p_lastname", "p_password", "p_type" };
            restaurant.updateTable(dataGridView1,"Rest_UpdateUser",parametersNames,userRowsChanged);

            buttonUpdateU.Visible = false;
            userRowsChanged.Clear();

        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //check and add to the list to make updates if it doesn't exist in the list already
            if (!dishRowsChanged.Contains(e.RowIndex))
                dishRowsChanged.Add(e.RowIndex);
            buttonUpdateDish.Visible = true;
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //check and add to the list to make updates if it doesn't exist in the list already
            if (!beverageRowsChanged.Contains(e.RowIndex))
                beverageRowsChanged.Add(e.RowIndex);
            buttonUpdateBeverage.Visible = true;
        }

        private void buttonUpdateDish_Click(object sender, EventArgs e)
        {
            string[] parametersNames = { "p_id", "p_name", "p_descr", "p_price" };
            restaurant.updateTable(dataGridView2, "Rest_UpdateDish", parametersNames, dishRowsChanged);

            buttonUpdateDish.Visible = false;
            dishRowsChanged.Clear();
        }

        private void buttonUpdateBeverage_Click(object sender, EventArgs e)
        {
            string[] parametersNames = { "p_id", "p_name", "p_descr", "p_price" };
            restaurant.updateTable(dataGridView3, "Rest_UpdateBeverage", parametersNames, beverageRowsChanged);

            buttonUpdateBeverage.Visible = false;
            beverageRowsChanged.Clear();
        }

        private void buttonDelU_Click(object sender, EventArgs e)
        {
            string [] parametersName = {"p_id"};
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            foreach(DataGridViewRow row in rows){
                object[] parametersValue = {row.Cells[0].Value };
               MySqlCommand cmd= restaurant.callProcedure("Rest_DeleteUser", parametersName, parametersValue);
               cmd.ExecuteNonQuery();
            }

            buttonDelU.Visible = false;

            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowUsers"), dataGridView1);


            
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show(e.RowIndex+" Row selected");
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonDelU.Visible = true;
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonDelDish.Visible = true;
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonDelBeverage.Visible = true;
        }

        private void buttonDelDish_Click(object sender, EventArgs e)
        {
            string[] parametersName = { "p_id" };
            DataGridViewSelectedRowCollection rows = dataGridView2.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                object[] parametersValue = { row.Cells[0].Value };
                MySqlCommand cmd = restaurant.callProcedure("Rest_DeleteDish", parametersName, parametersValue);
                cmd.ExecuteNonQuery();
            }

            buttonDelDish.Visible = false;

            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowDishes"), dataGridView2);
        }

        private void buttonDelBeverage_Click(object sender, EventArgs e)
        {
            string[] parametersName = { "p_id" };
            DataGridViewSelectedRowCollection rows = dataGridView3.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                object[] parametersValue = { row.Cells[0].Value };
                MySqlCommand cmd = restaurant.callProcedure("Rest_DeleteBeverage", parametersName, parametersValue);
                cmd.ExecuteNonQuery();
            }

            buttonDelBeverage.Visible = false;

            restaurant.displayGridView(restaurant.callProcedure("Rest_ShowBeverages"), dataGridView3);
        }

        private void comboBoxNewUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
