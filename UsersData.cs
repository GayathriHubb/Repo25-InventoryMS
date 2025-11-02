using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    internal class UsersData
    {
        public UsersData() { }

        readonly SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\InventoryManagementSystem\Inventory.mdf;Integrated Security = True");

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string DateRegister { get; set; }

        public List<UsersData> ListUsersData()
        {
            List<UsersData> udlist = new List<UsersData>();

            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    con.Open();

                    string selectdata = "Select * From Users";
                    using (SqlCommand selectdatacmd = new SqlCommand(selectdata, con))
                    {
                        SqlDataReader sdr = selectdatacmd.ExecuteReader();

                        while (sdr.Read())
                        {
                            UsersData ud = new UsersData();

                            ud.Id = (int)sdr["Id"];
                            ud.UserName = sdr["Username"].ToString();
                            ud.Password = sdr["Password"].ToString();
                            ud.Role = sdr["Role"].ToString();
                            ud.Status = sdr["Status"].ToString();
                            ud.DateRegister = (Convert.ToDateTime(sdr["DateRegister"])).ToString("dd-MM-yyyy");

                            udlist.Add(ud);
                        }
                    }
                }
                catch (Exception ex)
                { Debug.WriteLine(ex.Message, "Error Message"); }
                finally { con.Close(); }
            }

            return udlist;
        }
    }
}
