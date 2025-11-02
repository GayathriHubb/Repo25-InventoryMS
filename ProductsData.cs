using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;

namespace InventoryManagementSystem
{
    internal class ProductsData
    {
        public ProductsData() { }

        readonly SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\InventoryManagementSystem\Inventory.mdf;Integrated Security = True");

        public int Id { get; set; }
        public string ProductId { get; set; }
        public string Category { get; set; }    
        public string ProductName { get; set; }
        public int Stock { get; set; }  
        public float Price { get; set; }
        public string Status { get; set; }  
        public string ImagePath { get; set; }   
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }
        public string DateDelete { get; set; }

        public override string ToString()
        {
            return $"{Id}, {ProductId}, {Category}, {ProductName}, {Stock}, {Price}, {Status}, {DateInsert}, {DateUpdate}, {DateDelete}";
        }

        public List<ProductsData> ListProductsData()
        {
            List<ProductsData> prodslist = new List<ProductsData>();

            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    con.Open();
                    string seldata = "Select * From Products Where DateDelete is NULL";
                    using (SqlCommand selcmd = new SqlCommand(seldata, con))
                    {
                        SqlDataReader sdr = selcmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            ProductsData pd = new ProductsData();

                            pd.Id = (int)sdr["Id"];
                            pd.ProductId = (string)sdr["ProductId"];
                            pd.Category = (string)sdr["Category"];
                            pd.ProductName = (string)sdr["ProductName"];
                            pd.Stock = (int)sdr["Stock"];
                            pd.Price = float.Parse(sdr["Price"].ToString());
                            pd.Status = (string)sdr["Status"]; 
                            pd.ImagePath = (sdr["ImagePath"] == DBNull.Value) ? null : (string)sdr["ImagePath"];
                            pd.DateInsert = (Convert.ToDateTime(sdr["DateInsert"])).ToString("dd-MM-yyyy");
                            pd.DateUpdate = (sdr["DateUpdate"] == DBNull.Value) ? null : (Convert.ToDateTime(sdr["DateUpdate"])).ToString("dd-MM-yyyy");
                            pd.DateDelete = (sdr["DateDelete"] == DBNull.Value) ? null : (Convert.ToDateTime(sdr["DateDelete"])).ToString("dd-MM-yyyy");

                            prodslist.Add(pd);
                        }
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message, "ProductsData");    
                }
                finally { con.Close(); }
            } 

            return prodslist;

        }
    }
}
