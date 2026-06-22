namespace TUBESPTCAHATAREMBULANSEJATI
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSampingBiru = new System.Windows.Forms.Panel();
            this.txtLabelInfoKiri = new System.Windows.Forms.Label();
            this.txtLabelJudulUtama = new System.Windows.Forms.Label();
            this.inputKotakResi = new System.Windows.Forms.TextBox();
            this.tombolProsesLacak = new System.Windows.Forms.Button();
            this.tombolSilangKeluar = new System.Windows.Forms.Label();
            this.pnlSampingBiru.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSampingBiru
            // 
            this.pnlSampingBiru.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(114)))), ((int)(((byte)(195)))));
            this.pnlSampingBiru.Controls.Add(this.txtLabelInfoKiri);
            this.pnlSampingBiru.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSampingBiru.Location = new System.Drawing.Point(0, 0);
            this.pnlSampingBiru.Name = "pnlSampingBiru";
            this.pnlSampingBiru.Size = new System.Drawing.Size(280, 500);
            this.pnlSampingBiru.TabIndex = 0;
            // 
            // txtLabelInfoKiri
            // 
            this.txtLabelInfoKiri.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLabelInfoKiri.ForeColor = System.Drawing.Color.White;
            this.txtLabelInfoKiri.Location = new System.Drawing.Point(40, 160);
            this.txtLabelInfoKiri.Name = "txtLabelInfoKiri";
            this.txtLabelInfoKiri.Size = new System.Drawing.Size(220, 150);
            this.txtLabelInfoKiri.TabIndex = 0;
            this.txtLabelInfoKiri.Text = "Silahkan Lacak\r\nPaket kalian";
            // 
            // txtLabelJudulUtama
            // 
            this.txtLabelJudulUtama.AutoSize = true;
            this.txtLabelJudulUtama.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLabelJudulUtama.ForeColor = System.Drawing.Color.Black;
            this.txtLabelJudulUtama.Location = new System.Drawing.Point(400, 120);
            this.txtLabelJudulUtama.Name = "txtLabelJudulUtama";
            this.txtLabelJudulUtama.Size = new System.Drawing.Size(193, 25);
            this.txtLabelJudulUtama.TabIndex = 1;
            this.txtLabelJudulUtama.Text = "LACAK PAKET KALIAN";
            // 
            // inputKotakResi
            // 
            this.inputKotakResi.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputKotakResi.Location = new System.Drawing.Point(397, 170);
            this.inputKotakResi.Name = "inputKotakResi";
            this.inputKotakResi.Size = new System.Drawing.Size(300, 32);
            this.inputKotakResi.TabIndex = 2;
            // 
            // tombolProsesLacak
            // 
            this.tombolProsesLacak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(114)))), ((int)(((byte)(195)))));
            this.tombolProsesLacak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tombolProsesLacak.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tombolProsesLacak.ForeColor = System.Drawing.Color.White;
            this.tombolProsesLacak.Location = new System.Drawing.Point(397, 240);
            this.tombolProsesLacak.Name = "tombolProsesLacak";
            this.tombolProsesLacak.Size = new System.Drawing.Size(145, 45);
            this.tombolProsesLacak.TabIndex = 3;
            this.tombolProsesLacak.Text = "LACAK";
            this.tombolProsesLacak.UseVisualStyleBackColor = false;
            this.tombolProsesLacak.Click += new System.EventHandler(this.tombolProsesLacak_Click);
            // 
            // tombolSilangKeluar
            // 
            this.tombolSilangKeluar.AutoSize = true;
            this.tombolSilangKeluar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tombolSilangKeluar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tombolSilangKeluar.Location = new System.Drawing.Point(760, 15);
            this.tombolSilangKeluar.Name = "tombolSilangKeluar";
            this.tombolSilangKeluar.Size = new System.Drawing.Size(24, 25);
            this.tombolSilangKeluar.TabIndex = 4;
            this.tombolSilangKeluar.Text = "X";
            this.tombolSilangKeluar.Click += new System.EventHandler(this.tombolSilangKeluar_Click);
            // 
            // FormLacak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.tombolSilangKeluar);
            this.Controls.Add(this.tombolProsesLacak);
            this.Controls.Add(this.inputKotakResi);
            this.Controls.Add(this.txtLabelJudulUtama);
            this.Controls.Add(this.pnlSampingBiru);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLacak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLacak";
            this.pnlSampingBiru.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlSampingBiru;
        private System.Windows.Forms.Label txtLabelInfoKiri;
        private System.Windows.Forms.Label txtLabelJudulUtama;
        private System.Windows.Forms.TextBox inputKotakResi;
        private System.Windows.Forms.Button tombolProsesLacak;
        private System.Windows.Forms.Label tombolSilangKeluar;
    }
}