using System;
using System.Collections.Generic;

#nullable disable

namespace DentOffice.WebAPI.Database
{
    public partial class Dijagnoza
    {
        public Dijagnoza()
        {
            Pregleds = new HashSet<Pregled>();
        }

        public int DijagnozaId { get; set; }
        public string Naziv { get; set; }
        public string Napomena { get; set; }

        public virtual ICollection<Pregled> Pregleds { get; set; }
    }
}
