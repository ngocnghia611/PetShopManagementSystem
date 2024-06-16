using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShopManagementSystem
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Homes homes = new Homes();
            homes.Show();
            this.Hide();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            Employees employees = new Employees();
            employees.Show();
            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Show();
            this.Hide();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            Billings billings = new Billings(); 
            billings.Show();
            this.Hide();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Confirm logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
            }
        }

        private void ClearInput()
        {
            txtName.Text = string.Empty;
            txtCategory.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }
    }
}
