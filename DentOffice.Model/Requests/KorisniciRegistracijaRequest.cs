using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class KorisniciRegistracijaRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Ime { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Prezime { get; set; }

        [Required(AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Pogrešan unos email adrese!")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string KorisnickoIme { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "JMBG mora da ima 13 brojeva!")]
        public string JMBG { get; set; }

        [Required]
        public DateTime DatumRodjenja { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string BrojTelefona { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string Adresa { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string PasswordPotvrda { get; set; }

        
        public byte[] Slika { get; set; }

        [Required]
        public int GradId { get; set; }


        [Required]
        public bool Proteza { get; set; }

        [Required]
        public bool Terapija { get; set; }


        [Required]
        public bool Aparatic { get; set; }
    }
}
