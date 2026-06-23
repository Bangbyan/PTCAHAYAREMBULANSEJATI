using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using TUBESPTCAHATAREMBULANSEJATI.Services;
using TUBESPTCAHATAREMBULANSEJATI.Models;

namespace TUBESPTCAHATAREMBULANSEJATI.Forms
{
    public class TrackingForm : Form
    {
        private TextBox txtNomerResi;
        private Button btnTrack;
        private Button btnBack;
        private Label lblMessage;

        // Details Panel
        private Panel pnlResult;
        private Label lblResiVal;
        private Label lblPengirimVal;
        private Label lblPenerimaVal;
        private Label lblTujuanVal;
        private Label lblBeratVal;
        private Label lblBiayaVal;
        private Label lblTglKirimVal;
        private Label lblTglTerimaVal;

        // Timeline controls
        private Panel pnlPending;
        private Panel pnlDiproses;
        private Panel pnlDikirim;
        private Panel pnlSelesai;
        
        private Label lblPending;
        private Label lblDiproses;
        private Label lblDikirim;
        private Label lblSelesai;

        private Label lblBatalBadge;

        public TrackingForm()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Lacak Paket - PT CAHAYA REMBULAN SEJATI";
            this.Size = new Size(600, 580);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;

            // Title
            Label lblTitle = new Label
            {
                Text = "LACAK PAKET",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Navy,
                Location = new Point(220, 20),
                AutoSize = true
            };

            // Input section
            Label lblInput = new Label
            {
                Text = "Masukkan Nomor Resi:",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(50, 70),
                AutoSize = true
            };

            txtNomerResi = new TextBox
            {
                Location = new Point(50, 95),
                Width = 350,
                Font = new Font("Segoe UI", 11)
            };

            btnTrack = new Button
            {
                Text = "Cari",
                Location = new Point(415, 93),
                Width = 130,
                Height = 32,
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnTrack.Click += BtnTrack_Click;

            lblMessage = new Label
            {
                Location = new Point(50, 130),
                Width = 495,
                ForeColor = Color.Red,
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                Visible = false
            };

            // Result Panel
            pnlResult = new Panel
            {
                Location = new Point(30, 160),
                Width = 530,
                Height = 320,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };

            InitializeResultPanel();

            // Back button
            btnBack = new Button
            {
                Text = "Kembali ke Login",
                Location = new Point(220, 495),
                Width = 160,
                Height = 35,
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnBack.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblInput);
            this.Controls.Add(txtNomerResi);
            this.Controls.Add(btnTrack);
            this.Controls.Add(lblMessage);
            this.Controls.Add(pnlResult);
            this.Controls.Add(btnBack);
        }

        private void InitializeResultPanel()
        {
            // Info Header
            Label lblResi = new Label { Text = "No. Resi:", Location = new Point(20, 20), Font = new Font("Segoe UI", 9, FontStyle.Bold), AutoSize = true };
            lblResiVal = new Label { Location = new Point(120, 20), Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.DodgerBlue, AutoSize = true };

            Label lblPengirim = new Label { Text = "Pengirim:", Location = new Point(20, 50), AutoSize = true };
            lblPengirimVal = new Label { Location = new Point(120, 50), AutoSize = true };

            Label lblPenerima = new Label { Text = "Penerima:", Location = new Point(20, 80), AutoSize = true };
            lblPenerimaVal = new Label { Location = new Point(120, 80), AutoSize = true };

            Label lblTujuan = new Label { Text = "Kota Tujuan:", Location = new Point(20, 110), AutoSize = true };
            lblTujuanVal = new Label { Location = new Point(120, 110), AutoSize = true };

            Label lblBerat = new Label { Text = "Berat:", Location = new Point(280, 50), AutoSize = true };
            lblBeratVal = new Label { Location = new Point(380, 50), AutoSize = true };

            Label lblBiaya = new Label { Text = "Biaya:", Location = new Point(280, 80), AutoSize = true };
            lblBiayaVal = new Label { Location = new Point(380, 80), AutoSize = true };

            Label lblTglKirim = new Label { Text = "Tgl Kirim:", Location = new Point(280, 110), AutoSize = true };
            lblTglKirimVal = new Label { Location = new Point(380, 110), AutoSize = true };

            Label lblTglTerima = new Label { Text = "Tgl Terima:", Location = new Point(280, 140), AutoSize = true };
            lblTglTerimaVal = new Label { Location = new Point(380, 140), AutoSize = true };

            // Divider Line
            Panel divider = new Panel
            {
                Location = new Point(20, 175),
                Width = 490,
                Height = 2,
                BackColor = Color.LightGray
            };

            // Timeline Header
            Label lblStatusHeader = new Label
            {
                Text = "Status Pengiriman:",
                Location = new Point(20, 190),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true
            };

            lblBatalBadge = new Label
            {
                Text = "DIBATALKAN",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.Crimson,
                ForeColor = Color.White,
                Location = new Point(390, 188),
                Size = new Size(120, 25),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };

            // Setup circles for timeline
            pnlPending = CreateCirclePanel(50, 240);
            pnlDiproses = CreateCirclePanel(170, 240);
            pnlDikirim = CreateCirclePanel(290, 240);
            pnlSelesai = CreateCirclePanel(410, 240);

            // Connectors
            Panel line1 = CreateLinePanel(75, 250, 95);
            Panel line2 = CreateLinePanel(195, 250, 95);
            Panel line3 = CreateLinePanel(315, 250, 95);

            // Labels
            lblPending = new Label { Text = "Pending", Location = new Point(30, 275), Width = 70, TextAlign = ContentAlignment.MiddleCenter };
            lblDiproses = new Label { Text = "Diproses", Location = new Point(150, 275), Width = 70, TextAlign = ContentAlignment.MiddleCenter };
            lblDikirim = new Label { Text = "Dikirim", Location = new Point(270, 275), Width = 70, TextAlign = ContentAlignment.MiddleCenter };
            lblSelesai = new Label { Text = "Selesai", Location = new Point(390, 275), Width = 70, TextAlign = ContentAlignment.MiddleCenter };

            pnlResult.Controls.Add(lblResi);
            pnlResult.Controls.Add(lblResiVal);
            pnlResult.Controls.Add(lblPengirim);
            pnlResult.Controls.Add(lblPengirimVal);
            pnlResult.Controls.Add(lblPenerima);
            pnlResult.Controls.Add(lblPenerimaVal);
            pnlResult.Controls.Add(lblTujuan);
            pnlResult.Controls.Add(lblTujuanVal);
            pnlResult.Controls.Add(lblBerat);
            pnlResult.Controls.Add(lblBeratVal);
            pnlResult.Controls.Add(lblBiaya);
            pnlResult.Controls.Add(lblBiayaVal);
            pnlResult.Controls.Add(lblTglKirim);
            pnlResult.Controls.Add(lblTglKirimVal);
            pnlResult.Controls.Add(lblTglTerima);
            pnlResult.Controls.Add(lblTglTerimaVal);
            
            pnlResult.Controls.Add(divider);
            pnlResult.Controls.Add(lblStatusHeader);
            pnlResult.Controls.Add(lblBatalBadge);

            // Timeline graphics
            pnlResult.Controls.Add(line1);
            pnlResult.Controls.Add(line2);
            pnlResult.Controls.Add(line3);
            pnlResult.Controls.Add(pnlPending);
            pnlResult.Controls.Add(pnlDiproses);
            pnlResult.Controls.Add(pnlDikirim);
            pnlResult.Controls.Add(pnlSelesai);
            pnlResult.Controls.Add(lblPending);
            pnlResult.Controls.Add(lblDiproses);
            pnlResult.Controls.Add(lblDikirim);
            pnlResult.Controls.Add(lblSelesai);
        }

        private Panel CreateCirclePanel(int x, int y)
        {
            var pnl = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(24, 24),
                BackColor = Color.LightGray
            };
            // Circle border effect via paint
            pnl.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddEllipse(0, 0, pnl.Width - 1, pnl.Height - 1);
                    pnl.Region = new Region(path);
                }
            };
            return pnl;
        }

        private Panel CreateLinePanel(int x, int y, int width)
        {
            return new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, 4),
                BackColor = Color.LightGray
            };
        }

        private async void BtnTrack_Click(object? sender, EventArgs e)
        {
            lblMessage.Visible = false;
            pnlResult.Visible = false;

            if (string.IsNullOrWhiteSpace(txtNomerResi.Text))
            {
                ShowError("Masukkan nomor resi terlebih dahulu.");
                return;
            }

            btnTrack.Enabled = false;
            btnTrack.Text = "Mencari...";

            var paket = await ApiClient.GetPaketByResiAsync(txtNomerResi.Text.Trim());

            if (paket != null)
            {
                DisplayTrackingResult(paket);
            }
            else
            {
                ShowError("Nomor resi tidak ditemukan. Pastikan nomor yang dimasukkan benar.");
            }

            btnTrack.Enabled = true;
            btnTrack.Text = "Cari";
        }

        private void DisplayTrackingResult(Paket paket)
        {
            lblResiVal.Text = paket.NomerResi;
            lblPengirimVal.Text = paket.Pengirim;
            lblPenerimaVal.Text = paket.Penerima;
            lblTujuanVal.Text = paket.Kota;
            lblBeratVal.Text = $"{paket.BeratKg} Kg";
            lblBiayaVal.Text = $"Rp {paket.Biaya:N0}";
            lblTglKirimVal.Text = paket.TanggalDikirm.ToString("dd MMM yyyy HH:mm");
            lblTglTerimaVal.Text = paket.TanggalDiterima.HasValue ? paket.TanggalDiterima.Value.ToString("dd MMM yyyy HH:mm") : "-";

            // Update status timeline colors
            ResetTimelineColors();

            string status = paket.StatusPengiriman;
            lblBatalBadge.Visible = (status == "Batal");

            if (status == "Pending")
            {
                SetStatusActive(pnlPending, lblPending, Color.Orange);
            }
            else if (status == "Diproses")
            {
                SetStatusActive(pnlPending, lblPending, Color.DodgerBlue);
                SetStatusActive(pnlDiproses, lblDiproses, Color.Orange);
            }
            else if (status == "Dikirim")
            {
                SetStatusActive(pnlPending, lblPending, Color.DodgerBlue);
                SetStatusActive(pnlDiproses, lblDiproses, Color.DodgerBlue);
                SetStatusActive(pnlDikirim, lblDikirim, Color.Orange);
            }
            else if (status == "Selesai")
            {
                SetStatusActive(pnlPending, lblPending, Color.SeaGreen);
                SetStatusActive(pnlDiproses, lblDiproses, Color.SeaGreen);
                SetStatusActive(pnlDikirim, lblDikirim, Color.SeaGreen);
                SetStatusActive(pnlSelesai, lblSelesai, Color.SeaGreen);
            }
            else if (status == "Batal")
            {
                // Gray out all, but highlight Batal badge
                SetStatusActive(pnlPending, lblPending, Color.Crimson);
            }

            pnlResult.Visible = true;
        }

        private void ResetTimelineColors()
        {
            Color gray = Color.LightGray;
            Color textGray = Color.DarkGray;

            pnlPending.BackColor = gray;
            pnlDiproses.BackColor = gray;
            pnlDikirim.BackColor = gray;
            pnlSelesai.BackColor = gray;

            lblPending.ForeColor = textGray;
            lblPending.Font = new Font(lblPending.Font, FontStyle.Regular);
            lblDiproses.ForeColor = textGray;
            lblDiproses.Font = new Font(lblDiproses.Font, FontStyle.Regular);
            lblDikirim.ForeColor = textGray;
            lblDikirim.Font = new Font(lblDikirim.Font, FontStyle.Regular);
            lblSelesai.ForeColor = textGray;
            lblSelesai.Font = new Font(lblSelesai.Font, FontStyle.Regular);
        }

        private void SetStatusActive(Panel pnl, Label lbl, Color color)
        {
            pnl.BackColor = color;
            lbl.ForeColor = color;
            lbl.Font = new Font(lbl.Font, FontStyle.Bold);
        }

        private void ShowError(string message)
        {
            lblMessage.Text = message;
            lblMessage.Visible = true;
        }
    }
}
