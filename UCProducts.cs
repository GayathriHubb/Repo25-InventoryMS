using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace InventoryManagementSystem
{
    public partial class UCProducts : UserControl
    {
        public UCProducts()
        {
            InitializeComponent();
        }

        readonly string constring = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\InventoryManagementSystem\Inventory.mdf;Integrated Security = True";


        bool stockb, priceb;
        string path;
        private void UCProducts_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                try
                {
                    DisplayCategories();
                    DisplayProductsData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            stockb = int.TryParse(TxtBxStock.Text.Trim(), out int stock);
            priceb = float.TryParse(TxtBxPrice.Text.Trim(), out float price);
            if (EmptyFields())
            {
                MessageBox.Show("All Fields are Required to be Filled", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            else if (!stockb || stock < 0)
            {
                MessageBox.Show("Invalid Input.. Stock must be a Non-Negative Integer", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                TxtBxStock.Focus();
                return;
            }
            else if (!priceb || price < 0)
            {
                MessageBox.Show("Invalid Input.. Price must be a Non-Negative Number", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                TxtBxPrice.Focus();
                return;
            }
            else
            {

                using (SqlConnection sqlcon = new SqlConnection(constring))
                {
                    sqlcon.Open();
                    string checkpid = "Select Count(*) From Products Where ProductId = @pid And DateDelete is NULL";
                    using (SqlCommand checkpidcmd = new SqlCommand(checkpid, sqlcon))
                    {
                        checkpidcmd.Parameters.AddWithValue("@pid", TxtBxPId.Text.Trim());
                        int rowcount = 0;
                        object result = checkpidcmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            rowcount = Convert.ToInt32(result);
                        }
                        if (rowcount > 0)
                        {
                            MessageBox.Show($"Product Id: {TxtBxPId.Text.Trim()} Already Exists", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }

                    }

                    try
                    {
                        string basedirectory = AppDomain.CurrentDomain.BaseDirectory;
                        string relativepath = Path.Combine("ProductsDirectory", $"{TxtBxPId.Text.Trim().ToUpper()}.jpg");
                        path = Path.Combine(basedirectory, relativepath);

                        string directorypath = Path.GetDirectoryName(path);
                        if (!Directory.Exists(directorypath))
                        {
                            Directory.CreateDirectory(directorypath);
                        }

                        PicBxProduct.Image = null;
                        if (!string.IsNullOrEmpty(PicBxProduct.ImageLocation))
                        { File.Copy(PicBxProduct.ImageLocation, path, true); }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "PicBox - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                    }

                    string insprod = "Insert Into Products (ProductId, Category, ProductName, Stock, Price, Status, ImagePath, DateInsert) Values (@pid, @cat, @pname, @stock, @price, @status, @imgpath, @dtins)";
                    using (SqlCommand insprodcmd = new SqlCommand(insprod, sqlcon))
                    {
                        insprodcmd.Parameters.AddWithValue("@pid", TxtBxPId.Text.Trim().ToUpper());
                        insprodcmd.Parameters.AddWithValue("@cat", CmbBxCategory.Text.Trim());
                        insprodcmd.Parameters.AddWithValue("@pname", TxtBxPName.Text.Trim());
                        insprodcmd.Parameters.AddWithValue("@stock", stock);
                        insprodcmd.Parameters.AddWithValue("@price", price.ToString("0.##"));
                        insprodcmd.Parameters.AddWithValue("@status", CmbBxStatus.Text.Trim());
                        insprodcmd.Parameters.AddWithValue("@imgpath", string.IsNullOrEmpty(path) ? (object)DBNull.Value : path);
                        insprodcmd.Parameters.AddWithValue("@dtins", DateTime.Today);

                        int i = insprodcmd.ExecuteNonQuery();

                        DisplayProductsData();
                        MessageBox.Show("Product Added Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    sqlcon.Close();
                }
                
            }
            
            ClearFields();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            stockb = int.TryParse(TxtBxStock.Text.Trim(), out int stock);
            priceb = float.TryParse(TxtBxPrice.Text.Trim(), out float price);
            if (EmptyFields())
            {
                MessageBox.Show("All Fields are Required to be Filled", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            if (!stockb || stock < 0)
            {
                MessageBox.Show("Invalid Input.. Stock must be a Non-Negative Integer", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            if (!priceb || price < 0)
            {
                MessageBox.Show("Invalid Input.. Price must be a Non-Negative Number", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult dr = MessageBox.Show($"Are you sure you want to Update Product Id: {TxtBxPId.Text.Trim().ToUpper()} ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        string basedirectory = AppDomain.CurrentDomain.BaseDirectory;
                        string relativepath = Path.Combine("ProductsDirectory", $"{TxtBxPId.Text.Trim().ToUpper()}.jpg");
                        path = Path.Combine(basedirectory, relativepath);

                        string directorypath = Path.GetDirectoryName(path);
                        

                        if (!string.IsNullOrEmpty(PicBxProduct.ImageLocation))
                        { File.Copy(PicBxProduct.ImageLocation, path, true); }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "PicBox - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                        

                    using (SqlConnection sqlcon = new SqlConnection(constring))
                    {
                        sqlcon.Open();

                        string updprod = "Update Products Set Category = @cat, ProductName = @pname, Stock = @stock, Price = @price, Status = @status, ImagePath = @imgpath, DateUpdate = @dtupd Where Id = @id";
                        using (SqlCommand updprodcmd = new SqlCommand(updprod, sqlcon))
                        {
                            updprodcmd.Parameters.AddWithValue("@cat", CmbBxCategory.Text.Trim());
                            updprodcmd.Parameters.AddWithValue("@pname", TxtBxPName.Text.Trim());
                            updprodcmd.Parameters.AddWithValue("@stock", stock);
                            updprodcmd.Parameters.AddWithValue("@price", price);
                            updprodcmd.Parameters.AddWithValue("@status", CmbBxStatus.Text.Trim());
                            updprodcmd.Parameters.AddWithValue("@imgpath", path ?? string.Empty);
                            updprodcmd.Parameters.AddWithValue("@dtupd", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                            updprodcmd.Parameters.AddWithValue("@id", getid);
                            int i = updprodcmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                DisplayProductsData();
                                MessageBox.Show("Product Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to Update Product", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            ClearFields();
        }
       

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (EmptyFields())
            {
                MessageBox.Show("Please Select The Product First", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dr = MessageBox.Show($"Are you sure you want to Delete Product Id: {TxtBxPId.Text.Trim().ToUpper()} ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    using (SqlConnection sqlcon = new SqlConnection(constring))
                    {
                        sqlcon.Open();

                        string delprod = "Update Products Set DateDelete = @dtdel Where Id = @id";

                        using (SqlCommand delprodcmd = new SqlCommand(delprod, sqlcon))
                        {
                            delprodcmd.Parameters.AddWithValue("@dtdel", DateTime.Now);
                            delprodcmd.Parameters.AddWithValue("@id", getid);
                            int i = delprodcmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                DisplayProductsData();
                                MessageBox.Show("Product Deleted Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to Delete Product", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            }
                        }
                        sqlcon.Close();
                    }
                }
            }

            ClearFields();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        int getid;
        private void DGVProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            { 
                DataGridViewRow row = DGVProducts.Rows[e.RowIndex];

                getid = Convert.ToInt32(row.Cells[0].Value);
                TxtBxPId.Text = row.Cells[1].Value.ToString();
                CmbBxCategory.Text = row.Cells[2].Value.ToString();
                TxtBxPName.Text = row.Cells[3].Value.ToString();
                TxtBxStock.Text = row.Cells[4].Value.ToString();
                TxtBxPrice.Text = row.Cells[5].Value.ToString();
                CmbBxStatus.Text = row.Cells[6].Value.ToString();

                string imgpath = row.Cells[7].Value.ToString();

                if (imgpath != string.Empty)
                {
                    PicBxProduct.Image = Image.FromFile(imgpath);
                }
                else
                {
                    PicBxProduct.Image = null;
                }
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Product Image";
            ofd.Filter = "Image File (*.png,*.jpg,*.jpeg)|*.png;*.jpg;*.jpeg";
            string imgpath = string.Empty;

            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imgpath = ofd.FileName;
                    PicBxProduct.ImageLocation = imgpath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "BtnImport - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void DisplayCategories()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                sqlcon.Open();
                string selcat = "Select * From Categories";
                using (SqlCommand selcatcmd = new SqlCommand(selcat, sqlcon))
                {
                    CmbBxCategory.Items.Clear();
                    SqlDataReader sdr = selcatcmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            string category = sdr["Category"].ToString();
                            CmbBxCategory.Items.Add(category);
                        }
                    }
                }
            }
        }
        

        private void ClearFields()
        {
            TxtBxPId.Text = string.Empty;
            TxtBxPName.Text = string.Empty;
            CmbBxCategory.Text = string.Empty;
            TxtBxStock.Text = string.Empty;
            TxtBxPrice.Text = string.Empty;
            CmbBxStatus.Text = string.Empty;
            PicBxProduct.Image = null;
        } 

        private bool EmptyFields()
        {
            if (TxtBxPId.Text == string.Empty || TxtBxPName.Text == string.Empty || CmbBxCategory.Text == string.Empty || TxtBxStock.Text == string.Empty || TxtBxPrice.Text == string.Empty || CmbBxStatus.Text == string.Empty || PicBxProduct.Image == null)
            {
                return true;
            }
            return false;
        }

        public void DisplayProductsData()
        {
            ProductsData pd = new ProductsData();
            DGVProducts.DataSource = pd.ListProductsData();
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            DisplayCategories();
            DisplayProductsData();
        }

    }
}

