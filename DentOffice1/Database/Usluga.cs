using System;
using System.Collections.Generic;

#nullable disable

namespace DentOffice.WebAPI.Database
{
    public partial class Usluga
    {
        public Usluga()
        {
            Termins = new HashSet<Termin>();
        }

        public int UslugaId { get; set; }
        public string Naziv { get; set; }
        public double? Cijena { get; set; }

        public virtual ICollection<Termin> Termins { get; set; }

    }
}
