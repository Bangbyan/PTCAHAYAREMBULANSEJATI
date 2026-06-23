using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using TUBESPTCAHATAREMBULANSEJATI.Services;
using TUBESPTCAHATAREMBULANSEJATI.Models;

namespace TUBESPTCAHATAREMBULANSEJATI.Forms
{
    public class MainDashboardForm : Form
    {
        private DataGridView gridPakets;
        private Button btnRefresh;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnLogout;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label lblTitle;
        private Label lblRole;

        public MainDashboardForm()
        {
            InitializeUI();
            this.Load += MainDashboardForm_Load;
        }

        private void InitializeUI()
        {
            this.Text = "Dashboard - PT CAHAYA REMBULAN SEJATI";
            this.Size = new Size(850, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.Navy
            };

            lblTitle = new Label
            {
                Text = "Data Paket",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 15),
                AutoSize = true
            };

            lblRole = new Label
            {
                Text = $"Role: {ApiClient.Role}",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.LightGray,
                Location = new Point(200, 22),
                AutoSize = true
            };

            btnLogout = new Button
            {
                Text = "Logout",
                Location = new Point(740, 15),
                BackColor = Color.Crimson,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnLogout.Click += BtnLogout_Click;

            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblRole);
            headerPanel.Controls.Add(btnLogout);

            btnRefresh = new Button
            {
                Text = "Refresh Data",
                Location = new Point(20, 80),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 100
            };
            btnRefresh.Click += BtnRefresh_Click;

            btnAdd = new Button
            {
                Text = "+ Tambah Paket",
                Location = new Point(130, 80),
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 120
            };
            btnAdd.Click += BtnAdd_Click;

            btnEdit = new Button
            {
                Text = "Edit Paket",
                Location = new Point(260, 80),
                BackColor = Color.Orange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 100
            };
            btnEdit.Click += BtnEdit_Click;

            btnDelete = new Button
            {
                Text = "Hapus Paket",
                Location = new Point(370, 80),
                BackColor = Color.Crimson,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 100
            };
            btnDelete.Click += BtnDelete_Click;

            txtSearch = new TextBox
            {
                Location = new Point(540, 85),
                Width = 180,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            
            btnSearch = new Button
            {
                Text = "Cari Resi",
                Location = new Point(730, 80),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 80,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnSearch.Click += BtnSearch_Click;

            gridPakets = new DataGridView
            {
                Location = new Point(20, 120),
                Width = 790,
                Height = 420,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White
            };

            // RBAC Logic
            if (ApiClient.Role == "Kurir")
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnEdit.Location = new Point(130, 80);
            }
            else if (ApiClient.Role == "User")
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }

            this.Controls.Add(headerPanel);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnDelete);
            this.Controls.Add(txtSearch);
            this.Controls.Add(btnSearch);
            this.Controls.Add(gridPakets);
        }

        private async void MainDashboardForm_Load(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void BtnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Text = "";
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var pakets = await ApiClient.GetPaketsAsync();
                gridPakets.DataSource = pakets;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async void BtnSearch_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                await LoadDataAsync();
                return;
            }

            var paket = await ApiClient.GetPaketByResiAsync(txtSearch.Text);
            if (paket != null)
            {
                gridPakets.DataSource = new List<Paket> { paket };
            }
            else
            {
                MessageBox.Show("Paket tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridPakets.DataSource = new List<Paket>();
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var form = new PackageManageForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = LoadDataAsync();
            }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (gridPakets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih paket yang akan diedit.");
                return;
            }

            var selectedRow = gridPakets.SelectedRows[0];
            var paket = selectedRow.DataBoundItem as Paket;
            if (paket != null)
            {
                var form = new PackageManageForm(paket);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadDataAsync();
                }
            }
        }

        private async void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (gridPakets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih paket yang akan dihapus.");
                return;
            }

            var selectedRow = gridPakets.SelectedRows[0];
            var paket = selectedRow.DataBoundItem as Paket;

            if (paket != null && MessageBox.Show("Apakah Anda yakin ingin menghapus paket ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var result = await ApiClient.DeletePaketAsync(paket.Id);
                if (result.Success)
                {
                    MessageBox.Show("Paket berhasil dihapus.");
                    await LoadDataAsync();
                }
                else
                {
                    MessageBox.Show(result.Message, "Error");
                }
            }
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            ApiClient.ClearAuth();
            var loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
