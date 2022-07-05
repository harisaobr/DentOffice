using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class OcjeneSearchRequest
    {
        public int PacijentId { get; set; }
        public int KorisnikId { get; set; }
        public int MjesecOcjene { get; set; }
        public int GodinaOcjene { get; set; }
        public decimal Ocjena { get; set; }
        public string Komentar { get; set; }
    }
}
