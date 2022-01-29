using System;
using System.Collections.Generic;

#nullable disable

namespace DentOffice.WebAPI.Database
{
    public partial class Lijek
    {
        public Lijek()
        {
            Pregleds = new HashSet<Pregled>();
        }

        public int LijekId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Pregled> Pregleds { get; set; }
    }
}
