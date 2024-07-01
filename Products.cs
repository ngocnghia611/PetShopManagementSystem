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
    public partial class Products : Form
    {
        private PetShopManagementContext context;
        public Products()
        {
            InitializeComponent();
            context = new PetShopManagementContext();

        }

        public void LoadProduct()
        {
            try
            {
                var product = context.Products.Select(p => new
                {
                    ProductId = (int?)p.ProductId,
                    ProductName = p.ProductName,
                    Category = p.Category,
                    Quantity = (int?)p.Quantity,
                    Price = (decimal?)p.Price
                }).ToList();

                // Add a blank row at the end of the list with null or empty values
                product.Add(new { ProductId = (int?)null, ProductName = "", Category = "", Quantity = (int?)null, Price = (decimal?)null });
                dgvProduct.DataSource = product;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Products_Load(object sender, EventArgs e)
        {
            LoadProduct();
            ClearInput();
            dgvProduct.SelectionChanged += dgvProduct_SelectionChanged;
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
            txtCategory.SelectedIndex = 0;
            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtCategory.SelectedIndex == -1 || txtQuantity.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Missing Information!!");
            }
            else
            {
                try
                {
                    var newProduct = new Product
                    {
                        ProductName = txtName.Text,
                        Category = txtCategory.SelectedItem.ToString(),
                        Quantity = int.Parse(txtQuantity.Text),
                        Price = int.Parse(txtPrice.Text)
                    };

                    context.Products.Add(newProduct);
                    context.SaveChanges();
                    LoadProduct();
                    ClearInput();
                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtCategory.Text == "" || txtQuantity.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Missing Information!!");
            }
            else
            {
                try
                {
                    if (dgvProduct.SelectedRows.Count > 0)
                    {
                        int productId = int.Parse(dgvProduct.SelectedRows[0].Cells["ProductId"].Value.ToString());
                        var product = context.Products.Find(productId);
                        if (product != null)
                        {
                            product.ProductName = txtName.Text;
                            product.Category = txtCategory.Text;
                            product.Quantity = int.Parse(txtQuantity.Text);
                            product.Price = int.Parse(txtPrice.Text);

                            context.SaveChanges();
                            LoadProduct();
                            ClearInput();
                            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a product to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtCategory.Text == "" || txtQuantity.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Missing Information!!");
            }
            else
            {
                try
                {
                    if (dgvProduct.SelectedRows.Count > 0)
                    {
                        int productId = int.Parse(dgvProduct.SelectedRows[0].Cells["ProductId"].Value.ToString());
                        var product = context.Products.Find(productId);
                        if (product != null)
                        {
                            context.Products.Remove(product);
                            context.SaveChanges();
                            LoadProduct();
                            ClearInput();
                            MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvProduct.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvProduct.SelectedRows[0];

                    // Check if the selected row is the blank row
                    if (selectedRow.Cells["ProductName"].Value == null || string.IsNullOrEmpty(selectedRow.Cells["ProductName"].Value.ToString()))
                    {
                        ClearInput();
                    }
                    else
                    {
                        txtName.Text = selectedRow.Cells["ProductName"].Value.ToString();
                        txtCategory.Text = selectedRow.Cells["Category"].Value.ToString();
                        txtQuantity.Text = selectedRow.Cells["Quantity"].Value.ToString();
                        txtPrice.Text = selectedRow.Cells["Price"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
