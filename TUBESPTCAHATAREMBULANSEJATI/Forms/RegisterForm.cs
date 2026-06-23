using System;
using System.Drawing;
using System.Windows.Forms;
using TUBESPTCAHATAREMBULANSEJATI.Services;

namespace TUBESPTCAHATAREMBULANSEJATI.Forms
{
    public class RegisterForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private ComboBox cmbRole;
        private Button btnRegister;
        private LinkLabel lnkLogin;
        private Label lblMessage;

        public RegisterForm()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Register - PT CAHAYA REMBULAN SEJATI";
            this.Size = new Size(400, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Label lblTitle = new Label
            {
                Text = "REGISTER",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(130, 20),
                AutoSize = true
            };

            Label lblUsername = new Label { Text = "Username:", Location = new Point(50, 70) };
            txtUsername = new TextBox { Location = new Point(50, 90), Width = 280 };

            Label lblEmail = new Label { Text = "Email:", Location = new Point(50, 130) };
            txtEmail = new TextBox { Location = new Point(50, 150), Width = 280 };

            Label lblPassword = new Label { Text = "Password:", Location = new Point(50, 190) };
            txtPassword = new TextBox { Location = new Point(50, 210), Width = 280, UseSystemPasswordChar = true };

            Label lblRole = new Label { Text = "Role:", Location = new Point(50, 250) };
            cmbRole = new ComboBox
            {
                Location = new Point(50, 270),
                Width = 280,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRole.Items.AddRange(new string[] { "User", "Admin", "Kurir" });
            cmbRole.SelectedIndex = 0;

            btnRegister = new Button
            {
                Text = "Register",
                Location = new Point(50, 320),
                Width = 280,
                Height = 35,
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnRegister.Click += BtnRegister_Click;

            lnkLogin = new LinkLabel
            {
                Text = "Already have an account? Login.",
                Location = new Point(100, 370),
                AutoSize = true
            };
            lnkLogin.LinkClicked += LnkLogin_LinkClicked;

            lblMessage = new Label
            {
                Location = new Point(50, 50),
                Width = 280,
                ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(lblRole);
            this.Controls.Add(cmbRole);
            this.Controls.Add(btnRegister);
            this.Controls.Add(lnkLogin);
            this.Controls.Add(lblMessage);
        }

        private async void BtnRegister_Click(object? sender, EventArgs e)
        {
            lblMessage.Visible = false;
            btnRegister.Enabled = false;

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || 
                string.IsNullOrWhiteSpace(txtEmail.Text) || 
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowMessage("All fields are required.", Color.Red);
                btnRegister.Enabled = true;
                return;
            }

            var result = await ApiClient.RegisterAsync(txtUsername.Text, txtEmail.Text, txtPassword.Text, cmbRole.Text);
            
            if (result.Success)
            {
                MessageBox.Show("Registration successful! You can now login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                ShowMessage(result.Message, Color.Red);
                btnRegister.Enabled = true;
            }
        }

        private void LnkLogin_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void ShowMessage(string message, Color color)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = color;
            lblMessage.Visible = true;
        }
    }
}
