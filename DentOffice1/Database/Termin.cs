using System;
using System.Collections.Generic;

#nullable disable

namespace DentOffice.WebAPI.Database
{
    public partial class Termin
    {
        public Termin()
        {
            Pregleds = new HashSet<Pregled>();
        }

        public int TerminId { get; set; }
        public int PacijentId { get; set; }
        public int UslugaId { get; set; }
        public string Razlog { get; set; }
        public bool? Hitno { get; set; }
        public bool Odobreno { get; set; }
        public DateTime Datum { get; set; }

        public virtual Pacijent Pacijent { get; set; }
        public virtual Usluga Usluga { get; set; }
        public virtual ICollection<Pregled> Pregleds { get; set; }
    }
}
