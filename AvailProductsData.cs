using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;

namespace InventoryManagementSystem
{
    internal class AvailProductsData
    {
        public AvailProductsData() { }

        readonly SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\InventoryManagementSystem\Inventory.mdf;Integrated Security = True");

        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public float Price {  get; set; }
        public string Status {  get; set; }

        public List<AvailProductsData> ListAvailProds()
        {
            List<AvailProductsData> avlprods = new List<AvailProductsData>();

            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    con.Open();

                    string seldata = "Select * From Products Where Status = @status AND DateDelete is NULL";

                    using (SqlCommand selcmd = new SqlCommand(seldata, con))
                    {
                        selcmd.Parameters.AddWithValue("@status", "Available");

                        SqlDataReader sdr = selcmd.ExecuteReader();

                        while (sdr.Read()) 
                        { 
                            AvailProductsData apd = new AvailProductsData();

                            apd.Id = (int)sdr["Id"];
                            apd.ProductId = (string)sdr["ProductId"];
                            apd.Category = (string)sdr["Category"];
                            apd.ProductName = (string)sdr["ProductName"];
                            apd.Stock = (int)sdr["Stock"];
                            apd.Price = float.Parse((sdr["Price"]).ToString());
                            apd.Status = (string)sdr["Status"];

                            avlprods.Add(apd);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "AvailProductsData");
                }
                finally { con.Close(); }
            }

            return avlprods;
        }
    }
}
