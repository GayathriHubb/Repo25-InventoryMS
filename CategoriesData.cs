using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    internal class CategoriesData
    {
        public CategoriesData() { }

        readonly SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\InventoryManagementSystem\Inventory.mdf;Integrated Security = True");

        public int Id { get; set; }
        public string Category { get; set; }
        public string DateInsert { get; set; }

        public List<CategoriesData> ListCategoriesData()
        {
            List<CategoriesData> categories = new List<CategoriesData>();

            if (con.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    con.Open();

                    string seldata = "Select * From Categories";

                    using (SqlCommand selcmd = new SqlCommand(seldata, con)) 
                    {
                        SqlDataReader sdr = selcmd.ExecuteReader();
                        while (sdr.Read()) 
                        {
                            CategoriesData cd = new CategoriesData();

                            cd.Id = (int)sdr["Id"];
                            cd.Category = (string)sdr["Category"];
                            cd.DateInsert = (Convert.ToDateTime(sdr["DateAdded"])).ToString("dd-MM-yyyy");

                            categories.Add(cd);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "CategoriesData");
                }
                finally
                { con.Close(); }

            }

            return categories;

        }
    }
}
