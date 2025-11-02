using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    internal class CustomersData
    {
        public CustomersData() { }

        readonly SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\InventoryManagementSystem\Inventory.mdf;Integrated Security = True");

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public float TotalPrice { get; set; }
        public float TotalWithGST { get; set; }
        public float TenderedCash { get; set; }
        public float TenderedChange {  get; set; }
        public string OrderDate { get; set; }

        public List<CustomersData> ListCustmsData()
        {
            List<CustomersData> custms = new List<CustomersData>();

            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    con.Open();

                    string seldata = "Select * From Customers";

                    using (SqlCommand selcmd = new SqlCommand(seldata, con))
                    {
                        SqlDataReader sdr = selcmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            CustomersData cd = new CustomersData();

                            cd.Id = (int)sdr["Id"];
                            cd.CustomerId = (int)sdr["CustomerId"];
                            cd.TotalPrice = Convert.ToSingle(sdr["TotalPrice"]);
                            cd.TenderedCash = Convert.ToSingle(sdr["Amount"]);
                            cd.TenderedChange = Convert.ToSingle(sdr["Change"]);
                            cd.OrderDate = (Convert.ToDateTime(sdr["OrderDate"])).ToString("dd-MM-yyyy");

                            if (sdr["TotalWithGST"] != DBNull.Value)
                            {
                                cd.TotalWithGST = Convert.ToSingle(sdr["TotalWithGST"]);
                            }

                            custms.Add(cd);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "CustomersData");
                }
                finally { con.Close(); }
            }

            return custms;
        }

        public List<CustomersData> ListTodayCustms()
        {
            List<CustomersData> custms = new List<CustomersData>();

            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();

                    string seldata = "Select * From Customers Where OrderDate = @orddt";

                    using (SqlCommand selcmd = new SqlCommand(seldata, con))
                    {
                        selcmd.Parameters.AddWithValue("@orddt", DateTime.Today);

                        SqlDataReader sdr = selcmd.ExecuteReader();

                        while (sdr.Read())
                        {
                            CustomersData cd = new CustomersData();

                            cd.Id = (int)sdr["Id"];
                            cd.CustomerId = (int)sdr["CustomerId"];
                            cd.TotalPrice = Convert.ToSingle(sdr["TotalPrice"]);
                            cd.TenderedCash = Convert.ToSingle(sdr["Amount"]);
                            cd.TenderedChange = Convert.ToSingle(sdr["Change"]);
                            cd.OrderDate = (Convert.ToDateTime(sdr["OrderDate"])).ToString("dd-MM-yyyy");

                            if (sdr["TotalWithGST"] != DBNull.Value)
                            {
                                cd.TotalWithGST = Convert.ToSingle(sdr["TotalWithGST"]);
                            }

                            custms.Add(cd);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally { con.Close(); }
            }

            return custms;
        }

    }
}
