using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model
{
    public class Racun
    {
        public int RacunID { get; set; }
        public decimal UkupnaCijena { get; set; }
        public DateTime DatumIzdavanjaRacuna { get; set; }
        public bool IsPlaceno { get; set; }
    }
}
