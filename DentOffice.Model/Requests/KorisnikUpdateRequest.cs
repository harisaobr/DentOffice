using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class KorisnikUpdateRequest
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        [MinLength(2)]
        public string Prezime { get; set; }
        [Required]
        [MinLength(2)]
        public string KorisnickoIme { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string JMBG { get; set; }
        public byte[] Slika { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }

        public string DatumRodjenja { get; set; }

        public int? GradID{ get; set; }
        public Spol Spol { get; set; }

        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
