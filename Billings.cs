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
    public partial class Billings : Form
    {
        private PetShopManagementContext context;
        private int Key = 0; // Biến lưu ProductId của sản phẩm được chọn
        private int Stock = 0; // Biến lưu số lượng tồn kho của sản phẩm được chọn
        private int n = 0; // Biến đếm số sản phẩm trong hóa đơn
        private int Total = 0; // Tổng tiền của hóa đơn
        private int pos = 60; // Biến để định vị trí in các sản phẩm trên hóa đơn
        public Billings()
        {
            InitializeComponent();
            context = new PetShopManagementContext();
            lblEmpName.Text = Login.Employee;
        }


        private void GetCustomer()
        {
            try
            {
                var customers = context.Customers
                                     .Select(c => new { c.CustId, c.CustName })
                                     .ToList();

                txtCustomerID.DisplayMember = "CustId";
                txtCustomerID.ValueMember = "CustId";
                txtCustomerID.DataSource = customers;

                txtCustomerID.SelectedIndexChanged += (sender, args) =>
                {
                    if (txtCustomerID.SelectedIndex != -1)
                    {
                        var selectedCustomer = customers[txtCustomerID.SelectedIndex];
                        txtCustomerName.Text = selectedCustomer.CustName;
                    }
                };
                txtCustomerName.ReadOnly = true;
                txtCustomerName.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProduct()
        {
            try
            {
                var product = context.Products.Select(p => new
                {
                    p.ProductId,
                    p.ProductName,
                    p.Category,
                    p.Quantity,
                    p.Price
                }).ToList();

                dgvProducts.DataSource = product;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void LoadProductBill()
        {
            // Thêm các cột cho DataGridView dgvProductBill
            dgvProductBill.Columns.Add("ID", "ID");
            dgvProductBill.Columns.Add("ProductName", "ProductName");
            dgvProductBill.Columns.Add("Quantity", "Quantity");
            dgvProductBill.Columns.Add("Price", "Price");
            dgvProductBill.Columns.Add("Total", "Total");
        }

        private void LoadTransactionBill()
        {
            try
            {
                var bill = context.Bills.Select(b => new
                {
                    b.BillId,
                    b.BillDate,
                    b.CustId,
                    b.CustName,
                    b.EmpName,
                    b.Amt
                }).ToList();
                dgvTransactions.DataSource = bill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateStock()
        {
            try
            {
                if (Key != 0 && Stock >= Convert.ToInt32(txtQuantity.Text))
                {
                    int newQuantity = Convert.ToInt32(txtQuantity.Text);

                    // Lấy sản phẩm cần cập nhật từ cơ sở dữ liệu
                    var productToUpdate = context.Products.Find(Key);
                    if (productToUpdate != null)
                    {
                        productToUpdate.Quantity -= newQuantity;
                        context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                        // Cập nhật số lượng tồn kho của sản phẩm trong dgvProducts
                        foreach (DataGridViewRow productRow in dgvProducts.Rows)
                        {
                            if (Convert.ToInt32(productRow.Cells["ProductId"].Value) == Key)
                            {
                                int currentStock = Convert.ToInt32(productRow.Cells["Quantity"].Value);
                                productRow.Cells["Quantity"].Value = currentStock - newQuantity;
                                break;
                            }
                        }

                        MessageBox.Show("Stock Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Product not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Insufficient stock or invalid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            txtProductName.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
            Stock = 0;
            Key = 0;
        }

        private void Billings_Load(object sender, EventArgs e)
        {
            GetCustomer();
            LoadProduct();
            LoadProductBill();
            LoadTransactionBill();
        }


        private void btnAddtoBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQuantity.Text == "" || Convert.ToInt32(txtQuantity.Text) > Stock)
                {
                    MessageBox.Show("Insufficient stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Key == 0)
                {
                    MessageBox.Show("Please select a product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int quantity = Convert.ToInt32(txtQuantity.Text);
                    int price = Convert.ToInt32(txtPrice.Text);
                    int total = quantity * price;

                    // Thêm sản phẩm vào DataGridView của hóa đơn
                    dgvProductBill.Rows.Add(n + 1, txtProductName.Text, quantity, price, total);

                    // Cập nhật tổng tiền của hóa đơn
                    Total += total;
                    Rs.Text = $"Total: {Total}$";

                    // Cập nhật số lượng tồn kho của sản phẩm
                    UpdateStock();

                    // Đặt lại các TextBox và biến đếm
                    Reset();
                    n++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product to bill: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtProductName.Text = dgvProducts.SelectedRows[0].Cells[1].Value.ToString();
                Stock = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells[3].Value.ToString());
                txtPrice.Text = dgvProducts.SelectedRows[0].Cells[4].Value.ToString();

                if (txtProductName.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells[0].Value.ToString());
                }

                txtProductName.ReadOnly = true;
                txtProductName.Enabled = false;
                txtPrice.ReadOnly = true;
                txtPrice.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocumentBill_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Petshop", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID PRODUCT PRICE QUANTITY TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26, 40));

            foreach (DataGridViewRow row in dgvProductBill.Rows)
            {
                int prodid = Convert.ToInt32(row.Cells["ID"].Value);
                string prodname = "" + row.Cells["ProductName"].Value;
                int prodprice = Convert.ToInt32(row.Cells["Price"].Value);
                int prodqty = Convert.ToInt32(row.Cells["Quantity"].Value);
                int total = Convert.ToInt32(row.Cells["Total"].Value);
                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + prodname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + prodqty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + total, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos = pos + 20;
            }

            e.Graphics.DrawString("Total: " + Total + "$", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(50, pos + 50));
            e.Graphics.DrawString("**************Petshop**************", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(80, pos + 85));
            dgvProductBill.Rows.Clear();
            dgvProductBill.Refresh();
            pos = 100;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocumentBill.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 600);
            if (printPreviewDialogBill.ShowDialog() == DialogResult.OK)
            {
                printDocumentBill.Print();
            }
            InsertBill();
        }

        private void InsertBill()
        {
            
        }
        private void dgvTransactions_SelectionChanged(object sender, EventArgs e)
        {

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
