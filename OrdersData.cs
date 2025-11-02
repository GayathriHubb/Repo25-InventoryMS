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
    internal class OrdersData
    {
        public OrdersData() { }

        readonly SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\InventoryManagementSystem\Inventory.mdf;Integrated Security = True");

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int ProductQty { get; set; }
        public float ProdOrigPrice { get; set; }
        public float ProdTotalPrice { get; set; }
        public string OrderDate { get; set; }

        public List<OrdersData> ListOrdersData()
        {
            List<OrdersData> orders = new List<OrdersData>();

            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    con.Open();
                    string selid = "Select MAX(CustomerId) From Orders";
                    int custid = 0;
                    using (SqlCommand idcmd = new SqlCommand(selid, con))
                    {
                        object result = idcmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            int temp = Convert.ToInt32(result);
                            if (temp == 0) { return null; }
                            else custid = temp;
                        }
                        else { Debug.WriteLine("Error Id"); }
                    }

                    string seldata = "Select * From Orders Where CustomerId = @custid";

                    using (SqlCommand selcmd = new SqlCommand(seldata, con))
                    {
                        selcmd.Parameters.AddWithValue("@custid", custid);
                        SqlDataReader sdr = selcmd.ExecuteReader();

                        while (sdr.Read())
                        {
                            OrdersData od = new OrdersData();

                            od.Id = (int)sdr["Id"];
                            od.CustomerId = (int)sdr["CustomerId"];
                            od.ProductId = (string)sdr["ProductId"];
                            od.Category = (string)sdr["Category"];
                            od.ProductName = (string)sdr["ProductName"];
                            od.ProductQty = (int)sdr["ProductQty"];
                            od.ProdOrigPrice = Convert.ToSingle(sdr["POrigPrice"]);
                            od.ProdTotalPrice = Convert.ToSingle(sdr["PtotalPrice"]);
                            od.OrderDate = (Convert.ToDateTime(sdr["OrderDate"])).ToString("dd-MM-yyyy");

                            orders.Add(od);
                        }

                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "OrdersData");
                }
            }

            return orders;
        }
    }
}
