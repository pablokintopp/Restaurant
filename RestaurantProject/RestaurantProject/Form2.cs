﻿using System;
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
    public partial class Form2 : Form
    {

        Restaurant restaurant;
        Form parent;
        public Form2(Form formLogin,Restaurant r)
        {
            InitializeComponent();
            parent = formLogin;
            restaurant = r;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            greet();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        public void greet() {
            labelWelcome.Text = "Welcome " + restaurant.Employee.FirstName +" "+ restaurant.Employee.LastName;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Close();

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Form formManagement = new Form3(this, restaurant);
            formManagement.Show();
            this.Hide();
        }

        private void buttonNewOrder_Click(object sender, EventArgs e)
        {
            Form formNewOrder = new Form4(this, restaurant);
            formNewOrder.Show();
            this.Hide();
        }

        private void buttonNewPayment_Click(object sender, EventArgs e)
        {
            Form formNewOrder = new Form5(this, restaurant);
            formNewOrder.Show();
            this.Hide();
        }
        
    }
}
