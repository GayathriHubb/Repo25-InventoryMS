using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class UCCustomers : UserControl
    {
        public UCCustomers()
        {
            InitializeComponent();
        }

        readonly SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\InventoryManagementSystem\Inventory.mdf;Integrated Security = True");

        private void UCCustomers_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime) 
            {
                try
                {
                    DisplayCustmsData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load - Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        DataGridViewRow row;
        private void DGVCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.RowIndex != -1)
           {  row = DGVCustomers.Rows[e.RowIndex]; }
        }
        public void DisplayCustmsData()
        {
            CustomersData cd = new CustomersData();
            DGVCustomers.DataSource = cd.ListCustmsData();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            DisplayCustmsData();
        }

        private void BtnReceipt_Click(object sender, EventArgs e)
        {
            PD1.PrintPage += new PrintPageEventHandler(PD1_PrintPage);

            PPD1.ShowDialog();
        }

        private void PD1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;

                int centrex1 = (int)(e.PageBounds.Width - g.MeasureString("Arsenal Inventory Management", new Font("Cambria", 18, FontStyle.Bold)).Width) / 2;
                int centrex2 = (int)(e.PageBounds.Width - g.MeasureString("------------  HAVE A GOOD DAY  ------------", new Font("Cambria", 16, FontStyle.Bold)).Width) / 2;
                int heading1y = 100;
                int remdatay = heading1y + 100;
                int remdatax = 50;

                Font f = new Font("Calibri", 13, FontStyle.Bold);

                g.DrawString("Arsenal Inventory Management", new Font("Cambria", 16, FontStyle.Bold), Brushes.Firebrick, new Point(centrex1, heading1y));

                g.DrawString($"Customer Id:  {row.Cells[1].Value}", f, Brushes.Black, new Point(remdatax, remdatay + 50));
                g.DrawString($"Total Price:  {row.Cells[2].Value}", f, Brushes.Black, new Point(remdatax, remdatay + 100));
                g.DrawString($"Tendered Cash:   {row.Cells[3].Value}", f, Brushes.Black, new Point(remdatax, remdatay + 150));
                g.DrawString($"Tendered Change: {row.Cells[4].Value}", f, Brushes.Black, new Point(remdatax, remdatay + 200));
                g.DrawString($"Order Date:  {row.Cells[5].Value}", f, Brushes.Black, new Point(remdatax, remdatay + 250));


                g.DrawString("------------  HAVE A GOOD DAY  ------------", f, Brushes.Firebrick, new Point(centrex2, remdatay + 400));
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }
    }
}
