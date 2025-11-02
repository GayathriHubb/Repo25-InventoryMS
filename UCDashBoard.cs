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
    public partial class UCDashBoard : UserControl
    {
        public UCDashBoard()
        {
            InitializeComponent();
        }

        readonly SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\InventoryManagementSystem\Inventory.mdf;Integrated Security = True");

        private void UCDashBoard_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                try
                {
                    DisplayTotalUsers();
                    DisplayTotalCustms();
                    DisplayTodayIncome();
                    DisplayTotalIncome();
                    DisplayTodayCustms();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        public void DisplayTotalUsers()
        {
            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();

                    string seldata = "Select Count(*) From Users Where Role = @role";

                    using (SqlCommand selcmd = new SqlCommand(seldata, con))
                    {
                        selcmd.Parameters.AddWithValue("@role", "Cashier");

                        object result = selcmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            LbCashiers.Text = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DTotUsers - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally { con.Close(); }
            }
        }

        public void DisplayTotalCustms()
        {
            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();

                    string seldata = "Select Count(*) From Customers";

                    using (SqlCommand selcmd = new SqlCommand(seldata, con))
                    {
                        object result = selcmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            LbCustms.Text = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DTotUsers - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally { con.Close(); }
            }
        }

        public void DisplayTodayIncome()
        {
            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();

                    string seldata = "Select SUM(TotalPrice) From Customers Where OrderDate = @orddt";

                    using (SqlCommand selcmd = new SqlCommand(seldata, con))
                    {
                        selcmd.Parameters.AddWithValue("@orddt", DateTime.Today);
                        object result = selcmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            LbTodIncome.Text = $"{result:0.##}";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DTodInc - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally { con.Close(); }
            }
        }

        public void DisplayTotalIncome()
        {
            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();

                    string seldata = "Select SUM(TotalPrice) From Customers";

                    using (SqlCommand selcmd = new SqlCommand(seldata, con))
                    {
                        object result = selcmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            LbTotIncome.Text = $"{result:0.##}";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DTotInc - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally { con.Close(); }
            }
        }

        public void DisplayTodayCustms()
        {
            CustomersData cd = new CustomersData();
            DGVTodayCustms.DataSource = cd.ListTodayCustms();
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            DisplayTotalUsers();
            DisplayTotalCustms();
            DisplayTodayIncome();
            DisplayTotalIncome();
            DisplayTodayCustms();

        }
    }
}
