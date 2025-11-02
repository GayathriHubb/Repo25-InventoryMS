using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagementSystem
{
    public partial class Form1Login : Form
    {
        public Form1Login()
        {
            InitializeComponent();
        }

        readonly SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\InventoryManagementSystem\Inventory.mdf;Integrated Security = True");
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TxtBxUsername.Text == string.Empty || TxtBxPswrd.Text == string.Empty)
            {
                MessageBox.Show("All Fields are Required To be Filled", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                {
                    try
                    {
                        con.Open();

                        string seldata = "Select Count(*) From Users Where Username = @un AND Password = @pswd";

                        using (SqlCommand seldatacmd = new SqlCommand(seldata, con))
                        {
                            seldatacmd.Parameters.AddWithValue("@un", TxtBxUsername.Text.Trim());
                            seldatacmd.Parameters.AddWithValue("@pswd", TxtBxPswrd.Text.Trim());
                            int rowcount = 0;
                            object result = seldatacmd.ExecuteScalar();
                            if (result != DBNull.Value) 
                            { 
                                rowcount = Convert.ToInt32(result); 
                            }

                            if (rowcount > 0) 
                            {
                                MessageBox.Show("Login Successfull", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                                string role1 = "Select Role From Users Where Username = @un";
                                using (SqlCommand rolecmd = new SqlCommand(role1, con))
                                {
                                    rolecmd.Parameters.AddWithValue("@un", TxtBxUsername.Text.Trim());
                                    string role2 = rolecmd.ExecuteScalar() as string;

                                    if (role2 == "Admin")
                                    {
                                        AdminMainForm admin = new AdminMainForm();
                                        admin.Show();
                                        Hide();
                                    }
                                    if (role2 == "Cashier")
                                    {
                                        InventoryData.Username = TxtBxUsername.Text.Trim();
                                        StaffMainForm staff = new StaffMainForm();
                                        staff.Show();
                                        Hide();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username/Password or there is no Admin's Approval", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    finally
                    { con.Close(); }
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtBxUsername.Text = string.Empty;
            TxtBxPswrd.Text = string.Empty;
        }

        private void ChkBxPswrd_CheckedChanged(object sender, EventArgs e)
        {
            TxtBxPswrd.UseSystemPasswordChar = !ChkBxPswrd.Checked;
        }

        private void LbRegAcc_Click(object sender, EventArgs e)
        {
            Form2Register register = new Form2Register();
            register.Show();
            Hide();
        }
    }
}
