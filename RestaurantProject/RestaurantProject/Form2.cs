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
    public partial class Form2 : Form
    {
        Form parent;
        public Form2(Form formLogin)
        {
            InitializeComponent();
            parent = formLogin;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }
        
    }
}
