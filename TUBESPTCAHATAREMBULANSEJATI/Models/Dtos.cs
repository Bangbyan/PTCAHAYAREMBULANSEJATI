using System;
using System.Collections.Generic;

namespace TUBESPTCAHATAREMBULANSEJATI.Models
{
    public class LoginDto //dto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterDto //register
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<string>? Roles { get; set; }
    }

    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }

    public class Paket
    {
        public int Id { get; set; }
        public string NomerResi { get; set; } = string.Empty;
        public string Pengirim { get; set; } = string.Empty;
        public string Penerima { get; set; } = string.Empty;
        public string AlamatAsal { get; set; } = string.Empty;
        public string AlamatTujuan { get; set; } = string.Empty;
        public double BeratKg { get; set; }
        public string StatusPengiriman { get; set; } = string.Empty;
        public DateTime TanggalDikirm { get; set; }
        public DateTime? TanggalDiterima { get; set; }
        public string Kota { get; set; } = string.Empty;
        public decimal Biaya { get; set; }
    }
}
