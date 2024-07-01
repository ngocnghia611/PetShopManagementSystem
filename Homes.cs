using PetShopManagementSystem.Models;
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
    public partial class Homes : Form
    {
        private readonly PetShopManagementContext context;
        public Homes()
        {
            InitializeComponent();
            context = new PetShopManagementContext();
            CountDogs();
            CountBirds();
            CountCats();
            Finance();
        }

        private void CountDogs()
        {
            try
            {
                var dogCount = context.Products.Count(p => p.Category == "Dog");
                lblDogs.Text = dogCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error counting dogs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CountBirds()
        {
            try
            {
                var birdCount = context.Products.Count(p => p.Category == "Bird");
                lblBirds.Text = birdCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error counting birds: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CountCats()
        {
            try
            {
                var catCount = context.Products.Count(p => p.Category == "Cat");
                lblCats.Text = catCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error counting cats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Finance()
        {
            try
            {
                var totalAmount = context.Bills.Sum(b => b.Amt);
                lblFinance.Text = totalAmount.ToString("C"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total finance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
            this.Hide();
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
                login.Show();
            }
        }
    }
}
