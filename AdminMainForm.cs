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
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void AdminMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure You Want to Close ? ", "Confirmation Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else { Application.ExitThread(); }
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            BtnDashboard.BackColor = Color.FromArgb(54, 54, 0);

            UCDashBoard1.Show();
            UCAdminUsers1.Hide();
            UCAdminCategories1.Hide();
            UCProducts1.Hide();
            UCCustomers1.Hide();
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

            switch(btn.Name)
            {
                case "BtnDashboard":
                    UCDashBoard1.Show();
                    UCAdminUsers1.Hide();
                    UCAdminCategories1.Hide();
                    UCProducts1.Hide();
                    UCCustomers1.Hide();

                    UCDashBoard ucd = UCDashBoard1 as UCDashBoard;
                    ucd?.RefreshData();
                    break;
                case "BtnCashiers":
                    UCDashBoard1.Hide();
                    UCAdminUsers1.Show();
                    UCAdminCategories1.Hide();
                    UCProducts1.Hide();
                    UCCustomers1.Hide();

                    UCAdminUsers ucadmusers = UCAdminUsers1 as UCAdminUsers;
                    ucadmusers?.RefreshData();
                    break;
                case "BtnCategories":
                    UCDashBoard1.Hide();
                    UCAdminUsers1.Hide();
                    UCAdminCategories1.Show();
                    UCProducts1.Hide();
                    UCCustomers1.Hide();

                    UCAdminCategories ucadmcat = UCAdminCategories1 as UCAdminCategories;
                    ucadmcat?.RefreshData();
                    break;
                case "BtnProducts":
                    UCDashBoard1.Hide();
                    UCAdminUsers1.Hide();
                    UCAdminCategories1.Hide();
                    UCProducts1.Show();
                    UCCustomers1.Hide();

                    UCProducts ucprods = UCProducts1 as UCProducts;
                    ucprods?.RefreshData();
                    break;
                case "BtnCustomers":
                    UCDashBoard1.Hide();
                    UCAdminUsers1.Hide();
                    UCAdminCategories1.Hide();
                    UCProducts1.Hide();
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
