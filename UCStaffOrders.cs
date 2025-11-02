using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class UCStaffOrders : UserControl
    {
        public UCStaffOrders()
        {
            InitializeComponent();
        }

        readonly string constring = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\InventoryManagementSystem\Inventory.mdf;Integrated Security = True";

        public static int getcustid;
        private void UCStaffOrders_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                try
                {
                    DisplayCategories();
                    DisplayAvailProds();
                    DisplayOrdersData();
                    DisplayTotalPrice();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Load - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
            }
        }
               
        private void BtnInsert_Click(object sender, EventArgs e)
        {
           if (CmbBxCategory.Text == string.Empty || CmbBxProducts.Text == string.Empty || LbPId.Text == string.Empty || LbPPrice.Text == string.Empty || NumUpdownQty.Value == 0)
           { 
                MessageBox.Show("All Fields Are Required To be Filled", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
           }
           using (SqlConnection sqlcon = new SqlConnection(constring))
           {
                try
                {
                    sqlcon.Open();
                    IdGenerator();
                    string seldata = "Select * From Products Where ProductId = @pid";
                    float getprice = 0;
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        selcmd.Parameters.AddWithValue("@pid", LbPId.Text);

                        SqlDataReader sdr = selcmd.ExecuteReader();

                        if (sdr.Read())
                        {
                            object rawvalue = sdr["Price"];
                            if (rawvalue != DBNull.Value)
                            {
                                getprice = Convert.ToSingle(rawvalue);
                            }
                        }
                        sdr.Close();

                        string insdata = "Insert Into Orders (CustomerId, ProductId, Category, ProductName, ProductQty, POrigPrice, PTotalPrice, OrderDate) " +
                            "Values (@custid, @pid, @cat, @pname, @pqty, @porgprice, @ptotprice, @orddt)";

                        using (SqlCommand inscmd = new SqlCommand(insdata, sqlcon))
                        {
                            float totalprice = getprice * (int)NumUpdownQty.Value;

                            inscmd.Parameters.AddWithValue("@custid", idgen);
                            inscmd.Parameters.AddWithValue("@pid", LbPId.Text);
                            inscmd.Parameters.AddWithValue("@cat", CmbBxCategory.Text);
                            inscmd.Parameters.AddWithValue("@pname", CmbBxProducts.Text);
                            inscmd.Parameters.AddWithValue("@pqty", NumUpdownQty.Value);
                            inscmd.Parameters.AddWithValue("@porgprice", getprice);
                            inscmd.Parameters.AddWithValue("@ptotprice", totalprice);
                            inscmd.Parameters.AddWithValue("@orddt", DateTime.Today);

                            inscmd.ExecuteNonQuery();

                            DisplayOrdersData();
                            DisplayTotalPrice();
                            UpdateStockWhenAdd();
                            MessageBox.Show("Order Added Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }

                    }
                    sqlcon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Insert - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
           }

            ClearFields();
        }


        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (idord == 0)
            {
                MessageBox.Show("Please Select Item First", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                using (SqlConnection sqlcon = new SqlConnection(constring))
                {
                    try
                    {
                        sqlcon.Open();

                        DialogResult dr = MessageBox.Show($"Are You Sure You Want To Remove Id: {idord} ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            string remdata = "Delete From Orders Where Id = @id";

                            using (SqlCommand remcmd = new SqlCommand(remdata, sqlcon))
                            {
                                remcmd.Parameters.AddWithValue("@id", idord);

                                remcmd.ExecuteNonQuery();
                                DisplayOrdersData();
                                DisplayTotalPrice();
                                UpdateStockWhenRemove();
                                MessageBox.Show("Order Removed Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            }
                        }
                        sqlcon.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Remove - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
        }


        int idord, getpqty;
        string prodid;
        private void DGVOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                try
                {
                    DataGridViewRow row = DGVOrders.Rows[e.RowIndex];

                    idord = (int)row.Cells[0].Value;
                    prodid = row.Cells[2].Value.ToString();
                    getpqty = (int)row.Cells[5].Value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }


        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            if (TxtBxTPrice.Text == string.Empty || DGVOrders.Rows.Count <= 0)
            {
                MessageBox.Show("Something Went Wrong", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();
                    IdGenerator();
                    DisplayTotalPrice();
                    DialogResult dr = MessageBox.Show("Are you Sure To Pay the Orders ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        string insdata = "Insert Into Customers (CustomerId, TotalPrice, Amount, Change, OrderDate, TotalWithGST) Values (@custid, @totprice, @tencash, @tenchange, @orddt, @tgst)";

                        using (SqlCommand inscmd = new SqlCommand(insdata, sqlcon))
                        {
                            inscmd.Parameters.AddWithValue("@custid", idgen);
                            inscmd.Parameters.AddWithValue("@totprice", totalprice);
                            inscmd.Parameters.AddWithValue("@tgst", tpwgst.ToString("0.##"));
                            inscmd.Parameters.AddWithValue("@tencash", TxtBxTenCash.Text.Trim());
                            inscmd.Parameters.AddWithValue("@tenchange", TxtBxTenChange.Text.Trim());
                            inscmd.Parameters.AddWithValue("@orddt", DateTime.Today);

                            inscmd.ExecuteNonQuery();

                            MessageBox.Show("Orders Paid Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }
                    }
                    sqlcon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Pay - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
           
        }
                
         
        private void BtnReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtBxTenCash.Text == string.Empty || DGVOrders.Rows.Count < 0)
                {
                    MessageBox.Show("Please Order First", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                PPD1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "BtnReceipt - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        int getid, getpstock;
        private void DGVAvlProds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) 
            { 
                DataGridViewRow row = DGVAvlProds.Rows[e.RowIndex];

                getid = (int) row.Cells[0].Value;
                getpstock = (int) row.Cells[4].Value;   

                LbPId.Text = row.Cells[1].Value.ToString();
                CmbBxProducts.Text = row.Cells[2].Value.ToString();
                CmbBxCategory.SelectedItem = row.Cells[3].Value.ToString();
                LbPPrice.Text = row.Cells[5].Value.ToString();
            }
        }

        private void TxtBxTenCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    float getamount = Convert.ToSingle(TxtBxTenCash.Text);
                    float getchange = getamount - Convert.ToSingle(TxtBxTPGST.Text);

                    if (getchange <= -1)
                    {
                        TxtBxTenCash.Text = string.Empty;
                        TxtBxTenChange.Text = string.Empty;
                    }

                    TxtBxTenChange.Text = getchange.ToString("0.##");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "TxtBxKeyDown - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

       
        private void ClearFields()
        {
            LbPId.Text = string.Empty;
            CmbBxCategory.Text = string.Empty;
            CmbBxProducts.Text= string.Empty;
            LbPPrice.Text = string.Empty;
            NumUpdownQty.Value = 0;
        }

        public void DisplayCategories()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {

                    sqlcon.Open();
                    CmbBxCategory.Items.Clear();
                    string seldata = "Select * From Categories";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        SqlDataReader sdr = selcmd.ExecuteReader();

                        while (sdr.Read())
                        {
                            CmbBxCategory.Items.Add(sdr.GetString(1));
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "DisplayCategories - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }


        private void CmbBxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbBxProducts.Text = string.Empty;
            CmbBxProducts.Items.Clear();
            LbPId.Text = "--------";
            LbPPrice.Text = "--------";

            string selectedcat = CmbBxCategory.SelectedItem.ToString();

            if (selectedcat != null)
            {
                using (SqlConnection sqlcon = new SqlConnection(constring))
                {
                    sqlcon.Open();

                    string seldata = $"Select * From Products Where Category = '{selectedcat}' AND Status = @status";

                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        selcmd.Parameters.AddWithValue("@status", "Available");
                        SqlDataReader sdr = selcmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            string prod = sdr["ProductName"].ToString();
                            CmbBxProducts.Items.Add(prod);
                        }
                    }
                    sqlcon.Close();
                }
            }
        }

        private void CmbBxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LbPId.Text = "--------";
            LbPPrice.Text = "--------";

            string selprod = CmbBxProducts.SelectedItem.ToString();

            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                sqlcon.Open();

                string seldata = $"Select * From Products Where ProductName = '{selprod}'";

                using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                {
                    SqlDataReader sdr = selcmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        string prodid = sdr["ProductId"].ToString();
                        float prodprice = Convert.ToSingle(sdr["Price"]);

                        LbPId.Text = prodid;
                        LbPPrice.Text = prodprice.ToString();
                    }

                }
                sqlcon.Close();
            }
        }
                    

        int idgen;
        public void IdGenerator()
        {
            using (SqlConnection sqlcon = new SqlConnection((constring)))
            {
                sqlcon.Open();

                // Use ISNULL to ensure we always get an integer back (0 when table empty)
                string selid = "Select ISNULL(MAX(CustomerId), 0) From Customers";
                using (SqlCommand idcmd = new SqlCommand(selid, sqlcon))
                {
                    object result = idcmd.ExecuteScalar();

                    int maxId = 0;
                    if (result != null && result != DBNull.Value)
                    {
                        int.TryParse(result.ToString(), out maxId);
                    }

                    // If maxId is 0, start ids at 1; otherwise increment.
                    idgen = (maxId == 0) ? 1 : (maxId + 1);
                }
                sqlcon.Close();
            }
        }  
       

        float totalprice; 
        double gst, tpwgst;
        public void DisplayTotalPrice()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();
                    IdGenerator();

                    string seldata = "Select SUM(PTotalPrice) From Orders Where CustomerId = @custid";

                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        selcmd.Parameters.AddWithValue("@custid", idgen);
                        object result = selcmd.ExecuteScalar();

                        gst = totalprice * 0.045;

                        if (result != DBNull.Value)
                        {
                            totalprice = Convert.ToSingle(result);
                            tpwgst = totalprice * 1.045;

                            TxtBxTPrice.Text = totalprice.ToString("0.##");
                            TxtBxTPGST.Text = tpwgst.ToString("0.##");
                        }
                    }
                    sqlcon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DispTotPrice - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }
        
        public void DisplayAvailProds()
        {
            AvailProductsData apd = new AvailProductsData();
            DGVAvlProds.DataSource = apd.ListAvailProds();
        }

        public void DisplayOrdersData()
        {
            OrdersData od = new OrdersData();
            DGVOrders.DataSource = od.ListOrdersData();
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            DisplayCategories();
            DisplayAvailProds();
            DisplayOrdersData();
            DisplayTotalPrice();
        }

        int rowindex;
        private void PD1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DisplayTotalPrice();
            IdGenerator();

            int y = 50;
            int left = 50;
            int colwidth = 120;

            Font headerfont = new Font("Cambria", 18, FontStyle.Bold);
            Font font = new Font("Arial", 12, FontStyle.Bold);
            Font smallfont = new Font("Segoe UI", 10);

            int centrex1 = (int)(e.PageBounds.Width - e.Graphics.MeasureString("Arsenal Inventory Store", headerfont).Width) / 2;
            int centrex2 = (int)(e.PageBounds.Width - e.Graphics.MeasureString("Thank You for Shopping!", font).Width)/2;
            int centrex3 = (int)(e.PageBounds.Width - e.Graphics.MeasureString("Visit Again!", font).Width)/2;

            // ✅ Store Header
            e.Graphics.DrawString("Arsenal Inventory Store", headerfont, Brushes.Firebrick, centrex1, y);
            y += 80;

            string date = $"Date: {DateTime.Now:dd/MM/yyyy hh:mm tt}";
            int datex = (int)((left + 720) - e.Graphics.MeasureString(date, font).Width);

            // ✅ Date + Bill No
            e.Graphics.DrawString($"Bill No: {idgen - 1}", font, Brushes.Black, left, y);
            e.Graphics.DrawString(date, font, Brushes.Black, datex, y);
            y += 30;

            e.Graphics.DrawLine(Pens.Black, left, y, left + 720, y);
            y += 20;

            // ✅ Table Headers
            string[] headers = { "Product Id", "ProductName", "Category", "Quantity", "Price", "Total" };
            for (int i = 0; i < headers.Length; i++)
            {
                e.Graphics.DrawString(headers[i], font, Brushes.Navy, left + (i * colwidth), y);
            }
            y += 25;

            e.Graphics.DrawLine(Pens.Black, left, y, left + 720, y);
            y += 10;

            // ✅ Table Rows
            while (rowindex < DGVOrders.Rows.Count)
            {
                DataGridViewRow row = DGVOrders.Rows[rowindex];

                e.Graphics.DrawString(row.Cells[2].Value.ToString(), smallfont, Brushes.Black, left + 0, y);

                string pname = row.Cells[3].Value.ToString();

                // Limit text width so it wraps
                int textwidth = 120;
                SizeF textsize = e.Graphics.MeasureString(pname, smallfont, textwidth);

                // Draw wrapped product name
                e.Graphics.DrawString(pname, smallfont, Brushes.Black, new RectangleF(left + 120, y, textwidth, textsize.Height));

                e.Graphics.DrawString(row.Cells[4].Value.ToString(), smallfont, Brushes.Black, left + 240, y);
                e.Graphics.DrawString(row.Cells[5].Value.ToString(), smallfont, Brushes.Black, left + 360, y);
                e.Graphics.DrawString(row.Cells[6].Value.ToString(), smallfont, Brushes.Black, left + 480, y);
                e.Graphics.DrawString(row.Cells[7].Value.ToString(), smallfont, Brushes.Black, left + 600, y);

                y += (int)textsize.Height > 25 ? (int)textsize.Height : 25; // Adjust y based on wrapped text height
                rowindex++;

                if (y > e.MarginBounds.Height)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            y += 20;
            e.Graphics.DrawLine(Pens.Black, left, y, left + 720, y);
            y += 20;

            // ✅ Summary Price Section
            DrawRightAligned(e.Graphics, "TotalPrice(₹):", $"{totalprice: 0.00}", font, left, ref y);
            DrawRightAligned(e.Graphics, "TotalWithGST(₹)(4.5%):", $"{tpwgst: 0.00}", font, left, ref y);
            DrawRightAligned(e.Graphics, "TenderedCash(₹):", $"{TxtBxTenCash.Text: 0.00}", font, left, ref y);
            DrawRightAligned(e.Graphics, "TenderedChange(₹):", $"{TxtBxTenChange.Text: 0.00}", font, left, ref y);

            y += 30;
            e.Graphics.DrawLine(Pens.Black, left, y, left + 720, y);
            y += 30;

            // ✅ Footer
            e.Graphics.DrawString("Thank You for Shopping!", font, Brushes.Black, centrex2, y);
            y += 25;
            e.Graphics.DrawString("Visit Again!", smallfont, Brushes.Black, centrex3, y);

            e.HasMorePages = false;

        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            DisplayAvailProds();
        }

        private void DrawRightAligned(Graphics g, string label, string value, Font font, int left, ref int y)
        {
            g.DrawString(label, font, Brushes.Black, left + 300, y);
            g.DrawString(value, font, Brushes.Black, left + 520, y);
            y += 25;
        }

        int stockafteradd;
        private void UpdateStockWhenAdd()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                sqlcon.Open();

                string seldata = "Update Products Set Stock = @pstock Where ProductId = @pid";
                int stockupd1 = getpstock - (int)NumUpdownQty.Value;

                using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                {
                    selcmd.Parameters.AddWithValue("@pid", LbPId.Text);
                    selcmd.Parameters.AddWithValue("@pstock", stockupd1);

                    selcmd.ExecuteNonQuery();

                    stockafteradd = stockupd1;
                }
            }
        }

        private void UpdateStockWhenRemove()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                sqlcon.Open();

                string seldata = "Update Products Set Stock = @pstock Where ProductId = @pid";
                int stockupd2 = stockafteradd + getpqty;
                using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                {
                    selcmd.Parameters.AddWithValue("@pid", prodid);
                    selcmd.Parameters.AddWithValue("@pstock", stockupd2);

                    selcmd.ExecuteNonQuery();
                }
            }
        }


    }
}
