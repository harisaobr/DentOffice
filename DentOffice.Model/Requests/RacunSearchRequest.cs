using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class RacunSearchRequest
    {
        public int RacunId { get; set; }
        public int KorisnikId { get; set; }
        public int PregledId { get; set; }
        public string ImePrezime { get; set; }
        public bool NijeUplatioRequest { get; set; }
        public int PacijentId { get; set; }
        public DateTime? DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }
    }
}
