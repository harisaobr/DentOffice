using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class KorisniciPacijentInsertRequest
    {
        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string Ime { get; set; }

        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string Prezime { get; set; }

        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string KorisnickoIme { get; set; }

        [StringLength(320)]
        [Required(AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Pogrešan unos email adrese!")]
        public string Email { get; set; }

        [StringLength(30)]
        [Required(AllowEmptyStrings = false)]
        public string BrojTelefona { get; set; }

        [StringLength(200)]
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Adresa { get; set; }

        [Required]
        public DateTime DatumRodjenja { get; set; }

        [StringLength(13, MinimumLength = 13, ErrorMessage = "JMBG mora da ima 13 brojeva!")]
        [Required]
        public string JMBG { get; set; }

        public byte[] Slika { get; set; }
        [Required]
        public int GradId { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string PasswordConfirm { get; set; }

        public bool Proteza { get; set; }

        public bool Terapija { get; set; }

        public bool Aparatic { get; set; }
        public Spol Spol { get; set; }
    }
}
