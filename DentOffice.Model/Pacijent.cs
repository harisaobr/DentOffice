using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model
{
    public class Pacijent
    {
        public int PacijentID { get; set; }
        public bool Proteza { get; set; }
        public bool Aparatic { get; set; }
        public bool Terapija { get; set; }
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }

        public override string ToString()
        {
            return Korisnik.Ime + " " + Korisnik.Prezime;
        }
    }
}
