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

namespace InventoryManagementSystem
{
    public partial class UCAdminCategories : UserControl
    {
        public UCAdminCategories()
        {
            InitializeComponent();
        }

        readonly SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\InventoryManagementSystem\Inventory.mdf;Integrated Security = True");

        private void UCAdminCategories_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                try
                {
                    DisplayCategoriesData();    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if (TxtBxCategory.Text == string.Empty)
            {
                MessageBox.Show("Please Fill The Field", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else 
            { 
                if (con.State == ConnectionState.Closed)
                {
                    try
                    {
                        con.Open();

                        string checkcat = "Select Count(*) From Categories Where Category = @cat";

                        using (SqlCommand checkcatcmd = new SqlCommand(checkcat, con))
                        {
                            checkcatcmd.Parameters.AddWithValue("@cat", TxtBxCategory.Text.Trim());
                            int rowcount = 0;
                            object result = checkcatcmd.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                rowcount = Convert.ToInt32(result);
                            }
                            if (rowcount > 0)
                            {
                                MessageBox.Show($"Category: {TxtBxCategory.Text.Trim()} Already Exists", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        string insdata = "Insert Into Categories (Category, DateAdded) Values (@cat, @dtadd)";

                        using (SqlCommand inscmd = new SqlCommand(insdata, con))
                        {
                            inscmd.Parameters.AddWithValue("@cat", TxtBxCategory.Text.Trim());
                            inscmd.Parameters.AddWithValue("@dtadd", DateTime.Today);

                            inscmd.ExecuteNonQuery();

                            DisplayCategoriesData();
                            MessageBox.Show("Category Added Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            TxtBxCategory.Text = string.Empty;
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "BtnInsert - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    finally { con.Close(); }
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (TxtBxCategory.Text == string.Empty)
            {
                MessageBox.Show("Please Fill The Field", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                {
                    try
                    {
                        con.Open();

                        string upddata = "Update Categories Set Category = @cat Where Id = @id";

                        using (SqlCommand updcmd = new SqlCommand(upddata, con))
                        {
                            updcmd.Parameters.AddWithValue("@cat", TxtBxCategory.Text.Trim());

                            updcmd.ExecuteNonQuery();

                            DisplayCategoriesData();
                            MessageBox.Show("Category Updated Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            TxtBxCategory.Text = string.Empty;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "BtnUpdate - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    finally { con.Close(); }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (TxtBxCategory.Text == string.Empty)
            {
                MessageBox.Show("Please Select The Record First", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            { 
                if (con.State == ConnectionState.Closed)
                {
                    try
                    {
                        con.Open();
                        DialogResult dr = MessageBox.Show($"Are You Sure You Want To Delete Category: {TxtBxCategory.Text} ?", "Confirmation",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            string deldata = "Delete From Categories Where Id = @id";

                            using (SqlCommand delcmd = new SqlCommand(deldata, con))
                            {
                                delcmd.Parameters.AddWithValue("@id", getid);

                                delcmd.ExecuteNonQuery();

                                DisplayCategoriesData();
                                MessageBox.Show("Category Deleted Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                TxtBxCategory.Text = string.Empty;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "BtnDelete - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    finally { con.Close(); }
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtBxCategory.Text = string.Empty;
        }

        int getid;
        private void DGVCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.RowIndex != -1)
           {
                DataGridViewRow row = DGVCategories.Rows[e.RowIndex];

                getid = (int)row.Cells[0].Value;

                TxtBxCategory.Text = row.Cells[1].Value.ToString(); 
           }
        }

        public void DisplayCategoriesData()
        {
            CategoriesData cd = new CategoriesData();
            DGVCategories.DataSource = cd.ListCategoriesData();
        }

        public void RefreshData()
        {
           if(InvokeRequired)
           {
                Invoke((MethodInvoker)RefreshData);
                return;
           }

            DisplayCategoriesData();
        }
    }
}
