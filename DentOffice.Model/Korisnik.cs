using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model
{
    public class Korisnik
    {
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string JMBG { get; set; }
        public byte[] Slika { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public Spol Spol { get; set; }


        public int GradID { get; set; }
        public Grad Grad { get; set; }

        public int ObavljenoPregleda { get; set; }
        public Uloga Uloga { get; set; }
        public int UlogaID { get; set; }
        public ICollection<Pacijent_Data> Pacijents { get; set; }
        public decimal? MojaOcjena { get; set; }

        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }

    public enum Spol
    {
        Muško, Žensko
    }
}
