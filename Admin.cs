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
    public partial class Admin : Form
    {
        private PetShopManagementContext context;
        public Admin()
        {
            InitializeComponent();
            context = new PetShopManagementContext();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtStartDate.Value;
            DateTime endDate = dtEndDate.Value;

            var reportData = context.Bills
                .Where(b => b.BillDate >= DateOnly.FromDateTime(startDate) && b.BillDate <= DateOnly.FromDateTime(endDate))
                .OrderByDescending(b => b.Amt)
                .ToList();

            dgvReports.DataSource = reportData.Select(b => new
            {
                b.BillId,
                b.CustName,
                b.EmpName,
                b.BillDate,
                b.Amt
            }).ToList();

            // Tính tổng doanh thu
            decimal totalRevenue = reportData.Sum(b => b.Amt);
            txtTotal.Text = totalRevenue.ToString("C"); // Định dạng tiền tệ
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            Employees employees = new Employees();
            employees.Show();
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

    }
}
