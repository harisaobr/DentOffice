using System;
using System.Collections.Generic;

namespace DentOffice.Model
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public CreditCard CreditCard { get; set; }
        public int? CreditCardId { get; set; }
        public string Metoda { get; set; }
        public DateTime Datum { get; set; }
        public double Iznos { get; set; }
        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
    }
}
