﻿using PetShopManagementSystem.Models;
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
    public partial class Customer : Form
    {
        private PetShopManagementContext context;
        public Customer()
        {
            InitializeComponent();
            context = new PetShopManagementContext();
            lblEmpName.Text = Login.Employee;
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            LoadCustomer();
            ClearInput();
        }
        public void LoadCustomer()
        {
            try
            {
                var customer = context.Customers.Select(c => new
                {
                    CustId = (int?)c.CustId,
                    c.CustName,
                    c.CustAddress,
                    c.CustPhone
                }).ToList();

                customer.Add(new { CustId = (int?)null, CustName = "", CustAddress = "", CustPhone = "" });
                dgvCustomer.DataSource = customer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Homes homes = new Homes();
            homes.Show();
            this.Hide();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {

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
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtAddress.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Missing Information!!");
            }
            else
            {
                try
                {
                    var newCustomer = new PetShopManagementSystem.Models.Customer
                    {
                        CustName = txtName.Text,
                        CustAddress = txtAddress.Text,
                        CustPhone = txtPhone.Text
                    };

                    context.Customers.Add(newCustomer);
                    context.SaveChanges();
                    LoadCustomer();
                    ClearInput();
                    MessageBox.Show("Customer added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtAddress.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Missing Information!!");
            }
            else
            {
                try
                {
                    if (dgvCustomer.SelectedRows.Count > 0)
                    {
                        int selectedCustomerId = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells["CustId"].Value);
                        var customer = context.Customers.FirstOrDefault(c => c.CustId == selectedCustomerId);

                        if (customer != null)
                        {
                            customer.CustName = txtName.Text;
                            customer.CustAddress = txtAddress.Text;
                            customer.CustPhone = txtPhone.Text;

                            context.SaveChanges();
                            LoadCustomer();
                            ClearInput();
                            MessageBox.Show("Customer updated successfully!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a customer to edit.");
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
            if (txtName.Text == "" || txtAddress.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Missing Information!!");
            }
            else
            {
                try
                {
                    if (dgvCustomer.SelectedRows.Count > 0)
                    {
                        int selectedCustomerId = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells["CustId"].Value);
                        var customer = context.Customers.FirstOrDefault(c => c.CustId == selectedCustomerId);

                        if (customer != null)
                        {
                            context.Customers.Remove(customer);
                            context.SaveChanges();
                            LoadCustomer();
                            ClearInput();
                            MessageBox.Show("Customer deleted successfully!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a customer to delete.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomer.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvCustomer.SelectedRows[0];
                    if (selectedRow.Cells["CustName"].Value == null || string.IsNullOrEmpty(selectedRow.Cells["CustName"].Value.ToString()))
                    {
                        ClearInput();
                    }
                    else
                    {
                        txtName.Text = selectedRow.Cells["CustName"].Value.ToString();
                        txtAddress.Text = selectedRow.Cells["CustAddress"].Value.ToString();
                        txtPhone.Text = selectedRow.Cells["CustPhone"].Value.ToString();
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error selecting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}
