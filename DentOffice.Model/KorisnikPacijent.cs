using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model
{
    public class KorisnikPacijent
    {
        public int? GradId { get; set; }
        public Grad Grad { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public byte[] Slika { get; set; }
        public string Jmbg { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string KorisnickoIme { get; set; }
        public Spol Spol { get; set; }

        public Uloga Uloga { get; set; }
        public int UlogaID { get; set; }

        public Pacijent Pacijent { get; set; }
        public int PacijentID { get; set; }

        public int KorisnikID { get; set; }
        public Korisnik Korisnici { get; set; }
        public bool Proteza { get; set; }
        public bool Aparatic { get; set; }
        public bool Terapija { get; set; }
    }
}
