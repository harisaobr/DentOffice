using System;
using System.Collections.Generic;

#nullable disable

namespace DentOffice.WebAPI.Database
{
    public partial class Pacijent
    {
        public Pacijent()
        {
            MedicinskiKartons = new HashSet<MedicinskiKarton>();
            Termins = new HashSet<Termin>();
        }

        public int PacijentId { get; set; }
        public int? KorisnikId { get; set; }
        public bool? Proteza { get; set; }
        public bool? Aparatic { get; set; }
        public bool? Terapija { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual ICollection<MedicinskiKarton> MedicinskiKartons { get; set; }
        public virtual ICollection<Termin> Termins { get; set; }
        public virtual ICollection<Ocjene> Ocjenes { get; set; }
    }
}
