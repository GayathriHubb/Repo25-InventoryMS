namespace InventoryManagementSystem
{
    partial class Form1Login
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
            this.Pnl1 = new System.Windows.Forms.Panel();
            this.LbRegAcc = new System.Windows.Forms.Label();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.PicBxUser = new System.Windows.Forms.PictureBox();
            this.PicBxPswrd = new System.Windows.Forms.PictureBox();
            this.ChkBxPswrd = new System.Windows.Forms.CheckBox();
            this.TxtBxPswrd = new System.Windows.Forms.TextBox();
            this.TxtBxUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PicBxProfile = new System.Windows.Forms.PictureBox();
            this.LbHeading = new System.Windows.Forms.Label();
            this.Pnl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBxUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBxPswrd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl1
            // 
            this.Pnl1.BackColor = System.Drawing.Color.Snow;
            this.Pnl1.Controls.Add(this.LbRegAcc);
            this.Pnl1.Controls.Add(this.BtnClear);
            this.Pnl1.Controls.Add(this.BtnLogin);
            this.Pnl1.Controls.Add(this.PicBxUser);
            this.Pnl1.Controls.Add(this.PicBxPswrd);
            this.Pnl1.Controls.Add(this.ChkBxPswrd);
            this.Pnl1.Controls.Add(this.TxtBxPswrd);
            this.Pnl1.Controls.Add(this.TxtBxUsername);
            this.Pnl1.Controls.Add(this.label1);
            this.Pnl1.Controls.Add(this.PicBxProfile);
            this.Pnl1.Location = new System.Drawing.Point(89, 72);
            this.Pnl1.Name = "Pnl1";
            this.Pnl1.Size = new System.Drawing.Size(700, 500);
            this.Pnl1.TabIndex = 0;
            // 
            // LbRegAcc
            // 
            this.LbRegAcc.AutoSize = true;
            this.LbRegAcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LbRegAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LbRegAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbRegAcc.Location = new System.Drawing.Point(130, 449);
            this.LbRegAcc.Name = "LbRegAcc";
            this.LbRegAcc.Size = new System.Drawing.Size(440, 30);
            this.LbRegAcc.TabIndex = 9;
            this.LbRegAcc.Text = "Don\'t Have An Account Yet ? Register Here";
            this.LbRegAcc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LbRegAcc.Click += new System.EventHandler(this.LbRegAcc_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.AutoSize = true;
            this.BtnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.BtnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClear.Font = new System.Drawing.Font("Lucida Fax", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear.ForeColor = System.Drawing.Color.Snow;
            this.BtnClear.Location = new System.Drawing.Point(233, 388);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(200, 45);
            this.BtnClear.TabIndex = 5;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = false;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnLogin
            // 
            this.BtnLogin.AutoSize = true;
            this.BtnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.BtnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.Font = new System.Drawing.Font("Lucida Fax", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogin.ForeColor = System.Drawing.Color.Snow;
            this.BtnLogin.Location = new System.Drawing.Point(233, 333);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(200, 45);
            this.BtnLogin.TabIndex = 4;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // PicBxUser
            // 
            this.PicBxUser.Image = global::InventoryManagementSystem.Properties.Resources.UserOutlineBlack;
            this.PicBxUser.Location = new System.Drawing.Point(136, 163);
            this.PicBxUser.Name = "PicBxUser";
            this.PicBxUser.Size = new System.Drawing.Size(34, 34);
            this.PicBxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBxUser.TabIndex = 6;
            this.PicBxUser.TabStop = false;
            // 
            // PicBxPswrd
            // 
            this.PicBxPswrd.Image = global::InventoryManagementSystem.Properties.Resources.Lock;
            this.PicBxPswrd.Location = new System.Drawing.Point(136, 219);
            this.PicBxPswrd.Name = "PicBxPswrd";
            this.PicBxPswrd.Size = new System.Drawing.Size(34, 34);
            this.PicBxPswrd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBxPswrd.TabIndex = 5;
            this.PicBxPswrd.TabStop = false;
            // 
            // ChkBxPswrd
            // 
            this.ChkBxPswrd.AutoSize = true;
            this.ChkBxPswrd.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBxPswrd.Location = new System.Drawing.Point(202, 275);
            this.ChkBxPswrd.Name = "ChkBxPswrd";
            this.ChkBxPswrd.Size = new System.Drawing.Size(179, 32);
            this.ChkBxPswrd.TabIndex = 3;
            this.ChkBxPswrd.Text = "Show Password";
            this.ChkBxPswrd.UseVisualStyleBackColor = true;
            this.ChkBxPswrd.CheckedChanged += new System.EventHandler(this.ChkBxPswrd_CheckedChanged);
            // 
            // TxtBxPswrd
            // 
            this.TxtBxPswrd.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxPswrd.Location = new System.Drawing.Point(196, 219);
            this.TxtBxPswrd.Name = "TxtBxPswrd";
            this.TxtBxPswrd.ShortcutsEnabled = false;
            this.TxtBxPswrd.Size = new System.Drawing.Size(300, 34);
            this.TxtBxPswrd.TabIndex = 2;
            this.TxtBxPswrd.UseSystemPasswordChar = true;
            // 
            // TxtBxUsername
            // 
            this.TxtBxUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBxUsername.Location = new System.Drawing.Point(196, 163);
            this.TxtBxUsername.Name = "TxtBxUsername";
            this.TxtBxUsername.Size = new System.Drawing.Size(300, 34);
            this.TxtBxUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(255, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login Account";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PicBxProfile
            // 
            this.PicBxProfile.BackColor = System.Drawing.Color.DarkKhaki;
            this.PicBxProfile.Image = global::InventoryManagementSystem.Properties.Resources.UserBlueUI;
            this.PicBxProfile.Location = new System.Drawing.Point(304, 15);
            this.PicBxProfile.Name = "PicBxProfile";
            this.PicBxProfile.Size = new System.Drawing.Size(80, 80);
            this.PicBxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBxProfile.TabIndex = 0;
            this.PicBxProfile.TabStop = false;
            // 
            // LbHeading
            // 
            this.LbHeading.AutoSize = true;
            this.LbHeading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LbHeading.Font = new System.Drawing.Font("Maiandra GD", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbHeading.ForeColor = System.Drawing.Color.Bisque;
            this.LbHeading.Location = new System.Drawing.Point(180, 20);
            this.LbHeading.Name = "LbHeading";
            this.LbHeading.Size = new System.Drawing.Size(518, 34);
            this.LbHeading.TabIndex = 0;
            this.LbHeading.Text = "INVENTORY MANAGEMENT SYSTEM";
            this.LbHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(878, 644);
            this.Controls.Add(this.LbHeading);
            this.Controls.Add(this.Pnl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1Login";
            this.Text = "Login";
            this.Pnl1.ResumeLayout(false);
            this.Pnl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBxUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBxPswrd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Pnl1;
        private System.Windows.Forms.Label LbHeading;
        private System.Windows.Forms.PictureBox PicBxProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbRegAcc;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.PictureBox PicBxUser;
        private System.Windows.Forms.PictureBox PicBxPswrd;
        private System.Windows.Forms.TextBox TxtBxPswrd;
        private System.Windows.Forms.TextBox TxtBxUsername;
        private System.Windows.Forms.CheckBox ChkBxPswrd;
    }
}

