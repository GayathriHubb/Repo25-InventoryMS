using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class StaffMainForm : Form
    {
        public StaffMainForm()
        {
            InitializeComponent();
        }

        private void StaffMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure You Want to Close ? ", "Confirmation Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else { Application.ExitThread(); }
        }

        private void StaffMainForm_Load(object sender, EventArgs e)
        {
            BtnDashboard.BackColor = Color.FromArgb(54, 54, 0);

            UCDashBoard1.Show();
            UCProducts1.Hide();
            UCStaffOrders1.Hide();
            UCCustomers1.Hide();

            string un = InventoryData.Username;
            LbUser.Text = $"{un.Substring(0, 1).ToUpper()}{un.Substring(1)} !";
        }
        private void MainButtons_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            foreach (Button b in PnlLeft.Controls.OfType<Button>())
            {
                if ((string)b.Tag == "MainBtns")
                { b.BackColor = Color.FromArgb(110, 40, 5); }
            }

            btn.BackColor = Color.FromArgb(54, 54, 0);

            switch (btn.Name)
            {
                case "BtnDashboard":
                    UCDashBoard1.Show();
                    UCProducts1.Hide();
                    UCStaffOrders1.Hide();
                    UCCustomers1.Hide();

                    UCDashBoard ucd = UCDashBoard1 as UCDashBoard;
                    ucd?.RefreshData();
                    break;
                case "BtnProducts":
                    UCDashBoard1.Hide();
                    UCProducts1.Show();
                    UCStaffOrders1.Hide();
                    UCCustomers1.Hide();

                    UCProducts ucprods = UCProducts1 as UCProducts;
                    ucprods?.RefreshData();
                    break;
                case "BtnOrders":
                    UCDashBoard1.Hide();
                    UCProducts1.Hide();
                    UCStaffOrders1.Show();
                    UCCustomers1.Hide();

                    UCStaffOrders ucstfords = UCStaffOrders1 as UCStaffOrders;
                    ucstfords?.RefreshData();
                    break;
                case "BtnCustomers":
                    UCDashBoard1.Hide();
                    UCProducts1.Hide();
                    UCStaffOrders1.Hide();
                    UCCustomers1.Show();

                    UCCustomers uccustms = UCCustomers1 as UCCustomers;
                    uccustms?.RefreshData();
                    break;
                default: UCDashBoard1.Show(); break;
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure You Want To Logout ?", "Confirmation Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Form1Login loginform = new Form1Login();
                loginform.Show();
                Hide();
            }
        }

        
    }
}
