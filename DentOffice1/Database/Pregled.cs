using System;
using System.Collections.Generic;

#nullable disable

namespace DentOffice.WebAPI.Database
{
    public partial class Pregled
    {
        public Pregled()
        {
            MedicinskiKartons = new HashSet<MedicinskiKarton>();
            Racuns = new HashSet<Racun>();
        }

        public int PregledId { get; set; }
        public int? KorisnikId { get; set; }
        public int? LijekId { get; set; }
        public int? TerminId { get; set; }
        public int? DijagnozaId { get; set; }
        public int? TrajanjePregleda { get; set; }
        public string Napomena { get; set; }

        public virtual Dijagnoza Dijagnoza { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual Lijek Lijek { get; set; }
        public virtual Termin Termin { get; set; }
        public virtual ICollection<MedicinskiKarton> MedicinskiKartons { get; set; }
        public virtual ICollection<Racun> Racuns { get; set; }
    }
}
