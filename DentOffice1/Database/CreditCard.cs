using System;
using System.Collections.Generic;

#nullable disable

namespace DentOffice.WebAPI.Database
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            Payments = new HashSet<Payment>();
        }

        public int CreditCardId { get; set; }
        public int KorisnikId { get; set; }
        public string Ime { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
