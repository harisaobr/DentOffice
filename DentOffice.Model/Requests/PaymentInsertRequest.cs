using System;
using System.Collections.Generic;
using System.Text;

namespace DentOffice.Model.Requests
{
    public class PaymentInsertRequest
    {
        public string Metoda { get; set; }
        public DateTime Datum { get; set; }
        public double Iznos { get; set; }
        public int KorisnikId { get; set; }
    }
}
