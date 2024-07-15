using Microsoft.EntityFrameworkCore;
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
using System.Xml.Linq;

namespace PetShopManagementSystem
{
    public partial class Employees : Form
    {
        private PetShopManagementContext dbContext;
        public Employees()
        {
            InitializeComponent();
            dbContext = new PetShopManagementContext();

        }

        public void LoadEmployees()
        {
            try
            {
                var employees = dbContext.Employees.Select(e => new
                {
                    EmpId = (int?)e.EmpId,
                    e.EmpName,
                    e.EmpAddress,
                    EmpDob = e.EmpDob.ToString("yyyy-MM-dd"),
                    e.EmpPhone,
                    e.EmpPass
                }).ToList();

                employees.Add(new { EmpId = (int?)null, EmpName = "", EmpAddress = "", EmpDob = "", EmpPhone = "", EmpPass = "" });
                dgvEmployees.DataSource = employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            ClearInput();
            dgvEmployees.SelectionChanged += dgvEmployees_SelectionChanged;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }


        private void btnEmployees_Click(object sender, EventArgs e)
        {

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
            txtAddress.Text = string.Empty;
            txtDateOfBirth.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtPass.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtAddress.Text == "" || txtDateOfBirth.Text == "" || txtPhone.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    var employee = new Employee
                    {
                        EmpName = txtName.Text,
                        EmpAddress = txtAddress.Text,
                        EmpDob = DateOnly.Parse(txtDateOfBirth.Text),
                        EmpPhone = txtPhone.Text,
                        EmpPass = txtPass.Text
                    };

                    dbContext.Employees.Add(employee);
                    dbContext.SaveChanges();
                    MessageBox.Show("Employee added successfully!");
                    LoadEmployees();
                    ClearInput();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtAddress.Text == "" || txtDateOfBirth.Text == "" || txtPhone.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    if (dgvEmployees.SelectedRows.Count > 0)
                    {
                        int empId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmpId"].Value);
                        var employee = dbContext.Employees.FirstOrDefault(emp => emp.EmpId == empId);

                        if (employee != null)
                        {
                            employee.EmpName = txtName.Text;
                            employee.EmpAddress = txtAddress.Text;
                            employee.EmpDob = DateOnly.Parse(txtDateOfBirth.Text); // Assuming txtDateOfBirth is a TextBox containing date as string
                            employee.EmpPhone = txtPhone.Text;
                            employee.EmpPass = txtPass.Text;

                            dbContext.SaveChanges();
                            MessageBox.Show("Employee updated successfully!");
                            LoadEmployees(); // Method to refresh the DataGridView
                            ClearInput(); // Method to clear input fields
                        }
                        else
                        {
                            MessageBox.Show("Employee not found.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select an employee to edit.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployees.SelectedRows.Count > 0)
                {
                    int empId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmpId"].Value);
                    var employee = dbContext.Employees
                                          .Include(emp => emp.Bills)  // Bao gồm thông tin hóa đơn liên quan
                                          .FirstOrDefault(emp => emp.EmpId == empId);

                    if (employee != null)
                    {
                        // Xóa hóa đơn của nhân viên trước
                        dbContext.Bills.RemoveRange(employee.Bills);

                        // Sau đó mới xóa nhân viên
                        dbContext.Employees.Remove(employee);
                        dbContext.SaveChanges();
                        MessageBox.Show("Employee deleted successfully!");
                        LoadEmployees();
                        ClearInput();
                    }
                }
                else
                {
                    MessageBox.Show("Please select an employee to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployees.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvEmployees.SelectedRows[0];

                    if (selectedRow.Cells["EmpName"].Value == null || string.IsNullOrEmpty(selectedRow.Cells["EmpName"].Value.ToString()))
                    {
                        ClearInput();
                    }
                    else
                    {
                        txtName.Text = selectedRow.Cells["EmpName"].Value.ToString();
                        txtAddress.Text = selectedRow.Cells["EmpAddress"].Value.ToString();
                        txtDateOfBirth.Text = selectedRow.Cells["EmpDob"].Value.ToString();
                        txtPhone.Text = selectedRow.Cells["EmpPhone"].Value.ToString();
                        txtPass.Text = selectedRow.Cells["EmpPass"].Value.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
    }
}
