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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PetShopManagementSystem
{
    public partial class Login : Form
    {
        private readonly string adminUser = "sa";
        private readonly string adminPassword = "123";
        public static string Employee;

        public Login()
        {
            InitializeComponent();
            txtPass.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string password = txtPass.Text;

            if (user == adminUser && password == adminPassword)
            {
                Admin admin = new Admin();
                admin.Show();
                this.Close();
            }
            else
            {
                using (var context = new PetShopManagementContext())
                {
                    var employee = context.Employees.FirstOrDefault(emp => emp.EmpName == user && emp.EmpPass == password);
                    if (employee != null)
                    {
                        Login.Employee = employee.EmpName;
                        Homes homes = new Homes();
                        homes.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("User or Password is incorrect. Please try again!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUser.Text = string.Empty;
            txtPass.Text = string.Empty;
        }
    }
}
