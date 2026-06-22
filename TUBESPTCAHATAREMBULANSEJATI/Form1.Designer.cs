namespace TUBESPTCAHATAREMBULANSEJATI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelLeft = new Panel();
            lblWelcome = new Label();
            panelRight = new Panel();
            lblClose = new Label();
            lblLogin = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(30, 115, 190);
            panelLeft.Controls.Add(lblWelcome);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(280, 450);
            panelLeft.TabIndex = 1;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(40, 150);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(218, 90);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome to the\r\nService Management\r\nSystem";
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.White;
            panelRight.Controls.Add(lblClose);
            panelRight.Controls.Add(lblLogin);
            panelRight.Controls.Add(txtUsername);
            panelRight.Controls.Add(txtPassword);
            panelRight.Controls.Add(btnLogin);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(280, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(520, 450);
            panelRight.TabIndex = 0;
            // 
            // lblClose
            // 
            lblClose.AutoSize = true;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblClose.Location = new Point(485, 10);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(20, 21);
            lblClose.TabIndex = 0;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 12F);
            lblLogin.Location = new Point(120, 100);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(161, 21);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "Login to your account";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(120, 150);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 27);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(120, 200);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 27);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(30, 115, 190);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(120, 250);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(120, 35);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOGIN";
            MouseDown += Form1_MouseDown;
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}
