using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class RacunInsertRequest
    {
        [Required]
        public int KorisnikId { get; set; }
        [Required]
        public int PregledId { get; set; }

        public double UkupnaCijena { get; set; }
        public DateTime DatumIzdavanjaRacuna { get; set; }
        public bool IsPlaceno { get; set; }
    }
}
