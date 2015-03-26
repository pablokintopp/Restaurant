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
           restaurant.callProcedure("Greet",labelWelcome);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }
        
    }
}
