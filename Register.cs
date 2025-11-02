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
    public partial class Form2Register : Form
    {
        public Form2Register()
        {
            InitializeComponent();
        }

        readonly SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\InventoryManagementSystem\Inventory.mdf;Integrated Security = True");

        private void Form2Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            if (TxtBxUsername.Text == string.Empty || TxtBxPswrd.Text == string.Empty || TxtBxConfrmPswrd.Text == string.Empty) 
            {
                MessageBox.Show("All Fields are Required To be Filled", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                {
                    try
                    {
                        con.Close();

                        string checkun = "Select Count(*) From Users Where Username = @un";

                        using (SqlCommand checkuncmd = new SqlCommand(checkun, con))
                        {
                            checkuncmd.Parameters.AddWithValue("@un", TxtBxUsername.Text.Trim());

                            int rowcount = 0;
                            object result = checkuncmd.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                rowcount = Convert.ToInt32(result);
                            }

                            if (rowcount > 0)
                            {
                                string tempun = $"{TxtBxUsername.Text.Substring(0, 1).ToUpper()}{TxtBxUsername.Text.Substring(1)}";
                                MessageBox.Show($"Username: {tempun} is Taken Already", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                            else if (TxtBxPswrd.Text.Length < 8)
                            {
                                MessageBox.Show("Invalid Password.. Atleast 8 characters is needed", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            }
                            else if (TxtBxPswrd.Text != TxtBxConfrmPswrd.Text) 
                            {
                                MessageBox.Show("Passwords Does Not Match", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insdata = "Insert Into Users (Username, Password, Role, Status, DateRegister) Values (@un, @pswd, @role, @status, @dtreg)";
                                
                                using (SqlCommand insdatacmd =  new SqlCommand(insdata, con))
                                {
                                    insdatacmd.Parameters.AddWithValue("@un", TxtBxUsername.Text);
                                    insdatacmd.Parameters.AddWithValue("@pswd", TxtBxPswrd.Text);
                                    insdatacmd.Parameters.AddWithValue("@role", "Cashier");
                                    insdatacmd.Parameters.AddWithValue("@status", "Approval");
                                    insdatacmd.Parameters.AddWithValue("@dtreg", DateTime.Today);

                                    int i = insdatacmd.ExecuteNonQuery();

                                    MessageBox.Show("Registration Successfull", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                }
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
            TxtBxConfrmPswrd.Text = string.Empty;
        }

        private void ChkBxPswrd_CheckedChanged(object sender, EventArgs e)
        {
            TxtBxPswrd.UseSystemPasswordChar = !ChkBxPswrd.Checked;
            TxtBxConfrmPswrd.UseSystemPasswordChar = !ChkBxPswrd.Checked;
        }

        private void LbSigninAcc_Click(object sender, EventArgs e)
        {
            Form1Login login = new Form1Login();
            login.Show();
            Hide();
        }
    }
}
