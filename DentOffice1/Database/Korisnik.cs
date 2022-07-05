using System;
using System.Collections.Generic;

#nullable disable

namespace DentOffice.WebAPI.Database
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Pacijents = new HashSet<Pacijent>();
            Pregleds = new HashSet<Pregled>();
            Racuns = new HashSet<Racun>();
        }

        public int KorisnikId { get; set; }
        public int? GradId { get; set; }
        public int? UlogaId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public byte[] Slika { get; set; }
        public string Jmbg { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public string KorisnickoIme { get; set; }
        public Spol Spol { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual Uloga Uloga { get; set; }
        public virtual ICollection<Pacijent> Pacijents { get; set; }
        public virtual ICollection<Pregled> Pregleds { get; set; }
        public virtual ICollection<Racun> Racuns { get; set; }
        public virtual ICollection<Ocjene> Ocjenes { get; set; }

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
