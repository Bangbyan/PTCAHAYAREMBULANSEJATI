using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TUBESPTCAHATAREMBULANSEJATI
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        public Form2()
        {
            InitializeComponent();
            instance = this;
        }

        private void tombolProsesLacak_Click(object sender, EventArgs e)
        {
            string nomorResi = inputKotakResi.Text.Trim();

            if (string.IsNullOrWhiteSpace(nomorResi))
            {
                MessageBox.Show("Silahkan masukkan nomor resi terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Dictionary<string, string> listPaket = new Dictionary<string, string>()
            {
                { "RESI123", "Paket sedang dibawa oleh kurir menuju lokasi Anda." },
                { "RESI456", "Paket telah diterima oleh [Bpk. Budi] di Jakarta Timur." },
                { "RESI789", "Paket Anda masih berada di Gudang Sortir Pusat (Hub)." }
            };

            if (listPaket.ContainsKey(nomorResi))
            {
                string statusPaket = listPaket[nomorResi];
                MessageBox.Show($"Nomor Resi: {nomorResi}\n\nStatus: {statusPaket}", "Hasil Pelacakan Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Maaf, nomor resi '{nomorResi}' tidak ditemukan. Periksa kembali nomor yang Anda masukkan.", "Resi Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tombolSilangKeluar_Click(object sender, EventArgs e)
        {
            DialogResult tanyaKeluar = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tanyaKeluar == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}