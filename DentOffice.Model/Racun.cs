using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model
{
    public class Racun
    {
        public int RacunId { get; set; }
        public int? KorisnikId { get; set; }
        public int? PregledId { get; set; }
        public double? UkupnaCijena { get; set; }
        public DateTime? DatumIzdavanjaRacuna { get; set; }
        public bool? IsPlaceno { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Pregled Pregled { get; set; }
        public string UkupnaCijenaFormatted => UkupnaCijena?.ToString("0.00") ?? "";
    }
}
