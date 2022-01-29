using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model
{
    public class Termin
    {
        public int TerminID { get; set; }
        public string Razlog { get; set; }
        public bool Hitno { get; set; }
        public bool Odobreno { get; set; }
        public DateTime DatumVrijeme { get; set; }

        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }
        public int UslugaId { get; set; }
        public Usluga Usluga { get; set; }
        public string UslugaNaziv { get; set; }

        public string Opis => $"{DatumVrijeme} ({(Odobreno ? "Odobren" : "Neodobren")})";
    }
}
