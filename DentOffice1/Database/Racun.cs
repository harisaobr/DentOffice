using System;
using System.Collections.Generic;

#nullable disable

namespace DentOffice.WebAPI.Database
{
    public partial class Racun
    {
        public int RacunId { get; set; }
        public int? KorisnikId { get; set; }
        public int? PregledId { get; set; }
        public double? UkupnaCijena { get; set; }
        public DateTime? DatumIzdavanjaRacuna { get; set; }
        public bool? IsPlaceno { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Pregled Pregled { get; set; }
    }
}
