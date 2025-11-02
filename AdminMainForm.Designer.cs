namespace InventoryManagementSystem
{
    partial class AdminMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PnlLeft = new System.Windows.Forms.Panel();
            this.BtnCategories = new System.Windows.Forms.Button();
            this.BtnLogout = new System.Windows.Forms.Button();
            this.BtnDashboard = new System.Windows.Forms.Button();
            this.BtnProducts = new System.Windows.Forms.Button();
            this.BtnCustomers = new System.Windows.Forms.Button();
            this.BtnCashiers = new System.Windows.Forms.Button();
            this.LbWelAdmn = new System.Windows.Forms.Label();
            this.LbAdmnsPrtal = new System.Windows.Forms.Label();
            this.PicBxInventory = new System.Windows.Forms.PictureBox();
            this.PnlRight = new System.Windows.Forms.Panel();
            this.UCDashBoard1 = new InventoryManagementSystem.UCDashBoard();
            this.UCAdminUsers1 = new InventoryManagementSystem.UCAdminUsers();
            this.UCAdminCategories1 = new InventoryManagementSystem.UCAdminCategories();
            this.UCProducts1 = new InventoryManagementSystem.UCProducts();
            this.UCCustomers1 = new InventoryManagementSystem.UCCustomers();
            this.PnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBxInventory)).BeginInit();
            this.PnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlLeft
            // 
            this.PnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.PnlLeft.Controls.Add(this.BtnCategories);
            this.PnlLeft.Controls.Add(this.BtnLogout);
            this.PnlLeft.Controls.Add(this.BtnDashboard);
            this.PnlLeft.Controls.Add(this.BtnProducts);
            this.PnlLeft.Controls.Add(this.BtnCustomers);
            this.PnlLeft.Controls.Add(this.BtnCashiers);
            this.PnlLeft.Controls.Add(this.LbWelAdmn);
            this.PnlLeft.Controls.Add(this.LbAdmnsPrtal);
            this.PnlLeft.Controls.Add(this.PicBxInventory);
            this.PnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlLeft.Location = new System.Drawing.Point(0, 0);
            this.PnlLeft.Name = "PnlLeft";
            this.PnlLeft.Size = new System.Drawing.Size(300, 844);
            this.PnlLeft.TabIndex = 0;
            // 
            // BtnCategories
            // 
            this.BtnCategories.AutoSize = true;
            this.BtnCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(40)))), ((int)(((byte)(5)))));
            this.BtnCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCategories.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(40)))), ((int)(((byte)(20)))));
            this.BtnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCategories.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCategories.ForeColor = System.Drawing.Color.Linen;
            this.BtnCategories.Location = new System.Drawing.Point(25, 382);
            this.BtnCategories.Name = "BtnCategories";
            this.BtnCategories.Size = new System.Drawing.Size(250, 50);
            this.BtnCategories.TabIndex = 10;
            this.BtnCategories.Tag = "MainBtns";
            this.BtnCategories.Text = "CATEGORIES";
            this.BtnCategories.UseVisualStyleBackColor = false;
            this.BtnCategories.Click += new System.EventHandler(this.MainButtons_Click);
            // 
            // BtnLogout
            // 
            this.BtnLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnLogout.AutoSize = true;
            this.BtnLogout.BackColor = System.Drawing.Color.Snow;
            this.BtnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BtnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogout.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(40)))), ((int)(((byte)(5)))));
            this.BtnLogout.Location = new System.Drawing.Point(25, 700);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Size = new System.Drawing.Size(250, 50);
            this.BtnLogout.TabIndex = 9;
            this.BtnLogout.Tag = "";
            this.BtnLogout.Text = "LOGOUT";
            this.BtnLogout.UseVisualStyleBackColor = false;
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // BtnDashboard
            // 
            this.BtnDashboard.AutoSize = true;
            this.BtnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(0)))));
            this.BtnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(40)))), ((int)(((byte)(20)))));
            this.BtnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDashboard.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDashboard.ForeColor = System.Drawing.Color.Linen;
            this.BtnDashboard.Location = new System.Drawing.Point(25, 244);
            this.BtnDashboard.Name = "BtnDashboard";
            this.BtnDashboard.Size = new System.Drawing.Size(250, 50);
            this.BtnDashboard.TabIndex = 5;
            this.BtnDashboard.Tag = "MainBtns";
            this.BtnDashboard.Text = "DASHBOARD";
            this.BtnDashboard.UseVisualStyleBackColor = false;
            this.BtnDashboard.Click += new System.EventHandler(this.MainButtons_Click);
            // 
            // BtnProducts
            // 
            this.BtnProducts.AutoSize = true;
            this.BtnProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(40)))), ((int)(((byte)(5)))));
            this.BtnProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnProducts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(40)))), ((int)(((byte)(20)))));
            this.BtnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProducts.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProducts.ForeColor = System.Drawing.Color.Linen;
            this.BtnProducts.Location = new System.Drawing.Point(25, 451);
            this.BtnProducts.Name = "BtnProducts";
            this.BtnProducts.Size = new System.Drawing.Size(250, 50);
            this.BtnProducts.TabIndex = 7;
            this.BtnProducts.Tag = "MainBtns";
            this.BtnProducts.Text = "PRODUCTS";
            this.BtnProducts.UseVisualStyleBackColor = false;
            this.BtnProducts.Click += new System.EventHandler(this.MainButtons_Click);
            // 
            // BtnCustomers
            // 
            this.BtnCustomers.AutoSize = true;
            this.BtnCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(40)))), ((int)(((byte)(5)))));
            this.BtnCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCustomers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(40)))), ((int)(((byte)(20)))));
            this.BtnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCustomers.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCustomers.ForeColor = System.Drawing.Color.Linen;
            this.BtnCustomers.Location = new System.Drawing.Point(25, 520);
            this.BtnCustomers.Name = "BtnCustomers";
            this.BtnCustomers.Size = new System.Drawing.Size(250, 50);
            this.BtnCustomers.TabIndex = 8;
            this.BtnCustomers.Tag = "MainBtns";
            this.BtnCustomers.Text = "CUSTOMERS";
            this.BtnCustomers.UseVisualStyleBackColor = false;
            this.BtnCustomers.Click += new System.EventHandler(this.MainButtons_Click);
            // 
            // BtnCashiers
            // 
            this.BtnCashiers.AutoSize = true;
            this.BtnCashiers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(40)))), ((int)(((byte)(5)))));
            this.BtnCashiers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCashiers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(40)))), ((int)(((byte)(20)))));
            this.BtnCashiers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCashiers.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCashiers.ForeColor = System.Drawing.Color.Linen;
            this.BtnCashiers.Location = new System.Drawing.Point(25, 313);
            this.BtnCashiers.Name = "BtnCashiers";
            this.BtnCashiers.Size = new System.Drawing.Size(250, 50);
            this.BtnCashiers.TabIndex = 6;
            this.BtnCashiers.Tag = "MainBtns";
            this.BtnCashiers.Text = "USERS";
            this.BtnCashiers.UseVisualStyleBackColor = false;
            this.BtnCashiers.Click += new System.EventHandler(this.MainButtons_Click);
            // 
            // LbWelAdmn
            // 
            this.LbWelAdmn.AutoSize = true;
            this.LbWelAdmn.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbWelAdmn.ForeColor = System.Drawing.Color.Snow;
            this.LbWelAdmn.Location = new System.Drawing.Point(31, 170);
            this.LbWelAdmn.Name = "LbWelAdmn";
            this.LbWelAdmn.Size = new System.Drawing.Size(238, 27);
            this.LbWelAdmn.TabIndex = 2;
            this.LbWelAdmn.Text = "Welcome, Admin !";
            this.LbWelAdmn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbAdmnsPrtal
            // 
            this.LbAdmnsPrtal.AutoSize = true;
            this.LbAdmnsPrtal.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbAdmnsPrtal.ForeColor = System.Drawing.Color.Snow;
            this.LbAdmnsPrtal.Location = new System.Drawing.Point(51, 130);
            this.LbAdmnsPrtal.Name = "LbAdmnsPrtal";
            this.LbAdmnsPrtal.Size = new System.Drawing.Size(199, 27);
            this.LbAdmnsPrtal.TabIndex = 1;
            this.LbAdmnsPrtal.Text = "Admin\'s Portal";
            this.LbAdmnsPrtal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PicBxInventory
            // 
            this.PicBxInventory.Image = global::InventoryManagementSystem.Properties.Resources.InventoryMngmnt;
            this.PicBxInventory.Location = new System.Drawing.Point(100, 20);
            this.PicBxInventory.Name = "PicBxInventory";
            this.PicBxInventory.Size = new System.Drawing.Size(100, 100);
            this.PicBxInventory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBxInventory.TabIndex = 0;
            this.PicBxInventory.TabStop = false;
            // 
            // PnlRight
            // 
            this.PnlRight.Controls.Add(this.UCDashBoard1);
            this.PnlRight.Controls.Add(this.UCAdminUsers1);
            this.PnlRight.Controls.Add(this.UCAdminCategories1);
            this.PnlRight.Controls.Add(this.UCProducts1);
            this.PnlRight.Controls.Add(this.UCCustomers1);
            this.PnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlRight.Location = new System.Drawing.Point(300, 0);
            this.PnlRight.Name = "PnlRight";
            this.PnlRight.Size = new System.Drawing.Size(1078, 844);
            this.PnlRight.TabIndex = 1;
            // 
            // UCDashBoard1
            // 
            this.UCDashBoard1.AutoScroll = true;
            this.UCDashBoard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCDashBoard1.Location = new System.Drawing.Point(0, 0);
            this.UCDashBoard1.Name = "UCDashBoard1";
            this.UCDashBoard1.Size = new System.Drawing.Size(1078, 844);
            this.UCDashBoard1.TabIndex = 2;
            // 
            // UCAdminUsers1
            // 
            this.UCAdminUsers1.AutoScroll = true;
            this.UCAdminUsers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCAdminUsers1.Location = new System.Drawing.Point(0, 0);
            this.UCAdminUsers1.Name = "UCAdminUsers1";
            this.UCAdminUsers1.Size = new System.Drawing.Size(1078, 844);
            this.UCAdminUsers1.TabIndex = 3;
            // 
            // UCAdminCategories1
            // 
            this.UCAdminCategories1.AutoScroll = true;
            this.UCAdminCategories1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCAdminCategories1.Location = new System.Drawing.Point(0, 0);
            this.UCAdminCategories1.Name = "UCAdminCategories1";
            this.UCAdminCategories1.Size = new System.Drawing.Size(1078, 844);
            this.UCAdminCategories1.TabIndex = 2;
            // 
            // UCProducts1
            // 
            this.UCProducts1.AutoScroll = true;
            this.UCProducts1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCProducts1.Location = new System.Drawing.Point(0, 0);
            this.UCProducts1.Name = "UCProducts1";
            this.UCProducts1.Size = new System.Drawing.Size(1078, 844);
            this.UCProducts1.TabIndex = 1;
            // 
            // UCCustomers1
            // 
            this.UCCustomers1.AutoScroll = true;
            this.UCCustomers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCCustomers1.Location = new System.Drawing.Point(0, 0);
            this.UCCustomers1.Name = "UCCustomers1";
            this.UCCustomers1.Size = new System.Drawing.Size(1078, 844);
            this.UCCustomers1.TabIndex = 0;
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 844);
            this.Controls.Add(this.PnlRight);
            this.Controls.Add(this.PnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminMainForm";
            this.Text = "Inventory Management System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminMainForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminMainForm_Load);
            this.PnlLeft.ResumeLayout(false);
            this.PnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBxInventory)).EndInit();
            this.PnlRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlLeft;
        private System.Windows.Forms.Label LbAdmnsPrtal;
        private System.Windows.Forms.PictureBox PicBxInventory;
        private System.Windows.Forms.Panel PnlRight;
        private System.Windows.Forms.Label LbWelAdmn;
        private System.Windows.Forms.Button BtnDashboard;
        private System.Windows.Forms.Button BtnProducts;
        private System.Windows.Forms.Button BtnCustomers;
        private System.Windows.Forms.Button BtnCashiers;
        private System.Windows.Forms.Button BtnLogout;
        private System.Windows.Forms.Button BtnCategories;
        private UCAdminUsers UCAdminUsers1;
        private UCAdminCategories UCAdminCategories1;
        private UCProducts UCProducts1;
        private UCCustomers UCCustomers1;
        private UCDashBoard UCDashBoard1;
    }
}